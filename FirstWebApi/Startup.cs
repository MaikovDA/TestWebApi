using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// устанавливаем контекст данных
			services.AddDbContext<UsersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDB")));

			services.AddControllers(); // используем контроллеры без представлений
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UsersContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
			}


			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}
