using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Entitys.Models.Users;
using Entitys.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitys.DTOs.Users;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryMannager _repositoryManager;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IMapper _mapper;
        private readonly SecurityTokenHandler securityTokenHandler;
        public UserController(IRepositoryMannager repositoryManager, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _mapper = mapper;
            securityTokenHandler = new JwtSecurityTokenHandler();
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<User>> LoginAsync([FromBody] UserCredentials credentials, CancellationToken cancellationToken)
        {
            if (credentials is null)
                return BadRequest("No Data");
            UserAuthInfoDTO userAuthInfoDTO = new();
            var user = await _repositoryManager.User.LoginAsync(credentials.Login, credentials.Password, false, cancellationToken);
            if (user is not null)
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Value.SecretKey);
                var tokenDiscriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.GivenName, user.FirstName),
                            new Claim(ClaimTypes.Name,user.LastName),
                            new Claim(ClaimTypes.Role,user.Role.ToString())
                        }
                    ),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };
                var securityToken = securityTokenHandler.CreateToken(tokenDiscriptor);
                userAuthInfoDTO.Token = securityTokenHandler.WriteToken(securityToken);
                userAuthInfoDTO.UserDetails = _mapper.Map<UserDTO>(user);
            }
            if (string.IsNullOrEmpty(userAuthInfoDTO?.Token))
                return Unauthorized(new { message = "Error Login or Password" });
            return Ok(userAuthInfoDTO);
        }

       /* [HttpGet("register")]
        public async Task<IActionResult> Register()
        {

        }*/
    }
}
