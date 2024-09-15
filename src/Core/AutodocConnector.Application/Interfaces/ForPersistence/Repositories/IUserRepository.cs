using AutodocConnector.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// This is used to check whether the user exists in the Identity Database or not.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> GetUserByLoginCredentialsAsync(string username, string password);
    }
}
