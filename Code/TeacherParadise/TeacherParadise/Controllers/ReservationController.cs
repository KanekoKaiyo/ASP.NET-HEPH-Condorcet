using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TeacherParadise.Models;
using TeacherParadise.Models.DAL;
using System.Runtime.InteropServices.WindowsRuntime;
namespace TeacherParadise.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICoursCollectifDAL _coursCollectifDAL;
        private readonly IEleveDal eleveDal;
        private readonly List<CatCoursCollectif> catCoursCollectifs;
        public ReservationController(ICoursCollectifDAL coursCollectifDAL,IProfesseurDAL professeurDAL,ICongeDAL congeDAL) {
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

        

        public IActionResult Deconnexion() {
            HttpContext.Session.SetString("UserType","Nothings");
            return RedirectToAction("Index","Home");
        }
    }
}