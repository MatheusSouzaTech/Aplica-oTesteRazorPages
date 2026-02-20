using AplicaçãoTesteRazorPages.Domain.Interfaces;
using AplicaçãoTesteRazorPages.Domain.Models;

namespace AplicaçãoTesteRazorPages.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task AdicionarAuthor(Author author)
        {
            return _authorRepository.AddAuthorAsync(author);
        }

        public Task AtualizarAuthor(Author author)
        {
            return _authorRepository.UpdateAsync(author);
        }

        public Task DeletarAuthor(int id)
        {
            return _authorRepository.DeleteAsync(id);
        }

        public Task<Author?> GetAuthorIdAsync(int id)
        {
            return _authorRepository.GetAuthorIdAsync(id);
        }

        public Task<List<Author>> GetAuthorsAsync()
        {
            return _authorRepository.GetAuthorsAsync();
        }
    }
}
