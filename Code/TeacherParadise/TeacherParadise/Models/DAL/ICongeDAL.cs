using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models.DAL {
    public interface ICongeDAL {
        List<CConge> GetConges(int? ID);
        CConge AddConge(CConge conge);
        bool DeleteConge(CConge conge);
        CConge GetConge(int ID);
    }
}
