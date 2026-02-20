using AplicaçãoTesteRazorPages.Domain.Interfaces;
using AplicaçãoTesteRazorPages.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AplicaçãoTesteRazorPages.Pages
{
    public class AuthoresModel : PageModel
    {
        private readonly IAuthorService _autorService;
        private readonly ILogger<AuthoresModel> _logger;

        public AuthoresModel(IAuthorService autorService, ILogger<AuthoresModel> logger)
        {
            _autorService = autorService;
            _logger = logger;
            
        }

        [BindProperty]
        public Author AuthorForm { get; set; } = new Author();
        public List<Author> Authors { get; set; } = new List<Author>();
        public async Task OnGetAsync()
        {
            Authors = await _autorService.GetAuthorsAsync();

        }

        public async Task<ActionResult> OnPostDeleteAsync(int id)
        {
            await _autorService.DeletarAuthor(id);

            return RedirectToPage();
        }

        public async Task<ActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                Authors = await _autorService.GetAuthorsAsync();
                return Page();
            }

            if(AuthorForm.Id == 0)
            {
                await _autorService.AdicionarAuthor(AuthorForm);
            }
            else 
            { 
                await _autorService.AtualizarAuthor(AuthorForm);
            }
                
            return RedirectToPage();

        }


    }
}
