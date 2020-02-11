using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Widget_Classes;

namespace Widget_Testing
{
    [TestClass]
    public class tstOrdercollection
    {
        [TestMethod]
        public void InstanceOK()
        {//create an instance of the class we want to create]
            clsOrder AnOrder = new clsOrder();
            //test to see that it exists
            Assert.IsNotNull(AnOrder);
        }
    
    }
}
