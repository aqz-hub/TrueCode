using Microsoft.EntityFrameworkCore;
using TrueCode.Application.Interfaces;
using TrueCode.Infrastructure;

namespace TrueCode.Application.User;
public sealed class UserService(DatabaseContext context) : IUserService
{
    public IQueryable<Domain.Entities.User> GetAll()
    {
        return context.Users.AsNoTracking();
    }
}
