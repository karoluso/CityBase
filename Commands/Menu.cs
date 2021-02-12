﻿using System;
using System.Collections.Generic;
using System.Text;
using CityBase.Data;
using System.Linq;
using System.Threading.Channels;
using Console = System.Console;

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

                input = int.Parse(Console.ReadLine());
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
                    Console.WriteLine("Wrong input; try again.");
                }
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