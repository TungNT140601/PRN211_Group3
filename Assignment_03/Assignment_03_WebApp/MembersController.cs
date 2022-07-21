using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_03_WebApp.Models;
using Assignment_03_Library.DataAccess;
using Assignment_03_Library.Repositories;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Localization;
using Assignment_03_WebApp.Helpers;
using System.IO;
using System.Collections.Generic;

namespace Assignment_03_WebApp
{
    public class MembersController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        IMemberRepository memberRepository = null;
        public MembersController()
        {
            this.memberRepository = new MemberRepository();
        }
        private Member AdminAccount()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            Member admin = new Member
            {
                MemberId = 0,
                Email = config["AdminAccount:Email"],
                City = "",
                CompanyName = "",
                Country = "",
                Password = config["AdminAccount:Password"]
            };
            return admin;
        }
        // GET: MembersController
        public ActionResult Index()
        {
            List<Member> memList = null;
            Member mem = (Member)HttpContext.Session.GetObjectFromJson<Member>("Member");
            if (mem == null)
            {
                return View("Login");
            }
            else if (mem.Email != AdminAccount().Email)
            {
                memList = new List<Member>();
                memList.Add(mem);
                return View(memList);
            }
            var memList1 = memberRepository.GetMembers();
            return View(memList1);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberById(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        // GET: MembersController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: MembersController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (email == null)
                {
                    ViewData["Message"] = "Please input email";
                    return View("Login");
                }
                else if (password == null)
                {
                    ViewData["Message"] = "Please input password";
                    return View("Login");
                }
                else
                {
                    Member admin = AdminAccount();
                    if (email == admin.Email && password == admin.Password)
                    {
                        HttpContext.Session.SetObjectAsJson("Member", admin);
                        return View("/Views/Home/Index.cshtml");
                    }
                    else if (memberRepository.CheckLogin(email, password) != null)
                    {
                        HttpContext.Session.SetObjectAsJson("Member", (memberRepository.CheckLogin(email, password)));
                        return View("/Views/Home/Index.cshtml");
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View();
            }
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            Member mem = (Member)HttpContext.Session.GetObjectFromJson<Member>("Member");
            if (mem == null)
            {
                return View("Login");
            }
            else if (mem.Email != AdminAccount().Email)
            {
                ViewBag.PopUp = "You cannot access this function!!!!";
                return View("/Views/Home/Index.cshtml");
            }
            return NotFound();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.Add(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int? id)
        {
            Member mem = (Member)HttpContext.Session.GetObjectFromJson<Member>("Member");
            if (mem == null)
            {
                return View("Login");
            }
            else if (mem.Email != AdminAccount().Email)
            {
                ViewBag.PopUp = "You cannot access this function!!!!";
                return View("/Views/Home/Index.cshtml");
            }
            else if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberById(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                if (id != member.MemberId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    memberRepository.Update(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(int? id)
        {
            Member mem = (Member)HttpContext.Session.GetObjectFromJson<Member>("Member");
            if (mem == null)
            {
                return View("Login");
            }
            else if (mem.Email != AdminAccount().Email)
            {
                ViewBag.PopUp = "You cannot access this function!!!!";
                return View("/Views/Home/Index.cshtml");
            }
            else if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberById(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Member member)
        {
            try
            {
                memberRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
