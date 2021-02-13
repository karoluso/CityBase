using System;
using System.Collections.Generic;

namespace CityBase.Estates
{
    class Office:Estate
    {
        public int NumOfFloors { get; }
        public int MaxPersons { get; }
        public Office(string address, int number,int numOfFloors, int maxPersons, decimal length, decimal width, decimal price, Property property, DateTime dateCreated) : base(address, number, length, width, price, property, dateCreated)
        {
            NumOfFloors = numOfFloors;
            MaxPersons = maxPersons;
        }
        public override List<string> AdditionalInfo(Estate estate)
        {
            Office office = estate as Office;
            List<string> list = new List<string>();
            list.Add($"Liczba Pieter : {office.NumOfFloors}");
            list.Add($"Maksymalna liczba osob: {office.MaxPersons}");
            return list;
        }
    }
}
