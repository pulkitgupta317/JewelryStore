using JewelryStore.DataLayer;
using JewelryStore.DataLayer.Models;
using JewelryStore.DataLayer.Repositories.Contracts;
using JewelryStore.Services.Contracts;
using JewelryStore.Services.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public AuthReponseDto AuthenticateUser(AuthRequestDto authRequest)
        {
            User user = _userRepository.GetUser(authRequest.UserName);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User doesnt exist");
            }
            else if (!user.IsActive)
            {
                throw new UnauthorizedAccessException("User is not active");
            }
            else if (!user.Password.Equals(authRequest.Password))
            {
                throw new UnauthorizedAccessException("Invalid Username or Password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole.Id.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthenticationSetting:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthenticationSetting:Issuer"],
                audience: _configuration["AuthenticationSetting:Audience"],
                signingCredentials: credentials,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120)
                );

            return new AuthReponseDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.Name,
                UserRole = user.UserRole.Name
            };
        }
    }
}
