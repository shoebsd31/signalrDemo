using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;


namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionConfiguration = Configuration.GetConnectionString("SensorDB");
            services.AddSignalR();
            services.AddDbContext<SensorDBContext>(options =>
                options.UseNpgsql(dbConnectionConfiguration));
            Register(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<SensorDataHub>("/sensordatahub");
            });

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SensorDBContext>();
               // context.Database.EnsureDeleted();
                //context.Database.Migrate();
                //context.Database.OpenConnection();
                //context.Database.EnsureCreated();
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }

        }

        private static void Register(IServiceCollection services)
        {
            services.AddTransient<IAction, Action>();
        }
    }
}