using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrueCode.Application.Interfaces;
using TrueCode.Application.User.Queries;

namespace TrueCode.Application.User.Handlers;
public sealed class GetUserByDomainQueryHandler(IUserService userService) : IRequestHandler<GetUsersByDomainQuery, List<Domain.Entities.User>>
{
    public async Task<List<Domain.Entities.User>> Handle(GetUsersByDomainQuery request, CancellationToken cancellationToken)
    {
        return await userService.GetAll().Include(u => u.TagToUsers)!
            .ThenInclude(t => t.Tag)
            .Where(u => u.Domain == request.Domain)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
    }
}
