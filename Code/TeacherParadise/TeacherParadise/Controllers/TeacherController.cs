using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TeacherParadise.Models;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Controllers
{
    public class TeacherController : Controller
    {
        // My Controller
        // Dal Loader
        private readonly ICoursCollectifDAL _coursCollectifDAL;
        public TeacherController(ICoursCollectifDAL coursCollectifDAL) {
            _coursCollectifDAL = coursCollectifDAL;
        }
        private bool VerifSession() {
            if(HttpContext.Session.GetString("UserType") != "Professeur")
                return true;
            else
                return false;
        }
        public IActionResult Index() {
            if(VerifSession())
                return RedirectToAction("Index","Home");
            return View();
        }

        public IActionResult ListCourCollectif() {
            if(VerifSession())
                return RedirectToAction("Index","Home");
            int ID = HttpContext.Session.GetInt32("IDP").GetValueOrDefault();
            List<CCoursCollectif> cours = CCoursCollectif.GetAllCours(ID,_coursCollectifDAL);
            if(cours == null) {
                TempData["CoursC"] = null;
            } else {
                TempData["CoursC"] = cours;
            }
            return View();
        }
        public IActionResult AfficheConge() {
            if(VerifSession())
                return RedirectToAction("Index","Home");
            return View();
        }
        public IActionResult MonProfil() {
            if(VerifSession())
                return RedirectToAction("Index","Home");
            return View();
        }
        public IActionResult AjoutCourCollectif() {
            if(VerifSession())
                return RedirectToAction("Index","Home");
            return View();
        }
        public IActionResult Deconnexion() {
            HttpContext.Session.SetString("UserType","Nothings");
            return RedirectToAction("Index","Home");
        }
    }
}