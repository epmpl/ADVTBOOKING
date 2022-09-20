using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
public partial class editorproofread : System.Web.UI.Page
{
    public string KEYNO_IE = "";
    public string KEYNO_MOZ = "";
    string previd = "";
    DataSet dsModify_tem = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }
        hidencomcode.Value = Session["compcode"].ToString();
        string fname = Request.QueryString["filename"].ToString();
        KEYNO_IE = "javascript/Mtexteditorcode_ie.js";
        KEYNO_MOZ = "javascript/Mtextboxkbrd_gecko.js";
        if (Request.QueryString["val"].ToString() == "DIS")
        {
            //   editordiv.Disabled = true;
            Hidden1.Value = "DIS";
        }
        if (Request.QueryString["packagecode"] != null)
        {
            hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();
            //package_ = package_.Replace("^", "+");
        }
        hiddefaultkey.Value = "";
        hdnkeyboardtype.Value = "";
        Ajax.Utility.RegisterTypeForAjax(typeof(editorproofread));
        cioid.Value = Request.QueryString["bookid"].ToString();
        hiddenFileName.Value = fname;
        getMatterData(fname);
        btnprev.Attributes.Add("OnClick", "javascript:return openMatterPrevpage();");
        btnok.Attributes.Add("OnClick", "javascript:return closematter();");
        btnCopytoEditor.Attributes.Add("onclick", "javascript:return copyMatterproofread();");
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
                if (Session["savedata"] == null && previd != "")
                {
                    dsModify = csModify.getMatter(previd, fName);
                }
                else
                {
                    dsModify = csModify.getMatter(cioid.Value, fName);
                }
                dsModify_tem = csModify.getMatter(cioid.Value, fName);
            }
            else
                if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                    if (Session["savedata"] == null && previd != "")
                    {
                        dsModify = csModify.getMatter(previd, fName);
                    }
                    else
                    {
                        dsModify = csModify.getMatter(cioid.Value, fName);
                    }
                    //dsModify_tem = csModify.getMatter(cioid.Value, fName);


                }
                else
                {
                    NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                    if (Session["savedata"] == null && previd != "")
                    {
                        dsModify = csModify.getMatter(previd, fName);
                    }
                    else
                    {
                        dsModify = csModify.getMatter(cioid.Value, fName);
                    }
                    // dsModify_tem = csModify.getMatter(cioid.Value, fName);


                }
            DataSet dspub1 = new DataSet();
            if (Request.QueryString["packagecode"] != null)
            {
                hiddenpublicode.Value = Request.QueryString["packagecode"].ToString();

            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                dspub1 = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                dspub1 = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
            }
            string output22 = "";
            if (dsModify.Tables[0].Rows.Count == 0)
            {
                if (dspub1.Tables[0].Rows.Count > 0)
                {
                    string datapuv = dspub1.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv1 = datapuv.Split(',');
                    editordiv.InnerHtml = "";
                    for (var m = 0; m < datapuv1.Length; m++)
                    {
                        puvdiv11.Attributes.Add("style", "display:block");
                        output22 += "<div style='float:left;'>";
                        output22 += "<div id=divpub_" + m + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                        output22 += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                        output22 += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                        //output += "<Button id='edit_" + i + "' onClick='javascript:selectmatter(this.id,'" + pubcode222 + "');'>Edit</Button>";
                        output22 += "<Button id='edit_" + m + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                        output22 += "</td>";
                        output22 += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                        output22 += "<input  id='filename_" + m + "' style='align:center;width:50px;font-size:10px;' value='" + fname + "'/>";
                        output22 += "</td></div></div>";

                        output22 += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output22 += "<input  type='hidden' id='pubcode_" + m + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv1[m] + "'/>";
                        output22 += "</td>";
                        output22 += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                        output22 += "<input  type='hidden' id='linecount_" + m + "' style='align:center;width:50px;font-size:10px;'/>";
                        output22 += "</td>";
                    }
                    puvdiv11.InnerHtml = output22;
                }
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

                string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
                string[] ff = fname.Split('-');
                string[] ff2 = ff[1].Split('.');

                if (dspub.Tables[0].Rows.Count > 0)
                {

                    string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv1 = datapuv.Split(',');
                    //string [] datapuv11= datapuv1[1].Split('.');
                    for (var j = 0; j < datapuv1.Length; j++)
                    {

                        if (datapuv1[j].Replace(" ", "") == ff2[0].Replace(" ", ""))
                        {

                            data = data.Replace("<br>", "");
                            if (data.IndexOf("<br>") == 0)
                                data = data.Replace("<br>", "");
                            if (data.IndexOf("\r\n") >= 0)
                                data = data.Replace("\r\n", "");
                            data = data.Replace("color=blackWHITEAND}", "");
                            //  data = data.Replace("<font face=Arial>", "").Replace("</font>", "").Replace("<font face=eLokmat>", "").Replace("<font face=Gandhi>", "");
                            //editordiv.InnerHtml = data;

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
            var q = 0;
            for (var i = 0; i < fname.Length; i++)
            {
                q = i;
                if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
                    if (Session["savedata"] == null && previd != "")
                    {
                        dsModify = csModify.getMatter(previd, fname[i]);
                    }
                    else
                    {
                        dsModify = csModify.getMatter(cioid.Value, fname[i]);
                    }
                    dsModify_tem = csModify.getMatter(cioid.Value, fname[i]);
                }
                else
                    if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                        if (Session["savedata"] == null && previd != "")
                        {
                            dsModify = csModify.getMatter(previd, fname[i]);
                        }
                        else
                        {
                            dsModify = csModify.getMatter(cioid.Value, fname[i]);
                        }
                        //dsModify_tem = csModify.getMatter(cioid.Value, fName);


                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                        if (Session["savedata"] == null && previd != "")
                        {
                            dsModify = csModify.getMatter(previd, fname[i]);
                        }
                        else
                        {
                            dsModify = csModify.getMatter(cioid.Value, fname[i]);
                        }
                        // dsModify_tem = csModify.getMatter(cioid.Value, fName);


                    }

                if (dsModify.Tables[0].Rows.Count == 0)
                {
                    //editordiv.InnerHtml = "";
                    ///////////////////add by anuja
                    string ffpub = "";
                    string datapuv22 = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv156 = datapuv22.Split(',');
                    string data = "";
                   
                    if (fname[i].ToString() != "")
                    {
                        string[] ff = fname[i].Split('-');
                        string[] ff2 = ff[1].Split('.');
                        ffpub = ff2[0].Replace(" ", "");
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
                        output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv156[i] + "'/>"; //
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
                                if (fname[i].ToString().Replace(" ", "") != "")
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
                else
                {
                    string ffpub = "";
                    string datapuv22 = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                    string[] datapuv156 = datapuv22.Split(',');
                    string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (fname[i].ToString() != "")
                    {
                        string[] ff = fname[i].Split('-');
                        string[] ff2 = ff[1].Split('.');
                        ffpub = ff2[0].Replace(" ", "");
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
                        output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;' value='" + datapuv156[i] + "'/>"; //
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
                //if (hiddenmodify.Value != "1")
                //{
                //    string datapuv16 = "";
                //    if (dspub.Tables[0].Rows.Count > 0)
                //    {

                //        string datapuv = dspub.Tables[0].Rows[0].ItemArray[0].ToString();
                //        string[] datapuv1 = datapuv.Split(',');

                //        //  datapuv16 = datapuv1[i];

                //    }
                //    puvdiv11.Attributes.Add("style", "display:block");
                //    output += "<div style='float:left;'>";
                //    output += "<div id=divpub_" + i + " style='font-size:14px;height: 160px; width:300px;margin-top:10px; margin-left:10px; border-style: double; overflow: auto;position: relative; padding-top: 15px; word-wrap:break-word;border-color:Blue;' ></div>";
                //    output += "<div style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:35px;margin-top:5px;'>";
                //    output += "<td style='width=5px;height:2px;border:0px solid #7DAAE3;margin-left:6px;align:center; background-color:#DA6200;'>";
                //    output += "<Button id='edit_" + i + "' onClick='javascript:return selectmatter(this.id);' >Edit</Button>";
                //    output += "</td>";
                //    output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;' >";
                //    output += "<input  id='filename_" + i + "' style='align:center;width:50px;font-size:10px;' />";
                //    output += "</td></div></div>";

                //    output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                //    output += "<input  type='hidden' id='pubcode_" + i + "' style='align:center;width:50px;font-size:10px;'  />";
                //    output += "</td>";

                //    output += "<td    style='width=5px;border:1px solid #7DAAE3;font-size:10px;display:none' >";
                //    output += "<input  type='hidden' id='linecount_" + i + "' style='align:center;width:50px;font-size:10px;'/>";
                //    output += "</td>";
                //}
            }

        }


        //if (dsModify.Tables[0].Rows.Count == 0)
        //{
        //    editordiv.InnerHtml = "";
        //}
        //else
        //{
        //    string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
        //    //data = data.Replace("<br>", "");
        //    if (data.IndexOf("<br>") == 0)
        //        data = data.Replace("<br>", "");
        //    data = data.Replace("color=blackWHITEAND}", "");
        //    editordiv.InnerHtml = data;
        //    Session["matter_session_proof"] = data;
        //    Session["matterText_session_proof"] = dsModify.Tables[0].Rows[0].ItemArray[1].ToString();
        //}
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

        HttpContext.Current.Session["matter_session_proof"] = ah.Trim();

        HttpContext.Current.Session["matterText_session_proof"] = matterText;

        //return str;
        return ah;

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
            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
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
            dspub = getpubwidth.getpublication(Session["compcode"].ToString(), hiddenpublicode.Value);
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
    [Ajax.AjaxMethod]
    public DataSet pucodforedition(string comcode, string edicode)
    {
        DataSet dspub = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
            dspub = getpubwidth.getpubcodeedit(comcode, edicode);

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
}
//{
//        DataSet dsModify = new DataSet();

//        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
//        {
//            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
//            //if (Session["savedata"] == null && previd != "")
//            //{
//            //    dsModify = csModify.getMatter(previd, fName);
//            //}
//            //else
//            //{
//                dsModify = csModify.getMatter(cioid.Value, fName);
//            //}
//            //dsModify_tem = csModify.getMatter(cioid.Value, fName);
//        }
//        else
//            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
//            {
//                NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
//                //if (Session["savedata"] == null && previd != "")
//                //{
//                //    dsModify = csModify.getMatter(previd, fName);
//                //}
//                //else
//                //{
//                    dsModify = csModify.getMatter(cioid.Value, fName);
//                //}
//                //dsModify_tem = csModify.getMatter(cioid.Value, fName);


//            }
//            else
//            {
//                NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
//                //if (Session["savedata"] == null && previd != "")
//                //{
//                //    dsModify = csModify.getMatter(previd, fName);
//                //}
//                //else
//                //{
//                    dsModify = csModify.getMatter(cioid.Value, fName);
//                //}
//                // dsModify_tem = csModify.getMatter(cioid.Value, fName);


//            }
