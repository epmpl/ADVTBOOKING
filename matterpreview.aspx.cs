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

public partial class matterpreview : System.Web.UI.Page
{
    private string fetchFont(string matter)
    {
      
        string data = matter;
        string finaldata = "";
        string fontname = "";
        string fontDefault = "";
        // int index = td1.InnerHtml.IndexOf("<font ");
        while (data.IndexOf("<FONT ") >= 0 || data.Length > 0)
        {
            int index = data.IndexOf("<FONT ");
            int index1;
            int index2;


            if (index == 0)
            {
                index1 = data.IndexOf("<FONT face=");
                index2 = data.IndexOf(">");
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
                        index4 = data.Length ;
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
        return finaldata;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        /*new change ankur 17feb*/
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }

        //*****************By Manish Verma******************************
        DataSet ds_data = new DataSet();
        DataTable dt_data = new DataTable();
        DataRow dr_data = dt_data.NewRow();
        DataColumn dc_data;
        int tableCount=0;

        string fileName;
        string flag="0";
        string mFinal = "";
        //****************************************************************

        string matter = "";
        string data = "";
        string uom = "";
        string uom_desc = "";

        //matter = Request.QueryString["matter"].ToString();//Session["matter"].ToString();
        /*new change ankur for matter*/
        matter = Session["matter_session"].ToString();
        matter = matter.Replace("^", "#");
        uom = Request.QueryString["hiddenuom"].ToString();
        Hiddeninser.Value = Request.QueryString["hiddeninsert"].ToString();

        //**************By Manish Verma********************************
        string edition = Request.QueryString["edition"].ToString();
        string insertid = Request.QueryString["hiddeninsert"].ToString();
        string cioid = Request.QueryString["cioid"].ToString();
        string srno = Request.QueryString["srno"].ToString();
        //*************************************************************
        /*new change ankur 9 feb*/
        string coltype = Request.QueryString["coltype"].ToString();

        //**************By Manish Verma********************************
        DataSet dsStyleSheet;
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.BookingMaster getStyle=new NewAdbooking.Classes.BookingMaster();
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
            NewAdbooking.classmysql .BookingMaster getStyle = new NewAdbooking.classmysql.BookingMaster();
            dsStyleSheet = getStyle.fetchStyleSheetName(uom);

        }
        /*new change ankur 17 feb*/
        uom_desc = dsStyleSheet.Tables[0].Rows[0].ItemArray[1].ToString();
        string sSheet = dsStyleSheet.Tables[0].Rows[0].ItemArray[0].ToString();
        //*************************************************************

        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
       objDataSetbu.ReadXml(Server.MapPath("XML/" + sSheet + ".xml"));
        data = fetchFont(matter);
        Graphics a;
        double colwidth =Convert.ToDouble(Request.QueryString["hiddenwidth"]);//3.8;
        colwidth = 43/10;//to convert  mm to cm
        double bitmapwidth = (96 / 2.54) * colwidth;//96 is bitmal verticalresolution and 2.54 is the cm. in 1 inch.
        Bitmap bmpDummy = new Bitmap(Convert.ToInt32(bitmapwidth), 100);
        int widthD = Convert.ToInt32(bitmapwidth);
        a = Graphics.FromImage(bmpDummy);
        int style = Convert.ToInt32(objDataSetbu.Tables[0].Rows[0].ItemArray[1]);//0 means first word bold and 1 means first line bold
        SizeF k;
        string fontname = "0";
        string fontsize = "0";
        int count = 1;
        //fontname = Request.QueryString["fontname"].ToString();
        //fontsize = Request.QueryString["fontsize"].ToString();
        if (fontname == "0")
            fontname = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        if (fontsize == "0")
            fontsize = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        string[] strarr;
       
        float width1 = 0;
        string final = "";
        string fstFName = "";//By Manish Verma
        string fileData = "";//By Manish Verma
        int divwidth = widthD;
        int height = 0;
        int dropcap = 0;
        
        string eyecatcher = Request.QueryString["eyecatch"].ToString();// "♥";
        int eyecatcherlen =  Convert.ToInt32(Request.QueryString["eyecatchlen"].ToString());
        string bgcolor = Request.QueryString["bgcolor"].ToString();
        /*new change ankur for matter*/
        string logo_name = Request.QueryString["logo_name"].ToString();
        string mod_log = Request.QueryString["modify_logo"].ToString();
        /////////////////////////////////////////
        
        string dropcapString = "";                                                                                                                                                                                                          
        string eyecatchstr = "";
        if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher != "0" && eyecatcher!="")
        {

            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
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
                }
                else
                {
                    NewAdbooking.classmysql.bulletmaster clsbullet = new NewAdbooking.classmysql.bulletmaster();
                    DataSet ds = clsbullet.getSymbol(eyecatcher, Session["compcode"].ToString());
                    eyecatchstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                }
        }
        if (eyecatcher != "0" && eyecatcherlen > 1)
        {
            dropcap = eyecatcherlen;
        }
        dropcapString = data.Substring(0, 1);
        strarr = data.Split(' ');
        //float fontsi = Convert.ToInt64(fontsize);
        float fontsi = float.Parse(fontsize);
        for (int i = 0; i < strarr.Length; i++)
        {
            string fname = "";
            string fdata = "";
            fname = strarr[i].Substring(strarr[i].IndexOf("{"), strarr[i].Length - strarr[i].IndexOf("{"));
            fname = fname.Replace("}", "");
            fname = fname.Replace("{", "");
            fdata = strarr[i].Substring(0, strarr[i].IndexOf("{"));

            if (fname == "")
                if (ConfigurationSettings.AppSettings["language"].ToString() != "multi")
                {
                    fname = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    fname = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
                }
            //Font f = new Font("Arial", 9, FontStyle.Bold);
            Font f;
            if (style == 0)
                f = new Font(fname, 8, FontStyle.Bold);
            else if (style == 1)
                f = new Font(fname, 8, FontStyle.Bold);
            else if (style == 2)
                f = new Font(fname, 8);
            else if (style == 3)
                f = new Font(fname, 8, FontStyle.Bold);
            else if (style == 5)
                f = new Font(fname, 8, FontStyle.Bold);
            else
                f = new Font(fname, 8);
            if (i != 0)
                fdata = " " + fdata;

            //textData = textData + fdata;

            k = a.MeasureString(fdata, f);
            height =Convert.ToInt32(k.Height);
            double tot_wid = (divwidth + colwidth * 2.54) + colwidth;
           // if ((k.Width + width1) - (colwidth * 2.54) >= tot_wid)
            if (width1 >= tot_wid)
            {
                float w = k.Width;
              
                    final = final.Substring(0, final.Length);
                    mFinal = mFinal.Substring(0, mFinal.Length);
                    if (final.IndexOf("\\l") < 0 && style == 1)
                    {
                        style = 2;
                        final = "<b>" + final + "</b>";
                    }

                    if (mFinal.IndexOf("\\l") < 0 && style == 1)
                    {
                        style = 2;
                        mFinal = "<b>" + mFinal + "</b>";
                    }
                   

                    final = final + "\\l<font face="+fname+">" + fdata + "</font> ";
                    
                    count = count + 1;
                    width1 = w;
                    if (dropcap > 1)
                    {
                        dropcap = 0;
                        k = a.MeasureString(dropcapString, f);
                        width1 = width1 + k.Width;
                    }

                    //*************Manish Verma****************/
                    if (final == "")
                    {
                        fstFName = fname;
                        fileData = "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                        mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                    }

                    else if (fstFName == fname)
                    {
                        if (ConfigurationSettings.AppSettings["language"] != "multi")
                        {

                            fileData = fileData + fdata;
                            mFinal = mFinal + fdata;
                        }
                        else
                        {
                            mFinal += "<font face=" + fname + ">" + fdata + "</font>";
                        }
                    }
                    else
                    {
                        fstFName = fname;
                        fileData = fileData + "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                        mFinal = mFinal + "</font>";
                        mFinal = mFinal + "\\l<font face=" + fname + ">" + fdata;
                    }
                    //mFinal = mFinal + "</font>";
                    //***************************************
              //  }
                //-------------------------
               
            }
            else
            {
                width1 = width1 + k.Width;
                if (i == strarr.Length - 1)
                {
                    //*************Manish Verma****************
                    if (final == "")
                    {
                        fstFName = fname;                        
                        fileData = "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                        mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                    }

                    else if (fstFName == fname)
                    {
                        if (ConfigurationSettings.AppSettings["language"] != "multi")
                        {

                            fileData = fileData + fdata;
                            mFinal = mFinal + fdata;
                        }
                        else
                        {
                            mFinal += "<font face=" + fname + ">" + fdata + "</font>";
                        }
                    }
                    else
                    {
                        fstFName = fname;
                        fileData = fileData + "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                        mFinal = mFinal + "</font>";
                        mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                    }
                    //mFinal = mFinal + "</font>";
                    //***************************************
                    final = final + "<font face=" + fname + ">" + fdata + "</font>";
                }
                else
                {
                    //*************Manish Verma****************
                    if (final == "")
                    {
                        fstFName = fname;
                        if (dropcap > 1 && i == 0)
                        {
                            if (eyecatcher == "DR")
                            {
                                fileData = "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + "><*d(1,"+dropcap+">" + fdata;
                            }
                        }
                        else
                        {
                            fileData = "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                        }
                        mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                    }

                    else if (fstFName == fname)
                    {
                        fileData = fileData + fdata;
                        mFinal = mFinal + fdata;
                    }
                    else
                    {
                        fstFName = fname;
                        fileData = fileData + "<*p(0,0,0,13,0,0,g,\"U.S. English\")z" + fontsize + "f\"" + fname + "\"" + ">" + fdata;
                        mFinal = mFinal + "</font>";
                        mFinal = mFinal + "<font face=" + fname + ">" + fdata;
                    }
                    //mFinal = mFinal + "</font>";
                    //***************************************
                    final = final + "<font face=" + fname + ">" + fdata + "</font>";
                }
                
            }
            if (dropcap > 1 && i == 0)
            {
                if (eyecatcher == "DR")
                {
                    mFinal = mFinal + "</font>";
                    final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1) + "</span>" + fdata.Substring(1, fdata.Length - 1);
                    mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:" + fname + ";padding:1px;line-height:1em;\">" + fdata.Substring(0, 1) + "</span>" + fdata.Substring(1, fdata.Length - 1);
                }
                else
                {
                    if (eyecatcher != "DR" && eyecatcher != "BO" && eyecatcher!="0")
                    {
                        mFinal = mFinal + "</font>";
                        if (eyecatcher == "HR")
                        {
                            final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                            mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Webdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                        }
                        else {
                            final = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Wingdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + final;
                            mFinal = "<span style=\"border:0px solid;float:left;font-size:" + dropcap + "em;font-family:Wingdings;padding:1px;line-height:1em;\">" + eyecatchstr + "</span>" + mFinal;
                        }
                    }
                }
                //final = "<span style=\"border:1px solid;float:left;font-size:12px;font-family:Arial;padding:1px;line-height:1em;\">" + final.Substring(0, 1) + "</span>" + final.Substring(1, final.Length - 1);
            }
            else
            {
                if (eyecatcher != "0" && i == 0)
                {
                    if (eyecatcher != "DR" && eyecatcher != "BO")
                    {
                        mFinal = mFinal + "</font>";
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
                    }
                   
                }
            }
            if (style == 0)
            {
                style = 2;
                final = "<b>" + final + "</b>";
                mFinal = "<b>" + mFinal + "</b>";
            }

            if (style == 3 && i==2)
            {
                style = 2;
                final = "<b>" + final + "</b>";
                mFinal = "<b>" + mFinal + "</b>";
            }

            if (style == 5 && i == 4)
            {
                style = 2;
                final = "<b>" + final + "</b>";
                mFinal = "<b>" + mFinal + "</b>";
            }

           
            f.Dispose();

        }
       /// int cou=final.
        mFinal = mFinal + "</font>";
        final = final.Replace("\\l", "<br>");
        mFinal = mFinal.Replace("\\l", "<br>");
        /*new change ankur 17 feb*/
        if (uom_desc == "ROL" || uom_desc=="ROD")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(matterpreview), "zz6", "window.opener.document.getElementById('txtnoofline').value=" + count.ToString() + ";", true);
        }
        else if (uom_desc == "ROW")
        {
            int words = strarr.Length;
            ScriptManager.RegisterClientScriptBlock(this, typeof(matterpreview), "zz6", "window.opener.document.getElementById('txtnoofline').value=" + words.ToString() + ";", true);
        }
        else if (uom_desc == "ROC")
        {
           
            int words = strarr.Length;
            ScriptManager.RegisterClientScriptBlock(this, typeof(matterpreview), "zz6", "window.opener.document.getElementById('txtnoofline').value=" + words.ToString() + ";", true);
        }

       ScriptManager.RegisterClientScriptBlock(this, typeof(matterpreview), "zz1", "parentid('"+Hiddeninser.Value+"');", true);
        int h = Convert.ToInt32(height) * (count+1);
      //  h = h + (height / 2);
        if (eyecatcher == "BO")
        {
            int wid = divwidth + 4;
            /*new change ankur 15 feb*/

            final = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + coltype + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + final + "</div></div>";
            mFinal = "<div style=\"text-align:justify;font-size:11px;background-color:White;position:absolute;border:2px Groove;width:" + wid + "px;height:" + h + "px;\">" + "<div style=\"font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + coltype + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + mFinal + "</div></div>";
          
            //td1.InnerHtml = final;
            mFinal = mFinal.Replace("<br>", "");
            td1.InnerHtml = mFinal;
        }
        else if (uom_desc != "ROD")
        {
            //td1.InnerHtml = "<div style=\"text-align:justify;font-size:" + fontsize + "px;background-color:" + bgcolor + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + final + "</div>";
            /*new change ankur 15 feb*/
            /*new change ankur for matter*/
           

            string abc = "<div style=\"text-align:justify;font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + coltype + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + mFinal + "</div>";
            abc = abc.Replace("<br>", "");
            td1.InnerHtml = abc;

        }
        else
        {
            //string abc = "<div style=\"text-align:justify;font-size:" + fontsize + "px;background-color:" + bgcolor + ";color:" + coltype + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">+"<img src=" + ff + "/>" +" + mFinal + "</div>";
            string path_logo = "";
            if (mod_log == "0")
            {
                if (logo_name == "All")
                {
                    //string name_log=cioid
                    string name_log = cioid + "-" + "0" + "-" + "All";
                    string name_ = "";
                    string filename = Session["imgname_logo"].ToString();
                    char[] splitimg = { '+' };
                    string[] array = filename.Split(splitimg);
                    
                    for (int z = 0; z < array.Length; z++)
                    {
                        path_logo = array[z];
                        break;
                    }
                    //path_logo = name_log + "." + name_;
                    //path_logo = Server.MapPath("~/Temp logo/" + path_logo);
                    path_logo =  "Temp logo" + "/" + path_logo;


                }
                else
                {
                    //string name_log=cioid
                    string name_log = cioid + "-" + "0" + "-" + "All";
                    string name_ = "";
                    string filename = Session["imgname_logo"].ToString();
                    char[] splitimg = { '+' };
                    string[] array = filename.Split(splitimg);
                    for (int z = 0; z < array.Length; z++)
                    {
                        path_logo = array[z];
                        break;
                    }
                    //path_logo = name_log + "." + name_;
                    //path_logo = Server.MapPath("~/Temp logo/"+path_logo);
                    path_logo =  "Temp logo" + "/" + path_logo;
                }
              
            }
            else
            {
                if (logo_name == "All")
                {
                    //string name_log=cioid
                    
                    /*new change ankur for matter*/
                    DataSet dex = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.BookingMaster showgri = new NewAdbooking.Classes.BookingMaster();

                        dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());
                    }
                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.BookingMaster showgri = new NewAdbooking.classesoracle.BookingMaster();

                            dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());

                        }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster showgri = new NewAdbooking.classmysql.BookingMaster();

                        dex = showgri.fetchdataforexe(cioid, Session["compcode"].ToString());
                    }
                 
                    //path_logo = Server.MapPath("~/Orignal logo/"+cioid+"/"+dex.Tables[9].Rows[0].ItemArray[0].ToString());
                    path_logo =  "Orignal Logo" + "/" + cioid + "/" + dex.Tables[9].Rows[0].ItemArray[0].ToString();

                }
                else
                {
                    //path_logo = Server.MapPath("~/Orignal Logo/" + cioid + "/" + logo_name);
                    path_logo =  "Orignal Logo" + "/" + cioid + "/" + logo_name;

                }
            }

            //string abc = "<div style=\"text-align:justify;font-size:" + fontsize + "px;background-color:" + bgcolor + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + "<img src='" + path_logo + "'/>" + " " + mFinal + "</div>";
            /*new change ankur for matter*/
            string abc = "<div  style=\"text-align:left;width:98%;\" ><div style=\"text-align:justify;font-size:" + fontsize + "px;background-color:" + bgcolor + ";position:absolute;border:2px Groove;width:" + divwidth + "px;\">" + "<img src='" + path_logo + "' align=\"left\" hspace=\"5\" style=\"float:left;\"/>" + " " + mFinal + "</div><div style=\"clear:both;\"></div>";
            abc = abc.Replace("<br>", "");
            td1.InnerHtml = abc;

        }

        //**************By Manish Verma*************************************************************

        if (insertid == "no")
        {
            fileName = cioid + "-All";
        }
        else
        {
            fileName = cioid + "-" + (Convert.ToInt32(Request.QueryString["insertNo"].ToString())) + "-" + (Convert.ToInt32(srno) + 1);
        }

        fileName = fileName + ".xtg";

        //System.IO.Directory.CreateDirectory(Server.MapPath("/htdemo/")+cioid);
        System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/") + cioid);
        FileStream fs = new FileStream(Server.MapPath("/webdir/") + cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(fs);

        Session["fileName"] = fileName;
        ScriptManager.RegisterClientScriptBlock(this, typeof(matterpreview), "FN", "window.opener.document.getElementById('hiddenFileName').value='" + fileName.ToString() + "';", true);
        sw.WriteLine(fileData);
        //sw.WriteLine(mFinal);

        sw.Flush();
        sw.Dispose();
        fs.Dispose();

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
                //else
                //{
                //    dr_data = dt_data.NewRow();
                //}
            }
        }
        //else
        //{
        //    dr_data = dt_data.NewRow();
        //}
        
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

        dr_data["cioid"] = cioid.ToString();
        dr_data["filename"] = fileName.ToString();
        dr_data["rtfformat"] = mFinal.ToString();
        dr_data["xtgformat"] = fileData.ToString();
        //dr_data["matter"] = Request.QueryString["matterText"].ToString();
        /*new change ankur for matter*/
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
        //************************************************************************************************   
   }

}
