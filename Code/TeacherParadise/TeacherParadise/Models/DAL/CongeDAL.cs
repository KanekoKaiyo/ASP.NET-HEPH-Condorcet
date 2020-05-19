using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherParadise.DAL;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.Models.DAL {
    public class CongeDAL:ICongeDAL {
        private readonly ParadiseContext _context;
        public CongeDAL(ParadiseContext context) {
            this._context = context;
        }
        public CConge GetConge(int ID) {
            // renvoie un seul congé avec son ID
            CConge conge = Where(con => con.ID.Equals(ID)).FirstOrDefault();
            if(conge == null)
                return null;
            else
                return conge;
        }
        public List<CConge> GetConges(int? ID) {
            // Fonction qui renvoie la liste de tout les congé du professeur en utilisant son ID
            List<CConge> conge = Where(con => con.Professeur.ID.Equals(ID)).OrderBy(con => con.DateDebut).ToList();
            if(conge == null)
                return null;
            else
                return conge;
        }
        public CConge AddConge(CConge conge) {
            CConge conge_ = Where(con => con.DateDebut.Equals(conge.DateDebut) || con.DateFin.Equals(conge.DateFin)).FirstOrDefault();

            if(conge_ == null) {
                _context.Conges.Add(conge);
                _context.SaveChanges();
                return conge;
            } else {
                return null;
            }
        }
        public bool DeleteConge(CConge conge) {
            _context.Remove(conge);
            int temp = _context.SaveChanges();

            if(temp != 0)
                return true;
            else
                return false;
        }



        // Substitution de la fonction Where qui permet de rechercher dans la base de donnée si un (ou des) enregistrement existe ou non en donnant un paramètre à rechercher
        private IEnumerable<CConge> Where(params Expression<Func<CConge,bool>>[] predicates) {
            IQueryable<CConge> query = _context.Conges;
            foreach(var predicate in predicates) {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
    }
}
