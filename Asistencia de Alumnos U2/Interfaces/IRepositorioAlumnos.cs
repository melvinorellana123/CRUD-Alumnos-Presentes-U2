using Asistencia_de_Alumnos_U2.Models;

namespace Asistencia_de_Alumnos_U2.Interfaces;

public interface IRepositorioAlumnos
{
    public List<Alumno> Alumnos { get; }
    public List<Alumno> ObtenerAlumnos();
    public void AgregarAlumno(Alumno alumno);
    public void EliminarAlumno(Guid id);
    public void ActualizarAlumno(Alumno alumno);
    public Alumno ObtenerAlumno(Guid id);
}