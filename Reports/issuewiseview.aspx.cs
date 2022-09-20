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
//using System.Text.RegularExpressions;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;
//using System.Web.UI.WebControls;
//using System.Drawing;
//using System.Diagnostics.Design;
using iTextSharp.text.pdf.wmf;




public partial class issuewiseview : System.Web.UI.Page
{
    double[] value;
    double[] value1;
    double[] value2;
    double[] value_main;
    double temp_tot = 0;
    double var1 = 0;
    double vared1 = 0;
    double temp_tot34 = 0;
    double temp_tot35 = 0;
    double temp_tot36 = 0;
    double varmained1 = 0;
    double varpub1 = 0;
    string h1 = "";
    string h2 = "";
    double h3 = 0;
    string h4 = "";
    int s = 0;
    int mn = 0;
    int n = 0;
    string d = "";
    string ratio_name = "";
    string extra1 = "";
    string tbl = "";
   string extra2 = "";
    string fromdate = "", dateto = "", destination = "", pubcentcode = "", edition = "", editionname = "", pubcentname = "";
    string day = "", month = "", year = "", Run_Date = "", ratio_type = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("../login.aspx");
        }

        ds = (DataSet)Session["issueprintcent"];
        string prm = Session["prm_issueprintcent"].ToString();
        string[] prm_Array = new string[17];
        prm_Array = prm.Split('~');


        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdate = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcentcode = prm_Array[7]; //Request.QueryString["pubcentcode"].ToString();
        edition = prm_Array[9]; //Request.QueryString["edition"].ToString();
        editionname = prm_Array[11]; //Request.QueryString["editionname"].ToString();
        pubcentname = prm_Array[13]; //
        chk_excel = prm_Array[15];
        
        ratio_type = prm_Array[17];
        extra2 = prm_Array[21]; ;
        ratio_name = prm_Array[23];
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();

       
        lblFDate.Text = fromdate;
        lblTDate.Text = dateto;
             
        DataSet dsx = new DataSet();
        dsx.ReadXml(Server.MapPath("XML/RPt_Daily_listing.xml"));

        lblHeading.Text = dsx.Tables[3].Rows[0].ItemArray[2].ToString();
        lblFromDate.Text = dsx.Tables[1].Rows[0].ItemArray[1].ToString();
        lblToDate.Text = dsx.Tables[1].Rows[0].ItemArray[2].ToString();
        lblpubcent.Text = dsx.Tables[3].Rows[0].ItemArray[3].ToString();
        lbledition.Text = dsx.Tables[3].Rows[0].ItemArray[4].ToString();
        lblRunningDate.Text = dsx.Tables[1].Rows[0].ItemArray[6].ToString();
     

            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {
                DateTime dt = System.DateTime.Now;
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = day + "/" + month + "/" + year;

            }
            else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {
                DateTime dt = System.DateTime.Now;
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = month + "/" + day + "/" + year;

            }
            else if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
            {
                DateTime dt = System.DateTime.Now;
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = year + "/" + month + "/" + day;

            }

//        lblRundate.Text = Run_Date.Substring(0, 9);
            if (Run_Date.Length > 9)
            {
                lblRundate.Text = Run_Date.Substring(0, 9);
            }
            else
            {
                lblRundate.Text = Run_Date;
            }
            if (!Page.IsPostBack)
            {
                if (destination == "On Screen" || destination == "---Select Report---" || destination == "1" || destination == "0")
                {
                    onscreen(hiddencomcode.Value, fromdate, dateto, pubcentcode, edition, hiddendateformat.Value, hiddenuserid.Value);
                }
                if (destination == "PDF" || destination == "3")
                {
                    pdf(hiddencomcode.Value, fromdate, dateto, pubcentcode, edition, hiddendateformat.Value, hiddenuserid.Value);
                }
                if (destination == "Excel File" || destination == "4")
                {
                    xls(hiddencomcode.Value, fromdate, dateto, pubcentcode, edition, hiddendateformat.Value, hiddenuserid.Value);
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
    private void pdf(string compcode, string fromdate, string dateto, string pubcentcode, string edition, string dateformat, string userid)
    {

        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.issuereport(Session["compcode"].ToString(), fromdate, dateto, pubcentcode, edition, dateformat, Session["userid"].ToString());
        //}

        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;


        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------
        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Record Not Found")
        {
            return;
        }
        string code_find = ds.Tables[0].Rows[0]["MAIN_EDTN_NAME"].ToString();
        int NumColumns = ds.Tables[0].Columns.Count - 3;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

           
          

            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[1].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new Phrase("Issue Wise Printing Center Wise Business Report", font9));
           
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
           
            for (int i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(3);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.WidthPercentage = 100;
           float[] xy12 = { 15, 20, 15 };
           tbl2.setWidths(xy12);
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl2.addCell(new Phrase("From Date" + fromdate, font10));           
            tbl2.addCell(new Phrase("To Date" + dateto, font10));           
            if (Run_Date.IndexOf(" ") > -1)
                Run_Date = Run_Date.Substring(0, 9).ToString();
            tbl2.addCell(new Phrase("Run Date" + Run_Date, font10));        
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            PdfPTable tbl45 = new PdfPTable(3);
            tbl45.DefaultCell.BorderWidth = 0;
            //tbl2.WidthPercentage = 100;
            float[] xy45 = { 15, 20, 15 };
            tbl45.setWidths(xy45);         
            tbl45.WidthPercentage = 100;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            string rt = "";
            if (ratio_name == "" || ratio_name == "0")
            {
                rt = "All";

            }
            else
            {
                rt = ratio_name;
            }
            string pub = "";
            if (pubcentname == "Select Printing Center" || pubcentname == "0")
            {
                pub = "All";

            }
            else
            {
                pub = pubcentname;
            }
            string ed = "";
            if (edition == "-Select Edition-" || edition == "0")
            {
                ed = "All";

            }
            else
            {
                ed = edition;
            }
            tbl45.addCell(new Phrase("Ratio Type:" + rt, font10));
            tbl45.addCell(new Phrase("Printing Center:" + pub, font10));
            tbl45.addCell(new Phrase("Edition Name:" + ed, font10));
            document.Add(tbl45);

            iTextSharp.text.Phrase p331 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p331);



            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //float[] xy893 = { 5, 15, 20,15,15,15,15,15,15,15,15,15 };
            //datatable.setWidths(xy893);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase("S.No.", font10));
            string[] str;
            for (int i = 2; i < ds.Tables[0].Columns.Count - 2; i++)
            {


                str = ds.Tables[0].Columns[i].ToString().Split('#');



                //          if (i < 4)
                //    {

                //        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //        datatable.addCell(new Phrase(ds.Tables[0].Columns[i].ToString(), font10));

                //    }
                //    else 
                //    {
                //        if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)

                //        {

                //          datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                //            string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                //            //tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                //            if (i % 3 == 0)

                //           datatable.addCell(new Phrase((str[1].ToString()), font10));

                //       datatable.addCell(new Phrase("\n", font10));
                //            if (str[0].ToString() == "D")
                //            {
                //               datatable.addCell(new Phrase("Display", font10));
                //            }
                //            if (str[0].ToString() == "L")
                //            {
                //                datatable.addCell(new Phrase("Lineage", font10));
                //                //tbl = tbl + "Lineage" + "&nbsp;&nbsp;";
                //            }
                //            if (str[0].ToString() == "A")
                //            {
                //                datatable.addCell(new Phrase("Amount", font10));
                //                //tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                //            }
                //           // tbl = tbl + "</td>";

                //        }
                //    }


                //}
                //for (int i = 22; i < ds.Tables[0].Columns.Count - 2; i++)
                //{
                //    if (i >9)
                //    {
                //         datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                //        datatable.addCell(new Phrase(ds.Tables[0].Columns[i].ToString(), font10));
                //    }
                //}
                if (i < 4)
                {
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                }
                else
                {
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                }
                if (ds.Tables[0].Columns[i].ToString() == "TOT")
                    datatable.addCell(new Phrase("Total", font10));
                else
                if (ds.Tables[0].Columns[i].ToString() == "edtn_name")
                    datatable.addCell(new Phrase("Edition", font10));
                else
                {
                    if (str.Length >= 2)
                        datatable.addCell(new Phrase(""+str[1], font10));
                    else
                        datatable.addCell(new Phrase(ds.Tables[0].Columns[i].ToString(), font10));
                }
            }
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new Phrase("________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            int sn = 0;
            int controw = ds.Tables[0].Rows.Count;
            int contcol = ds.Tables[0].Columns.Count;
            value = new double[ds.Tables[0].Columns.Count];
            value1 = new double[ds.Tables[0].Columns.Count];
            value2 = new double[ds.Tables[0].Columns.Count];
            value_main = new double[ds.Tables[0].Columns.Count];
            for (int i = 0; i < controw; i++)
            {

                string route_code = ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString();

                sn = i + 1;
                //////////////MAIN EDIITION TOTAL


                if (code_find.IndexOf(route_code) < 0)
                {
                    datatable.DefaultCell.Colspan = 3;
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase("Total Edition", font10));
                    datatable.DefaultCell.Colspan = 1;

                  
                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {

                        varmained1 = 0;

                        for (int v = mn; v <= (i - 1); v++)
                        {
                            double vared2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                varmained1 = varmained1 + vared2;
                            }

                        }

                        value_main[m] = varmained1;
                    }
                    mn = (i - 1) + 1;


                    for (int x = 4; x < value_main.Length - 2; x++)
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        //if (value_main[x].ToString() == "")
                        //    datatable.addCell(new Phrase("", font10));
                        //else
                            datatable.addCell(new Phrase(chk_null(value_main[x].ToString()), font10));


                        
                    }
                    for (int x = 4; x < value_main.Length - 2; x++)
                    {
                        value_main[x] = 0;
                    }

                    

                    code_find += ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString() + "~";
                }


                ////MAIN EDITION TOTAL

                if (i > 0)
                {
                   
                    if (ds.Tables[0].Rows[i - 1]["Publication"].ToString() != ds.Tables[0].Rows[i]["Publication"].ToString())
                    {
                        
                        datatable.DefaultCell.Colspan = 3;
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        datatable.addCell(new Phrase("Total Publication", font10));
                        datatable.DefaultCell.Colspan = 1;
                        for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                        {

                            varpub1 = 0;

                            for (int v = n; v < i; v++)
                            {
                                double varpub2 = 0;

                                if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                                {
                                    varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                    varpub1 = varpub1 + varpub2;
                                }

                            }

                            value2[m] = varpub1;
                        }
                        n = i;


                        for (int x = 4; x < value2.Length - 2; x++)
                        {
                            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            //if(value2[x].ToString()=="")
                            //    datatable.addCell(new Phrase("", font10));
                            //else
                            datatable.addCell(new Phrase(chk_null(value2[x].ToString()), font10));
                        }
                        for (int x = 4; x < value2.Length - 2; x++)
                        {
                            value2[x] = 0;
                        }
                       
                    }
                }

                for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                {
                    var1 = 0;
                    vared1 = 0;
                    varmained1 = 0;
                    varpub1 = 0;
                    for (int v = 0; v < ds.Tables[0].Rows.Count; v++)
                    {
                        double var2 = 0;

                        if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                        {
                            var2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                            var1 = var1 + var2;


                        }

                    }
                    value[m] = var1;
                    value2[m] = varpub1;
                }


                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.addCell(new Phrase(sn.ToString(), font10));

                
                for (int y = 2; y < contcol - 2; y++)
                {

                    if (y < 4)
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        if (ds.Tables[0].Rows[i].ItemArray[y].ToString() == "")
                            datatable.addCell(new Phrase("", font10));
                        else
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[i].ItemArray[y].ToString(), font10));
                    }
                    else
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                       
                            datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[i].ItemArray[y].ToString()), font10));
                    }
                   
                    
                }
             

                
                if (i == controw - 1)
                {
                    datatable.DefaultCell.Colspan = 3;
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase("Total Edition", font10));
                    datatable.DefaultCell.Colspan = 1;

                   
                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {

                        varmained1 = 0;

                        for (int v = mn; v <= i; v++)
                        {
                            double vared2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                varmained1 = varmained1 + vared2;
                            }

                        }

                        value_main[m] = varmained1;
                    }
                    mn = i + 1;


                    for (int x = 4; x < value_main.Length - 2; x++)
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                       
                            datatable.addCell(new Phrase(chk_null(value_main[x].ToString()), font10));

                       
                    }
                    for (int x = 4; x < value_main.Length - 2; x++)
                    {
                        value_main[x] = 0;
                    }

                   

                    code_find += ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString() + "~";

                    ////publication

                    datatable.DefaultCell.Colspan = 3;
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase("Total Publication", font10));
                    datatable.DefaultCell.Colspan = 1;
                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {

                        varpub1 = 0;

                        for (int v = n; v <= i; v++)
                        {
                            double varpub2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                varpub1 = varpub1 + varpub2;
                            }

                        }

                        value2[m] = varpub1;
                    }
                    n = i+1;


                    for (int x = 4; x < value2.Length - 2; x++)
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        //if(value2[x].ToString()=="")
                        //    datatable.addCell(new Phrase("", font10));
                        //else
                        datatable.addCell(new Phrase(chk_null(value2[x].ToString()), font10));
                    }
                    for (int x = 4; x < value2.Length - 2; x++)
                    {
                        value2[x] = 0;
                    }

                    ////publication

                }


            }

            datatable.DefaultCell.Colspan = 3;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase("Total Business", font10));
            datatable.DefaultCell.Colspan = 1;
            
            for (int x = 4; x < value.Length - 2; x++)
            {
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
               
                datatable.addCell(new Phrase(chk_null(value[x].ToString()), font10));
                
            }
           
            for (int g = 0; g < ds.Tables[1].Rows.Count; g++)
            {
                int dse=g+1;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.addCell(new Phrase(dse.ToString(), font10));
                
                for (int h = 1; h < ds.Tables[1].Columns.Count; h++)
                {

                    if (h == 1)
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                        if (ds.Tables[1].Rows[g].ItemArray[h].ToString() == "")
                        {
                            
                            datatable.addCell(new Phrase("", font10));
                            
                            datatable.addCell(new Phrase("", font10));
                            
                        }
                        else
                        {
                            
                            datatable.addCell(new Phrase(ds.Tables[1].Rows[g].ItemArray[h].ToString(), font10));
                            datatable.addCell(new Phrase(ds.Tables[1].Rows[g].ItemArray[h].ToString(), font10));
                            
                        }

                                              
                    }
                    else
                    {
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        if (ds.Tables[1].Rows[g].ItemArray[h].ToString() == "")
                        {
                            datatable.addCell(new Phrase(chk_null("0"), font10));

                        }
                        else
                        {
                            datatable.addCell(new Phrase(chk_null(ds.Tables[1].Rows[g].ItemArray[h].ToString()), font10));
                        }

                        //if (h == ds.Tables[1].Columns.Count - 1)
                        //{
                        //    datatable.addCell(new Phrase("", font10));
                        //}



                        if (ds.Tables[1].Rows[g].ItemArray[h].ToString() != "")

                            if (extra2 == "O")
                            {

                                temp_tot = temp_tot + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                            }
                        if (extra2 == "W")
                        {

                            if (ds.Tables[1].Columns[h].ToString().IndexOf("#") > -1)
                            {
                                string[] abc = ds.Tables[1].Columns[h].ToString().Split('#');

                                if (abc[0].ToString() == "D")
                                {

                                    temp_tot34 = temp_tot34 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());

                                }
                                if (abc[0].ToString() == "L")
                                {
                                    temp_tot35 = temp_tot35 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());

                                }
                                if (abc[0].ToString() == "A")
                                {
                                    temp_tot36 = temp_tot36 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());

                                }

                            }
                        }
                    }
                }
                if (extra2 == "O")
                {
                    datatable.addCell(new Phrase(chk_null(temp_tot.ToString()), font10));
                }
                if (extra2 == "W")
                {
                    datatable.addCell(new Phrase(chk_null(temp_tot34.ToString()), font10));
                    datatable.addCell(new Phrase(chk_null(temp_tot35.ToString()), font10));
                    datatable.addCell(new Phrase(chk_null(temp_tot36.ToString()), font10));
                }
                temp_tot34 = 0;
                temp_tot35 = 0;
                temp_tot36 = 0;
                temp_tot = 0;
    //        if (ds.Tables[1].Rows[g].ItemArray[h].ToString() != "")
    //            temp_tot = temp_tot + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());



    //    }





    //}
    //datatable.addCell(new Phrase(chk_null(temp_tot.ToString()), font10));
    temp_tot = 0;       
               
            }
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new Phrase("__________________________________________________________________________________________________________________________________________________________", font10));
          
            datatable.DefaultCell.Colspan = 3;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase("Total Business", font10));
            datatable.DefaultCell.Colspan = 1;

            
            for (int x = 4; x < value.Length - 2; x++)
            {
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
               
                datatable.addCell(new Phrase(chk_null(value[x].ToString()), font10));
                
            }
            


            document.Add(datatable);
            Phrase p3 = (new Phrase("__________________________________________________________________________________________________________________________________________________________", font10));


            document.Add(p3);
            document.Close();
            Response.Redirect(pdfName);



        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }

    }
      private void onscreen(string compcode,string fromdate,string dateto,string pubcentcode,string edition,string dateformat,string userid)
    {
        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Record Not Found")
        {
            return;
        }
      string code_find = ds.Tables[0].Rows[0]["MAIN_EDTN_NAME"].ToString();
      string taluka_find = "";
       //DataSet ds = new DataSet();

       //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
       //{
       //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
       //    ds = obj.issuereport(Session["compcode"].ToString(), fromdate, dateto, pubcentcode, edition, dateformat, Session["userid"].ToString());
       //}

    
            cmpnyname.Text = ds.Tables[1].Rows[0]["companyname"].ToString();
            int controw = ds.Tables[0].Rows.Count;
            int contcol = ds.Tables[0].Columns.Count;
        //string tbl = "";
        int j = 4;
        tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td>";
        tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + Run_Date + "</td></tr>";
        string rt = "";
        if (ratio_name == "" || ratio_name == "0")
        {
            rt = "All";

        }
        else
        {
            rt = ratio_name;
        }
        string pub = "";
        if (pubcentname == "Select Printing Center" || pubcentname == "0")
        {
            pub = "All";

        }
        else
        {
            pub = pubcentname;
        }
        string ed = "";
        if (edition == "-Select Edition-" || edition == "0")
        {
            ed = "All";

        }
        else
        {
            ed = edition;
        }
        tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Ratio Type:</b>" + rt + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + pub + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + ed + "</td></tr>";
        tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>";
        tbl = tbl + ("<td class='middle31new'  align='left'>");
        tbl = tbl + ("<tr><td class='middle31new'>S.No.</td>");
        //tbl = tbl + ("<td class='middle31new'  align='left'>");
        tbl = tbl + ("<td class='middle31new'>Edition</td>");
        //tbl = tbl + ("<td class='middle31new'  align='left'>");
        tbl = tbl + ("<td class='middle31new'>Printing Center</td>");
        if (extra2 == "W")
        {
            for (int i = 4; i < ds.Tables[0].Columns.Count - 2; i++)
            {
                if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                    {

                        tbl = tbl + ("<td class='middle31new' align='center' >");

                        string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                        //tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                        //if (i % 3 == 0)

                        if (i == j + 1)
                        {

                            tbl = tbl + (str[1].ToString());
                            j = j + 3;
                        }
                        else
                        {
                        }
                        //tbl = tbl + (str[1].ToString());


                        tbl = tbl + "</br>";
                        if (str[0].ToString() == "D")
                        {
                            tbl = tbl + "Display" + "&nbsp;&nbsp;";
                        }
                        if (str[0].ToString() == "L")
                        {
                            tbl = tbl + "Lineage" + "&nbsp;&nbsp;";
                        }
                        if (str[0].ToString() == "A")
                        {
                            tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                        }
                        tbl = tbl + "</td>";

                    }
                    else
                    {
                        tbl = tbl + ("<td class='middle31new' align='right'>");
                        tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                    }
             

            }
            
         
            tbl = tbl + ("</tr>");
       }
         else if (extra2 == "O")
        {
            for (int i = 4; i < ds.Tables[0].Columns.Count - 2; i++)
            {
                    if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                    {

                        tbl = tbl + ("<td class='middle31new' align='right' >");

                        string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                       

                        tbl = tbl + (str[1].ToString());
                        tbl = tbl + "</br>";
                        if (str[0].ToString() == "A")
                        {
                            tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                            tbl = tbl + "</td>";

                        }
                    }
                    else
                    {
                        tbl = tbl + ("<td class='middle31new' align='right'>");
                        if (ds.Tables[0].Columns[i].ToString()=="TOT")
                        tbl = tbl + ("Total" + "</td>");
                        else
                            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                    }

            }
           
            tbl = tbl + ("</tr>");
       }
          ////////////////////////////////////////
      
          int sn=0;

          value = new double[ds.Tables[0].Columns.Count];
          value1 = new double[ds.Tables[0].Columns.Count];
          value2 = new double[ds.Tables[0].Columns.Count];
          value_main = new double[ds.Tables[0].Columns.Count];
        for (int i = 0; i < controw; i++)
        {
            string route_code = ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString();
            
           
            sn=i+1;
            //////////////MAIN EDIITION TOTAL

           
            if (code_find.IndexOf(route_code) < 0)
            {
                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td colspan='3' align='left' class='middle31new'>Total Edition");
                tbl = tbl + ("</td>");
                for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                {

                    varmained1 = 0;

                    for (int v = mn; v <= (i - 1); v++)
                    {
                        double vared2 = 0;

                        if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                        {
                            vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                            varmained1 = varmained1 + vared2;
                        }

                    }

                    value_main[m] = varmained1;
                }
                mn = (i - 1) + 1;


                for (int x = 4; x < value_main.Length - 2; x++)
                {
                    tbl = tbl + "<td  align='right' class='middle31new'>" + chk_null(value_main[x].ToString()) + "</td>";
                }
                for (int x = 4; x < value_main.Length - 2; x++)
                {
                    value_main[x] = 0;
                }

                tbl = tbl + ("</tr>");

                code_find += ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString() + "~";
            }


            ////MAIN EDITION TOTAL
            if (i > 0)
            {
                if (ds.Tables[0].Rows[i - 1]["Publication"].ToString() != ds.Tables[0].Rows[i]["Publication"].ToString())
                {
                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td colspan='3' class='middle31new12' align='left'>Total Publication");
                    tbl = tbl + ("</td>");
                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {

                        varpub1 = 0;

                        for (int v = n; v < i; v++)
                        {
                            double varpub2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                varpub1 = varpub1 + varpub2;
                            }

                        }

                        value2[m] = varpub1;
                    }
                    n = i ;


                    for (int x = 4; x < value2.Length - 2; x++)
                    {
                        tbl = tbl + "<td  class='middle31new12'  align='right'>" + chk_null(value2[x].ToString()) + "</td>";
                    }
                    for (int x = 4; x < value2.Length - 2; x++)
                    {
                        value2[x] = 0;
                    }
                    tbl = tbl + ("</tr>");
                }
                
            }
           
            
                for (int m = 4; m < ds.Tables[0].Columns.Count-2; m++)
                {
                    var1 = 0;
                    vared1 = 0;
                    varmained1 = 0;
                    varpub1 = 0;
                    for (int v = 0; v < ds.Tables[0].Rows.Count; v++)
                    {
                        double var2 = 0;
                      
                        if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                        {
                            var2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                            var1 = var1 + var2;

                           
                        }
                       
                    }
                    value[m] = var1;
                    value2[m] = varpub1;
                }

                
                
            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td class='rep_data'>" + sn.ToString() + "</td>");
            for (int y = 2; y < contcol-2; y++)
            {

                if (y < 4)
                {
                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[y].ToString() + "</td>");
                }
                else
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");


                    tbl = tbl + (chk_null(ds.Tables[0].Rows[i].ItemArray[y].ToString()) + "</td>");
                }
                   
                    
            }
            tbl = tbl + ("</tr>");



            
            //////////////MAIN EDIITION TOTAL
            if (i == controw - 1)
            {
               

                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td colspan='3' align='left' class='middle31new'>Total Edition");
                    tbl = tbl + ("</td>");
                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {

                        varmained1 = 0;

                        for (int v = mn; v <= i ; v++)
                        {
                            double vared2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                varmained1 = varmained1 + vared2;
                            }

                        }

                        value_main[m] = varmained1;
                    }
                    mn = i  + 1;


                    for (int x = 4; x < value_main.Length - 2; x++)
                    {
                        tbl = tbl + "<td  align='right' class='middle31new'>" + chk_null(value_main[x].ToString()) + "</td>";
                    }
                    for (int x = 4; x < value_main.Length - 2; x++)
                    {
                        value_main[x] = 0;
                    }

                    tbl = tbl + ("</tr>");

                    code_find += ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString() + "~";
                

                //////////////////////////////publication
                    
                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td colspan='3' class='middle31new12' align='left'>Total Publication");
                        tbl = tbl + ("</td>");
                        for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                        {

                            varpub1 = 0;

                            for (int v = n; v <= i; v++)
                            {
                                double varpub2 = 0;

                                if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                                {
                                    varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                    varpub1 = varpub1 + varpub2;
                                }

                            }

                            value2[m] = varpub1;
                        }
                        n = i+1;


                        for (int x = 4; x < value2.Length - 2; x++)
                        {
                            tbl = tbl + "<td  class='middle31new12'  align='right'>" + chk_null(value2[x].ToString()) + "</td>";
                        }
                        for (int x = 4; x < value2.Length - 2; x++)
                        {
                            value2[x] = 0;
                        }
                        tbl = tbl + ("</tr>");

                ////publication
                   
               
            }
            ////MAIN EDITION TOTAL
            rptDiv.InnerHtml += tbl;
            tbl = "";
          
        }

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td colspan='3' class='middle31new12' align='left'>Total Business");
        for (int x = 4; x < value.Length - 2; x++)
        {
            tbl = tbl + "<td class='middle31new12' align='right'>" + chk_null(value[x].ToString()) + "</td>";
        }
        tbl = tbl + ("</tr>");
        tbl = tbl + ("<tr rowspan='3'></tr>");
      
        for (int g = 0; g < ds.Tables[1].Rows.Count; g++)
        {

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td class='rep_data'>" + (g + 1) + "</td>");
            for (int h = 1; h < ds.Tables[1].Columns.Count ; h++)
            {

                if (h == 1)
                {
                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[1].Rows[g].ItemArray[h].ToString() + "</td>");

                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[1].Rows[g].ItemArray[h].ToString() + "</td>");
                }
                else
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(ds.Tables[1].Rows[g].ItemArray[h].ToString()) + "</td>");
                  
                       
                        if (extra2 == "O")
                        {
                            
                            temp_tot = temp_tot + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                        }
                    if (extra2 == "W")
                    {
                        
                                if (ds.Tables[1].Columns[h].ToString().IndexOf("#") > -1)
                                {
                                    string[] abc = ds.Tables[1].Columns[h].ToString().Split('#');

                                    if (abc[0].ToString() == "D")
                                    {
                                      
                                        temp_tot34 = temp_tot34 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                                        
                                    }
                                    if (abc[0].ToString() == "L")
                                    {
                                        temp_tot35 = temp_tot35 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                                       
                                    }
                                    if (abc[0].ToString() == "A")
                                    {
                                        temp_tot36 = temp_tot36 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                                       
                                    }

                                }                  
                    }
                }
            }
            if (extra2 == "O")
            {
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot.ToString()) + "</td>");
            }
            if (extra2 == "W")
            {
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot34.ToString()) + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot35.ToString()) + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot36.ToString()) + "</td>");
            }
            temp_tot34 = 0;
            temp_tot35 = 0;
            temp_tot36 = 0;
            temp_tot = 0;
            tbl = tbl + ("</tr>");
        }

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td colspan='3' class='middle31new' align='left'>Total Business");
        for (int x = 4; x < value.Length - 2; x++)
        {
            tbl = tbl + "<td class='middle31new' align='right'>" +chk_null(value[x].ToString()) + "</td>";
        }
        tbl = tbl + ("</tr>");
        tbl = tbl + ("<tr rowspan='3'></tr>");
  
        tbl = tbl + ("</table>");
        rptDiv.InnerHtml += tbl;
       
       
    }
    private void xls(string compcode, string fromdate, string dateto, string pubcentcode, string edition, string dateformat, string userid)
    {


        //DataSet ds = new DataSet();

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.issuereport(Session["compcode"].ToString(), fromdate, dateto, pubcentcode, edition, dateformat, Session["userid"].ToString());
        //}

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        //if (chk_excel == "1")
        //{
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        //}
        //else
        //{
        //    Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        //}
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Record Not Found")
            {
                return;
            }
            string code_find = ds.Tables[0].Rows[0]["MAIN_EDTN_NAME"].ToString();
        int controw = ds.Tables[0].Rows.Count;
        int contcol = ds.Tables[0].Columns.Count;
        //string tbl = "";
        tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'>";
        tbl = tbl + ("<tr><td align='center' colspan='4'><b>" + ds.Tables[1].Rows[0]["companyname"].ToString() + "</b></td></tr>");
        tbl = tbl + ("<tr><td align='center' colspan='4'><b>Issue Wise Printing Center Wise Business Report</b></td></tr>");
        tbl = tbl + ("<tr></tr>");
        tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td>";
        tbl = tbl + "<td  colspan='2'align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + Run_Date + "</td></tr>";
        string rt = "";
        if (ratio_name == "" || ratio_name == "0")
        {
            rt = "All";

        }
        else
        {
            rt = ratio_name;
        }
        string pub = "";
        if (pubcentname == "Select Printing Center" || pubcentname == "0")
        {
            pub = "All";

        }
        else
        {
            pub = pubcentname;
        }
        string ed = "";
        if (edition == "-Select Edition-" || edition == "0")
        {
            ed = "All";

        }
        else
        {
            ed = edition;
        }
        tbl = tbl + "<tr><td colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>Ratio Type:</b>" + rt + "</td>";
        tbl = tbl + "<td colspan='2'align='left'style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + pub + "</td>";
        tbl = tbl + "<td colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + ed + "</td></tr>";
        tbl = tbl + ("<tr><td class='middle31new'><b>S.No.</b></td>");
        tbl = tbl + ("<td class='middle31new'><b>Edition</b></td>");
        //tbl = tbl + ("<td class='middle31new'  align='left'>");
        tbl = tbl + ("<td class='middle31new'><b>Printing Center</b></td>");
       int j = 4;
        if (extra2 == "W")
        {
           for (int i = 4; i < ds.Tables[0].Columns.Count - 2; i++)
            {
           
                if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                {

                    string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                 
                    if (i == j)
                    {
                        tbl = tbl + ("<td class='middle31new'colspan='3' align='center'>");
                        tbl = tbl + (str[1].ToString());
                        j = j + 3;
                    }
                   
                    else
                    {
                       
                    }

                }
                else
                {
                    tbl = tbl + ("<td class='middle31new' align='right'>");
                       tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                }

                }

            tbl = tbl + ("</tr>");
            for (int i = 1; i < ds.Tables[0].Columns.Count - 2; i++)
            {
                tbl = tbl + ("<td class='middle31new'  align='left' >");

                string[] abc = ds.Tables[0].Columns[i].ToString().Split('#');
                if (abc[0].ToString() == "D")
                {
                    tbl = tbl + "Display" + "&nbsp;&nbsp;";
                }
                if (abc[0].ToString() == "L")
                {
                    tbl = tbl + "Lineage" + "&nbsp;&nbsp;";
                }
                if (abc[0].ToString() == "A")
                {
                    tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                }
                tbl = tbl + "</td>";
            }
        }
    
        else if(extra2=="O")
        {
          
            for (int i = 4; i < ds.Tables[0].Columns.Count - 2; i++)
            {

                if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                {

                    tbl = tbl + ("<td class='middle31new' align='right' >");

                    string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                    if (str[0].ToString() == "A")
                    {
                        tbl = tbl + (str[1].ToString());
                    }
                }
                else
                {
                    tbl = tbl + ("<td class='middle31new' align='right'>");
                     tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                }
                
            }
         
            tbl = tbl + ("</tr>");
              for (int i = 1; i < ds.Tables[0].Columns.Count - 2; i++)
            {
                tbl = tbl + ("<td class='middle31new'  align='right' >");

                string[] abc = ds.Tables[0].Columns[i].ToString().Split('#');
          
                if (abc[0].ToString() == "A")
                {
                    tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                }
                tbl = tbl + "</td>";
            }
        }
        
        int sn = 0;

        value = new double[ds.Tables[0].Columns.Count];
        value1 = new double[ds.Tables[0].Columns.Count];
        value2 = new double[ds.Tables[0].Columns.Count];
        value_main = new double[ds.Tables[0].Columns.Count];
        for (int i = 0; i < controw; i++)
        {

            string route_code = ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString();

            sn = i + 1;
            //////////////MAIN EDIITION TOTAL


            if (code_find.IndexOf(route_code) < 0)
            {
                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td colspan='3' align='left' class='rep_datas'>Total Edition");
                tbl = tbl + ("</td>");
                for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                {

                    varmained1 = 0;

                    for (int v = mn; v <= (i - 1); v++)
                    {
                        double vared2 = 0;

                        if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                        {
                            vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                            varmained1 = varmained1 + vared2;
                        }

                    }

                    value_main[m] = varmained1;
                }
                mn = (i - 1) + 1;


                for (int x = 4; x < value_main.Length - 2; x++)
                {
                    tbl = tbl + "<td  align='right' class='rep_datas'>" +chk_null(value_main[x].ToString()) + "</td>";
                }
                for (int x = 4; x < value_main.Length - 2; x++)
                {
                    value_main[x] = 0;
                }

                tbl = tbl + ("</tr>");

                code_find += ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString() + "~";
            }

            if (i > 0)
            {
                if (ds.Tables[0].Rows[i - 1]["Publication"].ToString() != ds.Tables[0].Rows[i]["Publication"].ToString())
                {
                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td colspan='3' class='middle31new' align='left'><b>Total Publication</b>");
                   
                    tbl = tbl + ("</td>");
                   // name1 = name1 + "," + "Total Publication";
                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {

                        varpub1 = 0;

                        for (int v = n; v < i; v++)
                        {
                            double varpub2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                varpub1 = varpub1 + varpub2;
                            }

                        }

                        value2[m] = varpub1;
                    }
                    n = i;


                    for (int x = 4; x < value2.Length - 2; x++)
                    {
                        tbl = tbl + "<td  class='middle31new'  align='right'><b>" + chk_null(value2[x].ToString()) + "</b></td>";
                    }
                    for (int x = 4; x < value2.Length - 2; x++)
                    {
                        value2[x] = 0;
                    }
                    tbl = tbl + ("</tr>");
                }
            }

            for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
            {
                var1 = 0;
                vared1 = 0;
                varmained1 = 0;
                varpub1 = 0;
                for (int v = 0; v < ds.Tables[0].Rows.Count; v++)
                {
                    double var2 = 0;

                    if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                    {
                        var2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                        var1 = var1 + var2;


                    }

                }
                value[m] = var1;
                value2[m] = varpub1;
            }



            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td class='rep_data'>" + sn.ToString() + "</td>");
            for (int y = 2; y < contcol - 2; y++)
            {

                if (y < 4)
                {
                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[y].ToString() + "</td>");
                }
                else
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(ds.Tables[0].Rows[i].ItemArray[y].ToString()) + "</td>");
                }


               


            }
            tbl = tbl + ("</tr>");



            
            if (i == controw - 1)
            {


                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td colspan='3' align='left' class='rep_datas'>Total Edition");
                tbl = tbl + ("</td>");
                for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                {

                    varmained1 = 0;

                    for (int v = mn; v <= i; v++)
                    {
                        double vared2 = 0;

                        if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                        {
                            vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                            varmained1 = varmained1 + vared2;
                        }

                    }

                    value_main[m] = varmained1;
                }
                mn = i + 1;


                for (int x = 4; x < value_main.Length - 2; x++)
                {
                    tbl = tbl + "<td  align='right' class='rep_datas'>" +chk_null(value_main[x].ToString()) + "</td>";
                }
                for (int x = 4; x < value_main.Length - 2; x++)
                {
                    value_main[x] = 0;
                }

                tbl = tbl + ("</tr>");

                code_find += ds.Tables[0].Rows[i]["MAIN_EDTN_NAME"].ToString() + "~";

                //////////////////////////////publication

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td colspan='3' class='middle31new' align='left'>Total Publication");
                tbl = tbl + ("</td>");
                for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                {

                    varpub1 = 0;

                    for (int v = n; v <= i; v++)
                    {
                        double varpub2 = 0;

                        if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                        {
                            varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                            varpub1 = varpub1 + varpub2;
                        }

                    }

                    value2[m] = varpub1;
                }
                n = i + 1;


                for (int x = 4; x < value2.Length - 2; x++)
                {
                    tbl = tbl + "<td  class='middle31new'  align='right'>" + chk_null(value2[x].ToString()) + "</td>";
                }
                for (int x = 4; x < value2.Length - 2; x++)
                {
                    value2[x] = 0;
                }
                tbl = tbl + ("</tr>");

                ////publication

            }

        }

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td colspan='3' class='middle31new' align='left'><b>Total Business</b>");
        for (int x = 4; x < value.Length - 2; x++)
        {
            tbl = tbl + "<td class='middle31new' align='right'><b>" +chk_null(value[x].ToString()) + "</b></td>";
        }
        tbl = tbl + ("</tr>");
        tbl = tbl + ("<tr rowspan='3'></tr>");

        for (int g = 0; g < ds.Tables[1].Rows.Count; g++)
        {

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td class='rep_data'>" + (g + 1) + "</td>");
            for (int h = 1; h < ds.Tables[1].Columns.Count; h++)
            {

                if (h == 1)
                {
                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[1].Rows[g].ItemArray[h].ToString() + "</td>");

                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[1].Rows[g].ItemArray[h].ToString() + "</td>");
                }
                else
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(ds.Tables[1].Rows[g].ItemArray[h].ToString()) + "</td>");

                    if (ds.Tables[1].Rows[g].ItemArray[h].ToString() != "")

                        if (extra2 == "O")
                        {

                            temp_tot = temp_tot + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                        }
                    if (extra2 == "W")
                    {

                        if (ds.Tables[1].Columns[h].ToString().IndexOf("#") > -1)
                        {
                            string[] abc = ds.Tables[1].Columns[h].ToString().Split('#');

                            if (abc[0].ToString() == "D")
                            {

                                temp_tot34 = temp_tot34 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());

                            }
                            if (abc[0].ToString() == "L")
                            {
                                temp_tot35 = temp_tot35 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());

                            }
                            if (abc[0].ToString() == "A")
                            {
                                temp_tot36 = temp_tot36 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());

                            }

                        }
                    }
                }
            }
            if (extra2 == "O")
            {
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot.ToString()) + "</td>");
            }
            if (extra2 == "W")
            {
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot34.ToString()) + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot35.ToString()) + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(temp_tot36.ToString()) + "</td>");
            }
            temp_tot34 = 0;
            temp_tot35 = 0;
            temp_tot36 = 0;
            temp_tot = 0;
            tbl = tbl + ("</tr>");
        }

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td colspan='3' class='middle31new' align='left'><b>Total Business</b>");
        for (int x = 4; x < value.Length - 2; x++)
        {
            tbl = tbl + "<td class='middle31new' align='right'><b>" +chk_null(value[x].ToString()) + "</b></td>";
        }
        tbl = tbl + ("</tr>");
        tbl = tbl + ("<tr rowspan='3'></tr>");

        tbl = tbl + ("</table>");
        //if (chk_excel == "1")
        //{

            rptDiv.InnerHtml = tbl;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            rptDiv.RenderControl(hw);
            Response.Write(sw.ToString());
        //}
        //else
        //{
        //    DataGrid1.DataSource = ds;

        //    string[] names = name2.Substring(1, name2.Length - 1).Split(',');
        //    string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
        //    string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
        //    string[][] colProperties ={ names, captions, formats };

        //    QueryToCSV(ds, colProperties);
        //}
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["prm_issueprintcent_print"] = "destination~" + destination + "~fromdate~" + fromdate + "~dateto~" + dateto + "~pubcentcode~" + pubcentcode + "~edition~" + edition + "~editionname~" + editionname + "~pubcentname~" + pubcentname + "~ratio_type~" + ratio_type + "~extra1~" + extra1 + "~extra2~" + extra2 + "~ratio_name~" + ratio_name;
        
        Response.Redirect("issuewiseprint.aspx");
        //Response.Redirect("issuewiseprint.aspx?destination=" + destination + "&fromdate=" + fromdate + "&dateto=" + dateto + "&pubcentcode=" + pubcentcode + "&edition=" + edition + "&editionname=" + editionname + "&pubcentname=" + pubcentname);
            
    }
}
