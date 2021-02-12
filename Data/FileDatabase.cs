using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CityBase.Estates;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Type = CityBase.Estates.Type;

namespace CityBase.Data
{
    class FileDatabase : IDatabase
    {
        private string FileName;
        private List<Estate> EstatesList;
        private CityManager _cityManager;

        public FileDatabase(string fileName)
        {
            EstatesList = new List<Estate>();
            FileName = fileName;
            LoadFromFile().Wait();

        }

        public void AddEstate(Estate estate)
        {

            EstatesList.Add(estate);
            UpdateFile().Wait();
        }

        public void RemoveEstate(int number)
        {
            EstatesList.Remove(EstatesList.Single(x => x.Number == number));
            UpdateFile().Wait();
        }

        public IEnumerable<Estate> GetAllEstates()
        {
            return EstatesList;
        }
        public Estate GetEstate(int number)
        {
            return EstatesList.SingleOrDefault(x => x.Number == number);
        }

        private async Task UpdateFile()
        {
            var estatesStringList = new Collection<string>();// czy zadziala z kolekcja
            StringBuilder sbLine = new StringBuilder();
            Task task = Task.Run(() =>
            {
                foreach (var estate in EstatesList)
                {
                    if (estate is Parcel parcel
                    ) //zobacz notatki, lista jest typu klasy bazowej wiec musimy zmienic na obiekt dziecka
                    {
                        sbLine.Append(
                            $"{parcel.Number}|{parcel.Address}|{parcel.Property}|{parcel.Length}|{parcel.Width}|{parcel.Price}|{parcel.DateCreated.ToShortDateString()}|{parcel.Type}");
                        estatesStringList.Add(sbLine.ToString());
                        sbLine.Clear();
                    }
                    else if (estate is Office office)
                    {
                        sbLine.Append(
                            $"{office.Number}|{office.Address}|{office.Property}|{office.Length}|{office.Width}|{office.Price}|{office.DateCreated.ToShortDateString()}|{office.NumOfFloors}|{office.MaxPersons}");
                        estatesStringList.Add(sbLine.ToString());
                        sbLine.Clear();
                    }
                }

                FileStream fs = new FileStream(FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                foreach (var item in estatesStringList)
                {
                    sw.WriteLine(item);
                }

                sw.Close();
                // lub zwykly sposob
                //File.WriteAllLines(FileName, estatesStringList);
            });
            await task;
        }

        public async Task LoadFromFile()
        {
            Task task = Task.Run(() =>
            {
                try
                {
                    FileStream fs = new FileStream(FileName, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] tableLine = line.Split('|');
                        if (tableLine[2] == Property.City.ToString())
                        {
                            LoadOffice(tableLine);
                        }
                        else if (tableLine[2] == Property.Other.ToString())
                        {
                            LoadParcel(tableLine);
                        }
                    }

                    sr.Close();

                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Nie znaleziono pliku z danymi. "  + ex.Message);
                    Console.ReadKey();
                }
            });
            await task;


            // z uzyciem zwyklej metody
            //string[] tableAll;
            //tableAll = File.ReadAllLines(FileName);
            //foreach (var line in tableAll)
            //{
            //    string[] tableLine = line.Split('|');
            //    if (tableLine[2] == Property.City.ToString())
            //    {
            //        LoadOffice(tableLine);
            //    }
            //    else if (tableLine[2] == Property.Other.ToString())
            //    {
            //        LoadParcel(tableLine);
            //    }
            //}
        }

        private void LoadParcel(string[] tableLine)
        {
            int number = int.Parse(tableLine[0]);
            string address = tableLine[1];
            var property = (Property)Enum.Parse(typeof(Property), tableLine[2]);
            decimal length = decimal.Parse(tableLine[3]);
            decimal width = decimal.Parse(tableLine[4]);
            decimal price = decimal.Parse(tableLine[5]);
            DateTime dateCreated = DateTime.ParseExact(tableLine[6], "dd.MM.yyyy", null);
            Type type = (Type)Enum.Parse(typeof(Type), tableLine[7]);
            Estate parcel = new Parcel(address, number, length, width, price, property, dateCreated, type);
            EstatesList.Add(parcel);
        }

        private void LoadOffice(string[] tableLine)
        {
            int number = int.Parse(tableLine[0]);
            string address = tableLine[1];
            var property = (Property)Enum.Parse(typeof(Property), tableLine[2]);
            decimal length = decimal.Parse(tableLine[3]);
            decimal width = decimal.Parse(tableLine[4]);
            decimal price = decimal.Parse(tableLine[5]);
            DateTime dateCreated = DateTime.ParseExact(tableLine[6], "dd.MM.yyyy", null);
            int numOfFloors = int.Parse(tableLine[7]);
            int maxPersons = int.Parse(tableLine[8]);
            Estate office = new Office(address, number, numOfFloors, maxPersons, length, width, price, property, dateCreated);
            EstatesList.Add(office);
        }


    }
}

