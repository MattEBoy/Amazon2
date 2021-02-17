using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class BookDBContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public BookDBContext(DbContextOptions<BookDBContext> options) : base (options)
        {
            //public virtual DbSet<Book>  
        }

    }
}
