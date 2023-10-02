using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PL.Controllers
{
    public class RecetasMedicasController : Controller
    {
        [HttpGet]
        public IActionResult GetAllReceta()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            ML.Result result = BL.RecetasMedicas.GetAll();

            if (result.Correct)
            {
                recetas.Recetas = result.Objects;
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMessage;
            }

            return View(recetas);
        }


        [HttpPost]
        public IActionResult GetAllReceta(ML.RecetasMedicas receta)
        {
            ML.Result result = BL.RecetasMedicas.GetAll();
            receta = new ML.RecetasMedicas();
            receta.Recetas = result.Objects;
            return View(receta);
        }

        [HttpGet]
        public IActionResult Add(int? IdReceta)
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();
            recetas.Paciente = new ML.Paciente();

            ML.Result resultPaciente = BL.Paciente.GetAll();

            if (IdReceta != 0) //update
            {
                ML.Result resultReceta = BL.RecetasMedicas.GatById(IdReceta.Value);

                if (resultReceta.Correct)
                {
                    recetas = (ML.RecetasMedicas)resultReceta.Object;
                    
                    recetas.Paciente.Pacientes = resultPaciente.Objects;
                }   
            }
            else //add
            {
                recetas.Paciente.Pacientes = resultPaciente.Objects;
            }
            return View(recetas);
        }

        [HttpPost]
        public IActionResult Add(ML.RecetasMedicas recetas)
        {
            if(recetas.IdRecetas == 0) //add
            {
                ML.Result result = BL.RecetasMedicas.Add(recetas);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se incerto correctamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            else //update
            {
                ML.Result result = BL.RecetasMedicas.Update(recetas);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se actualizo correctamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        public IActionResult Dell(int IdReceta)
        {
            ML.Result result = BL.RecetasMedicas.Dell(IdReceta);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino correctamente";
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
            }

            return PartialView("Modal");
        }


    }
}
