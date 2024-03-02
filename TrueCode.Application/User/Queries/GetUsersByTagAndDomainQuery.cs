using MediatR;

namespace TrueCode.Application.User.Queries;
public sealed class GetUsersByTagAndDomainQuery(string tagValue, string domain) : IRequest<List<Domain.Entities.User>>
{
    public string TagValue { get; } = tagValue;
    public string Domain { get; } = domain;
}