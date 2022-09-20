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

public partial class chkpackageforbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["dateformat"] == null)
        {
            Response.Write("2");
            Response.End();
        }
        string adcat3 = "0";
        string adcat4 = "0";
        string adcat5 = "0";
        if (Request.QueryString["adcat3"] != null)
        {
            adcat3 = Request.QueryString["adcat3"].ToString();
        }
        if (Request.QueryString["adcat4"] != null)
        {
            adcat4 = Request.QueryString["adcat4"].ToString();
        }
        if (Request.QueryString["adcat5"] != null)
        {
            adcat5 = Request.QueryString["adcat5"].ToString();
        }
        string flag = "";
        string adtype = Request.QueryString["adtype"].ToString();
        string adcategory = Request.QueryString["adcat"].ToString();
        string color = Request.QueryString["color"].ToString();
        string adscat = Request.QueryString["adsucat"].ToString();
        string curr = Request.QueryString["currency"].ToString();
        string ratcod = Request.QueryString["ratecode"].ToString();
        string pack = Request.QueryString["package1"].ToString();
        string chkdate = Request.QueryString["selecdate"].ToString();
        string compcode = Session["compcode"].ToString();
        string uom = Request.QueryString["uomvalue"].ToString();
        string premium = Request.QueryString["prem_insert"].ToString();
        string line = Request.QueryString["line"].ToString();
        string insert = Request.QueryString["insert"].ToString();
        string clientname = Request.QueryString["clientname"].ToString();
        //string adcat3 = Request.QueryString["adcat3"].ToString();
        //string adcat4 = Request.QueryString["adcat4"].ToString();
        //string adcat5 = Request.QueryString["adcat5"].ToString();
        string noof_ins = Request.QueryString["noof_ins"].ToString();
        /*new change ankur for agency*/
        /*new change ankur 11 feb*/
        string agency_code = "";
        string uomdesc="";
        if(Request.QueryString["agency_code"]!=null)
            agency_code = Request.QueryString["agency_code"].ToString();
        string qbc = "";
        if (Request.QueryString["qbc_"] != null)
        {
            qbc = Request.QueryString["qbc_"].ToString();
        }

        if (adtype == "DI0")
        {
            line = "";
        }

        //string code   = Request.QueryString["code"].ToString();
        //string desc = Request.QueryString["desc"].ToString();
        //string cardrateval = Request.QueryString["cardrateval"].ToString();
        if(Request.QueryString["uomdesc"]!=null)
        
        uomdesc = Request.QueryString["uomdesc"].ToString();

        if (adtype == "DI0" && qbc=="")
        {
            try
            {
                DataSet dr = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster rate = new NewAdbooking.Classes.BookingMaster();

                    dr = rate.getrate(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, premium, clientname, noof_ins);
                }

                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster rate = new NewAdbooking.classesoracle.BookingMaster();

                        dr = rate.getrate(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, premium, clientname, noof_ins,adcat3,adcat4,adcat5);





                    }


                else
                {
                    NewAdbooking.classmysql.BookingMaster rate = new NewAdbooking.classmysql.BookingMaster();

                    dr = rate.getrate(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, premium, clientname, noof_ins);

                }


                if (dr.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                }
                else
                {
                    flag = "0";
                }

            }
            catch (Exception ex)
            {
                flag = "0";
                Response.Write(flag);
                Response.End();



            }
        }
        else
        {
            try
            {

                DataSet dr = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.Classes.BookingMaster rate = new NewAdbooking.Classes.BookingMaster();
                    /*new change ankur for agency*/
                    if (agency_code != "classified")
                    {
                        if (Session["agencyratecode"].ToString() == "no")
                        {
                            dr = rate.class_getrate_qbc(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, noof_ins, uomdesc);
                        }
                        else
                        {
                            dr = rate.class_getrate_qbcagency(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, noof_ins, uomdesc, agency_code);
                        }
                    }
                    else
                    {
                        dr = rate.class_getrate_qbc(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, noof_ins, uomdesc);
                    }
                }


                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        string date_format = Session["dateformat"].ToString();
                        NewAdbooking.classesoracle.BookingMaster rate = new NewAdbooking.classesoracle.BookingMaster();
                        /*new change ankur for agency*/
                        /*change for oracle*/
                        if (agency_code != "classified")
                        {
                            
                            if (Session["agencyratecode"].ToString() == "no")
                            {
                                
                                dr = rate.class_getrate_qbc(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, noof_ins, uomdesc,date_format);
                            }
                            else
                            {
                                dr = rate.class_getrate_qbcagency(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, noof_ins, uomdesc, agency_code,date_format);
                            }
                        }
                        else
                        {
                            dr = rate.class_getrate_qbc(adtype, color, adcategory, adscat, curr, ratcod, pack, chkdate, compcode, uom, insert, line, premium, adcat3, adcat4, adcat5, clientname, noof_ins, uomdesc,date_format);
                        }
                        /////////////////////////////////////
                    }
                else
                {
                    NewAdbooking.classmysql.BookingMaster rate = new NewAdbooking.classmysql.BookingMaster();
                    //string dateformat="mm/dd/yyyy";

                    //datesavemysql convertmysql = new datesavemysql();
                    //if (chkdate != "")
                    //{
                    //    chkdate = convertmysql.getDate(Session["dateformat"].ToString(), chkdate);
                    //}

                     /*new change ankur for agency*/
                    if (agency_code != "classified")
                    {
                        if (Session["agencyratecode"].ToString() == "no")
                        {
                            dr = rate.getpkgrate(pack, insert, chkdate, chkdate, Session["dateformat"].ToString(), compcode, adcategory, adscat, color, adtype, curr, ratcod, chkdate, "", pack, "", uom, "", "", insert, line, adcat3, adcat4, adcat5, clientname, uomdesc);
                        }
                        else
                        {
                            dr = rate.getpkgrate_agency(pack, insert, chkdate, chkdate, Session["dateformat"].ToString(), compcode, adcategory, adscat, color, adtype, curr, ratcod, chkdate, "", pack, "", uom, "", "", insert, line, adcat3, adcat4, adcat5, clientname, uomdesc, agency_code);
                        }
                    }
                    else {
                        dr = rate.getpkgrate(pack, insert, chkdate, chkdate, Session["dateformat"].ToString(), compcode, adcategory, adscat, color, adtype, curr, ratcod, chkdate, "", pack, "", uom, "", "", insert, line, adcat3, adcat4, adcat5, clientname, uomdesc);
                    }


                }

                if (dr.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                }
                else
                {
                    flag = "0";
                }
            }

          
            catch (Exception ex)
            {
                flag = "0";
                Response.Write(flag);
                Response.End();



            }

        }
        Response.Write(flag);
        Response.End();


    }
}
