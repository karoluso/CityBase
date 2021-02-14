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

            catch (ApplicationException ex)
            {
                Console.WriteLine("Number is already used. ");
                Program.LogException(ex);
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Incorrect value. " + ex.Message);
                Program.LogException(ex);
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine("Incorrect value. " + ex.Message);
                Program.LogException(ex);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
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
            return "Add";
        }
    }
}
