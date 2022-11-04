// See https://aka.ms/new-console-template for more information
Biblioteca biblioteca = new Biblioteca();
bool fine = false;
do
{
    Console.WriteLine("Scegli: ");
    Console.WriteLine("1 Registra nuovo utente");
    Console.WriteLine("2 Ricerca Libro");
    Console.WriteLine("3 Prestiti persona");
    Console.WriteLine("4 esci");
    int scelta = Convert.ToInt32(Console.ReadLine());
    string nome;
    string cognome;
    switch (scelta)
    {
        case 1:
            Console.WriteLine("Inserisci il nome");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            cognome = Console.ReadLine();
            biblioteca.Registrazione(nome,cognome);
            break;
        case 2:
            Console.WriteLine("Digita il codice o il titolo del documento ricercato");
            string dato = Console.ReadLine();
            string risultato = biblioteca.RicercaDocumento(dato);
            if(risultato != "La ricerca non ha dato risultati")
            {
                Console.WriteLine(risultato);
                Console.WriteLine("Vuoi prendere in prestito il documento? (Si/No)");
                string risposta = Console.ReadLine();
                if(risposta == "Si")
                {
                    Console.WriteLine("Inserisci il nome");
                    nome = Console.ReadLine();
                    Console.WriteLine("Inserisci il cognome");
                    cognome = Console.ReadLine();
                    biblioteca.NuovoPrestito(risultato, nome,cognome);
                }
            }
            else
                Console.WriteLine(dato);

            break;
        case 3:
            Console.WriteLine("Inserisci il nome");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            cognome = Console.ReadLine();
            biblioteca.ElencoPrestiti(nome, cognome);
            break;
        default:
            fine = true;
            break;
    }
    Console.WriteLine();
    Console.WriteLine();
} while (!fine);

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
        for (int i=0; i<4; i++)
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

    public void NuovoPrestito(string dato, string nome, string cognome)
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

    public void ElencoPrestiti(string nome, string cognome) {
        bool trovato = false;
        foreach (Utente utente in utenti)
        {
            if (utente.Nome == nome && utente.Cognome == cognome)
            {
                foreach(Prestito prestito in utente.prestiti)
                {
                    Console.WriteLine("Documento con codice: {0}, preso {1}, restituito {2}",prestito.Codice,prestito.Inizio,prestito.Fine);
                    trovato = true;
                }
                break;
            }
        }
        if (!trovato)
            Console.WriteLine("Utente non trovato o l'utente non ha effetuato prestiti");
    }
}
