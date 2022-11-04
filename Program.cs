// See https://aka.ms/new-console-template for more information

using System.Globalization;

public class Utente : Persona
{
    public string Email { get; set; }
    public int Telefono { get; set; }
    public List<Prestito> prestiti;

    public Utente(string nome, string cognome) : base(nome,cognome)
    {
        prestiti = new List<Prestito>();
    }
}

public class Prestito
{
    public string Codice { get; private set; }
    public string Inizio { get; private set; }
    public string Fine { get; private set; }
}

public class Documento
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public bool Disponibile { get; set; }
    public string Scaffale { get; set; }
    public Persona autore;

    public Documento()
    {
        Titolo = "Mario" + new Random().Next(1, 10).ToString();
        autore = new Persona("Alberto", "Rossi");
    }
}

public class Libro : Documento
{
    public int NumeroPagine { get; set; }
    public Libro() : base()
    {
        Codice = "LB" + new Random().Next(10000, 99999).ToString();
        NumeroPagine = new Random().Next(100, 600);
    }
}

public class Dvd : Documento
{
    public int Durata { get; set; } //espressa in minuti
    public Dvd() : base()
    {
        Codice = "DV" + new Random().Next(10000, 99999).ToString();
        Durata = new Random().Next(30, 120);
    }
}

public class Persona
{
    public string Nome { get; private set; }
    public string Cognome { get; private set; }

    public Persona(string nome, string cognome)
    {
        Nome = nome;
        Cognome = cognome;
    }
}