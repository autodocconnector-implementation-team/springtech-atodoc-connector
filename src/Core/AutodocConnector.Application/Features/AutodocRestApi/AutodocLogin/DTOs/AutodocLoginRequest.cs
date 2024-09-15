using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs
{
    public class AutodocLoginRequest : IRequest<AutodocLoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}