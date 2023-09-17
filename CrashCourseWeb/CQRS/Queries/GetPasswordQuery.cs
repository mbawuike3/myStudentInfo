using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Wrappers;
using MediatR;

namespace CrashCourseWeb.CQRS.Queries;

public class GetPasswordQuery : IRequest<Response<string>>
{
    public string Input { get; set; }
}

public class GetPasswordQueryHandler : IRequestHandler<GetPasswordQuery, Response<string>>
{
    ApplicationContext _context;

    public GetPasswordQueryHandler(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Response<string>> Handle(GetPasswordQuery request, CancellationToken cancellationToken)
    {
        var student = _context.Students.FirstOrDefault(x => x.Username.ToLower().Equals(request.Input.ToLower()) || x.Tel.Equals(request.Input));
        if (student == null)
        {
            return new Response<string>(code: "99", message: "User does not exist", succeeded: false, data: null);
        }
        return new Response<string>(code: "00", message: "Successful", succeeded: true, data: student.Password.Decrypt());
    }
}
