using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CProfesseur:CUtilisateur {

        // Attributs
        public List<CMatieres> Matieres { get; set; }
        public List<CCoursCollectif> CoursCollectifs { get; set; }
        public List<CCoursRemediation> CoursRemediations { get; set; }
        // public List<DateTime> ListeConge { get; set; }
        // Constructor
        public CProfesseur(string lastName,string surName,DateTime doB,string email,string password,string phoneNumber) {
            this.LastName = lastName;
            this.SurName = surName;
            this.DoB = doB;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            Matieres = new List<CMatieres>();
            CoursCollectifs = new List<CCoursCollectif>();
            CoursRemediations = new List<CCoursRemediation>();
            // ListeConge = new List<DateTime>();
        }

        // Methods
        public override void ModifierProfil(string lastname,string surname,DateTime dob,string email,string password,string phonenumber) {
            this.LastName = lastname;
            this.SurName = surname;
            this.DoB = dob;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = phonenumber;
        }
        public void AjoutMatiere() {
            // Envoie un email au webdev pour l'ajout d'une matière
        }
        // List management Methods
        //TODO : En plus d'ajouter/retirer/modifier l'objet de la liste personnel il faut effectuer l'opération sur la BDD et mettre a jour les catalogues
        // Part 1 Adding
        public void AddCMatieres(CMatieres m) {
            Matieres.Add(m);
        }
        public void AddCCoursCollectif(CCoursCollectif c) {
            CoursCollectifs.Add(c);
        }
        public void AddCCoursRemediation(CCoursRemediation c) {
            CoursRemediations.Add(c);
        }
        public void AddConge(DateTime d) {
            // ListeConge.Add(d);
        }
        // Part 2 Removing
        public void RemoveCMatieres(CMatieres m) {
            Matieres.Remove(m);
        }
        public void RemoveCCoursCollectif(CCoursCollectif c) {
            CoursCollectifs.Remove(c);
        }
        public void RemoveCCoursRemediation(CCoursRemediation c) {
            CoursRemediations.Remove(c);
        }
        public void RemoveConge(DateTime d) {
            // ListeConge.Remove(d);
        }
    }
}