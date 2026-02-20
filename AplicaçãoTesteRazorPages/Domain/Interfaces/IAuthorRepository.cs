using AplicaçãoTesteRazorPages.Domain.Models;

namespace AplicaçãoTesteRazorPages.Domain.Interfaces
{
    public interface IAuthorRepository 
    {
        Task<List<Author>> GetAuthorsAsync();

        Task<Author?> GetAuthorIdAsync(int id);

        Task AddAuthorAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
      
    }
}
