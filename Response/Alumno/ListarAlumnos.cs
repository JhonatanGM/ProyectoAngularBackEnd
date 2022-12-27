using System;

namespace Response.Alumno
{
    public class ListarAlumnos
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public string nombres { get; set; }
        public string aPaterno { get; set; }
        public string aMaterno { get; set; }
        public string fechaNacimiento { get; set; }
        public int dni { get; set; }
        public string correo { get; set; }

        public ListarAlumnos(int id, string nombreCompleto, string nombres, string aPaterno, string aMaterno, string fechaNacimiento, int dni, string correo)
        {
            this.id = id;
            this.nombreCompleto = nombreCompleto;
            this.nombres = nombres;
            this.aPaterno = aPaterno;
            this.aMaterno = aMaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.dni = dni;
            this.correo = correo;
        }
    }
}
