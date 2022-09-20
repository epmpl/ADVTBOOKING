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
using System.IO;
using System.Web.Mail;
using FourCPlus.AdBooking.BookingMaster.Oracle;
using FourCPlus.AdBooking.BookingMaster.Sql;

public partial class QBC : System.Web.UI.Page
{
    

    /*new change ankur 27 feb*/
    string for_uom = "";
    string foruom_temp = "";
    string[] arrfor_uom;
    //////////////////
    string formname = "";
    string dateformat = "";
    static int FlagStatus, fpnl;
    static string saveormodify = "";
    int cou = 0;
    string message = "";
    static DataSet executequery = new DataSet();
    static string gciobookid = "";
    string getdatecheck = "";
    string rategr = "";
    string agencyrate = "";
    string clientrate = "";
    string insertstatus;
    int i = 0;
    static string modifyrateaudit = "";
    static string ip = "";
    static string grono = "";
    static string gdockitno = "";
    static string gkeyno = "";
    static string gagencyscode = "";
    static string gclient = "";
    string agencycodeforsave = "";
    string confirm_Permission = "";
    /*change ankur*/
    static DataSet ds_billto = new DataSet();
    //
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage); AspNetMessageBox_close
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "ShowAlert", strAlert, true);
    }
    /*new change 14 feb*/
    protected void AspNetMessageBox_close(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage); 
        string strAlert = "";
        strAlert = "alert('" + strMessage + "');window.close();";
        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "ShowAlert", strAlert, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        ///////////////////////////add for category modify
        if (Request.QueryString["modifyflag"] != null)
        {
            hdnmodifycateg.Value = Request.QueryString["modifyflag"].ToString();
        }
        hdndepo.Value = ConfigurationSettings.AppSettings["center"].ToString();
        

        if (Request.QueryString["prcioid"] != null)
        {
            hdnprcioid.Value = Request.QueryString["prcioid"].ToString();
        }

        else
        {

            hdnprcioid.Value = "";
        }

      
        



        if (hdndepo.Value == "center")
        {

            btnholding.Text = "Hold Booking";
        }
        else
        {
            btnholding.Text = "Hold&Save";


        }
       
        

       
       hiddeninsertwise.Value = ConfigurationManager.AppSettings["boxchrginsertwise"].ToString();
        if (Request.QueryString["bookingtype"] != null)
        {
            hiddenbooktype.Value = Request.QueryString["bookingtype"].ToString();
            hiddenbooktypeOrig.Value = hiddenbooktype.Value;
        }
        else
        {
            hiddenbooktype.Value = "3";
            hiddenbooktypeOrig.Value = hiddenbooktype.Value;
        }
        //if (HttpContext.Current.Session.SessionID == null)
        //{
        hiddenqbcadtype.Value = ConfigurationManager.AppSettings["QBCADTYPE"].ToString();
      
        //if (ConfigurationManager.AppSettings["QBCADTYPE"].ToString() == "ENABLE")
        //{
        //    drpadtype.Enabled = true;
        //}
        //else
        //{
        //    drpadtype.Enabled = false;
        //}
        hiddenEyeBasedOnEdition.Value = ConfigurationSettings.AppSettings["EyeCatcherBasedOnEdition"].ToString();
        hiddenregClient.Value = ConfigurationSettings.AppSettings["registerClient"].ToString();
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
            string sessionout = "Your Session Has Been Expired";
            AspNetMessageBox_close(sessionout);
            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

            return;

        }
        // }

        if (HttpContext.Current.Session.SessionID != null)
        {
            if (Session["uom"] != null)
            {
                hiddenuom1.Value = Session["uom"].ToString();
            }
        }


        /*new change for agency*/
        hiddenagencyrate.Value = Session["agencyratecode"].ToString();
        ip = this.Page.Request.ServerVariables["REMOTE_ADDR"];

        //**********************By Manish Verma*****************************
        if (Session["copyrate"] != null)
        {
            hiddencopyrate.Value = Session["copyrate"].ToString();
        }
        hiddencopyrate.Value = "n";
        hiddencopy.Value = "n";
        if (saveormodify != "0" && saveormodify != "01")
        {
            Session["fileName"] = null;
            Session["savedata"] = null;
        }
        //*********************************************************************
        hiddeneyecatchpubwise.Value = ConfigurationSettings.AppSettings["eyecatcherRatePublicationwise"].ToString(); 
        hiddenconnect.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString().ToLower();
        get_pacakge_new.Enabled = false;
        dateformat = Session["dateformat"].ToString();
        if (dateformat == "mm/dd/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;
        }
        else if (dateformat == "dd/mm/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
        }
        else
        {
            HDN_server_date.Value = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
        }
        formname = "QBC";
        Ajax.Utility.RegisterTypeForAjax(typeof(QBC));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddencurrency.Value = Session["currency"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddeninserts.Value = Session["insertsbreakup"].ToString();
        hiddencurrency.Value = Session["currency"].ToString();
        hiddenuserdisc.Value = Session["USERDISCOUNT"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();

        hiddentfn.Value = Session["tfn"].ToString();
        hiddencioidformat.Value = Session["cioid"].ToString();
        hiddenusername.Value = Session["username"].ToString();

        hiddencompuser.Value = Session["userhome"].ToString();
        hiddenadmin.Value = Session["Admin"].ToString();
        hiddenreceiptnoformat.Value = Session["Receipt_no"].ToString();
        hiddenpremtype.Value = Session["premtype"].ToString();
        hiddentype.Value = Session["dealtype"].ToString();
        hiddenprefix.Value = Session["prefix"].ToString();
        hiddensufix.Value = Session["suffix"].ToString();
        hiddenvat.Value = Session["vat"].ToString();
        hiddencirculation.Value = Session["solorate"].ToString();

        hiddenroadcat.Value = Session["roadcat"].ToString();

        hiddenrodatetime.Value = Session["rodatetime"].ToString();
        /*new change ankur 26 feb*/
        hiddenvaliddate.Value = Session["validdate_pub"].ToString();
        hiddenratecheckdate.Value = Session["RATE_CHECK"].ToString();

        hiddencenter.Value = Session["center"].ToString();
        hiddenaudit.Value = Session["audit"].ToString();
        hiddenratepremtype.Value = Session["ratepremtype"].ToString();
        hiddenschemetype.Value = Session["SCHEME_TYPE"].ToString();

        txtratecode.Value = "qbc";
        txteyecathval.Enabled = false;
        txteyecathval.Text = "2";
        
        configclient.Value = ConfigurationSettings.AppSettings["CLIENTNAME"].ToString();
        // if (Request.QueryString["cioid"] != null)
        if (Request.QueryString["search"] != null)
        {
            hiddenadsearch.Value = "true";
        }
        else
        {
            hiddenadsearch.Value = "false";
        }
        if (Request.QueryString["cioid"] != null)
        {
            hiddenaudit.Value = Request.QueryString["cioid"].ToString();


        }
        else
        {
            hiddenaudit.Value = "";
        }
        /*change*/

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            hiddentypedatabase.Value = "sql";
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            hiddentypedatabase.Value = "mysql";
            /*mysql*/
            chkattach.Enabled = false;
            chkattach.Checked = true;
        }
        else
        {

            hiddentypedatabase.Value = "orcl";
        }
        //////////////////////////////////////////////////////////////////
        DataSet objDataSetbu1 = new DataSet();
        // Read in the XML file
       // objDataSetbu1.ReadXml(Server.MapPath("XML/qbcdefaultvalue.xml"));
      //  hiddenexecname.Value = objDataSetbu1.Tables[0].Rows[0].ItemArray[0].ToString();
       // hiddenzone.Value = objDataSetbu1.Tables[0].Rows[0].ItemArray[1].ToString(); 
        //This code reads the label name from the xml file
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
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

        ////////////////this is the code to get the label name
        DataSet objDataSetlabel = new DataSet();
        // Read in the XML file
        objDataSetlabel.ReadXml(Server.MapPath("XML/qbc.xml"));
      

        lbdatetime.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[0].ToString();
        lbbranch.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[1].ToString();
        lbbookedby.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[2].ToString();
        lbcioid.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[3].ToString();
        lbpreid.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[4].ToString();
        lbagency.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[5].ToString();
        lbclient.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[6].ToString();
        lbcaddress.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadcat.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[8].ToString();
        lbrono.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[9].ToString();
        lbrodate.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[10].ToString();
        lbrostatus.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[11].ToString();
        lbcolor.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[12].ToString();
        lbbgcolor.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[13].ToString();
        lbbullet.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[14].ToString();
        lbpackage.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[15].ToString();
        lbpaid.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[16].ToString();
        lbmat.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[17].ToString();
        lbuom.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[18].ToString();
        lbadsize.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[19].ToString();
        h.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[20].ToString();
        w.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[21].ToString();
        lbcolumn.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[22].ToString();
        lbpagepost.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[23].ToString();
        Label1.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[24].ToString();
        lblpaymentstatus.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[25].ToString();
        lbcontractname.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[26].ToString();
        lbcontracttype.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[27].ToString();
        lblcardrate.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[28].ToString();
        lbgrossamt.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[29].ToString();
        lbboxcode.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[40].ToString();
        lbboxno.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[41].ToString();
        lbselectdate.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[32].ToString();
        lbnoofins.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[33].ToString();
        lbrepdate.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[34].ToString();
        lblreceiptno.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[35].ToString();
        lblreceiptdate.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[36].ToString();
        lbprintremark.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[37].ToString();
        btnlogo.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[38].ToString();
        btnconfirm.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[39].ToString();
        lbbillto.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[42].ToString();
        /*new change ankur*/
        lbcolortype.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[43].ToString();
        /*new change ankur 11 feb*/
        lbadtype.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[44].ToString();
        /*new change ankur 22 feb*/
        btnlogo.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[45].ToString();
        btnlogoupload.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[46].ToString();
        lblogosize.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[47].ToString();
        logoh.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[20].ToString();
        logow.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[21].ToString();
        lbcolorlogo.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[48].ToString();
        lblogouom.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[49].ToString();
        lbreceipt.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[50].ToString();
        lblboxcode.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[52].ToString();
        lblboxno.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[53].ToString();
        lbboxadd.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[54].ToString();
        lbboxchrg.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[55].ToString();
        //lbadsubcategory.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[56].ToString();
        //lbadcat3.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[57].ToString();
        //lbadcat4.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[58].ToString();
        //lbadcat5.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[59].ToString();
        lbclntheading.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[60].ToString();
        lbaddtlheading.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[61].ToString();
        lbpackagecopy.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[62].ToString();
        btncopy.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[63].ToString();
        btndel.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[64].ToString();
        get_pacakge_new.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[65].ToString();
        btnSaveConfirm.ImageUrl = objDataSetlabel.Tables[0].Rows[0].ItemArray[66].ToString();
        lblbalance.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[67].ToString();
        lbratecode.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[68].ToString();
        btndeal.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[69].ToString();
        lbkey.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[70].ToString();
        lbldesign.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[71].ToString();
        lbllogoprem.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[72].ToString();
        lbmobileno.Text = objDataSetlabel.Tables[0].Rows[0].ItemArray[73].ToString();
        /*new changes ankur */
        if (objDataSetlabel.Tables.Count > 1)
        {
            if (objDataSetlabel.Tables[1].Rows[0].ItemArray[0].ToString() == "hide")
            {

                btndiscount.Attributes.Add("style", "display:none");
            }
        }
        ///////this code is to show the user's previous booking and the branch
        DataSet dprv = new DataSet();
     
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "CL0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "CL0");

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "CL0");


            }


        //NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
        //dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "QBC");

        if (dprv.Tables[0].Rows.Count > 0)
        {
            hiddensepcashier.Value = dprv.Tables[2].Rows[0].ItemArray[7].ToString();
            txtprevbook.Text = dprv.Tables[0].Rows[0].ItemArray[0].ToString();
            hiddencopy.Value = dprv.Tables[2].Rows[0].ItemArray[5].ToString();
            hiddencutofftime.Value = "y";// dprv.Tables[2].Rows[0].ItemArray[6].ToString();
            if (dprv.Tables[2].Rows[0].ItemArray[8].ToString() != "")
                hiddenmaxdays.Value = dprv.Tables[2].Rows[0].ItemArray[8].ToString();
            else
                hiddenmaxdays.Value = "0";
            hidspldisedit.Value = dprv.Tables[2].Rows[0].ItemArray[9].ToString();
            hidshareman.Value = dprv.Tables[2].Rows[0].ItemArray[10].ToString();
            hidmultisel.Value = dprv.Tables[2].Rows[0].ItemArray[11].ToString();
            hidschememin.Value = dprv.Tables[2].Rows[0].ItemArray[12].ToString();
          //  hidspltd.Value = dprv.Tables[2].Rows[0].ItemArray[13].ToString();
        }
        else
        {
            txtprevbook.Text = "";
        }
        //if (dprv.Tables[1].Rows.Count > 0)
        //{
        //    txtbranch.Text = dprv.Tables[1].Rows[0].ItemArray[0].ToString();
        //}
        //if (txtbranch.Text == "")
        //{
        //    txtbranch.Text = Session["revenue"].ToString();
        //}
        ///////this is to get that whether the user can do the backdate booking 
        ///if it is 0 than backdate booking is not possible and if 1 than it can be

        if (dprv.Tables[2].Rows.Count > 0)
        {
            hiddenbackdatebook.Value = dprv.Tables[2].Rows[0].ItemArray[0].ToString();
            if (dprv.Tables[2].Rows[0].ItemArray[0].ToString() == "" || dprv.Tables[2].Rows[0].ItemArray[0].ToString() == null)
            {
                hiddenbackdatebook.Value = "0";
            }

        }
        


        if (dprv.Tables[4].Rows.Count > 0)
        {
            confirm_Permission = dprv.Tables[4].Rows[0].ItemArray[0].ToString();
        }
        hiddenconfirm_Permission.Value = confirm_Permission;
        if (Session["ALL_PACKAGE"] != null)
        {
            if (Session["ALL_PACKAGE"].ToString() == "n")
            {
                chkall.Checked = false;
            }
            else
            {
                chkall.Checked = true;
            }
        }
        bindpackage();
        bindcoupan();
        State();
        if (!Page.IsPostBack)
        {
            if (Session["agency_name"].ToString() == "0")
                agnlogin.Value = "N";
            else
                agnlogin.Value = "Y";
            bindstyle();
            hdnf2.Value = Session["revenue"].ToString();
            hiddenadtype.Value = "CL0";
            hiddenchkf2.Value = ConfigurationSettings.AppSettings["f2"].ToString();
            if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes")
            {
                if (hdnf2.Value != "")
                {
                    txtagency.ReadOnly = true;
                    txtbranch.Enabled = false;
                    if(Session["agency_name"].ToString()=="0")
                    txtagency.Text = "";
                    txtagencyaddress.Value = "";
                    //txtagency.Enabled = true;
                }
                else
                {
                    //txtagency.Enabled = false;
                    txtagency.ReadOnly = true;
                    txtbranch.Enabled = false;
                }
            }
            else
            {
                txtagency.ReadOnly = true;
                txtbranch.Enabled = false;
            }

            if (dprv.Tables[3].Rows.Count > 0)
            {

                if (saveormodify != "1")
                {
                    if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes")
                    {
                        if (hdnf2.Value != "")
                        {
                            if (Session["agency_name"].ToString() == "0")
                            {
                                txtagency.Text = "";
                                txtagencyaddress.Value = "";
                            }
                            else
                            {
                                txtagency.Text = dprv.Tables[3].Rows[0].ItemArray[0].ToString();
                                txtagencyaddress.Value = dprv.Tables[3].Rows[0]["address"].ToString();
                            }
                            hdnagencyname.Value = dprv.Tables[3].Rows[0].ItemArray[0].ToString();
                            ListItem li1;
                            li1 = new ListItem();
                            li1.Text = "-Credit-";
                            li1.Value = "CR1";
                            drppaymenttype.Items.Add(li1);
                        }
                        else
                        {
                            txtagency.Text = dprv.Tables[3].Rows[0].ItemArray[0].ToString();
                            txtagencyaddress.Value = dprv.Tables[3].Rows[0]["address"].ToString();
                            ListItem li1;
                            li1 = new ListItem();
                            li1.Text = "-Credit-";
                            li1.Value = "CR1";
                            drppaymenttype.Items.Add(li1);
                        }
                    }
                    else
                    {
                        txtagency.Text = dprv.Tables[3].Rows[0].ItemArray[0].ToString();
                        txtagencyaddress.Value = dprv.Tables[3].Rows[0]["address"].ToString();
                        ListItem li1;
                        li1 = new ListItem();
                        li1.Text = "-Credit-";
                        li1.Value = "CR1";
                        drppaymenttype.Items.Add(li1);
                    }

                    /*new change ankur for agency*/
                    string[] split_code = dprv.Tables[3].Rows[0].ItemArray[0].ToString().Split('(');
                    hiddenagencycodeforrate.Value = split_code[1].Replace(")", "");
                    /*mysql*/
                    Session["agencycodeforrate"] = hiddenagencycodeforrate.Value;

                    agencycodeforsave = dprv.Tables[3].Rows[0].ItemArray[1].ToString();
                    hiddenagencycodeforsave.Value = agencycodeforsave;
                    /* chANGE     BIND THE BILL TO FROM AGENCY PARENT AND CHILD*/

                  //  bindagencybillto(dprv);
                }
                /*change for oracle*/



            }
            /* change  */
            else
            {
                /*new change ankur 14 feb*/
                //if (dprv.Tables[5].Rows.Count <= 0)
                //{
                //    string givalert = "You have not enrolled to any agency";
                //    AspNetMessageBox_close(givalert);
                //    //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "close", "window.close();", true);
                //    return;

                //}
                if (saveormodify != "1")
                {
                    if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes")
                    {
                        if (hdnf2.Value != "")
                        {
                            if (Session["agency_name"].ToString() == "0")
                            {
                                txtagency.Text = "";
                                txtagencyaddress.Value = "";
                            }
                            else
                            {
                                txtagency.Text = dprv.Tables[5].Rows[0].ItemArray[0].ToString();
                                txtagencyaddress.Value = dprv.Tables[5].Rows[0]["address"].ToString();
                            }
                            if(dprv.Tables[5].Rows.Count>0)
                                hdnagencyname.Value = dprv.Tables[5].Rows[0].ItemArray[0].ToString();

                        }
                        else
                        {
                            if (dprv.Tables[5].Rows.Count > 0)
                            {
                                txtagency.Text = dprv.Tables[5].Rows[0].ItemArray[0].ToString();
                                txtagencyaddress.Value = dprv.Tables[5].Rows[0]["address"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dprv.Tables[5].Rows.Count > 0)
                        {
                            txtagency.Text = dprv.Tables[5].Rows[0].ItemArray[0].ToString();
                            txtagencyaddress.Value = dprv.Tables[5].Rows[0]["address"].ToString();
                        }
                    }
                }


                /*new change for agency*/
                if (dprv.Tables[5].Rows.Count > 0)
                {
                    string[] split_code = dprv.Tables[5].Rows[0].ItemArray[0].ToString().Split('(');
                    hiddenagencycodeforrate.Value = split_code[1].Replace(")", "");
                    agencycodeforsave = dprv.Tables[5].Rows[0].ItemArray[1].ToString();
                }

                Session["agencycodeforrate"] = hiddenagencycodeforrate.Value;

               
                /* chANGE     BIND THE BILL TO FROM AGENCY PARENT AND CHILD*/
                if (saveormodify != "1")
                {
                  //  bindagencybillto_1(dprv);
                }
            }

          
            Session["fileName"] = null;
            Session["savedata"] = null;
            /*new change ankur 11 feb*/
            bindadtype();
           
            ///////////////////////////////////////
            txtbookedby.Text = Session["username"].ToString();
            getbuttoncheck(formname);
            advcat(Session["compcode"].ToString());
            bindcolor();
            fillQBC(Session["center"].ToString());
            // 
            if (ConfigurationSettings.AppSettings["EyeCatcherBasedOnEdition"].ToString() == "no")
            {
                bindbullet();
            }
            //
          //  bindpackage();
            binduom();
           // 2010 bindpagePosition(Session["compcode"].ToString());

            //  bindbox();
            /*    change    */
         // 2010   bindregion();
            ////////////////////
            /*new changes ankur 15 feb*/
         // 2010   bindvariable();
            bindbox();
            // bindcolortype();

            if (Session["bg_colorpub"].ToString() == "yes")
            {
                drpcolortype.Attributes.Add("onchange", "javascript:return fillbgcolor();");
            }
            else
            {
                bindbgcolor();
            }
            drpcoutype.Attributes.Add("OnChange", "javascript:return blankGross()");
            drpstyle.Attributes.Add("OnChange", "javascript:return fillStyle()");
            btnschme.Attributes.Add("onclick", "javascript:return scmename();");
            chkage.Attributes.Add("onclick", "javascript:return agencychk()");
            chkclie.Attributes.Add("onclick", "javascript:return clientchk()");

            btnfmg.Attributes.Add("OnClick", "javascript:return openFMGRef();"); 
            btnsharing.Attributes.Add("OnClick", "javascript:return openPubPrecentage();"); 
            drpratecode.Attributes.Add("onchange", "javascript:return rateRefresh();");
            btndiscount.Attributes.Add("OnClick", "javascript:return openDiscDetail();");
            txtagency.Attributes.Add("OnChange", "javascript:return chkagency();");
            drppackage.Attributes.Add("onkeypress", "return keySort(this);");
            btnconfirm.Attributes.Add("OnClick", "javascript:return confirmClick1();");
            btnNew.Attributes.Add("OnClick", "javascript:return newClick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return clearClick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryClick()");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstClick()");
            btnprevious.Attributes.Add("OnClick", "javascript:return prevClick()");
            btnlast.Attributes.Add("OnClick", "javascript:return lastClick()");
            btnnext.Attributes.Add("OnClick", "javascript:return nextClick()");
            drpboxcodenew.Attributes.Add("onChange", "javascript:return getboxno();");
            drpbgcolor.Attributes.Add("onchange", "javascript:return fillintohiddenbg();");

            drpboxcodenew.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtboxadd.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            btnDelete.Attributes.Add("onclick", "javascript:return deleteCheck();");
            ////////////////////////
            drpadcategory.Attributes.Add("onchange", "javascript:return filladsubcatmain();");
            drpadsubcategory.Attributes.Add("onchange", "javascript:return filladscatingrid();");
            drpadcategory.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            // drpadsubcategory.Attributes.Add("onchange", "javascript:return bindadscat3();");
            drpadsubcategory.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpadcat3.Attributes.Add("onchange", "javascript:return bindadscat4();");
            drpadcat3.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpadcat4.Attributes.Add("onchange", "javascript:return bindadcat5();");
            drpadcat4.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpadcat5.Attributes.Add("onchange", "javascript:return getcat5val();");
            drpadcat5.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbullet.Attributes.Add("onchange", "javascript:return getbullpremium();");
            drpbullet.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            btncopy.Attributes.Add("onclick", "javascript:return addpkgname();");
            btndel.Attributes.Add("onclick", "javascript:return removepkgname();");
            txtinsertion.Attributes.Add("OnChange", "javascript:return onInsertionChange();");
            txtinsertion.Attributes.Add("onfocus", "javascript:return chkbookingdate();");
            txtinsertion.Attributes.Add("OnBlur", "javascript:return noblank();");
            //btnshgrid.Attributes.Add("onclick", "javascript:return gettherate();");
            //btnshgrid.Attributes.Add("onclick", "javascript:return showdealvalue();");//Manish
            btnshgrid.Attributes.Add("onclick", "javascript:return checkGridDate_Validation();");
            /*new change ankur */
            chkhindi.Attributes.Add("OnClick", "javascript:return checkPub();");
            chkhindu.Attributes.Add("OnClick", "javascript:return checkPub();");

            drpuom.Attributes.Add("onchange", "javascript:return gettheuomdesc();");
            drpuom.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            //txttotalarea.Attributes.Add("onchange", "javascript:return fillnooflineintogrid();");showdealvalue
            //txttotalarea.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drppageposition.Attributes.Add("onchange", "javascript:return getpageamt();");
            drppageposition.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            // drpboxcode.Attributes.Add("onchange", "javascript:return getboxno();");
            //drpboxcode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            chkall.Attributes.Add("OnClick", "javascript:return bindpackage_cen();");
            lstagencymain.Attributes.Add("onclick", "javascript:return lstagencymain1();");
            //lstagencymain.Attributes.Add("OnKeydown", "javascript:return lstagencymain1();");
            lstagencymain.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");

            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");
            lstclient.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            btnSave.Attributes.Add("OnClick", "javascript:return checkValidation(this.id);");
            btnSaveConfirm.Attributes.Add("OnClick", "javascript:return checkValidation(this.id);");
            btnModify.Attributes.Add("OnClick", "javascript:return getprevcioid();");
            btnExit.Attributes.Add("onclick", "javascript:return exitbook();");
            txtrepeatingdate.Attributes.Add("OnBlur", "javascript:return onRepeatingDate();");
            txtrepeatingdate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtrepeatingdate.Attributes.Add("OnKeyPress", "javascript:return checkdateInsert();");
            txtrepeatingdate.Attributes.Add("OnKeydown", "javascript:return checknumeric();");

            txtrono.Attributes.Add("Onchange", "javascript:return setvalueintorodate();");
            txtrono.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtadsize1.Attributes.Add("onchange", "javascript:return getheight();");
            txtadsize1.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtadsize2.Attributes.Add("onchange", "javascript:return chkwidth();");
            txtadsize2.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txttotalarea.Attributes.Add("onchange", "javascript:return fillnooflineintogrid();");
            txttotalarea.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtclient.Attributes.Add("onblur", "javascript:return chkcasualclient();");
            txtclient.Attributes.Add("onchange", "javascript:return blanckclientadd();");
            txtclient.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpcolor.Attributes.Add("onchange", "javascript:return fillcoloringrid();");
            txtclientadd.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");

            drpcolor.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            /*    change               */
            drpcolor.Attributes.Add("onclick", "javascript:return chklevelofcategory();");
            drpbgcolor.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbgcolor.Attributes.Add("onBlur", "javascript:return bgcolor_blur();");
            drppackage.Attributes.Add("onBlur", "return lostfocusPackage(this);");
            drppackage.Attributes.Add("onfocus", "javascript:return getfocusPackage(this);");
            txtcolum.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
           // txtdummydate.Attributes.Add("onfocus", "javascript:return popUpCalendar(this, Form1.txtdummydate, 'mm/dd/yyyy');");
            //txtdummydate.Attributes.Add("OnChange", "javascript:return checkdateforbook(this);  ");
            txtdummydate.Attributes.Add("OnChange", "javascript:return hideCalendar1();  ");
            txtreceiptdate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtprintremark.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpmatstat.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcolum.Attributes.Add("onchange", "javascript:return getwidth();");
            txtprintremark.Attributes.Add("onchange", "javascript:return fillRemarks();");
            txtcontractname.Attributes.Add("onchange", "javascript:blankcontractrate();");
            chkcontract.Attributes.Add("onclick", "javascript:return enablecontract();");
            txtrodate.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
            txtrodate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            /*change ankur*/
            drpbillto_qbc.Attributes.Add("onchange", "javascript:return billtochange();");
            /*new change ankur 10 feb*/
            ////at the time of execution first it will ask than whether you want to copy the data if OK than search id's content comes to the 
            ///////////field with new cio id and if not than he can only modify the data
            //btnExecute.Attributes.Add("onclick", "javascript:return datacopy();");
            btnExecute.Attributes.Add("onclick", "javascript:return executeClick();");
            
            /////////////////////////////////////
            drpratecode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtinsertion.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtdummydate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpdesign.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drplogoprem.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drppaymenttype.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpcoutype.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtcouno.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtkeyno.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpbillto_qbc.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpstate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtMobile.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtsapid.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            /*new change ankur 11 feb*/
            drpadtype.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpadtype.Attributes.Add("onchange", "javascript:return bindadcategory();");
            ////////////////////////////
            /*new change ankur 22 feb*/
            btnlogo.Attributes.Add("onclick", "javascript:return showlogodetails();");

            /*new change ankur 2 feb*/
            btnlogoupload.Attributes.Add("onclick", "javascript:return uoloadlogoall();");

            /*new change ankur 23feb*/
            txtlogohei.Attributes.Add("onchange", "javascript:return filllogohei();");
            txtlogowid.Attributes.Add("onchange", "javascript:return filllogowidth();");

            /*new change ankur 26 feb*/
            lbreceipt.Attributes.Add("onclick", "javascript:return printreceipt();");
            get_pacakge_new.Attributes.Add("onclick", "javascript:return getmulpackage();");

            btnpaygateway.Attributes.Add("onclick", "javascript:return openpaygetway()");
            attachment1.Attributes.Add("OnClick", "javascript:return openattach1();");
            btndeal.Attributes.Add("onclick", "javascript:return showdealvalue();");
            btnholding.Attributes.Add("onclick", "javascript:return holdbooking();");
            btnsavepay.Attributes.Add("onclick", "javascript:return checkValidation(this.id);");
            drpuom.Attributes.Add("onBlur", "javascript:return alertforcatuom();");
            drpratecode.Attributes.Add("onmouseover", "opentooltipratecode(event);");
        /*add  by anuja*/
            drppaymenttype.Attributes.Add("OnChange", "javascript:return paymodechange()");
            btnshdl.Attributes.Add("onclick", "javascript:return CreateMfgDetail(this.id);");
           // drppaymenttype.Attributes.Add("onclick", "javascript:return chequedetail()");
          //  txtagency.Attributes.Add("OnBlur", "javascript:return noblank();");
            btnNew.Focus();
            hiddenbookstatus.Value = Session["bookstat"].ToString();
            if (Session["bookstat"].ToString() == "Booked")
            {
                drprostatus.SelectedValue = "1";
            }
            else if (Session["bookstat"].ToString() == "Unconfirmed")
            {
                drprostatus.SelectedValue = "2";
                drprostatus.Enabled = false;
            }

        }

        txtreceipt.ReadOnly = true;
        txteyecathval.Enabled = false;
        
        //txtagency.Enabled = false;
        DateTime dt = DateTime.Now;

        int year = Convert.ToInt32(dt.Year);
        int month = Convert.ToInt32(dt.Month);
        int day = Convert.ToInt32(dt.Day);
        string serdate = "";
      
        /*change for oracle*/
        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            serdate = Convert.ToString(day + "/" + month + "/" + year);
        }
        else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
        {
            serdate = Convert.ToString(month + "/" + day + "/" + year);
        }
        else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
        {
            serdate = Convert.ToString(year + "/" + month + "/" + day);
        }
        datesave getdatechk = new datesave();
        dateinsert getdateshow = new dateinsert();
       // txtdatetime.Text = getdateshow.getDatedisp(Session["dateformat"].ToString(), serdate);
        DataSet dsdate = new DataSet();
        DataSet per = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
           // FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
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
            //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            NewAdbooking.classesoracle.BookingMaster cls_book = new NewAdbooking.classesoracle.BookingMaster();
            dsdate = cls_book.getCurrdate();
            per = cls_book.chkdiscountpremedit_per(hiddenuserid.Value, hiddencompcode.Value);
        }
        if (per.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < per.Tables[0].Rows.Count; i++)
            {
                if (per.Tables[0].Rows[i].ItemArray[0].ToString() == "Edit Agency to Super Users After Confirm In QBC")
                    hideditagency.Value = "Y";
            }
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

        hiddenboxadd.Value = ConfigurationManager.AppSettings["boxmatterdefault"].ToString();

       // txtdatetime.Text = Convert.ToDateTime(serdate).ToString("dd-MMM-yyyy");


        //getdatecheck = getdatechk.getDate(Session["dateformat"].ToString(), serdate);
        /*change ankur*/
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[11].ToString();
        hidagencyname.Value = txtagency.Text;
        hiddencopy.Value = "n";
        bindDesignBox();
        bindLogoPremium();
        btnNew.Focus();

        DataSet ds_rcpt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objReceipt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds_rcpt = objReceipt.clsBranchAlias(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objReceipt = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds_rcpt = objReceipt.clsBranchAlias(Session["compcode"].ToString(), Session["revenue"].ToString());
        }
        else
        {

        }
        hiddenorigbranch.Value = ds_rcpt.Tables[0].Rows[0].ItemArray[1].ToString();

    }



    /*new change ankur 9feb*/
    public void bindDesignBox()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
            dx = bind.bindDesignBox_Classified(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bind = new NewAdbooking.classesoracle.adbooking();
                dx = bind.bindDesignBox_Classified(Session["compcode"].ToString());
            }
           
        drpdesign.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Design-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpdesign.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpdesign.Items.Add(li);
            }

        }
    }
    public void bindLogoPremium()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
            dx = bind.bindLogoPrem_Classified(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adbooking bind = new NewAdbooking.classesoracle.adbooking();
                dx = bind.bindLogoPrem_Classified(Session["compcode"].ToString());
            }

        drplogoprem.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Logo Prem-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drplogoprem.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drplogoprem.Items.Add(li);
            }

        }
    }
    /*new change ankur 11 feb*/
    public void bindadtype()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            dx = bind.adtypbind(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")   
            {
                NewAdbooking.classesoracle .CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
            dx = bind.adtypbind(Session["compcode"].ToString());
            }
        else
        {
            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
            dx = bind.adtypbind(Session["compcode"].ToString());
        }
        drpadtype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpadtype.Items.Add(li);
            }

        }
        drpadtype.SelectedValue = "CL0";
        hiddenadtype.Value = "CL0";

    }

    public void bindcolortype()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BgColor colortype = new NewAdbooking.Classes.BgColor();

            dx = colortype.bindcolortyp(Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Classes.BgColor colortype = new NewAdbooking.Classes.BgColor();

                dx = colortype.bindcolortyp(Session["compcode"].ToString());
            }
        else
        {
            NewAdbooking.classmysql.BookingMaster colortype = new NewAdbooking.classmysql.BookingMaster();

            dx = colortype.bindcolortyp(Session["compcode"].ToString());
        }
        drpcolortype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select color type-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcolortype.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcolortype.Items.Add(li);
            }

        }

    }
    public void bindregion()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CityMaster RegionName = new NewAdbooking.Classes.CityMaster();

            dx = RegionName.region(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CityMaster RegionName = new NewAdbooking.classesoracle.CityMaster();
            dx = RegionName.region(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        else
        {
            NewAdbooking.classmysql.CityMaster RegionName = new NewAdbooking.classmysql.CityMaster();

            dx = RegionName.region(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        drpregion.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Region-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpregion.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpregion.Items.Add(li);
            }

        }

    }
    /*  change  */


    /*new changes ankur*/
    public void bindvariable()
    {

        DataSet dset = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster variablename = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dset = variablename.variable_name(Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster variablename = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dset = variablename.variable_name(Session["compcode"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.BookingMaster RegionName = new NewAdbooking.classmysql.BookingMaster();

            dset = RegionName.variable_name(Session["compcode"].ToString());
        }
        drpvarient.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Variable-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpvarient.Items.Add(li1);

        if (dset.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dset.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dset.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dset.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpvarient.Items.Add(li);
            }

        }


    }

    public void bindagencybillto(DataSet dat)
    {
        ds_billto = dat;
        drpbillto_qbc.Items.Clear();
        int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "-Select Region-";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //drpbillto_qbc.Items.Add(li1);

        if (dat.Tables[7].Rows.Count > 0)
        {
            for (i = 0; i < dat.Tables[7].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dat.Tables[7].Rows[i].ItemArray[0].ToString();
                li.Value = dat.Tables[7].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpbillto_qbc.Items.Add(li);
            }

        }
        if (txtclient.Text != "" && (saveormodify == "1" || saveormodify == "01"))
        {
            ListItem li1;
            li1 = new ListItem();
            li1.Text = txtclient.Text;
            li1.Value = txtclient.Text;
            //li1.Selected = true;
            drpbillto_qbc.Items.Add(li1);
        }

    }
    /*change*/

    public void bindagencybillto_1(DataSet dat)
    {
        ds_billto = dat;
        drpbillto_qbc.Items.Clear();
        int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "-Select Region-";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //drpbillto_qbc.Items.Add(li1);

        if (dat.Tables[7].Rows.Count > 0)
        {
            for (i = 0; i < dat.Tables[7].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dat.Tables[7].Rows[i].ItemArray[0].ToString();
                li.Value = dat.Tables[7].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpbillto_qbc.Items.Add(li);
            }

        }

        if (txtclient.Text != "" && (saveormodify == "1" || saveormodify == "01"))
        {
            ListItem li1;
            li1 = new ListItem();
            li1.Text = txtclient.Text;
            li1.Value = txtclient.Text;
            //li1.Selected = true;
            drpbillto_qbc.Items.Add(li1);
        }

    }


    public void bindpagePosition(string compcode,string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.bindPagePosition(compcode, txtdatetime.Text, Session["dateformat"].ToString(),adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.bindPagePosition(compcode, txtdatetime.Text, Session["dateformat"].ToString(),adtype);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.bindPagePosition(compcode);
        }
        int i;
        ListItem li1;

        li1 = new ListItem();
        drppageposition.Items.Clear();
        li1.Text = "Select Page Position";
        li1.Value = "0";
        li1.Selected = true;
        drppageposition.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppageposition.Items.Add(li);


        }

    }
    public void binduom()
    {
        string type = "";
        /*new change ankur 15 feb*/
        if (drpadtype.SelectedValue == "DI0")
        {
            type = "Display";

        }
        else
        {



            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "SP")
            {
                type = "1";
            }
            else
            {
                type = "1";
            }


            
        }

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();

            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), type);
        }

            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();

                ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), type);

            }

        else
        {
            NewAdbooking.classmysql.RateMaster binduom = new NewAdbooking.classmysql.RateMaster();

            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), type);
        }
        drpuom.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select UOM";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        drpuom.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpuom.Items.Add(li);
            }

            if (hiddenuom1.Value != "")
            {
                if (drpuom.Items.FindByValue(hiddenuom1.Value) != null)
                {
                    drpuom.SelectedValue = hiddenuom1.Value;
                }
                else
                {
                    drpuom.SelectedValue = "RO0";
                }
            }
            else
            {
                drpuom.SelectedValue ="0";
            }
        }

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet binduomAjax()
    {
        string type = "";
        type = "1";

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();

            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), type);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();

                ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), type);

            }

            else
            {
                NewAdbooking.classmysql.RateMaster binduom = new NewAdbooking.classmysql.RateMaster();

                ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), type);
            }
        return ds;
        //drpuom.Items.Clear();
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select UOM";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        ////li1.Selected = true;
        //drpuom.Items.Add(li1);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpuom.Items.Add(li);
        //    }

        //    if (hiddenuom1.Value != "")
        //    {
        //        if (drpuom.Items.FindByValue(hiddenuom1.Value) != null)
        //        {
        //            drpuom.SelectedValue = hiddenuom1.Value;
        //        }
        //        else
        //        {
        //            drpuom.SelectedValue = "RO0";
        //        }
        //    }
        //    else
        //    {
        //        drpuom.SelectedValue = "0";
        //    }
        //}

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindpackage_javascript(Boolean chkall1,int no)
    {
        DataSet ds = new DataSet();
     //   drppackage.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            if (chkall1 == false)
            {
                ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0", Session["center"].ToString(),no);
            }
            else
            {
                ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0", "0",no);
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();

            ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0");
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindpackage_category(string compcode,string adtype,string category)
    {
        DataSet ds = new DataSet();
        //   drppackage.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindopackage.bindpackage_category(compcode, adtype, category);
            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
             if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
             {
                 ds = bindopackage.bindpackage_category_DJ(compcode, adtype, category, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
             }
             else{
                  ds = bindopackage.bindpackage_category(compcode, adtype, category);
             }
           
        }
        else
        {
          //  NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();

          //  ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0");
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getCouAmount(string compcode, string center,string coutype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.getCouAmount(compcode, center,coutype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.getCouAmount(compcode, center,coutype);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet chkCoupan(string compcode, string center,string cpnno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.chkCoupan(compcode,center,cpnno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.chkCoupan(compcode, center,cpnno);

        }
        return ds;
    }
    public void bindcoupan()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bindopackage = new NewAdbooking.Classes.adbooking();
            ds = bindopackage.bindcoupan(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindopackage = new NewAdbooking.classesoracle.adbooking();
            ds = bindopackage.bindcoupan(Session["compcode"].ToString(), Session["center"].ToString());
          
        }


        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select CPN";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcoutype.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcoutype.Items.Add(li);
            }

        }
    }
    public void bindpackage()
    {
        DataSet ds = new DataSet();
     //   drppackage.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
            ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bindopackage = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            if (chkall.Checked == false)
            {
                ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0", Session["center"].ToString(),0);
            }
            else
            {
                ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0", "0",0);
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();

            ds = bindopackage.packagebind(Session["compcode"].ToString(), "CL0");
        }
                
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select Package";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //drppackage.Items.Add(li1);

        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
        //        li.Value = ds.Tables[1].Rows[i].ItemArray[2].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drppackage.Items.Add(li);
        //    }

        //}
        ds.Clear();
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        test_grid.DataSource = dv;
        test_grid.DataBind();


    }

    public void bindstyle()
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bindstyle(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster check = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = check.bindstyle(Session["compcode"].ToString());
        }
        else
        {
           // NewAdbooking.classmysql.bulletmaster bindbgcolor = new NewAdbooking.classmysql.bulletmaster();

            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
          //  dsch = bindbgcolor.bindstyle(Session["compcode"].ToString());
        }
        drpstyle.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpstyle.Items.Add(li1);

        if (dsch.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();

                li.Text = dsch.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dsch.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpstyle.Items.Add(li);
            }

        }


    }





    public void bindbullet()
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "1","","");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bgcolorbind_qbc(Session["compcode"].ToString(), "1", Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();

            ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field  
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "1");
        }
        drpbullet.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbullet.Items.Add(li1);

        if (dsch.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();

                li.Text = dsch.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dsch.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpbullet.Items.Add(li);
            }

        }


    }

    public void bindbgcolor()
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0","","");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dsch = bindbgcolor.bgcolorbind_qbc(Session["compcode"].ToString(), "0", Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0");
        }
        
        ///////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field
        

        drpbgcolor.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-None-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbgcolor.Items.Add(li1);

        if (dsch.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();

                li.Text = dsch.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dsch.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpbgcolor.Items.Add(li);
            }

        }


    }
    public void bindcolor()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        drpcolor.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Color";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        drpcolor.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcolor.Items.Add(li);
            }
            drpcolor.SelectedValue = "B";
        }


    }
    public void advcat(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bind.advdatacategory(compcode, "CL0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bind.advdatacategory(compcode, "CL0");
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, "CL0");
        }
        
        

        int i;
        ListItem li1;
        li1 = new ListItem();
        drpadcategory.Items.Clear();
        li1.Text = "Select Ad Category";
        li1.Value = "0";
        li1.Selected = true;
        drpadcategory.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpadcategory.Items.Add(li);

            }
        }


    }




    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public DataSet updatehold(string compcode, string insertstaus, string bookingid, string edition, string date)
    {
        DataSet ds = new DataSet();
      
    
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
              
               
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster save = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = save.updatehold1(compcode, insertstaus, bookingid, edition, date);
                 return ds;
            }
            else
            {
              
               
            }
      

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getadsubcat(string compcode, string adcat)//, string agency)
    {

        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

            da = cls_comb.advdatasubcatcat(compcode, adcat);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //string agencycode = agency.Substring(agency.IndexOf("(") + 1, agency.Length - agency.IndexOf("(") - 2);
            //NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();
            //da = cls_comb.advdatasubcatcatstate(compcode, adcat, agencycode, "agency");
            //return da;
            NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

            da = cls_comb.advdatasubcatcat(compcode, adcat);
            return da;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bindsubcategorysate(string compcode, string adcat, string statecode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

            da = cls_comb.advdatasubcatcat(compcode, adcat);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();

            da = cls_comb.advdatasubcatcatstate(compcode, adcat, statecode, "state");
            return da;
        }
        else
        {
            NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

            da = cls_comb.advdatasubcatcat(compcode, adcat);
            return da;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bindadcat3(string adcat3, string compcode, string value)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            return dacat;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            return dacat;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            return dacat;

        }

    }
    [Ajax.AjaxMethod]
    public DataSet getbullprem(string compcode, string bullcode, string userid, string date, string branch)
    {
        string errormsg = "";
        DataSet dsch = new DataSet();
        //try
        //{
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                dsch = bindbgcolor.bgcolorbind(compcode, bullcode, "", "");
               // return dsch;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                //dsch = bindbgcolor.bgcolorbind_qbc(compcode, bullcode, userid);
                dsch = bindbgcolor.bgcolorbind(compcode, bullcode, "", "");
               // return dsch;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();

                dsch = bindbgcolor.bgcolorbind(compcode, bullcode);
                //return dsch;

            }
        //}
        //catch (Exception e)
        //{
        //   errormsg= e.Message;
        //}

        return dsch;
    }
    [Ajax.AjaxMethod]
    public string bindTable(string pkgname)
    {
        DataSet ds = new DataSet();
        string data = pkgname;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = clsbooking.getPkgDetail(pkgname);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = clsbooking.getPkgDetail(pkgname);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getPkgDetail(pkgname);
        }
        return data;

    }
    [Ajax.AjaxMethod]
    public DataSet bindratecodecenterwise(string adcat, string compcode, string branch, string bookingdate, string dateformat,string uom)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.ratebindcenterwise(adcat, compcode, branch, bookingdate, dateformat,uom);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.ratebindcenterwise(adcat, compcode, branch, bookingdate, dateformat,uom);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        return dx;
    }
    [Ajax.AjaxMethod]
    public DataSet bindratecode(string adcat, string compcode)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
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
    public DataSet bindcatcher(string adcat, string compcode)
    {
        //NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            dx = bindrate.ratebind(adcat, compcode);
        }
        return dx;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getData(string drppackage, string txtinsertion, string txtrepeatingdate, string txtstartdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string insert, string code, string cardrate, string uom, string dealrate, string che_or, string class_insert, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agency)
    {
        string agencycode = "";
        agencycode = HttpContext.Current.Session["agency_name"].ToString();
        if (agencycode != "" && agencycode != "0")
        {
            if (agency.IndexOf("(") >= 0)
            {
                agencycode = agency.Substring(agency.IndexOf("(") + 1, agency.Length - agency.IndexOf("(") - 2);
            }
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();


            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";


            ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";


            ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc, agencycode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";
            ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode);//,uomdesc, agencycode);
        }

        return ds;
    }


  
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [Ajax.AjaxMethod]
    public DataSet getratevalue_forrol_agency(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string noof_insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_line, string dateformat, string flag, string uomdesc, string agencycode)
    {


        DataSet dr = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dr = rate.class_getrate_qbcagency(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, prem, adcat3, adcat4, adcat5, clientname, noof_line, uomdesc, agencycode);

            return dr;
        }


        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dr = rate.class_getrate_qbcagency(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, prem, adcat3, adcat4, adcat5, clientname, noof_line, uomdesc, agencycode, dateformat);

                return dr;

            }
            else
            {
                //string[] arr = null;
                //arr = package.Split("+".ToCharArray());
                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
                //clsbooking.truncateResult();
                //for (int i = 0; i < arr.Length; i++)
                //{
                //    clsbooking.insertResult(arr[i],"0");
                //}

                /*new change ankur*/

                datesavemysql convertmysql = new datesavemysql();
                if (selecdate != "")
                {
                    selecdate = convertmysql.getDate(dateformat, selecdate);
                }
                dr = clsbooking.getpkgrate_agency(package, noof_insert, selecdate, selecdate, dateformat, compcode, adcat, adsucat, color, adtype, currency, ratecode, selecdate, "", package, "", uom, "", "", noof_insert, noof_line, adcat3, adcat4, adcat5, clientname, uomdesc, agencycode);

                return dr;
            }


    }



    /*new change ankur for agency*/
    [Ajax.AjaxMethod]
    public DataSet getData_fill_rate_agency(string drppackage, string txtinsertion, string txtrepeatingdate, string txtstartdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string insert, string code, string cardrate, string uom, string dealrate, string che_or, string class_insert, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agencycode)
    {
        /*new change ankur*/
        datesavemysql convertmysql = new datesavemysql();
        //////////////////////////////


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";


            ds = clsbooking.getInsertion_qbc_agency(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc, agencycode);




            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                if (txtinsertion == "")
                    txtinsertion = "1";
                if (txtrepeatingdate == "")
                    txtrepeatingdate = "";


                ds = clsbooking.getInsertion_qbc_agency(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc, agencycode);




                return ds;
            }
        else
        {



            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

            //string[] arr = null;
            //arr = package.Split("+".ToCharArray());
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //clsbooking.truncateResult();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    clsbooking.insertcodeResult();
            //}

            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";
          
            if (txtstartdate != "")
            {
                txtstartdate = convertmysql.getDate(dateformat, txtstartdate);
            }
            if (clickdate != "")
            {
                clickdate = convertmysql.getDate(dateformat, clickdate);
            }



            ds = clsbooking.getbreakuprate_agency(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc, agencycode);




            return ds;

        }
    }



    [Ajax.AjaxMethod]
    public DataSet getData_fill(string drppackage, string txtinsertion, string txtrepeatingdate, string txtstartdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string insert, string code, string cardrate, string uom, string dealrate, string che_or, string class_insert, string lines, string adcat3, string adcat4, string adcat5, string clientcode,string userid,string center)
    {

        DataSet ds = new DataSet();

        if (txtrepeatingdate == "")
            txtrepeatingdate = "1";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();


            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";


            //ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode);
            ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, userid, center);




            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();



                if (txtinsertion == "" || txtinsertion == null || txtinsertion == "null")
                    txtinsertion = "1";
                if (txtrepeatingdate == "")
                    txtrepeatingdate = "";


                //ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode);
                ds = clsbooking.qbc_getInsertion(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, userid,center);




                return ds;
            }
        else
        {

            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            datesave convertmysql = new datesave();
            
            if (txtstartdate != "")
            {
                txtstartdate = convertmysql.getDate(dateformat, txtstartdate);
            }
            if (clickdate != "")
            {
                clickdate = convertmysql.getDate(dateformat, clickdate);
            }

            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";

            //string[] arr = null;
            //arr = drppackage.Split("+".ToCharArray());
            //clsbooking.truncateResult();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    clsbooking.insertResult(arr[i], drppackage);
            //}
            ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode);




            return ds;
        }
    }

    /*new change ankur 17 feb*/
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]

    public DataSet getData_fill_rate(string drppackage, string txtinsertion, string txtrepeatingdate, string txtstartdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string insert, string code, string cardrate, string uom, string dealrate, string che_or, string class_insert, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agency)
    {
        /*new change ankur*/
        datesavemysql convertmysql = new datesavemysql();


        //////////////////////////////
        string agencycode = "";
        agencycode = HttpContext.Current.Session["agency_name"].ToString();
        if (agencycode != "" && agencycode != "0")
        {
            if (agency.IndexOf("(") >= 0)
            {
                agencycode = agency.Substring(agency.IndexOf("(") + 1, agency.Length - agency.IndexOf("(") - 2);
            }
        }



        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            if (txtinsertion == "")
                txtinsertion = "1";
            if (txtrepeatingdate == "")
                txtrepeatingdate = "";


            ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc);




            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {


                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                if (txtinsertion == "")
                    txtinsertion = "1";
                if (txtrepeatingdate == "")
                    txtrepeatingdate = "";


                ds = clsbooking.getInsertion_qbc(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc, agencycode);




                return ds;
            }
            else
            {



                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();


                //string[] arr = null;
                //arr = package.Split("+".ToCharArray());
                //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
                //clsbooking.truncateResult();
                //for (int i = 0; i < arr.Length; i++)
                //{
                //    clsbooking.insertcodeResult();
                //}

                if (txtinsertion == "")
                    txtinsertion = "1";
                if (txtrepeatingdate == "")
                    txtrepeatingdate = "";

                if (txtstartdate != "")
                {
                    txtstartdate = convertmysql.getDate(dateformat, txtstartdate);
                }
                if (clickdate != "")
                {
                    clickdate = convertmysql.getDate(dateformat, clickdate);
                }



                ds = clsbooking.getbreakuprate(drppackage, txtinsertion, txtrepeatingdate, txtstartdate, dateformat, compcode, adcategory, adsubcat, color, adtype, currency, ratecode, clickdate, insert, code, cardrate, uom, dealrate, che_or, class_insert, lines, adcat3, adcat4, adcat5, clientcode, uomdesc);




                return ds;

            }
    }




    /*change ankur 17 feb*/
    [Ajax.AjaxMethod]
    public DataSet getratevalue_forrol(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string noof_insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_line, string dateformat, string flag, string uomdesc)
    {


        DataSet dr = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dr = rate.class_getrate_qbc(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, prem, adcat3, adcat4, adcat5, clientname, noof_line, uomdesc);

            return dr;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dr = rate.class_getrate_qbc(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, prem, adcat3, adcat4, adcat5, clientname, noof_line, uomdesc, dateformat);

                return dr;
            }
            else
            {

                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();


                datesavemysql convertmysql = new datesavemysql();
                if (selecdate != "")
                {
                    selecdate = convertmysql.getDate(dateformat, selecdate);
                }
                dr = clsbooking.getpkgrate(package, noof_insert, selecdate, selecdate, dateformat, compcode, adcat, adsucat, color, adtype, currency, ratecode, selecdate, "", package, "", uom, "", "", noof_insert, noof_line, adcat3, adcat4, adcat5, clientname, uomdesc);

                return dr;
            }


    }

    [Ajax.AjaxMethod]
    /*new change ankur 23 feb*/
    public DataSet modifygridinsert(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string filename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string insertinsertion, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid, string splboldsizevalue, string vat_p, string vat_inc_p, string subedidata, string clicatamt, string flatfreqamt, string catamt, string cashamt, string eyecather, string dayprim, string gstamount, string gstgrid)
    {
        DataSet dii = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            NewAdbooking.Classes.adbooking insertchild = new NewAdbooking.Classes.adbooking();
            // dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias,"","","","","","","","","");
            dii = insertchild.insertbook_ins_display(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, insertid, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias, "", "", "", "", "", "", "", "", "", splboldsizevalue, vat_p, "", vat_inc_p, grossrate, billamt, "", "", "", "", "", subedidata, "", modifyrateaudit, ip, "", "", "", cashamt, "", "", "", clicatamt, flatfreqamt, catamt,"",gstamount,gstgrid);

            return dii;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

               // FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();

                dii = insertchild.insertbook_ins_update(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias, insertid, "", "", "", "", "", "", "", "", "", splboldsizevalue, vat_p, "", vat_inc_p, grossrate, billamt, "", "", "", subedidata, "", modifyrateaudit, ip, "", "", "", cashamt, "", "", "", clicatamt, flatfreqamt, catamt, eyecather, dayprim, gstamount, gstgrid);

                return dii;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();

                dii = insertchild.insertbook_ins_update(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias, insertid);

                return dii;
            }


    }
    [Ajax.AjaxMethod]
    public DataSet getpageamount(string pagecode, string compcode)
    {
        DataSet damt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
         
            damt = getamt.getpageamt(pagecode, compcode);
            return damt;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getamt = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            damt = getamt.getpageamt(pagecode, compcode);
            return damt;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getamt = new NewAdbooking.classmysql.BookingMaster();

            damt = getamt.getpageamt(pagecode, compcode);
            return damt;
        }


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getboxnovalue(string compcode, string boxno, string no,string autono)
    {
        //string auto = "BN";
        //string autogen = auto + cou;
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
           
            da = autocode.autogenrated(compcode, boxno, no);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            string center = HttpContext.Current.Session["center"].ToString();
            string agncodesubcode = HttpContext.Current.Session["agency_name"].ToString();
            da = autocode.autogenratedbox(compcode, boxno, no, center, agncodesubcode, Session["revenue"].ToString(), autono);
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();
            string center = HttpContext.Current.Session["center"].ToString();
            string agncodesubcode = HttpContext.Current.Session["agency_name"].ToString();
            da = autocode.autogenratedbox(compcode, boxno, no, center, agncodesubcode);

        }


        return da;

    }

    [Ajax.AjaxMethod]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            
            ds = clsbooking.getClientName(compcode, client);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {

                ds = clsbooking.getClientName_DJ(compcode, client, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString());
            }
            else
            {
                ds = clsbooking.getClientName(compcode, client, "0");
            }
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

            ds = clsbooking.getClientName(compcode, client);
            return ds;
        }
    }
    ///this the function to insert the records in insert table
   
   
    //this is to show the grid for execution
    [Ajax.AjaxMethod]

    public string insertinsertion(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string filename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string insertinsertion, string solorate, string grossrate, string insert, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string splitdata, string subedidata, string splboldsizevalue, string vat_p, string vat_inc_p, string clicatamt, string flatfreqamt, string catamt, string cashammt, string extra, string eyecath, string daywiseprem, string gstamount, string gstgrid)
    {
        string err = "";
        try
        {
            DataSet dii = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                NewAdbooking.Classes.adbooking insertchild = new NewAdbooking.Classes.adbooking();
                dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias, "", "", "", "", "", "", "", "", "", splitdata, subedidata, splboldsizevalue, vat_p, "", vat_inc_p, grossrate, billamt, "", "", "", "", "", "", "", "", "", cashammt, "", "", "", clicatamt, flatfreqamt, catamt,"",gstamount,gstgrid);            
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    // FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    //dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, Session["dateformat"].ToString());

                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();

                    err = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias, "", "", "", "", "", "", "", "", "", splitdata, subedidata, splboldsizevalue, vat_p, "", vat_inc_p, grossrate, billamt, "", "", "", "", "", "", "", "", "", cashammt, "", "", "", clicatamt, flatfreqamt, catamt, "", eyecath, daywiseprem, gstamount, gstgrid);


                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster insertchild = new NewAdbooking.classmysql.BookingMaster();

                    dii = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt, billrate, logo_h, logo_w, logo_name, dateformat, adcat3, adcat4, adcat5, pkgcode, gridins, pkgalias);

                }

        }
        catch (Exception e)
        {
            err = e.Message;

        }
        string data = "insertdate:" + insertdate + "edition:" + edition + "premium1:" + premium1 + "premium2:" + premium2 + "premallow:" + premallow + "adcategory:" + adcategory + "latestdate:" + latestdate + "material:" + material + "cardrate:" + cardrate + "filename:" + filename + "discrate:" + discrate + "insertstatus:" + insertstatus + "billstatus:" + billstatus + "adsubcat:" + adsubcat + "compcode:" + compcode + "userid:" + userid + "cioid:" + cioid + "height:" + height + "width:" + width + "totalsize:" + totalsize + "pagepost:" + pagepost + "premper1:" + premper1 + "premper2:" + premper2 + "colid:" + colid + "repeat:" + repeat + "insertno:" + insertno + "paid:" + paid + "insertinsertion:" + insertinsertion + "solorate:" + solorate + "grossrate:" + grossrate + "insert_pageno:" + insert_pageno + "insert_remarks:" + insert_remarks + "page_code:" + page_code + "page_per:" + page_per + "noofcol:" + noofcol + "billamt:" + billamt + "billrate:" + billrate + "logo_h:" + logo_h + "logo_w:" + logo_w + "logo_name:" + logo_name + "dateformat:" + dateformat + "0" + "0" + "0" + "pkgcode:" + pkgcode + "gridins:" + gridins + "pkgalias:" + pkgalias;
        if (err != "")
            err = err + " ERROR: " + data;
        string adcatcode2 = "Save QBC " + cioid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new(DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + userid + "','QBC','" + err.Replace("'", "''") + "','Ad Booking Saved','" + adcatcode2;
        sqldd = sqldd + "',";
        string serverip = "";
        sqldd = sqldd + "'" + serverip + "')";
        dconnect.executenonquery1(sqldd);
        return err;
    }
    [Ajax.AjaxMethod]
    public int getEditionCount(string compcode, string pkgcode, string edition)
    {
        DataSet dex = new DataSet();
        int i = 1;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            dex = showgri.getEditionCount_bullet(compcode, pkgcode, edition);
        }
        if (dex.Tables.Count > 0 && dex.Tables[0].Rows.Count > 0)
        {
            i = Convert.ToInt32(dex.Tables[0].Rows[0].ItemArray[0].ToString());
        }
        return i;
    }
    [Ajax.AjaxMethod]
    public void rollback(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            insertchild.rollbackT(cioid);
        }
    }
      [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string commit(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string adtype, string paymentflag)
    {
        string error = "";
        string updatebooking = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, adtype,"");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insertchild = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            error = insertchild.commitT(count, cioid, pcompcode, pcentname, puserid, pbkid_gentype, adtype,"");
        }
        Session["sesbooking"] = error.Split('~')[1].Remove(0, 1);
        if (paymentflag == "depo")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
                updatebooking = insertchild.updatepayment(pcompcode, Session["sesbooking"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster insertchild = new NewAdbooking.Classes.BookingMaster();
                updatebooking = insertchild.updatepayment(pcompcode, Session["sesbooking"].ToString());
            }
        }
        return error;
    }
    [Ajax.AjaxMethod]
    public DataSet showgridforexe(string ciobid, string compcode)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dex = showgri.fetchdataforexe(ciobid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

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
    public DataSet chkcasualcli(string client, string compcode)
    {
        DataSet dc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkcli = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            
            dc = chkcli.chkclient(client, compcode);
            return dc;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkcli = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            dc = chkcli.chkclient(client, compcode);
            return dc;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster chkcli = new NewAdbooking.classmysql.BookingMaster();

            dc = chkcli.chkclient(client, compcode);
            return dc;

        }

    }

    [Ajax.AjaxMethod]
    public DataSet getwidthforcoll(string desc, string collumn,string compcode)
    {
        DataSet dc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getwidth = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
           /* change */
            //dc = getwidth.getwidthforcollumn(desc, collumn, compcode);
            dc = getwidth.getwidthforcollumn_qbc(desc, collumn, compcode);
            return dc;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getwidth = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            /* change */
            //dc = getwidth.getwidthforcollumn(desc, collumn, compcode);
            dc = getwidth.getwidthforcollumn_qbc(desc, collumn, compcode);
            return dc;
        }
        else
        {
            //string[] arr = null;
            //arr = drppackage.Split("+".ToCharArray());
            //clsbooking.truncateResult();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    clsbooking.insertResult(arr[i]);
            //}

       
            NewAdbooking.classmysql.BookingMaster getwidth = new NewAdbooking.classmysql.BookingMaster();
            /*change*/
           // dc = getwidth.getwidthforcollumn(desc, collumn, compcode);
            dc = getwidth.getwidthforcollumn_qbc(desc, collumn, compcode);
            return dc;
        }

    }
    [Ajax.AjaxMethod]
    public DataSet binddealtype(string compcode, string agencysplit, string subagency, string bookingdate, string color, string curr, string adcat, string clientsplit, string prod, string col, string code, string rate_cod, string adtype,string dateformat)
    {

        DataSet ddeal = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdeal = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype, dateformat,"","");
            return ddeal;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdeal = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype,dateformat,"","");
            return ddeal;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getdeal = new NewAdbooking.classmysql.BookingMaster();

            ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype);
            return ddeal;

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
        

        string id = butt.Tables[0].Rows[0].ItemArray[0].ToString();
        hiddenbuttonidcheck.Value = id;
        hiddenroperm.Value = butt.Tables[2].Rows[0].ItemArray[0].ToString();


        if (id != "0")
        {
            


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
                btnSaveConfirm.Enabled = false;
                btnModify.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                btnlast.Enabled = false;



               

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
                btnSaveConfirm.Enabled = false;
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
                btnModify.Enabled = false;

                btnSave.Enabled = false;
                btnSaveConfirm.Enabled = false;
                btnfirst.Enabled = false;
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
                btnSaveConfirm.Enabled = false;
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
                btnSaveConfirm.Enabled = false;
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
                btnSaveConfirm.Enabled = false;
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
                btnSaveConfirm.Enabled = false;
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
                btnSaveConfirm.Enabled = false;
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

    public void chkstatus(int FlagStatus)
    {
        if (FlagStatus == 0 || FlagStatus == 8)
        {
            btnNew.Enabled = false;
            btnQuery.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = true;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = true;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = true;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = false;
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
            btnSaveConfirm.Enabled = false;
            btnQuery.Enabled = true;
            btnModify.Enabled = true;
            btnfirst.Enabled = true;
            btnnext.Enabled = true;
            btnprevious.Enabled = true;
            btnlast.Enabled = true;

        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {

        //if (Session["compcode"] == null)
        //{
        //    //Response.Redirect("login.aspx");
        //    //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
        //    string sessionout = "Your Session Has Been Expired";
        //    AspNetMessageBox_close(sessionout);
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

        //    return;

        //}
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz6", "document.getElementById('tblinsert').innerHTML=''", true);
        //int count = executequery.Tables[0].Rows.Count - 1;
        //dateinsert getdatechk = new dateinsert();
        //fpnl++;

        //if (fpnl != -1 && fpnl >= 0)
        //{
        //    if (fpnl <= count)
        //    {
        //        txtbranch.Text = executequery.Tables[0].Rows[fpnl].ItemArray[1].ToString();
        //        txtbookedby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[2].ToString();
        //        txtprevbook.Text = executequery.Tables[0].Rows[fpnl].ItemArray[4].ToString();
        //        string datetime = executequery.Tables[0].Rows[fpnl].ItemArray[0].ToString();
        //        txtdatetime.Text = getdatechk.getDate(dateformat, datetime);
        //        txtciobookid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[3].ToString();
        //        hiddencioid.Value = txtciobookid.Text;
        //        //txtappby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[5].ToString();
        //        // txtaudit.Text = executequery.Tables[0].Rows[fpnl].ItemArray[6].ToString();
        //        txtrono.Text = executequery.Tables[0].Rows[fpnl].ItemArray[7].ToString();
        //        string ro_date = executequery.Tables[0].Rows[fpnl].ItemArray[8].ToString();
        //        //txtrodate.Text = getdatechk.getDate(dateformat, ro_date);

        //        if (ro_date == "1900/1/1" || ro_date == "1900/01/01" || ro_date == "" || ro_date == "01/01/1900" || ro_date == "1/1/1900" || ro_date == null)
        //        {
        //            txtrodate.Text = "";
        //        }
        //        else
        //        {
        //            txtrodate.Text = getdatechk.getDate(dateformat, ro_date);
        //        }

        //        if (executequery.Tables[0].Rows[0].ItemArray[11].ToString() == null || executequery.Tables[0].Rows[0].ItemArray[11].ToString() == "")
        //        {
        //            drprostatus.SelectedValue = "0";
        //        }
        //        else
        //        {
        //            drprostatus.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[11].ToString();
        //        }


        //        txtagency.Text = executequery.Tables[0].Rows[fpnl].ItemArray[89].ToString();


        //        //2april
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == "" || (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString()))
        //        {
        //            txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();
        //        }
        //        else
        //        {

        //            txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() + "(" + executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString() + ")";
        //        }

        //        //2april

        //        //txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();

        //        txtclientadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[15].ToString();

        //        txtprintremark.Text = executequery.Tables[0].Rows[fpnl].ItemArray[24].ToString();
        //        string listpck = executequery.Tables[0].Rows[fpnl].ItemArray[25].ToString();
        //        hiddenpackage.Value = listpck;

        //        DataSet dsexecut = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //            dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);
        //        }

        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();

        //                dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //            }


        //        int i;




        //        drppackagecopy.Items.Clear();
        //        for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        //        {
        //            if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //            {
        //                if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        //                {

        //                    ListItem li;
        //                    li = new ListItem();
        //                    li.Text = dsexecut.Tables[0].Rows[i].ItemArray[1].ToString();
        //                    li.Value = dsexecut.Tables[0].Rows[i].ItemArray[2].ToString();
        //                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                    drppackagecopy.Items.Add(li);

        //                    arrfor_uom = li.Value.Split('@');
        //                    /*new change ankur 27 feb*/
        //                    foruom_temp = arrfor_uom[1];
        //                    if (for_uom == "")
        //                    {
        //                        for_uom = foruom_temp;
        //                    }
        //                    else
        //                    {
        //                        for_uom = for_uom + "+" + foruom_temp;

        //                    }

        //                }
        //            }
        //        }





        //        txtinsertion.Text = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //        hiddeninsertion.Value = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //        string start_date = executequery.Tables[0].Rows[fpnl].ItemArray[27].ToString();
        //        txtdummydate.Text = getdatechk.getDate(dateformat, start_date);
        //        txtrepeatingdate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[28].ToString();

        //        /*new change ankur 15 feb*/
        //        advcat(Session["compcode"].ToString());
        //        binduom();

        //        if (drpadcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString()) != null)
        //        {
        //            hiddencatcode.Value = drpadcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString();
        //        }
        //        else
        //        {
        //            hiddencatcode.Value = drpadcategory.SelectedValue = "0";
        //        }
        //        ///////////////////////

        //        /*change ankur*/
        //        DataSet dscat = new DataSet();
        //        if (executequery.Tables[0].Rows[0].ItemArray[31].ToString() == "")
        //        {
        //            drpadsubcategory.Items.Clear();
        //            hiddenad_subcat.Value = "";

        //        }
        //        else
        //        {
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

        //                dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();

        //                    dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

        //                    dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //                }


        //            drpadsubcategory.Items.Clear();
        //            ListItem likasu;
        //            likasu = new ListItem();
        //            likasu.Text = "Select";
        //            likasu.Value = "0";
        //            drpadsubcategory.Items.Add(likasu);
        //            for (int k = 0; k < dscat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem liocat;
        //                liocat = new ListItem();
        //                liocat.Text = dscat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                liocat.Value = dscat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadsubcategory.Items.Add(liocat);
        //            }
        //        }


        //        ////////////////////////////////////////////////////////////////
        //        if (drpadsubcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString()) != null)
        //        {
        //            drpadsubcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString();
        //        }
        //        else
        //        {
        //            drpadsubcategory.SelectedValue = "0";
        //        }

        //        drpcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[32].ToString();

        //        /*new change ankur 27 feb*/
        //        DataSet ds_edituom = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {

        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //            ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());
        //        }
        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //                ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster binduom_ = new NewAdbooking.classmysql.BookingMaster();
        //                ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //            }

        //        drpuom.Items.Clear();

        //        drpuom.Items.Clear();
        //        ListItem likasu2;
        //        likasu2 = new ListItem();
        //        likasu2.Text = "Select";
        //        likasu2.Value = "0";
        //        drpuom.Items.Add(likasu2);

        //        for (int k = 0; k < ds_edituom.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem liocat2;
        //            liocat2 = new ListItem();
        //            liocat2.Text = ds_edituom.Tables[0].Rows[k].ItemArray[1].ToString();
        //            liocat2.Value = ds_edituom.Tables[0].Rows[k].ItemArray[0].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpuom.Items.Add(liocat2);
        //        }


        //        for_uom = "";
        //        foruom_temp = "";

        //        ///////////////////

        //        /*new change ankur 15 feb*/
        //        if (drpuom.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[33].ToString()) != null)
        //        {
        //            hiddenuomcode.Value = drpuom.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[33].ToString();
        //        }
        //        ////////////

        //        drppageposition.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[34].ToString();

        //        //string adtype=drpadstype.SelectedValue;
        //        txtadsize1.Text = executequery.Tables[0].Rows[fpnl].ItemArray[38].ToString();
        //        txtadsize2.Text = executequery.Tables[0].Rows[fpnl].ItemArray[39].ToString();

        //        txttotalarea.Text = executequery.Tables[0].Rows[fpnl].ItemArray[54].ToString();
        //        txtcardrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[55].ToString();

        //        txtgrossamt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();
        //        hiddenprevamt.Value = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();
        //        if (drpboxcodenew.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString()) != null)
        //        {
        //            drpboxcodenew.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //        }
        //        else
        //        {
        //            drpboxcodenew.SelectedValue = "0";
        //        }

        //        txtboxnonew.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();
        //        txtboxadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[81].ToString();
        //        txtboxchrg.Text = executequery.Tables[0].Rows[fpnl].ItemArray[132].ToString();

        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString() != null)
        //        {
        //            txtsapid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString();
        //        }
        //        else
        //        {
        //            txtsapid.Text = "";
        //        }
        //        //   drpboxcode.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //        // txtboxno.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();

        //        txtcolum.Text = executequery.Tables[0].Rows[fpnl].ItemArray[84].ToString();

        //        txtpaid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[92].ToString();
        //        txtdealrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[93].ToString();


        //        txtcontractname.Text = executequery.Tables[0].Rows[fpnl].ItemArray[96].ToString();
        //        if (txtcontractname.Text == "")
        //        {
        //            chkcontract.Checked = false;

        //        }
        //        else
        //        {
        //            chkcontract.Checked = true;
        //        }

        //        hiddenreceiptno.Value = txtreceipt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[103].ToString();

        //        ////this is to bind the adscat3 drpdown



        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString() == "")
        //        {
        //            drpadcat3.Items.Clear();
        //            hiddenadscat3.Value = "";

        //        }
        //        else
        //        {
        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //            }

        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat3.Items.Clear();
        //            ListItem lika;
        //            lika = new ListItem();
        //            lika.Text = "Select";
        //            lika.Value = "0";
        //            drpadcat3.Items.Add(lika);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat3.Items.Add(lio);
        //            }


        //        }

        //        if (drpadcat3.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString()) != null)
        //        {
        //            hiddenadscat3.Value = drpadcat3.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString();
        //        }
        //        else
        //        {
        //            hiddenadscat3.Value = drpadcat3.SelectedValue = "0";
        //        }
        //        ////////////////////this is to bind the adcat4 drp down
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString() == "")
        //        {
        //            drpadcat4.Items.Clear();
        //            hiddenadscat4.Value = "";

        //        }
        //        else
        //        {
        //            ////////////when 1 than bind the adscat4 drp down
        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");
        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");



        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat4.Items.Clear();
        //            ListItem liks;
        //            liks = new ListItem();
        //            liks.Text = "Select";
        //            liks.Value = "0";
        //            drpadcat4.Items.Add(liks);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat4.Items.Add(lio);
        //            }

        //        }

        //        if (drpadcat4.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString()) != null)
        //        {
        //            hiddenadscat4.Value = drpadcat4.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString();
        //        }
        //        else
        //        {
        //            hiddenadscat4.Value = drpadcat4.SelectedValue = "0";
        //        }

        //        ///bind adcat5 drpdown
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString() == "")
        //        {
        //            drpadcat5.Items.Clear();
        //            hiddenadscat5.Value = "";
        //        }
        //        else
        //        {
        //            ////////////when 1 than bind the adscat4 drp down
        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 2 than bind adcat2 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 2 than bind adcat2 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 2 than bind adcat2 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");


        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat5.Items.Clear();
        //            ListItem liks;
        //            liks = new ListItem();
        //            liks.Text = "Select";
        //            liks.Value = "0";
        //            drpadcat5.Items.Add(liks);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat5.Items.Add(lio);
        //            }
        //        }

        //        if (drpadcat5.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString()) != null)
        //        {
        //            hiddenadscat5.Value = drpadcat5.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString();
        //        }
        //        else
        //        {
        //            hiddenadscat5.Value = drpadcat5.SelectedValue = "0";
        //        }


        //        //////bind the bg color drp down 

        //        /*new change ankur 15 feb*/
        //        string combin_name = "";
        //        //drpcolortype.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[124].ToString();
        //        if (Session["bg_colorpub"].ToString() == "yes")
        //        {
        //            ////this is to get the combin_desc
        //            for (int z = 0; z < drppackagecopy.Items.Count; z++)
        //            {
        //                string[] arr = drppackagecopy.Items[z].Value.Split('@');

        //                if (combin_name != "")
        //                {
        //                    combin_name = combin_name + "+" + arr[1];
        //                }
        //                else
        //                {
        //                    combin_name = arr[1];
        //                }

        //            }
        //            DataSet dsget = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //                dsget = bind.bindbgandfont(drpadcategory.SelectedValue, combin_name);
        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //                    dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
        //                    dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);
        //                }
        //            //////bind colortype

        //            drpcolortype.Items.Clear();
        //            ListItem colty;
        //            colty = new ListItem();
        //            colty.Text = "Select Color type";
        //            colty.Value = "0";
        //            drpcolortype.Items.Add(colty);
        //            for (int k = 0; k < dsget.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem col1;
        //                col1 = new ListItem();
        //                col1.Text = dsget.Tables[0].Rows[k].ItemArray[1].ToString();
        //                col1.Value = dsget.Tables[0].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpcolortype.Items.Add(col1);
        //            }
        //            /*new change ankur 10 feb*/
        //            if (executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString() != "")
        //            {
        //                drpcolortype.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString();
        //            }
        //            else
        //            {
        //                drpcolortype.Items.Clear();
        //            }

        //            /////bind bg color



        //            drpbgcolor.Items.Clear();
        //            ListItem liksabg;
        //            liksabg = new ListItem();
        //            liksabg.Text = "Select Bg color";
        //            liksabg.Value = "0";
        //            drpbgcolor.Items.Add(liksabg);
        //            for (int k = 0; k < dsget.Tables[1].Rows.Count; k++)
        //            {
        //                ListItem liobg;
        //                liobg = new ListItem();
        //                liobg.Text = dsget.Tables[1].Rows[k].ItemArray[1].ToString();
        //                liobg.Value = dsget.Tables[1].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpbgcolor.Items.Add(liobg);
        //            }
        //            /*new change ankur 10 feb*/
        //            if (executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString() != "")
        //            {
        //                drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //            }
        //            else
        //            {
        //                drpbgcolor.Items.Clear();
        //            }


        //            ////bind bullet


        //            drpbullet.Items.Clear();
        //            ListItem bul;
        //            bul = new ListItem();
        //            bul.Text = "Select Bg color";
        //            bul.Value = "0";
        //            drpbullet.Items.Add(bul);
        //            for (int k = 0; k < dsget.Tables[2].Rows.Count; k++)
        //            {
        //                ListItem bul1;
        //                bul1 = new ListItem();
        //                bul1.Text = dsget.Tables[2].Rows[k].ItemArray[1].ToString();
        //                bul1.Value = dsget.Tables[2].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpbullet.Items.Add(bul1);
        //            }
        //            /*new change ankur 10 feb*/
        //            if (executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString() != "")
        //            {
        //                drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //            }
        //            else
        //            {
        //                drpbullet.Items.Clear();
        //            }

        //        }
        //        else
        //        {
        //            if (drpbgcolor.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString()) != null)
        //            {
        //                drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //            }
        //            if (drpbullet.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString()) != null)
        //            {
        //                drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //            }
        //        }
        //        hiddencolortype.Value = drpcolortype.SelectedValue;
        //        hiddenbgcolor.Value = drpbgcolor.SelectedValue;
        //        hiddenbullet.Value = drpbullet.SelectedValue;
        //        ////////////////////////////////////////////////////////////////

        //        drpmatstat.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[120].ToString();
        //        txtreceiptdate.Text = getdatechk.getDate(dateformat, executequery.Tables[0].Rows[fpnl].ItemArray[121].ToString());
        //        /*   change  */
        //        drpregion.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[122].ToString();
        //        drpvarient.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[123].ToString();



        //        /*change ankur*/
        //        ///////this is to bind the bill to dropdown as agency and client////////
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            bindagencybillto(ds_billto);
        //        }
        //        else
        //        {
        //            bindagencybillto(ds_billto);
        //        }
        //        if (drpbillto_qbc.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString()) != null)
        //        {
        //            drpbillto_qbc.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString();
        //        }
        //        ///////////////////////////////////////////////////////////////////////////
        //        hiddenbillto.Value = drpbillto_qbc.SelectedValue;


        //        /*new change 15 feb*/

        //        bindpackage();


        //        ///
        //        hiddenuomdesc.Value = executequery.Tables[0].Rows[fpnl].ItemArray[125].ToString();

        //        /*new change ankur 24 feb*/
        //        hiddenlogomatter.Value = executequery.Tables[0].Rows[fpnl].ItemArray[126].ToString();
        //        txtlogohei.Text = executequery.Tables[0].Rows[fpnl].ItemArray[127].ToString();
        //        txtlogowid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[128].ToString();
        //        drplogocolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[129].ToString();
        //        txtlogouomcode.Text = executequery.Tables[0].Rows[fpnl].ItemArray[130].ToString();
        //        hiddenlogocode.Value = executequery.Tables[0].Rows[fpnl].ItemArray[131].ToString();
        //        ////////////////////////////

        //        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "ca", "showcardinfo('" + executequery.Tables[0].Rows[0].ItemArray[61].ToString() + "')", true);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "cc", "showgridexecute()", true);
        //        updateStatus();
        //        btnfirst.Enabled = true;
        //        btnprevious.Enabled = true;
        //    }
        //    else
        //    {
        //        btnnext.Enabled = false;
        //        btnlast.Enabled = false;
        //        btnfirst.Enabled = true;
        //        btnprevious.Enabled = true;

        //    }
        //}
        //else
        //{
        //    btnnext.Enabled = false;
        //    btnlast.Enabled = false;
        //    btnfirst.Enabled = true;
        //    btnprevious.Enabled = true;

        //}
        //if (hiddenuomdesc.Value == "CD")
        //{
        //    if (txtadsize1.Text != "" && txtcolum.Text != "")
        //    {
        //        txtadsize2.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }
        //    else if (txtadsize1.Text != "" && txtadsize2.Text != "")
        //    {
        //        txtcolum.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }


        //}
        //else if (hiddenuomdesc.Value != "CD")
        //{
        //    txtadsize1.Enabled = false;
        //    txtadsize2.Enabled = false;
        //    if (hiddenuomdesc.Value == "ROL" || hiddenuomdesc.Value == "ROD")
        //    {
        //        Label1.Text = "No. Of Lines";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;


        //    }
        //    else if (hiddenuomdesc.Value == "ROW")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }
        //    else if (hiddenuomdesc.Value == "ROC")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }

        //}
        //if (confirm_Permission == "1" && drprostatus.SelectedValue == "2")
        //{

        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj21", "document.getElementById('btnconfirm').disabled=false;", true);
        //}
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        //if (Session["compcode"] == null)
        //{
        //    //Response.Redirect("login.aspx");
        //    //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
        //    string sessionout = "Your Session Has Been Expired";
        //    AspNetMessageBox_close(sessionout);
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

        //    return;

        //}
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz5", "document.getElementById('tblinsert').innerHTML=''", true);

        //int count = executequery.Tables[0].Rows.Count - 1;

        //dateinsert getdatechk = new dateinsert();

        //fpnl--;

        //if (fpnl != -1)
        //{
        //    if (fpnl >= 0 || fpnl <= count)
        //    {

        //        txtbranch.Text = executequery.Tables[0].Rows[fpnl].ItemArray[1].ToString();
        //        txtbookedby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[2].ToString();
        //        txtprevbook.Text = executequery.Tables[0].Rows[fpnl].ItemArray[4].ToString();
        //        string datetime = executequery.Tables[0].Rows[fpnl].ItemArray[0].ToString();
        //        txtdatetime.Text = getdatechk.getDate(dateformat, datetime);
        //        txtciobookid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[3].ToString();
        //        hiddencioid.Value = txtciobookid.Text;
        //        //txtappby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[5].ToString();
        //        // txtaudit.Text = executequery.Tables[0].Rows[fpnl].ItemArray[6].ToString();
        //        txtrono.Text = executequery.Tables[0].Rows[fpnl].ItemArray[7].ToString();
        //        string ro_date = executequery.Tables[0].Rows[fpnl].ItemArray[8].ToString();
        //        //txtrodate.Text = getdatechk.getDate(dateformat, ro_date);

        //        if (ro_date == "1900/1/1" || ro_date == "1900/01/01" || ro_date == "" || ro_date == "01/01/1900" || ro_date == "1/1/1900" || ro_date == null)
        //        {
        //            txtrodate.Text = "";
        //        }
        //        else
        //        {
        //            txtrodate.Text = getdatechk.getDate(dateformat, ro_date);
        //        }


        //        if (executequery.Tables[0].Rows[0].ItemArray[11].ToString() == null || executequery.Tables[0].Rows[0].ItemArray[11].ToString() == "")
        //        {
        //            drprostatus.SelectedValue = "0";
        //        }
        //        else
        //        {
        //            drprostatus.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[11].ToString();
        //        }


        //        txtagency.Text = executequery.Tables[0].Rows[fpnl].ItemArray[89].ToString();
        //        //drpagency_SelectedIndexChanged(sender, e);



        //        //////////////////////////////////////////////////////
        //        //2april
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == "" || (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString()))
        //        {
        //            txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();
        //        }
        //        else
        //        {

        //            txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() + "(" + executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString() + ")";
        //        }
        //        //2april
        //        //txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();

        //        txtclientadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[15].ToString();

        //        txtprintremark.Text = executequery.Tables[0].Rows[fpnl].ItemArray[24].ToString();
        //        string listpck = executequery.Tables[0].Rows[fpnl].ItemArray[25].ToString();
        //        hiddenpackage.Value = listpck;
        //        //////////////////this is to bind the package grid on what the value is saved in the database


        //        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "c1", "bindgridpkg('" + listpck + "')", true);
        //        DataSet dsexecut = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //            dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);
        //        }
        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();

        //                dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //            }


        //        int i;


        //        //for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        //        //{
        //        //    if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //        //    {
        //        //        if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        //        //        {

        //        //            drppackage.Items.FindByValue(dsexecut.Tables[0].Rows[i].ItemArray[2].ToString()).Selected = true;
        //        //            drppackage.Items.FindByValue("0").Selected = false;

        //        //        }
        //        //    }
        //        //}
        //        drppackagecopy.Items.Clear();
        //        for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        //        {
        //            if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //            {
        //                if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        //                {

        //                    ListItem li;
        //                    li = new ListItem();
        //                    li.Text = dsexecut.Tables[0].Rows[i].ItemArray[1].ToString();
        //                    li.Value = dsexecut.Tables[0].Rows[i].ItemArray[2].ToString();
        //                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                    drppackagecopy.Items.Add(li);
        //                    arrfor_uom = li.Value.Split('@');
        //                    /*new change ankur 27 feb*/
        //                    foruom_temp = arrfor_uom[1];
        //                    if (for_uom == "")
        //                    {
        //                        for_uom = foruom_temp;
        //                    }
        //                    else
        //                    {
        //                        for_uom = for_uom + "+" + foruom_temp;

        //                    }

        //                }
        //            }
        //        }






        //        txtinsertion.Text = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //        hiddeninsertion.Value = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //        string start_date = executequery.Tables[0].Rows[fpnl].ItemArray[27].ToString();
        //        txtdummydate.Text = getdatechk.getDate(dateformat, start_date);
        //        txtrepeatingdate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[28].ToString();

        //        /*new change ankur 15 feb*/
        //        advcat(Session["compcode"].ToString());
        //        binduom();

        //        if (drpadcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString()) != null)
        //        {
        //            hiddencatcode.Value = drpadcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString();
        //        }
        //        else
        //        {
        //            hiddencatcode.Value = drpadcategory.SelectedValue = "0";
        //        }
        //        ///////////////////////

        //        /*change ankur*/
        //        DataSet dscat = new DataSet();
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString() == "")
        //        {
        //            drpadsubcategory.Items.Clear();
        //            hiddenad_subcat.Value = "";

        //        }
        //        else
        //        {
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

        //                dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();

        //                    dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

        //                    dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //                }


        //            drpadsubcategory.Items.Clear();
        //            ListItem likasu;
        //            likasu = new ListItem();
        //            likasu.Text = "Select";
        //            likasu.Value = "0";
        //            drpadsubcategory.Items.Add(likasu);
        //            for (int k = 0; k < dscat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem liocat;
        //                liocat = new ListItem();
        //                liocat.Text = dscat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                liocat.Value = dscat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadsubcategory.Items.Add(liocat);
        //            }
        //        }


        //        ////////////////////////////////////////////////////////////////
        //        if (drpadsubcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString()) != null)
        //        {
        //            drpadsubcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString();
        //        }
        //        else
        //        {
        //            drpadsubcategory.SelectedValue = "0";
        //        }
        //        drpcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[32].ToString();

        //        /*new change ankur 27 feb*/
        //        DataSet ds_edituom = new DataSet();

        //        //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //        //ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {

        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //            ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());
        //        }
        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //                ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster binduom_ = new NewAdbooking.classmysql.BookingMaster();
        //                ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //            }

        //        drpuom.Items.Clear();

        //        drpuom.Items.Clear();
        //        ListItem likasu2;
        //        likasu2 = new ListItem();
        //        likasu2.Text = "Select";
        //        likasu2.Value = "0";
        //        drpuom.Items.Add(likasu2);

        //        for (int k = 0; k < ds_edituom.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem liocat2;
        //            liocat2 = new ListItem();
        //            liocat2.Text = ds_edituom.Tables[0].Rows[k].ItemArray[1].ToString();
        //            liocat2.Value = ds_edituom.Tables[0].Rows[k].ItemArray[0].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpuom.Items.Add(liocat2);
        //        }


        //        for_uom = "";
        //        foruom_temp = "";

        //        ///////////////////

        //        /*new change ankur 15 feb*/
        //        hiddenuomcode.Value = drpuom.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[33].ToString();
        //        ////////////
        //        drppageposition.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[34].ToString();

        //        //string adtype=drpadstype.SelectedValue;
        //        txtadsize1.Text = executequery.Tables[0].Rows[fpnl].ItemArray[38].ToString();
        //        txtadsize2.Text = executequery.Tables[0].Rows[fpnl].ItemArray[39].ToString();

        //        txttotalarea.Text = executequery.Tables[0].Rows[fpnl].ItemArray[54].ToString();
        //        txtcardrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[55].ToString();

        //        txtgrossamt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();
        //        hiddenprevamt.Value = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();

        //        if (drpboxcodenew.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString()) != null)
        //        {
        //            drpboxcodenew.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //        }
        //        else
        //        {
        //            drpboxcodenew.SelectedValue = "0";
        //        }
        //        txtboxnonew.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();
        //        txtboxadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[81].ToString();
        //        txtboxchrg.Text = executequery.Tables[0].Rows[fpnl].ItemArray[132].ToString();

        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString() != null)
        //        {
        //            txtsapid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString();
        //        }
        //        else
        //        {
        //            txtsapid.Text = "";
        //        }
        //        // drpboxcode.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //        //txtboxno.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();


        //        txtcolum.Text = executequery.Tables[0].Rows[fpnl].ItemArray[84].ToString();

        //        txtpaid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[92].ToString();
        //        txtdealrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[93].ToString();


        //        txtcontractname.Text = executequery.Tables[0].Rows[fpnl].ItemArray[96].ToString();
        //        if (txtcontractname.Text == "")
        //        {
        //            chkcontract.Checked = false;

        //        }
        //        else
        //        {
        //            chkcontract.Checked = true;

        //        }

        //        hiddenreceiptno.Value = txtreceipt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[103].ToString();

        //        ////this is to bind the adscat3 drpdown



        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString() == "")
        //        {
        //            drpadcat3.Items.Clear();
        //            hiddenadscat3.Value = "";

        //        }
        //        else
        //        {
        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat3.Items.Clear();
        //            ListItem lika;
        //            lika = new ListItem();
        //            lika.Text = "Select";
        //            lika.Value = "0";
        //            drpadcat3.Items.Add(lika);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat3.Items.Add(lio);
        //            }


        //        }

        //        if (drpadcat3.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString()) != null)
        //        {
        //            hiddenadscat3.Value = drpadcat3.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString();
        //        }
        //        else
        //        {
        //            hiddenadscat3.Value = drpadcat3.SelectedValue = "0";
        //        }
        //        ////////////////////this is to bind the adcat4 drp down
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString() == "")
        //        {
        //            drpadcat4.Items.Clear();
        //            hiddenadscat4.Value = "";

        //        }
        //        else
        //        {
        //            ////////////when 1 than bind the adscat4 drp down

        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");
        //            }

        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 0 than bind adcat3 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat4.Items.Clear();
        //            ListItem liks;
        //            liks = new ListItem();
        //            liks.Text = "Select";
        //            liks.Value = "0";
        //            drpadcat4.Items.Add(liks);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat4.Items.Add(lio);
        //            }

        //        }

        //        if (drpadcat4.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString()) != null)
        //        {
        //            hiddenadscat4.Value = drpadcat4.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString();
        //        }
        //        else
        //        {
        //            hiddenadscat4.Value = drpadcat4.SelectedValue = "0";
        //        }

        //        ///bind adcat5 drpdown
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString() == "")
        //        {
        //            drpadcat5.Items.Clear();
        //            hiddenadscat5.Value = "";
        //        }
        //        else
        //        {
        //            ////////////when 1 than bind the adscat4 drp down
        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 2 than bind adcat2 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //            }
        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 2 than bind adcat2 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 2 than bind adcat2 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat4.Items.Clear();
        //            ListItem liks;
        //            liks = new ListItem();
        //            liks.Text = "Select";
        //            liks.Value = "0";
        //            drpadcat4.Items.Add(liks);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat4.Items.Add(lio);
        //            }
        //        }
        //        hiddenadscat5.Value = drpadcat5.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString();

        //        ///bind adcat5 drpdown
        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString() == "")
        //        {
        //            drpadcat5.Items.Clear();
        //            hiddenadscat5.Value = "";
        //        }
        //        else
        //        {
        //            ////////////when 1 than bind the adscat4 drp down

        //            DataSet dacat = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //                //////if 2 than bind adcat2 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //            }

        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                    //////if 2 than bind adcat2 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                    //////if 2 than bind adcat2 drop down 
        //                    dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //                }
        //            ////////////////////////////////////////////////////////////////
        //            drpadcat4.Items.Clear();
        //            ListItem liks;
        //            liks = new ListItem();
        //            liks.Text = "Select";
        //            liks.Value = "0";
        //            drpadcat4.Items.Add(liks);
        //            for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem lio;
        //                lio = new ListItem();
        //                lio.Text = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //                lio.Value = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpadcat4.Items.Add(lio);
        //            }
        //        }

        //        if (drpadcat5.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString()) != null)
        //        {
        //            hiddenadscat5.Value = drpadcat5.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString();
        //        }
        //        else
        //        {
        //            hiddenadscat5.Value = drpadcat5.SelectedValue = "0";
        //        }


        //        //////bind the bg color drp down 

        //        /*new change ankur 15 feb*/
        //        string combin_name = "";
        //        //drpcolortype.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[124].ToString();
        //        if (Session["bg_colorpub"].ToString() == "yes")
        //        {
        //            ////this is to get the combin_desc
        //            for (int z = 0; z < drppackagecopy.Items.Count; z++)
        //            {
        //                string[] arr = drppackagecopy.Items[z].Value.Split('@');

        //                if (combin_name != "")
        //                {
        //                    combin_name = combin_name + "+" + arr[1];
        //                }
        //                else
        //                {
        //                    combin_name = arr[1];
        //                }

        //            }
        //            DataSet dsget = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //                dsget = bind.bindbgandfont(drpadcategory.SelectedValue, combin_name);
        //            }

        //            else
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //                    dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);

        //                }
        //                else
        //                {
        //                    NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
        //                    dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);
        //                }
        //            //////bind colortype

        //            drpcolortype.Items.Clear();
        //            ListItem colty;
        //            colty = new ListItem();
        //            colty.Text = "Select Color type";
        //            colty.Value = "0";
        //            drpcolortype.Items.Add(colty);
        //            for (int k = 0; k < dsget.Tables[0].Rows.Count; k++)
        //            {
        //                ListItem col1;
        //                col1 = new ListItem();
        //                col1.Text = dsget.Tables[0].Rows[k].ItemArray[1].ToString();
        //                col1.Value = dsget.Tables[0].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpcolortype.Items.Add(col1);
        //            }
        //            /*new change ankur 10 feb*/
        //            if (executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString() != "")
        //            {
        //                drpcolortype.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString();
        //            }
        //            else
        //            {
        //                drpcolortype.Items.Clear();
        //            }

        //            /////bind bg color



        //            drpbgcolor.Items.Clear();
        //            ListItem liksabg;
        //            liksabg = new ListItem();
        //            liksabg.Text = "Select Bg color";
        //            liksabg.Value = "0";
        //            drpbgcolor.Items.Add(liksabg);
        //            for (int k = 0; k < dsget.Tables[1].Rows.Count; k++)
        //            {
        //                ListItem liobg;
        //                liobg = new ListItem();
        //                liobg.Text = dsget.Tables[1].Rows[k].ItemArray[1].ToString();
        //                liobg.Value = dsget.Tables[1].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpbgcolor.Items.Add(liobg);
        //            }
        //            /*new change ankur 10 feb*/
        //            if (executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString() != "")
        //            {
        //                drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //            }
        //            else
        //            {
        //                drpbgcolor.Items.Clear();
        //            }


        //            ////bind bullet


        //            drpbullet.Items.Clear();
        //            ListItem bul;
        //            bul = new ListItem();
        //            bul.Text = "Select eye catcher";
        //            bul.Value = "0";
        //            drpbullet.Items.Add(bul);
        //            for (int k = 0; k < dsget.Tables[2].Rows.Count; k++)
        //            {
        //                ListItem bul1;
        //                bul1 = new ListItem();
        //                bul1.Text = dsget.Tables[2].Rows[k].ItemArray[1].ToString();
        //                bul1.Value = dsget.Tables[2].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpbullet.Items.Add(bul1);
        //            }
        //            /*new change ankur 10 feb*/
        //            if (executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString() != "")
        //            {
        //                drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //            }
        //            else
        //            {
        //                drpbullet.Items.Clear();
        //            }

        //        }
        //        else
        //        {
        //            if (drpbgcolor.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString()) != null)
        //            {
        //                drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //            }
        //            if (drpbullet.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString()) != null)
        //            {
        //                drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //            }
        //        }
        //        hiddencolortype.Value = drpcolortype.SelectedValue;
        //        hiddenbgcolor.Value = drpbgcolor.SelectedValue;
        //        hiddenbullet.Value = drpbullet.SelectedValue;
        //        ////////////////////////////////////////////////////////////////

        //        drpmatstat.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[120].ToString();
        //        txtreceiptdate.Text = getdatechk.getDate(dateformat, executequery.Tables[0].Rows[fpnl].ItemArray[121].ToString());
        //        /*   change  */
        //        drpregion.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[122].ToString();
        //        drpvarient.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[123].ToString();


        //        /*change ankur*/
        //        ///////this is to bind the bill to dropdown as agency and client////////
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            bindagencybillto(ds_billto);
        //        }
        //        else
        //        {
        //            bindagencybillto(ds_billto);
        //        }
        //        if (drpbillto_qbc.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString()) != null)
        //        {
        //            drpbillto_qbc.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString();
        //        }
        //        ///////////////////////////////////////////////////////////////////////////
        //        hiddenbillto.Value = drpbillto_qbc.SelectedValue;


        //        /*new change 15 feb*/

        //        bindpackage();


        //        ///

        //        hiddenuomdesc.Value = executequery.Tables[0].Rows[fpnl].ItemArray[125].ToString();

        //        /*new change ankur 24 feb*/
        //        hiddenlogomatter.Value = executequery.Tables[0].Rows[fpnl].ItemArray[126].ToString();
        //        txtlogohei.Text = executequery.Tables[0].Rows[fpnl].ItemArray[127].ToString();
        //        txtlogowid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[128].ToString();
        //        drplogocolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[129].ToString();
        //        txtlogouomcode.Text = executequery.Tables[0].Rows[fpnl].ItemArray[130].ToString();
        //        hiddenlogocode.Value = executequery.Tables[0].Rows[fpnl].ItemArray[131].ToString();
        //        ////////////////////////////

        //        //   ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "ca", "showcardinfo('" + executequery.Tables[0].Rows[0].ItemArray[61].ToString() + "')", true);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "cc", "showgridexecute()", true);
        //        updateStatus();
        //        btnfirst.Enabled = true;
        //        btnlast.Enabled = true;
        //        btnprevious.Enabled = true;
        //        btnnext.Enabled = true;
        //    }
        //    else
        //    {
        //        btnnext.Enabled = true;
        //        btnlast.Enabled = true;
        //        btnfirst.Enabled = false;
        //        btnprevious.Enabled = false;


        //    }
        //}
        //else
        //{
        //    btnnext.Enabled = true;
        //    btnlast.Enabled = true;
        //    btnfirst.Enabled = false;
        //    btnprevious.Enabled = false;


        //}
        //if (fpnl == 0)
        //{
        //    btnfirst.Enabled = false;
        //    btnprevious.Enabled = false;
        //}
        //if (hiddenuomdesc.Value == "CD")
        //{
        //    if (txtadsize1.Text != "" && txtcolum.Text != "")
        //    {
        //        txtadsize2.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }
        //    else if (txtadsize1.Text != "" && txtadsize2.Text != "")
        //    {
        //        txtcolum.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }


        //}
        //else if (hiddenuomdesc.Value != "CD")
        //{
        //    txtadsize1.Enabled = false;
        //    txtadsize2.Enabled = false;
        //    if (hiddenuomdesc.Value == "ROL" || hiddenuomdesc.Value == "ROD")
        //    {
        //        Label1.Text = "No. Of Lines";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;


        //    }
        //    else if (hiddenuomdesc.Value == "ROW")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }
        //    else if (hiddenuomdesc.Value == "ROC")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }

        //}
        //if (confirm_Permission == "1" && drprostatus.SelectedValue == "2")
        //{

        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj21", "document.getElementById('btnconfirm').disabled=false;", true);
        //}
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
//        if (txtagency.Text != "")
//        {
//            bindagencybillto_btnnew(txtagency.Text);
//        }
//        if (Session["compcode"] == null)
//        {
//            //Response.Redirect("login.aspx");
//            //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
//            string sessionout = "Your Session Has Been Expired";
//            AspNetMessageBox_close(sessionout);
//            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

//            return;

//        }
//        drpboxcodenew.Enabled = true;
//        //txtboxadd.Enabled = true;

//        drpboxcodenew.SelectedValue = "0";
//        txtboxnonew.Text = "";
//        txtboxadd.Text = "";
//        txtboxchrg.Text = "";
//        /*change ankur*/
//        hiddenbillto.Value = drpbillto_qbc.SelectedValue;
//        drpbillto_qbc.Enabled = true;

//        hiddenprevamt.Value = "";
//        ////////////////////////////////////////
//        /*new change ankur 9feb*/
//        drpcolortype.Enabled = false;

//        hiddensavemod.Value = saveormodify;

//        txtciobookid.ReadOnly = true;
//        chkcontract.Checked = true;
//        chkcontract.Enabled = false;
//        txtrono.Enabled = false;
//        txtrodate.Enabled = false;
//        btncopy.Enabled = true;
//        btndel.Enabled = true;

//        drprostatus.Enabled = true;
//        //txtagency.Enabled = true;
//        txtclient.Enabled = true;
//        if (ConfigurationSettings.AppSettings["f2"].ToString() != "yes")
//        {
//            txtagency.ReadOnly = true;
//        }
//        else
//        {
//            txtagency.ReadOnly = false;
//        }
//        // txtagencyaddress.Enabled = true;
//        txtclientadd.Enabled = true;

////        txtprintremark.Enabled = true;
//        drppackage.Enabled = true;
//        txtinsertion.Enabled = true;
//        txtdummydate.Enabled = true;
//        txtrepeatingdate.Enabled = true;

//        drpadcategory.Enabled = true;
//        chkall.Enabled = true;
//        drpadsubcategory.Enabled = true;
//        drpcolor.Enabled = true;
//        drpuom.Enabled = true;
//        drppageposition.Enabled = false;

//        // txtadsizetypeheight.Enabled = true;
//        //txtadsizetypewidth.Enabled = true;


//        txtdatetime.ReadOnly = true;
//        txtrepeatingdate.Enabled = true;


//        txtadsize2.Enabled = true;
//        txtadsize1.Enabled = true;
//        //txttotalarea.Enabled = false;
//        txttotalarea.ReadOnly = true;
//       // drpvarient.Enabled = true;

//        drpregion.Enabled = false;


//        //txtgrossamt.Enabled = false;
//        txtgrossamt.ReadOnly = true;
//        //   drpboxcode.Enabled = true;



//        txtinsertion.Enabled = true;
//        txtcolum.Enabled = true;



//        drpadcat3.Enabled = true;
//        drpadcat4.Enabled = true;

//        drpbgcolor.Enabled = true;
//        drpadcat5.Enabled = true;

//        drpbullet.Enabled = true;


//        txtreceiptdate.Enabled = true;

//        drpmatstat.Enabled = true;
//       get_pacakge_new.Enabled = true;
//        /*new change ankur 11 feb*/
//        drpadtype.Enabled = false;

//        txteyecathval.Enabled = true;

//        btnpaygateway.Enabled = true;

//        drpadtype.SelectedValue = "CL0";

//        /*new changes ankur 26 feb*/
    
       
//        //////////////////
//        //btndel.Enabled = true;


//        txtcontractname.Text = "";

//        /*new changes ankur*/
//        drpvarient.SelectedValue = "0";


//        //////////////////////////////
//        drpadcat5.Items.Clear();
//        drpbgcolor.SelectedValue = "0";
//        drpbullet.SelectedValue = "0";
//        txtreceiptdate.Text = "";
//        drpadcat3.Items.Clear();
//        drpadcat4.Items.Clear();
//        drpmatstat.SelectedValue = "0";

//        //     drpschemepck.SelectedValue = "0";



//        drpcolortype.SelectedValue = "0";
//        /////////////////////////////////////

//        saveormodify = "0";
//        txtcolum.Text = "";


//        txtrono.Text = "";
//        txtrodate.Text = "";


//        drprostatus.SelectedValue = "0";

//        txtclient.Text = "";

//        txtclientadd.Text = "";

//        //  drppackage.SelectedValue = "0";
//        txtinsertion.Text = "";
//        txtdummydate.Text = "";
//        txtrepeatingdate.Text = "";

//        drpadcategory.SelectedValue = "0";
//        drpadsubcategory.SelectedValue = "0";
//        drpcolor.SelectedValue = "B";
//        //drpuom.SelectedValue = "0";
//        drppageposition.SelectedValue = "0";

//        //txtadsizetypeheight.Text = "";
//        //txtadsizetypewidth.Text = "";
//        //txtratecode.SelectedValue = "0";



//        txtadsize2.Text = "";
//        txtadsize1.Text = "";
//        txttotalarea.Text = "";
//        //   drpboxcode.SelectedValue = "0";
//        // txtboxno.Text = "";


//        txtgrossamt.Text = "";
//        drppackage.SelectedValue = "0";
//        drppackagecopy.Items.Clear();


//        //  drpboxcode.SelectedValue = "0";

//        /*new change ankur 24 feb*/
//        txtlogohei.Enabled = true;
//        txtlogohei.Text = "";
//        txtlogoname.Text = "";
//        drplogocolor.Enabled = true;
//        drplogocolor.SelectedValue = "0";

//        /////////////////////////////////



//        txtinsertion.Text = "";


//        hiddenbranch.Value = Session["revenue"].ToString();
//        saveormodify = "0";
//        /*new change ankur 23 feb*/
//        hiddensavemod.Value = saveormodify;
//        /////////////////////////////

//        /*change for oracle*/
//        hiddendummycioid.Value = "";


//        autogenerated("0");
//        autogenerated("2");

//        fpnl = 0;
//        drppackagecopy.Enabled = true;
//        if (Session["bookstat"].ToString() == "Booked")
//        {
//            drprostatus.SelectedValue = "1";
//        }
//        else if (Session["bookstat"].ToString() == "Unconfirmed")
//        {
//            drprostatus.SelectedValue = "2";
//            drprostatus.Enabled = false;
//        }

//        /*new change ankur 22 feb*/
//        txtlogohei.Text = "";
//        txtlogohei.Enabled = true;
//        txtlogowid.Enabled = true;
//        txtlogowid.Text = "";
//        txtlogouomcode.Text = "";
//        //txtlogouomcode.Enabled=true;
//        drplogocolor.Enabled = true;
//        drplogocolor.SelectedValue = "0";
//        btnlogo.Enabled = true;
//        ///////////////////////////////



//        //bindpackage();
//        DateTime dt = DateTime.Now;

//        int year = Convert.ToInt32(dt.Year);
//        int month = Convert.ToInt32(dt.Month);
//        int day = Convert.ToInt32(dt.Day);
//        //string serdate = Convert.ToString(month + "/" + day + "/" + year);

//        string serdate = "";
//        /*change for oracle*/
//        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
//        {
//            serdate = Convert.ToString(day + "/" + month + "/" + year);
//        }
//        else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
//        {
//            serdate = Convert.ToString(month + "/" + day + "/" + year);
//        }
//        else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
//        {
//            serdate = Convert.ToString(year + "/" + month + "/" + day);
//        }

//        datesave getdatechk = new datesave();
//        dateinsert getdateshow = new dateinsert();
//        //txtrodate.Text = getdateshow.getDate(Session["dateformat"].ToString(), serdate);
//        txtreceiptdate.Text = getdateshow.getDate(Session["dateformat"].ToString(), serdate);


//        chkstatus(FlagStatus);
//        btnSave.Enabled = true;
//        btnSaveConfirm.Enabled = true;
//        btnNew.Enabled = false;
//        btnQuery.Enabled = false;
//        if (txtagency.Text == "")
//        {
//            ScriptManager1.SetFocus(txtagency);
//        }
//        else
//        {
//            ScriptManager1.SetFocus(txtclient);
//        }
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj", "document.getElementById('btndel').disabled=false;", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj1", "document.getElementById('btnshgrid').disabled=false;", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "iid1", "getid=\"\";", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "igb", "gblogowithmatter=\"\";", true);
//        //*****************By Manish Verma********************************************************
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "pass", "modifyMatter=0;", true);
//        //****************************************************************************************
//        /*change for oracle*/
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "disa", "disabledlogoinfo();", true);

//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "setuom", "defaultuom()", true);



    }
    public void autogenerated(string no)
    {
        /*change ankur*/
        DateTime dt = DateTime.Now;

        string cen = txtbranch.Text;
        if (txtbranch.Text == "" || txtbranch.Text == "Branch")
        {
            txtbranch.Text = "";
            cen = txtagency.Text;
        }
        if (cen == "")
        {
            cen = hiddencenter.Value;
        }

        cen = cen.Substring(0, 3);
        cen = cen.Trim();
        int year = Convert.ToInt32(dt.Year);

        if (no == "0")
        {
            string auto = "";
            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["cioid"].ToString() == "1")
            {
                auto = cen + year;
            }
            else if (Session["cioid"].ToString() == "2")
            {
                auto = cen + year + Session["userid"].ToString();
            }


            string autogen = auto + cou;
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

            }

            if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                int cou1 = Convert.ToInt32(ab);
                //cou1++;
                int countlen = cou1.ToString().Length;
                if (countlen == 1)
                {
                    zeros = "0000000" + cou1;

                }
                else if (countlen == 2)
                {
                    zeros = "000000" + cou1;

                }
                else if (countlen == 3)
                {
                    zeros = "00000" + cou1;
                }
                else if (countlen == 4)
                {
                    zeros = "0000" + cou1;
                }
                else if (countlen == 5)
                {
                    zeros = "000" + cou1;
                }
                else if (countlen == 6)
                {
                    zeros = "00" + cou1;
                }
                else if (countlen == 7)
                {
                    zeros = "0" + cou1;
                }
                else if (countlen == 8)
                {
                    zeros = "0" + cou1;
                }


                txtciobookid.Text = auto + zeros;
            }
            else
            {
                txtciobookid.Text = autogen;

            }
        }
        else if (no == "1")
        {
            string auto = "DN";
            string autogen = auto + cou;
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

            }

            if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                int cou1 = Convert.ToInt32(ab);
                cou1++;

                //txtdockitno1.Text = auto + cou1;
            }
            else
            {
                //  txtdockitno1.Text = autogen;

            }


        }

        else if (no == "2")
        {
            DataSet datasetrecinc = new DataSet();
            if (Session["Receipt_no"].ToString() == "4")
            {
               
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rec = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                string agencycode = "";
                if (txtagency.Text != "")
                {
                    agencycode = txtagency.Text.Substring(txtagency.Text.IndexOf("(") + 1, txtagency.Text.Length - txtagency.Text.IndexOf("(") - 2);
                }
                datasetrecinc = rec.getReciptNo(agencycode);
            }
            int cou1 = 0;

            string auto = "";
            string zeros = "";
            /*change ankur*/
            if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes" && hdnf2.Value != "")
            {
                if (Session["Receipt_no"].ToString() == "4")
                {
                    if (datasetrecinc.Tables[0].Rows.Count > 0)
                    {
                        auto = datasetrecinc.Tables[0].Rows[0].ItemArray[1].ToString() + "-";
                    }
                    else
                    {
                        auto = hdnagencyname.Value.Substring(0, 2) + "-";
                    }


                }
                else if (Session["Receipt_no"].ToString() == "1" && Session["cioid"].ToString() == "1")
                {
                    if (txtbranch.Text == "Branch" || txtbranch.Text == "")
                    {
                        auto = hdnagencyname.Value.Substring(0, 3) + year;
                    }
                    else
                    {
                        auto = txtbranch.Text.Substring(0, 3) + year;
                    }
                }
                else if (Session["Receipt_no"].ToString() == "1" && Session["cioid"].ToString() == "2")
                {
                    if (txtbranch.Text == "Branch" || txtbranch.Text == "")
                    {
                        auto = hdnagencyname.Value.Substring(0, 3) + year + Session["userid"].ToString();
                    }
                    else
                    {
                        auto = txtbranch.Text.Substring(0, 3) + year + Session["userid"].ToString();
                    }

                }
                else if (Session["Receipt_no"].ToString() == "2" && Session["cioid"].ToString() == "1")
                {
                    auto = hdnagencyname.Value.Substring(0, 3) + year;
                }
                else if (Session["Receipt_no"].ToString() == "2" && Session["cioid"].ToString() == "2")
                {
                    auto = hdnagencyname.Value.Substring(0, 3) + year + Session["userid"].ToString();
                }
                // string autogen = auto + cou;
                DataSet da = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                    da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
                }
                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                        da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                        da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                    }
                if (Session["Receipt_no"].ToString() == "4")
                {
                    if (datasetrecinc.Tables[0].Rows.Count > 0)
                    {
                        string ab = datasetrecinc.Tables[0].Rows[0].ItemArray[0].ToString();
                        cou1 = Convert.ToInt32(ab);
                        zeros = cou1.ToString();
                        //cou1++;
                        if (cou1.ToString().Length == 1)
                        {
                            zeros = "000" + cou1;
                        }
                        if (cou1.ToString().Length == 2)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 3)
                        {
                            zeros = "0" + cou1;
                        }
                        if (cou1.ToString().Length == 4)
                        {
                            zeros = cou1.ToString();
                        }



                        hdnagencyname.Value = auto + zeros;
                    }
                    else
                    {
                        if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                        {
                            string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                            cou1 = Convert.ToInt32(ab);
                            zeros = cou1.ToString();
                            //cou1++;
                            if (cou1.ToString().Length == 1)
                            {
                                zeros = "000" + cou1;
                            }
                            if (cou1.ToString().Length == 2)
                            {
                                zeros = "00" + cou1;
                            }
                            if (cou1.ToString().Length == 3)
                            {
                                zeros = "0" + cou1;
                            }
                            if (cou1.ToString().Length == 4)
                            {
                                zeros = cou1.ToString();
                            }



                            hdnagencyname.Value = auto + zeros;
                            //txtreceipt.Text = auto + zeros;

                        }
                    }
                }
                else
                {
                    if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                    {
                        string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                         cou1 = Convert.ToInt32(ab);
                        //cou1++;
                        if (cou1.ToString().Length == 1)
                        {
                            zeros = "00000" + cou1;
                        }
                        if (cou1.ToString().Length == 2)
                        {
                            zeros = "0000" + cou1;
                        }
                        if (cou1.ToString().Length == 3)
                        {
                            zeros = "000" + cou1;
                        }
                        if (cou1.ToString().Length == 4)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 5)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 6)
                        {
                            zeros = "0" + cou1;
                        }

                      
                        hdnagencyname.Value = auto + zeros;
                        if (Session["Receipt_no"].ToString() == "3")
                        {
                            hdnagencyname.Value = "";
                            hdnagencyname.Value = Session["prefix"].ToString() + zeros + Session["suffix"].ToString();
                        }
                    }

                    else
                    {
                        hdnagencyname.Value = auto + "000000";

                    }
                }
                hdnagencyname.Value =Convert.ToString(cou1);
                hiddenreceiptno.Value = hdnagencyname.Value;
            }
            else
            {
                if (Session["Receipt_no"].ToString() == "4")
                {
                    if (datasetrecinc.Tables[0].Rows.Count > 0)
                    {
                        if (datasetrecinc.Tables[0].Rows[0].ItemArray[1].ToString() == "")
                        {
                            auto = txtagency.Text.Substring(0, 2) + "-";
                        }
                        else
                        {
                            auto = datasetrecinc.Tables[0].Rows[0].ItemArray[1].ToString() + "-";
                        }
                    }
                    else
                    {
                        auto = txtagency.Text.Substring(0, 2) + "-";
                    }
                    
                  
                }
                else if (Session["Receipt_no"].ToString() == "1" && Session["cioid"].ToString() == "1")
                {
                    if (txtbranch.Text == "Branch" || txtbranch.Text == "")
                    {
                        auto = txtagency.Text.Substring(0, 3) + year;
                    }
                    else
                    {
                        auto = txtbranch.Text.Substring(0, 3) + year;
                    }
                }
                else if (Session["Receipt_no"].ToString() == "1" && Session["cioid"].ToString() == "2")
                {
                    if (txtbranch.Text == "Branch" || txtbranch.Text == "")
                    {
                        auto = txtagency.Text.Substring(0, 3) + year + Session["userid"].ToString();
                    }
                    else
                    {
                        auto = txtbranch.Text.Substring(0, 3) + year + Session["userid"].ToString();
                    }

                }
                else if (Session["Receipt_no"].ToString() == "2" && Session["cioid"].ToString() == "1")
                {
                    auto = txtagency.Text.Substring(0, 3) + year;
                }
                else if (Session["Receipt_no"].ToString() == "2" && Session["cioid"].ToString() == "2")
                {
                    auto = txtagency.Text.Substring(0, 3) + year + Session["userid"].ToString();
                }
                // string autogen = auto + cou;
                DataSet da = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                    da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                    da = autocode.autogenrated(Session["compcode"].ToString(), auto, no);

                }
                if (Session["Receipt_no"].ToString() == "4")
                {
                    if (datasetrecinc.Tables[0].Rows.Count > 0)
                    {
                        string ab = datasetrecinc.Tables[0].Rows[0].ItemArray[0].ToString();
                        cou1 = Convert.ToInt32(ab);
                        zeros = cou1.ToString();
                        //cou1++;
                        if (cou1.ToString().Length == 1)
                        {
                            zeros = "000" + cou1;
                        }
                        if (cou1.ToString().Length == 2)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 3)
                        {
                            zeros = "0" + cou1;
                        }
                        if (cou1.ToString().Length == 4)
                        {
                            zeros = cou1.ToString();
                        }



                        txtreceipt.Text = auto + zeros;
                    }
                    else
                    {
                        if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                        {
                            string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                            cou1 = Convert.ToInt32(ab);
                            zeros = cou1.ToString();
                            //cou1++;
                            if (cou1.ToString().Length == 1)
                            {
                                zeros = "000" + cou1;
                            }
                            if (cou1.ToString().Length == 2)
                            {
                                zeros = "00" + cou1;
                            }
                            if (cou1.ToString().Length == 3)
                            {
                                zeros = "0" + cou1;
                            }
                            if (cou1.ToString().Length == 4)
                            {
                                zeros = cou1.ToString();
                            }



                            txtreceipt.Text = auto + zeros;
                        }
                    }
                }
                else
                {
                    if (da.Tables[0].Rows.Count > 0 && da.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                    {
                        string ab = da.Tables[0].Rows[0].ItemArray[0].ToString();
                        cou1 = Convert.ToInt32(ab);
                        //cou1++;
                        if (cou1.ToString().Length == 1)
                        {
                            zeros = "00000" + cou1;
                        }
                        if (cou1.ToString().Length == 2)
                        {
                            zeros = "0000" + cou1;
                        }
                        if (cou1.ToString().Length == 3)
                        {
                            zeros = "000" + cou1;
                        }
                        if (cou1.ToString().Length == 4)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 5)
                        {
                            zeros = "00" + cou1;
                        }
                        if (cou1.ToString().Length == 6)
                        {
                            zeros = "0" + cou1;
                        }


                        txtreceipt.Text = auto + zeros;
                        if (Session["Receipt_no"].ToString() == "3")
                        {
                            txtreceipt.Text = "";
                            txtreceipt.Text = Session["prefix"].ToString() + zeros + Session["suffix"].ToString();
                        }
                    }

                    else
                    {
                        txtreceipt.Text = auto + "000000";

                    }
                }
                hiddenreceiptno.Value = txtreceipt.Text;

            }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
     
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
//        if (txtagency.Text == "")
//        {
//            txtagency.Text = hdnagencyname.Value;
//        }
//        if (Session["compcode"] == null)
//        {
//            //Response.Redirect("login.aspx");
//            //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
//            string sessionout = "Your Session Has Been Expired";
//            AspNetMessageBox_close(sessionout);
//            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

//            return;

//        }
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "document.getElementById('btnlogoupload').disabled=false", true);
//        saveormodify = "01";
//        hiddensavemod.Value = saveormodify;

//        /*change ankur*/
//        drpbillto_qbc.Enabled = true;
//        ///////////////////////////////////////
//        /*new change ankur 10 feb*/
//        if (hiddencopy.Value == "copy")
//        {
//            //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "getprevid", "prevcioidformatter=document.getElementById('txtciobookid').value;", true);
//            // btnNew_Click(sender, e);
//            hiddendummycioid.Value = txtciobookid.Text;
//            forcopydate();
//            insertstatus = "0";
//            hiddensavemod.Value = "01";

//            DataSet dsmatter = new DataSet();
//            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
//            {
//                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getData = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

//                dsmatter = getData.getMatter(hiddendummycioid.Value, "copy");
//                Session["copy_matter"] = dsmatter;
//            }
//            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
//            {
//                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getData = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

//                dsmatter = getData.getMatter(hiddendummycioid.Value, "copy");
//                Session["copy_matter"] = dsmatter;
//            }
//            else
//            {
//                NewAdbooking.classmysql.BookingMaster getData = new NewAdbooking.classmysql.BookingMaster();

//                dsmatter = getData.getMatter(hiddendummycioid.Value, "copy");
//                Session["copy_matter"] = dsmatter;
//            }

            
//        }

//        chkcontract.Enabled = false;

//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "pass", "modifyMatter=1;", true);

//        /////if in the insertion grid record insertion status is publish or hold or cancel than the main form except the
//        ////insert grid record cannot modify
//        DataSet dex = new DataSet();
//        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
//        {
//            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

//            dex = showgri.fetchdataforexe(txtciobookid.Text, Session["compcode"].ToString());
//        }
//        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
//        {
//            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

//            dex = showgri.fetchdataforexe(txtciobookid.Text, Session["compcode"].ToString());
//        }
//        else
//        {
//            NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();

//            dex = showgri.fetchdataforexe(txtciobookid.Text, Session["compcode"].ToString());

//        }

//        for (int j = 0; j <= dex.Tables[0].Rows.Count - 1; j++)
//        {


//            if (dex.Tables[0].Rows[j].ItemArray[20].ToString() == "publish")
//            {
//                insertstatus = "2";
//                break;
//            }
//            else if (dex.Tables[0].Rows[j].ItemArray[20].ToString() == "billed")
//            {
//                insertstatus = "1";
//                saveormodify = "1";
//                hiddensavemod.Value = saveormodify;
//                break;
//            }
//            else
//            {
//                insertstatus = "0";
//            }
//        }
//        if (insertstatus == "2")
//        {
//            drpboxcodenew.Enabled = true;
//            //txtboxadd.Enabled = true;
//            btnlogo.Enabled = false;
//            //btnupload.Enabled = false;

//            txtciobookid.Enabled = false;
//            // txtappby.Enabled = true;
//            //txtaudit.Enabled = true;
//            txtrono.Enabled = false;
//            txtrodate.Enabled = false;


//            drprostatus.Enabled = true;
//            //txtagency.Enabled = true;
//            txtagency.ReadOnly = false;
//            txtclient.Enabled = true;
//            // txtagencyaddress.Enabled = true;
//            txtclientadd.Enabled = true;

//            //txtprintremark.Enabled = true;

//            drppackage.Enabled = false;
//            txtinsertion.Enabled = false;
//            txtdummydate.Enabled = false;
//            txtrepeatingdate.Enabled = false;

//            drpadcategory.Enabled = false;
//            chkall.Enabled = false;
//            drpadsubcategory.Enabled = false;
//            drpcolor.Enabled = false;
//            drpuom.Enabled = false;
//            drppageposition.Enabled = false;

//            // txtadsizetypeheight.Enabled = true;
//            //txtadsizetypewidth.Enabled = true;

//            //txtdatetime.Enabled = false;
//            txtdatetime.ReadOnly = true;
//            txtrepeatingdate.Enabled = false;


//            txtadsize2.Enabled = false;
//            txtadsize1.Enabled = false;
//            //txttotalarea.Enabled = false;
//            txttotalarea.ReadOnly = true;

//            drpregion.Enabled = false;
//            //txtboxno.Enabled = true;

//            //txtgrossamt.Enabled = false;
//            txtgrossamt.ReadOnly = true;
//            drpregion.Enabled = false;

//            txtinsertion.Enabled = false;
//            txtcolum.Enabled = false;

//            drpmatstat.Enabled = false;

//            ///////////////////////
//            txtcontractname.Enabled = false;

//            btnlogo.Enabled = false;
//            drpcolortype.Enabled = false;

//            /*new change ankur 24 feb*/
//            txtlogohei.Enabled = false;
//            //txtlogohei.Text = "";
//            //txtlogoname.Text = "";
//            drplogocolor.Enabled = false;
//            //drplogocolor.SelectedValue = "0";

//            txteyecathval.Enabled = true;
//            /////////////////////////////////

//        }
//        else if (insertstatus == "1")
//        {
//            drpboxcodenew.Enabled = false;
//            //txtboxadd.Enabled = false;
//            txtciobookid.Enabled = false;
//            // txtappby.Enabled = true;
//            //txtaudit.Enabled = true;
//            txtrono.Enabled = false;
//            txtrodate.Enabled = false;


//            drprostatus.Enabled = false;
//            //txtagency.Enabled = false;
//            txtagency.ReadOnly = true;
//            txtclient.Enabled = false;
//            // txtagencyaddress.Enabled = true;
//            txtclientadd.Enabled = false;

//            txtprintremark.Enabled = false;
//            drppackage.Enabled = false;
//            txtinsertion.Enabled = false;
//            txtdummydate.Enabled = false;
//            txtrepeatingdate.Enabled = false;

//            drpadcategory.Enabled = false;
//            chkall.Enabled = false;
//            drpadsubcategory.Enabled = false;
//            drpcolor.Enabled = false;
//            drpuom.Enabled = false;
//            drppageposition.Enabled = false;

//            // txtadsizetypeheight.Enabled = true;
//            //txtadsizetypewidth.Enabled = true;

//            txtdatetime.ReadOnly = true;
//            //txtdatetime.Enabled = false;
//            txtrepeatingdate.Enabled = false;


//            //txtcardrate.Enabled = false;
//            txtcardrate.ReadOnly = true;

//            txtadsize2.Enabled = false;
//            txtadsize1.Enabled = false;
//            //txttotalarea.Enabled = false;
//            txttotalarea.ReadOnly = true;

//            drpregion.Enabled = false;
//            //txtboxno.Enabled = true;


//            //txtgrossamt.Enabled = false;
//            txtgrossamt.ReadOnly = true;


//            drpregion.Enabled = false;

//            txtinsertion.Enabled = false;

//            txtcolum.Enabled = false;

//            // txtboxno.Enabled = false;
//            drpmatstat.Enabled = false;


//            ///////////////////////
//            txtcontractname.Enabled = false;

//            btnlogo.Enabled = false;
//            /*new change ankur 9 feb*/
//            drpcolortype.Enabled = false;

//            /*new change ankur 24 feb*/
//            txtlogohei.Enabled = false;
//            //txtlogohei.Text = "";
//            //txtlogoname.Text = "";
//            drplogocolor.Enabled = false;
//            //drplogocolor.SelectedValue = "0";

//            /////////////////////////////////


//        }
//        else if (insertstatus == "0")
//        {


//            drpboxcodenew.Enabled = true;
//            //txtboxadd.Enabled = true;
//            /*new change 14 feb*/
//            //drpadtype.SelectedValue = "0";
//            drpadtype.Enabled = false;
//            /////////////////////
//            btnlogo.Enabled = true;
//            //btnupload.Enabled = true;

//            txtciobookid.Enabled = false;
//            // txtappby.Enabled = true;
//            //txtaudit.Enabled = true;
//            txtrono.Enabled = false;
//            txtrodate.Enabled = false;


//            drprostatus.Enabled = true;
//            //txtagency.Enabled = true;
//            txtagency.ReadOnly = false;
//            txtclient.Enabled = true;
//            // txtagencyaddress.Enabled = true;
//            txtclientadd.Enabled = true;

////            txtprintremark.Enabled = true;
//            drppackage.Enabled = true;
//            txtinsertion.Enabled = true;
//            txtdummydate.Enabled = true;
//            txtrepeatingdate.Enabled = true;

//            drpadcategory.Enabled = true;
//            chkall.Enabled = true;
//            drpadsubcategory.Enabled = true;
//            drpcolor.Enabled = true;
//            drpuom.Enabled = true;
//            drppageposition.Enabled = false;

//            // txtadsizetypeheight.Enabled = true;
//            //txtadsizetypewidth.Enabled = true;

//            txtdatetime.ReadOnly = true;
//            //txtdatetime.Enabled = false;
//            txtrepeatingdate.Enabled = true;


//            txtadsize2.Enabled = true;
//            txtadsize1.Enabled = true;
//            //txttotalarea.Enabled = false;
//            txttotalarea.ReadOnly = true;

//            drpregion.Enabled = false;
//            //txtboxno.Enabled = true;


//            //txtgrossamt.Enabled = false;
//            txtgrossamt.ReadOnly = true;
//            drpregion.Enabled = false;

//            txtinsertion.Enabled = true;
//            txtcolum.Enabled = true;
//            drpmatstat.Enabled = true;



//            ///////////////////////
//            txtcontractname.Enabled = false;

//            btncopy.Enabled = true;
//            btndel.Enabled = true;
//            btnlogo.Enabled = true;
//            /*new change ankur 9 feb*/
//            drpcolortype.Enabled = false;
//            /*new change ankur 15 feb*/
//            drpbgcolor.Enabled = true;
//            drpbullet.Enabled = true;
//            drppackagecopy.Enabled = true;
////            drpvarient.Enabled = true;
//            drpadcat3.Enabled = true;
//            drpadcat4.Enabled = true;
//            drpadcat5.Enabled = true;
//            drprostatus.Enabled = false;
//            //////////////////////////////
//            /*new change ankur 24 feb*/
//            txtlogohei.Enabled = true;
//            //txtlogohei.Text = "";
//            //txtlogoname.Text = "";
//            drplogocolor.Enabled = true;
//            //drplogocolor.SelectedValue = "0";
//            btnlogoupload.Enabled = true;
//            /////////////////////////////////


//            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj", "document.getElementById('btndel').disabled=false;", true);
//        }

//        //if (drpuom.SelectedItem.Text == "ROD")
//        //{
//        //    if (txtadsize1.Text != "" && txtcolum.Text != "")
//        //    {
//        //        txtadsize2.Enabled = false;

//        //    }
//        //    else if (txtadsize1.Text != "" && txtadsize2.Text != "")
//        //    {
//        //        txtcolum.Enabled = false;

//        //    }


//        //}
//        //else if(drpuom.SelectedItem.Text!="ROD")
//        //{
//        //    txtadsize1.Enabled = false;
//        //    txtadsize2.Enabled = false;

//        //}

//        if (hiddenuomdesc.Value == "CD")
//        {
//            if (txtadsize1.Text != "" && txtcolum.Text != "")
//            {
//                txtadsize2.Enabled = false;
//                txtadsize1.BackColor = System.Drawing.Color.White;
//                txtadsize2.BackColor = System.Drawing.Color.White;
//                txtcolum.BackColor = System.Drawing.Color.White;

//            }
//            else if (txtadsize1.Text != "" && txtadsize2.Text != "")
//            {
//                txtcolum.Enabled = false;
//                txtadsize1.BackColor = System.Drawing.Color.White;
//                txtadsize2.BackColor = System.Drawing.Color.White;
//                txtcolum.BackColor = System.Drawing.Color.White;

//            }


//        }
//        else if (hiddenuomdesc.Value != "CD")
//        {
//            txtadsize1.Enabled = false;
//            txtadsize2.Enabled = false;
//            if (hiddenuomdesc.Value == "ROL" || hiddenuomdesc.Value == "ROD")
//            {
//                Label1.Text = "No. Of Lines";
//                txtadsize1.BackColor = System.Drawing.Color.Gray;
//                txtadsize2.BackColor = System.Drawing.Color.Gray;
//                txtcolum.BackColor = System.Drawing.Color.Gray;
//                txtcolum.Enabled = false;


//            }
//            else if (hiddenuomdesc.Value == "ROW")
//            {
//                Label1.Text = "No. Of Words";
//                txtadsize1.BackColor = System.Drawing.Color.Gray;
//                txtadsize2.BackColor = System.Drawing.Color.Gray;
//                txtcolum.BackColor = System.Drawing.Color.Gray;
//                txtcolum.Enabled = false;
//            }
//            else if (hiddenuomdesc.Value == "ROC")
//            {
//                Label1.Text = "No. Of Words";
//                txtadsize1.BackColor = System.Drawing.Color.Gray;
//                txtadsize2.BackColor = System.Drawing.Color.Gray;
//                txtcolum.BackColor = System.Drawing.Color.Gray;
//                txtcolum.Enabled = false;
//            }

//        }
//        //2april
//        txtlogohei.Enabled = false;
//        txtlogowid.Enabled = false;
//        txtlogouomcode.Enabled = false;
//        //2april
//        txtreceiptdate.Enabled = false;

//        //saveormodify = "01";
//        string listpck = hiddenpackage.Value;
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "c1", "bindgridpkg('" + listpck + "')", true);           
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "cc", "showgridexecute()", true);

//        chkstatus(FlagStatus);
//        //2april
//        btnconfirm.Enabled = true;
//        btnshgrid.Enabled = true;
//        //2april
//        btnSave.Enabled = true;
//        btnSaveConfirm.Enabled = true;
//        btnQuery.Enabled = false;
        
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        //if (Session["compcode"] == null)
        //{
        //    //Response.Redirect("login.aspx");
        //    //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
        //    string sessionout = "Your Session Has Been Expired";
        //    AspNetMessageBox_close(sessionout);
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

        //    return;

        //}
        //saveormodify = "1";
        //hiddensavemod.Value = saveormodify;
        //fpnl = 0;
        ////2april
        //btnshgrid.Enabled = false;
        ////2april
        ///*new change 14 feb*/
        //drpadtype.SelectedValue = "CL0";
        //        get_pacakge_new.Enabled = true;
        //drpadtype.Enabled = false;
        ///////////////////////

        ///*change ankur*/
        //drpbillto_qbc.Enabled = false;
        ////////////////////////////
        //btnlogo.Enabled = false;
        //// btnupload.Enabled = false;
        //chkcontract.Enabled = false;
        //chkcontract.Checked = false;
        //txtciobookid.Text = "";
        ////  txtappby.Text = "";
        ////txtaudit.Text = "";
        //txtrono.Text = "";
        //txtrodate.Text = "";


        //drprostatus.SelectedValue = "0";
        //if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes")
        //{
        //    txtagency.Text = "";
        //}
        //txtclient.Text = "";

        //txtclientadd.Text = "";


        //txtprintremark.Text = "";
        //// drppackage.SelectedValue = "0";
        //txtinsertion.Text = "";
        //txtdummydate.Text = "";
        //txtrepeatingdate.Text = "";

        //drpadcategory.SelectedValue = "0";
        //drpadsubcategory.SelectedValue = "0";
        ////drpcolor.SelectedValue = "0";
        //drpuom.SelectedValue = "0";
        //drppageposition.SelectedValue = "0";
        //drpboxcodenew.SelectedValue = "0";
        //txtboxnonew.Text = "";
        //txtboxadd.Text = "";
        //txtboxchrg.Text = "";

        //txtcolum.Text = "";
        ////txtbillcolumn.Text = "";
        //////txtbillarea.Text = "" = "";
        //drpmatstat.Enabled = false;
        //drpmatstat.SelectedValue = "0";


        //txtcontractname.Text = "";


        //drppackage.SelectedValue = "0";
        //drppackagecopy.Items.Clear();

        //drpadcat3.Enabled = false;
        //drpadcat4.Enabled = false;
        //drpadcat3.Items.Clear();
        //drpadcat4.Items.Clear();

        //drpbgcolor.Enabled = false;
        ///*new change ankur 9 feb*/
        //drpcolortype.SelectedValue = "0";
        //drpcolortype.Enabled = false;
        ////////////////////////////

        //drpadcat5.Enabled = false;
        //drpadcat5.Items.Clear();
        //drpbgcolor.SelectedValue = "0";

        //drpbullet.Enabled = false;
        //drpbullet.SelectedValue = "0";


        //txtrono.Enabled = false;
        ////txtagency.Enabled = true;
        //txtagency.ReadOnly = false;
        //txtclient.Enabled = true;

        //btnlogo.Enabled = false;
        ////btnupload.Enabled = false;

        //txtciobookid.Enabled = true;
        //txtciobookid.ReadOnly = false;

        ///*new change ankur 24 feb*/
        //txtlogohei.Enabled = false;
        //txtlogohei.Text = "";
        //txtlogoname.Text = "";
        //drplogocolor.Enabled = false;
        //drplogocolor.SelectedValue = "0";

        ///////////////////////////////////

        //saveormodify = "01";
        //chkstatus(FlagStatus);

        //btnQuery.Enabled = false;
        //btnExecute.Enabled = true;
        //btnSave.Enabled = false;
        //btnSaveConfirm.Enabled = false;

        //txtreceipt.Enabled = true;
        //txtreceipt.ReadOnly = false;
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz2", "document.getElementById('tblinsert').innerHTML=''", true);

        
    }
    protected void btnlast_Click(object sender, EventArgs e)
    {

        //if (Session["compcode"] == null)
        //{
        //    //Response.Redirect("login.aspx");
        //    //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
        //    string sessionout = "Your Session Has Been Expired";
        //    AspNetMessageBox_close(sessionout);
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

        //    return;

        //}
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz8", "document.getElementById('tblinsert').innerHTML=''", true);
        //int count = executequery.Tables[0].Rows.Count - 1;
        //fpnl = count;
        //dateinsert getdatechk = new dateinsert();
        //txtbranch.Text = executequery.Tables[0].Rows[fpnl].ItemArray[1].ToString();
        //txtbookedby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[2].ToString();
        //txtprevbook.Text = executequery.Tables[0].Rows[fpnl].ItemArray[4].ToString();
        //string datetime = executequery.Tables[0].Rows[fpnl].ItemArray[0].ToString();
        //txtdatetime.Text = getdatechk.getDate(dateformat, datetime);
        //txtciobookid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[3].ToString();
        //hiddencioid.Value = txtciobookid.Text;
        ////txtappby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[5].ToString();
        //// txtaudit.Text = executequery.Tables[0].Rows[fpnl].ItemArray[6].ToString();
        //txtrono.Text = executequery.Tables[0].Rows[fpnl].ItemArray[7].ToString();
        //string ro_date = executequery.Tables[0].Rows[fpnl].ItemArray[8].ToString();
        //// txtrodate.Text = getdatechk.getDate(dateformat, ro_date);

        //if (ro_date == "1900/1/1" || ro_date == "1900/01/01" || ro_date == "" || ro_date == "01/01/1900" || ro_date == "1/1/1900" || ro_date == null)
        //{
        //    txtrodate.Text = "";
        //}
        //else
        //{
        //    txtrodate.Text = getdatechk.getDate(dateformat, ro_date);
        //}

        //if (executequery.Tables[0].Rows[0].ItemArray[11].ToString() == null || executequery.Tables[0].Rows[0].ItemArray[11].ToString() == "")
        //{
        //    drprostatus.SelectedValue = "0";
        //}
        //else
        //{
        //    drprostatus.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[11].ToString();
        //}


        //txtagency.Text = executequery.Tables[0].Rows[fpnl].ItemArray[89].ToString();
        ////drpagency_SelectedIndexChanged(sender, e);



        ////////////////////////////////////////////////////////
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == "" || (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString()))
        //{
        //    txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();
        //}
        //else
        //{

        //    txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() + "(" + executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString() + ")";
        //}
        ////txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();

        //txtclientadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[15].ToString();



        //txtprintremark.Text = executequery.Tables[0].Rows[fpnl].ItemArray[24].ToString();
        //string listpck = executequery.Tables[0].Rows[fpnl].ItemArray[25].ToString();
        //hiddenpackage.Value = listpck;
        ////////////////////this is to bind the package grid on what the value is saved in the database


        ////ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "c1", "bindgridpkg('" + listpck + "')", true);
        //DataSet dsexecut = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //    dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);
        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //        dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //    }
        //    else
        //    {
        //        NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();

        //        dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //    }



        //int i;


        ////for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        ////{
        ////    if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        ////    {
        ////        if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        ////        {

        ////            drppackage.Items.FindByValue(dsexecut.Tables[0].Rows[i].ItemArray[2].ToString()).Selected = true;
        ////            drppackage.Items.FindByValue("0").Selected = false;

        ////        }
        ////    }
        ////}

        //drppackagecopy.Items.Clear();
        //for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        //{
        //    if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //    {
        //        if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        //        {

        //            ListItem li;
        //            li = new ListItem();
        //            li.Text = dsexecut.Tables[0].Rows[i].ItemArray[1].ToString();
        //            li.Value = dsexecut.Tables[0].Rows[i].ItemArray[2].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drppackagecopy.Items.Add(li);

        //            arrfor_uom = li.Value.Split('@');
        //            /*new change ankur 27 feb*/
        //            foruom_temp = arrfor_uom[1];
        //            if (for_uom == "")
        //            {
        //                for_uom = foruom_temp;
        //            }
        //            else
        //            {
        //                for_uom = for_uom + "+" + foruom_temp;

        //            }

        //        }
        //    }
        //}




        //txtinsertion.Text = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //hiddeninsertion.Value = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //string start_date = executequery.Tables[0].Rows[fpnl].ItemArray[27].ToString();
        //txtdummydate.Text = getdatechk.getDate(dateformat, start_date);
        //txtrepeatingdate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[28].ToString();

        ///*new change ankur 15 feb*/
        //advcat(Session["compcode"].ToString());
        //binduom();


        //if (drpadcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString()) != null)
        //{
        //    hiddencatcode.Value = drpadcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString();
        //}
        //else
        //{
        //    hiddencatcode.Value = drpadcategory.SelectedValue = "0";
        //}
        /////////////////////////

        ///*change ankur*/
        //DataSet dscat = new DataSet();
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString() == "")
        //{
        //    drpadsubcategory.Items.Clear();
        //    hiddenad_subcat.Value = "";

        //}
        //else
        //{
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

        //        dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();

        //            dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

        //            dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //        }

        //    drpadsubcategory.Items.Clear();
        //    ListItem likasu;
        //    likasu = new ListItem();
        //    likasu.Text = "Select";
        //    likasu.Value = "0";
        //    drpadsubcategory.Items.Add(likasu);
        //    for (int k = 0; k < dscat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem liocat;
        //        liocat = new ListItem();
        //        liocat.Text = dscat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        liocat.Value = dscat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadsubcategory.Items.Add(liocat);
        //    }
        //}



        //////////////////////////////////////////////////////////////////

        //if (drpadsubcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString()) != null)
        //{
        //    drpadsubcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString();
        //}
        //else
        //{
        //    drpadsubcategory.SelectedValue = "0";
        //}
        //drpcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[32].ToString();

        ///*new change ankur 27 feb*/
        //DataSet ds_edituom = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //    ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());
        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //        ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //    }
        //    else
        //    {
        //        NewAdbooking.classmysql.BookingMaster binduom_ = new NewAdbooking.classmysql.BookingMaster();
        //        ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //    }

        //drpuom.Items.Clear();

        //drpuom.Items.Clear();
        //ListItem likasu2;
        //likasu2 = new ListItem();
        //likasu2.Text = "Select";
        //likasu2.Value = "0";
        //drpuom.Items.Add(likasu2);

        //for (int k = 0; k < ds_edituom.Tables[0].Rows.Count; k++)
        //{
        //    ListItem liocat2;
        //    liocat2 = new ListItem();
        //    liocat2.Text = ds_edituom.Tables[0].Rows[k].ItemArray[1].ToString();
        //    liocat2.Value = ds_edituom.Tables[0].Rows[k].ItemArray[0].ToString();
        //    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //    drpuom.Items.Add(liocat2);
        //}


        //for_uom = "";
        //foruom_temp = "";

        /////////////////////

        ///*new change ankur 15 feb*/
        //hiddenuomcode.Value = drpuom.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[33].ToString();
        ////////////

        //drppageposition.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[34].ToString();

        ////string adtype=drpadstype.SelectedValue;
        //txtadsize1.Text = executequery.Tables[0].Rows[fpnl].ItemArray[38].ToString();
        //txtadsize2.Text = executequery.Tables[0].Rows[fpnl].ItemArray[39].ToString();





        //txttotalarea.Text = executequery.Tables[0].Rows[fpnl].ItemArray[54].ToString();
        //txtcardrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[55].ToString();



        //txtgrossamt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();
        //hiddenprevamt.Value = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();
        //if (drpboxcodenew.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString()) != null)
        //{
        //    drpboxcodenew.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //}
        //else
        //{
        //    drpboxcodenew.SelectedValue = "0";
        //}
        //txtboxnonew.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();
        //txtboxadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[81].ToString();
        //txtboxchrg.Text = executequery.Tables[0].Rows[fpnl].ItemArray[132].ToString();

        //if (executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString() != null)
        //{
        //    txtsapid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString();
        //}
        //else
        //{
        //    txtsapid.Text = "";
        //}
        //// drpboxcode.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //// txtboxno.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();


        //txtcolum.Text = executequery.Tables[0].Rows[fpnl].ItemArray[84].ToString();

        //txtpaid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[92].ToString();
        //txtdealrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[93].ToString();


        //txtcontractname.Text = executequery.Tables[0].Rows[fpnl].ItemArray[96].ToString();
        //if (txtcontractname.Text == "")
        //{
        //    chkcontract.Checked = false;
        //}
        //else
        //{
        //    chkcontract.Checked = true;
        //}

        //hiddenreceiptno.Value = txtreceipt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[103].ToString();

        //////this is to bind the adscat3 drpdown



        //if (executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString() == "")
        //{
        //    drpadcat3.Items.Clear();
        //    hiddenadscat3.Value = "";

        //}
        //else
        //{

        //    DataSet dacat = new DataSet();
        //    drpadcat3.Items.Clear();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {

        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //        //////if 0 than bind adcat3 drop down 
        //        dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //            //////if 0 than bind adcat3 drop down 
        //            //dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //            //////if 2 than bind adcat2 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //            //////if 0 than bind adcat3 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //        }
        //    ////////////////////////////////////////////////////////////////
        //    drpadcat3.Items.Clear();
        //    ListItem lika;
        //    lika = new ListItem();
        //    lika.Text = "Client";
        //    lika.Value = "client";
        //    drpadcat3.Items.Add(lika);
        //    for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem lio;
        //        lio = new ListItem();
        //        lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadcat3.Items.Add(lio);
        //    }


        //}

        //if (drpadcat3.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString()) != null)
        //{
        //    hiddenadscat3.Value = drpadcat3.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString();
        //}
        //else
        //{
        //    hiddenadscat3.Value = drpadcat3.SelectedValue = "0";
        //}
        //////////////////////this is to bind the adcat4 drp down
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString() == "")
        //{
        //    drpadcat4.Items.Clear();
        //    hiddenadscat4.Value = "";

        //}
        //else
        //{
        //    DataSet dacat = new DataSet();
        //    drpadcat4.Items.Clear();
        //    ////////////when 1 than bind the adscat4 drp down
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {

        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();


        //        //////if 0 than bind adcat3 drop down 
        //        dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {

        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();


        //            //////if 0 than bind adcat3 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();


        //            //////if 0 than bind adcat3 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //        }
        //    ////////////////////////////////////////////////////////////////

        //    ListItem liks;
        //    liks = new ListItem();
        //    liks.Text = "Select";
        //    liks.Value = "0";
        //    drpadcat4.Items.Add(liks);
        //    for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem lio;
        //        lio = new ListItem();
        //        lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadcat4.Items.Add(lio);
        //    }

        //}

        //if (drpadcat4.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString()) != null)
        //{
        //    hiddenadscat4.Value = drpadcat4.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString();
        //}
        //else
        //{
        //    hiddenadscat4.Value = drpadcat4.SelectedValue = "0";
        //}

        /////bind adcat5 drpdown
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString() == "")
        //{
        //    drpadcat5.Items.Clear();
        //    hiddenadscat5.Value = "";
        //}
        //else
        //{
        //    ////////////when 1 than bind the adscat4 drp down
        //    DataSet dacat = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //        //////if 2 than bind adcat2 drop down 
        //        dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //            //////if 2 than bind adcat2 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //            //////if 2 than bind adcat2 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");


        //        }
        //    ////////////////////////////////////////////////////////////////
        //    drpadcat5.Items.Clear();
        //    ListItem liks;
        //    liks = new ListItem();
        //    liks.Text = "Select";
        //    liks.Value = "0";
        //    drpadcat5.Items.Add(liks);
        //    for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem lio;
        //        lio = new ListItem();
        //        lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadcat5.Items.Add(lio);
        //    }
        //}

        //if (drpadcat4.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString()) != null)
        //{
        //    hiddenadscat5.Value = drpadcat5.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString();
        //}
        //else
        //{
        //    hiddenadscat5.Value = drpadcat5.SelectedValue = "0";
        //}


        ////////bind the bg color drp down 

        ///*new change ankur 15 feb*/
        //string combin_name = "";
        ////drpcolortype.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[124].ToString();
        //if (Session["bg_colorpub"].ToString() == "yes")
        //{
        //    ////this is to get the combin_desc
        //    for (int z = 0; z < drppackagecopy.Items.Count; z++)
        //    {
        //        string[] arr = drppackagecopy.Items[z].Value.Split('@');

        //        if (combin_name != "")
        //        {
        //            combin_name = combin_name + "+" + arr[1];
        //        }
        //        else
        //        {
        //            combin_name = arr[1];
        //        }

        //    }
        //    DataSet dsget = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //        dsget = bind.bindbgandfont(drpadcategory.SelectedValue, combin_name);
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //            dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
        //            dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);
        //        }
        //    //////bind colortype

        //    drpcolortype.Items.Clear();
        //    ListItem colty;
        //    colty = new ListItem();
        //    colty.Text = "Select Color type";
        //    colty.Value = "0";
        //    drpcolortype.Items.Add(colty);
        //    for (int k = 0; k < dsget.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem col1;
        //        col1 = new ListItem();
        //        col1.Text = dsget.Tables[0].Rows[k].ItemArray[1].ToString();
        //        col1.Value = dsget.Tables[0].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpcolortype.Items.Add(col1);
        //    }
        //    /*new change ankur 10 feb*/
        //    if (executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString() != "")
        //    {
        //        drpcolortype.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString();
        //    }
        //    else
        //    {
        //        drpcolortype.Items.Clear();
        //    }

        //    /////bind bg color



        //    drpbgcolor.Items.Clear();
        //    ListItem liksabg;
        //    liksabg = new ListItem();
        //    liksabg.Text = "Select Bg color";
        //    liksabg.Value = "0";
        //    drpbgcolor.Items.Add(liksabg);
        //    for (int k = 0; k < dsget.Tables[1].Rows.Count; k++)
        //    {
        //        ListItem liobg;
        //        liobg = new ListItem();
        //        liobg.Text = dsget.Tables[1].Rows[k].ItemArray[1].ToString();
        //        liobg.Value = dsget.Tables[1].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpbgcolor.Items.Add(liobg);
        //    }
        //    /*new change ankur 10 feb*/
        //    if (executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString() != "")
        //    {
        //        drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //    }
        //    else
        //    {
        //        drpbgcolor.Items.Clear();
        //    }


        //    ////bind bullet


        //    drpbullet.Items.Clear();
        //    ListItem bul;
        //    bul = new ListItem();
        //    bul.Text = "Select Bg color";
        //    bul.Value = "0";
        //    drpbullet.Items.Add(bul);
        //    for (int k = 0; k < dsget.Tables[2].Rows.Count; k++)
        //    {
        //        ListItem bul1;
        //        bul1 = new ListItem();
        //        bul1.Text = dsget.Tables[2].Rows[k].ItemArray[1].ToString();
        //        bul1.Value = dsget.Tables[2].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpbullet.Items.Add(bul1);
        //    }
        //    /*new change ankur 10 feb*/
        //    if (executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString() != "")
        //    {
        //        drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //    }
        //    else
        //    {
        //        drpbullet.Items.Clear();
        //    }

        //}
        //else
        //{
        //    if (drpbgcolor.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString()) != null)
        //    {
        //        drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //    }
        //    if (drpbullet.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString()) != null)
        //    {
        //        drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //    }
        //}
        //hiddencolortype.Value = drpcolortype.SelectedValue;
        //hiddenbgcolor.Value = drpbgcolor.SelectedValue;
        //hiddenbullet.Value = drpbullet.SelectedValue;
        //////////////////////////////////////////////////////////////////

        //drpmatstat.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[120].ToString();
        //txtreceiptdate.Text = getdatechk.getDate(dateformat, executequery.Tables[0].Rows[fpnl].ItemArray[121].ToString());
        ///*   change  */
        //drpregion.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[122].ToString();
        //drpvarient.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[123].ToString();


        ///*change ankur*/
        /////////this is to bind the bill to dropdown as agency and client////////
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    bindagencybillto(ds_billto);
        //}
        //else
        //{
        //    bindagencybillto(ds_billto);
        //}
        //if (drpbillto_qbc.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString()) != null)
        //{
        //    drpbillto_qbc.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString();
        //}
       
        /////////////////////////////////////////////////////////////////////////////
        //hiddenbillto.Value = drpbillto_qbc.SelectedValue;


        ///*new change 15 feb*/

        //bindpackage();


        /////
        //hiddenuomdesc.Value = executequery.Tables[0].Rows[fpnl].ItemArray[125].ToString();
        ///*new change ankur 24 feb*/
        //hiddenlogomatter.Value = executequery.Tables[0].Rows[fpnl].ItemArray[126].ToString();
        //txtlogohei.Text = executequery.Tables[0].Rows[fpnl].ItemArray[127].ToString();
        //txtlogowid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[128].ToString();
        //drplogocolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[129].ToString();
        //txtlogouomcode.Text = executequery.Tables[0].Rows[fpnl].ItemArray[130].ToString();
        //hiddenlogocode.Value = executequery.Tables[0].Rows[fpnl].ItemArray[131].ToString();
        //////////////////////////////

        ////   ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "ca", "showcardinfo('" + executequery.Tables[0].Rows[0].ItemArray[61].ToString() + "')", true);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "cc", "showgridexecute()", true);
        //btnfirst.Enabled = true;
        //btnprevious.Enabled = true;
        //btnlast.Enabled = false;
        //btnnext.Enabled = false;
        //if (hiddenuomdesc.Value == "CD")
        //{
        //    if (txtadsize1.Text != "" && txtcolum.Text != "")
        //    {
        //        txtadsize2.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }
        //    else if (txtadsize1.Text != "" && txtadsize2.Text != "")
        //    {
        //        txtcolum.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }


        //}
        //else if (hiddenuomdesc.Value != "CD")
        //{
        //    txtadsize1.Enabled = false;
        //    txtadsize2.Enabled = false;
        //    if (hiddenuomdesc.Value == "ROL" || hiddenuomdesc.Value == "ROD")
        //    {
        //        Label1.Text = "No. Of Lines";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;


        //    }
        //    else if (hiddenuomdesc.Value == "ROW")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }
        //    else if (hiddenuomdesc.Value == "ROC")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }

        //}
        //if (confirm_Permission == "1" && drprostatus.SelectedValue == "2")
        //{

        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj21", "document.getElementById('btnconfirm').disabled=false;", true);
        //}

    }
    protected void btnfirst_Click(object sender, EventArgs e)
    {
        //if (Session["compcode"] == null)
        //{
        //    //Response.Redirect("login.aspx");
        //    //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
        //    string sessionout = "Your Session Has Been Expired";
        //    AspNetMessageBox_close(sessionout);
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

        //    return;

        //}
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz4", "document.getElementById('tblinsert').innerHTML=''", true);
        //fpnl = 0;
        //dateinsert getdatechk = new dateinsert();

        //txtbranch.Text = executequery.Tables[0].Rows[fpnl].ItemArray[1].ToString();
        //txtbookedby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[2].ToString();
        //txtprevbook.Text = executequery.Tables[0].Rows[fpnl].ItemArray[4].ToString();
        //string datetime = executequery.Tables[0].Rows[fpnl].ItemArray[0].ToString();
        //txtdatetime.Text = getdatechk.getDate(dateformat, datetime);
        //txtciobookid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[3].ToString();
        //hiddencioid.Value = txtciobookid.Text;
        ////txtappby.Text = executequery.Tables[0].Rows[fpnl].ItemArray[5].ToString();
        //// txtaudit.Text = executequery.Tables[0].Rows[fpnl].ItemArray[6].ToString();
        //txtrono.Text = executequery.Tables[0].Rows[fpnl].ItemArray[7].ToString();
        //string ro_date = executequery.Tables[0].Rows[fpnl].ItemArray[8].ToString();
        ////txtrodate.Text = getdatechk.getDate(dateformat, ro_date);

        //if (ro_date == "1900/1/1" || ro_date == "1900/01/01" || ro_date == "" || ro_date == "01/01/1900" || ro_date == "1/1/1900" || ro_date == null)
        //{
        //    txtrodate.Text = "";
        //}
        //else
        //{
        //    txtrodate.Text = getdatechk.getDate(dateformat, ro_date);
        //}

        //if (executequery.Tables[0].Rows[0].ItemArray[11].ToString() == null || executequery.Tables[0].Rows[0].ItemArray[11].ToString() == "")
        //{
        //    drprostatus.SelectedValue = "0";
        //}
        //else
        //{
        //    drprostatus.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[11].ToString();
        //}


        //txtagency.Text = executequery.Tables[0].Rows[fpnl].ItemArray[89].ToString();
        ////drpagency_SelectedIndexChanged(sender, e);




        ////////////////////////////////////////////////////////
        ////2april
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == "" || (executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() == executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString()))
        //{
        //    txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();
        //}
        //else
        //{

        //    txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[111].ToString() + "(" + executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString() + ")";
        //}
        ////2april
        ////txtclient.Text = executequery.Tables[0].Rows[fpnl].ItemArray[14].ToString();

        //txtclientadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[15].ToString();


        //txtprintremark.Text = executequery.Tables[0].Rows[fpnl].ItemArray[24].ToString();
        //string listpck = executequery.Tables[0].Rows[fpnl].ItemArray[25].ToString();
        //hiddenpackage.Value = listpck;
        ////////////////////this is to bind the package grid on what the value is saved in the database


        //////ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "c1", "bindgridpkg('" + listpck + "')", true);
        //DataSet dsexecut = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //    dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);
        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //        dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //    }
        //    else
        //    {
        //        NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();

        //        dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);

        //    }


        //int i;




        ////////this is to bind the drppackagepck
        //drppackagecopy.Items.Clear();
        //for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        //{
        //    if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //    {
        //        if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        //        {

        //            ListItem li;
        //            li = new ListItem();
        //            li.Text = dsexecut.Tables[0].Rows[i].ItemArray[1].ToString();
        //            li.Value = dsexecut.Tables[0].Rows[i].ItemArray[2].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drppackagecopy.Items.Add(li);
        //            arrfor_uom = li.Value.Split('@');
        //            /*new change ankur 27 feb*/
        //            foruom_temp = arrfor_uom[1];
        //            if (for_uom == "")
        //            {
        //                for_uom = foruom_temp;
        //            }
        //            else
        //            {
        //                for_uom = for_uom + "+" + foruom_temp;

        //            }

        //        }
        //    }
        //}








        //txtinsertion.Text = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //hiddeninsertion.Value = executequery.Tables[0].Rows[fpnl].ItemArray[26].ToString();
        //string start_date = executequery.Tables[0].Rows[fpnl].ItemArray[27].ToString();
        //txtdummydate.Text = getdatechk.getDate(dateformat, start_date);
        //txtrepeatingdate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[28].ToString();

        ///*new change ankur 15 feb*/
        //advcat(Session["compcode"].ToString());
        //binduom();

        //if (drpadcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString()) != null)
        //{
        //    hiddencatcode.Value = drpadcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[30].ToString();
        //}
        //else
        //{
        //    hiddencatcode.Value = drpadcategory.SelectedValue = "0";
        //}
        /////////////////////////

        ///*change ankur*/
        //DataSet dscat = new DataSet();
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString() == "")
        //{
        //    drpadsubcategory.Items.Clear();
        //    hiddenad_subcat.Value = "";

        //}
        //else
        //{
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

        //        dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();

        //            dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

        //            dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //        }

        //    drpadsubcategory.Items.Clear();
        //    ListItem likasu;
        //    likasu = new ListItem();
        //    likasu.Text = "Select";
        //    likasu.Value = "0";
        //    drpadsubcategory.Items.Add(likasu);
        //    for (int k = 0; k < dscat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem liocat;
        //        liocat = new ListItem();
        //        liocat.Text = dscat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        liocat.Value = dscat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadsubcategory.Items.Add(liocat);
        //    }
        //}



        //////////////////////////////////////////////////////////////////
        //if (drpadsubcategory.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString()) != null)
        //{
        //    drpadsubcategory.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString();
        //}
        //else
        //{
        //    drpadsubcategory.SelectedValue = "0";
        //}
        //drpcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[32].ToString();

        ///*new change ankur 27 feb*/
        //DataSet ds_edituom = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{

        //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //    ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());
        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //        ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //    }
        //    else
        //    {
        //        NewAdbooking.classmysql.BookingMaster binduom_ = new NewAdbooking.classmysql.BookingMaster();
        //        ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //    }

        //drpuom.Items.Clear();

        //drpuom.Items.Clear();
        //ListItem likasu2;
        //likasu2 = new ListItem();
        //likasu2.Text = "Select";
        //likasu2.Value = "0";
        //drpuom.Items.Add(likasu2);

        //for (int k = 0; k < ds_edituom.Tables[0].Rows.Count; k++)
        //{
        //    ListItem liocat2;
        //    liocat2 = new ListItem();
        //    liocat2.Text = ds_edituom.Tables[0].Rows[k].ItemArray[1].ToString();
        //    liocat2.Value = ds_edituom.Tables[0].Rows[k].ItemArray[0].ToString();
        //    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //    drpuom.Items.Add(liocat2);
        //}


        //for_uom = "";
        //foruom_temp = "";

        /////////////////////

        ///*new change ankur 15 feb*/
        //hiddenuomcode.Value = drpuom.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[33].ToString();
        /////////////////////
        //drppageposition.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[34].ToString();

        ////string adtype=drpadstype.SelectedValue;
        //txtadsize1.Text = executequery.Tables[0].Rows[fpnl].ItemArray[38].ToString();
        //txtadsize2.Text = executequery.Tables[0].Rows[fpnl].ItemArray[39].ToString();


        //txttotalarea.Text = executequery.Tables[0].Rows[fpnl].ItemArray[54].ToString();
        //txtcardrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[55].ToString();


        //txtgrossamt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();
        //hiddenprevamt.Value = executequery.Tables[0].Rows[fpnl].ItemArray[75].ToString();

        //if (drpboxcodenew.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString()) != null)
        //        {
        //            drpboxcodenew.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        //        }
        //        else
        //        {
        //            drpboxcodenew.SelectedValue = "0";
        //        }
        //        txtboxnonew.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();
        //        txtboxadd.Text = executequery.Tables[0].Rows[fpnl].ItemArray[81].ToString();
        //        txtboxchrg.Text = executequery.Tables[0].Rows[fpnl].ItemArray[132].ToString();

        //        if (executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString() != null)
        //        {
        //            txtsapid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[133].ToString();
        //        }
        //        else
        //        {
        //            txtsapid.Text = "";
        //        }
        ////  drpboxcode.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[77].ToString();
        ////  txtboxno.Text = executequery.Tables[0].Rows[fpnl].ItemArray[78].ToString();


        //txtcolum.Text = executequery.Tables[0].Rows[fpnl].ItemArray[84].ToString();

        //txtpaid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[92].ToString();
        //txtdealrate.Text = executequery.Tables[0].Rows[fpnl].ItemArray[93].ToString();


        //txtcontractname.Text = executequery.Tables[0].Rows[fpnl].ItemArray[96].ToString();
        //if (txtcontractname.Text == "")
        //{
        //    chkcontract.Checked = false;
        //}
        //else
        //{
        //    chkcontract.Checked = true;
        //}

        //hiddenreceiptno.Value = txtreceipt.Text = executequery.Tables[0].Rows[fpnl].ItemArray[103].ToString();

        //////this is to bind the adscat3 drpdown



        //if (executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString() == "")
        //{
        //    drpadcat3.Items.Clear();
        //    hiddenadscat3.Value = "";

        //}
        //else
        //{
        //    DataSet dacat = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();


        //        dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //    }
        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();


        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();


        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //        }
        //    ////////////////////////////////////////////////////////////////
        //    drpadcat3.Items.Clear();
        //    ListItem lika;
        //    lika = new ListItem();
        //    lika.Text = "Select";
        //    lika.Value = "0";
        //    drpadcat3.Items.Add(lika);
        //    for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem lio;
        //        lio = new ListItem();
        //        lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadcat3.Items.Add(lio);
        //    }


        //}

        //if (drpadcat3.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString()) != null)
        //{
        //    hiddenadscat3.Value = drpadcat3.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString();
        //}
        //else
        //{
        //    hiddenadscat3.Value = drpadcat3.SelectedValue = "0";
        //}
        //////////////////////this is to bind the adcat4 drp down
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString() == "")
        //{
        //    drpadcat4.Items.Clear();
        //    hiddenadscat4.Value = "";

        //}
        //else
        //{
        //    ////////////when 1 than bind the adscat4 drp down
        //    DataSet dacat = new DataSet();

        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //        dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();


        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");

        //        }
        //    ////////////////////////////////////////////////////////////////
        //    drpadcat4.Items.Clear();
        //    ListItem liks;
        //    liks = new ListItem();
        //    liks.Text = "Select";
        //    liks.Value = "0";
        //    drpadcat4.Items.Add(liks);
        //    for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem lio;
        //        lio = new ListItem();
        //        lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadcat4.Items.Add(lio);
        //    }

        //}

        //if (drpadcat4.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString()) != null)
        //{
        //    hiddenadscat4.Value = drpadcat4.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString();
        //}
        //else
        //{
        //    hiddenadscat4.Value = drpadcat4.SelectedValue = "0";
        //}

        ///*change ankur*/


        /////bind adcat5 drpdown
        //if (executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString() == "")
        //{
        //    drpadcat5.Items.Clear();
        //    hiddenadscat5.Value = "";
        //}
        //else
        //{
        //    ////////////when 1 than bind the adscat4 drp down
        //    DataSet dacat = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //        //////if 2 than bind adcat2 drop down 
        //        dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //            //////if 2 than bind adcat2 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //            //////if 2 than bind adcat2 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[fpnl].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //        }
        //    ////////////////////////////////////////////////////////////////
        //    drpadcat5.Items.Clear();
        //    ListItem liks;
        //    liks = new ListItem();
        //    liks.Text = "Select";
        //    liks.Value = "0";
        //    drpadcat4.Items.Add(liks);
        //    for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem lio;
        //        lio = new ListItem();
        //        lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //        lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpadcat5.Items.Add(lio);
        //    }
        //}

        //if (drpadcat5.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString()) != null)
        //{
        //    hiddenadscat5.Value = drpadcat5.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[106].ToString();
        //}
        //else
        //{
        //    hiddenadscat5.Value = drpadcat5.SelectedValue = "0";
        //}


        ////////bind the bg color drp down 


        ///*new change ankur 15 feb*/
        //string combin_name = "";
        ////drpcolortype.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[124].ToString();
        //if (Session["bg_colorpub"].ToString() == "yes")
        //{
        //    ////this is to get the combin_desc
        //    for (int z = 0; z < drppackagecopy.Items.Count; z++)
        //    {
        //        string[] arr = drppackagecopy.Items[z].Value.Split('@');

        //        if (combin_name != "")
        //        {
        //            combin_name = combin_name + "+" + arr[1];
        //        }
        //        else
        //        {
        //            combin_name = arr[1];
        //        }

        //    }
        //    DataSet dsget = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //        dsget = bind.bindbgandfont(drpadcategory.SelectedValue, combin_name);
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //            dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);



        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
        //            dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);
        //        }
        //    //////bind colortype

        //    drpcolortype.Items.Clear();
        //    ListItem colty;
        //    colty = new ListItem();
        //    colty.Text = "Select Color type";
        //    colty.Value = "0";
        //    drpcolortype.Items.Add(colty);
        //    for (int k = 0; k < dsget.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem col1;
        //        col1 = new ListItem();
        //        col1.Text = dsget.Tables[0].Rows[k].ItemArray[1].ToString();
        //        col1.Value = dsget.Tables[0].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpcolortype.Items.Add(col1);
        //    }
        //    /*new change ankur 10 feb*/
        //    if (executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString() != "")
        //    {
        //        drpcolortype.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[124].ToString();
        //    }
        //    else
        //    {
        //        drpcolortype.Items.Clear();
        //    }

        //    /////bind bg color



        //    drpbgcolor.Items.Clear();
        //    ListItem liksabg;
        //    liksabg = new ListItem();
        //    liksabg.Text = "Select Bg color";
        //    liksabg.Value = "0";
        //    drpbgcolor.Items.Add(liksabg);
        //    for (int k = 0; k < dsget.Tables[1].Rows.Count; k++)
        //    {
        //        ListItem liobg;
        //        liobg = new ListItem();
        //        liobg.Text = dsget.Tables[1].Rows[k].ItemArray[1].ToString();
        //        liobg.Value = dsget.Tables[1].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpbgcolor.Items.Add(liobg);
        //    }
        //    /*new change ankur 10 feb*/
        //    if (executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString() != "")
        //    {
        //        drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //    }
        //    else
        //    {
        //        drpbgcolor.Items.Clear();
        //    }


        //    ////bind bullet


        //    drpbullet.Items.Clear();
        //    ListItem bul;
        //    bul = new ListItem();
        //    bul.Text = "Select Eye catcher";
        //    bul.Value = "0";
        //    drpbullet.Items.Add(bul);
        //    for (int k = 0; k < dsget.Tables[2].Rows.Count; k++)
        //    {
        //        ListItem bul1;
        //        bul1 = new ListItem();
        //        bul1.Text = dsget.Tables[2].Rows[k].ItemArray[1].ToString();
        //        bul1.Value = dsget.Tables[2].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpbullet.Items.Add(bul1);
        //    }
        //    /*new change ankur 10 feb*/
        //    if (executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString() != "")
        //    {
        //        drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //    }
        //    else
        //    {
        //        drpbullet.Items.Clear();
        //    }

        //}
        //else
        //{
        //    if (drpbgcolor.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString()) != null)
        //    {
        //        drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        //    }
        //    if (drpbullet.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString()) != null)
        //    {
        //        drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();
        //    }
        //}
        //hiddencolortype.Value = drpcolortype.SelectedValue;
        //hiddenbgcolor.Value = drpbgcolor.SelectedValue;
        //hiddenbullet.Value = drpbullet.SelectedValue;
        //////////////////////////////////////////////////////////////////
        ////drpbgcolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[107].ToString();
        ////drpbullet.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[108].ToString();

        //drpmatstat.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[120].ToString();
        //txtreceiptdate.Text = getdatechk.getDate(dateformat, executequery.Tables[0].Rows[fpnl].ItemArray[121].ToString());
        ///*   change  */
        //drpregion.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[122].ToString();
        //drpvarient.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[123].ToString();

        ///*change ankur*/
        /////////this is to bind the bill to dropdown as agency and client////////
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    bindagencybillto(ds_billto);
        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        bindagencybillto(ds_billto);
        //    }
        //    else
        //    {
        //        bindagencybillto(ds_billto);
        //    }


        //if (drpbillto_qbc.Items.FindByValue(executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString()) != null)
        //{
        //    drpbillto_qbc.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[64].ToString();
        //}
        /////////////////////////////////////////////////////////////////////////////
        //hiddenbillto.Value = drpbillto_qbc.SelectedValue;


        ///*new change 15 feb*/

        //bindpackage();

        ///*new change ankur 18 feb*/
        //hiddenuomdesc.Value = executequery.Tables[0].Rows[fpnl].ItemArray[125].ToString();


        /////
        ///*new change ankur 24 feb*/
        //hiddenlogomatter.Value = executequery.Tables[0].Rows[fpnl].ItemArray[126].ToString();
        //txtlogohei.Text = executequery.Tables[0].Rows[fpnl].ItemArray[127].ToString();
        //txtlogowid.Text = executequery.Tables[0].Rows[fpnl].ItemArray[128].ToString();
        //drplogocolor.SelectedValue = executequery.Tables[0].Rows[fpnl].ItemArray[129].ToString();
        //txtlogouomcode.Text = executequery.Tables[0].Rows[fpnl].ItemArray[130].ToString();
        //hiddenlogocode.Value = executequery.Tables[0].Rows[fpnl].ItemArray[131].ToString();
        //////////////////////////////

        //// ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "ca", "showcardinfo('" + executequery.Tables[0].Rows[0].ItemArray[61].ToString() + "')", true);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "cc", "showgridexecute()", true);
        //updateStatus();

        //btnfirst.Enabled = false;
        //btnprevious.Enabled = false;
        //if (hiddenuomdesc.Value == "CD")
        //{
        //    if (txtadsize1.Text != "" && txtcolum.Text != "")
        //    {
        //        txtadsize2.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }
        //    else if (txtadsize1.Text != "" && txtadsize2.Text != "")
        //    {
        //        txtcolum.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }


        //}
        //else if (hiddenuomdesc.Value != "CD")
        //{
        //    txtadsize1.Enabled = false;
        //    txtadsize2.Enabled = false;
        //    if (hiddenuomdesc.Value == "ROL" || hiddenuomdesc.Value == "ROD")
        //    {
        //        Label1.Text = "No. Of Lines";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;


        //    }
        //    else if (hiddenuomdesc.Value == "ROW")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }
        //    else if (hiddenuomdesc.Value == "ROC")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }

        //}
        //if (confirm_Permission == "1" && drprostatus.SelectedValue == "2")
        //{

        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj21", "document.getElementById('btnconfirm').disabled=false;", true);
        //}
    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        //if (Session["compcode"] == null)
        //{
        //    //Response.Redirect("login.aspx");
        //    //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
        //    string sessionout = "Your Session Has Been Expired";
        //    AspNetMessageBox_close(sessionout);
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

        //    return;

        //}
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "document.getElementById('btnlogoupload').disabled=true", true);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz3", "document.getElementById('tblinsert').innerHTML=''", true);
        //saveormodify = "1";
        //hiddensavemod.Value = saveormodify;
        ///*change ankur*/
        //drpbillto_qbc.Enabled = false;
        /////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////
        //btnlogoupload.Enabled = false;
        //btnlogo.Enabled = false;
        //chkcontract.Checked = false;
        //chkcontract.Enabled = false;
        ////btnupload.Enabled = false;


        //txtciobookid.ReadOnly = true;
        //// txtappby.Enabled = true;
        ////txtaudit.Enabled = true;
        //txtrono.Enabled = false;
        //txtrodate.Enabled = false;


        //drprostatus.Enabled = false;
        //txtagency.ReadOnly = true;
        //txtclient.Enabled = false;
        //// txtagencyaddress.Enabled = true;
        //txtclientadd.Enabled = false;

        //txtprintremark.Enabled = false;
        //drppackage.Enabled = false;
        //txtinsertion.Enabled = false;
        //txtdummydate.Enabled = false;
        //txtrepeatingdate.Enabled = false;

        //drpadcategory.Enabled = false;
        //chkall.Enabled = false;
        //drpadsubcategory.Enabled = false;
        //drpcolor.Enabled = false;
        //drpuom.Enabled = false;
        //drppageposition.Enabled = false;

        //drpboxcodenew.Enabled = false;
        ////txtboxadd.Enabled = false;

        //txtdatetime.ReadOnly = true;
        //txtrepeatingdate.Enabled = false;

        //txtadsize2.Enabled = false;
        //txtadsize1.Enabled = false;
        ////txttotalarea.Enabled = false;
        //txttotalarea.ReadOnly = true;


        ////   drpboxcode.Enabled = false;


        ////txtgrossamt.Enabled = false;
        //txtgrossamt.ReadOnly = true;


        //drpregion.Enabled = false;

        //txtinsertion.Enabled = false;

        //txtcolum.Enabled = false;

        //// txtboxno.Enabled = false;

        /////////////////////////
        //txtcontractname.Enabled = false;


        //btncopy.Enabled = false;
        //btndel.Enabled = false;
        //btnlogo.Enabled = false;

        //drpmatstat.Enabled = false;
        //txtreceiptdate.Enabled = false;




        /////////////////////////////////////////////////////////////////////////////

        //if (hiddenaudit.Value != "")
        //{
        //    txtciobookid.Text = hiddenaudit.Value;
        //}
        //string ciobookid = txtciobookid.Text;
        //gciobookid = ciobookid;
        //string docno = "";
        //gdockitno = docno;
        //string keyno = "";
        //gkeyno = keyno;
        //string rono = txtrono.Text;
        //grono = rono;

        //string agencycod = txtagency.Text;
        
        //string agencycode = "";

        //gagencyscode = agencycode;

        ///*new change ankur 15 feb*/
        //drpvarient.Enabled = false;
        //drpadtype.Enabled = false;
        /////////////////////////////

        //////for client

        //////////////////////////////////////


        //string clientcode = txtclient.Text;
        //string client = "";
        /////this is to split and get the client code

        //if (clientcode.IndexOf("(".ToString()) > 0 && clientcode != "")
        //{
        //    //clientcode.IndexOf(
        //    char[] splitterclie = { '(' };
        //    string[] myarray1 = clientcode.Split(splitterclie);
        //    client = myarray1[1];
        //    client = client.Replace(")", null);

        //    /////this is to chk whether this code exixts in the database if exists than it is a register client else
        //    ///it is walkinn client
        //    ///
        //    DataSet dcl = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //        dcl = chkclient.forwalkclient(client, Session["compcode"].ToString());
        //    }

        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //            dcl = chkclient.forwalkclient(client, Session["compcode"].ToString());

        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster chkclient = new NewAdbooking.classmysql.BookingMaster();
        //            dcl = chkclient.forwalkclient(client, Session["compcode"].ToString());
        //        }
        //    if (dcl.Tables[0].Rows.Count > 0)
        //    {

        //    }
        //    else
        //    {
        //        client = clientcode;
        //    }

        //}
        //else
        //{

        //    client = clientcode;
        //}
        //gclient = client;
        //////////////////////////////////////////////////////////////////////////////////////////
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //    executequery = execute.executebookingqbc(Session["compcode"].ToString(), ciobookid, docno, keyno, rono, agencycode, client, drpadtype.SelectedValue);

        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //        executequery = execute.executebookingqbc(Session["compcode"].ToString(), txtreceipt.Text, docno, keyno, rono, agencycode, client, drpadtype.SelectedValue);


        //    }
        //    else
        //    {
        //        NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
        //        executequery = execute.executebookingqbc(Session["compcode"].ToString(), ciobookid, docno, keyno, rono, agencycode, client, drpadtype.SelectedValue);

        //    }
        //dateinsert getdatechk = new dateinsert();
        //if (executequery.Tables[0].Rows.Count > 0)
        //{

        //    txtbranch.Text = executequery.Tables[0].Rows[0].ItemArray[1].ToString();
        //    txtbookedby.Text = executequery.Tables[0].Rows[0].ItemArray[2].ToString();
        //    txtprevbook.Text = executequery.Tables[0].Rows[0].ItemArray[4].ToString();
        //    string datetime = executequery.Tables[0].Rows[0].ItemArray[0].ToString();
        //    txtdatetime.Text = getdatechk.getDate(dateformat, datetime);
        //    if (dateformat == "mm/dd/yyyy" && txtdatetime.Text != "")
        //    {
        //        string[] arr = txtdatetime.Text.Split('/');
        //        string dd = arr[0];
        //        string mm = arr[1];
        //        string yy = arr[2];
        //        txtdatetime.Text = mm + "/" + dd + "/" + yy;


        //    }
           
           
        //    txtciobookid.Text = executequery.Tables[0].Rows[0].ItemArray[3].ToString();
        //    hiddencioid.Value = txtciobookid.Text;
        //    //txtappby.Text = executequery.Tables[0].Rows[0].ItemArray[5].ToString();
        //    // txtaudit.Text = executequery.Tables[0].Rows[0].ItemArray[6].ToString();
        //    txtrono.Text = executequery.Tables[0].Rows[0].ItemArray[7].ToString();
        //    string ro_date = executequery.Tables[0].Rows[0].ItemArray[8].ToString();
        //    if (ro_date == "1900/1/1" || ro_date == "1900/01/01" || ro_date == "" || ro_date == "01/01/1900" || ro_date == "1/1/1900" || ro_date == null)
        //    {
        //        txtrodate.Text = "";
        //    }
        //    else
        //    {
        //        txtrodate.Text = getdatechk.getDate(dateformat, ro_date);
        //    }

        //    if (executequery.Tables[0].Rows[0].ItemArray[11].ToString() == null || executequery.Tables[0].Rows[0].ItemArray[11].ToString() == "")
        //    {
        //        drprostatus.SelectedValue = "0";
        //    }
        //    else
        //    {
        //        if (hiddencopy.Value == "copy")
        //        {
        //            drprostatus.SelectedValue = "2";
        //        }
        //        else
        //        {
        //            drprostatus.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[11].ToString();
        //        }
        //    }
        //    txtagency.Text = executequery.Tables[0].Rows[0].ItemArray[89].ToString();
        //    hiddenagencynew.Value = txtagency.Text;
        //    //drpagency_SelectedIndexChanged(sender, e);

        //    ///////////////this is to bind the subagency drop down


        //    //////////////////////////////////////////////////////
        //    //2april
        //    if (executequery.Tables[0].Rows[0].ItemArray[111].ToString() == "" || (executequery.Tables[0].Rows[0].ItemArray[111].ToString() == executequery.Tables[0].Rows[0].ItemArray[14].ToString()))
        //    {
        //        txtclient.Text = executequery.Tables[0].Rows[0].ItemArray[14].ToString();
        //    }
        //    else
        //    {

        //        txtclient.Text = executequery.Tables[0].Rows[0].ItemArray[111].ToString() + "(" + executequery.Tables[0].Rows[0].ItemArray[14].ToString() + ")";
        //    }
        //    //2april
        //    txtclientadd.Text = executequery.Tables[0].Rows[0].ItemArray[15].ToString();


        //    txtprintremark.Text = executequery.Tables[0].Rows[0].ItemArray[24].ToString();
        //    string listpck = executequery.Tables[0].Rows[0].ItemArray[25].ToString();
        //    hiddenpackage.Value = listpck;
        //    //////////////////this is to bind the package grid on what the value is saved in the database


        //    //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "c1", "bindgridpkg('"+listpck+"')", true); 
        //    DataSet dsexecut = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //        dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);
        //    }
        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //            dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), listpck);


        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster bindpacforexe = new NewAdbooking.classmysql.BookingMaster();
        //            string[] arr = null;
        //            arr = listpck.Split(",".ToCharArray());
        //            string datasplit = "";
        //            for (int j = 0; j <= arr.Length - 1; j++)
        //            {
        //                if (j == 0)
        //                {
        //                    datasplit = arr[j];
        //                }
        //                else
        //                {
        //                    datasplit = datasplit + "'',''" + arr[j];
        //                }
        //            }
        //            dsexecut = bindpacforexe.packagebindforexebook(Session["compcode"].ToString(), datasplit);
        //        }

        //    int i;



        //    drppackagecopy.Items.Clear();
        //    for (i = 0; i <= dsexecut.Tables[0].Rows.Count - 1; i++)
        //    {
        //        if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //        {
        //            if (dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() != "0")
        //            {
        //                arrfor_uom = dsexecut.Tables[0].Rows[i].ItemArray[2].ToString().Split('@');
        //                DataSet dsinsert = new DataSet();
        //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //                {
        //                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //                    dsinsert = bindpacforexe.getPackageInsert(arrfor_uom[0].ToString(), txtciobookid.Text);


        //                }
        //                ListItem li;
        //                li = new ListItem();
        //                li.Text = dsexecut.Tables[0].Rows[i].ItemArray[1].ToString() + "(" + dsinsert.Tables[0].Rows[0].ItemArray[0].ToString() + ")";
        //                li.Value = dsexecut.Tables[0].Rows[i].ItemArray[2].ToString() + "(" + dsinsert.Tables[0].Rows[0].ItemArray[0].ToString() + ")"; ;
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drppackagecopy.Items.Add(li);
                       
        //                /*new change ankur 27 feb*/
        //                foruom_temp = arrfor_uom[1];
        //                if (for_uom == "")
        //                {
        //                    for_uom = foruom_temp;
        //                }
        //                else
        //                {
        //                    for_uom = for_uom + "+" + foruom_temp;

        //                }


        //            }
        //        }
        //    }





        //    txtinsertion.Text = executequery.Tables[0].Rows[0].ItemArray[26].ToString();
        //    hiddeninsertion.Value = executequery.Tables[0].Rows[0].ItemArray[26].ToString();
        //    string start_date = executequery.Tables[0].Rows[0].ItemArray[27].ToString();
        //    if (dateformat == "mm/dd/yyyy" && start_date != "")
        //    {
        //        string[] arr = start_date.Split('/');
        //        string dd = arr[0];
        //        string mm = arr[1];
        //        string yy = arr[2];
        //        txtdummydate.Text = mm + "/" + dd + "/" + yy;


        //    }
        //    else if (dateformat == "yyyy/mm/dd" && start_date != "")
        //    {
        //        string[] arr = start_date.Split('/');
        //        string dd = arr[0];
        //        string mm = arr[1];
        //        string yy = arr[2];
        //        txtdummydate.Text = yy + "/" + mm + "/" + dd;


        //    }
        //    else
        //    {
        //        txtdummydate.Text = start_date;//getDate1(dateformat, start_date);
        //    }
           
        //    txtrepeatingdate.Text = executequery.Tables[0].Rows[0].ItemArray[28].ToString();

        //    /*new change ankur 15 feb*/
        //    advcat(Session["compcode"].ToString());
        //    binduom();

        //    if (drpadcategory.Items.FindByValue(executequery.Tables[0].Rows[0].ItemArray[30].ToString()) != null)
        //    {
        //        hiddencatcode.Value = drpadcategory.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[30].ToString();
        //    }
        //    else
        //    {
        //        hiddencatcode.Value = drpadcategory.SelectedValue = "0";
        //    }
        //    ///////////////////////
        //    /*change ankur*/
        //    DataSet dscat = new DataSet();
        //    if (executequery.Tables[0].Rows[0].ItemArray[31].ToString() == "")
        //    {
        //        drpadsubcategory.Items.Clear();
        //        hiddenad_subcat.Value = "";

        //    }
        //    else
        //    {
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();

        //            dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //        }

        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();

        //                dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);



        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

        //                dscat = cls_comb.advdatasubcatcat(Session["compcode"].ToString(), drpadcategory.SelectedValue);

        //            }

        //        drpadsubcategory.Items.Clear();
        //        ListItem likasu;
        //        likasu = new ListItem();
        //        likasu.Text = "Select";
        //        likasu.Value = "0";
        //        drpadsubcategory.Items.Add(likasu);

        //        for (int k = 0; k < dscat.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem liocat;
        //            liocat = new ListItem();
        //            liocat.Text = dscat.Tables[0].Rows[k].ItemArray[1].ToString();
        //            liocat.Value = dscat.Tables[0].Rows[k].ItemArray[0].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpadsubcategory.Items.Add(liocat);
        //        }
        //    }



        //    ////////////////////////////////////////////////////////////////


        //    hiddenad_subcat.Value = drpadsubcategory.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[31].ToString();
        //    drpcolor.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[32].ToString();
        //    /*new change ankur 27 feb*/
        //  /*  DataSet ds_edituom = new DataSet();
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //        ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());
        //    }
        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //            ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());


        //        }
        //        else
        //        {
        //            NewAdbooking.classmysql.BookingMaster binduom_ = new NewAdbooking.classmysql.BookingMaster();
        //            ds_edituom = binduom_.binduomforedit(drpadtype.SelectedValue, for_uom, Session["compcode"].ToString());

        //        }

        //    drpuom.Items.Clear();

        //    drpuom.Items.Clear();
        //    ListItem likasu2;
        //    likasu2 = new ListItem();
        //    likasu2.Text = "Select";
        //    likasu2.Value = "0";
        //    drpuom.Items.Add(likasu2);

        //    for (int k = 0; k < ds_edituom.Tables[0].Rows.Count; k++)
        //    {
        //        ListItem liocat2;
        //        liocat2 = new ListItem();
        //        liocat2.Text = ds_edituom.Tables[0].Rows[k].ItemArray[1].ToString();
        //        liocat2.Value = ds_edituom.Tables[0].Rows[k].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drpuom.Items.Add(liocat2);
        //    }

        //    */
        //    for_uom = "";
        //    foruom_temp = "";

        //    ///////////////////
        //    /*new change ankur 15 feb*/
        //    hiddenuomcode.Value = drpuom.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[33].ToString();

        //    ////////
        //    drppageposition.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[34].ToString();

        //    //string adtype=drpadstype.SelectedValue;
        //    txtadsize1.Text = executequery.Tables[0].Rows[0].ItemArray[38].ToString();
        //    txtadsize2.Text = executequery.Tables[0].Rows[0].ItemArray[39].ToString();

        //    //       drpschemepck.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[41].ToString();


        //    txttotalarea.Text = executequery.Tables[0].Rows[0].ItemArray[54].ToString();
        //    txtcardrate.Text = executequery.Tables[0].Rows[0].ItemArray[55].ToString();










        //    txtgrossamt.Text = executequery.Tables[0].Rows[0].ItemArray[75].ToString();
        //    hiddenprevamt.Value = executequery.Tables[0].Rows[0].ItemArray[75].ToString();


        //    if (drpboxcodenew.Items.FindByValue(executequery.Tables[0].Rows[0].ItemArray[77].ToString()) != null)
        //    {
        //        drpboxcodenew.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[77].ToString();
        //    }
        //    else
        //    {
        //        drpboxcodenew.SelectedValue = "0";
        //    }
        //    txtboxnonew.Text = executequery.Tables[0].Rows[0].ItemArray[78].ToString();
        //    txtboxadd.Text = executequery.Tables[0].Rows[0].ItemArray[81].ToString();
        //    txtboxchrg.Text = executequery.Tables[0].Rows[0].ItemArray[132].ToString();
        //    if (executequery.Tables[0].Rows[0].ItemArray[133].ToString() != null)
        //    {
        //        txtsapid.Text = executequery.Tables[0].Rows[0].ItemArray[133].ToString();
        //    }
        //    else
        //    {
        //        txtsapid.Text = "";
        //    }

        //    //  drpboxcode.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[77].ToString();
        //    // txtboxno.Text = executequery.Tables[0].Rows[0].ItemArray[78].ToString();


        //    txtcolum.Text = executequery.Tables[0].Rows[0].ItemArray[84].ToString();

        //    txtpaid.Text = executequery.Tables[0].Rows[0].ItemArray[92].ToString();
        //    txtdealrate.Text = executequery.Tables[0].Rows[0].ItemArray[93].ToString();


        //    txtcontractname.Text = executequery.Tables[0].Rows[0].ItemArray[96].ToString();
        //    if (txtcontractname.Text == "")
        //    {
        //        chkcontract.Checked = false;
        //    }
        //    else
        //    {
        //        chkcontract.Checked = true;
        //    }


        //    hiddenreceiptno.Value = txtreceipt.Text = executequery.Tables[0].Rows[0].ItemArray[103].ToString();
        //    drpmatstat.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[120].ToString();
        //    if (dateformat == "mm/dd/yyyy" && executequery.Tables[0].Rows[0].ItemArray[121].ToString()!="")
        //    {
        //        string[] arr = executequery.Tables[0].Rows[0].ItemArray[121].ToString().Split('/');
        //        string dd = arr[0];
        //        string mm = arr[1];
        //        string yy = arr[2];
        //        txtreceiptdate.Text =  mm + "/" + dd + "/" + yy;


        //    }
        //     else if (dateformat == "yyyy/mm/dd" && executequery.Tables[0].Rows[0].ItemArray[121].ToString()!="")
        //    {
        //        string[] arr = executequery.Tables[0].Rows[0].ItemArray[121].ToString().Split('/');
        //        string dd = arr[0];
        //        string mm = arr[1];
        //        string yy = arr[2];
        //        txtreceiptdate.Text = yy + "/" + mm + "/" + dd;


        //    }
        //    else{
        //         txtreceiptdate.Text = executequery.Tables[0].Rows[0].ItemArray[121].ToString();//getDate1(dateformat, executequery.Tables[0].Rows[0].ItemArray[121].ToString());
        //     }
        //   // txtreceiptdate.Text = executequery.Tables[0].Rows[0].ItemArray[121].ToString();//getDate1(dateformat, executequery.Tables[0].Rows[0].ItemArray[121].ToString());

        //    ////this is to bind the adscat3 drpdown



        //    if (executequery.Tables[0].Rows[0].ItemArray[104].ToString() == "" || executequery.Tables[0].Rows[0].ItemArray[104].ToString() == "0")
        //    {
        //        drpadcat3.Items.Clear();
        //        hiddenadscat3.Value = "";

        //    }
        //    else
        //    {
        //        DataSet dacat = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //            //////if 0 than bind adcat3 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //        }

        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");

        //            }


        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[31].ToString(), Session["compcode"].ToString(), "0");
        //            }
        //        ////////////////////////////////////////////////////////////////
        //        drpadcat3.Items.Clear();
        //        ListItem lika;
        //        lika = new ListItem();
        //        lika.Text = "Select";
        //        lika.Value = "0";
        //        drpadcat3.Items.Add(lika);
        //        for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem lio;
        //            lio = new ListItem();
        //            lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //            lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpadcat3.Items.Add(lio);
        //        }


        //    }
        //    if (drpadcat3.Items.FindByValue(executequery.Tables[0].Rows[0].ItemArray[104].ToString()) != null)
        //    {
        //        hiddenadscat3.Value = drpadcat3.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[104].ToString();
        //    }
        //    else
        //    {
        //        hiddenadscat3.Value = drpadcat3.SelectedValue = "0";
        //    }
        //    ////////////////////this is to bind the adcat4 drp down
        //    if (executequery.Tables[0].Rows[0].ItemArray[105].ToString() == "")
        //    {
        //        drpadcat4.Items.Clear();
        //        hiddenadscat4.Value = "";

        //    }
        //    else
        //    {
        //        ////////////when 1 than bind the adscat4 drp down
        //        DataSet dacat = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //            //////if 0 than bind adcat3 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");
        //        }

        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {

        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");






        //            }

        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                //////if 0 than bind adcat3 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[104].ToString(), Session["compcode"].ToString(), "1");
        //            }
        //        ////////////////////////////////////////////////////////////////
        //        drpadcat4.Items.Clear();
        //        ListItem liks;
        //        liks = new ListItem();
        //        liks.Text = "Select";
        //        liks.Value = "0";
        //        drpadcat4.Items.Add(liks);
        //        for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem lio;
        //            lio = new ListItem();
        //            lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //            lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpadcat4.Items.Add(lio);
        //        }

        //    }

        //    if (drpadcat4.Items.FindByValue(executequery.Tables[0].Rows[0].ItemArray[105].ToString()) != null)
        //    {
        //        hiddenadscat4.Value = drpadcat4.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[105].ToString();
        //    }
        //    else
        //    {
        //        hiddenadscat4.Value = drpadcat4.SelectedValue = "0";
        //    }

        //    ///bind adcat5 drpdown
        //    if (executequery.Tables[0].Rows[0].ItemArray[106].ToString() == "")
        //    {
        //        drpadcat5.Items.Clear();
        //        hiddenadscat5.Value = "";
        //    }
        //    else
        //    {
        //        ////////////when 1 than bind the adscat4 drp down
        //        DataSet dacat = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

        //            //////if 2 than bind adcat2 drop down 
        //            dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //        }


        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

        //                //////if 2 than bind adcat2 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");

        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

        //                //////if 2 than bind adcat2 drop down 
        //                dacat = getadcat3.getvalfromadcat3(executequery.Tables[0].Rows[0].ItemArray[105].ToString(), Session["compcode"].ToString(), "2");
        //            }
        //        ////////////////////////////////////////////////////////////////
        //        drpadcat5.Items.Clear();
        //        ListItem liks;
        //        liks = new ListItem();
        //        liks.Text = "Select";
        //        liks.Value = "0";
        //        drpadcat4.Items.Add(liks);
        //        for (int k = 0; k < dacat.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem lio;
        //            lio = new ListItem();
        //            lio.Text = dacat.Tables[0].Rows[k].ItemArray[0].ToString();
        //            lio.Value = dacat.Tables[0].Rows[k].ItemArray[1].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpadcat5.Items.Add(lio);
        //        }
        //    }
        //    if (drpadcat5.Items.FindByValue(executequery.Tables[0].Rows[0].ItemArray[106].ToString()) != null)
        //    {
        //        hiddenadscat5.Value = drpadcat5.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[106].ToString();
        //    }
        //    else
        //    {
        //        hiddenadscat5.Value = drpadcat5.SelectedValue = "0";
        //    }


        //    //////bind the bg color drp down 

        //    /*new change ankur 15 feb*/
        //    string combin_name = "";
        //    //drpcolortype.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[124].ToString();
        //    if (Session["bg_colorpub"].ToString() == "yes")
        //    {
        //        ////this is to get the combin_desc
        //        for (int z = 0; z < drppackagecopy.Items.Count; z++)
        //        {
        //            string[] arr = drppackagecopy.Items[z].Value.Split('@');

        //            if (combin_name != "")
        //            {
        //                combin_name = combin_name + "+" + arr[1];
        //            }
        //            else
        //            {
        //                combin_name = arr[1];
        //            }

        //        }
        //        DataSet dsget = new DataSet();
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //        {
        //            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        //            dsget = bind.bindbgandfont(drpadcategory.SelectedValue, combin_name);
        //        }
        //        else

        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        //                dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);

        //            }
        //            else
        //            {
        //                NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
        //                dsget = bind.bindbgandfont(drpadcategory.SelectedValue, drpadsubcategory.SelectedValue, drpadcat3.SelectedValue, drpadcat4.SelectedValue, drpadcat5.SelectedValue, combin_name);
        //            }
        //        //////bind colortype

        //        drpcolortype.Items.Clear();
        //        ListItem colty;
        //        colty = new ListItem();
        //        colty.Text = "Select Color type";
        //        colty.Value = "0";
        //        drpcolortype.Items.Add(colty);
        //        for (int k = 0; k < dsget.Tables[0].Rows.Count; k++)
        //        {
        //            ListItem col1;
        //            col1 = new ListItem();
        //            col1.Text = dsget.Tables[0].Rows[k].ItemArray[1].ToString();
        //            col1.Value = dsget.Tables[0].Rows[k].ItemArray[0].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpcolortype.Items.Add(col1);
        //        }
        //        /*new change ankur 10 feb*/
        //        if (executequery.Tables[0].Rows[0].ItemArray[124].ToString() != "")
        //        {
        //            //drpcolortype.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[124].ToString();
        //        }


        //        else
        //        {
        //            drpcolortype.Items.Clear();
        //        }

        //        /////bind bg color



        //        drpbgcolor.Items.Clear();
        //        ListItem liksabg;
        //        liksabg = new ListItem();
        //        liksabg.Text = "Select Bg color";
        //        liksabg.Value = "0";
        //        drpbgcolor.Items.Add(liksabg);
        //        for (int k = 0; k < dsget.Tables[1].Rows.Count; k++)
        //        {
        //            ListItem liobg;
        //            liobg = new ListItem();
        //            liobg.Text = dsget.Tables[1].Rows[k].ItemArray[1].ToString();
        //            liobg.Value = dsget.Tables[1].Rows[k].ItemArray[0].ToString();
        //            //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //            drpbgcolor.Items.Add(liobg);
        //        }
        //        /*new change ankur 10 feb*/
        //        if (executequery.Tables[0].Rows[0].ItemArray[107].ToString() != "")
        //        {
        //            drpbgcolor.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[107].ToString();
        //        }
        //        else
        //        {
        //            drpbgcolor.Items.Clear();
        //        }


        //        ////bind bullet

        //        hiddenEyeBasedOnEdition.Value = ConfigurationSettings.AppSettings["EyeCatcherBasedOnEdition"].ToString();
        //        if (ConfigurationSettings.AppSettings["EyeCatcherBasedOnEdition"].ToString() == "no")
        //        {
        //            bindbullet();
        //        }
        //        else
        //        {
        //            drpbullet.Items.Clear();
        //            ListItem bul;
        //            bul = new ListItem();
        //            bul.Text = "Select Bullet";
        //            bul.Value = "0";
        //            drpbullet.Items.Add(bul);
        //            for (int k = 0; k < dsget.Tables[2].Rows.Count; k++)
        //            {
        //                ListItem bul1;
        //                bul1 = new ListItem();
        //                bul1.Text = dsget.Tables[2].Rows[k].ItemArray[1].ToString();
        //                bul1.Value = dsget.Tables[2].Rows[k].ItemArray[0].ToString();
        //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //                drpbullet.Items.Add(bul1);
        //            }
        //        }
        //        /*new change ankur 10 feb*/
        //        if (executequery.Tables[0].Rows[0].ItemArray[108].ToString() != "")
        //        {
        //            drpbullet.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[108].ToString();
        //        }
        //        else
        //        {
        //            drpbullet.Items.Clear();
        //        }

        //    }
        //    else
        //    {
        //        if (executequery.Tables[0].Rows[0].ItemArray[107].ToString() == "")
        //        {
        //            drpbgcolor.SelectedValue = "0";
        //        }
        //        else
        //        {
        //            drpbgcolor.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[107].ToString();
        //        }
        //        if (executequery.Tables[0].Rows[0].ItemArray[108].ToString() != "")
        //        {
        //            drpbullet.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[108].ToString();
        //        }
        //    }
        //    hiddencolortype.Value = drpcolortype.SelectedValue;
        //    hiddenbgcolor.Value = drpbgcolor.SelectedValue;
        //    hiddenbullet.Value = drpbullet.SelectedValue;
        //    ////////////////////////////////////////////////////////////////


        //    //drpbgcolor.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[107].ToString();

        //    /*   change  */
        //    drpregion.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[122].ToString();
        //    drpvarient.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[123].ToString();
        //    /*change ankur*/
        //    ///////this is to bind the bill to dropdown as agency and client////////
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        bindagencybillto(ds_billto);
        //    }
        //    else
        //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //        {
        //            bindagencybillto(ds_billto);

        //        }
        //        else
        //        {
        //            bindagencybillto(ds_billto);
        //        }
        //    bindbillto(executequery);
        //    if (drpbillto_qbc.Items.FindByValue(executequery.Tables[0].Rows[0].ItemArray[64].ToString()) != null)
        //    {
        //        drpbillto_qbc.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[64].ToString();
        //    }
            
        //    ///////////////////////////////////////////////////////////////////////////
        //    hiddenbillto.Value = drpbillto_qbc.SelectedValue;
        //    /*new change ankur 18 feb*/
        //    hiddenuomdesc.Value = executequery.Tables[0].Rows[0].ItemArray[125].ToString();

        //    /*new change ankur 24 feb*/
        //    hiddenlogomatter.Value = executequery.Tables[0].Rows[0].ItemArray[126].ToString();
        //    txtlogohei.Text = executequery.Tables[0].Rows[0].ItemArray[127].ToString();
        //    txtlogowid.Text = executequery.Tables[0].Rows[0].ItemArray[128].ToString();
        //    drplogocolor.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[129].ToString();
        //    txtlogouomcode.Text = executequery.Tables[0].Rows[0].ItemArray[130].ToString();
        //    hiddenlogocode.Value = executequery.Tables[0].Rows[0].ItemArray[131].ToString();
        //    ////////////////////////////


        //    /*new change 15 feb*/

        //    bindpackage();


        //    ///

        //}

        //else
        //{
        //    message = "Your Search Produces No Result";
        //    btnCancel_Click(sender, e);
        //    AspNetMessageBox(message);
        //    return;
        //}

        //updateStatus();
        //btnfirst.Enabled = false;
        //btnprevious.Enabled = false;


        //if (executequery.Tables[0].Rows.Count - 1 == 0)
        //{
        //    btnfirst.Enabled = false;
        //    btnprevious.Enabled = false;
        //    btnnext.Enabled = false;
        //    btnlast.Enabled = false;
        //}
        //////// we have called a javascript function to show the grid during execution mode
        ////ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "cc", "bindpackage()", true);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj", "document.getElementById('btndel').disabled=true;", true);
        ////  ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "ca", "showcardinfo('" + executequery.Tables[0].Rows[0].ItemArray[61].ToString() + "')", true);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "cc", "showgridexecute()", true);

        //if (hiddenuomdesc.Value == "CD")
        //{
        //    if (txtadsize1.Text != "" && txtcolum.Text != "")
        //    {
        //        txtadsize2.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }
        //    else if (txtadsize1.Text != "" && txtadsize2.Text != "")
        //    {
        //        txtcolum.Enabled = false;
        //        txtadsize1.BackColor = System.Drawing.Color.White;
        //        txtadsize2.BackColor = System.Drawing.Color.White;
        //        txtcolum.BackColor = System.Drawing.Color.White;

        //    }


        //}
        //else if (hiddenuomdesc.Value != "CD")
        //{
        //    txtadsize1.Enabled = false;
        //    txtadsize2.Enabled = false;
        //    if (hiddenuomdesc.Value == "ROL" || hiddenuomdesc.Value == "ROD")
        //    {
        //        Label1.Text = "No. Of Lines";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;


        //    }
        //    else if (hiddenuomdesc.Value == "ROW")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }
        //    else if (hiddenuomdesc.Value == "ROC")
        //    {
        //        Label1.Text = "No. Of Words";
        //        txtadsize1.BackColor = System.Drawing.Color.Gray;
        //        txtadsize2.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.BackColor = System.Drawing.Color.Gray;
        //        txtcolum.Enabled = false;
        //    }

        //}
        //txtlogowid.Enabled = false;
        //btnlogoupload.Enabled = false;
        //if (hiddenadsearch.Value == "true")
        //{
        //    btnNew.Enabled = false;
        //    btnQuery.Enabled = false;
        //    btnCancel.Enabled = false;
        //    btnExecute.Enabled = false;
        //    btnModify.Enabled = false;
        //    btnSave.Enabled = false;
        //    btnSaveConfirm.Enabled = false;
        //    btnDelete.Enabled = false;
        //}
        //if (confirm_Permission == "1" && drprostatus.SelectedValue == "2")
        //{

        //    ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj21", "document.getElementById('btnconfirm').disabled=false;", true);
        //}
        //lbreceipt.Enabled = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
//        if (Session["compcode"] == null)
//        {
//            //Response.Redirect("login.aspx");
//            //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
//            string sessionout = "Your Session Has Been Expired";
//            AspNetMessageBox_close(sessionout);
//            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

//            return;

//        }
//        Session["imgname"] = null;
//        Session["Tempimgname"] = null;
//        Session["insertname"] = null;
//        Session["Tempinsertname"] = null;
//        //***************By Manish Verma********************************
//        Session["fileName"] = null;
//        Session["savedata"] = null;
//        //**************************************************************

//        /*new change ankur 17feb*/
//        divagencymain.Visible = false;
//        drpvarient.Enabled = false;
//        drpvarient.SelectedValue = "0";
//        drpmatstat.SelectedValue = "0";
//        drpmatstat.Enabled = false;

//        //////

//        /*new change 14 feb*/
//        drpadtype.SelectedValue = "0";
//        drpadtype.Enabled = false;
//        /////////////////////

//        /*change ankur*/
//        drpbillto_qbc.Items.Clear();
//        drpbillto_qbc.Enabled = false;
//        ///////////////////////////////////
//        saveormodify = "0";
//        hiddencalendar.Value = "0";
//        hiddensavemod.Value = saveormodify;
//        /*new change ankur 10 feb*/
//        hiddencopy.Value = "";
//        hiddendummycioid.Value = "";
//        //////////////
//        drpboxcodenew.Enabled = false;
//        //txtboxadd.Enabled = false;
//        drpboxcodenew.SelectedValue = "0";
//        txtboxnonew.Text = "";
//        txtboxadd.Text = "";
//        txtboxchrg.Text = "";

//        btnlogo.Enabled = false;
//        // btnupload.Enabled = false;

//        txtciobookid.Enabled = false;
//        // txtappby.Enabled = false;
//        // txtaudit.Enabled = false;
//        txtrono.Enabled = false;
//        txtrodate.Enabled = false;
//        txteyecathval.Text = "";
//        txteyecathval.Enabled = false;
//        drprostatus.Enabled = false;
//        txtagency.ReadOnly = true;
//        txtclient.Enabled = false;

//        txtprintremark.Enabled = false;
//        drppackage.Enabled = false;
//        txtinsertion.Enabled = false;
//        txtdummydate.Enabled = false;
//        txtrepeatingdate.Enabled = false;

//        drpadcategory.Enabled = false;
//        chkall.Enabled = false;
//        drpadsubcategory.Enabled = false;
//        drpcolor.Enabled = false;
//        drpuom.Enabled = false;
//        drppageposition.Enabled = false;

//        // txtadsizetypeheight.Enabled = false;
//        //txtadsizetypewidth.Enabled = false;

//        txtdatetime.ReadOnly = true;
//        txtrepeatingdate.Enabled = false;


//        txtadsize1.Enabled = false;
//        txtadsize2.Enabled = false;
//        //txttotalarea.Enabled = false;
//        txttotalarea.ReadOnly = true;
//        //txtcardrate.Enabled = false;
//        txtcardrate.ReadOnly = true;



//        drpregion.Enabled = false;

//        txtinsertion.Enabled = false;

//        txtcolum.Enabled = false;



//        ///////////////////////
//        txtcontractname.Enabled = false;

//        btncopy.Enabled = false;
//        btndel.Enabled = false;

//        drpadcat3.Enabled = false;
//        drpadcat4.Enabled = false;
//        drpadcat3.Items.Clear();
//        drpadcat4.Items.Clear();

//        drpbgcolor.Enabled = false;
//        drpadcat5.Enabled = false;
//        drpadcat5.Items.Clear();

//        btnpaygateway.Enabled = false;

//        /*new change ankur 9 feb*/
//        drpcolortype.SelectedValue = "0";
//        drpcolortype.Enabled = false;
//        if (Session["bg_colorpub"].ToString() == "yes")
//        {
//            drpbgcolor.Items.Clear();

//        }
//        else
//        {

//            drpbgcolor.SelectedValue = "0";
//        }

//        drpbullet.Enabled = false;
//        drpbullet.SelectedValue = "0";


//        drpmatstat.SelectedValue = "0";

//        chkcontract.Checked = false;
//        chkcontract.Enabled = false;

//        txtcontractname.Text = "";

//        //////////////////////////////

//        txtcolum.Text = "";
//        txtreceipt.Text = "";


//        txtciobookid.Text = "";
//        // txtappby.Text = "";
//        // txtaudit.Text = "";
//        txtrono.Text = "";
//        txtrodate.Text = "";


//        drprostatus.SelectedValue = "0";
//        if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes")
//        {
//            txtagency.Text = "";
//        }
//        txtclient.Text = "";

//        txtclientadd.Text = "";

//        txtprintremark.Text = "";
//        //drppackage.SelectedValue = "0";
//        //drppackage.Items.Clear();
//        ///////////on the click of clear button bind the grid again to uncheck
//        txtinsertion.Text = "";
//        txtdummydate.Text = "";
//        txtrepeatingdate.Text = "";

//        drpadcategory.SelectedValue = "0";
//        drpadsubcategory.SelectedValue = "0";
//        //drpcolor.SelectedValue = "0";
//        if (drpuom.Items.FindByValue(hiddenuom1.Value) != null)
//        {
//            drpuom.SelectedValue = hiddenuom1.Value;
//        }
//        drppageposition.SelectedValue = "0";

//        //  txtadsizetypeheight.Text = "";
//        //txtadsizetypewidth.Text = "";

//        txtadsize1.Text = "";
//        txtadsize2.Text = "";
//        txttotalarea.Text = "";
//        txtcardrate.Text = "";
//        txtreceiptdate.Text = "";
//        txtdealrate.Text = "";
//        txtpaid.Text = "";
//        txtgrossamt.Text = "";

//        txtsapid.Text = "";

////2april
//        txtlogohei.Text = "";
//        txtlogowid.Text = "";
//        txtlogouomcode.Text = "";
//        //2april
//        // drpboxcode.SelectedValue = "0";

//        txtinsertion.Text = "";

//        drppackage.SelectedValue = "0";
//        drppackagecopy.Items.Clear();
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj", "document.getElementById('btndel').disabled=true;", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz", "document.getElementById('tblinsert').innerHTML=''", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj12", "document.getElementById('btnshgrid').disabled=true;", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "iid", "getid=\"\";", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "igb", "gblogowithmatter=\"\";", true);
//        /*new change ankur 24 feb*/
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj1", "document.getElementById('trbtnlogo').style.display=\"none\";", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz2", "document.getElementById('trlogouoload').style.display=\"none\";", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj123", "document.getElementById('trlogouom').style.display=\"none\";", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "hideclientdiv", "document.getElementById('divclient').style.display=\"none\";", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "divagencymain", "document.getElementById('divagencymain').style.display=\"none\";", true);
//        ////////////////////////////////////////////////////////////////

//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt", "document.getElementById('tblrate').style.display='none'", true);
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt1", "document.getElementById('tblbill').style.display='none'", true);
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt2", "document.getElementById('addetails').style.display='none'", true);
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt3", "document.getElementById('pagedetail').style.display='none'", true);
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt4", "document.getElementById('tblpackage').style.display='none'", true);
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt5", "document.getElementById('tbbox').style.display='none'", true);
//        //ScriptManager.RegisterClientScriptBlock(this, typeof(Classified_Booking), "zt7", "disablelistbox();", true);
//        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "disa1", "disabledlogoinfo();", true);

//        saveormodify = "01";
//        fpnl = 0;
//        getbuttoncheck(formname);
//        if (btnNew.Enabled == true)
//        {
//            ScriptManager1.SetFocus(btnNew);
//        }
//        //2april
//        btnconfirm.Enabled = false;

//        Session["imgname_logo"] = null;
//        Session["Tempimgname_logo"] = null;
//        Session["insertname_logo"] = null;
//        Session["Tempinsertname_logo"] = null;
//        lbreceipt.Enabled = false;
        //2april
    }
    protected void drpuom_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btncopy_Click(object sender, EventArgs e)
    {

    }
    protected void txtdummydate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtinsertion_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void drpboxcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        if (txtagency.Text == "")
        {
            txtagency.Text = hiddenagency.Value;
        }
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
            string sessionout = "Your Session Has Been Expired";
            AspNetMessageBox_close(sessionout);
            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "enable", "window.close();", true);

            return;

        }
        drprostatus.SelectedValue = "1";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster setval = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = setval.updatebookstatus(txtciobookid.Text, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster setval = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = setval.updatebookstatus(hiddencioid.Value, Session["compcode"].ToString(),Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster setval = new NewAdbooking.classmysql.BookingMaster();

            ds = setval.updatebookstatus(txtciobookid.Text, Session["compcode"].ToString());

        }
        btnconfirm.Enabled = false;
        message = "Ad Confirmed Successfully";
        AspNetMessageBox(message);
        btnCancel_Click(sender, e);
        if (hiddenprint_rec.Value == "Y")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "print", "printreceipt();", true);

        }
    }
    [Ajax.AjaxMethod]
    public DataSet confirmClick(string cioid, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster setval = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = setval.updatebookstatus(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster setval = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = setval.updatebookstatus(cioid, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster setval = new NewAdbooking.classmysql.BookingMaster();

            ds = setval.updatebookstatus(cioid, compcode);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fillbgcolor(string category, string coltyp)
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsch = bindbgcolor.bingbgcolor_drp(category, coltyp);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dsch = bindbgcolor.bingbgcolor_drp(category, coltyp);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
            dsch = bindbgcolor.bingbgcolor_drp(category, coltyp);
        }

        return dsch;


    }
    public void forcopydate()
    {

        hiddenbranch.Value = Session["revenue"].ToString();
        saveormodify = "0";

        autogenerated("0");
        autogenerated("2");

        fpnl = 0;
        drppackagecopy.Enabled = true;
        if (Session["bookstat"].ToString() == "Booked")
        {
            drprostatus.SelectedValue = "1";
        }
        else if (Session["bookstat"].ToString() == "Unconfirmed")
        {
            drprostatus.SelectedValue = "2";
            drprostatus.Enabled = false;
        }

get_pacakge_new.Enabled = false;
        //bindpackage();
        DateTime dt = DateTime.Now;

        int year = Convert.ToInt32(dt.Year);
        int month = Convert.ToInt32(dt.Month);
        int day = Convert.ToInt32(dt.Day);
        //string serdate = Convert.ToString(month + "/" + day + "/" + year);

        string serdate = "";
        /*change for oracle*/
        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            serdate = Convert.ToString(day + "/" + month + "/" + year);
        }
        else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
        {
            serdate = Convert.ToString(month + "/" + day + "/" + year);
        }
        else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
        {
            serdate = Convert.ToString(year + "/" + month + "/" + day);
        }


        datesave getdatechk = new datesave();
        dateinsert getdateshow = new dateinsert();
        //txtrodate.Text = getdateshow.getDate(Session["dateformat"].ToString(), serdate);
        txtreceiptdate.Text = getdateshow.getDate(Session["dateformat"].ToString(), serdate);


        chkstatus(FlagStatus);
        btnSave.Enabled = true;
        btnSaveConfirm.Enabled = true;
        btnNew.Enabled = false;
        btnQuery.Enabled = false;
      // ScriptManager1.SetFocus(txtclient);
        txtclient.Focus();
        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj", "document.getElementById('btndel').disabled=false;", true);
        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zj1", "document.getElementById('btnshgrid').disabled=false;", true);

        //*****************By Manish Verma********************************************************
        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "pass", "modifyMatter=0;", true);
        //****************************************************************************************

    }
    /*new change ankur 11 feb*/
    [Ajax.AjaxMethod]
    public DataSet bindcate(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
            }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }

        return ds;

    }
    /*new change ankur 15 feb*/
    [Ajax.AjaxMethod]
    public DataSet bindbgcolorandfont(string category, string category2, string category3, string category4, string category5, string desc)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bind.bindbgandfont(category, desc);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = bind.bindbgandfont(category, category2, category3, category4, category5, desc);
            }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.bindbgandfont(category, category2, category3, category4, category5, desc);
        }

        return ds;

    }
    /*new change ankur 16 feb*/
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet gettheuom_desc(string compcode, string uom)
    {
        /*2may*/
        HttpContext.Current.Session["imgname"] = null;
        HttpContext.Current.Session["Tempimgname"] = null;
        HttpContext.Current.Session["insertname"] = null;
        HttpContext.Current.Session["Tempinsertname"] = null;

        HttpContext.Current.Session["imgname_logo"] = null;
        HttpContext.Current.Session["Tempimgname_logo"] = null;
        HttpContext.Current.Session["insertname_logo"] = null;
        HttpContext.Current.Session["Tempinsertname_logo"] = null;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            ds = binduom.getuom_desc(compcode, uom);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster binduom = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            ds = binduom.getuom_desc(compcode, uom);

        }
            else
            {
                 NewAdbooking.classmysql .RateMaster binduom = new NewAdbooking.classmysql.RateMaster();
            ds = binduom.getuom_desc(compcode, uom);
            }
        return ds;

    }

    /*new change ankur 26 feb*/
    [Ajax.AjaxMethod]
    public DataSet get_validdates(string dateformat, string book_date, string pkgname,string adcat,string center,string pkgid,string pkgalias)
    {
        DataSet dvaid = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dvaid = chkpublishday.getvaliddate_qbc(dateformat, book_date, pkgname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dvaid = chkpublishday.getvaliddate_qbc_New(dateformat, book_date, pkgname,adcat,center,"CL0",pkgid,pkgalias);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();

                dvaid = chkpublishday.getvaliddate_qbc(dateformat, book_date, pkgname);
            }
        return dvaid;

    }
    /*new change ankur 27 feb8*/
    [Ajax.AjaxMethod]
    public DataSet binduomaccedition(string adtype, string desc, string compcode)
    {
        DataSet ds = new DataSet();

        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
        ds = binduom_.binduomforedit(adtype, desc, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster binduom_ = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = binduom_.binduomforedit(adtype, desc, compcode);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster binduom_ = new NewAdbooking.classmysql.BookingMaster();
                ds = binduom_.binduomforedit(adtype, desc, compcode);

            }

        return ds;

    }
    protected void drpadsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drpadcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public string getDate1(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        if (dateValue != "")
        {
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];

                dateReturn = mm + "/" + dd + "/" + yyyy;


            }
            //else if (dateformat == "yyyy/mm/dd")
            //{
            //    yyyy = myarrayfrom[0];
            //    mm = myarrayfrom[1];
            //    dd = myarrayfrom[2];

            //    dateReturn = mm + "/" + dd + "/" + yyyy;
            //}
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }

    //public void bindbgcolorcat(string category1, string category2, string category3, string category4, string category5)
    //{
    //    DataSet dsch = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0");
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
    //        dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0");
    //    }
    //    else
    //    {
    //        NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
    //        dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0");
    //    }

    //    /////if it is 0 than bind the drp down for bg col,or aND IF 1 THAN FOR BULLET DROP DOWN or if not 0 or 1 than get the selected bullet premium into its text field


    //    drpbgcolor.Items.Clear();
    //    int i;
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "-Select Bg Color-";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    drpbgcolor.Items.Add(li1);

    //    if (dsch.Tables[0].Rows.Count > 0)
    //    {
    //        for (i = 0; i < dsch.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();

    //            li.Text = dsch.Tables[0].Rows[i].ItemArray[1].ToString();
    //            li.Value = dsch.Tables[0].Rows[i].ItemArray[1].ToString();
    //            state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //            drpbgcolor.Items.Add(li);
    //        }

    //    }


    //}
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getagencyf(string matter,string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getagCenter(compcode, matter, Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {

                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster logindetail = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = logindetail.bindagency_DJ(compcode, "", matter, Session["revenue"].ToString(), Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString());
            }
            else
            {

                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getagCenter(compcode, matter, Session["center"].ToString());
            }
        }
         else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.getagCenter(compcode, matter, Session["center"].ToString());

        }
        return ds;

    }
    public void bindbox()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindboxcode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindboxcode.boxbind(Session["compcode"].ToString(), Session["center"].ToString());

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindboxcode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dx = bindboxcode.boxbind_qbc(Session["compcode"].ToString(), Session["userid"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindboxcode = new NewAdbooking.classmysql.BookingMaster();
                dx = bindboxcode.boxbind_qbc(Session["compcode"].ToString(), Session["userid"].ToString());

            }

        drpboxcodenew.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Box-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpboxcodenew.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpboxcodenew.Items.Add(li);
            }

        }

    }
    [Ajax.AjaxMethod]
    public DataSet getRec(string agencyname)
    {
        DataSet datasetrecinc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rec = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            string agencycode = "";
            if (agencyname != "")
            {
                agencycode = agencyname.Substring(agencyname.LastIndexOf("(") + 1, agencyname.Length - agencyname.LastIndexOf("(") - 2);
            }
            datasetrecinc = rec.clsMaxReceipt(agencycode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster rec = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            string agencycode = "";
            if (agencyname != "")
            {
                agencycode = agencyname.Substring(agencyname.LastIndexOf("(") + 1, agencyname.Length - agencyname.LastIndexOf("(") - 2);
            }
            datasetrecinc = rec.clsMaxReceipt();
        }
        else 
        {
            NewAdbooking.classmysql.BookingMaster rec = new NewAdbooking.classmysql.BookingMaster();
            datasetrecinc = rec.getReciptNo();
        }
        return datasetrecinc;
    }
    [Ajax.AjaxMethod]
    public DataSet getBalance(string compcode,string agencyname)
    {
        DataSet datasetrecinc = new DataSet();
        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rec = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        string agencycode = "";
        if (agencyname != "")
        {
            agencycode = agencyname.Substring(agencyname.LastIndexOf("(") + 1, agencyname.Length - agencyname.LastIndexOf("(") - 2);
        }
        datasetrecinc = rec.getAgencyBalance(compcode, agencycode);
        return datasetrecinc;
    }

    protected void btnSaveConfirm_Click(object sender, EventArgs e)
    {
        btnSave_Click(sender, e);
        //btnconfirm_Click(sender, e);
        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "confirmsave", "adsaveconfirm();", true);
    }

    protected void disablectrls()
    {
        
        /*change ankur*/
        drpbillto_qbc.Items.Clear();
        drpbillto_qbc.Enabled = false;
        ///////////////////////////////////
        /*new change ankur 23 feb*/
        Session["imgname_logo"] = null;
        Session["Tempimgname_logo"] = null;
        Session["insertname_logo"] = null;
        Session["Tempinsertname_logo"] = null;
        //////////////////////////////////
        Session["imgname"] = null;
        Session["Tempimgname"] = null;
        Session["insertname"] = null;
        Session["Tempinsertname"] = null;
        hiddencalendar.Value = "0";
        //  txtappby.Enabled = false;
        // txtaudit.Enabled = false;
        txtrono.Enabled = false;
        txtrodate.Enabled = false;
        chkage.Enabled = false;
        chkclie.Enabled = false;

        drprostatus.Enabled = false;
        txtagency.ReadOnly = true;
        txtclient.Enabled = false;
        drpboxcodenew.Enabled = false;
        //txtboxadd.Enabled = false;
        drpboxcodenew.Enabled = false;
        txtboxadd.Enabled = false;
        txtclientadd.Enabled = false;


        txteyecathval.Text = "";
        txteyecathval.Enabled = false;
        txtprintremark.Enabled = false;
        drppackage.Enabled = false;
        txtinsertion.Enabled = false;
        txtdummydate.Enabled = false;
        txtrepeatingdate.Enabled = false;

        drpadcategory.Enabled = false;
        chkall.Enabled = false;
        drpadsubcategory.Enabled = false;
        drpcolor.Enabled = false;
        drpuom.Enabled = false;
        drppageposition.Enabled = false;

        //txtadsizetypeheight.Enabled = false;
        // txtadsizetypewidth.Enabled = false;


        //  drpschemepck.Enabled = false;




        txtdatetime.ReadOnly = true;
        //txtdatetime.Enabled = false;
        txtrepeatingdate.Enabled = false;
        txtadsize1.Enabled = false;
        txtadsize2.Enabled = false;
        //txttotalarea.Enabled = false;
        txttotalarea.ReadOnly = true;
        //txtcardrate.Enabled = false;
        txtcardrate.ReadOnly = true;

        txtrepeatingdate.Enabled = false;


        txtcolum.Enabled = false;

        btnpaygateway.Enabled = false;

        drpregion.Enabled = false;
        // drpboxcode.SelectedValue = "0";
        //txtboxno.Enabled = false;
        //txtboxno.Text = "";


        drpadcat3.Enabled = false;
        drpadcat4.Enabled = false;
        drpadcat3.Items.Clear();
        drpadcat4.Items.Clear();

        drpbgcolor.Enabled = false;
        drpadcat5.Enabled = false;
        drpadcat5.Items.Clear();
        /*new change ankur 9 feb*/
        if (Session["bg_colorpub"].ToString() == "yes")
        {
            drpbgcolor.Items.Clear();
        }
        else
        {
            drpbgcolor.SelectedValue = "0";
        }
        drpcolortype.SelectedValue = "0";
        drpcolortype.Enabled = false;


        //////////////////////////////////////////

        drpbullet.Enabled = false;
        drpbullet.SelectedValue = "0";

        drpmatstat.Enabled = false;
        drpmatstat.SelectedValue = "0";
        chkcontract.Checked = false;
        chkcontract.Enabled = false;
        drpvarient.Enabled = false;


        txtgrossamt.Text = "";



        // txtappby.Text = "";
        //txtaudit.Text = "";
        txtcolum.Text = "";

        txtrono.Text = "";
        txtrodate.Text = "";


        drprostatus.SelectedValue = "0";
        if (ConfigurationSettings.AppSettings["f2"].ToString() == "yes")
        {
            txtagency.Text = "";
        }
        txtclient.Text = "";
        drpboxcodenew.SelectedValue = "0";
        txtboxnonew.Text = "";
        txtboxadd.Text = "";
        txtboxchrg.Text = "";
        txtclientadd.Text = "";

        txtprintremark.Text = "";
        txtinsertion.Text = "";
        txtdummydate.Text = "";
        txtrepeatingdate.Text = "";

        drpadcategory.SelectedValue = "0";
        drpadsubcategory.SelectedValue = "0";
        drpcolor.SelectedValue = "B";
        drpuom.SelectedValue = "0";
        drppageposition.SelectedValue = "0";




        txtadsize1.Text = "";
        txtadsize2.Text = "";
        txttotalarea.Text = "";
        txtcardrate.Text = "";

        txtrepeatingdate.Text = "";
        /*new change ankur 10 feb*/
        hiddencopy.Value = "";
        hiddendummycioid.Value = "";
        /////////////////////////

        /*new change 14 feb*/
        drpadtype.SelectedValue = "0";
        drpadtype.Enabled = false;
        /////////////////////
        /*new change ankur 17 feb*/
        txtreceiptdate.Enabled = false;
        txtreceiptdate.Text = "";
        txtpaid.Text = "";
        txtreceipt.Text = "";
        ///////////////////////

        /*new change ankur 24 feb*/
        txtlogohei.Enabled = true;
        txtlogohei.Text = "";
        txtlogoname.Text = "";
        drplogocolor.Enabled = true;
        drplogocolor.SelectedValue = "0";

        ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "zz1", "document.getElementById('tblinsert').innerHTML=''", true);

        drppackagecopy.Items.Clear();

        if (hiddenprint_rec.Value == "Y")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(QBC), "print", "printreceipt();", true);

        }

    }

    [Ajax.AjaxMethod]
    public void confirmsave(string compcode, string cioid, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster setval = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = setval.updatebookstatus(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster setval = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = setval.updatebookstatus(cioid, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster setval = new NewAdbooking.classmysql.BookingMaster();

            ds = setval.updatebookstatus(cioid, compcode);

        }
    }

    [Ajax.AjaxMethod]
    public DataSet getpaystatus(string receipt_no)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster paystatus = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = paystatus.get_paystatus(receipt_no);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster paystatus = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = paystatus.get_paystatus(receipt_no);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster colortype = new NewAdbooking.classmysql.BookingMaster();

            ds = colortype.get_paystatus(receipt_no);
        }
        return ds;
    }

    protected void bindbillto(DataSet execute)
    {
        string[] arragency = txtagency.Text.Split('(');
        string agencycode = arragency[1].Replace(")", "");
        string agencyname = arragency[0];
        ListItem li = new ListItem();

        drpbillto_qbc.Items.Clear();

        li.Value = agencycode;
        li.Text = agencyname;

        

        drpbillto_qbc.Items.Add(li);

        li = new ListItem();

        li.Value = txtclient.Text;
        li.Text = txtclient.Text;

        drpbillto_qbc.Items.Add(li);

        
    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        bindpackage();
    }
    protected void get_pacakge_new_Click(object sender, EventArgs e)
    {
        bindpackage();
    }

    [Ajax.AjaxMethod]
    public DataSet get_rate(string noofinsertion, string dateformat, string compcode, string uom, string adtype, string currency, string ratecode, string clientcode, string uomdesc, string agencycode, string newcode, string center, string ratepremtype, string premium, string schemetype, string fdate, string ldate, int currentcounter,string designbox,string logoprem,string style)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, currentcounter, fdate, ldate, "N", "", "", "", designbox, logoprem, style);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate, currentcounter, "N", "", "", "", designbox, logoprem, style);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getrate = new NewAdbooking.classmysql.BookingMaster();
            ds = getrate.get_rate_qbc(noofinsertion, dateformat, compcode, uom, adtype, currency, ratecode, clientcode, uomdesc, agencycode, newcode, center, ratepremtype, premium, schemetype, fdate, ldate);
        }
        return ds;
    }

    public void bindagencybillto_btnnew(string agency)
    {
        drpbillto_qbc.Items.Clear();
        string[] arr_agency = agency.Split('(');

        ListItem li;
        li = new ListItem();
        li.Text = arr_agency[0].ToString();
        li.Value = arr_agency[1].ToString().Replace(")", "");
        drpbillto_qbc.Items.Add(li);
         
    }
    [Ajax.AjaxMethod]
    public DataSet advcatinGrid(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = bind.advdatacategory(compcode, "CL0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bind = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                ds = bind.advdatacategory(compcode, "CL0");
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();

                ds = bind.advdatacategory(compcode, "CL0");
            }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindpagePositioninGrid(string compcode,string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = clsbooking.bindPagePosition(compcode, txtdatetime.Text, Session["dateformat"].ToString(),adtype);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                ds = clsbooking.bindPagePosition(compcode, txtdatetime.Text, Session["dateformat"].ToString(),adtype);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

                ds = clsbooking.bindPagePosition(compcode);

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindcolorForGrid(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();

            ds = bindcolor.colorbind(compcode, userid);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();

                ds = bindcolor.colorbind(compcode, userid);

            }
            else
            {
                NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();

                ds = bindcolor.colorbind(compcode, userid);

            }


        return ds;
    }
    [Ajax.AjaxMethod]
    public string getDate(string dateformat, string serdate)
    {
          datesave getdatechk = new datesave();
        dateinsert getdateshow = new dateinsert();
        //txtrodate.Text = getdateshow.getDate(Session["dateformat"].ToString(), serdate);
       string data="";
       data = getdateshow.getDatedisp(dateformat, serdate);
        return data;
    }
    [Ajax.AjaxMethod]
    public DataSet getReciptNo(string agencycode)
    {
        DataSet datasetrecinc = new DataSet();
        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster rec = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
        datasetrecinc = rec.getReciptNo(agencycode);
        return datasetrecinc;
    }
    [Ajax.AjaxMethod]
    public DataSet getBookingIdNo(string compcode, string auto, string no, string cioid)
    {
        DataSet da = new DataSet();
        if (no == "0")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                da = autocode.autogenrated(compcode, auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    da = autocode.autogenrated(compcode, auto, no);

                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                    da = autocode.autogenrated(compcode, auto, no);

                }
        }
        else if (no == "1")
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                da = autocode.autogenrated(compcode, auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                    da = autocode.autogenrated(compcode, auto, no);

                }

                else
                {
                    NewAdbooking.classmysql.BookingMaster autocode = new NewAdbooking.classmysql.BookingMaster();

                    da = autocode.autogenrated(compcode, auto, no);

                }
        }
        else if (no == "2")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

                da = autocode.autogenrated(compcode, auto, no);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

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

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objMaxReceipt_No = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                da = objMaxReceipt_No.clsMaxReceipt(cioid);
            }
            else
            {

            }
        }
        return da;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void clearSession()
    {
        Session["imgname"] = null;
        Session["Tempimgname"] = null;
        Session["insertname"] = null;
        Session["Tempinsertname"] = null;
        //***************By Manish Verma********************************
        Session["fileName"] = null;
        Session["savedata"] = null;
    }
    [Ajax.AjaxMethod]
    public DataSet chkwalkinClient(string client, string compcode)
    {
        DataSet dcl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dcl = chkclient.forwalkclient(client, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkclient = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dcl = chkclient.forwalkclient(client, compcode);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkclient = new NewAdbooking.classmysql.BookingMaster();

                dcl = chkclient.forwalkclient(client, compcode);

            }
        return dcl;
    }
    [Ajax.AjaxMethod]
    public DataSet executeBooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string adtype,string dateformat,string branch)
    {
        DataSet executequery1 = new DataSet();
        //adtype = "CL0";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
               FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
               executequery1 = execute.executebookingqbc(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat,branch);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery1 = execute.executebookingqbc(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformat, branch);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            executequery1 = execute.executebooking(compcode, ciobookid, docno, keyno, rono, agencycode, client, adtype);
        }
        return executequery1;
    }
    [Ajax.AjaxMethod]
    public DataSet bindpacforexe(string compcode, string listpck)
    {
        DataSet dsexecut = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dsexecut = bindpacforexe.packagebindforexebook(compcode, listpck);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

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
    public DataSet getPackageInsert(string uom, string cioid)
    {
        DataSet dsinsert = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dsinsert = bindpacforexe.getPackageInsert(uom, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindpacforexe = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
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
    public DataSet getvalfromadcat3(string agencysubcode, string compcode, string type)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(agencysubcode, compcode, type);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getadcat3 = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

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
    public DataSet bindBillTO(string compcode,string userid)
    {
        DataSet dprv = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dprv = prev.prevbooking(compcode,userid, "CL0");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dprv = prev.prevbooking(compcode, userid, "CL0");
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
                dprv = prev.prevbooking(compcode, userid, "CLO");


            }
        return dprv;
    }
    [Ajax.AjaxMethod]
    public DataSet fetchdataforexe(string cioid, string compcode)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dex = showgri.fetchdataforexe(cioid, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster showgri = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dex = showgri.fetchdataforexe(cioid, compcode);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();

                dex = showgri.fetchdataforexe(cioid, compcode);

            }
        return dex;
    }
    [Ajax.AjaxMethod]
           
    public string insertBookingQBC(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, string billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtyp, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prev_cioid, string prev_receipt, string prev_ga, string region, string variant_name, string coltype, string logo_hei, string logo_wid, string logo_color, string logo_uom, string dateformat, string retainer, string retainercomm, string mobileno, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string attach1, string fmgreasons, string logoprem, string designbox, string pstyle, string srtcancel, string cou_code, string cou_name,string state ,  string clientcatdisc,string clientcatamt,string clientcatdistype,string flatfreqdisc,string flatfreqamt,string flatfreqdisctype,string catdisc,string catamt,string catdisctype,string cashdiscount,string cashrecieved)
    {
        DataSet dins = new DataSet();
        string error = "";
        DataSet dscancel = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                /*new change ankur 9 feb*/
                /*new change ankur 23 feb*/
                dins = insert.insertbooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, receiptdate, prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), region, variant_name, coltype, logo_hei, logo_wid, logo_color, logo_uom, dateformat, retainer, "", mobileno, "", "", retainercomm, "", "", "", "", "", "", "", attach1, "",cashdiscount, cashrecieved, "", "", chktradeval, sharepub, fmginsert, "", "", "", "", "", "", "", "", "", "", "", "", grossamt, bill_amt, "", "", "", "", "", "", "", "", fmgreasons, "", "", "", "", designbox, logoprem, "", pstyle, "", "", cou_code, cou_name, state, clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype,"","");
                if (srtcancel == "1")
                {
                    dscancel = insert.cancelbooking(prev_cioid);
                }
                dscancel.Dispose();
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster insert = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    /*new change ankur 9 feb*/
                    /*new change ankur 23 feb*/
                    NewAdbooking.classesoracle.BookingMaster insert = new NewAdbooking.classesoracle.BookingMaster();

                    error = insert.insertbookingqbc(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, receiptdate, prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), region, variant_name, coltype, logo_hei, logo_wid, logo_color, logo_uom, dateformat, retainer, "", mobileno, "", "", retainercomm, "", "", "", chktradeval, sharepub, fmginsert, chkno, chkdate, "", chkbankname, "", "", "", "", "", "", "", "", grossamt, bill_amt, attach1, fmgreasons, "", "", "", "", designbox, logoprem, "", pstyle, cou_code, cou_name, state, clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, cashdiscount, cashrecieved);
                    if (srtcancel == "1")
                    {
                        dscancel = insert.cancelbooking(prev_cioid);
                    }
                    dscancel.Dispose();

                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster insert = new NewAdbooking.classmysql.BookingMaster();
                    /*new change ankur 9 feb*/
                    /*new change ankur 23 feb*/
                    dins = insert.insertbookingqbc(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, receiptdate, prev_cioid, prev_receipt, Convert.ToDecimal(prev_ga), region, variant_name, coltype, logo_hei, logo_wid, logo_color, logo_uom, dateformat, retainer, "", mobileno, "", "", retainercomm, "");

                }
        }
        catch (Exception e)
        {
            error = e.Message;

        }
        return error;
    }
    public void State()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CityMaster StateName = new NewAdbooking.Classes.CityMaster();
            ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CityMaster StateName = new NewAdbooking.classesoracle.CityMaster();
            ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.CityMaster StateName = new NewAdbooking.classmysql.CityMaster();
            ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        //li1.Selected =true;
        drpstate.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpstate.Items.Add(li);
        }
    }
    [Ajax.AjaxMethod]

    public DataSet updatebooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, string billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtyp, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string variant_name, string coltype, string logo_hei, string logo_wid, string logo_color, string logo_uom, string auditstatus, string dateformat, string retainer, string retainercomm, string mobileno, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string attach1, string fmgreasons, string logoprem, string designbox, string style, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string cashdiscount, string cashdiscountper)
    {
        DataSet dup = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster update = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            /*new change ankur 9 feb*/
            /*new change ankur 23 feb*/
            dup = update.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, region, variant_name, coltype, logo_hei, logo_wid, logo_color, logo_uom, auditstatus, dateformat, retainer, "", mobileno, "", "", retainercomm, "", "", "", "", "", "", "", cashdiscount, cashdiscountper, attach1, "", "", "", chktradeval, sharepub, fmginsert, "", "", "", "", "", "", "", "", "", "", "", "", grossamt, bill_amt, "", "", "", "", "", "", "", "", fmgreasons, "", modifyrateaudit, ip, "", "", "", designbox, logoprem, "", style, "", "", cou_code, cou_name, state, clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype,"","");//sunil
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
               // FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster update = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                /*new change ankur 9 feb*/
                /*new change ankur 23 feb*/
                NewAdbooking.classesoracle.BookingMaster insert = new NewAdbooking.classesoracle.BookingMaster();
                dup = insert.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, region, variant_name, coltype, logo_hei, logo_wid, logo_color, logo_uom, auditstatus, dateformat, retainer, "", mobileno, "", "", retainercomm, "", "", chktradeval, sharepub, fmginsert, chkno, chkdate, "", chkbankname, "", "", "", "", "", "", "", "", grossamt, bill_amt, attach1, fmgreasons, "", modifyrateaudit, ip, "", "", "", designbox, logoprem, "", style, cou_code, cou_name, state, clientcatdisc, clientcatamt, clientcatdistype, flatfreqdisc, flatfreqamt, flatfreqdisctype, catdisc, catamt, catdisctype, cashdiscount, cashdiscountper);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster update = new NewAdbooking.classmysql.BookingMaster();
                /*new change ankur 9 feb*/
                /*new change ankur 23 feb*/
                dup = update.updatebooking(adsizetype, branch, booked_by, prevbook, date_time, ciobookid, approvedby, audit, rono, rodate, caption, billstatus, rostatus, agency, client, agencyaddress, clientaddresses, agencycode, dockitno, execname, execzone, product, brand, keyno, billremark, printremark, package, insertion, startdate, repeatdate, adtype, adcategory, subcategory, color, uom, pageposition, pagetype, pageno, adsizheight, adsizwidth, ratecode, scheme, currency, agreedrate, agreedamt, spedisc, spacedisx, compcode, userid, specialcharges, agencytype, agencystatus, paymode, agencredit, cardrate, cardamount, discount, discountper, billaddress, totarea, billcycle, revenuecenter, billpay, billheight, billwidth, billto, invoices, vts, tradedisc, agencyout, boxcode, boxno, boxaddress, boxagency, boxclient, bookingtype, tfn, coupan, campaign, bill_amt, pageprem, pageamt, premper, grossamt, adsizcolumn, billcolumn, Convert.ToDecimal(billarea), specdiscper, spacediscper, paidins, dealrate, deviation, varient, contractname, dealtyp, cardname, cardtype, cardmonth, cardyear, cardno, receiptno, adscat3, adscat4, adscat5, bgcolor, bulletcode, bulletprm, material, region, variant_name, coltype, logo_hei, logo_wid, logo_color, logo_uom, auditstatus, dateformat, retainer, "", mobileno, "", "", retainercomm, "");

            }
        return dup;
    }
    [Ajax.AjaxMethod]
    public DataSet bookidchk(string compcode, string cioid, string agency, string agencycode, string rono, string val)
    {
        DataSet dck = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0","");

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0","0");

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkbookid = new NewAdbooking.classmysql.BookingMaster();

                dck = chkbookid.bookidchk(compcode, cioid, agency, agencycode, rono, "0", "0");

            }
        return dck;
    }
    [Ajax.AjaxMethod]
    public void deleteid(string cioid, string compcode)
    {
        DataSet ddl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ddl = delid.deleteid(cioid, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster delid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                ddl = delid.deleteid(cioid, compcode);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster delid = new NewAdbooking.classmysql.BookingMaster();

                ddl = delid.deleteid(cioid, compcode);
            }
    }
    [Ajax.AjaxMethod]
    public string getAgencyCode(string compcode,string agencycode)
    {
        DataSet dck=new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dck = chkbookid.getAgencyCode(compcode, agencycode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dck = chkbookid.getAgencyCode(compcode, agencycode);
        }
        else 
        {
            NewAdbooking.classmysql.BookingMaster chkbookid = new NewAdbooking.classmysql.BookingMaster();
            dck = chkbookid.getAgencyCode(compcode, agencycode);
        }
        string code = "";
        if (dck.Tables[0].Rows.Count > 0)
        {
            code = dck.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return code;
    }
    [Ajax.AjaxMethod]
    public string getAgencyStatus(string compcode, string agencycode)
    {
        DataSet dck = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkbookid = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            dck = chkbookid.getAgencyStatus(compcode, agencycode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster chkbookid = new NewAdbooking.classmysql.BookingMaster();

            dck = chkbookid.getAgencyStatus(compcode, agencycode);

        }
        string code = "";
        if (dck.Tables[0].Rows.Count > 0)
        {
            code = dck.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return code;
    }
    [Ajax.AjaxMethod]
    public void deleteBooking(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
             cls_book.deleteBooking(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            cls_book.deleteBooking(cioid);
        }

    }
    [Ajax.AjaxMethod]
    public void InsertintoTemp(string cioid, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objInsertintoTemp = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            objInsertintoTemp.clsInsertintoTemp(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objInsertintoTemp = new NewAdbooking.classmysql.BookingMaster();
            objInsertintoTemp.clsInsertintoTemp(cioid, compcode);
        }
    }

    [Ajax.AjaxMethod]
    public void deletefromtemp(string cioid, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objdeletefromtemp = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objdeletefromtemp = new NewAdbooking.classmysql.BookingMaster();
            objdeletefromtemp.clsdeletefromtemp(cioid, compcode);
        }
    }
    [Ajax.AjaxMethod]
    public string checkCIOIDReference(string compcode, string cioid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_booking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = cls_booking.checkCIOIDReference(compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster cls_booking = new NewAdbooking.classmysql.BookingMaster();
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
            cio_ID = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
        return cio_ID;
    }
    [Ajax.AjaxMethod]
    public int getCategoryTemplate(string category)
    {
        int count = 0;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            DataSet ds = new DataSet();
            ds = cls_book.getTemplate(category);
            count = ds.Tables[0].Rows.Count;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            DataSet ds = new DataSet();
            ds = cls_book.getTemplate(category);
            count = ds.Tables[0].Rows.Count;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
            DataSet ds = new DataSet();
            ds = cls_book.getTemplate(category);
            count = ds.Tables[0].Rows.Count;
       }
        return count;
    }
    [Ajax.AjaxMethod]
    public string getPkgEdition(string compcode, string combincode)
    {
        DataSet ds = new DataSet();
        string edition = "1";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster cls_book = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
           
            ds = cls_book.getPkgEdition_P(compcode, combincode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
          
            ds = cls_book.getPkgEdition_P(compcode, combincode);
           
        }
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.BookingMaster cls_booking = new NewAdbooking.Classes.BookingMaster();
        //    ds = cls_book.getPkgEdition_P(compcode, combincode);
        //}
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[0] != null)
            {
                edition = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
        return edition;
    }
    public void fillQBC(string pubcenter)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getQBC(pubcenter);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getQBC(pubcenter);
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getQBC(pubcenter);
            }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Branch-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        txtbranch.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                txtbranch.Items.Add(li);
            }

        }
        txtbranch.SelectedValue = Session["revenue"].ToString();
    }
    [Ajax.AjaxMethod]
    public Boolean chkCodeMain(string name, string code, string company)
    {
        DataSet ds = new DataSet();
        bool fag = false;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = prev.getmaincode(name, code, company);
           
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = prev.getmaincode(name, code, company);
            
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();
            ds = prev.getmaincode(name, code, company);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            fag = true;
        }
        else
        {
            fag = false;
        }
        return fag;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname1(string compcode, string client,string agency)
    {
        string agencycode = "";
        agencycode = HttpContext.Current.Session["agency_name"].ToString();
        if (agencycode != "0")
        {
            
        }
        else
        {
            agencycode = "";
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = clsbooking.getClientName_b(compcode, client,agencycode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                ds = clsbooking.getClientName_DJ(compcode, client, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString());
                
            }
            else
            {
                ds = clsbooking.getClientName_b(compcode, client, "0", agencycode);
            }
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

            ds = clsbooking.getClientName(compcode, client);
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getCurTime(string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getCurTime(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getCurTime(compcode);

        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet checkNoIssueBhaskar(string compcode, string combincode,string fromdate,string todate)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

            ds = clsbooking.getIssuedate_Bhaskar(compcode, combincode, fromdate, todate);
           
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fetchData(string compcode,string cioid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster objUpdatePage_Booking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = objUpdatePage_Booking.fetchqbcdetail(compcode, cioid);
            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster objPagePremium = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = objPagePremium.fetchqbcdetail(compcode, cioid);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            ds = objPagePremium.fetchqbcdetail(compcode, cioid);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public String getPaymentFlag(string agencycode)
    {
        DataSet dagen = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkagen = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dagen = chkagen.getPaymentFlag(agencycode);
            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkagen = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dagen = chkagen.getPaymentFlag(agencycode);
            
            }
            string flag = "1";
            if (dagen.Tables.Count > 0)
            {
                flag = dagen.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return flag;
    }
    [Ajax.AjaxMethod]
    public DataSet getPubSharing(string packagecode, string compcode, string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);

        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet fetchFMGrefID(string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.fetchFMGrefID(cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.fetchFMGrefID(cioid);

        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet getpubcount(string compcode, string noofinsert, string packagecode, string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getpubcount(compcode, noofinsert, packagecode, cioid);

        }
        return executequery;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void savelogin_dj(string cioid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            execute.SAVELOGIN_DJ(cioid, Session["PUBLICATIONDJ"].ToString(), Session["CENTERDJ"].ToString(), Session["revenue"].ToString(), Session["LOGINDJ"].ToString());

        }

    }
    [Ajax.AjaxMethod]
    public DataSet getPackageConsumption(string pkgcode_p, string pfdate, string pldate, string dateformat)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery = execute.getPackageConsumption(pkgcode_p, pfdate, pldate, dateformat);

        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet chkagencycode(string agency, string compcode, string product, string execname, string retainer)
    {
        DataSet dagen = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkagen = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            dagen = chkagen.getagencyname(agency, compcode, product, execname, retainer);
            return dagen;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkagen = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

                dagen = chkagen.getagencyname(agency, compcode, product, execname);
                return dagen;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkagen = new NewAdbooking.classmysql.BookingMaster();

                dagen = chkagen.getagencyname(agency, compcode, product, execname);
                return dagen;
            }


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
    public DataSet book_chkpublishday_n(string compcode, string pkgname, string dateday, string date_for1)
    {
        DataSet dpub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dpub = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster chkpublishday = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dpub = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();
                // dpub = chkpublishday.book_chkpublishday(strid, compcode, pkgname, dateday, Session["dateformat"].ToString(), adcat, adtype, center, strid, pkgalias);

            }
        return dpub;

    }
    [Ajax.AjaxMethod]
    public DataSet gettempBookingIdNo(string compcode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            da = autocode.autogenratedtempid(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster autocode = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            da = autocode.autogenratedtempid(compcode);

        }
        return da;
    }
//To Bind Agency....
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency, string fla)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

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
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
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
        //txtagency.Items.Clear();
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select Agency";
        //li1.Value = "0";
        //li1.Selected = true;
        //txtagency.Items.Add(li1);

        //int i;
        //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    txtagency.Items.Add(li);
        //}


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getbillnobilldate(string bookingid, string insertno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = bindagenname.getbillnobilldate1(bookingid, insertno, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = bindagenname.getbillnobilldate1(bookingid, insertno, Session["compcode"].ToString(), Session["dateformat"].ToString());

        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet chkrono(string compcode,string userid,string agencycode,string rono)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking autocode = new NewAdbooking.Classes.adbooking();
            da = autocode.rono1(compcode, userid,agencycode,rono);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking autocode = new NewAdbooking.classesoracle.adbooking();
            da = autocode.rono1(compcode, userid, agencycode, rono);

        }
        return da;
    }
    //[Ajax.AjaxMethod]
    //public DataSet binddealtype(string compcode, string agencysplit, string subagency, string bookingdate, string color, string curr, string adcat, string clientsplit, string prod, string col, string code, string rate_cod, string adtype, string dateformat)
    //{
    //    DataSet ddeal = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdeal = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
    //        ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype);
    //    }

    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdeal = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
    //        ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype, dateformat);
    //    }

    //    else
    //    {
    //        NewAdbooking.classmysql.BookingMaster getdeal = new NewAdbooking.classmysql.BookingMaster();
    //        ddeal = getdeal.getdealvalue(compcode, subagency, agencysplit, bookingdate, color, curr, adcat, clientsplit, prod, col, code, rate_cod, adtype);
    //    }

    //    return ddeal;


    //}

    [Ajax.AjaxMethod]
    public DataSet allowdisc(string dealcode, string compcode, string agencysplit, string subagency, string clientsplit)
    {
        DataSet ddisc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddisc = getdisc.booking_getdealdisc(dealcode, compcode, agencysplit, subagency, clientsplit);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddisc = getdisc.booking_getdealdisc(dealcode, compcode, agencysplit, subagency, clientsplit,"","");
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster getdisc = new NewAdbooking.classmysql.BookingMaster();
            ddisc = getdisc.booking_getdealdisc(dealcode, compcode, agencysplit, subagency, clientsplit);
        }

        return ddisc;

    }

    [Ajax.AjaxMethod]
    public DataSet getDealP(string compcode, string contcode)
    {
        DataSet ddisc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddisc = getdisc.getDealP(compcode, contcode,"",0);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddisc = getdisc.getDealP(compcode, contcode,"",0);
        }


        return ddisc;

    }


    [Ajax.AjaxMethod]
    public DataSet getDealAmt(string conttype, string dealagency, string dealclient, string compcode, string contcode)
    {
        DataSet ddisc = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ddisc = getdisc.getDealAmt(conttype, dealagency, dealclient, compcode, contcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getdisc = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ddisc = getdisc.getDealAmt(conttype, dealagency, dealclient, compcode, contcode);
        }


        return ddisc;

    }


    [Ajax.AjaxMethod]
    public DataSet tolltipforratecode(string compcode, string ratecode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            ds = bindagenname.bindratecode(compcode, ratecode);
        }
        else
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();

            ds = bindagenname.bindratecode(compcode, ratecode);

        }
      //  drpratecode.ToolTip = ds.Tables[0].Rows[0]["REMARKS"].ToString(); 
        return ds;



    }
    [Ajax.AjaxMethod]
    public DataSet btnschme_Click(string adcat, string uom, string pkg, string color, string bookingdate)
    {

        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Master databind = new NewAdbooking.Classes.Master();
            //  da = databind.schemebind(adcat, uom, pkg, color, bookingdate);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.BookingMaster databind = new NewAdbooking.classesoracle.BookingMaster();
            //  NewAdbooking.classesoracle.Master databind = new NewAdbooking.classesoracle.Master();
            da = databind.schemebind(adcat, uom, pkg, color, bookingdate);
            return da;
        }
        //Divgrid1.Attributes.Add("style", "display:block;");
        return da;
    }
    [Ajax.AjaxMethod]
    public void btnSavecall(string compcod, string userid, string cioid, string agencycode)
    {
        DataSet ds1 = new DataSet();
        DataSet objdat1 = new DataSet();
        // Read in the XML file
        string datapath = (Server.MapPath("XML/dealmailbody.xml")).Replace("ajax\\", "");
        //  datapath.Replace("ajax\\","");
        objdat1.ReadXml(datapath);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
            ds1 = bind.getmailagency(compcod, userid, cioid, agencycode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
            ds1 = bindrate.getmailagency(compcod, userid, cioid, agencycode);
        }
        string mailtoval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();
        if (ds1.Tables[0].Rows.Count > 0)
        {            
            if (ds1.Tables[0].Rows[0]["EmailID"].ToString() == "" || ds1.Tables[0].Rows[0]["EmailID"].ToString() == null)
                mailtoval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();
            else
                mailtoval = ds1.Tables[0].Rows[0]["EmailID"].ToString();
        }

        string mailbody = cioid;
        mailbody = objdat1.Tables[0].Rows[0].ItemArray[9].ToString()+ " " + cioid;
        string smtpadd = objdat1.Tables[0].Rows[0].ItemArray[32].ToString();
        string mailfromval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();

        MailMessage msgMail = new MailMessage();
        msgMail.To = mailtoval;
        msgMail.From = mailfromval;
        msgMail.BodyFormat = MailFormat.Html;
        msgMail.Subject = "Regarding Request";
        msgMail.Body = mailbody;
        SmtpMail.SmtpServer = smtpadd;
        SmtpMail.Send(msgMail);
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getRegClientCheck(string adcat)
    {
        string chk = "0";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    chk = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //DataSet ds = new DataSet();
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster prev = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            ds = prev.getRegisterClientCheck(Session["compcode"].ToString(), adcat);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    chk = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getpayandstatus(string agencycode, string agencysubcode, string compcode, string getdatecheck, string dateformat)
    {
        DataSet dch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster getsta = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, "CL0");
            return dch;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster getsta = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, "CL0");
                return dch;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getsta = new NewAdbooking.classmysql.BookingMaster();
                dch = getsta.getstatuspaymode(agencycode, agencysubcode, compcode, getdatecheck, dateformat, "CL0");
                return dch;
            }


    }
    [Ajax.AjaxMethod]
    public DataSet bindagencusub(string agency, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindsub = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();

            ds = bindsub.bindsubagency(agency, compcode);


        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindsub = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();

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
    public DataSet GETCASH_PAY(string compcode, string paymode)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dx = bindrate.GETCASH_PAY(compcode, paymode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
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
    public DataSet CHECKBOOKINGCREDITLIMIT(string compcode, string agcodeforcreadit, string outstand, string billamt, string datecheck, string dateformat, string cioid, string modflag)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
            dex = showgri.CHECKBOOKINGCREDITLIMIT(compcode, agcodeforcreadit, outstand, billamt, datecheck, dateformat, cioid, modflag);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
            dex = showgri.CHECKBOOKINGCREDITLIMIT(compcode, agcodeforcreadit, outstand, billamt, datecheck, dateformat, cioid, modflag);
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
            //dex = showgri.fetchdataforexe(ciobid, compcode);
        }
        return dex;

    }


    [Ajax.AjaxMethod]
    public DataSet alert(string compcode, string agcode, string uom, string cat)
    {
        DataSet dex = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking showgri = new NewAdbooking.Classes.adbooking();
            dex = showgri.alert1(compcode, agcode, uom, cat);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking showgri = new NewAdbooking.classesoracle.adbooking();
            dex = showgri.alert1(compcode, agcode, uom, cat);
        }

        
        return dex;

    }

    ////////////////add by anuja////////////
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindPaymentMode(string agency, string compcode)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        if (Session["agency_name"].ToString() != "0")
        {
            foreach (DataRow dr1 in ds.Tables[0].Select())
            {
                if (dr1["pay_mode_code"].ToString() != "CR1")
                    dr1.Delete();

            }
            ds.AcceptChanges();
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindPaymentMode_e(string agency, string compcode)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency_e(agency, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency_e(agency, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        if (Session["agency_name"].ToString() != "0")
        {
            foreach (DataRow dr1 in ds.Tables[0].Select())
            {
                if (dr1["pay_mode_code"].ToString() != "CR1")
                    dr1.Delete();

            }
            ds.AcceptChanges();
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet insertcashdetail(string cioid, string idofbutton, string paymode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.cash_recipt objpkg = new NewAdbooking.Classes.cash_recipt();
            ds = objpkg.InsertCashDetail(cioid);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cash_recipt objpkg = new NewAdbooking.classesoracle.cash_recipt();
            ds = objpkg.InsertCashDetailmulti1(cioid, idofbutton, paymode);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string updatero(string compcode, string paymode, string booking_id, string rcptno, string cardmonth, string cardyear, string cardname, string cardtype, string cardnumber, string chkno, string chkdate, string chkamt, string chkbankname, string buttontype)
    {
        string ds = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cash_recipt clsbooking = new NewAdbooking.Classes.cash_recipt();
            ds = clsbooking.updaterostatus(compcode, paymode, booking_id, rcptno, cardmonth, cardyear, cardname, cardtype, cardnumber, chkno, chkdate, chkamt, chkbankname);
        }



        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cash_recipt clsbooking = new NewAdbooking.classesoracle.cash_recipt();
            ds = clsbooking.updaterostatus1(compcode, paymode, booking_id, rcptno, cardmonth, cardyear, cardname, cardtype, cardnumber, chkno, chkdate, chkamt, chkbankname, buttontype, Session["Username"].ToString());
        }
        else
        {
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //ds = clsbooking.getExec(compcode, execname, "0", "0");
        }
        return "true";

    }


    [Ajax.AjaxMethod]
    public DataSet binddata(string compcode, string firstinsert, string repatingdate, string dayflag, string pkgname, string EXT1, string EXT2, string EXT3, string EXT4, string EXT5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.cash_recipt objpkg = new NewAdbooking.Classes.cash_recipt();
            //ds = objpkg.InsertCashDetail(cioid);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objpkg = new NewAdbooking.classesoracle.BookingMaster();
            ds = objpkg.binddata(compcode, firstinsert, repatingdate, dayflag, pkgname, EXT1, EXT2, EXT3, EXT4, EXT5);
        }
        return ds;
    }


    ///////////////////////////////////////end ////////////////////////////////

    [Ajax.AjaxMethod]
    public DataSet getpubcountdis(string compcode, string packagecode, string adcategory, string adsubcategory)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objpkg = new NewAdbooking.Classes.BookingMaster();
            executequery = objpkg.getpubcountdiscount(compcode, packagecode, adcategory, adsubcategory);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objpkg = new NewAdbooking.classesoracle.BookingMaster();
            executequery = objpkg.getpubcountdiscount(compcode, packagecode, adcategory, adsubcategory);

        }
        return executequery;
    }
    [Ajax.AjaxMethod]
    public DataSet bindPaymentModedepo(string agency, string compcode)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getreciept(string compcode, string bookingid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cash_recipt objpkg = new NewAdbooking.Classes.cash_recipt();
            ds = objpkg.reciptget(compcode, bookingid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cash_recipt objpkg = new NewAdbooking.classesoracle.cash_recipt();
            ds = objpkg.reciptget(compcode, bookingid);
        }
        return ds;
    }
    protected void btnSave_Click1(object sender, ImageClickEventArgs e)
    {

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet onchangebg()
    {
        DataSet dsch = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindbgcolor = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            dsch = bindbgcolor.bgcolorbind_qbc(Session["compcode"].ToString(), "0", Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindbgcolor = new NewAdbooking.classmysql.BookingMaster();
            dsch = bindbgcolor.bgcolorbind(Session["compcode"].ToString(), "0");
        }
        return dsch;

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
  
    public void setSessionmis_paymenygetway(string Ro_no, string netamount, string name, string adderess, string city, string state, string country, string mobile, string email)
    {

        Session["Ro_no"] = Ro_no;
        Session["netamount"] = netamount;
        Session["name"] = name;

        Session["adderess"] = adderess;

        Session["city"] = city;
        Session["state"] = state;


        Session["country"] = country;
        Session["mobile"] = mobile;
        Session["email"] = email;
        
    }
    /////////////////////////bhanu
    [Ajax.AjaxMethod]
    public string backdate_validate(string pcompcode, string pformname, string puserid, string pentrydate, string pdateformat, string pextra1, string pextra2)
    {
        DataSet ds = new DataSet();
        string output = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                ds = execute.backdate_validate(pcompcode, pformname, puserid, pentrydate, pdateformat, pextra1, pextra2);
            }

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            output = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return output;
    }
    [Ajax.AjaxMethod]
    public DataSet getgstcode(string compcode, string agencycodesubcode, string client, string uom, string revenue, string adcategory, string bookdatetime, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, agencycodesubcode, client, uom, revenue, adcategory, bookdatetime, extra1, extra2, extra3, extra4, extra5 };
        string procedureName = "getgstdetail";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
}
