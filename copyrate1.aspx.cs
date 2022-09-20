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

public partial class copyrate1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(copyrate1));
        bindrategroupcode();
    }

    [Ajax.AjaxMethod]
    public void copyrate(string srcRCode, string destRCode, string srcRGrCode, string destRGrCode, string dateformat)
    {
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.copyrate1 copy1 = new NewAdbooking.classesoracle.copyrate1();
            copy1.ratecopy(srcRCode, destRCode, srcRGrCode, destRGrCode, dateformat);
        }
    }

    ///////////////bind rate group code
    private void bindrategroupcode()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
            dx = bindrate.ratebind(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop bindrate = new NewAdbooking.classesoracle.pop();
                dx = bindrate.ratebind(Session["compcode"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.pop bindrate = new NewAdbooking.classmysql.pop();
                dx = bindrate.ratebind(Session["compcode"].ToString());
            }


        drpsrcrgrcode.Items.Clear();
        drpdestrgrcode.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Rate Group Code-";
        li1.Value = "0";
        li1.Selected = true;
        drpsrcrgrcode.Items.Add(li1);
        drpdestrgrcode.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                drpsrcrgrcode.Items.Add(li);
                drpdestrgrcode.Items.Add(li);

            }

        }
    }
}
