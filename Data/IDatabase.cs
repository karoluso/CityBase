using System.Collections.Generic;
using CityBase.Estates;
using CityBase;
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