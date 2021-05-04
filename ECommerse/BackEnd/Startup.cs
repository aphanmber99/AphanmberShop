using System;
using System.Collections.Generic;
using BackEnd.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackEnd.IdentityServer;
using BackEnd.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using BackEnd.Interface;
using BackEnd.Service;

namespace BackEnd
{
    public class Startup
    {

        public static Dictionary<string, string> ClientUrls;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            ClientUrls = new Dictionary<string, string>()
            {
                ["mvc"] = Configuration["Mvc"]
            };
            //services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            //DB
            services.AddDbContext<AplicationDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            //Identity
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AplicationDbContext>();

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
                    .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
                    .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
                    .AddInMemoryClients(IdentityServerConfig.Clients)
                    .AddAspNetIdentity<User>()
                    .AddProfileService<CustomerProfileService>()
                    .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure
                                                      //config
            services.AddAuthentication()
                .AddLocalApi("Bearer", option =>
                {
                    option.ExpectedScope = "rookieshop.api";
                });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("Bearer", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                });
            });
            //Service Swagger
            services.AddAutoMapper(typeof(MapperConfig).Assembly);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rookie Shop API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri("/connect/token", UriKind.Relative),
                                AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
                                Scopes = new Dictionary<string, string> { { "rookieshop.api", "Rookie Shop API" } }
                            },
                        },
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{ "rookieshop.api" }
                    }
                    });
                });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.WithOrigins("https://sa066a9e3124a5476498c317.z23.web.core.windows.net")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("swagger");
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rookie Shop API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
