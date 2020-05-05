using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CMatieres {

        public int ID { get; set; }

        [Display(Name = "Titre de la matière")]
        [Required(ErrorMessage = "Le titre de la matière est obligatoire")]
        public string Titre { get; set; }

        [Display(Name = "Niveau du cours")]
        [Required(ErrorMessage = "Le niveau du cours est obligatoire")]
        public string Niveau { get; set; }
        public CMatieres() {
            //Constructeur vide pour Entity Framework
        }
        public CMatieres(string titre, string niveau) {
            this.Titre = titre;
            this.Niveau = niveau;
        }

        public override string ToString() {
            return $"Matière : {Titre}. Niveau : {Niveau}";
        }
    }
}
