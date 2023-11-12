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

List<string> menuPagamentos = new List<string>();
menuPagamentos.Add("Visualizar pagamentos enviados a fornecedor");

GeradorMenu gerador = new GeradorMenu();
BancoDados bancoDados = new BancoDados(true);
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
                FornecedoresFunction();
                break;
            case "serviços":
                ServicosFunction();
                break;
            case "compras":
                ComprasFunction();
                break;
            case "pagamentos":
                PagamentosFunction();
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
        Console.WriteLine();

        foreach (Cliente cliente in bancoDados.Clientes)
        {
            if (cliente.Deletado) continue;

            Console.WriteLine(cliente.Nome + "\n└- " + cliente.Email);
            Console.WriteLine();
        }
    }

    void ClientePost()
    {
        List<string> perguntas = new List<string>();
        perguntas.Add("Nome: ");
        perguntas.Add("E-mail: ");

        gerador.LimparTela();
        List<string> respostas = gerador.FazerPerguntas(perguntas);
        Cliente cliente = new Cliente(respostas[0].Trim(), respostas[1].Trim());
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
            if (cliente.Deletado) continue;

            if (cliente.Nome.ToLower() == respostas[0].Trim().ToLower())
            {
                achado = true;
                cliente.setNome(respostas[1].Trim());
                cliente.setEmail(respostas[2].Trim());
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

        int index = bancoDados.Clientes.FindIndex(c => !c.Deletado && c.Nome.ToLower() == respostas[0].Trim().ToLower());
        if (index > -1)
        {
            bancoDados.Clientes[index].setDeletado(true);
            Console.WriteLine("Cliente apagado com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado!");
        }
    }
}

void FornecedoresFunction()
{
    while (true)
    {
        gerador.LimparTela();
        gerador.GerarMenu("Início > Fornecedores", menuFornecedor, true);
        int opcao = gerador.PedirInput("Selecione uma opção: ");
        bool opcaoSair = false;
        string opcaoEscolhida = gerador.PegarOpcaoEscolhida(opcao, menuFornecedor).ToLower();

        switch (opcaoEscolhida)
        {
            case "visualizar":
                FornecedorGet();
                Console.ReadKey();
                break;
            case "cadastrar":
                FornecedorPost();
                Console.ReadKey();
                break;
            case "atualizar":
                FornecedorPut();
                Console.ReadKey();
                break;
            case "excluir":
                FornecedorDelete();
                Console.ReadKey();
                break;
            case "associar a serviço":
                FornecedorAssociarServico();
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

    void FornecedorGet()
    {
        gerador.LimparTela();

        Console.WriteLine("FORNECEDORES CADASTRADOS");
        Console.WriteLine();

        foreach (Fornecedor fornecedor in bancoDados.Fornecedores)
        {
            if (fornecedor.Deletado) continue;

            string saida = "";
            saida += fornecedor.Nome;

            if (fornecedor.Servicos.Count > 0)
            {
                saida += "\n└- ";
            }

            foreach (Servico servico in fornecedor.Servicos)
            {
                saida += servico.Nome;

                int index = fornecedor.Servicos.FindIndex(s => s.Nome == servico.Nome);
                if (index != fornecedor.Servicos.Count - 1)
                    saida += ", ";
            }

            Console.WriteLine(saida);
            Console.WriteLine();
        }
    }

    void FornecedorPost()
    {
        List<string> perguntas = new List<string>();
        perguntas.Add("Nome: ");

        gerador.LimparTela();
        List<string> respostas = gerador.FazerPerguntas(perguntas);
        Fornecedor fornecedor = new Fornecedor(respostas[0].Trim());
        bancoDados.Fornecedores.Add(fornecedor);

        Console.WriteLine();

        Console.WriteLine("Fornecedor adicionado com sucesso!");
    }

    void FornecedorPut()
    {
        FornecedorGet();

        Console.WriteLine();

        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do fornecedor a mudar: ");
        perguntas.Add("Novo nome: ");

        List<string> respostas = gerador.FazerPerguntas(perguntas);

        bool achado = false;
        foreach (Fornecedor fornecedor in bancoDados.Fornecedores)
        {
            if (fornecedor.Nome.ToLower() == respostas[0].Trim().ToLower())
            {
                achado = true;
                fornecedor.setNome(respostas[1].Trim());
                break;
            }
        }

        Console.WriteLine();

        if (!achado) Console.WriteLine("Fornecedor não encontrado!");
        else Console.WriteLine("Fornecedor alterado com sucesso!");
    }

    void FornecedorDelete()
    {
        FornecedorGet();

        Console.WriteLine();

        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do fornecedor a deletar: ");

        List<string> respostas = gerador.FazerPerguntas(perguntas);

        int index = bancoDados.Fornecedores.FindIndex(f => f.Nome.ToLower() == respostas[0].ToLower());
        if (index > -1)
        {
            bancoDados.Fornecedores[index].setDeletado(true);
            Console.WriteLine("Fornecedor apagado com sucesso!");
        }
        else
        {
            Console.WriteLine("Fornecedor não encontrado!");
        }
    }

    void FornecedorAssociarServico()
    {
        FornecedorGet();

        Console.WriteLine();

        Console.WriteLine("SERVICOS CADASTRADOS");
        Console.WriteLine();
        foreach (Servico servico in bancoDados.Servicos)
        {
            if (servico.Deletado) continue;

            Console.WriteLine(servico.Nome);
        }

        Console.WriteLine();

        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do fornecedor: ");
        perguntas.Add("Nome do serviço: ");

        List<string> respostas = gerador.FazerPerguntas(perguntas);

        int indexFornecedor = bancoDados.Fornecedores.FindIndex(f => !f.Deletado && f.Nome.ToLower() == respostas[0].ToLower());
        int indexServico = bancoDados.Servicos.FindIndex(s => !s.Deletado && s.Nome.ToLower() == respostas[1].ToLower());

        if (indexFornecedor < 0)
            Console.WriteLine("Fornecedor não encontrado!");

        if (indexServico < 0)
            Console.WriteLine("Serviço não encontrado!");

        if (indexFornecedor >= 0 && indexServico >= 0)
        {
            bancoDados.Fornecedores[indexFornecedor].AssociarServico(bancoDados.Servicos[indexServico]);
            Console.WriteLine("Associado serviço ao fornecedor com sucesso!");
        }
    }
}

void ServicosFunction()
{
    while (true)
    {
        gerador.LimparTela();
        gerador.GerarMenu("Início > Serviços", menuServico, true);
        int opcao = gerador.PedirInput("Selecione uma opção: ");
        bool opcaoSair = false;
        string opcaoEscolhida = gerador.PegarOpcaoEscolhida(opcao, menuServico).ToLower();

        switch (opcaoEscolhida)
        {
            case "visualizar":
                ServicoGet();
                Console.ReadKey();
                break;
            case "cadastrar":
                ServicoPost();
                Console.ReadKey();
                break;
            case "atualizar":
                ServicoPut();
                Console.ReadKey();
                break;
            case "excluir":
                ServicoDelete();
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

    void ServicoGet()
    {
        gerador.LimparTela();

        Console.WriteLine("SERVICOS CADASTRADOS");
        Console.WriteLine();
        foreach (Servico servico in bancoDados.Servicos)
        {
            if (servico.Deletado) continue;

            Console.WriteLine("Nome: " + servico.Nome);
            Console.WriteLine("Modalidade de pagamento: " + servico.ModalidadePagamento);
            Console.WriteLine("Valor: " + servico.Valor);
            Console.WriteLine();
        }
    }

    void ServicoPost()
    {
        List<string> perguntas = new List<string>();
        perguntas.Add("Nome: ");
        perguntas.Add("Modalidade de pagamento: ");
        perguntas.Add("Valor (apenas numeros): ");

        List<string> respostas = new List<string>();
        while (true)
        {
            gerador.LimparTela();
            respostas = gerador.FazerPerguntas(perguntas);

            if (!double.TryParse(respostas[2].Trim(), out _)) {
                Console.WriteLine("Valor inválido.");
                Console.ReadKey();
            }
            else
            {
                break;
            }
        }

        Servico servico = new Servico(respostas[0].Trim(), respostas[1].Trim(), double.Parse(respostas[2].Trim()));
        bancoDados.Servicos.Add(servico);

        Console.WriteLine();

        Console.WriteLine("Serviço adicionado com sucesso!");
    }

    void ServicoPut()
    {
        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do serviço a mudar: ");
        perguntas.Add("Novo nome: ");
        perguntas.Add("Nova modalidade de pagamento: ");
        perguntas.Add("Novo valor (apenas numeros): ");

        List<string> respostas = new List<string>();
        while (true)
        {
            gerador.LimparTela();

            ServicoGet();
            Console.WriteLine();

            respostas = gerador.FazerPerguntas(perguntas);

            if (!double.TryParse(respostas[3].Trim(), out _))
            {
                Console.WriteLine("Valor inválido.");
                Console.ReadKey();
            }
            else
            {
                break;
            }

        }

        bool achado = false;
        foreach (Servico servico in bancoDados.Servicos)
        {
            if (servico.Nome.ToLower() == respostas[0].Trim().ToLower())
            {
                achado = true;
                servico.setNome(respostas[1].Trim());
                servico.setModalidadePagamento(respostas[2].Trim());
                servico.setValor(double.Parse(respostas[3].Trim()));
                break;
            }
        }

        Console.WriteLine();

        if (!achado) Console.WriteLine("Serviço não encontrado!");
        else Console.WriteLine("Serviço alterado com sucesso!");
    }

    void ServicoDelete()
    {
        ServicoGet();

        Console.WriteLine();

        List<string> perguntas = new List<string>();
        perguntas.Add("Nome do serviço a deletar: ");

        List<string> respostas = gerador.FazerPerguntas(perguntas);

        int index = bancoDados.Servicos.FindIndex(s => !s.Deletado && s.Nome.ToLower() == respostas[0].Trim().ToLower());
        if (index > -1)
        {
            foreach (Fornecedor fornecedor in bancoDados.Fornecedores)
            {
                int indexServicoInFornecedor = fornecedor.Servicos.FindIndex(s => !s.Deletado && s.Nome.ToLower() == respostas[0].Trim().ToLower());
                if (indexServicoInFornecedor > -1)
                {
                    fornecedor.Servicos.RemoveAt(indexServicoInFornecedor);
                    Console.WriteLine("Serviço " + respostas[0].Trim() + " desassociado do fornecedor " + fornecedor.Nome);
                }
            }
            bancoDados.Servicos[index].setDeletado(true);
            Console.WriteLine("Serviço apagado com sucesso!");
        }
        else
        {
            Console.WriteLine("Serviço não encontrado!");
        }
    }
}

void ComprasFunction()
{
    while (true)
    {
        gerador.LimparTela();
        gerador.GerarMenu("Início > Compras", menuTransacao, true);
        int opcao = gerador.PedirInput("Selecione uma opção: ");
        bool opcaoSair = false;
        string opcaoEscolhida = gerador.PegarOpcaoEscolhida(opcao, menuTransacao).ToLower();

        switch (opcaoEscolhida)
        {
            case "visualizar":
                CompraGet();
                Console.ReadKey();
                break;
            case "cadastrar":
                CompraPost();
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

    void CompraGet()
    {
        gerador.LimparTela();

        Console.WriteLine("COMPRAS CADASTRADAS");
        Console.WriteLine();
        foreach (Transacao transacao in bancoDados.Transacoes)
        {
            Console.WriteLine("Fornecedor: " + transacao.Fornecedor.Nome);
            Console.WriteLine("Cliente: " + transacao.Comprador.Nome);
            Console.WriteLine("Valor: " + transacao.GerarValorCobrado());
            Console.WriteLine();
        }
    }

    void CompraPost()
    {
        List<string> perguntasFornecedor = new List<string>();
        List<string> perguntasCliente = new List<string>();
        List<string> perguntasServicos = new List<string>();
        perguntasFornecedor.Add("Nome do fornecedor: ");
        perguntasCliente.Add("Nome do Cliente: ");
        perguntasServicos.Add("Serviços a comprar (separe múltiplos com \"/\"): ");
        Fornecedor fornecedorSelecionado;
        Cliente clienteSelecionado;
        List<Servico> servicosSelecionados = new List<Servico>();

        List<string> respostas = new List<string>();

        // Input de fornecedor com validacao
        while (true)
        {
            gerador.LimparTela();

            Console.WriteLine("FORNECEDORES CADASTRADOS");
            Console.WriteLine();

            foreach (Fornecedor fornecedor in bancoDados.Fornecedores)
            {
                if (fornecedor.Deletado) continue;

                string saida = "";
                saida += fornecedor.Nome;

                if (fornecedor.Servicos.Count > 0)
                {
                    saida += "\n└- ";
                }

                foreach (Servico servico in fornecedor.Servicos)
                {
                    saida += servico.Nome;

                    int indexServico = fornecedor.Servicos.FindIndex(s => s.Nome == servico.Nome);
                    if (indexServico != fornecedor.Servicos.Count - 1)
                        saida += ", ";
                }

                Console.WriteLine(saida);
                Console.WriteLine();
            }

            respostas = gerador.FazerPerguntas(perguntasFornecedor);

            int indexFornecedor = bancoDados.Fornecedores.FindIndex(f => !f.Deletado && f.Nome.ToLower() == respostas[0].Trim().ToLower());
            if (indexFornecedor < 0)
            {
                Console.WriteLine("Fornecedor não encontrado!");
                Console.ReadKey();
            }
            else
            {
                fornecedorSelecionado = bancoDados.Fornecedores[indexFornecedor];
                break;
            }
        }

        // Input de cliente com validacao
        while (true)
        {
            gerador.LimparTela();

            Console.WriteLine("CLIENTES CADASTRADOS");
            Console.WriteLine();

            foreach (Cliente cliente in bancoDados.Clientes)
            {
                if (cliente.Deletado) continue;

                Console.WriteLine(cliente.Nome + "\n└- " + cliente.Email);
            }

            Console.WriteLine();

            respostas = gerador.FazerPerguntas(perguntasCliente);
            int indexCliente = bancoDados.Clientes.FindIndex(c => !c.Deletado && c.Nome.ToLower() == respostas[0].Trim().ToLower());
            if (indexCliente < 0)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.ReadKey();
            }
            else
            {
                clienteSelecionado = bancoDados.Clientes[indexCliente];
                break;
            }
        }

        // Input de servico com validacao
        while (true)
        {
            gerador.LimparTela();

            Console.WriteLine("SERVICOS DESTE FORNECEDOR");
            foreach (Servico servico in fornecedorSelecionado.Servicos)
            {
                Console.WriteLine(servico.Nome);
            }

            Console.WriteLine();

            respostas = gerador.FazerPerguntas(perguntasServicos);

            foreach (string servicoNome in respostas[0].Trim().Split("/"))
            {
                int indexServico = fornecedorSelecionado.Servicos.FindIndex(s => !s.Deletado && s.Nome.ToLower() == servicoNome.Trim().ToLower());
                if (indexServico >= 0)
                {
                    servicosSelecionados.Add(fornecedorSelecionado.Servicos[indexServico]);
                }
            }

            if (servicosSelecionados.Count != respostas[0].Trim().Split("/").Length)
            {
                Console.WriteLine("Alguns serviços não foram encontrados!");
                Console.ReadKey();
                servicosSelecionados.Clear();
            }
            else
            {
                break;
            }
        }

        Transacao transacao = new Transacao(clienteSelecionado, servicosSelecionados, fornecedorSelecionado);
        bancoDados.Transacoes.Add(transacao);

        InformacoesPagamento informacoesPagamento = new InformacoesPagamento(DateTime.Now.AddMonths(1), transacao, fornecedorSelecionado);
        bancoDados.InformacoesPagamentos.Add(informacoesPagamento);

        Console.WriteLine();

        Console.WriteLine("Compra adicionada com sucesso!");
    }
}

void PagamentosFunction()
{
    while (true)
    {
        gerador.LimparTela();
        gerador.GerarMenu("Início > Pagamentos", menuPagamentos, true);
        int opcao = gerador.PedirInput("Selecione uma opção: ");
        bool opcaoSair = false;
        string opcaoEscolhida = gerador.PegarOpcaoEscolhida(opcao, menuPagamentos).ToLower();

        switch (opcaoEscolhida)
        {
            case "visualizar pagamentos enviados a fornecedor":
                PagamentoGet();
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

    void PagamentoGet()
    {
        gerador.LimparTela();

        Console.WriteLine("PAGAMENTOS AOS FORNECEDORES");

        Console.WriteLine();

        Console.WriteLine("Vencimento\tFornecedor\tValor cobrado");
        foreach (InformacoesPagamento informacoesPagamento in bancoDados.InformacoesPagamentos)
        {
            string date = informacoesPagamento.DataVencimento.ToShortDateString();
            Console.WriteLine(date + "\t" + informacoesPagamento.Fornecedor.Nome + "\t" + informacoesPagamento.ValorCobrado);
        }
    }
}

