using CrashCourseWeb.Data;
using CrashCourseWeb.Services;
using MediatR;
using System.Text.Json.Serialization;

namespace CrashCourseWeb.Models;

public class Login
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public class RegisterCommand : Student, IRequest<Student>
{
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Student>
{
    readonly ApplicationContext _context;
    readonly IPasswordService _passwordService;

    public RegisterCommandHandler(ApplicationContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public async Task<Student> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        //Generate salt
        string salt = Guid.NewGuid().ToString();
        //Work on Password
        request.Password += salt;  //Salting
        var student = new Student
        {
            Salt = salt,
            Username = request.Username,
            Password = _passwordService.Encoder(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Tel = request.Tel
        };

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Tel = request.Tel,
            Username = request.Username
        };
    }

    
}