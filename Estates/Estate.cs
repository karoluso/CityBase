using System;
using System.Collections.Generic;


namespace CityBase.Estates
{
     class Estate
    {
        public string Address { get; }
        public int Number { get; set; }
        public decimal Length { get; }
        public decimal Width { get; }
        public decimal Price { get; }
        public Property Property { get; }
        
        public decimal Area
        {
            get {return Width * Length; }
        }

        public decimal PricePerSqrMeter
        {
            get { return decimal.Round((Price / Area),2); }
        }

        public DateTime DateCreated { get; }
        public DateTime DateControlled { get; }


        public Estate(string address, int number, decimal length, decimal width, decimal price, Property property,DateTime dateCreated)
        {
            Address = address;
            Number = number;
            Length = decimal.Round(length,2);
            Width = decimal.Round(width,2);
            Price = price;
            Property = property;
            DateCreated = dateCreated;
            DateControlled = DateCreated.AddYears(3);
        }

        public Estate(string address, decimal length, decimal width, decimal price, Property property,DateTime dateCreated)
        {
            Address = address;
            Number = 0;
            Length = length;
            Width = width;
            Price = price;
            Property = property;
            DateCreated = dateCreated;
            DateControlled = DateCreated.AddYears(3);
        }

        public bool CheckControlDate(Estate estate)
        {
            return DateTime.Today >= DateControlled;
        }


        public virtual List<string> AdditionalInfo(Estate estate)
        {
            return new List<string>();
        }
    }


    public enum Property    //this is already beyond Estate Class !
    {
        City,
        Private,
        Other
    }
}

