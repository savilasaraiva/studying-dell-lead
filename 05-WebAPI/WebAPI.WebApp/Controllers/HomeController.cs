﻿using ListaLeitura.Persistencia;
using ListaLeitura.Modelos;
using ListaLeitura.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ListaLeitura.WebApp.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<Livro> _repo;

        public HomeController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        private IEnumerable<Livro> ListaDoTipo(TipoListaLeitura tipo)
        {
            return _repo.All
                .Where(l => l.Lista == tipo)
                .ToList();
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                ParaLer = ListaDoTipo(TipoListaLeitura.ParaLer),
                Lendo = ListaDoTipo(TipoListaLeitura.Lendo),
                Lidos = ListaDoTipo(TipoListaLeitura.Lidos)
            };
            return View(model);
        }
    }
}