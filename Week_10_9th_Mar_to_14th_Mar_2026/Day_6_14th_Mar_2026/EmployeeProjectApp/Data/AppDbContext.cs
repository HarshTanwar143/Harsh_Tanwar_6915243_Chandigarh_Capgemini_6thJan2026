using EmployeeProjectApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeProjectApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Engineering" },
                new Department { Id = 2, Name = "Marketing" },
                new Department { Id = 3, Name = "HR" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Harsh Tanwar", Email = "harshtanwar14122003@gmail.com", DepartmentId = 1 },
                new Employee { Id = 2, Name = "Sahil Verma", Email = "sahil@gmail.com", DepartmentId = 3 },
                new Employee { Id = 3, Name = "Sonika Singh", Email = "sonika123@gmail.com", DepartmentId = 2 },
                new Employee { Id = 4, Name = "Ramika Sahani", Email = "ramsah@gamil.com", DepartmentId = 1 }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Title = "AI Interview Assistant", Description = "A virtual AI assistant that will take real time interview of the candidate for Job." },
                new Project { Id = 2, Title = "B2B Architecture Optimization", Description = "Optimize and handling the millions of request simultaneously" },
                new Project { Id = 3, Title = "Ventures Advertisment", Description = "A marketing project for ventures" },
                new Project { Id = 4, Title = "Uber Business", Description = "A Bussiness app to make you next ride easy" }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject { EmployeeId = 1, ProjectId = 1, AssignedDate = new DateTime(2024, 1, 10) },
                new EmployeeProject { EmployeeId = 1, ProjectId = 2, AssignedDate = new DateTime(2024, 1, 10) },
                new EmployeeProject { EmployeeId = 1, ProjectId = 4, AssignedDate = new DateTime(2024, 1, 10) },
                new EmployeeProject { EmployeeId = 2, ProjectId = 1, AssignedDate = new DateTime(2024, 1, 15) },
                new EmployeeProject { EmployeeId = 3, ProjectId = 3, AssignedDate = new DateTime(2024, 2, 1) },
                new EmployeeProject { EmployeeId = 4, ProjectId = 1, AssignedDate = new DateTime(2024, 2, 5) },
                new EmployeeProject { EmployeeId = 4, ProjectId = 4, AssignedDate = new DateTime(2024, 2, 5) }
            );
        }
    }
}
