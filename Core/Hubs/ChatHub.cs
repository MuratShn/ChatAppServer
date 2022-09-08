using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;
        public ChatHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Login(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            user.ClientId = Context.ConnectionId;
            await _userManager.UpdateAsync(user);
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            //var olmayan client ıdye mesaj vs gonderdırıgmızde hata almıyorum hata alsaydık egerkı kullanıcı her cıkıs yaptıgında burdan userin client idsini silicektik
            var user = _userManager.Users.FirstOrDefault(x => x.ClientId == Context.ConnectionId);
            
            if (user != null)
            {
                user.ClientId = null;
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
