namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Priority { get; set; }
        public string Login { get; set; }

        public static int ADMIN = 1;
        public static int PADRAO = 0;       

    }
}


