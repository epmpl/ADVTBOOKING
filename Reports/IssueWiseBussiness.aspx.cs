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
using System.Text.RegularExpressions;
public partial class IssueWiseBussiness : System.Web.UI.Page
{
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(IssueWiseBussiness));
      
        
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbpub.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[82].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
         BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();

         DataSet dsY = new DataSet();
         dsY.ReadXml(Server.MapPath("XML/REPORT.xml"));
         lbPublicationCenter.Text = dsY.Tables[0].Rows[0].ItemArray[5].ToString();
         lbadtype.Text = dsY.Tables[0].Rows[0].ItemArray[0].ToString();
         if (!IsPostBack)
         {
             bindpub();
             binddest();
             bindadvtype();
             bindpubcent();
             BtnRun.Attributes.Add("onclick", "javascript:return chkpubnew();");
             txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
             txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

             dppubcent.Attributes.Add("onchange", "javascript:return bind_edition7();");
             dppub1.Attributes.Add("onchange", "javascript:return bind_edition7();");
         }
        
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "--Select Edition Name--";
        //li1.Value = "0";
        //li1.Selected = true;
        //dpedition.Items.Add(li1);
       
    }
   
    public void bindpubcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
        //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
      
         }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "pubcent_proc_pubcent_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
     
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }


        dppubcent.SelectedValue = Session["center"].ToString();
    }
    public void bindadvtype()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";
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
    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
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
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { pub, pub_cent, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
   

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        //for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        for (i = 0; i < destination.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }
     }

    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string from_date = "";
        string to_date = "";
        if (hiddenedition.Value == "--Select Edition Name--")
        {
            hiddenedition.Value = "0";
        }

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
            ds = obj.IssueBusnonscreen(txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, hiddenedition.Value, Session["dateformat"].ToString(), dpdadtype.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfrmdate.Text);
                to_date = DMYToMDY(txttodate1.Text);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                from_date = YMDToMDY(txtfrmdate.Text);
                to_date = YMDToMDY(txttodate1.Text);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            ds = obj.IssueBusnonscreen(from_date, to_date, dppub1.SelectedValue, hiddenedition.Value, Session["dateformat"].ToString(), dpdadtype.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Summaryreport";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
           // string[] parameterValueArray = { txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, hiddenedition.Value, Session["dateformat"].ToString(), dpdadtype.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            string[] parameterValueArray = { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, hiddenedition.Value, dpdadtype.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), null };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(IssueWiseBussiness), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            Session["issuebus"] = ds;
            Session["prm_issuebus"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~edition~" + hiddenedition.Value + "~editionname~" + hiddeneditionname.Value + "~publication~" + dppub1.SelectedValue + "~publicationname~" + dppub1.SelectedItem.Text + "~adtypecode~" + dpdadtype.SelectedValue + "~adtypename~" + dpdadtype.SelectedItem.Text + "~pubcentcode~" + dppubcent.SelectedValue + "~pubcentname~" + dppubcent.SelectedItem.Text;
            Response.Redirect("IssueBusnview.aspx");
//            Response.Redirect("IssueBusnview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&edition=" + hiddenedition.Value + "&editionname=" + hiddeneditionname.Value + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtypecode=" + dpdadtype.SelectedValue + "&adtypename=" + dpdadtype.SelectedItem.Text + "&pubcentcode=" + dppubcent.SelectedValue + "&pubcentname=" + dppubcent.SelectedItem.Text);
        }



    }
}
