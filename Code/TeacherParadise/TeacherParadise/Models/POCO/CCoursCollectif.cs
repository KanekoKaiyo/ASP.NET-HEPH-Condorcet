using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Models {
    public class CCoursCollectif {

        public int ID { get; set; }

        //Attributs
        [Display(Name = "Titre du cours")]
        [Required(ErrorMessage = "Le titre du cours est obligatoire")]
        public string Titre { get; set; }

        [Display(Name ="Description du cours")]
        [Required(ErrorMessage = "La description du cours est obligatoire")]
        public string Description { get; set; }

        [Display(Name = "Matière du cours")]
        [Required(ErrorMessage = "La matière du cours sont obligatoire")]
        public string Matieres { get; set; }

        [Display(Name = "Niveau du cours")]
        [Required(ErrorMessage = "Le niveau du cours sont obligatoire")]
        public string Niveau { get; set; }


        [Display(Name = "Date du cours")]
        [Required(ErrorMessage = "La date du cours est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Heure de début")]
        [Required(ErrorMessage = "L'heure de début est obligatoire")]
        [DataType(DataType.Time)]
        public DateTime StartHour { get; set; }

        [Display(Name = "Nombre d'étudiant maximum")]
        [Required(ErrorMessage = "Le nombre d'étudiant maximum est obligatoire")]
        public int MaxStudent { get; set; }

        [Display(Name = "Nombre d'étudiant inscrit au cours")]
        public int CurrentStudent { get; set; }

        [Display(Name = "Prix du cours")]
        [Required(ErrorMessage = "Le prix du cours est obligatoire")]
        public double Price { get; set; }

        public virtual CProfesseur Professeur { get; set; }

        //Constructeur
        
        public CCoursCollectif() {
            //Constructeur vide pour Entity Framework
        }
        public CCoursCollectif(string titre, string description, string matieres,string niveau, DateTime date, DateTime startHour,int maxstudent,double price, CProfesseur professeur) {
            this.Titre = titre;
            this.Description = description;
            this.Matieres = matieres;
            this.Niveau = niveau;
            this.Date = date;
            this.StartHour = startHour;
            this.MaxStudent = maxstudent;
            this.CurrentStudent = 0;
            this.Price = price;
            this.Professeur = professeur;
        }




        //Methods
        public static List<CCoursCollectif> GetAllCours(int ID, ICoursCollectifDAL coursCollectifDAL) {
            // Fonction qui renvoie la liste compléte des cours collectif du professeur
            List<CCoursCollectif> cours = coursCollectifDAL.GetAllCours(ID);
            if(cours == null)
                return null;
            else
                return cours;
        }

        public CCoursCollectif AddCours(CCoursCollectif cours, ICoursCollectifDAL coursCollectifDAL) {
            // Fonction d'ajout d'un nouveau cours collectif
            CCoursCollectif cours_ = coursCollectifDAL.AddCours(cours);
            if(cours_ == null)
                return null;
            else
                return cours_;
        }

        public static CCoursCollectif GetCour(int ID,ICoursCollectifDAL coursCollectifDAL) {
            // Fonction qui renvoie un objet cour gràce à son ID
            CCoursCollectif cours_ = coursCollectifDAL.GetCour(ID);
            if(cours_ == null)
                return null;
            else
                return cours_;
        }
        public bool DeleteCoursCollectif(CCoursCollectif cours,ICoursCollectifDAL coursCollectifDAL) {
            bool test = coursCollectifDAL.DeleteCoursCollectif(cours);
            if(test == true) {
                return true;
            } else {
                return false;
            }
        }

        public CCoursCollectif ModifyCour(CCoursCollectif cours,int ID,ICoursCollectifDAL coursCollectifDAL) {
            CCoursCollectif cours_ = coursCollectifDAL.ModifyCour(cours,ID);
            if(cours_ == null)
                return null;
            else
                return cours_;
        }

        public override bool Equals(object obj) {
            if(obj is CCoursCollectif && obj != null) {
                CCoursCollectif temp;
                temp = (CCoursCollectif)obj;
                if(temp.ID == this.ID) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    }
}
