using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AttendanceSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AttendanceSystem.iRepository;
using AttendanceSystem.Repository;
using Blazorise;
using Blazorise.DataGrid;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;



namespace AttendanceSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<Student_ImagesCRUD>();
            
            services.AddTransient<iRepositoryPASSData, RepositoryPASSData>();
            services.AddTransient<iRepositoryTeacher_Picture, RepositoryTeacherPicture>();
            services.AddTransient<iRepositoryStudent_Image, RepositoryStudent_Image>();
            services.AddTransient<iRepositoryAttendance, RepositoryAttendance>();
            services.AddTransient<iRepositoryAttendanceRecord, RepositoryAttendanceRecord>();
            services.AddTransient<iRepositoryReports, RepositoryReports>();
            services.AddTransient<iRepositoryNotesTable, RepositoryNotesTable>();
            services.AddTransient<iRepositoryNotesStatus, RepositoryNotesStatus>();
            services.AddTransient<iRepositorySummary, RepositorySummary>();
            services.AddTransient<iRepositorySubjectCount, RepositorySubjectCount>();
            services.AddTransient<iRepositoryTeacherReports, RepositoryTeacherReports>();
            services.AddTransient<iRepository64AttendanceRims, Repository64AttendanceRims>();
            services.AddTransient<iRepositoryTeacher_Attendance, RepositoryTeacherAttendance>();
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });


            services.AddBlazorise(option =>
            {
                option.ChangeTextOnKeyPress = true;
            }).AddBootstrapProviders().AddFontAwesomeIcons();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
