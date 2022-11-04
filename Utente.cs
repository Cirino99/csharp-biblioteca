// See https://aka.ms/new-console-template for more information

public class Utente
{
    public string Nome { get; private set; }
    public string Cognome { get; private set; }
    public string Email { get; set; }
    public int Telefono { get; set; }
    public List<Prestito> prestiti;

    public Utente(string nome, string cognome)
    {
        Nome = nome;
        Cognome = cognome;
        prestiti = new List<Prestito>();
    }
}
