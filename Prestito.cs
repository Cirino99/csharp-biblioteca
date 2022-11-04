// See https://aka.ms/new-console-template for more information

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
