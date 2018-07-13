using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Data;
using MusicStore.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MusicStore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using StarWars.Data.EntityFramework.Seed;

namespace MusicStore
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
            services.AddMvc();

            services.AddScoped<MusicStoreQuery>();  
            services.AddScoped<MusicStoreMutation>(); 
            
            // DB Repositories
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();   
            services.AddTransient<IVenueRepository, VenueEFRepository>();   
            services.AddTransient<IMusicianRepository, MusicianEFRepository>();   

            services.AddDbContext<MusicStoreDbContext>(options => {
                //string connectionString = Configuration["ConnectionStrings:MusicStoreDatabaseConnection"];
                string connectionString = @"Server=db;Database=music-store;User=sa;Password=mssqlServer1433;";

                Console.WriteLine(connectionString);
                options.UseSqlServer(connectionString);
            }
            );

            // GraphQl Types
            services.AddTransient<CategoryType>();
            services.AddTransient<ProductType>();
            services.AddTransient<VenueType>();
            services.AddTransient<MusicianType>();
            services.AddTransient<VenueInputType>();
            services.AddTransient<MusicianInputType>();

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();        
            
            var sp = services.BuildServiceProvider();
            
            services.AddScoped<ISchema>(_ => 
                                            new MusicStoreSchema(type => 
                                                (GraphType) sp.GetService(type)) {
                                                    Query = sp.GetService<MusicStoreQuery>()
                                                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MusicStoreDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            db.EnsureSeedData();
        }
    }
}
