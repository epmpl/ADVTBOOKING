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
using System.Data.OracleClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
//using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;

public partial class reportstatus : System.Web.UI.Page
{

    string agency = "";
    string client = "";

    string dytbl = "";

    string fromdt = "";
    string dateto = "";

    string package = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string status = "";
    string agname = "";
    string adcatname = "";
    string status1 = "";
    string hold = "";
    string datefrom1 = "";
    string dateto1 = "";
    
   //////////////////////////
 
 
    int sno = 1;
    double comm1 = 0;
    double comm2 = 0;
    double areanew=0;
    double areasum = 0;

    /////////////////////////
  
    
    string adtypename ="";
    double amt = 0;
    double Arr = 0;
    double area = 0;
      //int area = 0;
      int ins_no = 0;
      string sortorder = "";
      string sortvalue = "";
string    editionname="";
    protected void Page_Load(object sender, EventArgs e)
    {

        hiddendateformat.Value = Session["dateformat"].ToString();

         

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

        if (Request.QueryString["drilout"] == "yes")
        {
            fromdt= Session["frmdt"].ToString();
            dateto= Session["todt"].ToString() ;

            agency = Request.QueryString["agency"].Trim().ToString();
            adtyp = Request.QueryString["adtype"].Trim().ToString();
            adcat = Request.QueryString["adcategory"].Trim().ToString();
           // fromdt = Request.QueryString["fromdate"].Trim().ToString();
           // dateto = Request.QueryString["dateto"].Trim().ToString();
            publ = Request.QueryString["publication"].Trim().ToString();
            pubcen = Request.QueryString["pubcenter"].Trim().ToString();
            destination = Request.QueryString["destination"].Trim().ToString();
            client = Request.QueryString["client"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();
            package = Request.QueryString["package"].Trim().ToString();
            status = Request.QueryString["status"].Trim().ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();








            if (destination == "3")
            {
                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
            
              
                pdf_drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel_drilloutadday(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status);
            }
            else if (destination == "1" || destination == "0")
            {
                drillonscreen(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), package, status);
            }
            if (destination == "1" || destination == "0")
            {
                drillonscreen(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(),status);
            }




        }
        else
        {
            adtyp = Request.QueryString["adtype"].ToString();
            adcat = Request.QueryString["adcategory"].ToString();
            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            publ = Request.QueryString["publication"].ToString();
            pubcen = Request.QueryString["pubcenter"].ToString();
            pub2 = Request.QueryString["publiccent"].ToString();
            pubcname = Request.QueryString["publicname"].ToString();
            edition = Request.QueryString["edition"].ToString();
            destination = Request.QueryString["destination"].ToString();
            status = Request.QueryString["status"].ToString();
            agname = Request.QueryString["agname"].ToString();
            adcatname = Request.QueryString["adcatname"].ToString();
            status1 = Request.QueryString["status1"].ToString();
            // agencyname = Request.QueryString["agencyname"].ToString();
            adtypename = Request.QueryString["adtypename"].ToString();
            editionname = Request.QueryString["editionname"].ToString();
            hold = Request.QueryString["hold"].ToString();

            //hold = "abc";
            hiddendatefrom.Value = fromdt.ToString();
            Session["fromdate"]=fromdt;
            Session["todate"] = dateto;

            //  hiddendateto.Value = dateto.ToString();
            // string dateformat = Request.QueryString["dateformat"].ToString();
            if (publ == "0")
            {
                lblpub.Text = "ALL".ToString();
            }
            else
            {
                lblpub.Text = pubcname.ToString();
            }
            if (pubcen == "0")
            {
                pcenter.Text = "ALL".ToString();
            }
            else
            {
                pcenter.Text = pub2.ToString();
            }

            
            if (edition == "0")
            {
                lbedition.Text = "ALL".ToString();
            }
            else
            {
                lbedition.Text = editionname.ToString();


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
            //datefrom1 = "";


            if (fromdt != "")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = fromdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datefrom1 = mm + "/" + dd + "/" + yy;

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
            //dateto1 = "";
            if (dateto != "")
            {





                ///////////


                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = dd + "/" + mm + "/" + yy;

                }


            ////////////

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
            if (status1 == "--Select Status--")
            {

                lbstatus.Text = "ALL".ToString();
            }
            else
            {
                lbstatus.Text = status1.ToString();
            }

            if (destination == "1" || destination == "0")
            {
                onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
            }
            else if (destination == "4")
            {
                excel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

            }
            else
                if (destination == "3")
                {
                    pdf(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
                }


        }

    }



    /////////////////////////////////////////////////   excel generation    ////////////////////////////////////////


    private void excel(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
       
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"");


            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
           
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            
            DataGrid1.DataSource = ds;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("STATUS BASED REPORT");

            hw.WriteBreak();
            
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;

            Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"7\">TOTAL</td><td>" + areanew + "</td><td colspan=\"6\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td><tr><td>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));
            Response.Flush();
            Response.End(); 


















        //////////////////////////////////////////////////////////////////////////////////////////



        /*string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;




        try
        {
            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader1 = null;
            OracleDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
           // myReader = obj.spStatusexcel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                myReader1 = obj.spStatusexcel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader1.Read())
                // {

                ///oSheet.Cells[1,7] = "List of ADS -Hold/Cancelled";
                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));



                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

                for (int j = 0; j < myReader1.FieldCount; j++)
                {


                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[23].ToString();

                    oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                    oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[25].ToString();
                    oSheet.Cells[3, 20] = pdfxml.Tables[0].Rows[0].ItemArray[26].ToString();
                    oSheet.Cells[3, 21] = pdfxml.Tables[0].Rows[0].ItemArray[27].ToString();



                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "X3");
                oRng.EntireColumn.AutoFit();


                int i1 = 1;
                // int finaltotal = 0;
                while (myReader1.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader1.FieldCount; k++)
                    {

                        //oSheet.Cells[iRow, k + 1] = myReader1.GetValue(k).ToString();

                        oSheet.Cells[iRow, 2] = myReader1["CIOID"].ToString();



                        oSheet.Cells[iRow, 3] = myReader1["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader1["Agency"].ToString();
                        oSheet.Cells[iRow, 5] = myReader1["Client"].ToString();
                        oSheet.Cells[iRow, 6] = myReader1["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader1["Depth"].ToString();
                        oSheet.Cells[iRow, 8] = myReader1["Width"].ToString();
                        oSheet.Cells[iRow, 9] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 10] = myReader1["Hue"].ToString();
                        oSheet.Cells[iRow, 11] = myReader1["Ins.No."].ToString();
                        oSheet.Cells[iRow, 12] = myReader1["AdType"].ToString();

                        oSheet.Cells[iRow, 13] = myReader1["AdCat"].ToString();
                        oSheet.Cells[iRow, 14] = myReader1["RateCode"].ToString();
                        oSheet.Cells[iRow, 15] = myReader1["CardRate"].ToString();
                        oSheet.Cells[iRow, 16] = myReader1["Amt"].ToString();
                        oSheet.Cells[iRow, 17] = myReader1["Disc"].ToString();
                        oSheet.Cells[iRow, 18] = myReader1["Status"].ToString();
                        oSheet.Cells[iRow, 19] = myReader1["MatStatus"].ToString();
                        oSheet.Cells[iRow, 20] = myReader1["Cap"].ToString();

                        oSheet.Cells[iRow, 21] = myReader1["Key"].ToString();

                    }
                    if (myReader1["Area"] != "")
                        area = area + Convert.ToInt32(myReader1["Area"].ToString());
                    if (myReader1["Amt"].ToString() != "")
                        amt = amt + double.Parse(myReader1["Amt"].ToString());
                    iRow++;
                }



                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 7] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 8] = area.ToString();
                oSheet.Cells[iRow + 1, 16] = amt.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;

                //oSheet.Labels1="umesh";
                //oSheet.Labels1


                myReader1.Close();
                myReader1 = null;
            
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                myReader = obj.spStatusexcel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold,"","","");
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader.Read())
                // {

                ///oSheet.Cells[1,7] = "List of ADS -Hold/Cancelled";
                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));



                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

                for (int j = 0; j < myReader.FieldCount; j++)
                {


                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[23].ToString();

                    oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                    oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[25].ToString();
                    oSheet.Cells[3, 20] = pdfxml.Tables[0].Rows[0].ItemArray[26].ToString();
                    oSheet.Cells[3, 21] = pdfxml.Tables[0].Rows[0].ItemArray[27].ToString();



                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "X3");
                oRng.EntireColumn.AutoFit();


                int i1 = 1;
                // int finaltotal = 0;
                while (myReader.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader.FieldCount; k++)
                    {

                        //oSheet.Cells[iRow, k + 1] = myReader.GetValue(k).ToString();

                        oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();



                        oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                        oSheet.Cells[iRow, 5] = myReader["Client"].ToString();
                        oSheet.Cells[iRow, 6] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["Depth"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["Width"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["Ins.No."].ToString();
                        oSheet.Cells[iRow, 12] = myReader["AdType"].ToString();

                        oSheet.Cells[iRow, 13] = myReader["AdCat"].ToString();
                        oSheet.Cells[iRow, 14] = myReader["RateCode"].ToString();
                        oSheet.Cells[iRow, 15] = myReader["CardRate"].ToString();
                        oSheet.Cells[iRow, 16] = myReader["Amt"].ToString();
                        oSheet.Cells[iRow, 17] = myReader["Disc"].ToString();
                        oSheet.Cells[iRow, 18] = myReader["Status"].ToString();
                        oSheet.Cells[iRow, 19] = myReader["MatStatus"].ToString();
                        oSheet.Cells[iRow, 20] = myReader["Cap"].ToString();

                        oSheet.Cells[iRow, 21] = myReader["Key"].ToString();

                    }
                    if (myReader["Area"] != "")
                        area = area + Convert.ToInt32(myReader["Area"].ToString());
                    if (myReader["Amt"].ToString() != "")
                        amt = amt + double.Parse(myReader["Amt"].ToString());
                    iRow++;
                }



                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 7] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 8] = area.ToString();
                oSheet.Cells[iRow + 1, 16] = amt.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;

                //oSheet.Labels1="umesh";
                //oSheet.Labels1


                myReader.Close();
                myReader = null;
            
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }


            //DataSet dst=clsbook.spfun();
           

            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "S1").MergeCells = true;
            oSheet.get_Range("A1", "W1").Font.Bold = true;
            oSheet.get_Range("A1", "W1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;

            // Osheet.Cells.get_Range("A1", "A" + iRow).Locked = true; 


            oSheet.Cells.get_Range("A2", "T2");
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



            //oRng.EntireColumn.AutoFit();




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
            Response.Redirect("report3.aspx");
        }
    */
       }





    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Reportnew";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
      


        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";


        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td> <td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'   onclick=sorting('Depth',this.id)> Depth<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'   onclick=sorting('Width',this.id)> Width<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'   onclick=sorting('Area',this.id)> Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'    onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~22' class='middle3'   onclick=sorting('Ins.No.',this.id)> Ins.No.<img id='img21down' src='Images\\down.gif' style='display:block;'><img id='img21up' src='Images\\up.gif' style='display:none;'></td><td id='tdat~11' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~12' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdr~22' class='middle3'   onclick=sorting('Rate_code',this.id)>RateCode<img id='imgradown' src='Images\\down.gif' style='display:block;'><img id='imgraup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='middle3'   onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdam~20' class='middle3'   onclick=sorting('Amt',this.id)>Amt.<img id='imgamdown' src='Images\\down.gif' style='display:block;'><img id='imgamup' src='Images\\up.gif' style='display:none;'></td><td id='tddisc~28' class='middle3'   onclick=sorting('Disc',this.id)>Disc<img id='imgdisdown' src='Images\\down.gif' style='display:block;'><img id='imgdisup' src='Images\\up.gif' style='display:none;'></td><td id='tds~27' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td><td id='tdm~26' class='middle3'   onclick=sorting('MatStatus',this.id)>MatStatus<img id='imgmdown' src='Images\\down.gif' style='display:block;'><img id='imgmup' src='Images\\up.gif' style='display:none;'></td>    <td id='tdCap~16' class='middle3'   onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:block;'><img id='imgcapup' src='Images\\up.gif' style='display:none;'></td><td id='tdk~15' class='middle3'   onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:block;'><img id='imgkup' src='Images\\up.gif' style='display:none;'></td></tr>"); 

        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td> <td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'> <img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'   onclick=sorting('Depth',this.id)> Depth<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'   onclick=sorting('Width',this.id)> Width<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'   onclick=sorting('Area',this.id)> Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td> <td id='tdro~24' class='middle3'   onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td> <td id='tdro~22' class='middle3'   onclick=sorting('Ins.No.',this.id)> Ins.No.<img id='img21down' src='Images\\down.gif' style='display:block;'><img id='img21up' src='Images\\up.gif' style='display:none;'></td><td id='tdat~11' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~12' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdr~22' class='middle3'   onclick=sorting('Rate_code',this.id)>RateCode<img id='imgradown' src='Images\\down.gif' style='display:block;'><img id='imgraup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='middle3'   onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdam~20' class='middle3'   onclick=sorting('Amt',this.id)>Amt.<img id='imgamdown' src='Images\\down.gif' style='display:block;'><img id='imgamup' src='Images\\up.gif' style='display:none;'></td><td id='tddisc~28' class='middle3'   onclick=sorting('Disc',this.id)>Disc<img id='imgdisdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td><td id='tds~27' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td><td id='tdm~26' class='middle3'   onclick=sorting('MatStatus',this.id)>MatStatus<img id='imgmdown' src='Images\\down.gif' style='display:block;'><img id='imgmup' src='Images\\up.gif' style='display:none;'></td><td id='tdCap~16' class='middle3'   onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:block;'><img id='imgcapup' src='Images\\up.gif' style='display:none;'></td><td id='tdk~15' class='middle3'   onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:block;'><img id='imgkup' src='Images\\up.gif' style='display:none;'></td></tr>");
          

        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'  onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle3'  onclick=sorting('Depth',this.id)> Depth<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~29' class='middle3'  onclick=sorting('Width',this.id)> Width<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle3'  onclick=sorting('Area',this.id)> Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~24' class='middle3'  onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~22' class='middle3'   onclick=sorting('Ins.No.',this.id)> Ins.No.<img id='img21down' src='Images\\down.gif' style='display:none;'><img id='img21up' src='Images\\up.gif' style='display:block;'></td><td id='tdat~11' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~12' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td id='tdr~22' class='middle3'  onclick=sorting('Rate_code',this.id)>RateCode<img id='imgradown' src='Images\\down.gif' style='display:none;'><img id='imgraup' src='Images\\up.gif' style='display:block;'></td><td id='tdcard~29' class='middle3'  onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td><td id='tdam~20' class='middle3'  onclick=sorting('Amt',this.id)>Amt.<img id='imgamdown' src='Images\\down.gif' style='display:none;'><img id='imgamup' src='Images\\up.gif' style='display:block;'></td><td id='tddisc~28' class='middle3'  onclick=sorting('Disc',this.id)>Disc<img id='imgdisdown' src='Images\\down.gif' style='display:none;'><img id='imgdisup' src='Images\\up.gif' style='display:block;'></td><td id='tds~27' class='middle3'  onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:none;'><img id='imgstup' src='Images\\up.gif' style='display:block;'></td><td id='tdm~26' class='middle3'  onclick=sorting('MatStatus',this.id)>MatStatus<img id='imgmdown' src='Images\\down.gif' style='display:none;'><img id='imgmup' src='Images\\up.gif' style='display:block;'></td><td id='tdCap~16' class='middle3'  onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:none;'><img id='imgcapup' src='Images\\up.gif' style='display:block;'></td><td id='tdk~15' class='middle3'  onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:none;'><img id='imgkup' src='Images\\up.gif' style='display:block;'></td></tr>");
           

        }



        int i1 = 1;
     
        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr>");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");  
               // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");  
               // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
               // area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"].ToString());

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");  
               // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
                
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");  
               // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");
                ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[11].ToString());

              
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[16].ToString() + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[27].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");  
               // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[19].ToString() + "</td>");
                if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Disc"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[20].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["MatStatus"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");  
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");

                tbl = tbl + "</tr>";

            tbl = tbl + "</tr>";
        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
    //    tbl = tbl + ("<td class='middle3'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'>");
       // tbl = tbl + (area.ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("</td><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "</td>");
        tbl = tbl + "</tr>";
        tbl += "</table>";
        tblgrid.InnerHtml = tbl;


        double arr1 = amt / area;
        dytbl = dytbl + "<table>";
        dytbl = dytbl + "<tr>";
        dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
        dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
        dytbl = dytbl + ("<td class='middle13'>");
        dytbl = dytbl + ( Math.Round (arr1).ToString() + "</td>");
        dytbl = dytbl + ("</tr>");
        dytbl += "</table>";
        dynamictable.Text = dytbl;


   
    }

    private void pdf(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {


      
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);



        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int NumColumns = 21;
        //=======================================WATERMARK=========================================

        ////try
        ////{
        ////    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        ////    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        ////    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        ////    document.Add(watermark);
        ////}
        ////catch (Exception)
        ////{
        ////    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        ////}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);

       // HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();
        
        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------
       

        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

            //Table tbl = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;

            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // tbl.addCell(new Phrase("List of ADS", font9));
            
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[2].ToString(), font9));
          
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //--------------------------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
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

            //------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;



           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
            
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[23].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[25].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            
            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());

            document.Add(p2);
            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            //ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
                ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "Reportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }


            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                //for (int a = 0; a <= 10; ++a)
                //{
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                   // area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());                    
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                    ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());           
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Disc"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["MatStatus"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.HeaderRows = 1;
                //}
                    row++;

            }




            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            document.Add(p3);


            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 10, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            tbltotal.WidthPercentage = 100;
            //(i1 - 1).ToString()
            //float[] headerwidths5 = { 5, 5, 5, 5, 5, 5 };
            //tbltotal.setWidths(headerwidths5);
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
           
           // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
           // tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

      
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));

           
           
           
          
            document.Add(tbltotal);

            ////////////////////////////////////////////////////////////////////////////////////////

            Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            document.Add(p4);

            PdfPTable tbltotal1 = new PdfPTable(4);
            float[] headerwidths11 = { 5, 3, 20, 70 }; // percentage
            tbltotal1.setWidths(headerwidths11);
            tbltotal1.DefaultCell.BorderWidth = 0;
            tbltotal1.WidthPercentage = 100;
            tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            double arr = amt / area;
            tbltotal1.addCell(new Phrase(" ", font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            tbltotal1.addCell(new Phrase(" ", font10));
          //tbltotal1.addCell(new Phrase("ARR", font10));
          //tbltotal1.addCell(new Phrase(Math.Round(arr).ToString(), font10));
          //tbltotal1.addCell(new Phrase(" ", font10));
            document.Add(tbltotal1);

            //////////////////////////////////////////////////////////////////////////////////////

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
        pdf1(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
    }
    private void pdf1(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {



        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);



        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int NumColumns = 21;
        //=======================================WATERMARK=========================================

        ////try
        ////{
        ////    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        ////    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        ////    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        ////    document.Add(watermark);
        ////}
        ////catch (Exception)
        ////{
        ////    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        ////}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);

        // HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------


        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

            //Table tbl = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;

            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // tbl.addCell(new Phrase("List of ADS", font9));

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[2].ToString(), font9));

            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //--------------------------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
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
            //tbl2.addCell(new Phrase("FromDate", font10));
            //tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            //tbl2.addCell(new Phrase("DateTo", font10));
            //tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            //tbl2.addCell(new Phrase("RunDate", font10));
            //tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            //------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            //ColumnText ct = new ColumnText(datatable);
            //datatable.AutoFillEmptyCells = true;
            // datatable.DefaultRowspan = 2;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage


            //float[] headerwidths = { 12,16, 20, 14, 13, 13, 15, 14, 20, 15, 22, 22, 21, 22, 20, 12, 12, 16, 22, 10, 11 ,10}; // percentage
            //float[] headerwidths = { 12, 16, 25, 15, 15, 14, 14, 12, 20, 15, 22, 22, 21, 22, 21, 20, 12, 16, 22, 22, 11}; // percentage


            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;




            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));


            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[23].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[25].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());

            document.Add(p2);
            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            //ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
              //  NewAdbooking.classesoracle.classnew obj = new NewAdbooking.classesoracle.classnew();
               // ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "Reportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }


            //PdfPTable datatable = new PdfPTable(NumColumns);
            //float[] headerwidths5 = { 12,16, 20, 14, 10, 10, 18, 14, 20, 16, 22, 22, 21, 22, 20, 12, 12, 16, 22, 10, 11 }; // percentage
            //datatable.setWidths(headerwidths5);
            //datatable.WidthPercentage = 100; // percentage
            ////datatable.TotalWidth = 10;
            ////datatable.TotalHeight = 10;
            //datatable.DefaultCell.BorderWidth = 0;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                //for (int a = 0; a <= 10; ++a)
                //{
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Disc"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["MatStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                //datatable.HeaderRows = 1;
                //}
                row++;

            }




            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            document.Add(p3);


            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 13, 14, 10, 16, 10, 8, 16, 10, 10, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;

            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            tbltotal.WidthPercentage = 100;
            //(i1 - 1).ToString()
            //float[] headerwidths5 = { 5, 5, 5, 5, 5, 5 };
            //tbltotal.setWidths(headerwidths5);
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));





            document.Add(tbltotal);

            ////////////////////////////////////////////////////////////////////////////////////////

            Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p4);


            PdfPTable tbltotal1 = new PdfPTable(4);
            float[] headerwidths11 = { 5, 3, 20, 70 }; // percentage
            tbltotal1.setWidths(headerwidths11);
            tbltotal1.DefaultCell.BorderWidth = 0;
            tbltotal1.WidthPercentage = 100;
            tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            double arr = amt / area;
            tbltotal1.addCell(new Phrase("ARR", font10));
            tbltotal1.addCell(new Phrase(" : ", font10));
            tbltotal1.addCell(new Phrase(Math.Round(arr).ToString(), font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            document.Add(tbltotal1);

            //////////////////////////////////////////////////////////////////////////////////////

            document.Close();


            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
            //proc.StartInfo.Arguments = @"/p /hServer.MapPath(pdfName1)";
            proc.StartInfo.Arguments = @"/p /h" + Server.MapPath(pdfName1);

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

            //Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    //private void drillonscreen(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition,string dateformat, string package,  string status)
    //{

    //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    DataSet ds = new DataSet();
       // ds = obj.drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status);
    //    int cont = ds.Tables[0].Rows.Count;
    //    int contc = ds.Tables[0].Columns.Count;
    private void drillonscreen(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string dateformat,string status)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        //ds = obj.drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
      //      ds = obj.drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "report_drillout";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
         int cont = ds.Tables[0].Rows.Count;
          string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        


        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td> <td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td id='tdat~11' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~12' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>CardRate</td><td class='middle31'>Amt</td><td class='middle31'>Disc</td><td class='middle31'>Status</td><td class='middle31'>MatStatus</td><td class='middle31'>Cap</td><td class='middle3'>Key</td></tr>");
          
        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td id='tdat~11' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~12' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>CardRate</td><td class='middle31'>Amt</td><td class='middle31'>Disc</td><td class='middle31'>Status</td><td class='middle31'>MatStatus</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");
         
        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle3'>Area</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td id='tdat~11' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~12' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>RateCode</td><td class='middle31'>CardRate</td><td class='middle31'>Amt</td><td class='middle31'>Disc</td><td class='middle31'>Status</td><td class='middle31'>MatStatus</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");

            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdcl~3' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td> <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td> <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>RateCode</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");


        }


       
        int i1 = 1;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]);
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");
            ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[11].ToString());


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[16].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[27].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[19].ToString() + "</td>");
            if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Disc"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[20].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["MatStatus"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");

            tbl = tbl + "</tr>";

            tbl = tbl + "</tr>";
        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle3'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("</td><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "</td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
   
    
    }

    private void pdf_drilloutstatus(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string dateformat, string status, string descid, string ascdesc)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



      //  btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'DSC_473011.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 21;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[2].ToString(), font9));
            //ds.Tables[0].Rows[row].ItemArray[0]
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
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11,10, 16, 18, 15, 20, 20, 16,14, 16, 15, 10, 12,12,14}; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));


            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[23].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[25].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());

            document.Add(p2);
            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
           // ds = obj.statusdrilloutpdf(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, descid, ascdesc);


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.statusdrilloutpdf(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, descid, ascdesc);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
        //        ds = obj.statusdrilloutpdf(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, descid, ascdesc,"","","");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "report_drillout";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, descid, ascdesc };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                //for (int a = 0; a <= 10; ++a)
                //{
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                area = area + Convert.ToDouble(ds.Tables[0].Rows[row]["Area"].ToString());

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")

                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Disc"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["MatStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                //datatable.HeaderRows = 1;
                //}
                row++;

            }




            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));


            document.Add(p3);


            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 10, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;

            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            tbltotal.WidthPercentage = 100;
            //(i1 - 1).ToString()
            //float[] headerwidths5 = { 5, 5, 5, 5, 5, 5 };
            //tbltotal.setWidths(headerwidths5);
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));





            document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }



    }
    private void excel_drilloutadday(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string dateformat, string status)
    { 
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
       
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
    //        ds = obj.drilloutstatus(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "report_drillout";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
           
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            
            DataGrid1.DataSource = ds;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("ALL ADS OF DAY");

            hw.WriteBreak();
            
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;

            Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"7\">TOTAL</td><td>" + areanew + "</td><td colspan=\"6\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td><tr><td>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));
            Response.Flush();
            Response.End(); 


    } 
    /*string strCurrentDir = Server.MapPath(".") + "\\";
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
           // SqlDataReader myReader1 = null;

            DataSet pdfxml = new DataSet();
            DataSet mydata = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));


            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //mydata = obj.statusdrilloutexcel(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat
            //DataSet dst=clsbook.spfun();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                mydata = obj.statusdrilloutexcel(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                mydata = obj.statusdrilloutexcel(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), status, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }
            
            
            int iRow = 4;  //2
            oSheet.PageSetup.CenterFooter = "&P";

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

            for (int j = 0; j < mydata.Tables[0].Rows.Count; j++)
            {


                //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();

                //oSheet.Cells[3, 5] = myReader.GetName(4).ToString();
                oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();
                oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[23].ToString();

                oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[25].ToString();
                oSheet.Cells[3, 20] = pdfxml.Tables[0].Rows[0].ItemArray[26].ToString();
                oSheet.Cells[3, 21] = pdfxml.Tables[0].Rows[0].ItemArray[27].ToString();
                //oSheet.DisplayPageBreaks=

            }
            //   }
            oSheet.Cells.Font.Name = "verdana";
            oSheet.Cells.Font.Size = 7;

            //oRng = oSheet.get_Range("A3", "Y3");
            //oRng.EntireColumn.AutoFit();
            int i1 = 1;
            int i = 0;

            for (i = 0; i < mydata.Tables[0].Rows.Count ; i++)
            {
                oSheet.Cells[iRow, 1] = i1++.ToString();
                oSheet.Cells[iRow, 2] = mydata.Tables[0].Rows[i]["CIOID"].ToString();
                oSheet.Cells[iRow, 3] = mydata.Tables[0].Rows[i]["Ins.date"].ToString();
                oSheet.Cells[iRow, 4] = mydata.Tables[0].Rows[i]["Agency"].ToString();
                oSheet.Cells[iRow, 5] = mydata.Tables[0].Rows[i]["Client"].ToString();
                oSheet.Cells[iRow, 6] = mydata.Tables[0].Rows[i]["Package"].ToString();
                oSheet.Cells[iRow, 7] = mydata.Tables[0].Rows[i]["Depth"].ToString();
                oSheet.Cells[iRow, 8] = mydata.Tables[0].Rows[i]["Width"].ToString();
                oSheet.Cells[iRow, 9] = mydata.Tables[0].Rows[i]["Area"].ToString();
                oSheet.Cells[iRow, 10] = mydata.Tables[0].Rows[i]["Hue"].ToString();
                oSheet.Cells[iRow, 11] = mydata.Tables[0].Rows[i]["Ins.No."].ToString();
                oSheet.Cells[iRow, 12] = mydata.Tables[0].Rows[i]["AdType"].ToString();

                oSheet.Cells[iRow, 13] = mydata.Tables[0].Rows[i]["AdCat"].ToString();
                oSheet.Cells[iRow, 14] = mydata.Tables[0].Rows[i]["RateCode"].ToString();
                oSheet.Cells[iRow, 15] = mydata.Tables[0].Rows[i]["CardRate"].ToString();
                oSheet.Cells[iRow, 16] = mydata.Tables[0].Rows[i]["Amt"].ToString();
                oSheet.Cells[iRow, 17] = mydata.Tables[0].Rows[i]["Disc"].ToString();
                oSheet.Cells[iRow, 18] = mydata.Tables[0].Rows[i]["Status"].ToString();
                oSheet.Cells[iRow, 19] = mydata.Tables[0].Rows[i]["MatStatus"].ToString();
                oSheet.Cells[iRow, 20] = mydata.Tables[0].Rows[i]["Cap"].ToString();

                oSheet.Cells[iRow, 21] = mydata.Tables[0].Rows[i]["Key"].ToString();


                if (mydata.Tables[0].Rows[i]["Area"] != "")
                    area = area + Convert.ToInt32(mydata.Tables[0].Rows[i]["Area"].ToString());
                if (mydata.Tables[0].Rows[i]["Amt"].ToString() != "")
                    amt = amt + double.Parse(mydata.Tables[0].Rows[i]["Amt"].ToString());



                iRow++;

            }


            oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
            oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
            oSheet.Cells[iRow + 1, 7] = "Totals :".ToString();
            oSheet.Cells[iRow + 1, 9] = area.ToString();
            oSheet.Cells[iRow + 1, 17] = amt.ToString();
            // oSheet.Cells[iRow + 1, 11] = billarea.ToString();

            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);

            oSheet.get_Range(row, row1).Font.Bold = true;


            //myReader1.Close();
            //myReader1 = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "S1").MergeCells = true;
            oSheet.get_Range("A1", "S1").Font.Bold = true;
            oSheet.get_Range("A1", "S1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            oRng.EntireColumn.AutoFit();

            oXL.Visible = true;
            oXL.UserControl = false;
            string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

            oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRng);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

            GC.Collect();  // force final cleanup!
            //string strMachineName = Request.ServerVariables["SERVER_NAME"];
            string strMachineName = Request.ServerVariables["umesh"];
            //errLabel.Text = "<A href=http://" + strMachineName + "/ExcelGen/" + strFile + ">Download Report</a>";



        }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
            //errLabel.Text = errorMessage;
        }
        finally
        {
            Response.Redirect("report.aspx");
        }
    }

    */




    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
       
        
            string sno1 = e.Item.Cells[0].Text;
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
            }
            
            string check1 = e.Item.Cells[8].Text;
            string area = e.Item.Cells[8].Text;

            if (check1 != "Area")
            {
                if (check1 != "&nbsp;")
                {


                    string totalarea = e.Item.Cells[8].Text;
                    areasum = Convert.ToDouble(totalarea);
                    areanew = areanew + areasum;


                }
            }

            string check = e.Item.Cells[15].Text;
            string amt = e.Item.Cells[15].Text;

            if (check != "Amt")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[15].Text;
                    comm1 = Convert.ToDouble(grossamt);
                    comm2 = comm2 + comm1;

                }
            }
            
       
    }
}





