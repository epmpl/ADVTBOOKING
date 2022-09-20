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

public partial class spliteditionsize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(spliteditionsize));
        btninsertrow.Attributes.Add("onClick", "javascript:return addClick();");
        btndeleterow.Attributes.Add("OnClick", "javascript:return deleteRow();");
        btncancel.Attributes.Add("OnClick", "javascript:return closepopup();");
        btnsavedetail.Attributes.Add("OnClick", "javascript:return saveClick();");
       // btnDelete.Attributes.Add("onClick", "javascript:return deleteclick();");
        hiddenedition.Value = Request.QueryString["edition"].ToString();
        hiddentotalarea.Value = Request.QueryString["totalarea"].ToString();
        hiddendateformat.Value = Request.QueryString["dateformat"].ToString();
        hiddenchkbtnStatus.Value = Request.QueryString["chkbtnStatus"].ToString();
        hiddeninsertstatus.Value = Request.QueryString["insertstatus"].ToString();
        hiddenidnum.Value = Request.QueryString["idnum"].ToString();
        hiddencioid.Value = Request.QueryString["cioid"].ToString();
        hiddenreceiptno.Value = Request.QueryString["receiptno"].ToString();
        btninsertrow.Enabled = false;
        btndeleterow.Enabled = false;
        btnsavedetail.Enabled = false;
        if ((hiddeninsertstatus.Value=="booked" && Request.QueryString["chkbtnStatus"].ToString() =="modify") || Request.QueryString["chkbtnStatus"].ToString() == "new")
        {
            btninsertrow.Enabled = true;
            btndeleterow.Enabled = true;
            btnsavedetail.Enabled = true;
        }
        if (Request.QueryString["showid"] != null && Request.QueryString["showid"].ToString() != "")
        {
            hiddeninsertid.Value = Request.QueryString["showid"].ToString();
           
        }
    }
      [Ajax.AjaxMethod]
    public void deleteRecord(string srno,string insertid)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
            insertchild.deleteRecord(srno, insertid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster insertchild = new NewAdbooking.Classes.BookingMaster();
            insertchild.deleteRecord(srno, insertid);
        }
    }
   
    [Ajax.AjaxMethod]
    public void updateData(string srno, string insertid, string height, string width, string totarea, string dateI,string cioid,string receiptno)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
            insertchild.updateData(srno, insertid, height, width, totarea, dateI,cioid,receiptno);
        }
    }
     [Ajax.AjaxMethod]
    public DataSet fetchinsertdata(string insertid,string dateformat)
     {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.BookingMaster insertchild = new NewAdbooking.classesoracle.BookingMaster();
             ds = insertchild.getInsertSplitData(insertid, dateformat);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.BookingMaster insertchild = new NewAdbooking.Classes.BookingMaster();
             ds = insertchild.getInsertSplitData(insertid, dateformat);
         }
         return ds;
     }
}
