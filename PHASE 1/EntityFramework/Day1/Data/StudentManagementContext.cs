using Microsoft.EntityFrameworkCore;
using Day1.Models;

namespace Day1.Data;

public class StudentManagementContext : DbContext
{
    public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
    : base(options)
    {
    }
    public DbSet<Student> Students { get; set; } = null!;
}