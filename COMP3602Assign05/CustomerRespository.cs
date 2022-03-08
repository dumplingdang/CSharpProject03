using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace COMP3602Assign05
{
    class CustomerRespository
    {
        private static readonly string connString = @"Server=tcp:comp2614.database.windows.net,1433; 
                                                            Initial Catalog=comp2614;
                                                            User ID=student; Password=iLOVEpho!; 
                                                            Encrypt=True; 
                                                            TrustServerCertificate=False; 
                                                            Connection Timeout=30;";
        private const int ProvinceLength = 2;
        public static List<string> GetProvinces()
        {
            List<string> provinces = new List<string>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT DISTINCT Province FROM Customer";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string province = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("Province")))
                            {
                                province = reader["Province"] as string;
                                if (province.Trim().Length == ProvinceLength)
                                {
                                    provinces.Add(province);
                                }
                            }
                        }
                    }
                }
            }
            provinces.Add("ALL");
            return provinces;
        }
        public static List<Customer> GetCustomersByProvince(string provinceFilter = "ALL")
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = null;

                    if (provinceFilter == "ALL")
                    {
                        query = @"SELECT CustomerCode, CompanyName, Address, City, Province, PostalCode, CreditHold
                                      FROM Customer";
                    }
                    else
                    {
                        query = $@"SELECT CustomerCode, CompanyName, Address, City, Province, PostalCode, CreditHold
                                      FROM Customer                                     
                                      WHERE Province = @province";
                    }

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@province", provinceFilter);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string customerCode = null;
                            string companyName = null;
                            string address = null;
                            string city = null;
                            string province = null;
                            string postalCode = null;
                            bool? creditHold = null;
                            customerCode = reader["CustomerCode"] as string;
                            companyName = reader["CompanyName"] as string;
                            address = reader["Address"] as string;
                            city = reader["City"] as string;
                            province = reader["Province"] as string;
                            postalCode = reader["PostalCode"] as string;
                            creditHold = reader["CreditHold"] as bool?;
                            customers.Add(new Customer(customerCode, companyName, address, city, province, postalCode, creditHold ?? false));
                        }
                    }
                }
            }
            return customers;
        }
    }
}
