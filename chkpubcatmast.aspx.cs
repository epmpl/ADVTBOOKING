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

public partial class chkpubcatmast : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;

        string centername = Request.QueryString["centername"].ToString();
        string city = Request.QueryString["city"].ToString();

        //saurabh agarwal 
        string modify = Request.QueryString["modify"].ToString();
        string code = Request.QueryString["code"].ToString();


        string center = "N";

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        if (centername != "" && city != "")
        {
            if (modify != "1")
            {
                DataSet ds = new DataSet();
                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
                NewAdbooking.Classes.PubCatMast chkcity = new NewAdbooking.Classes.PubCatMast();
                
                ds = chkcity.chkcity(compcode, userid, centername, city);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.PubCatMast chkcity = new NewAdbooking.classesoracle.PubCatMast();
                    ds = chkcity.chkcity(compcode, userid, centername, city);
                }
                else
                {
                    NewAdbooking.classmysql.PubCatMast chkcity = new NewAdbooking.classmysql.PubCatMast();

                    ds = chkcity.chkcity(compcode, userid, centername, city);

                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    center = "Y";
                }
                else
                {
                    center = "N";
                }
                Response.Write(center);
                Response.End();
            }
            else if (modify == "1")
            {
                DataSet ds1 = new DataSet();
                if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
                {

                NewAdbooking.Classes.PubCatMast chkcity = new NewAdbooking.Classes.PubCatMast();
               
                ds1 = chkcity.chkcitymodify(compcode, userid, centername, city, code);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.PubCatMast chkcity = new NewAdbooking.classesoracle.PubCatMast();

                    ds1 = chkcity.chkcitymodify(compcode, userid, centername, city, code);
                }
                else
                {
                    NewAdbooking.classmysql.PubCatMast chkcity = new NewAdbooking.classmysql.PubCatMast();

                    ds1 = chkcity.chkcitymodify(compcode, userid, centername, city, code);

                }
                

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    center = "Y";
                }
                else
                {
                    center = "N";
                }
                Response.Write(center);
                Response.End();
            }
        }
        // //{
       // //    NewAdbooking.Classes.PubCatMast getcount = new NewAdbooking.Classes.PubCatMast();
       // //    DataSet ds = new DataSet();
       // //    ds = getcount.valueofcount(country);

       // //    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
       // //    {

       // //        countrycode = ds.Tables[0].Rows[i].ItemArray[0].ToString() + "," + countrycode;
       // //        country = ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + country;


       // //    }
       // //    total = country + "+" + countrycode;
       // //    Response.Write(total);
       // //    Response.End();

       // //}
       // //else (chkadv == "query")
       // //{
       // //    Session["exesave"] = null;
       // //}

       
    }

}
