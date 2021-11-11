using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using atividade_2_uc05.Models;
using Microsoft.AspNetCore.Http;

namespace atividade_2_uc05.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Usuario usuario)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuario user = ur.ValidarLogin(usuario);

            if (user == null)
            {
                ViewBag.Message = "Falha no login!";
                return View();
            }
            else
            {
                ViewBag.Message = "Você está logado";

                HttpContext.Session.SetInt32("IdUsuario", user.Id);
                HttpContext.Session.SetString("NomeUsuario", user.Nome);

                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public IActionResult Listar()
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            UsuarioRepository ur = new UsuarioRepository();

            List<Usuario> Listagem = ur.Listar();

            return View(Listagem);

        }

        public IActionResult Remover(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            UsuarioRepository ur = new UsuarioRepository();
            Usuario userEncontrado = ur.BuscarPorId(Id);
            ur.Remover(userEncontrado);
            return RedirectToAction("Listar", "Usuario");

        }

        public IActionResult Editar(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            UsuarioRepository ur = new UsuarioRepository();
            Usuario userEncontrado = ur.BuscarPorId(Id);
            return View(userEncontrado);
        }

        [HttpPost]

        public IActionResult Editar(Usuario usuario)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Atualizar(usuario);
            return RedirectToAction("Listar", "Usuario");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Cadastro(Usuario usuario)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Inserir(usuario);
            ViewBag.Mesagem = "Cadastro realizado com sucesso";
            return View();
        }

    }
}