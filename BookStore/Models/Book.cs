﻿using BookStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book : IBook
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int inStock { get; set; }
    }
}