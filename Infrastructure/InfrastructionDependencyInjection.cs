using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ImagesTask.Core.Interfaces;
using ImagesTask.Infrastructure.AzureBlobStorage;
using ImagesTask.Infrastructure.SQLServer;

namespace ImagesTask.Infrastructure
{
    public static class InfrastructionDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(IServiceCollection services, IConfiguration configuration)
        {
            var blobStorageSettings = new BlobStorageSettings();
            configuration.GetSection(BlobStorageSettings.SettingName).Bind(blobStorageSettings);
            services.AddSingleton(x => new BlobContainerClient(blobStorageSettings.ConnectionString, blobStorageSettings.ContainerName));
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<ISqlRepository, SqlRepository>();
            services.AddDbContext<ImagesTaskContext>();
            

            return services;
        }

    }
}