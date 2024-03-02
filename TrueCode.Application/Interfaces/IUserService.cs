namespace TrueCode.Application.Interfaces;
public interface IUserService
{
    IQueryable<Domain.Entities.User> GetAll();
}
