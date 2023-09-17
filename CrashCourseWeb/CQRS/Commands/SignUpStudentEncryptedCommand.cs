using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using CrashCourseWeb.Wrappers;
using MediatR;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrashCourseWeb.CQRS.Commands;

public class SignUpStudentEncryptedCommand : IRequest<Response<Student>>
{
    public string EncryptedPayload { get; set; }
}

public class SignUpStudentEncryptedCommandHandler : IRequestHandler<SignUpStudentEncryptedCommand, Response<Student>>
{
    ApplicationContext _context;

    public SignUpStudentEncryptedCommandHandler(ApplicationContext context, IMediator mediator)
    {
        _context = context;
    }

    public async Task<Response<Student>> Handle(SignUpStudentEncryptedCommand command, CancellationToken cancellationToken)
    {
        var plainClass = command.EncryptedPayload.Decrypt();
        var request = JsonConvert.DeserializeObject<CreateStudentCommand>(plainClass);
        var student = new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Tel = request.Tel,
            Email = request.Email,
            Username = request.Username,
            Password = request.Password.Encrypt()
        };

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync(); // Use async SaveChanges
        return new Response<Student>
        {
            Code = "00",
            Message = "User created successfully",
            Data = student,
            Succeeded = true
        };
    }
}
