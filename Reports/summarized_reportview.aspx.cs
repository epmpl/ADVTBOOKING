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
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;


public partial class summarized_reportview : System.Web.UI.Page
{
    int sno = 1;
    double amtsum = 0;
    string adtyp = "";
    string adtypname = "";
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
    double amtnew = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string package = "";
    //int area = 0;
    decimal area = 0;
    double ARR = 0;
    int i1 = 1;
    double amt = 0;
    string client = "";
    string agency = "";

    string sortorder = "";
    string sortvalue = "";

    string page = "", region = "", rep = "", place = "", grp = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
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
        
		
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/categoryreport.xml"));
        heading.Text = "Status Wise Daily Summarized Report";

        ds = (DataSet)Session["summarize"];
        string prm = Session["prm_summarize"].ToString();
        string[] prm_Array = new string[24];
        prm_Array = prm.Split('~');

        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        adtyp = prm_Array[5]; //Request.QueryString["adtype"].ToString();
        destination = prm_Array[7]; //Request.QueryString["destination"].ToString();
        publ = prm_Array[9]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[11]; //Request.QueryString["pubcenter"].ToString();
        edition = prm_Array[13]; //Request.QueryString["edition"].ToString();
        pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();
        editionname = prm_Array[19]; //Request.QueryString["editionname"].ToString();
        adtypname = prm_Array[21]; //Request.QueryString["adtypename"].ToString();
        chk_excel = prm_Array[23];
        Ajax.Utility.RegisterTypeForAjax(typeof(summarized_reportview));
        hiddendatefrom.Value = fromdt.ToString();

        if (publ == "0")
        {
            lblpublication.Text = "ALL".ToString();
        }
        else
        {
            lblpublication.Text = pubcname.ToString();
        }

        if (adtyp == "0")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypname.ToString();
        }


        if (edition == "0" || edition=="")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();
        }

        if (pubcen == "0")
        {
            lbcent.Text = "ALL".ToString();
        }
        else
        {
            lbcent.Text = pub2.ToString();
        }




        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();

            if (day.Length < 2)
                day = "0" + day;
            if (month.Length < 2)
                month = "0" + month;

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
        lblrundate.Text = date.ToString();
        lblfrom.Text = fromdt;
        lblto.Text = dateto;

        if (!Page.IsPostBack)
        {

            if (destination == "1" || destination == "0")
            {
                //onscreen(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                onscreen(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), edition);
            }
            else if (destination == "4")
            {
                excel(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), edition);

            }
            else
                if (destination == "3")
                {
                    pdf(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), edition);
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

    private void onscreen(string adtyp, string adcat, string fromdt, string dateto, string publ, string  pubcen,string compcode, string dateformat,string edition)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    //ds = obj.spfun(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
        //    ds = obj.Dailyrep(fromdt, dateto, adtyp, publ , pubcen , Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),editionname);
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        //tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";

        //if (hiddenascdesc.Value == "")
        //{

        //    //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>BookingID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdpc~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td id='tdat~12' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~13' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>CardRate</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdag~2' class='middle3'onclick=sorting('Name',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~4' class='middle3'onclick=sorting('Category',this.id)>Category<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle3'onclick=sorting('GrossAmt',this.id)>GrossAmt<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~4' class='middle3'onclick=sorting('Area',this.id)>Area<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>TotalAds</td></tr>");

        //}
        //else if (hiddenascdesc.Value == "asc")
        //{

        //    //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>BookingID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdpc~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td id='tdat~12' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~13' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>CardRate</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdag~2' class='middle3'onclick=sorting('Name',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~4' class='middle3'onclick=sorting('Category',this.id)>Type<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle3'onclick=sorting('GrossAmt',this.id)>GrossAmt<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~4' class='middle3'onclick=sorting('Area',this.id)>Area<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>TotalAds</td></tr>");


        //}
        //else if (hiddenascdesc.Value == "desc")
        //{

        //    //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>BookingID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdpc~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td id='tdat~12' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~13' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>CardRate</td><td class='middle31'>AggRate</td><td class='middle31'>Amt</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdag~2' class='middle3'onclick=sorting('Name',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~4' class='middle3'onclick=sorting('Category',this.id)>Type<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~3' class='middle3'onclick=sorting('GrossAmt',this.id)>GrossAmt<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~4' class='middle3'onclick=sorting('Area',this.id)>Area<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>TotalAds</td></tr>");

        //}


        tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td  class='middle31new' align='left'>Status</td><td class='middle31new' align='left'>Booking</br>Type</td><td  class='middle31new' align='right'>GrossAmt</td><td  class='middle31new' align='right'>Area</td><td class='middle31new' align='right'>TotalAds</td></tr>");



        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Type"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["GrossAmt"].ToString()) + "</td>");
            if (ds.Tables[0].Rows[i]["GrossAmt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["GrossAmt"].ToString());
            //=====================
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["Area"].ToString()) + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + decimal.Parse(ds.Tables[0].Rows[i]["Area"].ToString());

            //===temp===
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["count(*)"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["ARR"] + "</td>");
            //if (ds.Tables[0].Rows[i]["ARR"].ToString() != "")
            //    ARR = ARR + double.Parse(ds.Tables[0].Rows[i]["ARR"].ToString());
            //=======================
            tbl = tbl + "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";
        }
        tbl = tbl + ("<tr >");
  
        tbl = tbl + ("<td class='middle13new' style='font-size:12px'><b>Total:-</b></td>");
        tbl = tbl + ("<td class='middle13new' style='font-size:12px'>");
        tbl = tbl + ("&nbsp;</td>");
       
        tbl = tbl + ("<td class='middle13new' style='font-size:12px'>&nbsp;</td>");
        tbl = tbl + ("<td class='middle13new' style='font-size:12px' align='right'>");
        tbl = tbl + (chk_null(amt.ToString()) + "</td>");
        tbl = tbl + ("<td class='middle13new' style='font-size:12px' align='right'>");
        tbl = tbl + (chk_null(area.ToString()) + "</td>");
        tbl = tbl + ("<td class='middle13new'>&nbsp;</td>");
        
        tbl = tbl + "</tr>";
        

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;

    }

    private void excel(string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string dateformat, string edition)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        //NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
        //ds = obj.Dailyrep(fromdt, dateto, adtyp, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), editionname);
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
        int width1 = Int16.Parse("1000");
        nameColumn0.ItemStyle.Width = Unit.Pixel(1000);
      //  nameColumn0.
       // int width1=nameC
        DataGrid1.Columns.Add(nameColumn0);



        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = "Status";
        nameColumn.DataField = "Status";

        name1 = name1 + "," + "Status";
        name2 = name2 + "," + "Status";
        name3 = name3 + "," + "G";
        nameColumn.ItemStyle.Width = Unit.Pixel(1000);
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Booking Type";
        nameColumn1.DataField = "Type";

        name1 = name1 + "," + "Booking Type";
        name2 = name2 + "," + "Type";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "GrossAmt";
        nameColumn2.DataField = "GrossAmt";

        name1 = name1 + "," + "GrossAmt";
        name2 = name2 + "," + "GrossAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Area";
        nameColumn4.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);


        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = "TotalAds";
        nameColumn5.DataField = "count(*)";

        name1 = name1 + "," + "TotalAds";
        name2 = name2 + "," + "count(*)";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn5);

        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            //hw.Write("<p align=\"center\"> Daily Summarized Report View");
            hw.Write("<p <table border =\"4\"> <tr> <td align=\"center\" colspan=\"4\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
            hw.Write("<p <tr> <td align=\"center\" colspan=\"4\"><b>Status Wise Daily Summarized Report</b></td></tr>");
           hw.Write("<p <tr> <td align=\"left\" colspan=\"1\"><b>Date From:</b>" + lblfrom.Text + "</td><td colspan=\"2\"> <b>Date To:</b>" + lblto.Text + "</td><td colspan=\"3\"> <b>Run Date:</b>" + lblrundate.Text + "</td></tr>");
            hw.Write("<p <tr> <td align=\"left\" colspan=\"1\"><b>Publication:</b>" + lblpublication.Text + "</td><td colspan=\"2\"> <b>Center:</b>" + lbcent.Text + "</td><td colspan=\"3\"> <b>Edition:</b>" + lbedition.Text + "</td></tr>");
            hw.Write("<p <tr> <td align=\"left\" colspan=\"1\"><b>Ad Type:</b>" + lbladtype.Text + "</td></tr>");
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            int sno11 = sno - 1;
            // Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"2\">TOTAL AMOUNT</td><td align=\"center\">" + amtnew + "</td></tr><tr><td></td><td>Count</td><td>Area</td><td>Net Amount</td></tr><tr><td>Total Billed:-</td><td>" + ds.Tables[1].Rows[0].ItemArray[0].ToString() + "</td><td>" + ds.Tables[1].Rows[0].ItemArray[1].ToString() + "</td><td>" + ds.Tables[1].Rows[0].ItemArray[2].ToString() + "</td></tr><tr><td>Total Unbilled:-</td><td>" + ds.Tables[2].Rows[0].ItemArray[0].ToString() + "</td><td>" + ds.Tables[2].Rows[0].ItemArray[1].ToString() + "</td><td>" + ds.Tables[2].Rows[0].ItemArray[2].ToString() + "</td></tr><tr><td>Total Cancel:-</td><td>" + ds.Tables[3].Rows[0].ItemArray[0].ToString() + "</td><td>" + ds.Tables[3].Rows[0].ItemArray[1].ToString() + "</td><td>" + ds.Tables[3].Rows[0].ItemArray[2].ToString() + "</td></tr><tr><td>Total Publish:-</td><td>" + ds.Tables[4].Rows[0].ItemArray[0].ToString() + "</td><td>" + ds.Tables[4].Rows[0].ItemArray[1].ToString() + "</td><td>" + ds.Tables[4].Rows[0].ItemArray[2].ToString() + "</td></tr></table>"));
            Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"2\">TOTAL AMOUNT</td><td align=\"center\">" + amtnew + "</td></tr></table>"));
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



    private void pdf(string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string dateformat, string edition)
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
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);
        Font font2 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL);

        // ---------------table for heading-------------------------
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //    //ds = obj.spfun(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
            //    ds = obj.Dailyrep(fromdt, dateto, adtyp, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), editionname);
            //}
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/categoryreport.xml"));

            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new Phrase("Status Wise Daily Summarized Report", font9));
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);




            PdfPTable tbl6 = new PdfPTable(3);
            float[] abc = { 15, 20, 15 };
            tbl6.DefaultCell.BorderWidth = 0;
            tbl6.WidthPercentage = 100;
            tbl6.DefaultCell.Padding = 0;
            tbl6.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.setWidths(abc);
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("From Date:" + fromdt, font2));
            tbl6.addCell(new Phrase("To Date:" + dateto, font2));
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("Run Date:" + date.ToString(), font2));
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("Publication:" + lblpublication.Text, font2));
            tbl6.addCell(new Phrase("Center:" + lbcent.Text, font2));
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("Edition:" + lbedition.Text, font2));
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("AdType:" + lbladtype.Text, font2));
            tbl6.addCell(new Phrase("" , font2));
            tbl6.addCell(new Phrase("" , font2));
            document.Add(tbl6);




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

            PdfPTable tbl2 = new PdfPTable(7);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(6);
            datatable.DefaultCell.Padding = 3;

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase("Status", font10));
            datatable.addCell(new Phrase("Booking Type", font10));
            datatable.addCell(new Phrase("Gross Amt", font10));
            datatable.addCell(new Phrase("Area", font10));
            datatable.addCell(new Phrase("Total Ads", font10));

            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
          
            

            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Type"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["GrossAmt"].ToString()), font11));

                if (ds.Tables[0].Rows[row]["GrossAmt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["GrossAmt"].ToString());

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["count(*)"].ToString(), font11));
               

                row++;

            }
            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);
            PdfPTable tbltotal = new PdfPTable(6);
            float[] headerwidths = { 10, 5, 18, 15, 15, 15 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[66].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
        //    tbltotal.addCell(new Phrase(" ", font11));
         //   tbltotal.addCell(new Phrase(" ", font11));
       //     tbltotal.addCell(new Phrase(" ", font11));
           tbltotal.addCell(new Phrase(" ", font11));



        //    tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[66].ToString(), font10));
            tbltotal.addCell(new Phrase(chk_null(amt.ToString()), font11));

            //tbltotal.addCell(new Phrase(area.ToString(), font11));
          //  tbltotal.addCell(new Phrase(" ", font11));
          //  tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));
            document.Add(tbltotal);


            /************************            new         ***********************/


            //PdfPTable datatable11 = new PdfPTable(4);
            //datatable11.DefaultCell.Padding = 3;

            //datatable11.WidthPercentage = 100; // percentage
            //datatable11.DefaultCell.BorderWidth = 0;
            //datatable11.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable11.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;


            //datatable11.addCell(new Phrase("", font11));
            //datatable11.addCell(new Phrase("Count", font11));
            //datatable11.addCell(new Phrase("Area", font11));
            //datatable11.addCell(new Phrase("Net Amount", font11));




            //datatable11.addCell(new Phrase("Total Billed:-", font11));
            //datatable11.addCell(new Phrase(ds.Tables[1].Rows[0].ItemArray[0].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[1].Rows[0].ItemArray[1].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[1].Rows[0].ItemArray[2].ToString(), font11));


            //datatable11.addCell(new Phrase("Total Unbilled:-", font11));
            //datatable11.addCell(new Phrase(ds.Tables[2].Rows[0].ItemArray[0].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[2].Rows[0].ItemArray[1].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[3].Rows[0].ItemArray[2].ToString(), font11));


            //datatable11.addCell(new Phrase("Total Cancel:-", font11));
            //datatable11.addCell(new Phrase(ds.Tables[3].Rows[0].ItemArray[0].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[3].Rows[0].ItemArray[1].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[3].Rows[0].ItemArray[2].ToString(), font11));


            //datatable11.addCell(new Phrase("Total Publish:-", font11));
            //datatable11.addCell(new Phrase(ds.Tables[4].Rows[0].ItemArray[0].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[4].Rows[0].ItemArray[1].ToString(), font11));
            //datatable11.addCell(new Phrase(ds.Tables[4].Rows[0].ItemArray[2].ToString(), font11));





            //document.Add(datatable11);





          



            /*************************************************************************/

            document.Close();

            Response.Redirect(pdfName);



        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }




    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check1 = e.Item.Cells[3].Text;
        string amt = e.Item.Cells[3].Text;

        if (check1 != "GrossAmt")
        {
            if (check1 != "&nbsp;")
            {


                string totalarea = e.Item.Cells[3].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
         Session["prm_summarize_print"]="fromdate~" + fromdt + "~dateto~" + dateto + "~adtype~" + adtyp + "~destination~" + destination + "~publication~" + publ + "~pubcenter~" + pubcen + "~edition~" + edition + "~publicname~" + pubcname + "~publiccent~" + pubcname + "~editionname~" + editionname + "~adtypname~" + adtypname;
        Response.Redirect("summarised_report_print.aspx");
//        Response.Redirect("summarised_report_print.aspx?fromdate=" + fromdt + "&dateto=" + dateto + "&adtype=" + adtyp + "&destination=" + destination + "&publication=" + publ + "&pubcenter=" + pubcen + "&edition=" + edition + "&publicname=" + pubcname + "&publiccent=" + pubcname + "&editionname=" + editionname + "&adtypname=" + adtypname);

    }
}
