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
public partial class pagepreviewreport : System.Web.UI.Page
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

        
        //Ajax.Utility.RegisterTypeForAjax(typeof(agencyclient));

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(pagepreviewreport));
      

     
        
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;

        

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/pagepreviewreport.xml"));
   
       lbpage.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lbposition.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
       
        DataSet dsv = new DataSet();
        dsv.ReadXml(Server.MapPath("XML/disschreg.xml"));
        lbcatgory.Text = dsv.Tables[0].Rows[0].ItemArray[61].ToString();
        lbagtype.Text = dsv.Tables[0].Rows[0].ItemArray[59].ToString();


        DataSet dsw = new DataSet();
        dsw.ReadXml(Server.MapPath("XML/reportagency.xml"));
        agencyname.Text = dsw.Tables[0].Rows[0].ItemArray[0].ToString();

        DataSet dsa = new DataSet();
        dsa.ReadXml(Server.MapPath("XML/agencyclient.xml"));
        lbClient.Text = dsa.Tables[0].Rows[0].ItemArray[0].ToString();

        if (!Page.IsPostBack)
        {

            bindpub();
            publicationbind();
            binddest();
            edition();
            bindpage();
            bindposition();
            bindadtype();
           // bindagency();
           // bindagecli();
            bindagencytype();
          
          // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
          // dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            dppage.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpposition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpclient.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpagency.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpcategory.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpedition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppub1.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppubcent.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            BtnRun.Attributes.Add("OnClick", "javascript:return pagepremnew_f2(event);");
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition6();");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition6();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");


            dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_page(event);");
            dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_page(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaencybb(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaencybb(event);");

            dpclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_pageprem(event);");
            dpclient.Attributes.Add("onkeypress", "javascript:return F2fillclientcr_pageprem(event);");

            lstclient.Attributes.Add("onclick", "javascript:return Clickclientaa(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return Clickclientaa(event);");
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindagencyforxls_bindagencyforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcol, agen };
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcol, cli };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string chk_excel = "";

        string from_date = "";
        string to_date = "";
        string temp1 = "", temp2="", temp3="", temp4="", temp5 = "";
        string hold = "";
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

        string agencychk = "", clientchk = "";
        if (dpagency.Text == "")
        {
            agencychk = "";
            hdnagency1.Value = "";
            hdnagencytxt.Value = "";
        }
        else
            agencychk = hdnagency1.Value;
        if (dpclient.Text == "")
        {
            clientchk = "";
            hdnclienttxt.Value = "";
            hdnclient1.Value = "";
        }
        else
            clientchk = hdnclient1.Value;
          DataSet ds = new DataSet();
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
              ds = obj.spPagepremium(dppage.SelectedValue, dpposition.SelectedValue,from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),agencychk, dpcategory.SelectedValue, temp3, temp4, clientchk, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
              ds = obj.spPagepremium(dppage.SelectedValue, dpposition.SelectedValue, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), agencychk, dpcategory.SelectedValue, temp3, temp4, clientchk, dpagtype.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
       
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
          {
              string procedureName = "pagepremiumreport";
              NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
              //string[] parameterValueArray = { dppage.SelectedValue, dpposition.SelectedValue, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), agencychk, dpcategory.SelectedValue, temp3, temp4, clientchk, dpagtype.SelectedValue, Session["userid"].ToString(), Session["access"].ToString() };
              string[] parameterValueArray = { dppage.SelectedValue, dpposition.SelectedValue, agencychk, clientchk, temp3, dpcategory.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, dppubcent.SelectedValue, temp4, hiddenedition.Value, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dpagtype.SelectedValue, Session["userid"].ToString(), Session["access"].ToString() };
              ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
          }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(pagepreviewreport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["pageprem"] = ds;
            Session["prm_pageprem"] = "page~" + dppage.SelectedValue + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue + "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~destination~" + Txtdest.SelectedItem.Value + "~editionname~" + hiddeneditionname.Value + "~position~" + dpposition.SelectedValue + "~positioncode~" + dpposition.SelectedItem.Text + "~adtypename~" + dpcategory.SelectedItem.Text + "~adtype~" + dpcategory.SelectedValue + "~client~" + clientchk + "~agency~" + agencychk + "~clientname~" + hdnclienttxt.Value + "~agencyname~" + hdnagencytxt.Value + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~chk_excel~" + chk_excel;
                Response.Redirect("pageprview1.aspx");
            //Response.Redirect("pageprview1.aspx?page=" + dppage.SelectedValue + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + hiddenedition.Value + "&destination=" + Txtdest.SelectedItem.Value + "&editionname=" + hiddeneditionname.Value + "&position=" + dpposition.SelectedValue + "&positioncode=" + dpposition.SelectedItem.Text + "&adtypename=" + dpcategory.SelectedItem.Text + "&adtype=" + dpcategory.SelectedValue + "&client=" + dpclient.SelectedValue + "&agency=" + dpagency.SelectedValue + "&clientname=" + dpclient.SelectedItem.Text + "&agencyname=" + dpagency.SelectedItem.Text + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text);

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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Websp_agent";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["userid"].ToString(), Session["compcode"].ToString() };
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
   
    //public void bindagecli()
    //{
        
    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());
    //    }
       
    //    ListItem li1;
    //    li1 = new ListItem();
    //    dpclient.Items.Clear();


    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpclient.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpclient.Items.Add(li);


    //    }
    //}
    //public void bindagency()
    //{
    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {

    //        NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = adagency.agency(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagency.agency(Session["compcode"].ToString());

    //    }
      
      
    //    ListItem li1;
    //    li1 = new ListItem();
    //    dpagency.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();

    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpagency.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        dpagency.Items.Add(li);


    //    }
    //}
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
            string procedureName = "bindpremiumforrate_report_bindpremiumforrate_report_p";
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
else if(ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="orcl")
{
    NewAdbooking.Report.classesoracle.Class1 position = new NewAdbooking.Report.classesoracle.Class1();
    ds = position.bindPagePosition(Session["compcode"].ToString());
}

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_getPagePosition_websp_getPagePosition_p";
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
    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());

        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
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
        li.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
        //li.Text = "-Select Publication Center-";
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
            NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();
            ds = obj.edition(pub, pub_cent, compcode);
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
   
  
}
