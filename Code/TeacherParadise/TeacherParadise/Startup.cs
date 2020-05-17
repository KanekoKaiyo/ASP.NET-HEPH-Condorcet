using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeacherParadise.DAL;
using TeacherParadise.Models.DAL;

namespace TeacherParadise {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            // Mes services 
            // Services pour le contexte/connexion à la base de donnée
            services.AddDbContext<ParadiseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ParadiseContext")).UseLazyLoadingProxies());

            // Services pour l'injection de dépendance des DAL
            services.AddTransient<IProfesseurDAL,ProfesseurDAL>();
            services.AddTransient<ICoursCollectifDAL,CoursCollectifDAL>();
            services.AddTransient<ICongeDAL, CongeDAL>();

            // Services pour les sessions
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                // Option pour la durée de vie de la session
                options.IdleTimeout = TimeSpan.FromSeconds(3600); 
                // Option pour rendre les cookie impossible à manipuler coté client
                options.Cookie.HttpOnly = true;
                // Option pour rendre le cookie essentiel pour le fonctionnement de l'application
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Lancement du services des applications
            app.UseSession();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
