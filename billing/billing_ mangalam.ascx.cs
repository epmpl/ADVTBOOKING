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

public partial class billing__mangalam : System.Web.UI.UserControl
{




    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/mangalam_bill.xml"));
        //lblbillno.Text = ds.Tables[0].Rows[0].ItemArray[0];
        //lbldate.Text = ds.Tables[0].Rows[0].ItemArray[1];
        //lblrono.Text = ds.Tables[0].Rows[0].ItemArray[2];
        //lblrodate.Text = ds.Tables[0].Rows[0].ItemArray[3];
        //lblterms.Text = ds.Tables[0].Rows[0].ItemArray[4];
        //lbladvertiser.Text = ds.Tables[0].Rows[0].ItemArray[5];
        //lblcaption.Text = ds.Tables[0].Rows[0].ItemArray[6];
        //lbledition.Text = ds.Tables[0].Rows[0].ItemArray[7];
        //lblgrossamt.Text = ds.Tables[0].Rows[0].ItemArray[8];
        //lbltradedisc.Text = ds.Tables[0].Rows[0].ItemArray[9];
        //lblbalance.Text = ds.Tables[0].Rows[0].ItemArray[10];
        //lblboxchrgs.Text = ds.Tables[0].Rows[0].ItemArray[11];
        //lblnetbal.Text = ds.Tables[0].Rows[0].ItemArray[12];
        //lblrupees.Text = ds.Tables[0].Rows[0].ItemArray[13];
        //lblcomname.Text = ds.Tables[0].Rows[0].ItemArray[14];
        //lblauth.Text = ds.Tables[0].Rows[0].ItemArray[15];

    }
}
