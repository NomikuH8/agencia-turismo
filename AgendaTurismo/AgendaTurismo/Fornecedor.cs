namespace AgendaTurismo
{
    public class Fornecedor
    {
        private string nome;
        private List<Servico> servicos = new List<Servico>();
        private bool deletado;

        public string Nome { get { return nome; } }
        public List<Servico> Servicos { get { return servicos; } }
        public bool Deletado { get { return deletado; } }

        public Fornecedor(string nome)
        {
            this.nome = nome;
        }

        public Fornecedor(string nome, List<Servico> servicos)
        {
            this.nome = nome;
            this.servicos = servicos;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setDeletado(bool deletado)
        {
            this.deletado = deletado;
        }

        public void AssociarServico(Servico servico)
        {
            servicos.Add(servico);
        }
    }
}
