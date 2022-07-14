using BilletDeConcert.Data.Templates;
using BilletDeConcert.Data.ViewModels;
using BilletDeConcert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilletDeConcert.Data.Services
{
    public interface IConcertsService : IMethodsTemp<Concert>
    {
        Task<Concert> GetConcertByIdAsync(int id);
        Task<NewConcertDropdownsVM> GetNewConcertDropdownsValues();
        Task AddNewConcertAsync(NewConcertVM data);
        Task UpdateConcertAsync(NewConcertVM data);
    }
}
