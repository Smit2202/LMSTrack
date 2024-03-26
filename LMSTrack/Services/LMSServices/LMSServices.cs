using Azure.Core;
using LMSTrack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static LMSTrack.Model.ModelClass;

namespace LMSTrack.Services.LMSServices
{
    public class LMSServices : ILMSServices
    {
        private readonly LMSDbContext _context;

        public LMSServices(LMSDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetBooks()
        {
            var heroes = await _context.Books.ToListAsync();
            return heroes;
        }
        public async Task<Book?> GetBook(int id)
        {
            var hero = await _context.Books.FindAsync(id);
            if (hero is null)
                return null;

            return hero;
        }

        public async Task<Book?> GetBookbyname(string titlename)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == titlename);
            return book; 
        }
        public async Task<List<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            // Returning the list of books after adding the new book
            return await _context.Books.ToListAsync();
        }


        public async Task<List<Book>> PutBook(int id, Book book)
        {
            var hero = await _context.Books.FindAsync(id);
            if (hero is null)
                return null;

            hero.Author = book.Author;
            hero.Title = book.Title;
            hero.bId = book.bId;
            hero.Availability = book.Availability;
            

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
        public async Task<List<Book>> DeleteBook(int id)
        {
            var hero = await _context.Books.FindAsync(id);
            if (hero is null)
                return null;

            _context.Books.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        private bool BookExists(int bId)
        {
            return _context.Books.Any(e => e.bId == bId);
        }
    }
}
