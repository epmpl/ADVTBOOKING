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

public partial class chkcurrency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "";
        string conv_currency = "";

        string currcode = Request.QueryString["currency"].ToString();
        string date = "N";
        string txtfromdate = Request.QueryString["date1"].ToString();
        string txtefftill = Request.QueryString["date2"].ToString();
        string txtconrate = Request.QueryString["convrate"].ToString();
        string insertcom = Request.QueryString["insertcom"].ToString();
        string compcode;
        string userid;
        if (Request.QueryString["conv_currency"] != null)
        {
            conv_currency = Request.QueryString["conv_currency"].ToString();
        }

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
         
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        if (Request.QueryString["saveconver"] != null)
        {
            if (Request.QueryString["saveconver"].ToString() == "save")
            {
                string dateformat = Session["dateformat"].ToString();
                DataSet db = (DataSet)Session["currencysave"];
                if (Session["currencysave"] != null)
                {
                    int er = db.Tables[0].Rows.Count;
                    int gf = db.Tables.Count;
                    for (int b = 0; b <= gf - 1; b++)
                    {
                        string txtconrate1 = db.Tables[b].Rows[0].ItemArray[1].ToString();
                        string currency = db.Tables[b].Rows[0].ItemArray[2].ToString();
                        string txtfromdate1 = getDate(dateformat, db.Tables[b].Rows[0].ItemArray[3].ToString());
                        string txtefftill1 = getDate(dateformat, db.Tables[b].Rows[0].ItemArray[4].ToString());
                        string txtcurcode1 = Request.QueryString["currcode"].ToString();
                        string txtunit = db.Tables[b].Rows[0].ItemArray[5].ToString();
                        DataSet ds1 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.currencymaster insertgr = new NewAdbooking.Classes.currencymaster();

                            ds1 = insertgr.insertconverrate(txtconrate1, txtfromdate1, txtefftill1, compcode, userid, txtcurcode1, currency, txtunit);
                        }
                        else
                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                            {
                                NewAdbooking.classesoracle.currencymaster insertgr = new NewAdbooking.classesoracle.currencymaster();

                                ds1 = insertgr.insertconverrate(txtconrate1, txtfromdate1, txtefftill1, compcode, userid, txtcurcode1, currency, txtunit);
                            }
                            else
                            {
                                NewAdbooking.classmysql.currencymaster insertgr = new NewAdbooking.classmysql.currencymaster();
                                ds1 = insertgr.insertconverrate(txtconrate1, txtfromdate1, txtefftill1, compcode, userid, txtcurcode1);

                            }

                    }
                }
                Session["currencysave"] = null;
                Response.Write("saved");
                Response.End();
            }
        }
        //else if (Request.QueryString["saveconver"] == null)
        //{
        //    Response.Write("add");
        //    Response.End();
        //}

        if (currcode != "" && txtfromdate == "d1")
        {
            DataSet dschk = new DataSet();
            if(ConfigurationSettings.AppSettings ["connectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.currencymaster chkcode = new NewAdbooking.Classes.currencymaster();
          
            dschk = chkcode.chkcurrcode(currcode, compcode, userid);
            }

            else
                if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.currencymaster chkcode = new NewAdbooking.classesoracle.currencymaster();
          
            dschk = chkcode.chkcurrcode(currcode, compcode, userid);

                }
            else
            {
                NewAdbooking.classmysql .currencymaster chkcode = new NewAdbooking.classmysql.currencymaster();

                dschk = chkcode.chkcurrcode(currcode, compcode, userid);
   
            }

            if (dschk.Tables[0].Rows.Count != 0)
            {

                date = "as";

            }
            else
            {
                if (currcode == "currency" && Session["currencysave"] == null && txtfromdate != "dcancel")
                {
                    date = "0";
                }
                else
                {
                    date = "1";
                }
               
            }
            Response.Write(date);
            Response.End();
        }
        else if (currcode == "currency" && txtfromdate == "dcancel")
        {
            Session["currencysave"] = null;
        }




        else if (currcode != "currency" && txtfromdate != "d1")
        {
            DataSet ds = new DataSet();
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.currencymaster chkdate = new NewAdbooking.Classes.currencymaster();

            ds = chkdate.chkdaetconv(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, conv_currency);
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.currencymaster chkdate = new NewAdbooking.classesoracle.currencymaster();

                    ds = chkdate.chkdaetconv(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode, conv_currency);



                }
                else
                {
                    NewAdbooking.classmysql.currencymaster chkdate = new NewAdbooking.classmysql.currencymaster();

                    ds = chkdate.chkdaetconv(txtconrate, txtfromdate, txtefftill, compcode, userid, currcode);

                }

            if (ds.Tables[0].Rows.Count > 0)
            {
                date = "Y";
            }
            else
            {
                date = "N";

            }

            

            Session["fromdate"] = txtfromdate;
            Session["tilldate"] = txtefftill;
            Session["insertcom"] = insertcom;


            Response.Write(date);
            Response.End();
        }
     
       

         
        
    }

    protected string getDate(string dateformat, string value)
    {
        if (dateformat == "dd/mm/yyyy")
        {
            string[] datearr = value.Split('/');
            string dd = datearr[0];
            string mm = datearr[1];
            string yy = datearr[2];
            value = mm + '/' + dd + '/' + yy;
        }
        return value;
    }
}
