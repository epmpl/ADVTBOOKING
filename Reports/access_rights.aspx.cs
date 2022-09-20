using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Pam_access_rights : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Ajax.Utility.RegisterTypeForAjax(typeof(Pam_access_rights));

        if (Session["compcode"] != null)
        {

            hdncompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["DateFormat"].ToString();
            hiddenusername.Value = Session["Username"].ToString();

        }
        else
        {

            Response.Write("<script>alert('Your Session Has Been Expired');Window.close();</Scrip>");
            return;
        }
        
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/DataTransfer.xml"));

        lblrole.Text = ds.Tables[2].Rows[0].ItemArray[0].ToString();
        lbluser.Text = ds.Tables[2].Rows[0].ItemArray[1].ToString();
      
        linkcenter.Text = ds.Tables[2].Rows[0].ItemArray[12].ToString();
     

        btnsave.Text = ds.Tables[2].Rows[0].ItemArray[15].ToString();
        btnshow.Text = ds.Tables[2].Rows[0].ItemArray[16].ToString();
        btnupdate.Text = ds.Tables[2].Rows[0].ItemArray[17].ToString();
        btnclose1.Text = ds.Tables[2].Rows[0].ItemArray[18].ToString();
        lblcenter.Text = ds.Tables[2].Rows[0].ItemArray[19].ToString();
     
       
        btnsave.Attributes.Add("onclick", "javascript:return savecenter();");
       
        btnshow.Attributes.Add("onclick", "javascript:return showpermission();");
        btnupdate.Attributes.Add("onclick", "javascript:return updatepermission();");
        centall.Attributes.Add("Onclick", "javascript:return selectallcenter();");
        btnclose1.Attributes.Add("Onclick", "javascript:return exitclick1();");
   
        if (!Page.IsPostBack)
        {
            bind_role();
            bind_username();
         
            
        }
    }

    public void bind_role()
    {
        dpdrole.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();
            ds = obj.bind_roll(hdncompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();
            ds = obj.bind_roll(hdncompcode.Value);
        }
        ListItem li = new ListItem();
        li.Text = "--Select Role--";
        li.Value = "0";
        dpdrole.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpdrole.Items.Add(li1);
        }

        
    }

    public void bind_username()
    {
        dpduser.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();
            ds = obj.bind_username(hdncompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();
            ds = obj.bind_username(hdncompcode.Value);
        }
        ListItem li = new ListItem();
        li.Text = "--Select User Name--";
        li.Value = "0";
        dpduser.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpduser.Items.Add(li1);
        }


    }
    
 
    [Ajax.AjaxMethod]
    public DataSet bind_center(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();
            ds = obj.center(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();
            ds = obj.center(compcode);
        }
        return ds;
    }
   
  

    [Ajax.AjaxMethod]
    public DataSet save_centerrights(string rolcod, string newuid, string compcode, string hduid, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();

            ds = obj.save_center(rolcod, newuid, compcode, hduid, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();

            ds = obj.save_center(rolcod, newuid, compcode, hduid, center);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet serachcenter(string role, string user, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();

            ds = obj.search_center(role, user, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();

            ds = obj.search_center(role, user, compcode);
        }
        return ds;
    }
  
    [Ajax.AjaxMethod]
    public DataSet sel_center(string role, string user, string compcode, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();

            ds = obj.select_center(role, user, compcode, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();

            ds = obj.select_center(role, user, compcode, center);
        }
        return ds;
    }
  

    [Ajax.AjaxMethod]
    public DataSet update_center(string role, string user, string compcode, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Roll_mast obj = new NewAdbooking.Report.classesoracle.Roll_mast();

            ds = obj.update_cen(role, user, compcode, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Roll_mast obj = new NewAdbooking.Report.Classes.Roll_mast();

            ds = obj.update_cen(role, user, compcode, center);
        }
        return ds;
    }
}
