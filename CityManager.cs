using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CityBase.Estates;
using System.Linq;
using CityBase.Data;

namespace CityBase
{
    class CityManager
    {
        private IDatabase _iDatabase;

        public CityManager(IDatabase iDatabase)
        {
            _iDatabase = iDatabase;
        }
        public void AddEstate(Estate estate)
        {
            if (_iDatabase.GetAllEstates().Any() && _iDatabase.GetAllEstates().Any(x => x.Number == estate.Number))
            {
                _iDatabase.RemoveEstate( estate.Number);
            }

            int nextNumber = estate.Number == 0 ? GetNextNumber() : estate.Number;  // dodawanie ze zmiana typu na ddziecko
            Estate newItem = estate;
            newItem.Number = nextNumber;
            _iDatabase.AddEstate(newItem);
        }
        private int GetNextNumber()
        {
            int number = _iDatabase.GetAllEstates().Any() ? (_iDatabase.GetAllEstates().Max(x => x.Number) + 1) : 1;
            return number;
        }

    }
}
