using BookStore.Interfaces;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Services
{
    public class BookstoreService : IBookstoreService
    {
        public Task<IEnumerable<Book>> GetBooksAsync(string searchString)
        {
            string booksData = "[{ \"title\":\"Mastering åäö\", \"author\":\"Average Swede\", \"price\":762, \"inStock\":15},{ \"title\":\"How To Spend Money\", \"author\":\"Rich Block\", \"price\":1000000, \"inStock\":1},{ \"title\":\"Generic Title\", \"author\":\"First Author\", \"price\":185.5, \"inStock\":5},{ \"title\":\"Generic Title\", \"author\":\"Second Author\", \"price\":1748, \"inStock\":3},{ \"title\":\"Random Sales\", \"author\":\"Cunning Bastard\", \"price\":999, \"inStock\":20},{ \"title\":\"Random Sales\", \"author\":\"Cunning Bastard\", \"price\":499.5, \"inStock\":3},{ \"title\":\"Desired\", \"author\":\"Rich Bloke\", \"price\":564.5, \"inStock\":0}]";
            List<Book> AllBooks = JsonConvert.DeserializeObject<List<Book>>(booksData);

            if(string.IsNullOrEmpty(searchString))
            {
                return Task.FromResult(AllBooks.Select(B => B));
            }
            else
            {
                searchString = searchString.ToLower();
                return Task.FromResult(AllBooks.Where(B => B.Title.ToLower().Contains(searchString) || B.Author.ToLower().Contains(searchString)));
            }
        }
                    

    }
}