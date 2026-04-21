// TESTE
var conta = new ContaCorrente("001-7", "Carlos");
Console.WriteLine("Estado inicial:");
Console.WriteLine(conta);

Console.WriteLine("\nDepositando R$ 200:");
conta.Depositar(200);
Console.WriteLine(conta);

Console.WriteLine("\nSacando R$ 600 (usa limite):");
conta.Sacar(600);
Console.WriteLine(conta);

Console.WriteLine("\nTentando sacar R$ 200 (sem saldo):");
conta.Sacar(200);

Console.WriteLine("\nStatus da conta:");
Console.WriteLine($"Status: {conta.StatusConta} | Saldo Total: R$ {conta.SaldoTotal:F2}");

Console.WriteLine("\nAlterando titular:");
conta.Titular = "Carlos Silva";
Console.WriteLine(conta);

// CLASSE
class ContaCorrente
{
    private readonly string _numero;
    private string _titular;
    private double _saldo;
    private double _limite;

    public ContaCorrente(string numero, string titular)
    {
        _numero = numero;
        _titular = titular;
        _saldo = 0;
        _limite = 500;
    }

    public string Numero => _numero;
    public string Titular { get => _titular; set => _titular = value; }
    public double Saldo => _saldo;
    public double Limite => _limite;

    public double SaldoTotal => _saldo + _limite;
    public string StatusConta => _saldo < 0 ? "Negativo" : "Positivo";

    public bool Depositar(double valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo.");
            return false;
        }
        _saldo += valor;
        return true;
    }

    public bool Sacar(double valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo.");
            return false;
        }
        if (valor > SaldoTotal)
        {
            Console.WriteLine($"Saldo insuficiente. Saldo total disponível: R$ {SaldoTotal:F2}");
            return false;
        }
        _saldo -= valor;
        return true;
    }

    public override string ToString()
    {
        return $"Conta: {_numero} | Titular: {_titular} | Saldo: R$ {_saldo:F2} | Limite: R$ {_limite:F2}";
    }
}