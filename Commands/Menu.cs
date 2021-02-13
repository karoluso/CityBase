using System;
using System.Collections.Generic;
using CityBase.Data;
using System.Linq;

namespace CityBase.Commands
{
    class Menu
    {
        private Dictionary<int, ICommand> dictionaryEstates;

        public Menu(IDatabase iDatabase, DataInput dataInput,CityManager cityManager)  //tutaj nuie musinmy pola IDatabase tworzyc bo uzywany to tylko w kostruktorze
        {
            dictionaryEstates = new Dictionary<int, ICommand>()
            {
                {1, new ListOfEstatesCommand(iDatabase)},
                {2,new GetDetailsOfEstateCommand(iDatabase)},
                {3,new AddEstateCommand(cityManager, dataInput)},
                {4,new RemoveEstateCommand(iDatabase)}
            };
        }

        public void Run()
        {
            int input;

            do
            {
                Console.Clear();
                Console.WriteLine("MENU:\n==================");

                GetCommandsList();

                Console.Write("\nChoose command number: ");

                int.TryParse(Console.ReadLine(), out input); // if user gives null or text, input will be 0
                
                if (input == 5)
                {
                    Console.WriteLine("\nBye  Bye ...");
                    break;
                }

                if (dictionaryEstates.ContainsKey(input))
                {
                    RunCommand(input);
                }

                else
                {
                    Console.WriteLine("Incorrect input ");
                }

                Console.WriteLine("\npress any key to continue...");
                Console.ReadKey();

            } while (true);

        }

        private void GetCommandsList()
        {
            foreach (var item in dictionaryEstates)
            {
                Console.WriteLine($"{item.Key} - {item.Value.GetName()}");
            }

            Console.WriteLine("5 - End");

        }
        private void RunCommand(int num)
        {
            var command = dictionaryEstates.FirstOrDefault(x => x.Key == num);
            command.Value.Run();
        }

    }
}
