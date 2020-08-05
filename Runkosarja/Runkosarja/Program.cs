using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel.Design;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Runkosarja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liigan runkosarja");

            string Joukkue1 = "HIFK";
            string Joukkue2 = "HPK";
            string Joukkue3 = "ILV";
            string Joukkue4 = "JUK";
            string Joukkue5 = "JYP";
            string Joukkue6 = "KAL";
            string Joukkue7 = "KOO";
            string Joukkue8 = "KAR";
            string Joukkue9 = "LUK";
            string Joukkue10 = "PEL";
            string Joukkue11 = "SAI";
            string Joukkue12 = "SPO";
            string Joukkue13 = "TAP";
            string Joukkue14 = "TPS";
            string Joukkue15 = "ASS";
            
            int k = 0;
            string ottelupari = "0" +  "-" + "0";
            do

            {
                int i = 0;

                do

                {
                        var random = new Random();
                        var list = new List<string> { "HIFK", "HPK", "Ilves", "Jukurit", "JYP", "KalPa", "KooKoo", "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };
                        int index = random.Next(list.Count);
                        Console.WriteLine(list[index]);
                        i = i + 1;
                }
                while (i < 2);

                int j = 0;

                do
                {
                    var random2 = new Random();
                    var list2 = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    int index = random2.Next(list2.Count);
                    Console.WriteLine(list2[index]);
                    j = j + 1;
                }
                
                while (j < 2);

                k = k + 1;
            }
            while (k < 210);

        }
    }
}
