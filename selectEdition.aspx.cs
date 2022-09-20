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

public partial class selectEdition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["pkgname"] != null)
            {

                bindTable();
            }
        }
    }
        private void bindTable()
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            DataSet ds = new DataSet();
            string val = Request.QueryString["pkgname"].Replace("  ", "+");
            ds = clsbooking.getPkgDetail(val);
            string output = "";
            output = "<div style=\"width:300px,height:200px,overflow:auto\"><table cellpadding=0 cellspacing=0 border=1><tr bgcolor=\"#7DAAE3\" class=\"dtGridHd12\"><td align=center>Select</td><td align=center width=\"100px\">Edition</td></tr>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                output = output + "<tr><td class=\"dtGrid\" align=center><input type=checkbox onclick=\"checkCount('" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "');\" value='" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "' id=chk" + i + " /></td><td align=center class=\"dtGrid\" width=\"100px\" id=td"+i+">" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td></tr>";
            }
            output = output + "</table></div>";
            tdtable.InnerHtml = output;
        }


    }
