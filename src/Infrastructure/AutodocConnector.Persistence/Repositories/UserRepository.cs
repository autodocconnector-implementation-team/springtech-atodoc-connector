using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using AutodocConnector.Domain.Users.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Persistence.Repositories;


public class UserRepository : IUserRepository
{
    public async Task<User> AutodocLoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}
