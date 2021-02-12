using System;
using System.Collections.Generic;
using System.Text;
using CityBase.CityBase.Utils;
using CityBase.Data;

namespace CityBase.Commands
{
    class RemoveEstateCommand :ICommand
    {
        private IDatabase _iDatabase;

        public RemoveEstateCommand(IDatabase iDatabase)
        {
            _iDatabase = iDatabase;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Give a number of Estate :");
            int num = int.Parse(Console.ReadLine());
            _iDatabase.RemoveEstate(num);
            Console.WriteLine($"\nEstate {num} has been reomved. ");
        }

        public string GetName()
        {
            return "Remove";
        }

    }
}
