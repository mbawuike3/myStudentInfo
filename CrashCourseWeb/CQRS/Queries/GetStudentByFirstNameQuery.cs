using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
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
        private readonly ApplicationContext _context;

        public GetStudentByFirstNameQueryHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle(GetStudentByFirstNameQuery query, CancellationToken cancellationToken)
        {
            var student = await _context.Students.Where(c => c.FirstName == query.FirstName).FirstOrDefaultAsync();
       
            return student;
        }
    }
}
