using BilletDeConcert.Data;
using BilletDeConcert.Data.Services;
using BilletDeConcert.Data.Static;
using BilletDeConcert.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BilletDeConcert.Controllers
{

    public class ArtistesController : Controller
    {
        //injecter des services de modèle séparés au lieu du contexte pour éviter un DbContext unique géant
        private readonly IArtistesService _service;
        public ArtistesController(IArtistesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, PhotoURL,Bio")] Artiste artiste)
        {
            if (!ModelState.IsValid)
            {
                return View(artiste);
            }
            await _service.AddAsync(artiste);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var artisteDetails = await _service.GetByIdAsync(id);
            if (artisteDetails == null) return View("Empty");
            return View(artisteDetails);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var artisteDetails = await _service.GetByIdAsync(id);
            if (artisteDetails == null) return View("NotFound");
            return View(artisteDetails);


        }    
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, PhotoURL,Bio")] Artiste artiste)
        {
            if (!ModelState.IsValid)
            {
                return View(artiste);
            }
            await _service.UpdateAsync(id, artiste);
            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> Delete(int id)
        {
            var artisteDetails = await _service.GetByIdAsync(id);
            if (artisteDetails == null) return View("NotFound");
            return View(artisteDetails);


        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artisteDetails = await _service.GetByIdAsync(id);
            if (artisteDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
