using ComprasDeSupermercado.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace ComprasDeSupermercado.Controllers
{
    public class SuperMercadosController : Controller
    {
        private readonly SistemaComprasContext _context;
        public SuperMercadosController(SistemaComprasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SuperMercados = GetSupermercados();
            return View();
        }

        public List<Supermercado> GetSupermercados()
        {
            List<Supermercado> supermercado = _context.Supermercados.Where(p => p.EstatusSupermercado == "A").ToList();
            return supermercado;
        }

        public IActionResult Crear(string nom_superm, string direc_superm, string desc_superm)
        {
            Supermercado supermercado = new Supermercado();

            supermercado.NombreSupermercado = nom_superm;
            supermercado.DireccionSupermercado = direc_superm;
            supermercado.DescripcionSupermercado = desc_superm;
            supermercado.EstatusSupermercado = "A";
            _context.Supermercados.Add(supermercado);
            _context.SaveChanges();

            return RedirectToAction("Index", "SuperMercados");
        }

        public Supermercado Listar(string id)
        {
            Supermercado supermercado = _context.Supermercados.FirstOrDefault(p => p.NombreSupermercado == id);

            return supermercado;
        }

        public IActionResult Actualizar(string nSuperm, string dirSuperm, string desSuperm)
        {
            Supermercado supermercado = new Supermercado();

            supermercado.NombreSupermercado = nSuperm;
            supermercado.DireccionSupermercado = dirSuperm;
            supermercado.DescripcionSupermercado = desSuperm;
            supermercado.EstatusSupermercado = "A";
            _context.Supermercados.Update(supermercado);
            _context.SaveChanges();

            return RedirectToAction("Index", "SuperMercados");
        }
        public IActionResult Eliminar(string id)
        {
            Supermercado supermercado = _context.Supermercados.FirstOrDefault(p => p.NombreSupermercado == id);
            supermercado.EstatusSupermercado = "I";
            _context.SaveChanges();

            return RedirectToAction("Index", "SuperMercados");
        }

        public string ListarSupermercados(string codigo)
        {
            Supermercado supermercado = _context.Supermercados.FirstOrDefault(p => p.NombreSupermercado == codigo);

            string jsonSuper = new JavaScriptSerializer().Serialize(supermercado);
            return jsonSuper;
        }

    }
}
