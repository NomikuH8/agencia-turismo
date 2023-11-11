namespace AgendaTurismo
{
    public class Transacao
    {
        private Cliente comprador;
        private List<Servico> servicos;
        private Fornecedor fornecedor;

        public Transacao(Cliente comprador, List<Servico> servicos, Fornecedor fornecedor)
        {
            this.comprador = comprador;
            this.servicos = servicos;
            this.fornecedor = fornecedor;
        }

        public double GerarValorCobrado()
        {
            double valorCobrado = 0;

            foreach (Servico servico in this.servicos)
                valorCobrado += servico.Valor;

            return valorCobrado;
        }
    }
}
