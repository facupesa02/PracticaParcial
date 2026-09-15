namespace EjercicioParcial;
public class Alumno
{
    private int id;
    private string nombre;
    private string apellido;
    private string dni;
    private int edad;
    private string email;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Dni { get => dni; set => dni = value; }
    public int Edad { get => edad; set => edad = value; }
    public string Email { get => email; set => email = value; }
}