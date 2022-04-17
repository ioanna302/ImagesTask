#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ImagesTask.Core.Entities;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Infrastructure.SQLServer
{
    public class ImagesTaskContext : DbContext, IImagesTaskContext
    {

        public DbSet<Image> Image { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("ImagesTaskContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
