using Arvind.Contract;
using Arvind.EmailService;
using Arvind.Entities.Model;
using Arvind.Entities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

using System.Threading.Tasks;

namespace Arvind.WebApp.Controllers
{
    public class SecureController : Controller
    {
        private readonly IRepositoryWrapper repository;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILoggerManager logger;
        private readonly IEmailSender emailSender;

        public SecureController(IRepositoryWrapper repository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILoggerManager logger,IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repository = repository;
            this.logger = logger;
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserCreateVM model)
        {
            if (ModelState.IsValid)
            {
                //--Add Identity User--//
                var user = new AppUser { Email = model.Email, UserName = model.Email, FullName = model.EmployeeName };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    repository.Employee.CreateUser(model);
                    repository.Save();
                    long id = repository.Employee.FindByCondition(x => x.Email.Equals(model.Email)).FirstOrDefault().Id;

                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Secure", new { token, email = user.Email }, Request.Scheme);
                    var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink, null);
                    bool ismailsend=emailSender.SendEmail1(message);

                    var res = await userManager.AddToRoleAsync(user, "Staff");
                    if (res.Succeeded)
                    {
                        // return RedirectToAction("ListUser");
                        return RedirectToAction(nameof(SuccessRegistration));
                    }
                    else
                    {
                        foreach (var error in res.Errors)
                        {
                            logger.LogError(String.Format("Error Code: {0} - Description: {1} for CreateUser:Action at Secure:Controller", error.Code, error.Description));
                            ModelState.TryAddModelError(error.Code, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        logger.LogError(String.Format("Error Code: {0} - Description: {1} for CreateUser:Action at Secure:Controller", error.Code, error.Description));
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                }

            }

            ModelState.TryAddModelError("", "Please enter valid input!");
            logger.LogError(String.Format("Model Not Valid {0} for CreateUser:Action at Secure:Controller", ModelState.IsValid.ToString()));


            ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");
            var result = await userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl=null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.Msg = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            ViewBag.Msg = "";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ViewBag.Msg = "Entered email address not found!";
                    //return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }
            

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Secure", new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            bool res=emailSender.SendEmail1(message);

            if (res)
            {
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            else
            {
                ViewBag.Msg = "Email not send due to some technical issue! Please try again later.";
            }
            }
            catch { }
            return View(model);
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordVM { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReConfirmEmail()
        {
            ViewBag.Msg = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReConfirmEmail(ForgotPasswordVM model)
        {
            ViewBag.Msg = "";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ViewBag.Msg = "Entered email address not found!";
                    //return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }


                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Secure", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email }, "Re-Confirmation email link", confirmationLink, null);
                bool res = emailSender.SendEmail1(message);

                if (res)
                {
                    return RedirectToAction(nameof(SuccessRegistration));
                }
                else
                {
                    ViewBag.Msg = "Email not send due to some technical issue! Please try again later.";
                }
            }
            catch { }
            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.StatusMessage = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                ViewBag.StatusMessage = "Error Occured. Please validate your input!";
                return View();
            }

            await signInManager.RefreshSignInAsync(user);

            ViewBag.StatusMessage = "Your password has been changed.";

            
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            ViewBag.StatusMessage = "";
            return View();
        }
    }
}
