using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
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
        public CProfesseur ModifierProfil(CProfesseur professeur, int? ID, IProfesseurDAL professeurDAL) {
            CProfesseur prof_ = professeurDAL.ModifyProfil(professeur,ID);
            if(prof_ == null)
                return null;
            else
                return prof_;
        }
    }
}