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
using System.Web.Mail;

public partial class Forgetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Ajax.Utility.RegisterTypeForAjax(typeof(Forgetpassword));

        if (!IsPostBack)
        {
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitClick();");
            txtemail.Attributes.Add("OnBlur", "javascript:return clientemailcheck('txtemail');");
          
        }

    }

   
    [Ajax.AjaxMethod]
    public DataSet submitClick(string emailid)
    {
        DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.Forgetpassword abc = new NewAdbooking.Classes.Forgetpassword();
             ds = abc.userexecute(emailid);
         }
         else
         {
             NewAdbooking.classesoracle.Forgetpassword abc = new NewAdbooking.classesoracle.Forgetpassword();
             ds = abc.userexecute(emailid);

         }
         return ds;
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string emailid = txtemail.Text;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Forgetpassword abc = new NewAdbooking.Classes.Forgetpassword();
            ds = abc.fetchData(emailid);
        }
        else
        {
            NewAdbooking.classesoracle.Forgetpassword abc = new NewAdbooking.classesoracle.Forgetpassword();
            ds = abc.fetchData(emailid);

        }
        string tabmail = "";
        tabmail = tabmail + "<table>";
        tabmail = tabmail + "<tr><td align='left'>Hi&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]) + ",</td>";
        tabmail += "<tr><td></td></tr>";
        tabmail += "<tr><td align='left'>A request was made to send your password.</td></tr>";
        tabmail += "<tr><td>Your details are as follows: </td></tr>";
        tabmail += "<tr><td></td></tr>";
        tabmail += "<tr><td><b>User Id: </b> " + Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]) + "</td></tr>";
        tabmail += "<tr><td><b>Password: </b> " + Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]) + "</td></tr>";
      
        tabmail = tabmail + "</table>";
       // emailid = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]);
        
        MailMessage msgMail = new MailMessage();
        msgMail.To = txtemail.Text;
        msgMail.From = "lata@4cplus.com";
        msgMail.BodyFormat = MailFormat.Html;
        //	msgMail.Bcc="susmita.d@creativebpo.com";
        msgMail.Subject = "[HT Classified] Password Info";
        msgMail.Body = tabmail;
        SmtpMail.SmtpServer = "119.82.71.134";
        //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["EmailServer"];

        SmtpMail.Send(msgMail);
        string strAlert = "UserID and Password sent to your Email Address.";
        AspNetMessageBox(strAlert);
//        Response.Redirect("login.aspx");
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Forgetpassword), "ShowAlert", strAlert, true);
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage); AspNetMessageBox_close
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Forgetpassword), "ShowAlert", strAlert, true);
    }
}
