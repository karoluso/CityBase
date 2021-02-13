using System;
using CityBase.CityBase.Utils;
using CityBase.Data;

namespace CityBase.Commands
{
    class ListOfEstatesCommand :ICommand
    {
        private IDatabase _iDatabase;

        public ListOfEstatesCommand(IDatabase iDatabase)
        {
            _iDatabase = iDatabase;
        }
        public void Run()
        {   Console.Clear();
            var estates = _iDatabase.GetAllEstates();
            Console.WriteLine("List of estates: \n====================");
            EstatePrinter.PrintList(estates);
        }

        public string GetName()
        {
            return "List";
        }


    }
}
