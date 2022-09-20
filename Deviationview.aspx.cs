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
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;

public partial class Deviationview : System.Web.UI.Page
{
    string clientname = "";
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
    string clientname1 = "";
    string agname = "";
    string status = "";
    string status1 = "";
    string hold = "";
    string adtypename = "";
    string editionname = "";
    string agencyname = "";
    string datefrom1 = "";
    string dateto1 = "";
    string city = "";
    decimal area = 0;
    int ins_no = 0;
    string package = "";
    string sortorder = "";
    string sortvalue = "";

    int sno = 1;

    double areanew = 0;
    double areasum = 0;


    protected void Page_Load(object sender, EventArgs e)
    {


        hiddendateformat.Value = Session["dateformat"].ToString();

        fromdt = Session["fromdate"].ToString();
        dateto = Session["todate"].ToString();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();

        if (Request.QueryString["drilout"] == "yes")
        {
            agname = Request.QueryString["agency"].Trim().ToString();
            clientname = Request.QueryString["client"].Trim().ToString();
            adtyp = Request.QueryString["adtype"].Trim().ToString();
            adcat = Request.QueryString["adcategory"].ToString();
            //fromdt = Request.QueryString["fromdate"].Trim().ToString();
            //dateto = Request.QueryString["dateto"].Trim().ToString();
            publ = Request.QueryString["publication"].Trim().ToString();
            pubcen = Request.QueryString["pubcenter"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();
            package = Request.QueryString["package"].Trim().ToString();
           // city = Request.QueryString["city"].ToString();
            status1 = Request.QueryString["status1"].ToString();
            destination = Request.QueryString["destination"].ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
            if (destination == "0" || destination == "1")
            {
                drillonscreen(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString());
            }
            else if (destination == "3")
            {

                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
                pdf_drillout(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel_drillout(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString());
            }
            

        }
        else
        {

            clientname = Request.QueryString["clientname"].ToString();

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
            adcatname = Request.QueryString["adcatname"].ToString();
            clientname1 = Request.QueryString["client"].ToString();
            agname = Request.QueryString["agname"].ToString();
            status1 = Request.QueryString["status1"].ToString();
            status = Request.QueryString["status"].ToString();
            adtypename = Request.QueryString["adtypename"].ToString();
            editionname = Request.QueryString["editionname"].ToString();
            agencyname = Request.QueryString["agencyname"].ToString();



            //hold = "abc";//comment by gaurav in sambad
            hiddendatefrom.Value = fromdt.ToString();

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


            //if (adcat == "0")
            //{
            //    Adcat.Text = " ";
            //}
            //else
            //{
            //    Adcat.Text = (adcatname.Replace("'", " ").ToString());
            //}
            if (clientname == "0")
            {

                lbclient.Text = "ALL".ToString();
            }
            else
            {
                lbclient.Text = clientname1.ToString();
            }
            //if (adtyp == "0")
            //{
            //    lbladtype.Text = "";
            //}
            //else
            //{
            //    lbladtype.Text = adtypename.ToString();

            //}
            //if (edition == "0")
            //{
            //    lbedition.Text = "ALL".ToString();
            //}
            //else
            //{
            //    lbedition.Text = editionname.ToString();



            //}

            //if (agname == "0")
            //{
            //    lbAgencyna.Text = "";
            //}
            //else
            //{
            //    lbAgencyna.Text = agencyname.ToString();
            //}


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
            // date = "";
            //if (fromdt != "")
            //{
            //    DateTime dt = Convert.ToDateTime(fromdt.ToString());
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
            //lblfrom.Text = date;
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
                onscreen(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
            }
            else if (destination == "4")
            {
                excel(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

            }
            else
                if (destination == "3")
                {
                    pdf(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);


                }
        }
    }


    private void onscreen(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
       // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Deviationreportnew";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        
        
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
     
        int i1 = 1;


      





        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~26' class='middle3'   onclick=sorting('Depth',this.id)>Depth<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imgdup' src='Images\\up.gif' style='display:none;'></td>   <td id='tdmd~27' class='middle3'   onclick=sorting('Width',this.id)>Width<img id='imgwdown' src='Images\\down.gif' style='display:block;'><img id='imgwup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~39' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:block;'><img id='imgaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~28' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~42' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='impaup' src='Images\\up.gif' style='display:none;'></td> <td id='tdmd~29' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No.<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~30' class='middle3'   onclick=sorting('BookDate',this.id)>BookDate<img id='imgbdown' src='Images\\down.gif' style='display:block;'><img id='imgbup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~31' class='middle3'   onclick=sorting('RoNo',this.id)>RoNo<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~32' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~16' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~17' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~33' class='middle3'   onclick=sorting('RateCode',this.id)>RateCode<img id='imgrndown' src='Images\\down.gif' style='display:block;'><img id='imgrnup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='middle3'   onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~40' class='middle3'   onclick=sorting('Deviation(%)',this.id)>Dev%<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imdup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~34' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td></tr>");           // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Dev%</td><td class='middle3'>Status</td></tr>");
        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~26' class='middle3'   onclick=sorting('Depth',this.id)>Depth<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imgdup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~27' class='middle3'   onclick=sorting('Width',this.id)>Width<img id='imgwdown' src='Images\\down.gif' style='display:block;'><img id='imgwup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~39' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:block;'><img id='imgaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~28' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~42' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='impaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~29' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No.<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~30' class='middle3'   onclick=sorting('BookDate',this.id)>BookDate<img id='imgbdown' src='Images\\down.gif' style='display:block;'><img id='imgbup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~31' class='middle3'   onclick=sorting('RoNo',this.id)>RoNo<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~32' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~16' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~17' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~33' class='middle3'   onclick=sorting('RateCode',this.id)>RateCode<img id='imgrndown' src='Images\\down.gif' style='display:block;'><img id='imgrnup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='middle3'   onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~40' class='middle3'   onclick=sorting('Deviation(%)',this.id)>Dev%<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imdup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~34' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td></tr>");            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Dev%</td><td class='middle3'>Status</td></tr>");

        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'  onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~26' class='middle3'  onclick=sorting('Depth',this.id)>Depth<img id='imgddown' src='Images\\down.gif' style='display:none;'><img id='imgdup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~27' class='middle3'  onclick=sorting('Width',this.id)>Width<img id='imgddown' src='Images\\down.gif' style='display:none;'><img id='imgwup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~39' class='middle3'  onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:none;'><img id='imgaup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~28' class='middle3'  onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:none;'><img id='imghup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~42' class='middle3'  onclick=sorting('Page',this.id)>Page<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='impaup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~29' class='middle3'  onclick=sorting('Ins.No.',this.id)>Ins.No.<img id='imgidown' src='Images\\down.gif' style='display:none;'><img id='imgiup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~30' class='middle3'  onclick=sorting('BookDate',this.id)>BookDate<img id='imgbdown' src='Images\\down.gif' style='display:none;'><img id='imgbup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~31' class='middle3'  onclick=sorting('RoNo',this.id)>RoNo<img id='imgrdown' src='Images\\down.gif' style='display:none;'><img id='imgrup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~32' class='middle3'  onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:none;'><img id='imgrup' src='Images\\up.gif' style='display:block;'></td><td id='tdat~16' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~17' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~33' class='middle3'  onclick=sorting('RateCode',this.id)>RateCode<img id='imgrndown' src='Images\\down.gif' style='display:none;'><img id='imgrnup' src='Images\\up.gif' style='display:block;'></td><td id='tdcard~29' class='middle3'  onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~31' class='middle3'  onclick=sorting('AgreedRate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~40' class='middle3'  onclick=sorting('Deviation(%)',this.id)>Dev%<img id='imgddown' src='Images\\down.gif' style='display:none;'><img id='imdup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~34' class='middle3'  onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:none;'><img id='imgstup' src='Images\\up.gif' style='display:block;'></td></tr>");           // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Dev%</td><td class='middle3'>Status</td></tr>");



        }




        double devi = 0;


      
        for (int i = 0; i <= cont - 1; i++)
        {
            devi = 0;
            tbl = tbl + ("<tr >");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
           
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
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");

        //    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");
 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");
      
            
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BookDate"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[15].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[16].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");
          
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

//if(ds.Tables[0].Rows[i]["CardRate"]=""||ds.Tables[0].Rows[i]["AgreedRate"]="")
//{
//devi=0;
//)
//else
//{
//devi = Convert.ToDouble(((Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]) - Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"])) / Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"])) * 100);
//}
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[19].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + Convert.ToDouble(devi)  + "</td>";
            tbl = tbl + (ds.Tables[0].Rows[i]["Deviation(%)"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[20].ToString() + "</td>");
           

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>"); 
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");


        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");


         tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1-1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
     //   tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
         tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td>");
         tbl = tbl + ("<td class='middle13'>");

        tbl = tbl + ("<td class='middle13'>");
     //   tbl = tbl + (area.ToString() + "</td>");

    
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
    }


    private void excel(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {


        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
        ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "");


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
        hw.Write("<p align=center>Deviation Report");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"8\">TOTAL</td><td>" + areanew + "</td></tr></table>"));
        Response.Flush();
        Response.End(); 


        /*
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
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader1 = null;
            OracleDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //myReader = obj.spDeviationexcel(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                myReader1 = obj.spDeviationexcel(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader1.Read())
                // {


                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));
                //heading.Text =
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                // oSheet.Cells[1, 7] = "Deviation Report";
                for (int j = 0; j < myReader1.FieldCount; j++)
                {

                    //-------------------------------
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 1 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 2 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 3 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    //oSheet.Cells[3, 5 + 1] = myReader1.GetName(4).ToString();
                    oSheet.Cells[3, 6 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 12 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                    oSheet.Cells[3, 13 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[14].ToString();
                    oSheet.Cells[3, 14 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 15 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 16 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 17 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 18 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 19 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 20 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 21 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[34].ToString();
                    oSheet.Cells[3, 22 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                    //oSheet.Cells[3, 22 + 1] = myReader1.GetName(23).ToString();
                    //oSheet.Cells[3, 23 + 1] = myReader1.GetName(24).ToString();
                    //oSheet.Cells[3, 24 + 1] = myReader1.GetName(25).ToString();
                    //oSheet.Cells[3, 25 + 1] = myReader1.GetName(26).ToString();

                    //oSheet.Cells[3, 26 + 1] = myReader1.GetName(27).ToString();


                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "AB3");
                oRng.EntireColumn.AutoFit();

                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //string total = "";
                //int tot = 0;
                //int finaltotal = 0;
                int i1 = 1;
                while (myReader1.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader1.FieldCount; k++)
                    {


                        oSheet.Cells[iRow, 1 + 1] = myReader1["CIOID"].ToString();
                        oSheet.Cells[iRow, 2 + 1] = myReader1["Ins.date"].ToString();
                        oSheet.Cells[iRow, 3 + 1] = myReader1["Agency"].ToString();
                        oSheet.Cells[iRow, 4 + 1] = myReader1["Client"].ToString();
                        oSheet.Cells[iRow, 5 + 1] = myReader1["City"].ToString();
                        //oSheet.Cells[iRow, 5 + 1] = myReader1.GetValue(4).ToString();
                        oSheet.Cells[iRow, 6 + 1] = myReader1["Package"].ToString();
                        oSheet.Cells[iRow, 7 + 1] = myReader1["Depth"].ToString();
                        oSheet.Cells[iRow, 8 + 1] = myReader1["Width"].ToString();
                        oSheet.Cells[iRow, 9 + 1] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 10 + 1] = myReader1["Hue"].ToString();

                        oSheet.Cells[iRow, 11 + 1] = myReader1["Page"].ToString();
                        oSheet.Cells[iRow, 12 + 1] = myReader1["Ins.No."].ToString();

                        oSheet.Cells[iRow, 13 + 1] = myReader1["BookDate"].ToString();
                        oSheet.Cells[iRow, 14 + 1] = myReader1["RoNo."].ToString();

                        oSheet.Cells[iRow, 15 + 1] = myReader1["RoStatus"].ToString();
                        oSheet.Cells[iRow, 16 + 1] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 17 + 1] = myReader1["AdCat"].ToString();
                        oSheet.Cells[iRow, 18 + 1] = myReader1["RateCode"].ToString();
                        oSheet.Cells[iRow, 19 + 1] = myReader1["CardRate"].ToString();
                        oSheet.Cells[iRow, 20 + 1] = myReader1["AgreedRate"].ToString();

                        oSheet.Cells[iRow, 21 + 1] = myReader1["Deviation(%)"].ToString();
                        oSheet.Cells[iRow, 22 + 1] = myReader1["Status"].ToString();
                        //oSheet.Cells[iRow, 22 + 1] = myReader1.GetValue(23).ToString();
                        //oSheet.Cells[iRow, 23 + 1] = myReader1.GetValue(24).ToString();
                        //oSheet.Cells[iRow, 24 + 1] = myReader1.GetValue(25).ToString();
                        //oSheet.Cells[iRow, 25 + 1] = myReader1.GetValue(26).ToString();
                        //oSheet.Cells[iRow, 26 + 1] = myReader1.GetValue(27).ToString();







                        // mnWidth = 6;

                    }




                    if (myReader1["Area"].ToString() != "")
                        area = area + Convert.ToInt32(myReader1["Area"].ToString());


                    iRow++;
                }






                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 10] = area.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;
                oRng.EntireColumn.AutoFit();

                myReader1.Close();
                myReader1 = null;

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                myReader = obj.spDeviationexcel(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold,"","","","");
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader.Read())
                // {


                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));
                //heading.Text =
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                // oSheet.Cells[1, 7] = "Deviation Report";
                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    //-------------------------------
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 1 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 2 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 3 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    //oSheet.Cells[3, 5 + 1] = myReader.GetName(4).ToString();
                    oSheet.Cells[3, 6 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 12 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                    oSheet.Cells[3, 13 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[14].ToString();
                    oSheet.Cells[3, 14 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 15 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 16 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 17 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 18 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 19 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 20 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 21 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[34].ToString();
                    oSheet.Cells[3, 22 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                    //oSheet.Cells[3, 22 + 1] = myReader.GetName(23).ToString();
                    //oSheet.Cells[3, 23 + 1] = myReader.GetName(24).ToString();
                    //oSheet.Cells[3, 24 + 1] = myReader.GetName(25).ToString();
                    //oSheet.Cells[3, 25 + 1] = myReader.GetName(26).ToString();

                    //oSheet.Cells[3, 26 + 1] = myReader.GetName(27).ToString();


                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "AB3");
                oRng.EntireColumn.AutoFit();

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


                        oSheet.Cells[iRow, 1 + 1] = myReader["CIOID"].ToString();
                        oSheet.Cells[iRow, 2 + 1] = myReader["Ins.date"].ToString();
                        oSheet.Cells[iRow, 3 + 1] = myReader["Agency"].ToString();
                        oSheet.Cells[iRow, 4 + 1] = myReader["Client"].ToString();
                        oSheet.Cells[iRow, 5 + 1] = myReader["City"].ToString();
                        //oSheet.Cells[iRow, 5 + 1] = myReader.GetValue(4).ToString();
                        oSheet.Cells[iRow, 6 + 1] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7 + 1] = myReader["Depth"].ToString();
                        oSheet.Cells[iRow, 8 + 1] = myReader["Width"].ToString();
                        oSheet.Cells[iRow, 9 + 1] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 10 + 1] = myReader["Hue"].ToString();

                        oSheet.Cells[iRow, 11 + 1] = myReader["Page"].ToString();
                        oSheet.Cells[iRow, 12 + 1] = myReader["Ins.No."].ToString();

                        oSheet.Cells[iRow, 13 + 1] = myReader["BookDate"].ToString();
                        oSheet.Cells[iRow, 14 + 1] = myReader["RoNo."].ToString();

                        oSheet.Cells[iRow, 15 + 1] = myReader["RoStatus"].ToString();
                        oSheet.Cells[iRow, 16 + 1] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 17 + 1] = myReader["AdCat"].ToString();
                        oSheet.Cells[iRow, 18 + 1] = myReader["RateCode"].ToString();
                        oSheet.Cells[iRow, 19 + 1] = myReader["CardRate"].ToString();
                        oSheet.Cells[iRow, 20 + 1] = myReader["AgreedRate"].ToString();

                        oSheet.Cells[iRow, 21 + 1] = myReader["Deviation(%)"].ToString();
                        oSheet.Cells[iRow, 22 + 1] = myReader["Status"].ToString();
                        //oSheet.Cells[iRow, 22 + 1] = myReader.GetValue(23).ToString();
                        //oSheet.Cells[iRow, 23 + 1] = myReader.GetValue(24).ToString();
                        //oSheet.Cells[iRow, 24 + 1] = myReader.GetValue(25).ToString();
                        //oSheet.Cells[iRow, 25 + 1] = myReader.GetValue(26).ToString();
                        //oSheet.Cells[iRow, 26 + 1] = myReader.GetValue(27).ToString();







                        // mnWidth = 6;

                    }




                    if (myReader["Area"].ToString() != "")
                        area = area + Convert.ToInt32(myReader["Area"].ToString());


                    iRow++;
                }






                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 10] = area.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;
                oRng.EntireColumn.AutoFit();

                myReader.Close();
                myReader = null;
            
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }

            
           
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "R1").MergeCells = true;
            oSheet.get_Range("A1", "R1").Font.Bold = true;
            oSheet.get_Range("A1", "R1").Font.Size = 10;
            oSheet.get_Range("A3", "AB3").Font.Bold = true;
            oSheet.get_Range("A3", "AB3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



            





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
            Response.Redirect("Deviationreport.aspx");
        }*/
    }

    //private void pdf(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    //{
    //    DataSet pdfxml = new DataSet();
    //    pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
    //    string pdfName = "";
    //    pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
    //    string name = Server.MapPath("") + "//" + pdfName;
    //    Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);


    //    PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
    //    int i2 = 0;
    //    //=======================================WATERMARK=========================================

    //    //try
    //    //{
    //    //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
    //    //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
    //    //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
    //    //    document.Add(watermark);
    //    //}
    //    //catch (Exception)
    //    //{
    //    //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
    //    //}

    //    //--------------------for page numbering---------------------------------------------

    //    //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
    //    HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
    //    footer.Border = Rectangle.NO_BORDER;
    //    footer.Alignment = Element.ALIGN_CENTER;
    //    document.Footer = footer;

    //    document.Open();
        
    //    int NumColumns = 23;
        
    //    //---------------------------------

    //    Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
    //    Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
    //    Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

    //    //----------------------------------------
       


    //    try
    //    {
    //        DataSet ds1 = new DataSet();
    //        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
    //        PdfPTable tbl = new PdfPTable(1);
    //        float[] xy = { 100 };
    //        tbl.DefaultCell.BorderWidth = 0;
    //        tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        tbl.setWidths(xy);
            
    //        //heading.Text =
    //        //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
    //        tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[3].ToString(), font9));
    //        //tbl.addCell("List of ADS -Hold/Cancelled");
    //        float[] headerwidths1 = { 50 };

    //        tbl.setWidths(headerwidths1);
    //        tbl.WidthPercentage = 100;
    //        //tbl.DefaultCell.Padding = -5;
    //        document.Add(tbl);
    //        //-----------------------------------------------
    //        PdfPTable tbl1 = new PdfPTable(1);
    //        tbl1.DefaultCell.BorderWidth = 0;
    //        tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        tbl1.addCell("");
    //        //tbl.addCell("List of ADS -Hold/Cancelled");
    //        //float[] headerwidths2 = { 15 };
    //        //tbl1.setWidths(headerwidths2);
    //        tbl1.WidthPercentage = 100;
    //        //tbl1.DefaultCell.Padding = -5;
    //        int i;
    //        for (i = 0; i < 2; i++)
    //        {
    //            document.Add(tbl1);
    //        }

    //        PdfPTable tbl2 = new PdfPTable(6);
    //        tbl2.DefaultCell.BorderWidth = 0;
    //        tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
    //        tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
    //        tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
    //        tbl2.addCell(new Phrase(dateto1.ToString(), font11));
    //        tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
    //        tbl2.addCell(new Phrase(date.ToString(), font11));
    //        tbl2.WidthPercentage = 100;
    //        document.Add(tbl2);
            
    //        //--------------------------------------------===
    //        PdfPTable datatable = new PdfPTable(NumColumns);

    //        datatable.DefaultCell.Padding = 3;

    //        //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


    //        //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
    //        //float[] headerwidths = { 12,14, 18, 17, 24, 24, 18, 13, 11, 15, 19, 18, 26, 26, 22, 27, 17, 16, 19, 19, 19, 18, 16 }; // percentage

    //        //datatable.setWidths(headerwidths);
    //        datatable.WidthPercentage = 100; // percentage
    //        datatable.DefaultCell.BorderWidth = 0;
    //        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
    //        //datatable.addCell(new Phrase("Pub", font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
    //      datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
          
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[34].ToString(), font10));
    //        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
          
    //        datatable.HeaderRows = 1;
    //        Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


    //        document.Add(p2);

    //        NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    //        SqlDataAdapter da = new SqlDataAdapter();
    //        DataSet ds = new DataSet();
    //        ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            
    //        int i1 = 1;
    //        for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
    //        {
                    
    //                datatable.addCell(new Phrase(i1++.ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

    //                area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());

    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                  
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Deviation(%)"].ToString(), font11));                    
    //                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                   
    //        }


    //        document.Add(datatable);
    //        Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


    //        document.Add(p3);

    //        PdfPTable tbltotal = new PdfPTable(13);
    //        float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 1, 10, 13, 10, 20 }; // percentage
    //        tbltotal.setWidths(headerwidths);
    //        tbltotal.DefaultCell.BorderWidth = 0;
    //        tbltotal.WidthPercentage = 100;
    //      //  tbltotal.DefaultCell.BorderWidth = 0;
    //        tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //        tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
    //        tbltotal.addCell(new Phrase((i1-1).ToString(), font11));

    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
    //        tbltotal.addCell(new Phrase(area.ToString(), font11));

    //        tbltotal.addCell(new Phrase(" ", font11));

    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        tbltotal.addCell(new Phrase(" ", font11));
    //        document.Add(tbltotal);

    //        document.Close();

    //        Response.Redirect(pdfName);

    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.WriteLine(e.StackTrace);
    //    }


    //}
    protected void btnprint_Click(object sender, EventArgs e)
    {
        pdf1(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
    }

    private void pdf1(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

       // btnprint.Attributes.Add("onclick", "javascript:window.print();");


        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
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
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        int NumColumns = 23;

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------



        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);

            //heading.Text =
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[3].ToString(), font9));
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

            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 12,14, 18, 17, 24, 24, 18, 13, 11, 15, 19, 18, 26, 26, 22, 27, 17, 16, 19, 19, 19, 18, 16 }; // percentage

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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[34].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

           // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
           //     ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "deviationreport";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {

                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Deviation(%)"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 1, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            //  tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

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
    private void drillonscreen(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string status, string dateformate)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
//            ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "deviationreport_drillout";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
       
        int i1 = 1;







        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~26' class='middle3'   onclick=sorting('Depth',this.id)>Depth<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imgdup' src='Images\\up.gif' style='display:none;'></td>   <td id='tdmd~27' class='middle3'   onclick=sorting('Width',this.id)>Width<img id='imgwdown' src='Images\\down.gif' style='display:block;'><img id='imgwup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~39' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:block;'><img id='imgaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~28' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~42' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='impaup' src='Images\\up.gif' style='display:none;'></td> <td id='tdmd~29' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No.<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~30' class='middle3'   onclick=sorting('BookDate',this.id)>BookDate<img id='imgbdown' src='Images\\down.gif' style='display:block;'><img id='imgbup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~31' class='middle3'   onclick=sorting('RoNo',this.id)>RoNo<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~32' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~16' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~17' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~33' class='middle3'   onclick=sorting('RateCode',this.id)>RateCode<img id='imgrndown' src='Images\\down.gif' style='display:block;'><img id='imgrnup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='middle3'   onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~40' class='middle3'   onclick=sorting('Deviation(%)',this.id)>Dev%<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imdup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~34' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td></tr>");           // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Dev%</td><td class='middle3'>Status</td></tr>");
        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~26' class='middle3'   onclick=sorting('Depth',this.id)>Depth<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imgdup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~27' class='middle3'   onclick=sorting('Width',this.id)>Width<img id='imgwdown' src='Images\\down.gif' style='display:block;'><img id='imgwup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~39' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:block;'><img id='imgaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~28' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~42' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='impaup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~29' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No.<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~30' class='middle3'   onclick=sorting('BookDate',this.id)>BookDate<img id='imgbdown' src='Images\\down.gif' style='display:block;'><img id='imgbup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~31' class='middle3'   onclick=sorting('RoNo',this.id)>RoNo<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~32' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~16' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~17' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~33' class='middle3'   onclick=sorting('RateCode',this.id)>RateCode<img id='imgrndown' src='Images\\down.gif' style='display:block;'><img id='imgrnup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='middle3'   onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~40' class='middle3'   onclick=sorting('Deviation(%)',this.id)>Dev%<img id='imgddown' src='Images\\down.gif' style='display:block;'><img id='imdup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~34' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:block;'><img id='imgstup' src='Images\\up.gif' style='display:none;'></td></tr>");            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Dev%</td><td class='middle3'>Status</td></tr>");

        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'  onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~26' class='middle3'  onclick=sorting('Depth',this.id)>Depth<img id='imgddown' src='Images\\down.gif' style='display:none;'><img id='imgdup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~27' class='middle3'  onclick=sorting('Width',this.id)>Width<img id='imgddown' src='Images\\down.gif' style='display:none;'><img id='imgwup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~39' class='middle3'  onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:none;'><img id='imgaup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~28' class='middle3'  onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:none;'><img id='imghup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~42' class='middle3'  onclick=sorting('Page',this.id)>Page<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='impaup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~29' class='middle3'  onclick=sorting('Ins.No.',this.id)>Ins.No.<img id='imgidown' src='Images\\down.gif' style='display:none;'><img id='imgiup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~30' class='middle3'  onclick=sorting('BookDate',this.id)>BookDate<img id='imgbdown' src='Images\\down.gif' style='display:none;'><img id='imgbup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~31' class='middle3'  onclick=sorting('RoNo',this.id)>RoNo<img id='imgrdown' src='Images\\down.gif' style='display:none;'><img id='imgrup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~32' class='middle3'  onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:none;'><img id='imgrup' src='Images\\up.gif' style='display:block;'></td><td id='tdat~16' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~17' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~33' class='middle3'  onclick=sorting('RateCode',this.id)>RateCode<img id='imgrndown' src='Images\\down.gif' style='display:none;'><img id='imgrnup' src='Images\\up.gif' style='display:block;'></td><td id='tdcard~29' class='middle3'  onclick=sorting('CardRate',this.id)>CardRate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~31' class='middle3'  onclick=sorting('AgreedRate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~40' class='middle3'  onclick=sorting('Deviation(%)',this.id)>Dev%<img id='imgddown' src='Images\\down.gif' style='display:none;'><img id='imdup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~34' class='middle3'  onclick=sorting('Status',this.id)>Status<img id='imgstdown' src='Images\\down.gif' style='display:none;'><img id='imgstup' src='Images\\up.gif' style='display:block;'></td></tr>");           // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Dev%</td><td class='middle3'>Status</td></tr>");



        }









        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");

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
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");

            area = area + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[8].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BookDate"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[15].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[16].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");

            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[19].ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Deviation(%)"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[20].ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[21].ToString() + "</td>");


        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");


        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "</td>");


        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
    
    }
    private void pdf_drillout(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string status, string dateformate, string descid, string ascdesc)
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
        //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
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

        int NumColumns = 23;

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------



        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);

            //heading.Text =
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[3].ToString(), font9));
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

            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 12,14, 18, 17, 24, 24, 18, 13, 11, 15, 19, 18, 26, 26, 22, 27, 17, 16, 19, 19, 19, 18, 16 }; // percentage

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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[34].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

           // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), descid, ascdesc);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), descid, ascdesc);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
//                ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), descid, ascdesc);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "deviationreport_drillout";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), descid, ascdesc };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {

                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Deviation(%)"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 1, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            //  tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

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
    private void excel_drillout(string client, string agency, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string status, string dateformate)
    {
        
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
//            ds = obj.drilloutdev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "deviationreport_drillout";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim() };
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
        hw.Write("<p align=center>Deviation Report");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"8\">TOTAL</td><td>" + areanew + "</td></tr></table>"));
        Response.Flush();
        Response.End(); 
        
        
        
    }/*string strCurrentDir = Server.MapPath(".") + "\\";
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
            //myReader = obj.drillout_dev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //DataSet dst=clsbook.spfun();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                myReader1 = obj.drillout_dev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader1.Read())
                // {


                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));
                //heading.Text =
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                // oSheet.Cells[1, 7] = "Deviation Report";
                for (int j = 0; j < myReader1.FieldCount; j++)
                {

                    //-------------------------------
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 1 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 2 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 3 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    //oSheet.Cells[3, 5 + 1] = myReader1.GetName(4).ToString();
                    oSheet.Cells[3, 6 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 12 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                    oSheet.Cells[3, 13 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[14].ToString();
                    oSheet.Cells[3, 14 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 15 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 16 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 17 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 18 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 19 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 20 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 21 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[34].ToString();
                    oSheet.Cells[3, 22 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                    //oSheet.Cells[3, 22 + 1] = myReader1.GetName(23).ToString();
                    //oSheet.Cells[3, 23 + 1] = myReader1.GetName(24).ToString();
                    //oSheet.Cells[3, 24 + 1] = myReader1.GetName(25).ToString();
                    //oSheet.Cells[3, 25 + 1] = myReader1.GetName(26).ToString();

                    //oSheet.Cells[3, 26 + 1] = myReader1.GetName(27).ToString();


                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "AB3");
                oRng.EntireColumn.AutoFit();

                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //string total = "";
                //int tot = 0;
                //int finaltotal = 0;
                int i1 = 1;
                while (myReader1.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader1.FieldCount; k++)
                    {


                        oSheet.Cells[iRow, 1 + 1] = myReader1["CIOID"].ToString();
                        oSheet.Cells[iRow, 2 + 1] = myReader1["Ins.date"].ToString();
                        oSheet.Cells[iRow, 3 + 1] = myReader1["Agency"].ToString();
                        oSheet.Cells[iRow, 4 + 1] = myReader1["Client"].ToString();
                        oSheet.Cells[iRow, 5 + 1] = myReader1["City"].ToString();
                        //oSheet.Cells[iRow, 5 + 1] = myReader1.GetValue(4).ToString();
                        oSheet.Cells[iRow, 6 + 1] = myReader1["Package"].ToString();
                        oSheet.Cells[iRow, 7 + 1] = myReader1["Depth"].ToString();
                        oSheet.Cells[iRow, 8 + 1] = myReader1["Width"].ToString();
                        oSheet.Cells[iRow, 9 + 1] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 10 + 1] = myReader1["Hue"].ToString();

                        oSheet.Cells[iRow, 11 + 1] = myReader1["Page"].ToString();
                        oSheet.Cells[iRow, 12 + 1] = myReader1["Ins.No."].ToString();

                        oSheet.Cells[iRow, 13 + 1] = myReader1["BookDate"].ToString();
                        oSheet.Cells[iRow, 14 + 1] = myReader1["RoNo."].ToString();

                        oSheet.Cells[iRow, 15 + 1] = myReader1["RoStatus"].ToString();
                        oSheet.Cells[iRow, 16 + 1] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 17 + 1] = myReader1["AdCat"].ToString();
                        oSheet.Cells[iRow, 18 + 1] = myReader1["RateCode"].ToString();
                        oSheet.Cells[iRow, 19 + 1] = myReader1["CardRate"].ToString();
                        oSheet.Cells[iRow, 20 + 1] = myReader1["AgreedRate"].ToString();

                        oSheet.Cells[iRow, 21 + 1] = myReader1["Deviation(%)"].ToString();
                        oSheet.Cells[iRow, 22 + 1] = myReader1["Status"].ToString();
                        //oSheet.Cells[iRow, 22 + 1] = myReader1.GetValue(23).ToString();
                        //oSheet.Cells[iRow, 23 + 1] = myReader1.GetValue(24).ToString();
                        //oSheet.Cells[iRow, 24 + 1] = myReader1.GetValue(25).ToString();
                        //oSheet.Cells[iRow, 25 + 1] = myReader1.GetValue(26).ToString();
                        //oSheet.Cells[iRow, 26 + 1] = myReader1.GetValue(27).ToString();







                        // mnWidth = 6;

                    }




                    if (myReader1["Area"].ToString() != "")
                        area = area + Convert.ToInt32(myReader1["Area"].ToString());


                    iRow++;
                }






                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 10] = area.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);
                oRng.EntireColumn.AutoFit();
                oSheet.get_Range(row, row1).Font.Bold = true;


                myReader1.Close();
                myReader1 = null;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                myReader = obj.drillout_dev(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, status1, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");

                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader.Read())
                // {


                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));
                //heading.Text =
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                // oSheet.Cells[1, 7] = "Deviation Report";
                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    //-------------------------------
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 1 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 2 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 3 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    //oSheet.Cells[3, 5 + 1] = myReader.GetName(4).ToString();
                    oSheet.Cells[3, 6 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 12 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                    oSheet.Cells[3, 13 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[14].ToString();
                    oSheet.Cells[3, 14 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 15 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 16 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 17 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 18 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 19 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 20 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 21 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[34].ToString();
                    oSheet.Cells[3, 22 + 1] = pdfxml.Tables[0].Rows[0].ItemArray[24].ToString();
                    //oSheet.Cells[3, 22 + 1] = myReader.GetName(23).ToString();
                    //oSheet.Cells[3, 23 + 1] = myReader.GetName(24).ToString();
                    //oSheet.Cells[3, 24 + 1] = myReader.GetName(25).ToString();
                    //oSheet.Cells[3, 25 + 1] = myReader.GetName(26).ToString();

                    //oSheet.Cells[3, 26 + 1] = myReader.GetName(27).ToString();


                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "AB3");
                oRng.EntireColumn.AutoFit();

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


                        oSheet.Cells[iRow, 1 + 1] = myReader["CIOID"].ToString();
                        oSheet.Cells[iRow, 2 + 1] = myReader["Ins.date"].ToString();
                        oSheet.Cells[iRow, 3 + 1] = myReader["Agency"].ToString();
                        oSheet.Cells[iRow, 4 + 1] = myReader["Client"].ToString();
                        oSheet.Cells[iRow, 5 + 1] = myReader["City"].ToString();
                        //oSheet.Cells[iRow, 5 + 1] = myReader.GetValue(4).ToString();
                        oSheet.Cells[iRow, 6 + 1] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7 + 1] = myReader["Depth"].ToString();
                        oSheet.Cells[iRow, 8 + 1] = myReader["Width"].ToString();
                        oSheet.Cells[iRow, 9 + 1] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 10 + 1] = myReader["Hue"].ToString();

                        oSheet.Cells[iRow, 11 + 1] = myReader["Page"].ToString();
                        oSheet.Cells[iRow, 12 + 1] = myReader["Ins.No."].ToString();

                        oSheet.Cells[iRow, 13 + 1] = myReader["BookDate"].ToString();
                        oSheet.Cells[iRow, 14 + 1] = myReader["RoNo."].ToString();

                        oSheet.Cells[iRow, 15 + 1] = myReader["RoStatus"].ToString();
                        oSheet.Cells[iRow, 16 + 1] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 17 + 1] = myReader["AdCat"].ToString();
                        oSheet.Cells[iRow, 18 + 1] = myReader["RateCode"].ToString();
                        oSheet.Cells[iRow, 19 + 1] = myReader["CardRate"].ToString();
                        oSheet.Cells[iRow, 20 + 1] = myReader["AgreedRate"].ToString();

                        oSheet.Cells[iRow, 21 + 1] = myReader["Deviation(%)"].ToString();
                        oSheet.Cells[iRow, 22 + 1] = myReader["Status"].ToString();
                        //oSheet.Cells[iRow, 22 + 1] = myReader.GetValue(23).ToString();
                        //oSheet.Cells[iRow, 23 + 1] = myReader.GetValue(24).ToString();
                        //oSheet.Cells[iRow, 24 + 1] = myReader.GetValue(25).ToString();
                        //oSheet.Cells[iRow, 25 + 1] = myReader.GetValue(26).ToString();
                        //oSheet.Cells[iRow, 26 + 1] = myReader.GetValue(27).ToString();







                        // mnWidth = 6;

                    }




                    if (myReader["Area"].ToString() != "")
                        area = area + Convert.ToInt32(myReader["Area"].ToString());


                    iRow++;
                }






                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 10] = area.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;
                oRng.EntireColumn.AutoFit();

                myReader.Close();
                myReader = null;
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }
            
            
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "R1").MergeCells = true;
            oSheet.get_Range("A1", "R1").Font.Bold = true;
            oSheet.get_Range("A1", "R1").Font.Size = 10;
            oSheet.get_Range("A3", "AB3").Font.Bold = true;
            oSheet.get_Range("A3", "AB3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



            





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
            Response.Redirect("Deviationreport.aspx");
        }
    }

      * 
      * 
      * 
      * 
      * */




    private void pdf(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

      //  btnprint.Attributes.Add("onclick", "javascript:window.print();");

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
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
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        int NumColumns = 23;

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------



        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);

            //heading.Text =
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[3].ToString(), font9));
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

            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 12,14, 18, 17, 24, 24, 18, 13, 11, 15, 19, 18, 26, 26, 22, 27, 17, 16, 19, 19, 19, 18, 16 }; // percentage

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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[34].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
           // ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
                ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "Deviationreportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {

                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

              //  area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Deviation(%)"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 10, 1, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            //  tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
           
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

//            tbltotal.addCell(new Phrase(area.ToString(), font11));

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

    }
}