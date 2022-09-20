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

public partial class chkpubcatmast1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "", value1 = "", compcode, userid;
        //  string country = Request.QueryString["page"].ToString();
        //string chkadv=Request.QueryString["chk"].ToString();

        string centername = Request.QueryString["centername"].ToString();
        string city = Request.QueryString["city"].ToString();

        //saurabh agarwal 
        string modify = Request.QueryString["modify"].ToString();
        string code = Request.QueryString["code"].ToString();
        // string show = Request.QueryString["show"].ToString();

        if (Session["pubsave"] == null || Session["pubsave"] == "")
        {
            Response.Write("NO2");
            Response.End();
        }

        if (Session["pubstatus"] == null || Session["pubstatus"] == "")
        {
            Response.Write("NO3");
            Response.End();
        }

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
        if (centername != "" && city != "")
        {
            if (modify != "1")
            {
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
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
                Response.Write(center);
                //Response.Write(value1);
                Response.End();
            }
            else if (modify == "1")
            {
                DataSet ds1 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
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
                // return ds;

                if (ds1.Tables[0].Rows.Count > 0)
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
                Response.Write(center);
                //Response.Write(value1);
                Response.End();
            }
        }
        // //else
        // //{
        // //    if (chkadv == "query")
        // //    {
        // //        Session["pubsave"] = null;
        // //    }


        // //}
        // //else if (chkadv == "find")
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
