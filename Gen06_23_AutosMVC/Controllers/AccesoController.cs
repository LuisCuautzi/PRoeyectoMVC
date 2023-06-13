using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//Agregar para la autenticacion
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Gen06_23_AutosMVC.Models;

namespace Gen06_23_AutosMVC.Controllers
{
    public class AccesoController : Controller
    {
        public Gen06_23_MCVContext _Context { get; set; }
        public AccesoController( Gen06_23_MCVContext context)
        {
            _Context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(Usuario addUsuarioRequest)
        {
            var usuarioParam = new Usuario()
            {
                UserName = addUsuarioRequest.UserName,
                Password = addUsuarioRequest.Password,
                PerfilId = addUsuarioRequest.PerfilId,
                Id = addUsuarioRequest.Id
            };

            var users = await _Context.Usuarios.ToListAsync();

            //Aplicar las condiciones para validar el usuario
            var userOk = users.Where(item => item.UserName == usuarioParam.UserName && item.Password == usuarioParam.Password);
            IList<Usuario> listaUsuarios = new List<Usuario>(userOk);

            if (listaUsuarios.Count > 0)
            {
                IList<Usuario> listaUsuariosOk = new List<Usuario>(userOk);

                foreach (Usuario usuario in listaUsuariosOk)
                {
                    //Se agrega para la authenticacion
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,usuario.UserName),
                        new Claim("UserName",usuario.UserName),
                        new Claim("Id",usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role,usuario.PerfilId.ToString())
                    };
                    //Se agreaga para la authentication
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Se le esta pasando todo el contexto
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            else
            {
                ViewBag.Error = "Usuario o Contraseña Inavalida";
                return View();
            }

        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }
    }
}
