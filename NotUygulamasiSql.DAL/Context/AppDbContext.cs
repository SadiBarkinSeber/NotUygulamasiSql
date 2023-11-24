using Microsoft.EntityFrameworkCore;
using NotUygulamasiSql.DAL.Configuration;
using NotUygulamasiSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotUygulamasiSql.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Person> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=B\SQLSERVER;Initial catalog=NotUygulamasi; User Id=sa; Password = Baron3241*");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PersonMapping().Configure(modelBuilder.Entity<Person>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
