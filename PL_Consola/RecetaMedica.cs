using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class RecetaMedica
    {

        public static void Add()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();
            recetas.Paciente = new ML.Paciente();

            Console.WriteLine("Ingrese el Id del paciente:");
            recetas.IdPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de consulta (DD-MM-AAAA): ");
            recetas.FechaConsulta = Console.ReadLine();

            Console.WriteLine("Ingrese el diagnostico: ");
            recetas.Diagnostico = Console.ReadLine();

            Console.WriteLine("Nombre del Medico: ");
            recetas.NombreMedico = Console.ReadLine();

            Console.WriteLine("Notas Adicionales: ");
            recetas.NotasAdicionales = Console.ReadLine();

            ML.Result result = BL.RecetasMedicas.Add(recetas);

            if (result.Correct)
            {
                Console.WriteLine("Se incerto correctamnet");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public static void Update()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            Console.WriteLine("Ingrese el Id de la receta: ");
            recetas.IdRecetas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Id del paciente : ");
            recetas.IdPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de consulta (DD-MM-AAAA): ");
            recetas.FechaConsulta = Console.ReadLine();

            Console.WriteLine("Ingrese el diagnostico: ");
            recetas.Diagnostico = Console.ReadLine();

            Console.WriteLine("Nombre del Medico: ");
            recetas.NombreMedico = Console.ReadLine();

            Console.WriteLine("Notas Adicionales: ");
            recetas.NotasAdicionales = Console.ReadLine();

            ML.Result result = BL.RecetasMedicas.Update(recetas);

            if (result.Correct)
            {
                Console.WriteLine("Se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public static void Dell() 
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            Console.WriteLine("Ingrese el Id de la receta a eliminar");
            recetas.IdRecetas = int.Parse(Console.ReadLine());

            ML.Result result = BL.RecetasMedicas.Dell(recetas.IdRecetas);

            if (result.Correct)
            {
                Console.WriteLine("Se elimino correctamente");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }


        public static void GetAll() 
        {

            ML.Result result = BL.RecetasMedicas.GetAll();

            if (result.Correct)
            {
                foreach(ML.RecetasMedicas registro in result.Objects)
                {
                    Console.WriteLine("Id Recetas " +  registro.IdRecetas);
                    Console.WriteLine("Id Paciente " + registro.IdPaciente);
                    Console.WriteLine("Fecha Consulta " + registro.FechaConsulta);
                    Console.WriteLine("Diagnostico " + registro.Diagnostico);
                    Console.WriteLine("Nombre Medicamento " + registro.NombreMedico);
                    Console.WriteLine("Notas Adicionales " + registro.NotasAdicionales );
                    Console.WriteLine("------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Tabla vacia");
            }
        }

        public static void GetById()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            Console.WriteLine("Ingrese el id de la receta: ");
            recetas.IdRecetas = int.Parse(Console.ReadLine());

            ML.Result result = BL.RecetasMedicas.GatById(recetas.IdRecetas);

            if (result.Correct)
            {
                recetas = (ML.RecetasMedicas)result.Object;

                Console.WriteLine("Id Recetas: " + recetas.IdRecetas);
                Console.WriteLine("Id Paciente: " + recetas.IdPaciente);
                Console.WriteLine("Fecha Consulta: " + recetas.FechaConsulta);
                Console.WriteLine("Diagnostico: " + recetas.Diagnostico);
                Console.WriteLine("Nombre Medicamento: " + recetas.NombreMedico);
                Console.WriteLine("Notas Adicionales: " + recetas.NotasAdicionales);
                Console.WriteLine("------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No se encontro");
            }
        }
    }
}
