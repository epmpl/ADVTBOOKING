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

public partial class checkcurrency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string code;
        string dealcode = Request.QueryString["paise"].ToString();

        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.Contract checkcurr = new NewAdbooking.Classes.Contract();
        

        ds = checkcurr.currencychecked(dealcode,Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract checkcurr = new NewAdbooking.classesoracle.Contract();


                ds = checkcurr.currencychecked(dealcode, Session["compcode"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.Contract checkcurr = new NewAdbooking.classmysql.Contract();


            ds = checkcurr.currencychecked(dealcode, Session["compcode"].ToString());

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
             code = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
             code = "";
        }

        Response.Write(code);
        Response.End();


    }
}
