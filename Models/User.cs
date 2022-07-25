namespace pedronogueira_d3_avaliacao.Models
{
    internal class User
    {
        public Guid IdUser { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    internal class publicUser
    {
        public Guid IdUser { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
