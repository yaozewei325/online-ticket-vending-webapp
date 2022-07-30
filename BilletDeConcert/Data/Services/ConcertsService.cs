using BilletDeConcert.Data;
using BilletDeConcert.Data.Templates;
using BilletDeConcert.Data.ViewModels;
using BilletDeConcert.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilletDeConcert.Data.Services
{
    public class ConcertsService : MethodsTemp<Concert>, IConcertsService
    {
        private readonly AppDbContext _context;
        public ConcertsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewConcertAsync(NewConcertVM data)
        {
            var newConcert = new Concert()
            {
                Nom = data.Nom,
                Description = data.Description,
                Prix = data.Prix,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Genre= data.Genre,
            };
            await _context.Concerts.AddAsync(newConcert);
            await _context.SaveChangesAsync();

            //Add Concert Artistes 
            foreach (var artisteId in data.ArtisteIds)
            {
                var newArtisteConcert = new Artiste_Concert()
                {
                    ConcertId = newConcert.Id,
                    ArtisteId = artisteId
                };
                await _context.Artiste_Concerts.AddAsync(newArtisteConcert);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Concert> GetConcertByIdAsync(int id)
        {
            var ConcertDetails = await _context.Concerts
                .Include(am => am.Artiste_Concerts).ThenInclude(a => a.Artiste)
                .FirstOrDefaultAsync(n => n.Id == id);

            return ConcertDetails;
        }

        public async Task<NewConcertDropdownsVM> GetNewConcertDropdownsValues()
        {
            var response = new NewConcertDropdownsVM()
            {
                Artistes = await _context.Artistes.OrderBy(n => n.FullName).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateConcertAsync(NewConcertVM data)
        {
            var dbConcert = await _context.Concerts.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbConcert != null)
            {
                dbConcert.Nom = data.Nom;
                dbConcert.Description = data.Description;
                dbConcert.Prix = data.Prix;
                dbConcert.ImageURL = data.ImageURL;
                dbConcert.StartDate = data.StartDate;
                dbConcert.EndDate = data.EndDate;
                dbConcert.Genre = data.Genre;
                await _context.SaveChangesAsync();
            }

            //Remove existing Artistes
            var existingArtistesDb = _context.Artiste_Concerts.Where(n => n.ConcertId == data.Id).ToList();
            _context.Artiste_Concerts.RemoveRange(existingArtistesDb);
            await _context.SaveChangesAsync();

            //Add Concert Artistes
            foreach (var artisteId in data.ArtisteIds)
            {
                var newArtisteConcert = new Artiste_Concert()
                {
                    ConcertId = data.Id,
                    ArtisteId = artisteId
                };
                await _context.Artiste_Concerts.AddAsync(newArtisteConcert);
            }
            await _context.SaveChangesAsync();
        }
    }
}
