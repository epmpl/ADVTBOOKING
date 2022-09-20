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

public partial class chkstate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string compcode, ssss, statename,statecode;

        if (Session["compcode"] == null)
        {

            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            //Response.Redirect("login.aspx");
            //Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        //userid = Session["userid"].ToString();
        //hiddenuserid.Value = userid;

        //username = Session["Username"].ToString();
        //hiddenusername.Value = username;

        compcode = Session["compcode"].ToString();
       // hiddencompcode.Value = compcode;

        statename = Request.QueryString["statename"].ToString();
        ssss = Request.QueryString["ssss"].ToString();

        statecode = Request.QueryString["statecode"].ToString();
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        
        NewAdbooking.Classes.StateMaster chk = new NewAdbooking.Classes.StateMaster();
       
        ds = chk.countstatecode(statename, ssss, statecode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.StateMaster chk = new NewAdbooking.classesoracle.StateMaster();

                ds = chk.countstatecode(statename, ssss, statecode);
            }
            else
            {
                NewAdbooking.classmysql.StateMaster chk = new NewAdbooking.classmysql.StateMaster();

                ds = chk.countstatecode(statename, ssss, statecode);
            }

        
        if (ds.Tables[0].Rows.Count > 0)
        {
            string response = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            response += "," + ds.Tables[0].Rows[0].ItemArray[1].ToString();
            Response.Write(response);
            Response.End();
        }
        else
        {
            Response.Write("YES");
            Response.End();    
        }
        

    }
}
