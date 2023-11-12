namespace AgendaTurismo
{
    public class Cliente
    {
        private string nome;
        private string email;
        private bool deletado;

        public Cliente(string nome, string email, bool deletado = false)
        {
            this.nome = nome;
            this.email = email;
            this.deletado = deletado;
        }

        public string Nome { get { return nome; } }
        public string Email { get { return email; } }
        public bool Deletado { get {  return deletado; } }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setDeletado(bool deletado)
        {
            this.deletado = deletado;
        }
    }
}
