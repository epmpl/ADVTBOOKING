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
public partial class BarterBill : System.Web.UI.Page
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
            hdncompcode.Value = Session["compcode"].ToString();
        }
       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
       // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbbooktype.Text = ds.Tables[0].Rows[0].ItemArray[69].ToString();

        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;

        DataSet des = new DataSet();
        des.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = des.Tables[0].Rows[0].ItemArray[5].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(BarterBill));
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();
            publicationbind();
            //bindclient1();
            //bindagency1();
            bindAdType();


            BtnRun.Attributes.Add("onclick", "javascript:return runclickbarter_bar();");
          //BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
          //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
          //dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
          //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
          //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
          //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
          //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
          //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
          txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
          txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
          Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
          exe.Attributes.Add("onclick", "javascript:return enable_exe();");
          csv.Attributes.Add("onclick", "javascript:return enable_csv();");

          txt_agency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_bar(event);");
          txt_agency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_bar(event);");

          lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency_bar(event);");
          lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency_bar(event);");

          txt_client.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_bar(event);");
          txt_client.Attributes.Add("onkeypress", "javascript:return F2fillclientcr_bar(event);");

          lstclient.Attributes.Add("onclick", "javascript:return Clickclient_bar(event);");
          lstclient.Attributes.Add("onkeydown", "javascript:return Clickclient_bar(event);");

        }
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_CreditAgency(string compcol, string agen)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter adagency = new NewAdbooking.classmysql.Ad_Barter();
            ds = adagency.bindagency(compcol, agen);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string cli)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagencycli.clientxls(compcol, cli);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
            ds = adagencycli.clientxls(compcol, cli);
        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter adagencycli = new NewAdbooking.classmysql.Ad_Barter();
            ds = adagencycli.clientxls(compcol, cli);
        }


        return ds;
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
        else
        {
            NewAdbooking.classmysql.Ad_Barter pub_cent1 = new NewAdbooking.classmysql.Ad_Barter();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());

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

    public void bindAdType()
    {
        DataSet billtyp = new DataSet();
        billtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        drpbooktype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Booking Type";
        li1.Value = "0";
        //li1.Selected = true;
        drpbooktype.Items.Add(li1);

        for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();

            drpbooktype.Items.Add(li);

        }

    }

    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
             ds = objregion.bindregion(Session["compcode"].ToString());
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
         {
             string procedureName = "Sp_Region_sp_region_p";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             string[] parameterValueArray = { Session["compcode"].ToString() };
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }
         else
         {
             NewAdbooking.Report.classesoracle.Class1 objregion = new NewAdbooking.Report.classesoracle.Class1();
             ds = objregion.bindregion(Session["compcode"].ToString());
         }


        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpregion.Items.Add(li);


        }
    }


    public void bindproductnamne()
    {
       

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
        dpproduct.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpproduct.Items.Add(li);


        }

    }

    // -----------bind client  && bind Agency--------------------
    //public void bindclient1()
    //{
    //    //regionhidden=hiddenregion.Value;
    //    DataSet ds = new DataSet();
    //    ListItem li1;
    //    li1 = new ListItem();

    //    li1.Text = "--Select Client--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_client.Items.Add(li1);

    //    int i;
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = advpub.bindclient(Session["compcode"].ToString());

          
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();
    //            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            txt_client.Items.Add(li);


    //        }
    //    }
    //    else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
    //        ds = advpub.adagencycli(Session["compcode"].ToString());
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();
    //            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            txt_client.Items.Add(li);


    //        }
    //    }
    //}

    //public void bindagency1()
    //{
    //    //regionhidden=hiddenregion.Value;
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
    //        ds = advpub.agency(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = advpub.bindagency(Session["compcode"].ToString());
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();

    //    li1.Text = "--Select Agency--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_agency.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        txt_agency.Items.Add(li);


    //    }
    //}
//--------------------------------------------------------------------------------------------//

    
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
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

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
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
            ds = obj.barter_report(from_date,to_date, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value , dpregion.SelectedValue, dpproduct.SelectedValue, drpbooktype.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfrmdate.Text);
                to_date = DMYToMDY(txttodate1.Text);
            }

            string procedureName = "Barter_Report_bill_report_p";
            //NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { from_date, to_date, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, dpregion.SelectedValue, dpproduct.SelectedValue, drpbooktype.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString() };
            //ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            
            NewAdbooking.classmysql.Ad_Barter obj = new NewAdbooking.classmysql.Ad_Barter();
            ds = obj.barter_report(from_date, to_date, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, dpregion.SelectedValue, dpproduct.SelectedValue, drpbooktype.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        }
        else 
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.barter_report(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), hdnclient.Value, hdnagency.Value, dpregion.SelectedValue, dpproduct.SelectedValue, drpbooktype.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        }
        
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(BarterBill), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            Session["barterbill"] = ds;
            Session["prm_barterbill"] = "regcode~" + dpregion.SelectedValue + "~region~" + dpregion.SelectedItem.Text + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + Txtdest.SelectedItem.Value + "~product~" + dpproduct.SelectedValue + "~productname~" + dpproduct.SelectedItem.Text + "~agency~" + hdnagency.Value + "~client~" + hdnclient.Value + "~booktype~" + drpbooktype.SelectedValue + "~chk_excel~" + chk_excel + "~clientname~" + txt_client.Text + "~agencyname~" + txt_agency.Text ;
                Response.Redirect("BarterBillview.aspx");
//            Response.Redirect("BarterBillview.aspx?regcode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&product=" + dpproduct.SelectedValue + "&productname=" + dpproduct.SelectedItem.Text + "&agency=" + txt_agency.SelectedValue + "&client=" + txt_client.SelectedValue + "&booktype=" + drpbooktype.SelectedValue);
        }

    }
 
}




