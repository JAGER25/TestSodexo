using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestDomain.Entities;

#nullable disable

namespace TestPersistence.DbContextApi
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturasProducto> FacturasProductos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseOracle("User Id=USR_TEST;Password=Pr53b42021+;Data Source=localhost:1521/xe;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("USR_TEST")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura)
                    .HasName("FACTURAS_PK");

                entity.ToTable("FACTURAS");

                entity.Property(e => e.Idfactura)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDFACTURA");

                entity.Property(e => e.Descuento)
                    .HasColumnType("NUMBER(20,2)")
                    .HasColumnName("DESCUENTO");

                entity.Property(e => e.Documentocliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTOCLIENTE");

                entity.Property(e => e.Fecha)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Iva)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IVA");

                entity.Property(e => e.Nombrecliente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECLIENTE");

                entity.Property(e => e.Numerofactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROFACTURA");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("NUMBER(20,2)")
                    .HasColumnName("SUBTOTAL");

                entity.Property(e => e.Tipopago)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TIPOPAGO");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER(20,2)")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Totaldescuento)
                    .HasColumnType("NUMBER(20,2)")
                    .HasColumnName("TOTALDESCUENTO");

                entity.Property(e => e.Totalimpuesto)
                    .HasColumnType("NUMBER(20,2)")
                    .HasColumnName("TOTALIMPUESTO");
            });

            modelBuilder.Entity<FacturasProducto>(entity =>
            {
                entity.HasKey(e => e.Idfacturaproductos)
                    .HasName("FACTURAS_PRODUCTOS_PK");

                entity.ToTable("FACTURAS_PRODUCTOS");

                entity.Property(e => e.Idfacturaproductos)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDFACTURAPRODUCTOS");

                entity.Property(e => e.FacturasIdfactura)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FACTURAS_IDFACTURA");

                entity.Property(e => e.ProductosIdproducto)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRODUCTOS_IDPRODUCTO");

                entity.HasOne(d => d.FacturasIdfacturaNavigation)
                    .WithMany(p => p.FacturasProductos)
                    .HasForeignKey(d => d.FacturasIdfactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FACTURAS_PRODUCTOS_FACTURAS_FK");

                entity.HasOne(d => d.ProductosIdproductoNavigation)
                    .WithMany(p => p.FacturasProductos)
                    .HasForeignKey(d => d.ProductosIdproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FACTURAS_PRODUCTO_PRODUCTOS_FK");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PRODUCTOS_PK");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.Idproducto)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Precio)
                    .HasColumnType("NUMBER(20,2)")
                    .HasColumnName("PRECIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
