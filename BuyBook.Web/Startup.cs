using BuyBook.Application.CQRS.Users.Command.CreateUserCommand;
using BuyBook.Application.CQRS.Users.Query;
using BuyBook.Application.Interfaces;
using BuyBook.Application.PopulateDatabase;
using BuyBook.Infrastructure.UploadExcel.Data;
using BuyBook.PersistenceNoSQL;
using BuyBook.PersistenceNoSQL.Interfaces;
using BuyBook.PersistenceSQL;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace BuyBook.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddDbContext<BuyBookDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.Configure<MongoDatabaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("BuyBookDatabaseSettings:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("BuyBookDatabaseSettings:DatabaseName").Value;
            });

            services.AddScoped(typeof(IMongoDatabaseSettings), typeof(MongoDatabaseSettings));
            services.AddScoped(typeof(IBuyBookDbContext), typeof(BuyBookDbContext));
            services.AddScoped(typeof(IMongoDbContext), typeof(MongoDbContext));
            services.AddTransient(typeof(ExcelReader));
            services.AddTransient(typeof(UserPopulate));

            services.AddSingleton<IMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

            services.AddMediatR(typeof(GetAllUsersQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
