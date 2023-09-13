using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentByLastNameQuery : IRequest<Student>
    {
        public string? LastName { get; set; }
    }
    public class GetStudentByLastNameQueryHandler : IRequestHandler<GetStudentByLastNameQuery, Student>
    {
        readonly IStudentService _studentService;

        public GetStudentByLastNameQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(GetStudentByLastNameQuery query, CancellationToken cancellationToken)
        => (await _studentService.GetByFilter(query.LastName)).FirstOrDefault()!;
    }
}
