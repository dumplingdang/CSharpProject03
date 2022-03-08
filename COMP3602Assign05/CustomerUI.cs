using System;
using System.Collections.Generic;

namespace COMP3602Assign05
{
    class CustomerUI
    {
        private const int InitialNumber = 1;
        private const int NumberPlaceHolderWidth = 10;
        private const int ProvincePlaceHolderWidth = 3;
        private const int CompanyNameHolderWidth = 40;
        private const int CityHolderWidth = 15;
        private const int ProvHolderWidth = 5;
        private const int PostalHolderWidth = 8;
        private const int CreditHolderWidth = 4;
        public static void PrintCustomersBySelectedProvince()
        {
            Console.WriteLine("Select province filter: ");

            List<string> provinces = CustomerRespository.GetProvinces();
            int number = InitialNumber;

            foreach (string province in provinces)
            {
                Console.WriteLine($"{number,NumberPlaceHolderWidth}) {province,-ProvincePlaceHolderWidth}");//Display all provinces
                number++;
            }

            int selectedNumber;
            int.TryParse(Console.ReadLine(), out selectedNumber);//Store a number given by a user in a console

            string[] provinceArray = provinces.ToArray();
            string selectedProvince = provinceArray[selectedNumber - 1];//Store a province associated with the number given above by the user

            Console.WriteLine($"Customer listing for {selectedProvince}");
            Console.WriteLine();

            List<Customer> customers = CustomerRespository.GetCustomersByProvince(selectedProvince); //Filter customers by a province selected above by the user

            Console.WriteLine($"{"CompanyName",-CompanyNameHolderWidth}{"City",-CityHolderWidth}{"Prov",-ProvHolderWidth}{"Postal",-PostalHolderWidth}{"Hold",CreditHolderWidth}");

            int lineLength = CompanyNameHolderWidth + CityHolderWidth + ProvHolderWidth + PostalHolderWidth + CreditHolderWidth;
            string dashLine = new string('-', lineLength);

            Console.WriteLine(dashLine);

            foreach (Customer customer in customers)
            {
                string creditHoldString = "Y";
                if (!customer.CreditHold)
                {
                    creditHoldString = "N";
                }
                Console.WriteLine($"{customer.CompanyName,-CompanyNameHolderWidth}{customer.City,-CityHolderWidth}{customer.Province,-ProvHolderWidth}{customer.PostalCode,-PostalHolderWidth} {creditHoldString,-CreditHolderWidth}");
            }
        }

    }
}
