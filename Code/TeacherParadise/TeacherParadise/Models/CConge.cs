using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CConge {

        public int ID { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public CProfesseur Professeur { get; set; }

        public CConge(DateTime dateDebut,DateTime dateFin) {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
        }

        public CConge(DateTime dateDebut,DateTime dateFin, CProfesseur professeur) {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Professeur = professeur;
        }
    }
}
