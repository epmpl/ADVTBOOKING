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
public partial class availablepremium : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(availablepremium));
      
        
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/pagepreviewreport.xml"));

       
        lbpage.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbposition.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
       // lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
      
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();

        DataSet ds2 = new DataSet();
        ds2.ReadXml(Server.MapPath("XML/disschreg.xml"));
        lbPublication.Text = ds2.Tables[0].Rows[0].ItemArray[9].ToString();

        DataSet dps = new DataSet();
        dps.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = dps.Tables[0].Rows[0].ItemArray[5].ToString();
        if (!Page.IsPostBack)
        {
            bindadtype();
            bindpub();
            binddest();
            edition();
            bindpage();
            bindposition();
            publicationbind();
            bindpageno();
            refresh();

            ListItem li1;
            li1 = new ListItem();
            li1.Text = "--Select AdCat--";
            li1.Value = "0";
            dpadcat.Items.Add(li1);

            BtnRun.Attributes.Add("OnClick", "javascript:return btnrunclicknew(event);");
            
          //  dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");


            dppage.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpposition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpedition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppub1.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition11();");
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition11();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");

            dpadtype.Attributes.Add("onchange", "javascript:return bindadcat1();");
            dpadcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");

            
        }
    }
    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { adtype, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    public void bindadtype()
    {

        DataSet ds = new DataSet();
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
        li1.Text = "--Select AdType--";
        li1.Value = "0";
        li1.Selected = true;
        dpadtype.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadtype.Items.Add(li);


        }
    }

    public void bindpageno()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dppageno.Items.Clear();
        int i;


        for (i = 0; i < destination.Tables[16].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[16].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[16].Rows[0].ItemArray[i].ToString();
            dppageno.Items.Add(li);

        }
       

    }

    public void publicationbind()
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

    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        // li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }
    public void bindpage()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 page = new NewAdbooking.Report.Classes.Class1();
            ds = page.premiumbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 page = new NewAdbooking.Report.classesoracle.Class1();

            ds = page.premiumbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "BINDPREMIUMFORRATE_REPORT_BINDPREMIUMFORRATE_REPORT_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[13].ToString();
        //li1.Text = "--Select Page--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppage.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppage.Items.Add(li);


        }


    }
    public void bindposition()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 position = new NewAdbooking.Report.Classes.Class1();
            ds = position.bindPagePosition(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 position = new NewAdbooking.Report.classesoracle.Class1();
            ds = position.bindPagePosition(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "WEBSP_GETPAGEPOSITION_WEBSP_GETPAGEPOSITION_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }




        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();
        // li1.Text = "--Select Position--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpposition.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpposition.Items.Add(li);


        }

    }



    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
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
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string chk_excel = "";
        string from_date = "";
        string to_date = "";
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp_pubcent="";
        string hold = "";
        DataSet ds = new DataSet();
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
        string hadcat = hdnadcat.Value;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();

            ds = obj.availableprem(dppage.SelectedValue, dpposition.SelectedValue, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), dppageno.SelectedValue, dpadtype.SelectedValue, hadcat);
           
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
            //ds = obj.availableprem(dppage.SelectedValue, dpposition.SelectedValue, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), dppubcent.SelectedValue, Session["userid"].ToString());
            ds = obj.availableprem(dppage.SelectedValue, dpposition.SelectedValue, from_date, to_date, dppub1.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), dppageno.SelectedValue, dpadtype.SelectedValue, hadcat);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "report_avilable_dates_report_avilable_dates_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { dppage.SelectedValue, dpposition.SelectedValue, from_date, to_date, dppub1.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), dppageno.SelectedValue, dpadtype.SelectedValue, hadcat };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "gaurav")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(availablepremium), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["availableprem"] = ds;
            Session["prm_availableprem"] = "page~" + dppage.SelectedValue + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~publicname~" + dppub1.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~destination~" + Txtdest.SelectedItem.Value + "~editionname~" + hiddeneditionname.Value + "~position~" + dpposition.SelectedValue + "~positioncode~" + dpposition.SelectedItem.Text + "~chk_excel~" + chk_excel + "~pageno~" + dppageno.SelectedValue + "~adtype~" + dpadtype.SelectedValue + "~adcate~" + hadcat + "~pagename~" + dppage.SelectedItem.Text;
                 Response.Redirect("availablepremiumview.aspx");
//            Response.Redirect("availablepremiumview.aspx?page=" + dppage.SelectedValue + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&edition=" + hiddenedition.Value + "&destination=" + Txtdest.SelectedItem.Value + "&editionname=" + hiddeneditionname.Value + "&position=" + dpposition.SelectedValue + "&positioncode=" + dpposition.SelectedItem.Text);

        }

    }
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
       
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //    ds = obj.bindpubedition(publication);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
        //    //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //}
       
       
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


    protected void refresh()
    {
        dppage.SelectedValue = "0";
        dpposition.SelectedValue = "0";
        dppub1.SelectedValue = "0";
        //dppubcent.SelectedValue = "0";
        dpedition.SelectedValue = "0";
        dppageno.SelectedValue = "0";
        dpadtype.SelectedValue = "0";
        dpadcat.SelectedValue = "0";
        Txtdest.SelectedValue = "0";
        txtfrmdate.Text = "";
        txttodate1.Text = "";
        dppage.Focus();

    }
   
  
}
