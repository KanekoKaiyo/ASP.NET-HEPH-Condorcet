using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.DAL;

namespace TeacherParadise.Models {
    public class CatCoursCollectif {
        private List<CCoursCollectif> listCC;
        private static CatCoursCollectif instance = null;

        private CatCoursCollectif(int ID,ICoursCollectifDAL coursCollectifDAL) {
            ListCC = CCoursCollectif.GetAllCours(ID,coursCollectifDAL);
        }

        public List<CCoursCollectif> ListCC {
            get { return listCC; }
            set { listCC = value; }
        }

        public static CatCoursCollectif Instance(int ID,ICoursCollectifDAL coursCollectifDAL) {
            if(instance == null) {
                instance = new CatCoursCollectif(ID,coursCollectifDAL);
            }
            return instance;
        }
        public static CatCoursCollectif Instance() {
            return instance;
        }

        public void Add(CCoursCollectif cc) {
            listCC.Add(cc);
        }

        public void Remove(CCoursCollectif cc) {
            listCC.Remove(cc);
        }
    }
}
