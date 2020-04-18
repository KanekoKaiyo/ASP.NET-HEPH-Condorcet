using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models;

namespace TeacherParadise.DAL {
    public class ParadiseContext : DbContext {
        // Table of DataBase
        // DbSet<Model a utilisé> Non de la table
        public DbSet<CProfesseur> Professeurs { get; set; }
        public DbSet<CCoursCollectif> CoursCollectifs { get; set; }
        public DbSet<CCoursRemediation> CoursRemediations { get; set; }
        public DbSet<CMatieres> Matieres { get; set; }

        // Constructeur
        public ParadiseContext(DbContextOptions<ParadiseContext> options) : base(options) {

        }
    }
}
