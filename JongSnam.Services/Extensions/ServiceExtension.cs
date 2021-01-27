using AutoMapper;
using JongSnamFootball.Entities.Profiles;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers;
using JongSnamFootball.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JongSnam.Services.Extensions
{
    public static class ServiceExtension
    {
        public static void AddConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<IStoreManager, StoreManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IFieldManager, FieldManager>();
            services.AddScoped<ICommentManager, CommentManager>();
        }

        public static void AddConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(StoreProfile));
            services.AddAutoMapper(typeof(CommentProfile));
        }
    }
}
