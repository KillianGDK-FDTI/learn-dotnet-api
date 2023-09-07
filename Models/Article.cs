using System.ComponentModel.DataAnnotations.Schema;

namespace MonApiMSSQL.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public string Contenu { get; set; } = null!;

        // Clé étrangère pour User
        public int UserId { get; set; }

        // Propriété de navigation
        public User? User { get; set; } = null!;
    }
}
