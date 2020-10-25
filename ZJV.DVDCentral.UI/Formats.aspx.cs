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
    public partial class Formats : System.Web.UI.Page
    {
        List<Format> items;
        Format item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //is it the first time here
            {
                items = FormatManager.Load();
                Rebind();
                Session["items"] = items;
                ddlExisting_SelectedIndexChanged(sender, e);

                //Put ratings in session so i can use them later
            }
            else
            {
                items = (List<Format>)Session["items"];
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
            ddlExisting.DataTextField = "Description";

            //designate primary key of the object
            ddlExisting.DataValueField = "Id";

            //actually do the binding
            ddlExisting.DataBind();

            txtDescription.Text = string.Empty;

        }
        protected void ddlExisting_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get degreetype that is selected
            item = items[ddlExisting.SelectedIndex];

            //display the description
            txtDescription.Text = item.Description;

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                item = new Format();

                //Assign the property values
                item.Description = txtDescription.Text;

                //use the manager to add a row
                int results = FormatManager.Insert(item);
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
                //get the selected degreetype object that i want to use
                item = items[ddlExisting.SelectedIndex];

                //update degreeType Description
                item.Description = txtDescription.Text;

                //delete it from the database
                int results = FormatManager.Update(item);

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
                //get the selected degreetype object that i want to use
                item = items[ddlExisting.SelectedIndex];

                //delete it from the database
                int results = FormatManager.Delete(item.Id);
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