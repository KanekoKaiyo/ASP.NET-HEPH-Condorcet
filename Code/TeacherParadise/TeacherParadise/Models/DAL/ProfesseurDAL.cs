using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherParadise.DAL;

namespace TeacherParadise.Models.DAL {
    public class ProfesseurDAL:IProfesseurDAL {

        private readonly ParadiseContext _context;
        public ProfesseurDAL(ParadiseContext context) {
            this._context = context;
        }
        public CProfesseur AddProfesseur(CProfesseur professeur) {
            // Fonction d'ajout dans la base de donnée, vérifie si l'email fournis existe déjà dans la base de donnée, si oui, renvoie null, si non renvoie 
            CProfesseur prof = Where(pr => pr.Email.Equals(professeur.Email)).FirstOrDefault();
                                 
            if(prof == null) {
                _context.Professeurs.Add(professeur);
                _context.SaveChanges();
                return professeur;
            } else {
                return null;
            }
        }

        public CProfesseur VerifProfesseur(CProfesseur professeur) {
            // Fonction de vérification pour le login, si l'email ET le mot de passe sont présent et correspondent bien dans la base de donnée
            CProfesseur prof = Where(pr => pr.Email.Equals(professeur.Email) && pr.Password.Equals(professeur.Password)).FirstOrDefault();
            if(prof == null) {
                return null; // Combinnaisson email/mot de passe non trouvé
            } else {
                return prof;
            }
        }

        public CProfesseur GetProfByID(int? ID) {
            return Where(pr => pr.ID.Equals(ID)).FirstOrDefault();
        }
        //private CProfesseur GetProfesseurByEmail(string email) {
        //    return _context.Professeurs.Where(professeur => professeur.Email.Equals(email)).FirstOrDefault();
        //}

        // Substitution de la fonction Where qui permet de rechercher dans la base de donnée si un (ou des) enregistrement existe ou non en donnant un paramètre à rechercher
        private IEnumerable<CProfesseur> Where(params Expression<Func<CProfesseur,bool>>[] predicates) {
            IQueryable<CProfesseur> query = _context.Professeurs;
            foreach(var predicate in predicates) {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
    }
}
