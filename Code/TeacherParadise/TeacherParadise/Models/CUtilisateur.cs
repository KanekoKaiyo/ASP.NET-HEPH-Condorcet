using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    abstract public class CUtilisateur {

        // Attributs
        [Display(Name = "Nom")]
        [Required(ErrorMessage ="Le nom de famille est obligatoire")]
        [StringLength(20,MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(20,MinimumLength = 3)]
        public string Surname { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'Email est obligatoire")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Numéro de téléphone")]
        [Required(ErrorMessage = "Le numéro de téléhpone est obligatoire")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }



        //Methods
        abstract public void ModifierProfil(string lastname,string surname,DateTime dob,string email,string password,string phonenumber);
    }
}
