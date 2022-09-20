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
using System.Text;
public partial class ScheduleRegisterView : System.Web.UI.Page
{
    int notot = 0;
    int cnt1 = 0, cnt2 = 0, cnt4 = 0, cnt5 = 0;
    decimal cnt3 = 0;
    int dd2;
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

    string datefrom1 = "", adcatname = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    decimal paidins = 0;
    string package = "";
    string dateformate = "";
    string fmg = "";
    string sortorder = "";
    string sortvalue = "";
    string publicationcenter = "";
    string adtype = "";
    string adtypecode = "";
    string adcategory = "";
    string edition = "";
    string supplement = "";
    string pubcentcode = "";
    string dytbl = "";
    string editiondetail = "";
    string status = "";
    int cont1;
    //string fromdt = "";
    //string dateto="";
    int totunaudit = 0, totaudit = 0, temptotunaudit = 0, temptotaudit = 0;
    string branch_code = "", branch_name = "",ro_statuscod="",ro_statusnam="";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    string sortfield = "";
    string sorting = "", supplementcode = "", package11name = "", ciod="";
    double sqcm = 0, colcm = 0, other = 0, totrol = 0, totcd = 0, totcc = 0, areaset = 0;

    double tempsqcm = 0, tempcolcm = 0, tempother = 0, temptotrol = 0, temptotcd = 0, temptotcc = 0, tempareaset = 0;

    string package11 = "", pkgdetail = "";
    DataSet ds;
    string editionname = "";
    string name1 = "", name2 = "", name3 = "", hdnasc="";
    string chk_excel = "";

    string edipre, edichange;
    string section;

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

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }

   
        string[] prm_Array = new string[44];


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();


      



        destination = Request.QueryString["destination"].ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        publ = Request.QueryString["publication"].ToString();
        publication = Request.QueryString["publicationname"].ToString();
        edition = Request.QueryString["edition"].Trim().ToString();
        editionname = Request.QueryString["editionname"].Trim().ToString();
        publicationcenter = Request.QueryString["publicationcenter"].Trim().ToString();
        pubcentcode = Request.QueryString["pubcentcode"].Trim().ToString();
        adtype = Request.QueryString["adtype"].Trim().ToString();
        adtypecode = Request.QueryString["adtypecode"].Trim().ToString();
        adcategory = Request.QueryString["adcategory"].Trim().ToString();
        editiondetail = Request.QueryString["editiondetail"].Trim().ToString();
        status =Request.QueryString["status"].Trim().ToString();
        adcatname = Request.QueryString["adcatname"].Trim().ToString();
        supplementcode = Request.QueryString["supplementcode"].Trim().ToString();
        package11 = Request.QueryString["package11"].Trim().ToString();
        pkgdetail = Request.QueryString["pkgdetail"].Trim().ToString();
        package11name = Request.QueryString["package11name"].Trim().ToString();
        chk_excel = Request.QueryString["chk_excel"].Trim().ToString();
        branch_code = Request.QueryString["branch_code"].Trim().ToString();
        branch_name = Request.QueryString["branch_name"].Trim().ToString();
        hdnasc = Request.QueryString["hdnasc"].Trim().ToString();
        ciod = Request.QueryString["ciod"].Trim().ToString();
        ro_statuscod = Request.QueryString["rostatus_code"].Trim().ToString();
        ro_statusnam = Request.QueryString["rostatus"].Trim().ToString();

        section = Request.QueryString["designer"].Trim().ToString();

       // DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdt = DMYToMDY(fromdt);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdt = YMDToMDY(fromdt);
                dateto = YMDToMDY(dateto);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), ciod, hdnasc, supplementcode, package11, pkgdetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod, section);

        }
        else
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), ciod, hdnasc, supplementcode, package11, pkgdetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod);
            // ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, dpedition.SelectedValue, dppubcent.SelectedValue, dpaddtype.SelectedValue, dpadcatgory.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(ScheduleRegisterView));

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(ScheduleRegisterView), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
           // ScriptManager.RegisterClientScriptBlock(this, typeof(ScheduleRegisterView), "sa", "Window.close();", true);
            return;
        }
        if (edition == "")
            edition = "0";


        if (pkgdetail == "0")
        {
            pubnamelb.Text = "PUBLICATION:";
            if (publ == "0")
            {
                lblpublication.Text = "";
            }
            else
            {
                lblpublication.Text = publication.ToString();

            }
        }
        else
        {
            pubnamelb.Text = "PACKAGE:";
            if (package11name == "--Select Package--")
            {
                lblpublication.Text = "All";
            }
            else
            {
                lblpublication.Text = package11name.ToString();
            }
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

        lblfrom.Text = fromdt;
        datefrom1 = fromdt;
        lblto.Text = dateto;
        dateto1 = dateto;




        lbadtype.Text = adtype;
        if (adcategory != "")
        {
            lbadcategory.Text = adcatname;
        }
        else
        {
            lbadcategory.Text = "ALL";
        }
        if (edition != "" && edition != "0")
            lbedition.Text = editionname;
        else
            lbedition.Text = "ALL";

        lblrostatus.Text = ro_statusnam;

        if (pubcentcode != "0")
        {
            lblpublicationcenter.Text = publicationcenter;
        }
        else
        {
            lblpublicationcenter.Text = "ALL";
        }
        hiddendatefrom.Value = fromdt.ToString();
        if (!IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {

                //onscreen(agency);//, fromdt, dateto, subcat, publication, prod, brand, Session["compcode"].ToString(), Session["dateformat"].ToString());
                onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                //excel(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                excel(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            }
            else
                if (destination == "3")
                {
                    //pdf(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                    pdf(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
                }
        }

        else if (hiddenascdesc.Value != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                string from_date1 = "";
                string to_date1 = "";
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    from_date1 = DMYToMDY(fromdt);
                    to_date1 = DMYToMDY(dateto);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    from_date1 = YMDToMDY(fromdt);
                    to_date1 = YMDToMDY(dateto);
                }
                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                //ds = obj.displayonscreenreport(from_date1, to_date1, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, dpedition.SelectedValue, dppubcent.SelectedValue, dpaddtype.SelectedValue, dpadcatgory.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), hsuppliment, drppackage.SelectedValue, dpedidetail.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
                ds = obj.displayonscreenreport(from_date1, to_date1, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package11, editiondetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod, section);

            }
            else
            {
                NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
                //ds = obj.displayonscreenreport(from_date1, to_date1, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, dpedition.SelectedValue, dppubcent.SelectedValue, dpaddtype.SelectedValue, dpadcatgory.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), hsuppliment, drppackage.SelectedValue, dpedidetail.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
                ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package11, editiondetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod);

            }

            Session["schedulerep"] = ds;
            onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
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



    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string status, string edition, string pubcentcode, string adtypecode, string adcategory, string dateformat, string package111)  //, string supplement)
    {

        sortfield = hiddencioid.Value.Trim();
        sorting = hiddenascdesc.Value.Trim();

        if (pkgdetail == "0")//no package
        {
            edipre = "" + ds.Tables[0].Rows[1]["edition"];
            edichange = "" + ds.Tables[0].Rows[1]["edition"];
        }

        SqlDataAdapter da = new SqlDataAdapter();
        // DataSet ds = new DataSet();
        // //ds = obj.onscreenreport(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());


        // //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        // //{
        // //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        // //    ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode);

        // //}
        // //else
        // //{
        //     NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //     ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package111,editiondetail);

        //// }
        cmpnyname.Text = ds.Tables[4].Rows[0].ItemArray[1].ToString();
        string tab4date = ds.Tables[4].Rows[0].ItemArray[0].ToString();

        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];

        if (editiondetail == "0" || editiondetail == "2")
        {
            int cont = ds.Tables[0].Rows.Count;


            // string tbl = "";
            StringBuilder tbl = new StringBuilder();
            tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>");
            if (edition != "0")
                tbl.Append("<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>");
            else
            {
                if (pkgdetail == "0")//no package
                {
                    tbl.Append("<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>");

                }
                else
                {
                    tbl.Append("<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>");

                }
            }


            if (edition != "0")
            {
                if (hiddenascdesc.Value == "")
                {

                    tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle31' width='8%' onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~edi' class='middle31'  width='5%' onclick=sorting('edition',this.id)>Edition<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31' width='5%' onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31'  width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~31' class='middle31' width='5%' onclick=sorting1('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle31'  width='5%' onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                }
                else if (hiddenascdesc.Value == "asc")
                {
                    tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle31' width='8%' onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~edi' class='middle31'  width='5%' onclick=sorting('edition',this.id)>Edition<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~31' class='middle31'  width='5%' onclick=sorting1('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle31' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                }
                else if (hiddenascdesc.Value == "desc")
                {

                    tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%'  onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle31' width='8%' onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~edi' class='middle31'  width='5%' onclick=sorting('edition',this.id)>Edition<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdRO~1' class='middle31'  width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle31' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle31' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~31' class='middle31'  width='5%' onclick=sorting1('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~38' class='middle31' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");//<td id='tdcard~29' class='midwidth'   onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td>

                }
            }
            else
            {
                if (pkgdetail == "0")//no package
                {
                    if (hiddenascdesc.Value == "")
                    {
                        tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~edi' class='middle31'  width='5%' onclick=sorting('edition',this.id)>Edition<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31' width='5%' onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31'  width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31'  width='5%' onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                    }
                    else if (hiddenascdesc.Value == "asc")
                    {
                        tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~edi' class='middle31'  width='5%' onclick=sorting('edition',this.id)>Edition<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                    }
                    else if (hiddenascdesc.Value == "desc")
                    {
                        tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%'  onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~edi' class='middle31'  width='5%' onclick=sorting('edition',this.id)>Edition<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdRO~1' class='middle31'  width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle31' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle31' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                    }
                }
                else
                {
                    if (hiddenascdesc.Value == "")
                    {
                        tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31' width='5%' onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31'  width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31'  width='5%' onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                    }
                    else if (hiddenascdesc.Value == "asc")
                    {
                        tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                    }
                    else if (hiddenascdesc.Value == "desc")
                    {
                        tbl.Append("<tr><td class='middle31' width='3%'>S.No.</td><td id='tdcio~1' class='middle31' width='5%'  onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~3' class='middle31' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle31' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdRO~1' class='middle31'  width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td class='middle31' width='5%'>Publish</br>Date</td><td id='tdro~29' class='middle31' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle31' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle31' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td align='left' class='middle31' width='5%' >Uom</td><td id='tdro~24' class='middle31' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle31' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td  class='middle31'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle31' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle31' width='5%' >Audit<br>Authorization</td><td class='middle31' width='5%' >Insertion<br>N0.</td><td class='middle31' width='5%' >last publish<br>Date</td></tr>");
                    }
                }
            }
            hiddenascdesc.Value = "";
            int i1 = 1;
            int cnt = 0;
            for (int i = 0; i < cont; i++)
            {
                if (pkgdetail == "0")//no package
                {
                    if (i > 0)//for adcat total
                    {
                        if ((ds.Tables[0].Rows[i]["edition"].ToString() != ds.Tables[0].Rows[i - 1]["edition"].ToString()) || (i == cont - 1))
                        {
                            if (edition == "0")
                            {
                                if (ds.Tables[0].Rows[i]["edition"].ToString() != ds.Tables[0].Rows[i - 1]["edition"].ToString())
                                {

                                    notot = 1;
                                    arr1[0] = 0;
                                    for (int j11 = dd2; j11 < i1 - 1; j11++)
                                    {
                                        if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                        {
                                            arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                        }

                                        else
                                        {
                                            arr1[0] = arr1[0] + 0;
                                        }

                                    }
                                    cnt = Convert.ToInt32(i1 - 1) - dd2;
                                    dd2 = Convert.ToInt32(i1 - 1);

                                    cnt3 = cnt - cnt3;//paid
                                    /////////////////NEW ADDED
                                    //tbl.Append( ("<tr><td class='middle31new'colspan='2'>TotalAds:" + cnt.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + arr1[0].ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2'>Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2'>Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='3'>Date:" + tab4date.ToString() + "</td></tr>");
                            //        tbl.Append("<tr><td class='middle31new'colspan='18'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(tempareaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");

                                    cnt1 = 0;//line
                                    cnt2 = 0;//size
                                    cnt3 = 0;//paid
                                    cnt4 = 0;//fmg
                                    cnt5 = 0; //house ads  
                                    tempsqcm = 0;
                                    tempcolcm = 0;
                                    tempother = 0;
                                    temptotcc = 0;
                                    temptotcd = 0;
                                    temptotrol = 0;
                                    tempareaset = 0;
                                    temptotaudit = 0;
                                    temptotunaudit = 0;
                                    /////////////////NEW ADDED

                                }
                                if (i == cont - 1)
                                {



                                    arr1[0] = 0;
                                    for (int j11 = dd2; j11 <= cont - 1; j11++)
                                    {
                                        if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                        {
                                            arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                        }

                                        else
                                        {
                                            arr1[0] = arr1[0] + 0;
                                        }

                                    }
                                    cnt = Convert.ToInt32(cont) - dd2;

                                    cnt3 = cnt - cnt3;//paid


                                }

                            }
                        }

                    }//for adcat total
                    if (cont == 1)
                    {
                        arr1[0] = 0;
                        for (int j11 = dd2; j11 <= cont - 1; j11++)
                        {
                            if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                            {
                                arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                            }

                            else
                            {
                                arr1[0] = arr1[0] + 0;
                            }

                        }
                        cnt = Convert.ToInt32(cont) - dd2;

                        cnt3 = cnt - cnt3;//paid
                    }
                }

                tbl.Append("<tr >");
                tbl.Append("<td class='rep_data' width='3%'>");
                tbl.Append(i1++.ToString() + "</td>");

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
                    else if (ch % 10 != 0)
                    {
                        cioid1 = cioid1 + cioid[ch];
                    }
                    else
                    {
                        cioid1 = cioid1 + "</br>" + cioid[ch];
                    }
                }
                //----------------------------------------------------------------///

                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(cioid1 + "</td>");//tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='8%'>");
                //-------------------------------------------//
                string Agency1 = "";
                string Agency11 = "";
                string AA = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                char[] Agency = AA.ToCharArray();
                int len12 = Agency.Length;
                int line1 = 0;

                for (int ch = 0; ch < len12; ch++)
                {
                    if (Agency[ch] == ' ')
                    {
                        Agency1 = AA.Replace(" ", "_");
                    }
                    else
                    {
                        Agency1 = AA;
                    }
                }
                char[] AA1 = Agency1.ToCharArray();

                for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                {

                    if (ch == 0)
                    {
                        Agency11 = Agency11 + Agency[ch];
                    }
                    else if (ch % 16 != 0)
                    {
                        Agency11 = Agency11 + Agency[ch];
                    }
                    else
                    {

                        line1 = line1 + 1;
                        if (line1 != 2)
                        {
                            Agency11 = Agency11 + "</br>" + Agency[ch];
                        }

                    }
                }
                //---------------------------------------------//
                tbl.Append(Agency11 + "</td>");



                //tbl.Append( (Client11 + "</td>");
                tbl.Append("<td class='rep_data' width='8%'>");
                string Client1 = "";
                string Client11 = "";
                string BB = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                char[] Client = BB.ToCharArray();
                int len13 = Client.Length;
                int line2 = 0;

                for (int ch = 0; ch < len13; ch++)
                {
                    if (Client[ch] == ' ')
                    {
                        Client1 = BB.Replace(" ", "_");
                    }
                    else
                    {
                        Client1 = BB;
                    }
                }
                char[] BB1 = Client1.ToCharArray();

                for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                {

                    if (ch == 0)
                    {
                        Client11 = Client11 + BB1[ch];
                    }
                    else if (ch % 14 != 0)
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
                tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");


                if (edition != "0")
                {
                    tbl.Append("<td class='rep_data' width='8%'>");
                    tbl.Append(ds.Tables[0].Rows[i]["Package"] + "</td>");
                }
                if (pkgdetail == "0")//no package
                {

                    tbl.Append("<td class='rep_data' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[i]["edition"] + "</td>");


                    //if (i < cont - 1)
                    //{
                    //    edichange = "" + ds.Tables[0].Rows[i + 1]["edition"];
                    //}
                    //if (edipre != edichange)
                    //{
                    //    tbl.Append("<td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                    //    edipre = edichange;
                    //}

                }
                


                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["RO_No"] + "</td>");


                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Ins.date"] + "</td>");


                tbl.Append("<td class='rep_data' align='right' width='3%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Width"] + "</td>");//tbl.Append( (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='3%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Depth"] + "</td>");//tbl.Append( (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(chk_null(ds.Tables[0].Rows[i]["Area"].ToString()) + "</td>");

                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                {

                    if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROD")
                    {

                        areaset = areaset + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROL")
                    {
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROC")
                    {
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROW")
                    {
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                }




                tbl.Append("<td class='rep_data' align='left' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Uom"] + "</td>");


                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Hue"] + "</td>");//tbl.Append( (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["PagePremium"] + "</br>" + ds.Tables[0].Rows[i]["Pageno"] + "</td>");

                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["PosPremium"] + "</td>");

                if (edition != "0")
                {
                    tbl.Append("<td class='rep_data' align='right' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
                }




                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Adcat"] + "</br>" + ds.Tables[0].Rows[i]["AdSubcat"] + "</td>");

                tbl.Append("<td class='rep_data' width='7%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Caption"] + "</br>" + ds.Tables[0].Rows[i]["Key_no"] + "</td>");

                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[i]["FILE_NAME"]+ "</br>" + ds.Tables[0].Rows[i]["Spl Instruction"] + "</td>");//tbl.Append( (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='5%'>");
                if (ds.Tables[0].Rows[i]["audit"].ToString() != "")
                {
                    tbl.Append("Y" + "</br>"+ ds.Tables[0].Rows[i]["APP_STATUS"] +"</td>");
                    totaudit = totaudit + 1;
                    temptotaudit = temptotaudit + 1;
                }
                else
                {
                    tbl.Append("N" + "</br>"+ ds.Tables[0].Rows[i]["APP_STATUS"] +"</td>");
                    totunaudit = totunaudit + 1;
                    temptotunaudit = temptotunaudit + 1;
                }

                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["NO_INSERT"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' align='right' width='5%'>&nbsp;</td>");
//                tbl.Append(ds.Tables[0].Rows[i]["last_publish_date"].ToString() + "</td>");

                //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["ratecd"])
                if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")
                {

                    count1++;

                    cnt4++;


                }
                //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Adcat"].ToString())
                if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")
                {
                    count2++;

                    cnt5++;


                }
                // count2 = count2++;
                if (ds.Tables[0].Rows[i]["Uom"].ToString() != "")
                {
                    if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[i]["Uom"].ToString())
                    {
                        count3++;

                        cnt1++;


                    }
                    else
                    {
                        count31++;

                        cnt2++;


                    }
                }
                paidins = ((i1 - 1) - (count1 + count2));
                if (i != cont - 1)
                {
                    cnt3 = cnt4 + cnt5;
                }

                if (edition == "0")
                {
                    if (i == cont - 1 && cont > 1 && notot == 1)
                    {
                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(tempareaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                    }
                }



                tbl.Append("</tr>");

                if (pkgdetail == "0")//no package
                {

                    //     tbl.Append("<td class='rep_data' width='5%'>");
                    //     tbl.Append(ds.Tables[0].Rows[i]["edition"] + "</td>");


                    if (i < cont - 1)
                    {
                        edichange = "" + ds.Tables[0].Rows[i + 1]["edition"];
                    }
                    if (edipre != edichange)
                    {
                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                        edipre = edichange;
                    }

                }


            }
            tbl.Append("<tr ></tr>");
            if (edition != "0")
            {
                tbl.Append("<tr><td class='middle31new'colspan='20'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
            }
            else
            {
                if (pkgdetail == "0")//no package

                 //   tbl.Append("<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                    tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                else
                //   tbl.Append("<tr><td class='middle31new'colspan='17'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                    tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString()  + "</td></tr>");
            }

            tblgrid.InnerHtml = tbl.ToString();

        }
        else
        {
            int cont = ds.Tables[0].Rows.Count;
            cont1 = ds.Tables[1].Rows.Count;
            // string tbl = "";
            StringBuilder tbl = new StringBuilder();
            tbl.Append("<table width='100%'align='left' cellpadding='4' cellspacing='0' border='0'>");


            if (edition != "0")
            {
                if (hiddenascdesc.Value == "")
                {

                    tbl.Append("<tr><td class='middle31new' width='3%'>S.No.</td><td id='tdcio~1' class='middle31new' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31new' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31new' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle31new' width='8%' onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31new' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle31new' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31new' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31new' width='5%' onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' align='left'>Uom</td><td id='tdro~24' class='middle31new' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31new'  width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31new'  width='5%' >Post</br>Prem.</td><td id='tdag~31' class='middle31new' width='5%' onclick=sorting1('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle31new'  width='5%' onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' >Audit<br>Authorization</td>");


                }
                else if (hiddenascdesc.Value == "asc")
                {
                    tbl.Append("<tr><td class='middle31new' width='3%'>S.No.</td><td id='tdcio~1' class='middle31new' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31new' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31new' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle31new' width='8%' onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31new' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle31new' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31new' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31new' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' align='left'>Uom</td><td id='tdro~24' class='middle31new' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31new' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31new'  width='5%' >Post</br>Prem.</td><td id='tdag~31' class='middle31new'  width='5%' onclick=sorting1('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~38' class='middle31new' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' >Audit<br>Authorization</td>");
                }
                else if (hiddenascdesc.Value == "desc")
                {

                    tbl.Append("<tr><td class='middle31new' width='3%'>S.No.</td><td id='tdcio~1' class='middle31new' width='5%'  onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~3' class='middle31new' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle31new' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle31new' width='8%' onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td id='tdRO~1' class='middle31new'  width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~29' class='middle31new' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle31new' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle31new' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td class='middle31new' width='5%' align='left'>Uom</td><td id='tdro~24' class='middle31new' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle31new' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td  class='middle31new'  width='5%' >Post</br>Prem.</td><td id='tdag~31' class='middle31new'  width='5%' onclick=sorting1('AgreedRate',this.id)>Agg</br>Rate<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~38' class='middle31new' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle31new' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle31new' width='5%' >Audit<br>Authorization</td>");//<td id='tdcard~29' class='midwidth'   onclick=sorting('CardRate',this.id)>Card</br>Rate<img id='imgcarddown' src='Images\\down.gif' style='display:none;'><img id='imgcardup' src='Images\\up.gif' style='display:block;'></td>


                }
            }
            else
            {

                if (hiddenascdesc.Value == "")
                {
                    tbl.Append("<tr><td class='middle31new' width='3%'>S.No.</td><td id='tdcio~1' class='middle31new' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31new' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31new' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31new' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle31new' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31new' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31new' width='5%' onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' align='left'>Uom</td><td id='tdro~24' class='middle31new' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31new'  width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31new'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31new'  width='5%' onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' >Audit<br>Authorization</td>");

                }
                else if (hiddenascdesc.Value == "asc")
                {
                    tbl.Append("<tr><td class='middle31new' width='3%'>S.No.</td><td id='tdcio~1' class='middle31new' width='5%' onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~3' class='middle31new' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle31new' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdRO~1' class='middle31new' width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle31new' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle31new' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle31new' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' align='left'>Uom</td><td id='tdro~24' class='middle31new' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~32' class='middle31new' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td  class='middle31new'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31new' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle31new' width='5%' >Audit<br>Authorization</td>");

                }
                else if (hiddenascdesc.Value == "desc")
                {
                    tbl.Append("<tr><td class='middle31new' width='3%'>S.No.</td><td id='tdcio~1' class='middle31new' width='5%'  onclick=sorting1('CIOID',this.id)>Booking</br>Id<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~3' class='middle31new' width='8%' onclick=sorting('Agency',this.id) align='top'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle31new' width='8%'  onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdRO~1' class='middle31new'  width='5%' onclick=sorting('RO_No',this.id)>RONo.<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~29' class='middle31new' width='3%' onclick=sorting('Width',this.id)> WD<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle31new' width='3%' onclick=sorting('Depth',this.id)>HT<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle31new' width='5% onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td class='middle31new' width='5%' align='left'>Uom</td><td id='tdro~24' class='middle31new' width='5%' onclick=sorting('Hue',this.id)>Color<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~32' class='middle31new' width='5%' onclick=sorting1('Pageno',this.id)>Premium</br>Pageno<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td  class='middle31new'  width='5%' >Post</br>Prem.</td><td id='tdag~38' class='middle31new' width='5%'  onclick=sorting1('Adcat',this.id)>AdCat</br>Subcat<img id='imgspdown' src='Images\\down.gif' style='display:none;'><img id='imgspup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle31new' width='7%'  onclick=sorting1('Caption',this.id)>Caption</br>Keyno<img id='imgspdown' src='Images\\down.gif' style='display:block;'><img id='imgspup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle31new' width='5%' onclick=sorting1('InsertStatus',this.id)>MaterialStatus</br>FileName</br>Instruction<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle31new' width='5%' >Audit<br>Authorization</td>");

                }


            }
            hiddenascdesc.Value = "";
            int edi;

            for (edi = 0; edi < cont1; edi++)
            {
                tbl.Append("<td class='edidetail'>");
                tbl.Append(ds.Tables[1].Rows[edi]["Editions"] + "</td>");
            }
            tbl.Append("</tr>");
            int i1 = 1;
            int cnt = 0;

            for (int i = 0; i <= cont - 1; i++)
            {
                //if (pkgdetail == "0")//no package
                //{
                //    if (i > 0)//for adcat total
                //    {
                //        if ((ds.Tables[0].Rows[i]["edition"].ToString() != ds.Tables[0].Rows[i - 1]["edition"].ToString()) || (i == cont - 1))
                //        {
                //            if (i == cont - 1)
                //            {

                //                arr1[0] = 0;
                //                for (int j11 = dd2; j11 <= cont - 1; j11++)
                //                {
                //                    if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                //                    {
                //                        arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                //                    }

                //                    else
                //                    {
                //                        arr1[0] = arr1[0] + 0;
                //                    }

                //                }
                //                cnt = Convert.ToInt32(cont) - dd2;

                //                cnt3 = cnt - cnt3;//paid
                //            }
                //            else
                //            {
                //                notot = 1;
                //                arr1[0] = 0;
                //                for (int j11 = dd2; j11 < i1 - 1; j11++)
                //                {
                //                    if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                //                    {
                //                        arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                //                    }

                //                    else
                //                    {
                //                        arr1[0] = arr1[0] + 0;
                //                    }

                //                }
                //                cnt = Convert.ToInt32(i1 - 1) - dd2;
                //                dd2 = Convert.ToInt32(i1 - 1);

                //                cnt3 = cnt - cnt3;//paid

                //                tbl.Append( ("<tr><td class='middle31new'colspan='17'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                //                for (int dsd = 0; dsd < cont1; dsd++)
                //                {
                //                    tbl.Append( ("<td class='middle31new'>&nbsp;</td>");
                //                }
                //                tbl.Append( ("</tr>");
                //                cnt1 = 0;//line
                //                cnt2 = 0;//size
                //                cnt3 = 0;//paid
                //                cnt4 = 0;//fmg
                //                cnt5 = 0; //house ads  
                //                tempsqcm = 0;
                //                tempcolcm = 0;
                //                tempother = 0;
                //                temptotcc = 0;
                //                temptotcd = 0;
                //                temptotrol = 0;
                //                tempareaset = 0;
                //                /////////////////NEW ADDED
                //            }

                //        }

                //    }//for adcat total
                //    if (cont == 1)
                //    {
                //        arr1[0] = 0;
                //        for (int j11 = dd2; j11 <= cont - 1; j11++)
                //        {
                //            if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                //            {
                //                arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                //            }

                //            else
                //            {
                //                arr1[0] = arr1[0] + 0;
                //            }

                //        }
                //        cnt = Convert.ToInt32(cont) - dd2;

                //        cnt3 = cnt - cnt3;//paid
                //    }
                //}

                tbl.Append("<tr >");
                tbl.Append("<td class='rep_data'>");
                tbl.Append(i1++.ToString() + "</td>");

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
                    else if (ch % 10 != 0)
                    {
                        cioid1 = cioid1 + cioid[ch];
                    }
                    else
                    {
                        cioid1 = cioid1 + "</br>" + cioid[ch];
                    }
                }
                //----------------------------------------------------------------///

                tbl.Append("<td class='rep_data'>");
                tbl.Append(cioid1 + "</td>");


                tbl.Append("<td class='rep_data' width='200px'>");
                //-------------------------------------------//
                string Agency1 = "";
                string Agency11 = "";
                string AA = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                char[] Agency = AA.ToCharArray();
                int len12 = Agency.Length;
                int line1 = 0;

                for (int ch = 0; ch < len12; ch++)
                {
                    if (Agency[ch] == ' ')
                    {
                        Agency1 = AA.Replace(" ", "_");
                    }
                    else
                    {
                        Agency1 = AA;
                    }
                }
                char[] AA1 = Agency1.ToCharArray();

                for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                {

                    if (ch == 0)
                    {
                        Agency11 = Agency11 + Agency[ch];
                    }
                    else if (ch % 16 != 0)
                    {
                        Agency11 = Agency11 + Agency[ch];
                    }
                    else
                    {

                        line1 = line1 + 1;
                        if (line1 != 2)
                        {
                            Agency11 = Agency11 + "</br>" + Agency[ch];
                        }

                    }
                }
                //---------------------------------------------//
                tbl.Append(Agency11 + "</td>");

                tbl.Append("<td class='rep_data'>");
                string Client1 = "";
                string Client11 = "";
                string BB = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                char[] Client = BB.ToCharArray();
                int len13 = Client.Length;
                int line2 = 0;
                for (int ch = 0; ((ch < len13) && (line2 < 2)); ch++)
                {
                    if (ch == 0)
                    {
                        Client11 = Client11 + Client[ch];
                    }
                    else if (ch % 16 != 0)
                    {
                        Client11 = Client11 + Client[ch];
                    }
                    else
                    {
                        line2 = line2 + 1;
                        if (line2 != 2)
                        {
                            Client11 = Client11 + "</br>" + Client[ch];
                        }
                    }
                }
                tbl.Append(Client11 + "</td>");
                //---------------------------------------------//
                if (edition != "0")
                {
                    tbl.Append("<td class='rep_data'>");
                    tbl.Append(ds.Tables[0].Rows[i]["Package"] + "</td>");
                }


                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["RO_No"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["Width"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["Depth"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(chk_null(ds.Tables[0].Rows[i]["Area"].ToString()) + "</td>");

                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                {

                    if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROD")
                    {

                        areaset = areaset + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROL")
                    {
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROC")
                    {
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROW")
                    {
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }
                }



                if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

                tbl.Append("<td class='rep_data' align='left' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["Uom"] + "</td>");

                tbl.Append("<td class='rep_data'>");
                tbl.Append(ds.Tables[0].Rows[i]["Hue"] + "</td>");


                tbl.Append("<td class='rep_data'>");
                tbl.Append(ds.Tables[0].Rows[i]["PagePremium"] + "</br>" + ds.Tables[0].Rows[i]["Pageno"] + "</td>");

                tbl.Append("<td class='rep_data'>");
                tbl.Append(ds.Tables[0].Rows[i]["PosPremium"] + "</td>");


                if (edition != "0")
                {
                    tbl.Append("<td class='rep_data' align='right'>");
                    tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
                }



                tbl.Append("<td class='rep_data'>");
                tbl.Append(ds.Tables[0].Rows[i]["Adcat"] + "</br>" + ds.Tables[0].Rows[i]["AdSubcat"] + "</td>");

                tbl.Append("<td class='rep_data'>");
                tbl.Append(ds.Tables[0].Rows[i]["Caption"] + "</br>" + ds.Tables[0].Rows[i]["Key_no"] + "</td>");

                tbl.Append("<td class='rep_data'>");
                tbl.Append(ds.Tables[0].Rows[i]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[i]["FILE_NAME"] +"</br>" + ds.Tables[0].Rows[i]["Spl Instruction"] + "</td>");
                tbl.Append("<td class='rep_data'>");
                if (ds.Tables[0].Rows[i]["audit"].ToString() != "")
                {
                    tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[i]["APP_STATUS"] + "</td>");
                    totaudit = totaudit + 1;
                    temptotaudit = temptotaudit + 1;
                }
                else
                {
                    tbl.Append("N" + "</br>"+ ds.Tables[0].Rows[i]["APP_STATUS"] +"</td>");
                    totunaudit = totunaudit + 1;
                    temptotunaudit = temptotunaudit + 1;
                }

                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["NO_INSERT"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["last_publish_date"].ToString() + "</td>");


                for (int edi1 = 0; edi1 < cont1; edi1++)
                {
                    if (ds.Tables[0].Rows[i]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                    {
                        tbl.Append("<td class='rep_data'>");
                        tbl.Append(ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
                    }
                    else
                    {
                        tbl.Append("<td class='rep_data'></td>");
                    }
                }


                // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["ratecd"])
                if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")
                {

                    count1++;

                    cnt4++;

                }
                // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Adcat"].ToString())
                if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")
                {
                    count2++;

                    cnt5++;

                }
                if (ds.Tables[0].Rows[i]["Uom"].ToString() != "")
                {
                    if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[i]["Uom"].ToString())
                    {
                        count3++;

                        cnt1++;

                    }
                    else
                    {
                        count31++;

                        cnt2++;

                    }
                }
                paidins = ((i1 - 1) - (count1 + count2));
                if (i != cont - 1)
                {
                    cnt3 = cnt4 + cnt5;
                }
                //if (edition == "0")
                //{

                //    if (i == cont - 1 && cont > 1 && notot==1)
                //    {
                //        tbl.Append( ("<tr><td class='middle31new'colspan='17'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");



                //        for (int dsd = 0; dsd < cont1; dsd++)
                //        {
                //            tbl.Append( ("<td class='middle31new'>&nbsp;</td>");
                //        }
                //        tbl.Append( ("</tr>");
                //    }
                //}

                tbl.Append("</tr>");
            }
            tbl.Append("<tr ></tr>");
            tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + chk_null(areaset.ToString()) + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
            for (int dsd = 0; dsd < cont1; dsd++)
            {
                tbl.Append("<td class='middle31new' width='5px'>&nbsp;</td>");
            }
            tbl.Append("</tr>");
            tblgrid.InnerHtml = tbl.ToString();

        }
    }





    private void excel(string fromdt, string dateto, string compcode, string publication, string status, string edition, string publicationcenter, string adtype, string adcategory, string dateformat, string package111)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        // DataSet ds = new DataSet();
        // //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        // //{
        // //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        // //    ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode);

        // //}
        // //else
        // //{
        //     NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //     ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package111,editiondetail);

        //// }
        string cpn = "";
        cpn = ds.Tables[4].Rows[0].ItemArray[1].ToString();
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        for (int i = 0; i <= cont - 1; i++)
        {

            //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["ratecd"])
            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")
                count1++;
            // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Adcat"].ToString())
            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")
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





            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
            {

                if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROD")
                {
                    //if (ds.Tables[0].Rows[i]["Uom"].ToString() == "SQCM")
                    //{
                    //    sqcm = sqcm + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    //    tempsqcm = tempsqcm + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    //}
                    //else if (ds.Tables[0].Rows[i]["Uom"].ToString() == "CC")
                    //{
                    //    colcm = colcm + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    //    tempcolcm = tempcolcm + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    //}
                    //else
                    //{
                    //    other = other + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    //    tempother = tempother + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    //}
                    areaset = areaset + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                }
                else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROL")
                {
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                }
                else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROC")
                {
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                }
                else if (ds.Tables[0].Rows[i]["uomdesc"].ToString() == "ROW")
                {
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                }
            }

            if (ds.Tables[0].Rows[i]["audit"].ToString() == "")
            {
                totunaudit = totunaudit + 1;
            }
            else
            {
                totaudit = totaudit + 1;
            }


        }




        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        //Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/csv";
        if (chk_excel == "1")
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        }
        else
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        }

        tbl = tbl + "<table width='100%' id='tab2' align='left' cellpadding='0' cellspacing='0'border='1'>";
        tbl = tbl + ("<tr><td class='middle4' colspan='15'></td><td class='middle4' colspan='12' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + cpn + "</b><td class='middle4' ><td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' colspan='15'></td><td class='middle4' colspan='12' ><b>Schedule Register Report</b><td class='middle4' ><td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr></tr><tr></tr><tr><td class='middle4' >Date From:</td><td class='middle4' align='left' >" + fromdt + "</td><td class='middle4' colspan='13' ></td><td class='middle4' >Date To:</td><td class='middle4' >" + dateto + "</td><td class='middle4' ><td class='middle4' colspan='8' ></td></td><td class='middle4' >Run Date:</td><td class='middle4' >" + date.ToString() + "<td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' >Publication:</td><td class='middle4' align='left' >" + lblpublication.Text + "</td><td class='middle4' colspan='13' ></td><td class='middle4' >Ro Status</td><td class='middle4' >" + lblrostatus.Text + "</td><td class='middle4' ><td class='middle4' colspan='8' ></td><td class='middle4' >Publication Center:</td><td class='middle4' >" + lblpublicationcenter.Text + "</td><td class='middle4' ></td><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' >ADTYPE</td><td class='middle4' >" + adtype + "</td><td class='middle4' colspan='13' ></td><td class='middle4' >Adcategory</td><td class='middle4' >" + lbadcategory.Text + "</td><td class='middle4' ></td><td class='middle4' colspan='8' ></td><td class='middle4' >Edition:</td><td class='middle4' >" + lbedition.Text + "<td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr></tr></table>");

        tblgrid.InnerHtml += tbl;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            tblgrid.Visible = true;
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
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
        nameColumn1.HeaderText = "Agency";
        nameColumn1.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn29 = new BoundColumn();
        nameColumn29.HeaderText = "City Name";
        nameColumn29.DataField = "CITY_NAME";

        name1 = name1 + "," + "City Name";
        name2 = name2 + "," + "CITY_NAME";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn29);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Client";
        nameColumn2.DataField = "Client";

        name1 = name1 + "," + "Client";
        name2 = name2 + "," + "Client";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Package";
        nameColumn4.DataField = "Package";

        name1 = name1 + "," + "Package";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);


        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = "Edition";
        nameColumn5.DataField = "edition";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "edition";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn5);

        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "RO No.";
        nameColumn6.DataField = "RO_No";

        name1 = name1 + "," + "RO No.";
        name2 = name2 + "," + "RO_No";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "Publish Date";
        nameColumn7.DataField = "Ins.Date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins.Date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn8 = new BoundColumn();
        nameColumn8.HeaderText = "WD";
        nameColumn8.DataField = "Width";

        name1 = name1 + "," + "WD";
        name2 = name2 + "," + "Width";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn8);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "HT";
        nameColumn9.DataField = "Depth";

        name1 = name1 + "," + "HT";
        name2 = name2 + "," + "Depth";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "Area";
        nameColumn10.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Uom";
        nameColumn11.DataField = "Uom";

        name1 = name1 + "," + "Uom";
        name2 = name2 + "," + "Uom";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);


        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Color";
        nameColumn12.DataField = "Hue";

        name1 = name1 + "," + "Color";
        name2 = name2 + "," + "Hue";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);

        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "PagePremium";
        nameColumn13.DataField = "PagePremium";

        name1 = name1 + "," + "PagePremium";
        name2 = name2 + "," + "PagePremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);

        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "PosPremium";
        nameColumn14.DataField = "PosPremium";

        name1 = name1 + "," + "PosPremium";
        name2 = name2 + "," + "PosPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "Page no";
        nameColumn15.DataField = "Pageno";

        name1 = name1 + "," + "Page no";
        name2 = name2 + "," + "Pageno";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);

        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "AgreedRate";
        nameColumn16.DataField = "AgreedRate";

        name1 = name1 + "," + "AgreedRate";
        name2 = name2 + "," + "AgreedRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "Adcat";
        nameColumn17.DataField = "Adcat";

        name1 = name1 + "," + "Adcat";
        name2 = name2 + "," + "Adcat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "AdSubcat";
        nameColumn18.DataField = "AdSubcat";

        name1 = name1 + "," + "AdSubcat";
        name2 = name2 + "," + "AdSubcat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn28 = new BoundColumn();
        nameColumn28.HeaderText = "Adcat3";
        nameColumn28.DataField = "AdSubcat3";

        name1 = name1 + "," + "Adcat3";
        name2 = name2 + "," + "AdSubcat3";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn28);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "Caption";
        nameColumn19.DataField = "Caption";

        name1 = name1 + "," + "Caption";
        name2 = name2 + "," + "Caption";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "Keyno";
        nameColumn20.DataField = "Key_no";

        name1 = name1 + "," + "Keyno";
        name2 = name2 + "," + "Key_no";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = "Material Status";
        nameColumn21.DataField = "InsertStatus";

        name1 = name1 + "," + "Material Status";
        name2 = name2 + "," + "InsertStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn21);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = "File Name";
        nameColumn22.DataField = "FILE_NAME";

        name1 = name1 + "," + "File Name";
        name2 = name2 + "," + "FILE_NAME";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn22);


        BoundColumn nameColumn23 = new BoundColumn();
        nameColumn23.HeaderText = "Instruction";
        nameColumn23.DataField = "Spl Instruction";

        name1 = name1 + "," + "Instruction";
        name2 = name2 + "," + "Spl Instruction";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn23);

        BoundColumn nameColumn24 = new BoundColumn();
        nameColumn24.HeaderText = "Audit";
        nameColumn24.DataField = "audit";

        name1 = name1 + "," + "Audit";
        name2 = name2 + "," + "audit";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn24);

        BoundColumn nameColumn25 = new BoundColumn();
        nameColumn25.HeaderText = "Authorization";
        nameColumn25.DataField = "APP_STATUS";

        name1 = name1 + "," + "Authorization";
        name2 = name2 + "," + "APP_STATUS";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn25);

        BoundColumn nameColumn26 = new BoundColumn();
        nameColumn26.HeaderText = "Insertion N0.";
        nameColumn26.DataField = "NO_INSERT";

        name1 = name1 + "," + "nsertion N0.";
        name2 = name2 + "," + "NO_INSERT";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn26);

        BoundColumn nameColumn27 = new BoundColumn();
        nameColumn27.HeaderText = "Branch Name";
        nameColumn27.DataField = "BRANCH_NAME";

        name1 = name1 + "," + "Branch Name";
        name2 = name2 + "," + "BRANCH_NAME";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn27); 

        BoundColumn nameColumn30 = new BoundColumn();
        nameColumn30.HeaderText = "last_publish_date";
        nameColumn30.DataField = "last_publish_date";

        name1 = name1 + "," + "last_publish_date";
        name2 = name2 + "," + "last_publish_date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn30);


        ///nameColumn28 added up


        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
         //   DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
      //      hw.Write("<p align=center>Schedule Register Report");
            // hw.Write("<ul><li>test</li></ul>");
            //hw.Write(comm2);
            hw.WriteBreak();
            //DataGrid1.in
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;

            // Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds :" + sno11 + "</td><td colspan=\"2\">TotalArea:" + areanew + "</td><td>Line/Word::" + count3 + "</td><td ></td><td>Paid:" + paidins + "</td><td colspan=\"5\">Fmg:" + count1 + "</td><td colspan=\"4\">HouseAds:" + count2 + "</td><td colspan=\"4\">Pages:" + 1 + "-" + sno11 + "</td></table>")); //align=\"center\" colspan=\"7\"
            Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds :" + sno11 + "</td><td colspan='2'>Lines:" + totrol + "</td><td colspan='2'>Words:" + totcc + "</td><td colspan='2'>Chars:" + totcd + "</td><td colspan=\"3\" align='right'>TotalArea:" + areaset + "</td><td ></td><td colspan='2'>Paid:" + paidins + "</td><td colspan='1'>Fmg:" + count1 + "</td><td colspan=\"2\">&nbsp;</td><td colspan=\"2\">Audit:" + totaudit + "</td><td colspan=\"2\">Unaudit:" + totunaudit + "</td><td colspan=\"2\">Pages:" + 1 + "-" + sno11 + "</td></table>")); //align=\"center\" colspan=\"7\"
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




    private void pdf(string fromdt, string dateto, string compcode, string publication, string status, string edition, string publicationcenter, string adtype, string adcategory, string dateformat, string package111)
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

        int NumColumns = 24;
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
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));

            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            tbl2.addCell(new Phrase(lblpublication.Text, font11));
            tbl2.addCell(new Phrase("Ro Status", font10));
            tbl2.addCell(new Phrase(lblrostatus.Text, font11));
            tbl2.addCell(new Phrase("Publication Center", font10));
            tbl2.addCell(new Phrase(lblpublicationcenter.Text, font11));

            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            tbl2.addCell(new Phrase(lbadtype.Text, font11));
            tbl2.addCell(new Phrase("AdCategory", font10));
            tbl2.addCell(new Phrase(lbadcategory.Text, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            tbl2.addCell(new Phrase(lbedition.Text, font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            //-------------------------------table for header-------------------------------------------------------
            float[] headerwidths = { 11, 14, 14, 18, 15, 16, 10,27, 10, 10, 12, 15, 15, 20, 14, 16, 16, 18, 14, 14, 12, 24, 16}; // percentage
            PdfPTable datatable = new PdfPTable(headerwidths);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //////// float[] headerwidths = { 12, 18, 18, 20, 16, 18, 12, 14, 18, 18, 17, 15, 14, 15, 20 ,20,15,15,12,21,21}; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            ////////   datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            //datatable.addCell(new Phrase("City"));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));


            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[98].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[60].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[25].ToString() + "\n" + "File Name" + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[41].ToString(), font10));
            //datatable.addCell(new Phrase("File Name", font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[41].ToString(), font10));
            datatable.addCell(new Phrase("Audit" +"\n"+ "Authorization", font10));
            // datatable.addCell(new Phrase("Authorization", font10));
            datatable.DefaultCell.Colspan = 23;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase("___________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);


            //------------------//-------------------------------------------------------------------       


            //DataSet ds = new DataSet();

            ////if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            ////{
            ////    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            ////    ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, publicationcenter, adtype, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode);

            ////}
            ////else
            ////{
            //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();

            //    ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, publicationcenter, adtype, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package111,editiondetail);

            ////}
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RO_No"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                {
                    area = area + Convert.ToDecimal(ds.Tables[0].Rows[row]["Area"].ToString());


                    if (ds.Tables[0].Rows[row]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[row]["uomdesc"].ToString() == "ROD")
                    {
                        //if (ds.Tables[0].Rows[row]["Uom"].ToString() == "SQCM")
                        //{
                        //    sqcm = sqcm + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //    tempsqcm = tempsqcm + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //}
                        //else if (ds.Tables[0].Rows[row]["Uom"].ToString() == "CC")
                        //{
                        //    colcm = colcm + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //    tempcolcm = tempcolcm + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //}
                        //else
                        //{
                        //    other = other + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //    tempother = tempother + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        //}
                        areaset = areaset + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[row]["uomdesc"].ToString() == "ROL")
                    {
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[row]["uomdesc"].ToString() == "ROC")
                    {
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    }
                    else if (ds.Tables[0].Rows[row]["uomdesc"].ToString() == "ROW")
                    {
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    }




                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Uom"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PosPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Pageno"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adcat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdSubcat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Caption"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key_no"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["InsertStatus"].ToString() + ds.Tables[0].Rows[row]["FILE_NAME"].ToString() + ds.Tables[0].Rows[row]["Spl Instruction"].ToString(), font11));
              //  datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["FILE_NAME"].ToString(), font11));
              //  datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Spl Instruction"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["audit"].ToString() != "")
                {
                    datatable.addCell(new Phrase("Y" + "\n" + ds.Tables[0].Rows[row]["APP_STATUS"].ToString(), font11)); 
                    totaudit = totaudit + 1;
                }
                else
                {
                    datatable.addCell(new Phrase("N" + "\n" + ds.Tables[0].Rows[row]["APP_STATUS"].ToString(), font11));
                    totunaudit = totunaudit + 1;
                }



                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(24);
            //  float[] headerwidths5 = { 11, 13, 14, 14, 10, 8, 12 }; // percentage
            // tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
           
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase("Total Area", font10));
            tbltotal.addCell(new Phrase(areaset.ToString(), font11));
            //tbltotal.addCell(new Phrase("Sqcm:", font10));
            //tbltotal.addCell(new Phrase(sqcm.ToString(), font11));
            //tbltotal.addCell(new Phrase("Colcm:", font10));
            //tbltotal.addCell(new Phrase(colcm.ToString(), font11));
            tbltotal.DefaultCell.Colspan = 1;
            tbltotal.addCell(new Phrase("Lines", font10));
            tbltotal.addCell(new Phrase(totrol.ToString(), font11));
            tbltotal.addCell(new Phrase("Chars", font10));
            tbltotal.addCell(new Phrase(totcd.ToString(), font11));
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.addCell(new Phrase("Words", font10));
            tbltotal.addCell(new Phrase(totcc.ToString(), font11));
            tbltotal.addCell(new Phrase("Audit", font10));
            tbltotal.addCell(new Phrase(totaudit.ToString(), font11));
            tbltotal.addCell(new Phrase("Unaudit", font10));
            tbltotal.addCell(new Phrase(totunaudit.ToString(), font11));


            //   tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.Colspan = 24;
            tbltotal.addCell(new Phrase("________________________________________________________________________________________________________________________________________________________________________", font10));
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





    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["rep_schedulerep_print"] = "destination~" + destination + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~publicationname~" + publication + "~publicationcenter~" + publicationcenter + "~edition~" + edition + "~pubcentcode~" + pubcentcode + "~adtype~" + adtype + "~adtypecode~" + adtypecode + "~adcategory~" + adcategory + "~editiondetail~" + editiondetail + "~status~" + status + "~sortfield~" + sortfield + "~sorting~" + sorting + "~adcatname~" + adcatname + "~supplementcode~" + supplementcode + "~package1~" + package11 + "~pkgdetail~" + pkgdetail + "~package11name~" + package11name + "~editionname~" + editionname + "~ro_status~" + ro_statusnam;
        Session["schedulerep"] = ds;
        Response.Redirect("PrintScheduleRegister.aspx");
        //        Response.Redirect("PrintScheduleRegister.aspx?destination=" + destination + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&publicationname=" + publication + "&publicationcenter=" + publicationcenter + "&edition=" + edition + "&pubcentcode=" + pubcentcode + "&adtype=" + adtype + "&adtypecode=" + adtypecode + "&adcategory=" + adcategory + "&editiondetail=" + editiondetail + "&status=" + status + "&sortfield=" + sortfield + "&sorting=" + sorting + "&adcatname=" + adcatname + "&supplementcode=" + supplementcode + "&package1=" + package11 + "&pkgdetail=" + pkgdetail + "&package11name=" + package11name);

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

        string check1 = e.Item.Cells[11].Text;
        string amt1 = e.Item.Cells[11].Text;

        //area
        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {
                string arean = e.Item.Cells[11].Text;
                areanew = areanew + Convert.ToDouble(arean);
            }
        }


        string chkname = e.Item.Cells[25].Text;

        if (chkname != "Audit")
        {

            if (chkname != "" && chkname != "&nbsp;")
            {
                e.Item.Cells[25].Text = "Y";
            }
            else
            {
                if (e.Item.Cells[0].Text != "" && e.Item.Cells[0].Text != "&nbsp;")
                {
                    e.Item.Cells[25].Text = "N";
                }
            }

        }



    }
}

