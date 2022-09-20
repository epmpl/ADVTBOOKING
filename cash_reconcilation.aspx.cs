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

public partial class cash_reconcilation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenDateFormat.Value = Session["DateFormat"].ToString();
        hiddenusername.Value = Session["Username"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(cash_reconcilation));

        if (!IsPostBack)
        {
            btnsubmit.Attributes.Add("OnClick", "javascript:return openform();");
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmis_run(string optn)
    {

        Session["optn"] = optn;
    }
}