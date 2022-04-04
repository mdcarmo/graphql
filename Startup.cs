using ex_graphql.Contracts;
using ex_graphql.Entities.Context;
using ex_graphql.GraphQL;
using ex_graphql.Repository;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ex_graphql
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ex_graphql", Version = "v1" });
                c.EnableAnnotations();
            });

            string conx = Configuration.GetSection("SqlServerSettings").GetSection("ConnectionString").Value;

            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(conx.Replace("%CONTENTROOTPATH%", Environment.ContentRootPath)));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<AppSchema>();

            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ex_graphql v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<AppSchema>("/graphql");
            app.UseGraphQLPlayground();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
