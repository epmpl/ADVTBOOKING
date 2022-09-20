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
using System.IO;
public partial class approvalAttachment : System.Web.UI.Page
{
    string  message;
    string message1;    
    protected void Page_Load(object sender, EventArgs e)
    {
        btnok.Attributes.Add("OnClick", "javascript:closeattach();");
        lblfilename.Attributes.Add("OnClick", "javascript:return openfile();");
      //  btnok1.Attributes.Add("OnClick", "javascript:closeattach1();");
        //lblfilename1.Attributes.Add("OnClick", "javascript:return openfile1();");
        //if (Request.QueryString["filename"] != null)
        //{
        //    lblfilename.Text = Request.QueryString["filename"].ToString();
        //    lblfilename.ToolTip = Request.QueryString["filename"].ToString();
        //}
        if (ConfigurationSettings.AppSettings["ATTACHFILEPATH"] != null && ConfigurationSettings.AppSettings["ATTACHFILEPATH"].ToString() != "")
        {
            hidfilepth.Value = ConfigurationSettings.AppSettings["ATTACHFILEPATH"].ToString();
        }
        else
        {
            hidfilepth.Value = "";
        }
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
        // string filename1 = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        //if (filename1 == "")
        //{
        //    message1 = "Browse the file first";
        //    AspNetMessageBox1(message1);
        //    return;
        //}
        ////lebforattach.Text = filename;
        ////lebforattach.ToolTip = filename;
        //FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("ApprovalAttachment"), filename1));
        //ScriptManager.RegisterStartupScript(this, typeof(approvalAttachment), "ss", "addlabel1('" + filename1 + "');", true);
        string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        if (filename == "")
        {
            message = "Browse the file first";
            AspNetMessageBox(message);
            return;
        }
        //lebforattach.Text = filename;
        //lebforattach.ToolTip = filename;
        if (hidfilepth.Value == "")
        {
            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("ApprovalAttachment"), filename));
        }
        else
        {
            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(hidfilepth.Value, filename));
        }
        ScriptManager.RegisterStartupScript(this, typeof(approvalAttachment), "ss", "addlabel('" + filename + "');", true);
    }
    //bhanu/////
   
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(approvalAttachment), "ShowAlert", strAlert, true);
    }
    //protected void AspNetMessageBox1(string strMessage1)
    //{
    //    //strMessage = adminResource.GetStringFromResource(strMessage);
    //    string strAlert1 = "";
    //    strAlert1 = "alert('" + strMessage1 + "')";
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(approvalAttachment), "ShowAlert", strAlert1, true);
    //}
    //bhanu end/////
}
