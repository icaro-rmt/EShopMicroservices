﻿using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService
        (DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            //TODO: GetDiscount from Database
            var coupon = await dbContext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon is null)
            {
                coupon = new Coupon
                {
                    ProductName = "No discount",
                    Amount = 0,
                    Description = "No discount"
                };
            }
            logger.LogInformation("Discount is retrieved for ProductName: {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;

        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if(coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request parameters"));
            }
            
            dbContext.Coupons.Add(coupon); 
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfuly created. ProductName: {ProductName}", coupon.ProductName);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            //var coupon = request.
            //if (coupon is null)
            //{
            //    throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request parameters"));
            //}

            //dbContext.Coupons.Add(coupon);
            //await dbContext.SaveChangesAsync();

            //logger.LogInformation("Discount is successfuly created. ProductName: {ProductName}", coupon.ProductName);

            //var couponModel = coupon.Adapt<CouponModel>();
            //return couponModel;
        }

        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            return base.DeleteDiscount(request, context);
        }
    }
}