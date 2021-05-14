using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using JewelryStore.Controllers;

namespace JewelryStore.Tests
{
    public static class CommonMock
    {
        //public static void MockHttpContext<T>(this T obj, Guid userId, Guid userRoleId) where T: BaseController
        //{
        //    List<Claim> claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimTypes.Role, userRoleId.ToString()));
        //    claims.Add(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
        //    var mockContext = new Mock<HttpContext>(MockBehavior.Strict);
        //    mockContext.SetupGet(h => h.User.Claims).Returns(claims);

        //    obj.ControllerContext = new ControllerContext()
        //    {
        //        MockHttpContext = mockContext.Object
        //    };
        //}
    }
}
