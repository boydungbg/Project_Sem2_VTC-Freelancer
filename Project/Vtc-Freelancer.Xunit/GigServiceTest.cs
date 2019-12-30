using System;
using System.Collections.Generic;
using Vtc_Freelancer.Models;
using Vtc_Freelancer.Services;
using Xunit;

namespace Vtc_Freelancer.test
{
  public class GigServiceTest
  {
    MyDbContext dbContext = new MyDbContext();
    [Theory]
    [InlineData("Dung dep zai", "Programing", "Web", "fixbug", 1)]
    [InlineData("Dung dep zai", "Programing", "Web", "fixbug", 1)]
    public void CreateServiceStepOneTest1(string title, string category, string subcategory, string tags, int sellerId)
    {
      GigService gigService = new GigService(dbContext);
      Assert.NotNull(gigService.CreateServiceStepOne(title, category, subcategory, tags, sellerId));
    }
    [Fact]
    public void CreateServiceStepTwoTest1()
    {
      GigService gigService = new GigService(dbContext);
      Package package = new Package();
      package.Name = "Basic";
      package.Description = "Description";
      package.Title = "Khong co kho";
      package.DeliveryTime = 1;
      package.NumberRevision = 1;
      package.Price = 50;
      package.ServiceId = 1;
      Assert.True(gigService.CreateServiceStepTwo(package));
    }
    [Fact]
    public void CreateServiceStepThreeTest1()
    {
      GigService gigService = new GigService(dbContext);
      Assert.True(gigService.CreateServiceStepThree(1, "Dung dep zai", null, null));
    }
    [Fact]
    public void reportGigTest1()
    {
      GigService gigService = new GigService(dbContext);
      Assert.True(gigService.reportGig(1, 1, "dung de zai", "dung dep zai"));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetServiceByIDTest1(int? ID)
    {
      GigService gigService = new GigService(dbContext);
      Assert.NotNull(gigService.GetServiceByID(ID));
    }
    [Theory]
    [InlineData(22)]
    [InlineData(null)]
    public void GetServiceByIDTest2(int? ID)
    {
      GigService gigService = new GigService(dbContext);
      Assert.Null(gigService.GetServiceByID(ID));
    }
    [Theory]
    [InlineData(22)]
    [InlineData(2323)]
    public void GetPackageByServiceIDTest1(int? ServiceId)
    {
      GigService gigService = new GigService(dbContext);
      Assert.Empty(gigService.GetPackageByServiceID(ServiceId));
    }
    [Theory]
    [InlineData(22)]
    [InlineData(2323)]
    public void GetPackageByPackageIDTest1(int? packageId)
    {
      GigService gigService = new GigService(dbContext);
      Assert.Null(gigService.GetPackageByPackageID(packageId));
    }
    [Fact]
    public void GetListServiceTest1()
    {
      GigService gigService = new GigService(dbContext);
      Assert.Empty(gigService.GetListService());
    }
    [Theory]
    [InlineData(22)]
    [InlineData(2323)]
    public void GetUserByServiceIdTest1(int ServiceId)
    {
      GigService gigService = new GigService(dbContext);
      Assert.Null(gigService.GetUserByServiceId(ServiceId));

    }
  }
}