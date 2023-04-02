using System.Data.Common;
using Microsoft.EntityFrameworkCore;
namespace HelloMvcApp.Models
{
    public class OkulDbContext: DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen>Ogretmenler { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Integrated Security=true;Initial Catalog=BeltekOkulProje");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Ogretmen>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.Ders).HasColumnType("varchar").HasMaxLength(30).IsRequired();

        }//Fluent API
    }
}
