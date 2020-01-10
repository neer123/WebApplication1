using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class App1DBContext : DbContext
    {
        public App1DBContext(DbContextOptions options) : base(options)
        {

        }
        public App1DBContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
