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
public partial class followupmail : System.Web.UI.Page
{
    string idno = "";
    string compcode = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string fdate = "";
    string dateformat = "";
    string agency = "";
    string client = "";
    string tdate = "";
    string agencyname = "";
    string clintname = "";
    string agencymail = "";
    string excutivemail = "";
    string rono = "";
    string rodate = "";
    string packe = "";
    string page = "";
    string tabmail = "";
    string edtionname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        extra1 = Request.QueryString["idno"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();
        fdate = Request.QueryString["fdate"].ToString();
        tdate = Request.QueryString["tdate"].ToString();
        agency = Request.QueryString["agency"].ToString();
        client = Request.QueryString["client"].ToString();
        btnPrint.Attributes.Add("onclick", "javascript:return toid();");




        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.followup frec = new NewAdbooking.Classes.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.followup frec = new NewAdbooking.classesoracle.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);

        }

        agencyname = ds.Tables[0].Rows[0]["AGENCYNAME"].ToString();
        clintname = ds.Tables[0].Rows[0]["ClientName"].ToString();
        agencymail = ds.Tables[0].Rows[0]["MAIL"].ToString();
        excutivemail = ds.Tables[0].Rows[0]["EXEC_EMAILID"].ToString();
        rono = ds.Tables[0].Rows[0]["RONO"].ToString();
        rodate = ds.Tables[0].Rows[0]["RODATE"].ToString();
        packe = ds.Tables[0].Rows[0]["PACKAGENAME"].ToString();
        page = ds.Tables[0].Rows[0]["PAGE_NO"].ToString();
        edtionname = ds.Tables[0].Rows[0]["EDITIONNAME"].ToString();
        txt.Text = agencymail;
        textexcutive.Text = excutivemail;
        DataSet dsxml = new DataSet();
            dsxml.ReadXml(Server.MapPath("XML/followupmail.xml"));

         
            tabmail = tabmail + "<table>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail1'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'>" + agencyname + "</td></tr>";


            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + clintname + "<br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "&nbsp;<b>" + rono + "</b>&nbsp; &nbsp;" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() +"<b>"+ rodate + "</b></br></td></tr>";
            tabmail = tabmail + "<tr><br><td align='left' class='rep_mail'>" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "&nbsp; " + rodate + "&nbsp; &nbsp;" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "&nbsp; &nbsp;<b>" + page + "</b>&nbsp; &nbsp;" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "&nbsp;<b>" + packe + "</b></td></br></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><b>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</b> &nbsp; " + dsxml.Tables[1].Rows[0].ItemArray[16].ToString() + "</td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() +"<b>"+  edtionname + "<b></br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><b>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() +"</b>"+dsxml.Tables[1].Rows[0].ItemArray[17].ToString() + "</td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'><br>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</br></td></tr>";
            tabmail = tabmail + "<tr><td align='left' class='rep_mail'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td></tr>";
        
            tabmail = tabmail + "</table>";
           report.InnerHtml = tabmail;
          
    

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DataSet dsxml = new DataSet();
          dsxml.ReadXml(Server.MapPath("XML/followupmail.xml"));
        MailMessage msgMail = new MailMessage();
        msgMail.To = hdnto.Value;
        msgMail.Cc = hdnfrom.Value;
           msgMail.From = dsxml.Tables[0].Rows[0].ItemArray[0].ToString();
           msgMail.BodyFormat = MailFormat.Html;

            msgMail.Subject = dsxml.Tables[0].Rows[0].ItemArray[1].ToString();
            msgMail.Body = tabmail;
            SmtpMail.SmtpServer = dsxml.Tables[0].Rows[0].ItemArray[2].ToString();

           SmtpMail.Send(msgMail);
    }
}
