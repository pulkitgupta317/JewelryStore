using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace JewelryStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController: ControllerBase
    {
        private List<Claim> _claims;

        public Guid UserRoleId
        {
            get
            {
                _claims = HttpContext.User.Claims.ToList();
                return Guid.Parse(_claims.FirstOrDefault(t => t.Type == ClaimTypes.Role).Value);
            }
        }
    }
}
