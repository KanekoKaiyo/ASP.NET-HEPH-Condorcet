using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CatCoursRemediation {
        private List<CCoursRemediation> listCR;
        private static CatCoursRemediation instance = null;

        private CatCoursRemediation() {
            listCR = new List<CCoursRemediation>();
        }

        public List<CCoursRemediation> ListCR {
            get { return listCR; }
            set { listCR = value; }
        }

        public static CatCoursRemediation Instance() {
            if(instance == null) {
                instance = new CatCoursRemediation();
            }
            return instance;
        }

        public void Add(CCoursRemediation cr) {
            listCR.Add(cr);
        }

        public void Remove(CCoursRemediation cr) {
            listCR.Remove(cr);
        }

        public void Display() {
            foreach(CCoursRemediation cr in listCR) {
                Console.WriteLine(cr);
            }
        }
    }
}
