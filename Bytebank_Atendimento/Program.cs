using bytebank.Modelos.Conta;
using Bytebank_Atendimento.bytebank.Atendimento;
using Bytebank_Atendimento.bytebank.Exceptions;
using Bytebank_Atendimento.bytebank.Util;

Console.WriteLine("Boas vindas ao ByteBank!");

new ByteBankAtendimento().AtendimentoCliente();

#region Exemplos Aula
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
    //listaDeContas.ExibeLista();
    //Console.WriteLine("Agora irá remover a conta!");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("Conta removida!");

    for (int i =0; i < listaDeContas.Tamanho; i++) {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indíce[{i}] = Conta/Agência: {conta.Conta}/{conta.Numero_agencia}");
    }
}

//TestaArrayDeContasCorrentes();
#endregion


#region Exemplos métodos List

//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>() {
//    new ContaCorrente(95, "123456-A"){Saldo = 100},
//    new ContaCorrente(95, "951258-B"){Saldo = 200},
//    new ContaCorrente(94, "987321-C"){Saldo = 60}
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>() {
//    new ContaCorrente(95, "123456-D"){Saldo = 100},
//    new ContaCorrente(95, "951258-E"){Saldo = 200},
//    new ContaCorrente(94, "987321-F"){Saldo = 60}
//};

//// Metódos disponíveis da classe ArrayList (AddRange)
//_listaDeContas2.AddRange(_listaDeContas3);

//for (int i = 0; i < _listaDeContas2.Count; i++) {
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//// Utiliizando o método Range
//var range = _listaDeContas3.GetRange(0,1);

//for (int i = 0; i < range.Count; i++) {
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//// Metódo de inversão
//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++) {
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

////Método para limpar
//_listaDeContas3.Clear();

//for (int i = 0; i < _listaDeContas3.Count; i++) {
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas3[i].Conta}]");
//}

#endregion

