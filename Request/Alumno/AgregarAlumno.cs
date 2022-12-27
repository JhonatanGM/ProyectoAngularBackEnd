using System;

namespace Request.Alumno
{
    public class AgregarAlumno
    {
        public string nombreCompleto { get; set; }
        public string nombres { get; set; }
        public string aPaterno { get; set; }
        public string aMaterno { get; set; }
        public string fechaNacimiento { get; set; }
        public int dni { get; set; }
        public string correo { get; set; }
    }
}
