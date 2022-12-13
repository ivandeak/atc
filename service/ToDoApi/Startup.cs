using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoApi.Data;
using ToDoApi.ToDoItems;

namespace ToDoApi
{
    public class Startup
    {
        public IWebHostEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(
            IWebHostEnvironment env
        )
        {
            HostingEnvironment = env;
            var cb = new ConfigurationBuilder()
                .SetBasePath(HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{HostingEnvironment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = cb.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPooledDbContextFactory<ApplicationDbContext>(opts =>
                {
                    opts.UseSqlite("Data Source=todo.db");
                    opts.EnableDetailedErrors();
                })
                .AddCors(options => {  
                    options.AddDefaultPolicy(builder => {  
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .WithMethods("POST", "GET", "OPTIONS");  
                    });  
                });

            services.AddGraphQLServer()
                    .AddQueryType(d => d.Name("Query"))
                        .AddType<ToDoItemQueries>()
                    .AddMutationType(d => d.Name("Mutation"))
                        .AddType<ToDoItemMutations>()
                    .AddFiltering()
                    .AddSorting()
                    ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ApplicationServices
                .GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
                .CreateDbContext()
                .Database.Migrate();

            app.UseRouting();
            app.UseCors();  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/graphql");
                    return Task.CompletedTask;
                });
            });
        }
    }
}
