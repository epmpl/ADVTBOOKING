using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class AttendenceRegister : System.Web.UI.Page
{
    //static string YMDToMDY(string input)
    //{
    //    //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
    //    return Regex.Replace(input,
    //        "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
    //        "${month}/${day}/${year}");
    //}
    //static string DMYToMDY(string input)
    //{
    //    //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
    //    return Regex.Replace(input,
    //        "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
    //        "${month}/${day}/${year}");
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["dateformat"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                Session["access"] = "0";
                hiddendateformat.Value = Session["dateformat"].ToString();
                hdncompcode.Value = Session["compcode"].ToString();
                hiddencompcode.Value = Session["compcode"].ToString();
            }
          
           Ajax.Utility.RegisterTypeForAjax(typeof(AttendenceRegister));
           
            DataSet dsG = new DataSet();
            dsG.ReadXml(Server.MapPath("XML/AttendenceRegister.xml"));
           heading.Text = dsG.Tables[1].Rows[0].ItemArray[0].ToString();
           lbl_branch.Text = dsG.Tables[1].Rows[0].ItemArray[1].ToString();
           btnallbilled.Text = dsG.Tables[1].Rows[0].ItemArray[2].ToString();

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

            lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
          
            lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
           
            BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        
            lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            editiondetail.Text = ds.Tables[0].Rows[0].ItemArray[64].ToString();
            status.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
           // lbl_branch.Text = "Branch";
            DataSet dsr = new DataSet();
            dsr.ReadXml(Server.MapPath("XML/billbook.xml"));
            suppliment.Text = dsr.Tables[0].Rows[0].ItemArray[3].ToString();
            if (!IsPostBack)
            {
                bindadvtype();
                //binddest();
                bindpub();
                bindstatus();
                publicationbind();
                bindedidetail();
                bindbranch();

                BtnRun.Attributes.Add("OnClick", "javascript:return forreport();");
                btnallbilled.Attributes.Add("OnClick", "javascript:return forreportbilled();");
             
                dpedition.Attributes.Add("onchange", "javascript:return suppforschedule();");

                dpaddtype.Attributes.Add("onchange", "javascript:return bindadcat_schedule();");
                dppubcent.Attributes.Add("onchange", "javascript:return bind_edition_sch();");
                dppub1.Attributes.Add("onchange", "javascript:return bind_edition_sch();");
                dpadcatgory.Attributes.Add("onchange", "javascript:return adsubcat_bind();");
       
                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                //dpsuppliment.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                //dpedition.Attributes.Add("onkeypress", "return keySort(this);");
                //Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
                //exe.Attributes.Add("onclick", "javascript:return enable_exe();");
                //csv.Attributes.Add("onclick", "javascript:return enable_csv();");
                drppackagedetail.Attributes.Add("onchange", "javascript:return enable_pkg();");
              
                drppackage.Enabled = false;
                bindpackagedetailreq();
                string datewise = DateTime.Now.ToString();
                //if (datewise.IndexOf(' ') > -1)
                //{
                //    string[] datewise1 = datewise.Split(' ');
                //    string[] datewise2 = datewise1[0].Split('/');
                //    string mo = datewise2[0];
                //    string da = datewise2[1];
                //    string ye = datewise2[2];
                //    if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                //    {
                //        datewise = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                //    }
                //    else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                //    {

                //        datewise = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                //    }
                //    else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                //    {

                //        datewise = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                //    }
                //    //datewise = da + "/" + mo + "/" + ye;
                //}
                txtfrmdate.Text = datewise;
                txttodate1.Text = datewise;
              
     }
 }
    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubName.Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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
        dppub1.SelectedValue = Session["center"].ToString();
    }
    public void bindbranch()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
        else
        {
            string procedureName = "branchbind_adv.branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }
        dpd_branch.SelectedValue = Session["revenue"].ToString();
    }

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
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
            string procedureName = "pubcent_proc.pubcent_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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
  
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "RA_adbindcategory.RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
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



    //public void binddest()
    //{
    //    DataSet destination = new DataSet();
    //    destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
    //    DataSet ds = new DataSet();
    //    ds.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //    Txtdest.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    Txtdest.Items.Add(li1);

    //    for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
    //        i = i + 1;
    //        li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
    //        Txtdest.Items.Add(li);

    //    }


    //}


    public void bindedidetail()
    {
        DataSet edidetail = new DataSet();
        edidetail.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        dpedidetail.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        li1.Value = "0";
        li1.Selected = true;
        dpedidetail.Items.Add(li1);

        for (i = 0; i < edidetail.Tables[13].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = edidetail.Tables[13].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = edidetail.Tables[13].Rows[0].ItemArray[i].ToString();
            dpedidetail.Items.Add(li);

        }
    }
    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));

    }


    public void bindpackagedetailreq()
    {


        //   int i;
        drppackagedetail.Items.Clear();

        ListItem li;
        li = new ListItem();
        li.Text = "No";
        li.Value = "0";
        drppackagedetail.Items.Add(li);

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Yes";
        li1.Value = "1";
        drppackagedetail.Items.Add(li1);




    }
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { pub, pub_cent, compcode };
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
        else
        {
            string procedureName = "edition_proc.edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet adpkg_bind(string adtype, string compcode)
    { 
        DataSet ds4 = new DataSet();
        string[] parameterValueArray = new string[] { adtype, compcode };
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds4 = adcat.package_report(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat1 = new NewAdbooking.Report.classesoracle.Class1();
            ds4 = adcat1.package_report(compcode, adtype);
        }
        else
        {
            string procedureName = "bindpackagereport.bindpackagereport_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds4 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds4;

    }
    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { adtype, compcode };
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
        else
        {
            string procedureName = "RA_bindadcategory.RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, edition };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.pubsupply(compcode, edition);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.pubsupply(compcode, edition);
        }
        else
        {
            string procedureName = "bindsuppliment.bindsuppliment_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    
    protected void drppackagedetail_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (drppackagedetail.SelectedValue == "1")
        {
            drppackage.Enabled = true;
            dppub1.Enabled = false;
            dppubcent.Enabled = false;
            dpsuppliment.Enabled = false;
            dpedition.Enabled = false;

            dppub1.SelectedValue = "0";
            dppubcent.SelectedValue = "0";
            dpsuppliment.SelectedValue = "0";
            dpedition.SelectedValue = "0";
        }
        else
        {
            dppub1.Enabled = true;
            dppubcent.Enabled = true;
            dpsuppliment.Enabled = true;
            dpedition.Enabled = true;
            drppackage.Enabled = false;

            drppackage.SelectedValue = "0";
        }

    }
    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtye)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, adtye };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else
        {
            string procedureName = "uomadsize.uomadsize_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bind_adsubcat(string newstr, string newstr1)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { newstr, newstr1 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT adsubcat = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = adsubcat.bindadsubcat(newstr);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adsubcat = new NewAdbooking.Report.Classes.Class1();
            ds = adsubcat.bindadsubcat(newstr);
        }
        else
        {
            string procedureName = "adsubcategory.adsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }
}
