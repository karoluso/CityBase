using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using CityBase;
using CityBase.Estates;
using CityBase.CityBase.Utils;
using System.Linq;

namespace CityBase.Data
{
    class MemoryDatabase : IDatabase
    {
        private List<Estate> EstatesList { get; }

        public MemoryDatabase()
         {
             EstatesList= new List<Estate>();
         }
        
         public IEnumerable<Estate> GetAllEstates()
         {
             return EstatesList;
         }

         public void AddEstate(Estate estate)
         {
             EstatesList.Add(estate);
         }

         public Estate GetEstate(int number)
         {
             return EstatesList.SingleOrDefault(x => x.Number == number);
         }

         public void RemoveEstate(int number)
         {
            //dodac validacje
            EstatesList.Remove(EstatesList.Single(x => x.Number == number));
        }

    }
}
