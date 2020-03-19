using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Widget_Classes
{
    public class clsOrder
    {
        private int mOrderid;
        private int mCustomerid;
        private int mDeliveryid;

        //private data member for the OrderID property
        // private Int32 mOrderID;
        //private data member for Firstname
        private string mFirstname;
        //private data member for Lastname
        private string mLastname;
        //private date added data member
        private DateTime mDateAdded;
        //private data member for customerid
        private string mCustomerID;
        //private data member for deliveryid
        private string mDeliveryID;


        //public property for the orderid
        public int Orderid
        {
            get
            {
                //return the private data
                return mOrderid;
            }
            set
            {
                //set the value of the private data member
                mOrderid = value;
            }
        }

        //public property for First name
        public string Firstname
        {
            get
            {
                //return the private data
                return mFirstname;
            }
            set
            {
                //set the private data
                mFirstname = value;
            }
        }

        //public property for Last name
        public string Lastname
        {
            get
            {
                //return private data
                return mLastname;
            }
            set
            {
                //set the private data
                mLastname = value;
            }
        }


        //public property for date added
        public DateTime DateAdded
        {
            get
            {
                //return the private data
                return mDateAdded;
            }
            set
            {
                //set the private data
                mDateAdded = value;
            }
        }



        //public data member for Customerid
        public int CustomerID
        {
            get
            {
                //return the private data
                return mCustomerid;
            }
            set
            {
                //set the private data
                mCustomerid = value;
            }
        }

        //public data member for deliveryid
        public int DeliveryID
        {
            get
            {
                //return the private data
                return mDeliveryid;
            }
            set
            {
                //set the private data
                mDeliveryid = value;
            }

            //public property for activeusing Widget_Classes;
        }



        public bool Find(int OrderID)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the address no to search for
            DB.AddParameter("@Orderid", OrderID);
            //execute the stored procedure
            DB.Execute("sproc_tblOrder_FilterByLastname");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database to the private data members
                mOrderid = Convert.ToInt32(DB.DataTable.Rows[0]["Orderid"]);
                mFirstname = Convert.ToString(DB.DataTable.Rows[0]["Firstname"]);
                mLastname = Convert.ToString(DB.DataTable.Rows[0]["Lastname"]);
                mDateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"]);
                mDeliveryid = Convert.ToInt32(DB.DataTable.Rows[0]["Deliveryid"]);
                mCustomerid = Convert.ToInt32(DB.DataTable.Rows[0]["Customerid"]);
                //return that everything worked OK
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }

        public string Valid(string orderid, string firstname, string lastname, string dateAdded, string customerid, string deliveryid)
        {
            //create a string variable to store the error
            String Error = "";
            //create a temporary variable to store date values
            DateTime DateTemp;
            Int32 CustomeridTemp;
            Int32 DeliveryidTemp;
            //if the HouseNo is blank
            if (orderid.Length == 0)
            {
                //record the error
                Error = Error + "The orderid may not be blank : ";
            }
            //if the Firstname is greater than 3 characters
            if (firstname.Length > 6)
            {
                //record the error
                Error = Error + "The Firstrname must be more than 3 characters : ";
            }
            try
            {
                //copy the dateAdded value to the DateTemp variable
                DateTemp = Convert.ToDateTime(dateAdded);
                if (DateTemp < DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "The date cannot be in the past : ";
                }
                //check to see if the date is greater than today's date
                if (DateTemp > DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "The date cannot be in the future : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The date was not a valid date : ";
            }
            //is the Customerid blank
            CustomeridTemp = Convert.ToInt32(customerid);
            if (CustomeridTemp > 9)
            {
                //record the error
                Error = Error + "The customerid may not be blank : ";
            }
            //if the customerid is too long
            if (customerid.Length > 9)
            {
                //record the error
                Error = Error + "The customerid must be less than 9 characters : ";
            }
            //is the deliveryid blank
            DeliveryidTemp = Convert.ToInt32(deliveryid);
            if (DeliveryID > 9)
            {
                //record the error
                Error = Error + "The Deliveryid not be blank : ";
            }
            //if the deliveryid is too long
            if (deliveryid.Length > 9)
            {
                //record the error
                Error = Error + "The deliveryid be less than 50 characters : ";
            }

            //return any error messages
            return Error;
        }
    }





}