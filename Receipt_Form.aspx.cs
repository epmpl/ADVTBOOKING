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

public partial class Receipt_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
            return;

        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Receipt_Form));
         // hiddenprereceipt.Value = Session["Receipt_no"].ToString();
          hiddencompcode.Value = Session["compcode"].ToString();

          if (!Page.IsPostBack)
          {
              btnsubmit.Attributes.Add("OnClick", "javascript:return printreceipt();");
          }
    }

    
 
    [Ajax.AjaxMethod]
    public DataSet getcioid(string recptno)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindclient = new NewAdbooking.classesoracle.BookingMaster();
            dx = bindclient.clsGetBookingID(recptno);
          
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindclient = new NewAdbooking.Classes.BookingMaster();
            dx = bindclient.clsGetBookingID(recptno);
        }
        else
        {
            //NewAdbooking.classesoracle.BookingMaster bindclient = new NewAdbooking.classesoracle.BookingMaster();
            //dx = bindclient.clsGetBookingID(recptno);
        }
        return dx;
    }
}
