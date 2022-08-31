using Core.Entities;
using Core.Token;
using DataAccess.Abstract.Message;
using DataAccess.Concrete.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMessageWriteRepository _messageWriteRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        public TestController(IMessageWriteRepository messageWriteRepository, UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _messageWriteRepository = messageWriteRepository;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "muratsahh_61@outlook.com",
                FirstName = "Murat",
                UserName = "murat_"
            }, "123") ;
            await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "mehmet_61@outlook.com",
                FirstName = "Mehmet",
                UserName = "mehmet_"
            }, "123");
            await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "ahmet_61@outlook.com",
                FirstName = "Ahmet",
                UserName = "ahmet_"
            }, "123");


            return Ok();
        }
    
        [HttpGet("login")]
        public async Task<IActionResult> login()
        {
            var user = await _userManager.FindByIdAsync("44a76af0-bf89-405e-9ab0-d4d05a940456");
            var result = _tokenHandler.CreateAccessToken(user);
            return Ok(result);
        }
        [HttpGet("auth")]
        [Authorize]
        public async Task<IActionResult> author()
        {
            return Ok();
        }
    }
}
