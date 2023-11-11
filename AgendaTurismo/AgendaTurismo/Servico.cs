namespace AgendaTurismo
{
    public class Servico
    {
        private string nome;
        private string descricao;
        private string modalidadePagamento;
        private double valor;

        public string Nome { get { return nome; } }
        public string Descricao { get { return descricao; } }
        public string ModalidadePagamento { get { return modalidadePagamento; } }
        public double Valor { get { return valor; } }

        public Servico(string nome, string descricao, string modalidadePagamento, double valor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.modalidadePagamento = modalidadePagamento;
            this.valor = valor;
        }
    }
}
