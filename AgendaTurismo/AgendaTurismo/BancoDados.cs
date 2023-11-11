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

        public BancoDados(bool populado = false)
        {
            if (!populado) return;

            this.clientes.Add(new Cliente("Menna", "menna@gmail.com"));
            this.clientes.Add(new Cliente("Sophia", "fifi@gmail.com"));
            this.clientes.Add(new Cliente("Graziela", "grazi@gmail.com"));
            this.clientes.Add(new Cliente("Richard", "ricardo@gmail.com"));
            this.clientes.Add(new Cliente("Henrique", "henrique@gmail.com"));

            this.servicos.Add(new Servico("Passagens aereas", "3 vezes no crédito", 900.0));
            this.servicos.Add(new Servico("Hospedagem 3 dias", "A vista", 200.0));
            this.servicos.Add(new Servico("Aluguel de carro", "30 dias em 3 vezes", 500.0));


            // this.servicos[0] = Passagens aereas
            // this.servicos[1] = Hospedagem 3 dias
            // this.servicos[2] = Aluguel de carro
            this.fornecedores.Add(new Fornecedor("Mercury"));
            this.fornecedores[0].AssociarServico(this.servicos[2]);

            this.fornecedores.Add(new Fornecedor("Localiza"));
            this.fornecedores[1].AssociarServico(this.servicos[2]);

            this.fornecedores.Add(new Fornecedor("123milhas"));
            this.fornecedores[2].AssociarServico(this.servicos[0]);
            this.fornecedores[2].AssociarServico(this.servicos[1]);
            this.fornecedores[2].AssociarServico(this.servicos[2]);

            this.fornecedores.Add(new Fornecedor("Decolar.com"));
            this.fornecedores[3].AssociarServico(this.servicos[0]);
            this.fornecedores[3].AssociarServico(this.servicos[1]);

            this.fornecedores.Add(new Fornecedor("Azul"));
            this.fornecedores[4].AssociarServico(this.servicos[1]);

            this.informacoesPagamentos = informacoesPagamentos;
            this.transacoes = transacoes;
        }
    }
}
