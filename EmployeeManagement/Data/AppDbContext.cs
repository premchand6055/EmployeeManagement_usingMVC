using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> EmployeeDetails { get; set; }
    }
}
