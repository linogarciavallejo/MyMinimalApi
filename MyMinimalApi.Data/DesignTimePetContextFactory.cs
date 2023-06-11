using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using MyMinimalApi.Data;

public class DesignTimePetContextFactory : IDesignTimeDbContextFactory<PetContext> {
    public PetContext CreateDbContext(string[] args) {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<PetContext>();

        var connectionString = configuration.GetConnectionString("PetsDb");

        builder.UseSqlServer(connectionString);

        return new PetContext(builder.Options);
    }
}
