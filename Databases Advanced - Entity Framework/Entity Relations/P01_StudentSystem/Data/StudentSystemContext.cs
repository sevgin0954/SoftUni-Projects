using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                string connectionString =
                    "server=DESKTOP-4FKVBUR\\SQLEXPRESS;" +
                    "database=StudentSystem;" +
                    "integrated security=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(student =>
            {
                student.HasKey(s => s.StudentId);

                student.Property(s => s.Name)
                    .HasMaxLength(100)
                    .IsRequired(true);

                student.Property(s => s.PhoneNumber)
                    .HasColumnType("CHAR(10)");
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasKey(c => c.CourseId);

                course.Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Resource>(resource =>
            {
                resource.HasKey(r => r.ResourceId);

                resource.Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsRequired(true);

                resource.Property(r => r.Url)
                    .IsUnicode(false);

                resource.HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(hm => hm.HomeworkId);

                entity.Property(hm => hm.Content)
                    .IsUnicode(false);

                entity.HasOne(em => em.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(em => em.StudentId);

                entity.HasOne(em => em.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(em => em.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.CourseId, sc.StudentId });

                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
