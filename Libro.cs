// See https://aka.ms/new-console-template for more information

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
