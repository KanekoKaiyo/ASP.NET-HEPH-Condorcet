using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeacherParadise.Controllers
{   
    [Authorize]
    public class TeacherController : Controller
    {
        public IActionResult Index() {
            TempData["User"] = "Professeur";
            return View();
        }

        public IActionResult ListCourCollectif() {
            TempData["User"] = "Professeur";
            return View();
        }
        public IActionResult ListCourRemediation() {
            TempData["User"] = "Professeur";
            return View();
        }
        public IActionResult AfficheConge() {
            TempData["User"] = "Professeur";
            return View();
        }
        public IActionResult MonProfil() {
            TempData["User"] = "Professeur";
            return View();
        }
        public IActionResult Deconnexion() {
            // TODO gerer la déconnexion de l'utilisateur
            TempData["User"] = "Professeur";
            return RedirectToAction("Index","Home");
        }
        public IActionResult AjoutCourCollectif() {
            TempData["User"] = "Professeur";
            return View();
        }   
    }
}