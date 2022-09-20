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

public partial class fnttoolbar_new : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fntsize.Attributes.Add("onchange", "javascript:fontsize1();");
        fntname.Attributes.Add("OnChange", "javascript:return fontajay(this.value);");
        bindfontdrp();
        bindsize();
        fntname.SelectedIndex = 1;
		string agcode = Request.QueryString["agencycode"].ToString();
        hidagcode.Value = agcode;
        Ajax.Utility.RegisterTypeForAjax(typeof(fnttoolbar_new));
        if (ConfigurationSettings.AppSettings["fontDownload"].ToString() == "no")
        {
            tddown.Visible = false;
        }
    }
	[Ajax.AjaxMethod]
    public DataSet bindreceiptno(string s_agencycode, string filename)
    {
        DataSet ds_rcpt = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objCioid = new NewAdbooking.classesoracle.BookingMaster();
            ds_rcpt = objCioid.clsCioId(s_agencycode, filename);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objCioid = new NewAdbooking.classmysql.BookingMaster();
            ds_rcpt = objCioid.clsCioId(s_agencycode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objCioid = new NewAdbooking.Classes.BookingMaster();
            ds_rcpt = objCioid.clsCioId(s_agencycode, filename);
        }
        return ds_rcpt;
    }
    public void bindfontdrp()
    {
        DataSet font = new DataSet();
        font.ReadXml(Server.MapPath("XML/font.xml"));
        fntname.Items.Clear();
        int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select";
        //li1.Value = "0";
        ////li1.Selected = true;
        //fntname.Items.Add(li1);

        for (i = 0; i < font.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = font.Tables[0].Rows[0].ItemArray[i].ToString().Split('@')[0];
            li.Value = font.Tables[0].Rows[0].ItemArray[i].ToString().Split('@')[1];
            fntname.Items.Add(li);
        }

    }
    public void bindsize()
    {
        DataSet siz = new DataSet();
        siz.ReadXml(Server.MapPath("XML/font.xml"));
        fntsize.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        //li1.Selected = true;
        fntsize.Items.Add(li1);

        for (i = 0; i < siz.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = siz.Tables[1].Rows[0].ItemArray[i].ToString();
            // i = i + 1;
            li.Value = siz.Tables[1].Rows[0].ItemArray[i].ToString();

            fntsize.Items.Add(li);

        }
    }
}
