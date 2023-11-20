using bytebank.Modelos.Conta;
using Bytebank_Atendimento.bytebank.Exceptions;

namespace Bytebank_Atendimento.bytebank.Atendimento {
#nullable disable
    internal class ByteBankAtendimento {
       
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>() {
        new ContaCorrente(95, "123456-X"){Saldo = 100, Titular = new Cliente{Cpf="111111", Nome="José" }},
        new ContaCorrente(95, "951258-X"){Saldo = 200, Titular = new Cliente{Cpf="222222", Nome="Carlos" }},
        new ContaCorrente(94, "987321-W"){Saldo = 60, Titular = new Cliente{Cpf="333333", Nome="Maria" }}
};

        public void AtendimentoCliente() {
            try {
                char opcao = '0';
                while (opcao != '6') {
                    Console.Clear();
                    Console.WriteLine("===================================");
                    Console.WriteLine("===          Atendimento        ===");
                    Console.WriteLine("=== 1 -     Cadastrar Conta     ===");
                    Console.WriteLine("=== 2 -     Listar Contas       ===");
                    Console.WriteLine("=== 3 -     Remover Conta       ===");
                    Console.WriteLine("=== 4 -     Ordenar Contas      ===");
                    Console.WriteLine("=== 5 -     Pesquisar Conta     ===");
                    Console.WriteLine("=== 6 -     Sair do Sistema     ===");
                    Console.WriteLine("===================================");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Digite a opção desejada: ");
                    try {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao) {

                        throw new ByteBankException(excecao.Message);
                    }

                    switch (opcao) {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            EncerrarSistema();
                            break;
                        default:
                            Console.WriteLine("Opção não implementada.");
                            break;
                    }
                }
            }
            catch (ByteBankException excecao) {
                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void EncerrarSistema() {
            Console.WriteLine(" ... Encerrando o sistema! ...");
            Console.ReadKey();
        }

        private void PesquisarContas() {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("===       Pesquisar Contas      ===");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");
            Console.WriteLine("Deseja pesquisar por (1) Nº da Conta ou (2) CPF do Titular ou (3) Nº Da Agência: ");
            switch (int.Parse(Console.ReadLine())) {
                case 1: {
                        Console.WriteLine("Informe o número da conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString);
                        Console.ReadKey();
                        break;
                    }
                case 2: {
                        Console.WriteLine("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString);
                        Console.ReadKey();
                        break;
                    }
                case 3: {
                        Console.WriteLine("Informe o Número da Agência: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                        ExibeListaContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada!");
                    break;
            }
        }

        private void ExibeListaContas(List<ContaCorrente> contasPorAgencia) {
            if (contasPorAgencia == null) {
                Console.WriteLine(" ... A consulta não retornou dados! ...");
            }
            else {
                foreach (var item in contasPorAgencia) {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia) {
            var consulta = (from conta in _listaDeContas
                            where conta.Numero_agencia == numeroAgencia
                            select conta).ToList();

            return consulta;
        }

        ContaCorrente ConsultaPorCPFTitular(string? cpf) {

            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++) {
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf)) {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();

        }

        ContaCorrente ConsultaPorNumeroConta(string? numeroConta) {

            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++) {
            //    if (_listaDeContas[i].Conta.Equals(numeroConta)) {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            //Usando um metodo link para recuparar dados
            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();

        }

        private void OrdenarContas() {
            //Método de ordenação
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenadas! ...");
            Console.ReadKey();
        }

        private void RemoverContas() {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("===       Remover Contas        ===");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");

            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;

            foreach (var item in _listaDeContas) {
                if (item.Conta.Equals(numeroConta)) {
                    conta = item;
                }
            }
            if (conta != null) {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else {
                Console.WriteLine("... Conta não encontrada para remoção! ...");
            }
            Console.ReadKey();
        }

        private void ListarContas() {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("===       Lista de Contas       ===");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0) {
                Console.WriteLine("... Não há contas cadastradas! ... ");
                Console.ReadKey();
                return;
            }

            foreach (ContaCorrente item in _listaDeContas) {
                //Console.WriteLine("===       Dados da Conta     ====");
                //Console.WriteLine("Número da Conta: " + item.Conta);
                //Console.WriteLine("Saldo da Conta: " + item.Saldo);
                //Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                //Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                Console.WriteLine(item.ToString());
                Console.WriteLine("--------------------------------------------------");
                Console.ReadKey();
            }

        }

        private void CadastrarConta() {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("===     Cadastro de Contas      ===");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");
            Console.WriteLine("===  Informe os dados da conta  ===");

            //Console.WriteLine("Número da conta: ");
            //string numeroConta = Console.ReadLine();

            Console.WriteLine("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

            Console.WriteLine("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.WriteLine("Informe o CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.WriteLine("Informe a profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);

            Console.WriteLine(".... Conta cadastrada com sucesso!!");
            Console.ReadKey();
        }
    }
}
