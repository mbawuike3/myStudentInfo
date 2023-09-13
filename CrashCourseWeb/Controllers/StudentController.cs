using CrashCourseWeb.CQRS.Commands;
using CrashCourseWeb.CQRS.Queries;
using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        var query =new GetStudentByIdQuery { Id = id};
        var student =await _mediator.Send(query);
        if(student == null)
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

}
