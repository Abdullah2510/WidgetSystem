using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Widget_Classes
{
       public class ClsOrderCollection
    {


        //private data member for the list
        List<clsOrder> mOrderList = new List<clsOrder>();
        //private data member thisAddress
        clsOrder mThisOrder = new clsOrder();

        //constructor for the class
        public ClsOrderCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblOrder_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount;
            //get the count of records
            RecordCount = DB.Count;
            //clear the private array list
            mOrderList = new List<clsOrder>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsOrder AnOrder = new clsOrder();
                //read in the fields from the current record
                AnOrder.Orderid = Convert.ToInt32(DB.DataTable.Rows[Index]["Orderid"]);
                AnOrder.Firstname = Convert.ToString(DB.DataTable.Rows[Index]["Firstname"]);
                AnOrder.Lastname = Convert.ToString(DB.DataTable.Rows[Index]["Lastname"]);
                AnOrder.DateAdded = Convert.ToDateTime(DB.DataTable.Rows[Index]["Date"]);
                AnOrder.DeliveryID = Convert.ToInt32(DB.DataTable.Rows[Index]["Deliveryid"]);
                AnOrder.CustomerID = Convert.ToInt32(DB.DataTable.Rows[Index]["Customerid"]);

                //add the record to the private data mamber
                mOrderList.Add(AnOrder);
                //point at the next record
                Index++;
            }
        }


        //public property for the order list
        public List<clsOrder> OrderList
        {
            get
            {
                //return the private data
                return mOrderList;
            }
            set
            {
                //set the private data
                mOrderList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                //return the count of the list
                return mOrderList.Count;
            }
            set
            {
                //we shall worry about this later
            }
        }

        //public property for ThisAddress
        public clsOrder ThisOrder
        {
            get
            {
                //return the private data
                return mThisOrder;
            }
            set
            {
                //set the private data
                mThisOrder = value;
            }
        }

     

        public int Add()
        {
            //adds a new record to the database based on the values of thisAddress
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@Orderid", mThisOrder.Orderid);
            DB.AddParameter("@FirstName", mThisOrder.Firstname);
            DB.AddParameter("@LastName", mThisOrder.Lastname);
            DB.AddParameter("@DateAdded", mThisOrder.DateAdded);
            DB.AddParameter("@Customerid", mThisOrder.CustomerID);
            DB.AddParameter("@Deliveryid", mThisOrder.DeliveryID);
            //execute the query returning the primary key value
            return DB.Execute("sproc_tblOrder_Insert");
        }

        public void Delete()
        {
            //deletes the record pointed to by thisOrder
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@Orderid", mThisOrder.Orderid);
            //execute the stored procedure
            DB.Execute("sproc_tblOrder_Delete");
        }

        public void Update()
        {
            //create an instance of the class we want to create
            clsDataConnection DB = new clsDataConnection();
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            DB.AddParameter("@Orderid", mThisOrder.Orderid);
            DB.AddParameter("@FirstName", mThisOrder.Firstname);
            DB.AddParameter("@LastName", mThisOrder.Lastname);
            DB.AddParameter("@DateAdded", mThisOrder.DateAdded);
            DB.AddParameter("@Customerid", mThisOrder.CustomerID);
            DB.AddParameter("@Deliveryid", mThisOrder.DeliveryID);
          
            //execute the stored procedure
            DB.Execute("sproc_tblOrder_Update");
        }

        public void ReportBylastname(string Lastname)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //send the PostCode parameter to the database
            DB.AddParameter("@lastname", Lastname);
            //execute the stored procedure
            DB.Execute("sproc_tblOrder_FilterByLastname");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        public void ReportByOrderid(string v)
        {
            throw new NotImplementedException();
        }
    }
    }

