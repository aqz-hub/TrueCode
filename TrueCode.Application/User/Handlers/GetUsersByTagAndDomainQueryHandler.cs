using MediatR;
using Microsoft.EntityFrameworkCore;
using TrueCode.Application.Interfaces;
using TrueCode.Application.User.Queries;

namespace TrueCode.Application.User.Handlers;
public sealed class GetUsersByTagAndDomainQueryHandler(IUserService userService) : IRequestHandler<GetUsersByTagAndDomainQuery, List<Domain.Entities.User>>
{
    public async Task<List<Domain.Entities.User>> Handle(GetUsersByTagAndDomainQuery request, CancellationToken cancellationToken)
    {
        return await userService.GetAll().Include(u => u.TagToUsers)!
            .ThenInclude(t => t.Tag)
            .Where(u => u.Domain == request.Domain && u.TagToUsers!.Any(t => t.Tag!.Value == request.TagValue))
            .ToListAsync(cancellationToken);
    }
}
