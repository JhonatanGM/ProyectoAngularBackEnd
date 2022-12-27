using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using DA = DataAccess;
using EN = Entities;
using RES = Response;
using REQ = Request;
using ProyectoAngularBackEnd.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;


namespace ProyectoAngularBackEnd.Controllers
{
    [Route("api/alumno")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly string sqlConn;
        public AlumnoController(IOptions<ConnectionString> optionsConnectionStrings)
        {
            sqlConn = optionsConnectionStrings.Value.ConnectionAngular;
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Respuesta))]
        [ProducesResponseType(400)]
        [Route("listar")]
        [HttpGet]
        public IActionResult ListarAlumnos()
        {
            try
            {
                List<EN.ClassOut.Alumno.ListarAlumno> classOut = DA.Alumno.ObtenerAlumnos(sqlConn);
                List<RES.Alumno.ListarAlumnos> alumno = new List<RES.Alumno.ListarAlumnos>();
                if (classOut.Count > 0)
                {
                    foreach (EN.ClassOut.Alumno.ListarAlumno item in classOut)
                    {
                        alumno.Add(new RES.Alumno.ListarAlumnos(
                            item.Id,
                            item.NombreCompleto,
                            item.Nombres,
                            item.APaterno,
                            item.AMaterno,
                            item.FechaNacimiento,
                            item.Dni,
                            item.Correo
                            ));
                    }
                    return Ok(new Respuesta("Éxito", "Se obtuvieron las siguientes alumnos.", alumno));
                }
                else
                {
                    return Ok(new Respuesta("Éxito", "Intenta registrar un nuevo alumno."));
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Respuesta))]
        [ProducesResponseType(400)]
        [Route("agregar")]
        [HttpPost]
        public IActionResult AgregarAlumno(REQ.Alumno.AgregarAlumno req)
        {
            try
            {
                EN.ClassIn.Alumno.AgregarALumno classIn = new EN.ClassIn.Alumno.AgregarALumno()
                {
                    nombreCompleto = req.nombreCompleto,
                    nombres = req.nombres,
                    aPaterno = req.aPaterno,
                    aMaterno = req.aMaterno,
                    fechaNacimiento = req.fechaNacimiento,
                    dni = req.dni,
                    correo = req.correo
                };
                int res = DA.Alumno.AgregarAlumnos(sqlConn, classIn);

                if (res == -50) { return Ok(new Respuesta("Error", "Error al registrar.")); }
                if (res == -100) { return Ok(new Respuesta("Error", "El usuario ya se encuentra registrado.")); }

                return Ok(new Respuesta("Éxito", "Registro exitoso."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Respuesta))]
        [ProducesResponseType(400)]
        [Route("editar")]
        [HttpPost]
        public IActionResult EditarAlumno(REQ.Alumno.EditarAlumno req)
        {
            try
            {
                EN.ClassIn.Alumno.EditarAlumno classIn = new EN.ClassIn.Alumno.EditarAlumno()
                {
                    id = req.id,
                    nombreCompleto = req.nombreCompleto,
                    nombres = req.nombres,
                    aPaterno = req.aPaterno,
                    aMaterno = req.aMaterno,
                    fechaNacimiento = req.fechaNacimiento,
                    dni = req.dni,
                    correo = req.correo
                };
                int res = DA.Alumno.EditarAlumnos(sqlConn, classIn);
                if (res == -50) { return Ok(new Respuesta("Error", "No se pudo registrar.")); }

                return Ok(new Respuesta("Éxito", "Registro exitoso."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Respuesta))]
        [ProducesResponseType(400)]
        [Route("eliminar")]
        [HttpPost]
        public IActionResult EliminarAlumno(REQ.Alumno.EliminarAlumno req)
        {
            try
            {
                EN.ClassIn.Alumno.EliminarAlumno classIn = new EN.ClassIn.Alumno.EliminarAlumno()
                {
                    id = req.id
                };
                int res = DA.Alumno.ElimninarAlumnos(sqlConn, classIn);
                if (res == -50) { return Ok(new Respuesta("Error", "No se pudo eliminar.")); }

                return Ok(new Respuesta("Éxito", "Se elimino con exitoso."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
