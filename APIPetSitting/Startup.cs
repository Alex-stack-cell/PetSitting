using DALPetSitting.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OwnerBllService = BLLPetSitting.Services.OwnerService;
using OwnerDalService = DALPetSitting.Services.OwnerService;
using PetSitterBllService = BLLPetSitting.Services.PetSitterService;
using PetSitterDalService = DALPetSitting.Services.PetSitterService;
using PetBllService = BLLPetSitting.Services.PetService;
using PetDalService = DALPetSitting.Services.PetService;
using PrestationBllService = BLLPetSitting.Services.PrestationService;
using PrestationDalService = DALPetSitting.Services.PrestationService;
using AdvertisementBllService = BLLPetSitting.Services.AdvertisementService;
using AdvertisementDalService = DALPetSitting.Services.AdvertisementService;
using CommentBllService = BLLPetSitting.Services.CommentService;
using CommentDalService = DALPetSitting.Services.CommentService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APIPetSitting
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
           
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });
            
            services.AddTransient(typeof(OwnerBllService));
            services.AddTransient(typeof(OwnerDalService));
            services.AddTransient(typeof(PetSitterBllService));
            services.AddTransient(typeof(PetSitterDalService));
            services.AddTransient(typeof(PetBllService));
            services.AddTransient(typeof(PetDalService));
            services.AddTransient(typeof(PrestationBllService));
            services.AddTransient(typeof(PrestationDalService));
            services.AddTransient(typeof(AdvertisementBllService));
            services.AddTransient(typeof(AdvertisementDalService));
            services.AddTransient(typeof(CommentBllService));
            services.AddTransient(typeof(CommentDalService));

            services.AddSingleton(typeof(ConnectionString), (s) =>
            {
                return new ConnectionString(Configuration.GetConnectionString("Dev"));
            });
          
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIPetSitting", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIPetSitting v1"));
            }

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
