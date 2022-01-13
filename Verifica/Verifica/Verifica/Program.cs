/* Autore: Giovanni Marchetto
 * Data: 13/01/2021
 * Classe: 4F
 * Consegna: Scrivere il codice in C# per creare la classe Treni con i seguenti attributi: codtreno, tipo
(regionale,nazionale,internazionale) ,nome e costo. La classe avrà 2 metodi che calcolano il costo del mezzo
utilizzato e il costo per il suo utilizzo (calcolato dal percorso effettuato). Dalla classe si vogliono derivare 2
differenti classi: Passeggeri e Merci che avranno 2 ulteriori attributi: numvagoni e alimentazione.
Dopo aver visualizzato i dati (assegnati nel main o letti in input) calcolare e visualizzare:
1) il costo dei 2 mezzi sapendo che il costo di un mezzo generico è 100.000€ mentre per il Passeggeri è
aumentato del 25% e per il Merci aumenta del 35%;
2) il costo per il suo utilizzo, dopo aver letto in input i km effettuati, sapendo che il prezzo al km per il
treno Merci è di 100€ mentre per il Passeggeri è 150€;
3) Il costo totale dei i due mezzi.

tempo di svolgimento 1h.


Link: https://github.com/gmarck04/Verifica
 */

using System;

namespace Verifica
{
    // Classe che crea un oggetto di tipo Treni, che possiede i metodi costoMezzo(), costoUtilizzo() e costoTotale().
    class Treni
    {
        //Attributi
        protected string codtreno, tipo, nome;
        protected double costoalMezzo;
        protected int costoperUtilizzo;

        /*Metodo costruttore, che chiede in ingresso codtreno, tipo, nome.
          Poi assegna il codtreno, tipo, nome in ingresso ai rispettivi attributi,
          mentre il costoalMezzo viene posto uguale a 100000 e costoperUtilizzo uguale a 0.*/
        public Treni(string codtreno, string tipo, string nome)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            costoalMezzo = 100000;
            costoperUtilizzo = 0;
        }

        //Metodo che calcola il costo del mezzo
        virtual public double costoMezzo()
        {
            return costoalMezzo;
        }

        //Metodo che calcola il costo per l'utilizzo
        virtual public int costoUtilizzo(int km)
        {
            return costoperUtilizzo;
        }

        //Metodo che calcola il costo totale, quindi la somma delle variabili costoalMezzo e il costoperUtilizzo
        public double costoTotale()
        {
            return costoalMezzo + costoperUtilizzo; 
        }
    }

    //Classe figlia della classe Treni, che riscrive i metodi della classe padre costoMezzo() e costoUtilizzo()
    class Passegeri : Treni
    {
        //Attributi
        string alimentazione;
        int numvagoni;

        /*Metodo costruttore, che chiede in ingresso codtreno, tipo, nome (dal padre), alimentazione e numvagoni.
          Poi assegna il codtreno, tipo, nome, alimentazione e numvagoni in ingresso ai rispettivi attributi,
          mentre il costoalMezzo viene posto uguale a 100000 e costoperUtilizzo uguale a 0 (per effetto del costruttore del padre).*/
        public Passegeri(string codtreno, string tipo, string nome, string alimentazione, int numvagoni) : base(codtreno, tipo, nome)
        {
            this.alimentazione = alimentazione;
            this.numvagoni = numvagoni;
        }

        //Metodo che calcola il costo del mezzo
        public override double costoMezzo()
        {
            costoalMezzo = costoalMezzo * 1.25;
            return costoalMezzo;
        }

        //Metodo che calcola il costo per l'utilizzo
        public override int costoUtilizzo(int km)
        {
            costoperUtilizzo = 150 * km;
            return costoperUtilizzo;
        }
    }

    //Classe figlia della classe Treni, che riscrive i metodi della classe padre costoMezzo() e costoUtilizzo()
    class Merci : Treni
    {
        //Attributi
        string alimentazione;
        int numvagoni;

        /*Metodo costruttore, che chiede in ingresso codtreno, tipo, nome (dal padre), alimentazione e numvagoni.
          Poi assegna il codtreno, tipo, nome, alimentazione e numvagoni in ingresso ai rispettivi attributi,
          mentre il costoalMezzo viene posto uguale a 100000 e costoperUtilizzo uguale a 0 (per effetto del costruttore del padre).*/
        public Merci(string codtreno, string tipo, string nome, string alimentazione, int numvagoni) : base(codtreno, tipo, nome)
        {
            this.alimentazione = alimentazione;
            this.numvagoni = numvagoni;
        }

        //Metodo che calcola il costo del mezzo
        public override double costoMezzo()
        {
            costoalMezzo = costoalMezzo * 1.35;
            return costoalMezzo;
        }

        //Metodo che calcola il costo per l'utilizzo
        public override int costoUtilizzo(int km)
        {
            costoperUtilizzo = 100 * km;
            return costoperUtilizzo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Passeggero();
            Merci();
        }

        //Funzione che serve per creare, immettendo i valori da console, un'istanza della classe Merci ed esegue tutti i metodi
        public static void Merci()
        {
            int numeroVagoni, numerokm;

            Console.WriteLine("Inserisci il codtreno");
            string codtreno = Console.ReadLine();

            Console.WriteLine("Inserisci il tipo, puoi inserire solo i tipi regionale,nazionale,internazionale.");
            string tipo = Console.ReadLine();
            while (tipo != "regionale" && tipo != "nazionale" && tipo != "internazionale")
            {
                Console.WriteLine("Errato. Inserisci il tipo, puoi inserire solo i tipi regionale,nazionale,internazionale.");
                tipo = Console.ReadLine();
            }

            Console.WriteLine("Inserisci il nome del treno");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci l'alimentazione del treno");
            string alimentazione = Console.ReadLine();

            Console.WriteLine("Inserisci il numero vagoni");
            bool controllo = int.TryParse(Console.ReadLine(), out numeroVagoni);
            while (controllo == false)//Controllo per verificare di aver inserito una variabile di tipo int
            {
                Console.WriteLine("Errato. Inserisci il numero vagoni");
                controllo = int.TryParse(Console.ReadLine(), out numeroVagoni);
            }

            Console.WriteLine("Inserisci il numero di km fatti");
            bool controllo_1 = int.TryParse(Console.ReadLine(), out numerokm);
            while (controllo_1 == false)//Controllo per verificare di aver inserito una variabile di tipo int
            {
                Console.WriteLine("Errato. Inserisci il numero di km fatti");
                controllo_1 = int.TryParse(Console.ReadLine(), out numerokm);
            }

            Passegeri passegeri = new Passegeri(codtreno, tipo, nome, alimentazione, numeroVagoni); //Creo un'istanza della classe Passeggeri, a cui invio delle variabli, il nome dell'istanza è passegari.

            Console.WriteLine(passegeri.costoMezzo());
            Console.WriteLine(passegeri.costoUtilizzo(numerokm));
            Console.WriteLine(passegeri.costoTotale());
        }

        //Funzione che serve per creare, immettendo i valori da console, un'istanza della classe Passeggeri ed esegue tutti i metodi
        public static void Passeggero()
        {
            int numeroVagoni, numerokm;

            Console.WriteLine("Inserisci il codtreno");
            string codtreno = Console.ReadLine();

            Console.WriteLine("Inserisci il tipo, puoi inserire solo i tipi regionale,nazionale,internazionale.");
            string tipo = Console.ReadLine();
            while (tipo != "regionale" && tipo != "nazionale" && tipo != "internazionale")
            {
                Console.WriteLine("Errato. Inserisci il tipo, puoi inserire solo i tipi regionale,nazionale,internazionale.");
                tipo = Console.ReadLine();
            }

            Console.WriteLine("Inserisci il nome del treno");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci l'alimentazione del treno");
            string alimentazione = Console.ReadLine();

            Console.WriteLine("Inserisci il numero vagoni");
            bool controllo = int.TryParse(Console.ReadLine(), out numeroVagoni);
            while (controllo == false)//Controllo per verificare di aver inserito una variabile di tipo int
            {
                Console.WriteLine("Errato. Inserisci il numero vagoni");
                controllo = int.TryParse(Console.ReadLine(), out numeroVagoni);
            }

            Console.WriteLine("Inserisci il numero di km fatti");
            bool controllo_1 = int.TryParse(Console.ReadLine(), out numerokm);
            while (controllo_1 == false)//Controllo per verificare di aver inserito una variabile di tipo int
            {
                Console.WriteLine("Errato. Inserisci il numero di km fatti");
                controllo_1 = int.TryParse(Console.ReadLine(), out numerokm);
            }

            Merci merci = new Merci(codtreno, tipo, nome, alimentazione, numeroVagoni); //Creo un'istanza della classe Merci, a cui invio delle variabli, il nome dell'istanza è merci.

            Console.WriteLine(merci.costoMezzo());
            Console.WriteLine(merci.costoUtilizzo(numerokm));
            Console.WriteLine(merci.costoTotale());
        }
    }
}
