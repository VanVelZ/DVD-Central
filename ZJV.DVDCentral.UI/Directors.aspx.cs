using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.BL;

namespace ZJV.DVDCentral.UI
{
    public partial class Directors : System.Web.UI.Page
    {
        List<Director> items;
        Director item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //is it the first time here
            {
                items = DirectorManager.Load();
                Rebind();
                Session["items"] = items;
                ddlExisting_SelectedIndexChanged(sender, e);

                //Put ratings in session so i can use them later
            }
            else
            {
                items = (List<Director>)Session["items"];
            }
        }
        private void Rebind()
        {
            //Clear out the binding
            ddlExisting.DataSource = null;

            //rebind dropdown
            ddlExisting.DataSource = items;

            // Designate the field that is going to be displayed in the control
            //what property will be displayed in the dropdown
            ddlExisting.DataTextField = "FullName";

            //designate primary key of the object
            ddlExisting.DataValueField = "Id";

            //actually do the binding
            ddlExisting.DataBind();

            txtFirst.Text = string.Empty;
            txtLast.Text = string.Empty;

        }
        protected void ddlExisting_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get degreetype that is selected
            item = items[ddlExisting.SelectedIndex];

            //display the description
            txtFirst.Text = item.FirstName;
            txtLast.Text = item.LastName;

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                item = new Director();

                //Assign the property values
                item.LastName = txtLast.Text;
                item.FirstName = txtFirst.Text;

                //use the manager to add a row
                int results = DirectorManager.Insert(item);
                Response.Write("Inserted " + results + " rows...");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //get the selected  object that i want to use
                item = items[ddlExisting.SelectedIndex];

                //update  Description
                item.FirstName = txtFirst.Text;
                item.LastName = txtLast.Text;

                //delete it from the database
                int results = DirectorManager.Update(item);

                //update the list with new description
                items[ddlExisting.SelectedIndex] = item;

                //rebind
                Rebind();

                Response.Write("Updated " + results + " rows...");


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //get the selected  object that i want to use
                item = items[ddlExisting.SelectedIndex];

                //delete it from the database
                int results = DirectorManager.Delete(item.Id);
                //remove it from degreeTypes
                items.Remove(item);

                //rebind
                Rebind();

                Response.Write("Deleted " + results + " rows...");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}