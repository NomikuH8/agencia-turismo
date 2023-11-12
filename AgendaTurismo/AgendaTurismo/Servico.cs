namespace AgendaTurismo
{
    public class Servico
    {
        private string nome;
        private string modalidadePagamento;
        private double valor;
        private bool deletado;

        public string Nome { get { return nome; } }
        public string ModalidadePagamento { get { return modalidadePagamento; } }
        public double Valor { get { return valor; } }
        public bool Deletado { get { return deletado; } }

        public Servico(string nome, string modalidadePagamento, double valor)
        {
            this.nome = nome;
            this.modalidadePagamento = modalidadePagamento;
            this.valor = valor;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setModalidadePagamento(string modalidadePagamento)
        {
            this.modalidadePagamento = modalidadePagamento;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }

        public void setDeletado(bool deletado)
        {
            this.deletado = deletado;
        }
    }
}
