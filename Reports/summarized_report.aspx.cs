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
public partial class summarized_report : System.Web.UI.Page
{
    int cont;
    string fromdate;
    string dateto;
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
        
        Ajax.Utility.RegisterTypeForAjax(typeof(summarized_report));
       

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();     
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();

        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
      //  heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();


        if (!Page.IsPostBack)
        {
            edition();
            bindadvtype();
            bindpub();
            binddest();
            publicationbind();



            BtnRun.Attributes.Add("OnClick", "javascript:return daily_summarized();");
            //BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
           // dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");

            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");


            dpedition.Attributes.Add("onkeypress", "return keySort(this);");
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition12();");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition12();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();"); 
        }

    }

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }

    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
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

    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
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
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
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
    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }


    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
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
        // li.Text = "-Select Publication Center-";
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

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
        string hold = "";
        string chk_excel = "";

        if (Txtdest.SelectedValue == "4")
        {
            if (exe.Checked == true)
            {
                chk_excel = "1";//excel
            }
            else
            {
                chk_excel = "2";//csv
            }

        }
        else
        {
            chk_excel = "0";//other than excel
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
            ds = obj.Dailyrep(txtfrmdate.Text, txttodate1.Text, dpdadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), "", "", hiddeneditionname.Value, Session["userid"].ToString(), Session["access"].ToString());
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
            ds = obj.Dailyrep(from_date, to_date, dpdadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), "", "", hiddeneditionname.Value, Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Dailyreport";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { dpdadtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), Session["dateformat"].ToString(), dppub1.SelectedValue, dppubcent.SelectedValue, "", "", hiddeneditionname.Value, Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
          
            ScriptManager.RegisterClientScriptBlock(this, typeof(summarized_report), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["summarize"] = ds;
            Session["prm_summarize"] = "fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~adtype~" + dpdadtype.SelectedValue + "~destination~" + Txtdest.SelectedItem.Value + "~publication~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue + "~edition~" + hiddenedition.Value + "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~editionname~" + hiddeneditionname.Value + "~adtypename~" + dpdadtype.SelectedItem.Text + "~chk_excel~" + chk_excel;
            Response.Redirect("summarized_reportview.aspx");
            //Response.Redirect("summarized_reportview.aspx?fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&adtype=" + dpdadtype.SelectedValue + "&destination=" + Txtdest.SelectedItem.Value + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&edition=" + hiddenedition.Value + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&editionname=" + hiddeneditionname.Value + "&adtypename=" + dpdadtype.SelectedItem.Text);

          
        }
    }





}
