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

public partial class matterprevLine : System.Web.UI.Page
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
                    if ( newdata.Length>=2 && newdata.Substring(newdata.Length - 2) != "}~" )
                    {
                        // if (newdata.LastIndexOf("}~") != newdata.ToString().Length - 2 || newdata.LastIndexOf(" ") != newdata.ToString().Length - 1)
                        if (newdata.LastIndexOf(" ") != newdata.ToString().Length - 1)
                            newdata = newdata + "~{" + trufont + "}~";
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
                    if (a.IndexOf("Helvetica") > 0)
                    {
                        if (curfont == "")
                            curfont = "Helvetica";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "Helvetica";
                        }
                    }
                    else
                    {
                        if (curfont == "")
                            curfont = "HINDBODY";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "HINDBODY";
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
                    newdata = newdata + "~{" + curfont + "}~" + a;
                else
                {
                    newdata = newdata + a;
                }

            }
            else
                newdata = newdata + a;
        }
        if (newdata.Length >= 2 && newdata.Substring(newdata.Length - 2) != "}~")
            newdata = newdata + "~{" + trufont + "}~";
        if (newdata.IndexOf("~{Helvetica}~") >= 0 || newdata.IndexOf("~{helvetica}~") >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (newdata.IndexOf("~{HINDBODY}~") >= 0)
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
                    fontname = "Helvetica";
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
                                    finaldata = arr[i].ToString() + "{" + fontname + "}";
                                }
                                else
                                {
                                    finaldata = finaldata + " " + arr[i].ToString() + "{" + fontname + "}";
                                }
                            }
                            else
                            {
                                finaldata = finaldata + arr[i].ToString() + "{" + fontname + "}";
                            }

                        }
                        else
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
        if (finaldata.IndexOf("{Helvetica}") >= 0 || finaldata.IndexOf("{helvetica}") >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (finaldata.IndexOf("{HINDBODY}") >= 0)
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
        Response.Expires = -1;
        Response.Cache.SetNoStore();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
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


        previousid = Request.QueryString["previd"].ToString();
        /////////////////////////////////////////


        /*new change ankur for matter*/
        logohei = Request.QueryString["logohei"].ToString();
        logowid = Request.QueryString["logowid"].ToString();

        //matter = Request.QueryString["matter"].ToString();//Session["matter"].ToString();
        /*new change ankur for matter*/
        matter = Session["matter_session"].ToString().Trim();
        matter = matter.Replace("^", "#");
        danish = Session["matterText_session"].ToString();
        DataSet dsboxmatter = new DataSet();
        //Request.QueryString["boxno"].ToString() in this query string we are fetching receipt number.
        //if (Session["revenue"].ToString() != "")
        //{
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getBox = new NewAdbooking.Classes.BookingMaster();
           // dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());
          //  dsboxmatter = getBox.autogenratedbox(Session["compcode"].ToString(), "", "", Session["center"].ToString(), Session["agency_name"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
            //dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());
            dsboxmatter = getBox.autogenratedbox(Session["compcode"].ToString(), "", "", Session["center"].ToString(), Session["agency_name"].ToString(),Session["revenue"].ToString(),"");
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getBox = new NewAdbooking.classmysql.BookingMaster();
            dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());

        }
        string box_matter = "";
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
        boxmatter_string = box_matter;
        if (box_matter != "")
            box_matter = "<FONT face=Helvetica>" + box_matter + "</FONT>";
        if (box_matter != "")
            matter = matter.Replace(box_matter, "");
        matter = matter + box_matter;
        uom = Request.QueryString["hiddenuom"].ToString();
       // Hiddeninser.Value = Request.QueryString["hiddeninsert"].ToString();

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
       // Ajax.Utility.RegisterTypeForAjax(typeof(matterprev));


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
          //  dsbgcolcode = getbgcode.getbgcolcode(bgcolor);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getbgcode = new NewAdbooking.classesoracle.BookingMaster();
            dsbgcolcode = getbgcode.getbgcolcode(bgcolor);
        }


        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/" + sSheet + ".xml"));
        data = enterSpace(matter);
        Graphics a;
        double colwidth = Convert.ToDouble(Request.QueryString["hiddenwidth"]);//3.8;
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
        widthD = widthD + 1;
        a = Graphics.FromImage(bmpDummy);
        a.PageUnit = GraphicsUnit.Point;
        /*in this we have taken he bold description*/
        int style = 0;
        if (objDataSetbu.Tables[1].TableName == "bold")
        {
            style = Convert.ToInt32(objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString());//0 means first word bold and 1 means two words bold 2 means first line bold
        }
        else
        {
            style = 2;
        }
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


        SizeF k;
        string fontname = fontDefault;
        string fontsize = "0";
        int count = 1;
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

        string bgcolor_uni = "";
        if (bgcolor != "0" && bgcolor != "" && bgcolor != "White")
            bgcolor_uni = "<¶>" + bgcolor + "</¶>";
        //if(bgcolor=="GREEN")
        //    bgcolor_uni="ægæ";
        //else if (bgcolor=="ORANGE")
        //    bgcolor_uni="æmæ";
        //else if (bgcolor=="YELLOW")
        //    bgcolor_uni="æyæ";
        // else if (bgcolor=="BLUE")
        //    bgcolor_uni="æcæ";
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
        int divwidth = widthD;
        int height = 0;
        int dropcap = 0;
        string leading = "0";
        string eyecatcher = Request.QueryString["eyecatch"].ToString();// "?";
        int eyecatcherlen = Convert.ToInt32(Request.QueryString["eyecatchlen"].ToString());

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
        string temp_date = data.Replace("{}", "");
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
        strarr = data.ToCharArray();
        strArrSplit = data.Split(" ".ToCharArray());
        // new change for split array
        ArrayList newarr = new ArrayList();

        int index = 0;
        for (int n = 0; n < strArrSplit.Length; n++)
        {
            if (strArrSplit[n].IndexOf("Helvetica") >= 0 && strArrSplit[n].IndexOf("HINDBODY") >= 0)
            {
                string maindata = strArrSplit[n].ToString();
                while (maindata.IndexOf("Helvetica") >= 0 || maindata.IndexOf("HINDBODY") >= 0)
                {
                    string mdata = "";
                    if ((maindata.IndexOf("Helvetica") >= 0 && maindata.IndexOf("HINDBODY") < 0) || (maindata.IndexOf("Helvetica") < 0 && maindata.IndexOf("HINDBODY") >= 0))
                        mdata = maindata.Substring(0, maindata.LastIndexOf("}~") + 2);
                    else
                        mdata = maindata.Substring(0, maindata.IndexOf("}~") + 2);

                    // newarr[index] = mdata;
                    if (maindata == strArrSplit[n].ToString())
                        newarr.Add(" " + mdata);
                    else
                        newarr.Add(mdata);
                    if ((maindata.IndexOf("Helvetica") >= 0 && maindata.IndexOf("HINDBODY") < 0) || (maindata.IndexOf("Helvetica") < 0 && maindata.IndexOf("HINDBODY") >= 0))
                        maindata = maindata.Substring(maindata.LastIndexOf("}~") + 2, (maindata.Length) - (maindata.LastIndexOf("}~") + 2));
                    else
                        maindata = maindata.Substring(maindata.IndexOf("}~") + 2, (maindata.Length) - (maindata.IndexOf("}~") + 2));
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
            if (fdata.IndexOf("~{") >= 0)
            {
                string[] arrfdata;
                editorfornt = "Helvetica";
                /* if (fdata.IndexOf("{Helvetica}") == 0 || fdata.IndexOf("{helvetica}") == 0 && (fdata.IndexOf("{HINDBODY}") > 0))
                 {
                     fdata = fdata.Replace("{Helvetica}", "");
                     fdata = fdata.Replace("{helvetica}", "");
                 }
                 else if (fdata.IndexOf("{HINDBODY}") == 0 && (fdata.IndexOf("{Helvetica}") == 0 || fdata.IndexOf("{helvetica}") == 0))
                 {
                     fdata = fdata.Replace("{HINDBODY}", "");

                 }*/
                if (fdata.IndexOf("~{Helvetica}~") >= 0 || fdata.IndexOf("~{helvetica}~") >= 0)
                {
                    fdata = fdata.Replace("~{Helvetica}~", "");
                    //  fdata = fdata.Replace("{HINDBODY}", "");
                    fdata = fdata.Replace("~{helvetica}~", "");
                    fdata = fdata.Replace("~{}~", "");
                    // arrfdata = fdata.Split('{');
                    //fdata = arrfdata[0];
                    editorfornt = "Helvetica";
                }
                else
                {
                    if (fdata.IndexOf("~{HINDBODY}~") >= 0)
                    {
                        fdata = fdata.Replace("~{HINDBODY}~", "");
                        //   fdata = fdata.Replace("{Helvetica}", "");
                        //  fdata = fdata.Replace("{helvetica}", "");
                        fdata = fdata.Replace("~{}~", "");
                        //   arrfdata = fdata.Split('{');
                        // fdata = arrfdata[0];
                        editorfornt = "HINDBODY";
                    }

                }
                fdata = fdata.Replace("~{}~", "");
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
                    if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY"
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString());//8F;
                        if (objDataSetbu.Tables[0].Columns.Count > 8 && objDataSetbu.Tables[0].Rows[0].ItemArray[8] != null)
                            leading = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();//8F;
                    }
                }
                if (fontcntr > 1)
                {
                    if (objDataSetbu.Tables[0].Columns.Count > 6)
                    {
                        if (editorfornt == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY"
                            f_ = (float)Convert.ToDouble(objDataSetbu.Tables[2].Rows[0].ItemArray[1].ToString());//7F;
                        else
                            f_ = (float)Convert.ToDouble(objDataSetbu.Tables[2].Rows[0].ItemArray[0].ToString());//6F;
                        leading = objDataSetbu.Tables[2].Rows[0].ItemArray[2].ToString();
                    }
                }

            }
            fontsize = f_.ToString();

            if (fdata != "~{" && fdata != "}~")
            {
                /*  if (chklen == "w" && style == 5 && i <= 4)
                  {
                      if (fname == "" && style == 5 && i <= 4)
                      {
                          fname = fname_bold;
                      }
                      else
                      {
                          fname = fontname;
                      }
                  }
                  else if (chklen == "c" && style == 5 && i <= 35)
                  {
                      if (fname == "" && style == 5 && i <= 35)
                      {
                          fname = fname_bold;
                      }
                      else
                      {
                          fname = fontname;
                      }

                  }
                  else
                  {
                      fname = fontname;
                  }
                  if (style == 1)
                  {
                      fname = fname_bold;
                  }
                  else if(style!=5)
                  {
                      fname = fontname;
                  }*/

                if (editorfornt != "")
                {
                    fname = editorfornt;
                    fname_bold = fname;
                }

                Font f;

                if (style == 0)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 1)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 2)
                    f = new Font(fname, f_);
                else if (style == 3)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 5)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 7)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else
                    f = new Font(fname, f_, GraphicsUnit.Point);

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
                        if (firstFontName == "HINDBODY")
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
                            if (objDataSetbu.Tables[0].Columns.Count > 6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY"
                            {

                                if (f.FontFamily.Name == "HINDBODY")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();

                            }
                            else
                            {
                                if (f.FontFamily.Name == "HINDBODY")
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
                                if (f.FontFamily.Name == "HINDBODY")
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
                                if (f.FontFamily.Name == "HINDBODY")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                            }
                            //////if (objDataSetbu.Tables[0].Columns.Count>6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY")
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
                                        fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }

                                else if (eyecatcher != "DR" && eyecatcher != "BO")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {
                                        fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }
                            }
                            else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                            {
                                if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                {
                                    fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                }
                                else
                                {
                                    fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                }
                            }
                            else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                            {
                                fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            }
                            else
                            {
                                fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                            }

                            // mFinal = mFinal + "\\l<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                            mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                            sFinal = sFinal + "\\l<font face=" + fname + ">" + fdata;
                        }

                        else if (fstFName == fname)
                        {
                            fileData = fileData + fdata;
                            mFinal = mFinal + "\\l" + fdata;
                            sFinal = sFinal + "\\l" + fdata;
                        }
                        else
                        {
                            fstFName = fname;
                            fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            mFinal = mFinal + "</font>";
                            mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                            sFinal = sFinal + "</font>" + "\\l<font face=" + fname + ">" + fdata;
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
                                if (objDataSetbu.Tables[0].Columns.Count > 6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY"
                                {

                                    if (f.FontFamily.Name == "HINDBODY")
                                        htFinal += "<H>" + fdata;
                                    else
                                        htFinal += "<E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();

                                }
                                else
                                {
                                    if (f.FontFamily.Name == "HINDBODY")
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
                                    if (f.FontFamily.Name == "HINDBODY")
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
                                    if (f.FontFamily.Name == "HINDBODY")
                                        htFinal += "</E><H>" + fdata;
                                    else
                                        htFinal += "</H><E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                }
                                //////if (objDataSetbu.Tables[0].Columns.Count>6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY")
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
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }

                                    else if (eyecatcher != "DR" && eyecatcher != "BO")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                        {
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }
                                }
                                else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {
                                        fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                    else
                                    {
                                        fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                }
                                else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                {
                                    fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                else
                                {
                                    fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "<font face=" + fname + ">" + fdata;
                            }

                            else if (fstFName == fname)
                            {
                                fileData = fileData + fdata;
                                mFinal = mFinal + fdata;
                                sFinal = sFinal + fdata;
                            }
                            else
                            {
                                fstFName = fname;
                                fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                mFinal = mFinal + "</font>";
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "</font>" + "<font face=" + fname + ">" + fdata;
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
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }

                                    else if (eyecatcher != "DR" && eyecatcher != "BO")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                        {
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }
                                }
                                else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                    {
                                        fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                    else
                                    {
                                        fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                    }
                                }
                                else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW")
                                {
                                    fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                else
                                {
                                    fileData = "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "<font face=" + fname + ">" + fdata;
                            }

                            else if (fstFName == fname)
                            {
                                fileData = fileData + fdata;
                                mFinal = mFinal + fdata;
                                sFinal = sFinal + fdata;
                            }
                            else
                            {
                                fstFName = fname;
                                fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                mFinal = mFinal + "</font>";
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "</font>" + "<font face=" + fname + ">" + fdata;
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
                            final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1).ToUpper() + "</span>" + fdata.Substring(1, fdata.Length - 1);
                            mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1).ToUpper() + "</span>" + fdata.Substring(1, fdata.Length - 1);
                        }
                        else
                        {
                            if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "0" && eyecatcher != "")
                            {
                                //mFinal = mFinal + "</font>";
                                //if (eyecatcher == "HR")
                                //{
                                //    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                //    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
                                //}
                                //else
                                //{
                                final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
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
                                    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + final;
                                    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr.ToUpper() + "</span>" + mFinal;
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

                    if (style == 3 && i == 2)
                    {
                        style = 2;
                        final = "<b>" + final + "</b>";
                        mFinal = "<b>" + mFinal + "</b>";
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
        if (objDataSetbu.Tables[0].Columns.Count > 6)
        {
            if (firstFontName == "HINDBODY")
                htFinal += "</H>";
            else
                htFinal += "</E>";
            ////if (editorfornt == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY"
            ////    htFinal += "</H>";
            ////else
            ////    htFinal += "</E>";
        }

        if (dsbgcolcode.Tables[0].Rows.Count > 0)
        {
            if (objDataSetbu.Tables[0].Columns.Count > 6)
            {
                if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY")
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
                if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"HINDBODY")
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
        mFinal = mFinal.Trim();
        mFinal = mFinal + "</font>";
        sFinal = sFinal.Trim();
        sFinal = sFinal + "</font>";
        final = final.Replace("\\l", "<br>");
        mFinal = mFinal.Replace("\\l", "<br>");
        // mFinal = mFinal.Replace("\\l", "");
        sFinal = sFinal.Replace("\\l", "");

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
        string lineCount = "0";
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
          //  ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + c1.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + c1.ToString() + ";", true);
            lineCount = c1.ToString();
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

          //  ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + rwcount.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + rwcount.ToString() + ";", true);
            lineCount = rwcount.ToString();
        }
        else if (uom_desc == "ROC")
        {

            int words = strarr.Length;
            int word1 = strarr.Length;
            if (eyecatchtype == "S")
            {
                word1 = Convert.ToInt32(bPrem) + words;
            }

           // ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + word1.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + word1.ToString() + ";", true);
            lineCount = word1.ToString();
        }

      //  ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev), "zz1", "parentid('" + Hiddeninser.Value + "');", true);
        int h = Convert.ToInt32(height) * (count + 1);
        //  h = h + (height / 2);
        if (eyecatcher == "BO")
        {
            int wid = 180;//divwidth + 4;

            final = "<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + final + "</div></div>";
            mFinal = "<div style=\"text-align:justify;text-justify:newspaper;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div></div>";

            //td1.InnerHtml = final;
            //////  mFinal = mFinal.Replace("<br>", "");
            if (Request.QueryString["boxcode"].ToString() != "0")
            {
                mFinal = mFinal.Replace(Request.QueryString["boxcode"].ToString(), "<font class=boxmatter>" + Request.QueryString["boxcode"].ToString() + "</font>");
            }

           // td1.InnerHtml = mFinal;
        }
        else //if (uom_desc != "ROD")
        {
            int wid = 180;// divwidth;
            if (dropcap > 1)
            {
                wid = 180;// divwidth + 4;
            }

            string[] splitter = mFinal.Split("<br>".ToCharArray());

            //  divwidth = divwidth - 13;
            string abc = "";
            if (centertitle != "")
            {
                abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div>";
            }
            else
            {
                abc = "<div style=\"text-align:justify;text-justify:newspaper;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div>";
            }
            //   abc = abc.Replace("<br>", "");
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
            //if (Request.QueryString["boxcode"].ToString() != "0")
            //{
            //    abc = abc.Replace(Request.QueryString["boxcode"].ToString(), "<font class=boxmatter>" + Request.QueryString["boxcode"].ToString() + "</font>");
            //}
           // td1.InnerHtml = abc;
            fileData = fileData + bgcolor_uni;
            if (eyecatcher == "BO1")
            {
                fileData = fileData + "<ÿ>box</ÿ>";
            }
            else if (eyecatcher == "" || eyecatcher == "0")
            {
                fileData = fileData + "<æ>bold</æ>";
            }
            fileData = fileData + "<l>" + count + "</l>";
            fileData = fileData.Replace("<BR>", "");
            fileData = fileData.Replace("<br>", "");
            if (characterline != "")
                characterline = characterline + "," + Convert.ToString(charperline);
            else
                characterline = Convert.ToString(charperline);
            fileData = fileData + "<{>" + characterline + "</}>";
        }
      
        //******************************************************************************************
        string receiptno = Request.QueryString["boxno"].ToString();
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

        fileName = fileName + ".xtg";

        Session["fileName"] = fileName;
        //ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev), "FN", "window.opener.document.getElementById('hiddenFileName').value='" + fileName.ToString() + "';", true);

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
            box_matter = box_matter.Replace("<font face=Helvetica>", "");
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
        dr_data["rtfformat"] = sFinal.ToString();
        fileData = fileData.Replace("&amp;", "&");
        fileData = fileData.Replace("&gt;", ">");
        fileData = fileData.Replace("&lt;", "<");
        fileData = fileData.Replace("<P>", "");
        fileData = fileData.Replace("</P>", "");
        fileData = fileData.Replace("", "");
        dr_data["xtgformat"] = fileData.ToString();//fileData.ToString();
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
       // Response.Write(Request.QueryString["hiddeninsert"].ToString());//"parentid('" + Hiddeninser.Value + "');"
        Response.Write(fileName.ToString() + "æ" + lineCount.ToString());//hiddenFileName
       // Response.Write(lineCount);
        Response.End();
    }
    protected int countword(char[] str, int len1)
    {
        int rwcount = 1;
        string matterWordCount = Session["matterText_session"].ToString().Trim();
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
    static public float MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
    {
        const int width = 37; //33;

        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, 1, graphics);
        SizeF layoutSize = new SizeF(117F, 50.0F);
        System.Drawing.SizeF size = graphics.MeasureString(text, font, layoutSize);
        System.Drawing.Graphics anagra = System.Drawing.Graphics.FromImage(bitmap);

        float measured_width = (float)size.Width;
        // if (font.Name != "HINDBODY")
        ////////if (text != "")
        ////////{
        ////////    // {
        ////////    if (anagra != null)
        ////////    {
        ////////        anagra.Clear(Color.White);
        ////////        anagra.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        ////////        anagra.SmoothingMode = SmoothingMode.AntiAlias;
        ////////        anagra.DrawString(text + "|", font, Brushes.Black, width - measured_width, -font.Height / 2);

        ////////        for (int i = width - 1; i >= 0; i--)
        ////////        {

        ////////            if (bitmap.GetPixel(i, 0).R != 255)    // found a non-white pixel ?
        ////////                break;
        ////////            measured_width--;
        ////////        }
        ////////    }
        ////////}
        // }
        return measured_width;
    }
}
