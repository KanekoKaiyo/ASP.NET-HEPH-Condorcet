using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.Models {
    public class CConge {

        public int ID { get; set; }

        [Display(Name = "Début du congé")]
        [Required(ErrorMessage = "La date de début du congés est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [Display(Name = "Fin du congé")]
        [Required(ErrorMessage = "La date de fin du congés est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        public virtual CProfesseur Professeur { get; set; }

        public CConge() {
            //Constructeur vide pour Entity Framework
        }

        public CConge(DateTime dateDebut,DateTime dateFin, CProfesseur professeur) {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Professeur = professeur;
        }
        public static List<CConge> GetConges(int? ID, ICongeDAL congeDAL) {
            List<CConge> conge = congeDAL.GetConges(ID);
            if(conge == null)
                return null;
            else
                return conge;
        }
        public CConge AddConge(CConge conge,int? ID,ICongeDAL congeDAL) {
            List<CConge> Lconge = congeDAL.GetConges(ID);
            bool test = false;
            // Vérification si l'intervalle de congé ajouté ce trouve déjà dans un autre intervalle de congé déjà dans la DB

            foreach(CConge c in Lconge) {
                if(conge.DateFin < c.DateDebut || conge.DateDebut > c.DateFin) {
                    // Si la date de fin du congé à ajouté ce trouve avant la date de début d'un autre couté OU si la date de début du congé à ajouté est aprés la date de fin d'un autre congé, alors l'intervalle qu'on veut ajouté ne ce trouve pas dans la DB
                } else {
                    test = true;
                    break;
                }
            }

            if(test != true) {
                CConge conge_ = congeDAL.AddConge(conge);
                if(conge_ == null)
                    return null;
                else
                    return conge;
            } else {
                return null;
            }

        }
        public bool DeleteConge(CConge conge, ICongeDAL congeDAL) {
            bool test = congeDAL.DeleteConge(conge);
            if(test == true)
                return true;
            else
                return false;
        }
        public static CConge GetConge(int ID, ICongeDAL congeDAL) {
            CConge conge = congeDAL.GetConge(ID);
            if(conge == null)
                return null;
            else
                return conge;
        }
    }
}
