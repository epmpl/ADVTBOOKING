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
//using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Web.UI.WebControls;

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
    string dateto1 = "", agtype = "", agtypetext = "";
    
   int sno = 1;
    double comm1 = 0;
    double comm2 = 0;
    double areanew=0;
    double areasum = 0;
    string rundate = "";
   
    string adtypename ="";
    double amt = 0;
    double Arr = 0;
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;

      int ins_no = 0;
      string sortorder = "";
      string sortvalue = "";
    string    editionname="";
    string name1 = "", name2 = "", name3 = "";
    DataSet ds;
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
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

        ds = (DataSet)Session["statusad"];
        string prm = Session["prm_statusad"].ToString();
        string[] prm_Array = new string[39];
        prm_Array = prm.Split('~');

        agname = prm_Array[1];// Request.QueryString["agname"].ToString();
        adtyp = prm_Array[3]; //Request.QueryString["adtype"].ToString();
        adcat = prm_Array[5]; //Request.QueryString["adcategory"].ToString();
        fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();
        edition = prm_Array[19]; //Request.QueryString["edition"].ToString();
        destination = prm_Array[21]; //Request.QueryString["destination"].ToString();
        status1 = prm_Array[23]; //Request.QueryString["status1"].ToString();            
        adcatname = prm_Array[25]; //Request.QueryString["adcatname"].ToString();
        status = prm_Array[27]; //Request.QueryString["status"].ToString();
        adtypename = prm_Array[29]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[31]; //Request.QueryString["editionname"].ToString();
        hold = prm_Array[33]; //Request.QueryString["hold"].ToString();
        agtype = prm_Array[35]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[37]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[39];

           
            hiddendatefrom.Value = fromdt.ToString();
            Session["fromdate"]=fromdt;
            Session["todate"] = dateto;

            if (agtype == "0")
            {
                lblagtype.Text = "ALL".ToString();
            }
            else
            {
                lblagtype.Text = agtypetext.ToString();
            }

            if (adtyp == "0")
            {
                lbladtype.Text = "ALL".ToString();
            }
            else
            {
                lbladtype.Text = adtypename.ToString();
            }

            if ((adcat == "0") || (adcat == ""))
            {
                lbladcatg.Text = "ALL".ToString();
            }
            else
            {
                lbladcatg.Text = adcatname.ToString();
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


            if (edition == "0" || edition=="")
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
            rundate = date.ToString();
            


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

            if (status1 == "--Select Status--")
            {

                lbstatus.Text = "ALL".ToString();
            }
            else
            {
                lbstatus.Text = status1.ToString();
            }
            if (!Page.IsPostBack)
            {
                if (destination == "1" || destination == "0")
                {
                    onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
                }
                else if (destination == "4")
                {
                    excel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

                }
                else if(destination == "5")
                {
                    excelsummary(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
                }
                else if (destination == "6")
                {
                    excelsummary(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
                }
                else
                    if (destination == "3")
                    {
                        pdf(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
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

    /////////////////////////////////////////////////   excel generation    ////////////////////////////////////////


    private void excel(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
       
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
        //    ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", agtypetext);

        //}
        int cont = ds.Tables[0].Rows.Count;
        for (int u = 0; u < cont; u++)
        {

            if (ds.Tables[0].Rows[u]["Area"].ToString() != "")
            {
                //if (ds.Tables[0].Rows[u]["uom"].ToString() == "SQ0")
                //    area = area + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                //else if (ds.Tables[0].Rows[u]["uom"].ToString() == "LI0")
                //    totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                //else if (ds.Tables[0].Rows[u]["uom"].ToString() == "SQ1")
                //    totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                //else if (ds.Tables[0].Rows[u]["uom"].ToString() == "CC0")
                //    totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());


                if (ds.Tables[0].Rows[u]["uom"].ToString() == "CD" || ds.Tables[0].Rows[u]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());

            }
        }
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
            nameColumn.HeaderText = "Booking Id";
            nameColumn.DataField = "CIOID";
            name1 = name1 + "," + "Booking Id";
            name2 = name2 + "," + "CIOID";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn);

            BoundColumn nameColumn1 = new BoundColumn();
            nameColumn1.HeaderText = "Edition";
            nameColumn1.DataField = "edition";

            name1 = name1 + "," + "Edition";
            name2 = name2 + "," + "edition";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn1);

            BoundColumn nameColumn2 = new BoundColumn();
            nameColumn2.HeaderText = "Publish Date";
            nameColumn2.DataField = "Ins_Date";

            name1 = name1 + "," + "Publish Date";
            name2 = name2 + "," + "Ins_Date";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn2);

            BoundColumn nameColumn4 = new BoundColumn();
            nameColumn4.HeaderText = "Agency";
            nameColumn4.DataField = "Agency_Name";

            name1 = name1 + "," + "Agency";
            name2 = name2 + "," + "Agency";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn4);



            BoundColumn nameColumn6 = new BoundColumn();
            nameColumn6.HeaderText = "Client";
            nameColumn6.DataField = "Client_Name";

            name1 = name1 + "," + "Client";
            name2 = name2 + "," + "Client";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn6);

            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "Package";
            nameColumn7.DataField = "Package";

            name1 = name1 + "," + "Package";
            name2 = name2 + "," + "Package";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);

            BoundColumn nameColumn9 = new BoundColumn();
            nameColumn9.HeaderText = "Depth";
            nameColumn9.DataField = "Depth";

            name1 = name1 + "," + "Depth";
            name2 = name2 + "," + "Depth";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn9);

            BoundColumn nameColumn10 = new BoundColumn();
            nameColumn10.HeaderText = "Width";
            nameColumn10.DataField = "Width";

            name1 = name1 + "," + "Width";
            name2 = name2 + "," + "Width";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn10);

            BoundColumn nameColumn11 = new BoundColumn();
            nameColumn11.HeaderText = "Area";
            nameColumn11.DataField = "Area";

            name1 = name1 + "," + "Area";
            name2 = name2 + "," + "Area";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn11);

            BoundColumn nameColumn12 = new BoundColumn();
            nameColumn12.HeaderText = "Color";
            nameColumn12.DataField = "Color_code";

            name1 = name1 + "," + "Color";
            name2 = name2 + "," + "Color_code";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn12);

            BoundColumn nameColumn19 = new BoundColumn();
            nameColumn19.HeaderText = "AdCat";
            nameColumn19.DataField = "AdCat";

            name1 = name1 + "," + "AdCat";
            name2 = name2 + "," + "AdCat";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn19);

            BoundColumn name20Column20 = new BoundColumn();
            name20Column20.HeaderText = "RateCode";
            name20Column20.DataField = "RateCode";

            name1 = name1 + "," + "RateCode";
            name2 = name2 + "," + "RateCode";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(name20Column20);


            BoundColumn nameColumn20 = new BoundColumn();
            nameColumn20.HeaderText = "CardRate";
            nameColumn20.DataField = "CardRate";

            name1 = name1 + "," + "CardRate";
            name2 = name2 + "," + "CardRate";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn20);

            BoundColumn nameColumn22 = new BoundColumn();
            nameColumn22.HeaderText = "BillAmt";
            nameColumn22.DataField = "Amt";

            name1 = name1 + "," + "BillAmt";
            name2 = name2 + "," + "Amt";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn22);

            BoundColumn nameColumn13 = new BoundColumn();
            nameColumn13.HeaderText = "Disc";
            nameColumn13.DataField = "Disc";

            name1 = name1 + "," + "Disc";
            name2 = name2 + "," + "Disc";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn13);


            BoundColumn nameColumn14 = new BoundColumn();
            nameColumn14.HeaderText = "Status";
            nameColumn14.DataField = "Status";

            name1 = name1 + "," + "Status";
            name2 = name2 + "," + "Status";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn14);

            BoundColumn nameColumn15 = new BoundColumn();
            nameColumn15.HeaderText = "MatStatus";
            nameColumn15.DataField = "MatStatus";

            name1 = name1 + "," + "MatStatus";
            name2 = name2 + "," + "MatStatus";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn15);


            BoundColumn nameColumn16 = new BoundColumn();
            nameColumn16.HeaderText = "Caption";
            nameColumn16.DataField = "Cap";

            name1 = name1 + "," + "Caption";
            name2 = name2 + "," + "Cap";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn16);

            BoundColumn nameColumn17 = new BoundColumn();
            nameColumn17.HeaderText = "VARIANT";
            nameColumn17.DataField = "Key";

            name1 = name1 + "," + "VARIANT";
            name2 = name2 + "," + "Key";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn17);

            BoundColumn nameColumn18 = new BoundColumn();
            nameColumn18.HeaderText = "Page No";
            nameColumn18.DataField = "PAGE";

            name1 = name1 + "," + "Page No.";
            name2 = name2 + "," + "PAGE";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn18);

            BoundColumn nameColumn30 = new BoundColumn();
            nameColumn30.HeaderText = "PUB TYPE";
            nameColumn30.DataField = "pub_type";

            name1 = name1 + "," + "PUB TYPE";
            name2 = name2 + "," + "pub_type";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn30);
        
            BoundColumn nameColumn31 = new BoundColumn();
            nameColumn31.HeaderText = "Publishing Center";
            nameColumn31.DataField = "publishing_center";

            name1 = name1 + "," + "Publishing Center";
            name2 = name2 + "," + "publishing_center";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn31);


        

            DataGrid1.DataSource = ds;
            if (chk_excel == "1")
            {

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                DataGrid1.ShowHeader = true;
                DataGrid1.ShowFooter = true;
                DataGrid1.DataBind();
                hw.Write("<p <table border=\"1\"><tr><td colspan=\"20\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
                //hw.Write("<p <tr><td colspan=\"22\"align=\"center\"><b>" + "category wise Report" + "</b></td></tr>");
                //hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
                hw.Write("<p <tr><td colspan=\"20\"align=\"center\"><b>" + "Status Based Report" + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"20\"align=\"right\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
                hw.WriteBreak();
                //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Status Based Report<b>");
               
                DataGrid1.RenderControl(hw);
                double arr = comm2 / areanew;
                int sno11 = sno - 1;
                Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds  " + sno11 + "</td><td  colspan='2' align= 'right'>Total Words:" + totcc + "</td><td colspan='6' align= 'right'>Total Area:" + area + "</td><td  colspan='2' align= 'right'>Total Lines:" + totrol + "</td><td colspan='2' align='right'>Total Chars:" + totcd + "</td><td colspan='1'  align='right'>BillAmt:" + comm2 + "</td><td colspan='3'></td>></tr><tr><td colspan='3'>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));

            }
            else
            {
                string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                string[][] colProperties ={ names, captions, formats };

                QueryToCSV(ds, colProperties);
            }
            Response.Flush();
            Response.End();
            Response.Flush();
            Response.End(); 


       }


    private void excelsummary(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {

        SqlDataAdapter da = new SqlDataAdapter();
        int cont = ds.Tables[0].Rows.Count;
        for (int u = 0; u < cont; u++)
        {

            if (ds.Tables[0].Rows[u]["Area"].ToString() != "")
            {

                if (ds.Tables[0].Rows[u]["uom"].ToString() == "CD" || ds.Tables[0].Rows[u]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());

            }
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";

        Response.ContentType = "text/csv";
        
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
       
        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = "S.No";
        DataGrid1.Columns.Add(nameColumn0);



        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = "Booking Id";
        nameColumn.DataField = "CIOID";
        name1 = name1 + "," + "Booking Id";
        name2 = name2 + "," + "CIOID";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Edition";
        nameColumn1.DataField = "edition";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "edition";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Publish Date";
        nameColumn2.DataField = "Ins_Date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins_Date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Agency";
        nameColumn4.DataField = "Agency_Name";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);



        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Client";
        nameColumn6.DataField = "Client_Name";

        name1 = name1 + "," + "Client";
        name2 = name2 + "," + "Client";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "Package";
        nameColumn7.DataField = "Package";

        name1 = name1 + "," + "Package";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "Depth";
        nameColumn9.DataField = "Depth";

        name1 = name1 + "," + "Depth";
        name2 = name2 + "," + "Depth";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "Width";
        nameColumn10.DataField = "Width";

        name1 = name1 + "," + "Width";
        name2 = name2 + "," + "Width";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Area";
        nameColumn11.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);

        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Color";
        nameColumn12.DataField = "Color_code";

        name1 = name1 + "," + "Color";
        name2 = name2 + "," + "Color_code";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "AdCat";
        nameColumn19.DataField = "AdCat";

        name1 = name1 + "," + "AdCat";
        name2 = name2 + "," + "AdCat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn name20Column20 = new BoundColumn();
        name20Column20.HeaderText = "RateCode";
        name20Column20.DataField = "RateCode";

        name1 = name1 + "," + "RateCode";
        name2 = name2 + "," + "RateCode";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(name20Column20);


        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "CardRate";
        nameColumn20.DataField = "CardRate";

        name1 = name1 + "," + "CardRate";
        name2 = name2 + "," + "CardRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = "BillAmt";
        nameColumn22.DataField = "Amt";

        name1 = name1 + "," + "BillAmt";
        name2 = name2 + "," + "Amt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn22);

        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "Disc";
        nameColumn13.DataField = "Disc";

        name1 = name1 + "," + "Disc";
        name2 = name2 + "," + "Disc";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);


        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "Status";
        nameColumn14.DataField = "Status";

        name1 = name1 + "," + "Status";
        name2 = name2 + "," + "Status";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "MatStatus";
        nameColumn15.DataField = "MatStatus";

        name1 = name1 + "," + "MatStatus";
        name2 = name2 + "," + "MatStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);


        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "Caption";
        nameColumn16.DataField = "Cap";

        name1 = name1 + "," + "Caption";
        name2 = name2 + "," + "Cap";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "VARIANT";
        nameColumn17.DataField = "Key";

        name1 = name1 + "," + "VARIANT";
        name2 = name2 + "," + "Key";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "Page No";
        nameColumn18.DataField = "PAGE";

        name1 = name1 + "," + "Page No.";
        name2 = name2 + "," + "PAGE";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn30 = new BoundColumn();
        nameColumn30.HeaderText = "PUB TYPE";
        nameColumn30.DataField = "pub_type";

        name1 = name1 + "," + "PUB TYPE";
        name2 = name2 + "," + "pub_type";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn30);

        BoundColumn nameColumn31 = new BoundColumn();
        nameColumn31.HeaderText = "Publishing Center";
        nameColumn31.DataField = "publishing_center";

        name1 = name1 + "," + "Publishing Center";
        name2 = name2 + "," + "publishing_center";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn31);




        DataGrid1.DataSource = ds;
        if (chk_excel != "1")
        {

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p <table border=\"1\"><tr><td colspan=\"20\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
            //hw.Write("<p <tr><td colspan=\"22\"align=\"center\"><b>" + "category wise Report" + "</b></td></tr>");
            //hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            hw.Write("<p <tr><td colspan=\"20\"align=\"center\"><b>" + "Status Based Report" + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"20\"align=\"right\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
            hw.WriteBreak();
            //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Status Based Report<b>");

            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds  " + sno11 + "</td><td  colspan='2' align= 'right'>Total Words:" + totcc + "</td><td colspan='6' align= 'right'>Total Area:" + area + "</td><td  colspan='2' align= 'right'>Total Lines:" + totrol + "</td><td colspan='2' align='right'>Total Chars:" + totcd + "</td><td colspan='1'  align='right'>BillAmt:" + comm2 + "</td><td colspan='3'></td>></tr><tr><td colspan='3'>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));

        }
        else
        {
            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties = { names, captions, formats };

            QueryToCSV(ds, colProperties);
        }
        Response.Flush();
        Response.End();
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




    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
        //    ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", agtypetext);

        //}
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>";


        //tbl = tbl + ("<tr><td class='middle31new' width='1%'>S.</br>No</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='8%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='8%' align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp; HT</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp; WD</td><td  class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle31new'  width='2%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;AdCat</td><td  class='middle31new' width='4%' align='right'>&nbsp;&nbsp;CardRate</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt.&nbsp;&nbsp;</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Disc</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Status</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Material</br>&nbsp;&nbsp;Status</td><td class='middle31new'  width='4%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No.</td></tr>");

        tbl = tbl + ("<tr><td class='middle31new' width='1%'>S.</br>No</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='8%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='8%' align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='6%' align='right'>&nbsp;&nbsp; HT</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp; WD</td><td  class='middle31new' width='3%' align='right'> &nbsp;&nbsp;Area</td><td  class='middle31new' width='3%' align='right'> &nbsp;&nbsp;Page No</td><td class='middle31new'  width='2%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;AdCat</td><td  class='middle31new' width='4%' align='right'>&nbsp;&nbsp;CardRate</td><td class='middle31new' width='4%' align='right' >Bill&nbsp;&nbsp;</br>Amt.&nbsp;&nbsp;</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Discount</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Status</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Material</br>&nbsp;&nbsp;Status</td><td class='middle31new'  width='3%' colspan='2'align='left'>&nbsp;&nbsp;Caption </br>&nbsp;&nbsp;VARIANT</td></tr>");



        int i1 = 1;
     
        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr>");
           
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            if (rrr.Length >= 10)
            {
                cioid1 = rrr.Substring(0, 10);
                if (rrr.Length - 10 < 10)
                    cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                else
                    cioid1 += "</br>" + rrr.Substring(10, 10);
            }
            else
                cioid1 = rrr;


            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (cioid1 + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");


            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins_Date"] + "</td>");


            //string agency1 = "";
            //string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            //char[] agency = rrr1.ToCharArray();
            //int len111 = agency.Length;
            //int line11 = 0;
            //int ch_end1 = 0;
            //int ch_str1 = 0;
            //for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            //{
            //    /**/
            //    ch_end1 = ch_end1 + 16;
            //    ch_str1 = ch_end1;
            //    if (ch_end1 > len111)
            //        ch_str1 = len111 - ch1;
            //    else
            //        ch_str1 = ch_end1 - ch1;

            //    agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
            //    agency1 = agency1 + "</br>";
            //    ch1 = ch1 + 16;
            //    if (ch1 > len111)
            //        ch1 = len111;/**/
            //}
            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency_Name"].ToString();
            if (rrr1.Length >= 16)
            {
                agency1 = rrr1.Substring(0, 16);
                if (rrr1.Length - 16 < 16)
                    agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                else
                    agency1 += "</br>" + rrr1.Substring(16, 16);
            }
            else
                agency1 = rrr1;

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (agency1 + "</td>");



            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");  
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");




            //string client1 = "";
            //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            //char[] client = rrr11.ToCharArray();
            //int len1111 = client.Length;
            //int line = 0;
            //int ch_end11 = 0;
            //int ch_str11 = 0;
            //for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            //{
            //    /* */
            //    ch_end11 = ch_end11 + 16;
            //    ch_str11 = ch_end11;
            //    if (ch_end11 > len1111)
            //        ch_str11 = len1111 - ch11;
            //    else
            //        ch_str11 = ch_end11 - ch11;

            //    client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
            //    client1 = client1 + "</br>";
            //    ch11 = ch11 + 16;
            //    if (ch11 > len1111)
            //        ch11 = len1111;
            //}
            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["Client_Name"].ToString();
            if (rrr2.Length >= 16)
            {
                client1 = rrr2.Substring(0, 16);
                if (rrr2.Length - 16 < 16)
                    client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                else
                    client1 += "</br>" + rrr2.Substring(16, 16);
            }
            else
                client1 = rrr2;


            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (client1 + "</td>");




            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");  
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");


            //string Package1 = "";
            //string rrr111111 = ds.Tables[0].Rows[i]["Package"].ToString();
            //char[] Package = rrr111111.ToCharArray();
            //int len11111111 = Package.Length;
            //int line1111111 = 0;
            //int ch_end111 = 0;
            //int ch_str111 = 0;
            //for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
            //{
            //    /**/
            //    ch_end111 = ch_end111 + 9;
            //    ch_str111 = ch_end111;
            //    if (ch_end111 > len11111111)
            //        ch_str111 = len11111111 - ch111111;
            //    else
            //        ch_str111 = ch_end111 - ch111111;

            //    Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
            //    Package1 = Package1 + "</br>";
            //    ch111111 = ch111111 + 9;
            //    if (ch111111 > len11111111)
            //        ch111111 = len11111111;
            //}
            string Package1 = "";
            string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
            if (rrr3.Length >= 9)
            {
                Package1 = rrr3.Substring(0, 9);
                if (rrr3.Length - 9 < 9)
                    Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                else
                    Package1 += "</br>" + rrr3.Substring(9, 9);
            }
            else
                Package1 = rrr3;
            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (Package1 + "</td>");




            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            // area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"].ToString());
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
            {


                if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());


            }

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>&nbsp&nbsp");
            tbl = tbl + (ds.Tables[0].Rows[i]["PAGE"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>&nbsp&nbsp");
            tbl = tbl + (ds.Tables[0].Rows[i]["Color_code"] + "</td>");


            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'> ");


            if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {

                tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
            }




            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

            if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {

                tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");               
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
            }

            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[19].ToString() + "</td>");
            //if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                //
            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Disc"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[20].ToString() + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["MatStatus"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
            tbl = tbl + ds.Tables[0].Rows[i]["Cap"];
            tbl = tbl + "</br>";
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
            //  tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");

            //     tbl = tbl + "</tr>";

            tbl = tbl + "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";
        }




        //tbl = tbl + ("<tr><td class='middle13new' colspan='4' style='font-size: 13px;' ><b>Total:</b></td>");


        //tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 13px;' align='right'><b>Area:</b></td>");
        //tbl = tbl + ("<td class='middle13new' colspan='3' style='font-size: 13px;' align='left'><b>");
        //tbl = tbl + (area.ToString() + "</b></td>");

        //tbl = tbl + ("<td class='middle13new' colspan='3' style='font-size: 13px;' align='right'><b>Amt:</b></td>");
        //tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 13px;' align='left'><b>");
        //tbl = tbl + (amt.ToString() + "</b></td>");
        //tbl = tbl + "</tr>";
        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + (i1 - 1).ToString() + "</td>");
        //tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'>&nbsp;</td>");


        if (totcc > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            tbl = tbl + (calft.ToString() + "</td>");
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }

        tbl = tbl + ("<td class='middle1212' colspan='6' align='right'><b>Total Area:</b>");
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl = tbl + (cal.ToString() + "</td>");

        if (totrol > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Lines:</b>");
            double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            tbl = tbl + (calf.ToString() + "</td>");
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }

        tbl = tbl + ("<td class='middle13new' colspan='2' align='right' style='font-size: 12px;'><b>BillAmt:</b>");
        //tbl = tbl + ("<td class='middle13new' colspan='3' style='font-size: 12px;'>");
        tbl = tbl + (amt.ToString() + "</td>");
        if (totcd > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Chars:</b>");
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            tbl = tbl + (calfd.ToString() + "</td>");
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }
       


        //////////////////////////
        

       
        tbl = tbl + "</tr>";
        tbl += "</table>";
        //tblgrid.InnerHtml = tbl;
        tblgrid.InnerHtml += tbl;

    }

    private void pdf(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {


      
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
       
        int NumColumns = 20;
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase("Page No. " + i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;
        document.Open();
        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------
       

        try
        {

            SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{

            //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
            //    ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", agtypetext);
            //}

            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //    ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", agtypetext);

            //}

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

            //Table tbl = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;

            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // tbl.addCell(new Phrase("List of ADS", font9));
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));
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

            PdfPTable tbl2 = new PdfPTable(8);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            tbl2.addCell(new Phrase("Publication", font10));
            tbl2.addCell(new Phrase(lblpub.Text, font11));
            tbl2.addCell(new Phrase("Pub Center", font10));
            tbl2.addCell(new Phrase(pcenter.Text, font11));
            tbl2.addCell(new Phrase("Edition", font10));
            tbl2.addCell(new Phrase(lbedition.Text, font11));
            tbl2.addCell(new Phrase("Status", font10));
            tbl2.addCell(new Phrase(lbstatus.Text, font11));



            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(rundate, font11));
            tbl2.addCell(new Phrase("Agency Type", font10));
            tbl2.addCell(new Phrase(lblagtype.Text, font11));



            tbl2.addCell(new Phrase("Ad Type", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));
            tbl2.addCell(new Phrase("Ad Category", font10));
            tbl2.addCell(new Phrase(lbladcatg.Text, font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));
            
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            PdfPTable tbl91 = new PdfPTable(NumColumns);
            tbl91.DefaultCell.BorderWidth = 0;
            tbl91.WidthPercentage = 100;
            tbl91.DefaultCell.Colspan = NumColumns;
            tbl91.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl91);
            //------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;



           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            
         //   datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
            
            
         //   datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase("BillAmt", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[23].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[25].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            
            datatable.HeaderRows = 1;
            //Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());

            //document.Add(p2);
            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
               
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    //area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                    if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    {
                        //if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ0")
                        //    area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "LI0")
                        //    totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ1")
                        //    totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "CC0")
                        //    totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());




                        if (ds.Tables[0].Rows[row]["uom"].ToString() == "CD" || ds.Tables[0].Rows[row]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());

                    } 
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color_code"].ToString(), font11));
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
                   
                    //row++;

            }




            document.Add(datatable);
            //Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            //document.Add(p3);


            PdfPTable tbltotal = new PdfPTable(20);
            //float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 10, 10, 13, 10, 20 }; // percentage
            //tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.Colspan = 20;
            tbltotal.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString()+(i1 - 1).ToString(), font10));
            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.DefaultCell.Colspan = 1;
            tbltotal.DefaultCell.Colspan = 2;
            if (totcc > 0)
            {

                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                tbltotal.addCell(new Phrase("Words:" + calft.ToString(), font10));
                //tbltotal.addCell(new Phrase(calft.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" "+ "", font11));
                //tbltotal.addCell(new Phrase(" ", font11));
            }
            tbltotal.DefaultCell.Colspan = 1;
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase("Area:"+ area.ToString(), font10));
            tbltotal.DefaultCell.Colspan = 1;
            //tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
           
           
            tbltotal.DefaultCell.Colspan = 2;
            if (totrol > 0)
            {
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                tbltotal.addCell(new Phrase("Lines:" + calf.ToString(), font10));
                
               // tbltotal.addCell(new Phrase(calf.ToString(), font11));


            }
            else
            {
                tbltotal.addCell(new Phrase(" " + "", font11));
                //tbltotal.addCell(new Phrase(" ", font11));
            }
             tbltotal.DefaultCell.Colspan = 1;
             tbltotal.DefaultCell.Colspan = 3;
             tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
             tbltotal.addCell(new Phrase("BillAmt:" + amt.ToString(), font10));
             //tbltotal.addCell(new Phrase(amt.ToString(), font11));
             tbltotal.DefaultCell.Colspan = 1;
             tbltotal.DefaultCell.Colspan = 2;
            if (totcd > 0)
            {
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                tbltotal.addCell(new Phrase("Chars:" + calfd.ToString(), font10));
               
                //tbltotal.addCell(new Phrase(calfd.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" " + "", font11));
                //tbltotal.addCell(new Phrase(" ", font11));
            }
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));

            //tbltotal.addCell(new Phrase(" ", font11));
            document.Add(tbltotal);

            ////////////////////////////////////////////////////////////////////////////////////////

            //Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            //document.Add(p4);

            //PdfPTable tbltotal1 = new PdfPTable(4);
            //float[] headerwidths11 = { 5, 3, 20, 70 }; // percentage
            //tbltotal1.setWidths(headerwidths11);
            //tbltotal1.DefaultCell.BorderWidth = 0;
            //tbltotal1.WidthPercentage = 100;
            //tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            //double arr = amt / area;
            //tbltotal1.addCell(new Phrase("ARR", font10));
            //tbltotal1.addCell(new Phrase(" : ", font10));
            //tbltotal1.addCell(new Phrase(Math.Round(arr).ToString(), font10));
            //tbltotal1.addCell(new Phrase(" ", font10));
            //document.Add(tbltotal1);

            //////////////////////////////////////////////////////////////////////////////////////
            PdfPTable tbl911 = new PdfPTable(20);
            tbl911.DefaultCell.BorderWidth = 0;
            tbl911.WidthPercentage = 100;
            tbl911.DefaultCell.Colspan = 20;
            tbl911.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl911);
            document.Close();
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
        Session["prm_statusad_print"] = "agname~" + agname + "~adtype~" + adtyp + "~adcategory~" + adcat + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~pubcenter~" + pubcen + "~publicname~" + pubcname + "~publiccent~" + pub2 + "~edition~" + edition + "~status1~" + status1 + "~adcatname~" + adcatname + "~status~" + status + "~adtypename~" + adtypename + "~editionname~" + editionname + "~hold~" + hold + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
        Response.Redirect("reportstatusprint.aspx");
      //  Response.Redirect("reportstatusprint.aspx?agname=" + agname + "&adtype=" + adtyp + "&adcategory=" + adcat + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&pubcenter=" + pubcen + "&publicname=" + pubcname + "&publiccent=" + pub2 + "&edition=" + edition + "&status1=" + status1 + "&adcatname=" + adcatname + "&status=" + status + "&adtypename=" + adtypename + "&editionname=" + editionname + "&hold=" + hold + "&agtype1=" + agtype + "&agtypetext=" + agtypetext);

    }
    
    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
       
        
            string sno1 = e.Item.Cells[0].Text;
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
            }
            
            string check1 = e.Item.Cells[9].Text;
            string area = e.Item.Cells[9].Text;

            if (check1 != "Area")
            {
                if (check1 != "&nbsp;")
                {


                    string totalarea = e.Item.Cells[9].Text;
                    areasum = Convert.ToDouble(totalarea);
                    areanew = areanew + areasum;


                }
            }

          
            string check = e.Item.Cells[14].Text;
            string amt = e.Item.Cells[14].Text;

            if (check != "BillAmt")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[14].Text;
                    comm1 = Convert.ToDouble(grossamt);
                    comm2 = comm2 + comm1;

                }
            }
            
       
    }
   
}





