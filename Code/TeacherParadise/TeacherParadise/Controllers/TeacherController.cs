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
    public class TeacherController : Controller
    {
        // My Controller
        // Dal Loader
        private readonly ICoursCollectifDAL _coursCollectifDAL;
        private readonly IProfesseurDAL _professeurDAL;
        public TeacherController(ICoursCollectifDAL coursCollectifDAL,IProfesseurDAL professeurDAL) {
            _coursCollectifDAL = coursCollectifDAL;
            _professeurDAL = professeurDAL;
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
            CatCoursCollectif cours = CatCoursCollectif.Instance(ID,_coursCollectifDAL);
            //List<CCoursCollectif> cours = CCoursCollectif.GetAllCours(ID,_coursCollectifDAL);
            TempData["CoursC"] = cours;
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
            TempData["Error"] = false;
            TempData["Success"] = false;
            return View();
        }
        [HttpPost]
        public IActionResult AjoutCourCollectif(CCoursCollectif cours) {
            if(VerifSession())
                return RedirectToAction("Index","Home");

            // Vérification que le model est valide
            if(ModelState.IsValid) {
                // Vérification que la date du cours est postérieur, donc on peut prévoir un cours pour le lendemain, pas pour le jour même ou les jours précédents
                if(cours.Date.Date < DateTime.Now.Date) {
                    TempData["Error"] = true;
                    return View(cours);
                } else {
                    // Avant d'ajouté le cours dans la DB il faut recuperer l'objet professeur dans la DB
                    CProfesseur prof = new CProfesseur();
                    int? ID = HttpContext.Session.GetInt32("IDP");
                    // On ajoute l'objet professeur dans l'objet cours, enfin la référence
                    cours.Professeur = prof.GetProfByID(ID, _professeurDAL);
                    // On tente l'ajout dans la db 
                    CCoursCollectif cours_ = cours.AddCours(cours,_coursCollectifDAL);

                    if(cours_ == null) {
                        // Création impossible car la date et l'heure est déjà prise
                        TempData["Error"] = true;
                        return View(cours);
                    } else {
                        // On ajoute l'element dans le singleton si il a bien était ajouté dans la base de donnée
                        CatCoursCollectif Catcours = CatCoursCollectif.Instance();
                        Catcours.Add(cours_);
                        return RedirectToAction("ListCourCollectif");
                    }
                }
            } else {
                // Si une autre erreur est survenue, par exemple si la validation du formulaire client est désactivé
                TempData["Error"] = true;
                return View(cours);
            }
        }
        
        public IActionResult DeleteCoursCollectif(int id) {
            if(VerifSession())
                return RedirectToAction("Index","Home");

            CCoursCollectif cours = CCoursCollectif.GetCour(id,_coursCollectifDAL);
            bool test = cours.DeleteCoursCollectif(cours,_coursCollectifDAL);
            if (test == true) {
                CatCoursCollectif Catcours = CatCoursCollectif.Instance();
                Catcours.Remove(cours);
                return RedirectToAction("ListCourCollectif");
            } else {
                TempData["Error"] = true;
                return RedirectToAction("ListCourCollectif");
            }
        }
        public IActionResult ModifierCoursCollectif(int id) {
            if(VerifSession())
                return RedirectToAction("Index","Home");

            CCoursCollectif cours = CCoursCollectif.GetCour(id,_coursCollectifDAL);
            TempData["CoursC"] = cours;
            HttpContext.Session.SetInt32("IDModifyCour",id);
            return View();
        }
        [HttpPost]
        public IActionResult ModifierCoursCollectif(CCoursCollectif cours) {
            if(VerifSession())
                return RedirectToAction("Index","Home");
            int ID = HttpContext.Session.GetInt32("IDModifyCour").GetValueOrDefault();
            CCoursCollectif cours_ = cours.ModifyCour(cours,ID,_coursCollectifDAL);
            if(cours_ == null) {
                TempData["Error"] = true;
                return View(cours);
            } else {
                CatCoursCollectif Catcours = CatCoursCollectif.Instance();
                Catcours.Remove(cours);
                Catcours.Add(cours_);
            }
            return RedirectToAction("ListCourCollectif");
        }

        public IActionResult Deconnexion() {
            HttpContext.Session.SetString("UserType","Nothings");
            return RedirectToAction("Index","Home");
        }
    }
}