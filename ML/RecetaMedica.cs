using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class RecetasMedicas
    {
        public int IdRecetas {get; set;}
        public int IdPaciente { get; set; }
        public ML.Paciente? Paciente {get; set;}
        public string? FechaConsulta { get; set; }
        public string? Diagnostico { get; set; }
        public string? NombreMedico { get; set; }
        public string? NotasAdicionales { get; set; }

        public List<object> Recetas { get; set; }
        }
}
