using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models.DAL {
    public interface ICoursCollectifDAL {
        List<CCoursCollectif> GetAllCours(int ID);
    }
}
