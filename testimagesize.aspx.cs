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
using System.Diagnostics;
using System.Drawing;

public partial class testimagesize : System.Web.UI.Page
{
    string filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        filename = "tree.pdf";
        ProcessStartInfo ProcessInfo;
        int ExitCode;
        Process Process;
        Bitmap b1;
        Bitmap b2;
        
        string p2 = Server.MapPath("/webdir/");
        string p1 = Server.MapPath("/webdir/Temppdf/");
       // string finalnam = Request.QueryString["ImageId"].ToString();
        writefile(p2 + "lata.bat", p2 + "convert.exe " + p1 + filename + " " + p1 + filename.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        ProcessInfo = new ProcessStartInfo(p2 + "lata.bat");
        //ProcessInfo.w
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.UseShellExecute = false;

        Process = Process.Start(ProcessInfo);
        Process.WaitForExit(70000);
        ExitCode = Process.ExitCode;

        //if (ExitCode != 0)
        //{
        //    while (ExitCode != 0)
        //    {
        //        Process = Process.Start(ProcessInfo);
        //        Process.WaitForExit(70000);
        //        ExitCode = Process.ExitCode;

        //    }
        //}

        Process.Close();
        //System.Drawing.Image image = System.Drawing.Image.FromStream(p1 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        string con = p1 + filename.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg");
        //b1 = new Bitmap(con);
        //b2 = new Bitmap(con);
        //b1 = new Bitmap(image);

    }
    protected void writefile(string fname, string sdata)
    {
        StreamWriter myStreamWriter;

        myStreamWriter = File.CreateText(fname);
        myStreamWriter.Write(sdata);
        myStreamWriter.Flush();
        myStreamWriter.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
    }
}
