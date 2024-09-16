using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.Users.Models
{
    public class User : DomainEntity, IAggregateRoot
    {
        public string CountryCode { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
    }
}
