// TESTE
var heroi = new Personagem("Arthas", "Guerreiro");
Console.WriteLine("Estado inicial:");
Console.WriteLine(heroi);

Console.WriteLine("\nRecebendo 80 de dano:");
heroi.ReceberDano(80);
Console.WriteLine(heroi);

Console.WriteLine("\nCurando 30 de vida:");
heroi.Curar(30);
Console.WriteLine(heroi);

Console.WriteLine("\nSubindo de nível:");
heroi.SubirNivel();
Console.WriteLine(heroi);

Console.WriteLine("\nRecebendo dano fatal:");
heroi.ReceberDano(999);
Console.WriteLine(heroi);

Console.WriteLine("\nTentando curar (morto):");
heroi.Curar(50);

Console.WriteLine("\nTentando subir nível (morto):");
heroi.SubirNivel();

Console.WriteLine("\nRessuscitando:");
heroi.Ressuscitar();
Console.WriteLine(heroi);

// CLASSE
class Personagem
{
    private readonly string _nome;
    private readonly string _classe;
    private int _nivel;
    private int _vidaAtual;
    private int _vidaMaxima;

    public Personagem(string nome, string classe)
    {
        _nome = nome;
        _classe = classe;
        _nivel = 1;
        _vidaMaxima = classe == "Guerreiro" ? 150 : 80;
        _vidaAtual = _vidaMaxima;
    }

    public string Nome => _nome;
    public string Classe => _classe;
    public int Nivel => _nivel;
    public int VidaAtual => _vidaAtual;
    public int VidaMaxima => _vidaMaxima;
    public bool EstaMorto => _vidaAtual <= 0;

    public void ReceberDano(int pontos)
    {
        if (pontos <= 0) return;
        _vidaAtual = Math.Max(0, _vidaAtual - pontos);
    }

    public void Curar(int pontos)
    {
        if (EstaMorto)
        {
            Console.WriteLine($"{_nome} está morto e não pode ser curado.");
            return;
        }
        if (pontos <= 0) return;
        _vidaAtual = Math.Min(_vidaMaxima, _vidaAtual + pontos);
    }

    public void SubirNivel()
    {
        if (EstaMorto)
        {
            Console.WriteLine($"{_nome} está morto e não pode subir de nível.");
            return;
        }
        if (_nivel >= 99)
        {
            Console.WriteLine($"{_nome} já está no nível máximo.");
            return;
        }
        _nivel++;
        _vidaMaxima = (int)(_vidaMaxima * 1.10);
        _vidaAtual = _vidaMaxima;
    }

    public void Ressuscitar()
    {
        if (!EstaMorto)
        {
            Console.WriteLine($"{_nome} já está vivo.");
            return;
        }
        _vidaAtual = _vidaMaxima;
    }

    public override string ToString()
    {
        string status = EstaMorto ? " [MORTO]" : "";
        return $"{_nome} ({_classe}) - Lvl {_nivel} - HP: {_vidaAtual}/{_vidaMaxima}{status}";
    }
}