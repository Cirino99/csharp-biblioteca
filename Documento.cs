// See https://aka.ms/new-console-template for more information

public class Documento
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public bool Disponibile { get; set; }
    public string Scaffale { get; set; }
    public Autore autore;

    public Documento()
    {
        Titolo = "Mario" + new Random().Next(1, 10).ToString();
        autore = new Autore("Alberto", "Rossi");
        Disponibile = true;
    }

    public override string ToString()
    {
        return "Codice: " + Codice + ", Titolo: " + Titolo;
    }
}
