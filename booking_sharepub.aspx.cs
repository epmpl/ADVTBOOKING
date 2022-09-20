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


public partial class booking_sharepub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddenpackagecode.Value=Request.QueryString["package"].ToString();
        hiddenpackagecode.Value = hiddenpackagecode.Value.Replace("~", "+");
        hiddencompcode.Value = Request.QueryString["compcode"].ToString();
        hiddencioid.Value = Request.QueryString["cioid"].ToString();
        hiddeninsertstatus.Value = Request.QueryString["insertstatus"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(booking_sharepub));
        hiddensharepub.Value = Request.QueryString["sharepub"].ToString();
        hiddenagreedamt.Value = Request.QueryString["agreedamt"].ToString();
        btncancel.Attributes.Add("OnClick", "javascript:return closepopup();");
        btnsavedetail.Attributes.Add("OnClick", "javascript:return saveClick();");
        if (hiddeninsertstatus.Value == "0")
        {

            btnsavedetail.Enabled = true;
            drpsharingtype.Enabled = true;

        }
        else
        {
            btnsavedetail.Enabled = false;
            drpsharingtype.Enabled = false;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getPubSharing(string packagecode, string compcode,string cioid)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getPubSharing(packagecode, compcode, cioid);

        }
        return executequery;
    }
}
