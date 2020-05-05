using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models {
    public class CatMatieres {
        private List<CMatieres> listM;
        private static CatMatieres instance = null;

        private CatMatieres() {
            listM = new List<CMatieres>();
        }
        public List<CMatieres> ListM {
            get { return listM; }
            set { listM = value; }
        }

        public static CatMatieres Instance() {
            if(instance == null) {
                instance = new CatMatieres();
            }
            return instance;
        }

        public void Add(CMatieres m) {
            listM.Add(m);
        }

        public void Remove(CMatieres m) {
            listM.Remove(m);
        }

        public void Display() {
            foreach(CMatieres m in listM) {
                Console.WriteLine(m);
            }
        }
    }
}