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

public partial class packagename : System.Web.UI.Page
{
    string flag="";
    int validdatechk;
    string sun, mon, tue, wed, thu, fri, sat,day;
    DataSet dpub = new DataSet();
    DataSet dpub1 = new DataSet();
    string dateday;
    string pkgname;
    string adcat = "0";
    string chkbtnstatusdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        
        if (Request.QueryString["adcat"] != null)
        {
            adcat = Request.QueryString["adcat"].ToString();
        }
        string center = "";
        string adtype = "";
        string pkgalias = "";
        if (Request.QueryString["pkgalias"] != null)
        {
            pkgalias = Request.QueryString["pkgalias"].ToString();
        }
        if (Request.QueryString["center"] != null)
        {
            center = Request.QueryString["center"].ToString();
        }
        if (Request.QueryString["adtype"] != null)
        {
            adtype = Request.QueryString["adtype"].ToString();
        }
        string strid = Request.QueryString["pkgid"].ToString();
        string compcode = Request.QueryString["compcode"].ToString();
        string value = Request.QueryString["value"].ToString();

        if (Request.QueryString["chkbtnstatusdate"] != null)
        {
            chkbtnstatusdate = Request.QueryString["chkbtnstatusdate"].ToString();
        }
        else
        {
            chkbtnstatusdate = "";
        }

        if (Request.QueryString["pkgname"] != null)
        {
            pkgname = Request.QueryString["pkgname"].ToString();
            if (pkgname == "")
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpkg = new NewAdbooking.classesoracle.BookingMaster();
                    DataSet ds_combin = new DataSet();
                    ds_combin = getpkg.getCombinDesc(strid);
                    if (ds_combin.Tables[0].Rows.Count > 0)
                    {
                        pkgname = ds_combin.Tables[0].Rows[0].ItemArray[0].ToString();
                    }

                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                }
                else
                {
                    /*DataSet ds_combin = new DataSet();
                    string[] parameterValueArray = new string[] { strid };
                    string procedureName = "GETCOMBINDESC";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    ds_combin = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
                    NewAdbooking.classmysql.BookingMaster getpkg = new NewAdbooking.classmysql.BookingMaster();
                    DataSet ds_combin = new DataSet();
                    ds_combin = getpkg.getCombinDesc(strid);

                    if (ds_combin.Tables[0].Rows.Count > 0)
                    {
                        pkgname = ds_combin.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                }
            }
        }
        pkgname = pkgname.Replace("^", "+");
        strid = strid.Replace("^", "+");
         dateday=Request.QueryString["dateday"].ToString();
         string flagedition = "0";
        //////////bhanu 9june
         string date_for1 = Session["dateformat"].ToString();
         if (dateday != "")
         {
             //if (pkgname.IndexOf("+") > 0)
             //{

             //    string[] arr = null;
             //    arr = pkgname.Split("+".ToCharArray());
             //    for (int j = 0; j <= arr.Length - 1; j++)
             //    {
             //        pkgname = arr[j];
             //    }
                 

             //}
             //else
             //{
                 if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                 {
                     NewAdbooking.Classes.BookingMaster chkpublishday = new NewAdbooking.Classes.BookingMaster();
                     dpub1 = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);
                 }

                 else
                     if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                     {

                         NewAdbooking.classesoracle.BookingMaster chkpublishday = new NewAdbooking.classesoracle.BookingMaster();
                         dpub1 = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);

                     }
                     else
                     {
                        NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();
                         dpub1 = chkpublishday.book_chkpublishday_n(compcode, pkgname, dateday, date_for1);

                         //string[] parameterValueArray = new string[] { compcode, pkgname, dateday };
                         //string procedureName = "getperiodDate_Edition";
                         //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                         //dpub1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                     }

                 if (dpub1.Tables.Count > 0 && dpub1.Tables[0].Rows.Count > 0)
                 {
                     if (dpub1.Tables[0].Rows[0].ItemArray[0].ToString() != "0")
                     {
                         flag = dpub1.Tables[0].Rows[0].ItemArray[0].ToString();
                         Response.Write(flag);
                         Response.End();
                     }
                 }
             //}
         }
        ////////////bhanuend
        if (value == "0")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpkg = new NewAdbooking.Classes.BookingMaster();
                ds = getpkg.book_packagename(strid, compcode);
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                
                {
                NewAdbooking.classesoracle .BookingMaster getpkg = new NewAdbooking.classesoracle.BookingMaster();
                ds = getpkg.book_packagename(strid, compcode);

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster getpkg = new NewAdbooking.classmysql.BookingMaster();
                ds = getpkg.book_packagename(strid, compcode);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                flag = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            }
            else
            {
                flag = "0";
            }
        }
        else
        {
            flag = "0";
            string date_for = Session["dateformat"].ToString();
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster chkpublishday = new NewAdbooking.Classes.BookingMaster();
                dpub = chkpublishday.book_chkpublishday(strid, compcode, pkgname, dateday, date_for, adcat, adtype, center, strid, pkgalias);
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    /*change for oracle*/
                  
                    /////////////////////
                 NewAdbooking.classesoracle .BookingMaster chkpublishday = new NewAdbooking.classesoracle.BookingMaster();
                 dpub = chkpublishday.book_chkpublishday(strid, compcode, pkgname, dateday, date_for, adcat,adtype,center,strid,pkgalias);

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster chkpublishday = new NewAdbooking.classmysql.BookingMaster();
                //string[] arr = null;
                //arr = pkgname.Split(",".ToCharArray());
                //string datasplit = "";
                //for (int j = 0; j <= arr.Length - 1; j++)
                //{
                //    if (j == 0)
                //    {
                //        datasplit = arr[j];
                //    }
                //    else
                //    {
                //        datasplit = datasplit + "'',''" + arr[j];
                //    }
                //}
                /*new change 15 mar*/
                datesavechkmysql dat = new datesavechkmysql();
                //datesavemysql dat = new datesavemysql();
                 /*mysql*/
                //dateday = dat.getDate_mysql(Session["dateformat"].ToString(),dateday);
                //dpub = chkpublishday.book_chkpublishday(strid, compcode, pkgname, dateday);
                if (chkbtnstatusdate == "modify")
                {
                    dpub = chkpublishday.book_chkpublishday_modify(strid, compcode, pkgname, dateday, Session["dateformat"].ToString(), adcat, adtype, center, strid, pkgalias, chkbtnstatusdate);
                }
                else
                {
                    dpub = chkpublishday.book_chkpublishday(strid, compcode, pkgname, dateday, Session["dateformat"].ToString(), adcat, adtype, center, strid, pkgalias);
                }
                    
            }
            //0 is for sun,1 is for mon .....7 is for sat
            if (dpub.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dpub.Tables[0].Rows.Count; i++)
                {
                    flag = "0";
                    day = dpub.Tables[0].Rows[i].ItemArray[7].ToString();
                    if (day == "Sun")
                    {
                        sun = dpub.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (sun == "Y")
                        {
                            flag = "1";

                        }
                        else
                        {
                            /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(0);
                            }
                            goto s1;

                        }
                    }
                    if (day == "Mon")
                    {
                        mon = dpub.Tables[0].Rows[i].ItemArray[1].ToString();
                        if (mon == "Y")
                        {
                            flag = "1";

                        }
                        else
                        {
                             /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(1);
                            }
                            goto s1;
                        }
                    }
                    if (day == "Tue")
                    {
                        tue = dpub.Tables[0].Rows[i].ItemArray[2].ToString();
                        if (tue == "Y")
                        {
                            flag = "1";
                            goto s1;
                        }
                        else
                        {
                             /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(2);
                            }
                            goto s1;
                        }
                    }
                    if (day == "Wed")
                    {
                        wed = dpub.Tables[0].Rows[i].ItemArray[3].ToString();
                        if (wed == "Y")
                        {
                            flag = "1";

                        }
                        else
                        {
                             /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(3);
                            }
                            goto s1;
                        }
                    }
                    if (day == "Thu")
                    {
                        thu = dpub.Tables[0].Rows[i].ItemArray[4].ToString();
                        if (thu == "Y")
                        {
                            flag = "1";

                        }
                        else
                        {
                             /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(4);
                            }
                            goto s1;
                        }
                    }
                    if (day == "Fri")
                    {
                        fri = dpub.Tables[0].Rows[i].ItemArray[5].ToString();
                        if (fri == "Y")
                        {
                            flag = "1";

                        }
                        else
                        {
                             /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(5);
                            }
                            goto s1;
                        }
                    }
                    if (day == "Sat")
                    {
                        sat = dpub.Tables[0].Rows[i].ItemArray[6].ToString();
                        if (sat == "Y")
                        {
                            flag = "1";

                        }
                        else
                        {
                             /*new change ankur 24 feb*/
                            if (Session["validdate_pub"].ToString() == "yes")
                            {
                                chkvaliddate(6);
                            }
                            goto s1;
                        }
                    }


                }
            }
            else
            {
                flag = "1";

            }
        s1:
            if (dpub.Tables.Count > 1)
            {
                if (dpub.Tables[1].Rows.Count > 0)
                {
                    flag = "0";
                    /*change */
                    chkvaliddate(0);

                }
            }
            flagedition = "1";
            if (dpub.Tables.Count > 2)
            {
                if (dpub.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < dpub.Tables[2].Rows.Count; i++)
                    {
                        flagedition = "0";
                        day = dpub.Tables[2].Rows[i].ItemArray[7].ToString();
                        if (day == "Sun")
                        {
                            sun = dpub.Tables[2].Rows[i].ItemArray[0].ToString();
                            if (sun == "Y")
                            {
                                flagedition = "1";

                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                               // flagedition = "0";
                               //     chkvaliddate(0);
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(0);
                                }
                                break;

                            }
                        }
                        if (day == "Mon")
                        {
                            mon = dpub.Tables[2].Rows[i].ItemArray[1].ToString();
                            if (mon == "Y")
                            {
                                flagedition = "1";

                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                             //  flagedition = "0";
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(1);
                                }
                                break;
                            }
                        }
                        if (day == "Tue")
                        {
                            tue = dpub.Tables[2].Rows[i].ItemArray[2].ToString();
                            if (tue == "Y")
                            {
                                flagedition = "1";
                                break;
                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                             //   flagedition = "0";
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(2);
                                }
                                break;
                            }
                        }
                        if (day == "Wed")
                        {
                            wed = dpub.Tables[2].Rows[i].ItemArray[3].ToString();
                            if (wed == "Y")
                            {
                                flagedition = "1";

                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                              //  flagedition = "0";
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(3);
                                }
                                break;
                            }
                        }
                        if (day == "Thu")
                        {
                            thu = dpub.Tables[2].Rows[i].ItemArray[4].ToString();
                            if (thu == "Y")
                            {
                                flagedition = "1";

                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                              //  flagedition = "0";
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(4);
                                }
                                break;
                            }
                        }
                        if (day == "Fri")
                        {
                            fri = dpub.Tables[2].Rows[i].ItemArray[5].ToString();
                            if (fri == "Y")
                            {
                                flagedition = "1";

                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                              //  flagedition = "0";
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(5);
                                }
                                break;
                            }
                        }
                        if (day == "Sat")
                        {
                            sat = dpub.Tables[2].Rows[i].ItemArray[6].ToString();
                            if (sat == "Y")
                            {
                                flagedition = "1";

                            }
                            else
                            {
                                /*new change ankur 24 feb*/
                               // flagedition = "0";
                                if (Session["validdate_pub"].ToString() == "yes")
                                {
                                    chkvaliddate(6);
                                }
                                break;
                            }
                        }


                    }

                }
            }
      

        }


      /*  if (flagedition != "1" && value!="0")
        {
            flag = "0";
        }
       */

        Response.Write(flag);
        Response.End();
    }
    /*new change ankur 24 feb*/
 
    // /this is to get te next valid date
    /*new change ankur 24 feb*/
    public void chkvaliddate(int addday)
    {
        string center = "";
        string adtype = "";
        string pkgalias = "";
        string strid = Request.QueryString["pkgid"].ToString();
        strid = strid.Replace("^", "+");
        if (Request.QueryString["center"] != null)
        {
            center = Request.QueryString["center"].ToString();
        }
        if (Request.QueryString["adtype"] != null)
        {
            adtype = Request.QueryString["adtype"].ToString();
        }
        if (Request.QueryString["pkgalias"] != null)
        {
            pkgalias = Request.QueryString["pkgalias"].ToString();
        }
        NewAdbooking.Classes.BookingMaster chkpublishday = new NewAdbooking.Classes.BookingMaster();
                NewAdbooking.classesoracle .BookingMaster chkpublishdayorcl = new NewAdbooking.classesoracle.BookingMaster();


        DataSet dvaid = new DataSet();
        int dateadd;
               
                    flag = "0";
                    
                            validdatechk = 0;
                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                            {
                                dvaid = chkpublishday.getvaliddate_qbc_New(Session["dateformat"].ToString(), dateday, pkgname, adcat, center, adtype, strid, pkgalias);
                            }

                            else
                                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                                {
                                    dvaid = chkpublishdayorcl.getvaliddate_qbc_New(Session["dateformat"].ToString(), dateday, pkgname, adcat,center,adtype,strid,pkgalias);

                                }

                               
                            else
                            {
                               /* datesavechkmysql dat1 = new datesavechkmysql();
                                //dateday=dat1.getDate_mysql(Session["dateformat"].ToString(),dateday);
                                NewAdbooking.classmysql.BookingMaster chkpublishday1 = new NewAdbooking.classmysql.BookingMaster();
                                dvaid = chkpublishday1.getvaliddate_qbc(Session["dateformat"].ToString(), dateday, pkgname);
                                    */
                                string[] parameterValueArray = new string[] { Session["dateformat"].ToString(), dateday, pkgname, adcat, center, adtype, strid, pkgalias };
                                string procedureName = "get_validdate_qbc_get_validdate_qbc_P";
                                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                                dvaid = sms.DynamicBindProcedure(procedureName, parameterValueArray);

                            }
                            if (dvaid.Tables[0].Rows.Count > 0 && dvaid.Tables[0].Rows[0].ItemArray[0].ToString() != "" && dvaid.Tables[0].Rows[0].ItemArray[0].ToString() != null)
                            {
                                flag = dvaid.Tables[0].Rows[0].ItemArray[0].ToString();
                            }
                            else
                            {
                                flag="0";
                            }
                           // break;

                        
                    


      }



    
}
