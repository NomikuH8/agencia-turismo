using AgendaTurismo;

GeradorMenu gerador = new GeradorMenu();

List<string> menuInicio = new List<string>();
menuInicio.Add("Clientes");
menuInicio.Add("Fornecedores");
menuInicio.Add("Serviços");
menuInicio.Add("Compras");
menuInicio.Add("Pagamentos");

List<string> menuCliente = new List<string>();
menuCliente.Add("Visualizar");
menuCliente.Add("Cadastrar");
menuCliente.Add("Atualizar");
menuCliente.Add("Excluir");

MainFunction();

void MainFunction()
{
    while (true)
    {
        gerador.LimparTela();
        gerador.GerarMenu("Início", menuInicio, true, "0) Sair");
        int opcao = gerador.PedirInput("Selecione uma opção: ");
        bool opcaoSair = false;
        string opcaoEscolhida = gerador.PegarOpcaoEscolhida(opcao, menuInicio).ToLower();
        switch (opcaoEscolhida)
        {
            case "clientes":
                ClientesFunction();
                break;
            case "fornecedores":
                break;
            case "serviços":
                break;
            case "compras":
                break;
            case "pagamentos":
                break;
            case "sair":
                opcaoSair = true;
                break;
            default:
                Console.WriteLine("Opção inválida.");
                Console.ReadKey();
                break;
        }

        if (opcaoSair)
        {
            break;
        }
    }
}

void ClientesFunction()
{
    while (true)
    {
        gerador.LimparTela();
        gerador.GerarMenu("Início > Clientes", menuCliente, true);
        int opcao = gerador.PedirInput("Selecione uma opção: ");
        bool opcaoSair = false;

        switch (gerador.PegarOpcaoEscolhida(opcao, menuCliente).ToLower())
        {
            case "visualizar":
                Console.WriteLine("visualizar");
                break;
            case "cadastrar":
                Console.WriteLine("cadastrar");
                break;
            case "atualizar":
                Console.WriteLine("atualizar");
                break;
            case "excluir":
                Console.WriteLine("excluir");
                break;
            case "sair":
                opcaoSair = true;
                break;
            default:
                Console.WriteLine("Opção inválida.");
                Console.ReadKey();
                break;
        }

        if (opcaoSair)
        {
            break;
        }
    }
}

void FornecedoresFunction() { }
void ServicosFunction() { }
void ComprasFunction() { }
void PagamentosFunction() { }

