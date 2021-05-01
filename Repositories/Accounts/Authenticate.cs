using Microsoft.IdentityModel.Tokens;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project.Repositories.Accounts
{
    public class Authenticate:IAuthenticate
    {
        private AppDbContext context = new AppDbContext();
        private readonly string key;
        SecurityTokenDescriptor tokenDescriptor;
        JwtSecurityTokenHandler tokenHandler;
        public Authenticate(string key)
        {
            this.key = key;
        }

        public string Login(string username, string password)
        {
            if (context.Customers.Any(c => c.username == username && c.password == password))
                return tokenCreator(username);
            else if (context.Mechanics.Any(m => m.username == username && m.password == password))
                return tokenCreator(username);
            else if (context.Garages.Where(g => g.username == username && g.password == password).FirstOrDefault() != null)
                return tokenCreator(username);
            else if (context.SystemAdmin.Any(s => s.username == username && s.password == password))
                return tokenCreator(username);
            else
                return null;

        }

        public string tokenCreator(string username)
        {

            tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool Logout()
        {
            if (tokenHandler == null)
                return true;
            else 
                return false;
        }
    }
}
