using System;

namespace Test_Framework
{
    internal class clsOrder
    {
        public clsOrder()
        {
        }

        public bool Active { get; internal set; }
        public DateTime DateAdded { get; internal set; }
        public int Orderid { get; internal set; }
        public string Customerid { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}