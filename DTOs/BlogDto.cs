namespace MonApiMSSQL.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } // Supposant que la classe User a une propriété `Name`
    }
}
