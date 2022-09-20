using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Drawing;
//using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class Help_Page : System.Web.UI.Page
{
    double tot_amt = 0, tot_vol = 0, amount1 = 0, amount2 = 0, amount3 = 0, current_amt = 0, previous_amt = 0, supply = 0, unsold = 0;
    double max1 = 0, max2 = 0, max3 = 0;
    string maximum = "", maximum1 = "", maximum2 = "", maximum3 = "", maximum4 = "", maximum5 = "", year1 = "", bscode1 = "", frmdt1 = "", todate1 = "", frmdt2 = "", todate2 = "", dtfrmat1 = "";
    string max_Len1 = "", max_Len2 = "", max_Len3 = "", max_Len4 = "", max_Len5 = "", max_Len6 = "", pp = "", cc = "", yy = "";
    string axisy_Label = "", chk_zero1 = "", mont = "", tabl = "", parentpage = "";
    Int32 p = 0, q = 0, r = 0, s = 0, w = 0, ii = 0, x = 0, y = 0, z = 0, diff_type1 = 1, act_hgt = 0, act_wid = 0, e = 0, f = 0, g = 0, h = 0, j = 0, k = 0, l = 0, m = 0, a1 = 0, b1 = 0, c1 = 0, d1 = 0, act_int = 0;
    string extra1 = "", extra2 = ""; string differenceofvalue = ""; string helping_value = "";
    DataSet ds_help = new DataSet();
    string prv_img = "", previous = "", current = "", year = "";
    int sno = 1; int function = 1;
    int i = 0;
    string[] dat = new string[9];

    protected void Page_Load(object sender, EventArgs e)
    {
        count.Value = "4";
        count1.Value = "1";
        count2.Value = "";
        if (Session["compcode"] == null)
        {
            hidden_sess.Value = "1";
        }
        else
        {           
            cirpub.Value = "";
           
          
           
            txtcompany.Focus();

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/Help_Page.xml"));
            lblcompany.Text = ds.Tables[1].Rows[0].ItemArray[0].ToString();
            lblprtcen.Text = ds.Tables[1].Rows[0].ItemArray[1].ToString();
            lblbranch.Text = ds.Tables[1].Rows[0].ItemArray[2].ToString();
            //view10.Text = ds.Tables[2].Rows[0].ItemArray[0].ToString();
            //view11.Text = ds.Tables[2].Rows[0].ItemArray[1].ToString();
            //view12.Text = ds.Tables[2].Rows[0].ItemArray[2].ToString();
            //view13.Text = ds.Tables[2].Rows[0].ItemArray[3].ToString();
            //view14.Text = ds.Tables[2].Rows[0].ItemArray[4].ToString();
            //view15.Text = ds.Tables[2].Rows[0].ItemArray[5].ToString();
            //view16.Text = ds.Tables[2].Rows[0].ItemArray[6].ToString();
            //view17.Text = ds.Tables[2].Rows[0].ItemArray[7].ToString();
            //view18.Text = ds.Tables[2].Rows[0].ItemArray[8].ToString();


            Ajax.Utility.RegisterTypeForAjax(typeof(Help_Page));
            if (!Page.IsPostBack)
            {
                txtcompany.Attributes.Add("onkeydown", "javascript:return fill_Company(event)");
                lstcomp.Attributes.Add("onkeydown", "javascript:return onclick_Company(event)");
                lstcomp.Attributes.Add("onclick", "javascript:return onclick_Company(event)");

                txtprtcen.Attributes.Add("onkeydown", "javascript:return fill_pcenter(event)");
                lstprnt.Attributes.Add("onkeydown", "javascript:return onclick_pcenter(event)");
                lstprnt.Attributes.Add("onclick", "javascript:return onclick_pcenter(event)");

                txtbranch.Attributes.Add("onkeydown", "javascript:return fill_branch(event)");
                lstbrn.Attributes.Add("onkeydown", "javascript:return onclick_branch(event)");
                lstbrn.Attributes.Add("onclick", "javascript:return onclick_branch(event)");
                btnresult.Attributes.Add("onclick", "javascript:return show_result(event)");
                btnexcel.Attributes.Add("onclick", "javascript:return show_excel(event)");
                bind_difference();

                Graph1();
               
            }
        }
    }


    public void bind_difference()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Help_Page.xml"));
        ListItem li = new ListItem();
        li.Text = "--Select Difference Type--";
        li.Value = "0";
        helping.Items.Add(li);
        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[0].Rows[0].ItemArray[i].ToString();

           

            helping.Items.Add(li1);
            string value = helping.SelectedValue;
            
        }
       
    }


    [Ajax.AjaxMethod]

    public DataSet fillPubCenter()
    {
        DataSet ds = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Help_Page logindetail2 = new NewAdbooking.Classes.Help_Page();
                ds = logindetail2.getPubCenter();
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Help_page logindetail2 = new NewAdbooking.classesoracle.Help_page();
                ds = logindetail2.getPubCenter();
            }
            

            return ds;


        }
        catch (Exception ex)
        {
            return ds;

        }
    }




    [Ajax.AjaxMethod]

    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Help_Page logindetail1 = new NewAdbooking.Classes.Help_Page();
                ds = logindetail1.getQBC(pubcenter);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Help_page logindetail1 = new NewAdbooking.classesoracle.Help_page();
                 ds = logindetail1.getQBC(pubcenter);
            }
           

            return ds;


        }
        catch (Exception ex)
        {
            return ds;

        }
    }


    [Ajax.AjaxMethod]

    public DataSet fillCompany(string dtfrmat1, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        try
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Help_Page logindetail = new NewAdbooking.Classes.Help_Page();
                ds = logindetail.getCompany();
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Help_page logindetail = new NewAdbooking.classesoracle.Help_page();
                ds = logindetail.getCompany(dtfrmat1, extra1, extra2);
            }
           

            return ds;


        }
        catch (Exception ex)
        {
            return ds;

        }
    }



    private void Graph1()
    {
        string var = helping.SelectedValue;
        if (dd1.SelectedIndex == 0)
        { differenceofvalue = ""; }
        else
        {
            differenceofvalue = dd1.SelectedItem.Text;
        }

        DataSet ds = new DataSet();
    
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Help_Page obj = new NewAdbooking.Classes.Help_Page();
            ds = obj.mis_health_chk(compcode.Value, "", "", var, dtfrmat1, "", "", differenceofvalue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Help_page obj = new NewAdbooking.classesoracle.Help_page();
            ds = obj.mis_health_chk(compcode.Value, "", "", var, dtfrmat1, "", "", differenceofvalue);
        }

       
      //  DataGrid1.Visible = false;
   
        //DataGrid1.DataSource = ds;
        //DataGrid1.DataBind();

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]

     public DataSet showresultgrid(string comp_code,string print_center, string branch_code,string diff_type,string dateformat,string extra1,string extra2,string diff_value)
    
    { 
        DataSet ds = new DataSet();
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Help_Page obj = new NewAdbooking.Classes.Help_Page();

            ds = obj.mis_health_chk( comp_code, print_center,  branch_code, diff_type, dateformat, extra1, extra2, diff_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Help_page obj = new NewAdbooking.classesoracle.Help_page();

            ds = obj.mis_health_chk(comp_code, print_center, branch_code, diff_type, dateformat, extra1, extra2, diff_value);
           
        }
        //if (function == 1)
        //{
        //    grid3.Visible = true;
        //    grid3.DataSource = ds;
        //    grid3.DataBind();
        //}
        return ds;
    }

    
       

}
