// See https://aka.ms/new-console-template for more information

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
