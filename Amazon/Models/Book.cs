using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [RegularExpression("\\d{3}-\\d{10}")]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorMiddleInitial { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string Classification { get; set; }
        public string Category { get; set; }
        //Model has been updated to include the number of pages, and that data is reflected in the database
        public int TotalPages { get; set; }


        //public Book(string title, string authorfn, string authorln, string authormi, string publisher, string isbn, decimal price, string category)
        //{
        //    this.Title = title;
        //    this.AuthorFirstName = authorfn;
        //    this.AuthorLastName = authorln;
        //    this.AuthorMiddleInitial = authormi;
        //    this.Publisher = publisher;
        //    this.Price = price;
        //    this.ISBN = isbn;
        //    this.Classification = category;
        //}
    }
}
