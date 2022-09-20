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

public partial class valueforcontact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string contactperson = Request.QueryString["contactperson"].ToString();
        string agencycode = Request.QueryString["agencycode"].ToString();
        string subagencycode = Request.QueryString["subagencycode"].ToString();
        string val="";
        string proval="";
        NewAdbooking.Classes.pop getcontact = new NewAdbooking.Classes.pop();
        DataSet dz = new DataSet();
        dz = getcontact.getthevalue(contactperson, agencycode, subagencycode,Session["compcode"].ToString(),Session["userid"].ToString());

        for (int i = 0; i <= dz.Tables[0].Rows.Count - 1; i++)
        {
            val = dz.Tables[0].Rows[i].ItemArray[0].ToString();
            proval =  val + proval ;

        }
        string finalval = proval;
       
        Response.Write(finalval);
        Response.End();

    }
}
