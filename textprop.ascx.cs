using System;
using System.Data;
using System.Configuration;
using System.Drawing.Text;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class textprop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)

    {
        fntname.Attributes.Add("onchange", "javascript:fontName();");
        //InstalledFontCollection fonts = new InstalledFontCollection();
        //for (int x = 0; x < fonts.Families.Length; x++)
        //{
        //    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
        //    li.Text = fonts.Families[x].Name;
        //    fntname.Items.Add(li);

        //}
       
    }
    protected void dropcheck_CheckedChanged(object sender, EventArgs e)
    {

    }
}
