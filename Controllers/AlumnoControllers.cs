using EjercicioParcial;
using Microsoft.AspNetCore.Mvc;

namespace PracticaParcial.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentControllers : ControllerBase
{
    private readonly ILogger<StudentControllers> _logger;

    public StudentControllers(ILogger<StudentControllers> logger)
    {
        _logger = logger;
    }

    private static readonly List<Student> students = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            if(students.Count == 0)
            {
                return NotFound("No hay alumnos registrados");
            }
            return Ok(students);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
        try
        {
            var result = students.FirstOrDefault(a => a.Id == Id);

            if(result is null)
            {
                return BadRequest("El alumno no existe.");
            }  

            return Ok(result);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Student newStudent)
    {
        try
        {
            Student idValidation = students.FirstOrDefault(s => s.Id == newStudent.Id);

            if(idValidation is not null)
            {
                return Conflict("Ya existe un alumno con ese id.");
            }

            Student dniValidation = students.FirstOrDefault(s => s.Dni == newStudent.Dni);

            if(dniValidation is not null)
            {
                return Conflict("Ya existe un alumno con ese dni.");
            }

            if(newStudent.Age < 16)
            {
                return BadRequest("El alumno debe ser mayor o igual a 16 años");
            }

            if(newStudent.Name is null || newStudent.Name == "" || newStudent.Name == "string")
            {
                return BadRequest("El alumno debe rsgistrar un nombre.");
            }

            if(newStudent.Surname is null || newStudent.Surname == "" || newStudent.Surname == "string")
            {
                return BadRequest("El alumno debe rsgistrar un apellido.");
            }

            students.Add(newStudent);

            return Ok("Alumno agregado exitosamente.");
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] Student StudentModificado, int Id)
    {
        try
        {
            Student student = students.FirstOrDefault(s => s.Id == Id);

            if (student is null)
            {
                return NotFound("El alumno no existe.");
            }  

            bool dniAlreadyExists = students.Any(s => s.Dni == StudentModificado.Dni && s.Id != Id);

            if (dniAlreadyExists)
            {
                return Conflict("Ya existe un alumno con ese dni.");
            }

            if (StudentModificado.Age < 16)
            {
                return BadRequest("El alumno debe ser mayor o igual a 16 años");
            }

            if (string.IsNullOrWhiteSpace(StudentModificado.Name) || StudentModificado.Name == "string")
            {
                return BadRequest("El alumno debe registrar un nombre.");
            }

            if (string.IsNullOrWhiteSpace(StudentModificado.Surname) || StudentModificado.Surname == "string")
            {
                return BadRequest("El alumno debe registrar un apellido.");
            }

            student.Name = StudentModificado.Name;
            student.Surname = StudentModificado.Surname;
            student.Dni = StudentModificado.Dni;
            student.Age = StudentModificado.Age;
            student.Email = StudentModificado.Email;

            return Ok("Alumno modificado exitosamente.");
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        try
        {
            bool exists = students.Any(s => s.Id == id);

            if (exists)
            {
                Student delete = students.FirstOrDefault(s => s.Id == id);
                students.Remove(delete);
                return Ok("Alumno removido exitosamente.");
            }

            return BadRequest("El alumno que quiere borrar no existe.");
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }
}