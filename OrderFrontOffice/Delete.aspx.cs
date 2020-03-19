using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Widget_Classes;



public partial class Delete : System.Web.UI.Page
{
    //var to store the primary key value of the record to be deleted
    Int32 Orderid;

    //event handler for the load event
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the order to be deleted from the session object
        Orderid = Convert.ToInt32(Session["Orderid"]);
    }

    protected void Buttonyes_Click(object sender, EventArgs e)
    { 
        {
            //delete the record
            
          
            //redirect back to the main page
            Response.Redirect("Default.aspx");
        }
    }

    protected void ButtonNo_Click(object sender, EventArgs e)
    {
        {
            //redirect back to the main page
            Response.Redirect("Default.aspx");
        }

        void DeleteOrder()
        {
            //function to delete the selected record

            //create a new instance of the order book
            ClsOrderCollection OrderBook = new ClsOrderCollection();
            //find the record to delete
            OrderBook.ThisOrder.Find(Orderid);
            //delete the record
            OrderBook.Delete();
        }
    }
}