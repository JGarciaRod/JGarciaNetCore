using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JgarciaNetCoreContext context = new DL.JgarciaNetCoreContext())
                {
                    var query = context.Pacientes.FromSqlRaw("GetPacientes").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach ( var registro in query )
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = registro.IdPaciente;
                            paciente.Nombre = registro.Nombre;
                            paciente.ApellidoPaterno = registro.ApellidoPaterno;
                            paciente.ApellidoMaterno = registro.ApellidoMaterno;

                            result.Objects.Add ( paciente );
                        }
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }
    }
}
