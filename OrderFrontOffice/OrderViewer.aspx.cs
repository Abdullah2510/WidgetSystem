using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderViewer : System.Web.UI.Page

{
    //this function handles the load event for the page
    protected void Page_Load(object sender, EventArgs e)
    {
        //if this is the first time the page is displayed
        if (IsPostBack == false)
        {
            //update the list box
            DisplayOrders();
        }
    }

    void DisplayOrders()
    {
        //create an instance of the County Collection
        Widget_Classes.ClsOrderCollection Orders = new Widget_Classes.ClsOrderCollection();
        //set the data source to the list of counties in the collection
        lstorders.DataSource = Orders.OrderList;
        //set the name of the primary key
        lstorders.DataValueField = "AddressNo";
        //set the data field to display
        lstorders.DataTextField = "PostCode";
        //bind the data to the list
        lstorders.DataBind();
    }


    //event handler for the add button
    protected void btnadd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate this is a new record
        Session["Orderid"] = -1;
        //redirect to the data entry page
        Response.Redirect("AnOrder.aspx");
    }
    //event handler for the edit button
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //var to store the primary key value of the record to be edited
        Int32 Orderid;
        //if a record has been selected from the list
        if (lstorders.SelectedIndex != -1)
        {
            //get the primary key value of the record to edit
            Orderid = Convert.ToInt32(lstorders.SelectedValue);
            //store the data in the session object
            Session["Orderid"] = Orderid;
            //redirect to the edit page
            Response.Redirect("AnOrder.aspx");
        }
        else//if no record has been selected
        {
            //display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    //event handler for the delete button
    protected void btndelete_Click(object sender, EventArgs e)
    {
        //var to store the primary key value of the record to be deleted
        Int32 Orderid;
        //if a record has been selected from the list
        if (lstorders.SelectedIndex != -1)
        {
            //get the primary key value of the record to delete
            Orderid = Convert.ToInt32(lstorders.SelectedValue);
            //store the data in the session object
            Session["AddressNo"] = Orderid;
            //redirect to the delete page
            Response.Redirect("Delete.aspx");
        }
        else //if no record has been selected
        {
            //display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }
}