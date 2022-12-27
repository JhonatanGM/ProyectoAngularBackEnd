using System.Data;
using Dapper;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using EN = Entities;
using System;

namespace DataAccess
{
    public class Alumno
    {
        public static List<EN.ClassOut.Alumno.ListarAlumno> ObtenerAlumnos(string sqlConn)
        {

            using (var con = new SqlConnection(Config.DecryptConnection(sqlConn)))
            {
                try
                {
                    var result = con.Query< EN.ClassOut.Alumno.ListarAlumno> ("Alumnos_obtenerLista", commandType: CommandType.StoredProcedure).ToList();
                    return result;

                }
                catch
                {
                    throw;
                }
            }
        }

        public static int AgregarAlumnos(string sqlConn, EN.ClassIn.Alumno.AgregarALumno classIn)
        {
            using (TransactionScope scope = new TransactionScope())
            using (var con = new SqlConnection(Config.DecryptConnection(sqlConn)))
            {
                try
                {
                    int idRetorno = 0;

                    var param = new DynamicParameters();
                    param.Add("@nombreCompleto", classIn.nombreCompleto);
                    param.Add("@nombres", classIn.nombres);
                    param.Add("@aPaterno", classIn.aPaterno);
                    param.Add("@aMaterno", classIn.aMaterno);
                    param.Add("@fechaNacimiento", classIn.fechaNacimiento);
                    param.Add("@dni", classIn.dni);
                    param.Add("@correo", classIn.correo);
                    param.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    con.Execute("Alumnos_AgregarAlumnos", param, commandType: CommandType.StoredProcedure);

                    idRetorno = param.Get<Int32>("@retVal");
                    scope.Complete();

                    return idRetorno;

                }
                catch
                {
                    throw;
                }
            }
        }
        public static int EditarAlumnos(string sqlConn, EN.ClassIn.Alumno.EditarAlumno classIn)
        {
            using (TransactionScope scope = new TransactionScope())
            using (var con = new SqlConnection(Config.DecryptConnection(sqlConn)))
            {
                try
                {
                    int idRetorno = 0;

                    var param = new DynamicParameters();
                    param.Add("@id", classIn.id);
                    param.Add("@nombreCompleto", classIn.nombreCompleto);
                    param.Add("@nombres", classIn.nombres);
                    param.Add("@aPaterno", classIn.aPaterno);
                    param.Add("@aMaterno", classIn.aMaterno);
                    param.Add("@fechaNacimiento", classIn.fechaNacimiento);
                    param.Add("@dni", classIn.dni);
                    param.Add("@correo", classIn.correo);
                    param.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    con.Execute("Alumnos_EditarAlumnos", param, commandType: CommandType.StoredProcedure);

                    idRetorno = param.Get<Int32>("@retVal");
                    scope.Complete();

                    return idRetorno;

                }
                catch
                {
                    throw;
                }
            }
        }
        public static int ElimninarAlumnos(string sqlConn, EN.ClassIn.Alumno.EliminarAlumno classIn)
        {
            using (TransactionScope scope = new TransactionScope())
            using (var con = new SqlConnection(Config.DecryptConnection(sqlConn)))
            {
                try
                {
                    int idRetorno = 0;

                    var param = new DynamicParameters();
                    param.Add("@id", classIn.id);
                    param.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    con.Execute("Alumnos_EliminarAlumnos", param, commandType: CommandType.StoredProcedure);
                    idRetorno = param.Get<Int32>("@retVal");
                    scope.Complete();

                    return idRetorno;

                }
                catch
                {
                    throw;
                }
            }
        }

    }
}
