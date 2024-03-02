using Microsoft.Extensions.Hosting;
using TrueCode.Application;
using TrueCode.Infrastructure;
using MediatR;
using TrueCode.Application.User.Queries;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

using var host = builder.Build();
await host.StartAsync();

var mediator = (IMediator)host.Services.GetService(typeof(IMediator))!;

var running = true;
while(running)
{
    Console.WriteLine("\n1. Get user by id and domain.\n2. Get users by domain.\n3. Get users by tag and domain.\n4. Stop the program");
    var command = Console.ReadLine();
    switch(command)
    {
        case "1":
            await GetUserByIdAndDomain();
            break;
        case "2":
            await GetUsersByDomain();
            break;
        case "3":
            await GetUsersByTagAndDomain();
            break;
        case "4":
            running = false;
            break;
    }
}

string RequestDomain()
{
    Console.WriteLine("Domain:");
    return Console.ReadLine()!;
}

async Task GetUserByIdAndDomain()
{
    Console.WriteLine("ID:");
    var userId = Console.ReadLine();
    if (string.IsNullOrEmpty(userId))
    {
        Console.WriteLine("User id can't be null or empty");
        return;
    }
    if (!Guid.TryParse(userId, out var userIdResult))
    {
        Console.WriteLine("User id is not valid");
        return;
    }

    var domain = RequestDomain();
    if (string.IsNullOrEmpty(domain))
    {
        Console.WriteLine("Domain can't be null or empty");
        return;
    }

    var user = await mediator.Send(new GetUserByIdAndDomainQuery(userIdResult, domain));
    if (user is null)
    {
        Console.WriteLine("Couldn't find a user with the current ID and domain");
        return;
    }

    var tags = user!.TagToUsers != null ? string.Join("; ", user!.TagToUsers.Select(x => x.Tag).Select(x => x.Value)!) : "no tags";
    Console.WriteLine($"Username: {user!.Name}\nTags: {tags}");
}

async Task GetUsersByDomain()
{
    var domain = RequestDomain();
    if (string.IsNullOrEmpty(domain))
    {
        Console.WriteLine("Domain can't be null or empty");
        return;
    }

    Console.WriteLine("Page:");
    var page = Console.ReadLine();
    if(string.IsNullOrEmpty(page) || !int.TryParse(page, out int pageResult))
    {
        Console.WriteLine("Incorrect page number");
        return;
    }

    Console.WriteLine("Page size:");
    var pageSize = Console.ReadLine();
    if(string.IsNullOrEmpty(pageSize) || !int.TryParse(pageSize, out int pageSizeResult))
    {
        Console.WriteLine("Incorrect page size");
        return;
    }

    var users = await mediator.Send(new GetUsersByDomainQuery(domain, pageResult, pageSizeResult));
    if(users is null || !users.Any())
    {
        Console.WriteLine("Couldn't find a user with the current domain");
        return;
    }

    foreach(var user in users)
    {
        var tags = user!.TagToUsers != null ? string.Join("; ", user!.TagToUsers.Select(x => x.Tag).Select(x => x.Value)!) : "no tags";
        Console.WriteLine($"Username: {user!.Name}\nTags: {tags}");
    }
}

async Task GetUsersByTagAndDomain()
{
    Console.WriteLine("Tag value:");
    var tagValue = Console.ReadLine();
    if(string.IsNullOrEmpty(tagValue))
    {
        Console.WriteLine("Tag value can't be null or empty");
        return;
    }

    var domain = RequestDomain();
    if(string.IsNullOrEmpty(domain))
    {
        Console.WriteLine("Domain can't be null or empty");
        return;
    }

    var users = await mediator.Send(new GetUsersByTagAndDomainQuery(tagValue, domain));
    if (users is null || !users.Any())
    {
        Console.WriteLine("Couldn't find a user with the current domain");
        return;
    }

    foreach (var user in users)
    {
        var tags = user!.TagToUsers != null ? string.Join("; ", user!.TagToUsers.Select(x => x.Tag).Select(x => x.Value)!) : "no tags";
        Console.WriteLine($"Username: {user!.Name}\nTags: {tags}");
    }
}