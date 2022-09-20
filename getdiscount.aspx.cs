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

public partial class getdiscount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
    {
        Response.Expires = -1;

        string discount = Request.QueryString["page"].ToString();
        string compcode = Session["compcode"].ToString();
        string userid = Session["userid"].ToString();
        string username=Session["Username"].ToString();
        DataSet ds = new DataSet();

        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.Contract getdisc=new NewAdbooking.Classes.Contract();
      
        ds=getdisc.discvalue(discount,compcode,userid,username);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.Contract getdisc = new NewAdbooking.classesoracle.Contract();

                ds = getdisc.discvalue(discount, compcode, userid, username);

            }
            else
            {
                NewAdbooking.classmysql.Contract getdisc = new NewAdbooking.classmysql.Contract();

                ds = getdisc.discvalue(discount, compcode, userid, username);

            }

        string value = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        Response.Write(value);
        Response.End();

    }
}
