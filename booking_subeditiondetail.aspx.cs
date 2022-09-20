using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class booking_subeditiondetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(booking_subeditiondetail));
        txtedition.Value=Request.QueryString["edition"].ToString();
        txtinsertdate.Value = Request.QueryString["insertdate"].ToString();
        txtheight.Value = Request.QueryString["height"].ToString();
        txtwidth.Value = Request.QueryString["width"].ToString();
        txttotarea.Value = Request.QueryString["totarea"].ToString();
        txtcompcode.Value = Request.QueryString["compcode"].ToString();
        hiddenchkbtnStatus.Value = Request.QueryString["btnstatus"].ToString();
        hiddenreceipt.Value = Request.QueryString["receiptno"].ToString();
        hiddendateformat.Value = Request.QueryString["dateformat"].ToString();
        hiddenuomdesc.Value = Request.QueryString["uomdesc"].ToString();
        hiddeninsertstatus.Value = Request.QueryString["insertstatus"].ToString();
        hiddenidnum.Value = Request.QueryString["idnum"].ToString();
        hiddenpackage.Value = Request.QueryString["package"].ToString();
        hdnchkdetailperm.Value = Request.QueryString["chkuserperm"].ToString();
        if (Request.QueryString["adtype"] != null)
            hiddenadtype.Value = Request.QueryString["adtype"].ToString();
        if (Request.QueryString["pageno"] != null)
            hiddenpageno.Value = Request.QueryString["pageno"].ToString();
        if (Request.QueryString["pkglength"] != null)
            hiddenpkglength.Value = Request.QueryString["pkglength"].ToString();
        if (Request.QueryString["pkgname"] != null)
            hiddenpkgname.Value = Request.QueryString["pkgname"].ToString();
         if (Request.QueryString["insertid"] != null)
        {
            hiddeninsertid.Value = Request.QueryString["insertid"].ToString();
        }
        if (Request.QueryString["data"] != null)
        {
            txtdata.Value = Request.QueryString["data"].ToString();
        }
        btncancel.Attributes.Add("OnClick", "javascript:return closeWinForm();");
        btnok.Attributes.Add("OnClick", "javascript:return saveClick();");
        hdnfollodate1.Value = Session["ALLOW_FOLLOW_DT_BOOOK"].ToString();
        aglist.Attributes.Add("OnClick", "javascript:return fillinsert(event);");
        aglist.Attributes.Add("OnKeydown", "javascript:return fillinsert(event);");
    }
    [Ajax.AjaxMethod]
    public void updateData(string srno, string insertid, string height, string width, string totarea, string dateI, string edition, string receiptno, string dateformat, string insstatus, string pageno)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.booking_subedition cls1 = new NewAdbooking.classesoracle.booking_subedition();
            cls1.updateData(srno, insertid, height, width, totarea, dateI, edition, receiptno, dateformat, insstatus, pageno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.booking_subedition cls1 = new NewAdbooking.Classes.booking_subedition();
            cls1.updateData(srno, insertid, height, width, totarea, dateI, edition, receiptno, dateformat, insstatus, pageno);
        }
    }
    [Ajax.AjaxMethod]
    public DataSet fetchEdition(string edition,string compcode,string insertid,string dateformat,string pkgcode)
    {
        //if (insertid == "0")
        //    insertid = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.booking_subedition cls1=new  NewAdbooking.Classes.booking_subedition();
            ds = cls1.fetchSubEdition(edition, compcode, insertid, dateformat, pkgcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.booking_subedition cls1 = new NewAdbooking.classesoracle.booking_subedition();
            ds = cls1.fetchSubEdition(edition, compcode, insertid, dateformat, pkgcode);
        }
        return ds;
    }
}
