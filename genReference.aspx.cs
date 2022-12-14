using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.OracleClient;
using System.Data.Sql;
using NewAdbooking.classmysql;

public partial class genReference : System.Web.UI.Page
{
    string username, userid;
    string dateformat, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenusername.Value = Session["username"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenlogincenter.Value = Session["center"].ToString();
            hiddenclassified_reference.Value = ConfigurationSettings.AppSettings["Classified_Reference_Path"].ToString();
        }
        else
        {
            li.Text = "<script>window.parent.location=\"login.aspx\";</script>";

            return;
        }
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/Ref_file.xml"));
        lblPublicationDate.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblPublication.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lblCenter.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lblEdition.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lblSupplement.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lblFilepath.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnReference.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btnExit.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lblincludeuom.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        lblexcludeuom.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
        lblincludead.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
        lblexcludead.Text = objDataSet.Tables[0].Rows[0].ItemArray[12].ToString();
        lbpackage.Text = objDataSet.Tables[0].Rows[0].ItemArray[13].ToString();
        // txtFilepath.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();

        //if (Session["Center"].ToString() == "MU0")
        //{
        //    txtFilepath.Text = ConfigurationSettings.AppSettings["Mumbai_ref"].ToString();


        //}
        //else if (Session["Center"].ToString() == "RA0")
        //{
        //    txtFilepath.Text = ConfigurationSettings.AppSettings["Ratnagiri_ref"].ToString();
        //}
        //else if (Session["Center"].ToString() == "SI0")
        //{
        //    txtFilepath.Text = ConfigurationSettings.AppSettings["Sindhudurg_ref"].ToString();
        //}

        txtFilepath.Text = ConfigurationSettings.AppSettings["Classified_Reference_Path"].ToString();  //Server.MapPath("") + "\\";

        string ss = hiddenpermission.Value;
        hiddenpermission.Value = "";
        Ajax.Utility.RegisterTypeForAjax(typeof(genReference));

        hiddenusername.Value = Session["Username"].ToString();

        if (Session["Username"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        else
        {
            username = Session["Username"].ToString();
            userid = Session["userid"].ToString();
        }

        if (!Page.IsPostBack)
        {
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            btnReference.Attributes.Add("OnClick", "javascript:return ref_fileclick();");
            ddlCenter.Attributes.Add("OnChange", "javascript:return bindEdition();");
            ddlPublication.Attributes.Add("OnChange", "javascript:return bindEdition();");
            btnCopy.Attributes.Add("onclick", "javascript:return CopyEdition();");
            btnReport.Attributes.Add("OnClick", "javascript:return report_click();");
            Chkpackage.Attributes.Add("onclick", "javascript:return Cheked1();");
            // ddlCenter.Attributes.Add("OnChange", "bindEdition();");

            // disable();
            addpubcode();
            binduom();
            advcat(Session["compcode"].ToString());
            addcentercode();
            // addeditioncode();
            addsecpubcode();
            string ddate = DateTime.Today.AddDays(1).ToShortDateString();
            PubDate.Text = DateTime.Today.AddDays(1).ToShortDateString();
            if (Session["dateformat"].ToString() == "dd/mm/yyyy")
            {
                string[] arr;
                arr = ddate.Split("/".ToCharArray());

                PubDate.Text = arr[1] + "/" + arr[0] + "/" + arr[2];
            }
            else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
            {
                string[] arr;
                arr = ddate.Split("/".ToCharArray());

                PubDate.Text = arr[2] + "/" + arr[0] + "/" + arr[1];
            }
            //  PubDate.Text = DateTime.Today.AddDays(1).ToShortDateString();
            ddlPublication.SelectedIndex = 1;
            // ddlCenter.SelectedIndex = 1;
        }

        DateTime da = DateTime.Now;
        string formname = "genReference";
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            //dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname, Session["qbcselected"].ToString());
            dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            //  dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname, Session["qbcselected"].ToString());
            dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_showpermission_websp_showpermission_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hiddencompcode.Value, hiddenuserid.Value, formname };
            dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        if (dz.Tables[0].Rows.Count > 0)
        {
            id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            if (id == "0" || id == "8")
            {
                hiddenpermission.Value = "zero";
                Response.Write("<script>alert('You Are Not Authorised To See This Form');</script>");
                return;
            }
        }
        hiddenxtgfilepath_local.Value = Server.MapPath("xtg");
        //for fetching xtg local file path
        //if (Session["Center"].ToString() == "MU0")
        //{
        //    hiddenxtgfilepath_local.Value = ConfigurationSettings.AppSettings["Mumbai_xtg"].ToString();


        //}
        //else if (Session["Center"].ToString() == "RA0")
        //{
        //    hiddenxtgfilepath_local.Value = ConfigurationSettings.AppSettings["Ratnagiri_xtg"].ToString();
        //}
        //else if (Session["Center"].ToString() == "SI0")
        //{
        //    hiddenxtgfilepath_local.Value = ConfigurationSettings.AppSettings["Sindhudurg_xtg"].ToString();
        //}

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet ReferenceFileDict(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getReferenceFile objbindFile = new NewAdbooking.Classes.getReferenceFile();
            ds = objbindFile.clsReferenceFileDict(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
            //            ds = objbindFile.clsReferenceFile(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, Session["center"].ToString());
            //for dictionary
            ds = objbindFile.clsReferenceFileDict(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_getReferencefileDict";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, Session["center"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return ds;
    }
    /*
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet ReferenceFile(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string auditad,string includeuom,string excludeuom,string includecat,string excludecat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.getReferenceFile objbindFile = new NewAdbooking.Classes.getReferenceFile();
            ds = objbindFile.clsReferenceFile(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, Session["center"].ToString(), auditad,includeuom,excludeuom,includecat,excludecat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
            ds = objbindFile.clsReferenceFile(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, Session["center"].ToString(), auditad);
        }
        return ds;
    }*/

    [Ajax.AjaxMethod]
    public DataSet getCenterWiseEdition(string compcode, string userid, string center, string pub)
    {
        string chk_value = ConfigurationSettings.AppSettings["LAYOUTX"].ToString();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master objbindFile = new NewAdbooking.classesoracle.Master();
            ds = objbindFile.editioncodecenterwise(compcode, userid, center, pub, chk_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Master objbindFile = new NewAdbooking.Classes.Master();
            ds = objbindFile.editioncodecenterwise(compcode, userid, center, pub, chk_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
           // string procedureName = "websp_addedition_center_B_websp_addedition_center_B";
            string procedureName = "websp_addedition_center_B";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, userid, center, pub, chk_value };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    public void binduom()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binduom = new NewAdbooking.Classes.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "1");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster binduom = new NewAdbooking.classesoracle.RateMaster();
                ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "1");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "binduomforrate_binduomforrate_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), "1" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        drpincludeuom.Items.Clear();
        drpexcludeuom.Items.Clear();
        int i;
        System.Web.UI.WebControls.ListItem li1;
        li1 = new System.Web.UI.WebControls.ListItem();
        li1.Text = "Select UOM";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpincludeuom.Items.Add(li1);
        drpexcludeuom.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.WebControls.ListItem li;
                li = new System.Web.UI.WebControls.ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpincludeuom.Items.Add(li);
                drpexcludeuom.Items.Add(li);
            }
        }
    }
    public void advcat(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategory(compcode, "CL0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bind = new NewAdbooking.classesoracle.BookingMaster();
                ds = bind.advdatacategory(compcode, "CL0");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "book_advcategory1_book_advcategory1_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, "CL0" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

        int i;
        System.Web.UI.WebControls.ListItem li1;
        li1 = new System.Web.UI.WebControls.ListItem();
        drpincludead.Items.Clear();
        drpexcludead.Items.Clear();
        li1.Text = "Select Ad Category";
        li1.Value = "0";
        li1.Selected = true;
        drpincludead.Items.Add(li1);
        drpexcludead.Items.Add(li1);
        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.WebControls.ListItem li;
                li = new System.Web.UI.WebControls.ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpincludead.Items.Add(li);
                drpexcludead.Items.Add(li);
            }
        }
    }
    public void addpubcode()
    {
        string chk_value = ConfigurationSettings.AppSettings["LAYOUTX"].ToString();

        ddlPublication.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master Pripubl = new NewAdbooking.Classes.Master();
            ds = Pripubl.Pripubcode_new(Session["compcode"].ToString(), Session["userid"].ToString(), chk_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master Pripubl = new NewAdbooking.classesoracle.Master();
            ds = Pripubl.Pripubcode(Session["compcode"].ToString(), Session["userid"].ToString(), chk_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Websp_addpubcode_b_Websp_addpubcode1_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), chk_value };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        System.Web.UI.WebControls.ListItem li1;
        li1 = new System.Web.UI.WebControls.ListItem();
        li1.Text = "--Select Publ Code--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddlPublication.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.WebControls.ListItem li;
                li = new System.Web.UI.WebControls.ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                ddlPublication.Items.Add(li);
            }
        }
    }

    public void addcentercode()
    {
        string chk_value = ConfigurationSettings.AppSettings["LAYOUTX"].ToString();

        ddlCenter.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master addCenter = new NewAdbooking.Classes.Master();
            ds = addCenter.centercodenew(Session["compcode"].ToString(), Session["userid"].ToString(), chk_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master addCenter = new NewAdbooking.classesoracle.Master();
            ds = addCenter.centercode(Session["compcode"].ToString(), Session["userid"].ToString(), chk_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Websp_addcenter_B_Websp_addcenter";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), chk_value };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        System.Web.UI.WebControls.ListItem li1;
        li1 = new System.Web.UI.WebControls.ListItem();
        li1.Text = "--Select Center--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddlCenter.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.WebControls.ListItem li;
                li = new System.Web.UI.WebControls.ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                ddlCenter.Items.Add(li);
            }
        }
    }

    public void addeditioncode()
    {
        ddlEdition.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master addEdition = new NewAdbooking.Classes.Master();
            ds = addEdition.editioncode(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master addEdition = new NewAdbooking.classesoracle.Master();
            ds = addEdition.editioncode(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_addedition_websp_addedition_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        System.Web.UI.WebControls.ListItem li1;
        li1 = new System.Web.UI.WebControls.ListItem();
        li1.Text = "--Select Edition--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddlEdition.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.WebControls.ListItem li;
                li = new System.Web.UI.WebControls.ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                ddlEdition.Items.Add(li);
            }
        }
    }

    public void addsecpubcode()
    {
        ddlSupplement.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master addSecpub = new NewAdbooking.Classes.Master();
            ds = addSecpub.secpubcode(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master addSecpub = new NewAdbooking.classesoracle.Master();
            ds = addSecpub.secpubcode(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Websp_addsecpub_p_Websp_addsecpub";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        System.Web.UI.WebControls.ListItem li1;
        li1 = new System.Web.UI.WebControls.ListItem();
        li1.Text = "--Select Supplement--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddlSupplement.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                System.Web.UI.WebControls.ListItem li;
                li = new System.Web.UI.WebControls.ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                ddlSupplement.Items.Add(li);
            }
        }
        else
        {
            System.Web.UI.WebControls.ListItem li;
            li = new System.Web.UI.WebControls.ListItem();
            li.Value = "MN";
            li.Text = "MAIN";
            ddlSupplement.Items.Add(li);
        }
    }

    //[Ajax.AjaxMethod]   
    //public string updateclassified1(string  updatestatus)
    //{



    //}


    [Ajax.AjaxMethod]
    public string bookingstatusupdate(string updatestatus)
    {
        string[] cioid_insert = { };
        string cioid = "";
        string insertion = "";
        string edition = "";
        cioid_insert = updatestatus.Split(';');
        DataSet ds = new DataSet(); 
        for (int i = 0; i < cioid_insert.Length - 1; i++)
        {
            cioid = cioid_insert[i].Split(',')[0].ToString();
            insertion = cioid_insert[i].Split(',')[1].ToString();
            edition = cioid_insert[i].Split(',')[2].ToString();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.getReferenceFile objbindFile = new NewAdbooking.Classes.getReferenceFile();
                objbindFile.updateclassified(cioid, insertion, edition);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
                objbindFile.updateclassified(cioid, insertion, edition);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "websp_getReferenceupdate";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { cioid, insertion, edition };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        }
        return "success";
    }
    [Ajax.AjaxMethod]
    public double reader(string xtg_filename)
    {
        PdfReader reader = new PdfReader(xtg_filename);
        iTextSharp.text.Rectangle psize = reader.getCropBox(1);
        double s = psize.Height * (2.54 / 72);
        s = Math.Round(s, 2);
        return (s);
    }
    //[Ajax.AjaxMethod]
    //public DataSet bindEdition(string publication)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.getReferenceFile objbindFile = new NewAdbooking.Classes.getReferenceFile();
    //        ds = objbindFile.bindEdition_ref(publication);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
    //        ds = objbindFile.bindEdition_ref(publication);
    //    }

    //}

    protected void btnReference_Click(object sender, EventArgs e)
    {

    }

    [Ajax.AjaxMethod]
    public DataSet bindpackage_A_detail(string compcode, string adtype, string channel)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.TV_packagebind(compcode, adtype, channel);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                ds = bindopackage.TV_packagebind(compcode, adtype, channel);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "TV_packagebind";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, adtype, channel };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }


    // getCenterWiseEdition
    [Ajax.AjaxMethod]
    public DataSet getedition_namereffile(string compcode, string pubcode, string centercode, string edi, string secextra)
    {
            DataSet ds1 = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                
                }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                     OracleConnection objOracleConnection;
                     NewAdbooking.classesoracle.orclconnection objConnection = new NewAdbooking.classesoracle.orclconnection();
                     objOracleConnection = objConnection.GetConnection();
                     objOracleConnection.Open();
                     OracleDataAdapter da = new OracleDataAdapter();
                     da.SelectCommand = new OracleCommand("SELECT CONCAT(publication,'-',descriptions) FROM mapedition WHERE comp_code='" + compcode + "' AND pripub='" + pubcode + "' AND bkfor='" + centercode + " ' AND edition='" + edi + "' AND secpub='MN'", objOracleConnection);
                     da.Fill(ds1);
                     objOracleConnection.Close();   
                }
                 else
                 {
                     MySql.Data.MySqlClient.MySqlConnection objSqlConnection;
                     NewAdbooking.classmysql.connection objConnection = new NewAdbooking.classmysql.connection();
                     objSqlConnection = objConnection.GetConnection();
                     objSqlConnection.Open();
                     MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                     //da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + "BNG" + "' AND PUBL='TH0'", objSqlConnection);
                     da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(publication,'-',descriptions) reffilename FROM mapedition WHERE comp_code='" + compcode + "' AND pripub='"+pubcode + "' AND bkfor='"+ centercode + " ' AND edition='"+edi +"' AND secpub='MN'", objSqlConnection);
                     da.Fill(ds1);
                     objSqlConnection.Close();
                 }
             return ds1;
    }

    [Ajax.AjaxMethod]
    public DataSet geteditionname(string compcode, string editioncode, string supplement)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            /*clsconnection dconnect1 = new clsconnection();
            DataSet dsf = new DataSet();
            string sqldd1 = "";

            sqldd1 = "SELECT descriptions as editionname FROM mapedition WHERE edition ='" + editioncode + "'and secpub ='" + supplement + "' limit 1  ";
            // query = "select GET_cur_NAME('" + compcode + "','" + curr_code + "') as CURR_NAME ";
            //sqldd1 = sqldd1 + "('" + str1 + "','" + tot1 + "','" + Convert.ToDateTime(datefield).ToString("dd-MMMM-yyyy") + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate,'" + adtype + "','Y')";
            dsf = dconnect1.executequery(sqldd1);*/

            MySql.Data.MySqlClient.MySqlConnection objSqlConnection;
            NewAdbooking.classmysql.connection objConnection = new NewAdbooking.classmysql.connection();
            objSqlConnection = objConnection.GetConnection();
            objSqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
            //da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + "BNG" + "' AND PUBL='TH0'", objSqlConnection);
            da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(publication,'-',descriptions) reffilename FROM mapedition WHERE edition='" + editioncode + "' AND secpub='MN'", objSqlConnection);
            da.Fill(ds1);
            objSqlConnection.Close();
        }
        return ds1;
    }



}

