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

public partial class printreceipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string bill = Request.QueryString["billamt"].ToString();
        string client = Request.QueryString["cli"].ToString();
        string curr = Request.QueryString["curr"].ToString();
        string pkg = Request.QueryString["desc"].ToString();

        DataSet ds = new DataSet();
        
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.Classes.BookingMaster getcurr = new NewAdbooking.Classes.BookingMaster();
      
        ds = getcurr.getname(curr,Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getcurr = new NewAdbooking.classesoracle.BookingMaster();

                ds = getcurr.getname(curr, Session["compcode"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getcurr = new NewAdbooking.classmysql.BookingMaster();

                ds = getcurr.getname(curr, Session["compcode"].ToString());

            }

        string currency = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        NumberToEngish cls_getwords = new NumberToEngish();
        string words=cls_getwords.changeNumericToWords(bill);
        string To = "TO,<br><br>";
        to.InnerHtml = To;


        string printrec = "Received with thanks from " + client + " a sum of "+currency+"  " + bill + " <br>";
        printrec = printrec + " "+words+" against printing of Display Ad in "+pkg+" publication ";

        printrem.InnerHtml = printrec;

        string admanager = "<br><br><B>Ad Manager</B>";
        ad.InnerHtml = admanager;
        if (!Page.IsPostBack)
        {
            Button1.Attributes.Add("onclick", "javascript:return printwindow();");

        }

    }
}
