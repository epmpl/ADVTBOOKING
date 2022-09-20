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

public partial class Attachmentdelete : System.Web.UI.Page
{
    string compcode = "";
    string receiptno = "";
    string formname = "";
    string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        formname = "Attachmentdelete";
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        if (Session["Username"] == null && Request.QueryString["Username"] == null)
        {
            Response.Write("<script>alert('Your Session has been Expired!'); window.parent.location=\" login.aspx\";</script>)");
            return;
        }
        hiddencompcode.Value = Session["compcode"].ToString();
        compcode = hiddencompcode.Value;

        Ajax.Utility.RegisterTypeForAjax(typeof(Attachmentdelete));

        if (!Page.IsPostBack)
        {
            getbuttoncheck(formname);
            btndel.Attributes.Add("onclick", "javascript:return del();");
        }

    }
    public void getbuttoncheck(string formname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
             NewAdbooking.Classes.classlibraryforbutton perm = new NewAdbooking.Classes.classlibraryforbutton();
            ds = perm.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classlibraryforbutton perm = new NewAdbooking.classesoracle.classlibraryforbutton();
                ds = perm.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
            }

        if (ds.Tables[0].Rows.Count <= 0 || ds.Tables[0].Rows[0].ItemArray[0].ToString() == "0")
        {
            //Response.Write("<script> alert('You are not authorised to view this page');window.parent.location = 'Default.aspx';</script>");        
            Response.Write("<script> alert('You are not authorised to view this page');window.close();</script>");
            return;
        }

        id = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        hdn_btn_permission.Value = id.ToString();


        if (id == "7" || id == "15")
        {

            if (id == "7")
            {
                Session["FlagStatus"] = "7";
            }
            else
            {
                Session["FlagStatus"] = "15";

            }

        }
        else
        {
            Response.Write("<script> alert('You are not authorised to view this page');window.close();</script>");
        }

    }



    [Ajax.AjaxMethod]
    public DataSet selectval(string compcode, string receiptno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.attachmentdel recpt = new NewAdbooking.Classes.attachmentdel();
            ds = recpt.selectval(compcode, receiptno);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.attachmentdel recpt = new NewAdbooking.classesoracle.attachmentdel();
                ds = recpt.selectval(compcode, receiptno);

            }
        return ds;
    }



    [Ajax.AjaxMethod]
    public DataSet deletefun(string compcode, string receiptno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.attachmentdel recpt = new NewAdbooking.Classes.attachmentdel();
            ds = recpt.receiptdel(compcode, receiptno);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.attachmentdel recpt = new NewAdbooking.classesoracle.attachmentdel();
                ds = recpt.receiptdel(compcode, receiptno);

            }
        return ds;
    }
}


    




