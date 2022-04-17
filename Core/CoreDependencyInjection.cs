using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ImagesTask.Core.Interfaces;
using ImagesTask.Core.Services;
using MediatR;

namespace ImagesTask.Core
{
    public static class CoreDependencyInjection
    {
        public static IServiceCollection AddCoreServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IImagesService, ImagesService>();
            services.AddMediatR(typeof(Queries.GetImagesQuery));
            services.AddMediatR(typeof(Queries.CreateImageCommand));

            services.AddMediatR(typeof(Queries.DeleteImageCommand));

            return services;
        }

    }
}