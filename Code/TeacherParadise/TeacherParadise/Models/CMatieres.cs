using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CMatieres {

        public int ID { get; set; }

        public string Titre { get; set; }
        public string Niveau { get; set; }

        public CMatieres(string titre, string niveau) {
            this.Titre = titre;
            this.Niveau = niveau;
        }

        public override string ToString() {
            return $"Matière : {Titre}. Niveau : {Niveau}";
        }
    }
}
