using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using BilletDeConcert.Data.Enum;
using BilletDeConcert.Data.Templates;

namespace BilletDeConcert.Models
{
    public class Concert : IEntityTemp
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Genre Genre { get; set; }

        public List<Artiste_Concert> Artiste_Concerts{ get; set; }

    }
}
