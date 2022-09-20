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
using System.Web.Mail;

public partial class Approvalmailform : System.Web.UI.Page
{
    string tabmail = "";
    string cioid = "";
    string fdate = "";
    string tdate = "";
    string basedon = "";
    string flag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Approvalmailform));
        if (Request.QueryString["bookingid"] != null)
            cioid = Request.QueryString["bookingid"].ToString();
        fdate = Request.QueryString["fdate"].ToString();
        tdate = Request.QueryString["tdate"].ToString();
        basedon = Request.QueryString["basedon"].ToString();
        if(Request.QueryString["flag"] != null)
        flag = Request.QueryString["flag"].ToString();
        if (!IsPostBack)
        {
            btnmail.Attributes.Add("OnClick", "javascript:return chkmailid();");
        }

        bindrecord();
    }

    private void bindrecord()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AuthorizationRelease frec = new NewAdbooking.Classes.AuthorizationRelease();
            ds = frec.findrecord(Session["userid"].ToString(), Session["compcode"].ToString(), "", "", "", fdate, tdate, Session["dateformat"].ToString(), cioid, flag, basedon, "","");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AuthorizationRelease frec = new NewAdbooking.classesoracle.AuthorizationRelease();
            ds = frec.findrecord(Session["userid"].ToString(), Session["compcode"].ToString(), "", "", "", fdate, tdate, Session["dateformat"].ToString(), cioid, flag, basedon, "","");

        }

        //==========**************Read mail info From Excel****************============================//
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/AuthorizationRelease_mail.xml"));
        string key = "1";

        string tabmail = "";
        string exec = "";
        string size = "";
        if (ds.Tables[0].Rows[0]["EXECUTIVE_NAME"].ToString() == "" || ds.Tables[0].Rows[0]["EXECUTIVE_NAME"].ToString() == null)
            exec = ds.Tables[0].Rows[0]["RETAINER_NAME"].ToString();
        else
            exec = ds.Tables[0].Rows[0]["EXECUTIVE_NAME"].ToString();

        if (ds.Tables[0].Rows[0]["AD_SIZE_HEIGHT"].ToString() == "" || ds.Tables[0].Rows[0]["AD_SIZE_WIDTH"].ToString() == null)
            size=ds.Tables[0].Rows[0]["SIZE_BOOK"].ToString();
        else
            size=ds.Tables[0].Rows[0]["AD_SIZE_HEIGHT"].ToString()+ "*"+ds.Tables[0].Rows[0]["AD_SIZE_WIDTH"].ToString();
                
        tabmail = tabmail + "<table align='center' cellpadding='0' cellspacing='0' >";
        //for (int k = 0; k < dsxml.Tables[2].Columns.Count; k++)
        //{
        //    tabmail = tabmail + "<tr><td align='left' colspan='3' style='font-family:verdana;font-size:12'>" + dsxml.Tables[2].Rows[0].ItemArray[k].ToString() + "</td>";
        //}
        //tabmail += "<tr><td style='font-family:verdana;font-size:12'><b>Process For Licensing Key:</b></td></tr>";
        tabmail = tabmail + "<tr><td align='left' colspan='3' style='font-family:verdana;font-size:12'>" + dsxml.Tables[2].Rows[0].ItemArray[0].ToString() + "</td></tr>";
        tabmail = tabmail + "<tr><td align='left' colspan='3' style='font-family:verdana;font-size:12'></td></tr>";
        tabmail = tabmail + "<tr rowspan='3'><td align='left' colspan='3' style='font-family:verdana;font-size:12'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dsxml.Tables[2].Rows[0].ItemArray[1].ToString() + "</td></tr>";

        tabmail = tabmail + "<tr style='height:10px;'><td align='left' colspan='3' style='font-family:verdana;font-size:12;'></td></tr>";

        tabmail += "<tr><td  style='font-family:verdana;font-size:9'><b>Agency:</b> </td><td colspan='2' align='left' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["AGENCY"].ToString() + "</td></tr>";
        tabmail += "<tr><td  style='font-family:verdana;font-size:9'><b>Agency City:</b> </td><td colspan='2' align='left' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["CITY_NAME"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>CLIENT</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["CLIENT"].ToString() + "</td></tr>";
        tabmail += "<tr><td  style='font-family:verdana;font-size:9'><b>Executive/Retainer:</b> </td><td colspan='2' align='left' style='font-family:verdana;font-size:9'>" + exec + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Size:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + size + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Ad cat:</b> </td><td  colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["AD_CAT_NAME"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Color:</b> </td><td  colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["COLOR_NAME"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Insertion Date:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["FIRST_INSDATE"].ToString() + "-" + ds.Tables[0].Rows[0]["LAST_INSDATE"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Package Name:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["PACKAGE"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Card Rate:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["Card_rate"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Agreed Rate:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["AGRRED_RATE"].ToString() + "</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Deviation:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["DEVIATION"].ToString() + "%</td></tr>";
        tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>Page No:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + ds.Tables[0].Rows[0]["PAGE_NO"].ToString() + "</td></tr>";
       // tabmail += "<tr><td style='font-family:verdana;font-size:9'><b>* Remark:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + Remark + "%</td></tr>";
        tabmail = tabmail + "</table>";
        mailbody.InnerHtml = tabmail.ToString();
    }
    protected void btnmail_Click(object sender, EventArgs e)
    {
        string fmailid = "";
        string mailmsg="";
        string remarkrow = "<tr><td style='font-family:verdana;font-size:9'><b>*Remark:</b> </td><td colspan='2' style='font-family:verdana;font-size:9'>" + txtremarks.Text + "</td></tr></table>";
        tabmail=mailbody.InnerHtml;
        mailbody.InnerHtml = tabmail.Replace("</table>", remarkrow);
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AuthorizationRelease frec = new NewAdbooking.Classes.AuthorizationRelease();
            //ds = frec.findrecord(Session["userid"].ToString(), Session["compcode"].ToString(), "", "", "", fdate, tdate, Session["dateformat"].ToString(), cioid, "", basedon, "");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AuthorizationRelease frec = new NewAdbooking.classesoracle.AuthorizationRelease();
            ds = frec.findloginid(Session["Username"].ToString(),Session["userid"].ToString());

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            fmailid = ds.Tables[0].Rows[0]["EMAIL"].ToString();
        }

        //==========**************Read mail info From Excel****************============================//
        //if (txtmailto.Text == "")
        //{
        //    Response.Write("<script>alert('Please fill mail id.');</script>");
        //    return;
        //}
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/AuthorizationRelease_mail.xml"));
        try
        {
      
            MailMessage msgMail = new MailMessage();
            msgMail.To = txtmailto.Text;
            if(txtmailcc.Text != "")
            msgMail.Cc = txtmailcc.Text;
            msgMail.From = fmailid;// dsxml.Tables[0].Rows[0].ItemArray[0].ToString();
            msgMail.BodyFormat = MailFormat.Html;
            //	msgMail.Bcc="susmita.d@creativebpo.com";
            msgMail.Subject = dsxml.Tables[0].Rows[0].ItemArray[3].ToString();
            msgMail.Body = mailbody.InnerHtml;//tabmail;
            SmtpMail.SmtpServer = dsxml.Tables[0].Rows[0].ItemArray[4].ToString();
            SmtpMail.Send(msgMail);

            mailmsg = "Email successfully sent.";
            Response.Write("<script>alert('Email successfully sent.');window.close();</script>");
            return;

        }
        catch (Exception ex)
        {
            mailmsg = ex.Message;
            Response.Write("<script>alert('" + mailmsg + "');</script>");
            return;
        }
    }
}
