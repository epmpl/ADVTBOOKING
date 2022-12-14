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

public partial class loginsession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string flag = "0";
        string username = Request.QueryString["username"].ToString();
        string password = Request.QueryString["password"].ToString();
        string qbc = Request.QueryString["qbc"].ToString();
        string agency_name = Request.QueryString["agency_name"].ToString();
        string center = Request.QueryString["center"].ToString();
        Session["agency_name"] = agency_name;
        Session["center"] = center;
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();

            ds = logindetail.chklogin(username, password, qbc);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                    Session["revenue"] = qbc;
                    /*new change ankur 18 feb*/
                    Session["comp_name"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    Session["Username"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Session["userid"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Session["compcode"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    Session["dateformat"] = ds.Tables[1].Rows[0].ItemArray[3].ToString();
                    Session["autogenerated"] = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    Session["currency"] = ds.Tables[1].Rows[0].ItemArray[2].ToString();
                    Session["ratecode"] = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    Session["solorate"] = ds.Tables[1].Rows[0].ItemArray[4].ToString();
                    Session["decimal"] = ds.Tables[1].Rows[0].ItemArray[5].ToString();
                    Session["breakup"] = ds.Tables[1].Rows[0].ItemArray[6].ToString();
                    Session["bwcode"] = ds.Tables[1].Rows[0].ItemArray[7].ToString();
                    Session["uom"] = ds.Tables[1].Rows[0].ItemArray[8].ToString();
                    Session["rostatus"] = ds.Tables[1].Rows[0].ItemArray[9].ToString();
                    Session["tfn"] = ds.Tables[1].Rows[0].ItemArray[10].ToString();
                    Session["insertsbreakup"] = ds.Tables[1].Rows[0].ItemArray[11].ToString();
                    Session["premtype"] = ds.Tables[1].Rows[0].ItemArray[12].ToString();
                    Session["dealtype"] = ds.Tables[1].Rows[0].ItemArray[13].ToString();
                    Session["prefix"] = ds.Tables[1].Rows[0].ItemArray[14].ToString();
                    Session["suffix"] = ds.Tables[1].Rows[0].ItemArray[15].ToString();
                    Session["financestatus"] = ds.Tables[1].Rows[0].ItemArray[16].ToString();
                    Session["voucherst"] = ds.Tables[1].Rows[0].ItemArray[17].ToString();
                    Session["roadcat"] = ds.Tables[1].Rows[0].ItemArray[18].ToString();
                    Session["rodatetime"] = ds.Tables[1].Rows[0].ItemArray[19].ToString();
                    Session["spacearea"] = ds.Tables[1].Rows[0].ItemArray[20].ToString();
                    Session["vat"] = ds.Tables[1].Rows[0].ItemArray[21].ToString();
                    Session["bookstat"] = ds.Tables[1].Rows[0].ItemArray[22].ToString();
                    Session["cioid"] = ds.Tables[1].Rows[0].ItemArray[23].ToString();
                    Session["Receipt_no"] = ds.Tables[1].Rows[0].ItemArray[24].ToString();
                    /*new change ankur*/
                    Session["bg_colorpub"] = ds.Tables[1].Rows[0].ItemArray[25].ToString();
                    Session["validdate_pub"] = ds.Tables[1].Rows[0].ItemArray[26].ToString();
                    //////////////////
                    Session["userhome"] = ds.Tables[2].Rows[0].ItemArray[0].ToString();
                    Session["Admin"] = ds.Tables[2].Rows[0].ItemArray[1].ToString();
                    /*new change ankur for agency*/
                    Session["agencyratecode"] = ds.Tables[1].Rows[0].ItemArray[27].ToString();
                    Session["audit"] = ds.Tables[1].Rows[0].ItemArray[28].ToString();


                }
                else
                {
                    flag = "0";
                }
            }
            else
            {
                flag = "0";
            }
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();

                ds = logindetail.chklogin(username, password, qbc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                    Session["revenue"] = qbc;
                    Session["comp_name"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    Session["Username"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Session["userid"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Session["compcode"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    Session["dateformat"] = ds.Tables[1].Rows[0].ItemArray[3].ToString();
                    Session["autogenerated"] = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    Session["currency"] = ds.Tables[1].Rows[0].ItemArray[2].ToString();
                    Session["ratecode"] = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    Session["solorate"] = ds.Tables[1].Rows[0].ItemArray[4].ToString();
                    Session["decimal"] = ds.Tables[1].Rows[0].ItemArray[5].ToString();
                    Session["breakup"] = ds.Tables[1].Rows[0].ItemArray[6].ToString();
                    Session["bwcode"] = ds.Tables[1].Rows[0].ItemArray[7].ToString();
                    Session["uom"] = ds.Tables[1].Rows[0].ItemArray[8].ToString();
                    Session["rostatus"] = ds.Tables[1].Rows[0].ItemArray[9].ToString();
                    Session["tfn"] = ds.Tables[1].Rows[0].ItemArray[10].ToString();
                    Session["insertsbreakup"] = ds.Tables[1].Rows[0].ItemArray[11].ToString();
                    Session["premtype"] = ds.Tables[1].Rows[0].ItemArray[12].ToString();
                    Session["dealtype"] = ds.Tables[1].Rows[0].ItemArray[13].ToString();
                    Session["prefix"] = ds.Tables[1].Rows[0].ItemArray[14].ToString();
                    Session["suffix"] = ds.Tables[1].Rows[0].ItemArray[15].ToString();
                    Session["financestatus"] = ds.Tables[1].Rows[0].ItemArray[16].ToString();
                    Session["voucherst"] = ds.Tables[1].Rows[0].ItemArray[17].ToString();
                    Session["roadcat"] = ds.Tables[1].Rows[0].ItemArray[18].ToString();
                    Session["rodatetime"] = ds.Tables[1].Rows[0].ItemArray[19].ToString();
                    Session["spacearea"] = ds.Tables[1].Rows[0].ItemArray[20].ToString();
                    Session["vat"] = ds.Tables[1].Rows[0].ItemArray[21].ToString();
                    Session["bookstat"] = ds.Tables[1].Rows[0].ItemArray[22].ToString();
                    Session["cioid"] = ds.Tables[1].Rows[0].ItemArray[23].ToString();
                    Session["Receipt_no"] = ds.Tables[1].Rows[0].ItemArray[24].ToString();
                    Session["userhome"] = ds.Tables[2].Rows[0].ItemArray[0].ToString();
                    Session["Admin"] = ds.Tables[2].Rows[0].ItemArray[1].ToString();
                    Session["bg_colorpub"] = ds.Tables[1].Rows[0].ItemArray[25].ToString();
                    Session["validdate_pub"] = ds.Tables[1].Rows[0].ItemArray[26].ToString();
                    /*new change ankur for agency*/
                    Session["agencyratecode"] = ds.Tables[1].Rows[0].ItemArray[27].ToString();

                    Session["audit"] = ds.Tables[1].Rows[0].ItemArray[28].ToString();
                    Session["copyrate"] = ds.Tables[1].Rows[0].ItemArray[29].ToString();

                    Session["rateradio"] = ds.Tables[1].Rows[0].ItemArray[30].ToString();
                    Session["editionsubrate"] = ds.Tables[1].Rows[0].ItemArray[31].ToString();
                    Session["addAgencyComm"] = ds.Tables[1].Rows[0].ItemArray[32].ToString();
                    Session["addAgencyComm_Ret"] = ds.Tables[1].Rows[0].ItemArray[33].ToString();
                    Session["rate_audit"] = ds.Tables[1].Rows[0]["rate_audit"].ToString();
                    Session["invoice_no"] = ds.Tables[1].Rows[0]["invoice_no"].ToString();
                    Session["clsbilltype"] = ds.Tables[1].Rows[0]["CLS_BILLTYPE"].ToString();                     
                     Session["displaybilltype"]= ds.Tables[1].Rows[0]["DIS_BILLTYPE"].ToString();
                    Session["BILLING_FORMAT"] = ds.Tables[1].Rows[0]["BILLING_FORMAT"].ToString();




                    Session["DISP_CASHBILL"] = ds.Tables[1].Rows[0]["DISP_CASHBILL"].ToString();
                    Session["CLA_CASHBILL"] = ds.Tables[1].Rows[0]["CLA_CASHBILL"].ToString();

                
                
                }
                else
                {
                    flag = "0";
                }
            }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.chklogin(username, password, qbc);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = "1";
                    Session["revenue"] = qbc;
                    Session["Username"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Session["comp_name"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    Session["userid"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Session["compcode"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    Session["dateformat"] = ds.Tables[1].Rows[0].ItemArray[3].ToString();
                    Session["autogenerated"] = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                    Session["currency"] = ds.Tables[1].Rows[0].ItemArray[2].ToString();
                    Session["ratecode"] = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    Session["solorate"] = ds.Tables[1].Rows[0].ItemArray[4].ToString();
                    Session["decimal"] = ds.Tables[1].Rows[0].ItemArray[5].ToString();
                    Session["breakup"] = ds.Tables[1].Rows[0].ItemArray[6].ToString();
                    Session["bwcode"] = ds.Tables[1].Rows[0].ItemArray[7].ToString();
                    Session["uom"] = ds.Tables[1].Rows[0].ItemArray[8].ToString();
                    Session["rostatus"] = ds.Tables[1].Rows[0].ItemArray[9].ToString();
                    Session["tfn"] = ds.Tables[1].Rows[0].ItemArray[10].ToString();
                    Session["insertsbreakup"] = ds.Tables[1].Rows[0].ItemArray[11].ToString();
                    Session["premtype"] = ds.Tables[1].Rows[0].ItemArray[12].ToString();
                    Session["dealtype"] = ds.Tables[1].Rows[0].ItemArray[13].ToString();
                    Session["prefix"] = ds.Tables[1].Rows[0].ItemArray[14].ToString();
                    Session["suffix"] = ds.Tables[1].Rows[0].ItemArray[15].ToString();
                    Session["financestatus"] = ds.Tables[1].Rows[0].ItemArray[16].ToString();
                    Session["voucherst"] = ds.Tables[1].Rows[0].ItemArray[17].ToString();
                    Session["roadcat"] = ds.Tables[1].Rows[0].ItemArray[18].ToString();
                    Session["rodatetime"] = ds.Tables[1].Rows[0].ItemArray[19].ToString();
                    Session["spacearea"] = ds.Tables[1].Rows[0].ItemArray[20].ToString();
                    Session["vat"] = ds.Tables[1].Rows[0].ItemArray[21].ToString();
                    Session["bookstat"] = ds.Tables[1].Rows[0].ItemArray[22].ToString();
                    Session["cioid"] = ds.Tables[1].Rows[0].ItemArray[23].ToString();
                    Session["Receipt_no"] = ds.Tables[1].Rows[0].ItemArray[24].ToString();
                    /*new change ankur*/
                    Session["bg_colorpub"] = ds.Tables[1].Rows[0].ItemArray[25].ToString();
                    Session["validdate_pub"] = ds.Tables[1].Rows[0].ItemArray[26].ToString();
                    //////////////////

                    Session["userhome"] = ds.Tables[2].Rows[0].ItemArray[0].ToString();
                    Session["Admin"] = ds.Tables[2].Rows[0].ItemArray[1].ToString();
                    /*new change ankur for agency*/
                    Session["agencyratecode"] = ds.Tables[1].Rows[0].ItemArray[27].ToString();

                    if (ds.Tables[1].Rows[0].ItemArray.Length != 28)
                    {
                        Session["audit"] = ds.Tables[1].Rows[0].ItemArray[28].ToString();
                    }


                }
                else
                {
                    flag = "0";
                }
            }
            else
            {
                flag = "0";
            }

        }

      

        Response.Write(flag);
        Response.End();
    }
}
