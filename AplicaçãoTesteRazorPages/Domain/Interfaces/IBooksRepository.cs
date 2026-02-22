using AplicaçãoTesteRazorPages.Domain.Models;

namespace AplicaçãoTesteRazorPages.Domain.Interfaces
{
    public interface IBooksRepository
    {

        Task<List<Book>> ListAsyncBooks();

        Task<Book?> BuscarAsyncIdBook(int id);

        Task<List<Book>> AddAsyncBook(Book book);

        Task<List<Book>> RemoveAsyncBook(int id);

        Task<List<Book>> UpdateAsyncBook(Book book);

        Task<List<Book>> BuscarAsyncIdCategory(int categoryId);

        Task<Book> BuscarAsyncLivroIdAutor(int idAutor);


    }
}
