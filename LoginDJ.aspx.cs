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

public partial class LoginDJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(LoginDJ));

        if (!Page.IsPostBack)
        {
            txtusername.Attributes.Add("OnChange", "javascript:return bindpublication();");
            drppublication.Attributes.Add("OnChange", "javascript:return bindcenter();");
            drploginth.Attributes.Add("OnChange", "javascript:return bindbranch();");
            drpcenter.Attributes.Add("OnChange", "javascript:return bindHoLo();");
            btnlogin.Attributes.Add("Onclick", "javascript:return login1();");
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bindpublication(string username)
    {
        DataSet ds = new DataSet();
       if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
            ds = logindetail.bindpublicationDJ(username);

        }
       return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindcenter(string username,string publication)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
            ds = logindetail.bindcenterDJ(username,publication);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindbranch(string username,string  publication,string loginth,string pcenter)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
            ds = logindetail.bindbranchDJ(username, publication, loginth, pcenter);
        }
        return ds;
    }
    
}
