using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Practica2_U2_211G0353.Models;
using Practica2_U2_211G0353.Models.ViewModels;

namespace Practica2_U2_211G0353.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MapaCurricularContext context = new MapaCurricularContext();
            var index = context.Carreras.OrderBy(x => x.Id);
            if (index == null)
            {
                return RedirectToAction("Index");
            }
            return View(index);
        }
        [Route("Info/{dato}")]
        public IActionResult Info(string dato)
        {
            MapaCurricularContext context = new MapaCurricularContext();
            string trans = dato.Replace("-", " ");
            var info = context.Carreras.FirstOrDefault(x => x.Nombre == dato || trans == x.Nombre);
            if (info == null)
            {
                return RedirectToAction("Index");
            }
            return View(info);
        }
        [Route("Mapa/{datoMap}")]
        public IActionResult Mapa(string datoMap)
        {
            MapaCurricularContext context = new MapaCurricularContext();
            var map = context.Carreras.Include(x => x.Materias).FirstOrDefault(x => x.Nombre == datoMap);
            if (map == null)
            {
                return RedirectToAction("Index");
            }
            var reticula = new CarreraViewModel
            {
                Carrera = map.Nombre,
                Plan = map.Plan,
                CreditosTotales = map.Materias.Sum(x => x.Creditos),
                Semestres = Enumerable.Range(1, 9).Select(i => new SemestreView
                {
                    Semestre = i,
                    Materias = map.Materias.Where(m => m.Semestre == i).Select(m => new MateriaView
                    {
                        Clave = m.Clave,
                        Nombre = m.Nombre,
                        Creditos = m.Creditos,
                        HorasPracticas = m.HorasPracticas,
                        HorasTeoricas = m.HorasTeoricas
                    }).ToList()
                }).ToList()
            };
            return View(reticula);
        }
    }
}
