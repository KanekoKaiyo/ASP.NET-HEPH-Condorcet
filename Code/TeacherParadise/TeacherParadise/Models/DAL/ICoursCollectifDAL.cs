using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models.DAL {
    public interface ICoursCollectifDAL {
        List<CCoursCollectif> GetAllCours(int ID);
        CCoursCollectif AddCours(CCoursCollectif cours);
        CCoursCollectif GetCour(int ID);
        bool DeleteCoursCollectif(CCoursCollectif cours);
        CCoursCollectif ModifyCour(CCoursCollectif cours, int ID);
        List<CCoursCollectif> GetCoursByMatiere(string matiere);
    }
}
