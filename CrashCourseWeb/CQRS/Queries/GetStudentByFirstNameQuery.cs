using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentByFirstNameQuery :IRequest<Student>
    {
        public string? FirstName { get; set; }
    }
    public class GetStudentByFirstNameQueryHandler : IRequestHandler<GetStudentByFirstNameQuery, Student>
    {
        readonly IStudentService _studentService;

        public GetStudentByFirstNameQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(GetStudentByFirstNameQuery query, CancellationToken cancellationToken)

            => (await _studentService.GetByFilter(query.FirstName)).FirstOrDefault()!;

    }
}
