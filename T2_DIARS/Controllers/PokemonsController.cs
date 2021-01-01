using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using T2_DIARS.Models;

namespace T2_DIARS.Controllers
{
   
    public class PokemonsController : BaseController
    {
        private readonly AppPruebaContext context;
        private readonly IHostEnvironment _hostEnv;
        private readonly IConfiguration configuration;

        public PokemonsController(AppPruebaContext context, IHostEnvironment hostEnv, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.configuration = configuration;
            _hostEnv = hostEnv;
        }
        public ActionResult Pokemon(string search)
        {

            var pokemones = context.Tipos.ToList();

            ViewBag.Buscar = search;
            var pokemon = context.Pokemones
                .Include(o => o.Tipo)
                .ToList();

            if (!string.IsNullOrEmpty(search))
            {
                pokemon = pokemon.Where(s => s.Nombre.Contains(search)).ToList();
                return View("Pokemon", pokemon);
            }
            return View("Pokemon", pokemon);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Tipos = context.Tipos.ToList();
            return View("Create", new Pokemons());
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Pokemons pokemones, IFormFile image, string nombre)
        {
            if (image != null && image.Length > 0)
            {
                var basePath = _hostEnv.ContentRootPath + @"\wwwroot";
                var ruta = @"\Pokemones\" + image.FileName;
                using (var strem = new FileStream(basePath + ruta, FileMode.Create))
                {
                    image.CopyTo(strem);
                    pokemones.Imagen = ruta;
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Este campo es obligatorio");
            }
            var pokemons = context.Pokemones.ToList();
            foreach (var item in pokemons)
            {
                if (item.Nombre == nombre)
                {
                    ModelState.AddModelError("NombreV", "Pokemon Existente");
                }
            }
            Console.WriteLine("Imagen? " + image);
            if (ModelState.IsValid)
            {
                context.Pokemones.Add(pokemones);
                context.SaveChanges();
                return RedirectToAction("Pokemon");
            }
            else
            {
                ViewBag.Tipos = context.Tipos.ToList();
                return View("Create", pokemones);
            }
        }
        public string imagen()
        {
            return _hostEnv.ContentRootPath + @"\wwwroot";
        }
    }
}


