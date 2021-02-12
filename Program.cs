using System;
using System.ComponentModel;
using CityBase.Commands;
using CityBase.Data;
using CityBase.Estates;

namespace CityBase
{
    class Program
    {
      
        static void Main(string[] args)
        {
           DataInput dataInput= new DataInput();
          
           IDatabase iDatabase= new FileDatabase(@"C:\Users\Dom\Desktop\SzkolaSzarpania-CityBase kopia przed praca domowa z wzorcow\CityBase\Data\DatabaseTextFile.txt");
            CityManager cityManager= new CityManager(iDatabase);
            Menu menu = new Menu(iDatabase,dataInput,cityManager);
            
            menu.Run();
           
          
            

        }
    }

   

}
