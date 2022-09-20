using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class get_user_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
           // hiddenuser.Value = Request.QueryString["userid"].ToString();
            hiddenusername.Value = Session["Username"].ToString();
           // hiddenmodulename.Value = Request.QueryString["modulename"].ToString();
           // hiddendivision.Value = Request.QueryString["division"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(get_user_detail));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/get_user_detail.xml"));

        lblmodule.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblstatus.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcreationdtfrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcreationtodt.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbllastuseddtform.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbllastusedtodt.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnsummary.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnclear.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        btnexit.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbldestination.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        if (!Page.IsPostBack)
        {
            binddest();
            bindstatus();
            btnsummary.Attributes.Add("onclick", "javascript:return bind_summary();");
            btnclear.Attributes.Add("onclick", "javascript:return bind_clear();");
            btnexit.Attributes.Add("onclick", "javascript:return bind_exit();");

            txtuserid.Attributes.Add("onkeydown", "javascript:return FillUserId(event)");
            lstuser.Attributes.Add("onkeydown", "javascript:return onclickuser(event)");
            lstuser.Attributes.Add("onclick", "javascript:return onclickuser(event)");

            txtmodule.Attributes.Add("onkeydown", "javascript:return FillModule(event)");
            lstmodule.Attributes.Add("onkeydown", "javascript:return onclickmodule(event)");
            lstmodule.Attributes.Add("onclick", "javascript:return onclickmodule(event)");
        }
    }
    public void bindstatus()
    {
        dpdtatus.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/get_user_detail.xml"));
        for (int i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            dpdtatus.Items.Add(li);
        }
    }
    public void binddest()
    {

        dpdest.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/get_user_detail.xml"));

        for (int i = 0; i < ds1.Tables[2].Columns.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            dpdest.Items.Add(li);
        }


    }

    [Ajax.AjaxMethod]
    public DataSet fill_user(string extra1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
            ds = logindetail.getUser(extra1);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getUserlogin(extra1);
        }
         else 
        {
            string procedureName = "websp_getUser_websp_getUser_p";
            string[] parameterValueArray = { extra1 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet get_module(string user_id)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login ls = new NewAdbooking.Classes.login();
            ds = ls.getmodule();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.login ls = new NewAdbooking.classesoracle.login();
            ds = ls.getmodule();
        }
        else 
        {
            string procedureName = "user_privileges_module_bind_p";
            string[] parameterValueArray = { "","","","" };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
}