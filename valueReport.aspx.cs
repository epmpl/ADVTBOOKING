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
public partial class valueReport : System.Web.UI.Page
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
       // Session["compcode"] = "HT001";
       // Session["dateformat"] = "mm/dd/yyyy";
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
       
       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[74].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
        lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
        lborderby.Text = ds.Tables[0].Rows[0].ItemArray[63].ToString();
        lbexe.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();
        //ad.Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();
        //bill.Text = ds.Tables[0].Rows[0].ItemArray[67].ToString();
        //schedule.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
 
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        DataSet d1s = new DataSet();
        d1s.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = d1s.Tables[0].Rows[0].ItemArray[5].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(valueReport));
        if (!IsPostBack)
        {
            binddest();
            //bindregion();
            //bindproductnamne();
            bindregion();
            bindpublication();
            bindadtype();
            bindorder();
           // bindexecutive();
            publicationbind();
            //BtnRun.Attributes.Add("onclick", "javascript:return runclickbillregister();");
            BtnRun.Attributes.Add("onclick", "javascript:return chkorder_nn_reb();");
           // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            dppublication.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpregion.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpcategory.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            txt_executive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");

            txt_executive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr_reb();");
            txt_executive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr_reb();");

            lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive_reb();");
            lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive_reb();");

        }
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcol, string exectv)
    {
        string tname = "", userid = "";

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
            ds = exec.executivexls(compcol, userid, tname, exectv);
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
    //public void bindexecutive()
    //{
    //    string tname = "";

    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
    //        ds = exec.adexec(Session["compcode"].ToString(), Session["userid"].ToString(), tname);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
    //        ds = exec.adexec(Session["compcode"].ToString(), Session["userid"].ToString(), tname);
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_executive.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        txt_executive.Items.Add(li);


    //    }
    //}
    public void bindpublication()
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
        else
        {
        }

        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppublication.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppublication.Items.Add(li);


        }
    }
    public void bindadtype()
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
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpcategory.Items.Add(li1);


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcategory.Items.Add(li);


        }
    }
    public void bindorder()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dporderby.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[27].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        //li1.Selected = true;
        dporderby.Items.Add(li1);

        for (i = 0; i < destination.Tables[15].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[15].Rows[0].ItemArray[i].ToString();
            // i = i + 1;
            li.Value = destination.Tables[15].Rows[0].ItemArray[i].ToString();
            dporderby.Items.Add(li);

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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objregion = new NewAdbooking.Report.classesoracle.billregister();
            ds = objregion.bindregionname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        //li1.Text = "--Select Region--";
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
    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string from_date = "";
        string to_date = "";
        
        string orderby = dporderby.SelectedValue;
        string temp3 = dpcategory.SelectedValue;
        string temp_category = "", temp_agname = "", temp_pubcent = "", temp_edition = "", temp_state = "", temp_district = "", temp_client = "", temp_newcategory = "";
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
        DataSet ds = new DataSet();
       
     
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.rebatebilling(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dppublication.SelectedValue, temp_category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, temp_edition, hdnexecode.Value , temp_state, temp_district, temp_client, temp_newcategory, orderby, Session["userid"].ToString(), Session["access"].ToString());
                                  
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
            ds = obj.rebatebilling(from_date, to_date, dpregion.SelectedValue, dppublication.SelectedValue, temp_category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, temp_edition, hdnexecode.Value, temp_state, temp_district, temp_client, temp_newcategory, orderby, Session["userid"].ToString(), Session["access"].ToString());
          
        }
        if (ds.Tables[0].Rows.Count == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(valueReport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;
            Session["rebaterep"] = ds;
            Session["prm_rebaterep"] = "regcode~" + dpregion.SelectedValue + "~region~" + dpregion.SelectedItem.Text + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + Txtdest.SelectedItem.Value + "~orderby~" + dporderby.SelectedValue + "~adtype~" + dpcategory.SelectedValue + "~adtypename~" + dpcategory.SelectedItem.Text + "~publication~" + dppublication.SelectedValue + "~publname~" + dppublication.SelectedItem.Text + "~exename~" + txt_executive.Text + "~execode~" + hdnexecode.Value + "~chk_excel~" + chk_excel;
            Response.Redirect("valueReportview.aspx");
//            Response.Redirect("valueReportview.aspx?regcode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&orderby=" + dporderby.SelectedValue + "&adtype=" + dpcategory.SelectedValue + "&adtypename=" + dpcategory.SelectedItem.Text + "&publication=" + dppublication.SelectedValue + "&publname=" + dppublication.SelectedItem.Text + "&exename=" + txt_executive.SelectedItem.Text + "&execode=" + txt_executive.SelectedValue);
        }

    }
}

