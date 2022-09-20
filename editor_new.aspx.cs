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
using System.Text.RegularExpressions;
using System.Globalization;

public partial class editor_new : System.Web.UI.Page
{
    DataSet dsModify_tem = new DataSet();
    string previd = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string receiptno = "";

        Response.Expires = -1;
        if (Request.QueryString["prevcioid"] != null)
        {
            hiddenpreviousid.Value = Request.QueryString["prevcioid"].ToString();
        }
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }

        hiddenuom_desc.Value = Request.QueryString["uom_desc_"].ToString();
        //if (Session["insertname_logo"] == null && hiddenuom_desc.Value == "ROD" && Request.QueryString["modify"].ToString() == "0" && Request.QueryString["prevcioid"] == "")
        //{
        //   Response.Write("<script>alert(\"Please upload the logo\");window.close();</script>");
        //}

        Ajax.Utility.RegisterTypeForAjax(typeof(editor_new));
        cioid.Value = Request.QueryString["cioid"].ToString();
        hiddensrno.Value = Request.QueryString["srno"].ToString();
        hiddenedition.Value = Request.QueryString["edition"].ToString();
        hiddeneyecatcher.Value = Request.QueryString["eyecatch"].ToString();
        if (Request.QueryString["insertsta"] != null)
            hiddeninsertstatus.Value = Request.QueryString["insertsta"].ToString();

        hiddenbgcolor.Value = Request.QueryString["bgcolor"].ToString();

        hiddenuom_desc.Value = Request.QueryString["uom_desc_"].ToString();

        hiddencoltype.Value = Request.QueryString["coltype"].ToString();

        /////////////this is to get the bgcolor name         
        if (Request.QueryString["name_logo"] != null)
            hiddenlogoname.Value = Request.QueryString["name_logo"].ToString();
        ////////////////////////////        
        if (Request.QueryString["name_logo"] != null)
            hiddenlogoname.Value = Request.QueryString["name_logo"].ToString();

        if (Request.QueryString["prevcioid"] != null)
            previd = Request.QueryString["prevcioid"].ToString();
        if (hiddenuom_desc.Value == "ROD")
        {
            hiddenlogohei.Value = Request.QueryString["logohei"].ToString();
            hiddenlogowid.Value = Request.QueryString["logowid"].ToString();
        }
        else
        {
            hiddenlogohei.Value = "nologo";
            hiddenlogowid.Value = "nologo";

        }
        string logoprem = "";
        hiddenlogoprem.Value = "";
        if (Request.QueryString["logoprem"] != null && Request.QueryString["logoprem"].ToString() != "0" && Request.QueryString["logoprem"].ToString() != "")
        {
            //hiddenlogoprem.Value 
            logoprem = Request.QueryString["logoprem"].ToString();
            DataSet logopremDataSet;
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adbooking getStyle = new NewAdbooking.Classes.adbooking();
                logopremDataSet = getStyle.logopremimage(Request.QueryString["logoprem"].ToString());
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.adbooking getStyle = new NewAdbooking.classesoracle.adbooking();
                    logopremDataSet = getStyle.logopremimage(Request.QueryString["logoprem"].ToString());
                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster getStyle = new NewAdbooking.classmysql.BookingMaster();
                    logopremDataSet = getStyle.fetchStyleSheetName(Request.QueryString["logoprem"].ToString());

                }
            hiddenlogoprem.Value = logopremDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        DataSet dsStyleSheet;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getStyle = new NewAdbooking.Classes.BookingMaster();
            dsStyleSheet = getStyle.fetchStyleSheetName(Request.QueryString["uom"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getStyle = new NewAdbooking.classesoracle.BookingMaster();
                dsStyleSheet = getStyle.fetchStyleSheetName(Request.QueryString["uom"].ToString());
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getStyle = new NewAdbooking.classmysql.BookingMaster();
                dsStyleSheet = getStyle.fetchStyleSheetName(Request.QueryString["uom"].ToString());

            }
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        string sSheet = dsStyleSheet.Tables[0].Rows[0].ItemArray[0].ToString();
        objDataSetbu.ReadXml(Server.MapPath("XML/" + sSheet + ".xml"));
        if (Request.QueryString["logo"] != null && Request.QueryString["logo"].ToString() == "yes")
        {
            tdlogo.Visible = true;
            txtlogohei.Value = objDataSetbu.Tables[3].Rows[0].ItemArray[0].ToString();
            txtlogowid.Value = objDataSetbu.Tables[3].Rows[0].ItemArray[1].ToString();
            btnlogoupload.Enabled = true;

        }
        else
        {
            txtlogohei.Value = "";
            txtlogowid.Value = "";
            tdlogo.Visible = false;
        }
        DataSet dsgetbgname = new DataSet();
        if (hiddenbgcolor.Value != "White")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                dsgetbgname = getpubwidth.getwidth_qbc(hiddenbgcolor.Value, Session["compcode"].ToString());
            }
            else

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                    dsgetbgname = getpubwidth.getwidth_qbc(hiddenbgcolor.Value, Session["compcode"].ToString());
                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();
                    dsgetbgname = getpubwidth.getwidth_qbc(hiddenbgcolor.Value, Session["compcode"].ToString());

                }
            if (dsgetbgname.Tables[1].Rows.Count > 0)
            {
                hiddenbgcolor.Value = dsgetbgname.Tables[1].Rows[0].ItemArray[0].ToString();
            }

        }

        //////////////////////////////////////////////////////////////////////////////////

        if (hiddenbgcolor.Value != "White")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                dsgetbgname = getpubwidth.getwidth_qbc(hiddencoltype.Value, Session["compcode"].ToString());
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                    dsgetbgname = getpubwidth.getwidth_qbc(hiddencoltype.Value, Session["compcode"].ToString());
                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();
                    dsgetbgname = getpubwidth.getwidth_qbc(hiddencoltype.Value, Session["compcode"].ToString());
                }
            if (dsgetbgname.Tables[2].Rows.Count > 0)
            {
                hiddencoltype.Value = dsgetbgname.Tables[2].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                hiddencoltype.Value = "";
            }

        }

        string edition_ = Request.QueryString["width"].ToString();
        edition_ = edition_.Replace("^", "+");

        DataSet dsgetwidth = new DataSet();
        /*  this to calculate the width for publication*/
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();

            dsgetwidth = getpubwidth.getwidth_qbc(edition_, Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                //25sep
                if (edition_.IndexOf("(") > 0)
                    edition_ = edition_.Split('(')[0];

                dsgetwidth = getpubwidth.getwidth_qbc(edition_, Session["compcode"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();
                dsgetwidth = getpubwidth.getwidth_qbc(edition_, Session["compcode"].ToString());
            }
        if (dsgetwidth.Tables[0].Rows.Count > 0)
            hiddenwidth.Value = dsgetwidth.Tables[0].Rows[0].ItemArray[0].ToString();

        ////////////////////////////////////////////////////////////

        hiddenuom.Value = Request.QueryString["uom"].ToString();
        if (!Page.IsPostBack)
        {
            bindspecialcharacter();
            btnlogoupload.Attributes.Add("onclick", "javascript:return uploadlogoall();");
            btnprev.Attributes.Add("OnClick", "javascript:return buttonprev();");
            btncalline.Attributes.Add("OnClick", "javascript:return buttonprev();");
            //btnprev.Attributes.Add("OnClick", "javascript:return preview();");
            lbpickchar.Attributes.Add("onclick", "insertintomatter();");
            btnCopytoEditor.Attributes.Add("onclick", "javascript:return copyMatter();");
            //  editordiv.Attributes.Add("onChange", "javascript:return getFontname();");
            // editordiv.Attributes.Add("onkeypress", "javascript:return replacekey();");
            // editordiv.Attributes.Add("onkeydown", "javascript:return replacekey(event);");
        }

        hiddeneyecatchlength.Value = Request.QueryString["eyecatchlength"].ToString();
        hiddeninsert.Value = Request.QueryString["insertid"].ToString();

        hiddenInsertNo.Value = Request.QueryString["insertNo"].ToString();
        string modify = Request.QueryString["modify"].ToString();
        hiddenmodify.Value = Request.QueryString["modify"].ToString();

        //****************By Manish Verma***************************
        //if (Request.QueryString["line"].ToString() != "")
        //{
        //    txtnoofline.Text = Request.QueryString["line"].ToString();
        //}
        /*change for oracle*/
        //this is the case when the user want to copy the contents 

        if (Session["savedata"] == null)
        {
            if (hiddensrno.Value == "All")
            {
                //string fname = previd + "-All.xtg";
                string fname = receiptno + "-All.xtg";
                getMatterData_prev(fname);

                if (tdlogo.Visible == true && Request.QueryString["name_logo"] != null)
                    txtlogoupload.Value = Request.QueryString["name_logo"].ToString();
                if( Request.QueryString["logohei"] != null)
                txtlogohei.Value = Request.QueryString["logohei"].ToString();
                if (Request.QueryString["logowid"] != null)
                txtlogowid.Value = Request.QueryString["logowid"].ToString();



             
            }
            else
            {
                string fname = Request.QueryString["filename"].ToString();
                if (tdlogo.Visible == true && Request.QueryString["name_logo"] != null)
                    txtlogoupload.Value = Request.QueryString["name_logo"].ToString();

                txtlogohei.Value = Request.QueryString["logohei"].ToString();
                txtlogowid.Value = Request.QueryString["logowid"].ToString();
                getMatterData(fname);
            }
        }
        else
        {
            string fname = Request.QueryString["filename"].ToString();
            if (tdlogo.Visible == true && Request.QueryString["name_logo"] != null)
                txtlogoupload.Value = Request.QueryString["name_logo"].ToString();

            txtlogohei.Value = Request.QueryString["logohei"].ToString();
            txtlogowid.Value = Request.QueryString["logowid"].ToString();
            getMatterData(fname);
        }
        if (modify == "0" && (dsModify_tem.Tables.Count <= 0 || dsModify_tem.Tables[0].Rows.Count <= 0))
        {
            if (Session["savedata"] != null)
            {

                DataSet ds = (DataSet)Session["savedata"];
                //string fileName = Request.QueryString["filename"].ToString();
                if (Request.QueryString["filename"].ToString() != "")
                {
                    if (hiddensrno.Value == "All")
                    {
                        string data = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                        data = data.Replace("<br>", "");
                        data = data.Replace("style='font-size:8pt'", "");
                        data = data.Replace("style='font-size:7pt'", "");
                        data = data.Replace("style='font-size:6pt'", "");
                        data = data.Replace("style='font-size:6.2pt'", "");
                        editordiv.InnerHtml = data;
                        if (tdlogo.Visible == true && Request.QueryString["logoname"] != null)
                            txtlogoupload.Value = Request.QueryString["logoname"].ToString();
                    }
                    else
                    {
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            if (ds.Tables[i].Rows[0].ItemArray[1].ToString() == Request.QueryString["filename"].ToString())
                            {
                                string data = ds.Tables[i].Rows[0].ItemArray[2].ToString();
                                data = data.Replace("<br>", "");
                                data = data.Replace("style='font-size:8pt'", "");
                                data = data.Replace("style='font-size:7pt'", "");
                                data = data.Replace("style='font-size:6pt'", "");
                                data = data.Replace("style='font-size:6.2pt'", "");
                                editordiv.InnerHtml = data;
                                if (tdlogo.Visible == true && Request.QueryString["logoname"] != null)
                                    txtlogoupload.Value = Request.QueryString["logoname"].ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (Session["savedata"] == null)
            {
                //if (hiddensrno.Value == "All")
                //{
                //    //string fname = cioid.Value + "-All.xtg";
                //    string fname = receiptno + "-All.xtg";
                //    if (previd == "")
                //    {
                //        getMatterData(fname);
                //    }
                //    else
                //    {
                //        //string fname1 = previd + "-All.xtg";
                //        string fname1 = receiptno + "-All.xtg";
                //        getMatterData_prev(fname1);
                //    }
                //}
                //else
                //{
                string fname = Request.QueryString["filename"].ToString();
                if (tdlogo.Visible == true && Request.QueryString["logoname"] != null)
                    txtlogoupload.Value = Request.QueryString["logoname"].ToString();
                getMatterData(fname);
                // }
            }
            else
            {
                string flag = "0";
                string fName;
                NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
                DataSet dsModify = new DataSet();
                //if (hiddensrno.Value == "All")
                //{
                //    //fName = cioid.Value + "-All.xtg";
                //    fName = receiptno + "-All.xtg";
                //}
                //else
                //{
                fName = Request.QueryString["filename"].ToString();
                // }
                dsModify = (DataSet)Session["savedata"];
                for (int i = 0; i < dsModify.Tables.Count; i++)
                {
                    if (dsModify.Tables[i].Rows[0].ItemArray[1].ToString() == fName)
                    {
                        string data = dsModify.Tables[i].Rows[0].ItemArray[2].ToString();
                        data = data.Replace("<br>", "");
                        editordiv.InnerHtml = data;
                        flag = "1";
                        if (tdlogo.Visible == true && Request.QueryString["logoname"] != null)
                            txtlogoupload.Value = Request.QueryString["logoname"].ToString();
                        break;
                    }
                }


                if (flag == "0")
                {
                    string fname = Request.QueryString["filename"].ToString();
                    if (tdlogo.Visible == true && Request.QueryString["name_logo"] != null)
                        txtlogoupload.Value = Request.QueryString["name_logo"].ToString();
                    getMatterData(fname);
                }

            }

        }
        btnok.Attributes.Add("onClick", "javascript:return okClick_matter();");
        btnok.Enabled = false;
        //tdlogo.Visible = true;
    }

    public void bindspecialcharacter()
    {
        DataSet objDataSetxml = new DataSet();
        // Read in the XML file
        objDataSetxml.ReadXml(Server.MapPath("XML/insertspecialcharacter.xml"));
        lbpickchar.Items.Clear();

        for (int z = 0; z < objDataSetxml.Tables[0].Columns.Count; z++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = objDataSetxml.Tables[0].Rows[0].ItemArray[z].ToString();
            li.Text = objDataSetxml.Tables[0].Rows[0].ItemArray[z].ToString();
            lbpickchar.Items.Add(li);

        }
    }



    private void getMatterData(string fName)
    {
        DataSet dsModify = new DataSet();

        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
            dsModify = csModify.getMatter(cioid.Value, fName);
            dsModify_tem = csModify.getMatter(cioid.Value, fName);
        }
        else
            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                //  if (Session["savedata"] == null )
                // {
                //    dsModify = csModify.getMatter(previd, fName);
                //}
                //else
                //{
                dsModify = csModify.getMatter(cioid.Value, fName);
                //  }
                //dsModify_tem = csModify.getMatter(cioid.Value, fName);


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                //  if (Session["savedata"] == null )
                // {
                //    dsModify = csModify.getMatter(previd, fName);
                //}
                //else
                //{
                dsModify = csModify.getMatter(cioid.Value, fName);
                //   }
                // dsModify_tem = csModify.getMatter(cioid.Value, fName);


            }

        if (dsModify.Tables[0].Rows.Count == 0)
        {
            editordiv.InnerHtml = "";
        }
        else
        {
            string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
            data = data.Replace("<br>", "");
            editordiv.InnerHtml = data;
        }
    }

    /*change for oracle*/

    private void getMatterData_prev(string fName)
    {
        DataSet dsModify = new DataSet();

        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
            dsModify = csModify.getMatter(previd, fName);
            dsModify_tem = csModify.getMatter(previd, fName);
        }
        else
            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                if (Session["savedata"] == null)
                {
                    //    dsModify = csModify.getMatter(previd, fName);
                    //    dsModify_tem = csModify.getMatter(previd, fName);
                    //}
                    //else
                    //{
                    dsModify = csModify.getMatter(cioid.Value, fName);
                    dsModify_tem = csModify.getMatter(cioid.Value, fName);
                }


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                if (Session["savedata"] == null)
                {
                    //    dsModify = csModify.getMatter(previd, fName);
                    //    dsModify_tem = csModify.getMatter(previd, fName);
                    //}
                    //else
                    //{
                    dsModify = csModify.getMatter(cioid.Value, fName);
                    dsModify_tem = csModify.getMatter(cioid.Value, fName);
                }
            }

        if (dsModify.Tables[0].Rows.Count == 0)
        {
            editordiv.InnerHtml = "";
        }
        else
        {
            string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
            data = data.Replace("<br>", "");
            editordiv.InnerHtml = data;
        }
    }
    //////////////////////////

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    //[Ajax.AjaxMethod]
    public string savethematterinsession(string str, string matterText)
    {
        //  if (str.IndexOf("<span style") >= 0 || str.IndexOf("</span>") > 0)
        //{
        //    str = str.Replace("<span style", "$DD$<span style");
        //    str = str.Replace("</span>", "</span>$EE$");
        //    str = str.Replace("$DD$", "</span>");
        //    str = str.Replace("$EE$", "<span style=\"font-family: ePatrika;\">");
        //    //str = "<span style=\"font-family: ePatrika;\">" + str + "</span>";
        //    str = str.Replace("<span style=\"font-family: ePatrika;\"></span>", "");
        //    str = str.Replace("<span style=\"font-family: NimrodMT;\"></span>", "");
        //}
        //str = str.Replace("<span style=\"font-family: ", "<font face=\"").Replace(";\">", "\">").Replace("</span>", "</font>");

        string ah = str;
        ah = ah.Trim().Replace("&nbsp;", " ").Replace("&NBSP;", " ");
        ah = Regex.Replace(ah, "<a href[^>]*>", "");
        ah = Regex.Replace(ah, "<A href[^>]*>", "");
        ah = ah.Replace("</A>", "");
        while (ah.IndexOf("  ") >= 0)
        {
            ah = ah.Replace("  ", " ");
        }
        ah = ah.Replace(" color=black WHITE AND", "");
        HttpContext.Current.Session["matter_session"] = ah.Trim();

        HttpContext.Current.Session["matterText_session"] = matterText;

        //return str;
        return ah;

    }
    [Ajax.AjaxMethod]
    public DataSet getOldMatter(string rcpt_no)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objMatter = new NewAdbooking.classesoracle.BookingMaster();
            ds = objMatter.clsOldMatter(rcpt_no);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objMatter = new NewAdbooking.Classes.BookingMaster();
            ds = objMatter.clsOldMatter(rcpt_no);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objMatter = new NewAdbooking.classmysql.BookingMaster();
            ds = objMatter.clsOldMatter(rcpt_no);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public string bindbannedword(string mattertexrt)
    {
        DataSet objDataSetbu1 = new DataSet();
        //string error = "";

        string path = Server.MapPath("xml/bannedword.xml");
        path = path.Replace("ajax\\", "");
        objDataSetbu1.ReadXml(path);

        string mattertexrt1 = mattertexrt.ToString();
        string bantxt = objDataSetbu1.Tables[0].Rows[0].ItemArray[0].ToString();
        char[] splitins = { ',' };
        char[] splitins1 = { ' ' };
        string[] bantxt1 = bantxt.Split(splitins);
        string[] arrmatter = mattertexrt1.Split("".ToCharArray());
        for (int k = 0; k < arrmatter.Length; k++)
        {
            for (int j = 0; j < bantxt1.Length; j++)
            {
                if (arrmatter[k].ToString() == bantxt1[j].ToString())
                {
                    //Response.Write("<script>alert("+arrmatter[k].ToString() + " is Banned Word in Matter Composing. Please remove this word for getting Preview);</script>");
                    return "false" + "$~$" + arrmatter[k].ToString();
                }
            }

        }
        return "true";
    }
}
