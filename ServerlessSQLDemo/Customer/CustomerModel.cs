using System;

namespace ServerlessSQLDemo.Customer
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
    }
}
