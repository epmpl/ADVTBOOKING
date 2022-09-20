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

public partial class  agencyclient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["compcode"] = "HT001";
        //Session["dateformat"] = "mm/dd/yyyy";
         //Ajax.Utility.RegisterTypeForAjax(typeof(agencyclient));
        Ajax.Utility.RegisterTypeForAjax(typeof(agencyclient));
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/agencyclient.xml"));
        
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
       
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();

        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        if (!Page.IsPostBack)
        {

            bindpub();
            publicationbind();
            bindagecli();
            binddest();
            bindadtype();
            edition();

            BtnRun.Attributes.Add("OnClick", "javascript:return allagency_f24354();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate();");
         txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

         txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            dpaddtype.Attributes.Add("OnChange", "javascript:return bindadcategoryclientfclkient();");

            //BtnRun.Attributes.Add("OnClick", "javascript:return runclick3();");
            //BtnRun.Attributes.Add("OnClick", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onblur", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txttodate1.Attributes.Add("OnBlur", "javascript:return RetCheckdate_currtill(txttodate1);");
            //txtfrmdate.Attributes.Add("OnBlur", "javascript:return RetCheckdate1_currtill(txtfrmdate);");
           
            

        }
   }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        //string str = "";
        //string  str1 = ""; 
        //for (int i = 1; i < dpadcatgory.Items.Count; i++)
        //{

        //    if (dpadcatgory.Items[i].Selected == true)
        //    {
        //        if (str == "")
        //        {
        //            str = dpadcatgory.Items[i].Value;
        //        }
        //        else
        //        {
        //            str = str + "," + dpadcatgory.Items[i].Value;
        //            str1 = str1 + "," + dpadcatgory.Items[i].Text;
        //        }
        //    }
        //}

        string chk_excel = "";
        string from_date = "";
        string to_date = "";
        string str2 = "";

        string category = "";
        string str = "";
        string str1 = "";
        string agency = "";
        string agname = "";
        str = hiddenadcat.Value;
        str1 = hiddenadcatname.Value;


        //if (ChekAgency.Checked == true)
        //{
        //    str2 = "true";

        //}
        //else
        //{
        //    str2 = "false";
        //}

        //if (Txtdest.SelectedValue == "4")
        //{
        //    if (exe.Checked == true)
        //    {
        //        chk_excel = "1";//excel
        //    }
        //    else
        //    {
        //        chk_excel = "2";//csv
        //    }

        //}
        //else
        //{
        //    chk_excel = "0";//other than excel
        //}


        // category = dpadcatgory.Text;


        agency = hiddenagencycode.Value;
        agname = hiddenclientname.Value;

        string agencychk = "";//, clientchk="";
        if (dpagencycli.Text == "")
        {
            agencychk = "";
            hiddenclientname.Value = "";
            hdnagencytxt.Value = "";
        }
        else
            agencychk = hiddenclientname.Value;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //ds = obj.spclient(dpagencycli.SelectedValue, dpaddtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedItem.Text, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            ds = obj.spclient(agency, dpaddtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
          //  ds = obj.spclient(dpagencycli.SelectedValue, dpaddtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "");
            ds = obj.spAgency(agency, dpaddtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", ""); //, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
        
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "reportnew";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { agency, dpaddtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(agencyclient), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {

            Response.Redirect("Agencycliview.aspx?clientname=" + dpagencycli.SelectedValue + "&adtype=" + dpaddtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&client=" + dpagencycli.SelectedItem.Text + "&adtypename=" + dpaddtype.SelectedItem.Text + "&editionname=" + dpedition.SelectedItem.Text);
        }
        //--------------------------------------------------
        //string str = "";

        //if (Txtdest.SelectedItem.Text == "On Screen")
        //{
        //    Response.Redirect("reportview.aspx?adtype=" + dpagencycli.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publication1=" + dppub1.SelectedItem.Text + "&pubcname=" + dppubcent.SelectedItem);
        //}
        //else if (Txtdest.SelectedItem.Text == "Excel Sheet")
        //{
        //    Response.Redirect("Excelsheet.aspx?adtype=" + dpagencycli.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publication1=" + dppub1.SelectedItem.Text + "&pubcname=" + dppubcent.SelectedItem);
        //}
    }
    protected void dppub1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //int i;
        //ListItem li;
        //li = new ListItem();
        //dpedition.Items.Clear();
        //li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;
        //dpedition.Items.Add(li);


        //if (ds.Tables.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li1;
        //        li1 = new ListItem();
        //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        dpedition.Items.Add(li1);
        //    }
        //}
    }

    //public void edition()
    //{
    //    ListItem li;
    //    li = new ListItem();
    //    dpedition.Items.Clear();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();

    //   // li.Text = "-Select Edition Name-";
    //    li.Value = "0";
    //    li.Selected = true;
    //    dpedition.Items.Add(li);

    //}


    public void edition()
    {

        DataSet ds = new DataSet();

        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }

    /// //////////////////////////////
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass pub_cent2 = new NewAdbooking.classesoracle.reportclass();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "reportnew";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { pub, pub_cent, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass advpub = new NewAdbooking.classesoracle.reportclass();
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
       // li1.Text = "--Select Publication--";
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

    public void bindadtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adtype = new NewAdbooking.Classes.Class1();
            ds = adtype.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adtype = new NewAdbooking.classesoracle.reportclass();
            ds = adtype.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
      
        ListItem li1;
        li1=new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //li1.Text="--Select Ad Type--";
        li1.Value = "0";
        li1.Selected=true;
        dpaddtype.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpaddtype.Items.Add(li);


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
       // li1.Text = "--Select Destination--";
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
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass pub_cent1 = new NewAdbooking.classesoracle.reportclass();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "publication_proc_publication_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
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


    }
    public void bindagecli()
    {
       // regionhidden = hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adagencycli = new NewAdbooking.Classes.Class1();
            ds = adagencycli.adagencycli(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adagencycli = new NewAdbooking.classesoracle.reportclass();
            ds = adagencycli.adagencycli(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindclientforcontract_bindclientforcontract_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
    
        ListItem li1;
        li1 = new ListItem();
        dpagencycli.Items.Clear();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
       // li1.Text = "--Select Client Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpagencycli.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpagencycli.Items.Add(li);


        }
    }


    //protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string adtype = dpaddtype.SelectedValue;

    //    dpadcatgory.Items.Clear();
    //    NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = adcat.advtype(adtype, Session["compcode"].ToString());
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "--Select Ad Category--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpadcatgory.Items.Add(li1);

    //    //dpadcatgory.Items.Clear();
    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpadcatgory.Items.Add(li);



    //    }
    //}
    protected void dpadcatgory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getCategory(string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adcat = new NewAdbooking.classesoracle.reportclass();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_BINDADCATEGORY_RA_BINDADCATEGORY_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { adtype, Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    protected void dpaddtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpaddtype.SelectedValue;

        dpadcatgory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adcat = new NewAdbooking.classesoracle.reportclass();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { adtype, Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
         DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
            li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
       // li1.Text = "--Select Ad Category--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpadcatgory.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadcatgory.Items.Add(li);



        }
        ScriptManager.RegisterClientScriptBlock(this, typeof(agencyclient), "sa", "document.getElementById('dpaddtype').focus();", true);
    }
    protected void dppubcent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //int i;
        //ListItem li;
        //li = new ListItem();
        //dpedition.Items.Clear();
        //li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;
        //dpedition.Items.Add(li);


        //if (ds.Tables.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li1;
        //        li1 = new ListItem();
        //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        dpedition.Items.Add(li1);
        //    }
        //}
    }
    protected void dppubcent_SelectedIndexChanged1(object sender, EventArgs e)
    {
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
                ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass pub_cent2 = new NewAdbooking.classesoracle.reportclass();
                ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
            }
            else
            {
                string procedureName = "edition_proc_edition_proc_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
    
            int i;
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


            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1;
                    li1 = new ListItem();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    dpedition.Items.Add(li1);
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, typeof(agencyclient), "sa", "document.getElementById('dppubcent').focus();", true);

        }
    }
}

