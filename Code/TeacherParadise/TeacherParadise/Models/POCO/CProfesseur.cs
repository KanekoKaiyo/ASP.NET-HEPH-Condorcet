using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Models {
    public class CProfesseur:CUtilisateur {

        // Attributs
        public virtual List<CCoursCollectif> CoursCollectifs { get; set; }
        public virtual List<CConge> ListeConge { get; set; }
        // Constructor
        public CProfesseur() {
            //Constructeur vide pour Entity Framework
        }
        public CProfesseur(string lastName,string surName,DateTime doB,string email,string password,string phoneNumber) {
            this.LastName = lastName;
            this.SurName = surName;
            this.DoB = doB;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            CoursCollectifs = new List<CCoursCollectif>();
            ListeConge = new List<CConge>();
        }

        // Methods
        public CProfesseur AjoutProfesseur(CProfesseur professeur, IProfesseurDAL professeurDAL) {
            // Fonction d'ajout dans la base de donnée, demande à la classe dal de le faire, la classe dal vérifie si c'est possible et renvoie une réponse, si null l'ajout a échoué car l'email est déjà utilisé, si c'est bon elle renvoie l'objet au controller
            CProfesseur prof = professeurDAL.AddProfesseur(professeur);
            if(prof == null) {
                return null;
            } else {
                return prof;
            }
        }
        public CProfesseur VerifProfesseur(CProfesseur professeur,IProfesseurDAL professeurDAL) {
            // Fonction de vérification du login
            CProfesseur prof = professeurDAL.VerifProfesseur(professeur);
            if(prof == null) {
                return null;
            } else {
                return prof;
            }
        }
        public CProfesseur GetProfByID(int? ID,IProfesseurDAL professeurDAL) {
            // Fonction qui renvoie l'objet professeur lorsqu'on lui renvoie son ID
            return professeurDAL.GetProfByID(ID);
        }
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

        public void AddCCoursCollectif(CCoursCollectif c) {
            CoursCollectifs.Add(c);
        }

        public void AddConge(CConge d) {
            ListeConge.Add(d);
        }
        // Part 2 Removing

        public void RemoveCCoursCollectif(CCoursCollectif c) {
            CoursCollectifs.Remove(c);
        }

        public void RemoveConge(CConge d) {
            ListeConge.Remove(d);
        }
    }
}