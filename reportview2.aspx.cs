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
using System.Diagnostics.Design;
using System.Diagnostics;
using System.Data.OracleClient;

public partial class reportview2 : System.Web.UI.Page
{
    string agency = "";
    string client = "";
    string package = "";
    string dytbl = "";
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
    int area = 0;
    int i1 = 0;
    double amt = 0;
    string sortorder = "";
    string sortvalue = "";
   
    //string fromdt = "";
    //string dateto="";


    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    protected void Page_Load(object sender, EventArgs e)
    {
        
  
        
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

         

        if (Request.QueryString["drilout"] == "yes")
        {

            agency = Request.QueryString["agency"].Trim().ToString();
            adtyp = Request.QueryString["adtype"].Trim().ToString();
            adcat = Request.QueryString["adcategory"].Trim().ToString();
            //fromdt = Request.QueryString["fromdate"].Trim().ToString();
            //dateto = Request.QueryString["dateto"].Trim().ToString();
            publ = Request.QueryString["publication"].Trim().ToString();
            pubcen = Request.QueryString["pubcenter"].Trim().ToString();
            //pub2 = Request.QueryString["publiccent"].Trim().ToString();
            //pubcname = Request.QueryString["publicname"].Trim().ToString();
            client = Request.QueryString["client"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();
            destination = Request.QueryString["destination"].ToString();
            
            package = Request.QueryString["package"].Trim().ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
          

           // drillonscreen(client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package);

            if (destination == "3")


            {

                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
                pdf_drillout(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel_drillout(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString());
            }
            else if (destination == "1" || destination == "0")
            {
                drillonscreen(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString());

            }



 
           

        }
        else
        {

            agname = Request.QueryString["agname"].ToString();
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
            agencyname = Request.QueryString["agencyname"].ToString();
            adtypename = Request.QueryString["adtypename"].ToString();
            editionname = Request.QueryString["editionname"].ToString();
            agencysubcode1 = Request.QueryString["agencysubcode"].ToString();


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


            //if (agname == "0")
            //{
            //    lbAgencyna.Text  = "";
            //}
            //else
            //{
            //    lbAgencyna.Text = agencyname.ToString();
            //}
            //if (adtyp == "0")
            //{
            //    lbladtype.Text = "";
            //}
            //else
            //{
            //    lbladtype.Text =  adtypename.ToString();

            //}
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

            if (destination == "1" || destination == "0")
            {
                onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

            }
            else
                if (destination == "3")
                {
                    pdf(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                }

        }
    }



    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spAgency123(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
        }
        else
        {
            string procedureName = "REPORT";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        //garima1
        if (agencysubcode1 == "true")
        {

            tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
            //  tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Agency</td><td class='middle3'>SubAg</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Hue</td><td class='middle3'>Area</td><td class='middle3'>Page</td><td class='middle3'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>AggRate</td><td class='middle3'>Amt.</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");

            if (hiddenascdesc.Value == "")
            {
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdag~13' class='middle3'   onclick=sorting('SAPID',this.id)>SAPID<img id='imgciodown' src='Images\\down.gif' style='display:block;'><img id='imgcioup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdsu~24' class='middle3'   onclick=sorting('SubAg',this.id)>SubAg<img id='imgsudown' src='Images\\down.gif' style='display:block;'><img id='imgsuup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdh~23' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tda~19' class='middle3'   onclick=sorting('Area',this.id) align='right'>Area<img id='imgardown' src='Images\\down.gif' style='display:block;'><img id='imgarup' src='Images\\up.gif' style='display:none;'></td><td id='tdp~18' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpdown' src='Images\\down.gif' style='display:block;'><img id='imgpup' src='Images\\up.gif' style='display:none;'></td><td id='tdi~25' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~17' class='middle3'   onclick=sorting('RoNo.',this.id)>RoNo.<img id='imgrodown' src='Images\\down.gif' style='display:block;'><img id='imgroup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~34' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~15' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdr~22' class='middle3'   onclick=sorting('Rate_code',this.id)>Rate_code<img id='imgradown' src='Images\\down.gif' style='display:block;'><img id='imgraup' src='Images\\up.gif' style='display:none;'></td><td id='tda~21' class='middle3'   onclick=sorting('Agreed_Rate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdam~20' class='middle3'   onclick=sorting('Amt',this.id) align='right'>Net Amt.<img id='imgamdown' src='Images\\down.gif' style='display:block;'><img id='imgamup' src='Images\\up.gif' style='display:none;'></td><td id='tdCap~16' class='middle3'   onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:block;'><img id='imgcapup' src='Images\\up.gif' style='display:none;'></td><td id='tdk~15' class='middle3'   onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:block;'><img id='imgkup' src='Images\\up.gif' style='display:none;'></td></tr>");

            }
            else if (hiddenascdesc.Value == "asc")
            {



                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdag~13' class='middle3'   onclick=sorting('SAPID',this.id)>SAPID<img id='imgciodown' src='Images\\down.gif' style='display:block;'><img id='imgcioup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdsu~24' class='middle3'   onclick=sorting('SubAg',this.id)>SubAg<img id='imgsudown' src='Images\\down.gif' style='display:block;'><img id='imgsuup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdh~23' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tda~19' class='middle3'   onclick=sorting('Area',this.id) align='right'>Area<img id='imgardown' src='Images\\down.gif' style='display:block;'><img id='imgarup' src='Images\\up.gif' style='display:none;'></td><td id='tdp~18' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpdown' src='Images\\down.gif' style='display:block;'><img id='imgpup' src='Images\\up.gif' style='display:none;'></td><td id='tdi~25' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~17' class='middle3'   onclick=sorting('RoNo.',this.id)>RoNo.<img id='imgrodown' src='Images\\down.gif' style='display:block;'><img id='imgroup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~34' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~15' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdr~22' class='middle3'   onclick=sorting('Rate_code',this.id)>Rate_code<img id='imgradown' src='Images\\down.gif' style='display:block;'><img id='imgraup' src='Images\\up.gif' style='display:none;'></td><td id='tda~21' class='middle3'   onclick=sorting('Agreed_Rate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdam~20' class='middle3'   onclick=sorting('Amt',this.id) align='right'>Net Amt.<img id='imgamdown' src='Images\\down.gif' style='display:block;'><img id='imgamup' src='Images\\up.gif' style='display:none;'></td><td id='tdCap~16' class='middle3'   onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:block;'><img id='imgcapup' src='Images\\up.gif' style='display:none;'></td><td id='tdk~15' class='middle3'   onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:block;'><img id='imgkup' src='Images\\up.gif' style='display:none;'></td></tr>");

            }
            else if (hiddenascdesc.Value == "desc")
            {
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td> <td id='tdag~13' class='middle3'  onclick=sorting('SAPID',this.id)>SAPID<img id='imgciodown' src='Images\\down.gif' style='display:none;'><img id='imgcioup' src='Images\\up.gif' style='display:block;'></td> <td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdsu~24' class='middle3'  onclick=sorting('SubAg',this.id)>SubAg<img id='imgsudown' src='Images\\down.gif' style='display:none;'><img id='imgsuup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdci~6' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~7' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdh~23' class='middle3'  onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:none;'><img id='imghup' src='Images\\up.gif' style='display:block;'></td><td id='tda~19' class='middle3'  onclick=sorting('Area',this.id) align='right'>Area<img id='imgardown' src='Images\\down.gif' style='display:none;'><img id='imgarup' src='Images\\up.gif' style='display:block;'></td><td id='tdp~18' class='middle3'  onclick=sorting('Page',this.id)>Page<img id='imgpdown' src='Images\\down.gif' style='display:none;'><img id='imgpup' src='Images\\up.gif' style='display:block;'></td><td id='tdi~25' class='middle3'  onclick=sorting('Ins.No.',this.id)>Ins.No<img id='imgidown' src='Images\\down.gif' style='display:none;'><img id='imgiup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~17' class='middle3'  onclick=sorting('RoNo.',this.id)>RoNo.<img id='imgrodown' src='Images\\down.gif' style='display:none;'><img id='imgroup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~34' class='middle3'  onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:none;'><img id='imgrup' src='Images\\up.gif' style='display:block;'></td><td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~15' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td id='tdr~22' class='middle3'  onclick=sorting('Rate_code',this.id)>Rate_code<img id='imgradown' src='Images\\down.gif' style='display:none;'><img id='imgraup' src='Images\\up.gif' style='display:block;'></td><td id='tda~21' class='middle3'  onclick=sorting('Agreed_Rate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdam~20' class='middle3'  onclick=sorting('Amt',this.id)align='right'>Net Amt.<img id='imgamdown' src='Images\\down.gif' style='display:none;'><img id='imgamup' src='Images\\up.gif' style='display:block;'></td><td id='tdCap~16' class='middle3'  onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:none;'><img id='imgcapup' src='Images\\up.gif' style='display:block;'></td><td id='tdk~15' class='middle3'  onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:none;'><img id='imgkup' src='Images\\up.gif' style='display:block;'></td></tr>");

            }

            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SubAg"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");


                tbl = tbl + ("<td class='rep_data'align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
                if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");

                tbl = tbl + "</tr>";
                tbl = tbl + "</tr>";

            }



           // tbl = tbl + ("<tr >");
            /////////////

            tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";//<td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            tbl = tbl + ("<tr width='100%'>");
            tbl = tbl + ("<td class='middle3156'>TotalAds:-</td>");
            tbl = tbl + ("<td class='middle3156'>");
            tbl = tbl + ((i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;");


            tbl = tbl + ("<td class='middle3156'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle3156'>TotalArea:-</td><td class='middle3156'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156' align='right'>");
            tbl = tbl + (area.ToString() + "</td>");

            tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>TotalAmt:-</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'align='right'>");
            tbl = tbl + (amt.ToString() + "</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td>");
            tbl = tbl + "</tr>";
            //////////////
            //tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            //tbl = tbl + ("<tr >");
            //tbl = tbl + ("<td class='middle13'>TotalAds:-</td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + ((i1 - 1).ToString() + "</td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td><td class='middle13'></td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + (area.ToString() + "</td>");
            //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + (amt.ToString() + "</td>");
            //tbl = tbl + "</tr>";
            tbl = tbl + ("</table>");
            tblgrid.InnerHtml = tbl;


            double arr1 = amt / area;
            dytbl = dytbl + "<table>";
            dytbl = dytbl + "<tr>";
            dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
            dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
            dytbl = dytbl + ("<td class='middle13'>");
            dytbl = dytbl + (Math.Round (arr1).ToString() + "</td>");
            dytbl = dytbl + ("</tr>");
            dytbl += "</table>";
            dynamictable.Text = dytbl;


        }

        else
        {

            tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
            //   tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Hue</td><td class='middle3'>Area</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>AggRate</td><td class='middle3'>Amt.</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");



            //           <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
            //<td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
            //            <td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td>


            //           <td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
            //<td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
            //            <td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td>






            //<td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
            //    <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
            //        <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td>

            //                <td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td>
            //    <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td>
            //        <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td>




            //garima






            if (hiddenascdesc.Value == "")
            {

          //      tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Hue</td><td class='middle31'>Area</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>AdCat</td><td class='middle31'>RateCode</td><td class='middle3'>AggRate</td><td class='middle31'>Amt.</td><td class='middle3'>Cap</td><td class='middle31'>Key</td></tr>");

                tbl = tbl + ("<tr><td class='middle31'><b>S.No.</b></td><td id='tdag~13' class='middle3'   onclick=sorting('SAPID',this.id)>SAPID<img id='imgciodown' src='Images\\down.gif' style='display:block;'><img id='imgcioup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdh~23' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tda~19' class='middle3'   onclick=sorting('Area',this.id) align='right'>Area<img id='imgardown' src='Images\\down.gif' style='display:block;'><img id='imgarup' src='Images\\up.gif' style='display:none;'></td><td id='tdp~18' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpdown' src='Images\\down.gif' style='display:block;'><img id='imgpup' src='Images\\up.gif' style='display:none;'></td><td id='tdi~25' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~17' class='middle3'   onclick=sorting('RoNo.',this.id)>RoNo.<img id='imgrodown' src='Images\\down.gif' style='display:block;'><img id='imgroup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~32' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~15' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdr~22' class='middle3'   onclick=sorting('Rate_code',this.id)>Rate_code<img id='imgradown' src='Images\\down.gif' style='display:block;'><img id='imgraup' src='Images\\up.gif' style='display:none;'></td><td id='tda~21' class='middle3'   onclick=sorting('Agreed_Rate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdam~20' class='middle3'   onclick=sorting('Amt',this.id) align='right'>Net Amt.<img id='imgamdown' src='Images\\down.gif' style='display:block;'><img id='imgamup' src='Images\\up.gif' style='display:none;'></td><td id='tdCap~16' class='middle3'   onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:block;'><img id='imgcapup' src='Images\\up.gif' style='display:none;'></td><td id='tdk~15' class='middle3'   onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:block;'><img id='imgkup' src='Images\\up.gif' style='display:none;'></td></tr>");


            }
            else if (hiddenascdesc.Value == "asc")
            {

             //   tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Hue</td><td class='middle31'>Area</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td class='middle31'>AdCat</td><td class='middle31'>RateCode</td><td class='middle3'>AggRate</td><td class='middle31'>Amt.</td><td class='middle3'>Cap</td><td class='middle31'>Key</td></tr>");
                tbl = tbl + ("<tr><td class='middle31'><b>S.No.</b></td><td id='tdag~13' class='middle3'   onclick=sorting('SAPID',this.id)>SAPID<img id='imgciodown' src='Images\\down.gif' style='display:block;'><img id='imgcioup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdh~23' class='middle3'   onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:block;'><img id='imghup' src='Images\\up.gif' style='display:none;'></td><td id='tda~19' class='middle3'   onclick=sorting('Area',this.id) align='right'>Area<img id='imgardown' src='Images\\down.gif' style='display:block;'><img id='imgarup' src='Images\\up.gif' style='display:none;'></td><td id='tdp~18' class='middle3'   onclick=sorting('Page',this.id)>Page<img id='imgpdown' src='Images\\down.gif' style='display:block;'><img id='imgpup' src='Images\\up.gif' style='display:none;'></td><td id='tdi~25' class='middle3'   onclick=sorting('Ins.No.',this.id)>Ins.No<img id='imgidown' src='Images\\down.gif' style='display:block;'><img id='imgiup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~17' class='middle3'   onclick=sorting('RoNo.',this.id)>RoNo.<img id='imgrodown' src='Images\\down.gif' style='display:block;'><img id='imgroup' src='Images\\up.gif' style='display:none;'></td><td id='tdmd~32' class='middle3'   onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:block;'><img id='imgrup' src='Images\\up.gif' style='display:none;'></td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~15' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdr~22' class='middle3'   onclick=sorting('Rate_code',this.id)>Rate_code<img id='imgradown' src='Images\\down.gif' style='display:block;'><img id='imgraup' src='Images\\up.gif' style='display:none;'></td><td id='tda~21' class='middle3'   onclick=sorting('Agreed_Rate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdam~20' class='middle3'   onclick=sorting('Amt',this.id) align='right'>Net Amt.<img id='imgamdown' src='Images\\down.gif' style='display:block;'><img id='imgamup' src='Images\\up.gif' style='display:none;'></td><td id='tdCap~16' class='middle3'   onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:block;'><img id='imgcapup' src='Images\\up.gif' style='display:none;'></td><td id='tdk~15' class='middle3'   onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:block;'><img id='imgkup' src='Images\\up.gif' style='display:none;'></td></tr>");

            }
            else if (hiddenascdesc.Value == "desc")
            {

               // tbl = tbl + ("<tr><td class='middle31'>S.No.</td> <td class='middle31'>CIOID</td> <td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdci~6' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~7' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Hue</td><td class='middle3'>Area</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>AdCat</td><td class='middle31'>RateCode</td><td class='middle3'>AggRate</td><td class='middle31'>Amt.</td><td class='middle3'>Cap</td><td class='middle31'>Key</td></tr>");
                tbl = tbl + ("<tr><td class='middle31'><b>S.No.</b></td> <td id='tdag~13' class='middle3'  onclick=sorting('SAPID',this.id)>SAPID<img id='imgciodown' src='Images\\down.gif' style='display:none;'><img id='imgcioup' src='Images\\up.gif' style='display:block;'></td> <td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdci~6' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~7' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdh~23' class='middle3'  onclick=sorting('Hue',this.id)>Hue<img id='imghdown' src='Images\\down.gif' style='display:none;'><img id='imghup' src='Images\\up.gif' style='display:block;'></td><td id='tda~19' class='middle3'  onclick=sorting('Area',this.id) align='right'>Area<img id='imgardown' src='Images\\down.gif' style='display:none;'><img id='imgarup' src='Images\\up.gif' style='display:block;'></td><td id='tdp~18' class='middle3'  onclick=sorting('Page',this.id)>Page<img id='imgpdown' src='Images\\down.gif' style='display:none;'><img id='imgpup' src='Images\\up.gif' style='display:block;'></td><td id='tdi~25' class='middle3'  onclick=sorting('Ins.No.',this.id)>Ins.No<img id='imgidown' src='Images\\down.gif' style='display:none;'><img id='imgiup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~17' class='middle3'  onclick=sorting('RoNo.',this.id)>RoNo.<img id='imgrodown' src='Images\\down.gif' style='display:none;'><img id='imgroup' src='Images\\up.gif' style='display:block;'></td><td id='tdmd~32' class='middle3'  onclick=sorting('RoStatus',this.id)>RoStatus<img id='imgrdown' src='Images\\down.gif' style='display:none;'><img id='imgrup' src='Images\\up.gif' style='display:block;'></td><td id='tdat~14' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~15' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td id='tdr~22' class='middle3'  onclick=sorting('Rate_code',this.id)>Rate_code<img id='imgradown' src='Images\\down.gif' style='display:none;'><img id='imgraup' src='Images\\up.gif' style='display:block;'></td><td id='tda~21' class='middle3'  onclick=sorting('Agreed_Rate',this.id)>AggRate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdam~20' class='middle3'  onclick=sorting('Amt',this.id) align='right'>Net Amt.<img id='imgamdown' src='Images\\down.gif' style='display:none;'><img id='imgamup' src='Images\\up.gif' style='display:block;'></td><td id='tdCap~16' class='middle3'  onclick=sorting('Cap',this.id)>Cap<img id='imgCapdown' src='Images\\down.gif' style='display:none;'><img id='imgcapup' src='Images\\up.gif' style='display:block;'></td><td id='tdk~15' class='middle3'  onclick=sorting('Key',this.id)>Key<img id='imgkdown' src='Images\\down.gif' style='display:none;'><img id='imgkup' src='Images\\up.gif' style='display:block;'></td></tr>");


            }




            int i1 = 1;
            int area = 0;
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");



                //tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["SubAg"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");


                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")

                    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");



                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Adtype"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
                if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");


                tbl = tbl + "</tr>";
                tbl = tbl + "</tr>";

            }




           // tbl = tbl + ("<tr >");
            /////////
            tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";//<td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            tbl = tbl + ("<tr width='100%'>");
            tbl = tbl + ("<td class='middle3156'>TotalAds:-</td>");
            tbl = tbl + ("<td class='middle3156'>");
            tbl = tbl + ((i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;");


            tbl = tbl + ("<td class='middle3156'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle3156'>TotalArea:-</td><td class='middle3156'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156' align='right'>");
            tbl = tbl + (area.ToString() + "</td>");

            tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>TotalAmt:-</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'align='right'>");
            tbl = tbl + (amt.ToString() + "</td>");
            tbl = tbl + ("<td class='middle3156'>&nbsp;<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td>");
            tbl = tbl + "</tr>";
            /////////////
            //tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            //tbl = tbl + ("<tr >");
            //tbl = tbl + ("<td class='middle13'>TotalAds:-</td>");
            ////tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + ((i1 - 1).ToString() + "</td>");
            //tbl = tbl + ("<td class='middle13'>");

            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td><td class='middle13'></td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + (area.ToString() + "</td>");

            //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + (amt.ToString() + "</td>");
            //tbl = tbl + "</tr>";

            tbl = tbl + ("</table>");
            tblgrid.InnerHtml = tbl;


            double arr1 = amt / area;
            dytbl = dytbl + "<table>";
            dytbl = dytbl + "<tr>";
            dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
            dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
            dytbl = dytbl + ("<td class='middle13'>");
            dytbl = dytbl + (Math .Round(arr1).ToString() + "</td>");
            dytbl = dytbl + ("</tr>");
            dytbl += "</table>";
            dynamictable.Text = dytbl;

        }


    }

   



    private void excel(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";

        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spAgency123(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
        }
        else
        {
            string procedureName = "REPORT";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "";
        tbl = "<table width='100%' border='1' cellpadding='0' cellspacing='0'>";
        string pub = "";
        if (publ == "0")
        {
            pub = "ALL";
        }
        else
        {
            pub = pubcname.ToString();
        }
        string pubcernt = "";
        if (pubcen == "0")
        {
            pubcernt = "ALL";
        }
        else
        {
            pubcernt = pub2.ToString();
        }
        string edit = "";

        if (edition == "0")
        {
            edit = "ALL";
        }
        else
        {
            edit = editionname.ToString();

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
        string rundate = lbldate.Text;

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
        string fromdate = lblfrom.Text;
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
        // string dateto123 = "";
        string dateto123 = lblto.Text;
        tbl = tbl + "<tr width='100%'><td  align='center'style='font-family:Arial;font-size:12px;' colspan='14'><b>ALL ADS OF AGENCY </b></td></tr>";
        tbl = tbl + "<tr width='100%'><td  align='left'style='font-family:Arial;font-size:12px;' colspan='3'><b>Publication :</b>" + pub + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='3'><b>Pub Center :</b>" + pubcernt + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='13'><b>Edition :</b>" + edit + "</td></tr>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'  colspan='3'><b>Date From :</b>" + fromdate + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'  colspan='3'><b>Date To :</b>" + dateto123 + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='13'><b>Run Date :</b>" + rundate + "</td></tr></table>";

        tbl = tbl + "<table width='100%'align='left' cellpadding='5' border='1' cellspacing='0'>";
        //garima1
        if (agencysubcode1 == "true")
        {

           // tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
            //  tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Agency</td><td class='middle3'>SubAg</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Hue</td><td class='middle3'>Area</td><td class='middle3'>Page</td><td class='middle3'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>AggRate</td><td class='middle3'>Amt.</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");


            tbl = tbl + ("<tr><td class='middle31' align='right'><b>S.No.</b></td><td id='tdag~13' class='middle3'   ><b>SAPID</b></td><td class='middle31'><b>Ins.Date</b></td><td id='tdag~3' class='middle3' ><b>Agency</b></td><td id='tdsu~24' class='middle3' ><b>SubAg</b></td><td id='tdcl~5' class='middle3'  ><b>Client</b></td><td id='tdci~6' class='middle3' ><b>City<b></td> <td id='tdcl~7' class='middle3'><b>Package</b></td><td id='tdh~23' class='middle3' ><b>Hue</b></td><td id='tda~19' class='middle3' ><b>Area</b></td><td id='tdp~18' class='middle3'><b>Page</b></td><td id='tdi~25' class='middle3' ><b>Ins.No</b></td><td id='tdro~17' class='middle3'><b>RoNo.</b></td><td id='tdro~34' class='middle3' ><b>RoStatus</b></td><td id='tdat~14' class='middle3'  ><b>AdType<b></td> <td id='tdad~15' class='middle3'><b>AdCat</b></td><td id='tdr~22' class='middle3' ><b>Rate_code</b></td><td id='tda~21' class='middle3' ><b>AggRate</b></td><td id='tdam~20' class='middle3'  ><b>Net Amt.</b></td><td id='tdCap~16' class='middle3' ><b>Cap</b></td><td id='tdk~15' class='middle3'  ><b>Key</b></td></tr>");



            int i12 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i12++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SubAg"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
                if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");

                tbl = tbl + "</tr>";
                tbl = tbl + "</tr>";

            }



            tbl = tbl + ("<tr >");
            tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle13' align='right'>TotalAds:");
           // tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ((i12 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td><td class='middle13'></td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (area.ToString() + "</td>");
            tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (amt.ToString() + "</td>");
            tbl = tbl + "</tr>";
            tbl = tbl + ("</table>");
            tblgrid.InnerHtml = tbl;


            double arr1 = amt / area;
            dytbl = dytbl + "<table>";
            dytbl = dytbl + "<tr>";
            dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
            dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
            dytbl = dytbl + ("<td class='middle13'>");
            dytbl = dytbl + (Math.Round(arr1).ToString() + "</td>");
            dytbl = dytbl + ("</tr>");
            dytbl += "</table>";
            dynamictable.Text = dytbl;


        }

        else
        {

          //  tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
            //   tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Hue</td><td class='middle3'>Area</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>AggRate</td><td class='middle3'>Amt.</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");



            //           <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
            //<td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
            //            <td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td>


            //           <td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
            //<td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
            //            <td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td>






            //<td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
            //    <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
            //        <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td>

            //                <td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td>
            //    <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td>
            //        <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td>




            //garima








            //      tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdci~6' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~7' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Hue</td><td class='middle31'>Area</td><td class='middle31'>Page</td><td class='middle31'>Ins.No</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>AdCat</td><td class='middle31'>RateCode</td><td class='middle3'>AggRate</td><td class='middle31'>Amt.</td><td class='middle3'>Cap</td><td class='middle31'>Key</td></tr>");

            tbl = tbl + ("<tr><td class='middle31'><b>S.No.</b></td><td id='tdag~13' class='middle3'><b>SAPID</b></td><td class='middle31'><b>Ins.Date</b></td><td id='tdag~3' class='middle3' ><b>Agency</b></td><td id='tdcl~5' class='middle3' ><b>Client</b></td><td id='tdci~6' class='middle3' ><b>City</b></td> <td id='tdcl~7' class='middle3'><b>Package</b></td><td id='tdh~23' class='middle3'><b>Hue</b></td><td id='tda~19' class='middle3' ><b>Area</b></td><td id='tdp~18' class='middle3' ><b>Page</b></td><td id='tdi~25' class='middle3'><b>Ins.No</b></td><td id='tdro~17' class='middle3'><b>RoNo.</b></td><td id='tdmd~32' class='middle3'><b>RoStatus</b></td><td id='tdat~14' class='middle3'><b>AdType</b></td> <td id='tdad~15' class='middle3' ><b>AdCat</b></td><td id='tdr~22' class='middle3' ><b>Rate_code</b></td><td id='tda~21' class='middle3'><b>AggRate</b></td><td id='tdam~20' class='middle3'><b>Net Amt.</b></td><td id='tdCap~16' class='middle3' ><b>Cap</b></td><td id='tdk~15' class='middle3' ><b>Key</b></td></tr>");







            int i12 = 1;
            int area = 0;
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i12++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");



                //tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["SubAg"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")

                    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");



                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Adtype"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
                if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");


                tbl = tbl + "</tr>";
                tbl = tbl + "</tr>";

            }




            tbl = tbl + ("<tr >");
            tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle13' align='right'>TotalAds:");
            //tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ((i12 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td><td class='middle13'></td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (area.ToString() + "</td>");

            tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (amt.ToString() + "</td>");
            tbl = tbl + "</tr>";

            tbl = tbl + ("</table>");
            double arr1 = amt / area;
            tbl = tbl + "<table>";
            tbl = tbl + "<tr>";
            tbl = tbl + "<td class='middle13'>Average Rate Realisation </td>";
            tbl = tbl + ("<td class='middle13' > (ARR) : </td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (Math.Round(arr1).ToString() + "</td>");
            tbl = tbl + ("</tr>");
            tbl += "</table>";
           // dynamictable.Text = dytbl;
            tblgrid.InnerHtml = tbl;


            //double arr1 = amt / area;
            //dytbl = dytbl + "<table>";
            //dytbl = dytbl + "<tr>";
            //dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
            //dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
            //dytbl = dytbl + ("<td class='middle13'>");
            //dytbl = dytbl + (Math.Round(arr1).ToString() + "</td>");
            //dytbl = dytbl + ("</tr>");
            //dytbl += "</table>";
            //dynamictable.Text = dytbl;
        }

        

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
       // hw.Write("<p align=center>ALL ADS OF AGENCY");
        hw.WriteBreak();
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());

        Response.Flush();
        Response.End();
    }

    private void pdf(string agname, String adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
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
        HeaderFooter footer = new HeaderFooter(new Phrase(""), true);
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
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[1].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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



            PdfPTable tbl255 = new PdfPTable(3);
            tbl255.DefaultCell.BorderWidth = 0;
            tbl255.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl255.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            string pub = "";
            if (publ == "0")
            {
                pub = "ALL";
            }
            else
            {
                pub = pubcname.ToString();
            }
            string pubcernt = "";
            if (pubcen == "0")
            {
                pubcernt = "ALL";
            }
            else
            {
                pubcernt = pub2.ToString();
            }
            string edit = "";

            if (edition == "0")
            {
                edit = "ALL";
            }
            else
            {
                edit = editionname.ToString();

            }
            tbl255.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            tbl255.addCell(new Phrase("Publication:" + pub, font10));
            tbl255.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl255.addCell(new Phrase("Pub Center:" + pubcernt, font10));
            tbl255.addCell(new Phrase("Edition:" + edit, font10));
            //tbl255.addCell(new Phrase(dateto1.ToString(), font11));
            //tbl255.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            //tbl255.addCell(new Phrase(date.ToString(), font11));
            tbl255.WidthPercentage = 100;
            document.Add(tbl255);



            PdfPTable tbl2 = new PdfPTable(3);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase("From Date:" + datefrom1, font10));
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase("To Date:" + dateto1, font10));
            //tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            // tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            //tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.addCell(new Phrase("Run Date:" + date, font10));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            
            //PdfPTable tbl2 = new PdfPTable(6);
            //tbl2.DefaultCell.BorderWidth = 0;
            //tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            //tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            //tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            //tbl2.addCell(new Phrase(date.ToString(), font11));
            //tbl2.WidthPercentage = 100;
            //document.Add(tbl2);

            //-------------------------------------
            PdfPTable tb89 = new PdfPTable(20);
            tb89.DefaultCell.BorderWidth = 0;
            tb89.WidthPercentage = 100;
            tb89.DefaultCell.Colspan = 20;
            tb89.addCell(new Phrase("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));
            document.Add(tb89);

            //int NumColumns = 20;
            PdfPTable datatable = new PdfPTable(20);

            //int NumColumns1 = 20;
            PdfPTable datatable1 = new PdfPTable(20);

            //------------------------------------------------------------------------------------------------------
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage

            if (agencysubcode1 == "true")
            {
              //  datatable.DefaultCell.Padding = 3;
                datatable.WidthPercentage = 100; // percentage
                float[] headerwidths = { 7, 5, 15, 15, 15, 10, 10, 8, 10, 8, 6, 6, 10, 10, 10, 10, 7, 15, 6, 6 };

                datatable.setWidths(headerwidths);
                
                datatable.DefaultCell.BorderWidth = 0;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
               // datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[32].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                //datatable.addCell(new Phrase("Pub", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                //datatable.addCell(new Phrase("Depth", font10));
                //datatable.addCell(new Phrase("Width", font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

                // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10)); ;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
               
                datatable.DefaultCell.Colspan = 20;
                datatable.addCell(new Phrase("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));
                // document.Add(tb8944);
                // datatable.HeaderRows = 1;
                datatable.DefaultCell.Colspan = 1;
                //Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


                //document.Add(p2);

                //datatable.HeaderRows = 1;

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
                    ds = obj.spAgency123(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
                }
                else
                {
                    string procedureName = "REPORT";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "" };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                //int i1 = 1;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SubAg"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));

                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString()));
                    //datatable1.HeaderRows = 1;
                    //}
                    //break;

                    //}
                }


            }
            else
            {

                datatable1.WidthPercentage = 100; // percentage
                float[] abc = {7, 5, 15, 15, 15, 10, 10, 8, 10, 8, 6, 6, 10, 10, 10, 10,7,15,6, 6};

                datatable1.setWidths(abc);

                datatable1.DefaultCell.BorderWidth = 0;
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable1.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable1.DefaultCell.Colspan = 20;
                datatable1.addCell(new Phrase("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));
                // Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());
                // document.Add(tb8944);
                // datatable.HeaderRows = 1;
             
                //document.Add(p2);
                //datatable1.HeaderRows = 1;
              //  datatable1.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable1.DefaultCell.Colspan = 1;
                
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
                    ds = obj.spAgency123(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
                }
                else
                {
                    string procedureName = "REPORT";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "" };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }


                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable1.addCell(new Phrase(i1++.ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    //datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][26].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    //datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));

                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                   area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                   datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                    // ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row].ItemArray[11].ToString());

                    // datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][13].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                    datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));

                }


                document.Add(datatable1);


                //   document.Add(datatable);
                Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
                document.Add(p3);



                PdfPTable tbltotal = new PdfPTable(20);
                float[] headerwidths = { 11, 8, 8, 5, 8, 8, 10, 11, 5, 8, 8, 10, 10, 7, 15, 18,25, 20,20,6 }; // percentage
                tbltotal.setWidths(headerwidths);
                tbltotal.DefaultCell.BorderWidth = 0;
                tbltotal.WidthPercentage = 100;
                tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
                tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
                //tbltotal.addCell(new Phrase(" ", font11));
                  // tbltotal.addCell(new Phrase(area.ToString(), font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase(area.ToString(), font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase("", font11));
                tbltotal.addCell(new Phrase(" ", font11));
              //tbltotal.addCell(new Phrase(" ", font11));
                //tbltotal.addCell(new Phrase(billarea.ToString(), font11));
               // tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                tbltotal.addCell(new Phrase(amt.ToString(), font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));

                document.Add(tbltotal);

                ////////////////////////////////////////////////////////////////////////////////////////

                Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
                document.Add(p4);

                PdfPTable tbltotal1 = new PdfPTable(4);
                float[] headerwidths11 = { 25, 8, 20, 70 }; // percentage
                tbltotal1.setWidths(headerwidths11);
                tbltotal1.DefaultCell.BorderWidth = 0;
                tbltotal1.WidthPercentage = 100;
                tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                double arr = amt / area;
                tbltotal1.addCell(new Phrase("Average Rate Realisation(ARR):", font10));
                //tbltotal1.addCell(new Phrase(" : ", font10));
             //   tbltotal1.addCell(new Phrase("ARR ", font10));
                //tbltotal1.addCell(new Phrase(" : ", font10));
                //tbltotal1.addCell(new Phrase(" : ", font10));
                tbltotal1.addCell(new Phrase(Math.Round(arr).ToString(), font10));
                tbltotal1.addCell(new Phrase(" ", font10));
                tbltotal1.addCell(new Phrase(" ", font10));

                document.Add(tbltotal1);
                document.Close();
                Response.Redirect(pdfName);


            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        pdf1(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
    }

    private void pdf1(string agname, String adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
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
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[1].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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

            //-------------------------------------

            int NumColumns = 21;
            PdfPTable datatable = new PdfPTable(NumColumns);

            int NumColumns1 = 20;
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

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[32].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                //datatable.addCell(new Phrase("Pub", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                //datatable.addCell(new Phrase("Depth", font10));
                //datatable.addCell(new Phrase("Width", font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

                // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10)); ;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));


                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

                Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());

                document.Add(p2);
                datatable.HeaderRows = 1;
                  SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.classnew obj = new NewAdbooking.classesoracle.classnew();
                    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");
                }
                else
                {
                string procedureName = "reportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                //int i1 = 1;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {

                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SubAg"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));


                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString()));
                    //datatable1.HeaderRows = 1;
                    //}
                    //break;

                    //}
                }


            }
            else
            {

                datatable1.WidthPercentage = 100; // percentage
                datatable1.DefaultCell.BorderWidth = 0;
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable1.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;


                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));

                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

                Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


                document.Add(p2);
                datatable1.HeaderRows = 1;

                  SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");
                }
                else
                {
                    string procedureName = "reportnew";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = { agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "" };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                //int i1 = 1;





                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    //for (int a = 0; a <= 10; ++a)
                    //{
                    //for (int column = 0; column < ds.Tables[0].Columns.Count; column++)
                    //{
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString(), font11));
                    datatable1.addCell(new Phrase(i1++.ToString(), font11));
                    // datatable1.addCell(new Phrase(i1++.ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    //datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][26].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    //datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));


                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                    // ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row].ItemArray[11].ToString());

                    // datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][13].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString()));
                    //datatable1.HeaderRows = 1;
                    //}
                    //break;

                    //}
                }

            }





            document.Add(datatable);
            document.Add(datatable1);

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);



            PdfPTable tbltotal = new PdfPTable(12);
            float[] headerwidths = { 11, 13, 21, 21, 6, 10, 10, 6, 10, 19, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));


            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));

            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));

            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));



            //tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
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
            tbltotal1.addCell(new Phrase("ARR ", font10));
            tbltotal1.addCell(new Phrase(" : ", font10));
            tbltotal1.addCell(new Phrase(arr.ToString(), font10));
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
    private void drillonscreen(string client, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string dateformat)
    {    
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
            ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","","","");
        }
        else
        {
            string procedureName = "report_drillout_report_drillout_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";          

       

            tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
          



            if (hiddenascdesc.Value == "")
            {

                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>SAPID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td> <td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Hue</td><td class='middle31'>Area</td><td class='middle31'>page</td><td class='middle31'>Ins.No</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>AggRate</td><td class='middle31'>Amt.</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");


            }
            else if (hiddenascdesc.Value == "asc")
            {

                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>SAPID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Hue</td><td class='middle31'>Area</td><td class='middle31'>page</td><td class='middle31'>Ins.No</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td> <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>AggRate</td><td class='middle31'>Amt.</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");

            }
            else if (hiddenascdesc.Value == "desc")
            {

                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>SAPID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td> <td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td> <td id='tdcl~5' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td> <td id='tdcl~6' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Hue</td><td class='middle31'>Area</td><td class='middle31'>page</td><td class='middle31'>Ins.No</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td> <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>RateCode</td><td class='middle31'>AggRate</td><td class='middle31'>Amt.</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");

            }




            int i1 = 1;
            int area = 0;
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

                area = area + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[8].ToString());

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");



                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RoStatus"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Adtype"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["RateCode"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
                if (ds.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");


                tbl = tbl + "</tr>";
                tbl = tbl + "</tr>";

            }




            tbl = tbl + ("<tr >");
            tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle13'>TotalAds:-</td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ((i1 - 1).ToString() + "</td>");
            tbl = tbl + ("<td class='middle13'>");

            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td><td class='middle13'></td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (area.ToString() + "</td>");

            tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
            tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + (amt.ToString() + "</td>");
            tbl = tbl + "</tr>";

            tbl = tbl + ("</table>");
            tblgrid.InnerHtml = tbl;


        
    }




    private void excel_drillout(string client, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string dateformat)
    {
            
       

              SqlDataAdapter da = new SqlDataAdapter();
              DataSet ds = new DataSet();
              if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
              {
                  NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                  ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
              }
              else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
              {
                  NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                  ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "");
              }
              else
              {
                  string procedureName = "report_drillout_report_drillout_p";
                  NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                  string[] parameterValueArray = { client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "" };
                  ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
              }
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            // Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            //string danish=" , , , , , , , , , , , , , , , , , ";
            //object abc[]= danish.Split(
            //ds.Tables[0].Rows.Add(
            DataGrid1.DataSource = ds;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p align=center>All Ads Of The Agency");
            // hw.Write("<ul><li>test</li></ul>");
            //hw.Write(comm2);
            hw.WriteBreak();
            //DataGrid1.in
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;

            if (agencysubcode1 == "true")
            {


                Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"8\">TOTAL</td><td>" + areanew + "</td><td colspan=\"8\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td><tr><td>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));
            }
            else
            {

                Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"7\">TOTAL</td><td>" + areanew + "</td><td colspan=\"8\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td><tr><td>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));

            }



            //Response.Write(sw.ToString().Replace("</table>", "<tr><td align=\"center\" colspan=\"7\">TOTAL</td><td>50</td><td colspan=\"7\">&nbsp;</td><td>"+comm2+"</td><td></td><td></td></table>"));
            Response.Flush();
            Response.End(); 

    }
    
    
    /*
        string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        Excel.Range oRng1;


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
            SqlDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));


            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            myReader = obj.drillout_clientexcel(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString());
            //DataSet dst=clsbook.spfun();
            int iRow = 4;  //2
            oSheet.PageSetup.CenterFooter = "&P";
            // while(myReader.Read())
            // {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[1].ToString();

            //oSheet.Cells[1, 7] = "All Ads of A Agency ";

           

                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    // oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[32].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    //oSheet.Cells[3, 7] = myReader.GetName(4).ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();
                    oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 20] = pdfxml.Tables[0].Rows[0].ItemArray[26].ToString();
                    oSheet.Cells[3, 21] = pdfxml.Tables[0].Rows[0].ItemArray[27].ToString();

                }
                //   }
                // build the sheet contents
                //for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                //{
                //    oSheet.Cells[1, i + 1] = dst.Tables[0].Rows[0].ItemArray[i].ToString();
                //}
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "W3");
                oRng.EntireColumn.AutoFit();

                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //string total = "";
                int i1 = 1;
                //int finaltotal = 0;
                while (myReader.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader.FieldCount; k++)
                    {

                        oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                        oSheet.Cells[iRow, 5] = myReader["SubAg"].ToString();
                        oSheet.Cells[iRow, 6] = myReader["Client"].ToString();
                        //oSheet.Cells[iRow, 7] = myReader.GetValue(4).ToString();
                        oSheet.Cells[iRow, 7] = myReader["City"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["Page"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["Ins.No."].ToString();
                        oSheet.Cells[iRow, 13] = myReader["RoNo."].ToString();
                        oSheet.Cells[iRow, 14] = myReader["RoStatus"].ToString();
                        oSheet.Cells[iRow, 15] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 16] = myReader["AdCat"].ToString();
                        oSheet.Cells[iRow, 17] = myReader["RateCode"].ToString();
                        oSheet.Cells[iRow, 18] = myReader["AgreedRate"].ToString();
                        oSheet.Cells[iRow, 19] = myReader["Amt"].ToString();

                        oSheet.Cells[iRow, 20] = myReader["Cap"].ToString();
                        oSheet.Cells[iRow, 21] = myReader["Key"].ToString();








                    }
                    if (myReader.GetValue(8).ToString() != "")
                        area = area + int.Parse(myReader.GetValue(8).ToString());
                    if (myReader.GetValue(19).ToString() != "")
                        amt = amt + double.Parse(myReader.GetValue(19).ToString());


                    iRow++;
                }// end while

                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 7] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 9] = area.ToString();
                oSheet.Cells[iRow + 1, 19] = amt.ToString();



         
   
            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);
            //((Range)oSheet.Cells[row, 21]).EntireRow.Font.Color=Color.Gray;
            oSheet.get_Range(row, row1).Font.Bold = true;


            myReader.Close();
            myReader = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "R1").MergeCells = true;
            oSheet.get_Range("A1", "R1").Font.Bold = true;
            oSheet.get_Range("A1", "R1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


            oRng1 = oSheet.get_Range("A3", "W3");
            oRng1.EntireColumn.AutoFit();



            //oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            //oRng.Borders.Color = Color.LightGray.ToArgb();


            oXL.Visible = true;
            oXL.UserControl = false;
            string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

            oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);
            // Need all following code to clean up and extingush all references!!!
            //oWB.Close(null, null, null);
            //oXL.Workbooks.Close();
            //oXL.Quit();
            //  System.Runtime.InteropServices.Marshal.ReleaseComObject(oRng);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
            //oSheet = null;
            //oWB = null;
            //oXL = null;
            GC.Collect();  // force final cleanup!
            string strMachineName = Request.ServerVariables["SERVER_NAME"];
            // errLabel.Text = "<A href=http://" + strMachineName + "/EWA/" + strFile + ">Download Report</a>";
            //errLabel.Font.Size = 12;

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
            Response.Redirect("report2.aspx");
        }





    }
     * 
     * */



    private void pdf_drillout(string client, string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package, string dateformat, string descid, string ascdesc)
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
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[1].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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

            //-------------------------------------

            int NumColumns = 21;
            PdfPTable datatable = new PdfPTable(NumColumns);

            int NumColumns1 = 20;
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

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[32].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                //datatable.addCell(new Phrase("Pub", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                //datatable.addCell(new Phrase("Depth", font10));
                //datatable.addCell(new Phrase("Width", font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));

                // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10)); ;
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                //datatable.addCell(new Phrase("Area", font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));


                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

                Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


                document.Add(p2);

                datatable.HeaderRows = 1;

                     SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                    ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {

                    NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                    ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc,"","","","","");
                }
                else
                {
                    string procedureName = "report_drillout_report_drillout_p";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = { client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc, "", "", "", "", "" };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                //int i1 = 1;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {

                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SubAg"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));


                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString()));
                    //datatable1.HeaderRows = 1;
                    //}
                    //break;

                    //}
                }


            }
            else
            {

                datatable1.WidthPercentage = 100; // percentage
                datatable1.DefaultCell.BorderWidth = 0;
                datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable1.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;


                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));

                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));

                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
                datatable1.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

                Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


                document.Add(p2);
                datatable1.HeaderRows = 1;

                   SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                    ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                    ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","","","");
                }
                else
                {
                    string procedureName = "report_drillout_report_drillout_p";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = { client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "" };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                //int i1 = 1;





                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    //for (int a = 0; a <= 10; ++a)
                    //{
                    //for (int column = 0; column < ds.Tables[0].Columns.Count; column++)
                    //{
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString(), font11));
                    datatable1.addCell(new Phrase(i1++.ToString(), font11));
                    // datatable1.addCell(new Phrase(i1++.ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    //datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][26].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    //datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));


                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                    // ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row].ItemArray[11].ToString());

                    // datatable1.addCell(new Phrase(ds.Tables[0].Rows[row][13].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable1.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString()));
                    //datatable1.HeaderRows = 1;
                    //}
                    //break;

                    //}
                }

            }





            document.Add(datatable);
            document.Add(datatable1);

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);



            PdfPTable tbltotal = new PdfPTable(12);
            float[] headerwidths = { 11, 13, 21, 21, 6, 10, 10, 6, 10, 19, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));


            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));

            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));


            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));

            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));



            //tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));


            document.Add(tbltotal);
            document.Close();
            //document.PageCount=0;
            //count = i2;
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }



        


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
           

            string check = e.Item.Cells[18].Text;
            string amt = e.Item.Cells[18].Text;


            string check1 = e.Item.Cells[9].Text;
            string amt1 = e.Item.Cells[9].Text;








            if (check != "Net Amt")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[18].Text;
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

        else
        {
            e.Item.Cells[4].Visible = false;

            double sumamt = 0;


            string sno1 = e.Item.Cells[0].Text;
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
            }


            string check = e.Item.Cells[18].Text;
            string amt = e.Item.Cells[18].Text;


            string check1 = e.Item.Cells[9].Text;
            string amt1 = e.Item.Cells[9].Text;








            if (check != "Net Amt")
            {
                if (check != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[18].Text;
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
}

