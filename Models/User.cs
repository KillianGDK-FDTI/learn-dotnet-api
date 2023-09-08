namespace MonApiMSSQL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        // Propriété de navigation pour Article
        public List<Article> Articles { get; set; } = null!;

        // Propriété de navigation pour les Blogs
        public List<Blog> Blogs { get; set; } = null!;
    }
}
