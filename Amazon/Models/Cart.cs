using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book _book, int _quantity)
        {
            CartLine line = Lines
                .Where(c => c.Book.BookID == _book.BookID)
                .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = _book,
                    Quantity = _quantity



                });
            }
            else
            {
                line.Quantity += _quantity;
            }
        }
        public virtual void RemoveLine(Book _book) =>
            Lines.RemoveAll(c => c.Book.BookID == _book.BookID);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeCartTotal()
        {
            return Lines.Sum(c => c.Book.Price * c.Quantity);
        }
        public int ComputeItemCount()
        {
            return Lines.Sum(c => c.Quantity);
        }
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }

        }
    }
}
