namespace AgendaTurismo
{
    public class Fornecedor
    {
        private string nome;
        private List<Servico> servicos = new List<Servico>();

        public string Nome { get { return nome; } }

        public Fornecedor(string nome)
        {
            this.nome = nome;
        }

        public void AssociarServico(Servico servico)
        {
            servicos.Add(servico);
        }
    }
}
