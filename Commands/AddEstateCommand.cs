using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;
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
            try
            {
                Estate estate = _dataInput.GetDataFromUser();
                _cityManager.AddEstate(estate);
                Console.WriteLine("\nNew Estate added.");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("Number is already used. ");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Incorrect value. " + ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Incorrect value. " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public string GetName()
        {
            return "Add";
        }
    }
}
