using CrashCourseWeb.CQRS.Commands;
using CrashCourseWeb.CQRS.Queries;
using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrashCourseWeb.Controllers;

[Route("api/v1")]
[ApiController]
public class StudentController : ControllerBase
{
    readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var query = new GetAllStudentsQuery();
        var students = await _mediator.Send(query);
        return Ok(students);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetStudentByIdQuery { Id = id };
        var student = await _mediator.Send(query);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }
    [HttpGet("firstname/{firstName}")]
    public async Task<IActionResult> GetByFirstName(string firstName)
    {
        var query = new GetStudentByFirstNameQuery { FirstName = firstName };
        var student = await _mediator.Send(query);
        if (query == null)
            return NotFound();
        return Ok(student);
    }
    [HttpGet("lastname/{lastName}")]
    public async Task<IActionResult> GetByLastName(string lastName)
    {
        var query = new GetStudentByLastNameQuery { LastName = lastName };
        var student = await _mediator.Send(query);
        if (student == null)
            return NotFound();
        return Ok(student);
    }

    [HttpGet("get-password")]
    public async Task<IActionResult> TestGetPassword(string input)
    {
        var response = await _mediator.Send(new GetPasswordQuery { Input = input });
        if (response.Code.Equals("99"))
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpPost("student-encrypt")]
    public async Task<IActionResult> EncryptedSignup(CreateStudentCommand command)
    {
        string commandString = JsonConvert.SerializeObject(command);
        string commandCipher = commandString.Encrypt();
        return Ok(_mediator.Send(new SignUpStudentEncryptedCommand { EncryptedPayload = commandCipher }));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand register)
    {
        return Ok(await _mediator.Send(register));
    }

    [HttpGet("username-verification")]
    public async Task<IActionResult> UserVeriAsync(string username)
    {
        var response = await _mediator.Send(new UsernameVerifierQuery { Username = username });
        bool userExists = response.Item1;
        string message = response.Item2;
        if (userExists)
        {
            return BadRequest(message);
        }
        return Ok(message);
    }

    [HttpPost("login")]
    public async Task<IActionResult> StudentLoginAsync([FromBody] LoginQuery login)
    {
        return Ok(await _mediator.Send(login));
    }
}
