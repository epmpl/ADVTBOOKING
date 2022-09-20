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
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class reportview2 : System.Web.UI.Page
{
    string agency = "";
    string client = "";
    string package = "";

    string agname = "";
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
    string day = "";
    string month = "";
    string year = "";
    string adcatname = "";
    string agencyname = "";
    string agencysubcode1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    string pstatus = "";
    double area = 0;
    int i1 = 0;
    double amt = 0;
    string sortorder = "";
    string sortvalue = "", agtype = "", agtypetext = "", coid = "", ascdec = "", agtynem = "", uomcod = "", uomnam = "", branch = "";
    string pextra1 = "", pextra2 = "", pextra3 = "", pextra4 = "", pextra5 = "";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    DataSet ds;

    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";

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

    protected void Page_Load(object sender, EventArgs e)
    {

        ds = (DataSet)Session["allagency"];

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }


        //   string prm = Session["prm_allagency"].ToString();
        string[] prm_Array = new string[37];
        //     prm_Array = prm.Split('~');


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //  dateto = Session["dateto"].ToString();
        //   fromdt = Session["fromdate"].ToString();



        //agname = prm_Array[1];//Request.QueryString["agname"].ToString();
        //adtyp = prm_Array[3]; //Request.QueryString["adtype"].ToString();
        //adcat = prm_Array[5]; //Request.QueryString["adcategory"].ToString();
        //fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        //dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        //publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        //pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        //pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();

        //pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();

        //edition = prm_Array[19]; //Request.QueryString["edition"].ToString();
        //destination = prm_Array[21]; //Request.QueryString["destination"].ToString();
        //adcatname = prm_Array[23]; //Request.QueryString["adcatname"].ToString();
        //agencyname = prm_Array[25]; //Request.QueryString["agencyname"].ToString();
        //adtypename = prm_Array[27]; //Request.QueryString["adtypename"].ToString();
        //editionname = prm_Array[29]; //Request.QueryString["editionname"].ToString();
        //agencysubcode1 = prm_Array[31]; //Request.QueryString["agencysubcode"].ToString();
        //agtype = prm_Array[33]; //Request.QueryString["agtype"].ToString();
        //agtypetext = prm_Array[35]; //Request.QueryString["agtypetext"].ToString();
        //chk_excel = prm_Array[37];


        agname = Request.QueryString["agname"].ToString();
        adtyp = Request.QueryString["adtype"].ToString();
        adcat = Request.QueryString["adcategory"].ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        publ = Request.QueryString["publication"].ToString();
        pubcen = Request.QueryString["pubcenter"].ToString();
        pubcname = Request.QueryString["publicname"].ToString();

        pub2 = Request.QueryString["publiccent"].ToString();

        edition = Request.QueryString["edition"].ToString();
        destination = Request.QueryString["destination"].ToString();
        adcatname = Request.QueryString["adcatname"].ToString();
        agencyname = Request.QueryString["agencyname"].ToString();
        adtypename = Request.QueryString["adtypename"].ToString();
        editionname = Request.QueryString["editionname"].ToString();
        agencysubcode1 = Request.QueryString["agencysubcode"].ToString();
        agtype = Request.QueryString["agtype"].ToString();
        agtypetext = Request.QueryString["agtypetext"].ToString();
        chk_excel = Request.QueryString["chk_excel"].ToString();
        coid = Request.QueryString["coid"].ToString();
        ascdec = Request.QueryString["ascdec"].ToString();
        agtynem = Request.QueryString["agnamety"].ToString();
        uomcod = Request.QueryString["uomcod"].ToString();
        uomnam = Request.QueryString["uomnam"].ToString();
        pextra2 = Request.QueryString["pstatus"].ToString();
        branch = Request.QueryString["branch"].ToString();


        if (uomcod == "--Select UOM--")
            uomcod = "";

        SqlDataAdapter da = new SqlDataAdapter();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            //  ds = obj.spAgency(dpagency.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
            //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), coid, ascdec, "", "", "", agtynem, Session["userid"].ToString(), Session["access"].ToString(), uomcod, Dropdwnstatus.SelectedValue, pextra3, pextra4, pextra5);

            ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), coid, ascdec, "", pextra2, "", agtynem, Session["userid"].ToString(), Session["access"].ToString(), branch);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "REPORTNEW";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { agname, "", adtyp, adcat, fromdt, dateto, Session["compcode"].ToString(), publ, pubcen, "", edition, Session["dateformat"].ToString(), "", coid, ascdec, agtype, Session["userid"].ToString(), Session["access"].ToString(), pextra1, pextra2, pextra3, pextra4, pextra5, branch };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdt = DMYToMDY(fromdt);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                //  from_date = YMDToMDY(txtfrmdate.Text);
                //  to_date = YMDToMDY(txttodate1.Text);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //ds = obj.spAgency(dpagency.SelectedValue, dpdadtype.SelectedValue, str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
            ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), coid, ascdec, "", "", "", agtynem, Session["userid"].ToString(), Session["access"].ToString(), uomcod, pextra2, pextra3, pextra4, pextra5);

        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(reportview2), "sa", "alert(\"searching criteria is not valid\");window.close()", true);
            return;
        }

        // string dateformat = Request.QueryString["dateformat"].ToString();
        if (agtype == "0")
        {
            lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = agtypetext.ToString();
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
            lbladcat.Text = "ALL".ToString();
        }
        else
        {
            lbladcat.Text = adcatname.ToString();
        }



        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();


        }


        if (fromdt != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                // string dd = arr[0];
                string mm = arr[0];
                string dd = arr[1];
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
        //dateto1 = "";
        if (dateto != "")
        {





            ///////////


            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[1];
                string mm = arr[0];
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

        if (agencysubcode1 == "true")
        {
            lblAgencyCode.Visible = true;
            lblAgencyCode.Text = "All".ToString();
            aaa.Visible = true;

        }
        else
        {
            lblAgencyCode.Visible = false;
            // lblAgencyCode.Text = "All".ToString();
            aaa.Visible = false;




        }
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), branch);
            }
            else if (destination == "4")
            {
                excel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), branch);

            }
            else
                if (destination == "3")
                {
                    pdf(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), branch);
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
    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string branch)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{

        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);

        //}

        cmpnyname.Text = Session["centername"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>";
        //garima1
        if (agencysubcode1 == "true")
        {


            tbl = tbl + ("<tr><td class='middle31new' width='1%' >S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='10%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Sub</br>&nbsp;&nbsp;Agency</td><td class='middle31new' width='10%' align='left'>&nbsp;&nbsp;Client</td><td  class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;HT</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Post&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left' >Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='7%'   align='left'>Ro No.</td><td class='middle31new' width='4%'  align='left'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%'  align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>Bill</br>Amt.</td><td class='middle31new' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No</td><td class='middle31new' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Status</td></tr>");


            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins_date"] + "</td>");


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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (agency1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                tbl = tbl + (ds.Tables[0].Rows[i]["SubAg"] + "</td>");

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


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (client1 + "</td>");




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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (Package1 + "</td>");



                //----------------------------------------------------------------///
                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                tbl = tbl + (ds.Tables[0].Rows[i]["Color_code"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

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



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");

                if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");
                if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");
                if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");


                string RoStatus1 = "";
                string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
                if (rrr4.Length >= 9)
                {
                    RoStatus1 = rrr4.Substring(0, 9);
                    if (rrr4.Length - 9 < 9)
                        RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                    else
                        RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                }
                else
                    RoStatus1 = rrr4;


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (RoStatus1 + "</td>");

                string AdCat1 = "";
                string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
                if (rrr5.Length >= 9)
                {
                    AdCat1 = rrr5.Substring(0, 9);
                    if (rrr5.Length - 9 < 9)
                        AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                    else
                        AdCat1 += "</br>" + rrr5.Substring(9, 9);
                }
                else
                    AdCat1 = rrr5;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (AdCat1 + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["CardRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["AgreedRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");


                if (ds.Tables[0].Rows[i].ItemArray[19].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    if (ds.Tables[0].Rows[i]["Amt"].ToString() != "" && ds.Tables[0].Rows[i]["Amt"].ToString() != null)
                        tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                    else
                        tbl = tbl + ("</td>");
                    if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "" && ds.Tables[0].Rows[i]["Amt"].ToString() != "" && ds.Tables[0].Rows[i]["Amt"].ToString() != null)
                        amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
                tbl = tbl + ds.Tables[0].Rows[i]["Cap"];
                tbl = tbl + "</br>";
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
                //tbl = tbl + ds.Tables[0].Rows[i]["Status"];
                //tbl = tbl + "</br>";
                tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");


                tbl = tbl + "</tr>";

                tblgrid.InnerHtml += tbl;
                tbl = "";

            }




            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + (i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 12px;'>&nbsp;</td><td class='middle1212' colspan='4' align='right'><b>Total Area</b>");

            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");
            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }


            //////////////////////////
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle13new' colspan='2' align='right' style='font-size: 12px;'><b>BillAmt:</b></td>");
            tbl = tbl + ("<td class='middle13new' colspan='6' style='font-size: 12px;'><b>");
            tbl = tbl + (amt.ToString(("F2")) + "</b></td>");
            tbl = tbl + "</tr>";



            tbl = tbl + ("</table>");
            // tblgrid.InnerHtml = tbl;
            tblgrid.InnerHtml += tbl;



        }

        else
        {




            tbl = tbl + ("<tr><td class='middle31new' width='1%' >S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%'align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%'align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='10%'align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='8%'align='left'>&nbsp;&nbsp;Client</td><td  class='middle31new' width='6%'align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%'align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;HT</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='left' >&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Post&nbsp;&nbsp;</td><td class='middle31new' width='1%' >Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' >Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' >Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='5%'  >Ro No.</td><td class='middle31new' width='4%'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>Bill</br>Amt.</td><td class='middle31new' width='3%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No</td><td class='middle31new' width='3%' colspan='2' align='left'>&nbsp;&nbsp;Status</td></tr>");




            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins_date"] + "</td>");


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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (agency1 + "</td>");


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


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (client1 + "</td>");



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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (Package1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Color_code"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");

                if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {


                    tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                }




                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
                if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");



                string RoStatus1 = "";
                string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
                if (rrr4.Length >= 9)
                {
                    RoStatus1 = rrr4.Substring(0, 9);
                    if (rrr4.Length - 9 < 9)
                        RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                    else
                        RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                }
                else
                    RoStatus1 = rrr4;


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (RoStatus1 + "</td>");


                string AdCat1 = "";
                string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
                if (rrr5.Length >= 9)
                {
                    AdCat1 = rrr5.Substring(0, 9);
                    if (rrr5.Length - 9 < 9)
                        AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                    else
                        AdCat1 += "</br>" + rrr5.Substring(9, 9);
                }
                else
                    AdCat1 = rrr5;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (AdCat1 + "</td>");


                tbl = tbl + ("<td class='rep_data' align='left'>&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["CardRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["AgreedRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                //if (ds.Tables[0].Rows[i].ItemArray[19].ToString() == "")
                //{
                //    tbl = tbl + "" + "</td>";
                //}

                if (ds.Tables[0].Rows[i]["Amt"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }


                else
                {

                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                    if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + ds.Tables[0].Rows[i]["Cap"];
                tbl = tbl + "</br>";

                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                //tbl = tbl + ds.Tables[0].Rows[i]["Cap"];
                //tbl = tbl + "</br>";

                tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");


                tbl = tbl + "</tr>";


                //////////
                tblgrid.InnerHtml += tbl;
                tbl = "";
                //////////////
            }




            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + (i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 12px;'>&nbsp;</td>");



            //     tbl = tbl + ("<td class='middle13new'>");
            ////////////////////////////////////
            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");

            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");
            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            //////////////////////////////////////
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");

            tbl = tbl + ("<td class='middle13new' colspan='2' align='right' style='font-size: 12px;'><b>BillAmt:</b></td>");
            tbl = tbl + ("<td class='middle13new' colspan='5' style='font-size: 12px;'>");
            tbl = tbl + (amt.ToString(("F2")) + "</td>");
            //tbl = tbl + ("<td class='middle13new' style='font-size: 12px;'>&nbsp;</td>");
            tbl = tbl + "</tr>";

            tbl = tbl + ("</table>");
            // tblgrid.InnerHtml = tbl;
            tblgrid.InnerHtml += tbl;

        }


    }



    private void pdf(string agname, String adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string branch)
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

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();
        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        //----------------------------------------





        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tbl.addCell(new Phrase(dsw.Tables[0].Rows[0]["companyname"].ToString(), font9));
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[1].ToString(), font9));
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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

            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            tbl2.addCell(new Phrase(lblpub.Text, font11));
            tbl2.addCell(new Phrase("Pub Center", font10));
            tbl2.addCell(new Phrase(pcenter.Text, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            tbl2.addCell(new Phrase(lbedition.Text, font11));
            //tbl2.addCell(new Phrase("", font10));
            //tbl2.addCell(new Phrase("", font11));


            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            //tbl2.addCell(new Phrase("AgencySubCode", font10));
            //tbl2.addCell(new Phrase(lblAgencyCode.Text, font11));



            tbl2.addCell(new Phrase("Ad Type", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));
            tbl2.addCell(new Phrase("Ad Category", font10));
            tbl2.addCell(new Phrase(lbladcat.Text, font11));
            tbl2.addCell(new Phrase("Agency Type", font10));
            tbl2.addCell(new Phrase(lblagtype.Text, font11));
            //tbl2.addCell(new Phrase("", font10));
            //tbl2.addCell(new Phrase("", font11));

            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            //-------------------------------------

            int NumColumns = 24;
            PdfPTable datatable = new PdfPTable(NumColumns);

            int NumColumns1 = 23;
            PdfPTable datatable1 = new PdfPTable(NumColumns1);

            //------------------------------------------------------------------------------------------------------
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage

            if (agencysubcode1 == "true")
            {
                datatable.DefaultCell.Padding = 3;
                //float[] headerwidths = { 11, 14, 17, 14,17, 22, 18, 13, 17, 14, 23, 23, 20, 27, 20, 14, 20, 17, 13, 11 ,13};

                //datatable.setWidths(headerwidths);
                datatable.WidthPercentage = 100; // percentage
                datatable.DefaultCell.BorderWidth = 0;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[32].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                //datatable.addCell(new Phrase("Pub", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                //datatable.addCell(new Phrase("Depth", font10));
                //datatable.addCell(new Phrase("Width", font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[87].ToString(), font10));


                datatable.addCell(new Phrase("Page Prem", font10));
                datatable.addCell(new Phrase("Post Prem", font10));
                datatable.addCell(new Phrase("Eye Catcher", font10));


                //  datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

                // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10)); ;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                //      datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));


                datatable.addCell(new Phrase("BillAmt", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[101].ToString(), font10));

                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.DefaultCell.Colspan = NumColumns;
                datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
                datatable.DefaultCell.Colspan = 1;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


                document.Add(p2);


                //SqlDataAdapter da = new SqlDataAdapter();
                //i1 = 1;


                SqlDataAdapter da = new SqlDataAdapter();
                i1 = 1;


                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {


                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins_date"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SubAg"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                    if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    {



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


                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PositionPremium"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BulletPremium"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(string.Format("{0:0.00}", ds.Tables[0].Rows[row]["CardRate"]).ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable.addCell(new Phrase(string.Format("{0:0.00}", ds.Tables[0].Rows[row]["AgreedRate"]).ToString(), font11));
                    datatable.addCell(new Phrase(string.Format("{0:0.00}", ds.Tables[0].Rows[row]["Amt"]).ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));

                }


            }
            else
            {

                datatable1.WidthPercentage = 100; // percentage
                datatable1.DefaultCell.BorderWidth = 0;
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable1.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;


                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[87].ToString(), font10));

                datatable1.addCell(new Phrase("Page Prem", font10));
                datatable1.addCell(new Phrase("Post Prem", font10));
                datatable1.addCell(new Phrase("Eye Catcher", font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));

                datatable1.addCell(new Phrase("BillAmt", font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[101].ToString(), font10));

                Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


                document.Add(p2);
                datatable1.HeaderRows = 1;

                SqlDataAdapter da = new SqlDataAdapter();
                i1 = 1;



                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    datatable1.addCell(new Phrase(i1++.ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins_date"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));


                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    {

                        if (ds.Tables[0].Rows[row]["uom"].ToString() == "CD" || ds.Tables[0].Rows[row]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());


                    }

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Color_code"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["PositionPremium"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["BulletPremium"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable1.addCell(new Phrase(string.Format("{0:0.00}", ds.Tables[0].Rows[row]["CardRate"]).ToString(), font11));
                    datatable1.addCell(new Phrase(string.Format("{0:0.00}", ds.Tables[0].Rows[row]["AgreedRate"]).ToString(), font11));
                    datatable1.addCell(new Phrase(string.Format("{0:0.00}", ds.Tables[0].Rows[row]["Amt"]).ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));

                }

            }





            document.Add(datatable);
            document.Add(datatable1);

            // document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);



            PdfPTable tbltotal = new PdfPTable(12);
            float[] headerwidths = { 11, 19, 18, 21, 15, 10, 10, 6, 10, 19, 25, 10 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));


            tbltotal.addCell(new Phrase("Area:", font11));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

            if (totrol > 0)
            {
                tbltotal.addCell(new Phrase("Lines:", font11));
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.addCell(new Phrase(calf.ToString(), font11));


            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcd > 0)
            {
                tbltotal.addCell(new Phrase("Chars:", font11));
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.addCell(new Phrase(calfd.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcc > 0)
            {

                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbltotal.addCell(new Phrase("Words:", font11));
                tbltotal.addCell(new Phrase(calft.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }

            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.Colspan = 12;
            tbltotal.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            //  datatable.DefaultCell.Colspan = 1;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

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

        Session["prm_allagency_print"] = "agname~" + agname + "~adtype~" + adtyp + "~adcategory~" + adcat + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~pubcenter~" + pubcen + "~publicname~" + pubcname + "~publiccent~" + pub2 + "~edition~" + edition + "~adcatname~" + adcatname + "~agencyname~" + agencyname + "~adtypename~" + adtypename + "~editionname~" + editionname + "~agencysubcode~" + agencysubcode1 + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
        Session["allagency"] = ds;
        Response.Redirect("reportnewprint2.aspx");
        //Response.Redirect("reportnewprint2.aspx?agname=" + agname + "&adtype=" + adtyp + "&adcategory=" + adcat + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&pubcenter=" + pubcen + "&publicname=" + pubcname + "&publiccent=" + pub2 + "&edition=" + edition + "&adcatname=" + adcatname + "&agencyname=" + agencyname + "&adtypename=" + adtypename + "&editionname=" + editionname + "&agencysubcode=" + agencysubcode1 + "&agtype1=" + agtype + "&agtypetext=" + agtypetext);
    }



    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        if (agencysubcode1 == "true")
        {
            double sumamt = 0;


            string sno1 = e.Item.Cells[0].Text;
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
            }



        }

        else
        {
            e.Item.Cells[5].Visible = false;

            double sumamt = 0;


            string sno1 = e.Item.Cells[0].Text;
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
            }


            string check = e.Item.Cells[20].Text;
            string amt = e.Item.Cells[20].Text;


            string check1 = e.Item.Cells[9].Text;
            string amt1 = e.Item.Cells[9].Text;








            if (check != "BillAmt")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[20].Text;
                    comm1 = Convert.ToDouble(grossamt);
                    comm2 = comm2 + comm1;


                }
            }





            if (check1 != "Area")
            {
                if (check1 != "&nbsp;")
                {




                    string arean = e.Item.Cells[9].Text;
                    areanew = areanew + Convert.ToDouble(arean);


                }
            }


        }

    }





    private void excel(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string branch)
    {
        SqlDataAdapter da = new SqlDataAdapter();


        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");


        cmpnyname.Text = Session["centername"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='2' cellspacing='0' border='1'>";
        //garima1
        if (agencysubcode1 == "true")
        {


            tbl = tbl + ("<tr><td class='middle31new' width='1%' >S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='10%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Sub</br>&nbsp;&nbsp;Agency</td><td class='middle31new' width='10%' align='left'>&nbsp;&nbsp;Client</td><td  class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;HT</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Post&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left' >Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='7%'   align='left'>Ro No.</td><td class='middle31new' width='4%'  align='left'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%'  align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>Bill</br>Amt.</td><td class='middle31new' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No</td><td class='middle31new' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Status</td></tr>");


            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins_date"] + "</td>");


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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (agency1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                tbl = tbl + (ds.Tables[0].Rows[i]["SubAg"] + "</td>");

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


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (client1 + "</td>");




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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (Package1 + "</td>");



                //----------------------------------------------------------------///
                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                tbl = tbl + (ds.Tables[0].Rows[i]["Color_code"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

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



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");

                if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");
                if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");
                if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");


                string RoStatus1 = "";
                string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
                if (rrr4.Length >= 9)
                {
                    RoStatus1 = rrr4.Substring(0, 9);
                    if (rrr4.Length - 9 < 9)
                        RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                    else
                        RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                }
                else
                    RoStatus1 = rrr4;


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (RoStatus1 + "</td>");

                string AdCat1 = "";
                string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
                if (rrr5.Length >= 9)
                {
                    AdCat1 = rrr5.Substring(0, 9);
                    if (rrr5.Length - 9 < 9)
                        AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                    else
                        AdCat1 += "</br>" + rrr5.Substring(9, 9);
                }
                else
                    AdCat1 = rrr5;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (AdCat1 + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["CardRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["AgreedRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");


                if (ds.Tables[0].Rows[i].ItemArray[19].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {

                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                    if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
                tbl = tbl + ds.Tables[0].Rows[i]["Cap"];
                tbl = tbl + "</br>";
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>"); ;
                tbl = tbl + "</tr>";

                tblgrid.InnerHtml += tbl;
                tbl = "";

            }




            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + (i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 12px;'>&nbsp;</td><td class='middle1212' colspan='4' align='right'><b>Total Area</b>");

            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");
            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }


            //////////////////////////
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle13new' colspan='2' align='right' style='font-size: 12px;'><b>BillAmt:</b></td>");
            tbl = tbl + ("<td class='middle13new' colspan='6' style='font-size: 12px;'><b>");
            tbl = tbl + (amt.ToString(("F2")) + "</b></td>");
            tbl = tbl + "</tr>";



            tbl = tbl + ("</table>");
            // tblgrid.InnerHtml = tbl;
            tblgrid.InnerHtml += tbl;



        }

        else
        {




            tbl = tbl + ("<tr><td class='middle31new' width='1%' >S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%'align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%'align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='10%'align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='8%'align='left'>&nbsp;&nbsp;Client</td><td  class='middle31new' width='6%'align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%'align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;HT</td><td class='middle31new' width='1%' align='right' >&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='left' >&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Post&nbsp;&nbsp;</td><td class='middle31new' width='1%' >Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' >Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' >Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='5%'  >Ro No.</td><td class='middle31new' width='4%'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>Bill</br>Amt.</td><td class='middle31new' width='3%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No</td></tr>");




            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins_date"] + "</td>");


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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (agency1 + "</td>");


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


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (client1 + "</td>");



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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (Package1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Color_code"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

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

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");

                if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {


                    tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                }




                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
                if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");



                string RoStatus1 = "";
                string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
                if (rrr4.Length >= 9)
                {
                    RoStatus1 = rrr4.Substring(0, 9);
                    if (rrr4.Length - 9 < 9)
                        RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                    else
                        RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                }
                else
                    RoStatus1 = rrr4;


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (RoStatus1 + "</td>");


                string AdCat1 = "";
                string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
                if (rrr5.Length >= 9)
                {
                    AdCat1 = rrr5.Substring(0, 9);
                    if (rrr5.Length - 9 < 9)
                        AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                    else
                        AdCat1 += "</br>" + rrr5.Substring(9, 9);
                }
                else
                    AdCat1 = rrr5;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (AdCat1 + "</td>");


                tbl = tbl + ("<td class='rep_data' align='left'>&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["CardRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[i]["AgreedRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                //if (ds.Tables[0].Rows[i].ItemArray[19].ToString() == "")
                //{
                //    tbl = tbl + "" + "</td>";
                //}

                if (ds.Tables[0].Rows[i]["Amt"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }


                else
                {

                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                    if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + ds.Tables[0].Rows[i]["Cap"];
                tbl = tbl + "</br>";

                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");


                tbl = tbl + "</tr>";


                //////////
                tblgrid.InnerHtml += tbl;
                tbl = "";
                //////////////
            }




            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + (i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 12px;'>&nbsp;</td>");



            //     tbl = tbl + ("<td class='middle13new'>");
            ////////////////////////////////////
            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");

            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");
            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            //////////////////////////////////////
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");

            tbl = tbl + ("<td class='middle13new' colspan='2' align='right' style='font-size: 12px;'><b>BillAmt:</b></td>");
            tbl = tbl + ("<td class='middle13new' colspan='5' style='font-size: 12px;'>");
            tbl = tbl + (amt.ToString(("F2")) + "</td>");
            //tbl = tbl + ("<td class='middle13new' style='font-size: 12px;'>&nbsp;</td>");
            tbl = tbl + "</tr>";

            tbl = tbl + ("</table>");
            // tblgrid.InnerHtml = tbl;
            tblgrid.InnerHtml += tbl;

        }








        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();



    }



















    private void excel1(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {



        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{

        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);

        //}
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
        nameColumn.HeaderText = "Booking ID";
        nameColumn.DataField = "CIOID";
        name1 = name1 + "," + "Booking ID";
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
        nameColumn2.DataField = "Ins_date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins_date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);


        BoundColumn nameColumn3 = new BoundColumn();
        nameColumn3.HeaderText = "Billno";
        nameColumn3.DataField = "BILL_NO";

        name2 = name2 + "," + "BILL_NO";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn3);





        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Agency";
        nameColumn4.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);

        BoundColumn name4Column4 = new BoundColumn();
        name4Column4.HeaderText = "SubAg";
        name4Column4.DataField = "SubAg";

        name1 = name1 + "," + "SubAg";
        name2 = name2 + "," + "SubAg";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(name4Column4);

        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Client";
        nameColumn6.DataField = "Client";

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

        //BoundColumn nameColumn9 = new BoundColumn();
        //nameColumn9.HeaderText = "Depth";
        //nameColumn9.DataField = "Depth";

        //name1 = name1 + "," + "Depth";
        //name2 = name2 + "," + "Depth";
        //name3 = name3 + "," + "G";
        //DataGrid1.Columns.Add(nameColumn9);

        //BoundColumn nameColumn10 = new BoundColumn();
        //nameColumn10.HeaderText = "Width";
        //nameColumn10.DataField = "Width";

        //name1 = name1 + "," + "Width";
        //name2 = name2 + "," + "Width";
        //name3 = name3 + "," + "G";
        //DataGrid1.Columns.Add(nameColumn10);
        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Color";
        nameColumn12.DataField = "Color_code";

        name1 = name1 + "," + "Color";
        name2 = name2 + "," + "Color_code";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Area";
        nameColumn11.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);




        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "Page Position";
        nameColumn13.DataField = "Page";

        name1 = name1 + "," + "Page Position";
        name2 = name2 + "," + "Page";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);


        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "Page Prem";
        nameColumn14.DataField = "PagePremium";

        name1 = name1 + "," + "Page Prem";
        name2 = name2 + "," + "PagePremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "Position Prem";
        nameColumn15.DataField = "PositionPremium";

        name1 = name1 + "," + "Position Prem";
        name2 = name2 + "," + "PositionPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);


        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "Eye Catcher";
        nameColumn16.DataField = "BulletPremium";

        name1 = name1 + "," + "Eye Catcher";
        name2 = name2 + "," + "BulletPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "Ro No.";
        nameColumn17.DataField = "RoNo.";

        name1 = name1 + "," + "Ro No.";
        name2 = name2 + "," + "RoNo.";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "Ro Status";
        nameColumn18.DataField = "RoStatus";

        name1 = name1 + "," + "Ro Status";
        name2 = name2 + "," + "RoStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "AdCat";
        nameColumn19.DataField = "AdCat";

        name1 = name1 + "," + "AdCat";
        name2 = name2 + "," + "AdCat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn name2Column19 = new BoundColumn();
        name2Column19.HeaderText = "RateCode";
        name2Column19.DataField = "RateCode";

        name1 = name1 + "," + "RateCode";
        name2 = name2 + "," + "RateCode";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(name2Column19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "CardRate";
        nameColumn20.DataField = "CardRate";

        name1 = name1 + "," + "CardRate";
        name2 = name2 + "," + "CardRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = "AgreedRate";
        nameColumn21.DataField = "AgreedRate";

        name1 = name1 + "," + "AgreedRate";
        name2 = name2 + "," + "AgreedRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn21);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = "BillAmt";
        nameColumn22.DataField = "Amt";

        name1 = name1 + "," + "BillAmt";
        name2 = name2 + "," + "Amt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn22);


        BoundColumn nameColumn23 = new BoundColumn();
        nameColumn23.HeaderText = "Caption";
        nameColumn23.DataField = "Cap";

        name1 = name1 + "," + "Caption";
        name2 = name2 + "," + "Cap";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn23);

        BoundColumn nameColumn24 = new BoundColumn();
        nameColumn24.HeaderText = "Key No.";
        nameColumn24.DataField = "Key";

        name1 = name1 + "," + "Key No.";
        name2 = name2 + "," + "Key";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn24);



        BoundColumn nameColumn25 = new BoundColumn();
        nameColumn25.HeaderText = "Executive_name";
        nameColumn25.DataField = "EXECUTIVE";

        name1 = name1 + "," + "EXECUTIVE";
        //name2 = name2 + "," + "Key";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn25);

        BoundColumn nameColumn26 = new BoundColumn();
        nameColumn26.HeaderText = "Status";
        nameColumn26.DataField = "Status";

        name1 = name1 + "," + "Status";
        name2 = name2 + "," + "Status";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn26);





        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p <table border=\"1\"><tr><td colspan=\"22\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"22\"align=\"center\"><b>" + "All Ads Of The Agency" + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "Publication :" + "</b>" + lblpub.Text + "</td>");
            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Pub Center:" + "</b>" + pcenter.Text + "</td>");
            hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Edition:" + "</b>" + lbedition.Text + "</td></tr>");
            hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "Ad Type:" + "</b>" + lbladtype.Text + "</td>");
            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Ad Category:" + "</b>" + lbladcat.Text + "</td>");
            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Agency Type:" + "</b>" + lblagtype.Text + "</td></tr>");

            hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "From Date:" + "</b>" + lblfrom.Text + "</td>");
            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "To Date:" + "</b>" + lblto.Text + "</td>");
            hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Run Date:" + "</b>" + lbldate.Text + "</td><tr>");



            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            double arr = 0.0;
            if (areanew > 0)
                arr = comm2 / areanew;
            int sno11 = sno - 1;

            if (agencysubcode1 == "true")
            {
                Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds  " + sno11 + "</td><td colspan='6'></td><td >Total Area:</td><td align='left'>" + area + "</td><td >Total Lines:</td><td  align='left'>" + totrol + "</td><td >Total Chars:</td><td  align='left'>" + totcd + "</td><td >Total Words:</td><td align='left'>" + totcc + "</td><td colspan=\"5\">&nbsp;</td><td>" + comm2 + "</td><td></td><tr><td colspan='2'>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));

            }
            else
            {
                Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds  " + sno11 + "</td><td colspan='5'></td><td >Total Area:</td><td align='left'>" + area + "</td><td >Total Lines:</td><td  align='left'>" + totrol + "</td><td >Total Chars:</td><td  align='left'>" + totcd + "</td><td >Total Words:</td><td align='left'>" + totcc + "</td><td colspan='5'>" + comm2 + "</td><td></td><td></td><tr><td colspan='3'>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));

            }

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



}

