using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models.POCO
{
    public class CReservationCoursCollectif
    {
        //accesseur
        public int ID { get; set; }
        public CEleve Eleve;
        public CCoursCollectif Cours;

        [Display(Name = "Date du cours")]
        [Required(ErrorMessage = "La date du cours est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateRes { get; set; }
        //constructeur
        public CReservationCoursCollectif() { }
        //va récupérer tout les cours du catalogue.

    }
}
