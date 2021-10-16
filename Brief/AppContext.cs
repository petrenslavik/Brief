using Brief.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brief
{
    public class AppContext: DbContext
    {
        public DbSet<Form> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
                .Property(b => b.SerializedForm)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-IUMC6EK\\SQLEXPRESS; Database = brief; Trusted_Connection = True;MultipleActiveResultSets = true;");
        }
    }
}
