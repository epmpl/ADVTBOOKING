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
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

public partial class ADV_Page_Reservation : System.Web.UI.Page
{
    string email_id = "", user_id = "", publication = "", printing_center = "", client_name = "", page_position = "", ad_height = "", ad_weight = "",
           insert_date = "", cancel_remark = "", Id = "", emailid = "", email = "", branch_name = "", booked_date = "", USER_IDNAME = "",
           remark_note = "";
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
            hdncenter.Value = Session["center"].ToString();
            
            //hdnbrannm.Value = Session["revenuename"].ToString();
            hdnusernm.Value = Session["Username"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

            txtcreatedby.Text  = Session["Username"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(ADV_Page_Reservation));

        DataSet objDataSetbu = new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl         = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl        = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl      = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl       = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl     = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl      = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl       = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl    = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl        = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl        = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl      = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl        = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/ADV_Page_Reservation.xml"));
        lblrcode.Text       = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcreatedby.Text   = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblschdate.Text     = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbladsize.Text      = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblclient.Text      = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblpageprem.Text    = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblpubl.Text        = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbledtn.Text        = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblstatus.Text      = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblremark.Text      = ds.Tables[0].Rows[0].ItemArray[9].ToString();

        if (Request.QueryString["form"] != null && Request.QueryString["form"].ToString() == "ADV_Page_Reservation_EXE")
        {
            hdnmode.Value = "EXEC";
            hdntrnid.Value = Request.QueryString["trn_id"].ToString();
        }
        else
        {
            hdnmode.Value = "";
        }
        if (!Page.IsPostBack)
        {
            bindpageprem();
            bindpubl();
            btnNew.Attributes.Add("onclick", "javascript:return OnClickNew();");
            btnSave.Attributes.Add("onclick", "javascript:return OnClickSave();");
            btnModify.Attributes.Add("onclick", "javascript:return OnClickModify();");
            btnQuery.Attributes.Add("onclick", "javascript:return OnClickQuery();");
            btnExecute.Attributes.Add("onclick", "javascript:return OnClickExecute();");
            btnCancel.Attributes.Add("onclick", "javascript:return OnClickClear();");
            btnfirst.Attributes.Add("onclick", "javascript:return OnClickFirst();");
            btnprevious.Attributes.Add("onclick", "javascript:return OnClickPrevious();");
            btnnext.Attributes.Add("onclick", "javascript:return OnClickNext();");
            btnlast.Attributes.Add("onclick", "javascript:return OnClickLast();");
            btnDelete.Attributes.Add("onclick", "javascript:return OnClickDelete();");
            btnExit.Attributes.Add("onclick", "javascript:return OnClickExit();");
             
            txtclient.Attributes.Add("onkeydown", "javascript:return tabvalue(event);");
            txtclient.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtschdate.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtw.Attributes.Add("onblur", "javascript:return compare_date();");
            txth.Attributes.Add("onblur", "javascript:return chk_height();");
            txtclient.Attributes.Add("onblur", "javascript:return chk_client();");
            txtw.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txth.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            
            drppageprem.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drppubl.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            drpstatus.Attributes.Add("onchange", "javascript:return ststuschange();");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");
        }
        DataSet currdate = new DataSet();
        string[] parameterValueArray = { "1", Session["dateformat"].ToString() };
        string procedureName = "fn_get_next_dt";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            currdate = obj.BindCommanFunction(procedureName, parameterValueArray);
            hdncurrdate.Value = currdate.Tables[0].Rows[0].ItemArray[0].ToString();
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
    public void bindpubl()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "BINDPUBLICATION]";
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "BINDPUBLICATION.BINDPUBLICATION_P";
            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            string procedureName = "BINDPUBLICATION_BINDPUBLICATION_P";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dx = sms.DynamicBindProcedure(procedureName, parameterValueArray); 
        }

        drppubl.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Publication-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppubl.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppubl.Items.Add(li);
            }

        }


    }
    //[Ajax.AjaxMethod]
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
            string procedureName = "bind_pubcentname_res";
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
    public DataSet AD_RESERVE_DTL_IUD(string[] parameterValueArray)
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
            
            string procedureName = "AD_RESERVE_DTL_IUD";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

     [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
     public DataSet bind_pubcent(string comp_code, string unit_code, string extra1, string extra2, string extraflagm)
     {
         string mailbody = "";
         string cancel_status = "";
         string Statusbc = "";
         DataSet ds = new DataSet();
         string[] parameterValueArray = { comp_code, unit_code, extra1, extra2 };
         string procedureName = "send_mail_all_center";
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
             ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
             ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
         }
         else
         {
             NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
             ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
         }
         
         user_id = ds.Tables[0].Rows[0]["user_id"].ToString();
         for (int i = 0; i < ds.Tables[0].Rows.Count; i++){
             email=ds.Tables[0].Rows[i]["mail_id"].ToString();
             emailid = email + "," + emailid;
         }
         email_id = emailid;  //email_id.Substring(0, emailid.Length - 1);
         Id = extra1;  // this is AutoGenerated Id booking time
         publication = ds.Tables[1].Rows[0]["PUBLICATION"].ToString();
         printing_center = ds.Tables[1].Rows[0]["PRINTING_CENTER"].ToString();
         branch_name = ds.Tables[1].Rows[0]["BRAN_CODE"].ToString();
         client_name = ds.Tables[1].Rows[0]["CLIENT_NAME"].ToString();
         page_position = ds.Tables[1].Rows[0]["PAGE_POSITION"].ToString();
         ad_height = ds.Tables[1].Rows[0]["AD_HEIGHT"].ToString();
         ad_weight = ds.Tables[1].Rows[0]["AD_WEIDTH"].ToString();
         insert_date = ds.Tables[1].Rows[0]["INSERT_DATE"].ToString();
         booked_date = ds.Tables[1].Rows[0]["BOOK_DATE"].ToString();
         USER_IDNAME = ds.Tables[1].Rows[0]["USERID"].ToString();
         cancel_remark = ds.Tables[1].Rows[0]["CANCEL_REMARK"].ToString();
         //remark_note = "PLEASE BOOK SPACE ON FRONT/BACK PAGE AS PER THE DETAILS GIVEN BELOW : ";
         cancel_status = ds.Tables[1].Rows[0]["cancel_status"].ToString();

         //string mailbody = "SBNo.:" + Id + "\n" + "Publication :" + publication + "\n" + "Printing Center :" + printing_center + "\n" + "Client Name : " + client_name + "\n" + "Page Position : " + page_position + "\n" + "Height : " + ad_height + "\n" + "Weight : " + ad_weight + "\n" + "Insert Date : " + insert_date + "\n" + "Cancel Remark : " + cancel_remark ;

         if (cancel_status == "C")
         {
             Statusbc = "CANCEL";
             remark_note = "PLEASE CANCEL SPACE ON FRONT/BACK PAGE AS PER THE DETAILS GIVEN BELOW : ";
         }
         else
         {
             if(extraflagm == "U")
             {
                 Statusbc = "MODIFIED";
             }
             else
             {
                 Statusbc = "BOOKED";
             }
             remark_note = "PLEASE BOOK SPACE ON FRONT/BACK PAGE AS PER THE DETAILS GIVEN BELOW : ";
         }

         string SUBJECT = Statusbc + " Front/Back Page Reservation Details.";

         if (publication != "")
         {
             mailbody = remark_note + "\n\n" + "Remarks : " + cancel_remark + "\n\n" + "SBNo.: " + Id + "\n" + "Publication : " + publication + "\n" + "Publication Center : " + printing_center + "\n" + "Booking Center : " + branch_name + "\n" + "Client Name : " + client_name + "\n" + "Page Position : " + page_position + "\n" + "Width : " + ad_weight + "\n" + "Height : " + ad_height + "\n" + "Insert Date : " + insert_date + "\n" + "Booking Date : " + booked_date + "\n" + "Booked By : " + USER_IDNAME;
         }
         else
         {
             mailbody = remark_note + "\n\n" + "Remarks : " + cancel_remark + "\n\n" + "SBNo.: " + Id + "\n" + "Publication : " + publication + "\n"     + "Publication Center : " + printing_center + "\n" + "Booking Center : " + branch_name + "\n" + "Client Name : " + client_name + "\n" + "Page Position : " + page_position + "\n" + "Width : " + ad_weight + "\n" + "Height : " + ad_height + "\n" + "Insert Date : " + insert_date + "\n" + "Booking Date : " + booked_date + "\n" + "Booked By : " + USER_IDNAME;
         }

         SmtpClient smtp = new SmtpClient();
         smtp.Port = 25;
         smtp.Host = "203.197.142.35";
         smtp.Credentials = new NetworkCredential("adsonline", "advtupload");
         MailMessage email_msg = new MailMessage();
         MailMessage t_email_msg = new MailMessage();
         email_msg.To.Add(email_id);
         //email_msg.From = new MailAddress("adsonline@newindianexpress.com");
         email_msg.From = new MailAddress("4cplusadbooking@newindianexpress.com");
         email_msg.Subject = SUBJECT;// "Front/Back Page Reservation Details.";
         //email_msg.Body = mailstr + " " + mailbody;
         email_msg.Body = mailbody;
         email_msg.IsBodyHtml = false;
         smtp.Send(email_msg);
         return ds;
     }
     
    
}