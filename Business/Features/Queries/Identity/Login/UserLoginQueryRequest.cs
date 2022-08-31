using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Identity.Login
{
    public class UserLoginQueryRequest : IRequest<UserLoginQueryResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string password { get; set; }
    }
}
