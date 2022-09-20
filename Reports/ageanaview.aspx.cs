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
using System.Text;
public partial class ageanaview : System.Web.UI.Page
{
    int grouptotal_Govt = 0;
    int grouptotal_local = 0;
    int grouptotal_national = 0;
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
    string place = "";
    string publicationname = "";
    string publicationcode = "";
    string editionname = "";
    string editioncode = "";
    string revenuecentercode = "";
    string revenuecentername = "";
    string executivecode = "";
    string executivename = "";
    string check11 = "";
    string value11 = "";
    string placename = "";
    string adtypname = "";
    string pubcentname = "";
    string noofrows11 = "20";
    string val_chk = "";
    double payment = 0;
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string name11 = "", name22 = "", name33 = "";
    string chk_excel = "";
    string rundate = "";
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
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
       
        ds = (DataSet)Session["topcliage"];
        string prm = Session["prm_topcliage"].ToString();
        string[] prm_Array = new string[45];
        prm_Array = prm.Split('~');
        
        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcent = prm_Array[7]; //Request.QueryString["pubcent"].Trim().ToString();
        pubcentname = prm_Array[9]; //Request.QueryString["pubcentname"].ToString();
        revenuecentercode = prm_Array[11]; //Request.QueryString["revenuecentercode"].Trim().ToString();
        revenuecentername = prm_Array[13]; //Request.QueryString["revenuecentername"].ToString();
        adtyp = prm_Array[15]; //Request.QueryString["adtyp"].ToString(); 
        adtypname = prm_Array[17]; //Request.QueryString["adtypname"].ToString();
        val_chk = prm_Array[19]; //Request.QueryString["value"].ToString();
        bill = prm_Array[21]; //Request.QueryString["bill"].Trim().ToString();
        place = prm_Array[23]; //Request.QueryString["place"].Trim().ToString();
        placename = prm_Array[25]; //Request.QueryString["placename"].ToString();
        editioncode = prm_Array[27]; //Request.QueryString["editioncode"].Trim().ToString();
        editionname = prm_Array[29]; //Request.QueryString["editionname"].ToString();
        check11 = prm_Array[31]; //Request.QueryString["check11"].Trim().ToString();
        value11 = prm_Array[33]; //Request.QueryString["value1"].Trim().ToString();
        publicationname = prm_Array[35]; //Request.QueryString["publicationname"].ToString();
        publicationcode = prm_Array[37]; //Request.QueryString["publicationcode"].Trim().ToString();
        executivecode = prm_Array[39]; //Request.QueryString["executivecode"].Trim().ToString();
        executivename = prm_Array[41]; //Request.QueryString["executivename"].ToString();
        noofrows11 = prm_Array[43]; //Request.QueryString["noofrows11"].Trim().ToString();
        chk_excel = prm_Array[45];


            if (check11 != "1")
                heading.Text = "Top Agency Analysis Report";
            else
                heading.Text = "Top Client Analysis Report";
        
            Ajax.Utility.RegisterTypeForAjax(typeof(ageanaview));
            if (pubcent == "0")
            {
                lblpubcent.Text = "All";
            }
            else
            {
                lblpubcent.Text = pubcentname.ToString();
            }

            if (adtyp == "0")
            {
                lbladtype.Text = "All";
            }
            else
            {
                lbladtype.Text = adtypname.ToString();
            }

            if (place == "0")
            {
                lblcity.Text = "All";
            }
            else
            {
                lblcity.Text = placename.ToString();
            }

            if (publicationcode == "0")
            {
                lblpublication.Text = "All";
            }
            else
            {
                lblpublication.Text = publicationname.ToString();
            }

            if ((editioncode == "0")||(editioncode == ""))
            {
                lbledition.Text = "All";
            }
            else
            {
                lbledition.Text = editionname.ToString();
            }

            if ((executivecode == "0") || (executivecode == ""))
            {
                lblexec.Text = "All";
            }
            else
            {
                lblexec.Text = executivename.ToString();
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
           
            rundate = date.ToString();
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

            lblfrom.Text = datefrom1.ToString();
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

                lblto.Text = dateto1.ToString();

          
            hiddendatefrom.Value = fromdt.ToString();
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

    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
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
        int i1 = 1;
        SqlDataAdapter da = new SqlDataAdapter();

        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        StringBuilder tbl = new StringBuilder();
        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>");

        if (check11 != "1")
        {
            tbl.Append("<tr><td class='middle31new' width='5%'>S.No.</td><td class='middle31new' width='40%' align='left'>Agency</td><td class='middle31new' width='40%' align='left'>Agency</br>Address</td><td class='middle31new' align='right' width='15%'>Amount</td></tr>");
        }
        else
        {
            tbl.Append("<tr><td class='middle31new' width='5%'>S.No.</td><td  class='middle31new' width='40%' align='left'>Client</td><td class='middle31new' width='40%' align='left'>Client</br>Address</td><td class='middle31new' align='right' width='15%'>Amount</td></tr>");
        }
        
        int j = 0;
        
        for (int i = 0; i <= cont - 1; i++)
        {

            tbl.Append("<tr >");
            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            char[] agency = rrr1.ToCharArray();
            int len111 = agency.Length;
            int line11 = 0;
            int ch_end1 = 0;
            int ch_str1 = 0;
            for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            {
                /**/
                ch_end1 = ch_end1 + 30;
                ch_str1 = ch_end1;
                if (ch_end1 > len111)
                    ch_str1 = len111 - ch1;
                else
                    ch_str1 = ch_end1 - ch1;

                agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                agency1 = agency1 + "</br>";
                ch1 = ch1 + 30;
                if (ch1 > len111)
                    ch1 = len111;/**/
            }
            //----------------------------------------------------------------///
            tbl.Append("<td class='rep_data' align='left' >");
            tbl.Append(agency1 + "</td>");


            string A_Place1 = "";
            string rrr111 = ds.Tables[0].Rows[i]["A_Place"].ToString();
            char[] A_Place = rrr111.ToCharArray();
            int len11111 = A_Place.Length;
            int line1111 = 0;
            int ch_endp = 0;
            int ch_strp = 0;
            for (int ch1 = 0; ((ch1 < len11111) && (line1111 < 2)); ch1++)
            {
                /**/
                ch_endp = ch_endp + 40;
                ch_strp = ch_endp;
                if (ch_endp > len11111)
                    ch_strp = len11111 - ch1;
                else
                    ch_strp = ch_endp - ch1;

                A_Place1 = A_Place1 + rrr111.Substring(ch1, ch_strp).Trim();
                A_Place1 = A_Place1 + "</br>";
                ch1 = ch1 + 40;
                if (ch1 > len11111)
                    ch1 = len11111;/**/
            }


            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(A_Place1 + "</td>");


            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[i]["GrossAmt"]).ToString("F2") + "</td>");

            double amtnet = 0;
            if (ds.Tables[0].Rows[i]["GrossAmt"].ToString() != "")
            {
                amtnet = Convert.ToDouble(ds.Tables[0].Rows[i]["GrossAmt"].ToString());
            }

            payment = payment + amtnet;


            tbl.Append("</tr>");
            j = i;
            
        }
        //=====================


        tbl.Append("<tr >");
        tbl.Append("<td class='middle13new' width='5%'>&nbsp;</td>");
        tbl.Append("<td class='middle13new' width='40%'>&nbsp;</td>");
        tbl.Append("<td class='middle13new' width='40%' style='font-size:12px'><b>Total Amt:</b></td>");
        tbl.Append("<td class='middle13new' align='right'  width='15%' style='font-size:12px'><b>" + payment.ToString("F2") + "</b></td>");
        tbl.Append("</tr>");



        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();

    }





    private void excel(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {

        SqlDataAdapter da = new SqlDataAdapter();
       
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
        nameColumn0.HeaderText = "S.No";
        DataGrid1.Columns.Add(nameColumn0);

        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = "Agency";
        nameColumn.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Agency Address";
        nameColumn1.DataField = "A_Place";

        name1 = name1 + "," + "Agency Address";
        name2 = name2 + "," + "A_Place";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "GrossAmt";
        nameColumn4.DataField = "GrossAmt";

        name1 = name1 + "," + "GrossAmt";
        name2 = name2 + "," + "GrossAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);


        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = "S.No";
        DataGrid2.Columns.Add(nameColumn5);


        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Client";
        nameColumn6.DataField = "Agency";

        name11 = name11 + "," + "Client";
        name22 = name22 + "," + "Agency";
        name33 = name33 + "," + "G";
        DataGrid2.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "Client Address";
        nameColumn7.DataField = "A_Place";

        name11 = name11 + "," + "Client Address";
        name22 = name22 + "," + "A_Place";
        name33 = name33 + "," + "G";
        DataGrid2.Columns.Add(nameColumn7);
      

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "GrossAmt";
        nameColumn9.DataField = "GrossAmt";

        name11 = name11 + "," + "GrossAmt";
        name22 = name22 + "," + "GrossAmt";
        name33 = name33 + "," + "G";
        DataGrid2.Columns.Add(nameColumn9);


        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            if (check11 != "1")
            {
                DataGrid1.DataSource = ds;
                DataGrid1.ShowHeader = true;
                DataGrid1.ShowFooter = true;
                DataGrid1.DataBind();
                hw.Write("<p <table border=\"1\"><tr><td colspan=\"4\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");

                hw.Write("<p <tr><td colspan=\"4\"align=\"center\"><b>" + "Top Agency Analysis Report" + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>Date From:" + datefrom1.ToString() + "</b></td><td colspan=\"1\"align=\"left\"><b>To Date:" + dateto1.ToString() + "</b></td><td colspan=\"1\"align=\"left\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>Publication:" + lblpublication.Text + "</b></td><td colspan=\"1\"align=\"left\"><b>Edtion:" + lbledition.Text + "</b></td><td colspan=\"1\"align=\"left\"><b>" + "Ad Type:" + lbladtype.Text + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>Pubcent:" + lblpubcent.Text + "</b></td><td colspan=\"1\"align=\"left\"><b>City:" + lblcity.Text + "</b></td><td colspan=\"1\"align=\"left\"><b>" + "Executive:" + lblexec.Text + "</b></td></tr>");

                //hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
                //hw.Write("<p align=\"center\"><b>Top Agency Analysis Report&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Run Date:" + rundate + "</b>");
                hw.WriteBreak();
                DataGrid1.RenderControl(hw);
            }
            else
            {
                DataGrid2.DataSource = ds;
                DataGrid2.ShowHeader = true;
                DataGrid2.ShowFooter = true;
                DataGrid2.DataBind();          
                //hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
                //hw.Write("<p align=\"center\"><b>Top Client Analysis Report&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Run Date:" + rundate + "</b>");
                hw.Write("<p <table border=\"1\"><tr><td colspan=\"4\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");

                hw.Write("<p <tr><td colspan=\"20\"align=\"center\"><b>" + "Top Client Analysis Report" + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"20\"align=\"right\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
                
                hw.WriteBreak();
                
                DataGrid2.RenderControl(hw);
            }
            int sno11 = sno - 1;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td></td><td align=\"right\" colspan=\"2\"><b>Total Amt: </b></td><td><b>" + amtnew + "</b></td></tr></table>"));

        }
        else
        {
            if (check11 != "1")
            {

                DataGrid1.DataSource = ds;

                string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                string[][] colProperties ={ names, captions, formats };

                QueryToCSV(ds, colProperties);
            }
            else
            {
                DataGrid2.DataSource = ds;

                string[] names = name22.Substring(1, name22.Length - 1).Split(',');
                string[] captions = name11.Substring(1, name11.Length - 1).Split(',');
                string[] formats = name33.Substring(1, name33.Length - 1).Split(',');
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
        pdfxml.ReadXml(Server.MapPath("XML/categoryreport.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        btnprint.Attributes.Add("onclick", "javascript:window.print();");
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();
        int NumColumns = 4;
        int NumColumns1 = 4;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        double amt = 0;

        // ---------------table for heading-------------------------
        try
        {

            SqlDataAdapter da = new SqlDataAdapter();
           

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/categoryreport.xml"));

            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));
            if (check11 != "1")
      
                  tbl.addCell(new Phrase("Top Agency Analysis Report", font9));
            else
                 tbl.addCell(new Phrase("Top Client Analysis Report", font9));
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);

            double area11 = 0;

            //-----------------table for spacing------------------------------
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
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));

            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[56].ToString(), font10));
            tbl2.addCell(new Phrase(lblpublication.Text, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[9].ToString(), font10));
            tbl2.addCell(new Phrase(lbledition.Text, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[67].ToString(), font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));


            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[67].ToString(), font10));
            tbl2.addCell(new Phrase(lblpubcent.Text, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[68].ToString(), font10));
            tbl2.addCell(new Phrase(lblcity.Text, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[69].ToString(), font10));
            tbl2.addCell(new Phrase(lblexec.Text, font11));

            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            PdfPTable tbl91 = new PdfPTable(NumColumns1);
            tbl91.DefaultCell.BorderWidth = 0;
            tbl91.WidthPercentage = 100;
            tbl91.DefaultCell.Colspan = NumColumns1;
            tbl91.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl91);

            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns1);
            //datatable.DefaultCell.Padding = 3;
            datatable.DefaultCell.BorderWidth = 0;
            datatable.WidthPercentage = 100; // percentage
            
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            if (check11 != "1")
            {
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("Agency", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("AgencyAdd.", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase("Amount", font10));
            }
            else
            {
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("Client", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("ClientAdd.", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase("Amount", font10));
            }
           

           
            datatable.HeaderRows = 1;
            datatable.DefaultCell.Colspan = NumColumns1;
            datatable.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            //document.Add(datatable);

           
         
           

            int row = 0;
            
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {



               
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["A_Place"].ToString(), font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(Convert.ToDouble(ds.Tables[0].Rows[row]["GrossAmt"]).ToString("F2"), font11));

                if (ds.Tables[0].Rows[row]["GrossAmt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["GrossAmt"].ToString());

                row++;

            }

            document.Add(datatable);

          

          
            //Phrase p3 = (new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[53].ToString(), font10));
            //document.Add(p3);
            PdfPTable tbltotal = new PdfPTable(NumColumns1);
            //float[] headerwidths = { 14, 10, 8, 4, 2, 2, 14, 1, 10, 5, 8, 4, 4, 14, 4, 10, 8, 4 }; // percentage
            //tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.Colspan = NumColumns1;
            tbltotal.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;
            //tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //tbltotal.addCell(new Phrase("", font10));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));

           
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
           
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font10));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font10));
            tbltotal.addCell(new Phrase("Total Amt:", font10));
           
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(amt.ToString("F2"), font10));

            //tbltotal.addCell(new Phrase(" ", font11));

            //tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.DefaultCell.Colspan = NumColumns1;
            tbltotal.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;
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
        Session["prm_topcliage_print"] = "fromdate~" + fromdt + "~dateto~" + dateto + "~pubcent~" + pubcent + "~pubcentname~" + pubcentname + "~revenuecentercode~" + revenuecentercode + "~revenuecentername~" + revenuecentername + "~adtyp~" + adtyp + "~adtypname~" + adtypname + "~value~" + value11 + "~bill~" + bill + "~place~" + place + "~placename~" + placename + "~editioncode~" + editioncode + "~editionname~" + editionname + "~check11~" + check11 + "~value1~" + value11 + "~publicationname~" + publicationname + "~publicationcode~" + publicationcode + "~executivecode~" + executivecode + "~executivename~" + executivename + "~noofrows11~" + noofrows11;
        Response.Redirect("agencyanalysisprint.aspx");
    }
    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

       
      

        string check = e.Item.Cells[3].Text;
        string amt = e.Item.Cells[3].Text;
        string grossamt = "";
        double grossamt1 = 0;
        if (check != "GrossAmt")
        {
            if (check != "&nbsp;")
            {

                grossamt = e.Item.Cells[3].Text;
                string totalarea = e.Item.Cells[3].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }


    }



}