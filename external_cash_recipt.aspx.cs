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

public partial class external_cash_recipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();

        hiddenbk_audit.Value = Session["audit"].ToString();


        hiddenserverip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(external_cash_recipt));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Booking_Audit1.xml"));
        //lblvfrm.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //lblvalidtill.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //lblagenysubcode.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
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
        //lblbrand.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lblheight.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        //lblproduct.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblspecialcharge.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblretainername.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lbllines.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbladdagecomm.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //lblnocolumns.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lblbookingtype.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lblpageposition.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lblgrossamt.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        //lblcurrency.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
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
        if (!Page.IsPostBack)
        {
            btnsubmit.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnclear.Attributes.Add("OnClick", "javascript:return cleardata();");
            btnmodify.Attributes.Add("OnClick", "javascript:return insertcashdetail();");
        }
    }
    [Ajax.AjaxMethod]
    public DataSet checkreci(string cioid, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.cash_recipt objpkg = new NewAdbooking.Classes.cash_recipt();
            ds = objpkg.chkreci(cioid, compcode,"");

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cash_recipt objpkg = new NewAdbooking.classesoracle.cash_recipt();
            ds = objpkg.chkreci(cioid, compcode,"");
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
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 executebullet = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
            //NewAdbooking.classesoracle.adsubcat executebullet = new NewAdbooking.classesoracle.adsubcat();
            //ds = executebullet.addcategoryname();
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
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet InsertCashDetailExternalSource(string cioid, string receipt, string compcode, string userid, string ip)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.cash_recipt objpkg = new NewAdbooking.Classes.cash_recipt();
            ds = objpkg.InsertCashDetailExternalSource(cioid, receipt, compcode, userid, ip);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cash_recipt objpkg = new NewAdbooking.classesoracle.cash_recipt();
            ds = objpkg.InsertCashDetailExternalSource(cioid, receipt, compcode, userid, ip);
        }
        return ds;
    }
}
