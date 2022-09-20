using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class upgradelicense : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(upgradelicense));
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            return;
        }
        btnupgradelicense.Attributes.Add("OnClick", "javascript:return CheckKey();");
        btnexit.Attributes.Add("OnClick", "javascript:return ExitClick();");
        hiddencompname.Value = Session["comp_name"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
    }
    [Ajax.AjaxMethod]
    public DataSet updateKey(string keyno,string compname,string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.license cls_lic = new NewAdbooking.Classes.license();
            ds=cls_lic.updateKey(compname, keyno, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.license cls_lic = new NewAdbooking.classesoracle.license();
            ds=cls_lic.updateKey(compname, keyno, userid);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public string fetchCompanyName()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.license cls_lic = new NewAdbooking.Classes.license();
            ds = cls_lic.fetchCompanyName();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.license cls_lic = new NewAdbooking.classesoracle.license();
            ds = cls_lic.fetchCompanyName();
        }
        string data = "";
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            data = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return data;
    }
}
