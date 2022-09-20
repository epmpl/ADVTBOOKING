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
public partial class picontractreport : System.Web.UI.Page
{
    string fromdt = "";
    string dateto  = "";
    string dateto1 = "";
    string datefrom1 = "";
    string uom = "";
    string reporttype;
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
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;

        Ajax.Utility.RegisterTypeForAjax(typeof(picontractreport));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();


        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
       
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        DataSet d2s = new DataSet();
        d2s.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = d2s.Tables[0].Rows[0].ItemArray[5].ToString();
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();
           // bindclient1();
          //  bindagency1();
            bindadcat();
            publicationbind();

            BtnRun.Attributes.Add("onclick", "javascript:return allads_nn_picon();");
            
           // dpproduct.Attributes.Add("onfocus", "javascript:return checkrundate1();");
          
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
        
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            txt_agency.Attributes.Add("onkeypress", "return keySort(this);");
            txt_client.Attributes.Add("onkeypress", "return keySort(this);");
            drpregion.Attributes.Add("onkeypress", "return keySort(this);");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");

            txt_agency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_picon(event);");
            txt_agency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_picon(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency_picon(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency_picon(event);");

            txt_client.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_picon(event);");
            txt_client.Attributes.Add("onkeypress", "javascript:return F2fillclientcr_picon(event);");

            lstclient.Attributes.Add("onclick", "javascript:return Clickclient_picon(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return Clickclient_picon(event);");

        }
        fromdt = txtfrmdate.Text;
        dateto = txttodate1.Text;


        if (fromdt != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                datefrom1 = mm + "/" + dd + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    string day = dt.Day.ToString();
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    datefrom1 = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    string day = dt.Day.ToString();
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    datefrom1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    string day = dt.Day.ToString();
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    datefrom1 = year + "/" + month + "/" + day;
                }
            }
        }
        if (dateto != "")
            {
               

                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {

                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto1 = mm + "/" + dd + "/" + yy;

                    }
                    else
                    {
                        DateTime dt = Convert.ToDateTime(dateto.ToString());
                        if (hiddendateformat.Value == "dd/mm/yyyy")
                        {
                            string day = dt.Day.ToString();
                            string month = dt.Month.ToString();
                            string year = dt.Year.ToString();
                            dateto1 = day + "/" + month + "/" + year;


                        }
                        else if (hiddendateformat.Value == "mm/dd/yyyy")
                        {
                            string day = dt.Day.ToString();
                            string month = dt.Month.ToString();
                            string year = dt.Year.ToString();
                            dateto1 = month + "/" + day + "/" + year;

                        }
                        else if (hiddendateformat.Value == "yyyy/mm/dd")
                        {

                            string day = dt.Day.ToString();
                            string month = dt.Month.ToString();
                            string year = dt.Year.ToString();
                            dateto1 = year + "/" + month + "/" + day;
                        }
                    }
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
            string procedureName = "bindagencyforxls";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcol, agen };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
            string procedureName = "bindclientforxls";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcol, cli };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
            string procedureName = "pubcent_proc";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
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

    //public void bindagency1()
    //{
    //    //regionhidden=hiddenregion.Value;
    //    DataSet ds = new DataSet();
    // if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    // {
    //    NewAdbooking.Report.classesoracle.SHACHIREPORT advpub = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
    //    ds = advpub.bindagency(Session["compcode"].ToString());
    //}
    // else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagency.agency(Session["compcode"].ToString());
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
    //        NewAdbooking.Report.classesoracle.SHACHIREPORT advpub = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
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
    //    else  if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());

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

    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT advpub = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = advpub.bindregion1(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "regionbind_regionbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "--Select Region--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpregion.Items.Add(li);


        }
    }

    public void bindadcat()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.bindadcat1(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT advpub = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = advpub.bindadcat1(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "adcat_adcat_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       
        ListItem li1;
        li1 = new ListItem();

        //DataSet ds1 = new DataSet();
        //ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = "--Select Ad Cat--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcat.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcat.Items.Add(li);


        }
    }


    public void bindproductnamne()
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
        else
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "", temp11 = "", temp12 = "", temp13 = "";
        string str = "";
        string str1 = "";
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


        if (txtfrmdate.Text == "") 
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"Please fill From Date first.\");", true);
            return;
        }
        else if (txttodate1.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"Please fill To Date first.\");", true);
            return;
        }


        for (int i = 1; i < dpproduct.Items.Count; i++)
        {

            if (dpproduct.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpproduct.Items[i].Value;
                    str1 = dpproduct.Items[i].Text;
                }
                else
                {
                    str = str + "," + dpproduct.Items[i].Value;
                    str1 = str1 + "," + dpproduct.Items[i].Text;
                }
            }
        }

        string agency = txt_agency.Text;
        string agencycode = hdnagency.Value;
        string client = txt_client.Text;
        string clientcode = hdnclient.Value;
        string region = drpregion.SelectedItem.ToString();
        string regioncode = drpregion.SelectedValue;
        string adcat = drpcat.SelectedItem.ToString();
        string adcatcode = drpcat.SelectedValue;
        


        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

        if (rdsch.Checked == true)
        {
            reporttype = "scheduled";

            NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();

            ds = obj.spcontractreportnew(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (rdbilled.Checked == true)
        {
            reporttype = "billed";
            NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();

            ds = obj.spcontractreportnewbilled(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());

        }
        else
        {
          //  Response.Redirect("<script>alert('Please select one radio button.')</script>");
            ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"Please select one radio button.\");", true);
            return;
        }

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

            if (rdsch.Checked == true)
            {
                reporttype = "scheduled";

                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();

                //ds = obj.spcontractreportnew(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString());
                ds = obj.spcontractreportnew(from_date, to_date, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());


            }
            else if (rdbilled.Checked == true)
            {
                reporttype = "billed";
                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                // ds = obj.spcontractreportnewbilled(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString());
                ds = obj.spcontractreportnewbilled(from_date, to_date, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"Please select one radio button.\");", true);
                return;
            }
        }
        else
        {
            if (rdsch.Checked == true)
            {
                reporttype = "scheduled";

                string procedureName = "SHACHI_PICONTRACT_REPORT";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

               // NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();

               // ds = obj.spcontractreportnew(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
            }
            else if (rdbilled.Checked == true)
            {
                reporttype = "billed";

                string procedureName = "SHACHI_PICONTRACT_REPORTbilled";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

                //NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();

                //ds = obj.spcontractreportnewbilled(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hdnagency.Value, hdnclient.Value, drpregion.SelectedValue, drpcat.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());

            }
            else
            {
                //  Response.Redirect("<script>alert('Please select one radio button.')</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"Please select one radio button.\");", true);
                return;
            }
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
             ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;
            Session["picontract"] = ds;
            Session["prm_picontract"] = "fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + Txtdest.SelectedItem.Value + "~prodcode~" + str + "~product~" + str1 + "~agency~" + agency + "~agencycode~" + agencycode + "~client~" + client + "~clientcode~" + clientcode + "~region~" + region + "~regioncode~" + regioncode + "~adcat~" + adcat + "~adcatcode~" + adcatcode + "~reporttype~" + reporttype + "~chk_excel~" + chk_excel;
                Response.Redirect("picontractviewreport.aspx");
//            Response.Redirect("picontractviewreport.aspx?&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&prodcode=" + str + "&product=" + str1 + "&agency=" + agency + "&agencycode=" + agencycode + "&client=" + client + "&clientcode=" + clientcode + "&region=" + region + "&regioncode=" + regioncode + "&adcat=" + adcat + "&adcatcode=" + adcatcode + "&reporttype=" + reporttype );
                return;
        }
    }

       
    }
