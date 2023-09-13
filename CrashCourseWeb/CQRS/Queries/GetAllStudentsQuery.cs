using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<List<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
       => await _studentService.GetByFilter();
    }
}
