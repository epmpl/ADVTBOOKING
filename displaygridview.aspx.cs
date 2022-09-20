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

public partial class displaygridview : System.Web.UI.Page
{
    string fdate, tdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(displaygridview));
      

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("xml/displaytransferrept.xml"));

     txtfromdate.Text = Request.QueryString["fromdate"].ToString();
     txttodate.Text = Request.QueryString["todate"].ToString();


        lblmsg.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
       

        fdate = Request.QueryString["fromdate"].ToString();
        tdate = Request.QueryString["todate"].ToString();


        NewAdbooking.classmysql.transferreport bind = new NewAdbooking.classmysql.transferreport();
        ds = bind.gridview(fdate, tdate);

        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            GridView1.BorderStyle = BorderStyle.None;
            
        }
        else
        {
            lblerrormsg.ForeColor = Color.Red;
            
            lblerrormsg.Text = " Transfer Booking Ads Not Found";

        }

    }
}
