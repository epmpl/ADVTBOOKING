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
using System.Drawing.Drawing2D;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using iTextSharp.text.xml;
//using genpdf;
using System.Text.RegularExpressions;
public partial class matterprev_new : System.Web.UI.Page
{
    string danish = "";
    string chklen = "0";
    string contain = "";
    string logohei = "";
    string logowid = "";
    string centertitle = "";
    string src_name = "";
    string filename_pdf = "";
    string kop = "";
    int kopcount = 0;
    string boldforkop = "";
    string combinfdata = "";
    int prevmat = 0;
    string copy_cioid = "";
    string fontDefault = "";
    int fontcntr = 0;
    string boldfontsize = "";
    string normalfontsize = "";
    string comcharf = "~" + Convert.ToChar(05);//~}
    string comcharl = Convert.ToChar(05) + "~";//}~

    public string enterSpace(string matter)
    {
        matter = matter.Replace("<FONT size=+0></FONT>", "");
        matter = matter.Replace("<FONT size=+0>", "");
        matter = matter.Replace("&amp;", "&");
        string data = matter;
        string oldfont = "";
        string curfont = "";
        string newdata = "";
        bool htmlstart = false;
        bool gh = false;
        string trufont = "";
        //data = data.Replace("</FONT>", "").Replace("</font>", "");
        int i = 0;

        for (i = 0; i < data.Length; i++)
        {
            string a;
            if (gh == true)
            {
                gh = false;
                if (trufont != curfont && trufont != "" && newdata != "")
                {
                    if (newdata.Length >= 2 && newdata.Substring(newdata.Length - 2) != comcharl)
                    {
                        // if (newdata.LastIndexOf("}~") != newdata.ToString().Length - 2 || newdata.LastIndexOf(" ") != newdata.ToString().Length - 1)
                        if (newdata.LastIndexOf(" ") != newdata.ToString().Length - 1)
                            newdata = newdata + comcharf + trufont + comcharl;
                    }
                    trufont = curfont;

                }

            }
            a = data.Substring(i, 1);
            if (a == "¯")
            {
                string ff = "";
            }
            if (a == "<")
            {

                a = data.Substring(i, data.IndexOf(">", i + 1) - i + 1);
                i = i + a.Length - 1;
                if (a.IndexOf("FONT face=") > 0)
                {
                    gh = true;
                    if (a.IndexOf("TimesEuropa Roman") > 0)
                    {
                        if (curfont == "")
                            curfont = "TimesEuropa Roman";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "TimesEuropa Roman";
                        }
                    }
                    else
                    {
                        if (curfont == "")
                        {
                            if (matter.IndexOf("Satluj") >= 0)
                                curfont = "Satluj";
                            else
                            {
                                curfont = "Chanakya";
                            }
                        }
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            // curfont = "SHREE-KAN-0850";
                            if (matter.IndexOf("Satluj") >= 0)
                                curfont = "Satluj";
                            else
                            {
                                curfont = "Chanakya";
                            }
                        }
                    }
                }
                else if (a == "</FONT>")
                {
                    gh = true;
                    if (oldfont != "")
                    {
                        if (oldfont.IndexOf(",") > 0)
                        {
                            trufont = curfont;
                            curfont = oldfont.Substring(oldfont.LastIndexOf(",") + 1);
                            oldfont = oldfont.Substring(0, oldfont.LastIndexOf(","));
                        }
                        else
                        {
                            // if (trufont == "")
                            //{
                            trufont = curfont;
                            //}
                            curfont = oldfont;
                        }
                    }

                }
            }
            else if (a == " ")
            {

                trufont = curfont;
                if (newdata.LastIndexOf("}") != newdata.ToString().Length - 2)
                    newdata = newdata + comcharf + curfont + comcharl + a;
                else
                {
                    newdata = newdata + a;
                }

            }
            else
                newdata = newdata + a;
        }
        if (newdata.Length >= 2 && newdata.Substring(newdata.Length - 2) != comcharl)
            newdata = newdata + comcharf + trufont + comcharl;
        if (newdata.IndexOf(comcharf + "TimesEuropa Roman" + comcharl) >= 0 || newdata.IndexOf(comcharf + "TimesEuropa Roman" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (newdata.IndexOf(comcharf + "Satluj" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        else if (newdata.IndexOf(comcharf + "Chanakya" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        return newdata;
    }
    private string fetchFont(string matter)
    {
        matter = matter.Replace("<FONT size=+0></FONT>", "");
        matter = matter.Replace("<FONT size=+0>", "");
        matter = matter.Replace("&amp;", "&");
        matter = enterSpace(matter);
        string data = matter;
        string finaldata = "";
        string fontname = "";

        // int index = td1.InnerHtml.IndexOf("<font ");
        while (data.IndexOf("<FONT ") >= 0 || data.Length > 0)
        {
            int index = data.IndexOf("<FONT ");
            int index1;
            int index2;

            if (index == 0)
            {
                // fontcntr = fontcntr + 1;
                index1 = data.IndexOf("<FONT face=");
                index2 = data.IndexOf(">");
                if (index2 == -1)
                {
                    data = data.Replace("<FONT face=", "");
                    fontname = "TimesEuropa Roman";
                }
                else
                {
                    fontname = data.Substring(index1, index2 - index1);
                    fontname = fontname.Replace("<FONT face=", "");
                }
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
                // index1 = data.IndexOf("<FONT face=");
                // index2 = data.IndexOf(">");
                // string fontname = data.Substring(index1, index2 - index1);
                //  fontname = fontname.Replace("<FONT face=", "");
                // data = data.Substring(index2 + 1, data.Length - (index2+1));
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
                if (tempdata == " ")
                {
                    finaldata = finaldata + " ";
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (fontname != "")
                        {


                            if ((arr[i] == "" || arr.Length > 2) && arr.Length != 1)
                            {
                                if (finaldata == "")
                                {
                                    finaldata = arr[i].ToString() + comcharf + fontname + comcharl;
                                }
                                else
                                {
                                    finaldata = finaldata + " " + arr[i].ToString() + comcharf + fontname + comcharl;
                                }
                            }
                            else
                            {
                                finaldata = finaldata + arr[i].ToString() + comcharf + fontname + comcharl;
                            }

                        }
                        else
                        {
                            if (arr[i] != "")
                            {

                                if (finaldata != "")
                                {
                                    finaldata = finaldata + " " + arr[i].ToString() + comcharf + fontname + comcharl;
                                }
                                else
                                {
                                    finaldata = finaldata + arr[i].ToString() + comcharf + fontname + comcharl;
                                }

                            }
                        }
                    }
                }

                //finaldata = finaldata + data.Substring(0, data.IndexOf("<FONT face="));

                index = data.IndexOf("</FONT>");
                int len = 0;
                if (index == 0)
                {
                    len = 7;
                    fontname = "";
                }
                //if (index == -1)
                //{
                //    len = data.Length;
                //}
                //  data = matter.Substring(matter.Length + len, matter.Length - tempdata.Length);
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
        if (finaldata.IndexOf(comcharf + "TimesEuropa Roman" + comcharl) >= 0 || finaldata.IndexOf(comcharf + "TimesEuropa Roman" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (finaldata.IndexOf(comcharf + "SHREE-KAN-0850" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        return finaldata;
    }
    string mod_log = "";
    string cioid = "";
    string previousid = "";
    string boxmatter_string = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int hy = 0;
        string characterline = "";
        string firstFontName = "";
        string eyecatchtype = "";
        Boolean checkHY = false;
        /*new change ankur 17feb*/
        if (Session["compcode"] == null)
        {

            Response.Write("<script>window.close();</script>");
            return;
        }
        if (Request.QueryString["eyecatchtype"] != null)
        {
            eyecatchtype = Request.QueryString["eyecatchtype"].ToString();
        }
        DataSet ds_data = new DataSet();
        DataTable dt_data = new DataTable();
        DataRow dr_data = dt_data.NewRow();
        DataColumn dc_data;
        int tableCount = 0;

        string editorfornt = "";
        string xyz1 = "";
        string fileName;
        string flag = "0";
        string mFinal = "";
        string sFinal = "";
        string htFinal = "<l>";
        int charperline = 0;
        int totalchar = 0;
        string fname_bold = "";

        string matter = "";
        string data = "";
        string uom = "";
        string uom_desc = "";
        string language = "";
        string fntname = "";
        string fileData_indesign = "";
        string abc = "";
        string def = "";
        /*mysql*/

        hiddenagencyratecode.Value = Session["agencyratecode"].ToString();
        hiddendatabasename.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        if (Session["agencycodeforrate"] != null)
        {
            hiddenagencycode.Value = Session["agencycodeforrate"].ToString();
        }
        previousid = Request.QueryString["previd"].ToString();
        /////////////////////////////////////////


        /*new change ankur for matter*/
        logohei = Request.QueryString["logohei"].ToString();
        logowid = Request.QueryString["logowid"].ToString();

        //matter = Request.QueryString["matter"].ToString();//Session["matter"].ToString();
        /*new change ankur for matter*/
        matter = Session["matter_session"].ToString().Trim();
        //matter = matter.Replace("^", "#");
        //matter = matter.Replace("<P>", "");
        //matter = matter.Replace("</P>", "");
        //matter = matter.Replace("<p>", "");
        //matter = matter.Replace("</p>", "");
        matter = matter.Replace("<br>", "<BR>");
        string caption = "";
        matter = matter.Replace("\r\n", "");
        //if (matter.IndexOf("\r\n") > 0 || matter.IndexOf("\r\n") > 0)
        //{
        //    caption = matter.Substring(0, matter.IndexOf("\r\n"));
        //    matter = matter.Substring(matter.IndexOf("\r\n") + 2, matter.Length - caption.Length - 2);
        //}
        //else if (matter.IndexOf("<br>") > 0 || matter.IndexOf("<BR>") > 0)
        //{
        //    caption = matter.Substring(0, matter.IndexOf("<BR>"));
        //    matter = matter.Substring(matter.IndexOf("<BR>") + 4, matter.Length - caption.Length - 4);
        //}

        danish = Session["matterText_session"].ToString();
        DataSet dsboxmatter = new DataSet();
        //Request.QueryString["boxno"].ToString() in this query string we are fetching receipt number.
        //if (Session["revenue"].ToString() != "")
        //{
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getBox = new NewAdbooking.Classes.BookingMaster();
            dsboxmatter = getBox.autogenratedbox(Session["compcode"].ToString(), "", "", Session["center"].ToString(), Session["agency_name"].ToString(), Session["revenue"].ToString(),"");
            // dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
            //dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());
            dsboxmatter = getBox.autogenratedbox(Session["compcode"].ToString(), "", "", Session["center"].ToString(), Session["agency_name"].ToString(), Session["revenue"].ToString(),"");
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getBox = new NewAdbooking.classmysql.BookingMaster();
            dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());

        }
        string box_matter = "";
        if (dsboxmatter.Tables.Count > 1)
        {
            if (dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString() != "" && dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString() != null)
            {
                if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"] != "undefined")
                {
                    //matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
                    box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
                }
            }
            else
            {
                if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "undefined")
                {
                    // matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                    box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                }
            }
        }
        else
        {
            if (dsboxmatter.Tables[0].Rows.Count > 0 && dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString() != "" && dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString() != null)
            {
                if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"] != "undefined")
                {
                    //matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
                    box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
            else
            {
                if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "undefined")
                {
                    // matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                    box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                }
            }
        }
        boxmatter_string = box_matter;
        if (box_matter != "")
            box_matter = "<FONT face=TimesEuropa Roman>" + box_matter + "</FONT>";
        if (box_matter != "")
            matter = matter.Replace(box_matter, "");
        matter = matter + box_matter;
        uom = Request.QueryString["hiddenuom"].ToString();
        Hiddeninser.Value = Request.QueryString["hiddeninsert"].ToString();

        //******************************************************************
        string edition = Request.QueryString["edition"].ToString();
        string insertid = Request.QueryString["hiddeninsert"].ToString();
        cioid = Request.QueryString["cioid"].ToString();
        copy_cioid = Request.QueryString["cioid"].ToString();
        string srno = Request.QueryString["srno"].ToString();

        string txtcolor = Request.QueryString["txtcolor"].ToString();
        //*************************************************************
        if (txtcolor == "COLOR" || txtcolor == "color")
            txtcolor = "black";
        string coltype = Request.QueryString["coltype"].ToString();
        fntname = Request.QueryString["fntname"].ToString();
        language = Request.QueryString["language"].ToString();


        //*************************************************************
        Ajax.Utility.RegisterTypeForAjax(typeof(matterprev_new));


        DataSet dsStyleSheet;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getStyle = new NewAdbooking.Classes.BookingMaster();
            dsStyleSheet = getStyle.fetchStyleSheetName(uom);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getStyle = new NewAdbooking.classesoracle.BookingMaster();
                dsStyleSheet = getStyle.fetchStyleSheetName(uom);
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getStyle = new NewAdbooking.classmysql.BookingMaster();
                dsStyleSheet = getStyle.fetchStyleSheetName(uom);

            }
        /*new change ankur 17 feb*/
        uom_desc = dsStyleSheet.Tables[0].Rows[0].ItemArray[1].ToString();
        string sSheet = dsStyleSheet.Tables[0].Rows[0].ItemArray[0].ToString();
        //*************************************************************
        string bgcolor = Request.QueryString["bgcolor"].ToString();

        DataSet dsbgcolcode = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getbgcode = new NewAdbooking.Classes.BookingMaster();
            // dsbgcolcode = getbgcode.getbgcolcode(bgcolor);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getbgcode = new NewAdbooking.classesoracle.BookingMaster();
            dsbgcolcode = getbgcode.getbgcolcode(bgcolor);
        }


        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/" + sSheet + ".xml"));
        // data = fetchFont(matter);
        matter = matter.Replace("Times Roman New", "Times New Roman");
        data = enterSpace(matter);
        Graphics a;
        double colwidth = 0;
        if (Request.QueryString["hiddenwidth"].ToString() != "")
            colwidth = Convert.ToDouble(Request.QueryString["hiddenwidth"]);//3.8;
        colwidth = 3.8;
        if (ConfigurationSettings.AppSettings["adwidth"].ToString() == "mm")
        {
            colwidth = colwidth / 10;//to convert  mm to cm
        }
        else
        {
            colwidth = colwidth;
        }
        fileData_indesign = "<ASCII-WIN>" + "\r\n";
        fileData_indesign = fileData_indesign + "<Version:6><FeatureSet:InDesign-Roman><ColorTable:=<Black:COLOR:CMYK:Process:0,0,0,1>>" + "\r\n";
        fileData_indesign = fileData_indesign + "<ParaStyle:><pRuleBelowOffset:3.650000><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pTextAlignment:JustifyFull>";
        //  fileData_indesign = fileData_indesign + "<DefineParaStyle:Normal=<Nextstyle:Normal><pHyphenationLadderLimit:0><pHyphenationZone:0.000000><cFont:Arial><pDesiredWordSpace:1.100000><pMaxWordSpace:2.500000><pMinWordSpace:0.850000><pMaxLetterspace:0.040000><pKeepFirstNLines:1><pKeepLastNLines:1><pRuleAboveColor:Black><pRuleAboveTint:100.000000><pRuleBelowColor:Black><pRuleBelowTint:100.000000>>";

        //fileData_indesign = fileData_indesign + "<pRuleBelowOffset:3.650000><pRuleAboveOn:0><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pTextAlignment:JustifyFull>";

        //     else
        fileData_indesign = fileData_indesign + "<cTypeface:Normal>";
        double bitmapwidth = (72 / 2.54) * colwidth;//96 is bitmal verticalresolution and 2.54 is the cm. in 1 inch.
        Bitmap bmpDummy = new Bitmap(Convert.ToInt32(bitmapwidth), 100);
        int widthD = Convert.ToInt32(bitmapwidth);
        widthD = widthD + 1;
        a = Graphics.FromImage(bmpDummy);
        a.PageUnit = GraphicsUnit.Point;
        /*in this we have taken he bold description*/
        int style = 0;
        int tstyle = 0;
        if (objDataSetbu.Tables[1].TableName == "bold")
        {
            style = Convert.ToInt32(objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString());//0 means first word bold and 1 means two words bold 2 means first line bold
        }
        else
        {
            style = 2;
        }
        tstyle = style;
        if (objDataSetbu.Tables.Count - 1 >= 2 && objDataSetbu.Tables[2].TableName == "centered")
        {
            centertitle = objDataSetbu.Tables[2].Rows[0].ItemArray[0].ToString();
        }

        //this to chk whether the selected style sheet is of k0p
        if (objDataSetbu.Tables.Count - 1 >= 2 && objDataSetbu.Tables[2].Rows[0].ItemArray.Length == 3)
        {
            if (objDataSetbu.Tables.Count - 1 >= 2 && objDataSetbu.Tables[2].Rows[0].ItemArray[2].ToString() == "kop")
            {
                kop = "1";
            }
        }

        if (caption != "")
        {
            style = 5;
        }
        SizeF k;
        string fontname = fontDefault;
        string fontsize = "0";
        int count = 1;
        int allcount = 1;
        int boldcharcount;
        //this font is for normal
        if (fontname == "")
            fontname = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();

        if (fontsize == "0")
            fontsize = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        /*for font color type and bgcolor*/
        if (bgcolor == "" || bgcolor == "0" || bgcolor == "White")
        {
            bgcolor = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        }
        if (coltype == "" || coltype == "0" || coltype == "Black")
        {
            coltype = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        }
        normalfontsize=objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        boldfontsize=objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        string bgcolor_uni = "";
        /* if (bgcolor != "0" && bgcolor != "" && bgcolor != "White")
             bgcolor_uni = "<¶>" + bgcolor + "</¶>";
         if(bgcolor.ToUpper()=="YELLOW")
             bgcolor_uni="æYæ";
         else if (bgcolor.ToUpper()=="CYAN")
             bgcolor_uni="æBæ";
         else if (bgcolor.ToUpper()=="PINK")
             bgcolor_uni="æMæ";
          else if (bgcolor.ToUpper()=="ORANGE")
             bgcolor_uni="æGæ";*/
        // else if (bgcolor=="PINK")
        //    bgcolor_uni="æpæ";
        //string[] strarr;
        char[] strarr;
        string[] strArrSplit;
        string dataSplit = "";
        float width1 = 0;
        string final = "";
        string fstFName = "";//***************
        string fileData = "";//***************
        if (caption != "")
        {
            string cap = caption;
            cap = cap.Replace("<font face=TimesEuropa Roman>", "");
            cap = cap.Replace("</font>", "");
            cap = cap.Replace("<FONT FACE=TimesEuropa Roman>", "");
            cap = cap.Replace("</FONT>", "");
            cap = cap.Replace("<FONT face=TimesEuropa Roman>", "");
            cap = cap.Replace("<font face=Satluj>", "");
            cap = cap.Replace("</font>", "");
            cap = cap.Replace("<FONT FACE=Satluj>", "");
            cap = cap.Replace("<FONT face=Satluj>", "");
            cap = cap.Replace("</FONT>", "");
            cap = cap.Replace("<FONT face=Satluj>", "");
            cap = cap.Replace("<font face=Satluj>", "");
            cap = cap.Replace("<font face=Chanakya>", "");
            cap = cap.Replace("<FONT face=Chanakya>", "");
            cap = cap.Replace("<FONT FACE=Chanakya>", "");
            cap = cap.Replace("<FONT face=Chanakya>", "");
            if (caption.IndexOf("TimesEuropa Roman") > 0)
            {
                fileData = fileData + "<*C*p(0,11,0,10,0,0,g,\"International English\")><z10f\"TimesEuropa Roman\"><B>" + cap + "<$>\r\n";
            }
            else
            {
                fileData = fileData + "<*C*p(0,11,0,13,0,0,g,\"International English\")><z12f\"SHREE-KAN-0850\"><B>" + cap + "<$>\r\n";
            }
        }
        int divwidth = widthD;
        int height = 0;
        int dropcap = 0;
        string leading = "0";
        string eyecatcher = Request.QueryString["eyecatch"].ToString();// "?";
        int eyecatcherlen = Convert.ToInt32(Request.QueryString["eyecatchlen"].ToString());
        if (eyecatcher != "" && eyecatcherlen == 0)
            eyecatcherlen = 2;
        /*this is to get the eyecatcher if present*/
        if (objDataSetbu.Tables.Count - 1 >= 2 && objDataSetbu.Tables[2].TableName == "dropcap")
        {
            eyecatcher = "DR";
            eyecatcherlen = Convert.ToInt32(objDataSetbu.Tables[2].Rows[0].ItemArray[1].ToString());
        }

        string logo_name = Request.QueryString["logo_name"].ToString();
        mod_log = Request.QueryString["modify_logo"].ToString();
        /////////////////////////////////////////

        string eyecatchstr = "";
        string eyecatchfont = "";
        if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "BO0" && eyecatcher != "" && eyecatcher != "0")
            txtcolor = "RED";
        if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "0" && eyecatcher != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bulletmaster clsbullet = new NewAdbooking.Classes.bulletmaster();
                DataSet ds = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.bulletmaster clsbullet = new NewAdbooking.classesoracle.bulletmaster();
                    DataSet ds = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                    eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    eyecatchfont = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    NewAdbooking.classmysql.bulletmaster clsbullet = new NewAdbooking.classmysql.bulletmaster();
                    DataSet ds = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                    eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                }
        }
        if (eyecatcher != "0" && eyecatcher != "" && eyecatcherlen > 1)
        {
            dropcap = eyecatcherlen;
        }
        if (eyecatcher == "BO0")
            dropcap = 0;
        string temp_date = data.Replace(comcharf + comcharl, "");
        string[] arr_bold = temp_date.Split(' ');


        //this is to use that if 35 character comes first or 5 words which comes first that has to be bold
        /*   if (objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString() == "5")
           {
               if (arr_bold.Length >= 4)
               {
                   string temp_com = "";
                   string con = "";
                   for (int s = 0; s < arr_bold.Length; s++)
                   {
                       temp_com = arr_bold[s];
                       if (con != "")
                       {
                           con = con + temp_com;
                       }
                       else
                       {
                           con = temp_com;
                       }
                       if (con.Length >= 35)
                       {
                           chklen = "c";
                           break;
                       }
                       if (s == 4)
                       {
                           if (con.Length >= 35)
                           {
                               chklen = "c";
                               break;
                           }
                           else
                           {
                               chklen = "w";
                               break;
                           }
                       }
                   }
               }
               else
               {
                   chklen = "c";
               }
           }*/

        if (kop != "1")
        {
            data = data.Replace("\r\n", "");
            data = data.Replace("\r", "");
            data = data.Replace("\n", "");
        }
        data = data.Replace("TimesEuropa Roman", "TimesEuropaRoman");
        strarr = data.ToCharArray();
        strArrSplit = data.Split(" ".ToCharArray());
        data = data.Replace("TimesEuropaRoman", "TimesEuropa Roman");
        // new change for split array
        ArrayList newarr = new ArrayList();

        int index = 0;
        for (int n = 0; n < strArrSplit.Length; n++)
        {
            if (strArrSplit[n].IndexOf("TimesEuropaRoman") >= 0 && strArrSplit[n].IndexOf("Satluj") >= 0)
            {
                string maindata = strArrSplit[n].ToString();
                while (maindata.IndexOf("TimesEuropaRoman") >= 0 || maindata.IndexOf("Satluj") >= 0)
                {
                    string mdata = "";
                    if ((maindata.IndexOf("TimesEuropaRoman") >= 0 && maindata.IndexOf("Satluj") < 0) || (maindata.IndexOf("TimesEuropaRoman") < 0 && maindata.IndexOf("Satluj") >= 0))
                        mdata = maindata.Substring(0, maindata.LastIndexOf(comcharl) + 2);
                    else
                        mdata = maindata.Substring(0, maindata.IndexOf(comcharl) + 2);

                    // newarr[index] = mdata;
                    if (maindata == strArrSplit[n].ToString())
                        newarr.Add(" " + mdata);
                    else
                        newarr.Add(mdata);
                    if ((maindata.IndexOf("TimesEuropaRoman") >= 0 && maindata.IndexOf("Satluj") < 0) || (maindata.IndexOf("TimesEuropaRoman") < 0 && maindata.IndexOf("Satluj") >= 0))
                        maindata = maindata.Substring(maindata.LastIndexOf(comcharl) + 2, (maindata.Length) - (maindata.LastIndexOf(comcharl) + 2));
                    else
                        maindata = maindata.Substring(maindata.IndexOf(comcharl) + 2, (maindata.Length) - (maindata.IndexOf(comcharl) + 2));
                    index = index + 1;
                }

            }
            else if (strArrSplit[n].IndexOf("TimesEuropaRoman") >= 0 && strArrSplit[n].IndexOf("Chanakya") >= 0)
            {
                string maindata = strArrSplit[n].ToString();
                while (maindata.IndexOf("TimesEuropaRoman") >= 0 || maindata.IndexOf("Chanakya") >= 0)
                {
                    string mdata = "";
                    if ((maindata.IndexOf("TimesEuropaRoman") >= 0 && maindata.IndexOf("Chanakya") < 0) || (maindata.IndexOf("Chanakya") < 0 && maindata.IndexOf("Chanakya") >= 0))
                        mdata = maindata.Substring(0, maindata.LastIndexOf(comcharl) + 2);
                    else
                        mdata = maindata.Substring(0, maindata.IndexOf(comcharl) + 2);

                    // newarr[index] = mdata;
                    if (maindata == strArrSplit[n].ToString())
                        newarr.Add(" " + mdata);
                    else
                        newarr.Add(mdata);
                    if ((maindata.IndexOf("TimesEuropaRoman") >= 0 && maindata.IndexOf("Chanakya") < 0) || (maindata.IndexOf("TimesEuropaRoman") < 0 && maindata.IndexOf("Chanakya") >= 0))
                        maindata = maindata.Substring(maindata.LastIndexOf(comcharl) + 2, (maindata.Length) - (maindata.LastIndexOf(comcharl) + 2));
                    else
                        maindata = maindata.Substring(maindata.IndexOf(comcharl) + 2, (maindata.Length) - (maindata.IndexOf(comcharl) + 2));
                    index = index + 1;
                }

            }
            else
            {

                //newarr[index] = strArrSplit[n];
                if (n == 0)
                    newarr.Add(strArrSplit[n]);
                else
                    newarr.Add(" " + strArrSplit[n]);
                index = index + 1;
            }
        }
        //
        int strlength = 0;

        //float fontsi = Convert.ToInt64(fontsize);
        float fontsi = float.Parse(fontsize);

        //for (int i = 0; i < strarr.Length; i++,totalchar++)
        for (int i = 0; i < newarr.Count; i++, totalchar++)
        {

            string fname = "";
            string fdata = "";
            float f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString());//6.2F;
            leading = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();//8F;
            fdata = newarr[i].ToString();
            fdata = fdata.Replace("TimesEuropaRoman", "TimesEuropa Roman");
            if (fdata.IndexOf(comcharf) >= 0)
            {
                string[] arrfdata;
                editorfornt = "TimesEuropa Roman";
                /* if (fdata.IndexOf("{Times New Roman}") == 0 || fdata.IndexOf("{Times New Roman}") == 0 && (fdata.IndexOf("{SHREE-KAN-0850}") > 0))
                 {
                     fdata = fdata.Replace("{Times New Roman}", "");
                     fdata = fdata.Replace("{Times New Roman}", "");
                 }
                 else if (fdata.IndexOf("{SHREE-KAN-0850}") == 0 && (fdata.IndexOf("{Times New Roman}") == 0 || fdata.IndexOf("{Times New Roman}") == 0))
                 {
                     fdata = fdata.Replace("{SHREE-KAN-0850}", "");

                 }*/
                if (fdata.IndexOf(comcharf + "TimesEuropa Roman" + comcharl) >= 0 || fdata.IndexOf(comcharf + "TimesEuropa Roman" + comcharl) >= 0)
                {
                    fdata = fdata.Replace(comcharf + "TimesEuropa Roman" + comcharl, "");
                    //  fdata = fdata.Replace("{SHREE-KAN-0850}", "");
                    fdata = fdata.Replace(comcharf + "TimesEuropa Roman" + comcharl, "");
                    fdata = fdata.Replace(comcharf + comcharl, "");
                    // arrfdata = fdata.Split('{');
                    //fdata = arrfdata[0];
                    editorfornt = "TimesEuropa Roman";
                }
                else
                {
                    if (fdata.IndexOf(comcharf + "Chanakya" + comcharl) >= 0)
                    {
                        fdata = fdata.Replace(comcharf + "Chanakya" + comcharl, "");
                        //   fdata = fdata.Replace("{Times New Roman}", "");
                        //  fdata = fdata.Replace("{Times New Roman}", "");
                        fdata = fdata.Replace(comcharf + comcharl, "");
                        //   arrfdata = fdata.Split('{');
                        // fdata = arrfdata[0];
                        editorfornt = "Chanakya";
                    }
                    else if (fdata.IndexOf(comcharf + "Satluj" + comcharl) >= 0)
                    {
                        fdata = fdata.Replace(comcharf + "Satluj" + comcharl, "");
                        //   fdata = fdata.Replace("{Times New Roman}", "");
                        //  fdata = fdata.Replace("{Times New Roman}", "");
                        fdata = fdata.Replace(comcharf + comcharl, "");
                        //   arrfdata = fdata.Split('{');
                        // fdata = arrfdata[0];
                        editorfornt = "Satluj";
                    }

                }
                fdata = fdata.Replace(comcharf + comcharl, "");
                //else
                //{
                //    arrfdata = fdata.Split('{');
                //    fdata = arrfdata[0];
                //    editorfornt = arrfdata[1].Replace("}", "");
                //}

                if (editorfornt == "")
                {
                    fontname = fontname;
                }
                else
                {
                    fontname = editorfornt;
                }
                if (objDataSetbu.Tables[0].Columns.Count > 7)
                {
                    if (fontname == "TimesEuropa Roman")
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString());
                        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();//8F;
                    }
                    else if (fontname == "Chanakya")
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString());
                        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();//8F;
                    }
                    else if (fontname == "Satluj")
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString());
                        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();//8F;
                    }
                   
                }
               

            }
            fontsize = f_.ToString();

            if (fdata != comcharf && fdata != comcharl)
            {
               

                if (editorfornt != "")
                {
                    fname = editorfornt;
                    fname_bold = fname;
                }

                System.Drawing.Font f;

                if (style == 0)
                    f = new System.Drawing.Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 1)
                    f = new System.Drawing.Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 2)
                    f = new System.Drawing.Font(fname, f_);
                else if (style == 3)
                    f = new System.Drawing.Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 4)
                    f = new System.Drawing.Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 5)
                    f = new System.Drawing.Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 7)
                    f = new System.Drawing.Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else
                    f = new System.Drawing.Font(fname, f_, GraphicsUnit.Point);

                //if (eyecatcherlen > 1 && count <= Convert.ToInt32(eyecatcherlen))
                //{
                //    width1 = 0;
                //    f = new Font(fname_bold, f_, FontStyle.Bold);
                //    Font eyef;
                //    eyef = new Font(eyecatchfont, f_);
                //    k = a.MeasureString(eyecatchstr, eyef);
                //    width1 = width1 + k.Width;
                //}
                //else
                //{
                //    width1 = 0;
                //}
                if (dataSplit == "")
                {
                    dataSplit = fdata;
                }
                else
                {
                    dataSplit = dataSplit + " " + fdata;
                }
                //if(i!=0)
                //{
                fdata = fdata;
                //}
                if (fdata != "")
                {
                    k = a.MeasureString(dataSplit, f);
                    float sz_width = MeasureDisplayStringWidth(a, fdata, f);
                    k.Width = sz_width;
                    height = Convert.ToInt32(k.Height);
                    double tot_wid = (divwidth + colwidth * 2.54) + colwidth;
                    // if ((k.Width + width1) - (colwidth * 2.54) >= tot_wid)
                    //if (width1 >= tot_wid)

                    // double logohei_1 = Convert.ToDouble(logohei) * 3.77;
                    string val_ = "3.77";
                    //new change
                    string[] fdata1;
                    if (checkHY == true)
                    {

                        fdata1 = fdata.Split("-".ToCharArray());
                        hy = hy + 1;
                        sz_width = MeasureDisplayStringWidth(a, fdata1[hy].ToString().Trim(), f);
                        k.Width = sz_width;

                        if (hy == fdata1.Length - 1)
                        {
                            fdata = fdata1[hy].ToString().Trim() + " ";
                            checkHY = false;
                            hy = 0;
                        }
                        else
                        {
                            fdata = fdata1[hy].ToString().Trim() + "-";

                        }

                    }
                    //if ((sz_width + width1) >= divwidth)
                    if ((sz_width + width1) >= 92) // 92 for 3.1 col width
                    {
                        if (fdata.IndexOf("-") >= 0 && fdata.IndexOf("-") != fdata.Length - 1)
                        {
                            fdata1 = fdata.Split("-".ToCharArray());
                            if (checkHY == true)
                            {
                                sz_width = MeasureDisplayStringWidth(a, fdata1[hy].ToString().Trim(), f);
                                k.Width = sz_width;
                                fdata = fdata1[hy].ToString().TrimEnd() + " ";
                                checkHY = false;
                            }
                            else
                            {
                                sz_width = MeasureDisplayStringWidth(a, fdata1[hy].ToString().Trim() + "-", f);
                                k.Width = sz_width;
                                fdata = fdata1[hy].ToString().TrimEnd() + "-";
                                checkHY = true;
                                // i--;
                            }
                        }
                    }
                    if (checkHY == true)
                        i--;
                    // end
                    if ((sz_width + width1) >= 92)// 92 for 3.1 colwidth
                    {

                        float w = k.Width;
                        final = final.Substring(0, final.Length);
                        mFinal = mFinal.Substring(0, mFinal.Length);

                        /*in case of kop after enter every first line is bold*/
                        if (mFinal.LastIndexOf("\r\n") >= 0 && mFinal.LastIndexOf("\r\n") != prevmat && kop == "1")// for kompas
                        {
                            prevmat = mFinal.LastIndexOf("\r\n");
                            string finaltemp = final.Substring(mFinal.LastIndexOf("\r\n"));
                            finaltemp = finaltemp.Replace("\r\n", "\r\n<b>") + "</b>";
                            string finalprev = final.Substring(0, mFinal.LastIndexOf("\r\n"));
                            final = finalprev + finaltemp;

                            string mfinaltemp = mFinal.Substring(mFinal.LastIndexOf("\r\n"));
                            mfinaltemp = mfinaltemp.Replace("\r\n", "\r\n<b>") + "</b>";
                            string mfinalprev = mFinal.Substring(0, mFinal.LastIndexOf("\r\n"));
                            mFinal = mfinalprev + mfinaltemp;
                            //mFinal=mFinal.Replace("\r\n","\r\n<b>")+"</b>";

                        }

                        if (final.IndexOf("\\l") < 0 && style == 1)
                        {
                            //style = 2;

                            final = "<b>" + final + "</b>";
                        }

                        if (mFinal.IndexOf("\\l") < 0 && style == 1)
                        {
                            style = 2;
                            mFinal = "<b>" + mFinal + "</b>";
                            combinfdata = "";
                        }

                        if (mFinal.IndexOf("\\l") < 0 && style == 7)
                        {
                            style = 2;
                            mFinal = "<u><b>" + mFinal + "</b></u>";
                            combinfdata = "";
                        }

                        final = final + "\\l<font face=" + fname + " style='font-size:" + fontsize + "pt'>" + fdata + "</font> ";

                        count = count + 1;


                        kopcount = kopcount + 1;

                        width1 = w;
                        if (dropcap > 1)
                        {
                            if (dropcap == count)
                                dropcap = 0;
                            //k = a.MeasureString(eyecatchstr, f);
                            width1 = width1 + 10;
                        }
                        dataSplit = fdata;
                        if (firstFontName == "Satluj" || firstFontName == "Chanakya")
                        {
                            htFinal += "</H></l>{" + (charperline) + "}<l>";// +fdata;
                            if (characterline == "")
                                characterline = Convert.ToString(charperline);
                            else
                                characterline = characterline + "," + Convert.ToString(charperline);
                        }
                        else
                        {
                            htFinal += "</E></l>{" + (charperline) + "}<l>";// +fdata;
                            if (characterline == "")
                                characterline = Convert.ToString(charperline);
                            else
                                characterline = characterline + "," + Convert.ToString(charperline);
                        }
                        charperline = 0;
                        charperline = fdata.Length;

                        //******************************************************************//

                        if (final == "")
                        {
                            if (objDataSetbu.Tables[0].Columns.Count > 6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850"
                            {

                                if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();

                            }
                            else
                            {
                                if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                                // htFinal += "<E>" + fdata;
                            }
                        }
                        else if (fstFName == fname)
                        {
                            if (firstFontName == f.FontFamily.Name.ToString())
                            {
                                htFinal += fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                            }
                            else
                            {
                                if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                            }
                            //htFinal += fdata;
                        }
                        else
                        {
                            if (firstFontName == f.FontFamily.Name.ToString())
                            {
                                htFinal += fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                            }
                            else
                            {
                                if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                            }
                            //////if (objDataSetbu.Tables[0].Columns.Count>6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850")
                            //////    htFinal += "</E><H>" + fdata;
                            //////else
                            //////    htFinal += "</H><E>" + fdata;
                        }

                        //*****************************************************************//


                        if (final == "")
                        {
                            fstFName = fname;
                            if (dropcap > 1)
                            {
                                if (eyecatcher == "DR")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {

                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;

                                    }
                                    else
                                    {
                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }

                                else if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "BO0")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {
                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }
                            }
                            else if (eyecatcher == "BO0" || eyecatcher == "BO1" || style == 1)
                            {
                                if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                {
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                }
                                else
                                {
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                }
                            }
                            else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                            {
                                if (style == 3 || style == 1)
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                else
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            }
                            else
                            {
                                if (style == 3 || style == 1)
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                else
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            }

                            // mFinal = mFinal + "\\l<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                            if (ConfigurationSettings.AppSettings["LINEBREAK"].ToString() == "Y")
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            else
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            if (style == 1)
                                fileData = fileData + "<$>";
                            mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                            sFinal = sFinal + "\\l<font face=" + fname + ">" + fdata;
                        }

                        else if (fstFName == fname)
                        {
                            if (style == 2 && tstyle == 3)
                            {
                                fileData = fileData + fdata + "<$>";
                                tstyle = 2;
                            }
                            else
                                fileData = fileData + fdata;
                            mFinal = mFinal + "\\l" + fdata;
                            sFinal = sFinal + "\\l" + fdata;
                            if (ConfigurationSettings.AppSettings["LINEBREAK"].ToString() == "Y")
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "\r\n" + fdata;
                                //  fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            else
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + fdata;
                                //  fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                        }
                        else
                        {
                            fstFName = fname;
                            if (style == 2 && tstyle == 3)
                            {
                                fileData = fileData + "<$><*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                tstyle = 0;
                            }
                            else
                            {
                                if (style == 3 || style == 1)
                                    fileData = fileData + "<$><*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                else
                                    fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            }
                            mFinal = mFinal + "</font>";
                            mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                            sFinal = sFinal + "</font>" + "\\l<font face=" + fname + ">" + fdata;
                            if (ConfigurationSettings.AppSettings["LINEBREAK"].ToString() == "Y")
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            else
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                        }

                        combinfdata = "";
                        if (k.Width + width1 != divwidth)
                        {
                            width1 = w;
                        }
                        //if (eyecatchstr != "")
                        //    width1 = width1 + 10;

                    }
                    else
                    {
                        charperline += fdata.Length;
                        if (eyecatchstr != "" && i == 0)
                            width1 = width1 + 10;
                        width1 = width1 + k.Width;
                        //////////////////
                        if (objDataSetbu.Tables[0].Columns.Count > 6)
                        {
                            if (final == "")
                            {
                                if (objDataSetbu.Tables[0].Columns.Count > 6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850"
                                {

                                    if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                        htFinal += "<H>" + fdata;
                                    else
                                        htFinal += "<E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();

                                }
                                else
                                {
                                    if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                        htFinal += "<H>" + fdata;
                                    else
                                        htFinal += "<E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                    // htFinal += "<E>" + fdata;
                                }
                            }
                            else if (fstFName == fname)
                            {
                                if (firstFontName == f.FontFamily.Name.ToString())
                                {
                                    htFinal += fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                }
                                else
                                {
                                    if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                        htFinal += "</E><H>" + fdata;
                                    else
                                        htFinal += "</H><E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                }
                                //htFinal += fdata;
                            }
                            else
                            {
                                if (firstFontName == f.FontFamily.Name.ToString())
                                {
                                    htFinal += fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                }
                                else
                                {
                                    if (f.FontFamily.Name == "Satluj" || f.FontFamily.Name == "Chanakya")
                                        htFinal += "</E><H>" + fdata;
                                    else
                                        htFinal += "</H><E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                }
                                //////if (objDataSetbu.Tables[0].Columns.Count>6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850")
                                //////    htFinal += "</E><H>" + fdata;
                                //////else
                                //////    htFinal += "</H><E>" + fdata;
                            }
                        }

                        /////////////////
                        //htFinal += fdata;
                        if (i == strarr.Length - 1)
                        {
                            if (final == "")
                            {
                                fstFName = fname;
                                if (dropcap > 1)
                                {
                                    if (eyecatcher == "DR")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }

                                    else if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "BO0")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }
                                }
                                else if (eyecatcher == "BO0" || eyecatcher == "BO1" || style == 1)
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                    else
                                    {
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                }
                                else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                {
                                    if (style == 3 || style == 1)
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;

                                }
                                else
                                {
                                    if (style == 3 || style == 1)
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;

                                }
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "<font face=" + fname + ">" + fdata;
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }

                            else if (fstFName == fname)
                            {
                                if (style == 2 && tstyle == 3)
                                {
                                    fileData = fileData + fdata + "<$>";
                                    tstyle = 0;
                                }
                                else
                                    fileData = fileData + fdata;
                                mFinal = mFinal + fdata;
                                sFinal = sFinal + fdata;
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + fdata;
                            }
                            else
                            {
                                fstFName = fname;
                                if (style == 2 && tstyle == 3)
                                {
                                    tstyle = 0;
                                    fileData = fileData + "<$><*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                else
                                {
                                    if (style == 3 || style == 1)
                                        fileData = fileData + "<$><*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                mFinal = mFinal + "</font>";
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "</font>" + "<font face=" + fname + ">" + fdata;
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            //mFinal = mFinal + "</font>";
                            //***************************************
                            final = final + "<font face=" + fname + " style='font-size:" + fontsize + "pt'>" + fdata + "</font>";
                        }
                        else
                        {
                            if (final == "")
                            {
                                fstFName = fname;
                                if (dropcap > 1 && i == 0)
                                {
                                    if (eyecatcher == "DR")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }

                                    else if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "BO0")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }
                                }
                                else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                    else
                                    {
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                }
                                else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                {
                                    if (style == 3 || style == 1)
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                else
                                {
                                    if (style == 3 || style == 1)
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "<font face=" + fname + ">" + fdata;
                            }

                            else if (fstFName == fname)
                            {
                                if (style == 2 && tstyle == 3)
                                {
                                    fileData = fileData + fdata + "<$>";
                                    tstyle = 0;
                                }
                                else
                                    fileData = fileData + fdata;
                                mFinal = mFinal + fdata;
                                sFinal = sFinal + fdata;
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + fdata;
                            }
                            else
                            {
                                fstFName = fname;
                                if (style == 2 && tstyle == 3)
                                    fileData = fileData + "<$><*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                else
                                {
                                    if (style == 3 || style == 1)
                                        fileData = fileData + "<$><*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,11,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                mFinal = mFinal + "</font>";
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "</font>" + "<font face=" + fname + ">" + fdata;
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                    fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            //mFinal = mFinal + "</font>";
                            //***************************************
                            final = final + "<font face=" + fname + " style='font-size:" + fontsize + "pt'>" + fdata + "</font>";
                        }

                    }
                    if (dropcap > 1 && i == 0)
                    {
                        if (eyecatcher == "DR")
                        {
                            //mFinal = mFinal + "</font>";
                            final = "<span style=\"border:1px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1).ToUpper() + "</span>" + fdata.Substring(1, fdata.Length - 1);
                            mFinal = "<span style=\"border:1px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1).ToUpper() + "</span>" + fdata.Substring(1, fdata.Length - 1);
                        }
                        else
                        {
                            if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "BO0" && eyecatcher != "0" && eyecatcher != "")
                            {
                                //mFinal = mFinal + "</font>";
                                //if (eyecatcher == "HR")
                                //{
                                //    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                //    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
                                //}
                                //else
                                //{

                                final = "<span style=\"border:1px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                mFinal = "<span style=\"border:1px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
                                //}
                            }
                        }
                        //final = "<span style=\"border:1px solid;float:left;font-size:12px;font-family:Arial;padding:1px;line-height:1em;\">" + final.Substring(0, 1) + "</span>" + final.Substring(1, final.Length - 1);
                    }
                    else
                    {
                        if (eyecatcher != "0" && i == 0 && eyecatcher != "")
                        {
                            if (eyecatcher != "DR" && eyecatcher != "BO")
                            {
                                //if (eyecatcher == "HR")
                                //{
                                //    final = "<span style=\"border:0px solid;float:left;font-size:11px;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                //    mFinal = "<span style=\"border:0px solid;float:left;font-size:11px;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
                                //}
                                //else
                                //{
                                if (eyecatcher != "BO0" && eyecatcher != "BO1")
                                {
                                    final = "<span style=\"border:1px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                    mFinal = "<span style=\"border:1px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
                                }
                                // }
                            }

                        }
                    }

                    /*for bold we have to use the different font*/
                    if (style == 0)
                    {
                        style = 2;
                        final = "<b>" + final + "</b>";
                        mFinal = "<b>" + mFinal + "</b>";
                    }

                    if (style == 3 && i == 1)
                    {
                        style = 2;
                        final = "<b>" + final + "</b>";
                        mFinal = "<b>" + mFinal + "</b>";
                        fileData = fileData + "<$>";
                        tstyle = 0;
                    }

                    if (chklen == "c" && style == 5) // for kompas
                    {
                        if (style == 5 && i == 34)
                        {
                            style = 2;
                            final = "<b>" + final + "</b>";
                            mFinal = "<b>" + mFinal + "</b>";
                            //chklen = "1";
                        }
                    }
                    else if (style == 5 && chklen == "w")
                    {

                        if (contain != "")
                        {
                            contain = contain + fdata;
                        }
                        else
                        {
                            contain = fdata;
                        }
                        string[] arr_contain = null;
                        arr_contain = contain.Split(' ');
                        if (style == 5 && arr_contain.Length > 5)
                        {
                            style = 2;
                            final = "<b>" + final + "</b>";
                            mFinal = "<b>" + mFinal + "</b>";
                        }
                    }

                    f.Dispose();
                }
            }
        }
        if (style == 4)
        {
            final = "<b>" + final + "</b>";
            mFinal = "<b>" + mFinal + "</b>";
        }
        if (eyecatcher == "BO0")
        {
            final = "<b>" + final + "</b>";
            mFinal = "<b>" + mFinal + "</b>";
        }
        if (objDataSetbu.Tables[0].Columns.Count > 6)
        {
            if (firstFontName == "Satluj" || firstFontName == "Chanakya")
                htFinal += "</H>";
            else
                htFinal += "</E>";
            ////if (editorfornt == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850"
            ////    htFinal += "</H>";
            ////else
            ////    htFinal += "</E>";
        }

        if (dsbgcolcode.Tables.Count > 0 && dsbgcolcode.Tables[0].Rows.Count > 0)
        {
            if (objDataSetbu.Tables[0].Columns.Count > 6)
            {
                if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850")
                {
                    htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}ŸhŸæ" + dsbgcolcode.Tables[0].Rows[0].ItemArray[0].ToString() + "æ";
                }
                else
                {
                    htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}æ" + dsbgcolcode.Tables[0].Rows[0].ItemArray[0].ToString() + "æ";
                }
            }
            else
            {
                htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}æ" + dsbgcolcode.Tables[0].Rows[0].ItemArray[0].ToString() + "æ";
            }
        }
        else
        {
            if (objDataSetbu.Tables[0].Columns.Count > 6)
            {
                if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"SHREE-KAN-0850")
                {
                    htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}ŸhŸ";
                }
                else
                {
                    htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}";
                }
            }
            else
            {
                htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}";
            }
        }
        fontsize = "8";
        mFinal = mFinal.Trim();
        mFinal = mFinal + "</font>";
        sFinal = sFinal.Trim();
        sFinal = sFinal + "</font>";
        final = final.Replace("\\l", "<br>");
        if (ConfigurationSettings.AppSettings["LINEBREAK"].ToString() == "Y")
        {
            mFinal = mFinal.Replace("\\l", "<br>");
        }
        else
        {
            mFinal = mFinal.Replace("\\l", "");
        }
        sFinal = sFinal.Replace("\\l", "");
        fileData_indesign = fileData_indesign + "\r\n<cTypeface:><cSize:><cLeading:><cFont:><pRuleBelowOffset:><pRuleBelowLeftIndent:><pRuleBelowRightIndent:><pTextAlignment:>";
        string bPrem = "";
        if (Request.QueryString["bPrem"] != null)
        {
            bPrem = Request.QueryString["bPrem"].ToString();
        }
        if (bPrem == "")
        {
            bPrem = "0";
        }
        int c1 = 0;
        if (eyecatchtype == "S")
        {
            //c1 = Convert.ToInt32(bPrem) + count;
            c1 = count = Convert.ToInt32(bPrem) + count;
        }
        if (uom_desc == "ROL" || uom_desc == "ROD")
        {
            if (uom_desc == "ROD" && kop == "1")
            {
                string[] arrmatter = mFinal.Split("\r".ToCharArray());
                count = count + arrmatter.Length - 1;
                c1 = c1 + arrmatter.Length - 1;
            }
            else
            {
                c1 = count;
            }
            //ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev_new), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + c1.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + c1.ToString() + ";", true);
        }
        else if (uom_desc == "ROW")
        {
            int words = strarr.Length;
            int rwcount = countword(strarr, words);
            int word1 = strarr.Length;
            if (eyecatchtype == "S")
            {
                //word1 = Convert.ToInt32(bPrem) + words;
                rwcount = Convert.ToInt32(bPrem) + rwcount;
            }

            //ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev_new), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + rwcount.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + rwcount.ToString() + ";", true);
        }
        else if (uom_desc == "ROC")
        {

            int words = strarr.Length;
            int word1 = strarr.Length;
            if (eyecatchtype == "S")
            {
                word1 = Convert.ToInt32(bPrem) + words;
            }

            //ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev_new), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + word1.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + word1.ToString() + ";", true);
        }

        ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev_new), "zz1", "parentid('" + Hiddeninser.Value + "');", true);
        int h = Convert.ToInt32(height) * (count + 1);
        //  h = h + (height / 2);
        if (txtcolor == "RED")
            txtcolor = "";
        int wid;
        if (eyecatcher == "BO")
        {
            wid = divwidth;// +20;//180;
            if (caption == "")
            {
                final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + final + "</div></div>";
                mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div></div>";
            }
            else
            {
                final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><b>" + caption + "</b>" + final + "</div></div>";
                mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><b>" + caption + "</b>" + mFinal + "</div></div>";
            }

            //td1.InnerHtml = final;
            mFinal = mFinal.Replace("<br>", "");
            if (Request.QueryString["boxcode"].ToString() != "0")
            {
                mFinal = mFinal.Replace(Request.QueryString["boxcode"].ToString(), "<font class=boxmatter>" + Request.QueryString["boxcode"].ToString() + "</font>");
            }
            mFinal = mFinal.Replace("", "");
            td1.InnerHtml = mFinal;
        }
        else //if (uom_desc != "ROD")
        {
            wid = divwidth;// +20;//180;
            if (dropcap > 1)
            {
                // wid = 180;// 
                wid = divwidth;// +20;
            }

            string[] splitter = mFinal.Split("<br>".ToCharArray());

            //  divwidth = divwidth - 13;
            
            if (centertitle != "")
            {
                if (caption == "")
                {
                    abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div>";
                    def = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:0px Groove;LETTER-SPACING: 0px;line-height:7.5pt;width:" + wid + "px;\"></div>";
                }
                else
                {
                    abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><b>" + caption + "</b>" + mFinal + "</div>";
                    def = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:0px Groove;LETTER-SPACING: 0px;line-height:8pt;width:" + wid + "px;\"><b>" + caption + "</b></div>";
                }
            }
            else
            {
                if (caption == "")
                {
                    abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div>";
                    def = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:0px Groove;LETTER-SPACING: 0px;line-height:8pt;width:" + wid + "px;\"></div>";
                }
                else
                {
                    abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><b>" + caption + "</b>" + mFinal + "</div>";
                    def = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:0px Groove;LETTER-SPACING: 0px;line-height:8pt;width:" + wid + "px;\"><b>" + caption + "</b></div>";
                }
            }
            // abc = abc.Replace("<br>", "");
            abc = abc.Replace("\r\n", "");
            abc = abc.Replace("\r", "");
            abc = abc.Replace("\n", "");
            if (language == "3")
            {
                if (abc.IndexOf("font-size") >= 0)
                {
                    int leng = abc.IndexOf("font-size");
                    int leng1 = abc.IndexOf(";bac");
                    string abc1 = "";
                    if (leng < leng1)
                    {
                        abc1 = abc.Substring(leng, 14);
                        abc = abc.Replace(abc1, "");
                    }
                    else
                    { }


                }
            }
           
            abc = abc.Replace("", "");
            td1.InnerHtml = abc;
            if (eyecatcher == "BO0")// FOR BOX
            {
                fileData = fileData + "<$>";
            }
            fileData = fileData + bgcolor_uni;

            if (eyecatcher == "BO")// FOR BOX
            {
                fileData = fileData + "<ÿ>box</ÿ>";
            }
            //else if (eyecatcher == "" || eyecatcher == "0")
            //{
            //    fileData = fileData + "<æ>bold</æ>";
            //}
            //  fileData = fileData + "<l>"+count+"</l>";
            fileData = fileData.Replace("<BR>", "");
            fileData = fileData.Replace("<br>", "");
            if (characterline != "")
                characterline = characterline + "," + Convert.ToString(charperline);
            else
                characterline = Convert.ToString(charperline);
            //  fileData = fileData + "<{>"+characterline+"</}>";
        }
        ///////////////////////////////////////////////////////bhanu start ////////
        if (logo_name!="")
            if (Session["Tempimgname_logo"] == null)
            {
                //if (File.Exists(Server.MapPath("./temp logo/") + logo_name + ".jpg") == true)
                //    src_name = Server.MapPath("./temp logo/") + logo_name + ".jpg";
                //else if (File.Exists(Server.MapPath("./temp logo/") + logo_name + ".tiff") == true)
                //    src_name = Server.MapPath("./temp logo/") + logo_name + ".tiff";
                //else if (File.Exists(Server.MapPath("./temp logo/") + logo_name + ".tif") == true)
                //    src_name = Server.MapPath("./temp logo/") + logo_name + ".tif";
                //else
                    src_name = Server.MapPath("./temp logo/") + logo_name + ".jpg";
            }
            else
            {
                src_name = Server.MapPath("./temppdf/") + Session["Tempimgname_logo"].ToString().Replace(".pdf", ".jpg").Replace(".eps", ".jpg");
            }
        ////////////////////////////////////////bhanu code end///////////
        //******************************************************************************************
        string receiptno = "";//= Request.QueryString["boxno"].ToString();
        if (receiptno == "")
            receiptno = cioid;
        if (insertid == "no")
        {
            // fileName = cioid + "-All";
            //fileName = copy_cioid + "-All";
            fileName = receiptno + "-All";
        }
        else
        {
            //fileName = cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
            //fileName = copy_cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
            fileName = receiptno + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        }
        danish = danish.Replace("\r\n", "");
        danish = danish.Replace(" ", "");
        boldcharcount = charcount(matter);
        if (matter.IndexOf("</P><P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>") >= 0)
        {
            string caption2 = matter.Substring(0, matter.IndexOf("</P><P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("</P><P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("</P><P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("</P><P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>", "</P><P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("</P><P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("</P><P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("</P><P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("</P><P><FONT face=\"TimesEuropa Roman\"></FONT> </P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("</P><P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>", "</P><P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("<P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("<P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("<P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("<P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("<P><STRONG><FONT face=\"TimesEuropa Roman\"></FONT></STRONG> </P><P>", "<P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("<P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("<P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("<P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("<P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("<P><FONT face=\"TimesEuropa Roman\"></FONT> </P><P>", "<P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("</P><P><FONT face=ESangbadlight></FONT> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("</P><P><FONT face=ESangbadlight></FONT> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("</P><P><FONT face=ESangbadlight></FONT> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("</P><P><FONT face=ESangbadlight></FONT> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("</P><P><FONT face=ESangbadlight></FONT> </P><P>", "</P><P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("</P><P><FONT face=ESangbadlight><STRONG></STRONG></FONT> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("</P><P><FONT face=ESangbadlight><STRONG></STRONG></FONT> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("</P><P><FONT face=ESangbadlight><STRONG></STRONG></FONT> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("</P><P><FONT face=ESangbadlight><STRONG></STRONG></FONT> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("</P><P><FONT face=ESangbadlight><STRONG></STRONG></FONT> </P><P>", "</P><P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("<P><FONT face=ESangbadlight></FONT> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("<P><FONT face=ESangbadlight></FONT> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("<P><FONT face=ESangbadlight></FONT> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("<P><FONT face=ESangbadlight></FONT> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("<P><FONT face=ESangbadlight></FONT> </P><P>", "<P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("</P><P><STRONG><FONT face=ESangbadlight></FONT></STRONG> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("</P><P><STRONG><FONT face=ESangbadlight></FONT></STRONG> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("</P><P><STRONG><FONT face=ESangbadlight></FONT></STRONG> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("</P><P><STRONG><FONT face=ESangbadlight></FONT></STRONG> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("</P><P><STRONG><FONT face=ESangbadlight></FONT></STRONG> </P><P>", "</P><P>");
            matter = matter.Replace(matter4, matter5);

        }
        else if (matter.IndexOf("</P><P> </P><P>") >= 0)
        {

            string caption2 = matter.Substring(0, matter.IndexOf("</P><P> </P><P>"));
            string matter2 = matter.Substring(matter.IndexOf("</P><P> </P><P>"), matter.Length - caption2.Length);
            string matter3 = matter2.Replace("</P><P> </P><P>", "");
            string matter4 = matter3.Substring(0, matter3.IndexOf("</P>"));
            string matter5 = matter4.Replace("<FONT ", "<FONT style=\"font-size:12pt;line-height:12pt;text-align:center \"");
            matter = matter.Replace("</P><P> </P><P>", "</P><P>");
            matter = matter.Replace(matter4, matter5);

        }
        matter = matter.Replace("<STRONG>", "<STRONG><font size=\"2\">");
        matter = matter.Replace("</STRONG>", "</font></STRONG>");
        matter = matter.Replace("<FONT face=ESangbadlight", "<FONT style=\"font-size:10pt;\" face=ESangbadlight");
        matter = matter.Replace("<FONT face=ESangbadplight", "<FONT style=\"font-size:10pt;\" face=ESangbadplight");
        matter = matter.Replace("<FONT face=\"TimesEuropa Roman\"", "<FONT style=\"font-size:8pt;\" face=\"TimesEuropa Roman\"");

        string[] arr2 = Regex.Split(matter, "<STRONG><font size=\"2\">");
        int countrow2 = arr2.Length;
        string mat="";
        for (int i = 0; i < countrow2-1; i++)
       {
            int engindex=0;
            int hindex=0;
            int nindex=0;
            engindex=arr2[i].ToString().LastIndexOf("TimesEuropa Roman");
            hindex=arr2[i].ToString().LastIndexOf("ESangbadlight");
            nindex=arr2[i].ToString().LastIndexOf("ESangbadplight");
            if(engindex>hindex && engindex>nindex)
            {
                mat=mat+arr2[i].ToString()+"<STRONG><font size=\"2\">";
            }
            else
            {
                 mat=mat+arr2[i].ToString()+"<STRONG><font size=\"3\">";
            }
          
        }
        mat = mat + arr2[countrow2 - 1].ToString();
        matter = mat;
        //count = createPdf(matter, abc, def, fileName, logowid, logohei, wid, src_name,normalfontsize,boldfontsize);
        //genpdf.Service p = new Service();
        //count = p.createPdf(matter, abc, def, fileName, logowid, logohei, wid, src_name, normalfontsize, boldfontsize);
        allcount = allcharcount(danish);
        count = allcount;
        string t_fileName = fileName + ".pdf";
        createJpg(t_fileName);
        ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev_new), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + count.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + count.ToString() + ";window.opener.document.getElementById('hiddenboldchar').value=" + boldcharcount.ToString() + ";", true); 
        // fileName = fileName + ".txt";// for indesign
        string imgprev = Server.MapPath("~/jpgprev/" + fileName + ".jpg");
        fileName = fileName + ".xtg";// for quark
        
        xyz1 = "<div style=\"position:absolute;\">" + " <img src=\"s.aspx?p=" + imgprev + "\"/>" + "</div>";
        td1.InnerHtml = xyz1;
        System.IO.Directory.CreateDirectory(Server.MapPath("xtg"));
        FileStream fs = null;

        //fs = new FileStream(path + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
        fs = new FileStream(Server.MapPath("xtg") + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
        fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND}", "");
        fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND", "");

        // fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND}", "");
        if (style == 4)
        {
            fileData_indesign = fileData_indesign.Replace("cTypeface:Normal", "cTypeface:Bold");
            fileData_indesign = fileData_indesign.Replace("cTypeface:Regular", "cTypeface:Bold");
        }
        // sw.Write(fileData_indesign);// for indesign XTG
        sw.Write(fileData);// FOR QUARK
        // sw.WriteLine(htFinal);

        sw.Flush();
        sw.Dispose();
        fs.Dispose();

       

        Session["fileName"] = fileName;
        ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev_new), "FN", "window.opener.document.getElementById('hiddenFileName').value='" + fileName.ToString() + "';", true);

        //////sw.WriteLine(fileData);

        //////sw.Flush();
        //////sw.Dispose();
        //////fs.Dispose();

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

        mFinal = mFinal.Replace("<b>", "");
        mFinal = mFinal.Replace("</b>", "");
        mFinal = mFinal.Replace("&amp;", "&");
        mFinal = mFinal.Replace("&gt;", ">");
        mFinal = mFinal.Replace("&lt;", "<");
        dr_data["cioid"] = cioid.ToString();

        dr_data["filename"] = fileName.ToString();
        if (box_matter != "")
        {
            box_matter = box_matter.Replace("FONT", "font");
            sFinal = sFinal.Replace(box_matter, "");
            box_matter = box_matter.Replace("<font face=TimesEuropa Roman>", "");
            box_matter = box_matter.Replace("</font>", "");
            sFinal = sFinal.Replace(box_matter, "");
        }
        sFinal = sFinal.Replace("&amp;", "&");
        sFinal = sFinal.Replace("&gt;", ">");
        sFinal = sFinal.Replace("&lt;", "<");
        sFinal = sFinal.Replace("style='font-size:8pt'", "");
        sFinal = sFinal.Replace("style='font-size:7pt'", "");
        sFinal = sFinal.Replace("style='font-size:6pt'", "");
        sFinal = sFinal.Replace("style='font-size:6.2pt'", "");
        //if (caption != "")
        //    dr_data["rtfformat"] = caption.ToString() + "<br>" + sFinal.ToString();
        //else
        //{
        //    dr_data["rtfformat"] = sFinal.ToString();
        //} matter
        if (caption != "")
            dr_data["rtfformat"] = matter.ToString();
        else
        {
            dr_data["rtfformat"] = matter.ToString();
        } //matter
        fileData = fileData.Replace("&amp;", "&");
        fileData = fileData.Replace("&gt;", ">");
        fileData = fileData.Replace("&lt;", "<");
        fileData = fileData.Replace("<P>", "");
        fileData = fileData.Replace("</P>", "");
        fileData = fileData.Replace("", "");
        dr_data["xtgformat"] = fileData.ToString();//fileData_indesign.ToString();//fileData.ToString();//fileData.ToString();
        if (box_matter != "")
            Session["matterText_session"] = Session["matterText_session"].ToString().Replace(box_matter, "");
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

        Session["saveColor"] = txtcolor;
        Session["savedata"] = ds_data;
        Session["copy_matter"] = null;
       // string pdfFileName = "orignal%20logo/" + cioid + "/B-" + fileName.Replace("xtg", "pdf");
       // iframe.Attributes["src"] = "http://localhost:1120/webdir/" + pdfFileName;
     // iframe.Attributes.Add("src","Orignal Logo//"+cioid+"//B-"+fileName.Replace("xtg","pdf"));
        //**************iframe**********************************************************************************   
    }

    private void bindData(string fil)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("S.No", typeof(string));
        dt.Columns.Add("grdImage", typeof(string));
        DataRow dr;
        int i = 1;
        //foreach (string file1 in Directory.GetFiles("Temp logo" + "/" + fil));
        if (mod_log == "0" && filename_pdf != ".pdf" && filename_pdf != ".pdf" && filename_pdf != ".tiff" && filename_pdf != ".tif" && previousid == "")
        {
            foreach (string file in Directory.GetFiles(Server.MapPath("Temp logo") + "\\", fil))
            {
                dr = dt.NewRow();
                dr[0] = i.ToString();
                dr[1] = ResolveUrl("ThumbnailCreator.aspx?ImageId=" + file);
                dt.Rows.Add(dr);
                i += 1;
            }
        }
        else if ((mod_log != "0" || previousid != "") && filename_pdf != ".pdf" && filename_pdf != ".eps" && filename_pdf != ".tiff" && filename_pdf != ".tif")
        {
            string patth_lo = "";
            if (previousid != "")
            {
                //dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
                patth_lo = Server.MapPath("Orignal Logo" + "/" + previousid + "/");
            }
            else
            {
                patth_lo = Server.MapPath("Orignal Logo" + "/" + cioid + "/");
            }
            foreach (string file in Directory.GetFiles(patth_lo + "\\", fil))
            {
                dr = dt.NewRow();
                dr[0] = i.ToString();
                dr[1] = ResolveUrl("ThumbnailCreator.aspx?ImageId=" + file);
                dt.Rows.Add(dr);
                i += 1;
            }

        }
        else if (mod_log == "0" && (filename_pdf == ".pdf" || filename_pdf == ".eps" || filename_pdf == ".tiff" || filename_pdf == ".tif") && previousid == "")
        {
            foreach (string file in Directory.GetFiles(Server.MapPath("Temppdf") + "\\", fil))
            {
                dr = dt.NewRow();
                dr[0] = i.ToString();
                dr[1] = ResolveUrl("ThumbnailCreator.aspx?ImageId=" + file);
                dt.Rows.Add(dr);
                i += 1;
            }
        }
        else if ((mod_log != "0" || previousid != "") && (filename_pdf == ".pdf" || filename_pdf == ".eps" || filename_pdf == ".tiff" || filename_pdf == ".tif"))
        {
            string patth_lo = "";
            if (previousid != "")
            {
                //dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
                patth_lo = Server.MapPath("Orignal Logo" + "/" + previousid + "/");
            }
            else
            {
                patth_lo = Server.MapPath("Orignal Logo" + "/" + cioid + "/" + fil);
            }
            if (filename_pdf == ".pdf")
            {
                if (previousid != "")
                {
                    //dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + previousid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.pdf"), true);
                }
                else
                {
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + cioid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.pdf"), true);
                }
                createjpgfrompdf("xyz.pdf");
            }
            else if (filename_pdf == ".eps")
            {
                if (previousid != "")
                {
                    //dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + previousid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.eps"), true);
                }
                else
                {
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + cioid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.eps"), true);
                }
                createjpgfrompdf("xyz.eps");
            }
            else if (filename_pdf == ".tif")
            {
                if (previousid != "")
                {
                    //dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + previousid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.tif"), true);
                }
                else
                {
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + cioid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.tif"), true);
                }
                createjpgfrompdf("xyz.tif");
            }
            else if (filename_pdf == ".tiff")
            {
                if (previousid != "")
                {
                    //dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + previousid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.tiff"), true);
                }
                else
                {
                    System.IO.File.Copy(Server.MapPath("Orignal Logo" + "/" + cioid + "/" + fil), Server.MapPath("Temppdf/" + "xyz.tiff"), true);
                }
                createjpgfrompdf("xyz.tiff");
            }

            foreach (string file in Directory.GetFiles(Server.MapPath("Temppdf") + "\\", "xyz.jpg"))
            {
                dr = dt.NewRow();
                dr[0] = i.ToString();
                dr[1] = ResolveUrl("ThumbnailCreator.aspx?ImageId=" + file);
                dt.Rows.Add(dr);
                i += 1;
            }
        }

        src_name = dt.Rows[0].ItemArray[1].ToString();

    }

    /* [Ajax.AjaxMethod]
     public DataSet getthemaxlines(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string noof_insert, string lines, string adcat3, string adcat4, string adcat5, string clientname, string noof_line, string dateformat, string uomdesc)
     {
         DataSet dr = new DataSet();

         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {

             NewAdbooking.Classes.BookingMaster rate = new NewAdbooking.Classes.BookingMaster();

            // dr = rate.class_getrate_qbc(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines,  adcat3, adcat4, adcat5, clientname, noof_line, uomdesc);

             return dr;
         }

         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.BookingMaster rate = new NewAdbooking.classesoracle.BookingMaster();

                 dr = rate.getmaxline(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, adcat3, adcat4, adcat5, clientname, noof_line, dateformat, uomdesc);

                 return dr;
             }
             else
             {

                 NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();


                 datesavemysql convertmysql = new datesavemysql();
                 if (selecdate != "")
                 {
                     selecdate = convertmysql.getDate(dateformat, selecdate);
                 }
                 //(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, adcat3, adcat4, adcat5, clientname, noof_line, dateformat, uomdesc);
                 dr = clsbooking.getmaxlines(package, noof_insert, selecdate, selecdate, dateformat, compcode, adcat, adsucat, color, adtype, currency, ratecode, selecdate, "", package, "", uom, "", "", noof_insert, noof_line, adcat3, adcat4, adcat5, clientname, uomdesc);

                 return dr;
             }

        


     }

     [Ajax.AjaxMethod]
     public DataSet getthemaxlines_agency(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string noof_insert, string lines, string adcat3, string adcat4, string adcat5, string clientname, string noof_line, string dateformat, string uomdesc,string agencycode)
     {
         NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
         DataSet dr = new DataSet();

         datesavemysql convertmysql = new datesavemysql();
         if (selecdate != "")
         {
             selecdate = convertmysql.getDate(dateformat, selecdate);
         }
         //(adtype, color, adcat, adsucat, currency, ratecode, package, selecdate, compcode, uom, noof_insert, lines, adcat3, adcat4, adcat5, clientname, noof_line, dateformat, uomdesc);
         dr = clsbooking.getmaxlines_agency(package, noof_insert, selecdate, selecdate, dateformat, compcode, adcat, adsucat, color, adtype, currency, ratecode, selecdate, "", package, "", uom, "", "", noof_insert, noof_line, adcat3, adcat4, adcat5, clientname, uomdesc, agencycode);

         return dr;

     }
     */
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
            p2 = Server.MapPath("") + "\\";
            p1 = Server.MapPath("Temppdf/");
        }
        string finalnam = filname;
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
        b1.Dispose();
        b1 = null;
    }

    protected void writefile(string fname, string sdata)
    {
        StreamWriter myStreamWriter;

        myStreamWriter = File.CreateText(fname);
        myStreamWriter.Write(sdata);
        myStreamWriter.Flush();
        myStreamWriter.Close();
    }

    protected int countword(char[] str, int len1)
    {
        int rwcount = 1;
        string matterW = Session["matterText_session"].ToString().Trim();
        matterW = matterW.Replace("\r\n", " ");
        matterW = matterW.Replace("<br>", " ");
        matterW = matterW.Replace("<BR>", " ");
        string matterWordCount = matterW.ToString().Trim();
        if (boxmatter_string != "")
        {
            matterWordCount = matterWordCount + " " + boxmatter_string;
        }
        rwcount = matterWordCount.Split(" ".ToCharArray()).Length;
        string[] arr = matterWordCount.Split(" ".ToCharArray());
        int countrow = rwcount;
        for (int i = 0; i < rwcount; i++)
        {
            if (arr[i].ToString() == " " || arr[i].ToString() == "")
            {
                countrow = countrow - 1;
            }
        }
        return countrow;
    }

    static public float MeasureDisplayStringWidth(Graphics graphics, string text, System.Drawing.Font font)
    {
        const int width = 37; //33;

        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, 1, graphics);
        SizeF layoutSize = new SizeF(117F, 50.0F);
        System.Drawing.SizeF size = graphics.MeasureString(text, font, layoutSize);
        System.Drawing.Graphics anagra = System.Drawing.Graphics.FromImage(bitmap);

        float measured_width = (float)size.Width;
        return measured_width;
    }
    /*public int createPdf(string matterhtml, string iHTML, string deshtma, string filename, string l_width, string l_height, int wid_l, string source,string n_fontsize,string b_fontsize)
    {
        string header = "<HTML><HEAD></HEAD><BODY><table><tr><td>";
        string footer = "</td></tr></table></BODY></HTML>";
        string innerhtml = deshtma;
        innerhtml = innerhtml.Replace("</div>",  matterhtml + "</div>");
        innerhtml = header + innerhtml + footer;
        innerhtml = innerhtml.Replace("<table", "<table cellpadding=\"0\" cellspacing=\"0\" width=100%");
        //innerhtml = innerhtml.Replace("font-size:8pt;","");
        //int ht = Convert.ToInt32(l_height * .75) + 2;font-size:8pt;
        innerhtml = innerhtml.Replace("border:0px Groove;", "");
        innerhtml = innerhtml.Replace("position:absolute;", "");
        innerhtml = innerhtml.Replace("<STRONG>", "<STRONG style=\"font-size:" + b_fontsize + "px;\">");
        int wd = wid_l;
        string ffilename = Server.MapPath("Orignal Logo/") + filename.Split('-')[0];
        if (System.IO.Directory.Exists(ffilename) == false)
            System.IO.Directory.CreateDirectory(ffilename);

        //if (File.Exists(Server.MapPath("temp/" + filename + ".html")) == true)
        //    File.Delete(Server.MapPath("temp/" + filename + ".html"));
        if (File.Exists(ffilename + "\\" + filename + ".pdf") == true)
            File.Delete(ffilename + "\\" +  filename + ".pdf");
        if (File.Exists(ffilename + "\\" + filename + ".eps") == true)
            File.Delete(ffilename + "\\" +  filename + ".eps");
        StreamWriter myStreamWriter = File.CreateText(Server.MapPath("temp/" + filename + ".html"));
        myStreamWriter.Write(innerhtml, System.Text.Encoding.UTF8);
        myStreamWriter.Flush();
        myStreamWriter.Close();
        iTextSharp.text.Rectangle rp1 = new iTextSharp.text.Rectangle(wd, 1800);
        float thidh1 = 0;
        bool k1 = false;
        int line_count = 0;
    d5:
        string lcount = "";
        Document document1 = new Document(rp1, 0, 0, 0, 0);
        PdfWriter writerd = PdfWriter.getInstance(document1, new FileStream((ffilename + "\\" + filename + ".pdf"), FileMode.Create));
        document1.Open();
        iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
        System.Collections.Generic.List<iTextSharp.text.IElement> ob;
        StreamReader rd = new StreamReader(Server.MapPath("temp/" + filename + ".html"), System.Text.Encoding.UTF8);
        if (source != "")
        {
            source = source.Replace("\\temppdf\\", "\\Temp logo\\");
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(source);
            //jpg.ScaleToFit(98, l_height);
            jpg.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
            document1.Add(jpg);
        }
        ob = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(rd, styles);
        for (int k = 0; k < ob.Count; k++)
        {
            document1.Add((IElement)ob[k]);
            if (ob[k].Type == 23)
            {
              thidh1 = thidh1 + ((iTextSharp.text.pdf.PdfPTable)ob[k]).TotalHeight;
            }
        }
        rd.Close();
        rd.Dispose();
        document1.Close();
        if (k1 == false)
        {

            k1 = true;
            if (source != "")
            {
                line_count = Convert.ToInt32((thidh1 - 5.9) / 7.75);
                thidh1 = Convert.ToSingle(thidh1 + (Convert.ToInt32(l_height)*10)+115);
                thidh1 = thidh1 + Convert.ToSingle(.5);
                rp1 = new iTextSharp.text.Rectangle(wd, thidh1);
                
            }
            else
            {
                line_count = Convert.ToInt32((thidh1 - 5.9) / 7.75);
                thidh1 = Convert.ToSingle(thidh1);
                thidh1 = thidh1 + Convert.ToSingle(.5);
                rp1 = new iTextSharp.text.Rectangle(wd, thidh1);
            }
            goto d5;
        }
        return line_count;

    }*/
    public int charcount(string matterhtml1)
    {
        string strongmatter = matterhtml1;
       string boldcharacter = "";
       DataSet dschar = new DataSet();
       if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
       {
           NewAdbooking.Classes.BookingMaster getBox = new NewAdbooking.Classes.BookingMaster();
           dschar = getBox.getbengali();

       }

       else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
       {
           NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
           dschar = getBox.getbengali();
       }
       //char[] arr = boldcharacter.Split("".ToCharArray());
       while (strongmatter.IndexOf("<STRONG>") > 0)
       {
           boldcharacter = boldcharacter + strongmatter.Substring(strongmatter.IndexOf("<STRONG>") + 8, strongmatter.IndexOf("</STRONG>") - strongmatter.IndexOf("<STRONG>") - 8);
           boldcharacter = boldcharacter.Replace(" ", "");
           boldcharacter = HtmlRemoval.StripTagsRegex(boldcharacter);
           boldcharacter = HtmlRemoval.StripTagsRegexCompiled(boldcharacter);
           boldcharacter = HtmlRemoval.StripTagsCharArray(boldcharacter);
           

           strongmatter = strongmatter.Substring(strongmatter.IndexOf("</STRONG>") + 9);
       }

       char[] arr = boldcharacter.ToCharArray();
    
       int boldlen = boldcharacter.Length;
       if (dschar.Tables.Count > 0 && dschar.Tables[0].Rows.Count > 0)
       {
           for (int i = 0; i < arr.Length; i++)
           {
               for (int j = 0; j < dschar.Tables[0].Rows.Count; j++)
               {
                   if (arr[i].ToString() == dschar.Tables[0].Rows[j].ItemArray[0].ToString())
                   {
                       boldlen = boldlen - 1;
                       j = dschar.Tables[0].Rows.Count;
                   }
               }
           }
       }
       
    
       return boldlen;
    }
    public void createJpg(string filname)
    {
        ProcessStartInfo ProcessInfo;
        Process Process;
        int ExitCode;
        Bitmap b1;
        Bitmap b2;
        string p2 = "";
        string p1 = "";
        string p3 = "";
        string ffilename = Server.MapPath("Orignal Logo/") + filname.Split('-')[0];
        if (System.IO.Directory.Exists(ffilename) == false)
            System.IO.Directory.CreateDirectory(ffilename);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            p2 = Server.MapPath("~/");
            p3 = Server.MapPath("~/jpgprev/");
            p1 = ffilename + "\\"; // Server.MapPath("//temppdf/");
        }
        else
        {
            p2 = Server.MapPath("~/");
            p3 = Server.MapPath("~/jpgprev/");
            p1 = ffilename + "\\"; // Server.MapPath("~/temppdf/");
        }
        string finalnam = filname;
        ////string ori_wid;
        ////if (logowid == "1")
        ////{
        ////    ori_wid = Request.QueryString["hiddenwidth"];
        ////}
        ////else
        ////{
        ////    ori_wid = logowid;
        ////}
        ////string Pix_height = Convert.ToInt32((float.Parse(logohei) * 3.78)).ToString();
        ////string Pix_wid = Convert.ToInt32((float.Parse(ori_wid) * 3.78)).ToString();

        // ProcessInfo = new ProcessStartInfo(p2 + "convert.exe", "\"" + p1 + finalnam + "\" -density 72x72  -units PixelsPerInch -thumbnail " + Pix_wid + "x" + Pix_height + " \"" + p1 + finalnam.ToLower().Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg") + "\"");
        ProcessInfo = new ProcessStartInfo(p2 + "convert.exe", "\"" + p1  + finalnam + "\" \"" + p1 + finalnam.ToLower().Replace(".pdf", ".jpg").Replace(".tiff", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg") + "\"");
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.UseShellExecute = false;
        Process = Process.Start(ProcessInfo);

        Process.WaitForExit(70000);
        ExitCode = Process.ExitCode;
        Process.Close();

        string con = p1 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg");
        b1 = new Bitmap(con);
        System.Drawing.Image bmp2 = b1.GetThumbnailImage(Convert.ToInt32(b1.Width), Convert.ToInt32(b1.Height), null, IntPtr.Zero);
        //con = con.Replace(con, p3+finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"));
        bmp2.Save(p3 + finalnam.Replace(".tiff", ".jpg").Replace(".pdf", ".jpg").Replace(".tif", ".jpg").Replace(".eps", ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
        bmp2.Dispose();
        b1.Dispose();
        GC.Collect();

        if (File.Exists(con) == true)
            File.Delete(con);

    }

    public int allcharcount(string matterhtml1)
    {
        string strongmatter = matterhtml1;
        string boldcharacter = matterhtml1;
        DataSet dschar = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getBox = new NewAdbooking.Classes.BookingMaster();
            dschar = getBox.getbengali();

        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
            dschar = getBox.getbengali();
        }
        //char[] arr = boldcharacter.Split("".ToCharArray());
        //while (strongmatter.IndexOf("<STRONG>") > 0)
        //{
        //    boldcharacter = boldcharacter + strongmatter.Substring(strongmatter.IndexOf("<STRONG>") + 8, strongmatter.IndexOf("</STRONG>") - strongmatter.IndexOf("<STRONG>") - 8);
            boldcharacter = HtmlRemoval.StripTagsRegex(boldcharacter);
            boldcharacter = HtmlRemoval.StripTagsRegexCompiled(boldcharacter);
            boldcharacter = HtmlRemoval.StripTagsCharArray(boldcharacter);


        //    strongmatter = strongmatter.Substring(strongmatter.IndexOf("</STRONG>") + 9);
        //}

        char[] arr = boldcharacter.ToCharArray();

        int boldlen = boldcharacter.Length;
        if (dschar.Tables.Count > 0 && dschar.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < arr.Length; i++)
            {
				if (arr.Length > (i + 1))
                    if (arr[i].ToString() + arr[i + 1].ToString() == "i§" || arr[i].ToString() + arr[i + 1].ToString() == "øž")
                {
                    boldlen = boldlen - 1;
                    
                }
                if (arr.Length > (i + 1) && arr.Length > (i + 2))
                    if (arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() == "ã¸â" || arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() == "26Ã" || arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() == "KI×" || arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() == "LaÏ" || arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() == "ËLa")
                    {
                        boldlen = boldlen - 1;

                    }
                if (arr.Length > (i + 1) && arr.Length > (i + 2) && arr.Length > (i + 3))
                    if (arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() + arr[i + 3].ToString() == "ý3ÃÃ" )
                    {
                        boldlen = boldlen - 1;

                    }
                if (arr.Length > (i + 1))
                    if (arr[i].ToString() + arr[i + 1].ToString() == "Âó")
                    {
                        boldlen = boldlen + 1;

                    }
                //if (arr.Length > (i + 1) && arr.Length > (i + 2))
                //    if (arr[i].ToString() + arr[i + 1].ToString() + arr[i + 2].ToString() == "¿Âó")
                //    {
                //        boldlen = boldlen + 1;

                //    }
                for (int j = 0; j < dschar.Tables[0].Rows.Count; j++)
                {
                    if (arr[i].ToString() == dschar.Tables[0].Rows[j].ItemArray[0].ToString())
                    {
                        boldlen = boldlen - 1;
                        j = dschar.Tables[0].Rows.Count;
                    }
                      
                }
            }
        }


        return boldlen;
    }
}
