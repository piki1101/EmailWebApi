using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;
using Services.Repositories;

namespace Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }
        public string Authenticate(string email, string plainTextPassword)
        {
            EmailAppUser user = _userRepository.GetByEmail(email);

            string hashedPassword = _passwordHasher.HashPassword(plainTextPassword);
            if (user.Password == hashedPassword)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                };

                var token = new JwtSecurityToken(
                    issuer: _issuer,
                audience: _audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            throw new InvalidCredentialsException($"invalid credentials");
        }
    }
}
