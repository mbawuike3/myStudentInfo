using CrashCourseWeb.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.Models;

/*
 true if username is unique
false if it exists.
 */
public class UsernameVerifierQuery : IRequest<Tuple<bool, string>>
{
    public string? Username { get; set; }
}

public class UsernameVerifierQueryHandler : IRequestHandler<UsernameVerifierQuery, Tuple<bool, string>>
{
    readonly ApplicationContext _context;

    public UsernameVerifierQueryHandler(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Tuple<bool, string>> Handle(UsernameVerifierQuery request, CancellationToken cancellationToken)
    {
        var isUsernameExists = await _context.Students
            .AnyAsync(x => x.Username!.ToLower().Equals(request.Username!.ToLower()));
        if (isUsernameExists)
        {
            return Tuple.Create(true, $"Username {request.Username} already exists");
        }
        return Tuple.Create(false, $"Username {request.Username} is available");
    }
}