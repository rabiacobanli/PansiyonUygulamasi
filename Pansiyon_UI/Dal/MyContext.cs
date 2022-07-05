using Pansiyon_UI.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pansiyon_UI.Dal
{
    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<Konaklamalar> Konaklamalar { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Odalar> Odalar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Musteriler>()
            //    .HasMany(e => e.Konaklamalar)
            //    .WithRequired(e => e.Musteriler)
            //    .HasForeignKey(e => e.MusteriId);

            //modelBuilder.Entity<Odalar>()
            //    .HasMany(e => e.Konaklamalar)
            //    .WithRequired(e => e.Odalar)
            //    .HasForeignKey(e => e.OdaId);
        }
    }
}
