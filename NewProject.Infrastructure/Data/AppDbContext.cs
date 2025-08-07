using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NewProject.Domain.models.masterData;
using NewProject.Domain.models.Refrence;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SupportGroup> SupportGroups { get; set; }
        public DbSet<SupportGroupMember> SupportGroupMembers { get; set; }
        public DbSet<NewProject.Domain.models.masterData.Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<NewProject.Domain.models.Refrence.TaskStatus> TaskStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskType>().HasData(
                new TaskType { TaskTypeID = 1, TenantID = null, TaskTypeName = "Review", Description = "Review a record or item", Language = "EN" },
                new TaskType { TaskTypeID = 2, TenantID = null, TaskTypeName = "Approval", Description = "Approve a request or change", Language = "EN" },
                new TaskType { TaskTypeID = 3, TenantID = null, TaskTypeName = "Mitigation Plan", Description = "Develop or review a mitigation plan", Language = "EN" },
                new TaskType { TaskTypeID = 4, TenantID = null, TaskTypeName = "Assessment", Description = "Conduct an assessment", Language = "EN" },
                new TaskType { TaskTypeID = 5, TenantID = null, TaskTypeName = "Update", Description = "Make updates to a module record", Language = "EN" }
            );
            modelBuilder.Entity<NewProject.Domain.models.Refrence.TaskStatus>().HasData(
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 1, TenantID = null, TaskStatusName = "Pending", Language = "EN" },
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 2, TenantID = null, TaskStatusName = "In Progress", Language = "EN" },
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 3, TenantID = null, TaskStatusName = "Review", Language = "EN" },
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 4, TenantID = null, TaskStatusName = "Completed", Language = "EN" },
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 5, TenantID = null, TaskStatusName = "Cancelled", Language = "EN" },
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 6, TenantID = null, TaskStatusName = "On Hold", Language = "EN" },
                new NewProject.Domain.models.Refrence.TaskStatus { TaskStatusID = 7, TenantID = null, TaskStatusName = "Rejected", Language = "EN" }
            );
        }
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

 






