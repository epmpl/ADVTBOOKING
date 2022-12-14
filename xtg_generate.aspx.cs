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
using System.Diagnostics;
public partial class xtg_generate : System.Web.UI.Page
{
    float sz_width = 0;
    string temp_fdata = "";
    string centertitle = "";
    string contain_1 = "";
    string combinfdata = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btngen.Attributes.Add("OnClick","javascript:return genfile();");
        hiddendateformat.Value = Session["dateformat"].ToString();
    }
    static public float MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
    {
        const int width = 37;

        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, 1, graphics);
        SizeF layoutSize = new SizeF(113F, 50.0F);
        System.Drawing.SizeF size = graphics.MeasureString(text, font, layoutSize);
        System.Drawing.Graphics anagra = System.Drawing.Graphics.FromImage(bitmap);

        float measured_width = (float)size.Width;

        // int measured_width = (int)size.Width;
        //if (anagra != null)
        //{
        //    anagra.Clear(Color.White);
        //    anagra.DrawString(text + "|", font, Brushes.Black,width - measured_width, -font.Height / 2);

        //    for (int i = width - 1; i >= 0; i--)
        //    {
        //        measured_width--;
        //        if (bitmap.GetPixel(i, 0).R != 255)    // found a non-white pixel ?
        //            break;
        //    }
        //}

        return measured_width;
    }
    private string fetchFont(string matter)
    {

        string data = matter;
        string finaldata = "";
        string fontname = "";
        string fontDefault = "";
        data = data.Replace("<font color=BLACK AND WHITE", "<FONT");
        data = data.Replace("<FONT color=White", "<FONT"); 
        data = data.Replace("color=blackWHITEAND}", "");
        data = data.Replace("color=blackWHITEAND", "");
        data = data.Replace("</font>", "</FONT>");
        data = data.Replace("<BR>", "");
        data = data.Replace("<br>", "");
        data = data.Replace("<font", "<FONT");
        data = data.Replace(" <FONT  face=>", " <FONT  face=Gandhi>");
        data = data.Replace("<FONT  face", "<FONT face");
        data = data.Replace("color=#0e0ec0}", "");
        data = data.Replace("</B></div></div>", "");
        while (data.IndexOf("<FONT ") >= 0 || data.Length > 0)
        {
            int index = data.IndexOf("<FONT ");
            int index1;
            int index2;

            if (index == 0)
            {
                index1 = data.IndexOf("<FONT face=");
                index2 = data.IndexOf(">");
                if(index1!=-1)
                fontname = data.Substring(index1, index2 - index1);
                fontname = fontname.Replace("<FONT face=", "");
                data = data.Substring(index2 + 1, data.Length - (index2 + 1));
                if (fontDefault == "")
                {
                    if (matter.IndexOf("<FONT") == 0)
                    {
                        fontDefault = fontname;
                    }
                }
            }
            else
            {
                int index3 = data.IndexOf("</FONT>");
                int index4 = data.IndexOf("<FONT face=");
                string tempdata = "";

                if (index3 < index4)
                {
                    tempdata = data.Substring(0, index3);
                    // fontname = "";
                }
                else
                {
                    if (index4 == -1)
                    {
                        index4 = index3;
                    }
                    if (index4 == -1 && index3 == -1)
                    {
                        index4 = data.Length;
                    }
                    tempdata = data.Substring(0, index4);
                }
                if (index3 == 0)
                    fontname = "";
                if (index3 != 0 && fontname == "")
                {
                    fontname = fontDefault;
                }
                string[] arr;

                // arr = tempdata.ToString().Split(" ");
                arr = tempdata.Split(" ".ToCharArray());
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != "")
                    {
                        if (finaldata != "")
                        {
                            finaldata = finaldata + " " + arr[i].ToString() + "{" + fontname + "}";
                        }
                        else
                        {
                            finaldata = finaldata + arr[i].ToString() + "{" + fontname + "}";
                        }
                    }
                }
                index = data.IndexOf("</FONT>");
                int len = 0;
                if (index == 0)
                {
                    len = 7;
                    fontname = "";
                }
                if (tempdata.Length == data.Length)
                {
                    data = "";
                }
                else
                {
                    data = data.Substring(tempdata.Length + len, data.Length - (tempdata.Length + len));
                }
            }
        }
        return finaldata;
    }
    protected void btngen_ServerClick(object sender, EventArgs e)
    {
        string eyecatchtype = "";
        NewAdbooking.classesoracle.xtggenerate xtg = new NewAdbooking.classesoracle.xtggenerate();
        DataSet ds = new DataSet();
        ds = xtg.xtggeneratefile(Session["compcode"].ToString(), PubDate.Text, txtcioid.Text, Session["dateformat"].ToString(),Session["center"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
            {
                sz_width = 0;
                if (ds.Tables[0].Rows[i1].ItemArray[2].ToString() != "" && ds.Tables[0].Rows[i1].ItemArray[3].ToString() != "" && ds.Tables[0].Rows[i1].ItemArray[3].ToString() != "0")
                {
                    string mFinal = "";
                    string htFinal = "<l>";
                    string matter = ds.Tables[0].Rows[i1].ItemArray[3].ToString();// rtf format matter
                    matter = matter.Replace("^", "#");
                    matter = matter.Replace("  ", " ");
                    matter = matter.Replace("\r\n", "");
                    if(matter.IndexOf("<font")>=0)
                    matter = matter.Substring(matter.IndexOf("<font"), matter.Length - matter.IndexOf("<font"));
                    DataSet dsStyleSheet;
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.BookingMaster getStyle = new NewAdbooking.Classes.BookingMaster();
                        dsStyleSheet = getStyle.fetchStyleSheetName(ds.Tables[0].Rows[i1].ItemArray[6].ToString());
                    }

                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.BookingMaster getStyle = new NewAdbooking.classesoracle.BookingMaster();
                            dsStyleSheet = getStyle.fetchStyleSheetName(ds.Tables[0].Rows[i1].ItemArray[6].ToString());
                        }
                        else
                        {
                            NewAdbooking.classmysql.BookingMaster getStyle = new NewAdbooking.classmysql.BookingMaster();
                            dsStyleSheet = getStyle.fetchStyleSheetName(ds.Tables[0].Rows[i1].ItemArray[6].ToString());

                        }
                    string uom_desc = dsStyleSheet.Tables[0].Rows[0].ItemArray[1].ToString();
                    string sSheet = dsStyleSheet.Tables[0].Rows[0].ItemArray[0].ToString();
                    DataSet objDataSetbu = new DataSet();
                    // Read in the XML file
                    objDataSetbu.ReadXml(Server.MapPath("XML/" + sSheet + ".xml"));
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:white;position:absolute;border:2px Groove;width:143px;height:255px;\"><div style=\"font-size:10px;background-color:black;color:white;;position:absolute;border:2px Groove;width:128px;\"><B>", "");
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:143px;height:144px;\"><div style=\"font-size:10px;background-color:White;color:B;position:absolute;border:2px Groove;width:128px;\"><B>", "");
                    matter = matter.Replace("<font color=BLACK AND WHITE face=>color=black<br>ANDWHITE}</font>", "");
                    matter = matter.Replace(" color=black WHITE AND", "");//
                    matter = matter.Replace(" color=BLACK AND WHITE", "");
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:10px;background-color:White;color:B;position:absolute;border:2px Groove;width:113px;\"><B>", "");
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:7px;background-color:White;color:B;position:absolute;border:2px Groove;width:113px;\"><B>", "");
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:white;position:absolute;border:2px Groove;width:117px;height:391px;\"><div style=\"font-size:10px;background-color:black;color:white;;position:absolute;border:2px Groove;width:113px;\"><B>", "");
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:white;position:absolute;border:2px Groove;width:117px;height:272px;\"><div style=\"font-size:10px;background-color:black;color:white;;position:absolute;border:2px Groove;width:113px;\"><B>", "");
                    matter = matter.Replace("<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:117px;height:187px;\"><div style=\"font-size:10px;background-color:White;color:B;position:absolute;border:2px Groove;width:113px;\"><B>", "");
                    matter = matter.Replace("<font face=>color=blackANDWHITE}</font>", "");
                    matter = matter.Replace("</B></div>", "");
                    matter = matter.Replace("</B>", "");
                    matter = matter.Replace("</div>", "");
                    matter = matter.Replace("</STRONG>", "");
                    matter = matter.Replace("<STRONG>", "");
                    matter = matter.Replace("<font face=>size=3}</font>", "");
                    matter = matter.Replace("<br>", "");
                    matter = matter.Replace(" color=blackWHITEAND}", "");
                    matter = matter.Replace("<P>", "");
                    matter = matter.Replace("</P>", "");
                    matter = matter.Replace(" color=blackWHITEAND", "");
                    matter = matter.Replace("color=blackWHITE<br>AND}", "");
                    matter = matter.Replace("color=black<br>WHITEAND}", "");
                    matter = matter.Replace("<FONT><FONT><FONT>", "");
                    matter = matter.Replace("Groove;width:128px;”><B>", "");
                    matter = matter.Replace(" color=blackWHITE", "");
                    matter = matter.Replace(" color=black", "");
                    matter = matter.Replace("<font face=>color=blackANDWHITE}</font>", "");
                    matter = matter.Replace("color=White", "");
                    matter = matter.Replace("<P align=justify>", "");
                    matter = matter.Replace("<STRONG>", "");
                    matter=matter.Replace("Groove;width:143px;height:144px;”>Groove;width:128px;”><B>","");
                    string data = fetchFont(matter);
                    Graphics a;
                    double colwidth = 3;// Convert.ToDouble(Request.QueryString["hiddenwidth"]);//3.8;
                    if (ConfigurationSettings.AppSettings["adwidth"].ToString() == "mm")
                    {
                        colwidth = colwidth / 10;//to convert  mm to cm
                    }
                    else
                    {
                        colwidth = colwidth;
                    }
                    double bitmapwidth = (96 / 2.54) * colwidth;//96 is bitmal verticalresolution and 2.54 is the cm. in 1 inch.
                    Bitmap bmpDummy = new Bitmap(Convert.ToInt32(bitmapwidth), 100);
                    int widthD = Convert.ToInt32(bitmapwidth);
                    a = Graphics.FromImage(bmpDummy);
                    SizeF k;
                    int k_ = 0;
                    int k_1 = 0;
                    string fileData_indesign = "";
                    fileData_indesign = "<ASCII-WIN>" + "\r\n";
                    fileData_indesign = fileData_indesign + "<Version:5><FeatureSet:InDesign-Roman><ColorTable:=<Black:COLOR:CMYK:Process:0,0,0,1><C\\=0 M\\=0 Y\\=100 K\\=0:COLOR:CMYK:Process:0,0,1,0>>" + "\r\n";
                    fileData_indesign = fileData_indesign + "<DefineParaStyle:Normal=<Nextstyle:Normal><pHyphenationLadderLimit:0><pHyphenationZone:0.000000><cFont:Arial><pDesiredWordSpace:1.100000><pMaxWordSpace:2.500000><pMinWordSpace:0.850000><pMaxLetterspace:0.040000><pKeepFirstNLines:1><pKeepLastNLines:1><pRuleAboveColor:Black><pRuleAboveTint:100.000000><pRuleBelowColor:Black><pRuleBelowTint:100.000000><bnColor:None><numFont:\\<TextFont\\>>>" + "\r\n";
                    string eyecatcher = ds.Tables[0].Rows[i1].ItemArray[4].ToString();// "♥";
                    if (eyecatcher == "UN0")
                        fileData_indesign = fileData_indesign + "<ParaStyle:Normal><pRuleAboveColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleAboveStroke:0.000000><pRuleBelowColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleBelowStroke:0.000000><pRuleBelowTint:100.000000><pRuleBelowOffset:3.650000><pRuleAboveOn:1><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pTextAlignment:JustifyFull><cUnderline:1>";
                    else
                        fileData_indesign = fileData_indesign + "<ParaStyle:Normal><pRuleAboveColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleAboveStroke:0.000000><pRuleBelowColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleBelowStroke:0.000000><pRuleBelowTint:100.000000><pRuleBelowOffset:3.650000><pRuleAboveOn:1><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pTextAlignment:JustifyFull>";
                    string fontname = "0";
                    string fontsize = "0";
                    int count = 1;

                    /*this font is for normal*/
                    if (fontname == "0")
                        fontname = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (fontsize == "0")
                        fontsize = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
                    string bgcolor = "";
                    string coltype = "";
                    if (bgcolor == "" || bgcolor == "0")
                    {
                        bgcolor = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
                    }
                    if (coltype == "" || coltype == "0")
                    {
                        coltype = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
                    }
                    int style = 0;
                    string fname_bold = "";
               
                    if (objDataSetbu.Tables[1].TableName == "bold")
                    {
                        style = Convert.ToInt32(objDataSetbu.Tables[1].Rows[0].ItemArray[5]);
                        fname_bold = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
                        if (eyecatcher == "BO0" || eyecatcher == "BO3" || eyecatcher == "BO2")
                            fileData_indesign = fileData_indesign + "<cTypeface:Bold>";
                        else
                            fileData_indesign = fileData_indesign + "<cTypeface:Normal>";

                    }
                    else
                    {
                        style = 2;
                        if (eyecatcher == "BO0" || eyecatcher == "BO3" || eyecatcher == "BO2")
                            fileData_indesign = fileData_indesign + "<cTypeface:Bold>";
                        else
                        fileData_indesign = fileData_indesign + "<cTypeface:Normal>";
                    }

                    char[] strarr;
                    string[] strArrSplit;
                    string dataSplit = "";
                    float width1 = 0;
                    float width1_char = 0;
                    string final = "";
                    string fstFName = "";
                    string fileData = "";
                    int divwidth = widthD;
                    divwidth = divwidth + 10;
                    int height = 0;
                    int dropcap = 0;
                    int cent_sz_width = 0;
                    int eyecatcherlen = 2;
                    if (objDataSetbu.Tables.Count - 1 >= 2 && objDataSetbu.Tables[2].TableName == "dropcap")
                    {
                        eyecatcher = "DR";
                        eyecatcherlen = Convert.ToInt32(objDataSetbu.Tables[2].Rows[0].ItemArray[1].ToString());
                    }
                    string dropcapString = "";
                    string eyecatchstr = "";
                    if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "0" && eyecatcher != "")
                    {
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.bulletmaster clsbullet = new NewAdbooking.Classes.bulletmaster();
                            DataSet dssymbol = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                            eyecatchstr = dssymbol.Tables[0].Rows[0].ItemArray[0].ToString();
                        }
                        else
                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                            {
                                NewAdbooking.classesoracle.bulletmaster clsbullet = new NewAdbooking.classesoracle.bulletmaster();
                                DataSet dssymbol = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                                eyecatchstr = dssymbol.Tables[0].Rows[0].ItemArray[0].ToString();
                            }
                            else
                            {

                                NewAdbooking.classmysql.bulletmaster clsbullet = new NewAdbooking.classmysql.bulletmaster();
                                DataSet dssymbol = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                                eyecatchstr = dssymbol.Tables[0].Rows[0].ItemArray[0].ToString();

                            }
                    }
                    if (eyecatcher != "0" && eyecatcher != "" && eyecatcherlen > 1)
                    {
                        dropcap = eyecatcherlen;
                    }
                    strarr = data.ToCharArray();

                    strArrSplit = data.Split(" ".ToCharArray());
                    int strlength = 0;

                    float fontsi = float.Parse(fontsize);

                    //////////////
                    int j_ = 0;
                abc:
                    //int i=j_;
                    for (int i = j_; i < strarr.Length; i++)
                    {
                        string fname = "";
                        string fdata = "";

                        fdata = strarr[i].ToString();
                        if (fdata != " ")
                        {
                            if (fdata != "\r")
                            {
                                i++;
                                j_ = i;
                                if (temp_fdata != "")
                                {
                                    temp_fdata = temp_fdata + fdata;
                                }
                                else
                                {
                                    temp_fdata = fdata;

                                }
                                if (i == strarr.Length)
                                {
                                    fdata = temp_fdata;
                                }
                                else
                                {
                                    goto abc;
                                }
                            }
                        }
                        if (temp_fdata != "")
                        {
                            if (fdata == "\r")
                            {
                                if (centertitle != "center")
                                    count = count + 1;
                                style = 1;
                            }
                            fdata = temp_fdata; // +" ";
                            if (i == strarr.Length)
                            {
                                fdata = fdata.Replace(" ", "");
                            }
                            temp_fdata = "";
                        }
                        //get font name

                        if (fdata.IndexOf('{') > 0)
                        {
                            string[] arrfdata = fdata.Split('{');
                            fdata = arrfdata[0] + " ";
                            if (i == strarr.Length)
                            {
                                fdata = fdata.Replace(" ", "");
                            }
                            fname = arrfdata[1].Replace("}", "");
                            if (fname == "")
                            {
                                fname = fontname;
                            }
                        }
                        //****************************
                        if (contain_1 != "")
                        {
                            contain_1 = contain_1 + fdata;
                        }
                        else
                        {
                            contain_1 = fdata;
                        }
                        //Font f = new Font("Arial", 9, FontStyle.Bold);
                        Font f;
                        float f_ = .55F;

                        string leading = "";
                        if (fname == "Gandhi")
                        {
                            f = new Font(fname.Trim(), 9, FontStyle.Regular, GraphicsUnit.Point);
                            fontsize = "9";
                            leading = "9";
                        }
                        else
                        {
                            fontsize = "7";
                            leading = "7";
                            f = new Font(fname.Trim(), 7, FontStyle.Regular, GraphicsUnit.Point);
                        }



                        //   if (eyecatcherlen > 1 && count <= Convert.ToInt32(eyecatcherlen))
                        //   {
                        //       f = new Font(fname_bold, 6, FontStyle.Bold);
                        //  }
                        string txtcolor = "";
                        string lineText = "";
                        if (eyecatcher == "BO3")
                            txtcolor = "White";
                        if (lineText != "")
                        {
                            lineText = lineText + fdata;
                        }
                        else
                        {
                            lineText = fdata;
                        }

                        //*********************
                        k = a.MeasureString(lineText.Trim(), f);
                        width1 = sz_width + width1;
                        sz_width = MeasureDisplayStringWidth(a, fdata.Replace("\n", "").Trim(), f);

                        height = Convert.ToInt32(k.Height);

                        string val_ = Convert.ToString((96 / 25.4));


                        //******************  
                        if (fname == "\"\"")
                            fname = fontname;
                        if (eyecatchstr == "/")
                            eyecatchstr = "//";
                        if ((sz_width + width1) > divwidth)
                        {
                            width1 = sz_width;
                            sz_width = 0;
                            lineText = lineText.Trim();
                            if (lineText.LastIndexOf(" ") >= 0)
                            {
                                lineText = lineText.Substring(0, lineText.LastIndexOf(" "));
                            }
                            lineText = lineText + "\n";
                            final = final.Substring(0, final.Length);
                            mFinal = mFinal.Substring(0, mFinal.Length);

                            count = count + 1;

                            if (final == "")
                            {
                                fstFName = fname;
                                fileData = "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;

                                if (eyecatcher != "DR" && eyecatcher != "BO0" && eyecatcher != "BO1" && eyecatcher != "UN0" && eyecatcher != "0" && eyecatcher != "")
                                {
                                    if (eyecatcher == "HR")
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:Webdings>" + eyecatchstr + "<cSize:" + fontsize + "><cSize:><cFont:><cLeading:><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    else
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:Wingdings>" + eyecatchstr + "<cSize:" + fontsize + "><cSize:><cFont:><cLeading:><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                }
                                else
                                {
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                }
                                mFinal = mFinal + "\\l<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                            }

                            else if (fstFName == fname)
                            {
                                fileData = fileData + fdata;
                                fileData_indesign = fileData_indesign + "\r\n" + fdata;
                                mFinal = mFinal + "\\l" + fdata;
                            }
                            else
                            {
                                fstFName = fname;
                                fileData = fileData + "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                if (eyecatcher == "BO0" || eyecatcher == "BO3" || eyecatcher == "BO2")
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Bold><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                else
                                fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                mFinal = mFinal + "</font>";
                                mFinal = mFinal + "\\l<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                            }
                            combinfdata = "";
                            //**************************************                    
                            lineText = fdata;
                            //**************************************
                        }
                        else
                        {
                            htFinal += fdata;
                            if (i == strarr.Length)
                            {
                                // count = count + 1;
                                //*************************************
                                if (final == "")
                                {
                                    fstFName = fname;
                                    fileData = "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    if (eyecatcher != "DR" && eyecatcher != "BO0" && eyecatcher != "BO1" && eyecatcher != "UN0" && eyecatcher != "BO2" && eyecatcher != "BO3" && eyecatcher != "0" && eyecatcher != "")
                                    {
                                        if (eyecatcher == "HR")
                                            fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:Webdings>" + eyecatchstr + "<cSize:" + fontsize + "><cSize:><cFont:><cLeading:><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                        else
                                            fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:Wingdings>" + eyecatchstr + "<cSize:" + fontsize + "><cSize:><cFont:><cLeading:><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    mFinal = mFinal + "<font color=" + txtcolor + "  face=" + fname + ">" + fdata;
                                }

                                else if (fstFName == fname)
                                {
                                    fileData = fileData + fdata;
                                    mFinal = mFinal + fdata;
                                    fileData_indesign = fileData_indesign + fdata;
                                }
                                else
                                {
                                    fstFName = fname;
                                    fileData = fileData + "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    if (eyecatcher == "BO0" || eyecatcher == "BO3" || eyecatcher == "BO2")
                                        fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Bold><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    else
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    mFinal = mFinal + "</font>";
                                    mFinal = mFinal + "<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                                }
                                //mFinal = mFinal + "</font>";
                                //***************************************
                                final = final + "<font face=" + fname + ">" + fdata + "</font>";
                            }
                            else
                            {
                                //*******************************
                                if (final == "")
                                {
                                    fstFName = fname;
                                    // if (dropcap > 1 && i == 0)
                                    //  {
                                    if (eyecatcher == "DR")
                                    {
                                        fileData = "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><*d(1," + dropcap + ">" + fdata;
                                        // fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:8.100000><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (eyecatcher != "DR" && eyecatcher != "BO1" && eyecatcher != "BO0" && eyecatcher != "UN0" && eyecatcher != "BO2" && eyecatcher != "BO3" && eyecatcher != "0" && eyecatcher != "")
                                    {
                                        fileData = "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        if (eyecatcher == "HR")
                                            fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:Webdings>" + eyecatchstr + "<cSize:" + fontsize + "><cSize:><cFont:><cLeading:><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                        else
                                            fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:Wingdings>" + eyecatchstr + "<cSize:" + fontsize + "><cSize:><cFont:><cLeading:><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                        fileData = "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    // }
                                    //else
                                    //{
                                    //    fileData = "<*p(0,0,0,6.5,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    //    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:8.100000><cFont:" + fname + ">" + fdata;
                                    //}
                                    mFinal = mFinal + "<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                                }

                                else if (fstFName == fname)
                                {
                                    fileData = fileData + fdata;
                                    mFinal = mFinal + fdata;
                                    fileData_indesign = fileData_indesign + fdata;
                                }
                                else
                                {
                                    fstFName = fname;
                                    fileData = fileData + "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    if (eyecatcher == "BO0" || eyecatcher == "BO3" || eyecatcher == "BO2")
                                        fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Bold><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    else
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    mFinal = mFinal + "</font>";
                                    mFinal = mFinal + "<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                                }
                                //mFinal = mFinal + "</font>";
                                //***************************************
                                final = final + "<font face=" + fname + ">" + fdata + "</font>";
                            }

                        }
                        if (dropcap > 1)
                        {
                            if (eyecatcher == "DR")
                            {
                                //  mFinal = mFinal + "</font>";
                                final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1).ToUpper() + "</span>" + fdata.Substring(1, fdata.Length - 1);
                                mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1).ToUpper() + "</span>" + fdata.Substring(1, fdata.Length - 1);
                                eyecatcher = "";
                            }
                            else
                            {
                                if (eyecatcher != "DR" && eyecatcher != "BO1" && eyecatcher != "BO0" && eyecatcher != "UN0" && eyecatcher != "BO2" && eyecatcher != "BO3" && eyecatcher != "0" && eyecatcher != "")
                                {
                                    // mFinal = mFinal + "</font>";
                                    if (eyecatcher == "HR")
                                    {
                                        final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                        mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                    }
                                    else
                                    {
                                        final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Wingdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                        mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Wingdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                    }
                                    eyecatcher = "";
                                }
                            }
                            //final = "<span style=\"border:1px solid;float:left;font-size:12px;font-family:Arial;padding:1px;line-height:1em;\">" + final.Substring(0, 1) + "</span>" + final.Substring(1, final.Length - 1);
                        }
                        else
                        {
                            if (eyecatcher != "0" && eyecatcher != "")
                            {
                                if (eyecatcher != "DR" && eyecatcher != "BO1" && eyecatcher != "BO0" && eyecatcher != "UN0" && eyecatcher != "BO2" && eyecatcher != "BO3")
                                {
                                    //mFinal = mFinal + "</font>";
                                    if (eyecatcher == "HR")
                                    {
                                        final = "<span style=\"border:0px solid;float:left;font-size:11px;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                        mFinal = "<span style=\"border:0px solid;float:left;font-size:11px;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                    }
                                    else
                                    {
                                        final = "<span style=\"border:0px solid;float:left;font-size:11px;font-family:Wingdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                        mFinal = "<span style=\"border:0px solid;float:left;font-size:11px;font-family:Wingdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                    }
                                    eyecatcher = "";
                                }

                            }
                        }

                        //for bold we have to use the different font
                        if (style == 0)
                        {
                            style = 2;
                            final = "<b>" + final + "</b>";
                            mFinal = "<b>" + mFinal + "</b>";
                        }

                        if (style == 3 && i == 2)
                        {
                            style = 2;
                            final = "<b>" + final + "</b>";
                            mFinal = "<b>" + mFinal + "</b>";
                        }

                        f.Dispose();

                    }// end loop
                    mFinal = mFinal + "</font>";
                    final = final.Replace("\\l", "<br>");
                    mFinal = mFinal.Replace("\\l", "<br>");
                    if (eyecatcher == "UN0")
                        fileData_indesign = fileData_indesign + "\r\n<cTypeface:><cSize:><cLeading:><cFont:><pRuleAboveColor:><pRuleAboveStroke:><pRuleBelowColor:><pRuleBelowStroke:><pRuleBelowTint:><pRuleAboveOn:><pTextAlignment:><cUnderline:>";
                    else
                        fileData_indesign = fileData_indesign + "\r\n<cTypeface:><cSize:><cLeading:><cFont:><pRuleAboveColor:><pRuleAboveStroke:><pRuleBelowColor:><pRuleBelowStroke:><pRuleBelowTint:><pRuleAboveOn:><pTextAlignment:>";

                    // for placinf booking id
                   // fileData_indesign = fileData_indesign + "<ParaStyle:Normal><pSpaceBefore:4.300000><pRuleAboveColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleAboveStroke:0.000000><pRuleBelowColor:C\\=0 M\\=0 Y\\=100 K\\=0><pRuleBelowStroke:0.000000><pRuleBelowTint:0.000000><pRuleAboveOn:1><pTextAlignment:JustifyRight><cSize:6.000000><cLeading:10.000000><ParaStyle:Normal><cFont:Arial>" + ds.Tables[0].Rows[i1].ItemArray[1].ToString() + "(" + ds.Tables[0].Rows[i1].ItemArray[7].ToString() + ")<cSize:><cLeading:><cFont:><pSpaceBefore:><pRuleAboveColor:><pRuleAboveStroke:><pRuleBelowColor:><pRuleBelowStroke:><pRuleBelowTint:><pRuleAboveOn:><pTextAlignment:>";
                    // for line no
//                    fileData_indesign =fileData_indesign + "<ParaStyle:Normal>"+ds.Tables[0].Rows[i1].ItemArray[1].ToString() + "(" + ds.Tables[0].Rows[i1].ItemArray[7].ToString() + ")";
                    fileData_indesign = fileData_indesign + "<ParaStyle:Normal>" + ds.Tables[0].Rows[i1].ItemArray[1].ToString();
                    string fileName = ds.Tables[0].Rows[i1].ItemArray[2].ToString() + ".txt";
                    fileName = fileName.Replace(".xtg", "");
                    fileName = fileName.Replace(".txt", "");
                    fileName = fileName + ".txt";
                   // string path = ds.Tables[0].Rows[i1].ItemArray[8].ToString() + "\\xtg";
                   // System.IO.Directory.CreateDirectory(path);
                    System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/xtg"));
                    FileStream fs = null;
                   
                    //fs = new FileStream(path + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
                    fs = new FileStream(Server.MapPath("/webdir/xtg") + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                    fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND}", "");
                    fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND", "");
                  
                   // fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND}", "");
                    sw.Write(fileData_indesign);// for indesign XTG
                    //sw.WriteLine(mFinal);
                    // sw.WriteLine(htFinal);

                    sw.Flush();
                    sw.Dispose();
                    fs.Dispose();
                    xtg.updatextgmatter(ds.Tables[0].Rows[i1].ItemArray[1].ToString(), fileName, fileData_indesign, ds.Tables[0].Rows[i1].ItemArray[2].ToString()); 

                }
            }
        }
        string message = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            message = "Updated Successfully";
            AspNetMessageBox(message);
        }
        else
        {
            message = "No Data Found";
            AspNetMessageBox(message);
        }
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(xtg_generate), "ShowAlert", strAlert, true);
    }
}
