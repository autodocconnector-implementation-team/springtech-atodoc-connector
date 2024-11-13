using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using DomainModels = AutodocConnector.Domain.Users.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutodocConnector.Persistence.Models;

namespace AutodocConnector.Persistence.Repositories;

/// <summary>
/// User repository implementation
/// </summary>
internal class AutodocUserRepository : IAutodocUserRepository
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;
    SignInManager<User> _signInManager;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext">Database context</param>
    /// <param name="mapper">Mapper service</param>
    /// <param name="signInManager">Signin manager service</param>
    public AutodocUserRepository(DbContext dbContext, IMapper mapper, SignInManager<User> signInManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    /// <inheritdoc/>
    public async Task<DomainModels.AutodocUser> AutodocLogin(string? username, string password)
    {
        var user = await _dbContext.AutodocUsers.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new Exceptions.AuthentictionException("User not found.");
        }
        if (!await _signInManager.UserManager.CheckPasswordAsync(user, password!))
        {
            throw new Exceptions.AuthentictionException("Login failed");
        }
        return _mapper.Map<DomainModels.AutodocUser>(user);
    }
}
