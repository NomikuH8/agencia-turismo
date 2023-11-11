namespace AgendaTurismo
{
    public class GeradorMenu
    {
        public void LimparTela()
        {
            Console.Clear();
        }

        public void GerarMenu(string caminho, List<string> opcoes, bool temSair, string sairText = "0) Retornar")
        {
            Console.WriteLine(caminho);
            Console.WriteLine();

            int contador = 1;
            foreach (string opcao in opcoes)
            {
                Console.WriteLine(contador + ") " + opcao);
                contador++;
            }

            Console.WriteLine();

            if (temSair) Console.WriteLine(sairText);

            Console.WriteLine();
        }

        public int PedirInput(string texto)
        {
            string? input = "";
            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
            {
                Console.WriteLine(texto);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
                    Console.WriteLine("Opção inválida.");
            }
            return int.Parse(input);
        }

        public string PegarOpcaoEscolhida(int opcao, List<string> opcoes)
        {
            if (opcao != 0)
            {
                try
                {
                    return opcoes[opcao - 1];
                }
                catch
                {
                    return "invalido";
                }
            }
            else if (opcao == 0)
            {
                return "sair";
            }
            return "invalido";
        }

        public List<string> FazerPerguntas(List<string> perguntas)
        {
            List<string> respostas = new List<string>();

            foreach (string pergunta in perguntas)
            {
                string? resposta;
                while (true)
                {
                    Console.WriteLine(pergunta);
                    resposta = Console.ReadLine();

                    if (string.IsNullOrEmpty(resposta))
                    {
                        Console.WriteLine("Você deve escrever alguma coisa!");
                    }
                    else
                    {
                        respostas.Add(resposta);
                        break;
                    }
                }
            }
            return respostas;
        }
    }
}
