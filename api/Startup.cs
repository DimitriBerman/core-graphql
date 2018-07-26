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
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace MusicStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var elasticUri = Configuration["ELASTIC_SEARCH_URI"];
            Console.WriteLine("ElasticUri: {0}", elasticUri);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    AutoRegisterTemplate = true,
                })
            .CreateLogger();
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
                string connectionString = Configuration["DB_CONNECTION_STRING"];
                Console.WriteLine("ConnectionString: {0}", connectionString);
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MusicStoreDbContext db, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            db.EnsureSeedData();
        }
    }
}
