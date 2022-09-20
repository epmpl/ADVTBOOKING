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
using System.Diagnostics.Design;
using System.Diagnostics;
using System.Data.OracleClient;

public partial class ScheduleRegisterView : System.Web.UI.Page
{
    
    string client = "";
    string pdfName1 = "";
    string agency = "";
    int count1 = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count31 = 0;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    
    string day = "";
    string month = "";
    string year = "";
    string date = "";
   
    string datefrom1 = "";
    string dateto1 = "";
    string publ = "";
    string publication="";
    decimal area = 0;
    decimal paidins = 0;
    string package = "";
    string dateformate = "";
    string fmg = "";
    string sortorder = "";
    string sortvalue = "";
     string publicationcenter="";
     string   adtype="";
    string adtypecode = "";
    string adcategory = "";
     string   edition="";
    string supplement = "";
    string pubcentcode = "";
    string dytbl = "";
    string editiondetail = "";
    string status = "";
    int cont1;
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
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        //dateto = Session["dateto"].ToString();
        //fromdt = Session["fromdate"].ToString();

        if (Request.QueryString["schedule_drillout"] == "yes")
        {
     
            agency = Request.QueryString["agency"].Trim().ToString();
            client = Request.QueryString["client"].Trim().ToString();
            publication = Request.QueryString["publication"].Trim().ToString();
            adtype = Request.QueryString["adtype"].Trim().ToString();
            //payment = Request.QueryString["payment"].Trim().ToString();
            package = Request.QueryString["package"].Trim().ToString();
            destination = Request.QueryString["destination"].Trim().ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
            publicationcenter = Request.QueryString["publicationcenter"].Trim().ToString();
            adcategory = Request.QueryString["adcategory"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();
            //editiondetail = Request.QueryString["editiondetail"].Trim().ToString();
          // supplement = Request.QueryString["supplement"].Trim().ToString();


            if (destination == "3")
            {
                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;

                pdf_drillout(fromdt, dateto, client, Session["compcode"].ToString(), dateformate, package, agency, publication, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }

            else if (destination == "4")
            {
                excel_drillout(fromdt, dateto, client, Session["compcode"].ToString(), dateformate, package, agency, publication);
            }
            else if(destination == "1" || destination == "0")
            {
                drillonscreen(fromdt, dateto,client, Session["compcode"].ToString(),dateformate, package, agency,  publication );
            }
            //(string frmdt, string todate, string client,  string compcode, string dateformate, string package, string agency, string publication )



        }
        else
        {
            //DataSet ds1 = new DataSet();
            //ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();

            publication=Request.QueryString["publicationname"].ToString();
            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            destination = Request.QueryString["destination"].ToString();
            publ = Request.QueryString["publication"].ToString();
            publicationcenter = Request.QueryString["publicationcenter"].Trim().ToString();
            pubcentcode = Request.QueryString["pubcentcode"].Trim().ToString();
            adtype = Request.QueryString["adtype"].Trim().ToString();
            adtypecode = Request.QueryString["adtypecode"].Trim().ToString();
            adcategory = Request.QueryString["adcategory"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();
            editiondetail = Request.QueryString["editiondetail"].Trim().ToString();
            status= Request.QueryString["status"].Trim().ToString();
          //supplement = Request.QueryString["supplement"].Trim().ToString();

            Ajax.Utility.RegisterTypeForAjax(typeof(ScheduleRegisterView));

        if (publ == "0")
        {
            lblpublication.Text = "";
        }
        else
        {
            lblpublication.Text = publication.ToString();

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
        lblpublicationcenter.Text = publicationcenter;
        lbadtype.Text = adtype;
        if (adcategory != "")
        {
            lbadcategory.Text = adcategory;
        }
        else
        {
            lbadcategory.Text = "ALL";
        }
        if (pubcentcode != "0")
        {
            lblpublicationcenter.Text = publicationcenter;
        }
        else
        {
            lblpublicationcenter.Text = "ALL";
        }
            hiddendatefrom.Value = fromdt.ToString();

        if (destination == "1" || destination == "0")
        {

            //onscreen(agency);//, fromdt, dateto, subcat, publication, prod, brand, Session["compcode"].ToString(), Session["dateformat"].ToString());
            onscreen(fromdt, dateto, Session["compcode"].ToString(), publ,status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString()); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (destination == "4")
        {
            //excel(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            excel(fromdt, dateto, Session["compcode"].ToString(), publ, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString()); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        }
        else
            if (destination == "3")
            {
                //pdf(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                pdf(fromdt, dateto, Session["compcode"].ToString(), publ, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString()); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
    }

 }



    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string status, string edition, string pubcentcode, string adtypecode, string adcategory, string dateformat)  //, string supplement)
    {
     
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.onscreenreport(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

        
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
           // ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter, adtype, edition, supplement, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ,status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        }
        if (editiondetail == "0" || editiondetail == "2")
        {
            int cont = ds.Tables[0].Rows.Count;
            //  int cont1 = ds.Tables[1].Rows.Count;
            string tbl = "";
            tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
            //tbl = tbl + "<tr><td class='middle4' width='2px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
            tbl = tbl + "<tr><td class='middle4' width='2px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

            if (hiddenascdesc.Value == "")
            {

                //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle31' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Editions<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'onclick=sorting('Width',this.id)> WH<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle3'   onclick=sorting('Premium',this.id)>Premium<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='midwidth'   onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~34' class='middle3'   onclick=sorting('SplInstruction',this.id)>Instruction<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('Pageno',this.id)>Page</br>No<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td></tr>");
            }
            else if (hiddenascdesc.Value == "asc")
            {
                // tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Editions<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'onclick=sorting('Width',this.id)> WH<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle3'   onclick=sorting('Premium',this.id)>Premium<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='midwidth'   onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~34' class='middle3'   onclick=sorting('SplInstruction',this.id)>Instruction<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('Pageno',this.id)>Page</br>No<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td></tr>");
            }
            else if (hiddenascdesc.Value == "desc")
            {

                // tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'  onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Editions<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~29' class='middle3'onclick=sorting('Width',this.id)> WH<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle3'onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle3'onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~24' class='middle3'onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle3'  onclick=sorting('Premium',this.id)>Premium<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdcard~29' class='midwidth'  onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~31' class='middle3'  onclick=sorting('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~34' class='middle3'  onclick=sorting('SplInstruction',this.id)>Instruction<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('Pageno',this.id)>Page</br>No<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td></tr>");

            }

            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");

                //-------------------------------------------//
                string cioid1 = "";
                string rrr = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                char[] cioid = rrr.ToCharArray();
                int len11 = cioid.Length;

                for (int ch = 0; ch < len11; ch++)
                {

                    if (ch == 0)
                    {
                        cioid1 = cioid1 + cioid[ch];
                    }
                    else if (ch % 9 != 0)
                    {
                        cioid1 = cioid1 + cioid[ch];
                    }
                    else
                    {
                        cioid1 = cioid1 + "</br>" + cioid[ch];
                    }
                }
                //----------------------------------------------------------------///

                tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");

                tbl = tbl + (cioid1 + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
                tbl = tbl + ("<td class='rep_data' width='200px'>");
                //-------------------------------------------//
                string Agency1 = "";
                string Agency11 = "";
                string AA = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                char[] Agency = AA.ToCharArray();
                int len12 = Agency.Length;
                int line1 = 0;

                for (int ch = 0; ch < len12; ch++)
                {
                    if (Agency[ch] != ' ')
                    {
                        Agency1 = Agency1 + Agency[ch];
                    }
                }
                char[] AA1 = Agency1.ToCharArray();

                for (int ch = 0; ((ch < AA1.Length) && (line1 < 2)); ch++)
                {

                    if (ch == 0)
                    {
                        Agency11 = Agency11 + AA1[ch];
                    }
                    else if (ch % 16 != 0)
                    {
                        Agency11 = Agency11 + AA1[ch];
                    }
                    else
                    {

                        line1 = line1 + 1;
                        if (line1 != 2)
                        {
                            Agency11 = Agency11 + "</br>" + AA1[ch];
                        }

                    }
                }
                //---------------------------------------------//
                tbl = tbl + (Agency11 + "</td>");
                tbl = tbl + ("<td class='rep_data'>");

                string Client1 = "";
                string Client11 = "";
                string BB = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                char[] Client = BB.ToCharArray();
                int len13 = Client.Length;
                int line2 = 0;

                for (int ch = 0; ch < len13; ch++)
                {
                    if (Client[ch] != ' ')
                    {
                        Client1 = Client1 + Client[ch];
                    }
                }
                char[] BB1 = Client1.ToCharArray();

                for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                {

                    if (ch == 0)
                    {
                        Client11 = Client11 + BB1[ch];
                    }
                    else if (ch % 16 != 0)
                    {
                        Client11 = Client11 + BB1[ch];
                    }
                    else
                    {

                        line2 = line2 + 1;
                        if (line2 != 2)
                        {
                            Client11 = Client11 + "</br>" + BB1[ch];
                        }

                    }
                }
                //---------------------------------------------//
                // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                tbl = tbl + (Client11 + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='right'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='right'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

                tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

                tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "" + ds.Tables[0].Rows[i]["PosPremium"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["PosPremium"] + "</td>");
                //tbl = tbl + ("<td class='rep_data'>");
                // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");
                tbl = tbl + (ds.Tables[0].Rows[i]["InsertStatus"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Spl Instruction"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Caption"] + "</br>" + ds.Tables[0].Rows[i]["Key_no"] + "</td>");
                //tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["Key_no"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Pageno"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Adcat"] + "</br>" + ds.Tables[0].Rows[i]["AdSubcat"] + "</td>");

                //tbl = tbl + ("<td class='rep_data'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");

                if (ds.Tables[0].Rows[i]["Paidins"].ToString() != "")
                    paidins = paidins + Convert.ToInt32(ds.Tables[0].Rows[i]["Paidins"]);

                if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["ratecd"])
                    count1++;
                if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Adcat"].ToString())
                    count2++;
                // count2 = count2++;
                if (ds.Tables[0].Rows[i]["Uom"].ToString() != "")
                {
                    if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[i]["Uom"].ToString())
                        count3++;
                    else
                        count31++;
                }
                tbl = tbl + "</tr>";
            }
            tbl = tbl + ("<tr >");
            tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
            tblgrid.InnerHtml = tbl;
            // ----Ad by rinki----
            string tbl1 = "";
            tbl1 = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
            tbl1 = tbl1 + ("<tr><td class='middle31'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle3'>TotalArea:" + area.ToString() + "</td><td class='middle31'>Line/Word:" + count3.ToString() + "</td><td id='tdag~3' class='middle3'>Size:" + count31.ToString() + "</td><td id='tdcli~4' class='middle3'>Paid :" + paidins.ToString() + "</td><td id='tdpac~5' class='middle3'>Fmg:" + count1.ToString() + "</td><td id='tdro~29' class='middle3'>HouseAd:" + count2.ToString() + "</td><td id='tdro~26' class='middle3'>Date:" + date.ToString() + "</td><td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td></tr>");
            tblgrid1.InnerHtml = tbl1;
        }
        else
        {
                int cont = ds.Tables[0].Rows.Count;
                 cont1 = ds.Tables[1].Rows.Count;
                string tbl = "";
                tbl = "<table width='100%'align='left' cellpadding='4' cellspacing='0' border='0'>";
                //tbl = tbl + "<tr><td class='middle4' width='2px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
                tbl = tbl + "<tr><td class='middle4' width='2px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

                if (hiddenascdesc.Value == "")
                {

                    //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
                    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle31' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Editions<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'onclick=sorting('Width',this.id)> WH<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle3'   onclick=sorting('Premium',this.id)>Premium<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='midwidth'   onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~34' class='middle3'   onclick=sorting('SplInstruction',this.id)>Instruction<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('Pageno',this.id)>Page</br>No<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td>");
                }
                else if (hiddenascdesc.Value == "asc")
                {
                    // tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
                    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Editions<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'onclick=sorting('Width',this.id)> WH<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle3'   onclick=sorting('Premium',this.id)>Premium<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdcard~29' class='midwidth'   onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:block;'><img id='imgcardup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~31' class='middle3'   onclick=sorting('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~34' class='middle3'   onclick=sorting('SplInstruction',this.id)>Instruction<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('Pageno',this.id)>Page</br>No<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td></tr>");
                }
                else if (hiddenascdesc.Value == "desc")
                {

                    // tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
                    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'  onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Editions<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~29' class='middle3'onclick=sorting('Width',this.id)> WH<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle3'onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle3'onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~24' class='middle3'onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle3'  onclick=sorting('Premium',this.id)>Premium<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdcard~29' class='midwidth'  onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~31' class='middle3'  onclick=sorting('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Status',this.id)>Status<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~34' class='middle3'  onclick=sorting('SplInstruction',this.id)>Instruction<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle3'   onclick=sorting('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('Pageno',this.id)>Page</br>No<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td></tr>");

                }

               // string editionchk = ds.Tables[0].Rows[i]["edition"];
                int edi;
               
                for (edi = 0; edi < cont1; edi++)
                {
                    tbl = tbl + ("<td class='edidetail'>");
                    tbl = tbl + (ds.Tables[1].Rows[edi]["Editions"] + "</td>");
                }
               tbl = tbl + ("</tr>");
                int i1 = 1;

                for (int i = 0; i <= cont - 1; i++)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (i1++.ToString() + "</td>");

                    //-------------------------------------------//
                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    char[] cioid = rrr.ToCharArray();
                    int len11 = cioid.Length;

                    for (int ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            cioid1 = cioid1 + cioid[ch];
                        }
                        else if (ch % 9 != 0)
                        {
                            cioid1 = cioid1 + cioid[ch];
                        }
                        else
                        {
                            cioid1 = cioid1 + "</br>" + cioid[ch];
                        }
                    }
                    //----------------------------------------------------------------///

                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (cioid1 + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data' width='200px'>");
                    //-------------------------------------------//
                    string Agency1 = "";
                    string Agency11 = "";
                    string AA = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    char[] Agency = AA.ToCharArray();
                    int len12 = Agency.Length;
                    int line1 = 0;

                    for (int ch = 0; ch < len12; ch++)
                    {
                        if (Agency[ch] != ' ')
                        {
                            Agency1 = Agency1 + Agency[ch];
                        }
                    }
                    char[] AA1 = Agency1.ToCharArray();

                    for (int ch = 0; ((ch < AA1.Length) && (line1 < 2)); ch++)
                    {

                        if (ch == 0)
                        {
                            Agency11 = Agency11 + AA1[ch];
                        }
                        else if (ch % 16 != 0)
                        {
                            Agency11 = Agency11 + AA1[ch];
                        }
                        else
                        {

                            line1 = line1 + 1;
                            if (line1 != 2)
                            {
                                Agency11 = Agency11 + "</br>" + AA1[ch];
                            }

                        }
                    }
                    //---------------------------------------------//
                    tbl = tbl + (Agency11 + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data'>");
                    string Client1 = "";
                    string Client11 = "";
                    string BB = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    char[] Client = BB.ToCharArray();
                    int len13 = Client.Length;
                    int line2 = 0;

                    for (int ch = 0; ch < len13; ch++)
                    {
                        if (Client[ch] != ' ')
                        {
                            Client1 = Client1 + Client[ch];
                        }
                    }
                    char[] BB1 = Client1.ToCharArray();

                    for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                    {
                        if (ch == 0)
                        {
                            Client11 = Client11 + BB1[ch];
                        }
                        else if (ch % 16 != 0)
                        {
                            Client11 = Client11 + BB1[ch];
                        }
                        else
                        {
                            line2 = line2 + 1;
                            if (line2 != 2)
                            {
                                Client11 = Client11 + "</br>" + BB1[ch];
                            }
                        }
                    }
                    tbl = tbl + (Client11 + "</td>");
                    //---------------------------------------------//
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");
                   
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

                    if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                        area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "" + ds.Tables[0].Rows[i]["PosPremium"] + "</td>");
                   
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["InsertStatus"] + "</td>");
                   
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Spl Instruction"] + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Caption"] + "</br>" + ds.Tables[0].Rows[i]["Key_no"] + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Pageno"] + "</td>");
                    
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Adcat"] + "</br>" + ds.Tables[0].Rows[i]["AdSubcat"] + "</td>");
                    for (int edi1 = 0; edi1 < cont1; edi1++)
                    {
                        if (ds.Tables[0].Rows[i]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                        {
                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
                        }
                        else 
                        {
                            tbl = tbl + ("<td class='rep_data'>");
                        }
                    }
                    if (ds.Tables[0].Rows[i]["Paidins"].ToString() != "")
                        paidins = paidins + Convert.ToInt32(ds.Tables[0].Rows[i]["Paidins"]);

                    if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["ratecd"])
                        count1++;
                    if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Adcat"].ToString())
                        count2++;
                    
                    if (ds.Tables[0].Rows[i]["Uom"].ToString() != "")
                    {
                        if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[i]["Uom"].ToString())
                            count3++;
                        else
                            count31++;
                    }
                  
                    tbl = tbl + "</tr>";
                }
                tbl = tbl + ("<tr >");
                tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                tblgrid.InnerHtml = tbl;
                // ----Ad by rinki----
                string tbl1 = "";
                tbl1 = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
                tbl1 = tbl1 + ("<tr><td class='middle31' colspan='2'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle3' colspan='2'>TotalArea:" + area.ToString() + "</td><td class='middle31' colspan='2'>Line/Word:" + count3.ToString() + "</td><td id='tdag~3' class='middle3' colspan='1'>Size:" + count31.ToString() + "</td><td id='tdcli~4' class='middle3' colspan='2'>Paid :" + paidins.ToString() + "</td><td id='tdpac~5' class='middle3' colspan='2'>Fmg:" + count1.ToString() + "</td><td id='tdro~29' class='middle3'>HouseAd:" + count2.ToString() + "</td><td id='tdro~26' class='middle3'>Date:" + date.ToString() + "</td><td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td></tr></table>");
                tblgrid1.InnerHtml = tbl1;
            }
    }





    private void excel(string fromdt, string dateto,string compcode,string publication, string edition,string publicationcenter,string adtype,string adcategory, string dateformat)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //NewAdbooking.classesoracle.classnew obj = new NewAdbooking.classesoracle.classnew();
        //ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, edition, publicationcenter, adtype, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            // ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter, adtype, edition, supplement, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ,status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        }

        int cont = ds.Tables[0].Rows.Count;
        for (int i = 0; i < cont - 1; i++)
        {

            if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["ratecd"])
                count1++;
            if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Adcat"].ToString())
                count2++;
            // count2 = count2++;
            if (ds.Tables[0].Rows[i]["Uom"].ToString() != "")
            {
                if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[i]["Uom"].ToString())
                    count3++;
                else
                    count31++;
            }
            if (ds.Tables[0].Rows[i]["Paidins"].ToString() != "")
                paidins = paidins + Convert.ToInt32(ds.Tables[0].Rows[i]["Paidins"]);
        }

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        //Response.ContentEncoding = Encoding.UTF8;
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
        hw.Write("<p align=center>Advance Display Schedule Report");
        // hw.Write("<ul><li>test</li></ul>");
        //hw.Write(comm2);
        hw.WriteBreak();
        //DataGrid1.in
        DataGrid1.RenderControl(hw);
        double arr = comm2 / areanew;
        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds :" + sno11 + "</td><td colspan=\"2\">TotalArea:" + areanew + "</td><td>Line/Word::" + count3 + "</td><td >Size:" + count31 + "</td><td>Paid:" + paidins + "</td><td colspan=\"5\">Fmg:" + count1 + "</td><td colspan=\"4\">HouseAds:" + count2 + "</td><td colspan=\"4\">Pages:" + 1 + "-" + sno11 + "</td></table>")); //align=\"center\" colspan=\"7\"
        // tbl1 = tbl1 + ("<tr><td class='middle31'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle3'>TotalArea:" + area.ToString() + "</td><td class='middle31'>Line/Word:" + count3.ToString() + "</td><td id='tdag~3' class='middle3'>Size:" + count31.ToString() + "</td><td id='tdcli~4' class='middle3'>Paid :" + paidins.ToString() + "</td><td id='tdpac~5' class='middle3'>Fmg:" + count1.ToString() + "</td><td id='tdro~29' class='middle3'>HouseAd:" + count2.ToString() + "</td><td id='tdro~26' class='middle3'>Date:" + date.ToString() + "</td><td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td></tr>");
        //Response.Write(sw.ToString().Replace("</table>", "<tr><td align=\"center\" colspan=\"7\">TOTAL</td><td>50</td><td colspan=\"7\">&nbsp;</td><td>"+comm2+"</td><td></td><td></td></table>"));
        Response.Flush();
        Response.End(); 




       
        /*
        string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        // Excel.Range oRng1;

        try
        {


            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            oRng = oSheet.get_Range("A3", "Y3");
            //oSheet.PageSetup.CenterHeader = "GAURAV";
            //oXL.Visible = true;
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            
            OracleDataReader myorclReader = null;
           
            
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                SqlDataReader myReader = null;

                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                myReader = obj.displayexcelfile(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());

                //else
                //{

                //    NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                //    myorclReader = obj.displayexcelfile(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());

                //}
                int iRow = 4;  //2

                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));

                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[5].ToString();


                for (int j = 0; j < myReader.FieldCount; j++)
                {


                    //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();

                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();

                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[35].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[36].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[41].ToString();


                }

                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;


                oRng = oSheet.get_Range("A3", "Y3");
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
                        oSheet.Cells[iRow, 6] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["Width"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["Depth"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["PagePremium"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["PosPremium"].ToString();
                        oSheet.Cells[iRow, 13] = myReader["CardRate"].ToString();
                        oSheet.Cells[iRow, 14] = myReader["AgreedRate"].ToString();
                        oSheet.Cells[iRow, 15] = myReader["Spl Instruction"].ToString();


                    }

                    if (myReader["Area"].ToString() != "")
                        area = area + int.Parse(myReader["Area"].ToString());





                    iRow++;



                }
                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 8] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 9] = area.ToString();



                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;



                myReader.Close();
                myReader = null;
                oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "P1").MergeCells = true;
                oSheet.get_Range("A1", "P1").Font.Bold = true;
                oSheet.get_Range("A1", "P1").Font.Size = 10;
                oSheet.get_Range("A3", "Y3").Font.Bold = true;
                oSheet.get_Range("A3", "Y3").Font.Size = 8;

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
                string strMachineName = Request.ServerVariables["umesh"];

            }

            else
            {
                OracleDataReader myReader = null;
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                myReader = obj.displayexcelfile(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter,  adtype, edition,  supplement);

                //else
                //{

                //    NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                //    myorclReader = obj.displayexcelfile(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());

                //}
                int iRow = 4;  //2

                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/report1.xml"));

                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[5].ToString();


                for (int j = 0; j < myReader.FieldCount; j++)
                {


                    //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();

                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();

                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[35].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[36].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[41].ToString();


                }

                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;


                oRng = oSheet.get_Range("A3", "Y3");
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
                        oSheet.Cells[iRow, 6] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["Width"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["Depth"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["PagePremium"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["PosPremium"].ToString();
                        oSheet.Cells[iRow, 13] = myReader["CardRate"].ToString();
                        oSheet.Cells[iRow, 14] = myReader["AgreedRate"].ToString();
                        oSheet.Cells[iRow, 15] = myReader["Spl Instruction"].ToString();


                    }

                    if (myReader["Area"].ToString() != "")
                        area = area + int.Parse(myReader["Area"].ToString());





                    iRow++;



                }
                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 8] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 9] = area.ToString();



                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;



                myReader.Close();
                myReader = null;
                oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "P1").MergeCells = true;
                oSheet.get_Range("A1", "P1").Font.Bold = true;
                oSheet.get_Range("A1", "P1").Font.Size = 10;
                oSheet.get_Range("A3", "Y3").Font.Bold = true;
                oSheet.get_Range("A3", "Y3").Font.Size = 8;

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
                string strMachineName = Request.ServerVariables["umesh"];
            }


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
            Response.Redirect("Schedulereportnew.aspx");
        }
         * */
    }





    private void pdf(string fromdt, string dateto, string compcode, string publication, string edition, string publicationcenter, string adtype, string adcategory, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        // btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

        //--------------------for page numbering---------------------------------------------

        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("01",true));
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 21;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[5].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
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
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 3; i++)
            {
                document.Add(tbl1);
            }
            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 18, 18, 20, 16, 18, 12, 14, 18, 18, 17, 15, 14, 15, 20 ,20,15,15,12,21,21}; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));



            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            //datatable.addCell(new Phrase("City"));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));


            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[41].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[60].ToString(), font10));


            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);


            //------------------//-------------------------------------------------------------------       


            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();

                //ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(),publicationcenter ,adtype ,edition ,supplement , hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else
            {
                NewAdbooking.classesoracle.classnew obj = new NewAdbooking.classesoracle.classnew();

                ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, edition, publicationcenter, adtype, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            }
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Spl Instruction"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["InsertStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Caption"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key_no"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Pageno"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adcat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdSubcat"].ToString(), font11));


                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(7);
            float[] headerwidths5 = { 11, 13, 14, 14, 10, 8, 12 }; // percentage
            tbltotal.setWidths(headerwidths5);
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
            //tbltotal.addCell(new Phrase(" ", font11));

            //   tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));

            document.Add(tbltotal);
            document.Close();
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }


    //=========================================================================================

    private void pdf1(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        //string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

        //--------------------for page numbering---------------------------------------------

        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("01",true));
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 15;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[5].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
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
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 3; i++)
            {
                document.Add(tbl1);
            }
            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 13, 15, 20, 16, 12, 12, 14, 18, 18, 17, 15, 14, 15, 15 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));



            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            //datatable.addCell(new Phrase("City"));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));


            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[41].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);


            //------------------//-------------------------------------------------------------------       

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.pdffile(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            ////ds = obj.displayonscreenreport(agency, client, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), regionname, subcat, subsubcat, product, brand, varient);
            // by rinki ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), hiddencioid.Value.Trim(),publicationcenter ,adtype ,edition ,supplement , hiddenascdesc.Value.Trim());
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Spl Instruction"].ToString(), font11));


                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(7);
            float[] headerwidths5 = { 11, 13, 14, 14, 10, 8, 12 }; // percentage
            tbltotal.setWidths(headerwidths5);
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
            //tbltotal.addCell(new Phrase(" ", font11));

            //   tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));

            document.Add(tbltotal);
            document.Close();


            //Response.Redirect( pdfName1);

            // btnprint.Attributes.Add("onclick", "javascript:print(pdfName1);");

            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
            //proc.StartInfo.Arguments = @"/p /hServer.MapPath(pdfName1)";
            proc.StartInfo.Arguments = @"/p /h" + Server.MapPath(pdfName1);

            //proc.StartInfo.Arguments = @"/p /h C:\Inetpub\wwwroot\NewAdbooking\3719138.pdf";

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




        }

        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }

    private void drillonscreen(string fromdt, string dateto, string client, string compcode, string dateformate, string package, string agency, string publication)
   //(fromdt, dateto,client, Session["compcode"].ToString(),dateformate, package, agency,  publication );
    {

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.onscreenreport(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.schedule_drillout(fromdt, dateto, client, Session["compcode"].ToString(), Session["dateformat"].ToString(), package, agency, publication, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
          //  NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
          //  ds = obj.schedule_drillout(fromdt, dateto, client, Session["compcode"].ToString(), Session["dateformat"].ToString(), package, agency, publication, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        }
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        //tbl = tbl + ("<tr><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Pub</td><td class='middle3'>Package</td><td class='middle3'>H</td><td class='middle3'>W</td><td class='middle3'>AdArea</td><td class='middle3'>Hue</td><td class='middle3'>PagePost</td><td class='middle3'>Ins.No</td><td class='middle3'>Ins.Date</td><td class='middle3'>BookDate</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>RateCode</td><td class='middle3'>CardRate</td><td class='middle3'>Amt</td><td class='middle3'>Disc</td><td class='middle3'>Status</td><td class='middle3'>MatStatus</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Package</td><td class='middle3'>Width</td><td class='middle3'>Depth</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>PagePremium</td><td class='middle3'>PosPremium</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>SplInstruction</td></tr>");

        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Width</td><td class='middle31'>Depth</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td><td class='middle31'>CardRate</td><td class='middle31'>AggRate</td><td class='middle31'>SplInstruction</td></tr>");
        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Width</td><td class='middle31'>Depth</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td><td class='middle31'>CardRate</td><td class='middle31'>AggRate</td><td class='middle31'>SplInstruction</td></tr>");
        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Width</td><td class='middle31'>Depth</td><td class='middle31'>Area</td><td class='middle31'>Hue</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td><td class='middle31'>CardRate</td><td class='middle31'>AggRate</td><td class='middle31'>SplInstruction</td></tr>");

        }
        //datagrid2.DataSource = ds;
        // DropDownList1.DataTextField = ds.ToString();
        //DropDownList1.DataValueField = ds.ToString();
        // datagrid2.DataBind();  
        int i1 = 1;
        //int contc = 15;

        //int breaker = (i1 / 38);



        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            //if (ds.Tables[0].Rows[i].ItemArray[3].ToString() != "")
            //    area = area + float.Parse(ds.Tables[0].Rows[i].ItemArray[9].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PosPremium"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Spl Instruction"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[28].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[30].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[25].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[23].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");

            tbl = tbl + "</tr>";

            //    break;
            //}
            //  tbl = tbl + "</tr>";


        }


        tbl = tbl + ("<tr >");
        //tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");



        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("</td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString());
        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;



    }

    private void excel_drillout(string fromdt, string dateto, string client, string compcode, string dateformate, string package, string agency, string publication)
    {
        string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        // Excel.Range oRng1;

        try
        {


            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            oRng = oSheet.get_Range("A3", "Y3");
            //oSheet.PageSetup.CenterHeader = "GAURAV";
            //oXL.Visible = true;
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));


            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //myReader = obj.excelfile(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            //// myReader = obj.displayexcelfile(agency, client, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), regionname, subcat, subsubcat, product, brand, varient);
            myReader = obj.scheduleexcel_drillout(fromdt, dateto, client, compcode, "dd/mm/yyyy", package, agency, publication);
            //DataSet dst=clsbook.spfun();
            int iRow = 4;  //2

            oSheet.PageSetup.CenterFooter = "&P";

            // while(myReader.Read())
            // {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();

            oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[5].ToString();


            for (int j = 0; j < myReader.FieldCount; j++)
            {


                //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();

                oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();

                oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[35].ToString();
                oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[36].ToString();
                oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[21].ToString();
                oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[41].ToString();
                //oSheet.Cells[3, 14] = myReader.GetName(28).ToString();
                //oSheet.Cells[3, 15] = myReader.GetName(30).ToString();
                //oSheet.Cells[3, 16] = myReader.GetName(25).ToString();
                //oSheet.Cells[3, 17] = myReader.GetName(23).ToString();
                //oSheet.Cells[3, 18] = myReader.GetName(24).ToString();
                //oSheet.DisplayPageBreaks=

            }
            //   }
            oSheet.Cells.Font.Name = "verdana";
            oSheet.Cells.Font.Size = 7;


            oRng = oSheet.get_Range("A3", "Y3");
            oRng.EntireColumn.AutoFit();
            //oRng.Columns.AutoFit(oSheet, 3);
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

                    oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();
                    oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                    oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                    oSheet.Cells[iRow, 5] = myReader["Client"].ToString();
                    //oSheet.Cells[iRow, 5] = myReader.GetValue(4).ToString();
                    oSheet.Cells[iRow, 6] = myReader["Package"].ToString();
                    oSheet.Cells[iRow, 7] = myReader["Width"].ToString();
                    oSheet.Cells[iRow, 8] = myReader["Depth"].ToString();
                    oSheet.Cells[iRow, 9] = myReader["Area"].ToString();
                    oSheet.Cells[iRow, 10] = myReader["Hue"].ToString();
                    oSheet.Cells[iRow, 11] = myReader["PagePremium"].ToString();
                    oSheet.Cells[iRow, 12] = myReader["PosPremium"].ToString();
                    oSheet.Cells[iRow, 13] = myReader["CardRate"].ToString();
                    oSheet.Cells[iRow, 14] = myReader["AgreedRate"].ToString();
                    oSheet.Cells[iRow, 15] = myReader["Spl Instruction"].ToString();
                    //oSheet.Cells[iRow, 14] = myReader.GetValue(28).ToString();
                    ////oSheet.Cells[iRow, 15] = myReader.GetValue(30).ToString();
                    //oSheet.Cells[iRow, 16] = myReader.GetValue(25).ToString();
                    //oSheet.Cells[iRow, 17] = myReader.GetValue(23).ToString();
                    //oSheet.Cells[iRow, 18] = myReader.GetValue(24).ToString();
                    //oSheet.Cells[iRow, 1] = myReader.GetValue(0).ToString();

                    //oSheet.PageSetup.CenterHeader = oRng.ToString();
                    //oXL.Visible = true;
                    // mnWidth = 6;

                }

                if (myReader["Area"].ToString() != "")
                    area = area + int.Parse(myReader["Area"].ToString());





                iRow++;



            }
            oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
            oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
            oSheet.Cells[iRow + 1, 8] = "Totals :".ToString();
            oSheet.Cells[iRow + 1, 9] = area.ToString();



            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);

            oSheet.get_Range(row, row1).Font.Bold = true;



            myReader.Close();
            myReader = null;
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "P1").MergeCells = true;
            oSheet.get_Range("A1", "P1").Font.Bold = true;
            oSheet.get_Range("A1", "P1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;

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
            string strMachineName = Request.ServerVariables["umesh"];


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
            Response.Redirect("ScheduleRegister.aspx");
        }
    }






    private void pdf_drillout(string fromdt, string dateto, string client, string compcode, string dateformate, string package, string agency, string publication, string descid, string ascdesc)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        // btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

        //--------------------for page numbering---------------------------------------------

        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("01",true));
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 15;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[5].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
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
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 3; i++)
            {
                document.Add(tbl1);
            }
            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 13, 15, 20, 16, 12, 12, 14, 18, 18, 17, 15, 14, 15, 15 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));



            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            //datatable.addCell(new Phrase("City"));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));


            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[41].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);


            //------------------//-------------------------------------------------------------------       

            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.pdffile(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            ////ds = obj.displayonscreenreport(agency, client, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), regionname, subcat, subsubcat, product, brand, varient);
            ds = obj.schedule_drillout(fromdt, dateto, client, Session["compcode"].ToString(), Session["dateformat"].ToString(), package, agency, publication,descid,ascdesc);
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Spl Instruction"].ToString(), font11));


                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(7);
            float[] headerwidths5 = { 11, 13, 14, 14, 10, 8, 12 }; // percentage
            tbltotal.setWidths(headerwidths5);
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
            //tbltotal.addCell(new Phrase(" ", font11));

            //   tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));

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
        publication = Request.QueryString["publicationname"].ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        destination = Request.QueryString["destination"].ToString();
        publ = Request.QueryString["publication"].ToString();
        publicationcenter = Request.QueryString["publicationcenter"].Trim().ToString();
        pubcentcode = Request.QueryString["pubcentcode"].Trim().ToString();
        adtype = Request.QueryString["adtype"].Trim().ToString();
        adtypecode = Request.QueryString["adtypecode"].Trim().ToString();
        adcategory = Request.QueryString["adcategory"].Trim().ToString();
        edition = Request.QueryString["edition"].Trim().ToString();
        editiondetail = Request.QueryString["editiondetail"].Trim().ToString();
        status = Request.QueryString["status"].Trim().ToString();
        Response.Redirect("PrintScheduleRegister.aspx?destination=" + destination + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&publicationname=" + publication + "&publicationcenter=" + publicationcenter + "&edition=" + edition + "&pubcentcode=" + pubcentcode + "&adtype=" + adtype + "&adtypecode=" + adtypecode + "&adcategory=" + adcategory + "&editiondetail=" + editiondetail + "&status=" + status);
        // pdf1(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());
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
        
        string check1 = e.Item.Cells[8].Text;
        string amt1 = e.Item.Cells[8].Text;

        //area
        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {
                string arean = e.Item.Cells[8].Text;
                areanew = areanew + Convert.ToDouble(arean);
            }
        }
    }
}