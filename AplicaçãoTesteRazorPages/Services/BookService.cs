using AplicaçãoTesteRazorPages.Domain.Interfaces;
using AplicaçãoTesteRazorPages.Domain.Models;
using AplicaçãoTesteRazorPages.Repository.Books;

namespace AplicaçãoTesteRazorPages.Services
{
    public class BookService : IBooksService
    {
        private readonly BooksRepository _bookRepository;

        public BookService(BooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<List<Book>> AdicionarLivro(Book book)
        {
            return _bookRepository.AddAsyncBook(book);
        }

        public Task<List<Book>> AtualizarLivro(Book book)
        {
            return _bookRepository.UpdateAsyncBook(book);
        }

        public Task BuscarLivroPorAutorId(int idAutor)
        {
            return _bookRepository.BuscarAsyncLivroIdAutor(idAutor);
        }

        public Task<List<Book>> BuscarLivroPorCategoriaId(int idCategory)
        {
            return _bookRepository.BuscarAsyncIdCategory(idCategory);
        }

        public Task<Book?> BuscarLivroPorId(int id)
        {
            return _bookRepository.BuscarAsyncIdBook(id);
        }

        public Task<List<Book>> DeletarLivro(int id)
        {
            return _bookRepository.RemoveAsyncBook(id);
        }

        public Task<List<Book?>> ListarLivros()
        {
            return _bookRepository.ListAsyncBooks();
        }
    }
}
