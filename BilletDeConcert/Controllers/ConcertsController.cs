using BilletDeConcert.Data.Static;
using BilletDeConcert.Data;
using BilletDeConcert.Data.Services;
using BilletDeConcert.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilletDeConcert.Data.Services;

namespace BilletDeConcert.Controllers
{
    public class ConcertsController : Controller
    {
        //injecter des services de modèle séparés au lieu du contexte pour éviter un DbContext unique géant

        private readonly IConcertsService _service;

        public ConcertsController(IConcertsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allConcerts = await _service.GetAllAsync();
            return View(allConcerts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allConcerts = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allConcerts.Where(n => n.Nom.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allConcerts);
        }

        //GET: Concerts/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ConcertDetail = await _service.GetConcertByIdAsync(id);
            return View(ConcertDetail);
        }

        //GET: Concerts/Create
        public async Task<IActionResult> Create()
        {
            var ConcertDropdownsData = await _service.GetNewConcertDropdownsValues();

            ViewBag.Artistes = new SelectList(ConcertDropdownsData.Artistes, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewConcertVM Concert)
        {
            if (!ModelState.IsValid)
            {
                var ConcertDropdownsData = await _service.GetNewConcertDropdownsValues();

                ViewBag.Artistes = new SelectList(ConcertDropdownsData.Artistes, "Id", "FullName");

                return View(Concert);
            }

            await _service.AddNewConcertAsync(Concert);
            return RedirectToAction(nameof(Index));
        }


        //GET: Concerts/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ConcertDetails = await _service.GetConcertByIdAsync(id);
            if (ConcertDetails == null) return View("NotFound");

            var response = new NewConcertVM()
            {
                Id = ConcertDetails.Id,
                Nom = ConcertDetails.Nom,
                Description = ConcertDetails.Description,
                Prix = ConcertDetails.Prix,
                StartDate = ConcertDetails.StartDate,
                EndDate = ConcertDetails.EndDate,
                ImageURL = ConcertDetails.ImageURL,
                Genre = ConcertDetails.Genre,
                ArtisteIds = ConcertDetails.Artiste_Concerts.Select(n => n.ArtisteId).ToList(),
            };

            var ConcertDropdownsData = await _service.GetNewConcertDropdownsValues();
            ViewBag.Artistes = new SelectList(ConcertDropdownsData.Artistes, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewConcertVM Concert)
        {
            if (id != Concert.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var ConcertDropdownsData = await _service.GetNewConcertDropdownsValues();

                ViewBag.Artistes = new SelectList(ConcertDropdownsData.Artistes, "Id", "FullName");

                return View(Concert);
            }

            await _service.UpdateConcertAsync(Concert);
            return RedirectToAction(nameof(Index));
        }
    }
}