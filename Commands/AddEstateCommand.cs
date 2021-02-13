using System;
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

            catch (ApplicationException)
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

            catch (OverflowException ex)
            {
                Console.WriteLine("Two large input value. " + ex.Message);
            }
        }

        public string GetName()
        {
            return "Add";
        }
    }
}
