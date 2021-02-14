
using System;
using System.IO;
using CityBase.Commands;
using CityBase.Data;

namespace CityBase
{
    class Program
    {
        /*below static method is logging all exceptions into a specified text file*/
        public static void LogException(Exception ex)
        {
            string filename = @"C:\Users\Dom\Desktop\SzkolaSzarpania-CityBase kopia przed praca domowa z wzorcow\CityBase\ExceptionLogger.txt";
            string logData = ($"Date: {DateTime.Now} \n" +
                              $"Details:  {ex} \n" +
                              $"MethodBase: {ex.TargetSite} \n" +
                              "\n--------------------------------\n");
            File.AppendAllText(filename, logData);
        }

        static void Main(string[] args)
        {
            IDatabase iDatabase = new FileDatabase(@"C:\Users\Dom\Desktop\SzkolaSzarpania-CityBase kopia przed praca domowa z wzorcow\CityBase\Data\DatabaseTextFile.txt");

            //IDatabase iDatabase= new MemoryDatabase();   // optionaly if we want to work on MemoryDatabase

            DataInput dataInput = new DataInput(iDatabase);

            CityManager cityManager= new CityManager(iDatabase);

            Menu menu = new Menu(iDatabase,dataInput,cityManager);
            
            menu.Run();
           
        }
    }

   

}
