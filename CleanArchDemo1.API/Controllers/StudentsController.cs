using CleanArchDemo1.Application.UseCases.Student.CreateStudents;
using CleanArchDemo1.Application;
using CleanArchDemo1.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Azure;
using CleanArchDemo1.Application.UseCases.Student.UpdateStudent;
using CleanArchDemo1.Application.UseCases.Student.DeleteStudent;
using CleanArchDemo1.Application.UseCases.Student.GetStudentById;
using CleanArchDemo1.Application.UseCases.Student.GetStudents;

namespace CleanArchDemo1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly CreateStudentsHandler _createStudentsHandler;
        private readonly DeleteStudentHandler _deleteStudentHandler;
        private readonly UpdateStudentHandler _updateStudentHandler;
        private readonly GetStudentsHandler _getStudentsHandler;
        private readonly GetStudentByIdHandler _getStudentByIdHandler;
        public StudentsController(CreateStudentsHandler createStudentsHandler, DeleteStudentHandler deleteStudentHandler,
            UpdateStudentHandler updateStudentHandler, GetStudentsHandler getStudentsHandler, GetStudentByIdHandler getStudentByIdHandler)
        {;

            _createStudentsHandler = createStudentsHandler;

            _deleteStudentHandler = deleteStudentHandler;

            _updateStudentHandler = updateStudentHandler;

            _getStudentsHandler = getStudentsHandler;

            _getStudentByIdHandler = getStudentByIdHandler;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _getStudentsHandler.Handle();

            return Ok(students);

        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {

            var students = _getStudentByIdHandler.Handle(id);
            if (students == null)
            {
                return NotFound("Student not Found");
            }

            return Ok(students);

        }

        [HttpPost]

        public IActionResult CreateStudents(CreateStudentsRequest request)
        {
            if (request == null)
            {
                return BadRequest("Record Not found");
            }

            var response = _createStudentsHandler.Handle(request);

            return CreatedAtAction(nameof(GetStudents), new { id = response.Id }, response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            var response = _deleteStudentHandler.Handle(id);
            if (response == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudents(int id, UpdateStudentRequest request)
        {
            var updatedStudent = _updateStudentHandler.Handle(id,request);

            if (updatedStudent == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(updatedStudent);
        }

    }
}
