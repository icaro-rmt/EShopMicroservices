﻿using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext: DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options)
            :base(options)
        {    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id=1, ProductName="Iphone 14", Description="Iphone Discount", Amount=150 },
                new Coupon { Id=2, ProductName="Samsung S24", Description= "Samsung Discount", Amount=200 }                
                );
        }
    }
}