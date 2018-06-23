using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Interfaces
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        decimal Price { get; }
        int inStock { get; set; }
    }
}