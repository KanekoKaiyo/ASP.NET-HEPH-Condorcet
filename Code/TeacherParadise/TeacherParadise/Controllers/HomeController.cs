using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeacherParadise.DAL;
using TeacherParadise.Models;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Controllers {
    public class HomeController:Controller {
        public IActionResult Index() {
            TempData["User"] = "Nothing";
            return View();
        }
        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error() {
            TempData["User"] = "Nothing";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // My Controller
        private readonly IProfesseurDAL _professeurDAL;
        public HomeController(IProfesseurDAL professeurDal) {
            _professeurDAL = professeurDal;
        }

        public IActionResult TeacherInscription() {
            // First Time User arrive
            TempData["User"] = "Nothing";
            return View();
        }

        [HttpPost]
        public IActionResult TeacherAdded(CProfesseur professeur) {
            TempData["User"] = "Nothing";
            // Vérification de l'inscription de l'utilisateur : 1) vérifie si le model est correcte 2) vérifie si cella est possible en appelant une méthode de la classe poco qui appel la classe dal ( voir commentaire dans les autres fichiers pour plus de détails )
            if(ModelState.IsValid) {
                CProfesseur prof = professeur.AjoutProfesseur(professeur,_professeurDAL);
                if(prof == null) {
                    // Création du compte impossible car l'email est déjà utilisé
                    TempData["Error"] = "Email";
                    return RedirectToAction(nameof(TeacherInscription));
                } else {
                    TempData["Success"] = true;
                    TempData["Session"] = prof;
                    return View();
                }
            } else {
                TempData["Error"] = "Error";
                return RedirectToAction(nameof(TeacherInscription));
            }

            //if(ModelState.IsValid) {
            //    TempData["Success"] = true;
            //    TempData["Session"] = professeur;
            //    return View();
            //} else {
            //    return RedirectToAction(nameof(TeacherInscription));
            //}
        }
    }
}