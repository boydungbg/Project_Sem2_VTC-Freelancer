using System;
using System.Collections.Generic;
using Vtc_Freelancer.Models;
using Vtc_Freelancer.Services;
using Xunit;

namespace Vtc_Freelancer.test
{
  public class OrderServiceTest
  {
    private MyDbContext dbContext = new MyDbContext();
    private HashPassword hashPassword = new HashPassword();
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetPackageByPackageIdTest1(int PackageId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.Null(orderService.GetPackageByPackageId(PackageId));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetServiceByServiceIdTest1(int? ServiceId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.Null(orderService.GetServiceByServiceId(ServiceId));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetUserIdOfSellerBySellerIdTest1(int SellerId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.Null(orderService.GetUserIdOfSellerBySellerId(SellerId));
    }
    [Theory]
    [InlineData(1, 1, 1, 10)]
    [InlineData(1, 2, 2, 2)]
    public void CreateOrderTest1(int UserId, int ServiceId, int PackageId, int Quantity)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.NotNull(orderService.CreateOrder(UserId, ServiceId, PackageId, Quantity));
    }
    [Theory]
    [InlineData(11)]
    [InlineData(22)]
    public void GetOrderByPackageIdTest1(int PackageId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.Null(orderService.GetOrderByPackageId(PackageId));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetOrderByPackageIdTest2(int PackageId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.NotNull(orderService.GetOrderByPackageId(PackageId));
    }
    [Theory]
    [InlineData(12)]
    [InlineData(22)]
    public void GetOrderByOrderIdTest1(int OrderId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.Null(orderService.GetOrderByOrderId(OrderId));
    }
    [Theory]
    [InlineData(12)]
    [InlineData(null)]
    public void GetListOrderbyUserIdTest1(int? userId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      UserService userService = new UserService(dbContext, hashPassword);
      OrderService orderService = new OrderService(dbContext, adminService, userService);
      Assert.Null(orderService.GetListOrderbyUserId(userId));
    }
  }
}