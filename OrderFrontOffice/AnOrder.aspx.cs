using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Widget_Classes;

public partial class AnOrder : System.Web.UI.Page
{
    //variable to store the primary key with page level scope
    Int32 Orderid;

    //event handler for the page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the address to be processed
        Orderid = Convert.ToInt32(Session["Orderid"]);
        if (IsPostBack == false)
        {

            //if this is not a new record
            if (Orderid != -1)
            {
                //display the current data for the record
                DisplayOrders();
            }
        }
    }

    protected void Bttnok_Click(object sender, EventArgs e)
    {
        if (Orderid == -1)
        {
            //add the new record
            Add();
        }
        else
        {
            //update the record
            Update();
        }
    }

    //function for adding new records
    void Add()
    {
        //create an instance of the address book
        ClsOrderCollection OrderBook = new ClsOrderCollection();
        //validate the data on the web form
        String Error = OrderBook.ThisOrder.Valid(txtboxFname.Text, txtboxlname.Text, Txtid.Text, Txtboxdate.Text, Txtboxcid.Text, txtboxdid.Text);
        //if the data is OK then add it to the object
        if (Error == "")
        {
            //get the data entered by the user
            OrderBook.ThisOrder.Firstname = txtboxFname.Text;
            OrderBook.ThisOrder.Lastname = txtboxlname.Text;
            OrderBook.ThisOrder.Orderid = Txtid.Text;
            OrderBook.ThisOrder.DateAdded = Convert.ToDateTime(Txtboxdate.Text);
            OrderBook.ThisOrder.CustomerID = Txtboxcid.Text;
            OrderBook.ThisOrder.DeliveryID = txtboxdid.Text;

            //add the record
            OrderBook.Add();
            //all done so redirect back to the main page
            Response.Redirect("OrderViewer.aspx");
        }
        else
        {
            //report an error
            lblError.Text = "There were problems with the data entered " + Error;
        }


        //function for updateing records

        void Update()
        {
            //create an instance of the address book
            Widget_Classes.ClsOrderCollection OrderBook = new Widget_Classes.ClsOrderCollection();
            //validate the data on the web form
            String Error = OrderBook.ThisOrder.Valid(txtboxFname.Text, txtboxlname.Text, Txtid.Text, Txtboxdate.Text, Txtboxcid.Text, txtboxdid.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to update
                OrderBook.ThisOrder.Find(Orderid);
                //get the data entered by the user
                //get the data entered by the user
                OrderBook.ThisOrder.Firstname = txtboxFname.Text;
                OrderBook.ThisOrder.Lastname = txtboxlname.Text;
                OrderBook.ThisOrder.Orderid = Convert.ToInt32(Txtid.Text);
                OrderBook.ThisOrder.DateAdded = Convert.ToDateTime(Txtboxdate.Text);
                OrderBook.ThisOrder.CustomerID = Convert.ToInt32(Txtboxcid.Text);
                OrderBook.ThisOrder.DeliveryID = Convert.ToInt32(txtboxdid.Text);
                //update the record
                OrderBook.Update();
                //all done so redirect back to the main page
                Response.Redirect("OrderViewer.aspx");
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered " + Error;
            }

            void DisplayOrder()
            {
                //create an instance of the address book
                ClsOrderCollection OrderBook = new ClsOrderCollection();
                //find the record to update
                OrderBook.ThisOrder.Find(Orderid);
                //display the data for this record
                txtboxFname.Text = OrderBook.ThisOrder.Firstname;
                txtboxlname.Text = OrderBook.ThisOrder.Lastname;
                Txtid.Text   =    OrderBook.ThisOrder.Orderid;
                Txtboxdate.Text = OrderBook.ThisOrder.DateAdded.ToString();
                Txtboxcid.Text = OrderBook.ThisOrder.Custromerid();
                txtboxdid.Text = OrderBook.ThisOrder.Deliveryid;
               
            }
        }
    }
}
