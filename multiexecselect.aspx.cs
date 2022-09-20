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


public partial class multiexecselect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddendateformat.Value = Session["DateFormat"].ToString();
        hiddencioid.Value = Request.QueryString["cioid"].ToString();
        hiddenmod.Value = Request.QueryString["modify"].ToString();
        if (Request.QueryString["execode"].ToString() != "")
        {
            btnsubmit.Enabled = false;
            btad.Enabled = true;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(multiexecselect));
        if (!IsPostBack)
        {
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitcl();");
            btad.Attributes.Add("OnClick", "javascript:return multiad();");
            
        }
        
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindExec(string compcode, string execname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

            ds = clsbooking.getExec(compcode, execname, "0");

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }
        }
       
        return ds;
    }
    
    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "exec";
        myDataTable.Columns.Add(myDataColumn);




        return myDataTable;
    }
    private void AddDataToTable(string username, string firstname, string lastname, DataTable myTable)
    {
        DataRow row;

        row = myTable.NewRow();
       
        row["exec"] = firstname;

        myTable.Rows.Add(row);
    }
    [Ajax.AjaxMethod]
    public void deleteexe(string compcode, string cioid,string code)
    {
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

           clsbooking.deleteexe(compcode,cioid, code );

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

           clsbooking.deleteexe(compcode,cioid, code);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            
        }

      
    }

}
