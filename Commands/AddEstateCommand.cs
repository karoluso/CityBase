using System;
using System.Collections.Generic;
using System.Text;
using CityBase.CityBase.Utils;
using CityBase.Data;
using CityBase.Estates;

namespace CityBase.Commands
{
    class AddEstateCommand:ICommand
    {
        private CityManager _cityManager;
        private DataInput _dataInput;

        public AddEstateCommand(CityManager cityManager,DataInput dataInput)
        {
            _cityManager = cityManager;
            _dataInput = dataInput;
        }
        public void Run()
        {
            Console.Clear();
            Estate estate= _dataInput.GetDataFromUser();
            _cityManager.AddEstate(estate);
            Console.WriteLine("\nNew Estate added.");
        }

        public string GetName()
        {
            return "Add";
        }
    }
}
