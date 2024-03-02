using MediatR;
using Microsoft.EntityFrameworkCore;
using TrueCode.Application.Interfaces;
using TrueCode.Application.User.Queries;
using TrueCode.Domain.Entities;

namespace TrueCode.Application.User.Handlers;
public sealed class GetUserByIdAndDomainQueryHandler(IUserService userService) : IRequestHandler<GetUserByIdAndDomainQuery, Domain.Entities.User?>
{
    public async Task<Domain.Entities.User?> Handle(GetUserByIdAndDomainQuery request, CancellationToken cancellationToken)
    {
        return await userService.GetAll().Include(u => u.TagToUsers)!
            .ThenInclude(t => t.Tag)
            .SingleOrDefaultAsync(x => x.Id == request.Id && x.Domain == request.Domain, cancellationToken);
    }
}
