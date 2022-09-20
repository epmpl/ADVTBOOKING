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

public partial class Execopoup : System.Web.UI.Page
{
    string userid, compcode, retcode, show, n_m, gbcommrate;
    string gbfrom, gbto, gbenln, gbcommon;
    string gbpublist="";
    string gbpubtype="";
    string gbadtype="";
    string gbcusttype="";
    string gbcat="";
    string gbteam = "";
    //string submit = "F";
    string gbtempexecode = "";
    static DataSet dk1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {Response.Expires = -1;
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
        Ajax.Utility.RegisterTypeForAjax(typeof(Execopoup));
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
            //drpteam.Enabled = false;
            //drpcat.Enabled = false;
            //lstpublication.Enabled = false;
            hiddendelsau.Value = "0";
        }

        if (show == "2")
        {
            submit.Enabled = true;
            del.Enabled = false;
            clear.Enabled = false;
            //txtto.Enabled = true;
            //txtfrom.Enabled = true;
            //drpcusttype.Enabled = true;
            //drpadpub.Enabled = true;
            //drpteam.Enabled = true;
            //drpcat.Enabled = true;
            //lstpublication.Enabled = true;
            hiddendelsau.Value = "1";
        }




        if (!Page.IsPostBack)
        {



            addrow.Attributes.Add("OnClick", "javascript:return creatnewrow();");
            lstagency.Attributes.Add("onkeydown", "javascript:return insertagency(event);");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency(event);");
            submit.Attributes.Add("OnClick", "javascript:return datasubmit();");
           clear.Attributes.Add("OnClick", "javascript:return cleardata();");
           close.Attributes.Add("OnClick", "javascript:return closepage();");
           del.Attributes.Add("OnClick", "javascript:return datadel();");

        
            txtagency.Attributes.Add("onkeydown", "javascript:return fillagency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return insertagency(event);");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency(event);");

         
           

        }
      
    }



    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string pag, string id, string dateformate, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup coupondetail = new NewAdbooking.Classes.execopoup();
            ds = coupondetail.fill_reoprt(compcode, pag, id, dateformate, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.fill_reoprt(compcode, pag, id, dateformate, extra1, extra2, extra3, extra4, extra5);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet duplicasy(string compcode, string execcode, string agencycode, string fromdate, string todate, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup coupondetail = new NewAdbooking.Classes.execopoup();
            ds = coupondetail.duplicasy_ckeck(compcode, execcode, agencycode, fromdate, todate, dateformat);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.duplicasy_ckeck(compcode, execcode, agencycode, fromdate, todate, dateformat);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet savedata(string compcode, string agencycode, string days, string limit, string recovery, string fromdate, string todate, string execcode, string createdby, string createddt, string updatedby, string updateddt, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup coupondetail = new NewAdbooking.Classes.execopoup();
            ds = coupondetail.savedata_table(compcode, agencycode, days, limit, recovery, fromdate, todate, execcode, createdby, createddt, updatedby, updateddt, dateformat);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.savedata_table(compcode, agencycode, days, limit, recovery, fromdate, todate, execcode, createdby, createddt, updatedby, updateddt, dateformat);
        }
        return ds;
    }



    [Ajax.AjaxMethod]
    public DataSet bindgrid(string compcode,string agencycode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup coupondetail = new NewAdbooking.Classes.execopoup();
            ds = coupondetail.binddata_grid(compcode, agencycode);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.binddata_grid(compcode, agencycode);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet reportname_agency(string compcode, string reportto)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup route = new NewAdbooking.Classes.execopoup();
            ds = route.bind_agency(compcode, reportto);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.bind_agency(compcode, reportto);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet modify_save(string compcode, string agencycode, string days, string limit, string recovery, string fromdate, string todate, string execcode, string createdby, string createddt, string updatedby, string updateddt, string dateformat,string slab_no)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup coupondetail = new NewAdbooking.Classes.execopoup();
            ds = coupondetail.mdy_table(compcode, agencycode, days, limit, recovery, fromdate, todate, execcode, createdby, createddt, updatedby, updateddt, dateformat, slab_no);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.mdy_table(compcode, agencycode, days, limit, recovery, fromdate, todate, execcode, createdby, createddt, updatedby, updateddt, dateformat, slab_no);
        }
        return ds;
    }



    [Ajax.AjaxMethod]
    public DataSet del_dta(string compcode,string execcode, string slab_no)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.execopoup coupondetail = new NewAdbooking.Classes.execopoup();
            ds = coupondetail.delete_data(compcode, execcode, slab_no);
        }
        else
        {
            NewAdbooking.classesoracle.execopoup coupondetail = new NewAdbooking.classesoracle.execopoup();
            ds = coupondetail.delete_data(compcode, execcode, slab_no);
        }
        return ds;
    }
    //protected void submit_Click(object sender, EventArgs e)
    //{
    //    Session["execvalue"] = hdnexecval.Value;
    //}
}

