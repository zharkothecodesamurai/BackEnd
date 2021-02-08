using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;
using Seavus.Recipe.Api.DataAccess.Ef.Repository;
using Seavus.Recipe.Api.Services;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.DataProvider;
using Seavus.Recipe.Core.Services;
using Seavus.Recipe.Core.Shared;
using Seavus.Recipe.DataProvider.Edamam;
using System;
using System.Text;

namespace Seavus.Recipe.Api.WebHost
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
            var appConfig = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appConfig);
            ApplicationSettings appSettings = appConfig.Get<ApplicationSettings>();

            services.AddDbContext<RecipeDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IShopingListRepository, ShoppingListRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IDataProvider, EdamamDataProvider>();
            services.AddScoped<IHealthService, HealthService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddControllers();

            services.AddCors();
            var secretBytes = Encoding.ASCII.GetBytes(appSettings.JWT_secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    //get the jwt token from the HttpContext
                    x.SaveToken = true;
                    //what to validate from the default claims
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Starting Recipe WebApi host.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
           
            //tuka
            app.UseCors(builder =>
                 builder.WithOrigins("http://localhost:4200", "http://localhost:5000")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials()
                 );
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            


        }
    }
}
