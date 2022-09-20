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

public partial class chkuniqueforbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string compcode = Request.QueryString["compcode"].ToString();
        string rono = Request.QueryString["rono"].ToString();
        string cioid = Request.QueryString["cioid"].ToString();
        string agencycode = Request.QueryString["agencycode"].ToString();
        string agscode = Request.QueryString["agencyscode"].ToString();
        string savemod = Request.QueryString["savemod"].ToString();
        string rodate = Request.QueryString["rodate"].ToString();
        string keyno ="";
        if(Request.QueryString["keyno"]!=null)
         keyno = Request.QueryString["keyno"].ToString();
        string flag = "";
        DataSet dck = new DataSet();
        if (Session["ROKEYCHECK"].ToString() != "Y")
        {
            flag = "";
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster chkbookid = new NewAdbooking.Classes.BookingMaster();

                dck = chkbookid.bookidchk(compcode, cioid, agencycode, agscode, rono, savemod, keyno, rodate);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster chkbookid = new NewAdbooking.classesoracle.BookingMaster();

                dck = chkbookid.bookidchk(compcode, cioid, agencycode, agscode, rono, savemod, keyno);
            }
            else {
                /*string[] parameterValueArray = new string[] { compcode, cioid, agencycode, agscode, rono, savemod, keyno };
                string procedureName = "chkciobookid_chkciobookid_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dck = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/

                NewAdbooking.classmysql.BookingMaster chkbookid = new NewAdbooking.classmysql.BookingMaster();

                dck = chkbookid.bookidchkp(compcode, cioid, agencycode, agscode, rono, savemod, keyno);

            }
            if (savemod != "0")
            {
                if (dck.Tables[2].Rows.Count > 0)
                {
                    flag = "0";
                }
            }
            else
            {
                if (dck.Tables[1].Rows.Count > 0)
                {
                    flag = "0";
                }
                else
                {
                    if (dck.Tables[2].Rows.Count > 0) // for keyno check 
                    {
                        if (dck.Tables[2].Rows[0].ItemArray[0].ToString() != "0")
                            flag = "1";
                    }
                }

            }
        }
        Response.Write(flag);
        Response.End();



    }
}
