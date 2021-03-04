using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models.ViewModels
{
    public class BookListViewModel

        //this class lets us pass everything that we want to see in the index.cshtml
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        //added category to help filter
        public string Category { get; set; }


    }
}
