using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.User
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQueryRequest, GetUserInfoQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserInfoQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetUserInfoQueryResponse> Handle(GetUserInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var user =  await _userManager.FindByIdAsync(request.UserId);
            //bos gelme ıhtımalı yok

            return new GetUserInfoQueryResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
            };
        }
    }
}
