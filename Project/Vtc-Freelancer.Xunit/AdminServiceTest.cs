using System;
using System.Collections.Generic;
using Vtc_Freelancer.Models;
using Vtc_Freelancer.Services;
using Xunit;

namespace Vtc_Freelancer.test
{
  public class AdminServiceTest
  {
    MyDbContext dbContext = new MyDbContext();
    HashPassword hashPassword = new HashPassword();
    [Fact]
    public void GetListServiceTest1()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<Service> listService = adminService.GetListServices("Asdasd");
      Assert.Empty(listService);
    }
    [Fact]
    public void GetListOrdersTest1()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<Orders> listOrders = adminService.GetListOrders("asssssxzcsadfsdf");
      Assert.Null(listOrders);
    }
    [Fact]
    public void GetListRequestsTest1()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<Request> ListRequest = adminService.GetListRequests("asdasda");
      Assert.Empty(ListRequest);
    }
    [Fact]
    public void GetListReportTest1()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<Report> ListReports = adminService.GetListReport("asdasd");
      Assert.Empty(ListReports);
    }
    [Fact]
    public void GetListUsersTest1()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<Users> ListUsers = adminService.GetListUsers("");
      Assert.NotEmpty(ListUsers);
    }
    [Fact]
    public void GetListUsersTest2()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<Users> ListUsers = adminService.GetListUsers("sadasdasd");
      Assert.Empty(ListUsers);
    }
    [Theory]
    [InlineData("Programing", 1, "Web")]
    [InlineData("Programing", 1, "App")]
    [InlineData("Design", 1, "Logo")]
    [InlineData("Design", 1, "Banner")]
    public void CreateCategoryTest1(string CategoryName, int ParenId, string SubCategoryName)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.True(adminService.CreateCategory(CategoryName, ParenId, SubCategoryName));
    }
    [Theory]
    [InlineData(999)]
    [InlineData(2312)]
    public void GetListImageServiceTest1(int? idService)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      List<ImageService> ListImageService = adminService.GetListImageService(idService);
      Assert.Empty(ListImageService);
    }
    [Theory]
    [InlineData(999)]
    [InlineData(2312)]
    public void ChangeStatusUserTest1(int UserId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.False(adminService.ChangeStatusUser(UserId));
    }
    [Theory]
    [InlineData(5)]
    [InlineData(6)]
    public void ChangeStatusUserTest2(int UserId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.True(adminService.ChangeStatusUser(UserId));
    }
    [Theory]
    [InlineData(999)]
    [InlineData(2312)]
    public void HandleServiceTest1(int ReportId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.False(adminService.HandleService(ReportId));
    }
    [Theory]
    [InlineData(999)]
    [InlineData(2312)]
    public void ChangeStatusReportTest1(int ReportId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.False(adminService.ChangeStatusReport(ReportId));
    }
    [Theory]
    [InlineData("Programing")]
    [InlineData("Design")]
    public void GetListCategoryByParentIdTest1(string CategoryName)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.NotEmpty(adminService.GetListCategoryByParentId(CategoryName));
    }
    [Fact]
    public void GetListCategoryByTest1()
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.NotEmpty(adminService.GetListCategoryBy());
    }
    [Theory]
    [InlineData(56)]
    [InlineData(12312)]
    public void GetListSubCategoryByParentIdTest1(int parentId)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.Empty(adminService.GetListSubCategoryByParentId(parentId));
    }
    [Theory]
    [InlineData(1)]
    public void GetListSubCategoryByCategoryParentIdTest1(int id)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.NotEmpty(adminService.GetListSubCategoryByCategoryParentId(id));
    }
    [Theory]
    [InlineData(123)]
    [InlineData(1233)]
    public void GetListSubCategoryByCategoryParentIdTest2(int id)
    {
      AdminService adminService = new AdminService(dbContext, hashPassword);
      Assert.Empty(adminService.GetListSubCategoryByCategoryParentId(id));
    }
  }
}
