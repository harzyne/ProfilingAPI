using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreAPI.Models;

namespace ScoreAPI.Controllers
{
    public class UserController : Controller
    {
        UserDataAccessLayer objemployee = new UserDataAccessLayer();

        public IActionResult Index()
        {
            List<User> lstUser = new List<User>();
            lstUser = objemployee.GetAllUsers().ToList();

            return View(lstUser);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] User employee)
        {
            if (ModelState.IsValid)
            {
                objemployee.AddUser(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

       
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User employee = objemployee.GetUserData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

       
    }
}