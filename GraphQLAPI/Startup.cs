using AutoMapper;
using GraphQLAPI.DataAccessLayer;
using GraphQLAPI.GraphQLModels;
using GraphQLAPI.Models;
using GraphQLAPI.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GraphQLAPI
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
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLAPI", Version = "v1" });
            });
            services.AddDbContext<MyHotelDbContext>(options => options.UseSqlServer(MyHotelDbContext.DbConnectionString)); services.AddTransient<ReservationRepository>();
            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<MyHotelSchema>();

            //registed graphQL
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in development mode. make it switchable.
            })
            .AddGraphTypes(ServiceLifetime.Scoped)  //register the various graphQL types, scans the assembly and adds all types that implements IGraphType like ObjectGraphType
            .AddUserContextBuilder(httpContext => httpContext.User)
            .AddDataLoader(); //data loader for dataloader operations
            //Data Loader is the caching technique used by graphQL internally,
            //which can be used to fetch data without making a call to the database
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyHotelDbContext dbContext)
        {
            InitializeMapper();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLAPI v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //add graphqL middleware and tell which schema to use, it sets up the endpoint for us.
            //It sets up the default path /graphql
            app.UseGraphQL<MyHotelSchema>(); 

            //to explorer API navigate https://*DOMAIN*/ui/playground
            //use GraphQL Playground middleware at default path /ui/playground with default options
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
        private static void InitializeMapper()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Guest, GuestModel>();
                x.CreateMap<Room, RoomModel>();
                x.CreateMap<Reservation, ReservationModel>();
            });
        }
    }
}
