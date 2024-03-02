using MediatR;

namespace TrueCode.Application.User.Queries;
public sealed class GetUserByIdAndDomainQuery(Guid id, string domain) : IRequest<Domain.Entities.User?>
{
    public Guid Id { get; } = id;
    public string Domain { get; } = domain;
}
