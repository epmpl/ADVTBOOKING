using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

public partial class Execsignattatchment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnok.Attributes.Add("OnClick", "javascript:closeattach();");
        lblfilename.Attributes.Add("OnClick", "javascript:return openfile();");
        if (Request.QueryString["filename"] != null)
        {
            lblfilename.Text = Request.QueryString["filename"].ToString();
            lblfilename.ToolTip = Request.QueryString["filename"].ToString();
        }
        if (Request.QueryString["hiddenshow"] != null && Request.QueryString["hiddenshow"].ToString() != "1")
        {
            Button1.Enabled = false;
            btnok.Enabled = false;
        }
        else
        {
            Button1.Enabled = true;
            btnok.Enabled = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        lblfilename.Text = filename;
        hiddenname.Value = filename;
        lblfilename.ToolTip = filename;
        if (!System.IO.Directory.Exists(Server.MapPath("TEMPSIGN")))
        {
            System.IO.Directory.CreateDirectory(Server.MapPath("TEMPSIGN"));
        }
        string SaveLocation = Server.MapPath("TEMPSIGN") + "\\" + filename;
        FileUpload1.PostedFile.SaveAs(SaveLocation);//System.IO.Path.Combine(SaveLocation, filename));
    }
    
}
