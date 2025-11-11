using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demo1.Models;

namespace demo1.Context;

public partial class Db542Context : DbContext
{
    public Db542Context()
    {
    }

    public Db542Context(DbContextOptions<Db542Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Idformatorprod> Idformatorprods { get; set; }

    public virtual DbSet<Productsmaterial> Productsmaterials { get; set; }

    public virtual DbSet<Proizvodstvo> Proizvodstvos { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    public virtual DbSet<Zakazchiki> Zakazchikis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=lorksipt.ru:5432;Database=db513;Username=user513;password=30472");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Idformatorprod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idformatorprod_pkey");

            entity.ToTable("idformatorprod");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Productsmaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productsmaterials_pkey");

            entity.ToTable("productsmaterials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Prodormatid).HasColumnName("prodormatid");

            entity.HasOne(d => d.Prodormat).WithMany(p => p.Productsmaterials)
                .HasForeignKey(d => d.Prodormatid)
                .HasConstraintName("productsmaterials_prodormatid_fkey");
        });

        modelBuilder.Entity<Proizvodstvo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proizvodstvo_pkey");

            entity.ToTable("proizvodstvo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kodprod).HasColumnName("kodprod");
            entity.Property(e => e.Kolvomaterial).HasColumnName("kolvomaterial");
            entity.Property(e => e.Kolvoprod).HasColumnName("kolvoprod");
            entity.Property(e => e.Materialid).HasColumnName("materialid");
            entity.Property(e => e.Materialkod).HasColumnName("materialkod");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Unitmaterial).HasColumnName("unitmaterial");
            entity.Property(e => e.Unitprod).HasColumnName("unitprod");

            entity.HasOne(d => d.Material).WithMany(p => p.ProizvodstvoMaterials)
                .HasForeignKey(d => d.Materialid)
                .HasConstraintName("proizvodstvo_materialid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ProizvodstvoProducts)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("proizvodstvo_productid_fkey");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("specification_pkey");

            entity.ToTable("specification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creatorid).HasColumnName("creatorid");
            entity.Property(e => e.Kolvomat).HasColumnName("kolvomat");
            entity.Property(e => e.Kolvoprod).HasColumnName("kolvoprod");
            entity.Property(e => e.Materialid).HasColumnName("materialid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.Creator).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.Creatorid)
                .HasConstraintName("specification_creatorid_fkey");

            entity.HasOne(d => d.Material).WithMany(p => p.SpecificationMaterials)
                .HasForeignKey(d => d.Materialid)
                .HasConstraintName("specification_materialid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.SpecificationProducts)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("specification_productid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.Banned).HasColumnName("banned");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Userdefault).HasColumnName("userdefault");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zakaz_pkey");

            entity.ToTable("zakaz");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Buyerid).HasColumnName("buyerid");
            entity.Property(e => e.Kolvo).HasColumnName("kolvo");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.Salesmanid).HasColumnName("salesmanid");
            entity.Property(e => e.Summ).HasColumnName("summ");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.Buyer).WithMany(p => p.ZakazBuyers)
                .HasForeignKey(d => d.Buyerid)
                .HasConstraintName("zakaz_buyerid_fkey");

            entity.HasOne(d => d.Salesman).WithMany(p => p.ZakazSalesmen)
                .HasForeignKey(d => d.Salesmanid)
                .HasConstraintName("zakaz_salesmanid_fkey");
        });

        modelBuilder.Entity<Zakazchiki>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zakazchiki_pkey");

            entity.ToTable("zakazchiki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Boyer).HasColumnName("boyer");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Salesman).HasColumnName("salesman");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
