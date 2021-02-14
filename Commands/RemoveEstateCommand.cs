using System;
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
            try
            {
            int num = int.Parse(Console.ReadLine());
            _iDatabase.RemoveEstate(num);
            Console.WriteLine($"\nEstate {num} has been reomved. ");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Incorrect number. " + ex.Message);
                Program.LogException(ex);
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Number does not exist in database. " + ex.Message);
                Program.LogException(ex);
            }

            catch (OverflowException ex)
            {
                Console.WriteLine("Two large input value. " + ex.Message);
                Program.LogException(ex);
            }
        }


        public string GetName()
        {
            return "Remove";
        }

    }
}
