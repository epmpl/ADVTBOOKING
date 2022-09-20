using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class retainpoup : System.Web.UI.Page
{
    string userid, compcode, retcode, show, n_m, gbcommrate;
    string gbfrom, gbto, gbenln, gbcommon;
    string gbpublist = "";
    string gbpubtype = "";
    string gbadtype = "";
    string gbcusttype = "";
    string gbcat = "";
    string gbteam = "";
    //string submit = "F";
    string gbtempexecode = "";
    static DataSet dk1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //string codepass = Request.QueryString["codepass"].ToString();

        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        //Session["Execdetail"] = hiddenexecutive.Value;
        Ajax.Utility.RegisterTypeForAjax(typeof(retainpoup));
        show = Request.QueryString["show"].ToString();
        n_m = Request.QueryString["n_m"].ToString();
        hiddenshow.Value = show;
        hiddencompcode.Value = Session["compcode"].ToString();
        compcode = hiddencompcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        userid = hiddenuserid.Value;
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddenretcode.Value = Request.QueryString["RetStatusCode"].ToString();
        retcode = hiddenretcode.Value;
        //btndelete.Enabled = false;
        if (hiddendateformat.Value == "mm/dd/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;

        }
        else if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
        }
        else
        {
            HDN_server_date.Value = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
        }
        if (hiddenretcode.Value == "")
        {
            Response.Write("<script>alert('You Should Enter The Retainer Code First');window.close();</script>");
            return;
        }
        DataSet dk = new DataSet();
        //dk.ReadXml(Server.MapPath("XML/retainercommstructure.xml"));

        dk.ReadXml(Server.MapPath("XML/Execopoup.xml"));


        lblagency.Text = dk.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcreditdays.Text = dk.Tables[0].Rows[0].ItemArray[1].ToString();
        lblcreditlimit.Text = dk.Tables[0].Rows[0].ItemArray[2].ToString();
        lblrecovery.Text = dk.Tables[0].Rows[0].ItemArray[3].ToString();
        lbleffectivefrom.Text = dk.Tables[0].Rows[0].ItemArray[4].ToString();
        lbleffectiveto.Text = dk.Tables[0].Rows[0].ItemArray[5].ToString();


        if (show == "1")
        {
            submit.Enabled = true;
            //txtto.Enabled = true;
            //txtfrom.Enabled = true;
            //drpcusttype.Enabled = true;
            //drpadpub.Enabled = true;
            //drpteam.Enabled = true;
            //drpcat.Enabled = true;
            //lstpublication.Enabled = true;
            del.Enabled = false;
            hiddendelsau.Value = "0";
        }
        if (show == "0")
        {
            del.Enabled = false;
            submit.Enabled = false;
            //txtto.Enabled = false;
            //txtfrom.Enabled = false;
            //drpcusttype.Enabled = false;
            //drpadpub.Enabled = false;
            //drpteam.
        }
    }
}