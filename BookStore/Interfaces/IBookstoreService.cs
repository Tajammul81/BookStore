using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Interfaces
{
    public interface IBookstoreService
    {
        Task<IEnumerable<Book>> GetBooksAsync(string searchString);
    }
}