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
            string[] maalit = new string[]
                { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            List<string> pelit = new List<string>();
            List<string> tulokset = new List<string>();
            Random random = new Random();

            for (int laskuri = 0; laskuri < 210; laskuri++)

            {
                bool peliOk = false;
                while (!peliOk)
                {
                    int indeksi = random.Next(0, joukkueet.Length);
                    int indeksi3 = random.Next(0, maalit.Length);
                    string kotiJoukkue = joukkueet[indeksi];
                    string kotiMaalit = maalit[indeksi3];

                    bool indeksiOk = false;
                    int indeksi2 = random.Next(0,joukkueet.Length);
                    int indeksi4 = random.Next(0, maalit.Length);
                    while (!indeksiOk)
                    {
                        indeksi2 = random.Next(0, joukkueet.Length);
                        indeksiOk = indeksi != indeksi2;
                    }
                    string vierasJoukkue = joukkueet[indeksi2];
                    string vierasMaalit = maalit[indeksi4];

                    string peli = kotiJoukkue + "-" + vierasJoukkue;
                    string lopputulos = kotiMaalit + "-" + vierasMaalit;

                    if (!pelit.Contains(peli))
                    {
                        pelit.Add(peli);
                        tulokset.Add(lopputulos);
                        peliOk = true;
                    }
                }
            }

            return pelit;

        }   

    }

}