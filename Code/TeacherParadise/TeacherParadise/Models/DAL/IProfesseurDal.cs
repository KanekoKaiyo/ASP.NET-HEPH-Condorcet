using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.Models.DAL {
    public interface IProfesseurDAL {
        CProfesseur AddProfesseur(CProfesseur professeur);
        CProfesseur VerifProfesseur(CProfesseur professeur);
        CProfesseur GetProfByID(int? ID);
        CProfesseur ModifyProfil(CProfesseur professeur,int? ID);
    }
}
