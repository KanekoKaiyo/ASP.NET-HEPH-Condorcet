using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TeacherParadise.Models;
using TeacherParadise.Models.DAL;
using System.Runtime.InteropServices.WindowsRuntime;
using TeacherParadise.Models.POCO;

namespace TeacherParadise.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICoursCollectifDAL _coursCollectifDAL;
        private readonly IEleveDal _elevedal;

        public StudentController(ICoursCollectifDAL coursCollectifDAL,IEleveDal EleveDal) {
            _coursCollectifDAL = coursCollectifDAL;
            _elevedal = EleveDal;
        }
        private bool VerifSession() {
            if(HttpContext.Session.GetString("UserType") != "Eleve")
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
            int ID = HttpContext.Session.GetInt32("IDE").GetValueOrDefault();
            CatCoursCollectif cours = CatCoursCollectif.Instance(ID,_coursCollectifDAL);
            TempData["CoursC"] = cours;
            return View();
        }


        [HttpPost]
        
        public IActionResult MonProfil() {
            if(VerifSession())
                return RedirectToAction("Index","Home");

            CEleve eleve = new CEleve();
            int? ID = HttpContext.Session.GetInt32("IDE");
            eleve = eleve.GetEleveByID(ID,_elevedal);
            TempData["Eleve"] = eleve;
            return View();
        }

        public IActionResult ModifyProfil() {
            if(VerifSession())
                return RedirectToAction("Index","Home");

            CEleve eleve = new CEleve();
            int? ID = HttpContext.Session.GetInt32("IDE");
            eleve = eleve.GetEleveByID(ID,_elevedal);
            TempData["Eleve"] = eleve;
            return View();
        }

        [HttpPost]
        public IActionResult ModifyProfil(CEleve eleve_) {
            if(VerifSession())
                return RedirectToAction("Index","Home");

            CEleve eleve = new CEleve();
            int? ID = HttpContext.Session.GetInt32("IDE");

            eleve = eleve.ModifierProfil(eleve_,ID,_elevedal);
            if(eleve == null) {
                TempData["Error"] = true;
                return View(eleve_);
            } else {
                return RedirectToAction("MonProfil");
            }

        }
        
        public IActionResult Deconnexion() {
            HttpContext.Session.SetString("UserType","Nothings");
            return RedirectToAction("Index","Home");
        }
    }
}