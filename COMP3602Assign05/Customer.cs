namespace COMP3602Assign05
{
    class Customer
    {
        private readonly string customerCode;
        private string companyName;
        private string address;
        private string city;
        private string province;
        private string postalCode;
        private bool creditHold;

        public Customer(string customerCode, string companyName, string address, string city, string province, string postalCode, bool creditHold)
        {
            this.customerCode = customerCode;
            this.companyName = companyName;
            this.address = address;
            this.city = city;
            this.province = province;
            this.postalCode = postalCode;
            this.creditHold = creditHold;
        }
        public string CustomerCode { get { return customerCode; } }
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
        public bool CreditHold
        {
            get { return creditHold; }
            set { creditHold = value; }
        }
    }
}
