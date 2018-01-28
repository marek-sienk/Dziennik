using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Dziennik.DAL
{
    public class DziennikContext : DbContext
    {
        public DziennikContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Student> Studenci { get; set; }
        public DbSet<Wynik> Wyniki { get; set; }
        public DbSet<Przedmiot> Przedmioty { get; set; }
        public DbSet<Wykładowca> Wykładowcy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}