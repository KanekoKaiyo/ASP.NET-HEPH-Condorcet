using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherParadise.DAL;

namespace TeacherParadise.Models.DAL {
    public class CoursCollectifDAL : ICoursCollectifDAL {
        private readonly ParadiseContext _context;
        public CoursCollectifDAL(ParadiseContext context) {
            this._context = context;
        }

        public List<CCoursCollectif> GetAllCours(int ID) {
            // Fonction qui renvoie une liste de tout les cours Collectifs du professeur en utilsant son ID
            List<CCoursCollectif> cours = Where(cr => cr.Professeur.ID.Equals(ID)).OrderBy(cr => cr.Date).ToList();
            if(cours == null)
                return null;
            else
                return cours;
        }

        public CCoursCollectif AddCours(CCoursCollectif cours) {
            // Fonction qui ajoute un cours dans la base de donnée, vérifions si il est possible d'ajouter un cours à cette heure la !

            CCoursCollectif crs = Where(cr => cr.Date.Date.Equals(cours.Date.Date) && cr.StartHour.Hour.Equals(cours.StartHour.Hour)).FirstOrDefault();

            if(crs == null) {
                // Si il n'a pas de cours à cette heure la on l'ajoute
                _context.CoursCollectifs.Add(cours);
                _context.SaveChanges();
                return cours;
            } else {
                return null;
            }

        }

        public CCoursCollectif GetCour(int ID) {
            //Fonction qui renvoie un cours de la base de donné via son ID

            CCoursCollectif crs = Where(cr => cr.ID.Equals(ID)).FirstOrDefault();

            if(crs == null) {
                // erreur survenu, bizarre d'aileurs si ça arrive 
                return null;
            } else {
                return crs;
            }
        }
        public bool DeleteCoursCollectif(CCoursCollectif cours) {
            _context.Remove(cours);
            int temp = _context.SaveChanges();

            if (temp != 0) {
                // Si le nombre de ligne modifié est différent de 0 on renvoie true
                return true;
            } else {
                // si non on renvoie false
                return false;
            }
        }

        public CCoursCollectif ModifyCour(CCoursCollectif cours, int ID) {
            cours.ID = ID;
            _context.Update(cours);
            int temp = _context.SaveChanges();

            if(temp != 0) {
                return cours;
            } else {
                return null;
            }
        }


        // Substitution de la fonction Where qui permet de rechercher dans la base de donnée si un (ou des) enregistrement existe ou non en donnant un paramètre à rechercher
        private IEnumerable<CCoursCollectif> Where(params Expression<Func<CCoursCollectif,bool>>[] predicates) {
            IQueryable<CCoursCollectif> query = _context.CoursCollectifs;
            foreach(var predicate in predicates) {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
    }
}
