using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Widget_Testing;

namespace Test_Framework
{
    [TestClass]
    public class tstOrdercollection
    {
        private object clsOrder;

        public object AnOrder { get; private set; }
        public object AllOrders { get; private set; }

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsOrdercollection AnOrdercollection = new clsOrdercollection();
            //test to see that it exists
            Assert.IsNotNull(AnOrder);
        }

        [TestMethod]
        public void OrderListOK()
        {
            //create an instance of the class we want to create
            clsOrdercollection AnOrdercollection = new clsOrdercollection();
            //create some test data to assign to the property
            //in this case the data needs to be a list of objects
            List<clsOrder> TestList = new List<clsOrder>();
            //add an item to the list
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //set its properties
            TestItem.FirstName = "some name";
            TestItem.LastName = "some name";
            TestItem.Orderid = "O1234";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Customerid = "C2113";
            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllOrders.OrderList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.OrderList, TestList);
        }

        [TestMethod]
        public void OrderPropertyOK()
        {
            //create an instance of the class we want to create
            clsOrdercollection AnOrdercollection = new clsOrdercollection();
            //create some test data to assign to the property
            clsOrder TestOrder = new clsOrder();
            //set the properties of the test object
            TestOrder.FirstName = "some name";
            TestOrder.LastName = "some name";
            TestOrder.Orderid = "O1234";
            TestOrder.DateAdded = DateTime.Now.Date;
            TestOrder.Customerid = "C2113";
            //assign the data to the property
            AllOrders.ThisOrder = TestOrder;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.ThisOrder, TestOrder);
        }

             [TestMethod]
        public void ListAndCountOK()
        {
            //create an instance of the class we want to create
            clsOrdercollection AnOrdercollection = new clsOrdercollection();
            //create some test data to assign to the property
            //in this case the data needs to be a list of objects
            List<clsOrder> TestList = new List<clsOrder>();
            //add an item to the list
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //set its properties
            TestItem.FirstName = "some name";
            TestItem.LastName = "some name";
            TestItem.Orderid = "O123";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Customerid = "C2113";
            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllOrders.OrderList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.Count, TestList.Count);
        }


    }







        }



    

