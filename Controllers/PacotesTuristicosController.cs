using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using atividade_2_uc05.Models;
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using System;

namespace atividade_2_uc05.Controllers
{
    public class PacotesTuristicosController : Controller
    {

        public IActionResult Listar()
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            PacotesTuristicosRepository ure = new PacotesTuristicosRepository();

            List<PacotesTuristicos> Listagem = ure.Listar();

            return View(Listagem);

        }

        public IActionResult Remover(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            PacotesTuristicos userEncontrado = ur.BuscarPorId(Id);
            ur.Remover(userEncontrado);
            return RedirectToAction("Listar", "Usuario");

        }

        public IActionResult Editar(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            PacotesTuristicos userEncontrado = ur.BuscarPorId(Id);
            return View(userEncontrado);

        }

        [HttpPost]

        public IActionResult Editar(PacotesTuristicos paco)
        {

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            ur.Atualizar(paco);
            return RedirectToAction("Listar", "PacotesTuristicos");

        }

        public IActionResult Cadastro()
        {
            //so no pacotes turiscos
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Cadastro(PacotesTuristicos paco)
        {

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            ur.Inserir(paco);
            ViewBag.Mesagem = "Cadastro realizado com sucesso";
            return View();

        }

    }
}