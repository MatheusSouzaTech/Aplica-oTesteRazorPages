using AplicaçãoTesteRazorPages.Domain.Models;

namespace AplicaçãoTesteRazorPages.Domain.Interfaces
{
    public interface IBooksService
    {
        Task<List<Book?>> ListarLivros();
        Task<Book?> BuscarLivroPorId(int id);
        Task<List<Book>> AtualizarLivro(Book book);

        Task<List<Book>> AdicionarLivro(Book book);
        Task<List<Book>> DeletarLivro(int id);
        Task<List<Book>> BuscarLivroPorCategoriaId(int idCategory);
        Task BuscarLivroPorAutorId(int idAutor);

    }
}
