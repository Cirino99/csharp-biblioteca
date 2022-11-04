// See https://aka.ms/new-console-template for more information

public class Autore
{
    public string Nome { get; private set; }
    public string Cognome { get; private set; }

    public Autore(string nome, string cognome)
    {
        Nome = nome;
        Cognome = cognome;
    }
}