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
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Text;

public partial class datewise_publicationwise_editionwise_billing_report_view : System.Web.UI.Page
{
    string Destination = "";
    string Report = "";
    string fromdate = "";
    string todate = "";
    string printing_centercode = "";
    string printingcentername = "";
    string printingcenter_name = "";
    string branch_name = "";
    string publication = "";
    string publicationname = "";
    string publicationtieup = "";
    string publicationtieup_name = "";
    string branchcode = "";
    string adv_type = "";
    string adtype_name = "";
    string adcat_code = "";
    string adv_category = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string d = "";
    string branch_find = "";
    int pageno = 1;
    string rundate = "";

    int maxlimit = 3;
    int sno = 1;
    string name1 = "", name2 = "", name3 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script> window.parent.location=\" login.aspx\";</script>)");
            return;
        }
        hiddendateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        rundate = DateTime.Today.ToString().Split(' ')[0];
        string date11117 = rundate;
        string dd7 = date11117.Split('/')[1];
        string mm7 = date11117.Split('/')[0];
        string yyyy7 = date11117.Split('/')[2];
        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {
            rundate = RETURN_LENGTH(dd7) + "/" + RETURN_LENGTH(mm7) + "/" + yyyy7;
        }
        else
            if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
            {
                rundate = yyyy7 + "/" + RETURN_LENGTH(mm7) + "/" + RETURN_LENGTH(dd7);
            }
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/date_pubediwise_billing_rpt.xml"));
        Report = ds1.Tables[0].Rows[0].ItemArray[9].ToString(); ;
        Destination = Request.QueryString["Destination"].ToString();

       

        fromdate = Request.QueryString["fromdate"].ToString();
        hdnfromdate11.Value = Request.QueryString["fromdate"].ToString();

        todate = Request.QueryString["todate"].ToString();
        hdntodate11.Value = Request.QueryString["todate"].ToString();

     

        publication = Request.QueryString["publication_code"].ToString();
        hdnpublication.Value = Request.QueryString["publication_code"].ToString();

        publicationname = Request.QueryString["pub_name"].ToString();
        hdnpubname.Value = Request.QueryString["pub_name"].ToString();

        publicationtieup = Request.QueryString["publicationtieup"].ToString();
        hdn_pub_tieup.Value = Request.QueryString["publicationtieup"].ToString();

        publicationtieup_name = Request.QueryString["publicationtieup_name"].ToString();
        hdn_pub_tieup_name.Value = Request.QueryString["publicationtieup_name"].ToString();

        adv_type = Request.QueryString["adtype"].ToString();
        hdnadtype.Value = Request.QueryString["adtype"].ToString();

        adtype_name = Request.QueryString["ad_type"].ToString();
        hdnad_type.Value = Request.QueryString["ad_type"].ToString();

      
        extra1 = Request.QueryString["ext1"].ToString();
        hdnextra111.Value = Request.QueryString["ext1"].ToString();

        extra2 = Request.QueryString["ext2"].ToString();
        hdnextra211.Value = Request.QueryString["ext2"].ToString();

        extra3 = Request.QueryString["ext3"].ToString();
        hdnextra311.Value = Request.QueryString["ext3"].ToString();

        extra4 = Request.QueryString["ext4"].ToString();
        hdnextra411.Value = Request.QueryString["ext4"].ToString();

        extra5 = Request.QueryString["ext5"].ToString();
        hdnextra511.Value = Request.QueryString["ext5"].ToString();

        if (!Page.IsPostBack)
        {
           
            {
                if (Destination == "1" || Destination == "0")
                {
                    ShowReport();
                }
                else if (Destination == "4")
                {
                    showreportexcel();
                }
                
            }
            
        }

    }

    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }


    private void ShowReport()
    {
        int t = 0;
        string code_data = "";
        StringBuilder tbl1 = new StringBuilder();
        
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise rpt = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = rpt.category_billing(hdncompcode.Value, publication, publicationtieup, adv_type, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise rpt = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = rpt.category_billing(hdncompcode.Value, publication, publicationtieup,  adv_type,  fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(datewise_publicationwise_editionwise_billing_report_view), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }

        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>");

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            string reportname1 = Report;

            tbl1.Append("<tr><td>");
            tbl1.Append("<table style='width:100%' >");
            tbl1.Append("<tr><td></td><td align='center' style='height: 20px' colspan='2' class='headingc' > ");
            tbl1.Append(compname1);
            tbl1.Append("</td></tr>");

            tbl1.Append("<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>");
            tbl1.Append("<td align='center' style='height: 20px; font-size:16px' colspan='2' class ='headingp1'><b>");
            tbl1.Append(reportname1);
            tbl1.Append("</b></td></tr>");

            tbl1.Append("<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>");
            tbl1.Append("<td align='center' style='height: 20px; font-family:Arial; font-size:12px' colspan='2'><b>From Date  </b>" + fromdate + "<b>    To   </b>" + todate + "</td>");
            tbl1.Append("</tr>");

            tbl1.Append("</table>");

            tbl1.Append("<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >");
            string pub_name = "";
            if (publicationname == "" || publicationname == null)
            {
                pub_name = "All";

            }
            else
            {
                pub_name = publicationname;
            }
            tbl1.Append("<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Publication:</b>" + pub_name + "</td>");

            string printingname = "";
            if (printingcentername == "" || printingcentername == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = printingcentername;
            }

            //tbl1.Append("<td  align='left' style='font-family:Arial;font-size:12px;'></td>";
            string brname = "";
            if (publicationtieup_name == "" || publicationtieup_name == null)
            {
                brname = "All";

            }
            else
            {
                brname = publicationtieup_name;
            }
            tbl1.Append("<td  align='right'style='font-family:Arial;font-size:12px;'><b>Publication Tie-Up:</b>" + brname + "</td></tr>");
            

            string adt = "";
            if (adtype_name == "" || adtype_name == null)
            {
                adt = "All";

            }
            else
            {
                adt = adtype_name;
            }
            tbl1.Append("<tr><td  align='left' style='font-family:Arial;font-size:12px;'><b>Ad Type:</b>" + adt + "</td>");

            string adcatname = "";
            if (adv_category == "" || adv_category == null)
            {
                adcatname = "All";

            }
            else
            {
                adcatname = adv_category;
            }
            //tbl1.Append("<td  align='left'style='font-family:Arial;font-size:12px;'></td>";

            tbl1.Append("<td  align='right' style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>");
            //string pno = 1;
            //tbl1.Append("<td  align='right'style='font-family:Arial;font-size:12px;'><b>Taluka Name:</b>" + pno + "</td></tr>";

            tbl1.Append(" </table>");
            /*************************  Header Starts here ******************************/
            tbl1.Append("<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='1'>");
            string sp_pubtype = "";
            string sp_pubtype1= "";
            string sp_pubcent = "";
            string sp_pubname = "";
            string sp_pubname3 = "";
            string sp_pubname4 = "";
            string sp_pubname5 = "";
            string sp_pubname6 = "";
            string sp_pubtype7 = "";
            string pubnm = "";
            int[] pubtypecol = new int[ds.Tables[0].Columns.Count - 1];
            int[] pubcol = new int[ds.Tables[0].Columns.Count - 1];
            int pubtype = 0;
            int de1 = 3;

            string TBLPUB = "";
            TBLPUB = TBLPUB + "<tr>";
            TBLPUB = TBLPUB + "<td>";
            TBLPUB = TBLPUB + "</td>";
            int xx = 0;
            int xxx = 0;
            int bc = 0;
            string flag = "";
            for (int i = 3; i < (ds.Tables[0].Columns.Count - 1); i++)
            {

                string[] split_pubtype2 = ds.Tables[0].Columns[i].Caption.Split('#');
                string[] split_pub_cent = split_pubtype2[1].Split('~');
                if ((sp_pubname4.IndexOf(split_pubtype2[0]) < 0) && (i > 3))
                {
                    string[] split_pubtype32 = ds.Tables[0].Columns[i - 1].Caption.Split('#');
                    string[] split_pub_cent32 = split_pubtype32[1].Split('~');
                    TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>" + get_pubtype(hdncompcode.Value, split_pubtype32[0], "", "") + "  Total</b>";
                    i--;
                    TBLPUB = TBLPUB + "</td>";
                    pubtypecol[xx] = bc + 1;
                    bc = 0;
                    xx++;
                }
                else
                {
                    TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>" + get_pub_cent(hdncompcode.Value, split_pub_cent[1]) + "</b>";
                    TBLPUB = TBLPUB + "</td>";
                    bc++;

                }
                sp_pubcent += split_pub_cent[1] + "~";
                sp_pubname4 += split_pubtype2[0] + "~";



                string[] split_pubtype1 = ds.Tables[0].Columns[i].Caption.Split('#');
                string[] split_pubn = split_pubtype1[1].Split('~');
               
                if (sp_pubname.IndexOf(split_pubn[0]) < 0)
                {
                    string[] split_magtype = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
                    string[] split_magnm = split_magtype[1].Split('~');
                    if (i >3 )
                    {
                      
                        if (flag == "")
                        {
                            pubcol[xxx] = pubtype + 1;
                            flag = "true";
                        }
                        else
                        {
                            pubcol[xxx] = pubtype ;
                        }
                        xxx++;
                    }
                   pubtype = 0;
                   
                }
                pubtype++;
                sp_pubname += split_pubn[0] + "~";  

            }
            pubcol[xxx] = pubtype;
            sp_pubname = "";
            string[] split_pubtype5 = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
            TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>" + get_pubtype(hdncompcode.Value, split_pubtype5[0], "", "") + "  Total</b>";
            TBLPUB = TBLPUB + "</td>";
            TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>Total</b>";
            TBLPUB = TBLPUB + "</td>";
            TBLPUB = TBLPUB + "</tr>";
            pubtypecol[xx] = bc + 1;
            bc = 0;

            for (int i = 2; i < (ds.Tables[0].Columns.Count-1); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "BILLDT")
                {
                    tbl1.Append("<tr><td class='middle31new' align='left'><b>Bill Date</b></td>");
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1.Append("<td ColSpan='2' class='middle31new' align='right'><b>Total</b>");
                    tbl1.Append("</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO");
                    tbl1.Append("</td>");
                }              
                else if (i >= 3)
                {
                    string[] split_pubtype = ds.Tables[0].Columns[i].Caption.Split('#');   
                                   
                    if (sp_pubtype.IndexOf(split_pubtype[0]) < 0)
                    {
                        
                        tbl1.Append("<td ColSpan='" + pubtypecol[bc] + "' class='middle31new' align='center'><b>" + get_pubtype(hdncompcode.Value, split_pubtype[0], "", "") + "</b>");
                       // sp_pubtype7 += split_pubtype[0] +"-"+pubtype+"~";
                        pubtype = 0;                      
                        tbl1.Append("</td>");
                        bc++;
                    }
                  
                    sp_pubtype += split_pubtype[0] + "~";
                }                
            }
            tbl1.Append("</tr>");
            tbl1.Append("<tr>");
            pubtype = 0;
            bc = 0;
            
            for (int i = 3; i < (ds.Tables[0].Columns.Count-1); i++)
            {
                //pubtype = 0;          
                //    if (i >= 3)
                //{
                    string[] split_pubtype1 = ds.Tables[0].Columns[i].Caption.Split('#');
                    string[] split_pubn = split_pubtype1[1].Split('~');                  
                        if (sp_pubname.IndexOf(split_pubn[0]) < 0)
                        {
                            string[] split_magtype = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
                            string[] split_magnm = split_magtype[1].Split('~');
                            if (split_pubn[0] == split_magnm[0])
                            {
                                pubtype = pubtype - 2;
                            }
                            //tbl1.Append("<td>";
                            //tbl1.Append("</td>";
                            tbl1.Append("<td ColSpan='" + pubcol[bc] + "' class='middle31new' align='center'><b>" + get_pub(hdncompcode.Value, split_pubn[0]) + "</b>");
                            pubtype = 0; 
                            tbl1.Append("</td>");
                            bc++;
                        }
                        pubtype++;
                        sp_pubname += split_pubn[0] + "~";                  
                //}
            }
            tbl1.Append("</tr>");

            tbl1.Append(TBLPUB.ToString());
            //==================================================for values=========================================================================================================================

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                double total123 = 0;
                tbl1.Append("<tr>");
                sp_pubname5 = "";
                for (int j = 2; j <= ds.Tables[0].Columns.Count-1; j++)
                {
                    string pub_brk = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                 
                    if (j == 2)
                    {
                       tbl1.Append("<td class='rep_data' align='left'>" + (ds.Tables[0].Rows[i].ItemArray[j].ToString()) + "</td>");
                    }                  
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        string[] split_pubtype10 = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');   
                        if (split_pubtype10[0] == ds.Tables[1].Columns[ds.Tables[1].Columns.Count - 1].Caption)
                        {
                            tbl1.Append("<td colspan='1' class='rep_data' align='right'><b>" + ds.Tables[1].Rows[i].ItemArray[ds.Tables[1].Columns.Count - 1].ToString() + "</b>");
                            tbl1.Append("</td>");
                        }
                        tbl1.Append("<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "</td>");
                    }                    
                    else if (j >= 3 && j < ds.Tables[0].Columns.Count - 1)
                    {                      
                        string[] split_pubtype3 = ds.Tables[0].Columns[j].Caption.Split('#');                      
                        if ((sp_pubname5.IndexOf(split_pubtype3[0]) < 0) && (j > 3))
                        {                           
                                for (int c = 3; c < ds.Tables[1].Columns.Count; c++)
                                {
                                    string[] split_pubtype67 = ds.Tables[0].Columns[j - 1].Caption.Split('#');
                                    if (split_pubtype67[0] == ds.Tables[1].Columns[c].Caption)
                                    {
                                        tbl1.Append("<td colspan='1' class='rep_data' align='right'><b>" + ds.Tables[1].Rows[i].ItemArray[c].ToString() + "</b>");
                                        tbl1.Append("</td>");
                                    }                                     
                                }                          
                        }                     
                            sp_pubname5 += split_pubtype3[0] + "~";                     
                            tbl1.Append("<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                            total123 = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j].ToString());                                              
                    }                  
                }               
                tbl1.Append("</tr>");                                  
            }
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                tbl1.Append("<tr>");
                tbl1.Append("<td colspan='1' class='middle31new' align='right'><b>Total</b>");
                for (int j = 2; j <= ds.Tables[3].Columns.Count - 1; j++)
                {
                    

                    string[] split_pubtype3 = ds.Tables[3].Columns[j].Caption.Split('#');
                    if ((sp_pubname6.IndexOf(split_pubtype3[0]) < 0) && (j > 2))
                    {
                        double add_total = 0;
                        for (int c = 3; c < ds.Tables[1].Columns.Count; c++)
                        {
                            string[] split_pubtype67 = ds.Tables[3].Columns[j - 1].Caption.Split('#');
                            if (split_pubtype67[0] == ds.Tables[1].Columns[c].Caption)
                            {
                                for (int x = 0; x < ds.Tables[1].Rows.Count; x++)
                                {
                                    add_total = add_total + Convert.ToDouble(ds.Tables[1].Rows[x].ItemArray[c].ToString());
                                }
                               
                            }
                        }
                        tbl1.Append("<td colspan='1' class='middle31new' align='right'><b>" + add_total + "</b>");
                        tbl1.Append("</td>");
                    }
                    sp_pubname6 += split_pubtype3[0] + "~";
                    tbl1.Append("<td class='middle31new' align='right'>" + ds.Tables[3].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                
                tbl1.Append("</tr>");
            }
            tbl1.Append("</table>");

            tblgrid.InnerHtml = tbl1.ToString();
           // btnprint.Attributes.Add("onclick", "javascript:return window.open('datewise_billing_report_print.aspx?Destination=" + Destination + "&report_name=" + Report + "&fromdate=" + fromdate + "&todate=" + todate + "&printingcenter_name=" + printingcenter_name + "&printingcenter=" + printing_centercode + "&branch=" + branchcode + "&branch_name=" + branch_name + "&publication_code=" + publication + "&pub_name=" + publicationname + "&adtype=" + adv_type + "&ad_type=" + adtype_name + "&adcat=" + adcat_code + "&ad_category=" + adv_category + "&ext1=" + extra1 + "&ext2=" + extra2 + "&ext3=" + extra3 + "&ext4=" + extra4 + "&ext5=" + extra5 + "')");
                                                                                                                  
        }
    }

    private void showreportexcel()
    {
        int t = 0;
        string code_data = "";
        StringBuilder tbl1 = new StringBuilder();

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise rpt = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = rpt.category_billing(hdncompcode.Value, publication, publicationtieup, adv_type, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise rpt = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = rpt.category_billing(hdncompcode.Value, publication, publicationtieup, adv_type, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(datewise_publicationwise_editionwise_billing_report_view), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1.Append("<table width='120%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>");

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            int coloumcnt = (ds.Tables[0].Columns.Count - 2) + (ds.Tables[1].Columns.Count - 3);
            int cnt1 = 0;
            int cnt2=0;
            if (coloumcnt % 2 == 0)
            {
                cnt1 = coloumcnt / 2;
                cnt2 = cnt1;
            }
            else
            {
                cnt1 = (coloumcnt-1) / 2;
                cnt2 = cnt1;
            }
           

            string reportname1 = Report;

            tbl1.Append("<tr><td>");
            tbl1.Append("<table style='width:120%' >");
            tbl1.Append("<tr><td align='center' style='height: 20px; font-size:18px' colspan=" + coloumcnt + " class='headingc' ><b> ");
            tbl1.Append(compname1);
            tbl1.Append("</b></td></tr>");

            tbl1.Append("<tr style=width:120%'>");
            tbl1.Append("<td align='center' style='height: 20px; font-size:16px' colspan=" + coloumcnt + " class ='headingp1'><b>");
            tbl1.Append(reportname1);
            tbl1.Append("</b></td></tr>");

            tbl1.Append("<tr style=width:120%'>");
            tbl1.Append("<td align='center' style='height: 20px;padding-right:130px; font-family:Arial;font-size:12px' colspan=" + coloumcnt + "><b>From Date  </b>" + fromdate + "<b>    To   </b>" + todate + "</td>");
            tbl1.Append("</tr>");

            tbl1.Append("<tr></tr></table>");

            tbl1.Append("<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='120%' >");
            string pub_name = "";
            if (publicationname == "" || publicationname == null)
            {
                pub_name = "All";

            }
            else
            {
                pub_name = publicationname;
            }
            tbl1.Append("<tr><td  align='left'style='font-family:Arial;font-size:12px; width:40%;' colspan=" + cnt1 + "><b>Publication:</b>" + pub_name + "</td>");

            string printingname = "";
            if (printingcentername == "" || printingcentername == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = printingcentername;
            }

            tbl1.Append("<td  align='left' style='font-family:Arial;font-size:12px;'></td>");
            string brname = "";
            if (publicationtieup_name == "" || publicationtieup_name == null)
            {
                brname = "All";

            }
            else
            {
                brname = publicationtieup_name;
            }
            tbl1.Append("<td  align='right'style='font-family:Arial;font-size:12px;' colspan=" + cnt1 + "><b>Publication Tie-Up:</b>" + brname + "</td></tr>");


            string adt = "";
            if (adtype_name == "" || adtype_name == null)
            {
                adt = "All";

            }
            else
            {
                adt = adtype_name;
            }
            tbl1.Append("<tr><td  align='left'style='font-family:Arial;font-size:12px; width:40%;' colspan=" + cnt1 + "><b>Ad Type:</b>" + adt + "</td>");

            string adcatname = "";
            if (adv_category == "" || adv_category == null)
            {
                adcatname = "All";

            }
            else
            {
                adcatname = adv_category;
            }
            tbl1.Append("<td  align='left'style='font-family:Arial;font-size:12px;'></td>");

            tbl1.Append("<td  align='right'style='font-family:Arial;font-size:12px;' colspan=" + cnt1 + "><b>Run Date:</b>" + rundate + "</td></tr>");
            //string pno = 1;
            //tbl1.Append("<td  align='right'style='font-family:Arial;font-size:12px;'><b>Taluka Name:</b>" + pno + "</td></tr>");

            tbl1.Append(" </table>");
            /*************************  Header Starts here ******************************/
            tbl1.Append("<table style='vertical-align:top' width='120%' cellpadding='0px' cellspacing ='0px' border ='1'>");
            string sp_pubtype = "";
            string sp_pubtype1 = "";
            string sp_pubcent = "";
            string sp_pubname = "";
            string sp_pubname3 = "";
            string sp_pubname4 = "";
            string sp_pubname5 = "";
            string sp_pubname6 = "";
            string sp_pubtype7 = "";
            string pubnm = "";
            int[] pubtypecol = new int[ds.Tables[0].Columns.Count - 1];
            int[] pubcol = new int[ds.Tables[0].Columns.Count - 1];
            int pubtype = 0;
            int de1 = 3;

            string TBLPUB = "";
            TBLPUB = TBLPUB + "<tr>";
            TBLPUB = TBLPUB + "<td>";
            TBLPUB = TBLPUB + "</td>";
            int xx = 0;
            int xxx = 0;
            int bc = 0;
            string flag = "";
            for (int i = 3; i < (ds.Tables[0].Columns.Count - 1); i++)
            {

                string[] split_pubtype2 = ds.Tables[0].Columns[i].Caption.Split('#');
                string[] split_pub_cent = split_pubtype2[1].Split('~');
                if ((sp_pubname4.IndexOf(split_pubtype2[0]) < 0) && (i > 3))
                {
                    string[] split_pubtype32 = ds.Tables[0].Columns[i - 1].Caption.Split('#');
                    string[] split_pub_cent32 = split_pubtype32[1].Split('~');
                    TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>" + get_pubtype(hdncompcode.Value, split_pubtype32[0], "", "") + "  Total</b>";
                    i--;
                    TBLPUB = TBLPUB + "</td>";
                    pubtypecol[xx] = bc + 1;
                    bc = 0;
                    xx++;
                }
                else
                {
                    TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>" + get_pub_cent(hdncompcode.Value, split_pub_cent[1]) + "</b>";
                    TBLPUB = TBLPUB + "</td>";
                    bc++;

                }
                sp_pubcent += split_pub_cent[1] + "~";
                sp_pubname4 += split_pubtype2[0] + "~";



                string[] split_pubtype1 = ds.Tables[0].Columns[i].Caption.Split('#');
                string[] split_pubn = split_pubtype1[1].Split('~');

                if (sp_pubname.IndexOf(split_pubn[0]) < 0)
                {
                    string[] split_magtype = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
                    string[] split_magnm = split_magtype[1].Split('~');
                    if (i > 3)
                    {

                        if (flag == "")
                        {
                            pubcol[xxx] = pubtype + 1;
                            flag = "true";
                        }
                        else
                        {
                            pubcol[xxx] = pubtype;
                        }
                        xxx++;
                    }
                    pubtype = 0;

                }
                pubtype++;
                sp_pubname += split_pubn[0] + "~";

            }
            pubcol[xxx] = pubtype;
            sp_pubname = "";
            string[] split_pubtype5 = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
            TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>" + get_pubtype(hdncompcode.Value, split_pubtype5[0], "", "") + "  Total</b>";
            TBLPUB = TBLPUB + "</td>";
            TBLPUB = TBLPUB + "<td colspan='1' class='middle31new' align='right'><b>Total</b>";
            TBLPUB = TBLPUB + "</td>";
            TBLPUB = TBLPUB + "</tr>";
            pubtypecol[xx] = bc + 1;
            bc = 0;

            for (int i = 2; i < (ds.Tables[0].Columns.Count - 1); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "BILLDT")
                {
                    tbl1.Append("<tr><td class='middle31new' align='left'><b>Bill Date</b></td>");
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1.Append("<td ColSpan='2' class='middle31new' align='right'><b>Total</b>");
                    tbl1.Append("</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO");
                    tbl1.Append("</td>");
                }
                else if (i >= 3)
                {
                    string[] split_pubtype = ds.Tables[0].Columns[i].Caption.Split('#');

                    if (sp_pubtype.IndexOf(split_pubtype[0]) < 0)
                    {

                        tbl1.Append("<td ColSpan='" + pubtypecol[bc] + "' class='middle31new' align='center'><b>" + get_pubtype(hdncompcode.Value, split_pubtype[0], "", "") + "</b>");
                        // sp_pubtype7 += split_pubtype[0] +"-"+pubtype+"~");
                        pubtype = 0;
                        tbl1.Append("</td>");
                        bc++;
                    }

                    sp_pubtype += split_pubtype[0] + "~";
                }
            }
            tbl1.Append("</tr>");
            tbl1.Append("<tr>");
            pubtype = 0;
            bc = 0;

            for (int i = 3; i < (ds.Tables[0].Columns.Count - 1); i++)
            {
                //pubtype = 0;          
                //    if (i >= 3)
                //{
                string[] split_pubtype1 = ds.Tables[0].Columns[i].Caption.Split('#');
                string[] split_pubn = split_pubtype1[1].Split('~');
                if (sp_pubname.IndexOf(split_pubn[0]) < 0)
                {
                    string[] split_magtype = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
                    string[] split_magnm = split_magtype[1].Split('~');
                    if (split_pubn[0] == split_magnm[0])
                    {
                        pubtype = pubtype - 2;
                    }
                    //tbl1.Append("<td>");
                    //tbl1.Append("</td>");
                    tbl1.Append("<td ColSpan='" + pubcol[bc] + "' class='middle31new' align='center'><b>" + get_pub(hdncompcode.Value, split_pubn[0]) + "</b>");
                    pubtype = 0;
                    tbl1.Append("</td>");
                    bc++;
                }
                pubtype++;
                sp_pubname += split_pubn[0] + "~";
                //}
            }
            tbl1.Append("</tr>");

            tbl1.Append(TBLPUB.ToString());
            //==================================================for values=========================================================================================================================

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                double total123 = 0;
                tbl1.Append("<tr>");
                sp_pubname5 = "";
                for (int j = 2; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    string pub_brk = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                    if (j == 2)
                    {
                        tbl1.Append("<td class='rep_data' align='left'>" + (ds.Tables[0].Rows[i].ItemArray[j].ToString()) + "</td>");
                    }
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        string[] split_pubtype10 = ds.Tables[0].Columns[ds.Tables[0].Columns.Count - 2].Caption.Split('#');
                        if (split_pubtype10[0] == ds.Tables[1].Columns[ds.Tables[1].Columns.Count - 1].Caption)
                        {
                            tbl1.Append("<td colspan='1' class='rep_data' align='right'><b>" + ds.Tables[1].Rows[i].ItemArray[ds.Tables[1].Columns.Count - 1].ToString() + "</b>");
                            tbl1.Append("</td>");
                        }
                        tbl1.Append("<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "</td>");
                    }
                    else if (j >= 3 && j < ds.Tables[0].Columns.Count - 1)
                    {
                        string[] split_pubtype3 = ds.Tables[0].Columns[j].Caption.Split('#');
                        if ((sp_pubname5.IndexOf(split_pubtype3[0]) < 0) && (j > 3))
                        {
                            for (int c = 3; c < ds.Tables[1].Columns.Count; c++)
                            {
                                string[] split_pubtype67 = ds.Tables[0].Columns[j - 1].Caption.Split('#');
                                if (split_pubtype67[0] == ds.Tables[1].Columns[c].Caption)
                                {
                                    tbl1.Append("<td colspan='1' class='rep_data' align='right'><b>" + ds.Tables[1].Rows[i].ItemArray[c].ToString() + "</b>");
                                    tbl1.Append("</td>");
                                }
                            }
                        }
                        sp_pubname5 += split_pubtype3[0] + "~";
                        tbl1.Append("<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                        total123 = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j].ToString());
                    }
                }
                tbl1.Append("</tr>");
            }
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                tbl1.Append("<tr>");
                tbl1.Append("<td colspan='1' class='middle31new' align='right'><b>Total</b>");
                for (int j = 2; j <= ds.Tables[3].Columns.Count - 1; j++)
                {


                    string[] split_pubtype3 = ds.Tables[3].Columns[j].Caption.Split('#');
                    if ((sp_pubname6.IndexOf(split_pubtype3[0]) < 0) && (j > 2))
                    {
                        double add_total = 0;
                        for (int c = 3; c < ds.Tables[1].Columns.Count; c++)
                        {
                            string[] split_pubtype67 = ds.Tables[3].Columns[j - 1].Caption.Split('#');
                            if (split_pubtype67[0] == ds.Tables[1].Columns[c].Caption)
                            {
                                for (int x = 0; x < ds.Tables[1].Rows.Count; x++)
                                {
                                    add_total = add_total + Convert.ToDouble(ds.Tables[1].Rows[x].ItemArray[c].ToString());
                                }

                            }
                        }
                        tbl1.Append("<td colspan='1' class='middle31new' align='right'><b>" + add_total + "</b>");
                        tbl1.Append("</td>");
                    }
                    sp_pubname6 += split_pubtype3[0] + "~";
                    tbl1.Append("<td class='middle31new' align='right'>" + ds.Tables[3].Rows[i].ItemArray[j].ToString() + "</td>");
                }

                tbl1.Append("</tr>");
            }
            tbl1.Append("</table>");

            tblgrid.InnerHtml = tbl1.ToString();
            // btnprint.Attributes.Add("onclick", "javascript:return window.open('datewise_billing_report_print.aspx?Destination=" + Destination + "&report_name=" + Report + "&fromdate=" + fromdate + "&todate=" + todate + "&printingcenter_name=" + printingcenter_name + "&printingcenter=" + printing_centercode + "&branch=" + branchcode + "&branch_name=" + branch_name + "&publication_code=" + publication + "&pub_name=" + publicationname + "&adtype=" + adv_type + "&ad_type=" + adtype_name + "&adcat=" + adcat_code + "&ad_category=" + adv_category + "&ext1=" + extra1 + "&ext2=" + extra2 + "&ext3=" + extra3 + "&ext4=" + extra4 + "&ext5=" + extra5 + "')");

        }

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }







    public string changeformat1(string Supplydate)
    {
        string[] arr = Supplydate.Split('/');
        //string len_dt = arr[1];
        //string len_mnth = arr[0];
        if (arr[1].ToString().Length < 2)
        {
            arr[1] = "0" + arr[1];
        }
        else
        {
            arr[1] = arr[1];
        }
        if (arr[0].ToString().Length < 2)
        {
            arr[0] = "0" + arr[0];
        }
        else
        {
            arr[0] = arr[0];
        }
        string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
        return change;
    }

    public string get_pubtype(string compcode, string pubtypecode, string extra1, string extra2)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise supost = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = supost.bind_function(compcode, pubtypecode, extra1, extra2);
        }
        else
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise supost = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = supost.bind_function(compcode, pubtypecode, extra1, extra2);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            return fetchvalue;
        }
        return fetchvalue;
    }

    public string get_pub(string compcode, string pubcode)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise supost1 = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = supost1.bind_publication(compcode, pubcode);
        }
        else
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise supost1 = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = supost1.bind_publication(compcode, pubcode);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            return fetchvalue;
        }
        return fetchvalue;
    }



    public string get_pub_cent(string compcode, string pubcode)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise supost1 = new NewAdbooking.Report.classesoracle.datewise_billwise_publicationwise();
            ds = supost1.bind_print_cent(compcode, pubcode);
        }
        else
        {
            NewAdbooking.Report.Classes.datewise_billwise_publicationwise supost1 = new NewAdbooking.Report.Classes.datewise_billwise_publicationwise();
            ds = supost1.bind_print_cent(compcode, pubcode);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            return fetchvalue;
        }
        return fetchvalue;
    }
}
