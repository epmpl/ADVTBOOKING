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

public partial class EnterPage : System.Web.UI.Page
{
    public string tree = "";
    public string page;
   
    protected void Page_Load(object sender, System.EventArgs e)
    {



        Response.Expires = -1;

        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        
     
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenusername.Value = Session["Username"].ToString();
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(EnterPage));
        //Ajax.Utility.RegisterTypeForAjax(typeof(topbar1));
        //Ajax.Utility.RegisterTypeForAjax(typeof(ClientMaster));

        //Label2.Attributes.Add("OnClick","javascript:return akh13();");

        //dynamictreeview();
        //Label2.Attributes.Add("OnClick","javascript:return akh13();");

        // Put user code to initialize the page here

        //Label1.Text=Session["username"].ToString();

    }





    [Ajax.AjaxMethod]
    public DataSet submitpermission(string hiddencompcode, string hiddenuserid, string formname)
    {

        NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
        DataSet dz = new DataSet();
        dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
        return dz;
    }












    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion

    private void hiddencompcode_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void hiddenuserid_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }
}