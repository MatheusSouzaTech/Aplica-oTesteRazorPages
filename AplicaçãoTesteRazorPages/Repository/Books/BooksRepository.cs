using AplicaçãoTesteRazorPages.Data;
using AplicaçãoTesteRazorPages.Domain.Interfaces;
using AplicaçãoTesteRazorPages.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AplicaçãoTesteRazorPages.Repository.Books
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _context;

        public BooksRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> AddAsyncBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return await ListAsyncBooks();
        }

        public async Task<Book?> BuscarAsyncIdBook(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> BuscarAsyncIdCategory(int idCategory)
        {
            return await _context.Books
                                 .Include(b => b.Categories)
                                 .Include(b => b.Author)
                                 .Where(b => b.Categories.Any(c => c.Id == idCategory))
                                 .ToListAsync();
        }

        
        public async Task<Book?> BuscarAsyncLivroIdAutor(int idAutor)
        {
            return await _context.Books
                                 .Include(b => b.Author)
                                 .Include(b => b.Categories)
                                 .FirstOrDefaultAsync(b => b.Author != null && b.Author.Id == idAutor);
        }

        public async Task<List<Book>> ListAsyncBooks()
        {
            return await _context.Books
                                 .Include(b => b.Author)
                                 .Include(b => b.Categories)
                                 .ToListAsync();
        }

        public async Task<List<Book>> RemoveAsyncBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return await ListAsyncBooks();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return await ListAsyncBooks();
        }

        public async Task<List<Book>> UpdateAsyncBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return await ListAsyncBooks();
        }
    }
}
