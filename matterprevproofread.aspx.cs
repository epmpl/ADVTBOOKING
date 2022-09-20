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
using System.Text.RegularExpressions;

public partial class matterprevproofread : System.Web.UI.Page
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
    string comcharf = "~" + Convert.ToChar(05);//~}
    string comcharl = Convert.ToChar(05) + "~";//}~
    string materialpath = ConfigurationSettings.AppSettings["Classified_Reference_Path"].ToString();
    string hinfont = "";
    string str1 = "";
    int tempwords;
    int rowcount1 = 0;
    string matterText = "";


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
        string finct = "";
        //string trufont = "Gandhi";
        ////ADD BY ANUJA//
        if (matter != "")
        {
            if (matter.IndexOf("FONT") == -1)
            {
                //finct = matter.Replace("</FONT>", "").Replace("</font>", "").Replace("<FONT face=", "").Replace("<font face=", "");
                //string[] fontt = finct.Split('>');
                trufont = "Gautami";
            }
            else
            {
                finct = matter.Replace("</FONT>", "").Replace("</font>", "").Replace("<FONT face=", "").Replace("<font face=", "");
                string[] fontt = finct.Split('>');
                trufont = fontt[0];
            }
        }
        else
        {
            finct = "";
            trufont = "";
        }
        ///////////////////////////end
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
                if (a.IndexOf("FONT face=") > 0 || a.IndexOf("font face=") > 0)
                {
                    gh = true;
                    if (a.IndexOf("Gautami") > 0)
                    {
                        if (curfont == "")
                            curfont = "Gautami";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "Gautami";
                        }
                    }
                    else if (a.IndexOf("Gandhi") > 0)
                    {
                        if (curfont == "")
                            curfont = "Gandhi";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "Gandhi";
                        }
                    }
                    /////////////////////add by anuja
                    else if (a.IndexOf("Gandhi") > 0)
                    {
                        if (curfont == "")
                            curfont = "Gandhi";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "Gandhi";
                        }
                    }
                    /////end
                    else
                    {
                        if (curfont == "")
                            curfont = "Gandhi";
                        else
                        {
                            if (oldfont == "")
                            {
                                oldfont = curfont;
                                trufont = oldfont;
                            }
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "Gandhi";
                        }
                    }
                }
                else if (a == "</FONT>" || a == "</font>")
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

                if (curfont == "")
                {
                    curfont = trufont;
                }
                trufont = curfont;
                if (newdata.LastIndexOf("}") != newdata.ToString().Length - 2 && newdata.LastIndexOf(comcharl) != newdata.Length - 2)
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
        if (newdata.IndexOf(comcharf + "Gautami" + comcharl) >= 0 || newdata.IndexOf(comcharf + "Gautami" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (newdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        //////////////////////add by anuja
        if (newdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        ///////////////////////end
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
                    fontname = "NimrodMT";
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
        if (finaldata.IndexOf(comcharf + "NimrodMT" + comcharl) >= 0 || finaldata.IndexOf(comcharf + "NimrodMT" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (finaldata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        ///////////////add by anuja
        if (finaldata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        if (finaldata.IndexOf(comcharf + "Gautami" + comcharl) >= 0)
        {
            fontcntr = fontcntr + 1;
        }
        /////////////////////////end
        return finaldata;
    }

    string mod_log = "";
    string cioid = "";
    string previousid = "";
    string boxmatter_string = "";
    string languagecode = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btndone.Attributes.Add("OnClick", "javascript:return fillfilename();");
        }
        hiddencio.Value = Request.QueryString["cioid"].ToString();
        int hy = 0;
        Response.Expires = -1;
        string characterline = "";
        string logopremimage = "";
        string firstFontName = "";
        string eyecatchtype = "";
        string pubcode22 = "";
        string logo_name = "";
        Boolean checkHY = false;
        int bgcolorcount = 0;
        /*new change ankur 17feb*/
        if (Session["compcode"] == null)
        {

            Response.Write("<script>window.close();</script>");
            return;
        }
        if (Request.QueryString["pucode"] != null)
        {
            pubcode22 = Request.QueryString["pucode"].ToString();
        }
        if (Request.QueryString["eyecatchtype"] != null)
        {
            eyecatchtype = Request.QueryString["eyecatchtype"].ToString();
        }
        if (Request.QueryString["logoprem"] != null && Request.QueryString["logoprem"].ToString() != "")
        {
            logopremimage = Request.QueryString["logoprem"].ToString();
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
        string fileData_indesign = "";
        int eyecatcherlen = 2;
        //int eyecatcherlen = Convert.ToInt32(Request.QueryString["eyecatchlen"].ToString());
        /*mysql*/
        if (Request.QueryString["logoht"] != null)
        {
            string logohei = Request.QueryString["logoht"].ToString();
        }

        if (Request.QueryString["logowd"] != null)
        {
            string logowid = Request.QueryString["logowd"].ToString();
        }


        if (Request.QueryString["no_of_words"] != null)
        {
            string no_words = Request.QueryString["no_of_words"].ToString();
        }



        if (Request.QueryString["minsize"] != null)
        {

            string min_size = Request.QueryString["minsize"].ToString();
        }

        hiddenagencyratecode.Value = Session["agencyratecode"].ToString();
        hiddendatabasename.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        if (Session["agencycodeforrate"] != null)
        {
            hiddenagencycode.Value = Session["agencycodeforrate"].ToString();
        }
        previousid = "";
        /////////////////////////////////////////


        /*new change ankur for matter*/
        //logohei = Request.QueryString["logohei"].ToString();
        //logowid = Request.QueryString["logowid"].ToString();

        //matter = Request.QueryString["matter"].ToString();//Session["matter"].ToString();
        /*new change ankur for matter*/
        matter = Session["matter_session_proof"].ToString().Trim();
        matter = matter.Replace("^", "#");
        matter = matter.Replace("<P>", "");
        matter = matter.Replace("</P>", "");
        matter = matter.Replace("<p>", "");
        matter = matter.Replace("</p>", "");
        matter = matter.Replace("<br>", "");
        //matter = matter.Replace("<br>", "<BR>");
        string caption = "";
        DataSet dsword = new DataSet();
        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();

            dsword = csModify.getwords12(hiddencio.Value);

            tempwords = Convert.ToInt32(dsword.Tables[0].Rows[0].ItemArray[0].ToString());

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
            dsword = csModify.getwords12(hiddencio.Value);

            tempwords = Convert.ToInt32(dsword.Tables[0].Rows[0].ItemArray[0].ToString());
        }

        if (matter.IndexOf("\r\n") > 0 || matter.IndexOf("\r\n") > 0)
        {
            caption = matter.Substring(0, matter.IndexOf("\r\n"));
            matter = matter.Substring(matter.IndexOf("\r\n") + 2, matter.Length - caption.Length - 2);
        }
        else if (matter.IndexOf("<br>") > 0 || matter.IndexOf("<BR>") > 0)
        {
            caption = matter.Substring(0, matter.IndexOf("<BR>"));
            matter = matter.Substring(matter.IndexOf("<BR>") + 4, matter.Length - caption.Length - 4);
        }

        danish = Session["matter_session_proof"].ToString();
        DataSet dsboxmatter = new DataSet();
        //Request.QueryString["boxno"].ToString() in this query string we are fetching receipt number.
        //if (Session["revenue"].ToString() != "")
        //{
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getBox = new NewAdbooking.Classes.BookingMaster();
            dsboxmatter = getBox.autogenratedbox(Session["compcode"].ToString(), "", "", Session["center"].ToString(), Session["agency_name"].ToString(), Session["revenue"].ToString(), "A");
            // dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
            //dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());
            dsboxmatter = getBox.autogenratedbox(Session["compcode"].ToString(), "", "", Session["center"].ToString(), Session["agency_name"].ToString(), Session["revenue"].ToString(), "A");
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getBox = new NewAdbooking.classmysql.BookingMaster();
            dsboxmatter = getBox.getboxmatter(Session["revenue"].ToString());

        }
        string box_matter = "";
        DataSet dsdet = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getBox = new NewAdbooking.Classes.BookingMaster();
            dsdet = getBox.getDetailforProof(hiddencio.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
            dsdet = getBox.getDetailforProof(hiddencio.Value);
        }
        string eyecatcher = dsdet.Tables[0].Rows[0]["eyecatch"].ToString();
        //if (dsboxmatter.Tables.Count > 1)
        //{
        //    if (dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString() != "" && dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString() != null)
        //    {
        //        if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"] != "undefined" && Request.QueryString["boxcode"].ToString() != "")
        //        {
        //            //matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
        //            box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
        //        }
        //    }
        //    else
        //    {
        //        if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "undefined" && Request.QueryString["boxcode"].ToString() != "")
        //        {
        //            // matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
        //            box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
        //        }
        //    }
        //}
        //else
        //{
        //    if (dsboxmatter.Tables[0].Rows.Count > 0 && dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString() != "" && dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString() != null)
        //    {
        //        if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"] != "undefined" && Request.QueryString["boxcode"].ToString() != "")
        //        {
        //            //matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
        //            box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString();
        //        }
        //    }
        //    else
        //    {
        //        if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "undefined" && Request.QueryString["boxcode"].ToString() != "")
        //        {
        //            // matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
        //            box_matter = "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
        //        }
        //    }
        //}
        if (dsboxmatter.Tables.Count > 1 && dsdet.Tables.Count > 0 && dsdet.Tables[0].Rows.Count > 0)
        {
            if (dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString() != "" && dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString() != null)
            {
                if (dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "0" && dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "")
                //if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"] != "undefined")
                {
                    //matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
                    box_matter = "Box " + dsdet.Tables[0].Rows[0]["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
                }
            }
            else
            {
                // if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "undefined")
                if (dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "0" && dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "")
                {
                    // matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                    box_matter = "Box " + dsdet.Tables[0].Rows[0]["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                }
            }
        }
        else
        {
            if (dsdet.Tables.Count > 0 && dsdet.Tables[0].Rows.Count > 0 && dsboxmatter.Tables[0].Rows.Count > 0 && dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString() != "" && dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString() != null)
            {
                // if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"] != "undefined")
                if (dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "0" && dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "")
                {
                    //matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + dsboxmatter.Tables[2].Rows[0].ItemArray[0].ToString();
                    box_matter = "Box " + dsdet.Tables[0].Rows[0]["boxno"].ToString() + " " + dsboxmatter.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
            else
            {
                //  if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "undefined"
                if (dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "0" && dsdet.Tables[0].Rows[0]["boxcode"].ToString() != "")
                {
                    // matter = matter + " " + "Box " + Request.QueryString["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                    box_matter = "Box " + dsdet.Tables[0].Rows[0]["boxno"].ToString() + " " + ConfigurationManager.AppSettings["boxmatterdefault"].ToString();
                }
            }
        }
        boxmatter_string = box_matter;
        if (box_matter != "")
            box_matter = "<FONT face=Gautami> " + box_matter + "</FONT>";
        if (box_matter != "")
            matter = matter.Replace(box_matter, "");
        matter = matter + box_matter;
        uom = dsdet.Tables[0].Rows[0]["uom"].ToString();
        //Hiddeninser.Value = Request.QueryString["hiddeninsert"].ToString();

        //******************************************************************
        //string edition = Request.QueryString["edition"].ToString();
        //string insertid = Request.QueryString["hiddeninsert"].ToString();
        cioid = Request.QueryString["cioid"].ToString();
        copy_cioid = Request.QueryString["cioid"].ToString();
        //string srno = Request.QueryString["srno"].ToString();

        string txtcolor = ""; //Request.QueryString["txtcolor"].ToString();
        //*************************************************************
        if (txtcolor == "COLOR" || txtcolor == "color")
            txtcolor = "black";
        string coltype = "";// Request.QueryString["coltype"].ToString();
        fntname = "";// Request.QueryString["fntname"].ToString();
        //language = Request.QueryString["language"].ToString();


        //*************************************************************
        Ajax.Utility.RegisterTypeForAjax(typeof(matterprevproofread));
        string eyecatchstr = "";
        string eyecatchfont = "";
        int dropcap = 0;
        string eyecatchfontsize = "";
        if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "0" && eyecatcher != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bulletmaster clsbullet = new NewAdbooking.Classes.bulletmaster();
                DataSet ds = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                eyecatchfont = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                eyecatchfontsize = "7";
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.bulletmaster clsbullet = new NewAdbooking.classesoracle.bulletmaster();
                    DataSet ds = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                    eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    eyecatchfont = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    eyecatchfontsize = "7";
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
        string bgcolor = dsdet.Tables[0].Rows[0]["bgcolor"].ToString();
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
        if (bgcolor == "YELLOW")
        {
            bgcolor = "#ffff01";


        }
        else if (bgcolor == "GREEN")
        {
            bgcolor = "#d2eaae";
        }
        else if (bgcolor == "YELLOW WAKER")
        {
            bgcolor = "#e5deb4";
        }
        else if (bgcolor == "BLUE")
        {
            bgcolor = "#ceecf4";
        }
        else if (bgcolor == "YELLOW_L")
        {
            bgcolor = "#f4efb7";
        }
        else if (bgcolor == "CHROME")
        {
            bgcolor = " #fed981";
        }
        else if (bgcolor == "BLUE_1")
        {
            bgcolor = " #8dd4e6";
        }
        else if (bgcolor == "ORANGE_L")
        {
            bgcolor = "#fcd5ae";
        }
        else if (bgcolor == "PINK")
        {
            bgcolor = " #fcc1df";
        }
        else if (bgcolor == "VOILET_L")
        {
            bgcolor = " #ddcde8";
        }
        else if (bgcolor == "GREEN_L")
        {
            bgcolor = "#e9f39d";
        }
        else
        {
            bgcolor = bgcolor;
        }




        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/" + sSheet + ".xml"));
        // data = fetchFont(matter);
        //   matter = matter.Replace("Times Roman New", "NimrodMT");
        data = enterSpace(matter);
        Graphics a;
        double colwidth = 0;
        //if (Request.QueryString["hiddenwidth"].ToString() != "")
        //    colwidth = Convert.ToDouble(Request.QueryString["hiddenwidth"]);//3.8;
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
        fileData_indesign = fileData_indesign + "<Version:6><FeatureSet:InDesign-Roman><ColorTable:=<Black:COLOR:CMYK:Process:0,0,0,1>>" + "\r\n" + "<ParaStyle:>";
        //        fileData_indesign = fileData_indesign + "<ParaStyle:><pRuleBelowOffset:3.650000><pRuleBelowLeftIndent:2.ra834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pTextAlignment:JustifyLeft>";
        if (eyecatcher != "" && eyecatcher != "0")
            fileData_indesign = fileData_indesign + "<pDropCapCharacters:1><pDropCapLines:" + eyecatcherlen + ">";
        if (uom == "RO1" || uom == "RO2" || uom == "RO3")
            fileData_indesign = fileData_indesign + "<pHyphenation:0><pRuleBelowStroke:0.000000><pRuleBelowOffset:0.000000><pRuleBelowLeftIndent:0><pRuleBelowRightIndent:0><pRuleBelowOn:0>";//<pTextAlignment:JustifyLeft>";
        else if (uom == "ROL")
            fileData_indesign = fileData_indesign + "<pHyphenation:0><pRuleBelowOffset:0.000000><pRuleBelowLeftIndent:0><pRuleBelowRightIndent:0><pRuleBelowOn:0><pTextAlignment:JustifyLeft>";
        else
            fileData_indesign = fileData_indesign + "<pHyphenation:0><pRuleBelowStroke:0.000000><pRuleBelowOffset:0.000000><pRuleBelowLeftIndent:0><pRuleBelowRightIndent:0><pRuleBelowOn:0><pTextAlignment:JustifyLeft>";
        //  fileData_indesign = fileData_indesign + "<DefineParaStyle:Normal=<Nextstyle:Normal><pHyphenationLadderLimit:0><pHyphenationZone:0.000000><cFont:Gautami><pDesiredWordSpace:1.100000><pMaxWordSpace:2.500000><pMinWordSpace:0.850000><pMaxLetterspace:0.040000><pKeepFirstNLines:1><pKeepLastNLines:1><pRuleAboveColor:Black><pRuleAboveTint:100.000000><pRuleBelowColor:Black><pRuleBelowTint:100.000000>>";

        //fileData_indesign = fileData_indesign + "<pRuleBelowOffset:3.650000><pRuleAboveOn:0><pRuleBelowLeftIndent:2.834645><pRuleBelowRightIndent:2.834645><pRuleBelowOn:1><pTextAlignment:JustifyLeft>";

        //     else

        ///////comment by anuja
        //if (eyecatcher != "" && eyecatcher != "0")
        //    fileData_indesign = fileData_indesign + "<cSize:7.50><cLeading:7.50><cFont:" + eyecatchfont + ">" + eyecatchstr + "<cSize:><cLeading:><cFont:>";
        ////////////////////////////////end
        fileData_indesign = fileData_indesign + "<cTypeface:Regular>";
        double bitmapwidth = (96 / 2.54) * colwidth;//96 is bitmal verticalresolution and 2.54 is the cm. in 1 inch.
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
        string fontsize = "6.5";
        int count = 1;
        int line_count = 1;
        //this font is for normal
        if (fontname == "")
            fontname = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();

        if (fontsize == "0")
            fontsize = "6.5";// objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        /*for font color type and bgcolor*/
        /* if (bgcolor == "" || bgcolor == "0" || bgcolor == "White")
         {
             bgcolor = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
         }*/
        //Change for background color
        if (coltype == "" || coltype == "0" || coltype == "Black")
        {
            coltype = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        }

        string bgcolor_uni = "";
        //***if (bgcolor != "0" && bgcolor != "" && bgcolor != "White")
        //***  bgcolor_uni = "<¶>" + bgcolor + "</¶>";
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
        if (caption != "")
        {
            string cap = caption;
            cap = cap.Replace("<font face=NimrodMT>", "");
            cap = cap.Replace("</font>", "");
            cap = cap.Replace("<FONT FACE=NimrodMT>", "");
            cap = cap.Replace("</FONT>", "");
            cap = cap.Replace("<FONT face=NimrodMT>", "");
            cap = cap.Replace("<font face=Gandhi>", "");
            cap = cap.Replace("</font>", "");
            cap = cap.Replace("<FONT FACE=Gandhi>", "");
            cap = cap.Replace("<FONT face=Gandhi>", "");
            cap = cap.Replace("</FONT>", "");
            cap = cap.Replace("<FONT face=Gandhi>", "");
            cap = cap.Replace("<font face=Gandhi>", "");
            ////////////////add by anuja
            cap = cap.Replace("<font face=Gandhi>", "");
            cap = cap.Replace("</font>", "");
            cap = cap.Replace("<FONT FACE=Gandhi>", "");
            cap = cap.Replace("<FONT face=Gandhi>", "");
            cap = cap.Replace("</FONT>", "");
            cap = cap.Replace("<FONT face=Gandhi>", "");
            cap = cap.Replace("<font face=Gandhi>", "");
            ///////////////////////////////end
            if (caption.IndexOf("NimrodMT") > 0)
            {
                fileData = fileData + "<*C*p(0,0,0,10,0,0,g,\"International English\")><z10f\"NimrodMT\"><B>" + cap + "<$>\r\n";
            }
            else if (caption.IndexOf("Gandhi") > 0)
            {
                fileData = fileData + "<*C*p(0,0,0,13,0,0,g,\"International English\")><z12f\"Gandhi\"><B>" + cap + "<$>\r\n";
            }
            else
            {
                fileData = fileData + "<*C*p(0,0,0,13,0,0,g,\"International English\")><z12f\"Gandhi\"><B>" + cap + "<$>\r\n";
            }
        }
        int divwidth = widthD;
        int height = 0;

        string leading = "6.5";// "0";


        /*this is to get the eyecatcher if present*/
        if (objDataSetbu.Tables.Count - 1 >= 2 && objDataSetbu.Tables[2].TableName == "dropcap")
        {
            eyecatcher = "DR";
            eyecatcherlen = Convert.ToInt32(objDataSetbu.Tables[2].Rows[0].ItemArray[1].ToString());
        }
        if (Request.QueryString["logo_name"] != null)
        {
            logo_name = Request.QueryString["logo_name"].ToString();
        }
        mod_log = "";
        /////////////////////////////////////////


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
        //   data = data.Replace("NimrodMT", "Gautami");
        strarr = data.ToCharArray();
        strArrSplit = data.Split(" ".ToCharArray());
        //  data = data.Replace("Gautami", "NimrodMT");
        // new change for split array
        ArrayList newarr = new ArrayList();

        int index = 0;
        for (int n = 0; n < strArrSplit.Length; n++)
        {
            if (strArrSplit[n].IndexOf("Gautami") >= 0 && strArrSplit[n].IndexOf("Gandhi") >= 0)
            {
                string maindata = strArrSplit[n].ToString();
                while (maindata.IndexOf("Gautami") >= 0 || maindata.IndexOf("Gandhi") >= 0)
                {
                    string mdata = "";
                    if ((maindata.IndexOf("Gautami") >= 0 && maindata.IndexOf("Gandhi") < 0) || (maindata.IndexOf("Gautami") < 0 && maindata.IndexOf("Gandhi") >= 0))
                        mdata = maindata.Substring(0, maindata.LastIndexOf(comcharl) + 2);
                    else
                        mdata = maindata.Substring(0, maindata.IndexOf(comcharl) + 2);

                    // newarr[index] = mdata;
                    if (maindata == strArrSplit[n].ToString())
                        newarr.Add(" " + mdata);
                    else
                        newarr.Add(mdata);
                    if ((maindata.IndexOf("Gautami") >= 0 && maindata.IndexOf("Gandhi") < 0) || (maindata.IndexOf("Gautami") < 0 && maindata.IndexOf("Gandhi") >= 0))
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
        string fdataN = "";

        int allcount = 0;


        int lcou = 0;
        //for (int i = 0; i < strarr.Length; i++,totalchar++)
        for (int i = 0; i < newarr.Count; i++, totalchar++)
        {

            string fname = "";
            string fdata = "";
            string fdata12121 = "";
            // string [] fdata1212="";
            float f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString());//6.2F;
            leading = "6.5";// objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();//8F;
            fdata = newarr[i].ToString();
            if (fdata.IndexOf('~') > 0)
            {
                string[] fdata1212 = fdata.Split('~');
                fdata12121 = fdata1212[1];
            }
            else
            {
                fdata12121 = fdata;
            }
            //fdata = fdata.Replace("Gautami", "NimrodMT");
            if (editorfornt == "")
                editorfornt = fdata12121.Replace("|", "").Replace("|", "");// "Gandhi";
            if (fdata.IndexOf(comcharf) >= 0)
            {
                string[] arrfdata;
                editorfornt = fdata12121.Replace("|", "").Replace("|", "");// "Gandhi";
                /* if (fdata.IndexOf("{NimrodMT}") == 0 || fdata.IndexOf("{NimrodMT}") == 0 && (fdata.IndexOf("{Gandhi}") > 0))
                 {
                     fdata = fdata.Replace("{NimrodMT}", "");
                     fdata = fdata.Replace("{NimrodMT}", "");
                 }
                 else if (fdata.IndexOf("{Gandhi}") == 0 && (fdata.IndexOf("{NimrodMT}") == 0 || fdata.IndexOf("{NimrodMT}") == 0))
                 {
                     fdata = fdata.Replace("{Gandhi}", "");

                 }*/
                if (fdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0 || fdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
                {
                    fdata = fdata.Replace(comcharf + "Gandhi" + comcharl, "");
                    //  fdata = fdata.Replace("{Gandhi}", "");
                    fdata = fdata.Replace(comcharf + "Gandhi" + comcharl, "");
                    fdata = fdata.Replace(comcharf + comcharl, "");
                    // arrfdata = fdata.Split('{');
                    //fdata = arrfdata[0];
                    editorfornt = "Gandhi";
                }
                else if (fdata.IndexOf(comcharf + "Gautami" + comcharl) >= 0 || fdata.IndexOf(comcharf + "Gautami" + comcharl) >= 0)
                {
                    fdata = fdata.Replace(comcharf + "Gautami" + comcharl, "");
                    //  fdata = fdata.Replace("{Gandhi}", "");
                    fdata = fdata.Replace(comcharf + "Gautami" + comcharl, "");
                    fdata = fdata.Replace(comcharf + comcharl, "");
                    // arrfdata = fdata.Split('{');
                    //fdata = arrfdata[0];
                    editorfornt = "Gautami";
                }
                /////////////add by anuja
                else if (fdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0 || fdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
                {
                    fdata = fdata.Replace(comcharf + "Gandhi" + comcharl, "");
                    fdata = fdata.Replace(comcharf + "Gandhi" + comcharl, "");
                    fdata = fdata.Replace(comcharf + comcharl, "");
                    editorfornt = "Gandhi";
                }
                ////////////////////end//
                else
                {
                    if (fdata.IndexOf(comcharf + "Gandhi" + comcharl) >= 0)
                    {
                        fdata = fdata.Replace(comcharf + "Gandhi" + comcharl, "");
                        //   fdata = fdata.Replace("{NimrodMT}", "");
                        //  fdata = fdata.Replace("{NimrodMT}", "");
                        fdata = fdata.Replace(comcharf + comcharl, "");
                        //   arrfdata = fdata.Split('{');
                        // fdata = arrfdata[0];
                        editorfornt = "Gandhi";
                    }

                }
                fdata = fdata.Replace(comcharf + comcharl, "");
                //else
                //{
                //    arrfdata = fdata.Split('{');
                //    fdata = arrfdata[0];
                //    editorfornt = arrfdata[1].Replace("}", "");
                //}
                ////////////////////////////add by anuja///
                string fd = fdataN;
                if (fd == "")
                    fd = fdata;
                else
                    fd = fd + fdata;

                if (fontcntr > 1)
                {
                    if (editorfornt == "Gandhi")
                    {
                        //  int chrlen = allcharcount(fd);!"#$%&'()*+,-./:;<=>?@XYZ[\]^_`abcdefghijklmÆÇÈÉÊËÌÍÎÐÑÒÔ×Þûü
                        //lcou = lcou + allcharcount(fdata) + 1;
                        lcou = lcou + allcharcount(fdata.Replace("!", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("&", "").Replace("'", "").Replace("(", "").Replace(")", "").Replace("*", "").Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("<", "").Replace("=", "").Replace(">", "").Replace("?", "").Replace("@", "").Replace("X", "").Replace("Y", "").Replace("Z", "").Replace("[", "").Replace("\"", "").Replace("]", "").Replace("^", "").Replace("_", "").Replace("`", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("h", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("Æ", "").Replace("Ç", "").Replace("È", "").Replace("É", "").Replace("Ê", "").Replace("Ë", "").Replace("Ì", "").Replace("Í", "").Replace("Î", "").Replace("Ð", "").Replace("Ñ", "").Replace("Ò", "").Replace("Ô", "").Replace("×", "").Replace("Þ", "").Replace("û", "").Replace("ü", "")) + 1;
                        if (lcou == 17)
                        {
                            // int dlen = 15 - allcharcount(fdataN);
                            int dlen = 17 - allcharcount(fdataN.Replace("!", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("&", "").Replace("'", "").Replace("(", "").Replace(")", "").Replace("*", "").Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("<", "").Replace("=", "").Replace(">", "").Replace("?", "").Replace("@", "").Replace("X", "").Replace("Y", "").Replace("Z", "").Replace("[", "").Replace("\"", "").Replace("]", "").Replace("^", "").Replace("_", "").Replace("`", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("h", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("Æ", "").Replace("Ç", "").Replace("È", "").Replace("É", "").Replace("Ê", "").Replace("Ë", "").Replace("Ì", "").Replace("Í", "").Replace("Î", "").Replace("Ð", "").Replace("Ñ", "").Replace("Ò", "").Replace("Ô", "").Replace("×", "").Replace("Þ", "").Replace("û", "").Replace("ü", ""));
                            fdata = fdata + "\r\n";
                            // fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            fdataN = "";
                            lcou = 0;
                        }
                        else if (lcou > 17)
                        {
                            // int dlen = 15 - fdataN.ToString().Length;
                            //fdata = fdata + "\r\n";
                            //fdataN = "";

                            int dlen = 17 - (lcou - allcharcount(fdata));
                            lcou = allcharcount(fdata) - dlen;
                            if (fdataN.IndexOf(" ") == 0)
                            {
                                lcou = lcou - 1;
                                dlen = dlen + 1;
                            }

                            int lden = dlen;
                            // fdataN = fdata;// fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            //    DataSet dschar = new DataSet();
                            //    NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
                            //    dschar = getBox.getbengali();
                            //outer:
                            //    string fdata_new = fdata.Substring(0, dlen);
                            //    string smain = "";
                            //    smain = fdata_new;
                            //    char[] arr1 = fdata_new.ToCharArray();
                            //    int k1 = 0;
                            //    for (int x = 0; x < arr1.Length; x++)
                            //    {

                            //        for (int j = 0; j < dschar.Tables[0].Rows.Count; j++)
                            //        {
                            //            if (arr1[x].ToString() == dschar.Tables[0].Rows[j].ItemArray[0].ToString())
                            //            {
                            //                // fdata=fdata.Replace(arr1[x].ToString(), "");
                            //                k1 = k1 + 1;
                            //                smain = smain.Replace(arr1[x].ToString(), "");
                            //            }
                            //        }
                            //    }
                            //    if (smain.ToString().Length < lden)
                            //    {
                            //        dlen = dlen + 1;
                            //        goto outer;
                            //    }
                            //  dlen = dlen + k1;
                            //  if(k1>0)
                            //  dlen = dlen - 1;
                            if (dlen < 0)
                            {
                                fdata = "\r\n" + fdata;//.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString();//.Substring(dlen, fdata.ToString().Length - dlen);
                            }
                            else
                            {
                                fdata = fdata.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            }



                        }
                        else
                        {
                            if (fdataN == "")
                                fdataN = fdata;
                            else
                                fdataN = fdataN + fdata;
                            //   lcou = lcou + allcharcount(fdata);
                        }
                    }
                    else
                    {
                        //  int chrlen1 = allcharcount_english(fd);
                        lcou = lcou + allcharcount_english(fdata.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                        if (lcou == 21)
                        {
                            int dlen = 21 - allcharcount_english(fdataN.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                            fdata = fdata + "\r\n";
                            // fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            fdataN = "";
                            lcou = 0;
                        }
                        else if (lcou > 21)
                        {
                            // int dlen = 15 - fdataN.ToString().Length;
                            //fdata = fdata + "\r\n";
                            //fdataN = "";

                            int dlen = 21 - (lcou - allcharcount_english(fdata));
                            lcou = allcharcount_english(fdata) - dlen;
                            if (fdataN.IndexOf(" ") == 0)
                            {
                                lcou = lcou - 1;
                                dlen = dlen + 1;
                            }
                            int lden = dlen;
                            // fdataN = fdata;// fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            //    DataSet dschar = new DataSet();
                            //    NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
                            //    dschar = getBox.getbengali();
                            //outer:
                            //    string fdata_new = fdata.Substring(0, dlen);
                            //    string smain = "";
                            //    smain = fdata_new;
                            //    char[] arr1 = fdata_new.ToCharArray();
                            //    int k1 = 0;
                            //    for (int x = 0; x < arr1.Length; x++)
                            //    {

                            //        for (int j = 0; j < dschar.Tables[1].Rows.Count; j++)
                            //        {
                            //            if (arr1[x].ToString() == dschar.Tables[1].Rows[j].ItemArray[0].ToString())
                            //            {
                            //                // fdata=fdata.Replace(arr1[x].ToString(), "");
                            //                k1 = k1 + 1;
                            //                smain = smain.Replace(arr1[x].ToString(), "");
                            //            }
                            //        }
                            //    }
                            //    if (smain.ToString().Length < lden)
                            //    {
                            //        dlen = dlen + 1;
                            //        goto outer;
                            //    }
                            //  dlen = dlen + k1;
                            //  if(k1>0)
                            //  dlen = dlen - 1; 
                            if (dlen < 0)
                            {
                                fdata = "\r\n" + fdata;//.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString();//.Substring(dlen, fdata.ToString().Length - dlen);
                            }
                            else
                            {
                                fdata = fdata.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            }


                        }

                        else
                        {
                            if (fdataN == "")
                                fdataN = fdata;
                            else
                                fdataN = fdataN + fdata;
                            //  lcou = lcou + allcharcount_english(fdata);
                        }
                    }
                    //int chrlen = fd.ToString().Length;
                    //if (chrlen == 15){
                    //    fdata = fdata + "\r\n";
                    //    fdataN="";
                    //}
                    //else if (chrlen > 15)
                    //{


                    //    int dlen = 15 - fdataN.ToString().Length;

                    //    fdataN = fdata;//fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                    //    fdata = "\r\n" + fdata;//fdata.Insert(dlen, "\r\n");

                    //}
                    //else
                    //{
                    //    if (fdataN == "")
                    //        fdataN = fdata;
                    //    else
                    //        fdataN = fdataN +  fdata;
                    // }
                }
                else if (matter.ToString().IndexOf("Gautami") > 0)
                {

                    int chrlen = allcharcount_english(fd.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                    if (chrlen == 21)
                    {
                        int dlen = 21 - allcharcount_english(fdataN.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                        fdata = fdata + "\r\n";
                        // fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                        fdataN = "";
                        //fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);

                    }
                    else if (chrlen > 21)
                    {
                        // int dlen = 15 - fdataN.ToString().Length;
                        //fdata = fdata + "\r\n";
                        //fdataN = "";

                        int dlen = 21 - allcharcount_english(fdataN.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                        if (fdataN.IndexOf(" ") == 0)
                        {
                            dlen = dlen + 1;
                        }
                        int lden = dlen;

                        if (dlen < 0)
                        {
                            fdata = "\r\n" + fdata;//.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                            fdataN = fdata.ToString();//.Substring(dlen, fdata.ToString().Length - dlen);
                        }
                        else
                        {
                            fdata = fdata.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                            fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                        }



                    }
                    else
                    {
                        if (fdataN == "")
                            fdataN = fdata;
                        else
                            fdataN = fdataN + fdata;
                    }
                }
                else
                {
                    if (editorfornt == "Gautami")
                    {
                        // allcount = allcharcount(danish);
                        // int chrlen = fd.ToString().Length;
                        int chrlen = allcharcount_english(fd.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                        if (chrlen == 21)
                        {
                            int dlen = 21 - allcharcount_english(fdataN.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                            fdata = fdata + "\r\n";
                            // fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            fdataN = "";
                            //fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);

                        }
                        else if (chrlen > 21)
                        {
                            // int dlen = 15 - fdataN.ToString().Length;
                            //fdata = fdata + "\r\n";
                            //fdataN = "";

                            int dlen = 21 - allcharcount_english(fdataN.Replace(":", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("-", "").Replace("+", "").Replace("=", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("&", "").Replace("^", "").Replace("$", "").Replace("#", "").Replace("@", "").Replace("!", "").Replace("~", "").Replace("}", "").Replace("{", "").Replace("[", "").Replace("|", "").Replace("=", "").Replace(">", "").Replace(".", "").Replace("<", "").Replace(",", ""));
                            if (fdataN.IndexOf(" ") == 0)
                            {
                                dlen = dlen + 1;
                            }
                            int lden = dlen;
                            // fdataN = fdata;// fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            //    DataSet dschar = new DataSet();
                            //    NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
                            //    dschar = getBox.getbengali();
                            //outer:
                            //    string fdata_new = "";
                            //    if (fdata.ToString().Length > dlen)
                            //    {
                            //         fdata_new = fdata.Substring(dlen, fdata.ToString().Length - dlen);
                            //    }
                            //    else
                            //    {
                            //        fdata_new = fdata.Substring(0, fdata.ToString().Length);
                            //    }

                            //    string smain = "";
                            //    smain = fdata_new;
                            //    char[] arr1 = fdata_new.ToCharArray();
                            //    int k1 = 0;
                            //    for (int x = 0; x < arr1.Length; x++)
                            //    {

                            //        for (int j = 0; j < dschar.Tables[0].Rows.Count; j++)
                            //        {
                            //            if (arr1[x].ToString() == dschar.Tables[0].Rows[j].ItemArray[0].ToString())
                            //            {
                            //                // fdata=fdata.Replace(arr1[x].ToString(), "");
                            //                k1 = k1 + 1;
                            //                smain = smain.Replace(arr1[x].ToString(), "");
                            //            }
                            //        }
                            //    }
                            //    if (smain.ToString().Length < lden)
                            //    {
                            //        dlen = dlen + 1;
                            //        goto outer;
                            //    }
                            //    //  dlen = dlen + k1;
                            //    //  if(k1>0)
                            //    //  dlen = dlen - 1;
                            if (dlen < 0)
                            {
                                fdata = "\r\n" + fdata;//.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString();//.Substring(dlen, fdata.ToString().Length - dlen);
                            }
                            else
                            {
                                fdata = fdata.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            }



                        }
                        else
                        {
                            if (fdataN == "")
                                fdataN = fdata;
                            else
                                fdataN = fdataN + fdata;
                        }
                    }
                    else if (editorfornt == "Gandhi")
                    {
                        // allcount = allcharcount(danish);
                        // int chrlen = fd.ToString().Length;
                        //int chrlen = allcharcount(fd);
                        int chrlen = allcharcount(fd.Replace("!", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("&", "").Replace("'", "").Replace("(", "").Replace(")", "").Replace("*", "").Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("<", "").Replace("=", "").Replace(">", "").Replace("?", "").Replace("@", "").Replace("X", "").Replace("Y", "").Replace("Z", "").Replace("[", "").Replace("\"", "").Replace("]", "").Replace("^", "").Replace("_", "").Replace("`", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("h", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("Æ", "").Replace("Ç", "").Replace("È", "").Replace("É", "").Replace("Ê", "").Replace("Ë", "").Replace("Ì", "").Replace("Í", "").Replace("Î", "").Replace("Ð", "").Replace("Ñ", "").Replace("Ò", "").Replace("Ô", "").Replace("×", "").Replace("Þ", "").Replace("û", "").Replace("ü", ""));
                        if (chrlen == 17)
                        {
                            // int dlen = 17 - allcharcount(fdataN);
                            int dlen = 17 - allcharcount(fdataN.Replace("!", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("&", "").Replace("'", "").Replace("(", "").Replace(")", "").Replace("*", "").Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("<", "").Replace("=", "").Replace(">", "").Replace("?", "").Replace("@", "").Replace("X", "").Replace("Y", "").Replace("Z", "").Replace("[", "").Replace("\"", "").Replace("]", "").Replace("^", "").Replace("_", "").Replace("`", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("h", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("Æ", "").Replace("Ç", "").Replace("È", "").Replace("É", "").Replace("Ê", "").Replace("Ë", "").Replace("Ì", "").Replace("Í", "").Replace("Î", "").Replace("Ð", "").Replace("Ñ", "").Replace("Ò", "").Replace("Ô", "").Replace("×", "").Replace("Þ", "").Replace("û", "").Replace("ü", ""));
                            fdata = fdata + "\r\n";
                            // fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            fdataN = "";
                            //fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);

                        }
                        else if (chrlen > 17)
                        {
                            // int dlen = 15 - fdataN.ToString().Length;
                            //fdata = fdata + "\r\n";
                            //fdataN = "";

                            int dlen = 17 - allcharcount(fdataN.Replace("!", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("&", "").Replace("'", "").Replace("(", "").Replace(")", "").Replace("*", "").Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("<", "").Replace("=", "").Replace(">", "").Replace("?", "").Replace("@", "").Replace("X", "").Replace("Y", "").Replace("Z", "").Replace("[", "").Replace("\"", "").Replace("]", "").Replace("^", "").Replace("_", "").Replace("`", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("h", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("Æ", "").Replace("Ç", "").Replace("È", "").Replace("É", "").Replace("Ê", "").Replace("Ë", "").Replace("Ì", "").Replace("Í", "").Replace("Î", "").Replace("Ð", "").Replace("Ñ", "").Replace("Ò", "").Replace("Ô", "").Replace("×", "").Replace("Þ", "").Replace("û", "").Replace("ü", ""));
                            if (fdataN.IndexOf(" ") == 0)
                            {
                                dlen = dlen + 1;
                            }
                            int lden = dlen;
                            // fdataN = fdata;// fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            //    DataSet dschar = new DataSet();
                            //    NewAdbooking.classesoracle.BookingMaster getBox = new NewAdbooking.classesoracle.BookingMaster();
                            //    dschar = getBox.getbengali();
                            //outer:
                            //   // fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            //    string fdata_new = fdata.ToString().Substring(0,dlen);
                            //    string smain = "";
                            //    smain = fdata_new;
                            //    char[] arr1 = fdata_new.ToCharArray();
                            //    int k1 = 0;
                            //    for (int x = 0; x < arr1.Length; x++)
                            //    {

                            //        for (int j = 0; j < dschar.Tables[0].Rows.Count; j++)
                            //        {
                            //            if (arr1[x].ToString() == dschar.Tables[0].Rows[j].ItemArray[0].ToString())
                            //            {
                            //                // fdata=fdata.Replace(arr1[x].ToString(), "");
                            //                k1 = k1 + 1;
                            //                smain = smain.Replace(arr1[x].ToString(), "");
                            //            }
                            //        }
                            //    }
                            //    if (smain.ToString().Length < lden)
                            //    {
                            //        dlen = dlen + 1;
                            //        goto outer;
                            //    }
                            //  dlen = dlen + k1;
                            //  if(k1>0)
                            //  dlen = dlen - 1;
                            if (dlen < 0)
                            {
                                fdata = "\r\n" + fdata;//.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata;//.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            }
                            else
                            {
                                fdata = fdata.Insert(dlen, "\r\n"); //"\r\n" + fdata;//
                                fdataN = fdata.ToString().Substring(dlen, fdata.ToString().Length - dlen);
                            }



                        }
                        else
                        {
                            if (fdataN == "")
                                fdataN = fdata;
                            else
                                fdataN = fdataN + fdata;
                        }
                    }
                }


                if (fdata.IndexOf("\r\n") != -1)
                {


                    //  line_count = line_count + 1;

                    line_count = line_count + 1;
                    //if (i + 1 == strArrSplit.Length)
                    //{
                    //    if (fdata.LastIndexOf("\r\n") != 0)
                    //    {
                    //        if (fdata.Substring(fdata.LastIndexOf("\r\n"), 2) == "\r\n")
                    //        {
                    //            line_count = line_count - 1;
                    //        }
                    //    }
                    //}

                }
                //////////////////////////////////////end//////
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
                    if (fontname == "Gautami")
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString());
                        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString(); //"6.5";// objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();//8F;
                    }
                    else if (fontname == "Bhaskar")
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString());
                        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString(); //"6.5"; objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();//8F;
                    }
                    ///////////////////add by anuja
                    else if (fontname == "Gandhi" || fontname == "Gandhi")
                    {
                        f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString());
                        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString(); //"6.5";// objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();//8F;
                    }
                    //////////////////end
                    bgcolorcount = Convert.ToInt32(objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString());
                    //if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi"
                    //{
                    //    f_ = (float)Convert.ToDouble(objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString());//8F;
                    //    if (objDataSetbu.Tables[0].Columns.Count > 8 && objDataSetbu.Tables[0].Rows[0].ItemArray[8] != null)
                    //        leading = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();//8F;
                    //}
                }
                //if (fontcntr > 1)
                //{
                //    if (objDataSetbu.Tables[0].Columns.Count > 6)
                //    {
                //        if (editorfornt == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi"
                //            f_ = (float)Convert.ToDouble(objDataSetbu.Tables[2].Rows[0].ItemArray[1].ToString());//7F;
                //        else
                //            f_ = (float)Convert.ToDouble(objDataSetbu.Tables[2].Rows[0].ItemArray[0].ToString());//6F;
                //        leading = objDataSetbu.Tables[2].Rows[0].ItemArray[2].ToString();
                //    }
                //}

            }
            // fontsize = "6.5";// f_.ToString();
            fontsize = f_.ToString();
            if (fdata != comcharf && fdata != comcharl)
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
                //if (i < 3 && editorfornt == "Gandhi")
                //{
                //    fname = "Shree-Pud-77BL";
                //    fname_bold = fname;
                //}
                //else if (fontname == "Shree-Pud-77BL" && i > 3)
                //    fontname = "Gandhi";
                Font f;

                if (style == 0)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 1)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 2)
                    f = new Font(fname, f_);
                else if (style == 3)
                    f = new Font(fname_bold, f_, FontStyle.Bold, GraphicsUnit.Point);
                else if (style == 4)
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
                                if (fontname == "Gandhi")
                                    fdata = fdata1[hy].ToString();
                                else
                                    fdata = fdata1[hy].ToString().TrimEnd() + "-";
                                //fdata = fdata1[hy].ToString().TrimEnd() + "-";
                                //  checkHY = true;
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
                        if (firstFontName == "Gandhi")
                        {
                            htFinal += "</H></l>{" + (charperline) + "}<l>";// +fdata;
                            if (characterline == "")
                                characterline = Convert.ToString(charperline);
                            else
                                characterline = characterline + "," + Convert.ToString(charperline);
                        }
                        ///////////add by anuja
                        else if (firstFontName == "Gandhi")
                        {
                            htFinal += "</H></l>{" + (charperline) + "}<l>";// +fdata;
                            if (characterline == "")
                                characterline = Convert.ToString(charperline);
                            else
                                characterline = characterline + "," + Convert.ToString(charperline);
                        }
                        ///////////////end
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
                            if (objDataSetbu.Tables[0].Columns.Count > 6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi"
                            {

                                if (f.FontFamily.Name == "Gandhi")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();

                            }
                            else
                            {
                                if (f.FontFamily.Name == "Gandhi")
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
                                if (f.FontFamily.Name == "Gandhi")
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
                                if (f.FontFamily.Name == "Gandhi")
                                    htFinal += "<H>" + fdata;
                                else
                                    htFinal += "<E>" + fdata;
                                firstFontName = f.FontFamily.Name.ToString();
                            }
                            //////if (objDataSetbu.Tables[0].Columns.Count>6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi")
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
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                    {

                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;

                                    }
                                    else
                                    {
                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }

                                else if (eyecatcher != "DR" && eyecatcher != "BO")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                    {
                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else if (eyecatcher == "SP0" || eyecatcher == "SB0")
                                    {
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }
                            }
                            else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                            {
                                if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                {
                                    fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                else
                                {
                                    fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + "><B>" + fdata;
                                }
                            }
                            else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                            {
                                if (style == 3)
                                    fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                else
                                    fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            }
                            else
                            {
                                if (style == 3)
                                    fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                else
                                    fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                            }

                            // mFinal = mFinal + "\\l<font color=" + txtcolor + " face=" + fname + ">" + fdata;
                            if (ConfigurationSettings.AppSettings["LINEBREAK"].ToString() == "Y")
                            {
                                if (style == 3)
                                {
                                    if (fname == "Gandhi")
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                    else
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                }
                                else
                                {

                                    if (bgcolorcount == 0)
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    else if (bgcolorcount == 1 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 2 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 2 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 3 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 2)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else
                                    {
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                }
                            }
                            else
                            {
                                if (style == 3)
                                {
                                    if (fname == "Gandhi")
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                    else
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                }
                                else
                                    fileData_indesign = fileData_indesign + "\r\n" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
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
                                if (uom == "ROL")
                                {
                                    if (style == 3)
                                    {
                                        if (fname == "Gandhi")
                                            fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                        else
                                            fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                    }
                                    else
                                        fileData_indesign = fileData_indesign + fdata;
                                }
                                else
                                {
                                    if (style == 3)
                                    {
                                        if (uom == "ROL")
                                            fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                        else
                                            fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                    }
                                    else
                                        fileData_indesign = fileData_indesign + "\r\n" + fdata;
                                }
                                //  fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                            else
                            {
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                {

                                    if (bgcolorcount == 0)
                                        fileData_indesign = fileData_indesign + fdata;
                                    else if (bgcolorcount == 1 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 2 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 2 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 3 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 2)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                }
                                //  fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                            }
                        }
                        else
                        {
                            fstFName = fname;
                            if (style == 2 && tstyle == 3)
                            {
                                fileData = fileData + "<$><*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                tstyle = 0;
                            }
                            else
                            {
                                if (style == 3)
                                    fileData = fileData + "<$><*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                else
                                {
                                    if (fname == "NimrodMT")
                                    {
                                        fileData = fileData + "<$*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    ////////////add by anuja
                                    else if (fname == "Gandhi")
                                    {
                                        fileData = fileData + "<$*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "Gandhi" + "\"" + ">" + fdata;
                                    }
                                    /////////////////////end
                                    else
                                    {
                                        fileData = fileData + "<$*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }
                                //fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                            }
                            mFinal = mFinal + "</font>";
                            mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                            sFinal = sFinal + "</font>" + "\\l<font face=" + fname + ">" + fdata;
                            if (ConfigurationSettings.AppSettings["LINEBREAK"].ToString() == "Y")
                            {
                                if (uom == "ROL")
                                {
                                    if (style == 3)
                                        fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                    else
                                        fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                }
                                else
                                {
                                    if (style == 3)
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                    else
                                        fileData_indesign = fileData_indesign + "\r\n" + "<cTypeface:><cSize:><cLeading:><cFont:><cTypeface:Regular><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                }
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
                                if (objDataSetbu.Tables[0].Columns.Count > 6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi"
                                {

                                    if (f.FontFamily.Name == "Gandhi")
                                        htFinal += "<H>" + fdata;
                                    else
                                        htFinal += "<E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();

                                }
                                else
                                {
                                    if (f.FontFamily.Name == "Gandhi")
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
                                    if (f.FontFamily.Name == "Gandhi")
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
                                    if (f.FontFamily.Name == "Gandhi")
                                        htFinal += "</E><H>" + fdata;
                                    else
                                        htFinal += "</H><E>" + fdata;
                                    firstFontName = f.FontFamily.Name.ToString();
                                }
                                //////if (objDataSetbu.Tables[0].Columns.Count>6 && fname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi")
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
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }

                                    else if (eyecatcher != "DR" && eyecatcher != "BO")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else if (eyecatcher == "SP0" || eyecatcher == "SB0")
                                        {
                                            fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + fontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }
                                }
                                else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                    {
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }
                                else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                {
                                    if (style == 3)
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;

                                }
                                else
                                {
                                    if (style == 3)
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;

                                }
                                mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                                sFinal = sFinal + "<font face=" + fname + ">" + fdata;
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                {

                                    if (bgcolorcount == 0)
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    else if (bgcolorcount == 1 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 2 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 2 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 3 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 2)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else
                                    {
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                }
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
                                    fileData = fileData + "<$><*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                else
                                {
                                    if (style == 3)
                                        fileData = fileData + "<$><*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
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
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }

                                    else if (eyecatcher != "DR" && eyecatcher != "BO")
                                    {
                                        if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                        {
                                            if (eyecatcher == "EY0")
                                            {
                                                fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata + "<$>";
                                                //fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr.ToUpper() + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><B>" + fdata + "<$>";
                                            }
                                            else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                                            {
                                                fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                            }
                                            else if (eyecatcher == "EY1" || eyecatcher == "EY2")
                                            {
                                                fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                            }
                                            else if (eyecatcher == "EY3")
                                            {
                                                fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                            }
                                            else if (eyecatcher == "TI0")
                                            {
                                                if (txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                                {
                                                    txtcolor = "Black";
                                                }
                                                fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "c\"Red\"f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                            }
                                            else if (eyecatcher == "FO0")
                                            {
                                                fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"Red\"f\"" + fname + "\"" + ">" + fdata;
                                            }
                                            else if (eyecatcher == "SP0" || eyecatcher == "SB0")
                                            {
                                                fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                            }
                                            else
                                            {
                                                fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                            }
                                        }
                                        else
                                        {
                                            fileData = fileData + "<*d(1," + dropcap + ")*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + eyecatchfontsize + "f\"" + eyecatchfont + "\">" + eyecatchstr + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                        }
                                    }
                                }
                                else if (eyecatcher == "BO0" || eyecatcher == "BO1")
                                {
                                    if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                    {
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                    else
                                    {
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    }
                                }
                                else if (txtcolor == "" || txtcolor == "0" || txtcolor == "Black" || txtcolor == "black" || txtcolor == "BW" || txtcolor == "BLACK AND WHITE")
                                {
                                    if (style == 3)
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    else
                                    {
                                        //fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        if (fname == "NimrodMT")
                                        {
                                            //fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "NimrodMT" + "\"" + "><B>" + fdata+"<$>";
                                            fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + "7" + "f\"" + "Wingdings" + "\">" + "§" + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "NimrodMT" + "\"" + ">" + fdata + "<$>";
                                        }
                                        ////add by anuja
                                        else if (fname == "Gandhi")
                                        {
                                            //fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "NimrodMT" + "\"" + "><B>" + fdata+"<$>";
                                            //***fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + "7" + "f\"" + "Wingdings" + "\">" + "§" + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "Gandhi" + "\"" + "><B>" + fdata + "<$>";
                                            fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")>" + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "Gandhi" + "\"" + ">" + fdata;
                                        }
                                        else
                                        {
                                            //fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "Gandhi" + "\"" + "><B>" + fdata+"<$>";
                                            //***fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")><z" + "7" + "f\"" + "Wingdings" + "\">" + "§" + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + "Gandhi" + "\"" + "><B>" + fdata + "<$>";
                                            fileData = fileData + "<*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")>" + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                        }

                                    }
                                }
                                else
                                {
                                    if (style == 3)
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "c\"" + txtcolor + "\"" + "f\"" + fname + "\"" + ">" + fdata;
                                }
                                if (style == 3)
                                    fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + "><cTypeface:Bold>" + fdata + "<cTypeface:>";
                                else
                                {
                                    if (bgcolorcount == 0)
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    else if (bgcolorcount == 1 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 2 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 2 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 3 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 2)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else
                                    {
                                        fileData_indesign = fileData_indesign + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                }
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
                                {

                                    if (bgcolorcount == 0)
                                        fileData_indesign = fileData_indesign + fdata;
                                    else if (bgcolorcount == 1 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 2 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 2 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else if (bgcolorcount == 3 && i == 0)
                                    {
                                        fileData_indesign = fileData_indesign + "<pTextAlignment:JustifyLeft><cColor:White><cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">" + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 1)
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                    else if (bgcolorcount == 3 && i == 2)
                                    {
                                        fileData_indesign = fileData_indesign + fdata + "<cColor:><cSize:><cLeading:><cFont:>" + "<cSize:" + fontsize + "><cLeading:" + leading + "><cFont:" + fname + ">";
                                    }
                                    else
                                    {
                                        fileData_indesign = fileData_indesign + fdata;
                                    }
                                }
                            }
                            else
                            {
                                fstFName = fname;
                                if (style == 2 && tstyle == 3)
                                    fileData = fileData + "<$><*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                else
                                {
                                    if (style == 3)
                                        fileData = fileData + "<$><*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                                    else
                                        fileData = fileData + "<*F*p(0,0,0," + leading + ",0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
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
                                if (eyecatcher == "EY0")
                                {
                                    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                }
                                else if (eyecatcher == "BO0")
                                {
                                    final = "<span style=\"border:0px solid;float:left;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                    mFinal = "<span style=\"border:0px solid;float:left;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                }
                                else
                                {
                                    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                }
                                //}
                            }
                        }
                        //final = "<span style=\"border:1px solid;float:left;font-size:12px;font-family:Gautami;padding:1px;line-height:1em;\">" + final.Substring(0, 1) + "</span>" + final.Substring(1, final.Length - 1);
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
                                    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                                    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + eyecatchfont + ";padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                                }
                                // }
                            }

                        }
                    }

                    /*for bold we have to use the different font*/
                    if (style == 0)
                    {
                        style = 2;
                        if (eyecatcher == "BO0" || eyecatcher == "EY1")
                        {
                            style = 4;
                        }
                        else
                        {
                            final = "<b>" + final + "</b>";
                            mFinal = "<b>" + mFinal + "</b>";
                        }
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
        int last_line_count;
        fdataN = fdataN.Replace("\r\n", "");
        if (editorfornt == "Gautami")
        {
            last_line_count = allcharcount_english(fdataN);
        }
        else
        {

            last_line_count = allcharcount(fdataN);
        }
        //if (last_line_count <= 3)
        //{
        //    line_count = line_count - 1;
        //}


        if (style == 4)
        {
            final = "<b>" + final + "</b>";
            mFinal = "<b>" + mFinal + "</b>";
        }
        if (objDataSetbu.Tables[0].Columns.Count > 6)
        {
            if (firstFontName == "Gandhi")
                htFinal += "</H>";
            else
                htFinal += "</E>";
            ////if (editorfornt == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi"
            ////    htFinal += "</H>";
            ////else
            ////    htFinal += "</E>";
        }

        if (dsbgcolcode.Tables.Count > 0 && dsbgcolcode.Tables[0].Rows.Count > 0)
        {
            if (objDataSetbu.Tables[0].Columns.Count > 6)
            {
                if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi")
                {
                    htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}ŸhŸæ" + bgcolor + "æ";
                }
                else
                {
                    htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}æ" + bgcolor + "æ";
                }
            }
            else
            {
                htFinal = "Number of Lines{" + count + "}RateType{" + dsStyleSheet.Tables[0].Rows[0].ItemArray[2].ToString() + "}" + htFinal + "</l>{" + (charperline) + "}æ" + bgcolor + "æ";
            }
        }
        else
        {
            if (objDataSetbu.Tables[0].Columns.Count > 6)
            {
                if (fontname == objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString())//"Gandhi")
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
        fontsize = "6.5";// "8";
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
        if (uom == "ROL")
            fileData_indesign = fileData_indesign + "<cTypeface:><cSize:><cLeading:><cFont:><pRuleBelowOffset:><pRuleBelowLeftIndent:><pRuleBelowRightIndent:><pTextAlignment:>";
        else
            fileData_indesign = fileData_indesign + "\r\n<cTypeface:><cSize:><cLeading:><cFont:><pRuleBelowStroke:><pRuleBelowOffset:><pRuleBelowLeftIndent:><pRuleBelowRightIndent:><pTextAlignment:>";
        if (eyecatcher != "" && eyecatcher != "0")
            fileData_indesign = fileData_indesign + "<pDropCapCharacters:><pDropCapLines:>";
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
                //c1 = count;
                //if (line_count <= 4)
                //{
                //    c1 = 4;
                //}
                //else
                //{
                c1 = line_count;
                if (c1 > tempwords)
                {
                    rowcount1 = 0;
                }
                else
                {
                    rowcount1 = c1;
                }
                // }
            }
            if (uom == "ROL")
                ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=1;window.opener.document.getElementById('txtnoofline').value=1;", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + c1.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + c1.ToString() + ";", true);


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
            if (uom == "ROL")
                ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=1;window.opener.document.getElementById('txtnoofline').value=1;", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + rwcount.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + rwcount.ToString() + ";", true);
        }
        else if (uom_desc == "ROC")
        {

            int words = strarr.Length;
            int word1 = strarr.Length;
            if (eyecatchtype == "S")
            {
                word1 = Convert.ToInt32(bPrem) + words;
            }
            if (uom == "ROL")
                ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=1;window.opener.document.getElementById('txtnoofline').value=1;", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz6", "window.opener.document.getElementById('hiddenLineCount').value=" + word1.ToString() + ";window.opener.document.getElementById('txtnoofline').value=" + word1.ToString() + ";", true);
        }

        //ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "zz1", "parentid('" + Hiddeninser.Value + "');", true);
        //if (uom != "ROL")
        //    fileData_indesign = fileData_indesign + "<ParaStyle:Normal>" + cioid.ToString();
        int h = Convert.ToInt32(height) * (count + 1);
        //  h = h + (height / 2);
        if (eyecatcher == "BO")
        {
            int wid = divwidth + 20;//180;
            if (uom == "ROL")
            {
                if (caption == "")
                {
                    final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + final + "</div></div>";
                    mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div></div>";
                }
                else
                {
                    final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><center><b>" + caption + "</center></b>" + final + "</div></div>";
                    mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><center><b>" + caption + "</center></b>" + mFinal + "</div></div>";
                }
            }
            else
            {
                if (caption == "")
                {
                    final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + final + "</div></div>";
                    mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div></div>";
                }
                else
                {
                    final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><center><b>" + caption + "</center></b>" + final + "</div></div>";
                    mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><center><b>" + caption + "</center></b>" + mFinal + "</div></div>";
                }
            }

            //td1.InnerHtml = final;
            mFinal = mFinal.Replace("<br>", "");
            if (Request.QueryString["boxcode"].ToString() != "0" && Request.QueryString["boxcode"].ToString() != "")
            {
                mFinal = mFinal.Replace(Request.QueryString["boxcode"].ToString(), "<font class=boxmatter>" + Request.QueryString["boxcode"].ToString() + "</font>");
            }
            mFinal = mFinal.Replace("", "");
            if (uom == "ROL")
                td1.InnerHtml = td1.InnerHtml.Replace("~", " ");
            else
                td1.InnerHtml = mFinal;
        }
        else //if (uom_desc != "ROD")
        {
            int wid = divwidth + 20;//180;
            if (dropcap > 1)
            {
                // wid = 180;// 
                wid = divwidth + 20;
            }

            string[] splitter = mFinal.Split("<br>".ToCharArray());

            //  divwidth = divwidth - 13;
            string abc = "";
            if (uom == "ROL")
            {
                if (centertitle != "")
                {
                    if (caption == "")
                        abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;\">" + mFinal + "</div>";
                    else
                        abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;\"><center><b>" + caption + "</center></b>" + mFinal + "</div>";
                }
                else
                {
                    if (caption == "")
                        abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;\">" + mFinal + "</div>";
                    else
                        abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;\"><center><b>" + caption + "</center></b>" + mFinal + "</div>";
                }
            }
            else
            {
                if (centertitle != "")
                {
                    if (caption == "")
                        abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div>";
                    else
                        abc = "<div style=\"text-align:center;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><center><b>" + caption + "</center></b>" + mFinal + "</div>";
                }
                else
                {
                    if (caption == "")
                        abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + mFinal + "</div>";
                    else
                        abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + txtcolor + ";position:absolute;border:2px Groove;width:" + wid + "px;\"><center><b>" + caption + "</center></b>" + mFinal + "</div>";
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
            //if (Request.QueryString["boxcode"].ToString() != "0")
            //{
            //    abc = abc.Replace(Request.QueryString["boxcode"].ToString(), "<font class=boxmatter>" + Request.QueryString["boxcode"].ToString() + "</font>");
            //}
            abc = abc.Replace("", "");


            if (logo_name != "" && logo_name != "All")
                //C:\inetpub\wwwroot\LayoutX\
                abc = "<div><img width=" + wid + "px; src='" + "Orignal/" + logo_name + "'/></div>" + abc;
            if (logopremimage != "")
                abc = "<div><img width=" + wid + "px; src='" + "images/" + logopremimage + "'/></div>" + abc;
            td1.InnerHtml = abc;
            if (uom == "ROL")
                td1.InnerHtml = td1.InnerHtml.Replace("~", " ");
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
        //else
        //{
        //    //string abc = "<div style=\"text-align:justify;font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + coltype + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">+"<img src=" + ff + "/>" +" + mFinal + "</div>";
        //    int wid = divwidth + 4;
        //    string path_logo = "";
        //    string log_name = "";
        //    if (mod_log == "0" && previousid=="")
        //    {
        //        if (logo_name == "All")
        //        {
        //            //string name_log=cioid
        //            string name_log = cioid + "-" + "0" + "-" + "All";                    
        //            string filename = Session["imgname_logo"].ToString();
        //            char[] splitimg = { '+' };
        //            string[] array = filename.Split(splitimg);

        //            for (int z = 0; z < array.Length; z++)
        //            {
        //                path_logo = array[z];
        //                break;
        //            }
        //            //path_logo = name_log + "." + name_;
        //            //path_logo = Server.MapPath("~/Temp logo/" + path_logo);
        //            log_name = path_logo;
        //            path_logo = "Temp logo" + "/" + path_logo;


        //        }
        //        else
        //        {
        //            //string name_log=cioid
        //            string name_log = cioid + "-" + "0" + "-" + "All";                    
        //            string filename = Session["imgname_logo"].ToString();
        //            char[] splitimg = { '+' };
        //            string[] array = filename.Split(splitimg);
        //            for (int z = 0; z < array.Length; z++)
        //            {
        //                path_logo = array[z];
        //                break;
        //            }
        //            //path_logo = name_log + "." + name_;
        //            //path_logo = Server.MapPath("~/Temp logo/"+path_logo);
        //            log_name = path_logo;
        //            path_logo = "Temp logo" + "/" + path_logo;
        //        }

        //        /*if the material is pdf than we have to convert that pdf into jpg and than show the preview same case is for eps and tiff and for eps,tiff and pdf */
        //        ////we generate the jpg file with name abc.jpg 
        //        filename_pdf = log_name.Substring(log_name.LastIndexOf("."));
        //        if (filename_pdf == ".pdf" || filename_pdf == ".eps" || filename_pdf == ".tiff" || filename_pdf==".tif")
        //        {

        //            log_name = "abc.jpg";
        //        }

        //    }
        //    else
        //    {
        //        if (logo_name == "All")
        //        {                   

        //            DataSet dex = new DataSet();
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //            {
        //                NewAdbooking.Classes.BookingMaster showgri = new NewAdbooking.Classes.BookingMaster();
        //                if (previousid != "")
        //                {
        //                    dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
        //                }
        //                else
        //                {
        //                    dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());
        //                }
        //            }
        //            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        //            {
        //                NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();
        //                if (previousid != "")
        //                {
        //                    dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
        //                }
        //                else
        //                {
        //                    dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());
        //                }
        //            }
        //            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //            NewAdbooking.classesoracle.BookingMaster showgri = new NewAdbooking.classesoracle.BookingMaster();
        //            if (previousid != "")
        //            {
        //                dex = showgri.fetchdataforexe(previousid, Session["compcode"].ToString());
        //            }
        //            else
        //            {
        //                dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());
        //            }
        //            }

        //            //path_logo = Server.MapPath("~/Orignal logo/"+cioid+"/"+dex.Tables[9].Rows[0].ItemArray[0].ToString());
        //            if (previousid != "")
        //            {
        //                path_logo = "Orignal Logo" + "/" + previousid + "/" + dex.Tables[9].Rows[0].ItemArray[0].ToString();
        //            }
        //            else
        //            {
        //                path_logo = "Orignal Logo" + "/" + cioid + "/" + dex.Tables[9].Rows[0].ItemArray[0].ToString();
        //            }
        //            log_name = dex.Tables[9].Rows[0].ItemArray[0].ToString();

        //        }
        //        else
        //        {
        //            if (previousid != "")
        //            {
        //                path_logo = "Orignal Logo" + "/" + previousid + "/" + logo_name;
        //            }
        //            else
        //            {
        //                path_logo = "Orignal Logo" + "/" + cioid + "/" + logo_name;
        //            }
        //            log_name = logo_name;

        //        }
        //        filename_pdf = log_name.Substring(log_name.LastIndexOf("."));
        //    }


        //    double logohei_ = Convert.ToDouble(logohei) * 3.77;
        //    double logowid_ = 0;

        //    bindData(log_name);
        //    //string abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + "<img src='" + path_logo + "' width=" + logowid_ + " height=" + logohei_ + " align=\"left\"  style=\"float:left;\"/>" + " " + mFinal + "</div>";
        //    string abc = "<div style=\"text-align:justify;font-size:" + fontsize + "pt;background-color:" + bgcolor + ";color:" + coltype + ";position:absolute;border:2px Groove;width:" + wid + "px;\">" + "<img src='" + src_name + "' width=" + logowid_ + " height=" + logohei_ + " align=\"left\"  style=\"float:left;\"/>" + " " + mFinal + "</div>";

        //    abc = abc.Replace("<br>", "");
        //    if (kop != "1")
        //    {
        //        abc = abc.Replace("\r\n", "");
        //    }
        //    else
        //    {
        //        abc = abc.Replace("\r\n", "<br><br>");
        //    }
        //    if (Request.QueryString["boxcode"].ToString() != "0")
        //    {
        //        abc = abc.Replace(Request.QueryString["boxcode"].ToString(), "<font class=boxmatter>" + Request.QueryString["boxcode"].ToString() + "</font>");
        //    }
        //    td1.InnerHtml = abc;

        //}

        //td1.Attributes.Add("style", "color:red");
        //******************************************************************************************

        /* if (rowcount1 == 0)
         {
             Response.Write("<script>alert('Please Enter Words in Limit');window.close();</script>");
             return;
         }*/
        string receiptno = "";//= Request.QueryString["boxno"].ToString();
        if (receiptno == "")
            receiptno = cioid;
        //if (pubcode22 == "")
        //{
        //    if (insertid == "no")
        //    {
        //        // fileName = cioid + "-All";
        //        //fileName = copy_cioid + "-All";
        //        fileName = receiptno + "-All";
        //    }
        //    else
        //    {
        //        //fileName = cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        //        //fileName = copy_cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        //        fileName = receiptno + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        //    }
        //}
        //else
        //{
        //    if (insertid == "no")
        //    {
        //        // fileName = cioid + "-All";
        //        //fileName = copy_cioid + "-All";
        //        fileName = receiptno + "-" + pubcode22;
        //    }
        //    else
        //    {
        //        //fileName = cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        //        //fileName = copy_cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        //        fileName = receiptno + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1) + "-" + pubcode22;
        //    }

        //}
        fileName = receiptno + "-" + pubcode22;
        //fileName = fileName + ".txt";// for indesign
        fileName = fileName + ".xtg";// for quark

        System.IO.Directory.CreateDirectory(Server.MapPath("xtg"));
        FileStream fs = null;

        //fs = new FileStream(path + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
        fs = new FileStream(Server.MapPath("xtg") + "\\" + fileName.Replace("/", ""), FileMode.Create, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
        fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND}", "");
        fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND", "");

        // fileData_indesign = fileData_indesign.Replace("color=blackWHITEAND}", "");
        if (matter.IndexOf("SHREE-KAN7") >= 0)
        {
            fileData_indesign = fileData_indesign.Replace("cTypeface:Normal", "cTypeface:Regular");
            fileData_indesign = fileData_indesign.Replace("cTypeface:Regular", "cTypeface:Bold");

        }
        else if (style == 4)
        {
            fileData_indesign = fileData_indesign.Replace("cTypeface:Normal", "cTypeface:Bold");
            fileData_indesign = fileData_indesign.Replace("cTypeface:Regular", "cTypeface:Bold");
        }
        fileData_indesign = fileData_indesign.Replace("<cFont:Gandhi>", "<cFont:Gandhi>");
        // fileData_indesign = fileData_indesign.Replace("<cFont:Gandhi>", "<cFont:Bhaskar>");
        //sw.Write(fileData_indesign);// for indesign XTG
        sw.Write(fileData);// FOR QUARK
        // sw.WriteLine(htFinal);

        sw.Flush();
        sw.Dispose();
        fs.Dispose();

        //System.IO.Directory.CreateDirectory(Server.MapPath("/htdemo/")+cioid);
        //System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/") + cioid);
        //////if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        //////{
        //////    //System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/") + copy_cioid);
        //////    System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/matter/xtg/") + receiptno);
        //////}
        //////else
        //////{
        //////    //System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/") + copy_cioid);
        //////    System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/matter/xtg/") + receiptno);
        //////}
        //////FileStream fs = null;
        ////////FileStream fs = new FileStream(Server.MapPath("/webdir/") + cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
        //////if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        //////{
        //////    //fs = new FileStream(Server.MapPath("/webdir/") + copy_cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
        //////    fs = new FileStream(Server.MapPath("/webdir/matter/xtg/") + receiptno + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);

        //////}
        //////else
        //////{
        //////    //fs = new FileStream(Server.MapPath("/webdir/") + copy_cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
        //////    fs = new FileStream(Server.MapPath("/webdir/matter/xtg/") + receiptno + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
        //////}
        //////StreamWriter sw = new StreamWriter(fs);

        Session["fileName"] = fileName;
        ScriptManager.RegisterClientScriptBlock(this, typeof(matterprevproofread), "FN", "window.opener.document.getElementById('hiddenFileName').value='" + fileName.ToString() + "';", true);

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
            box_matter = box_matter.Replace("<font face=Gautami>", "");
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
        if (caption != "")
            dr_data["rtfformat"] = caption.ToString() + "<br>" + sFinal.ToString();
        else
        {
            dr_data["rtfformat"] = sFinal.ToString();
        }
        fileData = fileData.Replace("&amp;", "&");
        fileData = fileData.Replace("&gt;", ">");
        fileData = fileData.Replace("&lt;", "<");
        fileData = fileData.Replace("<P>", "");
        fileData = fileData.Replace("</P>", "");
        fileData = fileData.Replace("", "");
        //dr_data["xtgformat"] = fileData_indesign.ToString();//fileData.ToString();//fileData.ToString();
        dr_data["xtgformat"] = fileData.ToString();//fileData.ToString();
        if (box_matter != "")
            Session["matter_session_proof"] = Session["matter_session_proof"].ToString().Replace(box_matter, "");
        dr_data["matter"] = Session["matterText_session_proof"].ToString();

        if (flag == "0")
        {
            dt_data.Rows.Add(dr_data);
            ds_data.Tables.Add(dt_data);
        }
        else
        {
            ds_data.Tables[tableCount].Rows.Add(dr_data);
        }
        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
            //csModify.updateMatterDetail(plainmatter, sFinal, fileData, fileName, cioid, Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
            //csModify.updateMatterDetail_new(plainmatter, sFinal, fileData, fileName, cioid, Session["userid"].ToString());

        }
        //Session["saveColor"] = txtcolor;
        Session["savedata1"] = ds_data;
        //Session["copy_matter"] = null;
        //Response.Write("<script>window.open('Editor.aspx');</script>");
        //ScriptManager.RegisterClientScriptBlock(this, typeof(matterprev), "FN", "window.opener.document.getElementById('hiddenFileName').value='" + fileName.ToString() + "';", true);
        //************************************************************************************************   
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
        string matterW = Session["matter_session_proof"].ToString().Trim();
        matterW = matterW.Replace("\r\n", " ");
        matterW = matterW.Replace("<br>", " ");
        matterW = matterW.Replace("<BR>", " ");
        string matterWordCount = matterW.ToString().Trim();
        //change for dainik bhaskar         ////if (boxmatter_string != "")
        ////{
        ////    matterWordCount = matterWordCount + " " + boxmatter_string;
        ////}
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
        // if (font.Name != "Gandhi")
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

        boldcharacter = boldcharacter.Replace("&amp;", ">");
        boldcharacter = boldcharacter.Replace("&gt;", ">");
        boldcharacter = boldcharacter.Replace("&lt;", ">");
        boldcharacter = boldcharacter.Replace("\r\n", "");

        //    strongmatter = strongmatter.Substring(strongmatter.IndexOf("</STRONG>") + 9);
        //}

        char[] arr = boldcharacter.ToCharArray();

        int boldlen = boldcharacter.Length;
        //if (boldcharacter.IndexOf("\\") > 0)
        //    boldlen = boldlen + 1;
        if (dschar.Tables.Count > 0 && dschar.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr.Length > (i + 1))
                    if (arr[i].ToString() + arr[i + 1].ToString() == "Sç" || arr[i].ToString() + arr[i + 1].ToString() == "mª" || arr[i].ToString() + arr[i + 1].ToString() == "¹o")
                    {
                        boldlen = boldlen - 1;

                    }


                for (int j = 0; j < dschar.Tables[0].Rows.Count; j++)
                {
                    if (arr[i].ToString() == dschar.Tables[0].Rows[j].ItemArray[0].ToString())
                    {
                        boldlen = boldlen - 1;

                    }

                }
            }
        }

        if (matterhtml1.ToString().IndexOf(" ") == 0)
            boldlen = boldlen - 1;
        return boldlen;
    }





    public int allcharcount_english(string matterhtml1)
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

        boldcharacter = boldcharacter.Replace("&amp;", ">");
        boldcharacter = boldcharacter.Replace("&gt;", ">");
        boldcharacter = boldcharacter.Replace("&lt;", ">");
        boldcharacter = boldcharacter.Replace("\r\n", "");

        //    strongmatter = strongmatter.Substring(strongmatter.IndexOf("</STRONG>") + 9);
        //}

        char[] arr = boldcharacter.ToCharArray();

        int boldlen = boldcharacter.Length;
        //if (boldcharacter.IndexOf("\\") > 0)
        //    boldlen = boldlen + 1;
        if (dschar.Tables.Count > 0 && dschar.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < dschar.Tables[1].Rows.Count; j++)
                {
                    if (arr[i].ToString() == dschar.Tables[1].Rows[j].ItemArray[0].ToString())
                    {
                        boldlen = boldlen - 1;

                    }

                }
            }
        }


        return boldlen;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public DataSet findpub(string package_)
    {
        DataSet dspub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), package_);

        }

        //if (dspub.Tables[0].Rows.Count > 0)
        //{

        //    string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
        //    string[] datapuv1 = datapuv.Split(',');
        //    var length1 = datapuv1.Length;
        //    hiddenpublicode.Value = length1;
        //}
        return dspub;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void findmatterpub(string publication)
    {
        DataSet ds_matterFile = new DataSet();
        ds_matterFile = (DataSet)Session["savedata1"];
        string matter_cioid = ds_matterFile.Tables[0].Rows[0].ItemArray[0].ToString();
        string matter_filename = ds_matterFile.Tables[0].Rows[0].ItemArray[1].ToString();
        string matter_RTF = ds_matterFile.Tables[0].Rows[0].ItemArray[2].ToString();
        string matter_XTG = ds_matterFile.Tables[0].Rows[0].ItemArray[3].ToString();
        string matter = ds_matterFile.Tables[0].Rows[0].ItemArray[4].ToString();
        string lang = "";
        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
            //csModify.updateMatterDetail(plainmatter, sFinal, fileData, fileName, cioid, Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
            csModify.updateMatterDetail(matter, matter_RTF, matter_XTG, matter_filename, matter_cioid, Session["userid"].ToString(), 0, publication);

        }
        Session["savedata1"] = null;
    }
}
