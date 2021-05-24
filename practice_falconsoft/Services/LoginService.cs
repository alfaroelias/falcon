using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using practice_falconsoft.Entities;
using practice_falconsoft.Models;
using practice_falconsoft.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace practice_falconsoft.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _contexto;
        private readonly AppSettings _appSettings;

        public LoginService(AppDbContext contexto, IOptions<AppSettings> appSettings)
        {
            _contexto = contexto;
            _appSettings = appSettings.Value;
        }

        public LoginResponse Auth(LoginRequest model)
        {
            LoginResponse response = new LoginResponse();

            string password = GetSHA256(model.Password);

            Usuario usuario = _contexto.Usuario.Where(x => x.User == model.User && x.Password == password).FirstOrDefault();

            if (usuario == null) return null;

            response.User = usuario.User;
            response.Token = GetToken(usuario);

            return response;
        }

        private static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.KeySecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, usuario.User)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        } 
    }
}
