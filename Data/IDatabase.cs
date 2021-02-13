using System.Collections.Generic;
using CityBase.Estates;

namespace CityBase.Data

{
     interface IDatabase
    {
        void AddEstate(Estate estate);
        void RemoveEstate(int number);
        IEnumerable<Estate> GetAllEstates();
        Estate GetEstate(int number);
    }
}