namespace AgendaTurismo
{
    public class InformacoesPagamento
    {
        private DateTime dataVencimento;
        private Transacao transacao;
        private double valorCobrado;
        private Fornecedor fornecedor;

        public DateTime DataVencimento { get { return dataVencimento; } }
        public Transacao Transacao { get { return transacao; } }
        public double ValorCobrado { get { return valorCobrado; } }
        public Fornecedor Fornecedor{ get { return fornecedor; } }

        public InformacoesPagamento(DateTime dataVencimento, Transacao transacao, Fornecedor fornecedor)
        {
            this.dataVencimento = dataVencimento;
            this.transacao = transacao;
            this.valorCobrado = this.transacao.GerarValorCobrado();
            this.fornecedor = fornecedor;
        }
    }
}
