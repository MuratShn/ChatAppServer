using Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Identity.Login
{
    public class UserLoginQueryResponse
    {

    }
    public class UserLoginSuccesQueryResponse : UserLoginQueryResponse
    {
        public AccessToken AccessToken { get; set; }
    }
    public class UserLoginErrorQueryResponse : UserLoginQueryResponse
    {
        public string Message { get; set; }
    }
}
