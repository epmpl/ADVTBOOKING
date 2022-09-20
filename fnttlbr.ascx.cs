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
using System.Drawing.Text;

public partial class fnttlbr : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)

    {
        fntsize.Attributes.Add("onchange", "javascript:fontsize1();");// OnSelectedIndexChanged =

        fntname.Attributes.Add("onchange", "javascript:fontName1();");
        //fnttools.Attributes.Add("onload", "javascript:getFonts();");
        //InstalledFontCollection myfonts = new InstalledFontCollection();
        //for (int x = 0; x < myfonts.Families.Length; x++)
        //{
        //    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
        //    li.Text = myfonts.Families[x].Name;
        //    fntname.Items.Add(li);
            

        //}
        
    }

}
