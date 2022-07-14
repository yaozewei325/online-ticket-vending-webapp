using BilletDeConcert.Data.Templates;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BilletDeConcert.Models
{
    public class Artiste:IEntityTemp
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "L'image du profil est requise")]
        public string PhotoURL { get; set; }

        [Display(Name = "Nom Complet")]
        [Required(ErrorMessage = "Le nom complet est requis")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom complet doit comporter entre 3 et 50 caractères")]
        public string FullName { get; set; }


        [Display(Name = "Biographie")]
        [Required(ErrorMessage = "La biographie est obligatoire")]
        public string Bio { get; set; }
        public List<Artiste_Concert> Artiste_Concerts { get; set; }
    }
}
