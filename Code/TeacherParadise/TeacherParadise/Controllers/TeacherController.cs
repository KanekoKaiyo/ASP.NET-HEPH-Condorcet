﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeacherParadise.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        public IActionResult EditProfil() {
            return View();
        }
        public IActionResult AjoutCourCollectif() {
            return View();
        }
    }
}