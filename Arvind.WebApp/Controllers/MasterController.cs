using Arvind.Contract;
using Arvind.Entities.Model;
using Arvind.Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arvind.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class MasterController : Controller
    {
        private readonly IRepositoryWrapper repository;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILoggerManager logger;
        private readonly RoleManager<IdentityRole> roleManager;

        public MasterController(IRepositoryWrapper repository,
                                UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                ILoggerManager logger,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repository = repository;
            this.logger = logger;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //-----User------//
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

                    var res = await userManager.AddToRoleAsync(user, "Staff");
                    if (res.Succeeded)
                    {
                        return RedirectToAction("ListUser");
                    }
                    else
                    {
                        foreach (var error in res.Errors)
                        {
                            logger.LogError(String.Format("Error Code: {0} - Description: {1} for CreateUser:Action at Master:Controller", error.Code, error.Description));
                            ModelState.TryAddModelError(error.Code, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        logger.LogError(String.Format("Error Code: {0} - Description: {1} for CreateUser:Action at Master:Controller", error.Code, error.Description));
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                }

            }

            ModelState.TryAddModelError("", "Please enter valid input!");
            logger.LogError(String.Format("Model Not Valid {0} for CreateUser:Action at Master:Controller", ModelState.IsValid.ToString()));


            ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName");
            return View(model);
        }

        [HttpGet]
        public IActionResult ListUser()
        {
            List<Employee> empList = new List<Employee>();
            ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName");
            return View(empList);
        }

        [HttpPost]
        public IActionResult ListUser(long id)
        {
            List<Employee> empList = repository.Employee.UserListOfInstitute(id);
            ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName", id);
            return View(empList);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(long id)
        {
            ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName");

            var emp = repository.Employee.FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ErrorMsg = $"User with id = {id} cannot be found.";
                return View("NotFound");
            }
            var user = await userManager.FindByNameAsync(emp.Email);
            var userRoles = await userManager.GetRolesAsync(user);
            var model = new UserEditVM
            {
                Id = emp.Id,
                DateOfBirth = emp.DateOfBirth,
                Email = emp.Email,
                EmployeeName = emp.EmployeeName,
                Gender = emp.Gender,
                InstituteId = emp.InstituteId,
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(UserEditVM model)
        {
            if (ModelState.IsValid)
            {
                ViewData["InstituteId"] = new SelectList(repository.Institute.FindAll().ToList(), "Id", "InstituteName");

                var emp = repository.Employee.FindByCondition(x => x.Id.Equals(model.Id)).FirstOrDefault();

                if (emp == null)
                {
                    ViewBag.ErrorMsg = $"User with id = {model.Id} cannot be found.";
                    return View("NotFound");
                }
                emp.DateOfBirth = model.DateOfBirth;
                //emp.Email = model.Email;
                emp.EmployeeName = model.EmployeeName.ToUpper();
                emp.Gender = model.Gender;
                emp.InstituteId = model.InstituteId;
                repository.Employee.Update(emp);
                repository.Save();
                return RedirectToAction("ListUser");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var emp = repository.Employee.FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ErrorMsg = $"User with id = {id} cannot be found.";
                return View("NotFound");
            }
            var user = await userManager.FindByEmailAsync(emp.Email);
            if (user == null)
            {
                ViewBag.ErrorMsg = $"User with id = {id} cannot be found.";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var res = await userManager.DeleteAsync(user);
                    if (res.Succeeded)
                    {
                        repository.Employee.Delete(emp);
                        repository.Save();
                    }
                    else
                    {
                        ViewBag.ErrorTitle = $"{user.UserName} in is use.";
                        ViewBag.ErrorMsg = $"{user.UserName} can not be deleted.";
                        return View("Error");
                    }
                }
                catch (Exception err)
                {
                    ViewBag.ErrorTitle = $"{user.UserName} in is use.";
                    ViewBag.ErrorMsg = $"{user.UserName} can not be deleted. If you want to delete this user, please remove the roles from the user and then try to delete. "+err.Message;
                    return View("Error");
                }


            }


            return RedirectToAction("ListUser");
        }


        [HttpGet]
        public async Task<IActionResult> ManageUserRole(long userId)
        {
            ViewBag.userId = userId;

            var emp = repository.Employee.FindByCondition(x => x.Id.Equals(userId)).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ErrorMsg = $"User with id = {userId} cannot be found.";
                return View("NotFound");
            }
            var user = await userManager.FindByNameAsync(emp.Email);

            var model = new List<UserRolesVM>();
            foreach (var role in roleManager.Roles)
            {
                var obj = new UserRolesVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    obj.IsSelected = true;
                }
                else
                {
                    obj.IsSelected = false;
                }

                model.Add(obj);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRole(List<UserRolesVM> model, long userId)
        {
            ViewBag.userId = userId;

            var emp = repository.Employee.FindByCondition(x => x.Id.Equals(userId)).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ErrorMsg = $"User with id = {userId} cannot be found.";
                return View("NotFound");
            }
            var user = await userManager.FindByNameAsync(emp.Email);
            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user from existing roles.");
                return View(model);
            }

            var res = await userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(x => x.RoleName));
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user.");
                return View(model);
            }

            return RedirectToAction("EditUser", new { id = userId });
        }
        //--------Role--------//
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRole()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMsg = $"Role with id = {id} cannot be found.";
                return View("NotFound");
            }
            var model = new EditRoleVM
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMsg = $"Role with id = {model.Id} cannot be found.";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var res = await roleManager.UpdateAsync(role);
                if (res.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                foreach (var err in res.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMsg = $"Role with id = {roleId} cannot be found.";
                return View("NotFound");
            }
            var model = new List<UserRoleVM>();
            foreach (var user in userManager.Users)
            {
                var usr = new UserRoleVM { UserId = user.Id, UserName = user.UserName };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    usr.IsSelected = true;
                }
                else
                {
                    usr.IsSelected = false;
                }
                model.Add(usr);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserRoleVM> model, string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMsg = $"Role with id = {roleId} cannot be found.";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                }
                else
                {
                    return RedirectToAction("EditRole", new { id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { id = roleId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMsg = $"Role with id = {id} cannot be found.";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var res = await roleManager.DeleteAsync(role);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("ListRole");
                    }
                    foreach (var err in res.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
                catch (Exception err)
                {
                    ViewBag.ErrorTitle = $"{role.Name} in is use.";
                    ViewBag.ErrorMsg = $"{role.Name} role can not be deleted as there are users in this role. If you want to delete this role, please remove the user from the role and then try to delete. " + err.Message;
                    return View("Error");
                }
            }
            return RedirectToAction("ListRole");
        }
    }
}
