using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskApp3.Models;

namespace TaskApp3.DbContexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblItem> TblItems { get; set; } = null!;
        public virtual DbSet<TblPartner> TblPartners { get; set; } = null!;
        public virtual DbSet<TblPartnerType> TblPartnerTypes { get; set; } = null!;
        public virtual DbSet<TblPurchase> TblPurchases { get; set; } = null!;
        public virtual DbSet<TblPurchaseDetail> TblPurchaseDetails { get; set; } = null!;
        public virtual DbSet<TblSale> TblSales { get; set; } = null!;
        public virtual DbSet<TblSalesDetail> TblSalesDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DREAMENGINE\\SQLEXPRESS;Database=HW;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPartner>(entity =>
            {
                entity.Property(e => e.PartnerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblPartnerType>(entity =>
            {
                entity.Property(e => e.PratnerTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblPurchase>(entity =>
            {
                entity.Property(e => e.PurchaseId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblPurchaseDetail>(entity =>
            {
                entity.Property(e => e.DetailsId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblSale>(entity =>
            {
                entity.Property(e => e.SalesId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblSalesDetail>(entity =>
            {
                entity.Property(e => e.DetailsId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
