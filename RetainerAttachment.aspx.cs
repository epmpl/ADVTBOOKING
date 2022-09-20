using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class RetainerAttachment : System.Web.UI.Page
{
    string message;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnok.Attributes.Add("OnClick", "javascript:closeattach();");
        lblfilename.Attributes.Add("OnClick", "javascript:return openfile();");
        //if (Request.QueryString["filename"] != null)
        //{
        //    lblfilename.Text = Request.QueryString["filename"].ToString();
        //    lblfilename.ToolTip = Request.QueryString["filename"].ToString();
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        //if (filename == "")
        //{
        //    message = "Brows the file first";
        //    AspNetMessageBox(message);
        //    return;
        //}
        //lblfilename.Text = filename;
        //lblfilename.ToolTip = filename;
        //FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("ApprovalAttachment"),filename));

        ///bhanu////
        string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        if (filename == "")
        {
            message = "Browse the file first";
            AspNetMessageBox(message);
            return;
        }
        //lebforattach.Text = filename;
        //lebforattach.ToolTip = filename;
        FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Attachment"), filename));
        ScriptManager.RegisterStartupScript(this, typeof(RetainerAttachment), "ss", "addlabel('" + filename + "');", true);
    }
    //bhanu/////

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(RetainerAttachment), "ShowAlert", strAlert, true);
    }
    //bhanu end/////
}
