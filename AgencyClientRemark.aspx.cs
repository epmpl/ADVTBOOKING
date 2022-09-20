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

public partial class AgencyClientRemark : System.Web.UI.Page
{
    string agency_code = "";
    string subagency_code = "";
    string cust_code = "";
    string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }

        if (Request.QueryString["agencode"] != null)
            agency_code = Request.QueryString["agencode"].ToString();
        if (Request.QueryString["subagencode"] != null)
            subagency_code = Request.QueryString["subagencode"].ToString();
        if (Request.QueryString["custcode"] != null)
            cust_code = Request.QueryString["custcode"].ToString();
        if (Request.QueryString["type"] != null)
            type = Request.QueryString["type"].ToString();
        bindgrid();
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master clsau = new NewAdbooking.classesoracle.Master();
            ds = clsau.getagencyclientremark(agency_code, subagency_code, cust_code, type, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        else
        {

            NewAdbooking.Classes.Master clsau = new NewAdbooking.Classes.Master();
            ds = clsau.getagencyclientremark(agency_code, subagency_code, cust_code, type, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (type == "A")
            {
                divagency.Attributes.Add("style", "display:block");
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }
            else
            {
                divclient.Attributes.Add("style", "display:block");
                DataGrid2.DataSource = ds;
                DataGrid2.DataBind();
            }
        }
        else
        {
            Response.Write("<script>alert('No Data Found.');window.close();</script>");
        }
    }
}
