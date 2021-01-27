using AutoMapper;
using JongSnamFootball.Entities.Profiles;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers;
using JongSnamFootball.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JongSnam.Services
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JongSnam.Services", Version = "v1" });
            });

            services.AddDbContext<RepoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("comsci_jsnfb")));

            // Regis Manager
            services.AddScoped<IStoreManager, StoreManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IFieldManager, FieldManager>();
            services.AddScoped<ICommentManager, CommentManager>();

            // Regis Repo
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            // Regis AutoMapper
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(StoreProfile));
            services.AddAutoMapper(typeof(CommentProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JongSnam.Services v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
