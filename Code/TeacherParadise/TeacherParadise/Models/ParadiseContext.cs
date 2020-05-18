using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherParadise.Models;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.DAL {
    public class ParadiseContext : DbContext { 

        public ParadiseContext(DbContextOptions<ParadiseContext> options): base(options) {

        }

        public DbSet<CProfesseur> Professeurs { get; set; }
        public DbSet<CConge> Conges { get; set; }
        public DbSet<CCoursCollectif> CoursCollectifs { get; set; }
    }
}
