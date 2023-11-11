namespace AgendaTurismo
{
    public class Cliente
    {
        private string nome;
        private string email;

        public Cliente(string nome, string email)
        {
            this.nome = nome;
            this.email = email;
        }

        public string Nome { get { return nome; } }
        public string Email { get { return email; } }

        public Transacao Comprar(List<Servico> servicos, Fornecedor fornecedor)
        {
            Transacao novaTransacao = new Transacao(this, servicos, fornecedor);
            return novaTransacao;
        }
    }
}
