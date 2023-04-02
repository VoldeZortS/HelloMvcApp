﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beltek.EFApp
{
    internal class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=true;Initial Catalog=OkulDbMvcEF");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();

        }//Fluent API
        //Migration: Kodda yapılan değişiklerin kaydını bir class tutarak veritabanına yanstılmasını sağlar. Migratoinlar geri alınabildiği için son değişiklikleri geri alma şansı da sağlar. (add-migration)
        //update-database: Bu komut ile son oluşturulan migration içindeki değişiklikler veri tabanına yansıtılır.
        //DbContext nesnesi oluşturulur->Model Nesnesi oluştrulur->Nesne oluşturulur->DbSet'e eklenir->SaveChanges() metodu ile veritabanına kaydedilir.
    }
}
