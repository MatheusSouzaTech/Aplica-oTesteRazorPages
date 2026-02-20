using AplicaçãoTesteRazorPages.Domain.Models;

namespace AplicaçãoTesteRazorPages.Domain.Interfaces
{
    public interface IAuthorService
    {

        Task<List<Author>> GetAuthorsAsync();

        Task<Author?> GetAuthorIdAsync(int id);

        Task AdicionarAuthor(Author author);
        Task AtualizarAuthor(Author author);
        Task DeletarAuthor(int id);


    }
}
