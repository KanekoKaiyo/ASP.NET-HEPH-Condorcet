using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models;

namespace TeacherParadise.DAL {
    public class ParadiseContext : DbContext { 

        public ParadiseContext(DbContextOptions<ParadiseContext> options): base(options) {

        }

        public DbSet<CProfesseur> Professeurs { get; set; }
        public DbSet<CConge> Conges { get; set; }
        public DbSet<CCoursCollectif> CoursCollectifs { get; set; }
        public DbSet<CCoursRemediation> CoursRemediations { get; set; }
        public DbSet<CMatieres> Matieres { get; set; }
    }
}
