using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Reports_Issuebillwise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }


        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_Issuebillwise));
        DataSet xml = new DataSet();
        xml.ReadXml(Server.MapPath("XML/issuebillwise.xml"));
        Lblprincent.Text = xml.Tables[0].Rows[0].ItemArray[2].ToString();
        lbDateFrom.Text = xml.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = xml.Tables[0].Rows[0].ItemArray[1].ToString();
        lblmanedtn.Text = xml.Tables[0].Rows[0].ItemArray[5].ToString();
        lblbranch.Text = xml.Tables[0].Rows[0].ItemArray[3].ToString();
        lblpublication.Text = xml.Tables[0].Rows[0].ItemArray[4].ToString();
        lbldistrict.Text = xml.Tables[0].Rows[0].ItemArray[6].ToString();
        LblDestinationType.Text = xml.Tables[0].Rows[0].ItemArray[7].ToString();
        btnRun.Text = xml.Tables[0].Rows[0].ItemArray[8].ToString();

        if (!Page.IsPostBack)
        {
            dppub1.Attributes.Add("OnChange", "javascript:return bindedtn();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            bindpubcent();
            binddistrict();
            bindbranch();
            bindpub();
        }
    }

    public void bindpubcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillwise pub_cent1 = new NewAdbooking.Report.classesoracle.issuebillwise();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillwise pub_cent1 = new NewAdbooking.Report.Classes.issuebillwise();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "Select Printing Center";
        li.Selected = true;
        Drppubcent.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            Drppubcent.Items.Add(li1);


        }
    }

    public void binddistrict()
    {
        //regionhidden=hiddenregion.Value;

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillwise pub = new NewAdbooking.Report.classesoracle.issuebillwise();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillwise pub = new NewAdbooking.Report.Classes.issuebillwise();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }


        ListItem li1;
        li1 = new ListItem();

        //    DataSet ds1 = new DataSet();
        //   ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = "Select District";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddldistrict.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            ddldistrict.Items.Add(li);


        }
    }


    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.issuebillwise pub = new NewAdbooking.Report.classesoracle.issuebillwise();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillwise pub = new NewAdbooking.Report.Classes.issuebillwise();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }

    }
    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillwise advpub = new NewAdbooking.Report.Classes.issuebillwise();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillwise advpub = new NewAdbooking.Report.classesoracle.issuebillwise();
            ds = advpub.advpub(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        //li1.Text = "--Select Publication--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li);


        }


    }
    [Ajax.AjaxMethod]
    public DataSet bindedtn(string compcode, string publ_code, string dateformat, string extra1, string extra2)
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.issuebillwise advpub = new NewAdbooking.Report.Classes.issuebillwise();
            ds = advpub.pub_Edtn(compcode, publ_code, dateformat, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.issuebillwise advpub = new NewAdbooking.Report.classesoracle.issuebillwise();
            ds = advpub.pub_Edtn(compcode, publ_code, dateformat, extra1, extra2);
        }

        return ds;


    }
}
