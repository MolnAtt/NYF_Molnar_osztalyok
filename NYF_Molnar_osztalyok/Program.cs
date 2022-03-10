using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NYF_Molnar_osztalyok
{
    class Program
    {
        class Tanuló
        {
            public string kod;
            public string nev;
            public string matcsop;
            public string ancsop;
            public string mnyelv;
            public string nem;
            public int egyuttlakok;
            public int testverszam;

           
            // default-constructor : nincs visszatérési típus és ugyanaz kell legyen a neve, mint a classnak!
            public Tanuló() 
            { 

            }
            


            // ez egy nagyon fontos konstruktortípus! 
            public Tanuló(string kod, string nev, string matcsop, string ancsop, string mnyelv, string nem, int egyuttlakok, int testverszam)
            {
                this.kod = kod;
                this.nev = nev;
                this.matcsop = matcsop;
                this.mnyelv = mnyelv;
                this.nem = nem;
                this.ancsop = ancsop;
                this.testverszam = testverszam;
                this.egyuttlakok = egyuttlakok;
                Console.WriteLine($"Létrejött a következő tanuló!");
                this.Kiír();
            }

            public Tanuló(string[] sortömb)
            {
                this.kod = sortömb[0];
                this.nev = sortömb[1];
                this.matcsop = sortömb[2];
                this.ancsop = sortömb[3];
                this.mnyelv = sortömb[4];
                this.nem = sortömb[5];
                this.egyuttlakok = int.Parse(sortömb[6]);
                this.testverszam = int.Parse(sortömb[7]);
                Console.WriteLine($"Létrejött a következő tanuló!");
                this.Kiír();
            }



            public void Kiír()
            {
                Console.WriteLine(nev);
            }


        }

        static void Main(string[] args)
        {
            List<Tanuló> tanulók = new List<Tanuló>();

            string[] sorok = File.ReadAllLines("03_000-J.txt", Encoding.Default);

            
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] sortömb = sorok[i].Split(';');
                Tanuló t = new Tanuló();
                t.kod = sortömb[0];
                t.nev = sortömb[1];
                t.matcsop = sortömb[2];
                t.ancsop = sortömb[3];
                t.mnyelv = sortömb[4];
                t.nem = sortömb[5];
                t.egyuttlakok = int.Parse(sortömb[6]);
                t.testverszam = int.Parse(sortömb[7]);
                tanulók.Add(t);
            }
            


            
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] sortömb = sorok[i].Split(';');
                Tanuló t = new Tanuló(sortömb[0], sortömb[1], sortömb[2], sortömb[3], sortömb[4], sortömb[5], int.Parse(sortömb[6]), int.Parse(sortömb[7]));
                tanulók.Add(t);
            }
            

            for (int i = 0; i < sorok.Length; i++)
            {
                string[] sortömb = sorok[i].Split(';');
                Tanuló t = new Tanuló(sortömb);
                tanulók.Add(t);
            }

            for (int i = 0; i < sorok.Length; i++)
            {
                // nem olvasható, de megértem, hogy jó érzés csinálni...
                tanulók.Add(new Tanuló(sorok[i].Split(';')));
            }

            Tanuló eki = tanulók[3];

            eki.Kiír();


            Console.WriteLine("1. Ennyi diák tanul az osztályban:"); 
            Console.WriteLine(tanulók.Count);

            Console.WriteLine("2. Hány fiú tanul az osztályban?");

            int db = 0;
            for (int i = 0; i < tanulók.Count; i++)
            {
                if (tanulók[i].nem == "F")
                {
                    db++;
                }
            }

            Console.WriteLine(db);


            
        }
    }
}
