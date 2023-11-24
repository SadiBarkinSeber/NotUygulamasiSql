using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotUygulamasiSql.DAL.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotUygulamasiSql.Domain.Models;

namespace NotUygulamasiSql.DAL.Configuration
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Personels");
            builder.HasKey(x => x.PersonID);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Ignore(x => x.FullName);


            //Seed Data
            builder.HasData(
                new Person()
                {
                    PersonID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "Admin",
                    Password = "12345",
                    Durum = Durum.Aktif

                });
        }
    }
}
