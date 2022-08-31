using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public TokenHandler(IConfiguration configuration, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public AccessToken CreateAccessToken(AppUser user)
        {
            AccessToken token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(25);



            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: SetClaims(user).Result.ToList()
                );
            JwtSecurityTokenHandler tokenHandler = new();

            token.Token = tokenHandler.WriteToken(securityToken);

            return token;
        }
        private async Task<IEnumerable<Claim>> SetClaims(AppUser user)
        {
            //Olusturulucak jwt'deki kişinin bilgileri
            var claims = new List<Claim>();
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));

            return claims;
        }
    }
}

