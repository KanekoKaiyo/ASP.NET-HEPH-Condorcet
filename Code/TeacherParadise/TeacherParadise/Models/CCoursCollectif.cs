using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CCoursCollectif {
        //Attributs
        [Display(Name = "Titre du cours")]
        [Required(ErrorMessage = "Le titre du cours est obligatoire")]
        public string Titre { get; set; }

        [Display(Name ="Description du cours")]
        [Required(ErrorMessage = "La description du cours est obligatoire")]
        public string Description { get; set; }

        [Display(Name = "Matière et niveau du cours")]
        [Required(ErrorMessage = "La matière et le niveau du cours sont obligatoire")]
        public CMatieres Matieres { get; set; }

        [Display(Name = "Date du cours")]
        [Required(ErrorMessage = "La date du cours est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Heure de début")]
        [Required(ErrorMessage = "L'heure de début est obligatoire")]
        [DataType(DataType.Time)]
        public DateTime Starthour { get; set; }

        [Display(Name = "Nombre d'heure total")]
        [Required(ErrorMessage = "Le nombre d'heure total est obligatoire")]
        public double TotalHour { get; set; }

        [Display(Name = "Prix du cours")]
        [Required(ErrorMessage = "Le prix du cours est obligatoire")]
        public double Prix { get; set; }

        public CProfesseur Professeur { get; set; }

        //Constructeur
        public CCoursCollectif(string titre, string description, CMatieres matiere, DateTime date, DateTime starthour, double totalhour, double prix, CProfesseur professeur) {
            this.Titre = titre;
            this.Description = description;
            this.Matieres = matiere;
            this.Date = date;
            this.Starthour = starthour;
            this.TotalHour = totalhour;
            this.Prix = prix;
            this.Professeur = professeur;
        }

        //Methods
        public void ModifierCoursC(DateTime date,DateTime starthour,double totalhour,double prix) {
            this.Date = date;
            this.Starthour = starthour;
            this.TotalHour = totalhour;
            this.Prix = prix;
        }

        public void SuppressionCoursR() {
            //TODO : delete dans la database + catalogue
        }
    }
}
