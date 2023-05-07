using ComprasDeSupermercado.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComprasDeSupermercado.Controllers
{
    public class HomeController : Controller
    {
        private readonly SistemaComprasContext _context;
        public HomeController(SistemaComprasContext context)
        {
            _context = context;
        }

        public IActionResult Index(string marca, string superMercado, string buscador)
        {
            ViewBag.Productos = Filtro(marca, superMercado, buscador);
            ViewBag.Marcas = _context.Marcas.ToList();
            ViewBag.SuperMercados = _context.Supermercados.ToList();
            return View();
        }

        public List<Producto> Filtro(string marca, string superMercado, string buscador)
        {
            if(marca != null) 
            {
                List<Producto> datos = _context.Productos.Where(p => p.Marca == marca && p.EstatusProducto == "A").ToList();
                return datos;
            }
            else if(superMercado != null)
            {
                List<Producto> datos = _context.Productos.Where(p => p.Supermercado == superMercado && p.EstatusProducto == "A").ToList();
                return datos;
            }
            else if (buscador != null)
            {
                List<Producto> datos = _context.Productos.Where(c => c.NombreProducto.Contains(buscador) && c.EstatusProducto == "A").ToList();
                return datos;
            }
            else
            {
                List<Producto> datos = _context.Productos.Where(p => p.EstatusProducto == "A").ToList();
                return datos;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AgregarLista(int producto, string creador, string marca, string supermercado, decimal precio)
        {
            List lista = new List();

            lista.Productos = producto;
            lista.Creador = creador;
            lista.Marca = marca;
            lista.Supermercado = supermercado;
            lista.Precio = precio;
            lista.Fecha = DateTime.Now; 
            _context.Lists.Add(lista);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult List()
        {
            ViewBag.Lista = _context.Lists.Where(l => l.Creador == User.Identity.Name).ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}