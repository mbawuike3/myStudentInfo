using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CrashCourseWeb.Services;

public interface IStudentService
{
    Task<List<Student>> GetByFilter(string? filter = null);
}

public class StudentService : IStudentService
{
    private readonly ApplicationContext _context;

    public StudentService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetByFilter(string? filter)
    {
        var students = await _context.Students.Where
              (x => (string.IsNullOrEmpty(filter) || x.FirstName!.ToLower().Equals(filter.ToLower()))
              || (string.IsNullOrEmpty(filter) || x.LastName!.ToLower().Equals(filter.ToLower())))
              .ToListAsync();
        return students;
    }
}
