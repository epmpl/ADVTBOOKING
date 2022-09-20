using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text;
using System.IO;



public partial class regionwisereport : System.Web.UI.Page
{
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string adtypename = "";
    string editionname = "";
    string pdfName1 = "";
    //string date = "";
    string datefrom1 = "";
    string dateto1 = "";
    string region = "";
    string regtext = "";
    string lang = "";
    string agency = "";
    string client = "";
    string sortorder = "";
    string sortvalue = "";
    double amt = 0;
    int i1 = 1;
    //int area = 0;
    decimal area = 0;
    double BillAmt = 0;
    float billarea = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();
        fromdt=Session["fromdate"].ToString();
        dateto= Session["todate"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
        //adcatname = Request.QueryString["adcatname"].ToString();
        //adtypename = Request.QueryString["adtypename"].ToString();
        //editionname = Request.QueryString["editionname"].ToString();
        //publ = Request.QueryString["publication"].ToString();
        //pubcen = Request.QueryString["pubcenter"].ToString();
        //pub2 = Request.QueryString["publiccent"].ToString();
        //pubcname = Request.QueryString["publicname"].ToString();
        //edition = Request.QueryString["edition"].ToString();
        //adtyp = Request.QueryString["adtype"].ToString();
        //adcat = Request.QueryString["adcategory"].ToString();

        if (Request.QueryString["drilout"] == "yes")
        {

            //fromdt = Request.QueryString["fromdate"].ToString();
            //dateto = Request.QueryString["dateto"].ToString();
            region = Request.QueryString["region"].ToString();
            //regtext = Request.QueryString["regiontext"].ToString();
            lang = Request.QueryString["language"].ToString();
            agency = Request.QueryString["agency"].ToString();
            client = Request.QueryString["client"].ToString();
            destination = Request.QueryString["destination"].ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
            if(destination=="0" || destination=="1")
            {
            drillonscreen(fromdt, dateto, region, lang, agency, client, Session["compcode"].ToString(), Session["dateformat"].ToString());   
            }
            else if(destination=="3")
            {
                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
                pdf_drillout(fromdt, dateto, region, lang, agency, client, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());  
            }
            else if (destination == "4")
            {
                excel_drillout(fromdt, dateto, region, lang, agency, client, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
        }

        else
        {
            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            destination = Request.QueryString["destination"].ToString();
            region = Request.QueryString["region"].ToString();
            //regtext = Request.QueryString["regiontext"].ToString();

            


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
            //datefrom1 = "";
            if (fromdt != "")
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
            lblfrom.Text = datefrom1;
            //dateto1 = "";
            if (dateto != "")
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
            lblto.Text = dateto1;

            if (destination == "1" || destination == "0")
            {
                onscreen(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());

            }
            else
                if (destination == "3")
                {
                    pdf(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());
                }
        }

    }


    private void onscreen( string fromdt, string dateto,  string compcode, string region, string dateformat)
    {
        NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ds = obj.spregionreport(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>Hue</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Coloumn</td><td class='middle3'>CardRate</td><td class='middle3'>Package</td><td class='middle3'>Region</td><td class='middle3'>AdCat</td><td class='middle3'>Amt</td><td class='middle3'>Ins.Date</td><td class='middle3'>Area</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Region</td><td class='middle3'></td></tr>");
        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td id='tdreg~11' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");
        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td id='tdreg~11' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");
        }
        else if (hiddenascdesc.Value == "desc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td id='tdreg~11' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:none;'><img id='imgregup' src='Images\\up.gif' style='display:block;'></td></tr>");

        }

        int i1 = 1;
        //int area = 0;



        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");






            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


           tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");

               
             tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>"); 
            tbl = tbl + (ds.Tables[0].Rows[i]["Ro.Date"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
          
            tbl = tbl + "</tr>";

            //    break;
            //}
            //  tbl = tbl + "</tr>";


        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'></td>    <td class='middle13'>TotalArea</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "<td class='middle13'></td><td class='middle13'></td></td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;


    }
    //private void excel(string fromdt, string dateto, string compcode, string region, string dateformat)
    //{
    //    string strCurrentDir = Server.MapPath(".") + "\\";
    //    //RemoveFiles(strCurrentDir); // utility method to clean up old files			
    //    Excel.Application oXL;
    //    Excel._Workbook oWB;
    //    Excel._Worksheet oSheet;
    //    Excel.Range oRng;
    //    // Excel.Range oRng1;

    //    try
    //    {


    //        GC.Collect();// clean up any other excel guys hangin' around...
    //        oXL = new Excel.Application();
    //        oXL.Visible = true;

    //        //Get a new workbook.
    //        oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
    //        oSheet = (Excel._Worksheet)oWB.ActiveSheet;
    //        oRng = oSheet.get_Range("A3", "Y3");
    //        //oSheet.PageSetup.CenterHeader = "GAURAV";
    //        //oXL.Visible = true;
    //        //get our Data     
    //        // sqlc
    //        // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
    //        //SPGen sg = new SPGen(strConnect, spName);
    //        SqlDataReader myReader = null;

    //        NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    //        myReader = obj.spregionexcel(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());
    //        //DataSet dst=clsbook.spfun();
    //        int iRow = 4;  //2

    //        oSheet.PageSetup.CenterFooter = "&P";

    //        // while(myReader.Read())
    //        // {
    //        oSheet.Cells[1, 7] = "PI Report Region Wise";
    //        for (int j = 0; j < myReader.FieldCount; j++)
    //        {

    //            //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
    //            oSheet.Cells[3, 1] = "S.No.".ToString();
    //            oSheet.Cells[3, 2] = myReader.GetName(0).ToString();
    //            oSheet.Cells[3, 3] = myReader.GetName(1).ToString();
    //            oSheet.Cells[3, 4] = myReader.GetName(2).ToString();
    //            //oSheet.Cells[3, 5] = myReader.GetName(4).ToString();
    //            oSheet.Cells[3, 5] = myReader.GetName(8).ToString();
    //            oSheet.Cells[3, 6] = myReader.GetName(9).ToString();
    //            oSheet.Cells[3, 7] = myReader.GetName(14).ToString();
    //            oSheet.Cells[3, 8] = myReader.GetName(28).ToString();
    //            oSheet.Cells[3, 8] = myReader.GetName(12).ToString();
    //            oSheet.Cells[3, 10] = myReader.GetName(19).ToString();
    //            oSheet.Cells[3, 11] = myReader.GetName(30).ToString();
    //           // oSheet.Cells[3, 13] = myReader.GetName(27).ToString();
    //            //oSheet.Cells[3, 14] = myReader.GetName(19).ToString();
    //           // oSheet.Cells[3, 15] = myReader.GetName(30).ToString();
    //            //oSheet.Cells[3, 12] = myReader.GetName(12).ToString();
    //            //oSheet.Cells[3, 13] = myReader.GetName(8).ToString();
    //            //oSheet.Cells[3, 14] = myReader.GetName(13).ToString();
    //            //oSheet.Cells[3, 15] = myReader.GetName(16).ToString();
    //            //oSheet.Cells[3, 16] = myReader.GetName(27).ToString();
    //            //oSheet.Cells[3, 17] = myReader.GetName(18).ToString();
    //            //oSheet.Cells[3, 18] = myReader.GetName(25).ToString();
    //            //oSheet.Cells[3, 19] = myReader.GetName(23).ToString();
    //            //oSheet.Cells[3, 20] = myReader.GetName(24).ToString();
    //            //oSheet.DisplayPageBreaks=

    //        }
    //        //   }
    //        oSheet.Cells.Font.Name = "verdana";
    //        oSheet.Cells.Font.Size = 7;

    //        oRng = oSheet.get_Range("A3", "Y3");
    //        oRng.EntireColumn.AutoFit();
    //        //oRng.Columns.AutoFit(oSheet, 3);
    //        //oRng.EntireColumn.Font.Size = 10;

    //        //				oRng.Column=1;
    //        //				oRng.EntireColumn.Width=0;
    //        //string total = "";
    //        //int tot = 0;
    //        //int finaltotal = 0;
    //        int i1 = 1;
    //        while (myReader.Read())
    //        {
    //            oSheet.Cells[iRow, 1] = i1++.ToString();
    //            for (int k = 0; k < myReader.FieldCount; k++)
    //            {
    //                oSheet.Cells[iRow, 2] = myReader.GetValue(0).ToString();
    //                oSheet.Cells[iRow, 3] = myReader.GetValue(1).ToString();
    //                oSheet.Cells[iRow, 4] = myReader.GetValue(2).ToString();
    //                //oSheet.Cells[iRow, 5] = myReader.GetValue(4).ToString();
    //                oSheet.Cells[iRow, 6] = myReader.GetValue(8).ToString();
    //                oSheet.Cells[iRow, 7] = myReader.GetValue(9).ToString();
    //                oSheet.Cells[iRow, 8] = myReader.GetValue(14).ToString();
    //                oSheet.Cells[iRow, 9] = myReader.GetValue(28).ToString();
    //                oSheet.Cells[iRow, 10] = myReader.GetValue(12).ToString();
    //                oSheet.Cells[iRow, 11] = myReader.GetValue(19).ToString();
    //                oSheet.Cells[iRow, 12] = myReader.GetValue(30).ToString();
    //                //oSheet.Cells[iRow, 13] = myReader.GetValue(8).ToString();
    //                //oSheet.Cells[iRow, 14] = myReader.GetValue(13).ToString();
    //                //oSheet.Cells[iRow, 15] = myReader.GetValue(16).ToString();
    //                //oSheet.Cells[iRow, 16] = myReader.GetValue(27).ToString();
    //                //oSheet.Cells[iRow, 17] = myReader.GetValue(18).ToString();
    //                //oSheet.Cells[iRow, 18] = myReader.GetValue(25).ToString();
    //                //oSheet.Cells[iRow, 19] = myReader.GetValue(23).ToString();
    //                //oSheet.Cells[iRow, 20] = myReader.GetValue(24).ToString();
    //                //oSheet.Cells[iRow, 1] = myReader.GetValue(0).ToString();

    //                //oSheet.PageSetup.CenterHeader = oRng.ToString();
    //                //oXL.Visible = true;
    //                // mnWidth = 6;

    //            }

    //            iRow++;



    //        }
    //        //sheet.PageSetup.Orientation = ExcelPageOrientation.Landscape;

    //        //oSheet.HPageBreaks.Add("A20");
    //        //oSheet.VPageBreaks.Add("R20");

    //        //oRng1 = oSheet.get_Range("A3", "Y3");

    //        // oSheet.HPageBreaks.Add(["A20"]);
    //        // oSheet.VPageBreaks.Add(oSheet.get_Range["R20"]);


    //        string row;
    //        string row1;
    //        iRow = iRow + 1;
    //        row = "A" + Convert.ToString(iRow);
    //        row1 = "AA" + Convert.ToString(iRow);

    //        oSheet.get_Range(row, row1).Font.Bold = true;


    //        myReader.Close();
    //        myReader = null;
    //        oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
    //        oSheet.get_Range("A1", "S1").MergeCells = true;
    //        oSheet.get_Range("A1", "S1").Font.Bold = true;
    //        oSheet.get_Range("A1", "S1").Font.Size = 10;
    //        oSheet.get_Range("A3", "Y3").Font.Bold = true;
    //        oSheet.get_Range("A3", "Y3").Font.Size = 8;
    //        oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

    //        oRng.EntireColumn.AutoFit();

    //        oXL.Visible = true;
    //        oXL.UserControl = false;
    //        string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

    //        oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);

    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

    //        GC.Collect();  // force final cleanup!
    //        string strMachineName = Request.ServerVariables["SERVER_NAME"];


    //    }
    //    catch (Exception theException)
    //    {
    //        String errorMessage;
    //        errorMessage = "Error: ";
    //        errorMessage = String.Concat(errorMessage, theException.Message);
    //        errorMessage = String.Concat(errorMessage, " Line: ");
    //        errorMessage = String.Concat(errorMessage, theException.Source);
    //    }
    //    finally
    //    {
    //        Response.Redirect("piregion.aspx");
    //    }
    //}


    private void excel(string fromdt, string dateto, string compcode, string region, string dateformat)
    {
        string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        // Excel.Range oRng1;

        try
        {


            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            oRng = oSheet.get_Range("A3", "Y3");
            //oSheet.PageSetup.CenterHeader = "GAURAV";
            //oXL.Visible = true;
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
             myReader = obj.spregionexcel(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());
             //DataSet dst=clsbook.spfun();
             int iRow = 4;  //2

             oSheet.PageSetup.CenterFooter = "&P";

             // while(myReader.Read())
             // {
             DataSet ds1 = new DataSet();
             ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
             oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
             for (int j = 0; j < myReader.FieldCount; j++)
             {

                //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                
                 oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                 oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                 oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                 oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[39].ToString();
                oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[40].ToString();
             
                
            }
            //   }
            oSheet.Cells.Font.Name = "verdana";
            oSheet.Cells.Font.Size = 7;

            oRng = oSheet.get_Range("A3", "Y3");
            oRng.EntireColumn.AutoFit();
            //oRng.Columns.AutoFit(oSheet, 3);
            //oRng.EntireColumn.Font.Size = 10;

            //				oRng.Column=1;
            //				oRng.EntireColumn.Width=0;
            //string total = "";
            //int tot = 0;
            //int finaltotal = 0;
            int i1 = 1;
            while (myReader.Read())
            {
                 oSheet.Cells[iRow, 1] = i1++.ToString();
                for (int k = 0; k < myReader.FieldCount; k++)
                {

                    oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();
                    oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                    oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                    oSheet.Cells[iRow, 5] = myReader["Client"].ToString();

                    oSheet.Cells[iRow, 6] = myReader["Area"].ToString();
                    oSheet.Cells[iRow, 7] = myReader["Hue"].ToString();
                    // oSheet.Cells[iRow, 7] = myReader.GetValue(9).ToString();
                    oSheet.Cells[iRow, 8] = myReader["RoNo."].ToString();
                    oSheet.Cells[iRow, 9] = myReader["Ro.Date"].ToString();
                    oSheet.Cells[iRow, 10] = myReader["AgreedRate"].ToString();
                    oSheet.Cells[iRow, 11] = myReader["Amt"].ToString();
                    oSheet.Cells[iRow, 12] = myReader["Region"].ToString();
                   // oSheet.Cells[iRow, 11] = myReader.GetValue(27).ToString();
                   // oSheet.Cells[iRow, 14] = myReader.GetValue(19).ToString();
                    //oSheet.Cells[iRow, 15] = myReader.GetValue(30).ToString();
                    //oSheet.Cells[iRow, 16] = myReader.GetValue(27).ToString();
                    //oSheet.Cells[iRow, 17] = myReader.GetValue(18).ToString();
                    //oSheet.Cells[iRow, 18] = myReader.GetValue(25).ToString();
                    //oSheet.Cells[iRow, 19] = myReader.GetValue(23).ToString();
                    //oSheet.Cells[iRow, 20] = myReader.GetValue(24).ToString();
                    //oSheet.Cells[iRow, 1] = myReader.GetValue(0).ToString();

                    //oSheet.PageSetup.CenterHeader = oRng.ToString();
                    //oXL.Visible = true;
                    // mnWidth = 6;



                    if (myReader["Area"].ToString() != "")
                        area = area + int.Parse(myReader["Area"].ToString());
                    if (myReader["Amt"].ToString() != "")
                        amt = amt + double.Parse(myReader["Amt"].ToString());

            }



                iRow++;
        }


            

            oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
            oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
            oSheet.Cells[iRow + 1, 5] = "Totals :".ToString();
            oSheet.Cells[iRow + 1, 6] = area.ToString();
            oSheet.Cells[iRow + 1, 11] = amt.ToString();
          //  oSheet.Cells[iRow + 1, 10] = billarea.ToString();
            //sheet.PageSetup.Orientation = ExcelPageOrientation.Landscape;

            //oSheet.HPageBreaks.Add("A20");
            //oSheet.VPageBreaks.Add("R20");

            //oRng1 = oSheet.get_Range("A3", "Y3");

            // oSheet.HPageBreaks.Add(["A20"]);
            // oSheet.VPageBreaks.Add(oSheet.get_Range["R20"]);

    
            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);

            oSheet.get_Range(row, row1).Font.Bold = true;


            myReader.Close();
            myReader = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "R1").MergeCells = true;
            oSheet.get_Range("A1", "R1").Font.Bold = true;
            oSheet.get_Range("A1", "R1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            oRng.EntireColumn.AutoFit();

            oXL.Visible = true;
            oXL.UserControl = false;
            string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

            oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

            GC.Collect();  // force final cleanup!
            string strMachineName = Request.ServerVariables["SERVER_NAME"];


    }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
        }

        finally
        {
            Response.Redirect("pipublication.aspx");
        }
    }


 private void pdf(string fromdt, string dateto, string compcode, string region, string dateformat)
 {
     DataSet pdfxml = new DataSet();
     pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.GetInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);

        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
           
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            

            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 14, 15, 18, 16, 15, 7, 10,10, 18, 18,17 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[39].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            
            document.Add(p2);


            //------------------//-------------------------------------------------------------------       

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj.spregionreport(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                    //----------------------------------------------------------------------

                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                        area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RO.Date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                   
                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            float[] headerwidths5 = { 10, 6, 14, 14, 6, 8, 12, 10, 10, 6, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
           
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));

            // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(billarea.ToString(), font11));
           
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));

            document.Add(tbltotal);

            document.Close();

            //PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Truncate));

           // count = i2;
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        pdf1(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        //Response.Redirect("<script>window.print();</script>");
    }

    //=========================================================================================

    private void pdf1(string fromdt, string dateto, string compcode, string region, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        //string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.GetInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);

        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");

            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 14, 15, 18, 16, 15, 7, 10, 10, 18, 18, 17 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[39].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));

            document.Add(p2);


            //------------------//-------------------------------------------------------------------       

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj.spregionreport(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                //----------------------------------------------------------------------

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RO.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));

                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            float[] headerwidths5 = { 10, 6, 14, 14, 6, 8, 12, 10, 10, 6, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));

            // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            // tbltotal.addCell(new Phrase(billarea.ToString(), font11));

            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));

            document.Add(tbltotal);

            document.Close();


            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
            proc.StartInfo.Arguments = @"/p /h" + Server.MapPath(pdfName1);
            //proc.StartInfo.Arguments = @"/p /Depth" + Server.MapPath(pdfName1);

            //proc.StartInfo.Arguments = @"/p /Depth C:\Inetpub\wwwroot\NewAdbooking\3719138.pdf";

            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            if (!proc.HasExited)
            {
                proc.Refresh();
                //Thread.Sleep(2000);
                proc.CloseMainWindow();
            }
            else
            {
                //break;

            }
            
            
           

        }

        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
        //=============================================================================================
    }

    private void drillonscreen(string fromdt, string dateto, string region,string language, string agency, string client, string compcode, string dateformat)//, string lang
    {
        NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ds = obj.regiondrillout(fromdt, dateto, region, lang, agency, client, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());  // 
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>Hue</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Coloumn</td><td class='middle3'>CardRate</td><td class='middle3'>Package</td><td class='middle3'>Region</td><td class='middle3'>AdCat</td><td class='middle3'>Amt</td><td class='middle3'>Ins.Date</td><td class='middle3'>Area</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Region</td><td class='middle3'></td></tr>");
        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td id='tdreg~11' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");
        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td id='tdreg~11' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");
        }
        else if (hiddenascdesc.Value == "desc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td id='tdreg~11' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:none;'><img id='imgregup' src='Images\\up.gif' style='display:block;'></td></tr>");

        }


        int i1 = 1;
        int area = 0;



        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");






            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>"); 
            tbl = tbl + (ds.Tables[0].Rows[i]["Ro.Date"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");

            tbl = tbl + "</tr>";

            //    break;
            //}
            //  tbl = tbl + "</tr>";


        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'></td>    <td class='middle13'>TotalArea</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "<td class='middle13'></td><td class='middle13'></td></td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;


                   
    }

    private void pdf_drillout(string fromdt, string dateto, string region, string language, string agency, string client, string compcode, string dateformat, string descid, string ascdesc)//, string lang
    {
            DataSet pdfxml = new DataSet();
     pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.GetInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);

        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
           
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            

            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 14, 15, 18, 16, 15, 7, 10,10, 18, 18,17 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[39].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            
            document.Add(p2);


            //------------------//-------------------------------------------------------------------       

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj.regiondrillout(fromdt, dateto, region, lang, agency, client, Session["compcode"].ToString(), Session["dateformat"].ToString(), descid, ascdesc);  // 

            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                    //----------------------------------------------------------------------

                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                        area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RO.Date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                   
                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            float[] headerwidths5 = { 10, 6, 14, 14, 6, 8, 12, 10, 10, 6, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
           
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));

            // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(billarea.ToString(), font11));
           
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));

            document.Add(tbltotal);

            document.Close();

            //PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Truncate));

           // count = i2;
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    private void excel_drillout(string fromdt, string dateto, string region, string language, string agency, string client, string compcode, string dateformat)
    {
        string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        // Excel.Range oRng1;

        try
        {


            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            oRng = oSheet.get_Range("A3", "Y3");
            //oSheet.PageSetup.CenterHeader = "GAURAV";
            //oXL.Visible = true;
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
             myReader = obj.region_drillout(fromdt, dateto, region, lang, agency, client, Session["compcode"].ToString(), Session["dateformat"].ToString());  // 
             //DataSet dst=clsbook.spfun();
             int iRow = 4;  //2

             oSheet.PageSetup.CenterFooter = "&P";

             // while(myReader.Read())
             // {
             DataSet ds1 = new DataSet();
             ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
             oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
             for (int j = 0; j < myReader.FieldCount; j++)
             {

                //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                
                 oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                 oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                 oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                 oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[39].ToString();
                oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[40].ToString();
             
                
            }
            //   }
            oSheet.Cells.Font.Name = "verdana";
            oSheet.Cells.Font.Size = 7;

            oRng = oSheet.get_Range("A3", "Y3");
            oRng.EntireColumn.AutoFit();
            //oRng.Columns.AutoFit(oSheet, 3);
            //oRng.EntireColumn.Font.Size = 10;

            //				oRng.Column=1;
            //				oRng.EntireColumn.Width=0;
            //string total = "";
            //int tot = 0;
            //int finaltotal = 0;
            int i1 = 1;
            while (myReader.Read())
            {
                 oSheet.Cells[iRow, 1] = i1++.ToString();
                for (int k = 0; k < myReader.FieldCount; k++)
                {

                    oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();
                    oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                    oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                    oSheet.Cells[iRow, 5] = myReader["Client"].ToString();

                    oSheet.Cells[iRow, 6] = myReader["Area"].ToString();
                    oSheet.Cells[iRow, 7] = myReader["Hue"].ToString();
                    // oSheet.Cells[iRow, 7] = myReader.GetValue(9).ToString();
                    oSheet.Cells[iRow, 8] = myReader["RoNo."].ToString();
                    oSheet.Cells[iRow, 9] = myReader["Ro.Date"].ToString();
                    oSheet.Cells[iRow, 10] = myReader["AgreedRate"].ToString();
                    oSheet.Cells[iRow, 11] = myReader["Amt"].ToString();
                    oSheet.Cells[iRow, 12] = myReader["Region"].ToString();
                   // oSheet.Cells[iRow, 11] = myReader.GetValue(27).ToString();
                   // oSheet.Cells[iRow, 14] = myReader.GetValue(19).ToString();
                    //oSheet.Cells[iRow, 15] = myReader.GetValue(30).ToString();
                    //oSheet.Cells[iRow, 16] = myReader.GetValue(27).ToString();
                    //oSheet.Cells[iRow, 17] = myReader.GetValue(18).ToString();
                    //oSheet.Cells[iRow, 18] = myReader.GetValue(25).ToString();
                    //oSheet.Cells[iRow, 19] = myReader.GetValue(23).ToString();
                    //oSheet.Cells[iRow, 20] = myReader.GetValue(24).ToString();
                    //oSheet.Cells[iRow, 1] = myReader.GetValue(0).ToString();

                    //oSheet.PageSetup.CenterHeader = oRng.ToString();
                    //oXL.Visible = true;
                    // mnWidth = 6;



                    if (myReader["Area"].ToString() != "")
                        area = area + int.Parse(myReader["Area"].ToString());
                    if (myReader["Amt"].ToString() != "")
                        amt = amt + double.Parse(myReader["Amt"].ToString());

            }



                iRow++;
        }


            

            oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
            oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
            oSheet.Cells[iRow + 1, 5] = "Totals :".ToString();
            oSheet.Cells[iRow + 1, 6] = area.ToString();
            oSheet.Cells[iRow + 1, 11] = amt.ToString();
          //  oSheet.Cells[iRow + 1, 10] = billarea.ToString();
            //sheet.PageSetup.Orientation = ExcelPageOrientation.Landscape;

            //oSheet.HPageBreaks.Add("A20");
            //oSheet.VPageBreaks.Add("R20");

            //oRng1 = oSheet.get_Range("A3", "Y3");

            // oSheet.HPageBreaks.Add(["A20"]);
            // oSheet.VPageBreaks.Add(oSheet.get_Range["R20"]);

    
            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);

            oSheet.get_Range(row, row1).Font.Bold = true;


            myReader.Close();
            myReader = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "R1").MergeCells = true;
            oSheet.get_Range("A1", "R1").Font.Bold = true;
            oSheet.get_Range("A1", "R1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            oRng.EntireColumn.AutoFit();

            oXL.Visible = true;
            oXL.UserControl = false;
            string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

            oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

            GC.Collect();  // force final cleanup!
            string strMachineName = Request.ServerVariables["SERVER_NAME"];


    }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
        }

        finally
        {
            Response.Redirect("pipublication.aspx");
        }
    }
    

    
}




