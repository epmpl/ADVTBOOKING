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
using forCopy;
using iTextSharp.text;

public partial class Default3 : System.Web.UI.Page
{
    string imgname;
    string Temp;
    string col;
    string dateforfold;
    double tolerancelimt;
    double toleranceheight;
    double tolerancewidth;

    string dealertypematter = "";
    string matstatusfileid = "";
    string packagepckcode = "";
    string matrevised = "Revised";
    protected void Page_Load(object sender, EventArgs e)
    {
       // Button1.Attributes.Add("OnClick", "javascript:return imagetget();");
        Ajax.Utility.RegisterTypeForAjax(typeof(Default3));
        //   string str1 = FileUpload1.PostedFile.FileName;
        string inserts = Request.QueryString["ins"].ToString();
        string edition = Request.QueryString["edition"].ToString();
        string cioid = Request.QueryString["ciobookid"].ToString();
        string fileid = Request.QueryString["fileid"].ToString();
        string filename="";

        if (Request.QueryString["dealertypematter"] != null && Request.QueryString["dealertypematter"] != "0")
        {
            dealertypematter = Request.QueryString["dealertypematter"].ToString();
        }
        else
        {
            dealertypematter = "";
        }
        if (Request.QueryString["matstatus"] != null && Request.QueryString["matstatus"] != "0")
        {
            matstatusfileid = Request.QueryString["matstatus"].ToString();
        }
        else
        {
            matstatusfileid = "";
        }
        if (Request.QueryString["packagepckcode"] != null && Request.QueryString["packagepckcode"] != "0")
        {
            packagepckcode = Request.QueryString["packagepckcode"].ToString();
        }
        else
        {
            packagepckcode = "";
        }
        if (!Page.IsPostBack)
        {
            if (packagepckcode != "")
            {
                bindeditiondetails(packagepckcode);
            }
            lbljavascriptfor.Text = "";
        }

        if (Request.QueryString["filename"] != null)
            filename = Request.QueryString["filename"].ToString();
        if (filename == "bookdiv")
            filename = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbook = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbook.getIP(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbook = new NewAdbooking.Classes.BookingMaster();
            ds = clsbook.getIP(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString() };
            string procedureName = "websp_getlocal_ip";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            hiddenIP.Value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        tolerancelimt = Convert.ToDouble(ConfigurationSettings.AppSettings["ATTACHFILESIZETOLERLIMIT"].ToString());
        string val = cioid + "-" + inserts + "-" + edition;// +tot; //   NO INCLUDE FILE EXT
        hiddenfilename.Value = val;
         string path = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + val + ".jpg";
         if (filename == "")
             filename = path;
         filename = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + filename + ".jpg";
         if (System.IO.File.Exists(filename))
         {
            
             //prev.InnerHtml = "<img src='sbview.aspx?path1=" + filename + "' style='width: 200px; height: 200px;' />";
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert(\"Your session has been expired.\");window.close();</script>");
            return;
        }
        if (FileUpload1.PostedFile.FileName == "")
        {
            Response.Write("<script>alert(\"Please select the file.\")</script>");
            return;
        }

        string filename = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("."));
        //if (filename == ".jpg" || filename == ".tiff" || filename == ".eps" || filename == ".pdf" || filename == ".tif")
        if (filename == ".tiff"  || filename == ".pdf" || filename == ".tif")
        {
        }
        else
        {
            Response.Write("<script>alert(\"Upload Tiff and Pdf only.\");</script>");
            return;
        }

        //************************
        string str1 = FileUpload1.PostedFile.FileName;
        string inserts = Request.QueryString["ins"].ToString();
        string edition = Request.QueryString["edition"].ToString();
        string cioid = Request.QueryString["ciobookid"].ToString();
        string fileid = Request.QueryString["fileid"].ToString();
        string datefield = "";
        string datefield1 = "";
        string adtype ="";
        if(Request.QueryString["datefield"]!=null)
         datefield = Request.QueryString["datefield"].ToString();
        if (Request.QueryString["datefield"] != null)
            datefield1 = Request.QueryString["datefield"].ToString();
        if(Request.QueryString["adtype"]!=null)
         adtype = Request.QueryString["adtype"].ToString();
        string str2 = Path.GetFileName(str1);

        int ind = str2.LastIndexOf(".");
        int len = (str2.Length) - ind;

        string tot = str2.Substring(ind, len);
        string val = cioid + "-" + inserts + "-" + edition; // +tot;    NO INCLUDE FILE EXT

        // new chages by sourabh discuss with bhanu sir for material versining 

        DataSet dsf = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), cioid, inserts, edition, "", "", "", "" };
            string procedureName = "websp_updatefilenamebooking";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dsf = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        string ver = "0";
        string matr = "attached";
        if (dsf.Tables[0].Rows.Count > 0)
        {
            if (dsf.Tables[0].Rows[0].ItemArray[0].ToString().IndexOf('_') > 0)
            {
                ver = dsf.Tables[0].Rows[0].ItemArray[0].ToString().Split('_')[1];
                ver = Convert.ToString(Convert.ToInt16(ver) + 1);
                matr = "Revised";
            }
        }
        val = val + "_" + ver;

        /////////////////////       

        double adheight = 0;
        double adwidth = 0;
        if (Request.QueryString["adheight"] != null)
        {
            adheight = Convert.ToDouble(Request.QueryString["adheight"]);
            adwidth = Convert.ToDouble(Request.QueryString["adwidth"]);
            if(Request.QueryString["color"]!=null)
            col = Request.QueryString["color"].ToString();
        }

        ////if height and width are in mm, convert it in cm
        if (ConfigurationManager.AppSettings["adwidth"] == "mm")
        {
            adheight = adheight / 10;
            adwidth = adwidth / 10;
        }

        Bitmap image = null;

        ////if (filename == ".pdf" || filename == ".eps")
        ////{
        string nam = Server.MapPath("temppdf");
        string filnam = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string tot1 = filnam.Substring(0, ind);
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
        FileUpload1.PostedFile.SaveAs(Path.Combine(nam, tot1));  //save in \temppdf
        FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("Orignal"), tot1)); //save in Orignal folder
        /// if need any other file path.

        // for color check validation
        if (ConfigurationSettings.AppSettings["ATTACHFILECOLOUREVALIDREQ"].ToString() == "Y")
        {
            string colourcheckvalid = colourcheck(tot1);
            if (colourcheckvalid.ToString() == "A")
            {
                //image.Dispose();
                System.IO.FileInfo fi = new FileInfo(Server.MapPath("Temppdf/" + tot1)); //Path.GetFileName(FileUpload1.PostedFile.FileName)));
                fi.Delete();

                if (System.IO.File.Exists(Server.MapPath("Orignal") + "\\" + tot1) == true)
                {
                    System.IO.File.Delete(Server.MapPath("Orignal") + "\\" + tot1);
                }
                return;
            }
        }

        // to create the jpg
        createjpgfrompdf(tot1);

        ////}
        byte[] imgByte = null;
        if (filename != ".pdf" && filename != ".eps")
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                image = new Bitmap(Server.MapPath("temppdf/" + tot1));
            }
            else
            {
                image = new Bitmap(Server.MapPath("temppdf/" + tot1));
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                imgByte = GetImageByteArr(new Bitmap(ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + val + ".jpg")); //GetImageByteArr(new Bitmap(Server.MapPath("//eps/" + val + ".jpg")));
            }
            else
            {
                imgByte = GetImageByteArr(new Bitmap(ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + val + ".jpg")); //GetImageByteArr(new Bitmap(Server.MapPath("eps/" + val + ".jpg")));
            }

            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(imgByte, 0, imgByte.Length);
            //image = System.Drawing.Image.FromStream(memoryStream);
            image = new Bitmap(memoryStream);
            memoryStream.Flush();
            memoryStream.Close();
        }
        string fffname = Server.MapPath("temppdf/") + tot1;
        double imgWidth = 0;
        double imgWidthcm = 0;
        double imgHeight = 0;
        double imgHeightcm = 0;
        toleranceheight = 0;
        tolerancewidth = 0;

        if (filename == ".pdf")
        {
            try
            {
                iTextSharp.text.pdf.PdfReader pdfreader = new iTextSharp.text.pdf.PdfReader(fffname);

                iTextSharp.text.Rectangle k = pdfreader.getCropBox(1);
                imgHeightcm = Math.Round(((Convert.ToDouble(k.Height.ToString()) / 72) * 2.54), 1);
                imgWidthcm = Math.Round(((Convert.ToDouble(k.Width.ToString()) / 72) * 2.54), 1);
            }
            catch (Exception ex2)
            {
                imgWidth = image.PhysicalDimension.Width;
                imgWidthcm = Math.Round((imgWidth * 2.54 / 72), 2);

                imgHeight = image.PhysicalDimension.Height;
                imgHeightcm = Math.Round((imgHeight * 2.54 / 72), 2);
            }
        }
        else if (filename == ".eps" /*|| filename == ".pdf"*/)
        {
            imgWidth = image.PhysicalDimension.Width;
            imgWidthcm = Math.Round((imgWidth * 2.54 / 72), 2);
            
            imgHeight = image.PhysicalDimension.Height;
            imgHeightcm = Math.Round((imgHeight * 2.54 / 72), 2);
            
        }
        else
        {
            imgWidth = image.PhysicalDimension.Width;
            imgWidthcm = Math.Round((imgWidth * 2.54 / image.HorizontalResolution), 2);
           
            imgHeight = image.PhysicalDimension.Height;
            imgHeightcm = Math.Round((imgHeight * 2.54 / image.VerticalResolution), 2);
          
        }
        //if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision" && Request.QueryString["edition1"] != null && Request.QueryString["col1"]!=null)
        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision" && Request.QueryString["edition1"] != null && (Request.QueryString["col1"] != null && Request.QueryString["col1"] != "null"))
        {
            DataSet ds = new DataSet();
            clsconnection dconnect = new clsconnection();
            string sqldd = "";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                sqldd = "SELECT dbo.getcm1('" + Request.QueryString["col1"].ToString() + "','" + Request.QueryString["edition1"].ToString() + "','CL0') from dual";

            }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                sqldd = "SELECT dbo.getcm1('" + Request.QueryString["col1"].ToString() + "','" + Request.QueryString["edition1"].ToString() + "','CL0')as size";

            }
             else
            {
                sqldd = "SELECT getcm1('" + Request.QueryString["col1"].ToString() + "','" + Request.QueryString["edition1"].ToString() + "','CL0')as size";

            }
            ds = dconnect.executequery(sqldd);

            adwidth = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }

        clsconnection dconnect12 = new clsconnection();
        string sqldd12 = "";
        string[] arr1 = datefield1.Split('/');
        string dd1 = arr1[0];
        string mm1 = arr1[1];
        string yy1 = arr1[2];
        datefield1 = yy1 + "/" + mm1 + "/" + dd1;
        sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,CENTERUPLOAD,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
        sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','BEFORE1'" + ",'Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
        dconnect12.executequery(sqldd12);
        //sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
        //sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','BEFORE1','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
        //dconnect12.executequery(sqldd12);

        /*mysql */
        if (dealertypematter == "")
        {
            if (ConfigurationSettings.AppSettings["ATTACHFILESIZEVALIDREQ"].ToString() == "Y")
            {
                sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,CENTERUPLOAD,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
                sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','BEFORE2'" + ",'Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
                dconnect12.executequery(sqldd12);

                toleranceheight = ((adheight * tolerancelimt) / 100);
                tolerancewidth = ((adwidth * tolerancelimt) / 100);
                // if ((imgHeightcm > (adheight + .2) || imgHeightcm < (adheight - .2)) || (imgWidthcm > (adwidth + .2) || imgWidthcm < (adwidth - .2)))
                if ((imgHeightcm > (adheight + .3) || imgHeightcm < (adheight - .3)) || (imgWidthcm > (adwidth + .3) || imgWidthcm < (adwidth - .3)))
                //if ((imgHeightcm > (adheight + toleranceheight) || imgHeightcm < (adheight - toleranceheight)) || (imgWidthcm > (adwidth + tolerancewidth) || imgWidthcm < (adwidth - tolerancewidth)))
                {
                    sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,CENTERUPLOAD,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
                    sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','BEFORE3'" + ",'Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
                    dconnect12.executequery(sqldd12);

                    Response.Write("<script>alert(\"Uploaded material size doesn't match with the Adv height and width\");window.close();</script>");

                    sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,CENTERUPLOAD,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
                    sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','BEFORE4'" + ",'Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
                    dconnect12.executequery(sqldd12);

                    image.Dispose();
                    //if (filename != ".pdf" && filename != ".eps")
                    //{
                    System.IO.FileInfo fi = new FileInfo(Server.MapPath("Temppdf/" + tot1)); //Path.GetFileName(FileUpload1.PostedFile.FileName)));
                    fi.Delete();

                    // new added 04042018

                    // delete from code folder

                    if (System.IO.File.Exists(Server.MapPath("Temppdf") + "\\" + tot1.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")) == true)
                    {
                        System.IO.File.Delete(Server.MapPath("Temppdf") + "\\" + tot1.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
                    }


                    if (System.IO.File.Exists(Server.MapPath("Orignal") + "\\" + tot1) == true)
                    {
                        System.IO.File.Delete(Server.MapPath("Orignal") + "\\" + tot1);
                    }

                    if (System.IO.File.Exists(Server.MapPath("jpgpreview") + "\\" + tot1.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")) == true)
                    {
                        System.IO.File.Delete(Server.MapPath("jpgpreview") + "\\" + tot1.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
                    }

                    // delete from finalserver folder

                    if (System.IO.File.Exists(ConfigurationSettings.AppSettings["applicationpath"].ToString() + "Original\\" + tot1) == true)
                    {
                        System.IO.File.Delete(ConfigurationSettings.AppSettings["applicationpath"].ToString() + "Original\\" + tot1);
                    }

                    /* if (System.IO.File.Exists(ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + tot1.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")) == true)
                     {
                         System.IO.File.Delete(ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + tot1.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
                     }*/

                    // end new added


                    //if (File.Exists(Server.MapPath("eps/" + val + ".jpg")) == true)
                    //    File.Delete(Server.MapPath("eps/" + val + ".jpg"));
                    ////System.IO.FileInfo fii = new FileInfo(Server.MapPath("eps/" + val + ".jpg"));
                    ////fii.Delete();   
                    //}

                    return;
                }
            }
        }

        sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,CENTERUPLOAD,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
        sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','BEFORE5'" + ",'Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
        dconnect12.executequery(sqldd12);

        /*clsconnection dconnect12 = new clsconnection();
        string sqldd12 = "";
        string[] arr1 = datefield1.Split('/');
        string dd1 = arr1[0];
        string mm1 = arr1[1];
        string yy1 = arr1[2];
        datefield1 = yy1 + "/" + mm1 + "/" + dd1;
        sqldd12 = "insert into uploadimage_log(ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,FLAG,AD_IMAGEHEIGHT,AD_IMAGEWIDTH,AD_HEIGHT,AD_WIDTH) values ";
        sqldd12 = sqldd12 + "('" + str1 + "','" + tot1 + "','" + datefield + "','BEFORE3','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','Y','" + imgHeightcm + "','" + imgWidthcm + "','" + adheight + "','" + adwidth + "')";
        dconnect12.executequery(sqldd12);*/

        image.Dispose();


        ////if (filename == ".pdf" || filename == ".eps")
        {
            string jpegfilepath = "";
            string jpegsave = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                jpegfilepath = Server.MapPath("Temp");
            }
            else
            {
                jpegfilepath = Server.MapPath("Temp");
            }

            FileUpload1.PostedFile.SaveAs(Path.Combine(jpegfilepath, jpegsave));
            //System.IO.File.Copy(Server.MapPath("temppdf/abc.jpg"),)
        }


        ////string str1 = FileUpload1.PostedFile.FileName;
        ////string inserts = Request.QueryString["ins"].ToString();
        ////string edition = Request.QueryString["edition"].ToString();
        ////string cioid = Request.QueryString["ciobookid"].ToString();
        ////string fileid = Request.QueryString["fileid"].ToString();

        ////string str2 = Path.GetFileName(str1);


        ////int ind = str2.LastIndexOf(".");
        ////int len = (str2.Length)-ind;

        ////string tot = str2.Substring(ind,len );
        ////string val = cioid + "-" + inserts + "-" + edition; // +tot;    NO INCLUDE FILE EXT


        Session["Tempimgname"] = str2;
        Session["Tempinsertname"] = inserts + "-" + edition;

        if (Session["imgname"] != null)
        {
            Session["imgname"] = Session["Tempimgname"].ToString() + "+" + Session["imgname"].ToString();
            Session["insertname"] = Session["Tempinsertname"].ToString() + "/" + Session["insertname"].ToString();
        }
        else
        {
            Session["imgname"] = Session["Tempimgname"].ToString();
            Session["insertname"] = Session["Tempinsertname"].ToString();
        }

        //string str3 = @"c:/inetpub/wwwroot/newadbooking/Temp";  //give the path where you want to upload the file.
        string str3 = Server.MapPath("Temp");

        if (fileid != "bookdiv")
        {
            string fill = "<script>";

            //            fill = fill + "var y=window.opener.document.getElementById('" + fileid + "').getElementsByTagName('table')[0].rows.length;";
            fill = fill + "var y=window.opener.document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length;";
            fill = fill + "var filename;";
            fill = fill + "var matsta;";
            fill = fill + "var h;";
            fill = fill + "var w;";
            fill = fill + "var s;";
            fill = fill + "var i;";
            fill = fill + "var editionname;";
            fill = fill + "var height;";
            fill = fill + "var width;";
            int cou = Convert.ToInt32(fileid.Replace("fil", ""));
            fill = fill + "window.opener.document.getElementById('" + fileid + "').value='" + val + "';";
            fill = fill + "window.opener.document.getElementById('" + matstatusfileid + "').value='" + matr + "';";
            fill = fill + "editionName=opener.document.getElementById('pubcode" + cou + "').value;";
            fill = fill + "height=opener.document.getElementById('hei" + cou + "').value;";
            fill = fill + "width=opener.document.getElementById('wid" + cou + "').value;";
            fill = fill + "if(confirm(\"Do You Want To Copy the Material in all same Publication\")){";
            fill = fill + "for(i=0;i<y-1;i++)";
            fill = fill + "{";
            fill = fill + "filename=\"fil\"+i;";
            fill = fill + "matsta=\"mat\"+i;";
            fill = fill + "h=\"hei\"+i;";
            fill = fill + "w=\"wid\"+i;";
            fill = fill + "s=\"siz\"+i;";


            fill = fill + " if(i!=" + cou + " && editionName==opener.document.getElementById('pubcode'+i).value && height==opener.document.getElementById('hei'+i).value && width==opener.document.getElementById('wid'+i).value){";
            fill = fill + "if(opener.document.getElementById('inssta'+i).value=='booked' || opener.document.getElementById('inssta'+i).value=='hold'){";
            fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";
            fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "';";
            fill = fill + "window.opener.document.getElementById(h).value=opener.document.getElementById('hei" + cou + "').value;";
            fill = fill + "window.opener.document.getElementById(w).value=opener.document.getElementById('wid" + cou + "').value;";
            fill = fill + "window.opener.document.getElementById(s).value=opener.document.getElementById('siz" + cou + "').value;;";
            fill = fill + "}"; // second if
            fill = fill + "}"; // first if
            // 
            fill = fill + " } "; // end for looop for(i=0;i<y-1;i++)";
            fill = fill + " } "; // end here if(confirm(\"Do You Want To Copy the Material in all same Publication\")){";
            fill = fill + "else if(confirm(\"Do You Want To Copy the Material in Selected Editions.\")){";
            fill = fill + "var si = document.getElementById(" + "\"" + "SendGridView" + "\").rows.length - 1;";

            //GridViewRow row = SendGridView.Rows[2];
            //string testttt = SendGridView.Rows.Count;

            fill = fill + " for( var js=2;js<si+2;js++)";
            fill = fill + " { ";

            fill = fill + "if(js<10)";
            fill = fill + " var str1chk=" + "'SendGridView_ctl" + "0'" + "+js +'_CheckBox1' ;";
            fill = fill + " else ";
            fill = fill + " var str1chk=" + "'SendGridView_ctl'" + " + js + '_CheckBox1' ;"; ;
            //fill = fill + " var str1chk='SendGridView_ctl'+js+'_CheckBox1';";

            fill = fill + " if(document.getElementById(str1chk).checked==true) { ";

            fill = fill + " var editionnamegrid = document.getElementById(" + "\"" + "SendGridView" + "\").rows[js-1].cells[1].innerText; ";

            fill = fill + "for(i=0;i<y-1;i++)";
            fill = fill + "{";
            fill = fill + "filename=\"fil\"+i;";
            fill = fill + "matsta=\"mat\"+i;";
            fill = fill + "h=\"hei\"+i;";
            fill = fill + "w=\"wid\"+i;";
            fill = fill + "s=\"siz\"+i;";

            fill = fill + " if(i!=" + cou + " && editionnamegrid==opener.document.getElementById('edit'+i).value && height==opener.document.getElementById('hei'+i).value && width==opener.document.getElementById('wid'+i).value){";
            fill = fill + "if(opener.document.getElementById('inssta'+i).value=='booked' || opener.document.getElementById('inssta'+i).value=='hold'){";

            fill = fill + "  if(" + inserts + " ==  opener.document.getElementById('ins'+ i).innerHTML) {;";
            fill = fill + " var chkmaterialstuss = Default3.checkmaterialstatus('" + cioid + "',editionnamegrid);";
            fill = fill + " var chkmaterialstusst = chkmaterialstuss.value; var swapedexistdatat;";
            fill = fill + " window.opener.document.getElementById(filename).value='" + val + "';";
            fill = fill + " window.opener.document.getElementById(matsta).value = chkmaterialstusst; ";

            /*  fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";
                fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "';";
                fill = fill + "if(opener.document.getElementById(matsta).value=='attached'){";
                fill = fill + "window.opener.document.getElementById(matsta).value='" + matrevised + "'; } ";
                fill = fill + "  else {   ";
                fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "'; } ";*/


            fill = fill + "window.opener.document.getElementById(h).value=opener.document.getElementById('hei" + cou + "').value;";
            fill = fill + "window.opener.document.getElementById(w).value=opener.document.getElementById('wid" + cou + "').value;";
            fill = fill + "window.opener.document.getElementById(s).value=opener.document.getElementById('siz" + cou + "').value;;";
            fill = fill + "}"; // if for insertion inserts

            fill = fill + "}"; // if first
            fill = fill + "}"; // if second
            fill = fill + "}";   // for y
            fill = fill + "}";  // if end str1chk
            fill = fill + "}";  // for loop
            // 
            fill = fill + "}";  // confirm if end
            //
            fill = fill + "else if(i==" + cou + ")";
            fill = fill + "{";
            fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";
            fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "';";
            fill = fill + "}"; // else if

            fill = fill + "</script>";
            lbljavascriptfor.Text = fill;
            //Response.Write(fill);



            // string no = Request.QueryString["no"].ToString();
            // Response.Write("<script>window.opener.document.getElementById('" + fileid + "').value='" + val + "'</script>");
            /*string fill = "<script>";
            //            fill = fill + "var y=window.opener.document.getElementById('" + fileid + "').getElementsByTagName('table')[0].rows.length;";
            fill = fill + "var y=window.opener.document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length;";
            fill = fill + "var filename;";
            fill = fill + "var matsta;";
            fill = fill + "var h;";
            fill = fill + "var w;";
            fill = fill + "var s;";
            fill = fill + "var i;";
            fill = fill + "var editionname;";
            fill = fill + "var height;";
            fill = fill + "var width;";
            int cou = Convert.ToInt32(fileid.Replace("fil", ""));
            fill = fill + "window.opener.document.getElementById('" + fileid + "').value='" + val + "';";
            fill = fill + "window.opener.document.getElementById('" + matstatusfileid + "').value='" + matr + "';";
            fill = fill + "editionName=opener.document.getElementById('pubcode" + cou + "').value;";
            fill = fill + "height=opener.document.getElementById('hei" + cou + "').value;";
            fill = fill + "width=opener.document.getElementById('wid" + cou + "').value;";
            fill = fill + "if(confirm(\"Do You Want To Copy the Material in all same Publication\")){";
            fill = fill + "for(i=0;i<y-1;i++)";
            fill = fill + "{";
            fill = fill + "filename=\"fil\"+i;";
            fill = fill + "matsta=\"mat\"+i;";
            fill = fill + "h=\"hei\"+i;";
            fill = fill + "w=\"wid\"+i;";
            fill = fill + "s=\"siz\"+i;";

            fill = fill + " if(i!=" + cou + " && editionName==opener.document.getElementById('pubcode'+i).value && height==opener.document.getElementById('hei'+i).value && width==opener.document.getElementById('wid'+i).value){";
            fill = fill + "if(opener.document.getElementById('inssta'+i).value=='booked' || opener.document.getElementById('inssta'+i).value=='hold'){";
            fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";
            fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "';";
            fill = fill + "window.opener.document.getElementById(h).value=opener.document.getElementById('hei" + cou + "').value;";
            fill = fill + "window.opener.document.getElementById(w).value=opener.document.getElementById('wid" + cou + "').value;";
            fill = fill + "window.opener.document.getElementById(s).value=opener.document.getElementById('siz" + cou + "').value;;";
            fill = fill + "}";
            fill = fill + "}";
            fill = fill + "else if(i==" + cou + ")";
            fill = fill + "{";
            fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";
            fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "';";
            fill = fill + "}";
            fill = fill + "}";
            fill = fill + "}";
            fill = fill + "</script>";
            Response.Write(fill);*/
        }
        else
        {
            string fill = "<script>";
            fill = fill + "var y=window.opener.document.getElementById('" + fileid + "').getElementsByTagName('table')[0].rows.length;";
            fill = fill + "var filename;";
            fill = fill + "var matsta;";
            fill = fill + "var h;";
            fill = fill + "var w;";
            fill = fill + "var s;";
            fill = fill + "var i;";
            fill = fill + "for(i=0;i<y-1;i++)";
            fill = fill + "{";
            fill = fill + "filename=\"fil\"+i;";
            fill = fill + "matsta=\"mat\"+i;";
            fill = fill + "h=\"hei\"+i;";
            fill = fill + "w=\"wid\"+i;";
            fill = fill + "s=\"siz\"+i;";
            fill = fill + "window.opener.document.getElementById(filename).value='" + val + "';";
            fill = fill + "window.opener.document.getElementById(matsta).value='" + matr + "';";
            fill = fill + "window.opener.document.getElementById(h).value=window.opener.document.getElementById('txtadsize1').value;";
            fill = fill + "window.opener.document.getElementById(w).value=window.opener.document.getElementById('txtadsize2').value;";
            fill = fill + "window.opener.document.getElementById(s).value=window.opener.document.getElementById('txttotalarea').value;";
            fill = fill + "}";
            fill = fill + "</script>";
            Response.Write(fill);

        }

        float height;
        float width;
        float finalheight;
        float finalwidth;
        double imgRatio;
        //if (filename == ".pdf" || filename == ".eps")
        {
            string path = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + val + ".jpg";//Server.MapPath("eps/") + val + ".jpg";

            Bitmap b1 = new Bitmap(path);
            height = b1.Height;
            width = b1.Width;
            if (height > width)
                imgRatio = width / height;
            else
                imgRatio = height / width;

            if (height < width)
            {
                finalwidth = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                finalheight = Convert.ToInt32(150 * imgRatio);
            }
            else
            {
                finalheight = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                finalwidth = Convert.ToInt32(150 * imgRatio);
            }
            //check color of image *********************************************
            bool bw;
            if (b1.PixelFormat.ToString() == "Format8bppIndexed")
                bw = true;
            else
                bw = false;
            
            if (col == "B" && bw == false)
            {
                Response.Write("<script>alert(\"Image color not matched\")</script>");
            }
            else if (col != "B" && bw == true)
            {
                Response.Write("<script>alert(\"Image color not matched\")</script>");
            }
            //**************************************************************************
            b1.Dispose();
            path = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\" + val + ".jpg";  //"eps/" + val + ".jpg";
            //prev.InnerHtml = "<img src='" + path + "'  width='" + finalwidth + "' height='" + finalheight + "'>";
            prev.InnerHtml = "<img src='sbview.aspx?path1=" + path + "' width=" + Convert.ToString(finalwidth) + " height=" + Convert.ToString(finalheight) + "/>";
        }
        /* else
         {
             string jpegsave = Path.GetFileName(FileUpload1.PostedFile.FileName);
             string jpegfilepath = "";
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
             {
                 jpegfilepath = Server.MapPath("//Temp/");
             }
             else
             {
                 jpegfilepath = Server.MapPath("Temp/");
             }
             string path = jpegfilepath + jpegsave;
             Bitmap b1 = new Bitmap(path);
             height = b1.Height;
             width = b1.Width;
             if (height > width)
                 imgRatio = width / height;
             else
                 imgRatio = height / width;

             if (height < width)
             {
                 finalwidth = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                 finalheight = Convert.ToInt32(150 * imgRatio);
             }
             else
             {
                 finalheight = 150;// System.Web.UI.WebControls.Unit(imgHeightcm / 72);
                 finalwidth = Convert.ToInt32(150 * imgRatio);
             }
             prev.InnerHtml = "<img src='" + path + "'  width='" + finalwidth + "' height='" + finalheight + "'>";

         }*/
        clsconnection dconnect1 = new clsconnection();
        string sqldd1 = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && datefield!="")
        {
            /// same for maridb
            string[] arr = datefield.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            datefield = mm + "/" + dd + "/" + yy;
            sqldd1 = "insert into allthumbimage_log (ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,FLAG) values ";
            sqldd1 = sqldd1 + "('" + str1 + "','" + tot1 + "','" + Convert.ToDateTime(datefield).ToString("dd-MMMM-yyyy") + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate,'" + adtype + "','Y')";
            dconnect1.executequery(sqldd1);
            //sqldd = "select \"userid\",\"username\" from login ";
            //if (Session[0].ToString() != "0")
            //    sqldd = sqldd + " where \"Agency_code\"='" + Session[0].ToString() + "'";
        }
        else
        {
            string[] arr = datefield.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            datefield = yy + "/" + mm + "/" + dd;
            sqldd1 = "insert into allthumbimage_log (ORIGINALNAME,SAPNAME,INSDATE,PRIPUB,BKFOR,EDITION,SECPUB,USERNAME,UPD_DATETIME,ad_type,FLAG) values ";
            sqldd1 = sqldd1 + "('" + str1 + "','" + tot1 + "','" +  datefield  + "','','" + Session["center"].ToString() + "','','','" + Session["username"].ToString() + "',sysdate(),'" + adtype + "','Y')";
            dconnect1.executequery(sqldd1);

        }

      

    }


    public string colourcheck(string filname)
    {
        ProcessStartInfo ProcessInfo;
        ProcessStartInfo ProcessInfo1;
        int ExitCode;
        int ExitCode1;
        Process Process;
        Process Process1;
        Bitmap b1;
        Bitmap b2;
        string p2 = "";
        string p1 = "";
        string p3 = "";
        string p4 = "";
        string p5 = "";
        string p10 = "";
        string p11 = "";

        string datefield = "";
        string datefield1 = "";

        if (Request.QueryString["datefield"] != null)
            datefield1 = Request.QueryString["datefield"].ToString();

        string[] arr11 = datefield1.Split('/');
        string dd11 = arr11[0];
        string mm11 = arr11[1];
        string yy11 = arr11[2];
        datefield1 = dd11 + mm11 + yy11;

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            //date wise folder for layoux
            p2 = Server.MapPath("") + "\\";
            p1 = Server.MapPath("Temppdf/");
            p3 = Server.MapPath("jpgpreview/");

            p4 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\"; //Server.MapPath("eps/");
            p5 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "Original\\";
            if (!Directory.Exists(p4))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(p4);
            }
            if (!Directory.Exists(p5))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(p5);
            }
        }
        else
        {
            p2 = Server.MapPath("") + "\\";
            p1 = Server.MapPath("Temppdf/");
            p3 = Server.MapPath("jpgpreview/");
            p4 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\"; //Server.MapPath("eps/");
            p5 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "Original\\";
        }

        string finalnam = filname;
        if (System.IO.File.Exists(p2 + "abcd.bat"))
            System.IO.File.Delete(p2 + "abcd.bat");


        // for colour checking

        p10 = Server.MapPath("fileinfo/");
        p11 = Server.MapPath("bach/");

        if (!Directory.Exists(p10 + datefield1))
        {
            Directory.CreateDirectory(p10 + datefield1);
        }


        string finalnamNEWJPG = p3 + finalnam.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg");
        string FILENAMECREATETXT = finalnam.Replace(".pdf", ".txt").Replace(".tiff", ".txt").Replace(".tif", ".txt").Replace(".eps", ".txt");
        if (ConfigurationSettings.AppSettings["ATTACHFILECOLOUREVALIDREQ"].ToString() == "Y")
        {
            writefile(p10 + "abcd.bat", p11 + "identify -verbose " + "\"" + p1 + finalnam + "\"" + " > " + "\"" + p10 + datefield1 + "\\" + FILENAMECREATETXT + "\"");
            try
            {
                ProcessInfo1 = new ProcessStartInfo(p10 + "abcd.bat");
                ProcessInfo1.CreateNoWindow = true;
                ProcessInfo1.UseShellExecute = true;

                Process1 = Process.Start(ProcessInfo1);
                Process1.WaitForExit(700000);
                ExitCode1 = Process1.ExitCode;
                Process1.Close();
            }
            catch (Exception ex1_1)
            {

            }

        }
        int linelengtg;

        string mode = "";
        if (System.IO.File.Exists(p10 + datefield1 + "\\" + FILENAMECREATETXT))
        {
            string inputString;
            string testlinest = "";
            string path = p10 + datefield1 + "\\" + FILENAMECREATETXT;
            string readlinechar = "";
            string readlinecharall = "";
            int a, b;

            using (StreamReader streamReader = File.OpenText(path))
            {
                inputString = streamReader.ReadLine();
                if (inputString != null)
                {
                    string line, noOfLines;
                    int lineNumber = 0;
                    StreamReader streamReader1 = new StreamReader(path);
                    /*count for the number of lines*/
                    while ((line = streamReader1.ReadLine()) != null)
                        if (line.Contains("Colorspace:"))
                        {
                            a = line.IndexOf("  Colorspace: ");
                            a = a + "  Colorspace: ".Length;
                            b = line.IndexOf("\r", a);
                            linelengtg = line.ToString().Length;
                            mode = line.Substring(a, (linelengtg - a));
                        }
                    lineNumber++;
                }
            }
        }

        //string ghostscriptpath = "C:\\Program Files\\gs\\gs9.15\\bin";
        string ghostscriptpath = "C:\\Program Files (x86)\\gs\\gs9.15\\bin";

        bool bw;
        bool bwcl;
        bool cw = false;
        if ((mode == "GRAY") || (mode == "Gray") || (mode == "CMYK"))
        {
            if (mode == "CMYK")
            {
                cw = true;
                if (finalnam.ToLower().IndexOf(".pdf") > 0)
                {
                    FILENAMECREATETXT = "1" + FILENAMECREATETXT;
                    bw = false;
                    writefile(p10 + "abcd.bat", "\"" + ghostscriptpath + "\\gswin32c\" -q -o - -sDEVICE=inkcov " + "\"" + p1 + finalnam + "\"" + " > " + "\"" + p10 + datefield1 + "\\" + FILENAMECREATETXT + "\"");
                    try
                    {
                        ProcessInfo1 = new ProcessStartInfo(p10 + "abcd.bat");
                        ProcessInfo1.CreateNoWindow = true;
                        ProcessInfo1.UseShellExecute = true;

                        Process1 = Process.Start(ProcessInfo1);
                        Process1.WaitForExit(700000);
                        ExitCode1 = Process1.ExitCode;
                        Process1.Close();
                    }
                    catch (Exception ex1_1)
                    {

                    }
                    bw = false;
                    if (System.IO.File.Exists(p10 + datefield1 + "\\" + FILENAMECREATETXT))
                    {
                        try
                        {
                            String pp = System.IO.File.ReadAllText(p10 + datefield1 + "\\" + FILENAMECREATETXT);
                            String[] ps1 = pp.Split(' ');
                            int ppl = 0;
                            int ppl1 = 0;
                            for (ppl = 0; ppl < ps1.Length; ppl++)
                            {
                                try
                                {
                                    Double k = Convert.ToDouble(ps1[ppl]);
                                    if (k == 0)
                                        ppl1 = ppl1 + 1;
                                    else
                                        break;
                                }
                                catch (Exception ee)
                                {
                                }
                            }
                            if (ppl1 == 3)
                            {
                                bw = true;
                                cw = false;
                            }
                            else
                            {
                                bw = false;
                            }
                        }
                        catch (Exception e2)
                        {
                        }
                    }
                    else
                        bw = false;
                }
                else
                    bw = false;
            }
            else
            {
                bw = true;
            }
        }
        else if ((mode == "RGB"))
        {
            if (finalnam.ToLower().IndexOf(".pdf") > 0)
            {
                FILENAMECREATETXT = "1" + FILENAMECREATETXT;
                bw = false;
                writefile(p10 + "abcd.bat", "\"" + ghostscriptpath + "\\gswin32c\" -q -o - -sDEVICE=inkcov " + "\"" + p1 + finalnam + "\"" + " > " + "\"" + p10 + datefield1 + "\\" + FILENAMECREATETXT + "\"");
                try
                {
                    ProcessInfo1 = new ProcessStartInfo(p10 + "abcd.bat");
                    ProcessInfo1.CreateNoWindow = true;
                    ProcessInfo1.UseShellExecute = true;

                    Process1 = Process.Start(ProcessInfo1);
                    Process1.WaitForExit(700000);
                    ExitCode1 = Process1.ExitCode;
                    Process1.Close();
                }
                catch (Exception ex1_1)
                {

                }
                bw = false;
                if (System.IO.File.Exists(p10 + datefield1 + "\\" + FILENAMECREATETXT))
                {
                    try
                    {
                        String pp = System.IO.File.ReadAllText(p10 + datefield1 + "\\" + FILENAMECREATETXT);
                        String[] ps1 = pp.Split(' ');
                        int ppl = 0;
                        int ppl1 = 0;
                        for (ppl = 0; ppl < ps1.Length; ppl++)
                        {
                            try
                            {
                                Double k = Convert.ToDouble(ps1[ppl]);
                                if (k == 0)
                                    ppl1 = ppl1 + 1;
                                else
                                    break;
                            }
                            catch (Exception ee)
                            {
                            }
                        }
                        if (ppl1 == 3)
                        {
                            bw = true;
                        }
                        else
                        {
                            bw = false;
                        }
                    }
                    catch (Exception e2)
                    {
                    }
                }
                else
                    bw = false;
            }
            else
                bw = false;
        }
        else
        {
            bw = false;
        }

        if (col == "BA0" && bw != true)
        {
            //Response.Write("<script>alert(\"Uploaded material Colour doesn't match with the Adv Colour\");window.close();</script>");
            Response.Write("<script>alert(\"Unable to upload file due to wrong Colour Format. Compare to Booking \");window.close();</script>");
            return "A";
        }
        else if (col == "CO0" && cw != true)
        {
            //Response.Write("<script>alert(\"Uploaded material Colour doesn't match with the Adv Colour\");window.close();</script>");
            Response.Write("<script>alert(\"Unable to upload file due to wrong Colour Format. Compare to Booking \");window.close();</script>");
            return "A";
        }
        else
        {
            return "";
        }
        //return;
        //   end colour check
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
        string p3 = "";
        string p4 = "";
        string p5 = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            //date wise folder for layoux
            p2 = Server.MapPath("") + "\\";
            p1 = Server.MapPath("Temppdf/");
            p3 = Server.MapPath("jpgpreview/");
           
            p4 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\"; //Server.MapPath("eps/");
            p5 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "Original\\";
            if (!Directory.Exists(p4))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(p4);
            }
            if (!Directory.Exists(p5))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(p5);
            }
        }
        else
        {
            p2 = Server.MapPath("") + "\\";
            p1 = Server.MapPath("Temppdf/");
            p3 = Server.MapPath("jpgpreview/");
            p4 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "jpgpreview\\"; //Server.MapPath("eps/");
            p5 = ConfigurationSettings.AppSettings["applicationpath"].ToString() + "Original\\";
        }

        string finalnam = filname;
        if (System.IO.File.Exists(p2 + "abc.bat"))
            System.IO.File.Delete(p2 + "abc.bat");
       // if(System.IO.File.Exists(p1 + finalnam.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")))
        //    System.IO.File.Delete(p1 + finalnam.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        if (finalnam.Replace(".jpeg", ".jpg").IndexOf(".jpg") < 0)
        {
            writefile(p2 + "abc.bat", "\"" + p2 + "convert.exe" + "\" "  + "\"" + p1 + finalnam + "\" \"" + p1 + finalnam.Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg") + "\"");
            ProcessInfo = new ProcessStartInfo(p2 + "abc.bat");
            //ProcessInfo.w
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit(700000);
            ExitCode = Process.ExitCode;

            Process.Close();
        }
        try
        {
            if (System.IO.File.Exists(p3 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")))
                System.IO.File.Delete(p3 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
            if (System.IO.File.Exists(p4 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")))
                System.IO.File.Delete(p4 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        }
        catch (Exception ex1)
        {
        }
        //System.Drawing.Image image = System.Drawing.Image.FromStream(p1 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        if (System.IO.File.Exists(p1 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")))
        {
            string con = p1 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg");
            b1 = new Bitmap(con);
            System.Drawing.Image bmp2 = b1.GetThumbnailImage(Convert.ToInt32(b1.Width), Convert.ToInt32(b1.Height), null, IntPtr.Zero);
            
            bmp2.Save(p3 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp2.Save(p4 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
           if (System.IO.File.Exists(p5 + finalnam) == true)
           {
               System.IO.File.Delete(p5 + finalnam);
           }
            //bmp2.Save(p5 + finalnam, System.Drawing.Imaging.ImageFormat.Tiff);
            
            bmp2.Dispose();
            b1.Dispose();
           
            GC.Collect();

            forCopy.file objcopy = new file();
            if (System.IO.File.Exists(p4 + finalnam.ToLower().Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg")) == true)
                objcopy.delete(p4 + finalnam.ToLower().Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
            objcopy.copy(p3 + finalnam.ToLower().Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"), p4 + finalnam.ToLower().Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
           /* if (System.IO.File.Exists(p5 + finalnam) == true)
                objcopy.delete(p5 + finalnam);*/
            if (System.IO.File.Exists(p5 + finalnam))
            {
            }
            else
            {
                objcopy.copy(Server.MapPath("Orignal/") + finalnam, p5 + finalnam);
            }
            
            if (con.Replace(".jpeg", ".jpg").IndexOf(".jpg") < 0)
            {
                if (File.Exists(con) == true)
                    File.Delete(con);
            }
        }
        else
        {
            Response.Write("<script>alert('Ad File is copied. Preview file is not created.');</script>"); 
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
        }
        return ImgByte;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getPrintingIP()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbook = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbook.getIP(Session["compcode"].ToString(), "");
        }
        else
        {
            NewAdbooking.Classes.BookingMaster clsbook = new NewAdbooking.Classes.BookingMaster();
            ds = clsbook.getIP(Session["compcode"].ToString(), "");
        }
        return ds;
    }

    // new added by ss



    public void bindeditiondetails(string packagepckcode)
    {
        DataSet ds = new DataSet();

        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), packagepckcode, "", "" };
        string procedureName = "editionname_formatterfrom_pck_sou";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster Show_NoAd = new NewAdbooking.classmysql.BookingMaster();
            ds = Show_NoAd.editionfordatagrid(Session["compcode"].ToString(), packagepckcode, "", "");
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            SendGridView.DataSource = ds;
            SendGridView.DataBind();
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string checkmaterialstatus(string cioidd, string editiont)
    {
        //string inserts = Request.QueryString["ins"].ToString();
        //string edition = Request.QueryString["edition"].ToString();
        //string cioid = Request.QueryString["ciobookid"].ToString();
        string insertst = "";
        DataSet dsf = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), cioidd, insertst, editiont, "", "", "", "" };
            string procedureName = "websp_updatefilenamebooking";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dsf = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        string ver = "0";
        string matr = "attached";
        if (dsf.Tables[0].Rows.Count > 0)
        {
            if (dsf.Tables[0].Rows[0].ItemArray[0].ToString().IndexOf('_') > 0)
            {
                ver = dsf.Tables[0].Rows[0].ItemArray[0].ToString().Split('_')[1];
                ver = Convert.ToString(Convert.ToInt16(ver) + 1);
                matr = "Revised";
            }
        }
        // val = val + "_" + ver;
        return matr;
    }




}
