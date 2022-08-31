using Core.Entities;
using Core.Token;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Identity.Login
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQueryRequest, UserLoginQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        public UserLoginQueryHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        
        public async Task<UserLoginQueryResponse> Handle(UserLoginQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser user;
            
            user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            if (user == null)
                return new UserLoginErrorQueryResponse {Message = "Kullanıcı Adı veya Şifre Hatalı"};

            var checkPassword = await _userManager.CheckPasswordAsync(user, request.password);

            if (checkPassword)
            {
                return new UserLoginSuccesQueryResponse { AccessToken = _tokenHandler.CreateAccessToken(user) };
            }
            return new UserLoginErrorQueryResponse { Message = "Kullanıcı Adı veya Şifre Hatalı" };

        }
    }
}
