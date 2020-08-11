using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBackend.Controllers
{
    [Route("api/oma")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("luku")]
        public int Luku()
        { return 123; }

        [Route("satunnainen")]
        public int Satunnaisluku()
        {
            Random random = new Random();
            int luku = random.Next(1, 20);
            return luku;
        }

        [Route("merkkijono")]
        public string Merkkijono()
        { return "ABCD"; }
        [Route("merkkijonot")]
        public string[] Merkkijonot()
        {
            return new string[] { "ABCD", "DEFG" };
        }

        [Route("ottelut")]
        public List<string> Ottelut()
      
        {
            string[] joukkueet = new string[]
            {
                "HIFK", "HPK", "Ilves", "Jukurit", "JYP", "KalPa", "KooKoo", "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät"
            };
            int[] maalit = new int[]
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            Dictionary<string, int> pistetilanne = new Dictionary<string, int>();
            
            List<string> pelit = new List<string>();
            List<string> tulokset = new List<string>();
            Random random = new Random();

            foreach (string joukkue in joukkueet)
            {
                pistetilanne.Add(joukkue, 0);
            }

            for (int laskuri = 0; laskuri < 210; laskuri++)

            {
                bool peliOk = false;
                while (!peliOk)
                {
                    int indeksi = random.Next(0, joukkueet.Length);
                    int indeksi3 = random.Next(0, maalit.Length);
                    string kotiJoukkue = joukkueet[indeksi];
                    int kotiMaalit = maalit[indeksi3];

                    bool indeksiOk = false;
                    int indeksi2 = random.Next(0,joukkueet.Length);
                    int indeksi4 = random.Next(0, maalit.Length);
                    while (!indeksiOk)
                    {
                        indeksi2 = random.Next(0, joukkueet.Length);
                        indeksiOk = indeksi != indeksi2;
                    }
                    string vierasJoukkue = joukkueet[indeksi2];
                    int vierasMaalit = maalit[indeksi4];

                    string peli = kotiJoukkue + "-" + vierasJoukkue;
                    string lopputulos = kotiMaalit + "-" + vierasMaalit;

                   
                   
                    if (!pelit.Contains(peli))
                    {
                        pelit.Add(peli + " " + lopputulos);
                        //tulokset.Add(lopputulos);
                        peliOk = true;

                        if (kotiMaalit > vierasMaalit)
                        {
                            pistetilanne[kotiJoukkue] += 3;
                            pistetilanne[vierasJoukkue] += 0;
                        }

                        else if (vierasMaalit > kotiMaalit)
                        {
                            pistetilanne[kotiJoukkue] += 0;
                            pistetilanne[vierasJoukkue] += 3;
                        }
                        else
                        {
                            pistetilanne[kotiJoukkue] += 1;
                            pistetilanne[vierasJoukkue] += 1;
                        }


                    }
                    
                }
                
            }
            static void Lokiin(string viesti)
            {
                const string TiedostoNimi = "C:\\users\\janne\\Sarjataulukko.txt";
                System.IO.File.AppendAllText(TiedostoNimi, viesti + "\r\n");
            }


            var Sarjataulukko = pistetilanne.ToList();
            Sarjataulukko.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            Sarjataulukko.ToArray();
            Lokiin("SARJATAULUKKO:\n");
            
            foreach (KeyValuePair<string, int> kvp in Sarjataulukko)
            {
                Lokiin("Joukkueen " + kvp.Key + " pistetilanne: " + kvp.Value);
            }

            /*
            foreach (string joukkue in joukkueet)
            {


                Lokiin("SARJATAULUKKO\n" + "Joukkueen " + joukkue + " pistetilanne: " + Sarjataulukko);
            }*/
            
            return pelit;

          
            
        }   

    }

}