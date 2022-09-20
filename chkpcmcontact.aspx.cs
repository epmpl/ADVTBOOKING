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

public partial class chkpcmcontact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;


       // string compcode1 = Request.QueryString["compcode1"].ToString();
   //                     txtphoneno,txtext,txtfaxno,mail,desi,txtdob
        string contactperson = Request.QueryString["contactperson"].ToString();
        string centcode = Request.QueryString["centcode"].ToString();
        string sau = Request.QueryString["sau"].ToString();

        string txtphoneno = Request.QueryString["txtphoneno"].ToString();
        string txtext = Request.QueryString["txtext"].ToString();
        string txtfaxno = Request.QueryString["txtfaxno"].ToString();
        string mail = Request.QueryString["mail"].ToString();
        string desi = Request.QueryString["desi"].ToString();
        string txtdob = Request.QueryString["txtdob"].ToString();

        string center = "N";

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("yes");
            return;
        }
        compcode = Session["compcode"].ToString();
        if (compcode != "" && contactperson!= "")
        {
            if (sau == "saurabh")
            {
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.PubCatMast chkname = new NewAdbooking.Classes.PubCatMast();

                    ds = chkname.chkcolormod(contactperson, centcode, compcode, txtphoneno, txtext, txtfaxno, mail, desi, txtdob);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.PubCatMast chkname = new NewAdbooking.classesoracle.PubCatMast();
                    ds = chkname.chkcolormod(contactperson, centcode, compcode, txtphoneno, txtext, txtfaxno, mail, desi, txtdob);
                }
                else
                {
                    NewAdbooking.classmysql.PubCatMast chkname = new NewAdbooking.classmysql.PubCatMast();
                    ds = chkname.chkcolormod(contactperson, centcode, compcode, txtphoneno, txtext, txtfaxno, mail, desi, txtdob);
                }
                // return ds;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    center = "Y";
                    // value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    // value1 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    center = "N";
                    //value = "";
                    // value1 = "";
                }
            }
            else
            {
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.PubCatMast chkname = new NewAdbooking.Classes.PubCatMast();

                    ds = chkname.chkcolor(contactperson, centcode, compcode);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.PubCatMast chkname = new NewAdbooking.classesoracle.PubCatMast();
                    ds = chkname.chkcolor(contactperson, centcode, compcode);

                }
                else
                {
                    NewAdbooking.classmysql.PubCatMast chkname = new NewAdbooking.classmysql.PubCatMast();
                    ds = chkname.chkcolor(contactperson, centcode, compcode);
                }
                // return ds;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    center = "Y";
                    // value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    // value1 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    center = "N";
                    //value = "";
                    // value1 = "";
                }
            }

            Response.Write(center);
            //Response.Write(value1);
            Response.End();
        }







    }
}
