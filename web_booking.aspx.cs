using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;

public partial class web_booking : System.Web.UI.Page
{
    string getdatecheck = "";
    string adtype = "WE0";
    string formname = "";
    int i = 0;
    static string modifyrateaudit = "";
    static string ip = "";
    static int FlagStatus, fpnl;
   

    protected void Page_Load(object sender, EventArgs e)
    {

        btndeal.Enabled = false;


        bindpagePosition();
        Response.Expires = -1;
        hiddenuomdesc.Value = "CD";
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }
        if (Request.QueryString["rateauditflag"] != null)
        {
            hiddenrateauditflag.Value = Request.QueryString["rateauditflag"].ToString();
        }
        else
        {
            hiddenrateauditflag.Value = "";
        }
        if (Request.QueryString["quotation"] != null)
        {
            hiddenquotation.Value = Request.QueryString["quotation"].ToString();
        }
        else
        {
            hiddenquotation.Value = "";
        }
        if (hiddenrateauditflag.Value == "rateaudit")
        {
            modifyrateaudit = "Y";
        }

        if (Request.QueryString["Billhold"] != null)
        {
            Hiddenbillclear.Value = Request.QueryString["Billhold"].ToString();
        }
        else
        {
            Hiddenbillclear.Value = "";
        }

        ip = this.Page.Request.ServerVariables["REMOTE_ADDR"];

        hiddenconnect.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString().ToLower();
        lbltotarea.Text = hdnlabel.Value;
        hdnrevenue.Value = Session["revenue"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        // ip = this.Page.Request.ServerVariables["REMOTE_ADDR"];
        //hiddenserverip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();
        hiddenregClient.Value = ConfigurationSettings.AppSettings["registerClient"].ToString();
        hiddeninsertwise.Value = ConfigurationManager.AppSettings["boxchrginsertwise"].ToString();
        configclient.Value = ConfigurationSettings.AppSettings["CLIENTNAME"].ToString();
        hiddenuserdisc.Value = Session["USERDISCOUNT"].ToString();
        hiddenschemetype.Value = Session["SCHEME_TYPE"].ToString();
        hiddenvaliddate.Value = Session["validdate_pub"].ToString();
        hiddenrostatus.Value = Session["rostatus"].ToString();
        hidcash.Value = Session["CLA_CASHBILL"].ToString();
        hiddencioidformat.Value = Session["cioid"].ToString();
        hiddencenter.Value = Session["center"].ToString();
      //  dateformat = Session["dateformat"].ToString();
        formname = "web_Booking";
        hiddenratecheckdate.Value = Session["RATE_CHECK"].ToString();
        hiddenratepremtype.Value = Session["ratepremtype"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuom.Value = Session["uom"].ToString();
        hiddenusername.Value = Session["username"].ToString();
        hiddenadtype.Value = "WE0";
        hiddentfn.Value = Session["tfn"].ToString();
        hiddeninserts.Value = Session["insertsbreakup"].ToString();
        hiddencurrency.Value = Session["currency"].ToString();
        hidcurr.Value = Session["currency"].ToString();
        hiddenpremtype.Value = Session["premtype"].ToString();
        hiddentype.Value = Session["dealtype"].ToString();
        hiddenprefix.Value = Session["prefix"].ToString();
        hiddensufix.Value = Session["suffix"].ToString();
        hiddenvat.Value = Session["vat"].ToString();
        hiddencirculation.Value = Session["solorate"].ToString();
        hiddenprereceipt.Value = Session["Receipt_no"].ToString();
        hiddenauditsession.Value = Session["audit"].ToString();
        hdnfollodate.Value = Session["ALLOW_FOLLOW_DT_BOOOK"].ToString();
        hiddenafency_retainer.Value = Session["addAgencyComm_Ret"].ToString();

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


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/webbooking.xml"));
        //lbdatetime.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //lbbranch.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //lbcioid.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //lbbookedby.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        lbagency.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        lbaaddress.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
        lbagescode.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
        lblagencystatus.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
        lblagencycreditperiod.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        lbrodate.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        lbdockit.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
        lbececname.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
        lblagencyoutstand.Text = ds1.Tables[0].Rows[0].ItemArray[22].ToString();



        lbclient.Text = ds1.Tables[0].Rows[0].ItemArray[13].ToString();
        lbcaddress.Text = ds1.Tables[0].Rows[0].ItemArray[14].ToString();
        lblmobile.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();
        lblagencypaymode.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
        lbrono.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        lbrostatus.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
        lbkey.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
        lbexeczone.Text = ds1.Tables[0].Rows[0].ItemArray[20].ToString();
        lblretainer.Text = ds1.Tables[0].Rows[0].ItemArray[21].ToString();

        LinkButton1.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
        LinkButton5.Text = ds1.Tables[0].Rows[0].ItemArray[24].ToString();
        LinkButton2.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        LinkButton4.Text = ds1.Tables[0].Rows[0].ItemArray[26].ToString();
        LinkButton3.Text = ds1.Tables[0].Rows[0].ItemArray[27].ToString();
        //LinkButton6.Text = ds1.Tables[0].Rows[0].ItemArray[28].ToString();
        //LinkButton7.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
        //hidehref.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
        //lbadcat.Text = ds1.Tables[0].Rows[0].ItemArray[31].ToString();

        lbadtype.Text = ds1.Tables[2].Rows[0].ItemArray[0].ToString();
        lbadcat.Text = ds1.Tables[2].Rows[0].ItemArray[1].ToString();
        lbadcat3.Text = ds1.Tables[2].Rows[0].ItemArray[2].ToString();
        Label4.Text = ds1.Tables[2].Rows[0].ItemArray[3].ToString();
        Label2.Text = ds1.Tables[2].Rows[0].ItemArray[4].ToString();
        lbproduct.Text = ds1.Tables[2].Rows[0].ItemArray[5].ToString();
        lbcurrency.Text = ds1.Tables[2].Rows[0].ItemArray[6].ToString();
        lbladon.Text = ds1.Tables[2].Rows[0].ItemArray[7].ToString();
        lbpackage.Text = ds1.Tables[2].Rows[0].ItemArray[8].ToString();
        lbselectdate.Text = ds1.Tables[2].Rows[0].ItemArray[9].ToString();
        lbad.Text = ds1.Tables[2].Rows[0].ItemArray[10].ToString();
        lbnoofins.Text = ds1.Tables[2].Rows[0].ItemArray[11].ToString();
        lbrepdate.Text = ds1.Tables[2].Rows[0].ItemArray[12].ToString();
        lbpaid.Text = ds1.Tables[2].Rows[0].ItemArray[13].ToString();
        lbrptcurrency.Text = ds1.Tables[2].Rows[0].ItemArray[14].ToString();
        lbcontractname.Text = ds1.Tables[2].Rows[0].ItemArray[15].ToString();
        lbcontracttype.Text = ds1.Tables[2].Rows[0].ItemArray[16].ToString();
        lbprintremark.Text = ds1.Tables[2].Rows[0].ItemArray[17].ToString();
        btndeal.Text = ds1.Tables[2].Rows[0].ItemArray[18].ToString();

        lblpage.Text = ds1.Tables[3].Rows[0].ItemArray[0].ToString();
        lblposit.Text = ds1.Tables[3].Rows[0].ItemArray[1].ToString();
       // lbltotarea.Text = ds1.Tables[3].Rows[0].ItemArray[2].ToString();


        lbscheme.Text = ds1.Tables[4].Rows[0].ItemArray[0].ToString();
        lbratecode.Text = ds1.Tables[4].Rows[0].ItemArray[1].ToString();
        lblcardrate.Text = ds1.Tables[4].Rows[0].ItemArray[2].ToString();
        lblcardamt.Text = ds1.Tables[4].Rows[0].ItemArray[3].ToString();
        lbdealtype.Text = ds1.Tables[4].Rows[0].ItemArray[4].ToString();

        lbdeviation.Text = ds1.Tables[4].Rows[0].ItemArray[5].ToString();
        lbagreed.Text = ds1.Tables[4].Rows[0].ItemArray[6].ToString();
        lbagreamo.Text = ds1.Tables[4].Rows[0].ItemArray[7].ToString();
        lbldiscount.Text = ds1.Tables[4].Rows[0].ItemArray[8].ToString();
        lbldiscpre.Text = ds1.Tables[4].Rows[0].ItemArray[9].ToString();
        lbltranslationdisc.Text = ds1.Tables[4].Rows[0].ItemArray[10].ToString();
        lblpospremdisc.Text = ds1.Tables[4].Rows[0].ItemArray[11].ToString();
        lbspecialamo.Text = ds1.Tables[4].Rows[0].ItemArray[12].ToString();
        lbspediscper.Text = ds1.Tables[4].Rows[0].ItemArray[13].ToString();
        lbspace.Text = ds1.Tables[4].Rows[0].ItemArray[14].ToString();
        lbspadiscper.Text = ds1.Tables[4].Rows[0].ItemArray[15].ToString();
        lbpagepostamt.Text = ds1.Tables[4].Rows[0].ItemArray[16].ToString();
        lblagencyaddcomm.Text = ds1.Tables[4].Rows[0].ItemArray[17].ToString();

        lbspechar.Text = ds1.Tables[4].Rows[0].ItemArray[18].ToString();
        lblRetainercomm.Text = ds1.Tables[4].Rows[0].ItemArray[19].ToString();
        lbgrossamt.Text = ds1.Tables[4].Rows[0].ItemArray[20].ToString();
                lbllocalcurr.Text = ds1.Tables[4].Rows[0].ItemArray[21].ToString();

                lblbillcycle.Text = ds1.Tables[5].Rows[0].ItemArray[0].ToString();
                lblrevenuecenter.Text = ds1.Tables[5].Rows[0].ItemArray[1].ToString();
                lblpaymenttype.Text = ds1.Tables[5].Rows[0].ItemArray[2].ToString();
                lbbillstatus.Text = ds1.Tables[5].Rows[0].ItemArray[3].ToString();
                lblbillsize.Text = ds1.Tables[5].Rows[0].ItemArray[4].ToString();
                lblbillto.Text = ds1.Tables[5].Rows[0].ItemArray[5].ToString();
                lbbillamtlocal.Text = ds1.Tables[5].Rows[0].ItemArray[6].ToString();
                lbltradedisc.Text = ds1.Tables[5].Rows[0].ItemArray[7].ToString();
                lbbillamt.Text = ds1.Tables[5].Rows[0].ItemArray[8].ToString();
        lbbillremark.Text = ds1.Tables[5].Rows[0].ItemArray[9].ToString();

        lblbillsize.Text = ds1.Tables[5].Rows[0].ItemArray[10].ToString();


        if (Request.QueryString["cioid"] != null)
        {
            hiddenaudit.Value = Request.QueryString["cioid"].ToString();

        }
        else
        {
            hiddenaudit.Value = "";
        }







        Ajax.Utility.RegisterTypeForAjax(typeof(web_booking));


        DateTime dt = DateTime.Now;

        int year = Convert.ToInt32(dt.Year);
        int month = Convert.ToInt32(dt.Month);
        int day = Convert.ToInt32(dt.Day);
        string serdate = Convert.ToString(month + "/" + day + "/" + year);
        datesave getdatechk = new datesave();
        dateinsert getdateshow = new dateinsert();


        DataSet dsdate = new DataSet();
        DataSet per = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster cls_book = new NewAdbooking.Classes.BookingMaster();
            dsdate = cls_book.getCurrdate();
            per = cls_book.chkdiscountpremedit_per(hiddenuserid.Value, hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
            dsdate = cls_book.getCurrdate();
        }
        else
        {
            NewAdbooking.classesoracle.BookingMaster cls_book = new NewAdbooking.classesoracle.BookingMaster();
            dsdate = cls_book.getCurrdate();
            per = cls_book.chkdiscountpremedit_per(hiddenuserid.Value, hiddencompcode.Value);
        }
        if (per.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < per.Tables[0].Rows.Count; i++)
            {
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Allow Editing Discount Item Line Wise In Transaction")
                    hiddisceditgrid.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Enable Adcat and Subcat After Billed")
                    ena_adsubcataftbill.Value = "Y";
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Client Register Required in Transaction")
                    hdnregclient.Value = "Y";
            }
        }
        if (per.Tables[1].Rows.Count > 0)
        {
            allowpaidchangeper.Value = "N";
        }
        if (per.Tables[2].Rows.Count > 0) { }
        else
        {
            billhold.Attributes.Add("style", "display:none");
        }
        day = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[0].ToString());
        month = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[1].ToString());
        year = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[2].ToString());
        string mon1 = Convert.ToString(month);
        if (Convert.ToString(mon1).Length == 1)
        {
            mon1 = "0" + mon1;
        }
        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            txtdatetime.Text = day + "/" + mon1 + "/" + year;

            getdatecheck = day + "/" + mon1 + "/" + year;
        }
        else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
        {
            txtdatetime.Text = year + "/" + mon1 + "/" + day;

            getdatecheck = year + "/" + mon1 + "/" + day;
        }
        else
        {
            txtdatetime.Text = mon1 + "/" + day + "/" + year;//getdateshow.getDate(Session["dateformat"].ToString(), serdate);

            getdatecheck = mon1 + "/" + day + "/" + year;//getdatechk.getDate(Session["dateformat"].ToString(), serdate);
        }
       currdate.Value = txtdatetime.Text;








        //// This code used for show branch


        DataSet dsbranch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getbranch = new NewAdbooking.Classes.BookingMaster();
            dsbranch = getbranch.getbranchname(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getbranch = new NewAdbooking.classesoracle.BookingMaster();
            dsbranch = getbranch.getbranchname(Session["compcode"].ToString(), Session["revenue"].ToString());
        }

        if (dsbranch.Tables[0].Rows.Count > 0)
        {
            txtbranch_name.Text = dsbranch.Tables[0].Rows[0].ItemArray[0].ToString();
            //hdnbranch_name.Value = dsbranch.Tables[0].Rows[0].ItemArray[0].ToString();
        }





        DataSet dprv = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster prev = new NewAdbooking.Classes.BookingMaster();

            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "WE0");


        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster prev = new NewAdbooking.classesoracle.BookingMaster();

                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "WE0");


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();

                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "WE0");


            }



        if (dprv.Tables[0].Rows.Count > 0)
        {
            txtprevbook.Text = dprv.Tables[0].Rows[0].ItemArray[0].ToString();
           



        }


        if (dprv.Tables[2].Rows.Count > 0)
        {

            creditreceipt_allow.Value = dprv.Tables[2].Rows[0].ItemArray[2].ToString();
            hiddenbackdatebook.Value = dprv.Tables[2].Rows[0].ItemArray[0].ToString();
            hiddockit.Value = dprv.Tables[2].Rows[0].ItemArray[4].ToString();
            hidschememin.Value = dprv.Tables[2].Rows[0].ItemArray[12].ToString();
            allowprem_card_disc_rate.Value = dprv.Tables[2].Rows[0]["ALLOWPREM_CARD_DISC_RATE"].ToString();
            hidshareman.Value = dprv.Tables[2].Rows[0].ItemArray[10].ToString();
            hiddensepcashier.Value = dprv.Tables[2].Rows[0].ItemArray[7].ToString();
            hidpremedit.Value = dprv.Tables[2].Rows[0].ItemArray[15].ToString();
            hidbackdatereceipt.Value = dprv.Tables[2].Rows[0].ItemArray[3].ToString();
            hiddeneiitagcomm.Value = dprv.Tables[2].Rows[0].ItemArray[17].ToString();
            hiddencopybooking.Value = dprv.Tables[2].Rows[0].ItemArray[5].ToString();
            hiddencancelcharge.Value = dprv.Tables[2].Rows[0].ItemArray[18].ToString();
            hiddenrateauditpreferrence.Value = dprv.Tables[2].Rows[0].ItemArray[14].ToString();
        }


        txtbookedby.Text = Session["username"].ToString();

        if (!Page.IsPostBack)
        {


            if (Request.QueryString["form"] == "Modify Master")
            {
                txtciobookid.Enabled = true;
                Hdnmodbook.Value = "modify";
                //  ClientScript.RegisterStartupScript(GetType(), "id", "queryClick()", true);
                //  Page.ClientScript.RegisterClientScriptBlock(typeof(ScriptManager), "CallMyMethod", "queryClick();");

            }


            drpposition.Attributes.Add("onchange", "javascript:return getposition();");

            drppageprem.Attributes.Add("onchange", "javascript:return getpremper();");
            btnCancel.Attributes.Add("OnClick", "javascript:return clearClick();");
            txtinsertion.Attributes.Add("OnChange", "javascript:return onInsertionChange('txtinsertion');");
            btnNew.Attributes.Add("onclick", "javascript:return newclick();");
            btnExit.Attributes.Add("onclick", "javascript:return Exit();");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
            txtdummydate.Attributes.Add("OnChange", "javascript:return hideCalendar1(this);  ");
            txtprintremark.Attributes.Add("onchange", "javascript:return getremarkintogrid();");
            txttotalarea.Attributes.Add("onchange", "javascript:return getsizeintogrid();");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");
            LinkButton1.Attributes.Add("Onclick", "javascript:return changediv();");
            LinkButton5.Attributes.Add("Onclick", "javascript:return changepackage();");
            lstexec.Attributes.Add("onclick", "javascript:return insertagency();");
            lstretainer.Attributes.Add("onclick", "javascript:return showretainervalue(this);");
          //  txtdummydate.Attributes.Add("OnChange", "javascript:return hideCalendar1(this);  ");
            txtcategory.Attributes.Add("onkeydown", "javascript:return filladcategory(event)");
           // txtcategory.Attributes.Add("onkeydown", "javascript:return filladcategory(event)");
            lstadcategory.Attributes.Add("onkeydown", "javascript:return onclickadcategory(event)");
            lstadcategory.Attributes.Add("onclick", "javascript:return onclickadcategory(event)");
            btncopy.Attributes.Add("onclick", "javascript:return Btncopyclick();");
            btndel.Attributes.Add("onclick", "javascript:return removepkgname();");
            LinkButton2.Attributes.Add("Onclick", "javascript:return changediv1();");
            LinkButton4.Attributes.Add("Onclick", "javascript:return changedivrate();");
            LinkButton3.Attributes.Add("Onclick", "javascript:return changebilldiv();");
            btnshgrid.Attributes.Add("onclick", "javascript:return checkGridDate_Validation();");
            btnSave.Attributes.Add("OnClick", "javascript:return checkValidation();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryClick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextClick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeClick(this.id);");
            btnlast.Attributes.Add("OnClick", "javascript:return lastClick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstClick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousClick();");

            btnModify.Attributes.Add("OnClick", "javascript:return modifyClick();");
            txtrepeatingdate.Attributes.Add("OnKeyPress", "javascript:return checkdateInsert();");            

            txtdummydate.Attributes.Add("OnChange", "javascript:return hideCalendar1(this);  ");
            txtrepeatingdate.Attributes.Add("OnChange", "javascript:return onRepeatingDate();");

            drpuom.Attributes.Add("OnChange", "javascript:return drpuomlabel();");

          //  txtratecode.Attributes.Add("onblur", "javascript:return bindrategroupvode();");
            bindStatus();
            bindAdType();
            binduom(hiddencompcode.Value, adtype, Session["center"].ToString());
            bindcurrency();
            bindpackage();

            bindpageprem();
            bindbillcycle();
            bindrevenuecenter();
            bindBillStatus();
           
            getbuttoncheck(formname);



          


        }


       
    }



    [Ajax.AjaxMethod]
    public string backdate_validate(string pcompcode, string pformname, string puserid, string pentrydate, string pdateformat, string pextra1, string pextra2)
    {
        DataSet ds = new DataSet();
        string output = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
           // ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
                //ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
            }

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            output = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return output;
    }

    [Ajax.AjaxMethod]
    public DataSet get_validdates(string dateformat, string book_date, string pkgname, string adcat, string center, string pkgid, string pkgalias)
    {
        DataSet dvaid = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster chkpublishday = new NewAdbooking.Classes.BookingMaster();
            dvaid = chkpublishday.getvaliddate_qbc_New(dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkpublishday = new NewAdbooking.classesoracle.BookingMaster();
                dvaid = chkpublishday.getvaliddate_qbc_New(dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();
                dvaid = chkpublishday.getvaliddate_qbc(dateformat, book_date, pkgname);
            }
        return dvaid;
    }


    [Ajax.AjaxMethod]
    public DataSet executeBooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string adtype, string dateformat, string branch)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.executebooking(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
                executequery = execute.executebooking(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
                executequery = execute.executebookingdisp(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);
            }
        return executequery;
    }


    [Ajax.AjaxMethod]
    public void deletefromtemp(string cioid, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objdeletefromtemp = new NewAdbooking.classesoracle.BookingMaster();
            objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objdeletefromtemp = new NewAdbooking.Classes.BookingMaster();
            objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
    }



    [Ajax.AjaxMethod]
    public DataSet showgridforexe(string ciobid, string compcode)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster showgri = new NewAdbooking.Classes.BookingMaster();
            dex = showgri.fetchdataforexe(ciobid, compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster showgri = new NewAdbooking.classesoracle.BookingMaster();
            dex = showgri.fetchdataforexe(ciobid, compcode);
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
            dex = showgri.fetchdataforexe(ciobid, compcode);
        }
        return dex;

    }



    [Ajax.AjaxMethod]
    public DataSet bindsubagency(string agency, string compcode)
    {
        DataSet dsbsa = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindsubage = new NewAdbooking.Classes.BookingMaster();

            dsbsa = bindsubage.bindsubagency(agency, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bindsubage = new NewAdbooking.classesoracle.BookingMaster();

                dsbsa = bindsubage.bindsubagency(agency, compcode);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindsubage = new NewAdbooking.classmysql.BookingMaster();

                dsbsa = bindsubage.bindsubagency(agency, compcode);

            }
        return dsbsa;
    }

    [Ajax.AjaxMethod]
    public DataSet brandbind(string compcode, string product)
    {
        DataSet dsbrand = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster brandbind = new NewAdbooking.Classes.BookingMaster();
            dsbrand = brandbind.bindBrand(compcode, product);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster brandbind = new NewAdbooking.classesoracle.BookingMaster();
                dsbrand = brandbind.bindBrand(compcode, product);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster brandbind = new NewAdbooking.classmysql.BookingMaster();
                dsbrand = brandbind.bindBrand(compcode, product);
            }

        return dsbrand;
    }


    [Ajax.AjaxMethod]
    public DataSet varientbind(string compcode, string brand)
    {
        DataSet dva = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getvarient = new NewAdbooking.Classes.BookingMaster();
            dva = getvarient.bindvarient(brand, compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getvarient = new NewAdbooking.classesoracle.BookingMaster();
            dva = getvarient.bindvarient(brand, compcode);
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster getvarient = new NewAdbooking.classmysql.BookingMaster();
            dva = getvarient.bindvarient(brand, compcode);
        }
        return dva;
    }

    [Ajax.AjaxMethod]
    public DataSet getPackageInsert(string uom, string cioid)
    {
        DataSet dsinsert = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindpacforexe = new NewAdbooking.classesoracle.BookingMaster();
            dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindpacforexe = new NewAdbooking.Classes.BookingMaster();
            dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
            dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
        }
        return dsinsert;
    }


    [Ajax.AjaxMethod]
    public DataSet bindpacforexe(string compcode, string listpck)
    {
        DataSet dsexecut = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindpacforexe = new NewAdbooking.Classes.BookingMaster();
            dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bindpacforexe = new NewAdbooking.classesoracle.BookingMaster();
                dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
                dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);
            }
        return dsexecut;
    }






    [Ajax.AjaxMethod]
    public DataSet getcirEdition(string compcode, string editioncode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getciredition(compcode, editioncode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getciredition(compcode, editioncode);

        }
        return executequery;
    }




    [Ajax.AjaxMethod]
    public string checkCIOIDReference(string compcode, string cioid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster cls_booking = new NewAdbooking.classesoracle.BookingMaster();
            ds = cls_booking.checkCIOIDReference(compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster cls_booking = new NewAdbooking.Classes.BookingMaster();
            ds = cls_booking.checkCIOIDReference(compcode, cioid);
        }
        string cio_ID = cioid;
        if (ds.Tables[0].Rows.Count > 0)
        {
            cio_ID = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return cio_ID;
    }




    [Ajax.AjaxMethod]
    public DataSet getCurTime(string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getCurTime(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getCurTime(compcode);

        }
        return executequery;
    }

    [Ajax.AjaxMethod]
    public string getdateCHK(string dateformat, string date)
    {
        datesave getdatechk = new datesave();
        string ret = getdatechk.getDate(dateformat, date);
        return ret;
    }
    [Ajax.AjaxMethod]
    public DataSet chkwalkinClient(string client, string compcode)
    {
        DataSet dcl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster chkclient = new NewAdbooking.Classes.BookingMaster();
            dcl = chkclient.forwalkclient(client, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkclient = new NewAdbooking.classesoracle.BookingMaster();
                dcl = chkclient.forwalkclient(client, compcode);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkclient = new NewAdbooking.classmysql.BookingMaster();
                dcl = chkclient.forwalkclient(client, compcode);
            }
        return dcl;
    }

    //this is to show the grid for execution
    [Ajax.AjaxMethod]
    public void rollback(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
            insertchild.rollbackT(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster insertchild = new NewAdbooking.Classes.BookingMaster();
            insertchild.rollbackT(cioid);
        }
    }

    [Ajax.AjaxMethod]
    public string commit(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string quotation)
    {
        string error = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
            error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster insertchild = new NewAdbooking.Classes.BookingMaster();
            error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, "DI", quotation);
        }
        return error;
    }

    [Ajax.AjaxMethod]
    public DataSet bookidchk(string compcode, string cioid, string agency, string agencycode, string rono, string val, string keyno)
    {
        DataSet dck = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster chkbookid = new NewAdbooking.Classes.BookingMaster();
            dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", keyno,"");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkbookid = new NewAdbooking.classesoracle.BookingMaster();
                dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", keyno);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkbookid = new NewAdbooking.classmysql.BookingMaster();

                dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", keyno);

            }
        return dck;
    }


    [Ajax.AjaxMethod]
    public DataSet getBookingIdNo(string compcode, string auto, string no, string cioid)
    {
        DataSet da = new DataSet();
        if (no == "0" || no == "1" || no == "2")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster autocode = new NewAdbooking.Classes.BookingMaster();
                da = autocode.autogenrated(compcode, auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster autocode = new NewAdbooking.classesoracle.BookingMaster();
                    da = autocode.autogenrated(compcode, auto, no);

                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
                    da = autocode.autogenrated(compcode, auto, no);
                }
        }

        else if (no == "3")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster objMaxReceipt_No = new NewAdbooking.Classes.BookingMaster();
                da = objMaxReceipt_No.clsMaxReceipt();
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster objMaxReceipt_No = new NewAdbooking.classesoracle.BookingMaster();
                da = objMaxReceipt_No.clsMaxReceipt(cioid);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster objMaxReceipt_No = new NewAdbooking.classmysql.BookingMaster();
                da = objMaxReceipt_No.clsMaxReceipt(cioid);
            }
        }
        return da;
    }



    [Ajax.AjaxMethod]
    public DataSet chkrategroup(string color, string adcategory, string subcategory, string package, string ratecode, string startdate, string currency, string adtype, string compcode, string agency, string client, string dateformat)
    {
        DataSet dgr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster chkrategrupcode = new NewAdbooking.Classes.BookingMaster();
            dgr = chkrategrupcode.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, adtype, compcode, agency, client, dateformat);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkrategrupcode = new NewAdbooking.classesoracle.BookingMaster();
                dgr = chkrategrupcode.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, adtype, compcode, agency, client, dateformat);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkrategrupcode = new NewAdbooking.classmysql.BookingMaster();

                dgr = chkrategrupcode.chkrategroup(color, adcategory, subcategory, package, ratecode, startdate, currency, adtype, compcode, agency, client, dateformat);

            }
        return dgr;
    }



    [Ajax.AjaxMethod]
    public DataSet getRepresenttaive(string compcode, string executive, string retainer)
    {
        DataSet dup = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster update = new NewAdbooking.classesoracle.BookingMaster();
            dup = update.getRepressentative(compcode, executive, retainer);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster update = new NewAdbooking.Classes.BookingMaster();
            dup = update.getRepressentative(compcode, executive, retainer);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();
            dup = update.getRepressentative(compcode, executive, retainer);
        }
        return dup;
    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void update_chqinfo(string compcode, string rcptno, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ppaymodres, string ptype, string date_time, string dateformat, string remarks, string ourbank, string repcode, string cioid, string revenue, string execname, string retainer, string prevcioid, string grossamt)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objupdate_chqinfo = new NewAdbooking.classesoracle.BookingMaster();
            //    if (ppaymodres == "CA0")
            //    objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, "RCP", date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(),cioid);
            //  else
            //  objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(), cioid, execname, retainer, prevcioid, grossamt);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objupdate_chqinfo = new NewAdbooking.Classes.BookingMaster();
            //if (ppaymodres == "CA0")
            //    objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, Session["center"].ToString(), Session["userid"].ToString(), ourbank, repcode);
            //else
            // objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, Session["center"].ToString(), Session["userid"].ToString(), ourbank, repcode);
            objupdate_chqinfo.clsupdate_chqinfo(compcode, rcptno, chqno, chqdate, chqamt, bankname, ag_codesubcode, ag_code, ag_subcode, ppaymodres, ptype, date_time, dateformat, remarks, ourbank, repcode, revenue, Session["userid"].ToString(), cioid, execname, retainer, prevcioid, grossamt);
        }
    }





    [Ajax.AjaxMethod]
    public DataSet updatebooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, string billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtyp, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string val1, string val2, string val3, string val4, string val5, string val6, string val7, string auditstatus, string retainer, string txtaddagencycommrate, string dateformat, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string mobno, string agreedrate_active, string agreedamt_active, string grossamtlocal, string billamtlocal, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold)
    {
        DataSet dup = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster update = new NewAdbooking.Classes.BookingMaster();
            dup = update.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, cashdiscount, cashdiscountper, attach1, attach2, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold,"","");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster update = new NewAdbooking.classesoracle.BookingMaster();
                dup = update.updatebookingdisp(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, dealerpanel, dealerh, dealerw, dealertype, multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, modifyrateaudit, ip, transdisc, pospremdisc, billhold);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();

                //dup = update.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, Session["compcode"].ToString(), Session["userid"].ToString(), specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout);
                dup = update.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "0", "0", "0", "0", "0", "0", "0", auditstatus, dateformat, retainer, txtaddagencycommrate, "", addlamt, retamt, retper, cashrecieved);


            }
        return dup;
    }




    [Ajax.AjaxMethod]

    public string insertBooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, string billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtyp, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string val1, string prev_cioid, string prev_receipt, string prev_ga, string val2, string val3, string val4, string val5, string val6, string val7, string val8, string dateformat, string retainer, string txtaddagencycommrate, string srtcancel, string auditstatus, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string mobno, string agreedrate_active, string agreedamt_active, string grossamtlocal, string billamtlocal, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold, string online_ad, string fixed_booking, string vat_code, string coupantype, string coupanno, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype)
    {
        DataSet dins = new DataSet();
        DataSet dscancel = new DataSet();
        string error = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                dins = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), "0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, "", "", "", "", multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, transdisc, pospremdisc, billhold, "", "", online_ad, "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype);
                if (srtcancel == "1")
                {
                    dscancel = insert.cancelbooking(prev_cioid);
                }
                dscancel.Dispose();

            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    error = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), "0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, mobno, addlamt, retamt, retper, cashrecieved, ciragency, cirrate, ciredition, cirpublication, ciragencysubcode, bartertype, attach1, attach2, cashdiscount, cashdiscountper, drpdiscprem, doctype, chktradeval, sharepub, fmginsert, chkno, chkdate, chkamt, chkbankname, ourbank, "", "", "", "", multicode, agreedrate_active, agreedamt_active, grossamtlocal, billamtlocal, chkadon, refid, rcpt_currency, cur_convrate, revisedate, clienttype, translation, translationcharge, fmgreasons, canclecharge, transdisc, pospremdisc, billhold, online_ad, "", fixed_booking, vat_code, coupantype, coupanno, "0", clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype);

                    if (srtcancel == "1")
                    {
                        dscancel = insert.cancelbooking(prev_cioid);
                    }
                    dscancel.Dispose();


                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
                    // dins = insert.insertbookingqbc(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga),"0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, "", addlamt, retamt, retper, cashrecieved);
                    dins = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, "", prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), "0", "0", "0", "0", "0", "0", "0", dateformat, retainer, txtaddagencycommrate, "", addlamt, retamt, retper, cashrecieved);
                    if (srtcancel == "1")
                    {
                        dscancel = insert.cancelbooking(prev_cioid);
                    }
                    dscancel.Dispose();

                }
        }
        catch (Exception e)
        {
            error = e.Message;

        }
        return error;
    }

    [Ajax.AjaxMethod]
    public void insertionCount(string cioid, int count)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
            insertchild.insertionCount(cioid, count);
        }

    }


    ///this the function to insert the records in insert table
    [Ajax.AjaxMethod]
    public string insertinsertion(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string filename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string insertinsertion, string solorate, string grossrate, string no, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string insert_id, string dateformat, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string serverip, string splitdata, string subedidata, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clicatamt, string flatfreqamt, string catamt)
    {
        string err = "";
        DataSet dii = new DataSet();
        try
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "", "", "", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, "", "", disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt);

            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    err = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "", "", "", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, "", "", disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt);
                }
            else
            {
                NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();
                dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, "0", "0", "0", dateformat, "0", "0", "0", pkgcode, gridins, pkgalias);
            }


        }
        catch (Exception e)
        {
            err = e.Message;

        }
        string data = "insertdate:" + insertdate + "edition:" + edition + "premium1:" + premium1 + "premium2:" + premium2 + "premallow:" + premallow + "adcategory:" + adcategory + "latestdate:" + latestdate + "material:" + material + "cardrate:" + cardrate + "filename:" + filename + "discrate:" + discrate + "insertstatus:" + insertstatus + "billstatus:" + billstatus + "adsubcat:" + adsubcat + "compcode:" + compcode + "userid:" + userid + "cioid:" + cioid + "height:" + height + "width:" + width + "totalsize:" + totalsize + "pagepost:" + pagepost + "premper1:" + premper1 + "premper2:" + premper2 + "colid:" + colid + "repeat:" + repeat + "insertno:" + insertno + "paid:" + paid + "insertinsertion:" + insertinsertion + "solorate:" + solorate + "grossrate:" + grossrate + "insert_pageno:" + insert_pageno + "insert_remarks:" + insert_remarks + "page_code:" + page_code + "page_per:" + page_per + "noofcol:" + noofcol + "billamt:" + billamt + "billrate:" + billrate + "logo_h:" + "0" + "logo_w:" + "0" + "logo_name:" + "0" + "dateformat:" + dateformat + "0" + "0" + "0" + "pkgcode:" + pkgcode + "gridins:" + gridins + "pkgalias:" + pkgalias + "cirvts:" + cirvts + "cirpub:" + cirpub + "ciredi:" + ciredi + "cirrate:" + cirrate + "cirdate:" + cirdate + "ciragency:" + ciragency + "ciragencysubcode:" + ciragencysubcode + "center:" + center + "branch:" + branch;
        if (err != "")
            err = err + " ERROR: " + data;
        string adcatcode2 = "Save Display Booking " + cioid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new(DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP)  values($date,'" + userid + "','Display Ad Booking','" + err.Replace("'", "''") + "','Ad Booking Saved','" + adcatcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + serverip + "')";
        dconnect.executenonquery1(sqldd);
        return err;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void savelogin_dj(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            execute.SAVELOGIN_DJ(cioid, Session["PUBLICATIONDJ"].ToString(), Session["CENTERDJ"].ToString(), Session["revenue"].ToString(), Session["LOGINDJ"].ToString());

        }

    }

    public void getbuttoncheck(string formname)
    {

        DataSet butt = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classlibraryforbutton getpermission = new NewAdbooking.Classes.classlibraryforbutton();
            butt = getpermission.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classlibraryforbutton getpermission = new NewAdbooking.classesoracle.classlibraryforbutton();
            butt = getpermission.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }

        else
        {
            NewAdbooking.classmysql.classlibraryforbutton getpermission = new NewAdbooking.classmysql.classlibraryforbutton();
            butt = getpermission.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }
        string id = "0";
        if (butt.Tables[0].Rows.Count > 0)
        {
            id = butt.Tables[0].Rows[0].ItemArray[0].ToString();
            hiddenroperm.Value = butt.Tables[2].Rows[0].ItemArray[0].ToString();
        }
        //////this is for the ro date time permission if there is 0 than no permission and if 1 than having the permission

        hiddenbuttonidcheck.Value = id;

        if (id != "0")
        {
            //var id = ds.Tables[0].Rows[0].button_id;



            if (id == "0" || id == "8")
            {

                FlagStatus = 0;

                btnNew.Enabled = false;
                btnQuery.Enabled = false;
                btnExecute.Enabled = false;
                btnCancel.Enabled = false;
                btnExit.Enabled = false;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;

                btnSave.Enabled = false;
              //  btnsavepaginate.Enabled = false;
                btnModify.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;



                //window.location.href = 'EnterPage.aspx';
                //alert("You Are Not Authorised To See This Form");
                //FlagStatus = 0;
                //

            }
            if (id == "1" || id == "9")
            {
                btnNew.Enabled = true;
                btnQuery.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnExecute.Enabled = false;

                btnSave.Enabled = false;
              //  btnsavepaginate.Enabled = false;
                btnModify.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                FlagStatus = 1;

            }
            if (id == "2" || id == "10")
            {

                btnNew.Enabled = false;
                btnExecute.Enabled = false;
                btnQuery.Enabled = true;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnModify.Enabled = true;

                btnSave.Enabled = false;
               // btnsavepaginate.Enabled = false;
                btnfirst.Enabled = true;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExit.Enabled = true;
                FlagStatus = 2;


            }
            if (id == "3" || id == "11")
            {
                btnNew.Enabled = true;
                btnQuery.Enabled = true;
                btnExecute.Enabled = false;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;


                btnSave.Enabled = false;
              //  btnsavepaginate.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;

                FlagStatus = 3;



            }
            if (id == "4" || id == "12")
            {
                btnNew.Enabled = false;
                btnQuery.Enabled = true;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;

                btnNew.Enabled = false;
                btnExecute.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;


                btnModify.Enabled = false;

                btnSave.Enabled = false;
              //  btnsavepaginate.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                FlagStatus = 4;



            }
            if (id == "5" || id == "13")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
              //  btnsavepaginate.Enabled = false;
                btnQuery.Enabled = true;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;
                btnModify.Enabled = false;
                FlagStatus = 5;


            }
            if (id == "6" || id == "14")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
               // btnsavepaginate.Enabled = false;
                btnQuery.Enabled = true;
                btnModify.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;

                FlagStatus = 6;
            }
            if (id == "7" || id == "15")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
              //  btnsavepaginate.Enabled = false;
                btnQuery.Enabled = true;
                btnModify.Enabled = false;
                btnCancel.Enabled = true;
                btnExit.Enabled = true;
                btnDelete.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;
                btnExecute.Enabled = false;
                FlagStatus = 7;

            }
        }




    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string getRev()
    {
        return Session["revenue"].ToString();
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string getCen()
    {
        return Session["center"].ToString();
    }
   


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getPrevBookId()
    {
        DataSet dprv = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster prev = new NewAdbooking.Classes.BookingMaster();

            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "WE0");


        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster prev = new NewAdbooking.classesoracle.BookingMaster();

                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "WE0");


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();

                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "WE0");


            }
        return dprv;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string getRegClientCheck(string adcat)
    {
        string chk = "0";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            DataSet ds = new DataSet();
            NewAdbooking.classesoracle.BookingMaster prev = new NewAdbooking.classesoracle.BookingMaster();
            ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chk = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            DataSet ds = new DataSet();
            NewAdbooking.Classes.BookingMaster prev = new NewAdbooking.Classes.BookingMaster();
            ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chk = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
        return chk;
    }

    [Ajax.AjaxMethod]
    public string bindAdTypeAgencyWiseXML()
    {
        DataSet ds = new DataSet();
        DataSet billtyp = new DataSet();
        // billtyp.ReadXml(Server.MapPath("XML/billcycle.xml").Replace("\\ajax", ""));
        billtyp.ReadXml(Server.MapPath("../XML/billcycle.xml").Replace("\\ajax", ""));
        string data = "";
        for (int i = 0; i < billtyp.Tables[3].Columns.Count; i++)
        {
            if (data == "")
            {
                data = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            }
            else
            {
                data = data + "," + billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
            }
        }

        return data;

    }

    [Ajax.AjaxMethod]
    public string bindAdTypeAgencyWise(string agencycode, string compcode)
    {

        DataSet ds1 = new DataSet();
        string bookingtype = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds1 = clsbooking.bindAdTypeAgencyWise(agencycode, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds1 = clsbooking.bindAdTypeAgencyWise(agencycode, compcode);
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            bookingtype = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return bookingtype;

    }



    [Ajax.AjaxMethod]
    public DataSet getadsubcat(string compcode, string adcat, string agencytype)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster cls_comb = new NewAdbooking.Classes.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster cls_comb = new NewAdbooking.classesoracle.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster cls_comb = new NewAdbooking.classmysql.BookingMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat, agencytype);
        }

        return da;


    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet gettheuom_desc(string compcode, string uom)
    {
        /*
        HttpContext.Current.Session["imgname"] = null;
        HttpContext.Current.Session["Tempimgname"] = null;
        HttpContext.Current.Session["insertname"] = null;
        HttpContext.Current.Session["Tempinsertname"] = null;

        HttpContext.Current.Session["imgname_logo"] = null;
        HttpContext.Current.Session["Tempimgname_logo"] = null;
        HttpContext.Current.Session["insertname_logo"] = null;
        HttpContext.Current.Session["Tempinsertname_logo"] = null;*/
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binduom = new NewAdbooking.Classes.RateMaster();
            ds = binduom.getuom_desc(compcode, uom);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster binduom = new NewAdbooking.classesoracle.RateMaster();
                ds = binduom.getuom_desc(compcode, uom);

            }
            else
            {
                NewAdbooking.classmysql.RateMaster binduom = new NewAdbooking.classmysql.RateMaster();
                ds = binduom.getuom_desc(compcode, uom);
            }
        return ds;
    }





    public void bindBillStatus()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsBook = new NewAdbooking.Classes.BookingMaster();

            ds = clsBook.getBillStatus();
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster clsBook = new NewAdbooking.classesoracle.BookingMaster();

                ds = clsBook.getBillStatus();
            }

            else
            {
                NewAdbooking.classmysql.BookingMaster clsBook = new NewAdbooking.classmysql.BookingMaster();

                ds = clsBook.getBillStatus();
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Status";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbillstatus.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //drpregion.SelectedValue=ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //drpregion.SelectedItem.Text=ds.Tables[0].Rows[i].ItemArray[1].ToString();
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbillstatus.Items.Add(li);

        }
    }


    public void bindrevenuecenter()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster logindetail = new NewAdbooking.Classes.BookingMaster();

            ds = logindetail.getQBC_n(Session["center"].ToString(), Session["compcode"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster logindetail = new NewAdbooking.classesoracle.BookingMaster();
            ds = logindetail.getQBC_n(Session["center"].ToString(), Session["compcode"].ToString());

        }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();

            ds = logindetail.getQBC(Session["center"].ToString());
        }

        drprevenue.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Revenue Center";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprevenue.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drprevenue.Items.Add(li);
            }

        }

    }


    [Ajax.AjaxMethod]
    public DataSet getpubcount(string compcode, string noofinsert, string packagecode, string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);

        }
        return executequery;
    }


    [Ajax.AjaxMethod]
    public DataSet getPackageConsumption(string pkgcode_p, string pfdate, string pldate, string dateformat)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);

        }
        return executequery;
    }


    public void bindbillcycle()
    {
        DataSet billcyc = new DataSet();
        billcyc.ReadXml(Server.MapPath("XML/billcycle.xml"));
        drpbillcycle.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Bill";
        li1.Value = "0";
        li1.Selected = true;
        drpbillcycle.Items.Add(li1);

        for (i = 0; i < billcyc.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = billcyc.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = billcyc.Tables[0].Rows[0].ItemArray[i].ToString();
            drpbillcycle.Items.Add(li);

        }

    }



    protected void btncopy_Click(object sender, EventArgs e)
    {

    }

    [Ajax.AjaxMethod]
    public DataSet bindratecode(string adcat, string compcode)
    {       
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindrate = new NewAdbooking.Classes.BookingMaster();

            dx = bindrate.ratebind(adcat, compcode);
            return dx;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bindrate = new NewAdbooking.classesoracle.BookingMaster();

                dx = bindrate.ratebind(adcat, compcode);
                return dx;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();

                dx = bindrate.ratebind(adcat, compcode);
                return dx;
            }
        
    }



    [Ajax.AjaxMethod]
    public DataSet ratebind(string adcat, string compcode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindrate = new NewAdbooking.Classes.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bindrate = new NewAdbooking.classesoracle.BookingMaster();
                dx = bindrate.ratebind(adcat, compcode);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
                dx = bindrate.ratebind(adcat, compcode);
            }
        return dx;
    }


    [Ajax.AjaxMethod]
    public DataSet getstatuspaymode(string agencycode, string agency, string compcode, string datetimeval, string dateformat, string adtype)
    {
        DataSet dch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getsta = new NewAdbooking.Classes.BookingMaster();
            dch = getsta.getstatuspaymode(agencycode, agency, compcode, datetimeval, dateformat, adtype);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getsta = new NewAdbooking.classesoracle.BookingMaster();
                dch = getsta.getstatuspaymode(agencycode, agency, compcode, datetimeval, dateformat, adtype);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getsta = new NewAdbooking.classmysql.BookingMaster();

                dch = getsta.getstatuspaymode(agencycode, agency, compcode, datetimeval, dateformat, adtype);

            }
        return dch;
    }






    [Ajax.AjaxMethod]
    public DataSet get_rate(string noofinsertion, string dateformat, string compcode, string uom, string adtype, string currency, string ratecode, string clientcode, string uomdesc, string agencycode, string newcode, string center, string ratepremtype, string premium, string schemetype, string fdate, string ldate, int currentcounter, string chkadon_var, string discprem, string spediscper, string pospremdisc)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getrate = new NewAdbooking.Classes.BookingMaster();
            ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, i, fdate, ldate, chkadon_var, discprem, spediscper, pospremdisc,"","");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getrate = new NewAdbooking.classesoracle.BookingMaster();
            ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate, currentcounter, chkadon_var, discprem, spediscper, pospremdisc);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getrate = new NewAdbooking.classmysql.BookingMaster();
            ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate);
        }
        return ds;
    }




    public void bindpagePosition()
    
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));
        ListItem li = new ListItem();
        int i;
        drpposition.Items.Clear();

        li.Text = "--Select Position--";
        li.Value = "0";
        li.Selected = true;
        drpposition.Items.Add(li);

        for (i = 0; i < ds.Tables[10].Columns.Count; i++)
          {
              ListItem li1;
              li1 = new ListItem();
              li1.Text = ds.Tables[10].Rows[0].ItemArray[i].ToString();
              li1.Value = ds.Tables[10].Rows[0].ItemArray[i].ToString();
              drpposition.Items.Add(li1);


          }
       
    }



    public void bindpageprem()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bindrate = new NewAdbooking.Classes.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), "WE0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bindrate = new NewAdbooking.classesoracle.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), "WE0");
        }
        else
        {
            NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), "WE0");
        }

        drppageprem.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Premium-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppageprem.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppageprem.Items.Add(li);
            }

        }


    }



    public void bindcurrency()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract curr = new NewAdbooking.Classes.Contract();

            ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract curr = new NewAdbooking.classesoracle.Contract();

                ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.Contract curr = new NewAdbooking.classmysql.Contract();

                ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());

            }

        drpcurrency.Items.Clear();
        drprptcurrency.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Currency";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcurrency.Items.Add(li1);
        drprptcurrency.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcurrency.Items.Add(li);
                drprptcurrency.Items.Add(li);
            }

        }

    }


    [Ajax.AjaxMethod]
    public DataSet getData(string drppackage, string txtinsertion, string txtrepeatingdate, string txtstartdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string insert, string code, string cardrate, string uom, string dealrate, string che_or, string class_insert, string lines, string adcat3, string adcat4, string adcat5, string clientcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();


            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";


            // ds = clsbooking.getInsertion_classified(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode);
            ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, "0", code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, "", "0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();


                if (txtinsertion == "")
                    txtinsertion = "1";
                if (txtrepeatingdate == "")
                    txtrepeatingdate = "";


                ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, "", "0");

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();


                if (txtinsertion == "")
                    txtinsertion = "1";
                if (txtrepeatingdate == "")
                    txtrepeatingdate = "";


                // ds = clsbooking.getInsertion_classified(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode,"","0");
                ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode);

            }
        //////this to get the value for color,uom,premium,adscat to bind the drop down in java script
        //NewAdbooking.Classes.BookingMaster getuompreas = new NewAdbooking.Classes.BookingMaster();
        //DataSet duom = new DataSet();
        //duom=getuompreas.getthedatabook(Session["compcode"].ToString());


        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet gettempBookingIdNo(string compcode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster autocode = new NewAdbooking.Classes.BookingMaster();
            da = autocode.autogenratedtempid(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster autocode = new NewAdbooking.classesoracle.BookingMaster();
            da = autocode.autogenratedtempid(compcode);

        }
        return da;
    }


    public void bindpackage()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.packagebindActive(Session["compcode"].ToString(), "WE0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
                {
                    NewAdbooking.classesoracle.BookingMaster bindopackage = new NewAdbooking.classesoracle.BookingMaster();
                    ds = bindopackage.packagebindActive_DJ(Session["compcode"].ToString(), "WE0", hiddenuserid.Value, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
                }
                else
                {
                    NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                    ds = bindopackage.packagebindActive(Session["compcode"].ToString(), "WE0");
                }
            }
            else
            {
                NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();

                ds = bindopackage.packagebind(Session["compcode"].ToString(), "WE0");
            }

        drppackage.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Package";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppackage.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppackage.Items.Add(li);
            }

        }


    }










    [Ajax.AjaxMethod]
    public DataSet getRetainerComm(string reatinername, string compcode)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getadcat3 = new NewAdbooking.classesoracle.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getadcat3 = new NewAdbooking.Classes.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);
        }
        return dacat;
    }
    
//public DataSet bindpackage(string reatinername, string compcode)
    [Ajax.AjaxMethod]
    public DataSet advcat(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();

            ds = bind.advdatacategory(compcode, "WE0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bind = new NewAdbooking.classesoracle.BookingMaster();

                ds = bind.advdatacategory(compcode, "WE0");
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();

                ds = bind.advdatacategory(compcode, "WE0");
            }

        return ds;
      

    }


    [Ajax.AjaxMethod]
    public DataSet getbillval(string agency, string compcode)
    {
        DataSet dbt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getbillto = new NewAdbooking.Classes.BookingMaster();
            dbt = getbillto.getbillval(agency, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getbillto = new NewAdbooking.classesoracle.BookingMaster();
                dbt = getbillto.getbillval(agency, compcode);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getbillto = new NewAdbooking.classmysql.BookingMaster();
                dbt = getbillto.getbillval(agency, compcode);
            }
        return dbt;
    }





    [Ajax.AjaxMethod]
    public DataSet fetchmultiexe(string cioid, string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.fetchmultiexe(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.fetchmultiexe(cioid, compcode);

        }
        return executequery;
    }


    [Ajax.AjaxMethod]
    public DataSet getvalfromadcat3(string agencysubcode, string compcode, string type)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getadcat3 = new NewAdbooking.Classes.BookingMaster();
            dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getadcat3 = new NewAdbooking.classesoracle.BookingMaster();
                dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();
                dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);
            }
        return dacat;
    }


    [Ajax.AjaxMethod]
    public DataSet getPubSharing(string packagecode, string compcode, string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);

        }
        return executequery;
    }






    [Ajax.AjaxMethod]
    public DataSet bindbillto_ag(string agcode, string compcode)
    {
        DataSet dbt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getbillto = new NewAdbooking.Classes.BookingMaster();

            dbt = getbillto.getbillval(agcode, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getbillto = new NewAdbooking.classesoracle.BookingMaster();

                dbt = getbillto.getbillval(agcode, compcode);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getbillto = new NewAdbooking.classmysql.BookingMaster();

                dbt = getbillto.getbillval(agcode, compcode);
            }

        return dbt;

    }



    [Ajax.AjaxMethod]
    public DataSet chkcasualclient(string client, string compcode)
    {
        DataSet dcl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster chkclient = new NewAdbooking.Classes.BookingMaster();

            dcl = chkclient.forwalkclient(client, compcode);
            return dcl;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkclient = new NewAdbooking.classesoracle.BookingMaster();

                dcl = chkclient.forwalkclient(client, compcode);
                return dcl;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkclient = new NewAdbooking.classmysql.BookingMaster();

                dcl = chkclient.forwalkclient(client, compcode);
                return dcl;
            }

    }






    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency, string fla)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();

            if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency(compcode, userid, agency, Session["revenue"].ToString());
                else
                    ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }

            else if (Session["FILTER"].ToString() == "P")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency(compcode, userid, agency, Session["center"].ToString());
                else
                    ds = bindagenname.bindagency(compcode, userid, agency, Session["center"].ToString());
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency(compcode, userid, agency, "0");
                else
                    ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                ds = bindagenname.bindagency_DJ(compcode, userid, agency, Session["revenue"].ToString(), Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
            }
            else if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency(compcode, userid, agency, Session["revenue"].ToString());
                else
                    ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }

            else if (Session["FILTER"].ToString() == "P")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency(compcode, userid, agency, Session["center"].ToString());
                else
                    ds = bindagenname.bindagency(compcode, userid, agency, Session["center"].ToString());
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bind10agency(compcode, userid, agency, "0");
                else
                    ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        return ds;



    }

    [Ajax.AjaxMethod]
    public void btnSavecall(string compcod, string userid, string dealno, string quotation)
    {
        if (quotation == "Q")
        {
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
                ds1 = bind.getmailheader(compcod, userid, dealno);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
                ds1 = bindrate.getmailheader(compcod, userid, dealno);
            }

            DataSet ds2 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
                ds2 = bind.getmaildetail(compcod, userid, dealno);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
                ds2 = bindrate.getmaildetail(compcod, userid, dealno);
            }

            DataSet objdat1 = new DataSet();
            // Read in the XML file
            string datapath = (Server.MapPath("XML/dealmailbody.xml")).Replace("ajax\\", "");
            //  datapath.Replace("ajax\\","");
            objdat1.ReadXml(datapath);


            string mailbody = "<table width='100%' cellspacing='0' cellpadding='0' border='1'>";
            mailbody = mailbody + "<tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>";
            mailbody = mailbody + "<td align='left' colspan='3'style='font-family:verdana;font-size:12'>" + chkvalue(Convert.ToDateTime(ds1.Tables[0].Rows[0].ItemArray[0].ToString()).ToShortDateString()) + "</td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:14'><label id=\"lblclntnam\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></label></td><td align=\"left\" colspan=\"3\">";
            mailbody = mailbody + "<label id=\"lblclntnam1\" style='font-family:verdana;font-size:12'\" >" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[1].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:12'><label id=\"lblcompnam\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></label></td><td align=\"left\"  colspan=\"3\">";
            mailbody = mailbody + "<label id=\"lblcompnam1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[2].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:12'><label id=\"lblsub\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></label></td><td align=\"left\" colspan=\"3\">";
            mailbody = mailbody + "<label id=\"lblsub1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[3].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\" align='left' style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></td>";
            mailbody = mailbody + "<td style='font-family:verdana;font-size:14'>" + objdat1.Tables[0].Rows[0].ItemArray[5].ToString() + "<label id=\"lbltel\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[4].ToString()) + "</label></td>";
            mailbody = mailbody + "<td style='font-family:verdana;font-size:14'>" + objdat1.Tables[0].Rows[0].ItemArray[6].ToString() + "<label id=\"lblfax\" style='font-family:verdana;font-size:12'>" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[5].ToString()) + "</label></td>";
            mailbody = mailbody + "<td style=\" font-size:'14px';\">Cell:<label id=\"lblfax1\" style='font-family:verdana;font-size:12'>018414084:</label></td>";
            mailbody = mailbody + "</tr><tr><td><label id=\"lblsub\" style=\" font-size:'12px';\"></label></td><td align=\"left\" colspan=\"3\" style='font-family:verdana;font-size:14'>";
            mailbody = mailbody + objdat1.Tables[0].Rows[0].ItemArray[7].ToString() + ":<label id=\"lblmail1\" style=\" font-size:'12px';\">" + chkvalue(ds1.Tables[0].Rows[0].ItemArray[6].ToString()) + "</label></td>";
            mailbody = mailbody + "</tr></table><u><label id=\"lblquote\" style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></label></u></br>";
            mailbody = mailbody + "<label id=\"lblquote1\" style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></label>";
            mailbody = mailbody + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"1\">";
            mailbody = mailbody + "<tr><td><label id=\"lblcolor\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[10].ToString() + "</label></td>";
            mailbody = mailbody + "<td><label id=\"lblprice\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[11].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td><label id=\"lblpub\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td><label id=\"lblpubdat\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td><label id=\"lbltotal\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[24].ToString() + "</b></label></td></tr>";

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {

                    mailbody = mailbody + "<tr><td><label id=\"lblinserts\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[0].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lblfulcol\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[1].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lblpub1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[3].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lblpubdat1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[4].ToString()) + "</label></td>";
                    mailbody = mailbody + "<td><label id=\"lbltotal1\" style='font-family:verdana;font-size:12'>" + chkvalue(ds2.Tables[0].Rows[i].ItemArray[5].ToString()) + "</label></td>";
                }
            }

            mailbody = mailbody + "</tr><tr><td><label id=\"lblinserts2\" style='font-family:verdana;font-size:12'>A3 Windhoek only</label></td>";
            mailbody = mailbody + "<td><label id=\"lblfulcol2\" style='font-family:verdana;font-size:12'>&nbsp;</label></td>";
            mailbody = mailbody + "<td><label id=\"lblpub2\" style=\" font-size:'12px';\">&nbsp;</label></td>";
            mailbody = mailbody + "<td><label id=\"lblpubdat2\" style='font-family:verdana;font-size:12'>Tuesday</label></td>";
            mailbody = mailbody + "<td><label id=\"lbltotal2\" style=\" font-size:'12px';\"></label>&nbsp;</td>";
            mailbody = mailbody + "</tr><tr><td colspan=\"5\"><label id=\"lblbop\" style='font-family:verdana;font-size:12'><b>" + objdat1.Tables[0].Rows[0].ItemArray[14].ToString() + "</b></label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblsig\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[15].ToString() + "</b></label></td>";
            mailbody = mailbody + "<td colspan=\"3\"><label id=\"lblsig2\" style=\" font-size:'12px';\">&nbsp;</label></td>";
            mailbody = mailbody + "</tr></table>";
            mailbody = mailbody + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" >";
            mailbody = mailbody + "<tr><td>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td><label id=\"lblthank\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[16].ToString() + "</b></label></td>";
            mailbody = mailbody + "</tr><tr><td>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td>__________________________</td></tr>";
            mailbody = mailbody + "<tr><td height=\"50px\"><label id=\"lbladd1\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></label></td></tr>";
            mailbody = mailbody + "</table>";
            mailbody = mailbody + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"1\">";
            mailbody = mailbody + "<tr><td colspan=\"2\" ><label id=\"lbldet\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblacnt\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[19].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblacnt1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[26].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblbank\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[20].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblbank1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[27].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblacntno\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[21].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblacntno1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[28].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblbranch\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[22].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblbranch1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[29].ToString() + "</label></td>";
            mailbody = mailbody + "</tr><tr><td width=\"28%\"><label id=\"lblactyp\" style='font-family:verdana;font-size:14'><b>" + objdat1.Tables[0].Rows[0].ItemArray[23].ToString() + "</b></label></td><td>";
            mailbody = mailbody + "<label id=\"lblactyp1\" style='font-family:verdana;font-size:12'>" + objdat1.Tables[0].Rows[0].ItemArray[30].ToString() + "</label></td>";
            mailbody = mailbody + "</tr></table>";
            string mailtoval = "";
            if (ds1.Tables[0].Rows[0]["EmailID"].ToString() == "" || ds1.Tables[0].Rows[0]["EmailID"].ToString() == null)
                mailtoval = "jens@dmh.com.na";
            else
                mailtoval = ds1.Tables[0].Rows[0]["EmailID"].ToString();
            string smtpadd = objdat1.Tables[0].Rows[0].ItemArray[32].ToString();
            string mailfromval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();
            objdat1.Tables[0].Rows[0].ItemArray[30].ToString();
            //MailMessage objMailMessage = new MailMessage();
            //objMailMessage = new MailMessage();
            //objMailMessage.To.Add(mailtoval);
            //objMailMessage.Subject = "Regarding Request";
            //objMailMessage.From = new MailAddress(mailfromval);// http://"+ipaddres+"/tverp/tv_car_approval.aspx?uid=" + uid + "&pstdate=" + stdate + "&sttme=" + sttme + " ";
            ////objMailMessage.IsBodyHtml = true;
            //string str = "";
            //str = "Hi, This is a request";

            ////objMailMessage.Body = "Hi, This is a request for mail.   <a href=" + url + ">http://" + ipaddres + "/tverp/tv_car_approval.aspx?uid=" + uid + "&pstdate=" + refid + "&mailto=" + mailto_indv + " </a> ";//&sttme=" + sttme + "
            ////192.168.5.148
            //objMailMessage.IsBodyHtml = true;
            //objMailMessage.Body = mailbody;
            //SmtpClient smtp = new SmtpClient(smtpadd);//192.168.1.99 // "202.63.107.91"
            //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            //smtp.Send(objMailMessage);
            MailMessage msgMail = new MailMessage();
            msgMail.To = mailtoval;
            msgMail.From = mailfromval;
            msgMail.BodyFormat = MailFormat.Html;
            msgMail.Subject = "Regarding Request";
            msgMail.Body = mailbody;
            SmtpMail.SmtpServer = smtpadd;
            SmtpMail.Send(msgMail);

        }
    }


    public string chkvalue(string val)
    {
        if (val == null || val == "")
            return "&nbsp;";
        else
            return val;
    }




    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindRetainer(string compcode, string reatinername, string agcode)
    {
        DataSet dsret = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getRetain = new NewAdbooking.Classes.BookingMaster();

            dsret = getRetain.getretainer(compcode, reatinername);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getRetain = new NewAdbooking.classesoracle.BookingMaster();
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                dsret = getRetain.getretainerDJ(compcode, reatinername, "0", Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString(), agcode);
            }
            else
            {
                if (Session["FILTER"].ToString() == "D")
                {
                    dsret = getRetain.getretainer(compcode, reatinername, Session["revenue"].ToString());
                }
                else
                {
                    dsret = getRetain.getretainer(compcode, reatinername, "0");
                }
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getRetain = new NewAdbooking.classmysql.BookingMaster();
            dsret = getRetain.getretainer(compcode, reatinername, "0");
        }
        return dsret;
    }





    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindExec(string compcode, string execname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

            ds = clsbooking.getExecbooking(compcode, execname, "0", "WE0");

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExecbooking(compcode, execname, "0", Session["revenue"].ToString(), "WE0");
            }
            else
            {
                ds = clsbooking.getExecbooking(compcode, execname, "0", "0", "WE0");
            }

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }
        }
        return ds;

       


    }



    [Ajax.AjaxMethod]
    public DataSet getexeczone(string execcode, string compcode)
    {
        //string execcode = txtexecname.Text;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

            ds = clsbooking.getExecZoneName(execcode, compcode);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

                ds = clsbooking.getExecZoneName(execcode, compcode);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

                ds = clsbooking.getExecZoneName(execcode, compcode);
                return ds;
            }



    }





    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client, string fla)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            {
                NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
                ds = clsbooking.get10ClientName(compcode, client);
            }
            else
            {
                NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
                ds = clsbooking.getClientName(compcode, client);
            }
            
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName_DJ(compcode, client, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString());
            }
            else if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                {
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.get10ClientName(compcode, client, Session["revenue"].ToString());
                }
                else
                {
                    NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                    ds = clsbooking.getClientName(compcode, client, Session["revenue"].ToString());
                }
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                {
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.get10ClientName(compcode, client, "0");
                }
                else
                {
                    NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                    ds = clsbooking.getClientName(compcode, client, "0");
                }
            }
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
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
        li1.Selected = true;
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


    public void binduom(string compcode, string adtype, string center)
    {
        DataSet ds = new DataSet();
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate( compcode,  adtype,  center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, center);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
       
        drpuom.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select UOM--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpuom.Items.Add(li1);

        if (ds.Tables[1].Rows.Count > 0)
        {



            for (i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[1].Rows[i].ItemArray[0].ToString();

                drpuom.Items.Add(li);
            }

        }

    }



   





    protected void drpuom_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/webbooking.xml"));


  
                if (drpuom.SelectedValue == "CPC")
                {
                    lbltotarea.Text = ds1.Tables[3].Rows[0].ItemArray[3].ToString();
                }
                //if (li.Value == "CPD")
                //{
                //    lbltotarea.Text = ds1.Tables[3].Rows[0].ItemArray[4].ToString();
                //}



                //if (li.Value == "CPI")
                //{
                //    lbltotarea.Text = ds1.Tables[3].Rows[0].ItemArray[5].ToString();
                //}

           


    }







    [Ajax.AjaxMethod]
    public DataSet bindagencusub(string agency, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindsub = new NewAdbooking.Classes.BookingMaster();

            ds = bindsub.bindsubagency(agency, compcode);


        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bindsub = new NewAdbooking.classesoracle.BookingMaster();

                ds = bindsub.bindsubagency(agency, compcode);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindsub = new NewAdbooking.classmysql.BookingMaster();

                ds = bindsub.bindsubagency(agency, compcode);


            }

        return ds;



    }


    [Ajax.AjaxMethod]
    public DataSet insertcashreceived(string ciobookid, string receiptno, string drpcashrecieved)
    {
        DataSet dscash = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insert = new NewAdbooking.classesoracle.BookingMaster();
            dscash = insert.insertCashReceived(ciobookid, receiptno, drpcashrecieved);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster insert = new NewAdbooking.Classes.BookingMaster();
            dscash = insert.insertCashReceived(ciobookid, receiptno, drpcashrecieved);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
            dscash = insert.insertCashReceived(ciobookid, receiptno, drpcashrecieved);
        }
        return dscash;
    }




   
    [Ajax.AjaxMethod]
    public DataSet GETCASH_PAY(string compcode, string paymode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindrate = new NewAdbooking.Classes.BookingMaster();
            dx = bindrate.GETCASH_PAY(compcode, paymode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindrate = new NewAdbooking.classesoracle.BookingMaster();
            dx = bindrate.GETCASH_PAY(compcode, paymode);
        }
        else
        {
            //  NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //  dx = bindrate.ratebind(adcat, compcode);
        }
        return dx;

    }

    [Ajax.AjaxMethod]
    public DataSet getVTSRate(string pubcode, string edition, string compcode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.getVTSRate(pubcode, edition, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dx = bindrate.getVTSRate(pubcode, edition, compcode);
            }
        return dx;
    }

    [Ajax.AjaxMethod]
    public DataSet getPremPage(string premcode, string id)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objUpdatePage_Booking = new NewAdbooking.Classes.BookingMaster();
            ds = objUpdatePage_Booking.getPremPage(premcode, id);
            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objPagePremium = new NewAdbooking.classesoracle.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        return ds;
    }
    




    [Ajax.AjaxMethod]
    public DataSet getpayandstatus(string agencycode, string agencysubcode, string compcode, string getdatecheck, string dateformat)
    {
        DataSet dch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getsta = new NewAdbooking.Classes.BookingMaster();
            dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, "WE0");
            return dch;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getsta = new NewAdbooking.classesoracle.BookingMaster();
                dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, "WE0");
                return dch;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getsta = new NewAdbooking.classmysql.BookingMaster();
                dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, "WE0");
                return dch;
            }


    }



    public void bindStatus()
    {
        drprostatus.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));
        ListItem li = new ListItem();
        li.Text = "--Select RO Status--";
        li.Value = "0";
        drprostatus.Items.Add(li);

        for (int i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drprostatus.Items.Add(li1);
        }
    }


    [Ajax.AjaxMethod]
    public void  labelgenerate(string a)
    {
        hdnlabel.Value = a;
    }



    [Ajax.AjaxMethod]
    public DataSet CONVERTTOLOCAL_CURRENCY(string p_Comp_code, string p_Curr_Code, string p_gross_amount, string p_bill_amount, string p_date, string dateformat, string covertcurrency)
    {
        DataSet ddl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        return ddl;
    }



}
