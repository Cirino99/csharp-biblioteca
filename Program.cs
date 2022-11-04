// See https://aka.ms/new-console-template for more information

using System.Net;

public class Biblioteca
{
    public List<Documento> documenti;
    public List<Utente> utenti;

    public Biblioteca()
    {
        string[] nomi = { "Mario", "Luigi", "Simone", "Luca" };
        string[] cognomi = { "Rossi", "Verdi", "Cirino", "Bianchi" };
        documenti = new List<Documento>();
        utenti = new List<Utente>();
        for (int i=0; i<20; i++)
        {
            documenti.Add(new Libro());
            documenti.Add(new Dvd());
        }
        for (int i=0; i<5; i++)
        {
            utenti.Add(new Utente(nomi[i], cognomi[i]));
        }
    }

    public void Registrazione(string nome, string cognome)
    {
        utenti.Add(new Utente(nome, cognome));
    }

    public string RicercaDocumento(string dato)
    {
        foreach(Documento documento in documenti)
        {
            if (documento.Codice == dato || documento.Titolo == dato)
            {
                return documento.ToString();
            }
        }
        return "La ricerca non ha dato risultati";
    }

    public void prestito(string dato, string nome, string cognome)
    {
        bool prestito = false;
        foreach (Utente utente in utenti)
        {
            if (utente.Nome == nome && utente.Cognome == cognome)
            {
                foreach (Documento documento in documenti)
                {
                    if (documento.ToString() == dato && documento.Disponibile)
                    {
                        Console.WriteLine("Quando vuoi iniziare il prestito?");
                        string inizio = Console.ReadLine();
                        Console.WriteLine("Quando vuoi finire il prestito?");
                        string fine = Console.ReadLine();
                        utente.prestiti.Add(new Prestito(documento.Codice,inizio,fine));
                        documento.Disponibile = false;
                        Console.WriteLine("Il prestito è andato a buon fine");
                        prestito = true;
                        break;
                    }
                }
            }
            if (prestito)
                break;
        }
        if (!prestito)
            Console.WriteLine("Il documeto desiderato non è al momento disponibile");
    }
}

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

    public Prestito(string codice, string inizio, string fine)
    {
        Codice = codice;
        Inizio = inizio;
        Fine = fine;
    }
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

    public override string ToString()
    {
        return "Codice: " + Codice + ", Titolo: " + Titolo;
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

    public override string ToString()
    {
        return "ISBN: " + Codice + ", Titolo: " + Titolo;
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

    public override string ToString()
    {
        return "Numero Seriale: " + Codice + ", Titolo: " + Titolo;
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