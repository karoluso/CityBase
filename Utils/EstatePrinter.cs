using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CityBase.Estates;

namespace CityBase.CityBase.Utils
{
    class EstatePrinter
    {
        public static void Print(Estate estate)
        {
            Console.WriteLine(estate.Number +" - "+ estate.Address);
            Console.WriteLine("Wlasnosc: "+estate.Property);
            Console.WriteLine("Wymiary: " + estate.Length + "x" + estate.Width);
            Console.WriteLine("Powierzchnia: "+ estate.Area);
            Console.WriteLine("Cena za metr: "+ estate.PricePerSqrMeter);
            Console.WriteLine("Data dodania: "+estate.DateCreated.ToShortDateString());
            Console.WriteLine("Data kontroli: "+estate.DateControlled.ToShortDateString());
            if (estate.CheckControlDate(estate))
            {
                Console.Write("   MINELA !!!!\n");
            }
            estate.AdditionalInfo(estate).ForEach(Console.WriteLine);
            //ciekawe czy wyswietli czy nie
        }

        public static void PrintList(IEnumerable<Estate> estateList)
        {
            
            foreach (Estate item  in estateList.OrderBy(x=>x.Number))
            {
                Console.WriteLine(item.Number + " - " + item.Address +$"({item.Property})");
                Console.WriteLine("Powierzchnia: " + item.Area);
                Console.WriteLine("Cena: "+ item.Price);
                Console.WriteLine("====================");
            }
        }
    }
}


