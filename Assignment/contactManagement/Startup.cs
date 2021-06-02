using contactManagement.Implementation;
using contactManagement.Model;
using contactManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace contactManagement
{
    public class Startup
    {
        private readonly IConfiguration _cfg;

        public Startup(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_cfg.GetConnectionString("ContactDetailsDbConnection")));
            services.AddTransient<IContactRepository, contactRepository>();
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
          {
              endpoints.MapRazorPages();
              endpoints.MapControllerRoute("default", "{controller=Contact}/{action=Index}");
          });
        }

    }
}
