using EjercicioParcial;
using Microsoft.AspNetCore.Mvc;

namespace PracticaParcial.Controllers;

[ApiController]
[Route("[controller]")]
public class AlumnoControllers : ControllerBase
{
    private readonly ILogger<AlumnoControllers> _logger;

    public AlumnoControllers(ILogger<AlumnoControllers> logger)
    {
        _logger = logger;
    }

    private static readonly List<Alumno> alumnos = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            if(alumnos.Count == 0)
            {
                return NotFound("No hay alumnos registrados");
            }
            return Ok(alumnos);
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
            var resultado = alumnos.FirstOrDefault(a => a.Id == Id);

            if(resultado is null)
            {
                return BadRequest("El alumno no existe.");
            }  

            return Ok(resultado);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Alumno nuevoAlumno)
    {
        try
        {
            var ValidacionId = alumnos.FirstOrDefault(a => a.Id == nuevoAlumno.Id);
            var ValidacionDni = alumnos.FirstOrDefault(a => a.Dni == nuevoAlumno.Dni);

            if(ValidacionId is null && ValidacionDni is null)
            {
                alumnos.Add(nuevoAlumno);
                return Ok("Alumno creado con exito.");
            }
            
            return Conflict("El alumno ya existe.");
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un problema en el servidor {ex.Message}");
        }
    }

    //[http]
}