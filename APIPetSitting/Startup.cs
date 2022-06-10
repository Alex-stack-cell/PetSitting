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
using APIPetSitting.Models;
using System;

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

            JwtSettings bindJwtSettings = new JwtSettings();
            Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);

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

            services.AddSingleton(bindJwtSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                    ValidateIssuer = bindJwtSettings.ValidateIssuer,
                    ValidIssuer = bindJwtSettings.ValidIssuer,
                    ValidateAudience = bindJwtSettings.ValidateAudience,
                    ValidAudience = bindJwtSettings.ValidAudience,
                    RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
                    ValidateLifetime = bindJwtSettings.RequireExpirationTime,
                    ClockSkew = TimeSpan.FromDays(1),
                };
            });
          
            services.AddControllers();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIPetSitting", Version = "v1" });
            //});
            // Définit l'autorisation dans swagger 
            services.AddSwaggerGen(options => {
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme 
                        {
                            Reference = new OpenApiReference {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                        new string[] {}
                    }
                });
                //options.SwaggerDoc("v1.1", new OpenApiInfo { Title = "APIPetSitting", Version = "v1.1" });
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
