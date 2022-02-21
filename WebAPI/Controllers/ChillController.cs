using Entitys.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChillController : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpGet("AdminText")]
        public string AdminText()
        {
            return "This is admin";
        }
    }
}
