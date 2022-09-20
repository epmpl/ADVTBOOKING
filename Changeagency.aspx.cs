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

public partial class Changeagency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenusername.Value = Session["USERNAME"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();

        hdncode.Value = "";
        hdncodesubcode.Value = "";

        Ajax.Utility.RegisterTypeForAjax(typeof(Changeagency));
        if (!Page.IsPostBack)
        {


            btnsubmit.Attributes.Add("OnClick", "javascript:return executeclick();");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency(event);");
            btnupdate.Attributes.Add("OnClick", "javascript:return updateclick();");
            btnexit.Attributes.Add("OnClick", "javascript:return exit();");

        }

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Booking_Audit1.xml"));
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblagreedrate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //lbladdress1.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lbladdress2.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblagreedamount.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        //lblstatus.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpaymode.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpublichdate.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lblcredit.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbldiscount.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblrono.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblnoofinsertion.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblpositionpremium.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblrostatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //lblkeyno.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblpaid.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblspecialdiscount.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        //lblexezone.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lblexecutivename.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lblcontractname.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lblspacediscount.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lbloutstanding.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        
        lblheight.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
    
        lblspecialcharge.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblretainername.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lbllines.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbladdagecomm.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
      
        lblbookingtype.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lblpageposition.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lblgrossamt.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
      
        lblcolourtype.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lblpositionpre.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lblretainercommission.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbladcategory.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lblarea.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lblagtradediscount.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbladsubcat1.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lblschemetype.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lblbillamount.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbladsubcat2.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        lblratecode.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
        lbladsubcat3.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lblcardrate.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbladsubcat4.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lblcardamount.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        //lblremarks.Text = ds.Tables[0].Rows[0].ItemArray[44].ToString();
        lblSumAmt.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        lblPagePrem.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();

        //lbl_section.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
       lbagency.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
       // lbClient.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        lblbremark.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        lblcaption.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();
        lbltranslationcrg.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        lblboxcharg.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        //lblbooktyp.Text = ds.Tables[0].Rows[0].ItemArray[55].ToString();
        lbboxcharges.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
        lblagencyaddres.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        //lbalert.Text = ds.Tables[0].Rows[0].ItemArray[59].ToString();
        txtagency.ReadOnly = true;
        txtratecode.ReadOnly = true;
        txtclient.ReadOnly = true;
        txtadsubcat4.ReadOnly = true;
        txtcardrate.ReadOnly = true;
        txtagtradediscount.ReadOnly = true;
        txtagreedamount.ReadOnly = true;
        txtarea.ReadOnly = true;
        txtagreedrate.ReadOnly = true;
        txtgrossamt.ReadOnly = true;
        txtcardamount.ReadOnly = true;
        txtcontractname.ReadOnly = true;
        txtaddagecomm.ReadOnly = true;
        txtpackage.ReadOnly = true;
        txtdiscount.ReadOnly = true;
        txtpageposition.ReadOnly = true;
        txtexecutivename.ReadOnly = true;
        txtlines.ReadOnly = true;
        txtbookingtype.ReadOnly = true;
        txtheight.ReadOnly = true;
        txtcolourtype.ReadOnly = true;

        txtwidth.ReadOnly = true;
        txtspecialdiscount.ReadOnly = true;
        txtdiscount.ReadOnly = true;
        txtagreedrate.ReadOnly = true;
        txtschemetype.ReadOnly = true;
        txtpositionpre.ReadOnly = true;
        txtpaid.ReadOnly = true;
        txtpublishdate.ReadOnly = true;
        txtpositionpremium.ReadOnly = true;
        txtretainercommission.ReadOnly = true;
        txtadcategory.ReadOnly = true;
        txtadsubcat1.ReadOnly = true;
        txtuom.ReadOnly = true;
        txtoutstanding.ReadOnly = true;
        txtadsubcat2.ReadOnly = true;
        txtspecialcharge.ReadOnly = true;
        txtadsubcat3.ReadOnly = true;
        txtrono.ReadOnly = true;
        txtrostatus.ReadOnly = true;
        txtretainername.ReadOnly = true;
        txtpaymode.ReadOnly = true;
        txtnoofinsertion.ReadOnly = true;
        txtspacediscount.ReadOnly = true;
        txtbillamount.ReadOnly = true;
        //txtremarks.Enabled = false;
   
        //btnrefresh.Enabled = false;




        txtdiscountamt.ReadOnly = true;
        txtPagePrem.ReadOnly = true;
        txtPagePremamt.ReadOnly = true;
        txtpositionpremiumamt.ReadOnly = true;
        txtspecialdiscount.ReadOnly = true;
        txtspecialdiscountamt.ReadOnly = true;
        txtspacediscount.ReadOnly = true;
        txtspacediscountamt.ReadOnly = true;
        txtSumAmt.ReadOnly = true;
        txtretainercommissionamt.ReadOnly = true;
        txtagtradediscountamt.ReadOnly = true;

        txtaddagecommamt.ReadOnly = true;



    }



    [Ajax.AjaxMethod]
    public DataSet updateagency(string comcode, string agency, string agencysubcode, string pid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 executebullet = new NewAdbooking.Classes.Booking_Audit1();
           // executebullet.updateagency(comcode, agency, agencysubcode, pid);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "updatechangeagency";
            string[] parameterValueArray = { comcode, agency, agencysubcode, pid };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 executebullet = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = executebullet.updateagency(comcode, agency, agencysubcode, pid);
           
        }
        return ds;
    }



        [Ajax.AjaxMethod]
    public DataSet execute(string bookingid, string compcode, string adtype, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 executebullet = new NewAdbooking.Classes.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "executebookingdispaudit_executebookingdispaudit_p";
            string[] parameterValueArray = { compcode, bookingid, "", "", "", "", "", adtype, dateformat };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 executebullet = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
           
        }
        return ds;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getagencyRemark(string compcode, string bookingid, string agency, string client, string type1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindgencyRemark(compcode, bookingid, agency, client, type1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            ds = bindagenname.bindgencyRemark(compcode, bookingid, agency, client, type1);

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ADB_GETAGENCY_ADD";
            string[] parameterValueArray = { compcode, bookingid, agency, client, type1, type1 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getPackageName(string compcode, string pkg_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.publish_audit objpkg = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = objpkg.clsPackageName(compcode, pkg_code);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Booking_Audit1 objpkg = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = objpkg.clsPackageName(compcode, pkg_code);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "websp_PackageName_websp_PackageName_p";
            string[] parameterValueArray = { compcode, pkg_code  };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }





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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
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
                    //ds = bindagenname.bind10agency(compcode, userid, agency, Session["center"].ToString());

                    ds = bindagenname.bindagency_DB(compcode , agency);

                else
                    ds = bindagenname.bindagency(compcode, userid, agency, Session["center"].ToString());
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                    ds = bindagenname.bindagency_DB(compcode, agency);
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










}
