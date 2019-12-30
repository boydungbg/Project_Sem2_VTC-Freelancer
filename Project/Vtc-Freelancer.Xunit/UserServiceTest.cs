using System;
using System.Collections.Generic;
using Vtc_Freelancer.Models;
using Vtc_Freelancer.Services;
using Xunit;

namespace Vtc_Freelancer.test
{
  public class UserServiceTest
  {
    MyDbContext dbContext = new MyDbContext();
    HashPassword hashPassword = new HashPassword();
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void GetUsersByIDTest1(int id)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.NotNull(userService.GetUserByUserId(id));
    }
    [Theory]
    [InlineData(1123)]
    [InlineData(21233)]
    public void GetUsersByIDTest2(int id)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.GetUserByUserId(id));
    }
    [Theory]
    [InlineData("admin", "admin@gmail.com", "123456")]
    [InlineData("dung1", "dung1@gmail.com", "123456")]
    public void RegisterTest1(string username, string email, string password)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.True(userService.Register(username, email, password));
    }
    [Theory]
    [InlineData("boydungbg", "admin@gmail.com", "123456")]
    [InlineData("dung1", "dung1@gmail.com", "123456")]
    public void RegisterTest2(string username, string email, string password)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.False(userService.Register(username, email, password));
    }
    [Theory]
    [InlineData("boydungbg", "123456")]
    [InlineData("dung1", "123456")]
    [InlineData("admin@gmail.com", "123456")]
    [InlineData("dung1@gmail.com", "123456")]
    public void LoginTest1(string email, string password)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.NotNull(userService.Login(email, password));
    }
    [Theory]
    [InlineData("boyduasdngbg", "123456")]
    [InlineData("dungasdasd1", "123456")]
    [InlineData("asdsddmin@gmail.com", "123456")]
    [InlineData("dunsdsdg1gmail.sdcom", "123456")]
    public void LoginTest2(string email, string password)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.Login(email, password));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetSellerByUserIDTest1(int? userID)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.NotNull(userService.GetSellerByUserID(userID));
    }
    [Theory]
    [InlineData(123)]
    [InlineData(22323)]
    public void GetSellerByUserIDTest2(int? userID)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.GetSellerByUserID(userID));
    }
    [Theory]
    [InlineData("boydungbg")]
    [InlineData("dung1")]
    public void GetUserByUsernameTest1(string username)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.NotNull(userService.GetUserByUsername(username));
    }
    [Theory]
    [InlineData("boydungbgsss")]
    [InlineData("dung1ssss")]
    public void GetUserByUsernameTest2(string username)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.GetUserByUsername(username));
    }
    [Theory]
    [InlineData("admin@gmail.com")]
    [InlineData("dung1@gmail.com")]
    public void GetUserByEmailTest1(string email)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.NotNull(userService.GetUserByEmail(email));
    }
    [Theory]
    [InlineData("admisssn@gmail.com")]
    [InlineData("dungsss1@gmail.com")]
    public void GetUserByEmailTest2(string email)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.GetUserByEmail(email));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetLanguagesByUserIdTest1(int? userId)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.GetLanguagesByUserId(userId));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetSkillsByUserIdTest1(int? userId)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.GetSkillsByUserId(userId));
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void getCategoryOfSellerByUserId(int userId)
    {
      UserService userService = new UserService(dbContext, hashPassword);
      Assert.Null(userService.getCategoryOfSellerByUserId(userId));
    }
  }
}
