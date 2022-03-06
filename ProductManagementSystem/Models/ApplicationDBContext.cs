using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<Regsitration> RegistrationTable { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
