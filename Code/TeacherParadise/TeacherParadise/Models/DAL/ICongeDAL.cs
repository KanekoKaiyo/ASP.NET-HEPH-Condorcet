using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.Models.DAL {
    public interface ICongeDAL {
        List<CConge> GetConges(int? ID);
        CConge AddConge(CConge conge);
        bool DeleteConge(CConge conge);
        CConge GetConge(int ID);
    }
}
