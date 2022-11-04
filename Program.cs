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
