using System;

namespace DDD.Domain.Entities
{
    public class Customer
    {
        private const int YEARS_FOR_CUSTOMER_VIP = 5;

        public Customer()
        {
            Created = DateTime.Now;
            Active = true;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        protected DateTime Created { get; private set; }

        public bool Active { get; private set; }

        public static bool IsCustomerVip(Customer customer)
        {
            return customer.Active && DateTime.Now.Year - customer.Created.Year >= YEARS_FOR_CUSTOMER_VIP;
        }

        public bool IsCustomerVip()
        {
            return IsCustomerVip(this);
        }
    }
}
