namespace AgendaTurismo
{
    public class BancoDados
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Fornecedor> fornecedores = new List<Fornecedor>();
        private List<InformacoesPagamento> informacoesPagamentos = new List<InformacoesPagamento>();
        private List<Servico> servicos = new List<Servico>();
        private List<Transacao> transacoes = new List<Transacao>();

        public List<Cliente> Clientes { get { return clientes;  } }
        public List<Fornecedor> Fornecedores { get { return fornecedores; } }
        public List<InformacoesPagamento> InformacoesPagamentos { get { return informacoesPagamentos; } }
        public List<Servico> Servicos { get { return servicos; } }
        public List<Transacao> Transacoes { get { return transacoes; } }
    }
}
