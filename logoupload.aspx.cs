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

public partial class logoupload : System.Web.UI.Page
{
    string filename = "";
    string str1 = "";
    // for checking///////
    double adheight = 0;
    double adwidth = 0;
    double subheight = 0;
    double subwidth = 0;
    ProcessStartInfo ProcessInfo;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;
        }
        if (FileUpload1.PostedFile.FileName == "")
        {
            Response.Write("<script>alert(\"Please select the file\")</script>");
            return;
        }       
        string inserts = Request.QueryString["insertNo"].ToString();
        //  string edition = Request.QueryString["edition"].ToString();
        string cioid = Request.QueryString["ciobookid"].ToString();
        string fileid = Request.QueryString["srno"].ToString();
        string edition = Request.QueryString["edition"].ToString();
        string logoid = Request.QueryString["logoid"].ToString();
        str1 = FileUpload1.PostedFile.FileName;
        string str2 = Path.GetFileName(str1);
        int ind = str2.LastIndexOf(".");
        int len = (str2.Length) - ind;
        string tot = str2.Substring(ind, len);
        string val = cioid + "-" + inserts + "-" + fileid;
        if(fileid=="All")
            val = cioid + "-" + fileid + "-" + logoid;
        else
            val = cioid + "-" + (Convert.ToInt32(inserts.ToString())) + "-" + (Convert.ToInt32(fileid) + 1) + "-" + logoid;
        
        if (Request.QueryString["adheight"] != null)
        {
            adheight = Convert.ToDouble(Request.QueryString["adheight"]);
            /*adding and subtracting  the tolerance in height*/
            //subheight = adheight - 1;
            //adheight = adheight + .1;
            adwidth = Convert.ToDouble(Request.QueryString["adwidth"]);
            /*adding and subtracting the tolerance in width*/
            //subwidth = adwidth - 1;
            //adwidth = adwidth + .1;
        }        
        if (adwidth == 1 || adwidth == 1.1 || adwidth == .9)
        {
            if(Request.QueryString["colwidth"]!=null)
                adwidth = Convert.ToDouble(Request.QueryString["colwidth"]);
        }
      //  DataSet dsgetwidth = new DataSet();
        /*  this to calculate the width for publication*/
      /*  if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
            dsgetwidth = getpubwidth.getwidth_qbc(pubedit, Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                if (pubedit.IndexOf("+") < 0)
                {
                    dsgetwidth = getpubwidth.getwidth_qbc(pubedit, Session["compcode"].ToString());
                    ////////if the width is in 1 column than we have to take the leading publication column width and than convert it into cm
                    if (adwidth == 1 || adwidth == 1.1 || adwidth == .9)
                    {
                        adwidth = Convert.ToDouble(dsgetwidth.Tables[0].Rows[0].ItemArray[0]);
                    }
                }
                else
                {
                    dsgetwidth = getpubwidth.getpriority_lead(Request.QueryString["code"].ToString(), Request.QueryString["uom"].ToString());
                    ////////if the width is in 1 column than we have to take the leading publication column width and than convert it into cm
                    if (adwidth == 1 || adwidth == 1.1 || adwidth == .9)
                    {
                        adwidth = Convert.ToDouble(dsgetwidth.Tables[0].Rows[0].ItemArray[1]);
                    }
                }
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();
                if (pubedit.IndexOf("+") < 0)
                {
                    dsgetwidth = getpubwidth.getwidth_qbc(pubedit, Session["compcode"].ToString());
                    ////////if the width is in 1 column than we have to take the leading publication column width and than convert it into cm
                    if (adwidth == 1 || adwidth == 1.1 || adwidth == .9)
                    {
                        adwidth = Convert.ToDouble(dsgetwidth.Tables[0].Rows[0].ItemArray[0]);
                    }
                }
                else
                {
                    dsgetwidth = getpubwidth.getpriority_lead(Request.QueryString["code"].ToString(), Request.QueryString["uom"].ToString());
                    ////////if the width is in 1 column than we have to take the leading publication column width and than convert it into cm
                    if (adwidth == 1 || adwidth == 1.1 || adwidth == .9)
                    {
                        if (dsgetwidth.Tables[0].Rows.Count > 0)
                        {
                            adwidth = Convert.ToDouble(dsgetwidth.Tables[0].Rows[0].ItemArray[1]);
                        }
                        else
                        {
                            adwidth = 33;
                        }
                    }
                }
            }*/
        //////////////////////////
        /*this is to upload only jpg,gif,tif and png file only*/
        filename = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("."));
        str1 = FileUpload1.PostedFile.FileName;        
        if (filename == ".jpg" || filename == ".jpeg" || filename == ".png" || filename == ".tiff" || filename == ".png" || filename == ".gif" || filename == ".eps" || filename == ".pdf" || filename == ".tif")
        {   
        }
        else
        {           
            Response.Write("<script>alert(\"Upload Jpegs,Gifs,Tiff,Png,Eps and Pdf only.\");</script>");
            return;
        }

        ////these height and width are in mm therefore we have to convert it in cm
        if (ConfigurationSettings.AppSettings["adwidth"].ToString() == "mm")
        {
            adheight = adheight / 10;
            adwidth = adwidth / 10;
        }
        //subheight = subheight / 10;
        //subwidth = subwidth / 10;
        //System.Drawing.Image image=null;
        Bitmap image = null;
        string tot1 = "";
        /*convert the pdf and eps file  into jpeg and than chk its height and width during run time*/
        // by nand on 3rdjune *** if (filename == ".pdf" || filename == ".eps" || filename == ".tiff" || filename == ".tif" )  
        if (filename == ".pdf" || filename == ".eps" || filename == ".tiff" || filename == ".tif" || filename == ".jpg" || filename == ".jpeg")
        {            
            string nam = "";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                nam = Server.MapPath("//Temppdf/");
            }
            else
            {
                nam = Server.MapPath("Temppdf");
            }
            string filnam = Path.GetFileName(FileUpload1.PostedFile.FileName);
            ind = filnam.LastIndexOf(".");
            tot1 = filnam.Substring(0, ind);
            if (filename == ".pdf")
            {
                tot1 = tot1.Replace(tot1, val + ".pdf");
            }
            else if (filename == ".eps")
            {
                tot1 = tot1.Replace(tot1, val + ".eps");
            }
            else if (filename == ".tif")
            {
                tot1 = tot1.Replace(tot1, val + ".tif");
            }
            else if (filename == ".tiff")
            {
                tot1 = tot1.Replace(tot1, val + ".tiff");
            }
            else if (filename == ".jpg")
            {
                tot1 = tot1.Replace(tot1, val + ".jpg");
            }
            else if (filename == ".JPG")
            {
                tot1 = tot1.Replace(tot1, val + ".jpg");
            }
            else if (filename == ".jpeg")
            {
                tot1 = tot1.Replace(tot1, val + ".jpeg");
            }
            
           //*** FileUpload1.PostedFile.SaveAs(Path.Combine(nam, tot1));
            FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("Orignal"), tot1));
            string p10 = ConfigurationSettings.AppSettings["Classified_Reference_Path"].ToString();
            FileUpload1.PostedFile.SaveAs(Path.Combine(p10, tot1));
            createjpgfrompdf(tot1);
        }

        /*MemoryStream memoryStream = new MemoryStream();
        memoryStream.Write(imgByte, 0, imgByte.Length);
        image = new Bitmap(memoryStream);
        memoryStream.Flush();
        memoryStream.Close();*/
        string p6 = Server.MapPath("Temp/");
        image = new Bitmap(p6 + tot1.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg"));

        double imgWidth = image.PhysicalDimension.Width;
        double imgWidthcm = 0;
        double imgHeight = 0;
        double imgHeightcm = 0;

        if (filename == ".tif" || filename == ".tiff" || filename == ".jpg" || filename == ".jpeg")
        {
            imgWidthcm = Math.Round((imgWidth * 2.54 / image.HorizontalResolution), 2); //image.HorizontalResolution
            imgHeight = image.PhysicalDimension.Height;
            imgHeightcm = Math.Round((imgHeight * 2.54 / image.HorizontalResolution), 2);
        }
        else
        {
            imgWidthcm = Math.Round((imgWidth * 2.54 / 72), 2);
            imgHeight = image.PhysicalDimension.Height;
            imgHeightcm = Math.Round((imgHeight * 2.54 / 72), 2);
        }
        image.Dispose();
        image = null;
        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision" && Request.QueryString["edition"]!=null)
        {
            DataSet ds = new DataSet();
            clsconnection dconnect = new clsconnection();
            string sqldd = "";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                sqldd = "SELECT dbo.getcm1('" + adwidth + "','" + edition + "','CL0') from dual";                
            }
            else
            {
                sqldd = "SELECT dbo.getcm1('" + adwidth + "','" + edition + "','CL0')as size";                
            }
            ds = dconnect.executequery(sqldd);
            adwidth = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        } 
        if ((imgHeightcm > (adheight + .1) || imgHeightcm < (adheight - .1)) || (imgWidthcm > (adwidth + .1) || imgWidthcm < (adwidth - .1)))
        {
            Response.Write("<script>alert(\"Wrong size image\");window.close();</script>");
            //image.Dispose();           
           // Response.Write("<script>window.opener.document.getElementById('txtlogoupload').value='" + val + "'</script>");
            if (filename != ".pdf" && filename != ".eps")
            {
                if (System.IO.File.Exists(p6 + tot1.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg")))
                    System.IO.File.Delete(p6 + tot1.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg"));
                if(System.IO.File.Exists(Server.MapPath("Orignal//") + tot1))
                    System.IO.File.Exists(Server.MapPath("Orignal//") + tot1);
                
                /*System.IO.FileInfo f1 = new FileInfo(p6 + tot1.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg"));                
                try
                {
                    f1.Delete();
                    f1 = null;
                    FileUpload1.Dispose();
                    FileUpload1 = null;
                }
                catch
                {
                }
                finally
                {
                }*/
            }            
            return;
        }
         

        /*india*/
     /*   if (Request.QueryString["chk_modify"].ToString() == "01")
        {
            DataSet dex = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
                dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster showgri = new NewAdbooking.classesoracle.BookingMaster();
                dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());
            }
            if (dex.Tables[9].Rows.Count > 0)
            {
                string log_nam = "";
                string log_ext = "";
                if (dex.Tables[9].Rows[0].ItemArray[0].ToString() != "" && dex.Tables[9].Rows[0].ItemArray[0].ToString() != null)
                {
                    log_nam = dex.Tables[9].Rows[0].ItemArray[0].ToString().Substring(0, dex.Tables[9].Rows[0].ItemArray[0].ToString().LastIndexOf("."));
                    log_ext = dex.Tables[9].Rows[0].ItemArray[0].ToString().Substring(dex.Tables[9].Rows[0].ItemArray[0].ToString().LastIndexOf("."));
                }
                else
                {
                    log_nam = "";
                    log_ext = "";
                }
                if (log_nam.LastIndexOf("_") >= 0)
                {
                    string under_nam = log_nam.Substring(0, log_nam.LastIndexOf("_"));
                    string underscore = log_nam.Substring(log_nam.LastIndexOf("_"));
                    underscore = underscore.Replace("_", "");

                    underscore = Convert.ToString(Convert.ToInt32(underscore) + 1);
                    val = under_nam + "_" + Convert.ToString(underscore) + log_ext;
                    edition = edition + "_" + Convert.ToString(underscore);
                }
                else
                {
                    if (log_nam != "" && log_ext != "")
                    {
                        val = log_nam + "_" + "1" + filename;
                        edition = edition + "_1";
                    }
                    else
                    {
                    }
                }
            }
        }
        Session["Tempimgname_logo"] = str2;
        Session["Tempinsertname_logo"] = inserts + "-" + edition;

        if (Session["imgname_logo"] != null)
        {
            Session["imgname_logo"] = Session["Tempimgname_logo"].ToString() + "+" + Session["imgname_logo"].ToString();
            Session["insertname_logo"] = Session["Tempinsertname_logo"].ToString() + "/" + Session["insertname_logo"].ToString();
        }
        else
        {
            Session["imgname_logo"] = Session["Tempimgname_logo"].ToString();
            Session["insertname_logo"] = Session["Tempinsertname_logo"].ToString();
        }
        */

        if (logoid == "1")
        {
            Response.Write("<script>window.opener.document.getElementById('txtlogoupload').value='" + tot1 + "'</script>");
        }
        else
        {
            Response.Write("<script>window.opener.document.getElementById('txtlogoupload1').value='" + tot1 + "'</script>");
        }
        Response.Write("<script>window.close();</script>");
        Response.Write("<script>window.close();</script>");

    /*  if (fileid != "bookdiv")
        {
            string no = Request.QueryString["no"].ToString();
            Response.Write("<script>window.opener.document.getElementById('txtlogoupload').value='" + val + "'</script>");
            Response.Write("<script>window.close();</script>");
        }
        else
        {
            string fill = "<script>";
            fill = fill + "var y=window.opener.document.getElementById('" + fileid + "').getElementsByTagName('table')[0].rows.length;";
            fill = fill + "var filename;";
            fill = fill + "var h;";
            fill = fill + "var w;";
            fill = fill + "var s;";
            fill = fill + "var i;";
            fill = fill + "for(i=0;i<y-1;i++)";
            fill = fill + "{";
            fill = fill + "filename=\"lnam\"+i;";
            fill = fill + "h=\"hei\"+i;";
            fill = fill + "w=\"wid\"+i;";
            fill = fill + "s=\"siz\"+i;";
            fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";

            fill = fill + "}";
            fill = fill + "</script>";
            Response.Write(fill);
            Response.Write("<script>window.close();</script>");
        }
        */
     /*   clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + Session["userid"] + "','Order','','Order Attach image','";
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    sqldd = sqldd + dconnect.getagencyname(Request.QueryString["agcode"].ToString()) + " ";
        sqldd = sqldd + Request.QueryString["ciobookid"].ToString() + " " + dfname + "',";
        sqldd = sqldd + "'" + Request.ServerVariables["REMOTE_ADDR"] + "')";
        dconnect.executenonquery1(sqldd);
        */


        string datefield = Request.QueryString["datefield"].ToString();
        clsconnection dconnect1 = new clsconnection();
        string sqldd1 = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string[] arr = datefield.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            datefield = mm + "/" + dd + "/" + yy;
            sqldd1 = "insert into allthumbimage_log (ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,FLAG) values ";
            sqldd1 = sqldd1 + "('" + str1 + "','" + val + filename + "','" + Convert.ToDateTime(datefield).ToString("dd-MMMM-yyyy") + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate,'CL0','Y')";
            //sqldd = "select \"userid\",\"username\" from login ";
            //if (Session[0].ToString() != "0")
            //    sqldd = sqldd + " where \"Agency_code\"='" + Session[0].ToString() + "'";
        }
        else
        {


        }

        dconnect1.executequery(sqldd1);
 
    }

    public void createjpgfrompdf(string filname)
    {
        int ExitCode;
        Process Process;
       // Bitmap b1;
        //Bitmap b2;
        string p2 = "";
        string p1 = "";
        string p3 = "";
        string p4 = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            p2 = Server.MapPath("//");
            p1 = Server.MapPath("//Orignal/");
            p3 = Server.MapPath("//Temppdf/");
            p4 = Server.MapPath("//Temp/");
        }
        else
        {
            p2 = Server.MapPath("~/");
            p1 = Server.MapPath("~/Orignal/");
            p3 = Server.MapPath("~/Temppdf/");
            p4 = Server.MapPath("~/Temp/");
        }
        string finalnam = filname;

        //by nand on 3june***
        //if (finalnam.IndexOf(".jpg") > 0)
        //{
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        //{
        //    b2 = new Bitmap(Server.MapPath("//Temppdf/") + finalnam);

        //}
        //else
        //{
        //    b2 = new Bitmap(Server.MapPath("Temppdf/") + finalnam);

        //}
        //if (b2.HorizontalResolution == 600)
        //{
        //    //writefile(p2 + "lata.bat", p2 + "convert.exe " + p1 + finalnam + " " + "-resize 16%%" + " " + p1 + "abc.jpg");
        //    //Process = Process.Start(p2 + "convert.exe", p1 + finalnam + " -resize 16%% " + p1 + finalnam);
        //    ProcessInfo = new ProcessStartInfo(p2 + "convert.exe", p1 + finalnam + " -resize 16%% " + p1 + finalnam);
        //}
        //else if (b2.HorizontalResolution == 300)
        //{
        //    //writefile(p2 + "lata.bat", p2 + "convert.exe " + p1 + finalnam + " " + "-resize 32%%" + " " + p1 + "abc.jpg");
        //    //Process = Process.Start(p2 + "convert.exe", p1 + finalnam + " -resize 32%% " + p1 + finalnam);
        //    ProcessInfo = new ProcessStartInfo(p2 + "convert.exe", p1 + finalnam + " -resize 32%% " + p1 + finalnam);
        //}
        //else if (b2.HorizontalResolution == 1200)
        //{
        //    //writefile(p2 + "lata.bat", p2 + "convert.exe " + p1 + finalnam + " " + "-resize 8%%" + " " + p1 + "abc.jpg");
        //    //Process = Process.Start(p2 + "convert.exe", p1 + finalnam + " -resize 8%% " + p1 + finalnam);
        //    ProcessInfo = new ProcessStartInfo(p2 + "convert.exe", p1 + finalnam + " -resize 8%% " + p1 + finalnam);
        //}
        //else
        //{
        //    //writefile(p2 + "lata.bat", p2 + "convert.exe " + p1 + finalnam + " " + "-resample 96x96" + " " + p1 + finalnam.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        //    //Process = Process.Start(p2 + "convert.exe", p1 + finalnam + " -resample 96x96 " + p1 + finalnam);
        //    ProcessInfo = new ProcessStartInfo(p2 + "convert.exe", p1 + finalnam + " -resample 96x96 " + p1 + finalnam);
        //}

       // string Pix_height = Convert.ToInt32((adheight * 3.78 * 10)).ToString();
      //  string Pix_wid = Convert.ToInt32((adwidth * 3.78 * 10)).ToString();

        string Pix_height = Convert.ToString((72 / 2.54) * Convert.ToDouble(adheight));
        string Pix_wid = Convert.ToString((72 / 2.54) * Convert.ToDouble(adwidth));
        ProcessInfo = new ProcessStartInfo("\"" + p2 + "convert.exe" + "\"", "\"" + p1 + finalnam + "\" -density 72x72  -units PixelsPerInch -thumbnail " + Pix_wid + "x" + Pix_height + " \"" + p4 + finalnam.ToLower().Replace(".pdf", ".jpg").Replace(".jpeg", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg") + "\"");
        
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.UseShellExecute = false;

        Process = Process.Start(ProcessInfo);

        Process.WaitForExit(900000);
        ExitCode = Process.ExitCode;
        Process.Close();
        Process.Dispose();
        if (System.IO.File.Exists(p4 + finalnam.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg")))
        {
            Bitmap bmp1 = new Bitmap(p4 + finalnam.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg"));
            System.Drawing.Image bmp2 = bmp1.GetThumbnailImage(Convert.ToInt32(bmp1.Width), Convert.ToInt32(bmp1.Height), null, IntPtr.Zero);
            bmp2.Save(p3 + finalnam.Replace(".tiff", ".jpg").Replace(".eps", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".jpeg", ".jpg").Replace(".TIF", ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();
            bmp2.Dispose();
        }
        else
        {
            Response.Write("<script>alert('Please Upload File Again.');</script>");
            return;
        }
    }

    protected void writefile(string fname, string sdata)
    {
        StreamWriter myStreamWriter;

        myStreamWriter = File.CreateText(fname);
        myStreamWriter.Write(sdata);
        myStreamWriter.Flush();
        myStreamWriter.Close();
    }

    private static byte[] GetImageByteArr(System.Drawing.Image img)
    {
        byte[] ImgByte;
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            ImgByte = stream.ToArray();
            stream.Flush();
            stream.Close();
        }
        return ImgByte;
    }

}

