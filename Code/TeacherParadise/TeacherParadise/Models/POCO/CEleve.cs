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
        public string NiveauEtude { get; set; }
        public virtual List<CReservationCoursCollectif> ReservationCoursCollectifs { get; set; }
        // Constructor
        public CEleve()
        {
            //Constructeur vide pour Entity Framework
        }
        public CEleve(string lastName, string surName, DateTime doB, string email, string password, string phoneNumber, string niveauetude)
        {
            this.LastName = lastName;
            this.SurName = surName;
            this.DoB = doB;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            ReservationCoursCollectifs = new List<CReservationCoursCollectif>();
            this.NiveauEtude = niveauetude;
            
        }

        

        // Methods
        public CEleve AjoutEleve(CEleve eleve, IEleveDal EleveDAL)
        {
            
            CEleve el = EleveDAL.AddEleve(eleve);
            if (el == null)
            {
                return null;
            }
            else
            {
                return el;
            }
        }
        public CEleve VerifEleve(CEleve eleve, IEleveDal EleveDAL)
        {
            // Fonction de vérification du login
            CEleve el = EleveDAL.VerifEleve(eleve);
            if (el == null)
            {
                return null;
            }
            else
            {
                return el;
            }
        }
        public CEleve GetEleveByID(int? ID, IEleveDal EleveDAL)
        {
            // Fonction qui renvoie l'objet professeur lorsqu'on lui renvoie son ID
            return EleveDAL.GetEleveByID(ID);
        }
        public CEleve ModifierProfil(CEleve eleve, int? ID, IEleveDal EleveDAL)
        {
            CEleve eleve_ = EleveDAL.ModifyProfil(eleve, ID);
            if (eleve_ == null)
                return null;
            else
                return eleve_;
        }
        public CEleve ChangerNvEtude(CEleve eleve, int? ID, IEleveDal EleveDAL)
        {
            return EleveDAL.ChangerNvEtude(NiveauEtude);
        }

    }
}
