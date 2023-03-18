using Asistencia_de_Alumnos_U2.Interfaces;
using Asistencia_de_Alumnos_U2.Models;

namespace Asistencia_de_Alumnos_U2.Services;

public class RepositorioAlumnos : IRepositorioAlumnos
{
    public List<Alumno> Alumnos { get; }

    public RepositorioAlumnos()
    {
        Alumnos = new List<Alumno>();
    }
    
    public List<Alumno> ObtenerAlumnos()
    {
        return Alumnos;
    }

    public void AgregarAlumno(Alumno alumno)
    {
        alumno.Id = Guid.NewGuid();
        Alumnos.Add(alumno);
    }

    public void EliminarAlumno(Guid id)
    {
        var alumnoAEliminar = Alumnos.Find(alumno => alumno.Id == id);
        if (alumnoAEliminar == null)
        {
            throw new Exception("No existe el alumno que desea eliminar");
        }

        Alumnos.Remove(alumnoAEliminar);
    }

    public void ActualizarAlumno(Alumno alumnoA)
    {
        var alumnoAActualizar = Alumnos.Find(alumno => alumno.Id == alumnoA.Id);
        if (alumnoAActualizar == null)
        {
            throw new Exception("No existe el alumno que desea actualizar");
        }

        alumnoAActualizar.Nombre = alumnoA.Nombre;
        alumnoAActualizar.Asistencia = alumnoA.Asistencia;
        
    }
    

    public Alumno ObtenerAlumno(Guid id)
    {
        var alumnoAObtener = Alumnos.Find(alumno => alumno.Id == id);
        if (alumnoAObtener == null)
        {
            throw new Exception("No existe el alumno que desea obtener");
        }

        return alumnoAObtener;
    }
}