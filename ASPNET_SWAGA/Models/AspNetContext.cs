using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Models;

public partial class AspNetContext : DbContext
{
    public AspNetContext()
    {
    }

    public AspNetContext(DbContextOptions<AspNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Cartitem> Cartitems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Infoproduct> Infoproducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Ordersitem> Ordersitems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    // Строка подключения настраивается в Program.cs (из appsettings.json), здесь ничего не нужно.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartsId).HasName("PK__CARTS__DFAD877940BF3A36");

            entity.ToTable("CARTS");

            entity.HasIndex(e => e.IdUser, "UQ__CARTS__ED4DE4432946BEF1").IsUnique();

            entity.Property(e => e.CartsId).HasColumnName("CartsID");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CARTS__ID_User__534D60F1");
        });

        modelBuilder.Entity<Cartitem>(entity =>
        {
            entity.HasKey(e => e.CartItemsId).HasName("PK__CARTITEM__5D2644754B6A111B");

            entity.ToTable("CARTITEMS");

            entity.Property(e => e.CartItemsId).HasColumnName("CartItemsID");
            entity.Property(e => e.CountItems).HasDefaultValue(1);
            entity.Property(e => e.IdCart).HasColumnName("ID_Cart");
            entity.Property(e => e.IdProducts).HasColumnName("ID_Products");

            entity.HasOne(d => d.IdCartNavigation).WithMany(p => p.Cartitems)
                .HasForeignKey(d => d.IdCart)
                .HasConstraintName("FK__CARTITEMS__ID_Ca__5FB337D6");

            entity.HasOne(d => d.IdProductsNavigation).WithMany(p => p.Cartitems)
                .HasForeignKey(d => d.IdProducts)
                .HasConstraintName("FK__CARTITEMS__ID_Pr__60A75C0F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoriesId).HasName("PK__CATEGORI__EFF907B02C097386");

            entity.ToTable("CATEGORIES");

            entity.HasIndex(e => e.CategoriesItems, "UQ__CATEGORI__03BD53FF9A2D0DEA").IsUnique();

            entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");
            entity.Property(e => e.CategoriesItems).HasMaxLength(40);
        });

        modelBuilder.Entity<Infoproduct>(entity =>
        {
            entity.HasKey(e => e.InfoProductsId).HasName("PK__INFOPROD__9E2FF257CA75C6B5");

            entity.ToTable("INFOPRODUCTS");

            entity.HasIndex(e => e.NameProduct, "UQ__INFOPROD__DF0C7103F8497F50").IsUnique();

            entity.Property(e => e.InfoProductsId).HasColumnName("InfoProductsID");
            entity.Property(e => e.DescriptionProduct).HasMaxLength(500);
            entity.Property(e => e.NameProduct).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("PK__ORDERS__630B995654ACF408");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrdersId).HasColumnName("OrdersID");
            entity.Property(e => e.DateOrder).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdCart).HasColumnName("ID_Cart");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCartNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__ID_Cart__6477ECF3");
        });

        modelBuilder.Entity<Ordersitem>(entity =>
        {
            entity.HasKey(e => e.OrderItemsId).HasName("PK__ORDERSIT__D5BB2535357A86DB");

            entity.ToTable("ORDERSITEMS");

            entity.Property(e => e.OrderItemsId).HasColumnName("OrderItemsID");
            entity.Property(e => e.CountItem).HasDefaultValue(1);
            entity.Property(e => e.IdOrders).HasColumnName("ID_Orders");
            entity.Property(e => e.IdProducts).HasColumnName("ID_Products");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdOrdersNavigation).WithMany(p => p.Ordersitems)
                .HasForeignKey(d => d.IdOrders)
                .HasConstraintName("FK__ORDERSITE__ID_Or__693CA210");

            entity.HasOne(d => d.IdProductsNavigation).WithMany(p => p.Ordersitems)
                .HasForeignKey(d => d.IdProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERSITE__ID_Pr__6A30C649");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductsId).HasName("PK__PRODUCTS__BB48EDC5957960A9");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductsId).HasColumnName("ProductsID");
            entity.Property(e => e.IdCategories).HasColumnName("ID_Categories");
            entity.Property(e => e.IdInfoProducts).HasColumnName("ID_InfoProducts");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");

            entity.HasOne(d => d.IdCategoriesNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTS__ID_Cat__5CD6CB2B");

            entity.HasOne(d => d.IdInfoProductsNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdInfoProducts)
                .HasConstraintName("FK__PRODUCTS__ID_Inf__5BE2A6F2");

            // Остаток — токен конкурентности: два параллельных резервирования не смогут оба списать один и тот же остаток.
            entity.Property(e => e.StockCount).IsConcurrencyToken();
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationsId).HasName("PK_RESERVATIONS");

            entity.ToTable("RESERVATIONS");

            entity.Property(e => e.ReservationsId).HasColumnName("ReservationsID");
            entity.Property(e => e.IdUser).HasColumnName("ID_Users");
            entity.Property(e => e.IdProducts).HasColumnName("ID_Products");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RESERVATIONS_USERS");

            entity.HasOne(d => d.IdProductsNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdProducts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RESERVATIONS_PRODUCTS");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolesId).HasName("PK__ROLES__C4B2782087AD628A");

            entity.ToTable("ROLES");

            entity.HasIndex(e => e.Roles, "UQ__ROLES__F92229BC2A08F956").IsUnique();

            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.Roles)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__USERS__A349B042A7D45BC8");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.LoginUser, "UQ__USERS__1B979CD11BB8AE9B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__USERS__A9D10534E92C5E0F").IsUnique();

            entity.Property(e => e.UsersId).HasColumnName("UsersID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.IdRoles).HasColumnName("ID_Roles");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOGIN_USER");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolesNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRoles)
                .HasConstraintName("FK__USERS__ID_Roles__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
