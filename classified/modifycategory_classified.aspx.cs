using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;

public partial class classified_modifycategory_classified : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    NewAdbooking.classified.classified_sql objsql = new NewAdbooking.classified.classified_sql();
    NewAdbooking.classified.classified_mysql objmysql = new NewAdbooking.classified.classified_mysql();
    NewAdbooking.classified.classified_oracle objoracle = new NewAdbooking.classified.classified_oracle();
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(classified_modifycategory_classified));
        if (!Page.IsPostBack)
        {
            bindMainCategories();
        }

    }
   
    public void bindMainCategories()
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = objsql.bindmainchannel();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ds = objoracle.bindmainchannel();
        }
        else
        {
            ds = objmysql.bindmainchannel();
        }
        common.FillDropDown(ref ddlmaincat_new, ds, "adv_cat_name", "adv_cat_code", "--Select--", true);

    }

    protected void grd_user_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grd_user_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            string Getid = e.CommandArgument.ToString();
            Response.Redirect("addcategory_classified.aspx?id=" + e.CommandArgument.ToString());
        }
        if (e.CommandName == "Delete")
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
               // ds = objsql.bindmainchannel();
                SqlCommand cmd = new SqlCommand();
                string fldID = e.CommandArgument.ToString();
                cmd = objsql.deletefld(fldID);
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_modifycategory_classified), "wq", "alert('Data deleted successfully.');", true);
                cmd.Connection.Close();
                cmd.Dispose();
                string GetID = ddlmaincat_new.SelectedValue;
                ds = objsql.Bind_calssified_grid(GetID);
                common.FillGrid(ref grd_user, ds, true);
               
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                OracleCommand cmd = new OracleCommand();
                string fldID = e.CommandArgument.ToString();
                cmd = objoracle.deletefld(fldID);
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_modifycategory_classified), "wq", "alert('Data deleted successfully.');", true);
                cmd.Connection.Close();
                cmd.Dispose();
                string GetID = ddlmaincat_new.SelectedValue;
                ds = objoracle.Bind_calssified_grid(GetID);
                common.FillGrid(ref grd_user, ds, true);
            }
            else
            {


                MySqlCommand cmd = new MySqlCommand();
                string fldID = e.CommandArgument.ToString();
                cmd = objmysql.deletefld(fldID);
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_modifycategory_classified), "wq", "alert('Data deleted successfully.');", true);
                cmd.Connection.Close();
                cmd.Dispose();
                string GetID = ddlmaincat_new.SelectedValue;
                ds = objmysql.Bind_calssified_grid(GetID);
                common.FillGrid(ref grd_user, ds, true);
            }

        }
    }
    protected void grd_user_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grd_user_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grd_user_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlmaincat_new_SelectedIndexChanged(object sender, EventArgs e)
    {

        string GetID = ddlmaincat_new.SelectedValue;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = objsql.Bind_calssified_grid(GetID);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ds = objoracle.Bind_calssified_grid(GetID);
        }
        else
        {
            ds = objmysql.Bind_calssified_grid(GetID);
        }
        common.FillGrid(ref grd_user, ds, true);

        

    }
   
}
