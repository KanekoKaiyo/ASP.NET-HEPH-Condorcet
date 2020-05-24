using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeacherParadise.DAL;
using TeacherParadise.Models;
using TeacherParadise.Models.DAL;
using TeacherParadise.Models.POCO;
/* 
Projet scolaire HEPH Condorcet 2019-2020
Made by Simon Jonathan & Mikel Rousseaux  
*/
namespace TeacherParadise.Controllers {
    public class HomeController:Controller {
        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // My Controller
        // Dal Loader
        private readonly IProfesseurDAL _professeurDAL;
        private readonly IEleveDal _eleveDal;
        public HomeController(IProfesseurDAL professeurDal, IEleveDal eleveDal) {
            _professeurDAL = professeurDal;
            _eleveDal = eleveDal;
        }
        // IActionResult
        public IActionResult Index() {
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("UserType"))) {
                HttpContext.Session.SetString("UserType","Nothings");
            }
            return View();
        }
        public IActionResult TeacherLogin() {
            TempData["Error"] = false;
            return View();
        }
        
        [HttpPost]
        public IActionResult TeacherLogin(CProfesseur professeur) {
            CProfesseur prof = professeur.VerifProfesseur(professeur,_professeurDAL);
            if(prof == null) {
                TempData["Error"] = true;
                return View(professeur);
            } else {
                HttpContext.Session.SetString("UserType","Professeur");
                HttpContext.Session.SetInt32("IDP",prof.ID);
                return RedirectToAction("Index","Teacher");
            }
            
        }
        public IActionResult StudentLogin()
        {
            TempData["Error"] = false;
            return View();
        }
        [HttpPost]
        public IActionResult StudentLogin(CEleve eleve)
        {
            CEleve eleves = eleve.VerifEleve(eleve, _eleveDal);
            if (eleves == null)
            {
                TempData["Error"] = true;
                return View(eleve);
            }
            else
            {
                HttpContext.Session.SetString("UserType", "Eleve");
                HttpContext.Session.SetInt32("IDE", eleves.ID);

                return RedirectToAction("Index", "Student");
            }

        }

        public IActionResult TeacherInscription() {
            TempData["Error"] = "Empty";
            return View();
        }
        [HttpPost]
        public IActionResult TeacherInscription(CProfesseur professeur) {
            // Vérification de l'inscription de l'utilisateur : 1) vérifie si le model est correcte 2) vérifie si cella est possible en appelant une méthode de la classe poco qui appel la classe dal ( voir commentaire dans les autres fichiers pour plus de détails )
            if(ModelState.IsValid) {
                //TODO Modifier le mot de passe pour le sécurisé avant de le mettre dans la base de donnée !!!!!
                CProfesseur prof = professeur.AjoutProfesseur(professeur,_professeurDAL);
                if(prof == null) {
                    // Création du compte impossible car l'email est déjà utilisé
                    TempData["Error"] = "Email";
                    return View(professeur);
                } else {
                    HttpContext.Session.SetString("UserType","Professeur");
                    HttpContext.Session.SetInt32("IDP",prof.ID);
                    return RedirectToAction("Index","Teacher");
                }
            } else {
                TempData["Error"] = "Error";
                return View(professeur);
            }
        }
        public IActionResult StudentInscription()
        {
            TempData["Error"] = "Empty";
            return View();
        }
        [HttpPost]
        public IActionResult StudentInscription(CEleve eleve)
        {
            if (ModelState.IsValid)
            {
                CEleve eleves = eleve.AjoutEleve(eleve, _eleveDal);
                if (eleves == null)
                {
                    TempData["Error"] = "Email";
                    return View(eleve);
                }
                else
                {
                    HttpContext.Session.SetString("UserType", "Eleve");
                    HttpContext.Session.SetInt32("IDE", eleve.ID);
                    return RedirectToAction("Index", "Student");
                }
            }
            else
            {
                TempData["Error"] = "Error";
                return View(eleve);
            }
        }
    }
}