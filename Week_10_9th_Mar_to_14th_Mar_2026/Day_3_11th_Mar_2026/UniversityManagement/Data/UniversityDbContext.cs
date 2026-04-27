// Data/UniversityDbContext.cs
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Models;

namespace UniversityManagement.Data;

public class UniversityDbContext : DbContext
{
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options) { }

    // DbSets — each becomes a table in the database
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ── Department → Instructors (One to Many) ──────────────────────
        modelBuilder.Entity<Instructor>()
            .HasOne(i => i.Department_)
            .WithMany(d => d.Instructors)
            .HasForeignKey(i => i.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Instructor → Courses (One to Many) ──────────────────────────
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Student ↔ Course via Enrollment (Many to Many) ───────────────
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // ── Column Precision for Budget ──────────────────────────────────
        modelBuilder.Entity<Department>()
            .Property(d => d.Budget)
            .HasColumnType("decimal(18,2)");

        // ── Seed Data ────────────────────────────────────────────────────
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, Name = "Computer Science", Budget = 500000 },
            new Department { DepartmentId = 2, Name = "Mathematics", Budget = 300000 }
        );

        modelBuilder.Entity<Instructor>().HasData(
            new Instructor { InstructorId = 1, Name = "Dr. John Smith", Department = "Computer Science", DepartmentId = 1 },
            new Instructor { InstructorId = 2, Name = "Dr. Sarah Jones", Department = "Mathematics", DepartmentId = 2 }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 1, Title = "Introduction to C#", Credits = 3, InstructorId = 1 },
            new Course { CourseId = 2, Title = "Data Structures", Credits = 4, InstructorId = 1 },
            new Course { CourseId = 3, Title = "Calculus I", Credits = 3, InstructorId = 2 }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { StudentId = 1, FullName = "Alice Johnson", Email = "alice@uni.com", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { StudentId = 2, FullName = "Bob Smith", Email = "bob@uni.com", EnrollmentDate = new DateTime(2023, 9, 1) }
        );

        modelBuilder.Entity<Enrollment>().HasData(
            new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1, Grade = "A" },
            new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 2, Grade = "B+" },
            new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 1, Grade = "A-" },
            new Enrollment { EnrollmentId = 4, StudentId = 2, CourseId = 3, Grade = "B" }
        );
    }
}