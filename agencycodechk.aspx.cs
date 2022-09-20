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

public partial class agencycodechk : System.Web.UI.Page
{
    string center="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string compcode, userid, message;
        

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

        compcode = Session["compcode"].ToString();

        string agencode = Request.QueryString["agencode"].ToString();
        string subagencode = Request.QueryString["subagencode"].ToString();
        string agenname = Request.QueryString["agenname"].ToString();
        
        string type = Request.QueryString["type"].ToString();
        string txtagenho = Request.QueryString["txtagenho"].ToString();
        string subcode = Request.QueryString["subcode"].ToString();

        string newagencode = Request.QueryString["newagencode"].ToString();
        string qbc = Request.QueryString["qbc"].ToString();

        //string agentcode = Request.QueryString["agentcode"].ToString();

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master bindlistwithagencycode = new NewAdbooking.Classes.Master();

            ds = bindlistwithagencycode.usercode(agencode, subagencode, compcode, userid, agenname, qbc);
        }
        else if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master bindlistwithagencycode=new NewAdbooking.classesoracle.Master();
             ds = bindlistwithagencycode.usercode(agencode, subagencode, compcode, userid, agenname, qbc);
        }
        else
        {
            NewAdbooking.classmysql.Master bindlistwithagencycode = new NewAdbooking.classmysql.Master();
            ds = bindlistwithagencycode.usercode(agencode, subagencode, compcode, userid, agenname, qbc);
        }
            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    if (ds.Tables[3].Rows[0].ItemArray[0].ToString() != "0")
            //    {
            //        center = "Please Choose another UserId. One agency is already assigned to this User";
            //        Response.Write(center);
            //        Response.End();
            //        return;
            //    }
            //}
            if (type == "P")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //alert("This Agency code already Exist");
                    //message="This Agency code already Exist";
                    ////document.getElementById('txtagencode').focus();
                    //AspNetMessageBox(message);

                    center = "agency code exists";
                    Response.Write(center);
                    Response.End();
                    return;

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    center = "sub agency code exists";
                    Response.Write(center);
                    Response.End();
                    return;
                    //alert("This Sub Agency Code already exist");
                    //document.getElementById('txtsagencycode').focus();
                    //return false;
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    //alert("This Agency Name is already been enroled");
                    //document.getElementById('txtagenname').focus();
                    //return false;
                    center = "agency name exists";
                    Response.Write(center);
                    Response.End();
                    return;
                }
                else
                {
                    string flag = "";
                    string flag1 = "";
                    DataSet da = new DataSet();
                    if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                    NewAdbooking.Classes.Master checkcode = new NewAdbooking.Classes.Master();
                   
                    da = checkcode.agencycode(agencode, compcode, userid, type, subcode);

                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.Master checkcode = new NewAdbooking.classesoracle.Master();
                        da = checkcode.agencycode(agencode, compcode, userid, type, subcode);

                    }
                    else
                    {
                        NewAdbooking.classmysql.Master checkcode = new NewAdbooking.classmysql.Master();
                        da = checkcode.agencycode(agencode, compcode, userid, type, subcode);
                    }

                    if (da.Tables[0].Rows.Count > 0)
                    {

                        flag = "y";
                    }
                    else
                    {
                        flag1 = "n";
                    }

                    if (flag == "y")
                    {
                        //alert("This Agency Code Already Exists ");
                        //return false;
                        center = "agency code exists";
                        Response.Write(center);
                        Response.End();
                        return;
                    }
                    else
                    {

                        //                    Agent_master.commcheck(txtagencode, compcode, userid, agencode, commchk);
                        string f1 = "";
                        string f2 = "";
                        DataSet db = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.pop checkpay = new NewAdbooking.Classes.pop();
                            db = checkpay.commcheck(agencode, compcode, userid, subagencode);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.pop checkpay = new NewAdbooking.classesoracle.pop();
                            db = checkpay.commcheck(agencode, compcode, userid, subagencode);
                        }
                        else
                        {
                            NewAdbooking.classmysql.pop checkpay = new NewAdbooking.classmysql.pop();
                            db = checkpay.commcheck(agencode, compcode, userid, subagencode);
                        }

                        if (db.Tables[0].Rows.Count > 0)
                        {

                            f1 = "y";
                        }
                        else
                        {
                            f2 = "y";
                        }

                        if ((f2 == "y") && (Session["commdetail"] == null || Session["commdetail"] == ""))
                        {
                            center = "enter commission detail";
                            Response.Write(center);
                            Response.End();
                            return;

                        }
                        else
                        {
                            //Agent_master.paycheck1(txtagencode, compcode, userid, newagencode, paychk);

                            string f0 = "";
                            string f00 = "";
                            DataSet daa = new DataSet();
                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                            {
                                NewAdbooking.Classes.pop checkpayag = new NewAdbooking.Classes.pop();

                                daa = checkpayag.paycheck(subagencode, compcode, userid, agencode);
                            }
                            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                            {
                                NewAdbooking.classesoracle.pop checkpayag = new NewAdbooking.classesoracle.pop();
                                daa = checkpayag.paycheck(subagencode, compcode, userid, agencode);
                            }
                            else
                            {
                                NewAdbooking.classmysql.pop checkpayag = new NewAdbooking.classmysql.pop();
                                daa = checkpayag.paycheck(subagencode, compcode, userid, agencode);
                            }
                            if (daa.Tables[0].Rows.Count > 0)
                            {
                                f0 = "y";
                                //return flag;
                            }
                            else
                            {
                                f00 = "y";
                            }
                            if (f00 == "y")
                            {
                                if (Session["paymodeagency"] == null || Session["paymodeagency"] == "")
                                {
                                    center = "enter pay mode detail";
                                    Response.Write(center);
                                    Response.End();
                                    return;
                                }
                            }
                        }



                    }


                }

            }
            else if (ds.Tables[1].Rows.Count > 0)
            {
                //alert("This Sub Agency Code already exist");
                //document.getElementById('txtsagencycode').focus();
                //return false;
                center = "sub agency code exists";
                Response.Write(center);
                Response.End();
                return;
            }

            else if (ds.Tables[2].Rows.Count > 0)
            {
                //alert("This Agency Name is already been enroled");
                //document.getElementById('txtagenname').focus();
                //return false;
                center = "agency name exists";
                Response.Write(center);
                Response.End();
                return;

            }
            else
            {
                string flag = "";
                string falg1 = "";
                DataSet daas = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Master checkcode = new NewAdbooking.Classes.Master();
                    
                    daas = checkcode.agencycode(agencode, compcode, userid, type, subcode);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.Master checkcode = new NewAdbooking.classesoracle.Master();
                    daas = checkcode.agencycode(agencode, compcode, userid, type, subcode);
                }
                else
                {
                    NewAdbooking.classmysql.Master checkcode = new NewAdbooking.classmysql.Master();
                    daas = checkcode.agencycode(agencode, compcode, userid, type, subcode);
                }

                if (daas.Tables[0].Rows.Count > 0)
                {

                    flag = "y";
                }
                else
                {
                    falg1 = "n";
                }
                if (flag == "y")
                {
                    //alert("This Agency Code Already Exists ");
                    //return false;
                    center = "agency code exists";
                    Response.Write(center);
                    Response.End();
                    return;
                }
                else
                {

                    //                    Agent_master.commcheck(txtagencode, compcode, userid, agencode, commchk);
                    string f1 = "";
                    string f2 = "";
                    DataSet db = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.pop checkpay = new NewAdbooking.Classes.pop();

                        db = checkpay.commcheck(agencode, compcode, userid, subagencode);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.pop checkpay = new NewAdbooking.classesoracle.pop();
                        db = checkpay.commcheck(agencode, compcode, userid, subagencode);
                    }
                    else
                    {
                        NewAdbooking.classmysql.pop checkpay = new NewAdbooking.classmysql.pop();
                        db = checkpay.commcheck(agencode, compcode, userid, subagencode);
                    }
                    if (db.Tables[0].Rows.Count > 0)
                    {

                        f1 = "y";
                    }
                    else
                    {
                        f2 = "y";
                    }

                    if ((f2 == "y") && (Session["commdetail"] == null || Session["commdetail"] == ""))
                    {

                        center = "enter commission detail";
                        Response.Write(center);
                        Response.End();
                        return;

                    }
                    else
                    {
                        //Agent_master.paycheck1(txtagencode, compcode, userid, newagencode, paychk);

                        string f0 = "";
                        string f00 = "";
                        DataSet dada = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.pop checkpayagency = new NewAdbooking.Classes.pop();

                            dada = checkpayagency.paycheck(subagencode, compcode, userid, agencode);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.pop checkpayagency = new NewAdbooking.classesoracle.pop();
                            dada = checkpayagency.paycheck(subagencode, compcode, userid, agencode);
                        }
                        else
                        {
                            NewAdbooking.classmysql.pop checkpayagency = new NewAdbooking.classmysql.pop();
                            dada = checkpayagency.paycheck(subagencode, compcode, userid, agencode);
                        }

                        if (dada.Tables[0].Rows.Count > 0)
                        {
                            f0 = "y";
                            //return flag;
                        }
                        else
                        {
                            f00 = "y";
                        }
                        if (f00 == "y")
                        {
                            if (Session["paymodeagency"] == null || Session["paymodeagency"] == "")
                            {
                                center = "enter pay mode detail";
                                Response.Write(center);
                                Response.End();
                                return;
                            }
                        }
                    }



                }

            }

        }
     
        
  
        
 
    //Response.Write(center);
    //    Response.End();


    //protected void AspNetMessageBox(string strMessage)
    //{
    //    //strMessage = adminResource.GetStringFromResource(strMessage);
    //    string strAlert = "";
    //    strAlert = "alert('" + strMessage + "')";
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(agencycodechk), "ShowAlert", strAlert, true);
    //}
}


/*

alert("You Have Not Entered The Commission Detail Please Enter!!!");
document.getElementById('lbcommdetail').focus();

document.getElementById('lbcommdetail').style.fontWeight="bold";
return false;

 else

 document.getElementById('lbcommdetail').style.fontWeight="normal";


------------
alert("You Have Not Entered The Pay Mode Detail Please Enter!!!");
document.getElementById('lbpaymode').focus();
document.getElementById('lbpaymode').style.fontWeight="bold";
return false;*/