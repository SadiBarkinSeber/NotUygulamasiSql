using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NotUygulamasiSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotUygulamasiSql.DAL.Configuration
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(x => x.NoteID);
            builder.Property(x => x.NoteTitle).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NoteContent).IsRequired().HasMaxLength(50);
        }
    }
}
