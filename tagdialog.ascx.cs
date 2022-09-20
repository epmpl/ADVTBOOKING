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
public partial class tagdialog : System.Web.UI.UserControl
{
    string[] names;
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        //abc.Attributes.Add("onclick", "javascript:return addElement();");
        //abc.Attributes.Add("onclick", "javascript:return addElement();");
        //apply.Attributes.Add("onclick", "javascript:spltags();");

       // string abc1 = Server.MapPath("") + "/" + "spacial/";
        //string s = @"C:\Inetpub\wwwroot\Admaking1111\spacial";
        string p = ConfigurationManager.AppSettings["imagepath"].ToString();
        string abc1 = p + "/"+ "spacial/";
        System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(Server.MapPath("~/spacial"));
       // System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(abc1);
        int folders;
        int files;
        folders = d.GetDirectories().Length;
        files = d.GetFiles().Length;
        string pan = Convert.ToString(files);
        //string a = "<table><tr><td>ajay</td></tr></table>";
        //div1.InnerHtml = a;
        //div1.Visible = false;
        names = new string[files];
        string str1 = null;
        //System.IO.DirectoryInfo(Server.MapPath("") + "/" + "spacial/";
        //System.IO.Directory(Server.MapPath("") + "/" + "spacial/";
        for (int i = 0; i <= files - 1; i++)
        {
            //if(System.IO.DirectoryInfo
            names[i] = d.GetFiles().GetValue(i).ToString();

            //str1 = str1 + "," + d.GetFiles().GetValue(i).ToString();
            str1 = str1 + "," + names[i];
           }

        Console.WriteLine("The directory " + abc1 + " contains " + folders.ToString() + " folders and " + files.ToString() + " files.");
        arrayname.Value = str1;
        path11.Value = abc1;
       
       

    } 

   


   protected void abc_ServerClick(object sender, EventArgs e)
    {
        
       
    }

}
