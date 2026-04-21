// TESTE
var cofre = new Cofre("Ana", "1234");
Console.WriteLine(cofre);

Console.WriteLine("\nTentando abrir com senha errada 3x:");
Console.WriteLine(cofre.Abrir("0000"));
Console.WriteLine(cofre.Abrir("0000"));
Console.WriteLine(cofre.Abrir("0000"));

Console.WriteLine("\nTentando abrir com senha certa (bloqueado):");
Console.WriteLine(cofre.Abrir("1234"));

Console.WriteLine("\nResetando bloqueio:");
Console.WriteLine(cofre.ResetarBloqueio());

Console.WriteLine("\nAbrindo com senha certa:");
Console.WriteLine(cofre.Abrir("1234"));

Console.WriteLine("\nTrocando senha:");
Console.WriteLine(cofre.AlterarSenha("1234", "9999"));

Console.WriteLine("\nFechando:");
Console.WriteLine(cofre.Fechar());
Console.WriteLine(cofre);

// CLASSE
class Cofre
{
    private readonly string _dono;
    private string _senha;
    private bool _estaAberto;
    private int _tentativasErradas;

    private const int MaxTentativas = 3;

    public Cofre(string dono, string senha)
    {
        _dono = dono;
        _senha = senha;
        _estaAberto = false;
        _tentativasErradas = 0;
    }

    public string Dono => _dono;
    public bool EstaAberto => _estaAberto;
    public int TentativasErradas => _tentativasErradas;
    public bool EstaBloqueado => _tentativasErradas >= MaxTentativas;

    public string Abrir(string senhaInformada)
    {
        if (EstaBloqueado)
            return "Cofre bloqueado! Número máximo de tentativas atingido.";

        if (senhaInformada == _senha)
        {
            _estaAberto = true;
            _tentativasErradas = 0;
            return "Cofre aberto com sucesso.";
        }

        _tentativasErradas++;
        if (EstaBloqueado)
            return "Senha incorreta. Cofre bloqueado após 3 tentativas!";

        return $"Senha incorreta. Tentativas restantes: {MaxTentativas - _tentativasErradas}.";
    }

    public string Fechar()
    {
        if (!_estaAberto)
            return "O cofre já está fechado.";

        _estaAberto = false;
        return "Cofre fechado.";
    }

    public string AlterarSenha(string senhaAntiga, string novaSenha)
    {
        if (!_estaAberto)
            return "O cofre precisa estar aberto para trocar a senha.";
        if (senhaAntiga != _senha)
            return "Senha antiga incorreta.";
        if (string.IsNullOrWhiteSpace(novaSenha))
            return "A nova senha não pode ser vazia.";

        _senha = novaSenha;
        return "Senha alterada com sucesso.";
    }

    public string ResetarBloqueio()
    {
        _tentativasErradas = 0;
        return "Bloqueio removido. Tentativas zeradas.";
    }

    public override string ToString()
    {
        string estado = _estaAberto ? "Aberto" : "Fechado";
        return $"Cofre de {_dono} - {estado} - Tentativas erradas: {_tentativasErradas}/{MaxTentativas}";
    }
}