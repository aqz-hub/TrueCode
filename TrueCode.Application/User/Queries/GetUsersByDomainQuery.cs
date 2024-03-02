using MediatR;

namespace TrueCode.Application.User.Queries;
public sealed class GetUsersByDomainQuery(string domain, int page, int pageSize) : IRequest<List<Domain.Entities.User>>
{
    public string Domain { get; set; } = domain;
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}