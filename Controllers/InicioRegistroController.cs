using ComprasDeSupermercado.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace ComprasDeSupermercado.Controllers
{
    public class InicioRegistroController : Controller
    {
        private readonly SistemaComprasContext _context;
        public InicioRegistroController(SistemaComprasContext context)
        {
            _context = context;
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        // metodo para registrar usuarios
        public IActionResult RegistrarUsuario(Usuario usuario, string confirmPassword)
        {
            if (usuario.Password == confirmPassword)
            {
                usuario.Password = GetSHA256(usuario.Password);
                usuario.EstatusUsuario = "A";
                usuario.Rol = "Usuario";
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }

            return RedirectToAction("Inicio", "InicioRegistro");
        }

        // metodo que devuelve todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return usuarios;
        }

        // metodo qie valida si el usuario introducido es correcto
        public Usuario ValidarUsuario(string matricula, string password)
        {
            var pswordEncrypted = GetSHA256(password);
            return ObtenerUsuarios().Where(x => x.NombreUsuario == matricula && x.Password == pswordEncrypted).FirstOrDefault();
        }

        public async Task<IActionResult> ValidarInicio(Usuario _usuario)
        {
            var usuario = ValidarUsuario(_usuario.NombreUsuario, _usuario.Password);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario)
                };

                string[] usuarioRol = { usuario.Rol };

                foreach (string rol in usuarioRol)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                switch (usuario.Rol)
                {
                    case "Administrador":
                        var claimsIdentityAdmin = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityAdmin));
                        return RedirectToAction("Privacy", "Home");


                    case "Usuario":
                        var claimsIdentityUsuario = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityUsuario));
                        return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Inicio", "InicioRegistro");
            }
            else
            {

                return RedirectToAction("Inicio", "InicioRegistro");
            }
        }

        // metodo para encriptar las contraseñas
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        // metodo para cerrar sesion
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Inicio", "InicioRegistro");
        }
    }
}

