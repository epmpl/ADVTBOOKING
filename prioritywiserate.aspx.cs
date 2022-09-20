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


public partial class prioritywiserate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(prioritywiserate));
            hidpkgdesc.Value = Request.QueryString["pkgdesc"].ToString();
            hidrateid.Value = Request.QueryString["rateid"].ToString();
            hidpkgdesc.Value = hidpkgdesc.Value.Replace("~", "+");
            hidpriorityrate.Value = Request.QueryString["priority"].ToString();
            hidpriorityrateval.Value = Request.QueryString["priorityval"].ToString();
            hiddenchkbtnStatus.Value = Request.QueryString["chkbtnStatus"].ToString();
            btnsavedetail.Attributes.Add("OnClick", "javascript:return saveClick();");
            btncancel.Attributes.Add("OnClick", "javascript:return cancelClick();");
        }
    }
    [Ajax.AjaxMethod]
    public string insert_priority_rate(string rateuniqueid, string data)
    {
        string error = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster delete = new NewAdbooking.Classes.RateMaster();
             delete.insert_priority_rate(rateuniqueid, data, "UPDATE");

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster delete = new NewAdbooking.classesoracle.RateMaster();
            error = delete.insert_priority_rate(rateuniqueid, data, "UPDATE");


        }
        return error;
    }
    [Ajax.AjaxMethod]
    public DataSet getEditionDetail(string pkgdesc)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster insertchild = new NewAdbooking.classesoracle.RateMaster();
            ds=insertchild.getEditionDetail(pkgdesc);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster insertchild = new NewAdbooking.Classes.RateMaster();
            ds=insertchild.getEditionDetail(pkgdesc);
        }
        return ds;
    }
}
