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


public partial class classified_addcategory_classified : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    NewAdbooking.classified.classified_sql objsql = new NewAdbooking.classified.classified_sql();
    NewAdbooking.classified.classified_mysql objmysql = new NewAdbooking.classified.classified_mysql();
    NewAdbooking.classified.classified_oracle objoracle = new NewAdbooking.classified.classified_oracle();
    string Getid = "";
    string Getddlval = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(classified_addcategory_classified));

        if (!Page.IsPostBack)
        {
        if (Request.QueryString["id"] != null)
        {
            Getid = Request.QueryString["id"].ToString();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                
                ds = objsql.get_val_from_table(Getid);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlmaincat.SelectedValue  = ds.Tables[0].Rows[0]["cat_cd"].ToString();
                    txtfieldname.Text  = ds.Tables[0].Rows[0]["fld_name"].ToString();
                    Getddlval = ds.Tables[0].Rows[0]["fld_type"].ToString();
                    gethid.Value = Getddlval;

                    if (Getddlval == "R" || Getddlval == "C" || Getddlval == "S")
                    {
                        lbl.Text = "List was Selected";
                        ddlfieldtype.SelectedValue = "0";
                    }
                    
                }


            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                ds = objoracle.get_val_from_table(Getid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlmaincat.SelectedValue = ds.Tables[0].Rows[0]["cat_cd"].ToString();
                    txtfieldname.Text = ds.Tables[0].Rows[0]["fld_name"].ToString();
                    Getddlval = ds.Tables[0].Rows[0]["fld_type"].ToString();
                    gethid.Value = Getddlval;

                    if (Getddlval == "R" || Getddlval == "C" || Getddlval == "S")
                    {
                        lbl.Text = "List was Selected";
                        ddlfieldtype.SelectedValue = "0";

                    }
                   

                }

            }
            else
            {
                ds = objmysql.get_val_from_table(Getid);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlmaincat.SelectedValue = ds.Tables[0].Rows[0]["cat_cd"].ToString();
                    txtfieldname.Text = ds.Tables[0].Rows[0]["fld_name"].ToString();
                    Getddlval = ds.Tables[0].Rows[0]["fld_type"].ToString();
                    gethid.Value = Getddlval;

                    if (Getddlval == "R" || Getddlval == "C" || Getddlval == "S")
                    {
                        lbl.Text = "List was Selected";
                        ddlfieldtype.SelectedValue = "0";
                    }
                }

            }




        }

            bindMainCategories();
        }
        if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
        {

            Secdiv.Visible = true;

        }
        else
        {
            Secdiv.Visible = false;
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            int maxid = objsql.maxid_ID_fld_mst();
            //int getval = Convert.ToInt32(ddlmaincat.SelectedValue);
            SqlCommand cmd = new SqlCommand();
            //int maxid,int catid,string Fieldname,string fldtype
            cmd = objsql.insertMainclassifiedcat_option(maxid, Convert.ToInt32(ddlsecondcat.SelectedValue), txtoption1.Text);
            ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Submitted Successfully.');", true);
            cmd.Connection.Close();
            cmd.Dispose();
            //if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
            //{
            //    bindsecondCategories();
            //}
            txtoption1.Text = "";
            txtoption1.Focus();

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            int maxid = objoracle.maxid_ID_fld_option();
            OracleCommand cmd1 = new OracleCommand();
            //int maxid,int catid,string Fieldname,string fldtype
            cmd1 = objoracle.insertMainclassifiedcat_option(maxid, Convert.ToInt32(ddlsecondcat.SelectedValue), txtoption1.Text);
            ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Submitted Successfully.');", true);
            cmd1.Connection.Close();
            cmd1.Dispose();
            if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
            {
                bindsecondCategories();
            }

        }
        else
        {

            int maxid = objmysql.maxid_ID_fld_opt_mst();
            MySqlCommand cmd = new MySqlCommand();
            //int maxid,int catid,string Fieldname,string fldtype
            cmd = objmysql.insertMainclassifiedcat_option(maxid, Convert.ToInt32(ddlsecondcat.SelectedValue), txtoption1.Text);
            ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Submitted Successfully.');", true);
            cmd.Connection.Close();
            cmd.Dispose();
            if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
            {
                bindsecondCategories();
            }


        }
        


    }
    protected void ddlmaincat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string catVal = ddlmaincat.SelectedValue;
        if (catVal != "0")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                ds = objsql.bindSubCat(catVal);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                ds = objoracle.bindSubCat(catVal);
            }
            else
            {
                ds = objmysql.bindSubCat(catVal);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpsubcat.ClearSelection();
                common.FillDropDown(ref drpsubcat, ds, "Adv_Subcat_Name", "Adv_Subcat_Code", "---Select---", true);
            }
            else
            {
                common.FillDropDown(ref drpsubcat, null, "", "0", "----Select----", true);
            }
            ds.Dispose();
        }
    }
    protected void btnadds_Click(object sender, EventArgs e)
    {
        string maincat = ddlmaincat.SelectedValue;
        if (drpsubcat.SelectedValue != "" && drpsubcat.SelectedValue != "0")
        {
            maincat = drpsubcat.SelectedValue;
        }
        if (Request.QueryString["id"] != null)
        {
            Getid = Request.QueryString["id"].ToString();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                SqlCommand cmd1 = new SqlCommand();

                String FLDlength = "";

                if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
                {
                    FLDlength = "50";
                }
                if (ddlfieldtype.SelectedValue == "D")
                {
                    FLDlength = "10";
                }
                if (ddlfieldtype.SelectedValue == "L")
                {
                    FLDlength = "1";
                }
                if (ddlfieldtype.SelectedValue == "N")
                {
                    FLDlength = "20";
                }
                if (ddlfieldtype.SelectedValue == "T")
                {
                    FLDlength = "200";
                }


                string query1 = "update cat_field_mst set cat_cd='" + maincat + "',fld_name='" + txtfieldname.Text.ToString() + "',fld_len=" + FLDlength + ",fld_type='" + ddlfieldtype.SelectedValue + "' where fld_id=" + Getid + "";
                cmd1 = objsql.update_table(query1);
                cmd1.Connection.Close();
                cmd1.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Updated Successfully.');", true);


            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                OracleCommand cmd1 = new OracleCommand();

                String FLDlength = "";

                if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
                {
                    FLDlength = "50";
                }
                if (ddlfieldtype.SelectedValue == "D")
                {
                    FLDlength = "10";
                }
                if (ddlfieldtype.SelectedValue == "L")
                {
                    FLDlength = "1";
                }
                if (ddlfieldtype.SelectedValue == "N")
                {
                    FLDlength = "20";
                }
                if (ddlfieldtype.SelectedValue == "T")
                {
                    FLDlength = "200";
                }

                string query1 = "update cat_field_mst set cat_cd='" + maincat + "',fld_name='" + txtfieldname.Text.ToString() + "',fld_len=" + FLDlength + ",fld_type='" + ddlfieldtype.SelectedValue + "' where fld_id=" + Getid + "";
                cmd1 = objoracle.update_table(query1);
                cmd1.Connection.Close();
                cmd1.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Updated Successfully.');", true);

            }
            else
            {

                MySqlCommand cmd1 = new MySqlCommand();

                String FLDlength = "";

                if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
                {
                    FLDlength = "50";
                }
                if (ddlfieldtype.SelectedValue == "D")
                {
                    FLDlength = "10";
                }
                if (ddlfieldtype.SelectedValue == "L")
                {
                    FLDlength = "1";
                }
                if (ddlfieldtype.SelectedValue == "N")
                {
                    FLDlength = "20";
                }
                if (ddlfieldtype.SelectedValue == "T")
                {
                    FLDlength = "200";
                }


                string query1 = "update cat_field_mst set cat_cd='" + maincat + "',fld_name='" + txtfieldname.Text.ToString() + "',fld_len=" + FLDlength + ",fld_type='" + ddlfieldtype.SelectedValue + "' where fld_id=" + Getid + "";
                cmd1 = objmysql.update_table(query1);
                cmd1.Connection.Close();
                cmd1.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Updated Successfully.');", true);


            }

        }
        else
        {


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                DataSet ds_get = objsql.Getcat_name_val(txtfieldname.Text.ToString(), maincat);
                if (ds_get.Tables[0].Rows.Count > 0 && ds_get.Tables[0].Rows[0]["fld_name"].ToString() == txtfieldname.Text.ToString())
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Duplicate Value is not allowed');", true);
                }
                else
                {
                    int maxid = objsql.maxid_ID();
                    //int getval = Convert.ToInt32(ddlmaincat.SelectedValue);          
                    SqlCommand cmd = new SqlCommand();
                    //int maxid,int catid,string Fieldname,string fldtype
                    cmd = objsql.insertMainclassifiedcat(maxid, maincat, txtfieldname.Text, ddlfieldtype.SelectedValue);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Submitted Successfully.');", true);
                    cmd.Connection.Close();
                    cmd.Dispose();
                    if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
                    {
                        bindsecondCategories();
                    }
                }

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                int maxid = objoracle.maxid_ID();
                OracleCommand cmd1 = new OracleCommand();
                //int maxid,int catid,string Fieldname,string fldtype
                cmd1 = objoracle.insertMainclassifiedcat(maxid, Convert.ToInt32(maincat), txtfieldname.Text.Trim().ToString(), ddlfieldtype.SelectedValue);
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Submitted Successfully.');", true);
                cmd1.Connection.Close();
                cmd1.Dispose();
                if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
                {
                    bindsecondCategories();
                }

            }
            else
            {

                int maxid = objmysql.maxid_ID();
                MySqlCommand cmd = new MySqlCommand();
                //int maxid,int catid,string Fieldname,string fldtype
                cmd = objmysql.insertMainclassifiedcat(maxid, Convert.ToInt32(maincat), txtfieldname.Text.Trim().ToString(), ddlfieldtype.SelectedValue);
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_addcategory_classified), "wq", "alert('Submitted Successfully.');", true);
                cmd.Connection.Close();
                cmd.Dispose();
                if (ddlfieldtype.SelectedValue == "R" || ddlfieldtype.SelectedValue == "C" || ddlfieldtype.SelectedValue == "S")
                {
                    bindsecondCategories();
                }


            }
        }
        
        

    }
    public void bindMainCategories()
    {
        //if (Request.QueryString["id"] != null)
        //{
        //}
        //else
        //{
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
        //}
        common.FillDropDown(ref ddlmaincat, ds, "adv_cat_name", "adv_cat_code", "--Select--", true);

    }

    public void bindsecondCategories()
    {
        string maincat = ddlmaincat.SelectedValue;
        if (drpsubcat.SelectedValue != "" && drpsubcat.SelectedValue != "0")
        {
            maincat = drpsubcat.SelectedValue;
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = objsql.bindmainchannel_sec(maincat, ddlfieldtype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ds = objoracle.bindmainchannel_sec(maincat, ddlfieldtype.SelectedValue);
        }
        else
        {
            ds = objmysql.bindmainchannel_sec(maincat, ddlfieldtype.SelectedValue);
        }
        common.FillDropDown(ref ddlsecondcat, ds, "fld_name", "fld_id", "--Select--", true);
    }
    protected void ddlfieldtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maincat = ddlmaincat.SelectedValue;
        if (drpsubcat.SelectedValue != "" && drpsubcat.SelectedValue != "0")
        {
            maincat = drpsubcat.SelectedValue;
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = objsql.bindmainchannel_sec(maincat, ddlfieldtype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ds = objoracle.bindmainchannel_sec(maincat, ddlfieldtype.SelectedValue);
        }
        else
        {
            ds = objmysql.bindmainchannel_sec(maincat, ddlfieldtype.SelectedValue);
        }
        common.FillDropDown(ref ddlsecondcat, ds, "fld_name", "fld_id", "--Select--", true);


    }
}
