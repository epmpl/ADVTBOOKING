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

public partial class chkclient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["Username"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }
        string client = Request.QueryString["client"].ToString();
        string save = Request.QueryString["save"].ToString();
        string custcode = Request.QueryString["code"].ToString();
        string userid = Session["userid"].ToString();
        string compcode = Session["compcode"].ToString();
        if (Session["client_stat"] == null)
        {
            Response.Write("NO2");
            Response.End();
        }
        if (client == "new")
        {
            Session["client_cont"] = null;
            Session["client_stat"] = null;
            Session["client_prod"] = null;
            Session["client_pay"] = null;
            Session["client_exec"] = null;
            Session["client_brand"] = null;
        }
        else if (Session["client_cont"] != null || Session["client_stat"] != null || Session["client_prod"] != null || Session["client_pay"] != null || Session["client_exec"] != null || Session["client_brand"] != null)
        {
            if (save == "Y")
            {
                if (Session["client_prod"] != null)
                {
                    DataSet db2 = (DataSet)Session["client_prod"];
                    int er2 = db2.Tables[0].Rows.Count;
                    int gf2 = db2.Tables.Count;
                    for (int b2 = 0; b2 <= gf2 - 1; b2++)
                    {
                        string client_name = db2.Tables[b2].Rows[0].ItemArray[0].ToString();
                        string product_code = db2.Tables[b2].Rows[0].ItemArray[3].ToString();
                        string exec_code = db2.Tables[b2].Rows[0].ItemArray[4].ToString();
                        DataSet ds2 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.ClientProdMastr prodinsert = new NewAdbooking.Classes.ClientProdMastr();

                            ds2 = prodinsert.insertclientcode(custcode, client_name, product_code, compcode, userid, exec_code);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.ClientProdMastr prodinsert = new NewAdbooking.classesoracle.ClientProdMastr();
                            ds2 = prodinsert.insertclientcode(custcode, client_name, product_code, compcode, userid, exec_code);
                        }
                        else
                        {
                            NewAdbooking.classmysql.ClientProdMastr prodinsert = new NewAdbooking.classmysql.ClientProdMastr();
                            ds2 = prodinsert.insertclientcode(custcode, client_name, product_code, compcode, userid);
                        }
                    }
                }
                if (Session["client_cont"] != null)
                {
                    DataSet db = (DataSet)Session["client_cont"];
                    int er = db.Tables[0].Rows.Count;
                    int gf = db.Tables.Count;
                    for (int b = 0; b <= gf - 1; b++)
                    {
                        string contactperson = db.Tables[b].Rows[0].ItemArray[0].ToString();
                        string txtdob = db.Tables[b].Rows[0].ItemArray[1].ToString();
                        //string desi = db.Tables[b].Rows[0].ItemArray[2].ToString();
                        string txtphoneno = db.Tables[b].Rows[0].ItemArray[2].ToString();
                        string txtext = db.Tables[b].Rows[0].ItemArray[3].ToString();
                        string txtfaxno = db.Tables[b].Rows[0].ItemArray[4].ToString();
                        string mail = db.Tables[b].Rows[0].ItemArray[5].ToString();
                        string anniversary = db.Tables[b].Rows[0].ItemArray[7].ToString();
                        string mobile = db.Tables[b].Rows[0].ItemArray[8].ToString();
                        txtdob = getDate(Session["dateformat"].ToString(), txtdob);
                        anniversary = getDate(Session["dateformat"].ToString(), anniversary);


                        DataSet ds1 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.ClientMasterpopup contactinsert = new NewAdbooking.Classes.ClientMasterpopup();

                            ds1 = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, custcode, compcode, anniversary, mobile);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.ClientMasterpopup contactinsert = new NewAdbooking.classesoracle.ClientMasterpopup();
                            ds1 = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, custcode, compcode, anniversary, mobile);
                        }
                        else
                        {
                            NewAdbooking.classmysql.ClientMasterpopup contactinsert = new NewAdbooking.classmysql.ClientMasterpopup();
                            ds1 = contactinsert.insertcontact(contactperson, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, custcode, compcode);
                        }
                        //Response.Write("YES");
                        //Response.End();
                    }
                }

                if (Session["client_stat"] != null)
                {
                    DataSet db1 = (DataSet)Session["client_stat"];
                    int er1 = db1.Tables[0].Rows.Count;
                    int gf1 = db1.Tables.Count;
                    for (int b1 = 0; b1 <= gf1 - 1; b1++)
                    {
                        string status = db1.Tables[b1].Rows[0].ItemArray[0].ToString();
                        string fromdate = db1.Tables[b1].Rows[0].ItemArray[1].ToString();
                        string todate = db1.Tables[b1].Rows[0].ItemArray[2].ToString();
                        string circular = db1.Tables[b1].Rows[0].ItemArray[4].ToString();
                        string attach = db1.Tables[b1].Rows[0].ItemArray[6].ToString();
                   //     string remark = db1.Tables[b1].Rows[0].ItemArray[7].ToString();

                        string remark = "";
                        fromdate = getDate(Session["dateformat"].ToString(), fromdate);
                        todate = getDate(Session["dateformat"].ToString(), todate);

                        //string txtext = db.Tables[b].Rows[0].ItemArray[3].ToString();
                        //string txtfaxno = db.Tables[b].Rows[0].ItemArray[4].ToString();
                        //string mail = db.Tables[b].Rows[0].ItemArray[5].ToString();
                        DataSet ds1 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.ClientMasterpopup statusinsert = new NewAdbooking.Classes.ClientMasterpopup();

                            ds1 = statusinsert.insertstatus11(status, fromdate, todate, custcode, compcode, userid, circular, attach,remark);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.ClientMasterpopup statusinsert = new NewAdbooking.classesoracle.ClientMasterpopup();
                            ds1 = statusinsert.insertstatus11(status, fromdate, todate, custcode, compcode, userid, circular, attach,remark);
                        }
                        else
                        {

                            string procedureName = "sp_insertclientstatus";
                            string[] parameterValueArray = new string[] { custcode, status, ConvertToDateTime(fromdate), ConvertToDateTime(todate), userid, compcode, circular, attach, remark };
                            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray); 
                            /*NewAdbooking.classmysql.ClientMasterpopup statusinsert = new NewAdbooking.classmysql.ClientMasterpopup();
                            ds1 = statusinsert.insertstatus11(status, fromdate, todate, custcode, compcode, userid, circular);
                             * */
                        }

                        //Response.Write("YES");
                        //Response.End();
                    }
                }

                if (Session["MySelectedValue"] != null)
                {
                    string db3 = Session["MySelectedValue"].ToString();
                    //int er2 = db2.Tables[0].Rows.Count;
                    //int gf2 = db2.Tables.Count;
                    //for (int b2 = 0; b2 <= gf2 - 1; b2++)
                    //{
                    //    string client_name = db2.Tables[b2].Rows[0].ItemArray[0].ToString();
                    //    string product_code = db2.Tables[b2].Rows[0].ItemArray[2].ToString();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.ClientMasterpopup CustCode = new NewAdbooking.Classes.ClientMasterpopup();
                        //DataSet ds3 = new DataSet();
                        CustCode.insertData(compcode, custcode, userid, 0, db3);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.ClientMasterpopup CustCode = new NewAdbooking.classesoracle.ClientMasterpopup();
                        CustCode.insertData(compcode, custcode, userid, 0, db3);

                    }
                    else
                    {
                        NewAdbooking.classmysql.ClientMasterpopup CustCode = new NewAdbooking.classmysql.ClientMasterpopup();
                        CustCode.insertData(compcode, custcode, userid, 0, db3);

                    }

                    //}
                }

                /*************************              shachi          *******************************/

                //if (Session["client_exec"] != null)
                //{
                //    DataSet db21 = (DataSet)Session["client_exec"];
                //    int er21 = db21.Tables[0].Rows.Count;
                //    int gf21 = db21.Tables.Count;
                //    for (int b21 = 0; b21 <= gf21 - 1; b21++)
                //    {
                //        string client_name = db21.Tables[b21].Rows[0].ItemArray[0].ToString();
                //       // string product_code = db21.Tables[b21].Rows[0].ItemArray[3].ToString();
                //        string exec_code = db21.Tables[b21].Rows[0].ItemArray[3].ToString();
                //        DataSet ds2 = new DataSet();
                //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                //        {
                //            NewAdbooking.Classes.clientexecmastr insert = new NewAdbooking.Classes.clientexecmastr();
                //            ds2 = insert.insertclientcode(client_code, client_name, product_code, compcode, userid);
                //        }
                //        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                //        {
                //            NewAdbooking.classesoracle.clientexecmastr prodinsert = new NewAdbooking.classesoracle.clientexecmastr();
                //            ds2 = prodinsert.insertclientcode(custcode, client_name, exec_code, compcode, userid);
                //        }
                //        //else
                //        //{
                //        //    NewAdbooking.classmysql.ClientProdMastr prodinsert = new NewAdbooking.classmysql.ClientProdMastr();
                //        //    ds2 = prodinsert.insertclientcode(custcode, client_name, product_code, compcode, userid);
                //        //}
                //    }
                //}


                //if (Session["client_brand"] != null)
                //{
                //    DataSet db22 = (DataSet)Session["client_brand"];
                //    int er22 = db22.Tables[0].Rows.Count;
                //    int gf22 = db22.Tables.Count;
                //    for (int b22 = 0; b22 <= gf22 - 1; b22++)
                //    {
                //        string client_name = db21.Tables[b22].Rows[0].ItemArray[0].ToString();
                //        // string product_code = db21.Tables[b21].Rows[0].ItemArray[3].ToString();
                //        string exec_code = db21.Tables[b22].Rows[0].ItemArray[3].ToString();
                //        DataSet da = new DataSet();
                //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                //        {
                //            NewAdbooking.Classes.clientbrandmast insert = new NewAdbooking.Classes.clientbrandmast();
                //            da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid, product_code, brand_code);
                //        }
                //        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                //        {
                //            NewAdbooking.classesoracle.clientbrandmast insert = new NewAdbooking.classesoracle.clientbrandmast();
                //            da = insert.insertclientcode(client_code, client_name, exec_code, compcode, userid, product_code, brand_code);
                //        }
                //        //else
                //        //{
                //        //    NewAdbooking.classmysql.ClientProdMastr prodinsert = new NewAdbooking.classmysql.ClientProdMastr();
                //        //    ds2 = prodinsert.insertclientcode(custcode, client_name, product_code, compcode, userid);
                //        //}
                //    }
                //}

                /**************************************************************************************/
            }
        }
        else
        {
            //if (Session["client_prod"] == null)
            //{
            //    Response.Write("NO3");
            //    Response.End();
            //}
            //if (Session["client_cont"] == null)
            //{
            //    Response.Write("NO1");
            //    Response.End();
            //}
            if (Session["client_stat"] == null)
            {
                Response.Write("NO2");
                Response.End();
            }
            
            //if (Session["client_pay"] == null)
            //{
            //    Response.Write("NO4");
            //    Response.End();
            //}
        }
        if (Session["client_stat"] == null)
        {
            Response.Write("NO2");
            Response.End();
        }
     }
    public string ConvertToDateTime(string strDateTime)
    {
        string dtFinaldate; string sDateTime;
        if (strDateTime != "")
        {
            string hddndateformat = Session["DateFormat"].ToString();
            try
            {
                if (hddndateformat == "dd/mm/yyyy")
                {
                    string[] sDate = strDateTime.Split('/');
                    sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                    dtFinaldate = sDateTime;
                }
                else
                {
                    dtFinaldate = Convert.ToDateTime(strDateTime).ToString();
                }
            }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                dtFinaldate = sDateTime;
            }
            return dtFinaldate;
        }
        else
        {
            return "";
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
            else if (dateformat == "yyyy/mm/dd")
            {
                yyyy = myarrayfrom[0];
                mm = myarrayfrom[1];
                dd = myarrayfrom[2];

                dateReturn = mm + "/" + dd + "/" + yyyy;
            }
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }
}
