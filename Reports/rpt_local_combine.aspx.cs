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
using System.Text.RegularExpressions;
public partial class Reports_rpt_local_combine : System.Web.UI.Page
{
    string dateformate = "";
    string compcode = "";
    string userid = "";
    string compname = "";
    string unitcode = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            dateformate = Session["dateformat"].ToString();
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
            compname = Session["comp_name"].ToString();
            unitcode = Session["center"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_rpt_local_combine));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/local_combine.xml"));
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblbranch.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblpub.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblreporttype.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbldest.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblratetype.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        if (!Page.IsPostBack)
        {
            binddest();
            bindpub();
            bindbranch();
            bindreporttype();
            bindratetype();




            btnsubmit.Attributes.Add("onclick", "javascript:return getreport();");
            btncancel.Attributes.Add("onclick", "javascript:return clear_onload();");
            btnexit.Attributes.Add("onclick", "javascript:return exitclick();");

        }
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/local_combine.xml"));
        drpdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        drpdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;

            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            drpdest.Items.Add(li);

        }


    }

    public void bindreporttype()
    {
        DataSet rprttype = new DataSet();
        rprttype.ReadXml(Server.MapPath("XML/local_combine.xml"));
        drprprttype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Text = "--Select Report type--";
        li1.Value = "0";
        li1.Selected = true;
        drprprttype.Items.Add(li1);

        for (i = 0; i < rprttype.Tables[2].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = rprttype.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;

            li.Text = rprttype.Tables[2].Rows[0].ItemArray[i].ToString();
            drprprttype.Items.Add(li);

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
            NewAdbooking.Report.classesoracle.issuebillreport advpub = new NewAdbooking.Report.classesoracle.issuebillreport();
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
    public DataSet bind_branch1(string userid, string pubcenter, string extra1)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { userid, pubcenter, extra1 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "cir_branch_bind.cir_branch_bind_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "cir_branch_bind_p2";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;


    }

    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "--Select Branch--";
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
    public void bindratetype()
    {
        DataSet ratetype = new DataSet();
        ratetype.ReadXml(Server.MapPath("XML/local_combine.xml"));
        drpratetype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Text = "--Select Rate type--";
        li1.Value = "1";
        li1.Selected = true;
        drpratetype.Items.Add(li1);

        for (i = 0; i < ratetype.Tables[3].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ratetype.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;

            li.Text = ratetype.Tables[3].Rows[0].ItemArray[i].ToString();
            drpratetype.Items.Add(li);

        }
    }

     [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmis_run(string branch, string frdt, string todt, string pub, string dest, string rprttype, string ratetype, string extra1, string extra2, string extra3, string extra4, string extra5)
    { 
        //if (dateformate == "dd/mm/yyyy")
        //        {
        //            string[] arr = frmdt.Split('/');
        //            string dd = arr[0];
        //            string mm = arr[1];
        //            string yy = arr[2];
        //            frmdt = mm + "/" + dd + "/" + yy;
        //        }
        //        prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
        //    }
        Session["frdt"] = frdt;
        Session["todt"] = todt;
        Session["branch"] = branch;
       
        Session["pub"] = pub;
      
        Session["dest"] = dest;
        Session["rprttype"] = rprttype;
        Session["ratetype"] = ratetype;
     
        Session["extra1"] = extra1;
        Session["extra2"] = extra2;
        Session["extra3"] = extra3;
        Session["extra4"] = extra4;
        Session["extra5"] = extra5;
        //Session["branchname"] = branchname;
        //Session["pubname"] = pubname;
        

    }

}

