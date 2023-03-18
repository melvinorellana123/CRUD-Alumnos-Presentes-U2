using Microsoft.AspNetCore.Identity;

namespace Asistencia_de_Alumnos_U2.Models;

public class Alumno
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public bool Asistencia { get; set; }
}