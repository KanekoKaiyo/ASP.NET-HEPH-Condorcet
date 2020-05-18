using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Attribute;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.Models {
    abstract public class CUtilisateur {

        public int ID { get; set; }

        // Attributs
        [Display(Name = "Nom")]
        [Required(ErrorMessage ="Le nom de famille est obligatoire")]
        [StringLength(20,MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(20,MinimumLength = 3)]
        public string SurName { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        [DoBMajor]
        public DateTime DoB { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'Email est obligatoire")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [StringLength(20,ErrorMessage ="Le {0} doit avoir au moins {2} de long",MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",ErrorMessage = "Le mot de passe doit avoir au moins 8 characteres et contenir 3 des 4 conditions suivante: Majuscule (A-Z), Minuscule (a-z), Chiffre (0-9) Et caractéres spéciaux (e.g. !@#$%^&*)")]
        public string Password { get; set; }


        [Display(Name = "Numéro de téléphone")]
        [Required(ErrorMessage = "Le numéro de téléhpone est obligatoire")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
