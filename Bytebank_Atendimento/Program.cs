using bytebank.Modelos.Conta;
using Bytebank_Atendimento.bytebank.Util;

void TestaArrayDeContasCorrentes()
{
    ListaDeContaCorrente listaDeContas = new ListaDeContaCorrente();

    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));

    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-D"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-E"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-F"));

    var contaDoAndre = new ContaCorrente(963, "123456-X");
    listaDeContas.Adicionar(contaDoAndre);
    listaDeContas.ExibeLista();
    Console.WriteLine("Agora irá remover a conta!");
    listaDeContas.Remover(contaDoAndre);
    listaDeContas.ExibeLista();
    Console.WriteLine("Conta removida!");
}

TestaArrayDeContasCorrentes();