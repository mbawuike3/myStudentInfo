using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using MediatR;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentByLastNameQuery : IRequest<Student>
    {
        public string? LastName { get; set; }
    }
    public class GetStudentByLastNameQueryHandler : IRequestHandler<GetStudentByLastNameQuery, Student>
    {
        private readonly ApplicationContext _context;

        public GetStudentByLastNameQueryHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle(GetStudentByLastNameQuery query, CancellationToken cancellationToken)
        {
            var student = _context.Students.Where(c => c.LastName == query.LastName).FirstOrDefault();
            return student;
        }
    }
}
