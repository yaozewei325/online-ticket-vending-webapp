using BilletDeConcert.Models;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using BilletDeConcert.Data.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace BilletDeConcert.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Vérifiez d'abord si les listes sont vides, si c'est le cas, initialisez en remplissant les données de test.
                //Artistes
                if (!context.Artistes.Any())
                {
                    context.Artistes.AddRange(new List<Artiste>()
                    {
                        new Artiste()
                        {
                            FullName = "Artiste 1",
                            Bio = "This is the Bio of the first Artiste",
                            PhotoURL = "https://image.shutterstock.com/image-photo/los-angeles-jan-10-jay-600w-68774434.jpg"

                        },
                        new Artiste()
                        {
                            FullName = "Artiste 2",
                            Bio = "This is the Bio of the second Artiste",
                            PhotoURL = "https://image.shutterstock.com/image-photo/los-angeles-jan-10-jay-600w-68774434.jpg"
                        },
                        new Artiste()
                        {
                            FullName = "Artiste 3",
                            Bio = "This is the Bio of the third Artiste",
                            PhotoURL = "https://image.shutterstock.com/image-photo/los-angeles-jan-10-jay-600w-68774434.jpg"
                        },
                        new Artiste()
                        {
                            FullName = "Artiste 4",
                            Bio = "This is the Bio of the fourth Artiste",
                            PhotoURL = "https://image.shutterstock.com/image-photo/los-angeles-jan-10-jay-600w-68774434.jpg"
                        },
                        new Artiste()
                        {
                            FullName = "Artiste 5",
                            Bio = "This is the Bio of the fifth Artiste",
                            PhotoURL = "https://image.shutterstock.com/image-photo/los-angeles-jan-10-jay-600w-68774434.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                //Concerts
                if (!context.Concerts.Any())
                {
                    context.Concerts.AddRange(new List<Concert>()
                    {
                        new Concert()
                        {
                            Nom = "COUCOU PASSE-PARTOUT, LE SPECTACLE!",
                            Description = "This is the first Concert description",
                            Prix = 19.50,
                            ImageURL = "https://image.shutterstock.com/z/stock-photo-silhouette-of-young-girl-waving-hands-to-the-music-on-popular-dj-concert-in-night-club-big-group-of-1913904964.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            Genre = Genre.Jazz
                        },
                        new Concert()
                        {
                            Nom = "The second concert",
                            Description = "This is the second concert description",
                            Prix = 29.50,
                            ImageURL = "https://image.shutterstock.com/z/stock-photo-silhouette-of-young-girl-waving-hands-to-the-music-on-popular-dj-concert-in-night-club-big-group-of-1913904964.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            Genre = Genre.Pop
                        },
                        new Concert()
                        {
                            Nom = "The third concert",
                            Description = "This is the third Concert description",
                            Prix = 29.50,
                            ImageURL = "https://image.shutterstock.com/z/stock-photo-silhouette-of-young-girl-waving-hands-to-the-music-on-popular-dj-concert-in-night-club-big-group-of-1913904964.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            Genre = Genre.Hiphop
                        },
                        new Concert()
                        {
                            Nom = "The fourth concert",
                            Description = "This is the fourth Concert description",
                            Prix = 39.50,
                            ImageURL = "https://image.shutterstock.com/z/stock-photo-silhouette-of-young-girl-waving-hands-to-the-music-on-popular-dj-concert-in-night-club-big-group-of-1913904964.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            Genre = Genre.ComédiesMusicales
                        },
                        new Concert()
                        {
                            Nom = "The fifth concert",
                            Description = "This is the fifth Concert description",
                            Prix = 39.50,
                            ImageURL = "https://image.shutterstock.com/z/stock-photo-silhouette-of-young-girl-waving-hands-to-the-music-on-popular-dj-concert-in-night-club-big-group-of-1913904964.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            Genre = Genre.Country
                        },
                        new Concert()
                        {
                            Nom = "The sixth concert",
                            Description = "This is the sixth Concert description",
                            Prix = 29.50,
                            ImageURL = "https://image.shutterstock.com/z/stock-photo-silhouette-of-young-girl-waving-hands-to-the-music-on-popular-dj-concert-in-night-club-big-group-of-1913904964.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            Genre = Genre.Classique
                        }
                    });
                    context.SaveChanges();
                }
                //Artistes & Concerts
                if (!context.Artiste_Concerts.Any())
                {
                    context.Artiste_Concerts.AddRange(new List<Artiste_Concert>()
                    {
                        new Artiste_Concert()
                        {
                            ArtisteId = 1,
                            ConcertId = 1
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 3,
                            ConcertId = 1
                        },

                         new Artiste_Concert()
                        {
                            ArtisteId = 1,
                            ConcertId = 2
                        },
                         new Artiste_Concert()
                        {
                            ArtisteId = 4,
                            ConcertId = 2
                        },

                        new Artiste_Concert()
                        {
                            ArtisteId = 1,
                            ConcertId = 3
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 2,
                            ConcertId = 3
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 5,
                            ConcertId = 3
                        },


                        new Artiste_Concert()
                        {
                            ArtisteId = 2,
                            ConcertId = 4
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 3,
                            ConcertId = 4
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 4,
                            ConcertId = 4
                        },


                        new Artiste_Concert()
                        {
                            ArtisteId = 2,
                            ConcertId = 5
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 3,
                            ConcertId = 5
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 4,
                            ConcertId = 5
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 5,
                            ConcertId = 5
                        },


                        new Artiste_Concert()
                        {
                            ArtisteId = 3,
                            ConcertId = 6
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 4,
                            ConcertId = 6
                        },
                        new Artiste_Concert()
                        {
                            ArtisteId = 5,
                            ConcertId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

    }
}
