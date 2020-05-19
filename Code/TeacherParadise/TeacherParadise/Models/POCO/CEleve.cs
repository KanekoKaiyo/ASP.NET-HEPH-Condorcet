using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Models.POCO
{
    public class CEleve:CUtilisateur
    {
        // Attributs
        public virtual List<CCoursCollectif> CoursCollectifs { get; set; }
        public virtual List<CConge> ListeConge { get; set; }
        // Constructor
        public CEleve()
        {
            //Constructeur vide pour Entity Framework
        }
        public CEleve(string lastName, string surName, DateTime doB, string email, string password, string phoneNumber)
        {
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
        public CEleve AjoutEleve(CEleve eleve, IEleveDal eleveDAL)
        {
            // Fonction d'ajout dans la base de donnée, demande à la classe dal de le faire, la classe dal vérifie si c'est possible et renvoie une réponse, si null l'ajout a échoué car l'email est déjà utilisé, si c'est bon elle renvoie l'objet au controller
            CEleve eleve = eleveDAL.AddEleve(eleve);
            if (eleve == null)
            {
                return null;
            }
            else
            {
                return eleve;
            }
        }
        public CEleve VerifEleve(CEleve eleve, IEleveDal eleveDAL)
        {
            // Fonction de vérification du login
            CEleve eleve = eleveDAL.VerifEleve(eleve);
            if (eleve == null)
            {
                return null;
            }
            else
            {
                return eleve;
            }
        }
        public CEleve GetEleveByID(int? ID, IEleveDal eleveDAL)
        {
            // Fonction qui renvoie l'objet professeur lorsqu'on lui renvoie son ID
            return eleveDAL.GetEleveByID(ID);
        }
        public CEleve ModifierProfil(CEleve eleve, int? ID, IEleveDal eleveDAL)
        {
            CEleve eleve_ = eleveDAL.ModifyProfil(eleve, ID);
            if (eleve_ == null)
                return null;
            else
                return eleve_;
        }

    }
}
