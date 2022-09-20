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
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

public partial class Reports_vtsviewpage : System.Web.UI.Page
{
    string Tables = "";
    string clientname = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string branchcode = "";
    string ban1 = "";
    string edit = "";
    string editioncode = "";
    string pubcen = "";
    string pubcenter = "";
    string publication = "";
    //string edition = "";
    string date = "";
    string PUB_DATE = "";
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "", agency_code1 = "", agency_name1 = "", despub = "";
    string client = "";
    string agname = "";
    string agency_code = "";
    string client_code = "";
    string from_date = "";
    string to_date = "";
    string report_name1 = "";
    string publi = "";
    string pub_center = "";
    string chk_access = "";
    string status = "";
    string status1 = "";
    string hold = "";
    string adtypename = "";
    string edition = "";
    string edition_code1 = "";
    string branch_code1 = "";
    string agencyname = "";
    string fromdate = "";
    string agtype = "", CIOID = "", branch = "", dppub1 = "", agnecyname = "", pubnamecode = "", pubcentcode = "", branch_code = "", agnecycode = "", txttodate1 = "", clientcode = "", branch_c = "", dpclient = "", txtfrmdate = "", dateformat = "", useid = "", chk_acc = "", compcode = "", agencychk = "";
    string TBL = "";
    double area = 0;
    double totrol = 0;

    double totcd = 0;
    double totcc = 0;
    string dttoal = "";
    string package = "", pubname = "", pubcent = "", extra1 = "", extra2 = "";
    string sortorder = "";
    string sortvalue = "";
    double areanew = 0;
    int sno = 0;
 
    double comm2 = 0;
    int maxlimit = 10;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    int a = 0;
    int rr1 = 0;
    string rr2 = "";
    System.Web.HttpBrowserCapabilities browser;
    double ver;
    string clienttype = "";
    string dpdadtype = "";
    string clienttypeName="";
    string dpdadtypeName = "";
    string reporttype = "";
    string state = "";
    
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[55].ToString());
       maxlimit = 8;


        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        DataSet ds2 = new DataSet();
        ds2.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));
        comp_name.Text = ds2.Tables[0].Rows[0].ItemArray[6].ToString();
        //Session["AGENCY"] = heading.Text;
        // ds.ReadXml(Server.MapPath("XML/vtheader.xml"));


        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }



        agnecycode = Request.QueryString["agency_code1"].ToString();
        agnecyname = Request.QueryString["agency_name1"].ToString();
        clientcode = Request.QueryString["client_code1"].ToString();
        clientname = Request.QueryString["client_name1"].ToString();
        fromdate = Request.QueryString["from_date1"].ToString();
        dateto = Request.QueryString["todate1"].ToString();
        pubname = Request.QueryString["pub_name1"].ToString();
        pubnamecode = Request.QueryString["pub_code1"].ToString();
        edition = Request.QueryString["edition_name1"].ToString();
        editioncode = Request.QueryString["edition_code1"].ToString();
        pubcentcode = Request.QueryString["publication_center1"].ToString();
        branch_c = Request.QueryString["branch_name1"].ToString();
        branchcode = Request.QueryString["branch_code1"].ToString();
       
        pubcenter = Request.QueryString["pub_center1"].ToString();
        useid = Request.QueryString["userid1"].ToString();
        destination = Request.QueryString["dest1"].ToString();
        clienttype = Request.QueryString["clienttype"].ToString();
        dpdadtype = Request.QueryString["dpdadtype"].ToString();
        clienttypeName = Request.QueryString["clienttypeName"].ToString();
        dpdadtypeName = Request.QueryString["dpdadtypeName"].ToString();
        reporttype = Request.QueryString["reporttype"].ToString();
        state = Request.QueryString["state"].ToString();


        //agtype = branch_c;
        //if (agtype != "--Select Branch--")
        //{
        //    lblagtype.Text = "ALL".ToString();
        //}
        //if (agtype == "--Select Branch--")
        //{
        //    lblagtype.Text = branch_c.ToString();
        //}
        //publ = pubname;
        //if (publ != "0")
        //{
        //    lblpub.Text = pubname.ToString();
        //}
        //else
        //{
        //    lblpub.Text = "ALL".ToString();
        //}
        //pubcen = pubcenter;
        //if (pubcen != "0")
        //{
        //    pcenter.Text = pubcenter.ToString();
        //}
        //else
        //{
        //    pcenter.Text = "ALL".ToString();
        //}

        //agtype = branch_c;
        if (branchcode == "0" || branchcode == "")
        {
            lbbranch.Text = "ALL".ToString();
        }
        else
        {
            lbbranch.Text = branch_c.ToString();
        }



        if (editioncode == "0" || editioncode == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = edition.ToString();

        }
        

        if (pubcentcode == "0" || pubcentcode == "")
        {
            pcenter.Text = "ALL".ToString();
        }
        else
        {
            pcenter.Text = pubcenter.ToString();
        }



        if (dpdadtype == "0" || dpdadtype == "")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = dpdadtypeName.ToString();

        }


        if (clienttype == "0" || clienttype == "")
        {
            lblclientype.Text = "ALL".ToString();
        }
        else
        {
            lblclientype.Text = clienttypeName.ToString();

        }




        //if (agtype == "0" || agtype == "")
        //{
        //    lblagtype.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lblagtype.Text = branch_c.ToString();

        //}
      
        if (pubnamecode == "0" || pubnamecode == "")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = pubname.ToString();
        }
        //if (pubcen == "0" || pubcen == "")
        //{
        //    pcenter.Text = "ALL".ToString();
        //}
        //else
        //{
        //    pcenter.Text = pubcent.ToString();
        //}

        ////if (clientname == "0" || clientname == "")
        ////{

        ////    lbclient.Text = "ALL".ToString();
        ////}
        ////else
        ////{
        ////    lbclient.Text = dpclient.ToString();
        ////}

        //if (edition == "0" || edition == "")
        //{
        //    lbedition.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lbedition.Text = edition.ToString();



        //}



        if (fromdate != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = month + "/" + day + "/" + year;

                }
                 else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = year + "/" + month + "/" + day;
                }
            }
        }
        lblfrom.Text = fromdate;
        //dateto1 = "";
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto = dd + "/" + mm + "/" + yy;

            }


            else
            {

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto = day + "/" + month + "/" + year;

                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto = year + "/" + month + "/" + day;
                }
            }
        }
        lblto.Text = dateto;

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
        if (!Page.IsPostBack)
        {
            if (destination == "0" || destination == "1")
            {
                onscreen();//(edition, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_access, extra1, extra2);
            }
            else if (destination == "4")
            {
                excel ();//(edition, agnecycode, fromdate, dateto, clientcode, pubname, pubcent, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_access, extra1, extra2);
            }
            else if (destination == "3")
            {
              
                pdf();//(edition, agency_code, from_date, to_date, client_code, publication, pub_center, branch, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(),  chk_access, extra1, extra2);
    
            }
    

        }

    }



    private void onscreen()//string edition, string agencycode, string fromdate, string dateto, string clientcode, string pubnamecode, string pubcentcode, string branchcode, string dateformat, string userid, string compcode, string chk_access, string extra1, string extra2)
    {
        int m11 = 0;
        string page = "";
        string position = "";
        double vts = 0;
        double rate = 0;
        double amt = 0;

        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            fromdate = DMYToMDY(fromdate);
            dateto = DMYToMDY(dateto);
        }


        else if (hiddendateformat.Value == "yyyy/mm/dd")
        {
            fromdate = YMDToMDY(fromdate);
            dateto = YMDToMDY(dateto);
        }

        StringBuilder TBL = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        
        DataSet ds1 = new DataSet();

       
            if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
                ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, reporttype, state);

            }
            else if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
                ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, reporttype, state);

            }
            else
            {
                string procedureName = "Rpt_vts_Report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, reporttype, state };
                ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            Session["vtsreport"]=ds1;

        //catch (Exception ex)
        //{
        //    throw (ex);
        //}

        
        
        //subregrepDiv.InnerHtml = TBL.ToString();

        int cont = ds1.Tables[0].Rows.Count;

        if (ds1.Tables[0].Rows.Count > 0)
        {
            comp_name.Text = ds1.Tables[0].Rows[0]["COMP_NAME"].ToString();
            DataSet ds_xml = new DataSet();
            ds_xml.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));
            report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[12].ToString();

            TBL.Append("<table cellspacing='0px' cellpadding = '0px' width='100%' border='0'colspan='2' >");
           // TBL.Append("<table width=100%>");
            TBL.Append("<tr><td class='middle31new'align='left' width='2%'>");
            TBL.Append("Sno.</td>");

            TBL.Append("<td class='middle31new'align='left' width='9%'>");
            TBL.Append("Booking ID</td>");

            TBL.Append("<td class='middle31new'align='left' width='15%'>");
            TBL.Append("Agency Name</td>");
            TBL.Append("<td class='middle31new'align='left' width='20%'>");
            TBL.Append("Agency Address</td>");

            TBL.Append("<td class='middle31new'align='left' width='13%'>");
            TBL.Append("client Name</td>");
            TBL.Append("<td class='middle31new'align='left' width='15%'>");
            TBL.Append("client Address</td>");
            //TBL.Append("<td class='middle31new'align='left' width='10%'>");
            //TBL.Append("Edition</td>");
            TBL.Append("<td class='middle31new'align='left' width='13%'>");
            TBL.Append("Package</td>");
            TBL.Append("<td class='middle31new'align='left' width='4%'>");
            TBL.Append("Publish Date</td>");
            TBL.Append("<td class='middle31new' align='left' width='4%'>");
            TBL.Append("VTS(No.ofcopies)</td>");

            TBL.Append("<td class='middle31new' align='right' width='5%'>");
            TBL.Append("VTS(Rate)</td>");
            TBL.Append("<td class='middle31new' align='right' width='5%'>");
            TBL.Append("VTS(Amount)</td>");



            TBL.Append("</tr>");




            // ======================================= For values ===================================================

            Double dttoal=0,SUM = 0;
            double dttoalamt = 0;

            for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
            {
                if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "" || ds1.Tables[0].Rows[m]["CIRRATE"].ToString()==null)
                    SUM = 0;
                else
                 SUM = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"]);
             sno++;
                dttoal = dttoal + SUM;
            
                TBL.Append("<tr>");
                TBL.Append("<td class='rep_data' ' align='left' width='2%'>");
                TBL.Append(sno + "</td>");

                TBL.Append("<td class='rep_data' ' align='left' width='9%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["CIOID"].ToString() + "</td>");

                TBL.Append("<td class='rep_data' ' align='left' width='15%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["AGENCY"].ToString() + "</td>");

                TBL.Append("<td class='rep_data' ' align='left' width='20%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["Add1"].ToString() + ds1.Tables[0].Rows[m]["Add2"].ToString() + ds1.Tables[0].Rows[m]["Add3"].ToString() + ds1.Tables[0].Rows[m]["CITY_NAME"].ToString() + "</td>");

                TBL.Append("<td class='rep_data'  align='left' width='15%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["CLIENT"].ToString() + "</td>");

                TBL.Append("<td class='rep_data'  align='left' width='13%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["CLIENT_ADDR"].ToString() + "</td>");

                //TBL.Append("<td class='rep_data' align='left' width='10%'>");
                //TBL.Append(ds1.Tables[0].Rows[m]["EDITION"].ToString() + "</td>");

                TBL.Append("<td class='rep_data' align='left' width='13%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["PACKAGE_NAME"].ToString() + "</td>");

                TBL.Append("<td class='rep_data'  align='left' width='4%'>");
                
                
                string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 9);


                if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
                { 
               
                 TBL.Append(rrR.ToString() + "</td>");
             }
                else if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
                {
                    string[] arr = rrR.Split('/');
                    string mm = arr[0].ToString();
                    string dd = arr[1].ToString();
                    string yy = arr[2].ToString();
                    rr2 = dd + "/" + mm + "/" + yy;
                    TBL.Append(rr2.ToString() + "</td>");
                }
                else
                {
                    string[] arr = rrR.Split('/');
                    string mm = arr[0].ToString();
                    string dd = arr[1].ToString();
                    string yy = arr[2].ToString();
                    rr2 = dd + "/" + mm + "/" + yy;
                    TBL.Append(rr2.ToString() + "</td>");
                }


                TBL.Append("<td class='rep_data'  align='center' width='4%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["VTS"].ToString() + "</td>");
                if (ds1.Tables[0].Rows[m]["VTS"].ToString() == "")
                    vts = 0.00;
                else
                vts = Convert.ToDouble(ds1.Tables[0].Rows[m]["VTS"].ToString());
                TBL.Append("<td class='rep_data'  align='right' width='5%'>");
                TBL.Append(chk_null(ds1.Tables[0].Rows[m]["CIRRATE"].ToString()) + "</td>");
                if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "" || ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == null)
                    rate = 0;
                else
                    rate = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"]);
                //rate = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"].ToString());
                TBL.Append("<td class='rep_data'  align='right'>");
                amt = vts * rate;
                TBL.Append(amt + "<td>");
                dttoalamt = dttoalamt + amt;




                TBL.Append("</tr>");

                TBL.Append("<tr>");
                TBL.Append("<td class='rep_data'align='left' width='10%'>");
                TBL.Append("<b>Edition:</b></td>");
                TBL.Append("<td class='rep_data' align='left'colspan='5' width='10%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["EDITION"].ToString() + "</td>");
                TBL.Append("</tr>");
                TBL.Append("<tr>");
                TBL.Append("<td class='rep_data'align='left' width='10%'>");
                TBL.Append("&nbsp;" + "</td>");
                TBL.Append("</tr>");
           
            }




            TBL.Append("<tr>");
            TBL.Append("<td class='middle31new'  align='left'>");
            TBL.Append("TOTAL</td>");
            TBL.Append("<td class='middle31new'  align='left'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new' align='left'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='left'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new' align='right'>");
            TBL.Append(chk_null(dttoal.ToString()) + "</td>");
            TBL.Append("<td class='middle31new' align='right'>");
            TBL.Append(chk_null(dttoalamt.ToString()) + "</td>");
            TBL.Append("</tr>");


        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_vtsviewpage), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
            return;
        }

        tblgrid.InnerHtml = TBL.ToString();


    }



    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        double sumamt = 0;
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check1 = e.Item.Cells[7].Text;
        string amt1 = e.Item.Cells[7].Text;

        //area
        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {
                string arean = e.Item.Cells[7].Text;
                areanew = areanew + Convert.ToDouble(arean);
            }
        }
    }



    private void excel()//string edition, string agency_code, string from_date, string to_date, string client_code, string publication, string pub_center, string branch, string dateformat, string useid, string compcode, string chk_access, string extra1, string extra2)
    {

        StringBuilder TBL = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();
        double vts = 0;
        double rate = 0;
        double amt = 0;
        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            fromdate = DMYToMDY(fromdate);
            dateto = DMYToMDY(dateto);
        }


        else if (hiddendateformat.Value == "yyyy/mm/dd")
        {
            fromdate = YMDToMDY(fromdate);
            dateto = YMDToMDY(dateto);
        }

        
        
            if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
                ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, reporttype, state);

            }
            else if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
                ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, reporttype, state);

            }
            else
            {
                string procedureName = "Rpt_vts_Report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, reporttype, state };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
        
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        TBL.Append("<table><tr><td align=left><b>Publication:</b>" + lblpub.Text + "</td>");

        TBL.Append("<td align=left><b>Pubcenter:</b>" + pcenter.Text + "</td>");
        TBL.Append("<td align=left><b>");
        TBL.Append("Branch</b>" + lbbranch.Text + "</td>");
        TBL.Append("<td align=left><b>");
        TBL.Append("Client Type</b>" + lblclientype.Text + "</td>");
        TBL.Append("<td align=left><b>");
        TBL.Append("Adtype</b>" + lbladtype.Text + "</td>");




        TBL.Append("<tr><td align=left><b>Date From:</b>" + fromdate + "</td>");
        TBL.Append("<td align=left><b>Date To:</b>" + dateto + "</td>");
        TBL.Append("<td align=left><b>");
        TBL.Append("Edition</b>" + lbedition.Text + "</td>");
        TBL.Append("<td align=left><b>");
        TBL.Append("</td>");
       // TBL.Append("<td>");
       // TBL.Append("</td>");
        TBL.Append("<td align=left><b>Run Date:</b>" + date + "</td>");

        int cont = ds1.Tables[0].Rows.Count;

        comp_name.Text = ds1.Tables[0].Rows[0]["COMP_NAME"].ToString();
            TBL.Append("<table cellspacing='0px' cellpadding = '0px' width='100%' border='1'colspan='2' >");
            // TBL.Append("<table width=100%>");
            TBL.Append("<tr><td class='middle31new'align='left' width='2%'>");
            TBL.Append("Sno.</td>");

            TBL.Append("<td class='middle31new'align='left' width='9%'>");
            TBL.Append("Booking ID</td>");

            TBL.Append("<td class='middle31new'align='left' width='15%'>");
            TBL.Append("Agency Name</td>");
            TBL.Append("<td class='middle31new'align='left' width='20%'>");
            TBL.Append("Agency Address</td>");

            TBL.Append("<td class='middle31new'align='left' width='13%'>");
            TBL.Append("client Name</td>");
            TBL.Append("<td class='middle31new'align='left' width='15%'>");
            TBL.Append("client Address</td>");
            //TBL.Append("<td class='middle31new'align='left' width='10%'>");
            //TBL.Append("Edition</td>");
            TBL.Append("<td class='middle31new'align='left' width='13%'>");
            TBL.Append("Package</td>");
            TBL.Append("<td class='middle31new'align='left' width='4%'>");
            TBL.Append("Publish Date</td>");
            TBL.Append("<td class='middle31new' align='left' width='4%'>");
            TBL.Append("VTS(No.ofcopies)</td>");
            TBL.Append("<td class='middle31new' align='right' width='5%'>");
            TBL.Append("VTS(Rate)</td>");
            TBL.Append("<td class='middle31new' align='right' width='5%'>");
            TBL.Append("VTS(Amount)</td>");


            TBL.Append("</tr>");




            // ======================================= For values ===================================================

            Double dttoal = 0, SUM = 0;
            double dttoalamt = 0;


            for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
            {
                if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "")
                    SUM = 0;
                else
                    SUM = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"]);
                sno++;
                dttoal = dttoal + SUM;

                TBL.Append("<tr>");
                TBL.Append("<td class='rep_data' ' align='left' width='2%'>");
                TBL.Append(sno + "</td>");

                TBL.Append("<td class='rep_data' ' align='left' width='9%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["CIOID"].ToString() + "</td>");

                TBL.Append("<td class='rep_data' ' align='left' width='15%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["AGENCY"].ToString() + "</td>");

                TBL.Append("<td class='rep_data' ' align='left' width='20%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["Add1"].ToString() + ds1.Tables[0].Rows[m]["Add2"].ToString() + ds1.Tables[0].Rows[m]["Add3"].ToString() + ds1.Tables[0].Rows[m]["CITY_NAME"].ToString() + "</td>");

                TBL.Append("<td class='rep_data'  align='left' width='15%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["CLIENT"].ToString() + "</td>");

                TBL.Append("<td class='rep_data'  align='left' width='13%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["CLIENT_ADDR"].ToString() + "</td>");

                //TBL.Append("<td class='rep_data' align='left' width='10%'>");
                //TBL.Append(ds1.Tables[0].Rows[m]["EDITION"].ToString() + "</td>");

                TBL.Append("<td class='rep_data' align='left' width='13%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["PACKAGE_NAME"].ToString() + "</td>");

                TBL.Append("<td class='rep_data'  align='left' width='4%'>");


                string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 9);


                if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
                {

                    TBL.Append(rrR.ToString() + "</td>");
                }
                else
                {
                    string[] arr = rrR.Split('/');
                    string mm = arr[0].ToString();
                    string dd = arr[1].ToString();
                    string yy = arr[2].ToString();
                    rr2 = dd + "/" + mm + "/" + yy;
                    TBL.Append(rr2.ToString() + "</td>");
                }

                TBL.Append("<td class='rep_data'  align='center' width='4%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["VTS"].ToString() + "</td>");
                if (ds1.Tables[0].Rows[m]["VTS"].ToString() == "")
                    vts = 0;
                else
                vts = Convert.ToDouble(ds1.Tables[0].Rows[m]["VTS"].ToString());
                TBL.Append("<td class='rep_data'  align='right' width='5%'>");
                TBL.Append(chk_null(ds1.Tables[0].Rows[m]["CIRRATE"].ToString()) + "</td>");
                if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "")
                    rate = 0;
                else
                rate = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"].ToString());
                TBL.Append("<td class='rep_data'  align='right'>");
                amt = vts * rate;
                TBL.Append(amt + "<td>");
                dttoalamt = dttoalamt + amt;




                TBL.Append("</tr>");

                TBL.Append("<tr>");
                TBL.Append("<td class='rep_data'align='left' width='10%'>");
                TBL.Append("<b>Edition:</b></td>");
                TBL.Append("<td class='rep_data' align='left'colspan='5' width='10%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["EDITION"].ToString() + "</td>");
                TBL.Append("</tr>");
                TBL.Append("<tr>");
                TBL.Append("<td class='rep_data'align='left' width='10%'>");
                TBL.Append("&nbsp;" + "</td>");
                TBL.Append("</tr>");

            }




            TBL.Append("<tr>");
            TBL.Append("<td class='middle31new'  align='left'>");
            TBL.Append("TOTAL</td>");
            TBL.Append("<td class='middle31new'  align='left'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new' align='left'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='left'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
            TBL.Append("</td>");
            TBL.Append("<td class='middle31new' align='right'>");
            TBL.Append(chk_null(dttoal.ToString()) + "</td>");
            TBL.Append("<td class='middle31new' align='right'>");
            TBL.Append(chk_null(dttoalamt.ToString()) + "</td>");
            TBL.Append("</tr>");

       

        tblgrid.InnerHtml = TBL.ToString();

       

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.Write("<p align='center'><b> " +  ds1.Tables[0].Rows[0]["COMP_NAME"].ToString() + "</b></p>");
        DataSet ds_xml = new DataSet();
        ds_xml.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));
        // report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[12].ToString();

        hw.Write("<p align='center'><b> " + report_name1 + ds_xml.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></p>");

        //hw.Write("<p align='center'><b> " + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></p>");
        hw.WriteBreak();
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }
    else
    {
        ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_vtsviewpage), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
        return;
    }



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

    //----for decimal values-----------//

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


    //=========== for print button-------//

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Double dttoal = 0, SUM = 0;
        double dttoalamt = 0;
        double vts = 0;
        double rate = 0;
        double amt = 0;
        int m11 = 0;
        string page = "";
        string position = "";
        //int j = 0;
        


        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

       
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(fromdate);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                dateto = YMDToMDY(dateto);
            }

            //if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
            //{
            //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //    ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", extra1, extra2);

            //}
            //else
            //{
            //    NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
            //    ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", extra1, extra2);

            //}
            ds1 = (DataSet)Session["vtsreport"];
        StringBuilder TBL = new StringBuilder();
        int cont = ds1.Tables[0].Rows.Count;
        comp_name.Text = ds1.Tables[0].Rows[0]["COMP_NAME"].ToString();


        int ct = 0;
        int fr = maxlimit;
        int rcount = ds1.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
            pagecount = pagecount + 1;

        // string tbl = "";
        if (ds1.Tables[0].Rows.Count > 0)
        {

            //if (browser.Browser == "Firefox")
            //{
            //    TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            //}
            //else 
            if (browser.Browser == "IE")
            {
            //    if ((ver == 7.0) || (ver == 8.0))
            //    {
            TBL.Append("<P><table width='90%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
            //    else if (ver == 6.0)
            //    {
            //        TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            //    }
            //}



            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;


                if (browser.Browser == "Firefox")
                {
                    TBL.Append("</table></P>");
                    if (p == pagecount ||p==0)
                        TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        TBL.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                
                }
                else if (browser.Browser == "IE")
                {
                //    if ((ver == 8.0) || (ver == 7.0))
                //    {
                TBL.Append("</table></P>");
                if (p == pagecount - 1)
                    TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                else
                    TBL.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                    }
             

              
                TBL.Append("<td  class='middle111' align='right' colspan='12'>" + "Page  " + s + "  of  " + pagecount);
                TBL.Append("</td></tr>");
                TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='0'colspan='2' >");
                TBL.Append("<tr><td class='middle31new'align='left' width='2%'>");
                TBL.Append("Sno.</td>");

                TBL.Append("<td class='middle31new'align='left' width='9%'>");
                TBL.Append("Booking ID</td>");

                TBL.Append("<td class='middle31new'align='left' width='15%'>");
                TBL.Append("Agency Name</td>");
                TBL.Append("<td class='middle31new'align='left' width='20%'>");
                TBL.Append("Agency Address</td>");

                TBL.Append("<td class='middle31new'align='left' width='13%'>");
                TBL.Append("client Name</td>");
                TBL.Append("<td class='middle31new'align='left' width='15%'>");
                TBL.Append("client Address</td>");
                //TBL.Append("<td class='middle31new'align='left' width='10%'>");
                //TBL.Append("Edition</td>");
                TBL.Append("<td class='middle31new'align='left' width='13%'>");
                TBL.Append("Package</td>");
                TBL.Append("<td class='middle31new'align='left' width='4%'>");
                TBL.Append("Publish Date</td>");
                TBL.Append("<td class='middle31new' align='left' width='4%'>");
                TBL.Append("VTS(No.ofcopies)</td>");
                TBL.Append("<td class='middle31new' align='right' width='5%'>");
                TBL.Append("VTS(Rate)</td>");
                TBL.Append("<td class='middle31new' align='right' width='5%'>");
                TBL.Append("VTS(Amount)</td>");


                TBL.Append("</tr>");


                 

           
                

                double num = 0.0;
               

                for (int m = ct; m < ds1.Tables[0].Rows.Count && m < fr; m++)
                {
                    sno++;
                    if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "")
                        SUM = 0;
                    else
                        SUM = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"]);

                    dttoal = dttoal + SUM;
                    a = m;
                    a = a + 1;
                    TBL.Append("<tr >");
                    //TBL.Append("<td class='rep_data'>");
                    //TBL.Append(a.ToString() + "</td>");
                    TBL.Append("<td class='rep_data' ' align='left' width='2%'>");
                    TBL.Append(sno + "</td>");

                    TBL.Append("<td class='rep_data' ' align='left' width='9%'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["CIOID"].ToString() + "</td>");


                    TBL.Append("<td class='rep_data'  align='left' width='15%'>");
                    string cioid1 = "";
                    string rrr = ds1.Tables[0].Rows[m]["AGENCY"].ToString();
                    if (rrr.Length >= 30)
                    {
                        cioid1 = rrr.Substring(0, 30);
                        if (rrr.Length - 30 < 30)
                            cioid1 += "</br>" + rrr.Substring(30, rrr.Length - 30);
                        else
                            cioid1 += "</br>" + rrr.Substring(30, 30);
                    }
                    else
                        cioid1 = rrr;
                    TBL.Append(cioid1 + "</td>");

                    TBL.Append("<td class='rep_data' ' align='left' width='20%'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["Add1"].ToString() + ds1.Tables[0].Rows[m]["Add2"].ToString() + ds1.Tables[0].Rows[m]["Add3"].ToString() + ds1.Tables[0].Rows[m]["CITY_NAME"].ToString() + "</td>");
                    //TBL.Append("<td class='middle31' cellspacing='0px' cellpadding = '0px' align='left'>");
                    //TBL.Append(ds1.Tables[0].Rows[m]["AGENCY"].ToString() + "</td>");

                    TBL.Append("<td class='rep_data'  align='left' width='13%'>");
                    string cioid2 = "";
                    string rr = ds1.Tables[0].Rows[m]["CLIENT"].ToString();
                    if (rr.Length >= 30)
                    {
                        cioid2 = rr.Substring(0, 30);
                        if (rr.Length - 30 < 30)
                            cioid2 += "</br>" + rr.Substring(30, rr.Length - 30);
                        else
                            cioid2 += "</br>" + rr.Substring(30, 30);
                    }
                    else
                        cioid2 = rr;
                    TBL.Append(cioid2 + "</td>");
                    TBL.Append("<td class='rep_data'  align='left' width='10%'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["CLIENT_ADDR"].ToString() + "</td>");
                  
                    TBL.Append("<td class='rep_data' align='left' width='13%'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["PACKAGE_NAME"].ToString() + "</td>");

                   
                    TBL.Append("<td class='rep_data'  align='left' width='4%'>");

                    string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 9);


                    if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
                    {

                        TBL.Append(rrR.ToString() + "</td>");
                    }
                    else
                    {
                        string[] arr = rrR.Split('/');
                        string mm = arr[0].ToString();
                        string dd = arr[1].ToString();
                        string yy = arr[2].ToString();
                        rr2 = dd + "/" + mm + "/" + yy;
                        TBL.Append(rr2.ToString() + "</td>");
                    }

                   

                   
                 
                    TBL.Append("<td class='rep_data'  align='center' width='4%'>");
                    string cioid5 = "";
                    string rr3 = ds1.Tables[0].Rows[m]["VTS"].ToString();
                    if (rr3.Length >= 10)
                    {
                        cioid5 = rr3.Substring(0, 10);
                        if (rr3.Length - 10 < 10)
                            cioid5 += "</br>" + rr3.Substring(10, rr3.Length - 10);
                        else
                            cioid5 += "</br>" + rr3.Substring(10, 10);
                    }
                    else
                        cioid5 = rr3;

                    TBL.Append(cioid5 + "</td>");
                    if (ds1.Tables[0].Rows[m]["VTS"].ToString() == "")
                        vts = 0;
                    else
                        vts = Convert.ToDouble(ds1.Tables[0].Rows[m]["VTS"]);

                   // vts = Convert.ToDouble(ds1.Tables[0].Rows[m]["VTS"].ToString());
                    
                    TBL.Append("<td class='rep_data' align='right' width='5%'>");
                    string cioid6 = "";
                    string rr4 = chk_null(ds1.Tables[0].Rows[m]["CIRRATE"].ToString());
                    if (rr4.Length >= 15)
                    {
                        cioid6 = rr4.Substring(0, 15);
                        if (rr4.Length - 15 < 15)
                            cioid6 += "</br>" + rr4.Substring(15, rr4.Length - 15);
                        else
                            cioid6 += "</br>" + rr4.Substring(15, 15);
                    }
                    else
                        cioid6 = rr4;
                    if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "")
                        rate = 0;
                    else
                    rate = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"].ToString());
                    TBL.Append(cioid6 + "</td>");
                    if (ds1.Tables[0].Rows[m]["CIRRATE"].ToString() == "")
                        num = 0;
                    else
                    num = Convert.ToDouble(ds1.Tables[0].Rows[m]["CIRRATE"]);
                    
                    //TBL.Append("</tr>");


                    TBL.Append("<td class='rep_data'  align='right'>");

                    amt = vts * rate;
                    TBL.Append(amt + "</td>");
                    dttoalamt = dttoalamt + amt;

                    TBL.Append("<tr>");
                    TBL.Append("<td   align='left' width='10%'>");
                    TBL.Append("<b>Edition:</b></td>");
                    TBL.Append("<td class='rep_data' align='left' colspan='5' width='10%'>");
                    string cioid3 = "";
                    string rr1 = ds1.Tables[0].Rows[m]["EDITION"].ToString();
                    if (rr1.Length >= 15)
                    {
                        cioid3 = rr1.Substring(0, 15);
                        if (rr1.Length - 15 < 15)
                            cioid3 += "</br>" + rr1.Substring(15, rr1.Length - 15);
                        else
                            cioid3 += "</br>" + rr1.Substring(15, 15);
                    }
                    else
                        cioid3 = rr1;
                    TBL.Append(cioid3 + "</td>");
                    TBL.Append("</tr>");
                    TBL.Append("<tr>");
                    TBL.Append("<td class='rep_data'align='left' width='10%'>");
                    TBL.Append("&nbsp;" + "</td>");
                    TBL.Append("</tr>");
                   
                    btnprint.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_vtsviewpage), "sa", "window.print();", true);

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
               
            }


     
        }

        TBL.Append("<tr>");
        TBL.Append("<td class='middle31new'  align='left'>");
        TBL.Append("TOTAL</td>");
        TBL.Append("<td class='middle31new'  align='left'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new' align='left'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new'  align='left'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new'  align='right'>&nbsp;");
        TBL.Append("</td>");
        TBL.Append("<td class='middle31new' align='right'>");
        TBL.Append(chk_null(dttoal.ToString()) + "</td>");
        TBL.Append("<td class='middle31new' align='right'>");
        TBL.Append(chk_null(dttoalamt.ToString()) + "</td>");

        TBL.Append("</tr>");



        TBL.Append("</table></p>");


        tblgrid.InnerHtml = TBL.ToString();





    }


    private void pdf()//(string edition, string agency_code, string from_date, string to_date, string client_code, string publication, string pub_center, string branch, string dateformat, string useid, string compcode, string chk_access, string extra1, string extra2)
    {
        string code_find = "";
        Double dttoal = 0, SUM = 0;
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "\\" + pdfName;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase("Page No. " + i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;
        document.Open();

        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);


        DataSet ds1 = new DataSet();

       
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(fromdate);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                dateto = YMDToMDY(dateto);
            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
                ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype,  extra1, extra2);

        }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
                ds1 = obj.vtsreport(editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, extra1, extra2);

            }
            else
            {
                string procedureName = "Rpt_vts_Report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { editioncode, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), "0", clienttype, extra1, extra2 };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

        if(ds1.Tables[0].Rows.Count>0)
        {

            string pub = "";
            if (pubnamecode == "0" || pubnamecode == "")
            {
                pub = "ALL".ToString();
            }
            else
            {
                pub = pubname.ToString();
            }

        //string pub = "";
        //publi = pubname;
        //if (publi != "--Select Publication--")
        //{
        //    pub = pubname.ToString();

        //}
        //if (publi == "--Select Publication--")
        //{
        //    pub = "ALL".ToString();
            
        //}


        string pubcent = "";
        if (pubcentcode == "0" || pubcentcode == "")
        {
            pubcent = "ALL".ToString();
        }
        else
        {
            pubcent = pubcenter.ToString();
        }



        string bran = "";
        if (branchcode == "0" || branchcode == "")
        {
            bran = "ALL".ToString();
        }
        else
        {
            bran = branch_c.ToString();
        }



        string edi = "";
        if (editioncode == "0" || editioncode == "")
        {
            edi = "ALL".ToString();
        }
        else
        {
            edi = edition.ToString();

        }
        

        //string edi = "";
        //edit = editioncode;
        //if (edit != "0")
        //{
        //    edi = edition.ToString();
        //}
        //else
        //{
        //    edi = "ALL".ToString();
        //}

        //string shrey = "";

        //////if (cleint == "0")
        //////{
        //////   cli = "ALL".ToString();
        //////}
        //////else
        //////{
        //////    cli= clientname.ToString();
        //////}

        //string pub = "";
        //if (publi == "")
        //{
        //    pub = "ALL".ToString();
        //}
        //else
        //{
        //    pub = pubname.ToString();
        //}
        //string pubcenter = "";
        //if (pubcen == "")
        //{
        //    pubcenter = "ALL".ToString();
        //}
        //else
        //{
        //    pubcenter = pubcent.ToString();
        //}
        //string bran = "";
        //if (ban1 == "")
        //{
        //    bran = "ALL".ToString();
        //}
        //else
        //{
        //    bran = branch_c.ToString();
        //}
        //string edi = "";
        //if (edit == "")
        //{
        //    edi = "ALL".ToString();
        //}
        //else
        //{
        //    edi = edition.ToString();
        //}

        //string shrey = "";




        int table1 = ds1.Tables[0].Rows.Count;
        int controw = ds1.Tables[0].Rows.Count;
        int contcol = ds1.Tables[0].Columns.Count;
        //int table2 = ds1.Tables[1].Rows.Count;

        int q = ds1.Tables[0].Columns.Count;
        int z = q - 1;
        int lastc = ds1.Tables[0].Columns.Count;
        int lastthirdc = lastc - 3;
        int NumColumns = ds1.Tables[0].Columns.Count + 1;
        NumColumns = NumColumns - 5;
        int xx = ds1.Tables[0].Columns.Count - 10;

        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["comp_name"].ToString(), font11));
            tbl.WidthPercentage = 100;
            document.Add(tbl);


            PdfPTable tbl4 = new PdfPTable(1);
            tbl4.DefaultCell.BorderWidth = 0;
            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl4.addCell(new iTextSharp.text.Phrase("VTS REPORT", font11));
            tbl4.WidthPercentage = 100;
            document.Add(tbl4);


            PdfPTable tb3 = new PdfPTable(8);
            float[] xy3 = { 100 };
            tb3.DefaultCell.BorderWidth = 0;
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tb3.setWidths(xy1);
            tb3.WidthPercentage = 100;
            tb3.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));


            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("PUBLICATION:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(pub, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("PUBCENT:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(pubcent, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("BRANCH:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(bran, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase("", font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("EDITION:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(edi, font11));


            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("DATE FROM:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(fromdate, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("TO DATE:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(dateto, font11));



            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("RUN DATE:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(date, font11));
            document.Add(tb3);



           
            PdfPTable datatable = new PdfPTable(6);
            datatable.DefaultCell.Padding = 0;
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 0;
            float[] set_width = {15, 25, 12, 12, 8, 8};
            datatable.setWidths(set_width);
            datatable.DefaultCell.Colspan = 6;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_BASELINE;
            datatable.addCell(new iTextSharp.text.Phrase("_______________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 0;

            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
            datatable.addCell(new iTextSharp.text.Phrase("Agency Name", font11));   
            datatable.addCell(new iTextSharp.text.Phrase("Client Name", font11));
            datatable.addCell(new iTextSharp.text.Phrase("Edition", font11));
            datatable.addCell(new iTextSharp.text.Phrase("Publication Date", font11));
            datatable.addCell(new iTextSharp.text.Phrase("VTS(No.of copies)", font11));
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
            datatable.addCell(new iTextSharp.text.Phrase("VTS(Rate)", font11));


            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            datatable.DefaultCell.Colspan = 6;
            datatable.DefaultCell.Padding = 0;
            datatable.addCell(new iTextSharp.text.Phrase("_____________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 0;

            //string cioid1 = "";
            //string rrr = ds1.Tables[0].Rows[m]["AGENCY"].ToString();
            //if (rrr.Length >= 30)
            //{
            //    cioid1 = rrr.Substring(0, 30);
            //    if (rrr.Length - 30 < 30)
            //        cioid1 += "</br>" + rrr.Substring(30, rrr.Length - 30);
            //    else
            //        cioid1 += "</br>" + rrr.Substring(30, 30);
            //}
            //else
            //    cioid1 = rrr;

           

            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
              

           
               



            for (int x = 0; x < ds1.Tables[0].Rows.Count; x++)
            {
                if (ds1.Tables[0].Rows[x]["CIRRATE"] == "")
                    SUM = 0;
                else
                    SUM = Convert.ToDouble(ds1.Tables[0].Rows[x]["CIRRATE"]);

                dttoal = dttoal + SUM;
                datatable.DefaultCell.PaddingTop = 7;
                datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                datatable.DefaultCell.Colspan = 1;

                datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["AGENCY"].ToString(), font11));
                datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["CLIENT"].ToString(), font11));
                datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["EDITION"].ToString(), font11));


                string rrR = ds1.Tables[0].Rows[x]["PUB_DATE"].ToString().Substring(0, 10);
                if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
                {
                    datatable.addCell(new iTextSharp.text.Phrase(rrR.ToString(), font11));
                }
                else
                {
                    string[] arr = rrR.Split('/');
                    string mm = arr[0].ToString();
                    string dd = arr[1].ToString();
                    string yy = arr[2].ToString();
                    rr2 = dd + "/" + mm + "/" + yy;
                    datatable.addCell(new iTextSharp.text.Phrase(rr2.ToString(), font11));
                }


              


                //string[] arr = rrR.Split('/');
                //string mm = arr[0].ToString();
                //string dd = arr[1].ToString();
                //string yy = arr[2].ToString();
                //rr2 = dd + "/" + mm + "/" + yy; 
                
                //datatable.addCell(new iTextSharp.text.Phrase(rr2.ToString(), font11));
               

                datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["VTS"].ToString(), font11));
                datatable.addCell(new iTextSharp.text.Phrase(chk_null(ds1.Tables[0].Rows[x]["CIRRATE"].ToString()), font11));


            }

            datatable.DefaultCell.Colspan = 1;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            datatable.addCell(new iTextSharp.text.Phrase("Total", font11));
            datatable.DefaultCell.Colspan = 5;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.addCell(new iTextSharp.text.Phrase(chk_null(dttoal.ToString()), font11));
            datatable.DefaultCell.Colspan = 1;

            document.Add(datatable);

            document.Close();
            Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }
    else
    {
        ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_vtsviewpage), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
        return;
    }

    }


    //string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 10);
               
    //function chk_dateformat
    //{
    //            string[] arr = rrR.Split('/');
    //            string mm = arr[0].ToString();
    //            string dd = arr[1].ToString();
    //            string yy = arr[2].ToString();
    //            rr2 = dd + "/" + mm + "/" + yy;
    //}           TBL.Append(rr2 + "</td>");





   

}



  