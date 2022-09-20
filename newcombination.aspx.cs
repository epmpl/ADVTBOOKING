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
using YControls;
public partial class newcombination : System.Web.UI.Page
{

    

    protected void Page_Load(object sender, EventArgs e)
    {
        YControls.YTripleStateCheckBox y1 = new YControls.YTripleStateCheckBox();
        CheckBox cb1 = new CheckBox();
        //LinkButton1.Click += new EventHandler(LinkButton1_Click);
        //this.PlaceHolder1.Controls.Add(LinkButton1); 
        cb1.CheckedChanged += new EventHandler(cb1_CheckedChanged);
        //cb1.Checked = true;
        cb1.Text = "anku";
        this.PlaceHolder1.Controls.Add(y1);
        
      
    }

    protected void cb1_CheckedChanged(object sender, EventArgs e)
    {

    }



    
    
}
