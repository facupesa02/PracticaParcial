namespace EjercicioParcial;
public class Student
{
    private int id;
    private string name;
    private string surname;
    private string dni;
    private int age;
    private string email;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string Dni { get => dni; set => dni = value; }
    public int Age { get => age; set => age = value; }
    public string Email { get => email; set => email = value; }
}