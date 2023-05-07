using ComprasDeSupermercado.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace ComprasDeSupermercado.Controllers
{
    public class MarcasController : Controller
    {
        private readonly SistemaComprasContext _context;
        public MarcasController(SistemaComprasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Marcas = GetMarcas();
            return View();
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> marcas = _context.Marcas.Where(p => p.EstatusMarca == "A").ToList();
            return marcas;
        }

        public IActionResult Crear(string nom_marca, string desc_marca)
        {
            Marca marca = new Marca();
            marca.NombreMarca = nom_marca;
            marca.DescripcionMarca = desc_marca;
            marca.EstatusMarca = "A";
            _context.Marcas.Add(marca);
            _context.SaveChanges();

            return RedirectToAction("Index", "Marcas");
        }

        public Marca Listar(string id)
        {
            Marca marcas = _context.Marcas.FirstOrDefault(p => p.NombreMarca == id);

            return marcas;
        }

        public IActionResult Actualizar(string nMarca, string dMarca)
        {
            Marca marca = new Marca();

            marca.NombreMarca = nMarca;
            marca.DescripcionMarca = dMarca;
            marca.EstatusMarca = "A";
            _context.Marcas.Update(marca);
            _context.SaveChanges();

            return RedirectToAction("Index", "Marcas");
        }

        public IActionResult Eliminar(string id)
        {
            Marca marca = _context.Marcas.FirstOrDefault(p => p.NombreMarca == id);
            marca.EstatusMarca = "I";
            _context.SaveChanges();

            return RedirectToAction("Index", "Marcas");
        }

        public string ListarMarcas(string codigo)
        {
            Marca marca = _context.Marcas.FirstOrDefault(p => p.NombreMarca == codigo);

            string jsonMarca = new JavaScriptSerializer().Serialize(marca);
            return jsonMarca;
        }
    }
}
