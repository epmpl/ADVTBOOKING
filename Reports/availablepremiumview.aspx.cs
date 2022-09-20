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
using System.Web.UI.WebControls;
using System.Text;
public partial class availablepremiumview : System.Web.UI.Page
{
    int q = 0, z = 0, lastc = 0, lastthirdc = 0;
    int sno = 1;
    int count = 0;
    double amt = 0;
    double amt1 = 0;
    double area1 = 0;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;

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
    string editionname = "";
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
    string sortvalue = "", adtype = "", adtypename = "", client = "", clientname1 = "", agency = "", agencyname = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "", pageno = "", adcate = "", pagename="";
    string chk_excel = "";
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
       
        fromdt = Session["fromdate"].ToString();
        dateto = Session["todate"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pagepreviewreport.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

        ds = (DataSet)Session["availableprem"];
        string prm = Session["prm_availableprem"].ToString();
        string[] prm_Array = new string[22];
        prm_Array = prm.Split('~');


        page = prm_Array[1];// Request.QueryString["page"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[7]; //Request.QueryString["publication"].ToString();
        pubcname = prm_Array[9]; //Request.QueryString["publicname"].ToString();
        edition = prm_Array[11]; //Request.QueryString["edition"].ToString();
        destination = prm_Array[13]; //Request.QueryString["destination"].ToString();
        editionname = prm_Array[15]; //Request.QueryString["editionname"].ToString();
        position = prm_Array[17]; //Request.QueryString["position"].ToString();
        positioncode = prm_Array[19]; //Request.QueryString["positioncode"].ToString();
        chk_excel = prm_Array[21];
        pageno = prm_Array[23];
        adtype = prm_Array[25];
        adcate = prm_Array[27];
        pagename = prm_Array[29];
        hiddendatefrom.Value = fromdt.ToString();
        hold = "abc";

       
        if (page == "0")
        {
            lblpagepr.Text = "ALL".ToString();
        }
        else
        {
            lblpagepr.Text = pagename.ToString();
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

        if (edition == "0" || edition == "--Select Edition Name--" || edition=="")
        {
            lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname.ToString();
        }
        

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;


        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);


                }
        lbldate.Text = date.ToString();
        lblfrom.Text = fromdt;
        lblto.Text = dateto;


        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            }
            else if (destination == "3")
            {
                pdf(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

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


    private void onscreen(string page, string position, string fromdt, string dateto, string publ, string compcode, string edition, string dateformat)
    {
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
        //    ds = obj.availableprem(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
        //}
        cmpnyname.Text = ds.Tables[1].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        StringBuilder tbl = new StringBuilder();
        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0'>");

    
        if (hiddenascdesc.Value == "")
        {
           
            tbl.Append("<tr>");
            tbl.Append("<td class='middle31new' valign='top' align='left'width='25%'>" + "S.No." + "</td>");

            for (int fr1 = 0; fr1 < ds.Tables[0].Columns.Count; fr1++)
            {
                if (fr1 == 0)
                {
                    tbl.Append("<td class='middle31new' valign='top' align='left' width='25%'>");
                    tbl.Append(ds.Tables[0].Columns[fr1].ToString() + "</td>");

                }
                else
                {
                    //tbl.Append("<td class='middle31new' width='130px'  colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Columns[fr1].ToString() + "</br>Booked&nbsp;&nbsp;&nbsp;Available</td>");
                    //fr1 = fr1 + 1;
                    tbl.Append("<td class='middle31new' width='25%' align='right'>" + ds.Tables[0].Columns[fr1].ToString() + "(" + "Booked" + ")" + "</td>");
                    tbl.Append("<td class='middle31new' width='25%'  colspan='2' align='right'>" + ds.Tables[0].Columns[fr1].ToString() + "(" + "Available" + ")" + "</td>");
                    fr1 = fr1 + 1;

                }

            }
            // TBL += "<td class='middle123' align='left' valign='top'>" + "CIOID" + "</td>";

            tbl.Append("</tr>");

        }
      
        int i1 = 1;

        for (int i = 0; i < cont; i++)
        {
            

            tbl.Append("<tr>");
            tbl.Append("<td class='rep_data' valign='top' align='left' width='25%'>");
            tbl.Append(i1++.ToString() + "</td>");

            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                if (j == 0)
                {
                    tbl.Append("<td class='rep_data' align='left'width='25%'>");
                    tbl.Append(ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");

                }
                else
                {
                    if (ds.Tables[0].Rows[i].ItemArray[j].ToString() != "")
                    {
                     //tbl.Append("<td class='rep_data' width='120px'  colspan='2' align='center'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "&nbsp;&nbsp;" + ds.Tables[0].Rows[i].ItemArray[j + 1].ToString() + "</td>");
                        tbl.Append("<td class='rep_data' width='25%'  align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                        tbl.Append("<td class='rep_data' width='25%'  colspan='2' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j + 1].ToString() + "</td>");

                    }
                   
                    j++;
                }
            }
            tbl.Append("</tr>");

        }
            

           
             tbl.Append("</tr>");

             tbl.Append("</table>");
       
        tblgrid.InnerHtml = tbl.ToString();

    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_availableprem_print"] = "dateto~" + dateto + "~fromdate~" + fromdt + "~destination~" + destination + "~publication~" + publ + "~publicname~" + pubcname + "~edition~" + edition + "~editionname~" + editionname + "~page~" + page + "~position~" + position + "~positioncode~" + positioncode + "~pageno~" + pageno + "~adtype~" + adtype + "~adcate~" + adcate + "~pagename~" + pagename;
        Response.Redirect("printavailable.aspx");
    }

    private void pdf(string page, string position, string fromdt, string dateto, string publ, string compcode, string edition, string dateformat)
    {


        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    //NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
        //    //ds = obj.availableprem(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
        //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
        //    ds = obj.availableprem(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
     
        //}
        int NumColumns = ds.Tables[0].Columns.Count + 1;


        //---------------------------------
        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);


        //--------------------for page numbering---------------------------------------------
        //---------------table for heading-------------------------
        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.addCell(new Phrase(ds.Tables[1].Rows[0]["companyname"].ToString(), font9));
            tbl.addCell(new iTextSharp.text.Phrase("Available Premium Date", font9));

            tbl.WidthPercentage = 100;
            document.Add(tbl);
            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl1.addCell("");
            tbl1.WidthPercentage = 100;

            int i;
            for (i = 0; i < 5; i++)
            {
                document.Add(tbl1);
            }
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(fromdt.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));


            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 1;

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            datatable.addCell(new iTextSharp.text.Phrase("S.No", font10));

            for (int x = 0; x < ds.Tables[0].Columns.Count; x++)
            {
                if (x == 0)
                {
                    datatable.addCell(new Phrase(ds.Tables[0].Columns[x].ToString(), font10));
                }
                else
                {
                    if (x % 2 == 0)
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Columns[x - 1].ToString() + "(Avail.)", font10));
                    }
                    else
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Columns[x].ToString() + "(Booked)", font10));

                    }
                }
            }

            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 0;
            iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p1);

            //---------------------for pagination--------------------------------------------
            int a = 1;
            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {

                datatable.addCell(new Phrase(a++.ToString(), font11));
                for (int y = 0; y < ds.Tables[0].Columns.Count; y++)
                {
                    if (ds.Tables[0].Rows[r].ItemArray[y].ToString() != "")
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[r].ItemArray[y].ToString(), font11));
                    }
                    else
                    {
                        datatable.addCell(new Phrase("0", font11));
                    }
                }


              //  break;


            }

            document.Add(datatable);
            document.Close();
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


  
        


    }
    private void excel(string page, string position, string fromdt, string dateto, string publ, string compcode, string edition, string dateformat)
    {
        
        
            string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
            //    ds = obj.availableprem(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            //}
            int cont = ds.Tables[0].Rows.Count;
            count = cont;
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
            //BoundColumn nameColumn0 = new BoundColumn();
            //nameColumn0.HeaderText = "S.No";
            //DataGrid1.Columns.Add(nameColumn0);

            //BoundColumn nameColumn1 = new BoundColumn();
            //nameColumn1.HeaderText = "Publication";
         
            //DataGrid1.Columns.Add(nameColumn1);

            for (int r = 0; r < ds.Tables[0].Columns.Count ; r++)
            {
                string ffdd = ds.Tables[0].Columns[r].ToString();
                BoundColumn nameColumn = new BoundColumn();
                if (r == 0)
                {
                    nameColumn.HeaderText = ffdd;
                    name1 = name1 + "," + ffdd;
                }
                else
                {
                    if (r % 2 == 0)
                    {
                        string ffdd1 = ds.Tables[0].Columns[r-1].ToString();
                        nameColumn.HeaderText = ffdd1 + "(Available)";
                        name1 = name1 + "," + ffdd1 + "(Available)";
                    }
                    else
                    {
                        nameColumn.HeaderText = ffdd + "(Booked)";
                        name1 = name1 + "," + ffdd + "(Booked)";
                    }
                }
                nameColumn.DataField = ffdd;
                name2 = name2 + "," + ffdd;
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }
            if (chk_excel == "1")
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                DataGrid1.ShowHeader = true;
                DataGrid1.ShowFooter = true;
            hw.Write("<p <table border=\"1\"><tr><td colspan=\"3\"align=\"center\"><b>" + ds.Tables[1].Rows[0]["companyname"].ToString() + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"3\"align=\"center\"><b>" + "Available Premium Date" + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"1\"align=\"left\"><b>" + "Page :" + "</b>" + lblpagepr.Text + "</td>");
            hw.Write("<p <td colspan=\"2\"align=\"left\"><b>" + "Position:" + "</b>" + lblposition.Text + "</td></tr>");
            hw.Write("<p <tr><td colspan=\"1\"align=\"left\"><b>" + "Publication:" + "</b>" + lblpub.Text + "</td>");
            hw.Write("<p <td colspan=\"2\"align=\"left\"><b>" + "Edition:" + "</b>" + lbledition.Text + "</td></tr>");
            hw.Write("<p <tr><td colspan=\"1\"align=\"left\"><b>" + "From Date:" + "</b>" + lblfrom.Text + "</td>");
            hw.Write("<p <td colspan=\"1\"align=\"left\"><b>" + "To Date:" + "</b>" + lblto.Text + "</td>");
            hw.Write("<p <td colspan=\"1\"align=\"left\"><b>" + "Run Date:" + "</b>" + lbldate.Text + "</td><tr>");



                
                hw.WriteBreak();
                DataGrid1.RenderControl(hw);
                Response.Write(sw.ToString());
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
       
           
    }
}
