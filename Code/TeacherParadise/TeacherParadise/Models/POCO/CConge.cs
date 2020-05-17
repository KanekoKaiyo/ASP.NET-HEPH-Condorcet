using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Models {
    public class CConge {

        public int ID { get; set; }

        [Display(Name = "Début du congé")]
        [Required(ErrorMessage = "La date de début du congés est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [Display(Name = "Fin du congé")]
        [Required(ErrorMessage = "La date de fin du congés est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        public virtual CProfesseur Professeur { get; set; }

        public CConge() {
            //Constructeur vide pour Entity Framework
        }

        public CConge(DateTime dateDebut,DateTime dateFin, CProfesseur professeur) {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Professeur = professeur;
        }
        public static List<CConge> GetConges(int? ID, ICongeDAL congeDAL) {
            List<CConge> conge = congeDAL.GetConges(ID);
            if(conge == null)
                return null;
            else
                return conge;
        }
        public CConge AddConge(CConge conge,ICongeDAL congeDAL) {
            CConge conge_ = congeDAL.AddConge(conge);
            if(conge_ == null)
                return null;
            else
                return conge;
        }
        public bool DeleteConge(CConge conge, ICongeDAL congeDAL) {
            bool test = congeDAL.DeleteConge(conge);
            if(test == true)
                return true;
            else
                return false;
        }
        public static CConge GetConge(int ID, ICongeDAL congeDAL) {
            CConge conge = congeDAL.GetConge(ID);
            if(conge == null)
                return null;
            else
                return conge;
        }
    }
}
