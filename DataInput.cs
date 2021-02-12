using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using CityBase.Estates;
using Type = CityBase.Estates.Type;


namespace CityBase
{
    class DataInput
    {
        public string Address { get; private set; }
        public int Number { get; private set; }
        public decimal Length { get; private set; }
        public decimal Width { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateCreated { get; private set;}
        public Property Property { get; private set; }
        public int NumOfFloors { get; private set; }
        public int MaxPersons { get; private set; }
        public  Estates.Type Type { get; private set; }

        public Estate GetDataFromUser()
        {
            try
            {
                Console.WriteLine("Wprowadz dane nowej nieruchomosci: \n==============================");
                Console.Write("Podaj numer lub wcisnij enter w celu autmoatycznego ustawienia numeru: ");
                string numtxt = Console.ReadLine();
                Number = !String.IsNullOrEmpty(numtxt) ? int.Parse(numtxt) : default;
                Console.Write("Podaj address: ");
                Address = Console.ReadLine();
                if (String.IsNullOrEmpty(Address))
                {
                    throw new ArgumentException("Nie wprowadzono ,zadnego adresu.");
                }

                Console.Write("Podaj dlugosc: ");
                Length = decimal.Parse(Console.ReadLine());
                if (Length < 0)
                {
                    throw new ArgumentException("Dlugosc  nie moze byc ujemna.");
                }

                Console.Write("Podaj szerokosc: ");
                Width = decimal.Parse(Console.ReadLine());
                if (Width < 0)
                {
                    throw new ArgumentException("Szerokosc nie moze byc ujemna.");
                }

                Console.Write("Podaj cene: ");
                Price = decimal.Parse(Console.ReadLine());
                if (Price < 0)
                {
                    throw new ArgumentException("Cena nie moze byc ujemna.");
                }
                Console.WriteLine("Podaj date utworzenia (dd.MM.yyyy : ");
                DateCreated = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Property = GetProperty();
            if (Property == Property.City)
            {
                GetOfficeData();
                return new Office(Address, Number, NumOfFloors, MaxPersons, Length, Width, Price, Property,
                    DateCreated);
            }
            else if (Property == Property.Other)
            {
                GetParcelData();
                return new Parcel(Address, Number, Length, Width, Price, Property, DateCreated,Type);
            }

            return null;
        }

        private void GetParcelData()
        {
            Property = Property.Other;
            Console.WriteLine($"Typ ({Type.Budowlana} / {Type.Rolna}):  ");
            string typek = Console.ReadLine();
            Type = (Estates.Type) Enum.Parse(typeof(Estates.Type),typek);
            
        }

        private void GetOfficeData()
        {
            Property = Property.City;
            Console.Write("Ilosc pieter: ");
            NumOfFloors = int.Parse(Console.ReadLine());
            Console.Write("Msx Ilosc osob: ");
            MaxPersons = int.Parse(Console.ReadLine());
        }

        private Property GetProperty()
        {
            Console.WriteLine("Wybierz rodzaj nieruchomosci: ");
            string[] tableOfPropertyValues = Enum.GetNames(typeof(Property));
            string text = null;
            for (int i = 0; i < tableOfPropertyValues.Length; i++)
            {
                text += $"{i}.{tableOfPropertyValues[i]}  ";
               
            }
            Console.WriteLine(text);
            int numer = int.Parse(Console.ReadLine());

            return (Property) numer; // rzutowanie wartosci int na enum
        }

    }
}
