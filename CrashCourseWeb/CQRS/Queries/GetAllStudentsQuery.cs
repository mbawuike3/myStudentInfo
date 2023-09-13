using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly ApplicationContext _context;

        public GetAllStudentsQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
        {
            var AllStudents = await _context.Students.ToListAsync();
            return AllStudents;
        }
    }
}
