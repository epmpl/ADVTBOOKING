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

public partial class updateprefer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";


        

        if (Session["compcode"] != null)
        {
            hiddencode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenusername.Value = Session["Username"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }


        Ajax.Utility.RegisterTypeForAjax(typeof(updateprefer));
        //========================Lable Name============================//
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/updateprefer.xml"));
        //lbldispbillcri.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //lblclasbillcr.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //lblmtpostallow.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        //lblbkpost.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //lblmaxret.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        //lblreturn.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        //lblchkbounce.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
        //lblchkreceive.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
        //lblreturndate.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
        //lblchgsupporder.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        //lblspl_trans_edit.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        //lblspl_dis_trans_editable.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
        //lblmul_pac_sel_trans.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
        //lblshmon_minword.Text = ds1.Tables[0].Rows[0].ItemArray[13].ToString();
        //lbltradon_spcrg.Text = ds1.Tables[0].Rows[0].ItemArray[14].ToString();
        //lblrateaut.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();
        //lblf2day.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
        //lblrateaudit_modify.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        //lblbindrevenuecenter.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
        //lblrepeatingdaytype.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
        //lbleditableintransaction.Text = ds1.Tables[0].Rows[0].ItemArray[20].ToString();
        //lblRO_OUTSTAND_P.Text = ds1.Tables[0].Rows[0].ItemArray[21].ToString();
        //lbagencycodegeneration.Text = ds1.Tables[0].Rows[0].ItemArray[22].ToString();
        //lbldisplauditbk.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
        //lbAutosupplypostingrequired.Text = ds1.Tables[0].Rows[0].ItemArray[24].ToString();
        //lbAuthorization.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        //lbUNSOLDAPPROVAL.Text = ds1.Tables[0].Rows[0].ItemArray[26].ToString();
        //lbUNSOLDPHYSICAL.Text = ds1.Tables[0].Rows[0].ItemArray[27].ToString();
        //lbINCLUDEUNSOLD.Text = ds1.Tables[0].Rows[0].ItemArray[28].ToString();
        //lbINCLUDEUNSOLDININSERTIONFEEPROCESS.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
        //lbUNSOLDONSUPPLYORRECEIVEDDATE.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();

        TDSAsseyTypeName.Text = ds1.Tables[0].Rows[0].ItemArray[26].ToString();
        TDSecName.Text = ds1.Tables[0].Rows[0].ItemArray[27].ToString();
      //  ret.Text = ds1.Tables[0].Rows[0].ItemArray[28].ToString();
        if (!Page.IsPostBack)
        {
          
            binddisbillcri();
            bindclasbillcri();
            bindpublication();
            Textvalue.Attributes.Add("onblur", "javascript:return value123(event);");
           // Textvalue.Attributes.Add("onblur", "javascript:return value();");

            lsttds.Attributes.Add("onkeydown", "javascript:return fill_tds(event);");
            lsttds.Attributes.Add("onclick", "javascript:return fill_tds(event);");
            lstassay.Attributes.Add("onkeydown", "javascript:return fill_assay(event);");
            lstassay.Attributes.Add("onclick", "javascript:return fill_assay(event);");
            retno.Attributes.Add("OnKeyPress", "javascript:return NumericValidation(event);");

            btnsubmit.Attributes.Add("OnClick", "javascript:return datesave();");
            //  chkinsertdate.Attributes.Add("OnClick", "javascript:return Chkchange();");
            //  txtcut.Attributes.Add("OnChange", "javascript:return chkcutt();");
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.login showdate = new NewAdbooking.classesoracle.login();
                ds = showdate.dateshow(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.login showdate = new NewAdbooking.Classes.login();
                ds = showdate.dateshow(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "Websp_dateshow_Websp_dateshow_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[3] != null && ds.Tables[0].Rows[0].ItemArray[3].ToString() != "")
                {
                    drpdateformat.SelectedValue = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                }
                else
                {
                    drpdateformat.SelectedValue = "mm/dd/yyyy";

                }
            }


            //-------------Ad by rinki (show button permission)------------------//

            DataSet dz = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
                dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "updateprefer");
            }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
                dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "updateprefer");

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "websp_showpermission_websp_showpermission_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), "updateprefer" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            string id = "";
            if (dz.Tables[0].Rows.Count > 0)
            {
                id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            }


            if (id == "2" || id == "15")
                btnsubmit.Enabled = true;
            else
               






                lbagencymaster.Attributes.Add("OnClick", "javascript:return openenability();");
            drpAuto_TDS_Credit_Note.Attributes.Add("onchange", "javascript:return Auto_TDS_Credit_Noteenbel();");
            drpauto_service_tax_credit_note.Attributes.Add("onchange", "javascript:return auto_service_tax_credit_noteenbel();");
            drpAuto_Patrakar_Kalyan_Kosh_Credit_Note.Attributes.Add("onchange", "javascript:return Auto_Patrakar_Kalyan_Kosh_Credit_Noteenbel();");
            drpAuto_Bank_Charges_Credit_Note.Attributes.Add("onchange", "javascript:return drpAuto_Bank_Charges_Credit_Noteenbel();");
            bindcurr();
            binduom();
            bindrategroup();
            adcategory();
            adtypedata(hiddencompcode.Value);
            bindsupplytypepaid();
            bindsupplytypefree();
            defaultdata();
            //tds();
            //asses();
            //ret1();


           
            // bindcurrcat();

            /*new change ankur*/

            //////////////////////


        }




    }

    #region Web Form Designer generated code
    protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion



    //		










    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
    }
    //====================Bind Dropdown==================================//
    public void binddisbillcri()
    {
        DataSet cardtyp = new DataSet();
        cardtyp.ReadXml(Server.MapPath("XML/updateprefer.xml"));
        drpdispbillcr.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---- Select ----";
        li1.Value = "0";
        drpdispbillcr.Items.Add(li1);
        for (i = 0; i < cardtyp.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = cardtyp.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = cardtyp.Tables[1].Rows[0].ItemArray[i].ToString();

            drpdispbillcr.Items.Add(li);

        }

    }



    public void bindpublication()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.updatestaus pub_cent1 = new NewAdbooking.BillingClass.classesoracle.updatestaus();
            ds = pub_cent1.publication_center(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "PubCentName1_PubCentName1_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select Publication---";
        li1.Value = "0";
        li1.Selected = true;
        drp_publication.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drp_publication.Items.Add(li);
        }
    }


    public void adtypedata(string compcode)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 bind = new NewAdbooking.Classes.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        li1.Text = "---Select Adtype---";
        li1.Value = "0";
        drp_adtype.Items.Clear();
        li1.Selected = true;
        drp_adtype.Items.Add(li1);


        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drp_adtype.Items.Add(li);


        }

    }


    public void bindclasbillcri()
    {
        DataSet cardtyp = new DataSet();
        cardtyp.ReadXml(Server.MapPath("XML/updateprefer.xml"));
        drpclasbillcr.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---- Select ----";
        li1.Value = "0";
        drpclasbillcr.Items.Add(li1);
        for (i = 0; i < cardtyp.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = cardtyp.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = cardtyp.Tables[1].Rows[0].ItemArray[i].ToString();

            drpclasbillcr.Items.Add(li);

        }

    }
    /*new change ankur*/
    public void binduom()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster uom = new NewAdbooking.classesoracle.EditorMaster();
            ds = uom.uomname(Session["compcode"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.EditorMaster uom = new NewAdbooking.Classes.EditorMaster();
            ds = uom.uomname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_uomname_Bind_uomname_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select UOM---";
        li1.Value = "0";
        li1.Selected = true;
        drpuom.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpuom.Items.Add(li);
        }

    }
    public void adcategory()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPagePositionMaster name = new NewAdbooking.classesoracle.AdvPagePositionMaster();
            ds = name.addadvcat();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvPagePositionMaster name = new NewAdbooking.Classes.AdvPagePositionMaster();
            ds = name.addadvcat("");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Addadvcat_Addadvcat_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Ad Category-";
        li1.Value = "0";
        li1.Selected = true;
        drpadcat.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpadcat.Items.Add(li);
        }

    }
    [Ajax.AjaxMethod]
    //		public void updatedate(string hiddencompcode,string hiddenuserid,string datefor)
    public void updatedate(string hiddencompcode, string hiddenuserid, string datefor, string code, string curr, string ratecode, string pre, string suff, string chkfinancestatus, string voucherst)
    {

        //string datefor=drpdateformat.SelectedValue.ToString();
        // NewAdbooking.Classes.pop abc = new NewAdbooking.Classes.pop();
        // DataSet dz = new DataSet();
        //dz = abc.dateupdation(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode);

        //			Collection.Classes.login loginsession=new Collection.Classes.login();
        //			DataSet ds=new DataSet();
        //			ds=loginsession.sessiondate(hiddencompcode.Value,hiddenuserid.Value);
        //
        //			if(ds.Tables[0].Rows.Count > 0)
        //			{
        //				Session["dateformat"]=ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //			}


    }



    [Ajax.AjaxMethod]
    //		public void updatedate(string hiddencompcode,string hiddenuserid,string datefor)
    public void submitdate(string hiddencompcode, string hiddenuserid, string datefor, string code, string curr, string ratecode)
    {
        //string datefor=drpdateformat.SelectedValue.ToString();
        //NewAdbooking.Classes.pop abc = new NewAdbooking.Classes.pop();
        //DataSet dz = new DataSet();
        //dz = abc.datesubmit(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode);


    }

    [Ajax.AjaxMethod]
    //	public void updatedate(string hiddencompcode,string hiddenuserid,string datefor)
    /*new change ankur*/
    /*new change ankur for agency*/
    public string chkprefer(string hiddencompcode, string hiddenuserid, string datefor, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdates, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string seperate_cashier, string disp_bill, string clas_bill, string mantimepost, string bkdaypost, string maxterutn, string cir_return, string noofchkbounc, string noofdaychkrec, string retday, string chngsuppord, string max_publishday, string billno_period, string spl_trans_edit, string spl_dis_trans_editable, string mul_pac_sel_trans, string shmon_minword, string tradon_spcrg, string rateauth, string f2day, string rateauditmodify, string bindrevenuecenter, string led_allow, string clear_allow, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string dispauditbk, string aotosupply, string Authorization, string UNSOLDAPPROVAL, string UNSOLDPHYSICAL, string INCLUDEUNSOLD, string INCLUDEUNSOLDININSERTIONFEEPROCESS, string UNSOLDONSUPPLYORRECEIVEDDATE, string Agencyunblockapproval, string UnblockApprovalOutsideCreditLimit, string billingpublicationwise, string ALLOW_FOLLOW_DT_BOOOK, string paging, string print, string allowpage, string agency, string region, string subscription_paid_supply_type, string subscription_free_supply_type, string CURRENCY_MEASUREMENT, string drpadddiscount, string cancharges, string entry_type, string ApprovalWith, string Auto_TDS_Credit_Note, string TDS_Reason, string Debit_Account_Head, string credit_Account_Head, string service_tax_credit_note, string Tax_Reason, string Debit_Account_Service_Tax, string Credit_Account_Service_Tax, string Auto_Patrakar_Credit_Note, string Patrakar_Reason, string Debit_Account_Head_For_Patrakar, string Credit_Account_Head_For_Patrakar, string Auto_Bank_Credit_Note, string Bank_Reason, string Debit_Account_Bank, string Credit_Account_Bank, string BARCODE, string WEIGHT_CAL, string GEN_RCT_TYP, string misdata, string allowpremium, string financecode, string executivepub, string executivecreditlimit, string mrv, string retainer_comm_bank, string fixed_tran_amt, string trade_dis_based, string retcomm, string supplbill, string tdstypename, string tdsSecname, string retno, string bankrecorequired, string txtretonoverdue, string txtdoconoverdue, string drpallowbooking, string drpchkfordupreq, string alowwithtro, string commonfrid, string drpreciptno, string txtvalue, string flag1, string drpret_exec, string drpcashrecacc, string daysbook)
    {



        string count;
        DataSet db = new DataSet();
        //string datefor=drpdateformat.SelectedValue.ToString();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer abc = new NewAdbooking.classesoracle.updateprefer();
            db = abc.datechkprefer(hiddencompcode);
    }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.updateprefer abc = new NewAdbooking.Classes.updateprefer();
            db = abc.datechkprefer(hiddencompcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "wesp_chkdateprefer_wesp_chkdateprefer_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hiddencompcode };
            db = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (db.Tables[0].Rows.Count > 0)
        {
            DataSet dz = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.updateprefer abcupdate = new NewAdbooking.classesoracle.updateprefer();

                /*new change ankur*/
                /*new change ankur for agency*/
                dz = abcupdate.dateupdation(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, seperate_cashier, disp_bill, clas_bill, mantimepost, bkdaypost, maxterutn, cir_return, noofchkbounc, noofdaychkrec, retday, chngsuppord, max_publishday, billno_period, spl_trans_edit, spl_dis_trans_editable, mul_pac_sel_trans, shmon_minword, tradon_spcrg, rateauth, f2day, rateauditmodify, bindrevenuecenter, led_allow, clear_allow, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, scheme_billing, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, dispauditbk, aotosupply, Authorization.Trim(), UNSOLDAPPROVAL, UNSOLDPHYSICAL, INCLUDEUNSOLD, INCLUDEUNSOLDININSERTIONFEEPROCESS, UNSOLDONSUPPLYORRECEIVEDDATE, Agencyunblockapproval, UnblockApprovalOutsideCreditLimit, billingpublicationwise, ALLOW_FOLLOW_DT_BOOOK, paging, print, allowpage, agency, region, subscription_paid_supply_type, subscription_free_supply_type, CURRENCY_MEASUREMENT, drpadddiscount, cancharges, entry_type, ApprovalWith, Auto_TDS_Credit_Note, TDS_Reason, Debit_Account_Head, credit_Account_Head, service_tax_credit_note, Tax_Reason, Debit_Account_Service_Tax, Credit_Account_Service_Tax, Auto_Patrakar_Credit_Note, Patrakar_Reason, Debit_Account_Head_For_Patrakar, Credit_Account_Head_For_Patrakar, Auto_Bank_Credit_Note, Bank_Reason, Debit_Account_Bank, Credit_Account_Bank, BARCODE, WEIGHT_CAL, GEN_RCT_TYP, misdata, allowpremium, financecode, executivepub, executivecreditlimit, mrv, retainer_comm_bank, fixed_tran_amt, trade_dis_based, retcomm, supplbill, tdstypename, tdsSecname, retno, bankrecorequired, txtretonoverdue, txtdoconoverdue, drpallowbooking, drpchkfordupreq, alowwithtro, commonfrid, drpreciptno, drpret_exec, drpcashrecacc, daysbook);
                // Response.Write("<script>alert('Updated Successfully')</script>");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.updateprefer abcupdate = new NewAdbooking.Classes.updateprefer();

                /*new change ankur*/
                /*new change ankur for agency*/

                dz = abcupdate.dateupdation(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, seperate_cashier, disp_bill, clas_bill, mantimepost, bkdaypost, maxterutn, cir_return, noofchkbounc, noofdaychkrec, retday, chngsuppord, max_publishday, billno_period, spl_trans_edit, spl_dis_trans_editable, mul_pac_sel_trans, shmon_minword, tradon_spcrg, rateauth, f2day, rateauditmodify, bindrevenuecenter, led_allow, clear_allow, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, scheme_billing, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, dispauditbk, aotosupply, Authorization.Trim(), UNSOLDAPPROVAL, UNSOLDPHYSICAL, INCLUDEUNSOLD, INCLUDEUNSOLDININSERTIONFEEPROCESS, UNSOLDONSUPPLYORRECEIVEDDATE, Agencyunblockapproval, UnblockApprovalOutsideCreditLimit, billingpublicationwise, ALLOW_FOLLOW_DT_BOOOK, paging, print, allowpage, agency, region, subscription_paid_supply_type, subscription_free_supply_type, CURRENCY_MEASUREMENT, drpadddiscount, cancharges, entry_type, ApprovalWith, Auto_TDS_Credit_Note, TDS_Reason, Debit_Account_Head, credit_Account_Head, service_tax_credit_note, Tax_Reason, Debit_Account_Service_Tax, Credit_Account_Service_Tax, Auto_Patrakar_Credit_Note, Patrakar_Reason, Debit_Account_Head_For_Patrakar, Credit_Account_Head_For_Patrakar, Auto_Bank_Credit_Note, Bank_Reason, Debit_Account_Bank, Credit_Account_Bank, BARCODE, WEIGHT_CAL, GEN_RCT_TYP, misdata, allowpremium, financecode, executivepub, executivecreditlimit, mrv, retainer_comm_bank, fixed_tran_amt, trade_dis_based, retcomm, supplbill, tdstypename, tdsSecname, retno, bankrecorequired, txtretonoverdue, txtdoconoverdue, drpallowbooking, drpchkfordupreq, alowwithtro, commonfrid, drpreciptno, txtvalue, flag1, drpret_exec, drpcashrecacc, daysbook);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "wesp_updatedate_wesp_updatedate_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, seperate_cashier, disp_bill, clas_bill, mantimepost, bkdaypost, maxterutn, cir_return, noofchkbounc, noofdaychkrec, retday, chngsuppord, max_publishday, billno_period, spl_trans_edit, spl_dis_trans_editable, mul_pac_sel_trans, shmon_minword, tradon_spcrg, rateauth, f2day, rateauditmodify, bindrevenuecenter, led_allow, clear_allow, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, scheme_billing, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, dispauditbk, aotosupply, Authorization.Trim(), UNSOLDAPPROVAL, UNSOLDPHYSICAL, INCLUDEUNSOLD, INCLUDEUNSOLDININSERTIONFEEPROCESS, UNSOLDONSUPPLYORRECEIVEDDATE, Agencyunblockapproval, UnblockApprovalOutsideCreditLimit, billingpublicationwise, ALLOW_FOLLOW_DT_BOOOK, paging, print, allowpage, agency, region, subscription_paid_supply_type, subscription_free_supply_type, CURRENCY_MEASUREMENT, drpadddiscount, cancharges, entry_type, ApprovalWith, Auto_TDS_Credit_Note, TDS_Reason, Debit_Account_Head, credit_Account_Head, service_tax_credit_note, Tax_Reason, Debit_Account_Service_Tax, Credit_Account_Service_Tax, Auto_Patrakar_Credit_Note, Patrakar_Reason, Debit_Account_Head_For_Patrakar, Credit_Account_Head_For_Patrakar, Auto_Bank_Credit_Note, Bank_Reason, Debit_Account_Bank, Credit_Account_Bank, BARCODE, WEIGHT_CAL, GEN_RCT_TYP, misdata, allowpremium, financecode, executivepub, executivecreditlimit, mrv, retainer_comm_bank, fixed_tran_amt, trade_dis_based, retcomm, supplbill, tdstypename, tdsSecname, retno, bankrecorequired, txtretonoverdue, txtdoconoverdue, drpallowbooking, drpchkfordupreq, alowwithtro, commonfrid, drpreciptno, txtvalue, flag1, drpret_exec, drpcashrecacc, daysbook };
                dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            //else
            //{
            //    NewAdbooking.classmysql.pop abcupdate = new NewAdbooking.classmysql.pop();
            //    dz = abcupdate.dateupdation(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, repeatday, premiumedit, BILL_GENERATION,  PUBLICATION_CENTER);

            //}
            count = "Y";
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //string datefor=drpdateformat.SelectedValue.ToString();
                NewAdbooking.classesoracle.updateprefer abcsubmit = new NewAdbooking.classesoracle.updateprefer();
                DataSet dz = new DataSet();

                dz = abcsubmit.datesubmit(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, scheme_billing, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, aotosupply, Authorization, retainer_comm_bank, retcomm, supplbill, daysbook);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //string datefor=drpdateformat.SelectedValue.ToString();
                NewAdbooking.Classes.updateprefer abcsubmit = new NewAdbooking.Classes.updateprefer();
                DataSet dz = new DataSet();
                /*new change ankur*/
                /*new change ankur for agency*/
                dz = abcsubmit.datesubmit(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, scheme_billing, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, aotosupply, Authorization, retainer_comm_bank, retcomm, supplbill, daysbook);

                //Response.Write("<script>alert('Saved Successfully')</script>");
            }
            else        
            {
                DataSet dz = new DataSet();
                string procedureName = "wesp_submitdate_wesp_submitdate_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { hiddencompcode, hiddenuserid, datefor, code, curr, ratecode, solo, breakup, bwcode, rostatus, filename, tfn, insertbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insert_date, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agencyretcomm, subrate, displaybilltype, classifiedbilltype, billformat, ratechk, allpkg, dayrate, schemetype, Includeclassi, receiptformat, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, pckstatus, cash_disc, cash_amt, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, scheme_billing, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, aotosupply, Authorization, retainer_comm_bank, retcomm, supplbill, daysbook };
                dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            count = "N";

        }
        return count;
        }

    

  [Ajax.AjaxMethod]
    //		public DataSet submitpermission(string hiddencompcode ,string hiddenuserid,string formname)
    public DataSet submitpermission(string hiddencompcode, string hiddenuserid, string formname)
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
            return dz;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
            return dz;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_showpermission_websp_showpermission_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hiddencompcode, hiddenuserid, formname };
            dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
    }

    protected void log_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("logout.aspx");
    }

    public void bindrategroup()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer bindrate = new NewAdbooking.classesoracle.updateprefer();

            //   dx = bindrate.ratebind(Session["compcode"].ToString());
            dx = bindrate.ratebindprefer(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.updateprefer bindrate = new NewAdbooking.Classes.updateprefer();

            //   dx = bindrate.ratebind(Session["compcode"].ToString());
            dx = bindrate.ratebindprefer(Session["compcode"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindrateforprefer_bindrateforprefer_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            dx = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //else
        //{
        //    NewAdbooking.classmysql.pop bindrate = new NewAdbooking.classmysql.pop();
        //    dx = bindrate.ratebindprefer(Session["compcode"].ToString());
        //}
        drprategroup.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Rate Group-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprategroup.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drprategroup.Items.Add(li);
            }

        }

    }
    public void defaultdata()
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer bindcurre = new NewAdbooking.classesoracle.updateprefer();

            ds1 = bindcurre.currbindpgld(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.updateprefer bindcurre = new NewAdbooking.Classes.updateprefer();

            ds1 = bindcurre.currbindpgld(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "currbindpreferpgld_currbindpreferpgld_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0].ItemArray[0] != null && ds1.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                drpdateformat.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[1] != null && ds1.Tables[0].Rows[0].ItemArray[1].ToString() != "")
            {
                drpcodetype.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            }



            if (ds1.Tables[0].Rows[0].ItemArray[2] != null && ds1.Tables[0].Rows[0].ItemArray[2].ToString() != "")
            {
                drpcurr.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            }


            if (ds1.Tables[0].Rows[0].ItemArray[3] != null && ds1.Tables[0].Rows[0].ItemArray[3].ToString() != "")
            {
                drprategroup.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[4] != null && ds1.Tables[0].Rows[0].ItemArray[4].ToString() != "")
            {
                drpcheckrate.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[5] != null && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
            {
                drpbreakup.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[6] != null && ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "")
            {
                txtbwcode.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[7] != null && ds1.Tables[0].Rows[0].ItemArray[7].ToString() != "")
            {
                //txtbwcode.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
                if (ds1.Tables[0].Rows[0].ItemArray[7].ToString() == "0")
                {
                    chbres.Checked = false;
                }
                else
                {
                    chbres.Checked = true;
                }
            }
            if (ds1.Tables[0].Rows[0].ItemArray[8] != null && ds1.Tables[0].Rows[0].ItemArray[8].ToString() != "")
            {
                drpfilename.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[9] != null && ds1.Tables[0].Rows[0].ItemArray[9].ToString() != "")
            {
                txttfn.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[10] != null && ds1.Tables[0].Rows[0].ItemArray[10].ToString() != "")
            {
                drpinsbreak.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[11] != null && ds1.Tables[0].Rows[0].ItemArray[11].ToString() != "")
            {

                txtprefix.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();

            }


            if (ds1.Tables[0].Rows[0].ItemArray[12] != null && ds1.Tables[0].Rows[0].ItemArray[12].ToString() != "")
            {

                txtsuffix.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();

            }


            if (ds1.Tables[0].Rows[0].ItemArray[13] != null && ds1.Tables[0].Rows[0].ItemArray[13].ToString() != "")
            {
                string value = ds1.Tables[0].Rows[0].ItemArray[13].ToString();

                if (value == "Y")
                    chkfinance.Checked = true;
                else
                    chkfinance.Checked = false;

            }
            if (ds1.Tables[0].Rows[0].ItemArray[14] != null && ds1.Tables[0].Rows[0].ItemArray[14].ToString() != "")
            {
                drpvoucherst.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[14].ToString();

            }
            if (ds1.Tables[0].Rows[0].ItemArray[16] != null && ds1.Tables[0].Rows[0].ItemArray[16].ToString() != "")
            {
                drprodatetime.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[16].ToString();

            }
            if (ds1.Tables[0].Rows[0].ItemArray[17] != null && ds1.Tables[0].Rows[0].ItemArray[17].ToString() != "")
            {
                drpvat.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[18] != null && ds1.Tables[0].Rows[0].ItemArray[18].ToString() != "")
            {
                drpbookingstat.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[19] != null && ds1.Tables[0].Rows[0].ItemArray[19].ToString() != "")
            {
                drpcioid.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[20] != null && ds1.Tables[0].Rows[0].ItemArray[20].ToString() != "")
            {
                drpreceipt.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[20].ToString();
            }
            /*new change ankur*/
            if (ds1.Tables[0].Rows[0].ItemArray[21] != null && ds1.Tables[0].Rows[0].ItemArray[21].ToString() != "")
            {
                drpuom.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[21].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[22] != null && ds1.Tables[0].Rows[0].ItemArray[22].ToString() != "")
            {
                drpbg.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[22].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[23] != null && ds1.Tables[0].Rows[0].ItemArray[23].ToString() != "")
            {
                drpvalid.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
            }

            /*new change ankuir for agency*/
            if (ds1.Tables[0].Rows[0].ItemArray[24] != null && ds1.Tables[0].Rows[0].ItemArray[24].ToString() != "")
            {
                drpageratecode.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[24].ToString();
            }


            if (ds1.Tables[0].Rows[0].ItemArray[25] != null && ds1.Tables[0].Rows[0].ItemArray[25].ToString() != "")
            {
                drpaudit.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[26] != null && ds1.Tables[0].Rows[0].ItemArray[26].ToString() != "")
            {
                if (ds1.Tables[0].Rows[0].ItemArray[26].ToString() == "y")
                {
                    chkinsertdate.Checked = true;
                    txtcut.Enabled = true;
                }
                else
                {
                    chkinsertdate.Checked = false;
                    txtcut.Enabled = false;
                }
            }

            if (ds1.Tables[0].Rows[0].ItemArray[27] != null && ds1.Tables[0].Rows[0].ItemArray[27].ToString() != "")
            {
                if (ds1.Tables[0].Rows[0].ItemArray[27].ToString() == "y")
                    chkagencycomm.Checked = true;
                else
                    chkagencycomm.Checked = false;
            }
            if (ds1.Tables[0].Rows[0]["DOCKIT_BOOKING"] != null && ds1.Tables[0].Rows[0]["DOCKIT_BOOKING"].ToString() != "")
            {
                drpdockitbooking.SelectedValue = ds1.Tables[0].Rows[0]["DOCKIT_BOOKING"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CUTOFFTIME"] != null && ds1.Tables[0].Rows[0]["CUTOFFTIME"].ToString() != "")
            {
                txtcut.Text = ds1.Tables[0].Rows[0]["CUTOFFTIME"].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[28] != null && ds1.Tables[0].Rows[0].ItemArray[28].ToString() != "")
            {

                drprateaudit.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[28].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[29] != null && ds1.Tables[0].Rows[0].ItemArray[29].ToString() != "")
            {

                drpbillaudit.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[30] != null && ds1.Tables[0].Rows[0].ItemArray[30].ToString() != "")
            {

                drpbilledtype.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
            }


            if (ds1.Tables[0].Rows[0].ItemArray[31] != null && ds1.Tables[0].Rows[0].ItemArray[31].ToString() != "")
            {

                drppremtype.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[31].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[32] != null && ds1.Tables[0].Rows[0].ItemArray[32].ToString() != "")
            {

                drpcopybooking.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[32].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[33] != null && ds1.Tables[0].Rows[0].ItemArray[33].ToString() != "")
            {

                drpratecompany.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[33].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[34] != null && ds1.Tables[0].Rows[0].ItemArray[34].ToString() != "")
            {

                drpagncomm.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[34].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[35] != null && ds1.Tables[0].Rows[0].ItemArray[35].ToString() != "")
            {

                drpagnlinkretainer.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[35].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[36] != null && ds1.Tables[0].Rows[0].ItemArray[36].ToString() != "")
            {

                drpsubrate.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[36].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[37] != null && ds1.Tables[0].Rows[0].ItemArray[37].ToString() != "")
            {
                drpclassifiedbill.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[37].ToString();
            }

            if (ds1.Tables[0].Rows[0].ItemArray[38] != null && ds1.Tables[0].Rows[0].ItemArray[38].ToString() != "")
            {
                drpdisplaybillnew.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[38].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[39] != null && ds1.Tables[0].Rows[0].ItemArray[39].ToString() != "")
            {

                drpbillformat.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[39].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[40] != null && ds1.Tables[0].Rows[0].ItemArray[40].ToString() != "")
            {

                drpratechk.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[40].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[41] != null && ds1.Tables[0].Rows[0].ItemArray[41].ToString() != "")
            {

                drpallpkg.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[41].ToString();
            }
            if (ds1.Tables[0].Rows[0].ItemArray[42] != null && ds1.Tables[0].Rows[0].ItemArray[42].ToString() != "")
            {

                drpdayrate.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[42].ToString();
            }
            if (ds1.Tables[0].Rows[0]["SCHEME_TYPE"] != null && ds1.Tables[0].Rows[0]["SCHEME_TYPE"].ToString() != "")
            {
                drpscheme.SelectedValue = ds1.Tables[0].Rows[0]["SCHEME_TYPE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["DISP_CLSBILL"] != null && ds1.Tables[0].Rows[0]["DISP_CLSBILL"].ToString() != "")
            {
                drpIncludeClassi.SelectedValue = ds1.Tables[0].Rows[0]["DISP_CLSBILL"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RECEIPT_FORMAT"] != null && ds1.Tables[0].Rows[0]["RECEIPT_FORMAT"].ToString() != "")
            {
                drp_receiptformat.SelectedValue = ds1.Tables[0].Rows[0]["RECEIPT_FORMAT"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["CASH_RECEIPT_BILL"] != null && ds1.Tables[0].Rows[0]["CASH_RECEIPT_BILL"].ToString() != "")
            {
                drpcashreceipt.SelectedValue = ds1.Tables[0].Rows[0]["CASH_RECEIPT_BILL"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["BILL_ORDERWSLAST"] != null && ds1.Tables[0].Rows[0]["BILL_ORDERWSLAST"].ToString() != "")
            {
                drp_billorderwiselast.SelectedValue = ds1.Tables[0].Rows[0]["BILL_ORDERWSLAST"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["FLOOR_CHK"] != null && ds1.Tables[0].Rows[0]["FLOOR_CHK"].ToString() != "")
            {
                drpfloor.SelectedValue = ds1.Tables[0].Rows[0]["FLOOR_CHK"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["DISP_CASHBILL"] != null && ds1.Tables[0].Rows[0]["DISP_CASHBILL"].ToString() != "")
            {
                drpinclcashdisp.SelectedValue = ds1.Tables[0].Rows[0]["DISP_CASHBILL"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["CLA_CASHBILL"] != null && ds1.Tables[0].Rows[0]["CLA_CASHBILL"].ToString() != "")
            {
                drpinclcashcls.SelectedValue = ds1.Tables[0].Rows[0]["CLA_CASHBILL"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RATE_AUDIT_PREF"] != null && ds1.Tables[0].Rows[0]["RATE_AUDIT_PREF"].ToString() != "")
            {
                drprateaudit_pref.SelectedValue = ds1.Tables[0].Rows[0]["RATE_AUDIT_PREF"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["BARCODING_ALLOWED"] != null && ds1.Tables[0].Rows[0]["BARCODING_ALLOWED"].ToString() != "")
            {
                drpbarcode.SelectedValue = ds1.Tables[0].Rows[0]["BARCODING_ALLOWED"].ToString();
            }



            if (ds1.Tables[0].Rows[0]["FMG_BILL_DIS"] != null && ds1.Tables[0].Rows[0]["FMG_BILL_DIS"].ToString() != "")
            {
                drpfmgbills.SelectedValue = ds1.Tables[0].Rows[0]["FMG_BILL_DIS"].ToString();
            }




            if (ds1.Tables[0].Rows[0]["BILL_DISP_CASHBILL"] != null && ds1.Tables[0].Rows[0]["BILL_DISP_CASHBILL"].ToString() != "")
            {
                drp_billdisp_ca.SelectedValue = ds1.Tables[0].Rows[0]["BILL_DISP_CASHBILL"].ToString();
            }



            if (ds1.Tables[0].Rows[0]["BILL_CLA_CASHBILL"] != null && ds1.Tables[0].Rows[0]["BILL_CLA_CASHBILL"].ToString() != "")
            {
                drp_billcls_ca.SelectedValue = ds1.Tables[0].Rows[0]["BILL_CLA_CASHBILL"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["BACKDATERECEIPT"] != null && ds1.Tables[0].Rows[0]["BACKDATERECEIPT"].ToString() != "")
            {
                drpbackdate.SelectedValue = ds1.Tables[0].Rows[0]["BACKDATERECEIPT"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["ROWISE_CASHBOOKING"] != null && ds1.Tables[0].Rows[0]["ROWISE_CASHBOOKING"].ToString() != "")
            {
                drp_cashbill.SelectedValue = ds1.Tables[0].Rows[0]["ROWISE_CASHBOOKING"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["APPROVAL"] != null && ds1.Tables[0].Rows[0]["APPROVAL"].ToString() != "")
            {
                drpapproval.SelectedValue = ds1.Tables[0].Rows[0]["APPROVAL"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["BACK_DAYS"] != null && ds1.Tables[0].Rows[0]["BACK_DAYS"].ToString() != "")
            {
                txtpackegeentry.Text = ds1.Tables[0].Rows[0]["BACK_DAYS"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CASH_DISCOUNT"] != null && ds1.Tables[0].Rows[0]["CASH_DISCOUNT"].ToString() != "")
            {
                txtcsamt.Text = ds1.Tables[0].Rows[0]["CASH_DISCOUNT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CASH_DISCOUNTTYPE"] != null && ds1.Tables[0].Rows[0]["CASH_DISCOUNTTYPE"].ToString() != "")
            {
                drpcashdis.Text = ds1.Tables[0].Rows[0]["CASH_DISCOUNTTYPE"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["Allowed_old_date"] != null && ds1.Tables[0].Rows[0]["Allowed_old_date"].ToString() != "")
            {

                drpallowprevbooking.SelectedValue = ds1.Tables[0].Rows[0]["Allowed_old_date"].ToString();


            }

            if (ds1.Tables[0].Rows[0]["AGENCYCOMM_SEQ_COM"] != null && ds1.Tables[0].Rows[0]["AGENCYCOMM_SEQ_COM"].ToString() != "")
            {
                drpagencycomm.SelectedValue = ds1.Tables[0].Rows[0]["AGENCYCOMM_SEQ_COM"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["SEPRATE_CASHIER"] != null && ds1.Tables[0].Rows[0]["SEPRATE_CASHIER"].ToString() != "")
            {
                drpsep_rate.SelectedValue = ds1.Tables[0].Rows[0]["SEPRATE_CASHIER"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["DISP_BILLING_CRITERIA"] != null && ds1.Tables[0].Rows[0]["DISP_BILLING_CRITERIA"].ToString() != "")
            {
                drpdispbillcr.SelectedValue = ds1.Tables[0].Rows[0]["DISP_BILLING_CRITERIA"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CLSD_BILLING_CRITERIA"] != null && ds1.Tables[0].Rows[0]["CLSD_BILLING_CRITERIA"].ToString() != "")
            {
                drpclasbillcr.SelectedValue = ds1.Tables[0].Rows[0]["CLSD_BILLING_CRITERIA"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_MANY_TIME_POSTING"] != null && ds1.Tables[0].Rows[0]["CIR_MANY_TIME_POSTING"].ToString() != "")
            {
                drpmtpostallow.SelectedValue = ds1.Tables[0].Rows[0]["CIR_MANY_TIME_POSTING"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_BACKDAYS_POSTING"] != null && ds1.Tables[0].Rows[0]["CIR_BACKDAYS_POSTING"].ToString() != "")
            {
                txtbkpost.Text = ds1.Tables[0].Rows[0]["CIR_BACKDAYS_POSTING"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_MAX_RETURN_ALLOW"] != null && ds1.Tables[0].Rows[0]["CIR_MAX_RETURN_ALLOW"].ToString() != "")
            {
                txtmaxret.Text = ds1.Tables[0].Rows[0]["CIR_MAX_RETURN_ALLOW"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_RETURN_LIMIT_ALLOW"] != null && ds1.Tables[0].Rows[0]["CIR_RETURN_LIMIT_ALLOW"].ToString() != "")
            {
                txtreturn.SelectedValue = ds1.Tables[0].Rows[0]["CIR_RETURN_LIMIT_ALLOW"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_NO_OF_CHQBOUNCE"] != null && ds1.Tables[0].Rows[0]["CIR_NO_OF_CHQBOUNCE"].ToString() != "")
            {
                txtchkbounce.Text = ds1.Tables[0].Rows[0]["CIR_NO_OF_CHQBOUNCE"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_DAYS_CHQBOUNCE"] != null && ds1.Tables[0].Rows[0]["CIR_DAYS_CHQBOUNCE"].ToString() != "")
            {
                txtchkreceive.Text = ds1.Tables[0].Rows[0]["CIR_DAYS_CHQBOUNCE"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_RETURN_DAYS"] != null && ds1.Tables[0].Rows[0]["CIR_RETURN_DAYS"].ToString() != "")
            {
                txtreturndate.Text = ds1.Tables[0].Rows[0]["CIR_RETURN_DAYS"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CIR_SUP_ORDER_LIMIT"] != null && ds1.Tables[0].Rows[0]["CIR_SUP_ORDER_LIMIT"].ToString() != "")
            {
                txtchgsupporder.Text = ds1.Tables[0].Rows[0]["CIR_SUP_ORDER_LIMIT"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["MAX_PUBLISHDAYS"] != null && ds1.Tables[0].Rows[0]["MAX_PUBLISHDAYS"].ToString() != "")
            {
                txtmaxpubday.Text = ds1.Tables[0].Rows[0]["MAX_PUBLISHDAYS"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["BILLNO_PERIODICITY"] != null && ds1.Tables[0].Rows[0]["BILLNO_PERIODICITY"].ToString() != "")
            {
                drpbill_periodicity.SelectedValue = ds1.Tables[0].Rows[0]["BILLNO_PERIODICITY"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["SPECIALDISC_TRANS_EDIT"] != null && ds1.Tables[0].Rows[0]["SPECIALDISC_TRANS_EDIT"].ToString() != "")
            {
                drpspl_trans_edit.SelectedValue = ds1.Tables[0].Rows[0]["SPECIALDISC_TRANS_EDIT"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["SHARING_TRANS"] != null && ds1.Tables[0].Rows[0]["SHARING_TRANS"].ToString() != "")
            {
                drpspl_dis_trans_editable.SelectedValue = ds1.Tables[0].Rows[0]["SHARING_TRANS"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["MULTIPACKAGE_SEL_TRANS"] != null && ds1.Tables[0].Rows[0]["MULTIPACKAGE_SEL_TRANS"].ToString() != "")
            {
                drpmul_pac_sel_trans.SelectedValue = ds1.Tables[0].Rows[0]["MULTIPACKAGE_SEL_TRANS"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["SCHEME_MINWORD"] != null && ds1.Tables[0].Rows[0]["SCHEME_MINWORD"].ToString() != "")
            {
                drpshmon_minword.SelectedValue = ds1.Tables[0].Rows[0]["SCHEME_MINWORD"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["TRADE_SPLCHARGE"] != null && ds1.Tables[0].Rows[0]["TRADE_SPLCHARGE"].ToString() != "")
            {
                drptradon_spcrg.SelectedValue = ds1.Tables[0].Rows[0]["TRADE_SPLCHARGE"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CREDIT_RECIPT"] != null && ds1.Tables[0].Rows[0]["CREDIT_RECIPT"].ToString() != "")
            {
                drpcreditrecpt.SelectedValue = ds1.Tables[0].Rows[0]["CREDIT_RECIPT"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["RATE_AUTHORIZATION"] != null && ds1.Tables[0].Rows[0]["RATE_AUTHORIZATION"].ToString() != "")
            {
                drprateaut.SelectedValue = ds1.Tables[0].Rows[0]["RATE_AUTHORIZATION"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["F2_RECORD"] != null && ds1.Tables[0].Rows[0]["F2_RECORD"].ToString() != "")
            {
                txtf2day.Text = ds1.Tables[0].Rows[0]["F2_RECORD"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["PUBLISHAD_EDIT_RATEAUDIT"] != null && ds1.Tables[0].Rows[0]["PUBLISHAD_EDIT_RATEAUDIT"].ToString() != "")
            {
                drprateaudit_modify.SelectedValue = ds1.Tables[0].Rows[0]["PUBLISHAD_EDIT_RATEAUDIT"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["BINDREVENUE_CENTER"] != null && ds1.Tables[0].Rows[0]["BINDREVENUE_CENTER"].ToString() != "")
            {
                drpbindrevenuecenter.SelectedValue = ds1.Tables[0].Rows[0]["BINDREVENUE_CENTER"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["fa_ledger_allow"] != null && ds1.Tables[0].Rows[0]["fa_ledger_allow"].ToString() != "")
            {
                drp_led_allow.SelectedValue = ds1.Tables[0].Rows[0]["fa_ledger_allow"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["clearance_type_allow"] != null && ds1.Tables[0].Rows[0]["clearance_type_allow"].ToString() != "")
            {
                drp_clear_allow.SelectedValue = ds1.Tables[0].Rows[0]["clearance_type_allow"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["REPEAT_DAY_TYPE"] != null && ds1.Tables[0].Rows[0]["REPEAT_DAY_TYPE"].ToString() != "")
            {
                drprepeatingdaytype.SelectedValue = ds1.Tables[0].Rows[0]["REPEAT_DAY_TYPE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["PREMIUM_EDIT"] != null && ds1.Tables[0].Rows[0]["PREMIUM_EDIT"].ToString() != "")
            {
                drpeditableintransaction.SelectedValue = ds1.Tables[0].Rows[0]["PREMIUM_EDIT"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["BILL_GENERATION_PRIOR"] != null && ds1.Tables[0].Rows[0]["BILL_GENERATION_PRIOR"].ToString() != "")
            {
                drp_genratebill.SelectedValue = ds1.Tables[0].Rows[0]["BILL_GENERATION_PRIOR"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["PUBLICATION_HO"] != null && ds1.Tables[0].Rows[0]["PUBLICATION_HO"].ToString() != "")
            {
                drp_publication.SelectedValue = ds1.Tables[0].Rows[0]["PUBLICATION_HO"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["SPLDISC_ALLOWPREM"] != null && ds1.Tables[0].Rows[0]["SPLDISC_ALLOWPREM"].ToString() != "")
            {
                drpallow_prem.SelectedValue = ds1.Tables[0].Rows[0]["SPLDISC_ALLOWPREM"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["BILL_SCHEME"] != null && ds1.Tables[0].Rows[0]["BILL_SCHEME"].ToString() != "")
            {
                drp_scheme_billing.SelectedValue = ds1.Tables[0].Rows[0]["BILL_SCHEME"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["ALLOWED_PDC_DAYS_RECEIPT"] != null && ds1.Tables[0].Rows[0]["ALLOWED_PDC_DAYS_RECEIPT"].ToString() != "")
            {
                txt_allowed_cdp.Text = ds1.Tables[0].Rows[0]["ALLOWED_PDC_DAYS_RECEIPT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["AD_TYPE_MANUL_BILL"] != null && ds1.Tables[0].Rows[0]["AD_TYPE_MANUL_BILL"].ToString() != "")
            {
                drp_adtype.SelectedValue = ds1.Tables[0].Rows[0]["AD_TYPE_MANUL_BILL"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["RO_OUTSTAND"] != null && ds1.Tables[0].Rows[0]["RO_OUTSTAND"].ToString() != "")
            {
                DRPRO_OUTSTAND_P.SelectedValue = ds1.Tables[0].Rows[0]["RO_OUTSTAND"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["GENRATE_CIR_AGCD"] != null && ds1.Tables[0].Rows[0]["GENRATE_CIR_AGCD"].ToString() != "")
            {
                drpgencycodegeneration.SelectedValue = ds1.Tables[0].Rows[0]["GENRATE_CIR_AGCD"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["DISP_AUDITBKG"] != null && ds1.Tables[0].Rows[0]["DISP_AUDITBKG"].ToString() != "")
            {
                drpdispauditbk.SelectedValue = ds1.Tables[0].Rows[0]["DISP_AUDITBKG"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_DIS_AUTO_POSTING"] != null && ds1.Tables[0].Rows[0]["CIR_DIS_AUTO_POSTING"].ToString() != "")
            {
                drpAutosupplypostingrequired.SelectedValue = ds1.Tables[0].Rows[0]["CIR_DIS_AUTO_POSTING"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RELAUTHREQON"] != null && ds1.Tables[0].Rows[0]["RELAUTHREQON"].ToString() != "")
            {
                drpAuthorization.SelectedValue = ds1.Tables[0].Rows[0]["RELAUTHREQON"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_AUTO_APPROVAL_UNSOLD"] != null && ds1.Tables[0].Rows[0]["CIR_AUTO_APPROVAL_UNSOLD"].ToString() != "")
            {
                drpUNSOLDAPPROVAL.SelectedValue = ds1.Tables[0].Rows[0]["CIR_AUTO_APPROVAL_UNSOLD"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_AUTO_PHYSICAL_UNSOLD"] != null && ds1.Tables[0].Rows[0]["CIR_AUTO_PHYSICAL_UNSOLD"].ToString() != "")
            {
                drpUNSOLDPHYSICAL.SelectedValue = ds1.Tables[0].Rows[0]["CIR_AUTO_PHYSICAL_UNSOLD"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_UNSOLD_INCLUDE_INCT"] != null && ds1.Tables[0].Rows[0]["CIR_UNSOLD_INCLUDE_INCT"].ToString() != "")
            {
                drpINCLUDEUNSOLD.SelectedValue = ds1.Tables[0].Rows[0]["CIR_UNSOLD_INCLUDE_INCT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_UNSOLD_INCLUDE_INSFEE"] != null && ds1.Tables[0].Rows[0]["CIR_UNSOLD_INCLUDE_INSFEE"].ToString() != "")
            {
                drpINCLUDEUNSOLDININSERTIONFEEPROCESS.SelectedValue = ds1.Tables[0].Rows[0]["CIR_UNSOLD_INCLUDE_INSFEE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_UNSOLD_ON_RECEIVED_DT"] != null && ds1.Tables[0].Rows[0]["CIR_UNSOLD_ON_RECEIVED_DT"].ToString() != "")
            {
                drpUNSOLDONSUPPLYORRECEIVEDDATE.SelectedValue = ds1.Tables[0].Rows[0]["CIR_UNSOLD_ON_RECEIVED_DT"].ToString();

            }

            if (ds1.Tables[0].Rows[0]["AGENCY_UNBLOCK_APPROVAL"] != null && ds1.Tables[0].Rows[0]["AGENCY_UNBLOCK_APPROVAL"].ToString() != "")
            {
                drpAgencyunblockapproval.SelectedValue = ds1.Tables[0].Rows[0]["AGENCY_UNBLOCK_APPROVAL"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["UNBLOCK_APPROVAL_OUTSIDE_LIMIT"] != null && ds1.Tables[0].Rows[0]["UNBLOCK_APPROVAL_OUTSIDE_LIMIT"].ToString() != "")
            {
                drpUnblockApprovalOutsideCreditLimit.SelectedValue = ds1.Tables[0].Rows[0]["UNBLOCK_APPROVAL_OUTSIDE_LIMIT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_BILL_PUBLWISE"] != null && ds1.Tables[0].Rows[0]["CIR_BILL_PUBLWISE"].ToString() != "")
            {
                drpbillingpublicationwise.SelectedValue = ds1.Tables[0].Rows[0]["CIR_BILL_PUBLWISE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["ALLOW_FOLLOW_DT_BOOOK"] != null && ds1.Tables[0].Rows[0]["ALLOW_FOLLOW_DT_BOOOK"].ToString() != "")
            {
                drpALLOW_FOLLOW_DT_BOOOK.SelectedValue = ds1.Tables[0].Rows[0]["ALLOW_FOLLOW_DT_BOOOK"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["RECORDS_ON_PAGE"] != null && ds1.Tables[0].Rows[0]["RECORDS_ON_PAGE"].ToString() != "")
            {
                txtpaging.Text = ds1.Tables[0].Rows[0]["RECORDS_ON_PAGE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RECORDS_ON_PRINT"] != null && ds1.Tables[0].Rows[0]["RECORDS_ON_PRINT"].ToString() != "")
            {
                txtprint.Text = ds1.Tables[0].Rows[0]["RECORDS_ON_PRINT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["HEADER_ON_PAGE"] != null && ds1.Tables[0].Rows[0]["HEADER_ON_PAGE"].ToString() != "")
            {
                Drophead.SelectedValue = ds1.Tables[0].Rows[0]["HEADER_ON_PAGE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["Agency_Required"] != null && ds1.Tables[0].Rows[0]["Agency_Required"].ToString() != "")
            {
                drpagency.SelectedValue = ds1.Tables[0].Rows[0]["Agency_Required"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["Region_Required"] != null && ds1.Tables[0].Rows[0]["Region_Required"].ToString() != "")
            {
                drpregion.SelectedValue = ds1.Tables[0].Rows[0]["Region_Required"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CRM_SUPPLY_TYPE_PAID"] != null && ds1.Tables[0].Rows[0]["CRM_SUPPLY_TYPE_PAID"].ToString() != "")
            {
                drpsubscription_paid_supply_type.SelectedValue = ds1.Tables[0].Rows[0]["CRM_SUPPLY_TYPE_PAID"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CRM_SUPPLY_TYPE_FREE"] != null && ds1.Tables[0].Rows[0]["CRM_SUPPLY_TYPE_FREE"].ToString() != "")
            {
                drpsubscription_free_supply_type.SelectedValue = ds1.Tables[0].Rows[0]["CRM_SUPPLY_TYPE_FREE"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CURRENCY_MEASUREMENT"] != null && ds1.Tables[0].Rows[0]["CURRENCY_MEASUREMENT"].ToString() != "")
            {
                drpCURRENCY_MEASUREMENT.SelectedValue = ds1.Tables[0].Rows[0]["CURRENCY_MEASUREMENT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["ROKEYCHECK"] != null && ds1.Tables[0].Rows[0]["ROKEYCHECK"].ToString() != "")
            {
                drprokey.SelectedValue = ds1.Tables[0].Rows[0]["ROKEYCHECK"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["Space_area"] != null && ds1.Tables[0].Rows[0]["Space_area"].ToString() != "")
            {
                drpspacearea.SelectedValue = ds1.Tables[0].Rows[0]["Space_area"].ToString();
            }

           
            if (ds1.Tables[0].Rows[0]["EDITABLE_AGENCY_COMM"] != null && ds1.Tables[0].Rows[0]["EDITABLE_AGENCY_COMM"].ToString() != "")
            {
                drpadddiscount.SelectedValue = ds1.Tables[0].Rows[0]["EDITABLE_AGENCY_COMM"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CANCELLATION_CHARGE"] != null && ds1.Tables[0].Rows[0]["CANCELLATION_CHARGE"].ToString() != "")
            {
                drpcancharges.SelectedValue = ds1.Tables[0].Rows[0]["CANCELLATION_CHARGE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["TAXI_ENTRY_TYPE"] != null && ds1.Tables[0].Rows[0]["TAXI_ENTRY_TYPE"].ToString() != "")
            {
                drpentry_type.SelectedValue = ds1.Tables[0].Rows[0]["TAXI_ENTRY_TYPE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["APPROVAL_WITH"] != null && ds1.Tables[0].Rows[0]["APPROVAL_WITH"].ToString() != "")
            {
                drpApprovalWith.SelectedValue = ds1.Tables[0].Rows[0]["APPROVAL_WITH"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["TDS_AUTO_CN"] != null && ds1.Tables[0].Rows[0]["TDS_AUTO_CN"].ToString() != "")
            {
                drpAuto_TDS_Credit_Note.SelectedValue = ds1.Tables[0].Rows[0]["TDS_AUTO_CN"].ToString();
                if (drpAuto_TDS_Credit_Note.SelectedValue == "Y")
                {
                    txtTDS_Reason.Enabled = true;
                    txtDebit_Account_Head.Enabled = true;
                    txtcredit_Account_Head.Enabled = true;
                }
            }

            if (ds1.Tables[0].Rows[0]["TDS_AUTO_REASON"] != null && ds1.Tables[0].Rows[0]["TDS_AUTO_REASON"].ToString() != "")
            {
                txtTDS_Reason.Text = ds1.Tables[0].Rows[0]["TDS_AUTO_REASON"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["TDS_DB_CDP"] != null && ds1.Tables[0].Rows[0]["TDS_DB_CDP"].ToString() != "")
            {
                txtDebit_Account_Head.Text = ds1.Tables[0].Rows[0]["TDS_DB_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["TDS_CR_CDP"] != null && ds1.Tables[0].Rows[0]["TDS_CR_CDP"].ToString() != "")
            {
                txtcredit_Account_Head.Text = ds1.Tables[0].Rows[0]["TDS_CR_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["SER_TAX_AUTO_CN"] != null && ds1.Tables[0].Rows[0]["SER_TAX_AUTO_CN"].ToString() != "")
            {
                drpauto_service_tax_credit_note.SelectedValue = ds1.Tables[0].Rows[0]["SER_TAX_AUTO_CN"].ToString();

                if (drpauto_service_tax_credit_note.SelectedValue == "Y")
                {
                    txtTax_Reason.Enabled = true;
                    txtDebit_Account_Head_For_Service_Tax.Enabled = true;
                    txtCredit_Account_Head_For_Service_Tax.Enabled = true;
                }
            }

            if (ds1.Tables[0].Rows[0]["SER_TAX_AUTO_REASON"] != null && ds1.Tables[0].Rows[0]["SER_TAX_AUTO_REASON"].ToString() != "")
            {
                txtTax_Reason.Text = ds1.Tables[0].Rows[0]["SER_TAX_AUTO_REASON"].ToString();
                
            }

            if (ds1.Tables[0].Rows[0]["SER_TAX_DB_CDP"] != null && ds1.Tables[0].Rows[0]["SER_TAX_DB_CDP"].ToString() != "")
            {
                txtDebit_Account_Head_For_Service_Tax.Text = ds1.Tables[0].Rows[0]["SER_TAX_DB_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["SER_TAX_CR_CDP"] != null && ds1.Tables[0].Rows[0]["SER_TAX_CR_CDP"].ToString() != "")
            {
                txtCredit_Account_Head_For_Service_Tax.Text = ds1.Tables[0].Rows[0]["SER_TAX_CR_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["PKK_AUTO_CN"] != null && ds1.Tables[0].Rows[0]["PKK_AUTO_CN"].ToString() != "")
            {
                drpAuto_Patrakar_Kalyan_Kosh_Credit_Note.SelectedValue = ds1.Tables[0].Rows[0]["PKK_AUTO_CN"].ToString();
                if (drpAuto_Patrakar_Kalyan_Kosh_Credit_Note.SelectedValue == "Y")
                {
                    txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh.Enabled = true;
                    txtPatrakar_Kalyan_Kosh_Reason.Enabled = true;
                    txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh.Enabled = true;
                }
            
            
            }

            if (ds1.Tables[0].Rows[0]["PKK_AUTO_REASON"] != null && ds1.Tables[0].Rows[0]["PKK_AUTO_REASON"].ToString() != "")
            {
                txtPatrakar_Kalyan_Kosh_Reason.Text = ds1.Tables[0].Rows[0]["PKK_AUTO_REASON"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["PKK_DB_CDP"] != null && ds1.Tables[0].Rows[0]["PKK_DB_CDP"].ToString() != "")
            {
                txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh.Text = ds1.Tables[0].Rows[0]["PKK_DB_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["PKK_CR_CDP"] != null && ds1.Tables[0].Rows[0]["PKK_CR_CDP"].ToString() != "")
            {
                txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh.Text = ds1.Tables[0].Rows[0]["PKK_CR_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["BANK_CHG_AUTO_CN"] != null && ds1.Tables[0].Rows[0]["BANK_CHG_AUTO_CN"].ToString() != "")
            {
                drpAuto_Bank_Charges_Credit_Note.SelectedValue = ds1.Tables[0].Rows[0]["BANK_CHG_AUTO_CN"].ToString();


                if (drpAuto_Bank_Charges_Credit_Note.SelectedValue == "Y")
                {
                    txtBank_Charges_Reason.Enabled = true;
                    txtDebit_Account_Head_For_Bank_Charges.Enabled = true;
                    txtCredit_Account_Head_For_Bank_Charges.Enabled = true;
                }
            }

            if (ds1.Tables[0].Rows[0]["BANK_CHG_AUTO_REASON"] != null && ds1.Tables[0].Rows[0]["BANK_CHG_AUTO_REASON"].ToString() != "")
            {

                txtBank_Charges_Reason.Text = ds1.Tables[0].Rows[0]["BANK_CHG_AUTO_REASON"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["BANK_CHG_DB_CDP"] != null && ds1.Tables[0].Rows[0]["BANK_CHG_DB_CDP"].ToString() != "")
            {
                txtDebit_Account_Head_For_Bank_Charges.Text = ds1.Tables[0].Rows[0]["BANK_CHG_DB_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["BANK_CHG_CR_CDP"] != null && ds1.Tables[0].Rows[0]["BANK_CHG_CR_CDP"].ToString() != "")
            {
                txtCredit_Account_Head_For_Bank_Charges.Text = ds1.Tables[0].Rows[0]["BANK_CHG_CR_CDP"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CIR_WIEGHT_CALC_REQ"] != null && ds1.Tables[0].Rows[0]["CIR_WIEGHT_CALC_REQ"].ToString() != "")
            {
                drpweightcal.SelectedValue = ds1.Tables[0].Rows[0]["CIR_WIEGHT_CALC_REQ"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["GEN_RCT_TYP"] != null && ds1.Tables[0].Rows[0]["GEN_RCT_TYP"].ToString() != "")
            {
                drpgenerate_recipt_no.SelectedValue = ds1.Tables[0].Rows[0]["GEN_RCT_TYP"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["PRODUCT_BRAND_REQ"] != null && ds1.Tables[0].Rows[0]["PRODUCT_BRAND_REQ"].ToString() != "")
            {
                drp_misdata.SelectedValue = ds1.Tables[0].Rows[0]["PRODUCT_BRAND_REQ"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["ALLOWPREM_CARD_DISC_RATE"] != null && ds1.Tables[0].Rows[0]["ALLOWPREM_CARD_DISC_RATE"].ToString() != "")
            {
                drpallowpremium.SelectedValue = ds1.Tables[0].Rows[0]["ALLOWPREM_CARD_DISC_RATE"].ToString();
            }



            if (ds1.Tables[0].Rows[0]["FINANCE_CADE"] != null && ds1.Tables[0].Rows[0]["FINANCE_CADE"].ToString() != "")
            {
                drpfinancecode.SelectedValue = ds1.Tables[0].Rows[0]["FINANCE_CADE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["EXECUTIVE_PUBLICATION_VISE"] != null && ds1.Tables[0].Rows[0]["EXECUTIVE_PUBLICATION_VISE"].ToString() != "")
            {
                drpexecutive.SelectedValue = ds1.Tables[0].Rows[0]["EXECUTIVE_PUBLICATION_VISE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["EXECUTIVECREDITLIMIT"] != null && ds1.Tables[0].Rows[0]["EXECUTIVECREDITLIMIT"].ToString() != "")
            {
                drpexec.SelectedValue = ds1.Tables[0].Rows[0]["EXECUTIVECREDITLIMIT"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["MRV_BASED_ON"] != null && ds1.Tables[0].Rows[0]["MRV_BASED_ON"].ToString() != "")
            {
                drpmrv.SelectedValue = ds1.Tables[0].Rows[0]["MRV_BASED_ON"].ToString();
            }
          

            if (ds1.Tables[0].Rows[0]["FIXED_TRANSACTION_AMT"] != null && ds1.Tables[0].Rows[0]["FIXED_TRANSACTION_AMT"].ToString() != "")
            {
                txtfxd_tran_amt.Text = ds1.Tables[0].Rows[0]["FIXED_TRANSACTION_AMT"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["TRADE_DIS_BASED_ON"] != null && ds1.Tables[0].Rows[0]["TRADE_DIS_BASED_ON"].ToString() != "")
            {
                drptradedis.SelectedValue = ds1.Tables[0].Rows[0]["TRADE_DIS_BASED_ON"].ToString();
            }




            if (ds1.Tables[0].Rows[0]["RETAIN_COMM_ON_LAST_RECDATE"] != null && ds1.Tables[0].Rows[0]["RETAIN_COMM_ON_LAST_RECDATE"].ToString() != "")
            {
                drpretcomm.SelectedValue = ds1.Tables[0].Rows[0]["RETAIN_COMM_ON_LAST_RECDATE"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["SUPPLIMENTARY_BILL_REQ"] != null && ds1.Tables[0].Rows[0]["SUPPLIMENTARY_BILL_REQ"].ToString() != "")
            {
                drpsuppbill.SelectedValue = ds1.Tables[0].Rows[0]["SUPPLIMENTARY_BILL_REQ"].ToString();
            }



            if (ds1.Tables[0].Rows[0]["RET_COMM_TDS_ASSEY"] != null && ds1.Tables[0].Rows[0]["RET_COMM_TDS_ASSEY"].ToString() != "")
            {
                txttdsnametype.Text = ds1.Tables[0].Rows[0]["RET_COMM_TDS_ASSEY"].ToString();
                hdntdsnametype.Value = ds1.Tables[0].Rows[0]["RET_COMM_TDS_ASSEY"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["RET_COMM_TDS_SEC_CODE"] != null && ds1.Tables[0].Rows[0]["RET_COMM_TDS_SEC_CODE"].ToString() != "")
            {
                txtTdsSecName.Text = ds1.Tables[0].Rows[0]["RET_COMM_TDS_SEC_CODE"].ToString();
                hdntdssecname.Value = ds1.Tables[0].Rows[0]["RET_COMM_TDS_SEC_CODE"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["RET_COMM_NOPAN_TDS_RATE"] != null && ds1.Tables[0].Rows[0]["RET_COMM_NOPAN_TDS_RATE"].ToString() != "")
            {
                retno.Text = ds1.Tables[0].Rows[0]["RET_COMM_NOPAN_TDS_RATE"].ToString();
            }


            if (ds1.Tables[0].Rows[0]["RET_COMM_BANK_RECO_REQ"] != null && ds1.Tables[0].Rows[0]["RET_COMM_BANK_RECO_REQ"].ToString() != "")
            {
                drpbankkreco.SelectedValue = ds1.Tables[0].Rows[0]["RET_COMM_BANK_RECO_REQ"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["REASON_FOR_INTT_ADBILL"] != null && ds1.Tables[0].Rows[0]["REASON_FOR_INTT_ADBILL"].ToString() != "")
            {
                txtretonoverdue.Text = ds1.Tables[0].Rows[0]["REASON_FOR_INTT_ADBILL"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["DOCTYP_FOR_INTT_ADBILL"] != null && ds1.Tables[0].Rows[0]["DOCTYP_FOR_INTT_ADBILL"].ToString() != "")
            {
                txtdoconoverdue.Text = ds1.Tables[0].Rows[0]["DOCTYP_FOR_INTT_ADBILL"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CHECKBOOKINGCREDITLIMIT"] != null && ds1.Tables[0].Rows[0]["CHECKBOOKINGCREDITLIMIT"].ToString() != "")
            {
                drpallowbooking.SelectedValue = ds1.Tables[0].Rows[0]["CHECKBOOKINGCREDITLIMIT"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["CHECKRODUPLICACY"] != null && ds1.Tables[0].Rows[0]["CHECKRODUPLICACY"].ToString() != "")
            {
                drpchkfordupreq.SelectedValue = ds1.Tables[0].Rows[0]["CHECKRODUPLICACY"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["withoutro"] != null && ds1.Tables[0].Rows[0]["withoutro"].ToString() != "")
            {
                ddlwithutro.SelectedValue = ds1.Tables[0].Rows[0]["withoutro"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["COMMON_GRID_ALLOW"] != null && ds1.Tables[0].Rows[0]["COMMON_GRID_ALLOW"].ToString() != "")
            {
                drpcommongrid.SelectedValue = ds1.Tables[0].Rows[0]["COMMON_GRID_ALLOW"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["RECIPT_AS_RO_NO"] != null && ds1.Tables[0].Rows[0]["RECIPT_AS_RO_NO"].ToString() != "")
            {
                drpreciptno.SelectedValue = ds1.Tables[0].Rows[0]["RECIPT_AS_RO_NO"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["RETAINER_EXEC_OUTSTANDING"] != null && ds1.Tables[0].Rows[0]["RETAINER_EXEC_OUTSTANDING"].ToString() != "")
            {
                drpret_exec.SelectedValue = ds1.Tables[0].Rows[0]["RETAINER_EXEC_OUTSTANDING"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["CASH_RECP_LINK_ADACC"] != null && ds1.Tables[0].Rows[0]["CASH_RECP_LINK_ADACC"].ToString() != "")
            {
                drpcashrecacc.SelectedValue = ds1.Tables[0].Rows[0]["CASH_RECP_LINK_ADACC"].ToString();
            }
            if (ds1.Tables[0].Rows[0]["DAY_VALIDATION_BOOKING_AGREED"] != null && ds1.Tables[0].Rows[0]["DAY_VALIDATION_BOOKING_AGREED"].ToString() != "")
            {
                txtdaybookagr.Text = ds1.Tables[0].Rows[0]["DAY_VALIDATION_BOOKING_AGREED"].ToString();
            }

            
        }
    }


    public void bindcurr()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer bindcurre = new NewAdbooking.classesoracle.updateprefer();
            ds = bindcurre.currbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.updateprefer bindcurre = new NewAdbooking.Classes.updateprefer();
            ds = bindcurre.currbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "currbindprefer_currbindprefer_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        drpcurr.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Currency-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcurr.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcurr.Items.Add(li);
            }

        }





    }



    private void bindsupplytypepaid()
    {
        string extra1 = "Y";
        string extra2 = "";
        string compcd = hiddencompcode.Value;
        string datefr = hiddendateformat.Value;
        drpsubscription_paid_supply_type.Items.Clear();
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.updateprefer delarea = new NewAdbooking.Classes.updateprefer();
            ds1 = delarea.getCsupply_type(compcd, datefr, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer delarea = new NewAdbooking.classesoracle.updateprefer();
            ds1 = delarea.getCsupply_type(compcd, datefr, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Cir_Supply_Type_Bind_Cir_Supply_Type_Bind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcd, datefr, extra1 };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
      
        ListItem li = new ListItem();
        li.Text = "--Select Supply Type--";
        li.Value = "";
        drpsubscription_paid_supply_type.Items.Add(li);
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[0].Rows[i]["SUP_TY_NAME"].ToString();
            li1.Value = ds1.Tables[0].Rows[i]["SUP_TY_CODE"].ToString();
            drpsubscription_paid_supply_type.Items.Add(li1);
        }
    }

    private void bindsupplytypefree()
    {
        string extra1 = "N";
        string extra2 = "";
        string compcd = hiddencompcode.Value;
        string datefr = hiddendateformat.Value;
        drpsubscription_free_supply_type.Items.Clear();
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.updateprefer delarea = new NewAdbooking.Classes.updateprefer();
            ds1 = delarea.getCsupply_type(compcd, datefr, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer delarea = new NewAdbooking.classesoracle.updateprefer();
            ds1 = delarea.getCsupply_type(compcd, datefr, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Cir_Supply_Type_Bind_Cir_Supply_Type_Bind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcd, datefr, extra1 };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li = new ListItem();
        li.Text = "--Select Supply Type--";
        li.Value = "";
        drpsubscription_free_supply_type.Items.Add(li);
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[0].Rows[i]["SUP_TY_NAME"].ToString();
            li1.Value = ds1.Tables[0].Rows[i]["SUP_TY_CODE"].ToString();
            drpsubscription_free_supply_type.Items.Add(li1);
        }
    }


    [Ajax.AjaxMethod]
    public string getaccountna(string compcode, string catcode)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer supost = new NewAdbooking.classesoracle.updateprefer();
            ds = supost.bind_account(compcode, catcode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                return fetchvalue;
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
           
            string procedureName = "ad_get_account_name";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            string[] parameterValueArray = { compcode, catcode };
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.updateprefer supost = new NewAdbooking.Classes.updateprefer();
            ds = supost.bind_account(compcode, catcode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                return fetchvalue;
            }
        }
        return fetchvalue;
    }




    [Ajax.AjaxMethod]
    public string getresoname(string compcode, string catcode)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer supost = new NewAdbooking.classesoracle.updateprefer();
            ds = supost.bind_resont(compcode, catcode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                return fetchvalue;
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {

            string procedureName = "AD_GET_REASONNAME";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            string[] parameterValueArray = { compcode, catcode };
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.updateprefer supost = new NewAdbooking.Classes.updateprefer();
            ds = supost.bind_resont(compcode, catcode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                return fetchvalue;
            }
        }
        return fetchvalue;
    }


    [Ajax.AjaxMethod]
    public DataSet bind_assesy(string CompCode, string Unit, string DocType, string dateformat, string extra1, string extra2, string psec_code)
    {
        // DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{

        //    finance.classesoracle.fin_vouchers vouchersentry = new finance.classesoracle.fin_vouchers();

        //    ds = vouchersentry.assesy(CompCode, Unit, DocType, dateformat, extra1, extra2);
        //}
        //else
        //{
        //    finance.Classes.fin_vouchers vouchersentry = new finance.Classes.fin_vouchers();

        //    ds = vouchersentry.assesy(CompCode, Unit, DocType, dateformat, extra1, extra2);
        //}
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.updateprefer voucherent = new NewAdbooking.classesoracle.updateprefer();
            ds = voucherent.fill_tds_ACCOUNT(CompCode, dateformat, extra1, extra2, "", psec_code, "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "fa_account_type_bind_fa_tdsheadbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { CompCode, dateformat, extra1, extra2, "", psec_code, "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.updateprefer voucherent = new NewAdbooking.Classes.updateprefer();
            ds = voucherent.fill_tds_ACCOUNT(CompCode, dateformat, extra1, extra2, "", psec_code, "");
        }

       
        return ds;
    }








    [Ajax.AjaxMethod]
    public DataSet fill_tds1(string pcomp_code, string asseytype, string seccode, string vchdate, string dateformat, string extra1, string extra2)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.updateprefer supost = new NewAdbooking.classesoracle.updateprefer();
          
             ds = supost.fill_tds_f2(pcomp_code, asseytype, "", "", dateformat, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "fa_account_type_bind_fa_tdsbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { pcomp_code, asseytype, "", "", dateformat, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.updateprefer voucherent = new NewAdbooking.Classes.updateprefer();
            ds = voucherent.fill_tds_f2(pcomp_code, asseytype, "", "", dateformat, extra1, extra2);
        }
        return ds;
    }


    //public void tds()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.updateprefer supost = new NewAdbooking.classesoracle.updateprefer();
    //        ds = supost.filltds();
    //        txttdsnametype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //    }
  
    
    //}

    //public void  asses()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.updateprefer supost = new NewAdbooking.classesoracle.updateprefer();
    //        ds = supost.assess();
    //        txtTdsSecName.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //    }
        
    
    //}





    //public void ret1()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.updateprefer supost = new NewAdbooking.classesoracle.updateprefer();
    //        ds = supost.retno();
    //        retno.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //    }
        
    
    
    //}



}
