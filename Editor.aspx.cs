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

public partial class Editor : System.Web.UI.Page
{
    DataSet dsModify_tem = new DataSet();
    string previd = "";
    public string KEYNO_IE = "";
    public string KEYNO_MOZ = "";
    int countvar = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         hiddeneyecatcher.Value = "DR";  //Request.QueryString["eyecatch"].ToString();
         //hiddenbgcolor.Value = Request.QueryString["bgcolor"].ToString();
         hiddenwidth.Value = "3";  // Request.QueryString["width"].ToString();
         hiddenuom.Value = "cm"; //Request.QueryString["uom"].ToString();
         hiddeneyecatchlength.Value = "2";
         hiddeninsert.Value = "1";*/

        string receiptno = "";
        hidencomcode.Value = Session["compcode"].ToString();
        Response.Expires = -1;
        if (Request.QueryString["packagecode"] != null)
        {
            hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();
            //package_ = package_.Replace("^", "+");
        }
        if (Request.QueryString["keyboard"] != null)
            hiddefaultkey.Value = Request.QueryString["keyboard"].ToString();
        if (Request.QueryString["keyboardtype"] != null)
            hdnkeyboardtype.Value = Request.QueryString["keyboardtype"].ToString();
        if (Request.QueryString["prevcioid"] != null)
        {
            hiddenpreviousid.Value = Request.QueryString["prevcioid"].ToString();
        }
        //KEYNO_IE = "javascript/texteditorcode_guj_ie.js";
        //KEYNO_MOZ = "javascript/textboxkbrd_geckoUni.js";
        KEYNO_IE = "javascript/texteditorcode_ie.js";
        KEYNO_MOZ = "javascript/textboxkbrd_gecko.js";
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }

        hiddenuom_desc.Value = Request.QueryString["uom_desc_"].ToString();
        if (Session["insertname_logo"] == null && hiddenuom_desc.Value == "ROD" && Request.QueryString["modify"].ToString() == "0" && Request.QueryString["prevcioid"] == "")
        {
            Response.Write("<script>alert(\"Please upload the logo\");window.close();</script>");
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Editor));
        //////////add by anuja
        hiddenreciept.Value = Request.QueryString["receiptno"].ToString();
        cioid.Value = receiptno = Request.QueryString["cioid"].ToString();
        //if (hiddenpreviousid.Value != "")
        //    cioid.Value = receiptno = hiddenpreviousid.Value;
        hiddensrno.Value = Request.QueryString["srno"].ToString();
        hiddenedition.Value = Request.QueryString["edition"].ToString();
        hiddeneyecatcher.Value = Request.QueryString["eyecatch"].ToString();
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
        hiddeneyecatchlength.Value = Request.QueryString["eyecatchlength"].ToString();
        hiddeninsert.Value = Request.QueryString["insertid"].ToString();

        hiddenInsertNo.Value = Request.QueryString["insertNo"].ToString();
        string modify = Request.QueryString["modify"].ToString();
        hiddenmodify.Value = Request.QueryString["modify"].ToString();
        hiddenuom.Value = Request.QueryString["uom"].ToString();
        if (!Page.IsPostBack)
        {
            bindspecialcharacter();
            btnprev.Attributes.Add("OnClick", "javascript:return buttonprev();");
            btnprintf.Attributes.Add("OnClick", "javascript:return buttonprintf();");
            //btnprev.Attributes.Add("OnClick", "javascript:return preview();");
            lbpickchar.Attributes.Add("onclick", "insertintomatter();");
            //  editordiv.Attributes.Add("onChange", "javascript:return getFontname();");
            btnCopytoEditor.Attributes.Add("onclick", "javascript:return copyMatter();");
            //  Button1.Attributes.Add("onclick", "javascript:return pubdiv();");
            /////////////////////////////////////////add anuja////
            if (Session["savedata"] == null)
            {
                if (modify != "1")
                {
                    string package_ = "";
                    string output = "";
                    DataSet dspub = new DataSet();
                    if (Request.QueryString["packagecode"] != null)
                    {
                        hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();
                        //package_ = package_.Replace("^", "+");
                    }
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                        dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                        dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
                    }
                    else
                    {
                        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                        string procedureName = "fn_pub_combin_code";
                        NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                        dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                        
                    }
                    if (dspub.Tables[0].Rows.Count > 0)
                    {

                        string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                        string[] datapuv1 = datapuv.Split(',');

                        for (var i = 0; i < datapuv1.Length; i++)
                        {
                            //data += "<div style='font-size:12px;'>"+datapuv1[i]+"</div>";
                            //puvdiv.Visible = true;
                            string pubcode222 = datapuv1[i].ToString();
                            puvdiv11.Attributes.Add("style", "display:block");

                            output += "<div style='float:left;'>";
                            output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                            output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                            output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                            //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                            output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                            output += "</td>";
                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                            output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' />";
                            output += "</td></div></div>";

                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[i] + "'/>";
                            output += "</td>";

                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                            output += "</td>";


                        }
                        puvdiv11.InnerHtml = output;
                        //var length1 = datapuv1.Length;
                        //hiddenpublicode.Value = length1;
                    }
                }
                else
                {
                    string package_ = "";
                    string output = "";
                    DataSet dspub = new DataSet();
                    if (Request.QueryString["packagecode"] != null)
                    {
                        hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();
                        //package_ = package_.Replace("^", "+");
                    }
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                        dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
                    {
                        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                        string procedureName = "fn_pub_combin_code";
                        NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                        dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                    }
                    if (dspub.Tables[0].Rows.Count > 0)
                    {

                        string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                        string[] datapuv1 = datapuv.Split(',');

                        for (var i = 0; i < datapuv1.Length; i++)
                        {
                            //data += "<div style='font-size:12px;'>"+datapuv1[i]+"</div>";
                            //puvdiv.Visible = true;
                            string pubcode222 = datapuv1[i].ToString();
                            puvdiv11.Attributes.Add("style", "display:block");

                            output += "<div style='float:left;'>";
                            output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                            output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                            output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                            //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                            output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                            output += "</td>";
                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                            output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' />";
                            output += "</td></div></div>";

                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[i] + "'/>";
                            output += "</td>";

                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                            output += "</td>";


                        }
                        puvdiv11.InnerHtml = output;
                        //var length1 = datapuv1.Length;
                        //hiddenpublicode.Value = length1;
                    }
                }
            }
            else if (Request.QueryString["filename"].ToString() == "" && Session["savedata"] != null)
            {
                string package_ = "";
                string output = "";
                DataSet dspub = new DataSet();
                if (Request.QueryString["packagecode"] != null)
                {
                    hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();
                    //package_ = package_.Replace("^", "+");
                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                    dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                    dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
                }
                else
                {
                    string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                    string procedureName = "fn_pub_combin_code";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                if (dspub.Tables[0].Rows.Count > 0)
                {

                    string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv1 = datapuv.Split(',');

                    for (var i = 0; i < datapuv1.Length; i++)
                    {
                        //data += "<div style='font-size:12px;'>"+datapuv1[i]+"</div>";
                        //puvdiv.Visible = true;
                        string pubcode222 = datapuv1[i].ToString();
                        puvdiv11.Attributes.Add("style", "display:block");

                        output += "<div style='float:left;'>";
                        output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                        output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                        output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                        //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                        output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                        output += "</td>";
                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                        output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' />";
                        output += "</td></div></div>";

                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[i] + "'/>";
                        output += "</td>";

                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                        output += "</td>";


                    }
                    puvdiv11.InnerHtml = output;
                    //var length1 = datapuv1.Length;
                    //hiddenpublicode.Value = length1;
                }
            }

            //////////////////////////////////////////////////////////////////////////////////
        }

        //hiddeneyecatchlength.Value = Request.QueryString["eyecatchlength"].ToString();
        //hiddeninsert.Value = Request.QueryString["insertid"].ToString();

        //hiddenInsertNo.Value = Request.QueryString["insertNo"].ToString();
        //string modify = Request.QueryString["modify"].ToString();
        //hiddenmodify.Value = Request.QueryString["modify"].ToString();

        //****************By Manish Verma***************************
        //if (Request.QueryString["line"].ToString() != "")
        //{
        //    txtnoofline.Text = Request.QueryString["line"].ToString();
        //}
        /*change for oracle*/
        //this is the case when the user want to copy the contents 

        if (Session["savedata"] == null && previd != "")
        {
            if (hiddensrno.Value == "All")
            {
                //string fname = previd + "-All.xtg";
                string fname = receiptno + "-All.xtg";
                getMatterData_prev(fname);
            }
            else
            {
                string fname = Request.QueryString["filename"].ToString();
                getMatterData(fname);
            }
        }
        else
        {
            if (modify != "1")
            {
                string fname = Request.QueryString["filename"].ToString();
                getMatterData(fname);
            }
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

                        //// data = data.Replace("<br>", "");
                        //if (data.IndexOf("<br>") == 0)
                        //    data = data.Replace("<br>", "");
                        ////////////////////////add by anuja
                        string package_ = "";
                        string output = "";
                        DataSet dspub = new DataSet();
                        if (Request.QueryString["packagecode"] != null)
                        {
                            hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();

                        }
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
                        }
                        else
                        {
                            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                            string procedureName = "fn_pub_combin_code";
                            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                            dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                        }

                        // string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();


                        if (dspub.Tables[0].Rows.Count > 0)
                        {
                            var r = 0;
                            string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                            string[] datapuv1 = datapuv.Split(',');
                            //string [] datapuv11= datapuv1[1].Split('.');
                            for (var j = 0; j < datapuv1.Length; j++)
                            {

                                string data = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                string fname = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                                string[] ff = ds.Tables[0].Rows[0].ItemArray[1].ToString().Split('-');
                                string[] ff2 = ff[1].Split('.');
                                for (int p = 0; p < ds.Tables.Count; p++)
                                {
                                    data = ds.Tables[p].Rows[0].ItemArray[2].ToString();
                                    fname = ds.Tables[p].Rows[0].ItemArray[1].ToString();
                                    ff = ds.Tables[p].Rows[0].ItemArray[1].ToString().Split('-');
                                    ff2 = ff[1].Split('.');
                                    if (datapuv1[j].Replace(" ", "") == ff2[0].Replace(" ", ""))
                                    {
                                        if (data.IndexOf("<br>") == 0)
                                            data = data.Replace("<br>", "");
                                        p = ds.Tables.Count;

                                    }
                                    else
                                    {

                                        data = "";
                                        fname = "";
                                    }
                                }
                                //{
                                // countvar = p;
                                //if (ds.Tables.Count > j)
                                //{
                                //    data = ds.Tables[j].Rows[0].ItemArray[2].ToString();
                                //    fname = ds.Tables[j].Rows[0].ItemArray[1].ToString();
                                //    ff = ds.Tables[j].Rows[0].ItemArray[1].ToString().Split('-');
                                //    ff2 = ff[1].Split('.');
                                //}


                                puvdiv11.Attributes.Add("style", "display:block");
                                output += "<div style='float:left;'>";
                                output += "<div id=divpub_" + j + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' >" + data + "</div>";
                                output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                                output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                                //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                                output += "<Button id='edit_" + j + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                                output += "</td>";
                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                                output += "<input  id='filename_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + fname + "'/>";
                                output += "</td></div></div>";

                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                                output += "<input  type='hidden' id='pubcode_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[j] + "'/>";
                                output += "</td>";
                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                                output += "<input  type='hidden' id='linecount_" + j + "' style='align:center;width:50px;font-size:10px;'/>";
                                output += "</td>";
                                //}
                            }
                            puvdiv11.InnerHtml = output;

                        }
                        /////////////////////////////////////
                        //editordiv.InnerHtml = data;
                    }
                    else
                    {
                        string output = "";
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            if (ds.Tables[i].Rows[0].ItemArray[1].ToString() == Request.QueryString["filename"].ToString())
                            {

                                string data = ds.Tables[i].Rows[0].ItemArray[2].ToString();
                                string fname = ds.Tables[i].Rows[0].ItemArray[1].ToString();
                                string[] ff = ds.Tables[i].Rows[0].ItemArray[1].ToString().Split('-');
                                string[] ff2 = ff[1].Split('.');
                                //  data = data.Replace("<br>", "");
                                if (data.IndexOf("<br>") == 0)
                                    data = data.Replace("<br>", "");

                                puvdiv11.Attributes.Add("style", "display:block");
                                output += "<div style='float:left;'>";
                                output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' >" + data + "</div>";
                                output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                                output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                                //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                                output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                                output += "</td>";
                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                                output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + fname + "'/>";
                                output += "</td></div></div>";

                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                                output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + ff2[0] + "'/>";
                                output += "</td>";
                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                                output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                                output += "</td>";
                                puvdiv11.InnerHtml = output;
                                editordiv.InnerHtml = data;
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
                getMatterData(fname);
                //}
            }
            else
            {
                string flag = "0";
                string fName;

                DataSet dspub = new DataSet();
                if (Request.QueryString["packagecode"] != null)
                {
                    hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();

                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                    dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                    dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
                }
                else
                {
                    string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                    string procedureName = "fn_pub_combin_code";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                DataSet dsModify = new DataSet();
                DataSet modds = new DataSet();
                fName = Request.QueryString["filename"].ToString();

                dsModify = (DataSet)Session["savedata"];

                //for (int i = 0; i < dsModify.Tables.Count; i++)
                //{

                //  fName = fName.Split(',');
                //if (dsModify.Tables[i].Rows[0].ItemArray[1].ToString() == fName)
                //{
                //    string data = dsModify.Tables[i].Rows[0].ItemArray[2].ToString();
                string output = "";
                /////////////////////////////////////////
                if (dspub.Tables[0].Rows.Count > 0)
                {
                    var r = 0;
                    string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv1 = datapuv.Split(',');
                    //string [] datapuv11= datapuv1[1].Split('.');
                    for (var j = 0; j < datapuv1.Length; j++)
                    {
                        string[] fName1 = fName.Split(',');
                        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.BookingMaster csModify33 = new NewAdbooking.classesoracle.BookingMaster();
                            if (hiddensrno.Value == "All")
                            {
                                if (Session["savedata"] == null && previd != "")
                                {
                                    modds = csModify33.getMatter(previd, fName1[j]);
                                }
                                else
                                {
                                    modds = csModify33.getMatter(cioid.Value, fName1[j]);
                                }
                            }
                            else
                            {
                                modds = csModify33.getMatter(previd, fName1[0]);
                            }
                            //dsModify_tem = csModify.getMatter(cioid.Value, fName);


                        }
                        else if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.BookingMaster csModify33 = new NewAdbooking.Classes.BookingMaster();
                            if (Session["savedata"] == null && previd != "")
                            {
                                modds = csModify33.getMatter(previd, fName1[j]);
                            }
                            else
                            {
                                modds = csModify33.getMatter(cioid.Value, fName1[j]);
                            }
                        }
                        else
                        {
                            /*string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                            string procedureName = "websp_getMatter_websp_getMatter_p";
                            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();

                            if (Session["savedata"] == null && previd != "")
                            {
                                parameterValueArray = new string[] { previd, fName1[j] };
                            }
                            else
                            {
                                parameterValueArray = new string[] { cioid.Value, fName1[j] };
                            }
                            modds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
                            NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                            if (hiddensrno.Value == "All")
                            {
                                
                                if (Session["savedata"] == null && previd != "")
                                {
                                    modds = csModify.getMatter(previd, fName1[j]);
                                }
                                else
                                {
                                    modds = csModify.getMatter(cioid.Value, fName1[j]);
                                }
                            }
                            else
                            {
                                modds = csModify.getMatter(previd, fName1[0]);
                            }

                        }
                        string data = dsModify.Tables[0].Rows[0].ItemArray[2].ToString();
                        string fname = dsModify.Tables[0].Rows[0].ItemArray[1].ToString();
                        string[] ff = dsModify.Tables[0].Rows[0].ItemArray[1].ToString().Split('-');
                        string[] ff2 = ff[1].Split('.');
                        for (int p = j; p < dsModify.Tables.Count; p++)
                        {
                            data = dsModify.Tables[p].Rows[0].ItemArray[2].ToString();
                            //fname = dsModify.Tables[p].Rows[0].ItemArray[1].ToString();
                            //ff = dsModify.Tables[p].Rows[0].ItemArray[1].ToString().Split('-');
                            //ff2 = ff[1].Split('.');

                            if (hiddensrno.Value == "All" || hiddensrno.Value == "0")
                            {
                                fname = dsModify.Tables[p].Rows[0].ItemArray[1].ToString();
                                ff = dsModify.Tables[p].Rows[0].ItemArray[1].ToString().Split('-');
                                ff2 = ff[1].Split('.');
                            }
                            else
                            {
                                fname = dsModify.Tables[p].Rows[0].ItemArray[1].ToString();
                                string[] fnameyy = fname.Split('-');
                                //string gghg = fnameyy[0] + "~" + fnameyy[1] + "~" + fnameyy[2] + "-" + fnameyy[3];
                                string gghg = fnameyy[0] + "-" + fnameyy[1]; // +"~" + fnameyy[2] + "-" + fnameyy[3];
                                ff = gghg.Split('-');
                                ff2 = ff[1].Split('.');
                            }

                            string gg = "filename_" + j;
                            if (datapuv1[j].Replace(" ", "") == ff2[0].Replace(" ", ""))
                            {
                                if (data.IndexOf("<br>") == 0)
                                    data = data.Replace("<br>", "");
                                // editordiv.InnerHtml = data;
                                p = dsModify.Tables.Count;
                                flag = "1";

                            }
                            else
                            {
                                if (hiddensrno.Value == "All")
                                {
                                    if (modds.Tables[0].Rows.Count > 0)
                                    {
                                        data = modds.Tables[0].Rows[0].ItemArray[0].ToString();
                                        fname = fName1[j];
                                    }
                                    else
                                    {
                                        data = "";
                                        fname = "";
                                    }
                                }
                                else
                                {
                                    data = "";
                                    fname = "";
                                }
                                p = dsModify.Tables.Count;
                                //fname = dsModify.Tables[p].Rows[0].ItemArray[1].ToString();
                                //string[] fnameyy = fname.Split('-');
                                //string gghg = fnameyy[0] + "-" + fnameyy[1];//  +"~" + fnameyy[2] + "-" + fnameyy[3];
                                //ff = gghg.Split('-');
                                //ff2 = ff[1].Split('.');
                                ////data = modds.Tables[0].Rows[0].ItemArray[0].ToString();
                                ////fname = fName1[j];
                                ////p = dsModify.Tables.Count;
                            }
                        }
                        puvdiv11.Attributes.Add("style", "display:block");
                        output += "<div style='float:left;'>";
                        output += "<div id=divpub_" + j + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' >" + data + "</div>";
                        output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                        output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                        //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                        output += "<Button id='edit_" + j + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                        output += "</td>";
                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                        output += "<input  id='filename_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + fname + "'/>";
                        output += "</td></div></div>";

                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output += "<input  type='hidden' id='pubcode_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[j] + "'/>";
                        output += "</td>";
                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output += "<input  type='hidden' id='linecount_" + j + "' style='align:center;width:50px;font-size:10px;'/>";
                        output += "</td>";
                    }
                    puvdiv11.InnerHtml = output;
                }

                ////////////////////////////////////////////
                //        data = data.Replace("<br>", "");
                //        if (data.IndexOf("<br>") == 0)
                //            data = data.Replace("<br>", "");
                //        if (data.IndexOf("\r\n") >= 0)
                //            data = data.Replace("\r\n", "");
                //        editordiv.InnerHtml = data;
                //        flag = "1";
                //        break;
                //    }
                //}


                if (flag == "0")
                {
                    string fname = Request.QueryString["filename"].ToString();
                    getMatterData(fname);
                }

            }

        }
        //btnok.Attributes.Add("onClick", "javascript:return okClick_matter();");
        btnok.Attributes.Add("onClick", "javascript:return okClick_matter12();");
        btnok.Enabled = false;
        //btnprintf.Enabled = false;
        //editordiv.Focus();
        //**************************************************************

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
        string fname1 = fName;
        if (fname1.IndexOf(",") == -1)
        {
            string fname = Request.QueryString["filename"].ToString();
            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
                if (hiddensrno.Value == "All")
                {
                    if (Session["savedata"] == null && previd != "")
                    {
                        dsModify = csModify.getMatter(previd, fName);
                    }
                    else
                    {
                        dsModify = csModify.getMatter(cioid.Value, fName);
                    }
                }
                else
                {
                    dsModify = csModify.getMatter(previd, fName);
                }
                dsModify_tem = csModify.getMatter(cioid.Value, fName);
            }
            else
                if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                    if (hiddensrno.Value == "All")
                    {
                        if (Session["savedata"] == null && previd != "")
                        {
                            dsModify = csModify.getMatter(previd, fName);
                        }
                        else
                        {
                            dsModify = csModify.getMatter(cioid.Value, fName);
                        }
                    }
                    else
                    {
                        dsModify = csModify.getMatter(previd, fName);
                    }
                    //dsModify_tem = csModify.getMatter(cioid.Value, fName);


                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                    if (hiddensrno.Value == "All")
                    {
                        if (Session["savedata"] == null && previd != "")
                        {
                            dsModify = csModify.getMatter(previd, fName);
                        }
                        else
                        {
                            dsModify = csModify.getMatter(cioid.Value, fName);
                        }
                    }
                    else
                    {
                        dsModify = csModify.getMatter(previd, fName);
                    }
                    // dsModify_tem = csModify.getMatter(cioid.Value, fName);



                }

            if (dsModify.Tables[0].Rows.Count == 0)
            {
                editordiv.InnerHtml = "";
            }
            else
            {
                //fname = Request.QueryString["filename"].ToString();
                string package_ = "";
                string output = "";
                DataSet dspub = new DataSet();
                if (Request.QueryString["packagecode"] != null)
                {
                    hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();

                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                    dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                    dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
                }
                else
                {
                    string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                    string procedureName = "fn_pub_combin_code";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                string ff2 = "";
                string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
                if (fname != "")
                {
                    string[] ff = fname.Split('-');

                    string[] dd = ff[1].Split('.');
                    ff2 = dd[0];
                }
                else
                {
                    ff2 = "";
                }
                if (dspub.Tables[0].Rows.Count > 0)
                {

                    string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv1 = datapuv.Split(',');
                    //string [] datapuv11= datapuv1[1].Split('.');
                    for (var j = 0; j < datapuv1.Length; j++)
                    {

                        if (datapuv1[j].Replace(" ", "") == ff2.Replace(" ", ""))
                        {

                            data = data.Replace("<br>", "");
                            if (data.IndexOf("<br>") == 0)
                                data = data.Replace("<br>", "");
                            if (data.IndexOf("\r\n") >= 0)
                                data = data.Replace("\r\n", "");
                            data = data.Replace("color=blackWHITEAND}", "");
                            //  data = data.Replace("<font face=Arial>", "").Replace("</font>", "").Replace("<font face=eLokmat>", "").Replace("<font face=Conv_E4CGandhi>", "");
                            //editordiv.InnerHtml = data;
                            if (data.IndexOf("</table>") <= 0)
                                data = data + "</table>";
                            puvdiv11.Attributes.Add("style", "display:block");
                            output += "<div style='float:left;'>";
                            output += "<div id=divpub_" + j + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' >" + data + "</div>";
                            output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                            output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                            //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                            output += "<Button id='edit_" + j + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                            output += "</td>";
                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                            output += "<input  id='filename_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + fname + "'/>";
                            output += "</td></div></div>";

                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='pubcode_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[j] + "'/>";
                            output += "</td>";
                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='linecount_" + j + "' style='align:center;width:50px;font-size:10px;'/>";
                            output += "</td>";

                        }
                        else
                        {
                            puvdiv11.Attributes.Add("style", "display:block");
                            output += "<div style='float:left;'>";
                            output += "<div id=divpub_" + j + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                            output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                            output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                            //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                            output += "<Button id='edit_" + j + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                            output += "</td>";
                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                            output += "<input  id='filename_" + j + "' style='align:center;width:50px;font-size:10px;' />";
                            output += "</td></div></div>";

                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='pubcode_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[j] + "'/>";
                            output += "</td>";
                            output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                            output += "<input  type='hidden' id='linecount_" + j + "' style='align:center;width:50px;font-size:10px;'/>";
                            output += "</td>";
                        }

                    }
                    puvdiv11.InnerHtml = output;

                }



                //  }
                // }
            }
        }
        else
        {
            string[] fname = fname1.ToString().Split(',');
            string package_ = "";
            string output = "";
            string output1 = "";
            DataSet dspub = new DataSet();
            if (Request.QueryString["packagecode"] != null)
            {
                hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();

            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
            }
            else
            {
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), hiddenpublicode.Value };
                string procedureName = "fn_pub_combin_code";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            var q = 0;
            for (var i = 0; i < fname.Length; i++)
            {
                q = i;
                if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
                    if (hiddensrno.Value == "All")
                    {
                        if (Session["savedata"] == null && previd != "")
                        {
                            dsModify = csModify.getMatter(previd, fname[i]);
                        }
                        else
                        {
                            dsModify = csModify.getMatter(cioid.Value, fname[i]);
                        }
                    }
                    else
                    {
                        dsModify = csModify.getMatter(previd, fname[i]);

                    }
                    dsModify_tem = csModify.getMatter(cioid.Value, fname[i]);
                }
                else
                    if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                        if (hiddensrno.Value == "All")
                        {
                            if (Session["savedata"] == null && previd != "")
                            {
                                dsModify = csModify.getMatter(previd, fname[i]);
                            }
                            else
                            {
                                dsModify = csModify.getMatter(cioid.Value, fname[i]);
                            }
                        }
                        else
                        {
                            dsModify = csModify.getMatter(previd, fname[i]);
                        }
                        //dsModify_tem = csModify.getMatter(cioid.Value, fName);


                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                        if (hiddensrno.Value == "All")
                        {
                            if (Session["savedata"] == null && previd != "")
                            {
                                dsModify = csModify.getMatter(previd, fname[i]);
                            }
                            else
                            {
                                dsModify = csModify.getMatter(cioid.Value, fname[i]);
                            }
                        }
                        else
                        {
                            dsModify = csModify.getMatter(previd, fname[i]);
                        }
                        // dsModify_tem = csModify.getMatter(cioid.Value, fName);


                    }

                if (dsModify.Tables[0].Rows.Count == 0)
                {
                    editordiv.InnerHtml = "";
                }
                else
                {
                    string ffpub = "";
                    string datapuv22 = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv156 = datapuv22.Replace(" ", "").Split(',');
                    string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (fname[i].ToString() != "")
                    {
                        string[] ff = fname[i].Split('-');
                        string[] ff2 = ff[1].Split('.');
                        ffpub = ff2[0];
                    }
                    else
                    {
                        ffpub = "";
                        puvdiv11.Attributes.Add("style", "display:block");
                        output += "<div style='float:left;'>";
                        output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                        output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                        output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                        //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                        output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                        output += "</td>";
                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                        output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' />";
                        output += "</td></div></div>";

                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv156[i] + "'/>";
                        output += "</td>";
                        output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                        output += "</td>";
                        puvdiv11.InnerHtml = output;
                    }

                    if (dspub.Tables[0].Rows.Count > 0)
                    {

                        string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                        string[] datapuv1 = datapuv.Split(',');
                        //string [] datapuv11= datapuv1[1].Split('.');
                        for (var j = 0; j < datapuv1.Length; j++)
                        {

                            if (datapuv1[j].Replace(" ", "") == ffpub.Replace(" ", ""))
                            {
                                if (fname[i].ToString() != "")
                                {
                                    data = data.Replace("<br>", "");
                                    if (data.IndexOf("<br>") == 0)
                                        data = data.Replace("<br>", "");
                                    if (data.IndexOf("\r\n") >= 0)
                                        data = data.Replace("\r\n", "");
                                    data = data.Replace("color=blackWHITEAND}", "");
                                }
                                else
                                {
                                    data = "";
                                }

                                puvdiv11.Attributes.Add("style", "display:block");
                                output += "<div style='float:left;'>";
                                output += "<div id=divpub_" + j + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' >" + data + "</div>";
                                output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                                output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                                //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                                output += "<Button id='edit_" + j + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                                output += "</td>";
                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                                output += "<input  id='filename_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + fname[i] + "'/>";
                                output += "</td></div></div>";

                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                                output += "<input  type='hidden' id='pubcode_" + j + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[j] + "'/>";
                                output += "</td>";
                                output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                                output += "<input  type='hidden' id='linecount_" + j + "' style='align:center;width:50px;font-size:10px;'/>";
                                output += "</td>";
                            }

                        }
                        puvdiv11.InnerHtml = output;

                    }

                }
                if (hiddenmodify.Value != "1")
                {
                    string datapuv16 = "";
                    if (dspub.Tables[0].Rows.Count > 0)
                    {

                        string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                        string[] datapuv1 = datapuv.Split(',');

                        //  datapuv16 = datapuv1[i];

                    }
                    puvdiv11.Attributes.Add("style", "display:block");
                    output += "<div style='float:left;'>";
                    output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                    output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                    output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                    output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                    output += "</td>";
                    output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                    output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' />";
                    output += "</td></div></div>";

                    output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                    output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;'  />";
                    output += "</td>";

                    output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                    output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                    output += "</td>";
                }
            }

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
                if (Session["savedata"] == null && previd != "")
                {
                    dsModify = csModify.getMatter(cioid.Value, fName);
                    dsModify_tem = csModify.getMatter(cioid.Value, fName);
                }
                else
                {
                    dsModify = csModify.getMatter(cioid.Value, fName);
                    dsModify_tem = csModify.getMatter(cioid.Value, fName);
                }


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                if (Session["savedata"] == null && previd != "")
                {
                    dsModify = csModify.getMatter(previd, fName);
                    dsModify_tem = csModify.getMatter(previd, fName);
                }
                else
                {
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
            //data = data.Replace("<br>", "");
            if (data.IndexOf("<br>") == 0)
                data = data.Replace("<br>", "");
            editordiv.InnerHtml = data;
        }
    }
    //////////////////////////

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


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    //[Ajax.AjaxMethod]
    public string savethematterinsession(string str, string matterText)
    {
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
        ah = ah.Replace("color=blackWHITEAND}", "");
        matterText = matterText.Replace(" color=black WHITE AND", "");
        matterText = matterText.Replace("color=blackWHITEAND}", "");

        HttpContext.Current.Session["matter_session"] = ah.Trim();

        HttpContext.Current.Session["matterText_session"] = matterText;

        //return str;
        return ah;

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
        string[] arrmatter = mattertexrt1.Split(splitins1);
        for (var k = 0; k < arrmatter.Length; k++)
        {
            for (var j = 0; j < bantxt1.Length; j++)
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
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public DataSet findpub(string package_)
    {
        DataSet dspub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), package_);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), package_);
        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), package_ };
            string procedureName = "fn_pub_combin_code";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return dspub;
    }
    [Ajax.AjaxMethod]
    public DataSet publiNameReturn(string comcode, string pubcode)
    {
        DataSet dspub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
            dspub = getpubwidth.getpublicationlanguage(comcode, pubcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
            dspub = getpubwidth.getpublicationlanguage(comcode, pubcode);

        }
        else
        {
            string[] parameterValueArray = new string[] { comcode, pubcode };
            string procedureName = "pubnamelanguage";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return dspub;
    }
    [Ajax.AjaxMethod]
    public DataSet pucodforedition(string comcode, string edicode)
    {
        DataSet dspub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
            dspub = getpubwidth.getpubcodeedit(comcode, edicode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
            dspub = getpubwidth.getpubcodeedit(comcode, edicode);

        }
        else
        {
            string[] parameterValueArray = new string[] { comcode, edicode };
            string procedureName = "qbc_getpubforedition";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            dspub = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return dspub;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    //[Ajax.AjaxMethod]
    public string savethematterinsessionforprint(string str, string matterText)
    {
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
        ah = ah.Replace("color=blackWHITEAND}", "");
        matterText = matterText.Replace(" color=black WHITE AND", "");
        matterText = matterText.Replace("color=blackWHITEAND}", "");

        HttpContext.Current.Session["matter_sessionah_print"] = ah.Trim();

        HttpContext.Current.Session["matterText_session_print"] = matterText;

        //return str;
        return ah;

    }

}

