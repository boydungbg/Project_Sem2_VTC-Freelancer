using System;
using System.Collections.Generic;
using Vtc_Freelancer.Models;
using Vtc_Freelancer.Services;
using Xunit;

namespace Vtc_Freelancer.test
{
  public class RequestServiceTest
  {
    MyDbContext dbContext = new MyDbContext();
    [Theory]
    [InlineData(1, "Dung dep zai", "Programing", "Web", "3 day", 3000, null)]
    [InlineData(2, "Dung yeu lan", "Programing", "Web", "3 day", 3000, null)]
    public void CreateRequestTest1(int? UserId, string inputRequest, string category, string SubCategory, string inputDeliveredTime, double inputBudget, string urlFile)
    {
      RequestService requestService = new RequestService(dbContext);
      Assert.True(requestService.CreateRequest(UserId, inputRequest, category, SubCategory, inputDeliveredTime, inputBudget, urlFile));
    }
    [Theory]
    [InlineData(1123)]
    [InlineData(1232)]
    public void getListRequestByUserIdTest1(int userId)
    {
      RequestService requestService = new RequestService(dbContext);
      Assert.Empty(requestService.getListRequestByUserId(userId));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void getListRequestByUserIdTest2(int userId)
    {
      RequestService requestService = new RequestService(dbContext);
      Assert.Empty(requestService.getListRequestByUserId(userId));
    }
  }
}