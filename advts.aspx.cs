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

public partial class advts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(advts));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddencenter.Value = Session["center"].ToString();
        lstcirrate.Attributes.Add("onclick", "javascript:return insertagency();");
        btnSubmit.Attributes.Add("OnClick", "javascript:return fillvts();");
        hiddenid.Value = Request.QueryString["id"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddenmode.Value = Request.QueryString["mode"].ToString();
    }
    [Ajax.AjaxMethod]
    public DataSet bindcirRate(string compcode, string center)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
           
                NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
                executequery = execute.bindcirRate(compcode, center);
           
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.bindcirRate(compcode, center);

        }
        return executequery;
    }
}
