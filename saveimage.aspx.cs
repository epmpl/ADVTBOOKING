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
using System.Drawing;

public partial class saveimage : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        //Response.Write("<script>alert(\"H\");</script>");
        string message = "";
        string filename = Request.QueryString["source"].ToString();
       
       

        string image = System.IO.Path.GetFileName(filename);
        string path = Server.MapPath("Images/");
        string fullPath = path + image;
        message = path;
        //AspNetMessageBox(message);
        
        
        //string str3 = @"d:/Ankur";  //give the path where you want to upload the file.
        Stream s = System.IO.File.OpenRead(filename);
        byte[] buffer = new byte[s.Length];
        s.Read(buffer, 0, (int)s.Length);
        int len = (int)s.Length;
        s.Dispose();
        s.Close();
        FileStream fs = new FileStream(fullPath, FileMode.Create);
       
        fs.Write(buffer, 0, len);
       Bitmap bmp = new Bitmap(fs);
        
       
        if (System.IO.Path.GetExtension(filename).Equals(".gif"))
        {

            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);

        }

        else
        {

            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

        }



        bmp.Dispose();



        fs.Dispose();

        fs.Close();
        Response.Write(fullPath);
        Response.End();

 
 

    }

    
}
