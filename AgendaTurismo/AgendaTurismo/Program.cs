using AgendaTurismo;

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

List<string> menuFornecedor = new List<string>();
menuFornecedor.Add("Visualizar");
menuFornecedor.Add("Cadastrar");
menuFornecedor.Add("Atualizar");
menuFornecedor.Add("Excluir");
menuFornecedor.Add("Associar a serviço");

List<string> menuServico = new List<string>();
menuServico.Add("Visualizar");
menuServico.Add("Cadastrar");
menuServico.Add("Atualizar");
menuServico.Add("Excluir");

List<string> menuTransacao = new List<string>();
menuTransacao.Add("Visualizar");
menuTransacao.Add("Cadastrar");
menuTransacao.Add("Atualizar");
menuTransacao.Add("Excluir");

List<string> menuPagamentos = new List<string>();
menuPagamentos.Add("Visualizar pagamentos enviados a fornecedor");

GeradorMenu gerador = new GeradorMenu();
BancoDados bancoDados = new BancoDados();
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
        string opcaoEscolhida = gerador.PegarOpcaoEscolhida(opcao, menuCliente).ToLower();

        switch (opcaoEscolhida)
        {
            case "visualizar":
                ClienteGet();
                Console.ReadKey();
                break;
            case "cadastrar":
                ClientePost();
                Console.ReadKey();
                break;
            case "atualizar":
                ClientePut();
                Console.ReadKey();
                break;
            case "excluir":
                ClienteDelete();
                Console.ReadKey();
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

    void ClienteGet()
    {
        gerador.LimparTela();

        Console.WriteLine("CLIENTES CADASTRADOS");
        Console.WriteLine("Nome\t\t\tE-mail");

        foreach (Cliente cliente in bancoDados.Clientes)
        {
            Console.WriteLine(cliente.Nome + "\t\t\t" + cliente.Email);
        }
    }

    void ClientePost()
    {
        List<string> perguntas = new List<string>();
        perguntas.Add("Nome: ");
        perguntas.Add("E-mail: ");

        gerador.LimparTela();
        List<string> respostas = gerador.FazerPerguntas(perguntas);
        Cliente cliente = new Cliente(respostas[0], respostas[1]);
        bancoDados.Clientes.Add(cliente);

        Console.WriteLine();

        Console.WriteLine("Cliente adicionado com sucesso!");
    }

    void ClientePut()
    {
        ClienteGet();

        Console.WriteLine();

        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do cliente a mudar: ");
        perguntas.Add("Novo nome: ");
        perguntas.Add("Novo e-mail: ");

        List<string> respostas = gerador.FazerPerguntas(perguntas);

        bool achado = false;
        foreach (Cliente cliente in bancoDados.Clientes)
        {
            if (cliente.Nome.ToLower() == respostas[0].ToLower())
            {
                achado = true;
                cliente.setNome(respostas[1]);
                cliente.setEmail(respostas[2]);
                break;
            }
        }

        Console.WriteLine();
        
        if (!achado) Console.WriteLine("Cliente não encontrado!");
        else Console.WriteLine("Cliente alterado com sucesso!");
    }

    void ClienteDelete()
    {
        ClienteGet();

        Console.WriteLine();

        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do cliente a deletar: ");

        List<string> respostas = gerador.FazerPerguntas(perguntas);

        int index = bancoDados.Clientes.FindIndex(c => c.Nome.ToLower() == respostas[0].ToLower());
        if (index > -1)
        {
            bancoDados.Clientes.RemoveAt(index);
            Console.WriteLine("Cliente apagado com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado!");
        }
    }
}

void FornecedoresFunction() { }
void ServicosFunction() { }
void ComprasFunction() { }
void PagamentosFunction() { }

