using System;
using System.Collections.Generic;
using System.Text;

namespace CityBase.Estates
{
    class Parcel:Estate
    {
        public Type Type { get; }
        public Parcel (string address, int number, decimal length, decimal width, decimal price, Property property, DateTime dateCreated, Type type) :base(address, number, length, width, price, property, dateCreated)
        {
            Type = type;
        }
        public override List<string> AdditionalInfo(Estate estate)
        {
            Parcel parcel = estate as Parcel;
            List<string> list = new List<string>();
            list.Add($"Typ dzialki  : {parcel.Type}");
            return list;
        }
    }

    public enum Type//this is already beyond Parcel Class !
    {
        Budowlana,
        Rolna
    }
}
