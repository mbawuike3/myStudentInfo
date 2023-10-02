using CrashCourseWeb.Data;
using CrashCourseWeb.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

public class LoginQuery : Login, IRequest<bool>
{

}

public class LoginQueryHandler : IRequestHandler<LoginQuery, bool>
{
    readonly ApplicationContext _context;
    readonly IPasswordService _passwordService;

    public LoginQueryHandler(ApplicationContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public async Task<bool> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        //Get user by username
        var userFromDb = await _context.Students.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(request.Username));
        if (userFromDb == null)
        {
            return false;
            //User does not exist.
        }

        string salt = userFromDb.Salt;
        request.Password = request.Password.Trim();
        request.Password += salt; //Salting
        var hashedPassword = _passwordService.Encoder(request.Password); //Hash the salted password
        if (hashedPassword.Equals(userFromDb.Password))
        {
            return true;
            //Successfully login

            //Return JWT
        }
        return false;
        //Return incorrect password
    }
}