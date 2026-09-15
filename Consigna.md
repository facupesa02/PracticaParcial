Ejercicio 1 - Sistema de inscripción de alumnos
Crear una API que permita administrar alumnos inscriptos.
Modelo sugerido
Alumno
- Id : int
- Nombre : string
- Apellido : string
- Dni : string
- Edad : int
- Email : string
Endpoints y operaciones
* CRUD completo: GET, GET por Id, POST, PUT y DELETE.
* Agregar una búsqueda de alumnos por nombre.
* Agregar un endpoint para listar alumnos ordenados por apellido.
Validaciones
* Nombre y apellido obligatorios.
* Edad mayor o igual a 16.
* DNI único.
* Devolver 404 cuando el Id no exista.
* Devolver 400 ante datos inválidos.
Desafío adicional
Crear GET /api/alumno/cantidad que devuelva la cantidad total de alumnos registrados.