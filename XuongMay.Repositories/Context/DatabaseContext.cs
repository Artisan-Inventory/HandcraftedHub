using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XuongMay.Contract.Repositories.Entity;
using XuongMay.Repositories.Entity;
using System;
using Microsoft.Extensions.Configuration;

namespace XuongMay.Repositories.Context
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaims,
        ApplicationUserRoles, ApplicationUserLogins, ApplicationRoleClaims, ApplicationUserTokens>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // user
        public virtual DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public virtual DbSet<ApplicationRole> ApplicationRoles => Set<ApplicationRole>();
        public virtual DbSet<ApplicationUserClaims> ApplicationUserClaims => Set<ApplicationUserClaims>();
        public virtual DbSet<ApplicationUserRoles> ApplicationUserRoles => Set<ApplicationUserRoles>();
        public virtual DbSet<ApplicationUserLogins> ApplicationUserLogins => Set<ApplicationUserLogins>();
        public virtual DbSet<ApplicationRoleClaims> ApplicationRoleClaims => Set<ApplicationRoleClaims>();
        public virtual DbSet<ApplicationUserTokens> ApplicationUserTokens => Set<ApplicationUserTokens>();
        public virtual DbSet<UserInfo> UserInfos => Set<UserInfo>();
        public virtual DbSet<Order> Orders => Set<Order>();
        public virtual DbSet<Account> Accounts => Set<Account>();
        public virtual DbSet<CancelReason> CancelReasons => Set<CancelReason>();
        public virtual DbSet<Cart> Carts => Set<Cart>();
        public virtual DbSet<Category> Categories => Set<Category>();
        public virtual DbSet<MediaUpload> MediaUploads => Set<MediaUpload>();
        public virtual DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public virtual DbSet<Payment> Payments => Set<Payment>();
        public virtual DbSet<PaymentDetail> PaymentDetails => Set<PaymentDetail>();
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Reply> Replies => Set<Reply>();
        public virtual DbSet<Review> Reviews => Set<Review>();
        public virtual DbSet<Shop> Shops => Set<Shop>();
        public virtual DbSet<Salary> Salaries => Set<Salary>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Primary Keys

            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Account>().HasKey(a => a.AccountId);
            modelBuilder.Entity<CancelReason>().HasKey(c => c.CancelReasonId);
            modelBuilder.Entity<Cart>().HasKey(c => c.CartId);
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<MediaUpload>().HasKey(m => m.MediaUploadId);
            modelBuilder.Entity<OrderDetail>().HasKey(o => o.OrderDetailId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<PaymentDetail>().HasKey(p => p.PaymentDetailId);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Reply>().HasKey(r => r.ReplyId);
            modelBuilder.Entity<Review>().HasKey(r => r.ReviewId);
            modelBuilder.Entity<Shop>().HasKey(s => s.ShopId);
            // modelBuilder.Entity<UserInfo>().HasKey(u => u.UserInfoId);
            // modelBuilder.Entity<Salary>().HasKey(s => s.SalaryId);
            
            

            #endregion

            #region Relationships
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)  
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(sc => sc.StatusChanges)
                .WithOne(sc => sc.Order)
                .HasForeignKey(sc => sc.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.CancelReason)
                .WithOne(cr => cr.OrderDetail)
                .HasForeignKey<CancelReason>(cr => cr.OrderDetailId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)  
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Category
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Product
            
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Product>()
                .HasMany(p => p.MediaUploads)
                .WithOne(m => m.Product)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Shop
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Shop)
                .HasForeignKey(p => p.ShopId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Replies)
                .WithOne(r => r.Shop)
                .HasForeignKey(r => r.ShopId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Shop>()
                .HasOne(s => s.User)
                .WithOne(u => u.Shop)
                .HasForeignKey<Shop>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
            
            // Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Reply
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Review)
                .WithOne(rv => rv.Reply)
                .HasForeignKey<Reply>(r => r.ReviewId)
                .OnDelete(DeleteBehavior.Cascade); 
            
            // Payment
            modelBuilder.Entity<Payment>()
                .HasMany(p => p.PaymentDetails)
                .WithOne(pd => pd.Payment)
                .HasForeignKey(pd => pd.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Cart
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=HandcraftedHub;TrustServerCertificate=True");
            }
        }

   

    }
}