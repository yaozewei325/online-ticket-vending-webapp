using BilletDeConcert.Data;
using BilletDeConcert.Data.Enum;
using BilletDeConcert.Data.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BilletDeConcert.Models
{
    public class NewConcertVM
    {
        public int Id { get; set; }

        [Display(Name = "Nom du concert")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }

        [Display(Name = "Concert description")]
        [Required(ErrorMessage = "La description est requise")]
        public string Description { get; set; }

        [Display(Name = "Prix en $")]
        [Required(ErrorMessage = "Le prix est requis")]
        public double Prix { get; set; }

        [Display(Name = "Affiche de concert URL")]
        [Required(ErrorMessage = "L'URL de l'affiche du concert est requise")]
        public string ImageURL { get; set; }

        [Display(Name = "Date début du concert")]
        [Required(ErrorMessage = "La date de début est requise")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date de fin du concert")]
        [Required(ErrorMessage = "La date de fin est requise")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Sélectionnez un genre")]
        [Required(ErrorMessage = "Le genre est requis")]
        public Genre Genre { get; set; }

        //Relationships
        [Display(Name = "Sélectionnez le(s) artiste(s)")]
        [Required(ErrorMessage = "Un ou plusieurs artistes de concert sont requis")]
        public List<int> ArtisteIds { get; set; }

  
    }
}
