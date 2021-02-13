using System;
using System.Collections.Generic;
using System.Text;
using CityBase.CityBase.Utils;
using CityBase.Data;

namespace CityBase.Commands
{
    class GetDetailsOfEstateCommand:ICommand
    {
        private IDatabase _iDatabase;
        public GetDetailsOfEstateCommand(IDatabase iDatabase)
        {
            _iDatabase = iDatabase;
        }
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Give a number of Estate :");
            try
            {
                int num = int.Parse(Console.ReadLine());
                var estate = _iDatabase.GetEstate(num);
                Console.WriteLine("\nEstate details\n=====================");
                EstatePrinter.Print(estate);
            }
            catch (FormatException ex)

            {
                Console.WriteLine("Incorrect number. " + ex.Message);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Number does not exist in database. " + ex.Message);

            }
            
        }

        public string GetName()
        {
            return "Details";
        }
    }
}
