using AplicaçãoTesteRazorPages.Data;
using AplicaçãoTesteRazorPages.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicaçãoTesteRazorPages.Repository.Author
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorAsync(Domain.Models.Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public async Task DeleteAsync(int id)
        {
            var author =  await GetAuthorIdAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChangesAsync();
            }
             
        }

        public async Task<Domain.Models.Author?> GetAuthorIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author;
        }

        public async Task<List<Domain.Models.Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task UpdateAsync(Domain.Models.Author author)
        {
            _context.Authors.Update(author);
             await _context.SaveChangesAsync();
        }
    }
}
