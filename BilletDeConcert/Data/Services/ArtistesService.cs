using BilletDeConcert.Data;
using BilletDeConcert.Data.Services;
using BilletDeConcert.Data.Templates;
using BilletDeConcert.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
namespace BilletDeConcert.Data.Services
{
    public class ArtistesService : MethodsTemp<Artiste>, IArtistesService
    {
        public ArtistesService(AppDbContext context) : base(context) { }
    }
}
