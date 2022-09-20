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

public partial class clientName : System.Web.UI.Page
{
    int j = 0;
    string nameadd;
    string add;
    string executive = "new";
    string adtype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("yes");
            return;

        }
        string name = Request.QueryString["page"].ToString();
        string value = Request.QueryString["value"].ToString();
        string date = "";
        if (Request.QueryString["adtype"] != null)
        {
            adtype = Request.QueryString["adtype"].ToString();
        }
        else
        {
            string executive = "old";
        }
        if (Request.QueryString["datetime"] != null)
        {
             date = Request.QueryString["datetime"].ToString();
        }

        if (value == "0")
        {
            DataSet dag = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getagenameaddress = new NewAdbooking.Classes.BookingMaster();

                dag = getagenameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getagenameaddress = new NewAdbooking.classesoracle.BookingMaster();

                dag = getagenameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date);
            }
            else
            {
                 //string procedureName="";
                //string[] parameterValueArray;
                  NewAdbooking.classmysql.BookingMaster getagenameaddress = new NewAdbooking.classmysql.BookingMaster();
                 dag = getagenameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date,Session["dateformat"].ToString());
                /*parameterValueArray = new string[] { Session["compcode"].ToString(), name, value, date };
                procedureName = "bindagencyforagency";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dag = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            }

            if (dag.Tables[0].Rows.Count > 0)
            {
                string clientname = dag.Tables[0].Rows[0].ItemArray[1].ToString();
                string code = dag.Tables[0].Rows[0].ItemArray[0].ToString();
                string address = dag.Tables[0].Rows[0].ItemArray[2].ToString();
                if (address == "null")
                    address = "";
                //string agentypename = dag.Tables[1].Rows[0].ItemArray[0].ToString();
                //string agenstatus = dag.Tables[2].Rows[0].ItemArray[0].ToString();
                //string credit = dag.Tables[3].Rows[0].ItemArray[0].ToString();
                //string rategroup = dag.Tables[4].Rows[0].ItemArray[0].ToString();
                //string comm = dag.Tables[5].Rows[0].ItemArray[0].ToString();
                //string pay = dag.Tables[6].Rows[0].ItemArray[0].ToString();

                nameadd = clientname + "(" + code + ")" + "+" + address;
                Response.Write(nameadd);
                Response.End();


            }
        }
            else if (value == "1")
            {
                DataSet dcl = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster getclientnameaddress = new NewAdbooking.Classes.BookingMaster();

                    dcl = getclientnameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getclientnameaddress = new NewAdbooking.classesoracle.BookingMaster();

                    dcl = getclientnameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date);
                }
                else
                {
                    //string procedureName = "";
                    //string[] parameterValueArray;
                      NewAdbooking.classmysql.BookingMaster getagenameaddress = new NewAdbooking.classmysql.BookingMaster();
                      dcl = getagenameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date, Session["dateformat"].ToString());
                    /*parameterValueArray = new string[] { Session["compcode"].ToString(), name, value, date };
                    procedureName = "bindagencyforagency";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dcl = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/

                }

                if (dcl.Tables[0].Rows.Count > 0)
                {
                    string clientname = dcl.Tables[0].Rows[0].ItemArray[1].ToString();
                    string code = dcl.Tables[0].Rows[0].ItemArray[0].ToString();
                    string address = dcl.Tables[0].Rows[0].ItemArray[2].ToString();
                    string street = "";
                    if (dcl.Tables[0].Rows[0].ItemArray[4] != null)
                    {
                        street = dcl.Tables[0].Rows[0].ItemArray[4].ToString();
                    }
                    if (address == "null")
                        address = "";

                    nameadd = clientname + "(" + code + ")" + "+" + address + "+" + street;
                    Response.Write(nameadd);
                    Response.End();



                }

            }
            else if (value == "2")
            {

                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

                    ds = clsbooking.bindProduct(Session["compcode"].ToString(), name, value);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

                    ds = clsbooking.bindProduct(Session["compcode"].ToString(), name, value);
                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

                    ds = clsbooking.bindProduct(Session["compcode"].ToString(), name, value);

                }

                string prod = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                string prodcod = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                nameadd = prod + "(" + prodcod + ")";

                Response.Write(nameadd);
                Response.End();



            }

            else if (value == "3")
        {
            DataSet ds = new DataSet();
                if (executive == "old")
                {
                   
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

                        ds = clsbooking.getExec(Session["compcode"].ToString(), name, value);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

                        ds = clsbooking.getExec(Session["compcode"].ToString(), name, value, "0");
                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

                        ds = clsbooking.getExec(Session["compcode"].ToString(), name, value, "0");

                    }
                }
                else
                {
                   
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

                        ds = clsbooking.getExecbooking(Session["compcode"].ToString(), name, value, adtype);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

                        ds = clsbooking.getExecbooking(Session["compcode"].ToString(), name, value, "0", adtype);
                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

                        ds = clsbooking.getExecbooking(Session["compcode"].ToString(), name, value, "0",adtype);

                    }
                }

                string exec = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                string execcod = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                nameadd = exec + "(" + execcod + ")";

                Response.Write(nameadd);
                Response.End();



            }


        
    }  
}
