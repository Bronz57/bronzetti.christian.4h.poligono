using System;

namespace bronzetti.christian._4h.poligono
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma poligoni regolari, scritto Christian Bronzetti, 4H");

            int nLati, lato;
            string strNLati, strLato;



            while (true)
            {
                Console.WriteLine("Inserire il numero dei lati");
                strNLati = Console.ReadLine();
                bool andataBene = Int32.TryParse(strNLati, out nLati);
                if (andataBene)
                    if (nLati > 0)
                        break;
            };

            while (true)
            {
                Console.WriteLine("Inserire la lunghezza del lato");
                strLato = Console.ReadLine();
                bool andataBene = Int32.TryParse(strLato, out lato);
                if (andataBene)
                    if (lato > 0)
                        break;
            };

            Console.WriteLine("Scegliere cosa vuoi fare:\n- Inserire 1 per calcolare l'apotema\n- Inserire 2 per calolare il perimetro\n- Inserire 3 per calcolare l'area");
            string strScelta;
            int scelta;

            while (true)
            {
                strScelta = Console.ReadLine();
                bool andataBene = Int32.TryParse(strScelta, out scelta);
                if (andataBene)
                    if (scelta > 0 && scelta <5)
                        break;
            };

            Poligono pol1 = new Poligono(lato, nLati);
            //Poligono pol1 = new Poligono(nLati); //chiama un metodo che crea un poligono di nLati e lato 1
             //Poligono pol1 = new Poligono(); //chaimma un metodo che crea un poligono (quadrato 1x1) di lato 1 e nLati=1;
            switch(scelta)
            {
                case 1:
                    pol1.CalcolaApotema(pol1);
                    Console.WriteLine($"L'apotema del poligono è {Math.Round(pol1.apotema,3)}");
                    break;
                case 2:
                    pol1.CalcolaPerimetro(pol1);
                    Console.WriteLine($"Il perimetro del poligono è {pol1.perimetro}");
                    break;
                case 3:
                    pol1.CalcolaArea(pol1);
                    Console.WriteLine($"L'area del poligono è {Math.Round(pol1.area, 3)}");
                    break;
            }

            string nomeP = pol1.Stampa(pol1);
            Console.WriteLine($"Il nome del poligono è {nomeP}");
            Console.WriteLine("Inserire i dati di un nuovo poligono da confrontare");
            while (true)
            {
                Console.WriteLine("Inserire il numero dei lati");
                strNLati = Console.ReadLine();
                bool andataBene = Int32.TryParse(strNLati, out nLati);
                if (andataBene)
                    if (nLati > 0)
                        break;
            };

            while (true)
            {
                Console.WriteLine("Inserire la lunghezza del lato");
                strLato = Console.ReadLine();
                bool andataBene = Int32.TryParse(strLato, out lato);
                if (andataBene)
                    if (lato > 0)
                        break;
            };

            Poligono pol2 = new Poligono(lato, nLati);
            string confronto = pol1.Confronta(pol1, pol2);

            Console.WriteLine(confronto);
            



        }
    }

    class Poligono
    {
        public double lato;
        public double perimetro;
        public double apotema;
        public double area;
        public int nLati;
        private double nFisso;
        private string[] nomePoligono = new[] {"a","b", "c","Triangolo Equilatero", "Quadrato", "Pentagono", "Esagono","Ettagono","Ottagono","Ennagono","Decagono","Endecagono",
                                               "Dodecagono","Tridecagono","Tetradecagono","Pentadecagono","Esadecagono","Ennadecagono","Ottadecagnono","Ennadecagono","Icosagono"};
        

        public Poligono(double l, int nL)
        {
            lato = l;
            nLati = nL;
        }

        public Poligono()
        {
            lato = 1;
            nLati = 4;
        }
        public Poligono(int nL)
        {
            nLati = nL;
            lato = 1;
        }
        public void CalcolaArea(Poligono p1)
        {
            p1.CalcolaPerimetro(p1); //chiamo metodo che mi calcola il perimetro
            p1.CalcolaApotema(p1);
            area = p1.perimetro * p1.apotema / 2;
        }

        public void CalcolaPerimetro(Poligono p1)
        {
            perimetro = p1.lato * p1.nLati;
        }

        public void CalcolaApotema(Poligono p1)
        {
            p1.calcolaNumeroFisso(p1);
            apotema = p1.nFisso*p1.lato;

        }

        private void calcolaNumeroFisso(Poligono p1)
        {
            nFisso = 1 / (2 * Math.Tan(Math.PI / p1.nLati));
        }

        public string Confronta(Poligono p1,Poligono p2)
        {
            string confronto;

            if (p2.nLati == p1.nLati)
            {
                if (p2.lato > p1.lato)
                    confronto = "Il poligono passato è più grande";
                else if (p2.lato == p1.lato)
                    confronto = "Il poligono passato è uguale";
                else
                    confronto = "Il poligono passato è più piccolo";
            }
            else
                confronto = "Il poligono passato non è confrontabile";

            return confronto;
        }

        public string Stampa (Poligono p1)
        {
            string nomeP= p1.nomePoligono[p1.nLati];
            return nomeP;
        }
    }
}
    
