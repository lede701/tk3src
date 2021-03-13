using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
	public static class SwaggerServiceExtension
	{
		public static String API_NAME = "Time Keeper 3 API";
		public static String API_VERSION = "v3";

		public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(SwaggerServiceExtension.API_VERSION, new OpenApiInfo { 
					Title = SwaggerServiceExtension.API_NAME, 
					Version = SwaggerServiceExtension.API_VERSION 
				});

				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "JWT Auth Vearer Scheme",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "Bearer",
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				};

				c.AddSecurityDefinition("Bearer", securitySchema);
				var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
				c.AddSecurityRequirement(securityRequirement);
			});

			return services;
		}


		public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint(
					String.Format("/swagger/{0}/swagger.json", SwaggerServiceExtension.API_VERSION),
					String.Format("API {0}", SwaggerServiceExtension.API_VERSION)
					));
			}

			return app;
		}
	}
}
