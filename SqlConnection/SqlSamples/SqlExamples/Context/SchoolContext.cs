using Microsoft.EntityFrameworkCore;
using SqlExamples.Models;

public class SchoolContext : DbContext
{
    public DbSet<Department> Department { get; set; }
    public DbSet<Student> Student { get; set; }

    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }
}
