using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class SeedData
    {
        public static void EnsureaPopulated(IApplicationBuilder application)
        {
            BookDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        ISBN = "978-0451419439",
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        AuthorMiddleInitial = "",
                        Publisher = "Signet",
                        Price = 9.95m,
                        ClassificationCategory = "Fiction, Classic",
                        TotalPages = 1488
                    },
                    new Book
                    {
                        ISBN = "978-0743270755",
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorLastName = "Goodwin",
                        AuthorMiddleInitial = "Kearns",
                        Publisher = "Simon & Schuster",
                        Price = 14.58m,
                        ClassificationCategory = "Non-Fiction, Biography",
                        TotalPages = 944

                    },

                    new Book
                    {
                        ISBN = "978-0553384611",
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        AuthorMiddleInitial = "",
                        Publisher = "Bantam",
                        Price = 21.54m,
                        ClassificationCategory = "Non-Fiction, Biography",
                        TotalPages = 832
                    },
                    new Book
                    {
                        ISBN = "978-0812981254",
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorLastName = "White",
                        AuthorMiddleInitial = "C.",
                        Publisher = "Random House",
                        Price = 11.61m,
                        ClassificationCategory = "Non-Fiction, Biography",
                        TotalPages = 864
                    },
                    new Book
                    {
                        ISBN = "978-0812974492",
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        AuthorMiddleInitial = "",
                        Publisher = "Random House",
                        Price = 13.33m,
                        ClassificationCategory = "Non-Fiction, Historical",
                        TotalPages = 528
                    },
                    new Book
                    {
                        ISBN = "978-0804171281",
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        AuthorMiddleInitial = "",
                        Publisher = "Vintage",
                        Price = 15.95m,
                        ClassificationCategory = "Fiction, Historical Fiction",
                        TotalPages = 288
                    },
                    new Book
                    {
                        ISBN = "978-1455586691",
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        AuthorMiddleInitial = "",
                        Publisher = "Grand Central Publishing",
                        Price = 14.99m,
                        ClassificationCategory = "Non-Fiction, Self-Help",
                        TotalPages = 304
                    },
                    new Book
                    {
                        ISBN = "978-1455523023",
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        AuthorMiddleInitial = "",
                        Publisher = "Grand Central Publishing",
                        Price = 21.66m,
                        ClassificationCategory = "Non-Fiction, Self-Help",
                        TotalPages = 240
                    },
                    new Book
                    {
                        ISBN = "978-1591847984",
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        AuthorMiddleInitial = "",
                        Publisher = "Portfolio",
                        Price = 29.16m,
                        ClassificationCategory = "Non-Fiction, Business",
                        TotalPages = 400
                    },
                    new Book
                    {
                        ISBN = "978-0553393613",
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        AuthorMiddleInitial = "",
                        Publisher = "Bantam",
                        Price = 15.03m,
                        ClassificationCategory = "Fiction, Thrillers",
                        TotalPages = 642
                    },
                    //Three new books have been added to the database through the Seed Data
                    new Book
                    {
                        ISBN = "978-0142417447",
                        Title = "The Ruins of Gorlan: Book 1 (Ranger's Apprentice)",
                        AuthorFirstName = "John",
                        AuthorLastName = "Flanagan",
                        AuthorMiddleInitial = "",
                        Publisher = "Penguin Group (USA) LLC",
                        Price = 8.29m,
                        ClassificationCategory = "Fantasy Fiction, Adventure Fiction",
                        TotalPages = 268
                    },
                    new Book
                    {
                        ISBN = "978-0765376671",
                        Title = "The Way of Kings: The Stormlight Archive Book One",
                        AuthorFirstName = "Brandon",
                        AuthorLastName = "Sanderson",
                        AuthorMiddleInitial = "",
                        Publisher = "Tor Books",
                        Price = 14.79m,
                        ClassificationCategory = "High Fantasy",
                        TotalPages = 1005
                    },
                    //this last one is pretty good.
                    new Book
                    {
                        ISBN = "978-0385519472",
                        Title = "Book of Mormon",
                        AuthorFirstName = "Various Authors",
                        AuthorLastName = "",
                        AuthorMiddleInitial = "",
                        Publisher = "The Church of Jesus Christ of Latter Day Saints",
                        Price = 15.99m,
                        ClassificationCategory = "Sacred Text",
                        TotalPages = 779
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
