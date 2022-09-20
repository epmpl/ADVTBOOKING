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

public partial class duplicacyaddon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string pub = Request.QueryString["publication"].ToString();
        string edit = Request.QueryString["edition"].ToString();
        string supp = Request.QueryString["supp"].ToString();
        string ratecode = Request.QueryString["rateid"].ToString();
        string flag = Request.QueryString["flag"].ToString();
        string type_age = Request.QueryString["type_age"].ToString();
        string value = "";
        //if flag =0 than we have to chk at Theme time of insert and if 1 than at update
        //if (flag == "0")
        //{
        DataSet dins = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons chkins = new NewAdbooking.Classes.adons();

            dins = chkins.chkdupins(ratecode, pub, edit, supp, Session["compcode"].ToString(), flag, type_age);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons chkins = new NewAdbooking.classesoracle.adons();
            //dins = chkins.chkdupins(ratecode, pub, edit, supp, Session["compcode"].ToString(), flag);
            dins = chkins.chkdupins(ratecode, pub, edit, supp, Session["compcode"].ToString(), flag, type_age);
        }
        else
        {
            NewAdbooking.classmysql.adons chkins = new NewAdbooking.classmysql.adons();
            dins = chkins.chkdupins(ratecode, pub, edit, supp, Session["compcode"].ToString(), flag);
        }
           

                if (dins.Tables[0].Rows.Count >= 1)
                {
                    value = "0";
                    Response.Write(value);
                    Response.End();
                }
                else
                {
                    value = "1";
                    Response.Write(value);
                    Response.End();

                }
           

           

    }
}
