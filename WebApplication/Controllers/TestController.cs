﻿using TestingSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.Statistic;
using WebApplication.Models.Test;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository testRepository;
        private readonly IStatisticRepository statisticRepository;
        private readonly IUserRepository userRepository;
        private readonly IPassTestService passTestService;

        public TestController(ITestRepository testRepository, IStatisticRepository statisticRepository, 
            IUserRepository userRepository, IPassTestService passTestService)
        {
            this.testRepository = testRepository;
            this.statisticRepository = statisticRepository;
            this.userRepository = userRepository;
            this.passTestService = passTestService;
        }

        public ActionResult Index()
        {
            IEnumerable<PreviewTestViewModel> tests;
            if (User.IsInRole("admin"))
            {
                tests = testRepository.GetAll().Select(t => t.ToPreviewTestViewModel());
            }
            else
            {
                tests = testRepository.GetAllReady().Select(t => t.ToPreviewTestViewModel());
            }
            return View(tests);
        }

        public ActionResult Preview(int id)
        {
            PreviewTestViewModel test = testRepository.GetById(id).ToPreviewTestViewModel();
            if (!test.IsReady)
            {
                return View("NotReadyTest");
            }
            string message = "";
            if (User.Identity.IsAuthenticated)
            {
                int userId = userRepository.GetByLogin(User.Identity.Name).Id;
                
            }
            ViewBag.Message = message;
            return View(test);
        }

        public ActionResult SearchTest(string keyWord)
        {
            IEnumerable<PreviewTestViewModel> tests;
            if (User.IsInRole("admin"))
            {
                tests = testRepository.SearchAllTestsByKeyWord(keyWord).Select(t => t.ToPreviewTestViewModel());
            }
            else
            {
                tests = testRepository.SearchAllReadyTestsByKeyWord(keyWord).Select(t => t.ToPreviewTestViewModel());
            }
            if(Request.IsAjaxRequest())
                return PartialView("_Tests", tests);
            return View("_Tests", tests);
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ActionResult PassTest(int id)
        {
            PassTestViewModel test = testRepository.GetById(id).ToPassTestViewModel();
            if (!test.IsReady)
            {
                return View("NotReadyTest");
            }
            return View(test);
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        [ActionName("PassTest")]
        public ActionResult PassedTest(PassTestViewModel passTestModel)
        {
            int userId = userRepository.GetByLogin(User.Identity.Name).Id;
            passTestModel.UserId = userId;
            passTestService.PassTest(passTestModel.ToPassTestModel());
            return RedirectToAction("TestResult", "Statistic", new { userId = userId, testId = passTestModel.Id });
        }

        
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View("CreateTest");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ActionName("Create")]
        public ActionResult Created(TestViewModel test)
        {
            if (ModelState.IsValid)
            {
                testRepository.Create(test.ToTest());
                int testId = testRepository.GetByName(test.Name).Id;
                return RedirectToAction("Details", "Test", new { id = testId });
            }
            return View("Create");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            TestViewModel test = testRepository.GetById(id).ToTestViewModel();
            return View("EditTest", test);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ActionName("Edit")]
        public ActionResult Edited(TestViewModel test)
        {
            if (ModelState.IsValid)
            {
                testRepository.Update(test.ToTest());
                return RedirectToAction("Details", "Test", new { id = test.Id });
            }
            return View("EditTest", test);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            TestViewModel test = testRepository.GetById(id).ToTestViewModel();
            return View("DeleteTest", test);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ActionName("Delete")]
        public ActionResult Deleted(TestViewModel test)
        {
            testRepository.Delete(test.ToTest());
            return RedirectToAction("Index", "Test");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            TestViewModel test = testRepository.GetById(id).ToTestViewModel();
            return View("DetailsTest", test);
        }
    }
}