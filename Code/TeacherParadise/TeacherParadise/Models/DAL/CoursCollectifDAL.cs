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
            List<CCoursCollectif> cours = Where(cr => cr.Professeur.ID.Equals(ID)).ToList();
            if(cours == null)
                return null;
            else
                return cours;
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
