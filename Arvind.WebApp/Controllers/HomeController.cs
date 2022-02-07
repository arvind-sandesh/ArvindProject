using Arvind.Contract;
using Arvind.EmailService;
using Arvind.Entities;
using Arvind.Entities.Model;
using Arvind.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Arvind.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager loggerManager;
        private readonly IEmailSender emailSender;

        public HomeController(IRepositoryWrapper repositoryWrapper, ILoggerManager loggerManager, IEmailSender emailSender)
        {

            this._repository = repositoryWrapper;
            this.loggerManager = loggerManager;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            //List<Institute> lst = _repository.Institute.FindAll().ToList();//  _repository.Institute.FindByCondition(x=>x.InstituteName.Contains("bc")).ToList();
            //Institute inst = await _repository.Institute.GetInstituteWithDetailAsync(1);

            //ViewBag.lst = lst;
            //ViewBag.inst = inst;
            //loggerManager.LogInfo("Bind Record from institute Table");          

            //var message = new Message(new string[] { "arvind.monu@gmail.com","arvind.coolhunk@gmail.com" }, "Test email async from arvind core app test", "<h2>This is the content from our async email.</h2><p>Test email async from arvind core app test</p>", null);
            //bool res=emailSender.SendEmail1(message);
            //ViewBag.EmailSend = "email sending failed";
            //if (res)
            //{
            //    ViewBag.EmailSend = "email send successfully.";
            //}

            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddInst()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInst(Institute model)
        {
            if (ModelState.IsValid)
            {
                _repository.Institute.Create(model);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error occured.");
            }

            return View(model);
        }
    }
}
