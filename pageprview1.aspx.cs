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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;


public partial class pageprview1 : System.Web.UI.Page
{

    string clientname = "";
    string adtyp = "";
    string destination = "";
    //string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
   // string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string positioncode = "";
    string agname = "";
   //string status = "";
    string status1 = "";
    string hold = "";
    //string adtypename="";
    string  editionname="";
   // string agencyname = "";
    string page = "";
    string position = "";
    string datefrom1 = "";
    string dateto1 = "";
    int ins_no = 0;
    float area = 0;
    double BillAmt = 0;
    float billarea = 0;
    string package = "";
    string sortorder = "";
    string sortvalue = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();
        fromdt = Session["fromdate"].ToString();
        dateto = Session["todate"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

        if (Request.QueryString["drilout"] == "yes")
        {
            page = Request.QueryString["page"].Trim().ToString();
            position = Request.QueryString["position"].Trim().ToString();
            agname = Request.QueryString["agency"].Trim().ToString();
            clientname = Request.QueryString["client"].Trim().ToString();
            adtyp = Request.QueryString["adtype"].Trim().ToString();
            fromdt = Request.QueryString["fromdate"].Trim().ToString();
            dateto = Request.QueryString["dateto"].Trim().ToString();
            publ = Request.QueryString["publication"].Trim().ToString();
            pubcen = Request.QueryString["pubcenter"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();
            package = Request.QueryString["package"].Trim().ToString();
            //city = Request.QueryString["city"].ToString();
            status1 = Request.QueryString["status1"].ToString();
            destination = Request.QueryString["destination"].ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();

            if (destination == "0" || destination == "1")
            {
                drillonscreen(page, position, clientname, agname, adtyp, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString());
            }
            else if (destination == "3")


            {

                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
                pdf_drillout(page, position, clientname, agname, adtyp, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel_drillout(page, position, clientname, agname, adtyp, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString());
            }
            
                      
        }
        else
        {

            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            publ = Request.QueryString["publication"].ToString();
            pubcen = Request.QueryString["pubcenter"].ToString();
            pub2 = Request.QueryString["publiccent"].ToString();
            pubcname = Request.QueryString["publicname"].ToString();
            edition = Request.QueryString["edition"].ToString();
            destination = Request.QueryString["destination"].ToString();
            //adcatname = Request.QueryString["adcatname"].ToString();
            // clientname1 = Request.QueryString["client"].ToString();
            page = Request.QueryString["page"].ToString();
            position = Request.QueryString["position"].ToString();
            // clientname = Request.QueryString["clientname"].ToString();
            //agname = Request.QueryString["agname"].ToString();
            //status1 = Request.QueryString["status1"].ToString();
            //status = Request.QueryString["status"].ToString();
            //adtypename = Request.QueryString["adtypename"].ToString();
            editionname = Request.QueryString["editionname"].ToString();
            positioncode = Request.QueryString["positioncode"].ToString();





            hiddendatefrom.Value = fromdt.ToString();
            hold = "abc";

            if (page == "0")
            {
                lblpagepr.Text = "ALL".ToString();
            }
            else
            {
                lblpagepr.Text = page.ToString();
            }
            if (position == "0")
            {
                lblposition.Text = "ALL".ToString();
            }
            else
            {
                lblposition.Text = positioncode.ToString();
            }
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

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                DateTime dt = System.DateTime.Now;

                day = dt.Date.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = day + "/" + month + "/" + year; 
                
            }
            else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
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
            //date = "";
            //if (dateto != "")
            //{
            //    DateTime dt = Convert.ToDateTime(dateto.ToString());
            //    if (hiddendateformat.Value == "dd/mm/yyyy")
            //    {
            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        date = day + "/" + month + "/" + year;
            //    }
            //    else if (hiddendateformat.Value == "mm/dd/yyyy")
            //    {
            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        date = month + "/" + day + "/" + year;
            //    }
            //    else if (hiddendateformat.Value == "yyyy/mm/dd")
            //    {
            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        date = year + "/" + month + "/" + day;
            //    }
            //}
            //lblto.Text = date;

            if (destination == "1" || destination == "0")
            {
                onscreen(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold);
            }
            else if (destination == "4")
            {
                excel(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold);
            }
            else
                if (destination == "3")
                {
                    pdf(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold);

                }
        }
    }
    //private void onscreen(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    private void onscreen(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold)    
    {
    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
    //ds = obj.spPagepremium(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
    int cont = ds.Tables[0].Rows.Count;
    int contc = ds.Tables[0].Columns.Count;
    string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
    tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
   
  

    if (hiddenascdesc.Value == "")
    {
        tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");
      
    }
    else if (hiddenascdesc.Value == "asc")
    {
        tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");
        
    }
    else if (hiddenascdesc.Value == "desc")
    {
        tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td> <td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td> <td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");
        
    }

    int i1 = 1;
  
        for (int i = 0; i <= cont - 1; i++)
    {
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");

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
            tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");            
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>"); 
          //  tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");


          
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BookDate"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[15].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[16].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PosPremium"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
    }
    tbl = tbl + ("<tr >");
    tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
    tbl = tbl + ("<tr >");

    tbl = tbl + ("<td class='middle13'>");
    tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
    tbl = tbl + ("<td class='middle13'>");
    tbl = tbl + ((i1 - 1).ToString() + "</td>");
    //tbl = tbl + ("<td class='middle13'>");
    //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
    //tbl = tbl + ("<td class='middle13'>");
    //tbl = tbl + (area.ToString() + "</td>");


    tbl = tbl + "</tr>";

    tbl = tbl + ("</table>");
    tblgrid.InnerHtml = tbl;
}

    private void excel(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold)
    {
        string strCurrentDir = Server.MapPath(".") + "\\";
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
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader=null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));   
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            myReader = obj.spPagepremiumexcel(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold);
            int iRow = 4;  //2
            oSheet.PageSetup.CenterFooter = "&P";



            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
                         for (int j = 0; j < myReader.FieldCount; j++)
                         {
                            
                             oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                             oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                             oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                             oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                             
                             oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                             oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                             //oSheet.Cells[3, 6] = myReader.GetName(4).ToString();
                             oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                             oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                             oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                             oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                             oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();
                            
                             oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[14].ToString();
                             oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                             oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                             oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                             oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                             //oSheet.Cells[3, 18] = myReader.GetName(19).ToString();
                             oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                             oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[35].ToString();
                             oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[36].ToString();
                         }                 
            oSheet.Cells.Font.Name = "verdana";
            oSheet.Cells.Font.Size = 7;          
           oRng = oSheet.get_Range("A3", "AB3");
           oRng.EntireColumn.AutoFit();
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
                    oSheet.Cells[iRow, 6] = myReader["City"].ToString();
                    //oSheet.Cells[iRow, 6] = myReader.GetValue(4).ToString();
                    oSheet.Cells[iRow, 7] = myReader["Package"].ToString();
                    oSheet.Cells[iRow, 8] = myReader["Depth"].ToString();
                    oSheet.Cells[iRow, 9] = myReader["Width"].ToString();
                    oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                    oSheet.Cells[iRow, 11] = myReader["Ins.No."].ToString();
                    oSheet.Cells[iRow, 12] = myReader["BookDate"].ToString();

                    oSheet.Cells[iRow, 13] = myReader["RoNo."].ToString();
                    oSheet.Cells[iRow, 14] = myReader["RoStatus"].ToString();
                    oSheet.Cells[iRow, 15] = myReader["AdType"].ToString();
                    oSheet.Cells[iRow, 16] = myReader["RateCode"].ToString();
                    //oSheet.Cells[iRow, 18] = myReader.GetValue(19).ToString();
                    oSheet.Cells[iRow, 17] = myReader["Status"].ToString();
                    oSheet.Cells[iRow, 18] = myReader["PagePremium"].ToString();
                    oSheet.Cells[iRow, 19] = myReader["PosPremium"].ToString();                  
                }
                iRow++;
            }


            oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
            oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);            
            oSheet.get_Range(row, row1).Font.Bold = true;
            myReader.Close();
            myReader = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment  = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "Q1").MergeCells = true;
            oSheet.get_Range("A1", "Q1").Font.Bold = true;
            oSheet.get_Range("A1", "Q1").Font.Size = 10;
            oSheet.get_Range("A3", "AB3").Font.Bold = true;
            oSheet.get_Range("A3", "AB3").Font.Size = 8;            
            oSheet.Cells.get_Range("A2", "Q2");
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
                Response.Redirect("pagepreviewreport.aspx");
            }
    }

       private void pdf(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold)    
        {
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
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
        int NumColumns = 19;        
        //---------------------------------
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 14, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);
        //----------------------------------------
        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);


            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[4].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);
            //-----------------------------------------------
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
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
           
            //float[] headerwidths = { 14, 14, 14, 21, 18, 18, 7, 7, 15, 15, 16, 14, 20, 20, 14, 16, 16, 18, 15, 16, 18, 14, 12, 14, 18, 9, 9 };
            //float[] headerwidths = { 12,12, 12, 14, 21, 18, 7, 7,18, 16, 20, 20, 15, 16, 18, 17,  18, 20, 18 }; // percentage
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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
          
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            //datatable.addCell(new Phrase("Area", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
            datatable.HeaderRows = 1;
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());            
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                //ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());

                
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adtype"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][19].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                //}               
                //}
            }

            document.Add(datatable);           

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
          tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 -1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
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
    protected void btnprint_Click(object sender, EventArgs e)
    {
        pdf1(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold);
    }
    private void pdf1(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
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
        int NumColumns = 19;
        //---------------------------------
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 14, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);
        //----------------------------------------
        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);


            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[4].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);
            //-----------------------------------------------
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
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;

            //float[] headerwidths = { 14, 14, 14, 21, 18, 18, 7, 7, 15, 15, 16, 14, 20, 20, 14, 16, 16, 18, 15, 16, 18, 14, 12, 14, 18, 9, 9 };
            //float[] headerwidths = { 12,12, 12, 14, 21, 18, 7, 7,18, 16, 20, 20, 15, 16, 18, 17,  18, 20, 18 }; // percentage
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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            //datatable.addCell(new Phrase("Area", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
            datatable.HeaderRows = 1;
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                //ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adtype"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][19].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                //}               
                //}
            }

            document.Add(datatable);

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            //float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16 }; // percentage
            //tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            document.Add(tbltotal);

            document.Close();
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
            //proc.StartInfo.Arguments = @"/p /hServer.MapPath(pdfName1)";
            proc.StartInfo.Arguments = @"/p /h" + Server.MapPath(pdfName1);            
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
            }
            //Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }
    private void drillonscreen(string page, string position, string client, string agency, string adtyp, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string status, string dateformate)
    {
        NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ds = obj.drilloutpage(page, position, clientname, agname, adtyp, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package,status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //ds = obj.spPagepremium(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";

        // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Hue</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>RateCode</td><td class='middle3'>Status</td><td class='middle3'>PagePremium</td><td class='middle3'>PosPremium</td></tr>");





        //           <td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td>
        //<td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td>
        //            <td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td>


        //           <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
        //<td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
        //            <td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td>



        //           <td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
        //<td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
        //            <td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td>

        //<td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
        //    <td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
        //        <td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td>



        //<td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td>
        //    <td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td>
        //        <td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td>



        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");

        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");

        }
        else if (hiddenascdesc.Value == "desc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td> <td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td> <td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");

        }

        int i1 = 1;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");

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
            tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");            
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");
            //  tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");



            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BookDate"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[15].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[16].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PosPremium"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (area.ToString() + "</td>");


        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
    
    }

    private void pdf_drillout(string page, string position, string client, string agency, string adtyp, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string status, string dateformate, string descid, string ascdesc)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
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
        int NumColumns = 19;
        //---------------------------------
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 14, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);
        //----------------------------------------
        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);


            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[4].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);
            //-----------------------------------------------
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
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;

            //float[] headerwidths = { 14, 14, 14, 21, 18, 18, 7, 7, 15, 15, 16, 14, 20, 20, 14, 16, 16, 18, 15, 16, 18, 14, 12, 14, 18, 9, 9 };
            //float[] headerwidths = { 12,12, 12, 14, 21, 18, 7, 7,18, 16, 20, 20, 15, 16, 18, 17,  18, 20, 18 }; // percentage
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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            //datatable.addCell(new Phrase("Area", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
            datatable.HeaderRows = 1;
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj.drilloutpage(page, position, clientname, agname, adtyp, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), descid, ascdesc);
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                //ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adtype"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][19].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                //}               
                //}
            }

            document.Add(datatable);

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
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
    private void excel_drillout(string page, string position, string client, string agency, string adtyp, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package,string status, string dateformate)
    {
        string strCurrentDir = Server.MapPath(".") + "\\";
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
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            myReader = obj.drillout_page(page, position, clientname, agname, adtyp, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            int iRow = 4;  //2
            oSheet.PageSetup.CenterFooter = "&P";



            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            for (int j = 0; j < myReader.FieldCount; j++)
            {

                oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();

                oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                //oSheet.Cells[3, 6] = myReader.GetName(4).ToString();
                oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[14].ToString();
                oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                //oSheet.Cells[3, 18] = myReader.GetName(19).ToString();
                oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[35].ToString();
                oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[36].ToString();
            }
            oSheet.Cells.Font.Name = "verdana";
            oSheet.Cells.Font.Size = 7;
            oRng = oSheet.get_Range("A3", "AB3");
            oRng.EntireColumn.AutoFit();
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
                    oSheet.Cells[iRow, 6] = myReader["City"].ToString();
                    //oSheet.Cells[iRow, 6] = myReader.GetValue(4).ToString();
                    oSheet.Cells[iRow, 7] = myReader["Package"].ToString();
                    oSheet.Cells[iRow, 8] = myReader["Depth"].ToString();
                    oSheet.Cells[iRow, 9] = myReader["Width"].ToString();
                    oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                    oSheet.Cells[iRow, 11] = myReader["Ins.No."].ToString();
                    oSheet.Cells[iRow, 12] = myReader["BookDate"].ToString();

                    oSheet.Cells[iRow, 13] = myReader["RoNo."].ToString();
                    oSheet.Cells[iRow, 14] = myReader["RoStatus"].ToString();
                    oSheet.Cells[iRow, 15] = myReader["AdType"].ToString();
                    oSheet.Cells[iRow, 16] = myReader["RateCode"].ToString();
                    //oSheet.Cells[iRow, 18] = myReader.GetValue(19).ToString();
                    oSheet.Cells[iRow, 17] = myReader["Status"].ToString();
                    oSheet.Cells[iRow, 18] = myReader["PagePremium"].ToString();
                    oSheet.Cells[iRow, 19] = myReader["PosPremium"].ToString();
                }
                iRow++;
            }


            oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
            oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);
            oSheet.get_Range(row, row1).Font.Bold = true;
            myReader.Close();
            myReader = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "Q1").MergeCells = true;
            oSheet.get_Range("A1", "Q1").Font.Bold = true;
            oSheet.get_Range("A1", "Q1").Font.Size = 10;
            oSheet.get_Range("A3", "AB3").Font.Bold = true;
            oSheet.get_Range("A3", "AB3").Font.Size = 8;
            oSheet.Cells.get_Range("A2", "Q2");
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
            Response.Redirect("pagepreviewreport.aspx");
        }
    }
}