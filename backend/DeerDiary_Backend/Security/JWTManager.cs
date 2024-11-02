﻿using DeerDiary_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace DeerDiary_Backend.Security
{
    public class JWTManager
    {
        private readonly IServiceScopeFactory _scopeFactory;

        private readonly SymmetricSecurityKey _securityKey;
        private readonly SigningCredentials _credentials;

        private readonly string _issuer;
        private readonly string _audience;

        public JWTManager(IConfiguration config, IServiceScopeFactory scopeFactory)
        {
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
            _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            _audience = config["JWT:ValidAudience"];
            _issuer = config["JWT:ValidIssuer"];
            _scopeFactory = scopeFactory;
        }
        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: _credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool VerifyTokenValidity(SecurityToken token) 
        {

            using (var scope = _scopeFactory.CreateScope())
            {
                var Context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var tokenInBlacklist = Context.TokenBlacklists
                    .Any(t => t._token.Contains(token.ToString()) && t._expiry > DateTime.UtcNow);

                Console.WriteLine("Token: " + token.ToString() + " " + "Is in DB?: " + tokenInBlacklist);
                Console.WriteLine("From DB");
                return !tokenInBlacklist;
            }


        }

        // Method to decode Base64 URL encoded string
        private byte[] ParseBase64Url(string base64Url)
        {
            // Replace URL-safe characters
            var base64 = base64Url.Replace('-', '+').Replace('_', '/');

            // Pad the string to make its length a multiple of 4
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}