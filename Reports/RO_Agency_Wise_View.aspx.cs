using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;
//using System.Linq;
//using System.Xml.Linq;
using System.Text;

public partial class RO_Agency_Wise_View : System.Web.UI.Page
{
    string from_date = "", to_date = "", print_center = "", agency = "", branch = "", district = "", executive = "", retainer = "", taluka = "", ro_docstatus = "", paymode = "", det_summ = "", age_exeret = "";
    string compcode = "", userid = "", dateformat = "", Run_Date = "", day = "", month = "", year = "", branch_name = "", destination="";
    string heading = "",lbl_from="",lbl_to="",lbl_run="";
    string name1 = "", name2 = "", name3 = "",comp_name="";
    double tot_buss = 0;
    Int64 tot_org = 0, tot_xerox = 0, tot_fax = 0, tot_remain = 0, tot_total = 0,tot_grandtot=0;
    int sno = 1;
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;

    //for print
    int maxlimit = 10;
    int maxlimit1 = 10;
    int a = 0;
   
    string chk_excel = "", print_cent_name="", taluka_name="", agency_name="", exe_name="", ret_name="", adtyp_name="", adcat_name="", typ_name="", rodoc_status_name="", paymode_name="";
    string temp_printcent = "", temp_taluka = "", temp_branch = "", temp_district = "", temp_rodocstatus = "", temp_paymode = "", temp_adtyp = "", temp_adcat = "", temp_typname = "", temp_baseon = "", temp_agency_exe_ret = "", rptype="";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat = hiddendateformat.Value;

            DataSet brk = new DataSet();
            brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
            maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[51].ToString());
            maxlimit1 = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[53].ToString());
            browser = Request.Browser;

            ver = (float)(browser.MajorVersion + browser.MinorVersion);


            Ajax.Utility.RegisterTypeForAjax(typeof(RO_Agency_Wise_View));

            ds = (DataSet)Session["roreport"];

            comp_name = Session["comp_name"].ToString();//ds.Tables[1].Rows[0].ItemArray[0].ToString();

            string prm = Session["roparameter"].ToString();
            string[] prm_Array = new string[59];
            prm_Array = prm.Split('~');


            from_date = prm_Array[1];
            to_date = prm_Array[3];
            print_center = prm_Array[5];
            agency = prm_Array[7];
            branch = prm_Array[9];
            district = prm_Array[11];
            taluka = prm_Array[13];
            ro_docstatus = prm_Array[15];
            paymode = prm_Array[17];
            executive = prm_Array[19];
            retainer = prm_Array[21];
            det_summ = prm_Array[23];
            age_exeret = prm_Array[25];
            branch_name = prm_Array[27];
            destination = prm_Array[29];
            chk_excel = prm_Array[31];

            print_cent_name = prm_Array[33];
            taluka_name = prm_Array[35];
            agency_name = prm_Array[37];
            exe_name = prm_Array[39];
            ret_name = prm_Array[41];
            typ_name = prm_Array[43];
            adtyp_name = prm_Array[45];
            adcat_name = prm_Array[47];
            rodoc_status_name = prm_Array[49];
            paymode_name = prm_Array[51];
            rptype = prm_Array[53];

            if (print_center == "0")
                temp_printcent = "All";
            else
                temp_printcent = print_cent_name;

            if (taluka == "0")
                temp_taluka = "All";
            else
                temp_taluka = taluka_name;

            if (branch == "0")
                temp_branch = "All";
            else
                temp_branch = branch_name;

            if (district == "Select District")
                temp_district = "All";
            else
                temp_district = district;

            if (ro_docstatus == "0")
                temp_rodocstatus = "All";
            else
                temp_rodocstatus = rodoc_status_name;

            if (paymode == "0")
                temp_paymode = "All";
            else
                temp_paymode = paymode_name;

            if (adtyp_name == "Select AdType")
                temp_adtyp = "All";
            else
                temp_adtyp = adtyp_name;

            if (adcat_name == "Select AdCat")
                temp_adcat = "All";
            else
                temp_adcat = adcat_name;

            if (typ_name == "--Select Type--")
                temp_typname = "Both";
            else
                temp_typname = typ_name;
            

            if (age_exeret == "1")
            {
                temp_baseon = "Agency";
                if (agency_name == "")
                    temp_agency_exe_ret = "All";
                else
                    temp_agency_exe_ret = agency_name;
            }
            else if (age_exeret == "2")
            {
                temp_baseon = "Executive";
                if (exe_name == "")
                    temp_agency_exe_ret = "All";
                else
                    temp_agency_exe_ret = exe_name;
            }
            else
            {
                temp_baseon = "Retainer";
                if (ret_name == "")
                    temp_agency_exe_ret = "All";
                else
                    temp_agency_exe_ret = ret_name;
            }



            DataSet ds_head = new DataSet();
            ds_head.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));
            if (age_exeret == "1")
            {
                if (det_summ == "1")
                {
                    lblHeading.Text = ds_head.Tables[2].Rows[0].ItemArray[0].ToString();//agency wise detail
                }
                else
                {
                    lblHeading.Text = ds_head.Tables[2].Rows[0].ItemArray[2].ToString();//agency wise summary
                }

            }

            else if (age_exeret == "2")
            
            {
                if (det_summ == "1")
                {
                    lblHeading.Text = ds_head.Tables[2].Rows[0].ItemArray[7].ToString();//exe_ret wise detail
                }
                else
                {
                    lblHeading.Text = ds_head.Tables[2].Rows[0].ItemArray[9].ToString();//exe_ret wise summary
                }
            }
            else
            {
                if (det_summ == "1")
                {
                    lblHeading.Text = ds_head.Tables[2].Rows[0].ItemArray[8].ToString();//exe_ret wise detail
                }
                else
                {
                    lblHeading.Text = ds_head.Tables[2].Rows[0].ItemArray[10].ToString();//exe_ret wise summary
                }
            }
               
            heading = lblHeading.Text;
            lblFromDate.Text = ds_head.Tables[2].Rows[0].ItemArray[4].ToString();
            lblToDate.Text = ds_head.Tables[2].Rows[0].ItemArray[5].ToString();
            lblRunningDate.Text = ds_head.Tables[2].Rows[0].ItemArray[6].ToString();
            lbl_from = lblFromDate.Text;
            lbl_to = lblToDate.Text;
            lbl_run = lblRunningDate.Text;

           


            Run_Date = DateTime.Now.ToString();
            DateTime dt = Convert.ToDateTime(Run_Date.ToString());

            if (dateformat == "dd/mm/yyyy")
            {
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

            }
            else if (dateformat == "mm/dd/yyyy")
            {

                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else if (dateformat == "yyyy/mm/dd")
            {

                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);
            }
            lblDate.Text = from_date;
            lblTDate.Text = to_date;
            lblRdate.Text = Run_Date;
            Compname.Text = comp_name;
            if (!Page.IsPostBack)
            {
                btnprint.Attributes.Add("onclick", "javascript:window.print();");
                if (rptype != "0")
                {
                    if (destination == "0" || destination == "1" || destination == "4")
                    {
                  
                       onscreen1();
                    }
                }
            else
            {
                if (destination == "0" || destination == "1" || destination == "4")
                {
                   
                        onscreen();
                    
                }
                else if (destination == "4")
                {
                    excel();
                }
                else if (destination == "3")
                {
                    pdf();
                }
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

    public string decimal_fun(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal.IndexOf(".") > -1)
        {
            final_decimal = str_decimal;
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = str_decimal;
        }
        return final_decimal;


    }
    public string head_value_print(int s, int pagecount)
    {
        StringBuilder head = new StringBuilder();

       
        head.Append("<tr><td colspan='9' class='headingc' align='center' >" + comp_name + "</td></tr>");
        head.Append("<tr><td colspan='9' class='headingp' align='center' >" + heading + "</td></tr>");
        head.Append("<tr><td colspan='9' class='reporttext_ro' align='center' ><b>From Date: </b>" + from_date + "&nbsp;&nbsp;&nbsp;&nbsp;<b>To Date: </b>" + to_date + "</td></tr>");
       

        head.Append("<tr>");
        head.Append("<td colspan='9' class='reporttext_ro' align='right' ><b>Page  " + s + "  of  " + pagecount+"</b></td>");      
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='4' class='reporttext_ro' align='left' style='font-size:12px;'><b>Based on: </b>" + temp_baseon + "</td>");
        head.Append("<td colspan='2' class='reporttext_ro' align='left' style='font-size:12px;'><b>Printing Center: </b>" + temp_printcent + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='right' style='font-size:12px;'><b>Run Date: </b>" + Run_Date + "</td>");        
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='4' class='reporttext_ro' align='left' style='font-size:12px;'><b>Branch: </b>" + temp_branch + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='left' style='font-size:12px;'><b>Ditrict: </b>" + temp_district + "</td>");
        head.Append("<td colspan='2' class='reporttext_ro' align='left' style='font-size:12px;'><b>Taluka: </b>" + temp_taluka + "</td>");
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='4' class='reporttext_ro' align='left' style='font-size:12px;'><b>" + temp_baseon + ": </b>" + temp_agency_exe_ret + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='left' style='font-size:12px;'><b>RoDoc Status: </b>" + temp_rodocstatus + "</td>");
        head.Append("<td colspan='2' class='reporttext_ro' align='left' style='font-size:12px;'><b>Pay Mode: </b>" + temp_paymode + "</td>");
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='4' class='reporttext_ro' align='left' style='font-size:12px;'><b>Ad Type: </b>" + temp_adtyp + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='left' style='font-size:12px;'><b>Ad Category: </b>" + temp_adcat + "</td>");
        head.Append("<td colspan='2' class='reporttext_ro' align='left' style='font-size:12px;'><b>Paid/Unpaid: </b>" + temp_typname + "</td>");
        head.Append("</tr>");

       
        return head.ToString();
    }
    public string head_value()
    {
        StringBuilder head = new StringBuilder();


        head.Append("<tr><td colspan='16' class='headingc' align='center' >" + comp_name + "</td></tr>");
        head.Append("<tr><td colspan='16' class='headingp' align='center' >" + heading + "</td></tr>");
        head.Append("<tr><td colspan='16' class='reporttext_ro' align='center' ><b>From Date: </b>" + from_date + "&nbsp;&nbsp;&nbsp;&nbsp;<b>To Date: </b>" + to_date + "</td></tr>");
                     

        head.Append("<tr>");
        head.Append("<td colspan='5' class='reporttext_ro' align='left' style='font-size:12px;'><b>Based on: </b>" + temp_baseon + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='right' style='font-size:12px;'><b>Printing Center: </b>" + temp_printcent + "</td>");
        head.Append("<td colspan='8' class='reporttext_ro' align='right' style='font-size:12px;'><b>Run Date: </b>" + Run_Date + "</td>");
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='5' class='reporttext_ro' align='left' style='font-size:12px;'><b>Branch: </b>" + temp_branch + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='right' style='font-size:12px;'><b>Ditrict: </b>" + temp_district + "</td>");
        head.Append("<td colspan='8' class='reporttext_ro' align='right' style='font-size:12px;'><b>Taluka: </b>" + temp_taluka + "</td>");
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='5' class='reporttext_ro' align='left' style='font-size:12px;'><b>" + temp_baseon + ": </b>" + temp_agency_exe_ret + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='right' style='font-size:12px;'><b>RoDoc Status: </b>" + temp_rodocstatus + "</td>");
        head.Append("<td colspan='8' class='reporttext_ro' align='right' style='font-size:12px;'><b>Pay Mode: </b>" + temp_paymode + "</td>");
        head.Append("</tr>");

        head.Append("<tr>");
        head.Append("<td colspan='5' class='reporttext_ro' align='left' style='font-size:12px;'><b>Ad Type: </b>" + temp_adtyp + "</td>");
        head.Append("<td colspan='3' class='reporttext_ro' align='right' style='font-size:12px;'><b>Ad Category: </b>" + temp_adcat + "</td>");
        head.Append("<td colspan='8' class='reporttext_ro' align='right' style='font-size:12px;'><b>Paid/Unpaid: </b>" + temp_typname + "</td>");
        head.Append("</tr>");


        return head.ToString();
    }
    private void onscreen()
    {
        if (det_summ == "1")
        {
//            string tbl = "";
            StringBuilder tbl = new StringBuilder();
             
            tbl.Append("<table cellspacing='0px' cellpadding='0px' border='0' width='100%'>");
            tbl.Append(head_value());
            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new'>SNo.</td>");
            tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Id</td>");
            if (age_exeret == "1")
            {
                tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
                tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive/</br>Retainer</td>");
            }
            else if (age_exeret == "2")
            {
                tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive</td>");
                tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
            }
            else
            {
                tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Retainer</td>");
                tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
            }
            tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Client</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ad Cat</td>");
            tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>RO. No.</td>");
            tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>RO.</br>Status</td>");

            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Page No.</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Size</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Rate</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ag. Comm%</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Hue</td>");

            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Amt</td>");
            tbl.Append( "</tr>");

            int sno = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sno = sno + 1;

                tbl.Append( "<tr>");
                tbl.Append( "<td  class='rep_data'>" + sno + "</td>");
                tbl.Append( "<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() + "</td>");
                if (age_exeret == "1")
                {
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");
                    tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");
                }
                else
                {
                    tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");

                }
                tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["CLIENT"].ToString() + "</td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["RONO"].ToString() + "</td>");
                tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ROSTATUS"].ToString() + "</td>");

                tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Page_no"].ToString() + "</td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["total_size"].ToString() + "</td>");
                tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agrred_rate"].ToString() + "</td>");
                tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["agency_comm"].ToString() + "</td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["color_code"].ToString() + "</td>");


                tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[0].Rows[i]["BILLAMT"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() != "")
                {
                    tot_buss = tot_buss + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());


                }
                tbl.Append( "</tr>");
               // rptDiv.InnerHtml += tbl;
               // tbl = "";
            }
            tbl.Append( "<tr>");
            tbl.Append( "<td colspan='13'  class='middle31new' align='left'>Total</td>");
            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_buss.ToString()) + "</td>");
            tbl.Append( "</tr>");

            tbl.Append( "</table>");
            rptDiv.Visible = true;
            rptDiv.InnerHtml = tbl.ToString();
        }
        else
        {
           // string tbl = "";
            StringBuilder tbl = new StringBuilder();

            tbl.Append(  "<table cellspacing='0px' cellpadding='0px' border='0' width='100%'>");
            tbl.Append(head_value());
            tbl.Append(  "<tr>");
            tbl.Append(  "<td  class='middle31new'>SNo.</td>");
            if (age_exeret == "1")
            {
                tbl.Append(  "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
                
            }
            else if (age_exeret == "2")
            {
                tbl.Append(  "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive</td>");
               
            }
            else
            {
                tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Retainer</td>");

            }
            tbl.Append(  "<td align='left' style=\"padding-left:4px\"  class='middle31new'>District</td>");
            tbl.Append(  "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Branch</td>");
            //tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ad Cat</td>");
            tbl.Append(  "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Original</td>");
            tbl.Append(  "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Xerox</td>");
            tbl.Append(  "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Fax</td>");
            tbl.Append(  "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Remaining</td>");
            tbl.Append(  "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Total</td>");
            tbl.Append(  "</tr>");

            int sno = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sno = sno + 1;

                tbl.Append( "<tr>");
                tbl.Append( "<td  class='rep_data'>" + sno + "</td>");
                if (age_exeret == "1")
                {
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");
                }
                else
                {
                    tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");
                   
                }
                tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["DISTRICT"].ToString() + "</td>");
                tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BRANCH"].ToString() + "</td>");

                //tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");

                tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ORIGINAL"].ToString() + "</td>");
                if (ds.Tables[0].Rows[i]["ORIGINAL"].ToString() != "")
                {
                    tot_org = tot_org + Convert.ToInt64(ds.Tables[0].Rows[i]["ORIGINAL"].ToString());
                    tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["ORIGINAL"].ToString());
                }

               tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["XEROX"].ToString() + "</td>");
               if (ds.Tables[0].Rows[i]["XEROX"].ToString() != "")
               {
                   tot_xerox = tot_xerox + Convert.ToInt64(ds.Tables[0].Rows[i]["XEROX"].ToString());
                   tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["XEROX"].ToString());
               }

               tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["FAX"].ToString() + "</td>");
               if (ds.Tables[0].Rows[i]["FAX"].ToString() != "")
               {
                   tot_fax = tot_fax + Convert.ToInt64(ds.Tables[0].Rows[i]["FAX"].ToString());
                   tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["FAX"].ToString());
               }

                    tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["REMAIN"].ToString() + "</td>");
                    if (ds.Tables[0].Rows[i]["REMAIN"].ToString() != "")
                    {
                        tot_remain = tot_remain + Convert.ToInt64(ds.Tables[0].Rows[i]["REMAIN"].ToString());
                        tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["REMAIN"].ToString());
                    }
                    tot_grandtot = tot_grandtot + tot_total;
                tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + tot_total.ToString() + "</td>");
                   
                tbl.Append( "</tr>");
               // rptDiv.InnerHtml += tbl;
               // tbl = "";
                
                tot_total = 0;
            }
            tbl.Append( "<tr>");//<td  class='middle31new'>SNo.</td>";
            tbl.Append( "<td colspan='4'  class='middle31new' align='left'>Total</td>");
            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_org.ToString() + "</td>");
            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_xerox.ToString() + "</td>");
            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_fax.ToString() + "</td>");
            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_remain.ToString() + "</td>");
            tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_grandtot.ToString() + "</td>");
            tbl.Append( "</tr>");

            tbl.Append( "</table>");
            rptDiv.Visible = true;
            rptDiv.InnerHtml = tbl.ToString();
        }
    }

    /// <summary>
    /// /////////////////////////////new add per client
    /// </summary>
    private void onscreen1()
    {
        int j = 0;
            //            string tbl = "";
            StringBuilder tbl = new StringBuilder();

            tbl.Append("<table cellspacing='0px' cellpadding='0px' border='1' width='100%'>");
            tbl.Append(head_value());
            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new'>SNo.</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Id</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Publish Date</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive/</br>Retainer</td>");
           
           
            
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Client</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ad Cat</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>RO. No.</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>RO.</br>Status</td>");

            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Page No.</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Size</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Rate</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ag. Comm%</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Color</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Edition</td>");
            tbl.Append("<td align='center' style=\"padding-left:4px\"  class='middle31new'>Booking Amt</td>");
            tbl.Append("</tr>");

            int sno = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sno = sno + 1;
            if(rptype=="F")
            {
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() == ds.Tables[0].Rows[i - 1]["BOOKING_ID"].ToString())
                    {
                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data'>" + sno + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["publish_date"].ToString() + "</td>");

                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");

                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["CLIENT"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["RONO"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ro_status"].ToString() + "</td>");

                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Page_no"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["total_size"].ToString() + "</td>");
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agrred_rate"].ToString() + "</td>");
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["agency_comm"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["color_code"].ToString() + "</td>");

                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Package_code"].ToString() + "</td>");
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BILLAMT"].ToString() + "</td>");
                        //if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() != "")
                        //{
                        //    tot_buss = tot_buss + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());


                        //}
                        tbl.Append("</tr>");
                    }
                    else
                    {
                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data'>" + sno + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["publish_date"].ToString() + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");

                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["CLIENT"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["RONO"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ro_status"].ToString() + "</td>");

                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Page_no"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["total_size"].ToString() + "</td>");
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agrred_rate"].ToString() + "</td>");
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["agency_comm"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["color_code"].ToString() + "</td>");

                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Package_code"].ToString() + "</td>");

                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[1].Rows[j]["BILLAMT"].ToString()) + "</td>");
                            if (ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() == ds.Tables[1].Rows[j]["BOOKING_ID"].ToString())
                            {
                                
                                if (ds.Tables[1].Rows[j]["BILLAMT"].ToString() != "")
                                {
                                    tot_buss = tot_buss + Convert.ToDouble(ds.Tables[1].Rows[j]["BILLAMT"].ToString());


                                }
                                j++;
                            }
                       
                        tbl.Append("</tr>");
                    }
                    
                }
                else
                {
                    tbl.Append("<tr>");
                    tbl.Append("<td  class='rep_data'>" + sno + "</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() + "</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["publish_date"].ToString() + "</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");

                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["CLIENT"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["RONO"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ro_status"].ToString() + "</td>");

                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Page_no"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["total_size"].ToString() + "</td>");
                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agrred_rate"].ToString() + "</td>");
                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["agency_comm"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["color_code"].ToString() + "</td>");

                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Package_code"].ToString() + "</td>");
                        if (ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() == ds.Tables[1].Rows[j]["BOOKING_ID"].ToString())
                        {
                            tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[1].Rows[j]["BILLAMT"].ToString()) + "</td>");
                            if (ds.Tables[1].Rows[j]["BILLAMT"].ToString() != "")
                            {
                                tot_buss = tot_buss + Convert.ToDouble(ds.Tables[1].Rows[j]["BILLAMT"].ToString());


                            }
                            j++;
                        }
                    
                    //tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[1].Rows[i]["BILLAMT"].ToString()) + "</td>");
                    //if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() != "")
                    //{
                    //    tot_buss = tot_buss + Convert.ToDouble(ds.Tables[1].Rows[i]["BILLAMT"].ToString());


                    //}
                    tbl.Append("</tr>");
                }
            }
                else
                {
                    tbl.Append("<tr>");
                    tbl.Append("<td  class='rep_data'>" + sno + "</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BOOKING_ID"].ToString() + "</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["publish_date"].ToString() + "</td>");

                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["AGENCY"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");

                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["CLIENT"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["RONO"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ro_status"].ToString() + "</td>");

                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Page_no"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["total_size"].ToString() + "</td>");
                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agrred_rate"].ToString() + "</td>");
                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["agency_comm"].ToString() + "</td>");
                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["color_code"].ToString() + "</td>");

                    tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Package_code"].ToString() + "</td>");
                    tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BILLAMT"].ToString() + "</td>");
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() != "")
                    {
                        tot_buss = tot_buss + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());


                    }

                }
                // rptDiv.InnerHtml += tbl;
                // tbl = "";
            }
            tbl.Append("<tr>");
            tbl.Append("<td colspan='15'  class='middle31new' align='left'>Total</td>");
            tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_buss.ToString()) + "</td>");
            tbl.Append("</tr>");

            tbl.Append("</table>");
            rptDiv.Visible = true;
            rptDiv.InnerHtml = tbl.ToString();
            if (destination == "4")
            {
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                hw.WriteBreak();
                rptDiv.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        
        
    }

    /// <summary>
    /// /////////////////////////////
    /// </summary>
    private void pdf()
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        //btnprint.Attributes.Add("onclick", "javascript:window.print();");
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase("Page No. " + i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;
        document.Open();

        int NumColumns = 0;
        if (det_summ == "1")
            NumColumns = 9;
        else
            NumColumns = 9;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

       
        try
        {


            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(comp_name, font9));
            tbl.addCell(new Phrase(heading, font9));
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);

            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            tbl1.WidthPercentage = 100;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl2.addCell(new Phrase(lbl_from, font10));
            tbl2.addCell(new Phrase(from_date.ToString(), font11));
            tbl2.addCell(new Phrase(lbl_to, font10));
            tbl2.addCell(new Phrase(to_date.ToString(), font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));

            tbl2.addCell(new Phrase("Based on:", font10));
            tbl2.addCell(new Phrase(temp_baseon.ToString() , font11));
            tbl2.addCell(new Phrase("Printing Center:", font10));
            tbl2.addCell(new Phrase(temp_printcent.ToString(), font11));
            tbl2.addCell(new Phrase(lbl_run, font10));
            tbl2.addCell(new Phrase(Run_Date.ToString(), font11));

            tbl2.addCell(new Phrase("Branch:", font10));
            tbl2.addCell(new Phrase(temp_branch.ToString(), font11));
            tbl2.addCell(new Phrase("Ditrict:" , font10));
            tbl2.addCell(new Phrase(temp_district.ToString(), font11));
            tbl2.addCell(new Phrase("Taluka: ", font10));
            tbl2.addCell(new Phrase(temp_taluka.ToString(), font11));

            tbl2.addCell(new Phrase(temp_baseon.ToString(), font10));
            tbl2.addCell(new Phrase(temp_agency_exe_ret.ToString(), font11));
            tbl2.addCell(new Phrase("RoDoc Status:", font10));
            tbl2.addCell(new Phrase(temp_rodocstatus.ToString(), font11));
            tbl2.addCell(new Phrase("Pay Mode:", font10));
            tbl2.addCell(new Phrase(temp_paymode.ToString(), font11));

            tbl2.addCell(new Phrase("Ad Type:", font10));
            tbl2.addCell(new Phrase(temp_adtyp.ToString(), font11));
            tbl2.addCell(new Phrase("Ad Category:", font10));
            tbl2.addCell(new Phrase(temp_adcat.ToString(), font11));
            tbl2.addCell(new Phrase("Paid/Unpaid:", font10));
            tbl2.addCell(new Phrase(temp_typname.ToString(), font11));


            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            PdfPTable tbl91 = new PdfPTable(11);
            tbl91.DefaultCell.BorderWidth = 0;
            tbl91.WidthPercentage = 100;
            tbl91.DefaultCell.Colspan = 11;
            tbl91.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl91);

            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
           
            datatable.addCell(new Phrase("SNo.", font10));
            if (det_summ == "1")
            {
                datatable.addCell(new Phrase("Booking Id", font10));
                if (age_exeret == "1")
                {
                    datatable.addCell(new Phrase("Agency", font10));
                    datatable.addCell(new Phrase("Executive/Retainer", font10));
                }
                else if (age_exeret == "2")
                {
                    datatable.addCell(new Phrase("Executive", font10));
                    datatable.addCell(new Phrase("Agency", font10));
                }
                else
                {
                    datatable.addCell(new Phrase("Retainer", font10));
                    datatable.addCell(new Phrase("Agency", font10));
                }
                datatable.addCell(new Phrase("Client", font10));
                datatable.addCell(new Phrase("Ad Cat", font10));
                datatable.addCell(new Phrase("RO. No.", font10));
                datatable.addCell(new Phrase("RO. Status", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase("Booking Amt", font10));
            }
            else
            {

               
                if (age_exeret == "1")
                {
                    datatable.addCell(new Phrase("Agency", font10));
                    
                }
                else if (age_exeret == "2")
                {
                    datatable.addCell(new Phrase("Executive", font10));
                    
                }
                else
                {
                    datatable.addCell(new Phrase("Retainer", font10));

                }
                datatable.addCell(new Phrase("District", font10));
                datatable.addCell(new Phrase("Branch", font10));
                //datatable.addCell(new Phrase("Ad Cat", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase("Original", font10));
                datatable.addCell(new Phrase("Xerox", font10));
                datatable.addCell(new Phrase("Fax", font10));
                datatable.addCell(new Phrase("Remaining", font10));
                datatable.addCell(new Phrase("Total", font10));


                
            }

            datatable.HeaderRows = 1;

            //Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());
            //document.Add(p2);

            datatable.DefaultCell.Colspan = 11;
            datatable.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            int row = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {

                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                if (det_summ == "1")
                {
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BOOKING_ID"].ToString(), font11));
                    if (age_exeret == "1")
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AGENCY"].ToString(), font11));
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["EXE_RET"].ToString(), font11));
                    }
                    else
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["EXE_RET"].ToString(), font11));
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AGENCY"].ToString(), font11));
                    }


                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CLIENT"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ad_Cat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RONO"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ROSTATUS"].ToString(), font11));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(decimal_fun(ds.Tables[0].Rows[row]["BILLAMT"].ToString()), font11));

                    if (ds.Tables[0].Rows[row]["BILLAMT"].ToString() != "")
                    {
                        tot_buss = tot_buss + Convert.ToDouble(ds.Tables[0].Rows[row]["BILLAMT"].ToString());


                    }
                }
                else
                {
                    
                    if (age_exeret == "1")
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AGENCY"].ToString(), font11));
                      
                    }
                    else
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["EXE_RET"].ToString(), font11));
                        
                    }


                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["DISTRICT"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BRANCH"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ad_Cat"].ToString(), font11));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ORIGINAL"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["XEROX"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["FAX"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["REMAIN"].ToString(), font11));

                    if (ds.Tables[0].Rows[row]["ORIGINAL"].ToString() != "")
                    {
                        tot_org = tot_org + Convert.ToInt64(ds.Tables[0].Rows[row]["ORIGINAL"].ToString());
                        tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[row]["ORIGINAL"].ToString());
                    }

                    if (ds.Tables[0].Rows[row]["XEROX"].ToString() != "")
                    {
                        tot_xerox = tot_xerox + Convert.ToInt64(ds.Tables[0].Rows[row]["XEROX"].ToString());
                        tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[row]["XEROX"].ToString());
                    }

                    if (ds.Tables[0].Rows[row]["FAX"].ToString() != "")
                    {
                        tot_fax = tot_fax + Convert.ToInt64(ds.Tables[0].Rows[row]["FAX"].ToString());
                        tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[row]["FAX"].ToString());
                    }

                    if (ds.Tables[0].Rows[row]["REMAIN"].ToString() != "")
                    {
                        tot_remain = tot_remain + Convert.ToInt64(ds.Tables[0].Rows[row]["REMAIN"].ToString());
                        tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[row]["REMAIN"].ToString());
                    }
                    tot_grandtot = tot_grandtot + tot_total;
                    datatable.addCell(new Phrase(tot_total.ToString(), font11));
                    tot_total = 0;
                }

                row++;

            }
            datatable.DefaultCell.Colspan = 11;
            datatable.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
           // document.Add(datatable);
           // Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
          //  document.Add(p3);
            if (det_summ == "1")
            {
           // PdfPTable tbltotal = new PdfPTable(8);
           // tbltotal.DefaultCell.BorderWidth = 0;
           // tbltotal.WidthPercentage = 100;
          //  tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
          //  tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
              
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("Total", font10));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase("", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(tot_buss.ToString(), font10));
                document.Add(datatable);
            }
           

            else
            {
               // PdfPTable tbltotal = new PdfPTable(7);
               // tbltotal.DefaultCell.BorderWidth = 0;
              //  tbltotal.WidthPercentage = 100;
              //  tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
              //  tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("Total", font10));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase(" ", font11));
                datatable.addCell(new Phrase(" ", font11));
               // datatable.addCell(new Phrase(" ", font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(tot_org.ToString(), font10));
                datatable.addCell(new Phrase(tot_xerox.ToString(), font10));
                datatable.addCell(new Phrase(tot_fax.ToString(), font10));
                datatable.addCell(new Phrase(tot_remain.ToString(), font10));
                datatable.addCell(new Phrase(tot_grandtot.ToString(), font10));
                
                document.Add(datatable);
            }


            PdfPTable tbl911 = new PdfPTable(11);
            tbl911.DefaultCell.BorderWidth = 0;
            tbl911.WidthPercentage = 100;
            tbl911.DefaultCell.Colspan = 11;
            tbl911.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl911);

            document.Close();

            Response.Redirect(pdfName);



        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }

    private void excel()
    {

        
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        if (chk_excel == "1")
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        }
        else
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        }

        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = "SNo.";
        DataGrid1.Columns.Add(nameColumn0);

        if (det_summ == "1")
        {

            BoundColumn nameColumn = new BoundColumn();
            nameColumn.HeaderText = "Booking Id";
            nameColumn.DataField = "BOOKING_ID";
            name1 = name1 + "," + "Booking Id";
            name2 = name2 + "," + "BOOKING_ID";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn);

            BoundColumn nameColumn01 = new BoundColumn();
            nameColumn01.HeaderText = "Publish Date";
            nameColumn01.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            nameColumn01.DataField = "Publish_Date";
            name1 = name1 + "," + "Publish Date";
            name2 = name2 + "," + "Publish_Date";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn01);

            if (age_exeret == "1")
            {
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Agency";
                nameColumn1.DataField = "AGENCY";

                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "AGENCY";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Executive/Retainer";
                nameColumn2.DataField = "EXE_RET";

                name1 = name1 + "," + "Executive/Retainer";
                name2 = name2 + "," + "EXE_RET";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);
            }
            else if (age_exeret == "2")
            {
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Executive";
                nameColumn1.DataField = "EXE_RET";

                name1 = name1 + "," + "Executive";
                name2 = name2 + "," + "EXE_RET";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Agency";
                nameColumn2.DataField = "AGENCY";

                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "AGENCY";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);
            }
            else
            {
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Retainer";
                nameColumn1.DataField = "EXE_RET";

                name1 = name1 + "," + "Retainer";
                name2 = name2 + "," + "EXE_RET";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Agency";
                nameColumn2.DataField = "AGENCY";

                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "AGENCY";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);
            }

            BoundColumn nameColumn4 = new BoundColumn();
            nameColumn4.HeaderText = "Client";
            nameColumn4.DataField = "CLIENT";

            name1 = name1 + "," + "Client";
            name2 = name2 + "," + "CLIENT";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn4);

            BoundColumn nameColumn41 = new BoundColumn();
            nameColumn41.HeaderText = "Ad Cat";
            nameColumn41.DataField = "Ad_Cat";

            name1 = name1 + "," + "Ad Cat";
            name2 = name2 + "," + "Ad_Cat";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn41);


            BoundColumn nameColumn6 = new BoundColumn();
            nameColumn6.HeaderText = "RO. No.";
            nameColumn6.DataField = "RONO";

            name1 = name1 + "," + "RO. No.";
            name2 = name2 + "," + "RONO";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn6);

            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "RO. Status";
            nameColumn7.DataField = "ROSTATUS";

            name1 = name1 + "," + "RO. Status";
            name2 = name2 + "," + "ROSTATUS";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);


            

            BoundColumn nameColumn9 = new BoundColumn();
            nameColumn9.HeaderText = "Booking Amt";
            nameColumn9.DataField = "BILLAMT";

            name1 = name1 + "," + "Booking Amt";
            name2 = name2 + "," + "BILLAMT";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn9);

            BoundColumn nameColumn71 = new BoundColumn();
            nameColumn71.HeaderText = "RO.COMMENT";
            nameColumn71.DataField = "RO_COMMENT";

            name1 = name1 + "," + "RO.COMMENT";
            name2 = name2 + "," + "RO_COMMENT";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn71);


            BoundColumn nameColumn72 = new BoundColumn();
            nameColumn72.HeaderText = "BRANCH";
            nameColumn72.DataField = "BRANCH";

            name1 = name1 + "," + "BRANCH";
            name2 = name2 + "," + "BRANCH";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn72);

            BoundColumn nameColumn73 = new BoundColumn();
            nameColumn73.HeaderText = "PAY_MODE_NAME";
            nameColumn73.DataField = "PAY_MODE_NAME";

            name1 = name1 + "," + "PAY_MODE_NAME";
            name2 = name2 + "," + "PAY_MODE_NAME";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn73);







            DataGrid1.DataSource = ds;
                 if (chk_excel == "1")
                {

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    DataGrid1.ShowHeader = true;
                    DataGrid1.ShowFooter = true;
                    DataGrid1.DataBind();

                    hw.Write("<p <table border=\"1\"><tr><td colspan=\"13\"align=\"center\"><b>" + comp_name + "</b></td></tr>");

                    hw.Write("<p <tr><td colspan=\"13\"align=\"center\"><b>" + heading + "</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"13\"align=\"center\"><b>" + "From Date:" + from_date + "</b><b> " + "To Date:" + to_date + " </b></td></tr>");



                    hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + "Based on:" + temp_baseon + "</b></td><td colspan=\"4\"align=\"left\"><b>" + "Printing Center:" + temp_printcent + "</b></td><td colspan=\"4\"align=\"right\"><b>" + "Run Date:" + Run_Date + "</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + "Branch:" + temp_branch + "</b></td><td colspan=\"4\"align=\"left\"><b>" + "Ditrict:" + temp_district + "</b></td><td colspan=\"4\"align=\"right\"><b>" + "Taluka:" + temp_taluka + "</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + temp_baseon + ":</b>" + temp_typname + "</b></td><td colspan=\"4\"align=\"left\"><b>" + "RoDoc Status::" + temp_rodocstatus + "</b></td><td colspan=\"4\"align=\"right\"><b>" + "Pay Mode:" + temp_paymode + "</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + "Ad Type:" + temp_adtyp + "</b></td><td colspan=\"4\"align=\"left\"><b>" + "Ad Category:" + temp_adcat + "</b></td><td colspan=\"4\"align=\"right\"><b>" + "Paid/Unpaid::" + temp_typname + "</b></td></tr>");

                    //hw.Write("<p align=\"left\"><b>" + comp_name + "</b>");
                    //hw.Write("<p align=\"left\"><b>From Date:</b>" + from_date + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>To Date:</b>" + to_date);
                    // hw.Write("<p align=\"left\"><b>Run Date:</b>" + Run_Date + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>" + heading + "<b>");
                    hw.WriteBreak();
                    DataGrid1.RenderControl(hw);

                    Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2' align=\"left\"><b>Total:</b></td><td align=\"right\" colspan=\"8\"><b>" + tot_buss + "</b></td></tr></table>"));
                }
                else
                {

                    string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                    string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                    string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                    string[][] colProperties ={ names, captions, formats };

                    QueryToCSV(ds, colProperties);
                }
        }
        else
        {
            

            if (age_exeret == "1")
            {
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Agency";
                nameColumn1.DataField = "AGENCY";

                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "AGENCY";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                
            }
            else if (age_exeret == "2")
            {
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Executive";
                nameColumn1.DataField = "EXE_RET";

                name1 = name1 + "," + "Executive";
                name2 = name2 + "," + "EXE_RET";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

               
            }
            else
            {
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Retainer";
                nameColumn1.DataField = "EXE_RET";

                name1 = name1 + "," + "Retainer";
                name2 = name2 + "," + "EXE_RET";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);


            }

            BoundColumn nameColumn4 = new BoundColumn();
            nameColumn4.HeaderText = "District";
            nameColumn4.DataField = "DISTRICT";

            name1 = name1 + "," + "District";
            name2 = name2 + "," + "DISTRICT";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn4);



            BoundColumn nameColumn6 = new BoundColumn();
            nameColumn6.HeaderText = "Branch";
            nameColumn6.DataField = "BRANCH";

            name1 = name1 + "," + "Branch";
            name2 = name2 + "," + "BRANCH";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn6);

            //BoundColumn nameColumn61 = new BoundColumn();
            //nameColumn61.HeaderText = "Ad Cat";
            //nameColumn61.DataField = "Ad_Cat";

            //name1 = name1 + "," + "Ad Cat";
            //name2 = name2 + "," + "Ad_Cat";
            //name3 = name3 + "," + "G";
            //DataGrid1.Columns.Add(nameColumn61);

            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "Original";
            nameColumn7.DataField = "ORIGINAL";

            name1 = name1 + "," + "Original";
            name2 = name2 + "," + "ORIGINAL";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);

            BoundColumn nameColumn9 = new BoundColumn();
            nameColumn9.HeaderText = "Xerox";
            nameColumn9.DataField = "XEROX";

            name1 = name1 + "," + "Xerox";
            name2 = name2 + "," + "XEROX";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn9);

            BoundColumn nameColumn10 = new BoundColumn();
            nameColumn10.HeaderText = "Fax";
            nameColumn10.DataField = "FAX";

            name1 = name1 + "," + "Fax";
            name2 = name2 + "," + "FAX";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn10);

            BoundColumn nameColumn11 = new BoundColumn();
            nameColumn11.HeaderText = "Remaining";
            nameColumn11.DataField = "REMAIN";

            name1 = name1 + "," + "Remaining";
            name2 = name2 + "," + "REMAIN";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn11);

            BoundColumn nameColumn12 = new BoundColumn();
            nameColumn12.HeaderText = "Total";
            DataGrid1.Columns.Add(nameColumn12);

            DataGrid1.DataSource = ds;
            if (chk_excel == "1")
            {

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                DataGrid1.ShowHeader = true;
                DataGrid1.ShowFooter = true;
                DataGrid1.DataBind();
                 hw.Write("<p <table border=\"1\"><tr><td colspan=\"9\"align=\"center\"><b>" + comp_name + "</b></td></tr>");

                    hw.Write("<p <tr><td colspan=\"9\"align=\"center\"><b>" + heading + "</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "From Date:" + from_date + "</b></td><td colspan=\"3\"align=\"center\"><b>" + "To Date:" + to_date + "</b></td><td colspan=\"3\"align=\"right\"><b>" + "Run Date:" + Run_Date + "</b></td></tr>");
                
                //hw.Write("<p align=\"left\"><b>" + comp_name + "</b>");
               // hw.Write("<p align=\"left\"><b>From Date:</b>" + from_date + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>To Date:</b>" + to_date );
               // hw.Write("<p align=\"left\"><b>Run Date:</b>" + Run_Date + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>" + heading + "</b>");
                hw.WriteBreak();
                DataGrid1.RenderControl(hw);

                Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='4' align=\"left\"><b>Total</b></td><td align=\"right\" ><b>" + tot_org + "</b></td><td align=\"right\" ><b>" + tot_xerox + "</b></td><td align=\"right\" ><b>" + tot_fax + "</b></td><td align=\"right\" ><b>" + tot_remain + "</b></td><td align=\"right\" ><b>" + tot_grandtot + "</b></td></tr></table>"));
            }
            else
            {

                string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                string[][] colProperties ={ names, captions, formats };

                QueryToCSV(ds, colProperties);
            }
        }

       

        Response.Flush();
        Response.End();


    }
    private void QueryToCSV(DataSet dr, string[][] colProperties)
    {
        if (colProperties.Length > 0)
        {
            int counter;
            Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
            for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
            {
                counter = 0;
                Response.Write("\"");
                foreach (String column in colProperties[0])
                {
                    //dr.Tables[0].Rows[i].
                    Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                    if (counter < colProperties[0].Length - 1)
                    {
                        Response.Write("\",\"");
                    }
                    counter += 1;
                }
                Response.Write("\"\n");
            }
            //dr.Close();
            //tw.Close();
        }
    }
    private int getcolindex(DataSet ds, string col)
    {
        int i;
        for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
        {
            if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
            {
                goto td5;

            }
        }
    td5:
        return i;

    }
    

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "SNo.") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }




        if (det_summ == "1")
        {
            string check = e.Item.Cells[9].Text;
            if (check != "Booking Amt")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[9].Text;
                    tot_buss = tot_buss + Convert.ToDouble(grossamt);

                }
            }
        }
        else
        {
            string check = e.Item.Cells[4].Text;
            string check1 = e.Item.Cells[5].Text;
            string check2 = e.Item.Cells[6].Text;
            string check3 = e.Item.Cells[7].Text;
            if (check != "Original")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[4].Text;
                    tot_org = tot_org + Convert.ToInt64(grossamt);
                    tot_total = tot_total + Convert.ToInt64(grossamt);

                }
            }
            if (check1 != "Xerox")
            {
                if (check1 != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[5].Text;
                    tot_xerox = tot_xerox + Convert.ToInt64(grossamt);
                    tot_total = tot_total + Convert.ToInt64(grossamt);

                }
            }
            if (check2 != "Fax")
            {
                if (check2 != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[6].Text;
                    tot_fax = tot_fax + Convert.ToInt64(grossamt);
                    tot_total = tot_total + Convert.ToInt64(grossamt);
                }
            }
            if (check3 != "Remaining")
            {
                if (check3 != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[7].Text;
                    tot_remain = tot_remain + Convert.ToInt64(grossamt);
                    tot_total = tot_total + Convert.ToInt64(grossamt);
                }
            }
            tot_grandtot = tot_grandtot + tot_total;
            string tot1 = e.Item.Cells[7].Text;
           

            if ((tot1 != "Total")  && (tot1 != "&nbsp;"))
            {
                e.Item.Cells[8].Text = Convert.ToString(tot_total);
            }
            tot_total = 0;
        }




    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        btnprint.Visible = false;
        if (rptype == "0")
        {
            onscreen_print();
        }
        else
        {
            onscreen1();
        }
    }

    public void onscreen_print()
    {
        rptDiv.InnerHtml = "";
       
         if (ds.Tables[0].Rows.Count > 0)
        {
            if (det_summ == "1")
            {
                int cont = ds.Tables[0].Rows.Count;

                int ct = 0;
                int fr = maxlimit;
                int rcount = ds.Tables[0].Rows.Count;
                int pagec = rcount % maxlimit;
                int pagecount = rcount / maxlimit;
                if (pagec > 0)
                    pagecount = pagecount + 1;

               // string tbl = "";
                StringBuilder tbl = new StringBuilder();
           //     if (browser.Browser == "IE")
            //    tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' >");
               // tbl.Append(head_value_print());
                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    if (browser.Browser == "Firefox")
                    {
                        tbl.Append("</table></P>");
                        if (p == pagecount || p == 0)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                         if ((ver == 7.0) || (ver == 8.0) || (ver == 9.0) || (ver == 10) || (ver == 11))
                        {
                            tbl.Append("</table></P>");
                            if (p == pagecount || p==0)
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                        else if (ver == 6.0)
                        {
                            tbl.Append("</table>");
                            if (p == pagecount - 1 || p == 0)
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                        }
                    }
                    if (p == 0)
                    {
                        tbl.Append(head_value_print(s, pagecount));
                    }
                    else
                    {
                        tbl.Append("<tr valign='top'>");
                        tbl.Append("<td class='middle111' align='right' colspan='9'>" + "Page  " + s + "  of  " + pagecount);
                        tbl.Append("</td></tr>");
                    }

                 


                    tbl.Append( "<tr>");
                    tbl.Append( "<td  class='middle31new'>SNo.</td>");
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Id</td>");
                    if (age_exeret == "1")
                    {
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive/</br>Retainer</td>");
                    }
                    else if (age_exeret == "2")
                    {
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive</td>");
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
                    }
                    else
                    {
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Retainer</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
                    }
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Client</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ad Cat</td>");
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>RO. No.</td>");
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>RO.</br>Status</td>");
                    tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Amt</td>");
                    tbl.Append( "</tr>");

                    for (int i = ct; i < ds.Tables[0].Rows.Count && i < fr; i++)
                    {

                        a = i;
                        a = a + 1;

                        tbl.Append( "<tr>");
                        tbl.Append( "<td  class='rep_data'>" + a.ToString() + "</td>");
                        string bookid1 = "";
                        string rrr1 = ds.Tables[0].Rows[i]["BOOKING_ID"].ToString();
                        if (rrr1.Length >= 12)
                        {
                            bookid1 = rrr1.Substring(0, 12);
                            if (rrr1.Length - 12 < 12)
                                bookid1 += "</br>" + rrr1.Substring(12, rrr1.Length - 12);
                            else
                                bookid1 += "</br>" + rrr1.Substring(12, 12);
                        }
                        else
                            bookid1 = rrr1;
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + bookid1 + "</td>");

                        string agency1 = "";
                        string rrr = ds.Tables[0].Rows[i]["CLIENT"].ToString();
                        if (rrr.Length >= 20)
                        {
                            agency1 = rrr.Substring(0, 20);
                            //if (rrr.Length - 20 < 20)
                            //    agency1 += "</br>" + rrr.Substring(20, rrr.Length - 20);
                            //else
                            //    agency1 += "</br>" + rrr.Substring(20, 20);
                        }
                        else
                            agency1 = rrr;


                        if (age_exeret == "1")
                        {
                            tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + agency1 + "</td>");
                            tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");
                        }
                        else
                        {
                            tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");
                            tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + agency1 + "</td>");

                        }

                        string client1 = "";
                        string rrr2 = ds.Tables[0].Rows[i]["CLIENT"].ToString();
                        if (rrr2.Length >= 20)
                        {
                            client1 = rrr2.Substring(0, 20);
                            //if (rrr2.Length - 20 < 20)
                            //    client1 += "</br>" + rrr2.Substring(20, rrr2.Length - 20);
                            //else
                            //    client1 += "</br>" + rrr2.Substring(20, 20);
                        }
                        else
                            client1 = rrr2;
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + client1 + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                        tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["RONO"].ToString() + "</td>");
                        tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ROSTATUS"].ToString() + "</td>");
                        tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[0].Rows[i]["BILLAMT"].ToString()) + "</td>");
                        if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() != "")
                        {
                            tot_buss = tot_buss + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());


                        }
                        tbl.Append( "</tr>");
                       // rptDiv.InnerHtml += tbl;
                       // tbl = "";
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;
                }
                tbl.Append( "<tr>");//<td  class='middle31new'>SNo.</td>";
                tbl.Append( "<td colspan='8'  class='middle31new' align='left'>Total</td>");
                tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_buss.ToString()) + "</td>");
                tbl.Append( "</tr>");
                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");

                }
                else if (browser.Browser == "IE")
                {
                     if ((ver == 7.0) || (ver == 8.0) || (ver == 9.0) || (ver == 10) || (ver == 11))
                    {
                        tbl.Append("</table></P>");

                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table>");

                    }
                }  

              //  tbl.Append( "</table>");
                rptDiv.Visible = true;
                rptDiv.InnerHtml = tbl.ToString();
            }
            else
            {
                int cont = ds.Tables[0].Rows.Count;

                int ct = 0;
                int fr = maxlimit1;
                int rcount = ds.Tables[0].Rows.Count;
                int pagec = rcount % maxlimit1;
                int pagecount = rcount / maxlimit1;
                if (pagec > 0)
                    pagecount = pagecount + 1;

               // string tbl = "";
                StringBuilder  tbl=new StringBuilder();
                tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' >");
                //tbl.Append(head_value_print());
                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    if (browser.Browser == "Firefox")
                    {
                        tbl.Append("</table></P>");
                        if (p == pagecount - 1)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                         if ((ver == 7.0) || (ver == 8.0) || (ver == 9.0) || (ver == 10) || (ver == 11))
                        {
                            tbl.Append("</table></P>");
                            if (p == pagecount - 1)
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                        else if (ver == 6.0)
                        {
                            tbl.Append("</table>");
                            if (p == pagecount - 1)
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                        }
                    }  

                    //tbl.Append( "<tr valign='top'>");
                    //tbl.Append( "<td class='middle111' align='right' colspan='9'>" + "Page  " + s + "  of  " + pagecount);
                    //tbl.Append( "</td></tr>");

                    //tbl.Append("<tr>");
                    //tbl.Append("<td colspan='9' class='reporttext_ro' align='right'><b>Run Date:</b>" + Run_Date + "</td>");
                    //tbl.Append("</tr>");

                    if (p == 0)
                    {
                        tbl.Append(head_value_print(s, pagecount));
                    }
                    else
                    {
                        tbl.Append("<tr valign='top'>");
                        tbl.Append("<td class='middle111' align='right' colspan='9'>" + "Page  " + s + "  of  " + pagecount);
                        tbl.Append("</td></tr>");
                    }

                    tbl.Append( "<tr>");
                    tbl.Append( "<td  class='middle31new'>SNo.</td>");
                    if (age_exeret == "1")
                    {
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");

                    }
                    else if (age_exeret == "2")
                    {
                        tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Executive</td>");

                    }
                    else
                    {
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Retainer</td>");

                    }
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>District</td>");
                    tbl.Append( "<td align='left' style=\"padding-left:4px\"  class='middle31new'>Branch</td>");
                    //tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Ad Cat</td>");
                    tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Original</td>");
                    tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Xerox</td>");
                    tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Fax</td>");
                    tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Remaining</td>");
                    tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>Total</td>");
                    tbl.Append( "</tr>");
                    

                    for (int i = ct; i < ds.Tables[0].Rows.Count && i < fr; i++)
                    {

                        a = i;
                        a = a + 1;

                        tbl.Append( "<tr>");
                        tbl.Append( "<td  class='rep_data'>" + a.ToString() + "</td>");
                        string agency1 = "";
                        string rrr2 = ds.Tables[0].Rows[i]["AGENCY"].ToString();
                        if (rrr2.Length >= 25)
                        {
                            agency1 = rrr2.Substring(0, 25);
                            //if (rrr2.Length - 25 < 25)
                            //    agency1 += "</br>" + rrr2.Substring(25, rrr2.Length - 25);
                            //else
                            //    agency1 += "</br>" + rrr2.Substring(25, 25);
                        }
                        else
                            agency1 = rrr2;


                        if (age_exeret == "1")
                        {
                            tbl.Append( "<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + agency1 + "</td>");
                        }
                        else
                        {
                            tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["EXE_RET"].ToString() + "</td>");

                        }
                        tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["DISTRICT"].ToString() + "</td>");
                        tbl.Append( "<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["BRANCH"].ToString() + "</td>");
                        //tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ad_Cat"].ToString() + "</td>");
                        tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["ORIGINAL"].ToString() + "</td>");
                        if (ds.Tables[0].Rows[i]["ORIGINAL"].ToString() != "")
                        {
                            tot_org = tot_org + Convert.ToInt64(ds.Tables[0].Rows[i]["ORIGINAL"].ToString());
                            tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["ORIGINAL"].ToString());
                        }

                            tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["XEROX"].ToString() + "</td>");
                            if (ds.Tables[0].Rows[i]["XEROX"].ToString() != "")
                            {
                                tot_xerox = tot_xerox + Convert.ToInt64(ds.Tables[0].Rows[i]["XEROX"].ToString());
                                tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["XEROX"].ToString());
                            }
                            tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["FAX"].ToString() + "</td>");
                            if (ds.Tables[0].Rows[i]["FAX"].ToString() != "")
                            {
                                tot_fax = tot_fax + Convert.ToInt64(ds.Tables[0].Rows[i]["FAX"].ToString());
                                tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["FAX"].ToString());
                            }

                        tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["REMAIN"].ToString() + "</td>");
                        if (ds.Tables[0].Rows[i]["REMAIN"].ToString() != "")
                        {
                            tot_remain = tot_remain + Convert.ToInt64(ds.Tables[0].Rows[i]["REMAIN"].ToString());
                            tot_total = tot_total + Convert.ToInt64(ds.Tables[0].Rows[i]["REMAIN"].ToString());
                        }
                        tot_grandtot = tot_grandtot + tot_total;
                        tbl.Append( "<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + tot_total.ToString() +"</td>");
                        tbl.Append( "</tr>");
                        //rptDiv.InnerHtml += tbl;
                        //tbl = "";
                        tot_total = 0;
                    }
                    ct = ct + maxlimit1;
                    fr = fr + maxlimit1;
                }
                tbl.Append( "<tr>");
                tbl.Append( "<td colspan='4'  class='middle31new' align='left'>Total</td>");
                tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_org.ToString() + "</td>");
                tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_xerox.ToString() + "</td>");
                tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_fax.ToString() + "</td>");
                tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_remain.ToString() + "</td>");
                tbl.Append( "<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + tot_grandtot.ToString() + "</td>");
                tbl.Append( "</tr>");
                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");

                }
                else if (browser.Browser == "IE")
                {
                     if ((ver == 7.0) || (ver == 8.0) || (ver == 9.0) || (ver == 10) || (ver == 11))
                    {
                        tbl.Append("</table></P>");

                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table>");

                    }
                }  

             //   tbl.Append( "</table>");
                rptDiv.Visible = true;
                rptDiv.InnerHtml = tbl.ToString();
            }
    }
    else
    {
        Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
    }
    }
}
