using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherParadise.Models.DAL {
    public interface IProfesseurDAL {
        CProfesseur AddProfesseur(CProfesseur professeur);
        CProfesseur VerifProfesseur(CProfesseur professeur);
    }
}
