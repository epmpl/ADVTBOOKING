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

//using FourCPlus.AdBooking.BookingMaster.Oracle;
//using FourCPlus.AdBooking.BookingMaster.Sql;

public partial class printEditionPackage : System.Web.UI.Page
{
    string formname = "";
    string dateformat = "";
    string userid = "";
    string compcode = "";
    string rateradio = "";
    string message, validfromdate, validtill;
    string dd, mm, yyyy, dd1, mm1, yyyy1, cont, bwcode;
    static int FlagStatus, fpnl;
    string getpremrate = "";
    string type_ = "";
    /////////////this is declared as to check whether user is saving or doing query if saving then this value is 0 indicating 
    ////////////that we are saving the data 
    static string chkquery, saveormodify, gbratecode, gbadtype, gbcurrency, gbratetype, gbcolor, gbuom, gpkgcode, gbscheme;
    ////////////////////////////////////////////////
    ////////////this int is for autogenerated
    int cou = 0;
    ////////////this is to declare the dataset for execute 
    static DataSet executequery = new DataSet();
    static DataSet chkedition = new DataSet();
    int z = 0;
    DataGridItemEventArgs e1;
    ///////////////////////////////////////////////
 
    //public void adtypedata(string compcode)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
    //        ds = bind.adtypbind(compcode);
    //    }
    //    else
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
    //            ds = bind.adtypbind(compcode);

    //        }
    //        else
    //        {
    //            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
    //            ds = bind.adtypbind(compcode);
    //        }


    //    int i;
    //    ListItem li1;

    //    li1 = new ListItem();
    //    drpadtype.Items.Clear();
    //    li1.Text = "-Select Ad Type-";
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    drpadtype.Items.Add(li1);

    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        drpadtype.Items.Add(li);


    //    }

    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        hiddenrateuniqid.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        Response.Expires = -1;
        Session["rateinsert"] = null;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session has been expired\");window.close();</script>");
            return;

        }
        //btnupdate.Visible = false;
        //save.Visible = false;
        hdnconfigclient.Value = ConfigurationSettings.AppSettings["CLIENTNAME"].ToString();
        if (rateradio == "")
        {
            rateradio = Session["rateradio"].ToString();
        }

        if (!Page.IsPostBack)
        {
            //DataSet dspref = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    FourCPlus.AdBooking.BookingMaster.Sql.RateMaster Show_NoAd = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();

            //    dspref = Show_NoAd.getSoloRateAuto_Pref(Session["compcode"].ToString());
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster Show_NoAd = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();

            //    dspref = Show_NoAd.getSoloRateAuto_Pref(Session["compcode"].ToString());
            //}
            //if (dspref.Tables.Count > 0 && dspref.Tables[0].Rows.Count > 0)
            //{
            //    hidsoloauto.Value = dspref.Tables[0].Rows[0].ItemArray[0].ToString();
            //}

            hiddenprem.Value = Session["premtype"].ToString();

            hiddenDecimal.Value = Session["decimal"].ToString();
            hiddencurrency.Value = Session["currency"].ToString();
            hiddenbranch.Value = Session["revenue"].ToString();
            hiddenCenter.Value = Session["center"].ToString();

            rateradio = Convert.ToString(Session["rateradio"]);
            hiddseesion.Value = rateradio;
            compcode = Convert.ToString(Session["compcode"].ToString());
            userid = Convert.ToString(Session["userid"]);
            hiddenuserid.Value = userid;
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenusername.Value = Session["username"].ToString();
            hiddenbreakup.Value = Session["breakup"].ToString();
            // Session["solorate"] = "solo";
            hiddensolo.Value = Session["solorate"].ToString();


            if (rateradio == "company")
            {
                type_ = "company";
                hiddentype_agency.Value = "company";
            }
            else if (rateradio == "agency")
            {
                type_ = "agency";
                hiddentype_agency.Value = "agency";
            }

            else if (rateradio == "both")
            {
                //if (rbHindustan.Checked == true)
                //{
                //    type_ = "company";
                //    hiddentype_agency.Value = "company";
                //}
                //else
                //{
                //    type_ = "agency";
                //    hiddentype_agency.Value = "agency";
                //}

            }

            Ajax.Utility.RegisterTypeForAjax(typeof(printEditionPackage));
            if (Session["compcode"] == null)
            {
                //Response.Redirect("login.aspx");
                Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
                return;

            }
            dateinsert chkdate = new dateinsert();
            formname = "Ratemaster";
            // dateformat = Session["dateformat"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat = Session["dateformat"].ToString();
            bwcode = Session["bwcode"].ToString();
            DataSet objDataSet = new DataSet();
            // Read in the XML file
            objDataSet.ReadXml(Server.MapPath("XML/ratemasterP.xml"));
            lbladtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();

            lblpkgcode.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
            hiddenurl.Value = ConfigurationManager.AppSettings["TVURL"].ToString();
            

            DataSet objDataSetbu = new DataSet();
            objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
            btnNew.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
            btnSave.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
            btnModify.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
            btnQuery.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
            btnExecute.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
            btnCancel.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
            btnfirst.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
            btnprevious.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
            btnnext.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
            btnlast.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
            btnDelete.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
            btnExit.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

            hiddenprem.Value = Session["premtype"].ToString();
            lbaddon.Attributes.Add("OnClick", "javascript:return adon();");

            lstbtb.Attributes.Add("onclick", "javascript:return Clickcbbtb1(event);");
            lstbtb.Attributes.Add("onkeydown", "javascript:return Clickcbbtb1(event);");
         
            lstprog.Attributes.Add("onclick", "javascript:return Clickprog(event);");
            lstprog.Attributes.Add("onclick", "javascript:return Clickprog(event);");
            save.Attributes.Add("onclick", "javascript:return insertEditPackeg();");
            btnupdate.Attributes.Add("onclick", "javascript:return updateEditPackeg();");
            hiddentextchanged.Value = "0";
           // getbuttoncheck(formname);
            //adtypedata(compcode);

            //scheme(compcode);

            

            // advcat(compcode);
            //bindcurrency();
            bindpackage();

            btnSave.Attributes.Add("onclick", "javascript:return saverate();");
            btnDelete.Attributes.Add("onclick", "javascript:return deleteclick();");//return confirm('Are you sure you want to delete?');");
            btnExit.Attributes.Add("onclick", "javascript:return closerate();");
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick1();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");

            drpadtype.Attributes.Add("OnChange", "javascript:return onchage_adtype();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return prevclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");

            drppkgcode.Attributes.Add("OnChange", "javascript:return onchange_drppkgcode();");
            lstratecode.Attributes.Add("onclick", "javascript:return onclicratecode(event);");
            lstratecode.Attributes.Add("onkeydown", "javascript:return onclicratecode(event);");
        }
        DataSet objDataSetbu1 = new DataSet();
        // Read in the XML file
        objDataSetbu1.ReadXml(Server.MapPath("XML/button.xml"));
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = objDataSetbu1.Tables[1].Rows[0].ItemArray[11].ToString();
       
       
    }
    [Ajax.AjaxMethod]
    public void bindpackage()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.PrintEditionPackage bind = new NewAdbooking.Classes.PrintEditionPackage();
            ds = bind.adtypbind(compcode);
        }
        else //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PrintEditionPackage bind = new NewAdbooking.classesoracle.PrintEditionPackage();
            ds = bind.adtypbind(compcode);

        }
        //else
        //{
        //    NewAdbooking.classmysql.PrintEditionPackage bindopackage = new NewAdbooking.classmysql.PrintEditionPackage();
        //    ds = bindopackage.packagebind(Session["compcode"].ToString(), Session["userid"].ToString());
        //}


        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }


    }
    //

    public void chkstatus(int FlagStatus)
    {
        if (FlagStatus == 0 || FlagStatus == 8)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnExecute.Enabled = false;
            btnCancel.Enabled = false;
            btnModify.Enabled = false;

            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = false;



        }
        if (FlagStatus == 1 || FlagStatus == 9)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnExecute.Enabled = false;
            btnCancel.Enabled = true;
            btnModify.Enabled = false;

            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = true;

        }
        if (FlagStatus == 2 || FlagStatus == 10)
        {
            btnExecute.Enabled = true;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = true;
            btnExecute.Enabled = false;
            btnModify.Enabled = false;
            btnExit.Enabled = true;

            btnSave.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = true;


        }

        if (FlagStatus == 3 || FlagStatus == 11)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;


            btnModify.Enabled = false;

            btnSave.Enabled = true;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }

        if (FlagStatus == 4 || FlagStatus == 12)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;


            btnModify.Enabled = false;

            btnSave.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }
        if (FlagStatus == 5 || FlagStatus == 13)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;


            btnModify.Enabled = false;

            btnSave.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }
        if (FlagStatus == 6 || FlagStatus == 14)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;


            btnModify.Enabled = false;

            btnSave.Enabled = false;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }
        if (FlagStatus == 7 || FlagStatus == 15)
        {
            btnNew.Enabled = false;
            btnExecute.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;


            btnModify.Enabled = false;

            btnSave.Enabled = true;
            btnfirst.Enabled = false;
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            btnlast.Enabled = false;
        }


    }

    public void updateStatus()
    {
        chkstatus(FlagStatus);
        if (FlagStatus == 2 || FlagStatus == 3)
        {
            btnQuery.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnModify.Enabled = true;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;
            btnDelete.Enabled = false;
        }
        if (FlagStatus == 4)
        {
            btnDelete.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = false;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
        if (FlagStatus == 5)
        {
            btnDelete.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = false;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
        if (FlagStatus == 6 || FlagStatus == 7)
        {
            btnDelete.Enabled = true;
            btnExecute.Enabled = false;
            btnSave.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = true;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
    }
    //protected void drpadtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bindPackage();
    //}

    private void bindPackage()
    {
        string pack_code = drpadtype.SelectedValue;
    }

        [Ajax.AjaxMethod]
    public DataSet pkg_adcat_uom_bind(string compcode, string adtype)
    {
        
        DataSet ds = new DataSet();
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.PrintEditionPackage package = new NewAdbooking.Classes.PrintEditionPackage();

            ds = package.selpackageForPrintEdition(compcode, adtype);
        }
        else //if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PrintEditionPackage package = new NewAdbooking.classesoracle.PrintEditionPackage();
            ds = package.selpackageForPrintEdition(compcode, adtype);
        }
        //else
        //{
        //    NewAdbooking.classmysql.PrintEditionPackage package = new NewAdbooking.classmysql.PrintEditionPackage();
        //    ds = package.selpackage(hiddencompcode.Value);
        //}
        return ds;

        
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "-Select Package Code-";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        ////drppkgcode.Items.Clear();
        ////drppkgcode.Items.Add(li1);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        //drppkgcode.Items.Add(li);
        //    }

        //}
        
    }

        [Ajax.AjaxMethod]
        public DataSet getPack(string packeg, string comcin_code)
                //public void getPackege()
           
         {
    //        string bb = drppkgcode.SelectedValue.ToString();
            DataSet ds = new DataSet();
            
            ds.Clear();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.PrintEditionPackage pack = new NewAdbooking.Classes.PrintEditionPackage();
                ds = pack.selectEditionComboCode(packeg, comcin_code);
            }
            else //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PrintEditionPackage pack = new NewAdbooking.classesoracle.PrintEditionPackage();
                ds = pack.selectEditionComboCode(packeg, comcin_code);
            }
            //else
            //{
            //    NewAdbooking.classmysql.ColorRateGroupMast pack = new NewAdbooking.classmysql.ColorRateGroupMast();
            //    ds = pack.selectEditionComboCode(packeg, comcin_code);
            //}
            //if(ds.Tables[0].Rows.Count>0)
            //{
            //    string code = ds.Tables[0].Rows[0]["edition_combin_code"].ToString();
            //    string[] dd = code.Split('+'); 
            ////pep.DataSource = ds;
            ////pep.DataBind();
            //}
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return ds;
            //}

            return ds;
        }

        [Ajax.AjaxMethod]
        public DataSet executePrintEdition(string comp_code, string adtype,string combin_code)
        {
            
            DataSet ds = new DataSet();

            ds.Clear();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.PrintEditionPackage pack = new NewAdbooking.Classes.PrintEditionPackage();
                ds = pack.executePrintEditionComboCode(comp_code, adtype, combin_code);
            }
            else //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PrintEditionPackage pack = new NewAdbooking.classesoracle.PrintEditionPackage();
                ds = pack.executePrintEditionComboCode(comp_code, adtype, combin_code);
            }
            //else
            //{
            //    NewAdbooking.classmysql.ColorRateGroupMast pack = new NewAdbooking.classmysql.ColorRateGroupMast();
            //    ds = pack.executePrintEditionComboCode(comp_code, adtype, combin_code);
            //}
           

            return ds;
        }
        
        protected void save_Click(object sender, EventArgs e)
        {
           
        }

        [Ajax.AjaxMethod]
        public void insertPack(string aa, string bb, string cc, string dd,string adtype, string comp_code)
        {
            DataSet ds = new DataSet();

            ds.Clear();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.PrintEditionPackage pack = new NewAdbooking.Classes.PrintEditionPackage();
                ds = pack.insertEditionComboCode(aa, bb, cc, dd,adtype,comp_code);
            }
            else //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PrintEditionPackage pack = new NewAdbooking.classesoracle.PrintEditionPackage();
                ds = pack.insertEditionComboCode(aa, bb, cc, dd, adtype, comp_code);
            }
            //else
            //{
            //    NewAdbooking.classmysql.PrintEditionPackage pack = new NewAdbooking.classmysql.PrintEditionPackage();
            //    pack.insertEditionComboCode(aa, bb, cc, dd, adtype, comp_code);
            //}
            

            //return ds;
        }


        [Ajax.AjaxMethod]
        public DataSet updatePack(string flag1, string id)
        //public void getPackege()
        {
            //        string bb = drppkgcode.SelectedValue.ToString();
            DataSet ds = new DataSet();

            ds.Clear();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.PrintEditionPackage pack = new NewAdbooking.Classes.PrintEditionPackage();
                ds = pack.updateEditionComboCode(flag1, id);
            }
            else //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PrintEditionPackage pack = new NewAdbooking.classesoracle.PrintEditionPackage();
                ds = pack.updateEditionComboCode(flag1, id);
            }
            //else
            //{
            //    NewAdbooking.classmysql.PrintEditionPackage pack = new NewAdbooking.classmysql.PrintEditionPackage();
            //    ds = pack.updateEditionComboCode(flag1, id);
            //}


            return ds;
        }


        [Ajax.AjaxMethod]
        public DataSet getTableOnQuery(string aa)
        {
            DataSet ds = new DataSet();
            ds.Clear();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.PrintEditionPackage pack = new NewAdbooking.Classes.PrintEditionPackage();
                ds = pack.selectPrintEditionComboCode(aa);
            }
            else //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PrintEditionPackage pack = new NewAdbooking.classesoracle.PrintEditionPackage();
                ds = pack.selectPrintEditionComboCode(aa);
            }
            //else
            //{
            //    NewAdbooking.classmysql.PrintEditionPackage pack = new NewAdbooking.classmysql.PrintEditionPackage();
            //    ds = pack.selectPrintEditionComboCode(aa);
            //}
            //if(ds.Tables[0].Rows.Count>0)
            //{
            //    string code = ds.Tables[0].Rows[0]["edition_combin_code"].ToString();
            //    string[] dd = code.Split('+'); 
            ////pep.DataSource = ds;
            ////pep.DataBind();
            //}
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return ds;
            //}

            return ds;
        }

        
}
