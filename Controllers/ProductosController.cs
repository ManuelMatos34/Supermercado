using ComprasDeSupermercado.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace ComprasDeSupermercado.Controllers
{
    public class ProductosController : Controller
    {
        private readonly SistemaComprasContext _context;
        public ProductosController(SistemaComprasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Productos = GetProductos();
            ViewBag.Marcas = _context.Marcas.ToList();
            ViewBag.SuperMercados = _context.Supermercados.ToList();

            return View();
        }

        public List<Producto> GetProductos()
        {
            List<Producto> productos = _context.Productos.Where(p => p.EstatusProducto == "A").ToList();
            return productos;
        }

        public IActionResult Crear(Producto producto)
        {
            producto.EstatusProducto = "A";
            _context.Productos.Add(producto);
            _context.SaveChanges();

            return RedirectToAction("Index", "Productos");
        }

        public Producto Listar(int id)
        {
            Producto producto = _context.Productos.FirstOrDefault(p => p.IdProducto == id);

            return producto;
        }

        public IActionResult Actualizar(Producto producto)
        {
            producto.EstatusProducto = "A";
            _context.Productos.Update(producto);
            _context.SaveChanges();

            return RedirectToAction("Index", "Productos");
        }

        public IActionResult Eliminar(int id)
        {
            Producto producto = _context.Productos.FirstOrDefault(p => p.IdProducto == id);
            producto.EstatusProducto = "I";
            _context.SaveChanges();

            return RedirectToAction("Index", "Productos");
        }

        public string ListarProductos(int codigo)
        {
            Producto producto = _context.Productos.FirstOrDefault(p => p.IdProducto == codigo);

            string jsonProd = new JavaScriptSerializer().Serialize(producto);
            return jsonProd;
        }

    }
}
