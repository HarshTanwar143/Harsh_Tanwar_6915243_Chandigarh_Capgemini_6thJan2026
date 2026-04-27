using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement
{
    internal class Inventory
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> GetBooksCheaperThan(double price)
        {
            return books.Where(b => b.Price < price).ToList();
        }

        public void IncreasePriceByPercentage(double percentage)
        {
            books.ForEach(b => b.Price += b.Price * percentage / 100);
        }

        public void RemoveOutOfStockBooks()
        {
            books = books.Where(b => b.Stock > 0).ToList();
        }

        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} | ₹{book.Price} | Stock: {book.Stock}");
            }
        }
    }
}
