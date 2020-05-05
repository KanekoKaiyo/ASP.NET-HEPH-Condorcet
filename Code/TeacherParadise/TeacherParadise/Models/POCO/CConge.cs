using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CConge {

        public int ID { get; set; }

        [Display(Name = "Début du congé")]
        [Required(ErrorMessage = "La date de début du congés est obligatoire")]
        public DateTime DateDebut { get; set; }
        [Display(Name = "Fin du congé")]
        [Required(ErrorMessage = "La date de fin du congés est obligatoire")]
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
    }
}
