using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CatCoursCollectif {
        private List<CCoursCollectif> listCC;
        private static CatCoursCollectif instance = null;

        private CatCoursCollectif() {
            listCC = new List<CCoursCollectif>();
        }

        public List<CCoursCollectif> ListCC {
            get { return listCC; }
            set { listCC = value; }
        }

        public static CatCoursCollectif Instance() {
            if(instance == null) {
                instance = new CatCoursCollectif();
            }
            return instance;
        }

        public void Add(CCoursCollectif cc) {
            listCC.Add(cc);
        }

        public void Remove(CCoursCollectif cc) {
            listCC.Remove(cc);
        }

        public void Display() {
            foreach(CCoursCollectif cc in listCC) {
                Console.WriteLine(cc);
            }
        }
    }
}
