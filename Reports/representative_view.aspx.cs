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
using System.Data.OracleClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Web.UI.WebControls;

public partial class representative_view : System.Web.UI.Page
{
    double grouptotal_Govt = 0;
    double grouptotal_local = 0;
    double grouptotal_national = 0;
    int netsum = 0;
    double areanew = 0;
    double areasum = 0;
    string client = "";
    string pdfName1 = "";
    string agency = "";
    int sno = 1;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    double amtnew = 0;
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    double amtsum = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    double amt1 = 0;
    string package = "";
    string dateformate = "";
    string pubcent = "";
    string sortorder = "";
    string sortvalue = "";
    string value = "";
    string adtyp = "";
    string bill = "";
    string execut = "";
    string team = "";
    string cl = "";
    string ag = "";
    decimal payment = 0;
    string sortfield = "";
    string sorting = "", retainercode = "", retainername = "", rep = "", adtypename="",pubcentname="";
    double amtnet = 0;
    string val_chk = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    string districtname = "";
    string branchname = "";
    string district = "";
    string branch = "";
    protected void AspNetMessageBox(string strMessage)
    {
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(representative_view), "ShowAlert", strAlert, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
       
       
        ds = (DataSet)Session["repledger"];
        string prm = Session["prm_repledger"].ToString();
        string[] prm_Array = new string[37];
        prm_Array = prm.Split('~');


        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcent = prm_Array[7]; //Request.QueryString["pubcent"].ToString();
        publ = prm_Array[9]; //Request.QueryString["publication"].ToString();
        publication = prm_Array[11]; //Request.QueryString["publicationname"].ToString();
        adtyp = prm_Array[13]; //Request.QueryString["adtyp"].ToString();
        val_chk = prm_Array[15]; //Request.QueryString["value"].ToString();
        execut = prm_Array[17]; //Request.QueryString["execut"].Trim().ToString();
        team = prm_Array[19]; //Request.QueryString["team"].Trim().ToString();
        bill = prm_Array[21]; //Request.QueryString["bill"].Trim().ToString();
        cl = prm_Array[23]; //Request.QueryString["cl"].Trim().ToString();
        ag = prm_Array[25]; //Request.QueryString["ag"].Trim().ToString();
        retainercode = prm_Array[27]; //Request.QueryString["retainercode"].Trim().ToString();
        retainername = prm_Array[29]; //Request.QueryString["retainername"].Trim().ToString();
        rep = prm_Array[31]; //Request.QueryString["rep"].Trim().ToString();
        pubcentname = prm_Array[33]; //Request.QueryString["pubcentname"].Trim().ToString();
        adtypename = prm_Array[35]; //Request.QueryString["adtypename"].Trim().ToString();
        districtname = prm_Array[39];
        branchname = prm_Array[41];
        chk_excel = prm_Array[37];
        branch = prm_Array[43];
        district = prm_Array[46];

            Ajax.Utility.RegisterTypeForAjax(typeof(representative_view));

            if (publication == "--Select Revenue Center--")
            {
                lblpublication.Text = "All";
            }
            else
            {
                lblpublication.Text = publication.ToString();

            }
            if (adtyp == "0")
            {
                lbladtype.Text = "All";
            }
            else
            {
                lbladtype.Text = adtypename.ToString();

            }
            if (pubcent == "0")
            {
                lblpubcent.Text = "All";
            }
            else
            {
                lblpubcent.Text = pubcentname.ToString();

            }
            if (branch == "0"||branch=="")
            {
                lblbranch.Text = "All";
            }
            else
            {
                lblbranch.Text = branchname.ToString();

            }



            if (district == "0"|| district=="")
            {
                lbldistrict.Text = "All";
            }
            else
            {
                lbldistrict.Text = districtname.ToString();

            }
            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = day + "/" + month + "/" + year;

            }
            else
                if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = month + "/" + day + "/" + year;

                }
                else
                    if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                    {

                        DateTime dt = System.DateTime.Now;


                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        date = year + "/" + month + "/" + day;

                    }
            lbldate.Text = date.ToString();


            if (fromdt != "")
            {
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = fromdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datefrom1 = dd + "/" + mm + "/" + yy;

                }
                else
                {
                    DateTime dt = Convert.ToDateTime(fromdt.ToString());
                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = day + "/" + month + "/" + year;


                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = year + "/" + month + "/" + day;
                    }
                }
            }
            lblfrom.Text = datefrom1;
            if (dateto != "")
            {
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = dd + "/" + mm + "/" + yy;

                }
                else
                {
                    DateTime dt = Convert.ToDateTime(dateto.ToString());
                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = day + "/" + month + "/" + year;

                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = year + "/" + month + "/" + day;
                    }
                }
            }
            lblto.Text = dateto1;

            hiddendatefrom.Value = fromdt.ToString();
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            if (rep == "1")
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            else
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

            if (!Page.IsPostBack)
            {
                if (destination == "1" || destination == "0")
                {
                    onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());
                }
                else if (destination == "4")
                {
                    excel(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());

                }
                else
                    if (destination == "3")
                    {
                        pdf(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());
                    }
            }
        


    }

    public string chk_null(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal == "0.00" || str_decimal == "0.0" || str_decimal == "0")
        {
            final_decimal = "0.00";
        }
        else if (str_decimal.IndexOf(".") > -1)
        {

            double dd = System.Math.Round(Convert.ToDouble(str_decimal), 2);
            string[] oo = dd.ToString().Split('.');
            if (oo.Length == 1)
                final_decimal = dd.ToString() + ".00";
            else if (oo[1].Length == 1)
                final_decimal = dd.ToString() + "0";
            else
                final_decimal = dd.ToString();
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = "0.00";
        }
        return final_decimal;
    }



    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {
        string agn = "";
        string agnnew = "";
        int agamt = 0;
        int agamtnew = 0;
        string agsamt = "";
        string agsamtnew = "";
        string agnj = "";
        string agnnewj = "";
        int agamtj = 0;
        int agamtnewj = 0;
        int agamtnew1 = 0;

        sortfield = hiddencioid.Value.Trim();
        sorting = hiddenascdesc.Value.Trim();

        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.representative(pubcent, adtyp, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, execut, team, bill, cl, ag, retainercode,rep);
        //}
      

        //int brk = ds.Tables[1].Rows.Count;
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        if (hiddenascdesc.Value == "")
        {
            //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillNo</td><td class='middle31'>Ins.Date</td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='exec' class='middle3'   onclick=sorting('Executive',this.id)>Executive<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ro.No.</td><td class='middle31'>Ro.Date</td><td class='middle31'>Key</td><td class='middle31'>NetAmt</td><td id='tdcli~ad' class='middle3'   onclick=sorting('Adcat',this.id)>Adcat<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~ret' class='middle3'   onclick=sorting('Retainer',this.id)>Retainer<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td></tr>"); //<td class='middle31'>Remarks1</td><td class='middle31'>Remarks2</td>
            tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' align='left'>Agency</td><td class='middle3' align='left'>Edition</td><td class='middle3' align='left'>Publish</br>Date</td><td  class='middle3' align='left'>Package</td><td class='middle3' align='left'>Client</td><td class='middle3' align='left'>Ro.No.</td><td class='middle3' align='left'>Ro.Date</td><td class='middle3' align='left'>Key</td><td class='middle3' align='right'>NetAmt</td><td  class='middle3' align='left'>Adcategory</td></tr>"); //<td class='middle31'>Remarks1</td><td class='middle31'>Remarks2</td>
       
        }
       

        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int i1 = 1;

        int j = 0;
        int sn = 1;
        double amtnet1 = 0;
        double newamt = 0;
        double group_govt = 0;
        double group_local = 0;
        double group_national = 0;


        for (int i = 0; i <= cont - 1; i++)
        {

            if (rep == "1")
            {
                if (i == 0)
                {
                    
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data2' align='left'>Executive");
                    tbl = tbl + ("</td>");
                    tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[i]["Executive"]);
                    tbl = tbl + ("</td>");
                    tbl = tbl + ("</tr >");
                }
                else 
                {
                    if (ds.Tables[0].Rows[i]["Executive"].ToString() != ds.Tables[0].Rows[i - 1]["Executive"].ToString())
                    {
                        sn = 1;
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_data2' colspan='9' align='right'>Sub Total");
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("<td class='rep_data2' valign='center' align='right'>" + chk_null(amtnet1.ToString()));
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("</tr >");
                        amtnet1=0;

                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_data2' align='left'>Executive");
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[i]["Executive"]);
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("</tr >");
                    }
                }
            }
            else if (rep == "2")
            {
               

                if (i == 0)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data2' align='left'>Retainer");
                    tbl = tbl + ("</td>");
                    tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[i]["Retainer"]);
                    tbl = tbl + ("</td>");
                    tbl = tbl + ("</tr >");
                }
                else
                {
                    if (ds.Tables[0].Rows[i]["Retainer"].ToString() != ds.Tables[0].Rows[i - 1]["Retainer"].ToString())
                    {
                        sn = 1;
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_data2' align='left'>Sub Total");
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("<td class='rep_data2' colspan='9' align='right'>" + amtnet1);
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("</tr >");
                        amtnet1 = 0;


                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_data2' align='left'>Retainer");
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[i]["Retainer"]);
                        tbl = tbl + ("</td>");
                        tbl = tbl + ("</tr >");
                    }
                }
            }




            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (sn++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
          
            tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.Date"]+ "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
          
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ro.No."] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ro.Date"] + "</td>");


            tbl = tbl + ("<td class='rep_data' align='left'>");
            if (ds.Tables[0].Rows[i]["Key"].ToString() == "-Select Heading-")
            {
                tbl = tbl + ("" + "</td>");
            }
            else
            {
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");
            }

            tbl = tbl + ("<td class='rep_data' align='right'>");
            if (ds.Tables[0].Rows[i]["NetAmt"].ToString() != "")
            {
                amtnet1 = amtnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["NetAmt"].ToString());
                newamt = newamt + Convert.ToDouble(ds.Tables[0].Rows[i]["NetAmt"].ToString());
                
            }
           
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["NetAmt"].ToString()) + "</td>");
           
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Adcat"] + "</td>");

           
              if (ds.Tables[0].Rows[i]["FinalGRP"].ToString() == "GOVT.")
            {
               
                if (ds.Tables[0].Rows[i]["NetAmt"].ToString() != "")
                    group_govt = Convert.ToDouble(ds.Tables[0].Rows[i]["NetAmt"].ToString());
                grouptotal_Govt = grouptotal_Govt + group_govt;
            }
            if (ds.Tables[0].Rows[i]["FinalGRP"].ToString() == "NATIONAL")
            {
               
                if (ds.Tables[0].Rows[i]["NetAmt"].ToString() != "")
                    group_national = Convert.ToDouble(ds.Tables[0].Rows[i]["NetAmt"].ToString());
                grouptotal_national = grouptotal_national + group_national;
            }
            if (ds.Tables[0].Rows[i]["FinalGRP"].ToString() == "LOCAL")
            {
                
                if (ds.Tables[0].Rows[i]["NetAmt"].ToString() != "")
                    group_local = Convert.ToDouble(ds.Tables[0].Rows[i]["NetAmt"].ToString());
                grouptotal_local = grouptotal_local + group_local;

            }
            tbl = tbl + "</tr>";

            if (i == cont - 1)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data2' colspan='9' align='left'>Sub Total");
                tbl = tbl + ("</td>");
                tbl = tbl + ("<td class='rep_data2'  align='right'>" + chk_null(amtnet1.ToString()));
                tbl = tbl + ("</td>");
                tbl = tbl + ("</tr >");
            }

            tblgrid.InnerHtml += tbl;
            tbl = "";
        }


            tbl = tbl + ("<tr >");
            tbl = tbl + "<tr><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<tr><td class='rep_data2'>TotalAds.</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (cont.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data2'>");
            tbl = tbl + ("</td><td class='rep_data2'></td>");
            tbl = tbl + ("<td class='rep_data2'>");
            tbl = tbl + ("</td><td class='rep_data2'></td><td class='middle13'></td><td class='middle13'></td><td class='rep_data2'>TotalAmt</td>");
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + chk_null(newamt.ToString());
            tbl = tbl + "</tr>";

         
            tbl = tbl + ("</table>");
            tblgrid.InnerHtml += tbl;



        
    }





    private void excel(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {
        string tbl = "";
        string headname = "";
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        if (rep == "1")
            headname = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        else
            headname = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        //NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //ds = obj.representative(pubcent, adtyp, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, execut, team, bill, cl, ag, retainercode,rep);
        
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


        tbl = tbl + "<table width='100%' id='tab2' align='left' cellpadding='5' cellspacing='0' border='1'>";
        tbl = tbl + ("<tr><td class='middle4' colspan='4'></td><td class='middle4' colspan='3' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' colspan='4'></td><td class='middle4' colspan='3' ><b>"   + headname +  "</b></td></tr>");
        //tbl = tbl + ("<tr></tr><tr></tr><tr><td class='middle4' >AGENCY</td><td class='middle4' >" + lbagency.Text + "</td><td class='middle4' ></td><td class='middle4' >CLIENT</td><td class='middle4' align='left' >" + lbclient.Text + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >PAYMODE:</td><td class='middle4' >" + lbpaymode.Text + "</td></tr>");
        tbl = tbl + ("<tr><td class='middle4' >Date From:</td><td class='middle4' align='left' >" + fromdt + "</td><td class='middle4' colspan='2'></td><td class='middle4' >Date To:</td><td class='middle4' align='left' >" + dateto + "</td><td class='middle4' ></td><td class='middle4' ></td></td><td class='middle4' >Run Date:</td><td class='middle4' >" + date.ToString() + "</td></tr>");
        tbl = tbl + ("<tr><td class='middle4' >Rev Center:</td><td class='middle4' >" + publication.ToString() + "</td><td class='middle4' colspan='2'></td><td class='middle4' >Pub Center:</td><td class='middle4' align='left' >" + pubcentname.ToString() + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >Ad Type:</td><td class='middle4' >" + adtypename.ToString() + "</td></tr>");
        //   tbl = tbl + ("<tr><td class='middle4' >Rev Center:</td><td class='middle4' align='left' >" + lblpublication.Text + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >Pub Center:</td><td class='middle4' >" + lblpublicationcenter.Text + "</td><td class='middle4' ></td><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' >Branch</td><td class='middle4' >" + lblbranch.Text + "</td><td class='middle4' colspan='2'></td><td class='middle4' >District</td><td class='middle4' >" + lbldistrict.Text + "</td><td class='middle4' ></td><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr></tr></table>");

        tblgrid.InnerHtml += tbl;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            tblgrid.Visible = true;
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
        }





        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = "S.No";
        DataGrid1.Columns.Add(nameColumn0);

        if (rep == "1")
        {
            BoundColumn nameColumn = new BoundColumn();
            nameColumn.HeaderText = "Executive";
            nameColumn.DataField = "Executive";

            name1 = name1 + "," + "Executive";
            name2 = name2 + "," + "Executive";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn);
        }
        else
        {
            BoundColumn nameColumn = new BoundColumn();
            nameColumn.HeaderText = "Retainer";
            nameColumn.DataField = "Retainer";

            name1 = name1 + "," + "Retainer";
            name2 = name2 + "," + "Retainer";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn);
        }

        BoundColumn nameColumnag = new BoundColumn();
        nameColumnag.HeaderText = "Agency";
        nameColumnag.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumnag);



        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Edition";
        nameColumn1.DataField = "edition";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "edition";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);


        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Publish Date";
        nameColumn2.DataField = "Ins.Date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins.Date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn3 = new BoundColumn();
        nameColumn3.HeaderText = "Package";
        nameColumn3.DataField = "Package";

        name1 = name1 + "," + "Package";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn3);


        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Client";
        nameColumn4.DataField = "Client";

        name1 = name1 + "," + "Client";
        name2 = name2 + "," + "Client";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);

        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = "Ro.No.";
        nameColumn5.DataField = "Ro.No.";

        name1 = name1 + "," + "Ro.No.";
        name2 = name2 + "," + "Ro.No.";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn5);

        BoundColumn nameColumn05 = new BoundColumn();
        nameColumn05.HeaderText = "Ro.Date";
        nameColumn05.DataField = "Ro.Date";

        name1 = name1 + "," + "Ro.Date";
        name2 = name2 + "," + "Ro.Date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn05);


        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Key";
        nameColumn6.DataField = "Key";

        name1 = name1 + "," + "Key";
        name2 = name2 + "," + "Key";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "NetAmt";
        nameColumn7.DataField = "NetAmt";

        name1 = name1 + "," + "NetAmt";
        name2 = name2 + "," + "NetAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);


        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "Adcat";
        nameColumn9.DataField = "Adcat";

        name1 = name1 + "," + "Adcat";
        name2 = name2 + "," + "Adcat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);


        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "Branch";
        nameColumn10.DataField = "Branch_Name";

        name1 = name1 + "," + "Branch";
        name2 = name2 + "," + "Branch_Name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);


        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "District";
        nameColumn11.DataField = "District_Name";

        name1 = name1 + "," + "District";
        name2 = name2 + "," + "District_Name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);
       
          


        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            // hw.Write("<p align=\"center\">Representative Ledger");
            //string headname = "";
            //DataSet ds1 = new DataSet();
            //ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //if (rep == "1")
            //    headname = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            //else
            //    headname = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

            //hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>" + headname + "<b>");


            //hw.WriteBreak();

            DataGrid1.RenderControl(hw);

            int sno11 = sno - 1;

            Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"9\">TOTAL </td><td>" + amtnew + "</td></tr></table>"));
        }
        else
        {
            DataGrid1.DataSource = ds;


            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties ={ names, captions, formats };

            QueryToCSV(ds, colProperties);
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



    private void pdf(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;


        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

      
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        int NumColumns = 11;
       

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
            //    ds = obj.representative(pubcent, adtyp, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, execut, team, bill, cl, ag, retainercode, rep);
            //}
            string headname = "";
            


            int cont = ds.Tables[0].Rows.Count;
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            if (rep == "1")
                headname = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            else
                headname = ds1.Tables[0].Rows[0].ItemArray[10].ToString();


            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new Phrase(headname, font9));
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
            for (i = 0; i < 3; i++)
            {
                document.Add(tbl1);
            }
            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));

            tbl2.addCell(new Phrase("Rev Center", font10));
            tbl2.addCell(new Phrase(lblpublication.Text, font11));
            tbl2.addCell(new Phrase("Pub Center", font10));
            tbl2.addCell(new Phrase( lblpubcent.Text , font11));
            tbl2.addCell(new Phrase("Ad Type", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));

            tbl2.addCell(new Phrase("Branch", font10));
            tbl2.addCell(new Phrase(lblbranch.Text, font11));
            tbl2.addCell(new Phrase("District", font10));
            tbl2.addCell(new Phrase(lbldistrict.Text, font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));
            
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
          
            float[] headerwidths = { 12, 13, 15, 20, 16, 12, 12, 14, 18, 18, 17, 15, 14 }; // percentage
           // datatable.setWidths(headerwidths);

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[5].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[11].ToString(), font10));

            datatable.DefaultCell.Colspan = NumColumns;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            //  datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[12].ToString(), font10));
            
          //  datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

           string agn = "";
            string agnnew = "";
            int agamt = 0;
            int agamtnew = 0;
            string agsamt = "";
            string agsamtnew = "";
            string agnj = "";
            string agnnewj = "";
            int agamtj = 0;
            int agamtnewj = 0;
            int agamtnew1 = 0;
            double amtnet1 = 0;
           

             int row = 0;
            int i1 = 1;
            int sn = 1;
            double newamt = 0;

            while (row < ds.Tables[0].Rows.Count)
            {


                if (rep == "1")
                {
                    if (row == 0)
                    {
                        datatable.addCell(new Phrase("Executive", font10));

                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Executive"].ToString(), font10));
                        //datatable.DefaultCell.Colspan = 9;
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[row]["Executive"].ToString() != ds.Tables[0].Rows[row - 1]["Executive"].ToString())
                        {
                            sn = 1;
                            datatable.addCell(new Phrase("Sub Total", font10));
                            //datatable.DefaultCell.Colspan = 8;
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(amtnet1.ToString(), font10));
                            datatable.addCell(new Phrase("", font10));
                            
                            amtnet1 = 0;

                            datatable.addCell(new Phrase("Executive", font10));
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Executive"].ToString(), font10));
                            //datatable.DefaultCell.Colspan = 9;
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));

                          
                        }
                    }
                }
                else if (rep == "2")
                {


                    if (row == 0)
                    {
                        datatable.addCell(new Phrase("Retainer", font10));

                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Retainer"].ToString(), font10));
                        //
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                        datatable.addCell(new Phrase(" ", font10));
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[row]["Retainer"].ToString() != ds.Tables[0].Rows[row - 1]["Retainer"].ToString())
                        {
                            sn = 1;
                            datatable.addCell(new Phrase("Sub Total", font10));
                           // datatable.DefaultCell.Colspan = 8;
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));

                            datatable.addCell(new Phrase(amtnet1.ToString(), font10));
                            datatable.addCell(new Phrase("", font10));

                            amtnet1 = 0;

                            datatable.addCell(new Phrase("Retainer", font10));
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Retainer"].ToString(), font10));
                           // datatable.DefaultCell.Colspan = 9;
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));
                            datatable.addCell(new Phrase(" ", font10));


                        }
                    }
                }
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(sn++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
               // datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Executive"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ro.No."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ro.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(string.Format("{0:0.00}",ds.Tables[0].Rows[row]["NetAmt"]), font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                if (ds.Tables[0].Rows[row]["NetAmt"].ToString() != "")
                {
                    //amtnetn = Convert.ToInt32(ds.Tables[0].Rows[i]["amtnetn"].ToString());
                    amtnet1 = amtnet1 + Convert.ToDouble(ds.Tables[0].Rows[row]["NetAmt"].ToString());
                    newamt = newamt + Convert.ToDouble(ds.Tables[0].Rows[row]["NetAmt"].ToString());

                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adcat"].ToString(), font11));
              
             
                row++;

            }

            document.Add(datatable);



            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(7);
            float[] headerwidths5 = { 11, 13, 14, 14, 10, 12, 7}; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;

           

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase(cont.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(string.Format("{0:0.00}", newamt), font11));
            
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.Colspan = 7;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;
          //  tbltotal.addCell(new Phrase(" ", font11));
          
           
            document.Add(tbltotal);
            document.Close();
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }


  

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_repledger_print"] = "destination~" + destination + "~fromdate~" + fromdt + "~dateto~" + dateto + "~pubcent~" + pubcent + "~publication~" + publ + "~publicationname~" + publication + "~adtyp~" + adtyp + "~execut~" + execut + "~team~" + team + "~bill~" + bill + "~cl~" + cl + "~ag~" + ag + "~sortfield~" + sortfield + "~sorting~" + sorting + "~retainercode~" + retainercode + "~retainername~" + retainername + "~rep~" + rep + "~adtypename~" + adtypename + "~pubcentname~" + pubcentname + "~districtname~" + districtname + "~branch~" + branch + "~branchname~" + branchname + "~district~" + district;
        Response.Redirect("Reports_printrepresentative_ledger.aspx");
//        Response.Redirect("Reports_printrepresentative_ledger.aspx?&destination=" + destination + "&fromdate=" + fromdt + "&dateto=" + dateto + "&pubcent=" + pubcent + "&publication=" + publ + "&publicationname=" + publication + "&adtyp=" + adtyp + "&execut=" + execut + "&team=" + team + "&bill=" + bill + "&cl=" + cl + "&ag=" + ag + "&sortfield=" + sortfield + "&sorting=" + sorting + "&retainercode=" + retainercode + "&retainername=" + retainername + "&rep=" + rep + "&adtypename=" + adtypename + "&pubcentname=" + pubcentname);// "&value=" + value +
    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        int group_gov = 0;
        int group_loc = 0;
        int group_nat = 0;

        string check = e.Item.Cells[10].Text;
        string amt = e.Item.Cells[10].Text;
        string grossamt = "";
        double grossamt1 = 0;
        if (check != "NetAmt")
        {
            if (check != "&nbsp;")
            {

                grossamt = e.Item.Cells[10].Text;
                string totalarea = e.Item.Cells[10].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }

    }



}