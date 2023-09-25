using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options){}
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Attandance> Attandances { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Result>().HasKey(res=> new{res.StudentId, res.SubjectId});
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentClassroom>().HasKey(sc=> new{sc.StudentId, sc.ClassroomId});
        base.OnModelCreating(modelBuilder);
    } 
}
