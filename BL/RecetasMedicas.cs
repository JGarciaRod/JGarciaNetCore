using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace BL
{
    public class RecetasMedicas
    {
        public static ML.Result Add(ML.RecetasMedicas recetas)
        {
            ML.Result result = new ML.Result();
            //recetas.Paciente = new ML.Paciente();

            try
            {
                using (DL.JgarciaNetCoreContext context = new DL.JgarciaNetCoreContext())
                {
                    int rowAffeted = context.Database.ExecuteSqlRaw($"AddReceta {recetas.Paciente.IdPaciente},'{recetas.FechaConsulta}','{recetas.Diagnostico}','{recetas.NombreMedico}','{recetas.NotasAdicionales}' ");

                    if (rowAffeted > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    { 
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.RecetasMedicas recetas)
        {
            ML.Result result = new ML.Result();
            //recetas.Paciente = new ML.Paciente();

            try
            {
                using (DL.JgarciaNetCoreContext context = new DL.JgarciaNetCoreContext())
                {
                    int rowAffeted = context.Database.ExecuteSqlRaw($"updateReceta {recetas.IdRecetas}, {recetas.Paciente.IdPaciente},'{recetas.FechaConsulta}','{recetas.Diagnostico}','{recetas.NombreMedico}','{recetas.NotasAdicionales}' ");

                    if (rowAffeted > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result Dell(int idReceta)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JgarciaNetCoreContext context = new DL.JgarciaNetCoreContext())
                {
                    int rowAffect = context.Database.ExecuteSqlRaw($"DeleteReceta {idReceta}");
                    
                    if (rowAffect > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JgarciaNetCoreContext context = new DL.JgarciaNetCoreContext())
                {
                    var query = context.RecetasMedicas.FromSqlRaw("GetAllReceta").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in query)
                        {
                            ML.RecetasMedicas medicas = new ML.RecetasMedicas();
                            //medicas.Paciente = new ML.Paciente();
                            medicas.IdRecetas = registro.IdRecetas;
                            medicas.IdPaciente = Convert.ToInt32(registro.IdPaciente);
                            medicas.FechaConsulta = Convert.ToString(registro.FechaConsulta);
                            medicas.Diagnostico = registro.Diagnostico;
                            medicas.NombreMedico = registro.NombreMedico;
                            medicas.NotasAdicionales = registro.NotasAdicionales;

                            result.Objects.Add(medicas);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GatById(int idReceta)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JgarciaNetCoreContext context = new DL.JgarciaNetCoreContext())
                {
                    var query = context.RecetasMedicas.FromSqlRaw($"GetByIdReceta {idReceta}").AsEnumerable().SingleOrDefault();

                    result.Object = new List<object>();

                    if (query != null)
                    {
                        ML.RecetasMedicas medicas = new ML.RecetasMedicas();
                        medicas.Paciente = new ML.Paciente();

                        medicas.IdRecetas = Convert.ToInt32(query.IdRecetas);
                        medicas.Paciente.IdPaciente = Convert.ToInt32(query.IdPaciente);
                        medicas.FechaConsulta = query.FechaConsulta.Value.ToString("dd-MM-yyyy");
                        medicas.Diagnostico = query.Diagnostico;
                        medicas.NombreMedico = query.NombreMedico;
                        medicas.NotasAdicionales = query.NotasAdicionales;

                        result.Object = medicas;

                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}