using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XuongMay.Contract.Repositories.Entity;
using XuongMay.Repositories.Entity;
using System;

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

            
            
            
            #endregion
        }
    }
}