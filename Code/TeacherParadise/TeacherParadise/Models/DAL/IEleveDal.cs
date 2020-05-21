using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models.POCO;

namespace TeacherParadise.Models.DAL
{
    public interface IEleveDal
    {
        CEleve AddEleve(CEleve eleve);
        CEleve VerifEleve(CEleve eleve);
        CEleve GetEleveByID(int? ID);
        CEleve ModifyProfil(CEleve eleve, int? ID);
        CEleve ChangerNvEtude(string niveauetude);
    }
}
