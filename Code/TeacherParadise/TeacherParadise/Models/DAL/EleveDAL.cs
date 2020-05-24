using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherParadise.DAL;
using TeacherParadise.Models.POCO;

namespace TeacherParadise.Models.DAL
{
    public class EleveDAL: IEleveDal
    {
        private readonly ParadiseContext _context;
        public EleveDAL(ParadiseContext context)
        {
            this._context = context;
        }
        public CEleve AddEleve(CEleve eleve)
        {
            // check de l'email, si présent on renvoie null sinon on ajoute 
            CEleve el = Where(ele => ele.Email.Equals(eleve.Email)).FirstOrDefault();

            if (el == null)
            {
                _context.Eleves.Add(eleve);
                _context.SaveChanges();
                return eleve;
            }
            else
            {
                return null;
            }
        }

        public CEleve VerifEleve(CEleve eleve)
        {
            // check des log-in et mail pour vérifier que ce soit valide. SI non concordance : NULL
            CEleve el = Where(ele => ele.Email.Equals(eleve.Email) && ele.Password.Equals(eleve.Password)).FirstOrDefault();
            if (el == null)
            {
                return null; 
            }
            else
            {
                return el;
            }
        }

        public CEleve ModifyProfil(CEleve eleve, int? ID)
        {
            eleve.ID = (int)ID;
            _context.Update(eleve);
            int temp = _context.SaveChanges();

            if (temp != 0)
            {
                return eleve;
            }
            else
            {
                return null;
            }
        }

        public CEleve GetEleveByID(int? ID)
        {
            return Where(el => el.ID.Equals(ID)).FirstOrDefault();
        }
                   
        
        private IEnumerable<CEleve> Where(params Expression<Func<CEleve, bool>>[] predicates) //méthode de substitution pour le where
        {
            IQueryable<CEleve> query = _context.Eleves;
            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }

        public CEleve ChangerNvEtude(string niveauetude)
        {
            CEleve eleve = _context.Eleves.FirstOrDefault(el => el.NiveauEtude == niveauetude);
            _context.Update(niveauetude);
            int temp = _context.SaveChanges();

            if (temp != 0)
            {
                return eleve;
            }
            else
            {
                return null;
            }
            //return Where(el => el.ID.NiveauEtude).FirstOrDefault;
        }
    }
}

