using BabyTransfer.Security;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace BabyTransfer
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
			//var connectionString = Configuration["server=localhost;user=igor;password=W9n3J0c0;port=3306;database=igor"];

			//services.AddEntityFrameworkMySql()
			//	.AddDbContext<TransferDbContext>(options => options
			//		.UseMySql(connectionString, sqlOptions => {
			//			sqlOptions.MigrationsAssembly("WebApplication6");
			//			sqlOptions.EnableRetryOnFailure(
			//				maxRetryCount: 4,
			//				maxRetryDelay: TimeSpan.FromMilliseconds(2000),
			//				errorNumbersToAdd: null);
			//		})
			//		.EnableSensitiveDataLogging()
			//		.EnableDetailedErrors());
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
			{
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;

				cfg.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidIssuer = "https://localhost:44385/",
					ValidateAudience = false,
					ValidAudience = "https://localhost:44385/",
					RequireExpirationTime = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.SIGNING_KEY)),
					ValidateIssuerSigningKey = true
				};
			});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("OnlyAdmins", policy => policy.RequireClaim("Role", "Admin"));
				options.AddPolicy("OnlyDrivers", policy => policy.RequireClaim("Role", "Driver"));
				options.AddPolicy("OnlyCustomers", policy => policy.RequireClaim("Role", "Customer"));
			});

			services.AddCors(c =>
			{
				c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
			});
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "BabyTransfer",
					Description = "Practica",
				});
				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				};
				c.AddSecurityDefinition("Bearer", securitySchema);

				var securityRequirement = new OpenApiSecurityRequirement();
				securityRequirement.Add(securitySchema, new[] { "Bearer" });
				c.AddSecurityRequirement(securityRequirement);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseCors(options => options.AllowAnyOrigin());

			app.UseStaticFiles();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
