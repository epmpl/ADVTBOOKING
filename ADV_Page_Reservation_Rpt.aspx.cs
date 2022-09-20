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

public partial class ADV_Page_Reservation_Rpt : System.Web.UI.Page
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
            hiddencompcode.Value = Session["compcode"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hdnbrancd.Value = Session["revenue"].ToString();
            //hdnbrannm.Value = Session["revenuename"].ToString();
            hdnusernm.Value = Session["Username"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

            
        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(ADV_Page_Reservation_Rpt));

         
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/ADV_Page_Reservation.xml"));

        lblschdate0.Text        = ds.Tables[1].Rows[0].ItemArray[1].ToString();
        lblschdate.Text         = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        lbldestination.Text     = ds.Tables[1].Rows[0].ItemArray[2].ToString();
        lblpageprem.Text        = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        

        if (!Page.IsPostBack)
        {
            bindpageprem(); 
            

            
            txtschdate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            
            drppageprem.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            
        }
    }
    protected void txtschdate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txth_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtw_TextChanged(object sender, EventArgs e)
    {

    }
    public void bindpageprem()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.RateMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Sql.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), "DI0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster bindrate = new FourCPlus.AdBooking.BookingMaster.Oracle.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(), "DI0");
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), "DI0" };
            string procedureName = "bindpremiumforrate_bindpremiumforrate_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
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
 
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet pub_centbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract pub_cent1 = new NewAdbooking.classesoracle.Contract();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract pub_cent1 = new NewAdbooking.Classes.Contract();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), "", "" };
            string procedureName = "bind_pubcentname_new";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client, string fla)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
            if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            {
                //NewAdbooking.Classes.tv_booking_transaction clsbooking = new NewAdbooking.Classes.tv_booking_transaction();
                ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            }
            else
            {
                //FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
                ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            }
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
            {
                FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                ds = clsbooking.getClientName_DJ(compcode, client, Session["revenue"].ToString(), Session["CENTERDJ"].ToString(), Session["LOGINDJ"].ToString(), Session["PUBLICATIONDJ"].ToString(), Session["userid"].ToString());
            }
            else if (Session["FILTER"].ToString() == "D")
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                {
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
                else
                {
                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
            }
            else
            {
                if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
                {
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
                else
                {
                    //FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster clsbooking = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
                    NewAdbooking.classesoracle.tv_booking_transaction clsbooking = new NewAdbooking.classesoracle.tv_booking_transaction();
                    ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
                }
            }
        }

        else
        {
            string procedureName = "";
            string[] parameterValueArray = new string[] { compcode, client, Session["revenue"].ToString(), Session["userid"].ToString() };
            if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            {
                procedureName = "websp_get10clientName1";
            }
            else
            {
                procedureName = "websp_getclientName_websp_getclientName_p";
            }
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            //NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            //if (ConfigurationSettings.AppSettings["agencyf2"].ToString() == "Y" && fla == "Y")
            //{
            //    ds = clsbooking.get10ClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            //}
            //else
            //{
            //    ds = clsbooking.getClientName_n(compcode, client, Session["revenue"].ToString(), Session["userid"].ToString());
            //}
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet AD_RESERVE_REP(string[] parameterValueArray)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract pub_cent1 = new NewAdbooking.classesoracle.Contract();
            //ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract pub_cent1 = new NewAdbooking.Classes.Contract();
            //ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else
        {

            string procedureName = "AD_RESERVE_REP";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

}