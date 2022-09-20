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

public partial class publish_status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Session["compcode"] = "HT001";
       // Session["dateformat"] = "mm/dd/yyyy";

        Ajax.Utility.RegisterTypeForAjax(typeof(publish_status));
        hiddendateformat.Value = Session["dateformat"].ToString();
        if (!Page.IsPostBack)
        {
            bindadvtype();
            bindrev();
        }
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();

        btnsubmit.Attributes.Add("onclick", "javascript:return checkboxid()");
        BtnRun.Attributes.Add("onclick", "javascript:return chekvalidaton()");
        txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
        txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

        // heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();

    }
    
    
     public void BtnRun_Click (object sender, EventArgs e)
    { 
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.publish_status abc = new NewAdbooking.BillingClass.classesoracle.publish_status();

            ds = abc.websp_updatestatus(Session["dateformat"].ToString(), txttodate1.Text, txtfrmdate.Text, dpdadtype.SelectedValue, dprev.SelectedValue);

        }
        else
        {
            NewAdbooking.BillingClass.Classes.publish_status abc = new NewAdbooking.BillingClass.Classes.publish_status();

            ds = abc.websp_updatestatus(Session["dateformat"].ToString(), txttodate1.Text, txtfrmdate.Text, dpdadtype.SelectedValue, dprev.SelectedValue);
        }


        Session["RowLen"] = ds.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();
        if (hidden1.Value == "0")
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            //div1.Disabled = true;
            ScriptManager.RegisterClientScriptBlock(this, typeof(publish_status), "cc", "checklenthbill()", true);
            return;



        }


        else
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            // ScriptManager.RegisterClientScriptBlock(this, typeof(updatestatus), "cc", "checkvisible()", true);
            // return;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet updatestatusnew(string bookingid, string insertion, string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_status executebullet = new NewAdbooking.BillingClass.Classes.publish_status();

            ds = executebullet.updatestatusnew(bookingid, insertion, edition);
        }
        else
        {
       

        NewAdbooking.BillingClass.classesoracle.publish_status executebullet = new NewAdbooking.BillingClass.classesoracle.publish_status();

        ds = executebullet.updatestatusnew(bookingid, insertion, edition);
       
        }
        return ds;
    }
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();


            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 advname = new NewAdbooking.classesoracle.Class1();


            ds = advname.adname(Session["compcode"].ToString());
        }
        dpdadtype.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpdadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


        }
    }


    public void bindrev()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.publish_status advpub = new NewAdbooking.BillingClass.Classes.publish_status();
            ds = advpub.bindrevenuecenter(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.publish_status advpub = new NewAdbooking.BillingClass.classesoracle.publish_status();
            ds = advpub.bindrevenuecenter(Session["compcode"].ToString());
        }
        else
        {
        }
        dprev.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[31].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dprev.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dprev.Items.Add(li);


        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
}
