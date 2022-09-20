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

public partial class picproperties : System.Web.UI.UserControl
{
    int newid = 0;
    public string message;
    protected void Page_Load(object sender, EventArgs e)
    {
        //thumimg.Attributes.Add("onblur", "javascript:checkimage();");
       // LinkButton1.Attributes.Add("onclick", "javascript:getcropped()");
        //upload.Disabled="true";
       
    }
    protected void upload_ServerClick(object sender, EventArgs e)
    {
        ////if (thumimg.Value =="" )
        ////{
        ////    Response.Write("<script>alert('Please Specify the Image');</script>");
        ////}
        ////else
        ////{
        //    string val = thumimg.Value.ToString();
        //    string[] strsql = val.Split('.');
        //    string foldername = "images/";
        //    string strFilename1 = "Image" + newid + "." + strsql[1];
        //    string strfilename2 = foldername + strFilename1;
        //    thumimg.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);
        //    //Response.Write("<script>alert('image uploaded');</script>");
        //    newid++;
       // }
    }

    //protected void upload_Click(object sender, EventArgs e)
    //{
    //    //string abc = "hello";

    //    string val = thumimg.Value.ToString();
    //    string[] strsql = val.Split('.');
    //    string foldername = "images/";
    //    string strFilename1 = "Image" + newid + "." + strsql[1];
    //    string strfilename2 = foldername + strFilename1;
    //    thumimg.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);
    //    Response.Write("<script>alert('image uploaded');</script>");
    //    //message = "Image Uploaded";
    //    //AspNetMessageBox(message);
    //       newid++;


    //}

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(picproperties), "ShowAlert", strAlert, true);
    }
}
