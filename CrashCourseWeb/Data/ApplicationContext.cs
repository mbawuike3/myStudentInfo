using CrashCourseWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {}

    public DbSet<Student> Students { get; set; }

    //Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
