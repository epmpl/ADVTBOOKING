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
public partial class issuewisereport : System.Web.UI.Page
{
    string compcode, userid, dateformat;
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

        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        
        hiddencompcode.Value = Session["compcode"].ToString();
        compcode = hiddencompcode.Value;
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        userid = hiddenuserid.Value;
        hiddendateformat.Value = Session["dateformat"].ToString();

        dateformat = hiddendateformat.Value;

        Ajax.Utility.RegisterTypeForAjax(typeof(issuewisereport));

        if (!Page.IsPostBack)
        {
            //bindpubcent();
            bindagencytype();
            bindpubcent();
           // bindbased();

            btnRun.Attributes.Add("OnClick", "javascript:return issuecheck();");
           // btnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");



            Drppubcent.Attributes.Add("onchange", "javascript:return bindedition();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();"); 

           }

        DataSet xml = new DataSet();
        xml.ReadXml(Server.MapPath("XML/Rpt_Daily_listing.xml"));
        Lblpubcent.Text = xml.Tables[3].Rows[0].ItemArray[0].ToString();
        lbDateFrom.Text = xml.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = xml.Tables[0].Rows[0].ItemArray[2].ToString();
       // Lbledition.Text = xml.Tables[3].Rows[0].ItemArray[1].ToString();
        lblbasedon.Text = xml.Tables[3].Rows[0].ItemArray[5].ToString();
        LblDestinationType.Text = xml.Tables[0].Rows[0].ItemArray[5].ToString();
        btnRun.Text = xml.Tables[0].Rows[0].ItemArray[6].ToString();
        lbagtype.Text = xml.Tables[0].Rows[0].ItemArray[9].ToString();
    }

    //public void bindbased()
    //{
    //    DataSet Based= new DataSet();
    //    Based.ReadXml(Server.MapPath("XML/RPt_Daily_listing.xml"));
    //    drpbasedon.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //   // li1.Text = "--Select Based on-";
    //    //li1.Value = "0";
    //    li1.Selected = true;
    //    drpbasedon.Items.Add(li1);

    //    for (i = 6; i < 10; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = Based.Tables[3].Rows[0].ItemArray[i].ToString();
    //        i = i + 1;
    //        li.Value = Based.Tables[3].Rows[0].ItemArray[i].ToString();
    //        drpbasedon.Items.Add(li);

    //    }
    //}
    //public void bindpubcent()
    //{
    //    DataSet ds = new DataSet();
        
    //     if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {
           
    //       // NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
    //        //ds = obj.pub_cent(Session["compcode"].ToString());
    //        NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
    
    //    }
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {


    //        NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
    //        ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());

    //    }
       
    //    int i;
    //    ListItem li;
    //    li = new ListItem();
    //    Drppubcent.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
    //    li.Value = "0";
    //    li.Selected = true;
    //    Drppubcent.Items.Add(li);


    //    if (ds.Tables.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li1;
    //            li1 = new ListItem();
    //            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            Drppubcent.Items.Add(li1);
    //        }
    //    }


    //}

    public void bindpubcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubCentName_r_Bind_PubCentName_r_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
    [Ajax.AjaxMethod]
    public DataSet editionbind(string compcode,string pub_center)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.edition("", pub_center, compcode);

        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {

            NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();
            ds = obj.edition("", pub_center, compcode);

        }
        else
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { "", pub_center, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    
    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string from_date = "";
        string to_date = "";
        DataSet ds = new DataSet();
        string chk_excel = "";
        //string ratio_name = "";
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
        //if (dpd_ratiotyp.SelectedValue == "C")
        //    ratio_name = "Circulation Copy";
        //else
        //    ratio_name = "Edition Ratio";
        string extra1 = drpbasedon.SelectedValue;
        string extra2 = drpreporttype.SelectedValue;
        //extra1 = Request.QueryString["drpbasedon"].ToString();
        //extra2 = Request.QueryString["drpreporttype"].ToString();

        string dpagtypet = "";

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.RO_Agency_Wise obj = new NewAdbooking.Report.classesoracle.RO_Agency_Wise();
            ds = obj.issuereport_ro(Session["compcode"].ToString(), txtfrmdate.Text, txttodate1.Text, Drppubcent.SelectedValue, hdnedition.Value, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), dpd_ratiotyp.SelectedValue, extra1, extra2, dpagtype.SelectedItem.Text);

        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
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
            ds = obj.issuereport(Session["compcode"].ToString(), from_date, to_date, Drppubcent.SelectedValue, hdnedition.Value, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), dpagtype.SelectedItem.Text);

        }
        else 
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfrmdate.Text);
                to_date = DMYToMDY(txttodate1.Text);
            }
            if (dpagtype.SelectedItem.Text == "--Select AgencyType--")
            {
                dpagtypet = "";
            }
            
            string procedureName = "rpt_issue_pcentre_wise_rpt_issue_pcentre_wise_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //  string[] parameterValueArray = new string[] { Session["compcode"].ToString(), from_date, to_date, Drppubcent.SelectedValue, hdnedition.Value, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), dpagtype.SelectedItem.Text };
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), txtfrmdate.Text, txttodate1.Text, Drppubcent.SelectedValue, hdnedition.Value, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), dpd_ratiotyp.SelectedValue, extra1, extra2, dpagtypet };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables.Count == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(issuewisereport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else if (ds.Tables[0].Rows.Count == 0 )
        {
           
            ScriptManager.RegisterClientScriptBlock(this, typeof(issuewisereport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["issueprintcent"] = ds;
            Session["prm_issueprintcent"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~pubcentcode~" + Drppubcent.SelectedValue + "~edition~" + hdnedition.Value + "~editionname~" + hdneditionname.Value + "~pubcentname~" + Drppubcent.SelectedItem.Text + "~chk_excel~" + chk_excel + "~ratio_type~" + dpd_ratiotyp.SelectedValue + "~extra1~" + drpbasedon.SelectedValue + "~extra2~" + drpreporttype.SelectedValue + "~ratio_name~" + dpd_ratiotyp.SelectedItem.Text;
            Response.Redirect("issuewiseview.aspx");
           // Response.Redirect("issuewiseview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcentcode=" + Drppubcent.SelectedValue + "&edition=" + hdnedition.Value + "&editionname=" + hdneditionname.Value + "&pubcentname=" + Drppubcent.SelectedItem.Text);
        }
    }

    public void bindagencytype()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.billregister obj = new NewAdbooking.Report.Classes.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());

        }
        else 
        {
            string procedureName = "Websp_agent_Websp_agent_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li;
        li = new ListItem();
        dpagtype.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpagtype.Items.Add(li);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagtype.Items.Add(li2);


        }
    }

}
