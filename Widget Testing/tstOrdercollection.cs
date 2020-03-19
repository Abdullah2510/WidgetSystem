using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Widget_Classes;
using System.Collections.Generic;


namespace Test_Framework
{
    [TestClass]
    public class tstOrderCollection
    { 

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //test to see that it exists
            Assert.IsNotNull(AllOrders);
        }

        [TestMethod]
        public void OrderListOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //create some test data to assign to the property
            //in this case the data needs to be a list of objects
            List<clsOrder> TestList = new List<clsOrder>();
            //add an item to the list
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //set its properties
            TestItem.Firstname = "some name";
            TestItem.Lastname = "some name";
            TestItem.Orderid = 1234;
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.CustomerID = 2113;
            TestItem.DeliveryID =1234 ;
            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllOrders.OrderList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.OrderList, TestList);
        }

        //[TestMethod]
        //public void CountPropertyOK()
        //{
        //    //create an instance of the class we want to create
        //    clsOrderCollection AllOrders = new clsOrderCollection();
        //    //create some test data to assign to the property
        //    Int32 SomeCount = 2;
        //    //assign the data to the property
        //    AllOrders.Count = SomeCount;
        //    //test to see that the two values are the same
        //    Assert.AreEqual(AllOrders.Count, SomeCount);
        //}

        [TestMethod]
        public void ThisOrderPropertyOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //create some test data to assign to the property
            clsOrder TestOrder = new clsOrder();
            //set the properties of the test object
            TestOrder.Firstname = "some name";
            TestOrder.Lastname = "some name";
            TestOrder.Orderid = 1234;
            TestOrder.DateAdded = DateTime.Now.Date;
            TestOrder.CustomerID = 2113 ;
            TestOrder.DeliveryID = 2113;
            //assign the data to the property
            AllOrders.ThisOrder = TestOrder;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.ThisOrder, TestOrder);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //create some test data to assign to the property
            //in this case the data needs to be a list of objects
            List<clsOrder> TestList = new List<clsOrder>();
            //add an item to the list
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //set its properties
            TestItem.Firstname = "some name";
            TestItem.Lastname = "some name";
            TestItem.Orderid = 1234;
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.CustomerID = 2113;
            TestItem.DeliveryID = 2113;

            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllOrders.OrderList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.Count, TestList.Count);
        }


        //[TestMethod]
        //public void TwoRecordsPresent()
        //{
        //    //create an instance of the class we want to create
        //    clsOrderCollection AllOrders = new clsOrderCollection();
        //    //test to see that the two values are the same
        //    Assert.AreEqual(AllOrders.Count, 2);
        //}

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Orderid = 1;
            TestItem.Firstname = "some name";
            TestItem.Lastname = "some name";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.CustomerID = 123;
            TestItem.DeliveryID = 123;
            //set ThisOrder to the test data
            AllOrders.ThisOrder = TestItem;
            //add the record
            PrimaryKey = AllOrders.Add();
            //set the primary key of the test data
            TestItem.Orderid = PrimaryKey;
            //find the record
            AllOrders.ThisOrder.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.ThisOrder, TestItem);
        }


        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Orderid = 1;
            TestItem.Firstname = "some name";
            TestItem.Lastname = "some name";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.CustomerID = 123;
            TestItem.DeliveryID = 123;

            //set ThisOrder to the test data
            AllOrders.ThisOrder = TestItem;
            //add the record
            PrimaryKey = AllOrders.Add();
            //set the primary key of the test data
            TestItem.Orderid = PrimaryKey;
            //find the record
            AllOrders.ThisOrder.Find(PrimaryKey);
            //delete the record
            AllOrders.Delete();
            //now find the record   
            Boolean Found = AllOrders.ThisOrder.Find(PrimaryKey);
            //test to see that the record was not found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of the class we want to create
            ClsOrderCollection Allorders = new ClsOrderCollection();
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Orderid = 1;
            TestItem.Firstname= "some name";
            TestItem.Lastname = "some name";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.CustomerID = 123;
            TestItem.DeliveryID = 123;
            //set ThisAddress to the test data
            Allorders.ThisOrder = TestItem;
            //add the record
            PrimaryKey = Allorders.Add();
            //set the primary key of the test data
            TestItem.Orderid = PrimaryKey;
            //modify the test data

            TestItem.Orderid = 1;
            TestItem.Firstname = "some name";
            TestItem.Lastname = "some name";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.CustomerID = 123;
            TestItem.DeliveryID = 123;
            //set the record based on the new test data
            Allorders.ThisOrder = TestItem;
            //update the record
            Allorders.Update();
            //find the record
            Allorders.ThisOrder.Find(PrimaryKey);
            //test to see ThisOrder matches the test data
            Assert.AreEqual(Allorders.ThisOrder, TestItem);
        }

        [TestMethod]
        public void ReportByOrderidMethodOK()
        {
            //create an instance of the class containing unfiltered results
            ClsOrderCollection AllOrders = new ClsOrderCollection();
            //create an instance of the filtered data
            ClsOrderCollection FilteredOrders = new ClsOrderCollection();
            //apply a blank string (should return all records);
            FilteredOrders.ReportByOrderid("122");
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.Count, FilteredOrders.Count);
        }


        [TestMethod]
        public void ReportByOrderidNoneFound()
        {
            //create an instance of the filtered data
            ClsOrderCollection FilteredOrders = new ClsOrderCollection();
            //apply a orderid that doesn't exist
            FilteredOrders.ReportByOrderid("xxx xxx");
            //test to see that there are no records
            Assert.AreEqual(0, FilteredOrders.Count);
        }

        [TestMethod]
        public void ReportByOrderidTestDataFound()
        {
            //create an instance of the filtered data
            ClsOrderCollection FilteredOrders = new ClsOrderCollection();
            //var to store outcome
            Boolean OK = true;
            //apply a post code that doesn't exist
            FilteredOrders.ReportByOrderid("1234");
            //check that the correct number of records are found
            if (FilteredOrders.Count == 2)
            {
                //check that the first record is ID 36
                if (FilteredOrders.OrderList[0].Orderid != 36)
                {
                    OK = false;
                }
                //check that the first record is ID 37
                if (FilteredOrders.OrderList[1].Orderid != 37)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            //test to see that there are no records
            Assert.IsTrue(OK);
        }

    }
}

  
     


   







    

