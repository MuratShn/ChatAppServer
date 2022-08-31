using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.User
{
    public class GetUserInfoQueryRequest : IRequest<GetUserInfoQueryResponse>
    {
        public string UserId { get; set; }
    }
}
