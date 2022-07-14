using BilletDeConcert.Models;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using BilletDeConcert.Data.Enum;

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

               
                //Artistes
                if (!context.Artistes.Any())
                {
                    context.Artistes.AddRange(new List<Artiste>()
                    {
                        new Artiste()
                        {
                            FullName = "Artiste 1",
                            Bio = "This is the Bio of the first Artiste",
                            PhotoURL = "http://dotnethow.net/images/Artistes/Artiste-1.jpeg"

                        },
                        new Artiste()
                        {
                            FullName = "Artiste 2",
                            Bio = "This is the Bio of the second Artiste",
                            PhotoURL = "http://dotnethow.net/images/Artistes/Artiste-2.jpeg"
                        },
                        new Artiste()
                        {
                            FullName = "Artiste 3",
                            Bio = "This is the Bio of the second Artiste",
                            PhotoURL = "http://dotnethow.net/images/Artistes/Artiste-3.jpeg"
                        },
                        new Artiste()
                        {
                            FullName = "Artiste 4",
                            Bio = "This is the Bio of the second Artiste",
                            PhotoURL = "http://dotnethow.net/images/Artistes/Artiste-4.jpeg"
                        },
                        new Artiste()
                        {
                            FullName = "Artiste 5",
                            Bio = "This is the Bio of the second Artiste",
                            PhotoURL = "http://dotnethow.net/images/Artistes/Artiste-5.jpeg"
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
                            Description = "This is the Life Concert description",
                            Prix = 39.50,
                            ImageURL = "https://www.evenko.ca/_uploads/event/37529/splash.jpg?v=1598304203",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            Genre = Genre.Jazz
                        },
                        new Concert()
                        {
                            Nom = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Prix = 29.50,
                            ImageURL = "http://dotnethow.net/images/Concerts/Concert-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            Genre = Genre.Pop
                        },
                        new Concert()
                        {
                            Nom = "Ghost",
                            Description = "This is the Ghost Concert description",
                            Prix = 39.50,
                            ImageURL = "http://dotnethow.net/images/Concerts/Concert-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            Genre = Genre.Hiphop
                        },
                        new Concert()
                        {
                            Nom = "Race",
                            Description = "This is the Race Concert description",
                            Prix = 39.50,
                            ImageURL = "http://dotnethow.net/images/Concerts/Concert-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            Genre = Genre.ComédiesMusicales
                        },
                        new Concert()
                        {
                            Nom = "Scoob",
                            Description = "This is the Scoob Concert description",
                            Prix = 39.50,
                            ImageURL = "http://dotnethow.net/images/Concerts/Concert-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            Genre = Genre.Country
                        },
                        new Concert()
                        {
                            Nom = "Cold Soles",
                            Description = "This is the Cold Soles Concert description",
                            Prix = 39.50,
                            ImageURL = "http://dotnethow.net/images/Concerts/Concert-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
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
