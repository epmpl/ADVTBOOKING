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
using System.Drawing;
using System.IO;
public partial class matterprevdict : System.Web.UI.Page
{

    void justifychar1(Graphics gfx, string s1, int width1, Font f1, StringFormat f, float start1, float nextline)
    {
        string s2;
        SizeF k, k1;
        float d, d1;
        float start = start1;
        int n;
        bool fontbold = false;
        s1 = s1.Trim();
        k = gfx.MeasureString(s1.Replace("à","").Replace("Ý",""), f1);

            
            d = width1 - k.Width;
            //d1 = d / s1.Replace("à","").Replace("Ý","").Length;
            for (n = 0; n < s1.Length; n++)
            {
                //k1 = gfx.MeasureString(s1.Substring(n, 1), f1);
                //this is for font selection 
                if (s1.Substring(n, 1) == "à" || s1.Substring(n, 1) == "Õ")
                {
                    if (s1.Substring(n, 1) == "à")
                        f1 = new Font("Arial", 5, FontStyle.Bold, GraphicsUnit.Pixel);
                    if (s1.Substring(n, 1) == "Õ")
                        f1 = new Font("Arial", 5, FontStyle.Regular, GraphicsUnit.Pixel);
                }
                else
                {
                    gfx.DrawString(s1.Substring(n, 1).Replace("à", "").Replace("Ý", ""), f1, new SolidBrush(Color.Black), start, nextline, f);

                    start = start + (k.Width / s1.Length);
                }
               

            }
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string flag = "0";
        DataSet ds_data = new DataSet();
        DataTable dt_data = new DataTable();
        DataRow dr_data = dt_data.NewRow();
        DataColumn dc_data;
        int tableCount = 0;
        string logoHeight = "";
        string logoWidth = "";
        string logoName = "";
        logoName=Request.QueryString["logo_name"].ToString();
        logoHeight = Request.QueryString["logohei"].ToString();
        logoWidth = Request.QueryString["logowid"].ToString();
       string matter = Session["matter_session"].ToString().Trim();
       matter = matter.Replace("</P>", "");
       matter = matter.Replace("<P>", "");
       matter = matter.Replace("\n", "");
       matter = matter.Replace("<STRONG>", "à");
       matter = matter.Replace("</STRONG>", "Õ");
       double colwidth = 0;
       float nextline = 3;
       
       StringFormat format1 = (StringFormat)StringFormat.GenericTypographic.Clone();
       
       if (Request.QueryString["hiddenwidth"].ToString() != "")
           colwidth = Convert.ToDouble(Request.QueryString["hiddenwidth"]);//3.8;
       colwidth = 4.5;
       if (ConfigurationSettings.AppSettings["adwidth"].ToString() == "mm")
       {
           colwidth = colwidth / 10;//to convert  mm to cm
       }
       else
       {
           colwidth = colwidth;
       }
       double bitmapwidth = (72 / 2.54) * colwidth;//72 is bitmal verticalresolution and 2.54 is the cm. in 1 inch.
       Bitmap g1 = new Bitmap(Convert.ToInt32(bitmapwidth) + 10, 2000);
       Graphics gfx = Graphics.FromImage(g1);
       gfx.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, g1.Width, g1.Height));
       if (logoName != "" && logoHeight!="nologo")
       {
          
           double logoWidth1=(72 / 2.54) * Convert.ToDouble(logoWidth);
           double logoHeight1 = (72 / 2.54) *  Convert.ToDouble(logoHeight);
           double colwidth1 = (72 / 2.54) * colwidth;
           int d1 = (Convert.ToInt32(colwidth1) - Convert.ToInt32(logoWidth1)) / 2;
           Bitmap b22 = new Bitmap(Server.MapPath("~/temppdf/") + logoName + ".jpg");
            logoWidth1 = b22.Width;
            logoHeight1 = b22.Height;
           for (int y = 0; y < Convert.ToInt32(logoWidth1); y++)
           {
               for (int u = 0; u < Convert.ToInt32(logoHeight1); u++)
               {
                   g1.SetPixel(y+d1, u, b22.GetPixel(y, u));
               }

           }
           b22.Dispose();
           nextline = Convert.ToInt32(logoHeight1) + 3;
       }
      
       
      
       Font f = new Font("Arial", 5, FontStyle.Regular, GraphicsUnit.Pixel);
       bool fontbold = false;
       string b = matter;
       string linestr = "";
       string linestrfinal = "";
       int linecount = 0;
       SizeF k;
       for (int i = 0; i < b.Length; i++)
       {
           if (b.Substring(i, 1) == "à")
                    f = new Font("Arial", 5, FontStyle.Bold, GraphicsUnit.Pixel);
           if (b.Substring(i, 1) == "Õ")
                    f = new Font("Arial", 5, FontStyle.Regular, GraphicsUnit.Pixel);
             
           k = gfx.MeasureString((linestr + b.Substring(i, 1)).Replace("à", "").Replace("Õ", "").Replace("Ý", ""), f);
           if (k.Width > bitmapwidth || b.Substring(i, 1)=="\r")
           {
               linecount = linecount + 1;
               if (linestr.IndexOf(" ") > 0 && k.Width > bitmapwidth)
               {
                   if (b.Substring(i, 1) != " " || b.Substring(i + 1, 1) != " ")
                   {
                       string ud = linestr.Substring(0, linestr.LastIndexOf(" "));

                       i = i - (linestr.Length - ud.Length) + 1;
                       linestr = ud;
                     
                   }
               }
               if (linestr.IndexOf("Ý") > 0)
               {
                    k = gfx.MeasureString(linestr.Replace("à", "").Replace("Õ", "").Replace("Ý", ""), f);
                   string g=" .";
                   while(k.Width < bitmapwidth)
                   {
                        k = gfx.MeasureString(linestr.Replace("à", "").Replace("Õ", "").Replace("Ý", g), f);
                       g=g + ".";
                   }
                   linestr=linestr.Replace("Ý", g);
               }
               if (linestrfinal == "")
                   linestrfinal = linestr;
               else
                   linestrfinal = linestrfinal + "\r\n" + linestr;

               //if (b.Substring(i+1, 1)==" " 
              
               justifychar1(gfx, linestr, Convert.ToInt32(bitmapwidth), f, format1, 5, nextline);
               linestr = "";
               //gfx.DrawString(justifychar(gfx, linestr, 130, f), f, new SolidBrush(Color.Black), 5, nextline, format1);
               nextline = nextline + k.Height + 3;
               linestr = b.Substring(i, 1);
           }
           else
           {
               linestr = linestr + b.Substring(i, 1);
              
           }

       }
       if (linestr != "")
       {
           linecount = linecount + 1;
           
           if (linestr.IndexOf("Ý") > 0)
           {
               k = gfx.MeasureString(linestr.Replace("à", "").Replace("Õ", "").Replace("Ý", ""), f);
               string g = " .";
               while (k.Width < bitmapwidth)
               {
                   k = gfx.MeasureString(linestr.Replace("à", "").Replace("Õ", "").Replace("Ý", g), f);
                   g = g + ".";
               }
               linestr = linestr.Replace("Ý", g);
           }
           
           justifychar1(gfx, linestr, Convert.ToInt32(bitmapwidth), f, format1, 5, nextline);
           if (linestrfinal == "")
               linestrfinal = linestr;
           else
               linestrfinal = linestrfinal + "\r\n" + linestr;
       }
       string fileName;
       string insertid = Request.QueryString["hiddeninsert"].ToString();
       string cioid = Request.QueryString["cioid"].ToString();
       string srno = Request.QueryString["srno"].ToString();
       if (insertid == "no")
       {
           // fileName = cioid + "-All";
           //fileName = copy_cioid + "-All";
           fileName = cioid + "-All";
       }
       else
       {
           //fileName = cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
           //fileName = copy_cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
           fileName = cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
       }
       Rectangle rect = new Rectangle();
       rect.X = 0;
       rect.Y = 0;
       rect.Width = g1.Width;
       rect.Height = Convert.ToInt32(nextline + 20);
       Bitmap g2 = g1.Clone(rect, g1.PixelFormat);
       g2.Save(Server.MapPath("xtg") + "\\" + fileName+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
       g1.Dispose();
       g2.Dispose();
       string xyz = "<div style=\"position:absolute;zoom:150%\">" + " <img src=\"s.aspx?p=" + Server.MapPath("xtg") + "\\" + fileName + ".jpg" + "\"/>" + "</div>";
       td1.InnerHtml = xyz;
        // for indesign file
       string fileData_indesign = "";
       fileData_indesign = "<ASCII-WIN>" + "\r\n";
       fileData_indesign = fileData_indesign + "<Version:5><FeatureSet:InDesign-Roman><ColorTable:=<Black:COLOR:CMYK:Process:0,0,0,1><C\\=0 M\\=0 Y\\=100 K\\=0:COLOR:CMYK:Process:0,0,1,0>>" + "\r\n";
       fileData_indesign = fileData_indesign + "<DefineParaStyle:Normal=<Nextstyle:Normal><pHyphenationLadderLimit:0><pHyphenationZone:0.000000><cFont:Arial><pDesiredWordSpace:1.100000><pMaxWordSpace:2.500000><pMinWordSpace:0.850000><pMaxLetterspace:0.040000><pKeepFirstNLines:1><pKeepLastNLines:1><pRuleAboveColor:Black><pRuleAboveTint:100.000000><pRuleBelowColor:Red><pRuleBelowTint:100.000000><bnColor:None><numFont:\\<TextFont\\>>>" + "\r\n";
        // for logo
       if (logoName != "" && logoHeight != "nologo")
       {
           fileData_indesign = fileData_indesign + "<ParaStyle:Normal><pRuleAboveColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleAboveStroke:0.000000><pRuleBelowColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleBelowStroke:0.000000><pRuleBelowTint:100.000000><pRuleBelowOffset:0><pRuleAboveOn:0><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pSingleWordAlignment:Left><pTextAlignment:JustifyLeft>";
       }
       else
       {
           fileData_indesign = fileData_indesign + "<ParaStyle:Normal><pRuleAboveColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleAboveStroke:0.000000><pRuleBelowColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleBelowStroke:0.000000><pRuleBelowTint:100.000000><pRuleBelowOffset:0><pSingleWordAlignment:Left><pTextAlignment:JustifyLeft>";
       }
       //<pRuleAboveOn:1><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1>
       
       //if (linestrfinal.IndexOf("à") == 0)
       //{
       //    fileData_indesign = fileData_indesign + "<cTypeface:Bold>";
       //    linestrfinal = linestrfinal.Substring(1, linestrfinal.Length - 2);
       //}
       //else
       //{
       //    fileData_indesign = fileData_indesign + "<cTypeface:Normal>";
       //}
       linestrfinal = linestrfinal.Replace("à", "<cTypeface:Bold>");
       linestrfinal = linestrfinal.Replace("Õ", "<cTypeface:>");
       linestrfinal=linestrfinal.Replace("\r","");
       linestrfinal = linestrfinal.Replace("\n", "\r\n");
       linestrfinal = linestrfinal.Replace("Ý", "");
       fileData_indesign = fileData_indesign + "<cSize:5><cLeading:5><cFont:Arial>" + linestrfinal;
       fileData_indesign = fileData_indesign + "\r\n<cSize:><cLeading:><cFont:><pRuleAboveColor:><pRuleAboveStroke:><pRuleBelowColor:><pRuleBelowStroke:><pRuleBelowTint:><pTextAlignment:>";
       FileStream fs = null;

       //fs = new FileStream(Server.MapPath("xtg") + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
     

       fileName = fileName + ".txt";
       fs = new FileStream(Server.MapPath("xtg") + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
       StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
       sw.Write(fileData_indesign);// for indesign XTG
       sw.Flush();
       sw.Dispose();
       fs.Dispose();
        // for saving in session
       Session["fileName"] = fileName;
        
       ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevdict), "FN", "window.opener.document.getElementById('hiddenFileName').value='" + fileName.ToString() + "';", true);
       ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevdict), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + linecount.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + linecount.ToString() + ";", true);
       ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevdict), "zz1", "parentid('" + Request.QueryString["hiddeninsert"].ToString() + "');", true);
       if (Session["savedata"] != null)
       {
           ds_data = (DataSet)Session["savedata"];
           for (tableCount = 0; tableCount < ds_data.Tables.Count; tableCount++)
           {
               if (fileName == ds_data.Tables[tableCount].Rows[0].ItemArray[1].ToString())
               {
                   ds_data.Tables[tableCount].Rows[0].Delete();
                   dr_data = ds_data.Tables[tableCount].NewRow();
                   flag = "1";
                   break;
               }

           }
       }

       dc_data = new DataColumn();
       dc_data.DataType = System.Type.GetType("System.String");
       dc_data.ColumnName = "cioid";
       dt_data.Columns.Add(dc_data);//matter

       dc_data = new DataColumn();
       dc_data.DataType = System.Type.GetType("System.String");
       dc_data.ColumnName = "filename";
       dt_data.Columns.Add(dc_data);

       dc_data = new DataColumn();
       dc_data.DataType = System.Type.GetType("System.String");
       dc_data.ColumnName = "rtfformat";
       dt_data.Columns.Add(dc_data);

       dc_data = new DataColumn();
       dc_data.DataType = System.Type.GetType("System.String");
       dc_data.ColumnName = "xtgformat";
       dt_data.Columns.Add(dc_data);

       dc_data = new DataColumn();
       dc_data.DataType = System.Type.GetType("System.String");
       dc_data.ColumnName = "matter";
       dt_data.Columns.Add(dc_data);
       dr_data["cioid"] = cioid.ToString();

       dr_data["filename"] = fileName.ToString();
       dr_data["rtfformat"] = Session["matter_session"].ToString().Trim();
       dr_data["xtgformat"] = fileData_indesign;
       dr_data["matter"] = Session["matterText_session"].ToString();
       if (flag == "0")
       {
           dt_data.Rows.Add(dr_data);
           ds_data.Tables.Add(dt_data);
       }
       else
       {
           ds_data.Tables[tableCount].Rows.Add(dr_data);
       }
       Session["savedata"] = ds_data;
    }
}

