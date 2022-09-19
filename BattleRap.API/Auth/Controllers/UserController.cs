using BattleRap.API.Auth.Models;
using BattleRap.API.Auth.Models.DTOs;
using BattleRap.API.Auth.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace BattleRap.API.Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly GenerateToken _generateToken;
        private readonly TokenConfiguration _configuration;

        public UserController(UserRepository userRepository, GenerateToken generateToken, TokenConfiguration configuration)
        {
            _userRepository = userRepository;
            _generateToken = generateToken;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserDTO userDTO)
        {
            userDTO.Password = EncryptPassword(userDTO.Password);
            await _userRepository.AddAsync(userDTO.ToUser());
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await _userRepository.GetAsync(userLoginDTO.Username, EncryptPassword(userLoginDTO.Password));

            if (user == null)
                return NotFound("Usuário ou senha inválidos");

            return _generateToken.GenerateJwt(user);
        }

        private string EncryptPassword(string password) => Encrypt(Encrypt(password) + Encrypt(_configuration.Secret));

        private string Encrypt(string value)
        {
            var sb = new StringBuilder();

            using (var sha256 = SHA256Managed.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));

                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
