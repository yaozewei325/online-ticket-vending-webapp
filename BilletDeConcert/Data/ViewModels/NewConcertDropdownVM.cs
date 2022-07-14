using BilletDeConcert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BilletDeConcert.Data.ViewModels
{
    public class NewConcertDropdownsVM
    {
        public NewConcertDropdownsVM()
        {
            Artistes = new List<Artiste>();
        }

        public List<Artiste> Artistes { get; set; }
    }
}
