using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GEM.Server.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ClassAndGym> ClassAndGyms { get; set; }

    public virtual DbSet<ClassSubscription> ClassSubscriptions { get; set; }

    public virtual DbSet<ClassTime> ClassTimes { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Enrolled> Enrolleds { get; set; }

    public virtual DbSet<MealPlan> MealPlans { get; set; }

    public virtual DbSet<NutritionFact> NutritionFacts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SubMealPlan> SubMealPlans { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1KJUL3H;Database=project8;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__415B03D8B648D434");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cartID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__userID__3F466844");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__283983960ECA9F39");

            entity.ToTable("CartItem");

            entity.Property(e => e.CartItemId).HasColumnName("cartItemID");
            entity.Property(e => e.CartId).HasColumnName("cartID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CartItem__cartID__4222D4EF");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__CartItem__produc__4316F928");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1F89952DA4C");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CategoryName).HasColumnName("categoryName");
        });

        modelBuilder.Entity<ClassAndGym>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassAnd__3213E83F635E8F90");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Flag).HasColumnName("flag");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Trainer)
                .HasMaxLength(100)
                .HasColumnName("trainer");
        });

        modelBuilder.Entity<ClassSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassSub__3213E83F68BB9C98");

            entity.ToTable("ClassSubscription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("classId");
            entity.Property(e => e.Duration)
                .HasColumnType("datetime")
                .HasColumnName("duration");
            entity.Property(e => e.FinalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("finalPrice");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSubscriptions)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassSubs__class__5FB337D6");
        });

        modelBuilder.Entity<ClassTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassTim__3213E83FC98AC624");

            entity.ToTable("ClassTime");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("classId");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassTimes)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassTime__class__5CD6CB2B");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.ContcatId).HasName("PK__ContactU__EFD5B74A9BA22942");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MessageContent).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(200);
        });

        modelBuilder.Entity<Enrolled>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrolled__3213E83FB0FB49B4");

            entity.ToTable("Enrolled");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassSubId).HasColumnName("classSubId");
            entity.Property(e => e.ClassTimeId).HasColumnName("classTimeId");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(100)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ClassSub).WithMany(p => p.Enrolleds)
                .HasForeignKey(d => d.ClassSubId)
                .HasConstraintName("FK__Enrolled__classS__6383C8BA");

            entity.HasOne(d => d.ClassTime).WithMany(p => p.Enrolleds)
                .HasForeignKey(d => d.ClassTimeId)
                .HasConstraintName("FK__Enrolled__classT__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.Enrolleds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Enrolled__userId__628FA481");
        });

        modelBuilder.Entity<MealPlan>(entity =>
        {
            entity.HasKey(e => e.MealPlanId).HasName("PK__MealPlan__0620DB5620627D7B");

            entity.Property(e => e.MealPlanId)
                .ValueGeneratedNever()
                .HasColumnName("MealPlanID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<NutritionFact>(entity =>
        {
            entity.HasKey(e => e.NutritionId).HasName("PK__Nutritio__8A74A1B6BBBD7D55");

            entity.Property(e => e.NutritionId).HasColumnName("NutritionID");
            entity.Property(e => e.Carbohydrates).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DietaryFiber).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Iron).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.MealPlanId).HasColumnName("MealPlanID");
            entity.Property(e => e.Protein).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SaturatedFat).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Sugars).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TotalFat).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.VitaminD).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.SubMealPlansNavigation).WithMany(p => p.NutritionFacts)
                .HasForeignKey(d => d.SubMealPlans)
                .HasConstraintName("FK__Nutrition__SubMe__5535A963");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__0809337D9192CE9E");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShippngStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Order__userID__45F365D3");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__3724BD7242948D60");

            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId).HasColumnName("orderItemID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__order__4AB81AF0");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__produ__4BAC3F29");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__A0D9EFA660C9842C");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("paymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Statues)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payment__orderID__6D0D32F4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D14A543BDAD4");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasColumnName("productName");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__categor__3C69FB99");
        });

        modelBuilder.Entity<SubMealPlan>(entity =>
        {
            entity.HasKey(e => e.SubMealPlanId).HasName("PK__SubMealP__131D71D30C70BB94");

            entity.Property(e => e.SubMealPlanId)
                .ValueGeneratedNever()
                .HasColumnName("SubMealPlanID");
            entity.Property(e => e.Instructions).HasColumnType("text");
            entity.Property(e => e.MealPlanId).HasColumnName("MealPlanID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.MealPlan).WithMany(p => p.SubMealPlans)
                .HasForeignKey(d => d.MealPlanId)
                .HasConstraintName("FK__SubMealPl__MealP__52593CB8");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Testimonialid).HasName("PK__Testimon__919D3A4BFABE5708");

            entity.ToTable("Testimonial");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Hidden");
            entity.Property(e => e.TestimonialSubmit).HasDefaultValue(false);
            entity.Property(e => e.Text).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Testimoni__userI__6754599E");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.TipsId).HasName("PK__Tips__9A110991835B2CBD");

            entity.Property(e => e.TipsId)
                .ValueGeneratedNever()
                .HasColumnName("TipsID");
            entity.Property(e => e.Tips).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF88C75F19");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A9406B0F").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FristName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(13);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
