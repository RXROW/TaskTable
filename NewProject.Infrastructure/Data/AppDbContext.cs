using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NewProject.Domain.models.masterData;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SupportGroup> SupportGroups { get; set; }
        public DbSet<SupportGroupMember> SupportGroupMembers { get; set; }
        public DbSet<NewProject.Domain.models.masterData.Task> Tasks { get; set; }

        // Optionally override OnModelCreating for further configuration
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
         
            public AppDbContext CreateDbContext(string[] args)
            {
                try
                {
                    var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "NewProject"));
                    Console.WriteLine("📁 BasePath: " + basePath);

                    var settingsPath = Path.Combine(basePath, "appsettings.json");
                    if (!File.Exists(settingsPath))
                    {
                        throw new FileNotFoundException("❌ appsettings.json not found at: " + settingsPath);
                    }

                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    Console.WriteLine("🔑 ConnectionString: " + connectionString);

                    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                    optionsBuilder.UseSqlServer(connectionString);

                    return new AppDbContext(optionsBuilder.Options);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ ERROR creating DbContext: " + ex.Message);
                    throw;
                }
            }
        }


    }

 






