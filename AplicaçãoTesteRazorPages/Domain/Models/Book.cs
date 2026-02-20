namespace AplicaçãoTesteRazorPages.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Year { get; set; } = 0;

        public Author Author { get; set; }

        public ICollection<Categories> Categories { get; set; } = new List<Categories>();

    }
}
