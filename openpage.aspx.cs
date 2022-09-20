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

public partial class openpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        string permission;

        if (Session["compcode"] != null)
        {
            string hiddencompcode = Session["compcode"].ToString();
            string hiddenuserid = Session["userid"].ToString();
            string formname = Request.QueryString["page"].ToString();

            DataSet dz = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {

        NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
       
        dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
            }
                else
                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="orcl")
                {
                    NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
                    dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
                }
            else
            {
                NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();

                dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
  
            }
        if (dz.Tables[0].Rows.Count > 0)
        {
            permission = dz.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            permission = "7";
        }
     
        Response.Write(permission);
        Response.End();
    }
    else
    {
        permission = "null";
        Response.Write(permission);
        Response.End();
    }
   
    }
}
