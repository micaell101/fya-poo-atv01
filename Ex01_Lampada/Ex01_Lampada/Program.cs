// TESTE
var lamp = new Lampada("Philips", "LED");
Console.WriteLine(lamp);

lamp.AjustarBrilho(50);
lamp.Alternar();
lamp.AjustarBrilho(75);
lamp.Alternar();
lamp.Alternar();
Console.WriteLine(lamp);

// CLASSE
class Lampada
{
    private readonly string _marca;
    private readonly string _tecnologia;
    private bool _ligada;
    private int _brilho;

    public Lampada(string marca, string tecnologia)
    {
        _marca = marca;
        _tecnologia = tecnologia;
        _ligada = false;
        _brilho = 100;
    }

    public string Marca => _marca;
    public string Tecnologia => _tecnologia;
    public bool Ligada => _ligada;
    public int Brilho => _brilho;
    public int BrilhoEfetivo => _ligada ? _brilho : 0;

    public void Alternar()
    {
        _ligada = !_ligada;
    }

    public void AjustarBrilho(int novoBrilho)
    {
        if (!_ligada)
        {
            Console.WriteLine("Lâmpada desligada. Ligue antes de ajustar.");
            return;
        }
        if (novoBrilho < 0 || novoBrilho > 100)
        {
            Console.WriteLine("Brilho inválido. Use entre 0 e 100.");
            return;
        }
        _brilho = novoBrilho;
    }

    public override string ToString()
    {
        string estado = _ligada ? "Ligada" : "Desligada";
        return $"Lâmpada {_marca} ({_tecnologia}) - {estado} - Brilho: {_brilho}%";
    }
}