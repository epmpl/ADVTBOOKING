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
using System.Diagnostics;
public partial class OPENAUDITPREVIEW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string uomdesc = "";
        string cioid = "";

        int wd = Convert.ToInt32((Convert.ToDouble(15) * 72) / 2.54);
        int ht =  Convert.ToInt32((Convert.ToDouble(15) * 72) / 2.54);
        if (Request.QueryString["uomdesc"] != null)
        {
            uomdesc = Request.QueryString["uomdesc"].ToString();
            cioid = Request.QueryString["cioid"].ToString();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Booking_Audit1 clsaudit = new NewAdbooking.classesoracle.Booking_Audit1();
                ds = clsaudit.fetchMatter(cioid, uomdesc);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.session_billing clsaudit = new NewAdbooking.BillingClass.Classes.session_billing();
                ds = clsaudit.fetchMatter(cioid, uomdesc);
            }
            else
            {
                string procedureName = "websp_fetchmatter_websp_fetchmatter_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { cioid, uomdesc };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (uomdesc == "CD")
                {
                    string imgname = "";
                    imgname = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (imgname != "" && imgname != "undefined" && imgname != "null")
                    {
                       string PATH = Server.MapPath(".") + "\\temppdf\\" + imgname;

                        if (System.IO.File.Exists(Server.MapPath("temppdf/" + imgname + ".jpg")))
                        {

                          
                            prev.InnerHtml = "<img src='image.aspx?path=" +(PATH+ ".jpg") + "' width=" + Convert.ToString(wd) + " height=" + Convert.ToString(ht) + "/>";
                           // prev.InnerHtml = "<img src='image.aspx?path=" + Server.MapPath("temppdf/" + imgname + ".jpg") + "' width=" + Convert.ToString(wd) + " height=" + Convert.ToString(ht) + "/>";
                           // prev.InnerHtml = "<img src='" + Server.MapPath("temppdf/" + imgname + ".jpg") + "'>";
                           // prev.InnerHtml = "<img src='image.aspx?path=" + Server.MapPath("temppdf/" + imgname + ".jpg")+"'/>";
                        }
                        if (System.IO.File.Exists(Server.MapPath("temppdf/" + imgname + ".eps")))
                        {
                            prev.InnerHtml = "<img src='" + (PATH+ ".eps") + "'>";
                           // prev.InnerHtml = "<img src='" + Server.MapPath("temppdf/" + imgname + ".eps") + "'>";
                        }
                       
                        //string log_ext = imgname.ToString().Substring(imgname.ToString().LastIndexOf("."));
                        //float height;
                        //float width;
                        //float finalheight;
                        //float finalwidth;
                        //double imgRatio;
                        ////////if (log_ext == ".jpg" || log_ext == ".jpeg")
                        ////////{
                        ////////    if (System.IO.File.Exists(Server.MapPath("Original/" + cioid + "/" + imgname)))
                        ////////    {
                        ////////        Bitmap b1 = new Bitmap(Server.MapPath("Original/" + cioid + "/" + imgname));
                        ////////        height = b1.Height;
                        ////////        width = b1.Width;
                        ////////        if (height > width)
                        ////////            imgRatio = width / height;
                        ////////        else
                        ////////            imgRatio = height / width;

                        ////////        if (height < width)
                        ////////        {
                        ////////            finalwidth = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                        ////////            finalheight = Convert.ToInt32(150 * imgRatio);
                        ////////        }
                        ////////        else
                        ////////        {
                        ////////            finalheight = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                        ////////            finalwidth = Convert.ToInt32(150 * imgRatio);
                        ////////        }

                        ////////        prev.InnerHtml = "<img src='" + Server.MapPath("Original/" + cioid + "/" + imgname) + "' width='" + Convert.ToString(finalwidth) + "' height='"+Convert.ToString(finalheight)+"'>";
                        ////////    }
                        ////////}
                        ////////else if (log_ext == ".eps")
                        ////////{
                        ////////    System.IO.File.Copy(Server.MapPath("Orignal" + "/" + cioid + "/" + imgname), Server.MapPath("Temppdf/" + "xyz.eps"), true);
                        ////////    createjpgfrompdf("xyz.eps");
                        ////////    string path = Server.MapPath("temppdf/") + "xyz1.jpg";

                        ////////    Bitmap b1 = new Bitmap(path);
                        ////////    height = b1.Height;
                        ////////    width = b1.Width;
                        ////////    if (height > width)
                        ////////        imgRatio = width / height;
                        ////////    else
                        ////////        imgRatio = height / width;

                        ////////    if (height < width)
                        ////////    {
                        ////////        finalwidth = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                        ////////        finalheight = Convert.ToInt32(150 * imgRatio);
                        ////////    }
                        ////////    else
                        ////////    {
                        ////////        finalheight = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                        ////////        finalwidth = Convert.ToInt32(150 * imgRatio);
                        ////////    }
                        ////////    prev.InnerHtml = "<img src='" + path + "'  width='"+finalwidth+"' height='"+finalheight+"'>";
                        ////////}
                        ////////else if (log_ext == ".pdf")
                        ////////{
                        ////////    System.IO.File.Copy(Server.MapPath("Orignal" + "/" + cioid + "/" + imgname), Server.MapPath("Temppdf/" + "xyz.pdf"), true);
                        ////////    createjpgfrompdf("xyz.eps");
                        ////////    string path = Server.MapPath("temppdf/") + "xyz1.jpg";

                        ////////    Bitmap b1 = new Bitmap(path);
                        ////////    height = b1.Height;
                        ////////    width = b1.Width;
                        ////////    if (height > width)
                        ////////        imgRatio = width / height;
                        ////////    else
                        ////////        imgRatio = height / width;

                        ////////    if (height < width)
                        ////////    {
                        ////////        finalwidth = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                        ////////        finalheight = Convert.ToInt32(150 * imgRatio);
                        ////////    }
                        ////////    else
                        ////////    {
                        ////////        finalheight = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                        ////////        finalwidth = Convert.ToInt32(150 * imgRatio);
                        ////////    }

                        ////////    prev.InnerHtml = "<img src='" + path + "'  width='"+finalwidth+"' height='"+finalheight+"'>";
                        ////////}

                    }

                }
                else
                {
                    prev.InnerHtml = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
            else
            {
                prev.InnerHtml = "<font name=verdana><b>Preview Not Available</font>";
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, typeof(OPENAUDITPREVIEW), "FN", "window.opener.document.getElementById('btnpreview').disabled=false;", true);
        ScriptManager.RegisterClientScriptBlock(this, typeof(OPENAUDITPREVIEW), "FN1", "window.opener.document.getElementById('btnaudit').disabled=false;", true);
    }
    public void createjpgfrompdf(string filname)
    {
        ProcessStartInfo ProcessInfo;
        int ExitCode;
        Process Process;
        Bitmap b1;
        Bitmap b2;
        string p2 = "";
        string p1 = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            p2 = Server.MapPath("//");
            p1 = Server.MapPath("//Temppdf/");
        }
        else
        {
            p2 = Server.MapPath("/webdir/");
            p1 = Server.MapPath("/webdir/Temppdf/");
        }

        string finalnam = filname;
        string ext = finalnam.Replace(".pdf", ".jpg").Replace(".eps", ".jpg").Replace(".tiff", ".jpg");
        writefile(p2 + "lata.bat", p2 + "convert.exe " + p1 + finalnam + " " + p1 + finalnam.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
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
        string con = p1 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg");
        b1 = new Bitmap(con);
        System.Drawing.Image bmp2 = b1.GetThumbnailImage(Convert.ToInt32(b1.Width), Convert.ToInt32(b1.Height), null, IntPtr.Zero);
        con=con.Replace("xyz.jpg", "xyz1.jpg");
        bmp2.Save(con, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    protected void writefile(string fname, string sdata)
    {
        StreamWriter myStreamWriter;

        myStreamWriter = File.CreateText(fname);
        myStreamWriter.Write(sdata);
        myStreamWriter.Flush();
        myStreamWriter.Close();
    }
}
