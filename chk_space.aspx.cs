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

public partial class chk_space : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        Response.Expires = -1;
        string flag = "0";
        string page_no = Request.QueryString["page_space"].ToString();
        string edit_name = Request.QueryString["edit_space"].ToString();
        string edit_date = Request.QueryString["date_space"].ToString();
        string compcode = Request.QueryString["comp_code"].ToString();
        string no = Request.QueryString["pageno_sp"].ToString();
         
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster chk = new NewAdbooking.Classes.BookingMaster();
            ds = chk.chkforspace(page_no, edit_name, edit_date, compcode, no);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster chk = new NewAdbooking.classesoracle.BookingMaster();
            ds = chk.chkforspace(page_no, edit_name, edit_date, compcode, no);
        }
          
       
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "1")
                {
                    flag = "1";
                }
                else
                {
                    flag = "0";
                }
            }
        }
        Response.Write(flag);
        Response.End();

    }
}
