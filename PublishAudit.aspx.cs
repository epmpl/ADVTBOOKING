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
using System.Data.SqlClient;

public partial class PublishAudit : System.Web.UI.Page
{
    int j = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnPublish.Visible = true;
         //Session["compcode"] = "HT001";

         
         if (Session["compcode"] == null)
         {
             Response.Redirect("login.aspx");
             Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
             return;
         }
         hiddendateformat.Value = Session["dateformat"].ToString();
        hiddencomcode.Value = Session["compcode"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(PublishAudit));
        if (!Page.IsPostBack)
        {
            //form1.Attributes.Add("onload", "javascript:return display();");
            btnPublish.Attributes.Add("OnClick", "javascript:return publishAudit();");
            txtvalidityfrom.Attributes.Add("OnClick", "javascript:return popUpCalendar(this,form1.txtvalidityfrom,hiddendateformat.Value);");
            txttilldate.Attributes.Add("OnClick", "javascript:return popUpCalendar(this,form1.txttilldate,hiddendateformat.Value);");
            txtvalidityfrom.Attributes.Add("Onkeypress", "javascript:return clientdate();  ");
            //txtvalidityfrom.Attributes.Add("OnBlur", "javascript:return Checkdate(this);");
            txttilldate.Attributes.Add("Onkeypress", "javascript:return clientdate();  ");
            //txttilldate.Attributes.Add("OnBlur", "javascript:return Checkdate(this);");
            btnclear.Attributes.Add("OnClick", "javascript:return cleardata();");
            drpcenter.Attributes.Add("OnChange", "javascript:return bindQBC();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return executeclick();");
            adtypedata(Session["compcode"].ToString());
            fillPubCenter();
        }
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Booking_Audit1.xml"));
        lblvfrm.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblvalidtill.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
    
        
    }
    //[Ajax.AjaxMethod]
    //public DataSet refreshgrid(string comcode, string dateformat, string tilldate, string fromdate, string publication, string adtype, string branch)
    //{
    //    DataSet ds = new DataSet();
    //    //string revcenter = drpcenter.SelectedValue;
    //   // string branch = drpbranch.SelectedValue;
    //    if (branch != "0" && branch != "")
    //    {
    //        branch = drpbranch.SelectedItem.Text;
    //    }
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        //    NewAdbooking.Classes.PublishAudit abc = new NewAdbooking.Classes.PublishAudit();
    //        //    ds = abc.bindgrid(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue);
    //    }
    //    else
    //    {
    //        NewAdbooking.classesoracle.PublishAudit abc = new NewAdbooking.classesoracle.PublishAudit();
    //        ds = abc.bindgrid(comcode, dateformat, tilldate, fromdate, publication, adtype, branch);
    //    }

    //    return ds;


    //    //Session["RowLen"] = ds.Tables[0].Rows.Count;
    //   /* DataGrid1.DataSource = ds;
    //    .DataBind();

    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        DataGrid1.Visible = true;
    //        btnPublish.Visible = false;
    //    }*/
       
    //}
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string revcenter = drpcenter.SelectedValue;
        string branch = hiddenbranch.Value;
        //if (branch != "0" &&  branch != "")
        //{
        //    //branch = drpbranch.SelectedItem.Text;
        //}
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.PublishAudit abc = new NewAdbooking.Classes.PublishAudit();
            ds = abc.bindgrid(Session["compcode"].ToString(), Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, branch);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PublishAudit abc = new NewAdbooking.classesoracle.PublishAudit();
                ds = abc.bindgrid(Session["compcode"].ToString(), Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, branch);
            }
            else
            {
                NewAdbooking.classmysql.PublishAudit abc = new NewAdbooking.classmysql.PublishAudit();
                ds = abc.bindgrid(Session["compcode"].ToString(), Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, branch);
            }




        //Session["RowLen"] = ds.Tables[0].Rows.Count;
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

        if (ds.Tables[0].Rows.Count == 0)
        {
            DataGrid1.Visible = true;
            btnPublish.Visible = false;
        }
        else

            btnPublish.Visible = true;
        //DataGrid1.Visible = true; 
    }
    //protected void btnclear_Click(object sender, EventArgs e)
    //{
    //    //txttilldate.Text = "";
    //    //txtvalidityfrom.Text = "";
    //    //drpadtype.SelectedValue = "0";
    //    //drpcenter.SelectedValue = "0";
    //    //drpbranch.Items.Clear();
    //    ////=====================
    //    //ListItem li1;
    //    //li1 = new ListItem();
    //    //li1.Text = "Select Branch";
    //    //li1.Value = "0";
    //    //li1.Selected = true;
    //    //drpbranch.Items.Add(li1);


    //    //drpbranch.SelectedValue = "0";
    //}
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string str = "chk" + j;
            
                e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "   value=" + e.Item.Cells[6].Text + "  />";
            
            j++;
            e.Item.Cells[6].Visible = true;
            

           

        }
        
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    private void fillPubCenter()
    {
        DataSet ds;
        drpcenter.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();

            ds = logindetail.getPubCenter();
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();

                ds = logindetail.getPubCenter();

            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getPubCenter();
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drpcenter.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcenter.Items.Add(li);
        }

    }

    [Ajax.AjaxMethod]
    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();

            ds = logindetail.getQBC(pubcenter);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();

                ds = logindetail.getQBC(pubcenter);

            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();

                ds = logindetail.getQBC(pubcenter);


            }
        return ds;
    }

    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 bind = new NewAdbooking.Classes.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
                ds = bind.adtypbind(compcode);
            }
            else
            {
                NewAdbooking.classmysql.PublishAudit bind = new NewAdbooking.classmysql.PublishAudit();
                ds = bind.adtypbind(compcode);
            }



        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }

    }
    [Ajax.AjaxMethod]

     public void updateStatus(string insert_id)
    {
          DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.PublishAudit up = new NewAdbooking.Classes.PublishAudit();
            ds = up.update(insert_id);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PublishAudit up = new NewAdbooking.classesoracle.PublishAudit();
            ds = up.update(insert_id);
        }
        else
        {
            NewAdbooking.classmysql.PublishAudit up = new NewAdbooking.classmysql.PublishAudit();
            ds = up.update(insert_id);
        }

     }
 
    protected void btnPublish_Click1(object sender, EventArgs e)
    {
        btnsubmit_Click(sender, e);
    }
}
