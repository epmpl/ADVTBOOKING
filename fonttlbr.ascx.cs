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

public partial class fonttlbr : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnpre.Attributes.Add("onclick", "javascript:previewdialog();");
        fntsize.Attributes.Add("onchange", "javascript:fontsize1();");
        fntname.Attributes.Add("OnChange", "javascript:fontajay(this.value);");
        bindfontdrp();
        bindsize();
    }

    public void bindfontdrp()
    {
        DataSet font = new DataSet();
        font.ReadXml(Server.MapPath("XML/font.xml"));
        fntname.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        //li1.Selected = true;
        fntname.Items.Add(li1);

        for (i = 0; i < font.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = font.Tables[0].Rows[0].ItemArray[i].ToString();
           // i = i + 1;
            li.Value = font.Tables[0].Rows[0].ItemArray[i].ToString();

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
