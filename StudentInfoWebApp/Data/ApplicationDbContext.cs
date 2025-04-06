namespace StudentInfoWebApp.Data
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using StudentInfoWebApp.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }

}
