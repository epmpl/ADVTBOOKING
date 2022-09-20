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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
public partial class qbc_chequedetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string comcode = "";
        string ciobookid = "";
        string docno = "";
        string keyno = "";
        string rono = "";
        string agencycode = "";
        string client = "";
        string adtype = "";
        string dateformate = "";
        string userid = "";
        string day = "";
        string month = "";
        string year = "";
        Ajax.Utility.RegisterTypeForAjax(typeof(qbc_chequedetail));
        //if (!Page.IsPostBack)
        //{
        DataSet objDatagetlabname = new DataSet();
        objDatagetlabname.ReadXml(Server.MapPath("XML/bookingmaster.xml"));
        if (Request.QueryString["paymode"] != null)
        {
            if (Request.QueryString["paymode"].ToString() == "SW0")
            {
                lbchqno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[146].ToString();
                lbchqdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[147].ToString();
                ttextchqno.Enabled = true;
                ttextbankname.Enabled = true;
                txtdummydate.Enabled = true;
            }

            else if (Request.QueryString["paymode"].ToString() == "ON0")
            {
                lbchqno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[148].ToString();
                lbchqdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[149].ToString();
                ttextchqno.Enabled = true;
                txtdummydate.Enabled = true;
                ttextbankname.Enabled = true;
            }
            else
            {
                lbchqno.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[111].ToString();
                lbchqdate.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[113].ToString();
                ttextchqno.Enabled = true;
                txtdummydate.Enabled = true;
                ttextbankname.Enabled = true;
            }
        }

     
        lbbankname.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[114].ToString();
        //}
        if (!Page.IsPostBack)
        {
            btnsubmit.Attributes.Add("onclick", "javascript:return ok();");
            txtdummydate.Attributes.Add("OnChange", "javascript:return checkdateforcurr(this);  ");
        }
        if (Request.QueryString["comcode"] != null)
        {
            comcode = Request.QueryString["comcode"].ToString();
        }
        if (Request.QueryString["ciobookid"] != null)
        {
            ciobookid = Request.QueryString["ciobookid"].ToString();
        }
        if (Request.QueryString["docno"] != null)
        {
            docno = Request.QueryString["docno"].ToString();
        }
        if (Request.QueryString["keyno"] != null)
        {
            keyno = Request.QueryString["keyno"].ToString();
        }
        if (Request.QueryString["rono"] != null)
        {
            rono = Request.QueryString["rono"].ToString();
        }
        if (Request.QueryString["agencycode"] != null)
        {
            agencycode = Request.QueryString["agencycode"].ToString();
        }
        if (Request.QueryString["client"] != null)
        {
            client = Request.QueryString["client"].ToString();
        }
        if (Request.QueryString["drtype"] != null)
        {
            adtype = Request.QueryString["drtype"].ToString();
        }
        if (Request.QueryString["dateformate"] != null)
        {
            dateformate = Request.QueryString["dateformate"].ToString();
        }
        if (Request.QueryString["userid"] != null)
        {
            userid = Request.QueryString["userid"].ToString();
        }

        DataSet executequery1 = new DataSet();
        //adtype = "CL0";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Sql.BookingMaster();
            executequery1 = execute.executebookingqbc(Session["compcode"].ToString(), ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformate, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster execute = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            executequery1 = execute.executebookingqbc(Session["compcode"].ToString(), ciobookid, docno, keyno, rono, agencycode, client, adtype, dateformate, userid);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            executequery1 = execute.executebooking(comcode, ciobookid, docno, keyno, rono, agencycode, client, adtype);
        }
        // return executequery1; 
        if (executequery1.Tables[0].Rows.Count > 0)
        {
            if (executequery1.Tables[0].Rows[0]["CHK_NO"].ToString() != "")
            {
                ttextchqno.Text = executequery1.Tables[0].Rows[0]["CHK_NO"].ToString();
            }
            else
            {
                ttextchqno.Text = "";
            }
            if (executequery1.Tables[0].Rows[0]["CHK_DATE"].ToString() != "")
            {
                string[] chequedate = executequery1.Tables[0].Rows[0]["CHK_DATE"].ToString().Split(' ');
                txtdummydate.Text = changedateformat(chequedate[0].ToString());
            }
            else
            {
                txtdummydate.Text = "";
            }
            if (executequery1.Tables[0].Rows[0]["CHK_BANK_NAME"].ToString() != "")
            {
                ttextbankname.Text = executequery1.Tables[0].Rows[0]["CHK_BANK_NAME"].ToString();
            }
            else
            {
                ttextbankname.Text = "";
            }
        }
    }
    public string changedateformat(string date)
    {
        string[] strdate = date.Split('/');

        if (strdate[1].Length < 2)
        {
            strdate[1] = "0" + strdate[1];
        }
        date = strdate[1] + "/" + strdate[0] + "/" + strdate[2];
        return date;
    }

}