using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CCoursRemediation {
        [Key]
        public int ID { get; set; }
        //Attributs
        [Display(Name = "Date du cours")]
        [Required(ErrorMessage = "La date du cours est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } // Uniquement le jour

        [Display(Name = "Heure de début")]
        [Required(ErrorMessage = "L'heure de début est obligatoire")]
        [DataType(DataType.Time)]
        public DateTime StartHour { get; set; }

        [Display(Name = "Heure de fin")]
        [Required(ErrorMessage = "L'heure de fin est obligatoire")]
        [DataType(DataType.Time)]
        public DateTime EndHour { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public virtual CProfesseur Professeur { get; set; }

        
        //Constructeur
        public CCoursRemediation(DateTime date, DateTime startHour,DateTime endHour) {
            this.Date = date;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.Status = "Open";
            // this.Professeur = professeur;
        }

        //Methods
        public void ModifierCoursR(DateTime date,DateTime startHour,DateTime endHour,string status) {
            this.Date = date;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.Status = status;
        }
        public void SuppressionCoursR() {
            //TODO : delete dans la database + catalogue
        }
    }
}
