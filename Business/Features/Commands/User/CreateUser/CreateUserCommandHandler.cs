using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser() //ellen userer nesnesini olusturduk
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
            };

            if (request.PasswordConfirm != request.Password)
                throw new Exception("Şifreler Farklı");

            var userresult = await _userManager.CreateAsync(user, request.Password); //database'e kaydettık sıfreyı ayrı yazdık o sayede haslandi


            if (userresult.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, "Customer"); //user'a role ekledik
                return new() { Message ="Kullanıcı Başarıyla Eklenmiştir",Succeeded=true};
            }
            else
            {
                //throw new Exception("Böyle bir kullanıcı bulunmaktadır");
                return  new() { Succeeded = false, Message = "Böyle bir kullanıcı bulunmaktadır" };
            }
        }
    }
}
