﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebsiteQuanLySanPham.Models;

public partial class QuanLySanPhamContext : DbContext
{
    public QuanLySanPhamContext()
    {
    }

    public QuanLySanPhamContext(DbContextOptions<QuanLySanPhamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TANHOANG;Database=QuanLySanPham;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.ToTable("Catalog");

            entity.Property(e => e.CatalogCode).HasMaxLength(50);
            entity.Property(e => e.CatalogName).HasMaxLength(250);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(250);

            entity.HasOne(d => d.Catalog).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatalogId)
                .HasConstraintName("FK_Product_Catalog");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
