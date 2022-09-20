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

public partial class saveretainerpopups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string compcode, userid, dateformat;

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
            dateformat = Session["dateformat"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("yes");
            return;
        }

        compcode = Session["compcode"].ToString();

        string flag_Save = Request.QueryString["flag_Save"].ToString();
        string flag_null = Request.QueryString["flag_null"].ToString();

        if (flag_Save == "true" && flag_null == "false")
        {
            string retcode = Request.QueryString["retcode"].ToString();

            if ((Session["retainer_stat"] == "") || (Session["retainer_stat"] == null))
            {
            }
            else
            {

                //saurabh code------------------------------------------------

                
                //string status1 = Request.QueryString["status"].ToString();
                //string fromdate1 = Request.QueryString["fromdate"].ToString();
                //string todate1 = Request.QueryString["todate"].ToString();
                //string circular1 = Request.QueryString["circular"].ToString();
                //string centercode = Request.QueryString["centercode"].ToString();


                //---------------------------end--------------------------------

                DataSet db1 = (DataSet)Session["retainer_stat"];
                int er1 = db1.Tables[0].Rows.Count;
                int gf1 = db1.Tables.Count;
                for (int b = 0; b <= gf1 - 1; b++)
                {
                    string circular = db1.Tables[b].Rows[0].ItemArray[4].ToString();
                    string status= db1.Tables[b].Rows[0].ItemArray[5].ToString();
                    string fromdate = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[1].ToString());
                    string todate = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[2].ToString());
                    //string txtext = db.Tables[b].Rows[0].ItemArray[4].ToString();
                    //string txtfaxno = db.Tables[b].Rows[0].ItemArray[5].ToString();
                    //string mail = db.Tables[b].Rows[0].ItemArray[6].ToString();


                    DataSet ds1 = new DataSet();
                    if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                    {
                    NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();
                   
                    ds1 = insert.insertretstatus(compcode, userid, retcode, status, fromdate, todate, circular);
                    }
                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                            ds1 = insert.insertretstatus(compcode, userid, retcode, status, fromdate, todate, circular);

                        }
                    else
                    {
                        NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                        ds1 = insert.insertretstatus(compcode, userid, retcode, status, fromdate, todate, circular);

                    }
                }


            }

            if ((Session["retainer_pay"] != "") && (Session["retainer_pay"] != null))
            {
                string db3 = Session["retainer_pay"].ToString();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {


                    NewAdbooking.Classes.RetainerMaster retCode = new NewAdbooking.Classes.RetainerMaster();

                    retCode.insertData(compcode, retcode, userid, 0, db3);
                }

                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                         NewAdbooking.classesoracle .RetainerMaster retCode = new NewAdbooking.classesoracle.RetainerMaster();

                    retCode.insertData(compcode, retcode, userid, 0, db3);
                    }
                else
                {
                    NewAdbooking.classmysql.RetainerMaster retCode = new NewAdbooking.classmysql.RetainerMaster();

                    retCode.insertData(compcode, retcode, userid, 0, db3);
                }
                
            }

            if ((Session["retainer_comm"] == "") || (Session["retainer_comm"] == null))
            {
            }
            else
            {

                //saurabh code------------------------------------------------


                //string status1 = Request.QueryString["status"].ToString();
                //string fromdate1 = Request.QueryString["fromdate"].ToString();
                //string todate1 = Request.QueryString["todate"].ToString();
                //string circular1 = Request.QueryString["circular"].ToString();
                //string centercode = Request.QueryString["centercode"].ToString();


                //---------------------------end--------------------------------

                DataSet db1 = (DataSet)Session["retainer_comm"];
                int er1 = db1.Tables[0].Rows.Count;
                int gf1 = db1.Tables.Count;
                for (int b = 0; b <= gf1 - 1; b++)
                {
                    string txtefffrom = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[0].ToString());
                    string txtefftill = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[1].ToString());
                    string txtcommrate = db1.Tables[b].Rows[0].ItemArray[3].ToString();
                    string discount = db1.Tables[b].Rows[0].ItemArray[4].ToString();
                    string fromamt = db1.Tables[b].Rows[0].ItemArray[5].ToString();
                    string toamt = db1.Tables[b].Rows[0].ItemArray[6].ToString();
                    string txtaddcommrate = db1.Tables[b].Rows[0].ItemArray[7].ToString();
                    string updatecommission = "";
                    //string txtext = db.Tables[b].Rows[0].ItemArray[4].ToString();
                    //string txtfaxno = db.Tables[b].Rows[0].ItemArray[5].ToString();
                    //string mail = db.Tables[b].Rows[0].ItemArray[6].ToString();

                    DataSet ds1 = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {


                        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

                        ds1 = insert.RetainerCommission(retcode, userid, compcode, txtefffrom, txtefftill, txtcommrate, discount, updatecommission, 0,fromamt, toamt, txtaddcommrate);
                    }

                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                       NewAdbooking.classesoracle .RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                       ds1 = insert.RetainerCommission(retcode, userid, compcode, txtefffrom, txtefftill, txtcommrate, discount, updatecommission, 0, fromamt, toamt, txtaddcommrate);

                        }
                    else
                    {
                        NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                        //ds1 = insert.insertretcomm(compcode, userid, retcode, status, fromdate, todate, circular);
                        ds1 = insert.RetainerCommission(retcode, userid, compcode, txtefffrom, txtefftill, txtcommrate, discount, updatecommission, 0, fromamt, toamt, txtaddcommrate);

                    }

                }


            }

            //======================================== ad for Retainer Comm Structure===================================//
            //------------------------------------------------------------------------------------------------//
            if ((Session["retainer_comm_structure"] == "") || (Session["retainer_comm_structure"] == null))
            {
            }
            else
            {

                //saurabh code------------------------------------------------


                //string status1 = Request.QueryString["status"].ToString();
                //string fromdate1 = Request.QueryString["fromdate"].ToString();
                //string todate1 = Request.QueryString["todate"].ToString();
                //string circular1 = Request.QueryString["circular"].ToString();
                //string centercode = Request.QueryString["centercode"].ToString();


                //---------------------------end--------------------------------

                DataSet db1 = (DataSet)Session["retainer_comm_structure"];
                int er1 = db1.Tables[0].Rows.Count;
                int gf1 = db1.Tables.Count;
                for (int b = 0; b <= gf1 - 1; b++)
                {
                     string enln = db1.Tables[b].Rows[0].ItemArray[0].ToString();
                    string PTEAM_CODE = db1.Tables[b].Rows[0].ItemArray[1].ToString();
                    string PADCTG_CODE = db1.Tables[b].Rows[0].ItemArray[4].ToString();
                    string PFROM_TGT = db1.Tables[b].Rows[0].ItemArray[2].ToString();
                    string PTO_TGT = db1.Tables[b].Rows[0].ItemArray[3].ToString();
                    string PCUST_TYPE = db1.Tables[b].Rows[0].ItemArray[5].ToString();
                    string PAD_TYPE = db1.Tables[b].Rows[0].ItemArray[6].ToString();
                    string PPUB_TYPE = db1.Tables[b].Rows[0].ItemArray[7].ToString();
                    string PPUBL_CODE = db1.Tables[b].Rows[0].ItemArray[8].ToString();
                   // string PCOMM_TARGET_ID = db1.Tables[b].Rows[0].ItemArray[0].ToString();
                   // string PCREATED_BY = db1.Tables[b].Rows[0].ItemArray[1].ToString();
                   

                    DataSet ds1 = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

                        ds1 = insert.insertretcommstructure(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, enln);
                    }
                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                            ds1 = insert.insertretcommstructure(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, enln);

                        }
                    //else
                    //{
                    //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                    //    ds1 = insert.insertretstatus(compcode, userid, retcode, status, fromdate, todate, circular);

                    //}
                }


            }
            //======================================== ad for Retainer Slab===================================//
            //------------------------------------------------------------------------------------------------//
            if ((Session["retainer_slab"] == "") || (Session["retainer_slab"] == null))
            {
            }
            else
            {

                //saurabh code------------------------------------------------


                //string status1 = Request.QueryString["status"].ToString();
                //string fromdate1 = Request.QueryString["fromdate"].ToString();
                //string todate1 = Request.QueryString["todate"].ToString();
                //string circular1 = Request.QueryString["circular"].ToString();
                //string centercode = Request.QueryString["centercode"].ToString();


                //---------------------------end--------------------------------

                DataSet db1 = (DataSet)Session["retainer_slab"];
                int er1 = db1.Tables[0].Rows.Count;
                int gf1 = db1.Tables.Count;
                for (int b = 0; b <= gf1 - 1; b++)
                {
                   // string enln = db1.Tables[b].Rows[0].ItemArray[0].ToString();
                    string fromdays = db1.Tables[b].Rows[0].ItemArray[1].ToString();
                    string todays = db1.Tables[b].Rows[0].ItemArray[2].ToString();
                    string drpcommon = db1.Tables[b].Rows[0].ItemArray[3].ToString();
                    string commrate = db1.Tables[b].Rows[0].ItemArray[4].ToString();
                    string commid = db1.Tables[b].Rows[0].ItemArray[5].ToString();
                    string agency_type = db1.Tables[b].Rows[0].ItemArray[7].ToString();
                    DataSet ds1 = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

                        ds1 = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, drpcommon, commrate, commid, agency_type);
                    }
                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                            ds1 = insert.insertretstatus_slab(compcode, userid, retcode, fromdays, todays, drpcommon, commrate, commid, agency_type);

                        }
                        //else
                        //{
                        //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                        //    ds1 = insert.insertretstatus(compcode, userid, retcode, status, fromdate, todate, circular);

                        //}
                }


            }
            //======================================== ad for Retainer Slab===================================//
            //------------------------------------------------------------------------------------------------//
            if ((Session["retaineraddtionalcomm_slab"] == "") || (Session["retaineraddtionalcomm_slab"] == null))
            {
            }
            else
            {


                DataSet db1 = (DataSet)Session["retaineraddtionalcomm_slab"];
                int er1 = db1.Tables[0].Rows.Count;
                int gf1 = db1.Tables.Count;
                for (int b = 0; b <= gf1 - 1; b++)
                {
                    // string enln = db1.Tables[b].Rows[0].ItemArray[0].ToString();
                    string lstpub = db1.Tables[b].Rows[0].ItemArray[0].ToString();
                    string minpub = db1.Tables[b].Rows[0].ItemArray[1].ToString();
                    string publication = db1.Tables[b].Rows[0].ItemArray[2].ToString();
                    string commid = db1.Tables[b].Rows[0].ItemArray[3].ToString();

                    DataSet ds1 = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.RetainerMaster insert = new NewAdbooking.Classes.RetainerMaster();

                        ds1 = insert.insertretaddcomm(compcode, userid, retcode, lstpub, minpub, publication, commid);
                    }
                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.RetainerMaster insert = new NewAdbooking.classesoracle.RetainerMaster();

                            ds1 = insert.insertretaddcomm(compcode, userid, retcode, lstpub, minpub, publication, commid);

                        }
                    //else
                    //{
                    //    NewAdbooking.classmysql.RetainerMaster insert = new NewAdbooking.classmysql.RetainerMaster();

                    //    ds1 = insert.insertretstatus(compcode, userid, retcode, status, fromdate, todate, circular);

                    //}
                }


            }


        }
        else if (flag_Save == "false" && flag_null == "true")
        {
            Session["retainer_comm"] = null;
            Session["retainer_stat"] = null;
            Session["retainer_slab"] = null;
            Session["retainer_pay"] = null;
            Session["retainer_comm_structure"] = null;
            Session["retaineraddtionalcomm_slab"] = null;
        }




    }

    public string getDate(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        if (dateValue != "")
        {
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];

                dateReturn = mm + "/" + dd + "/" + yyyy;


            }
            //else if (dateformat == "yyyy/mm/dd")
            //{
            //    yyyy = myarrayfrom[0];
            //    mm = myarrayfrom[1];
            //    dd = myarrayfrom[2];

            //    dateReturn = mm + "/" + dd + "/" + yyyy;
            //}
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }
}
