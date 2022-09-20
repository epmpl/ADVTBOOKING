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

public partial class Agencycliview : System.Web.UI.Page
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
    string day = "";
    string month = "";
    string year = "";
    string adcatname = "";
    string clientname1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    int ins_no = 0;
    double amt = 0;
    string client = "";
    string package = "";
    string drillon = "";
    string sortorder = "";
    string sortvalue = "";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;


    protected void Page_Load(object sender, EventArgs e)
    {
        //hiddendateformat.Value = Session["dateformat"].ToString();
        //hiddendatefrom.Value = Session["datefrom"].ToString();
        //hiddendateto.Value = Session["dateto"].ToString();

        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();
        

        if (Request.QueryString["drilout"] == "yes")
        {
            
            adtyp = Request.QueryString["adtype"].Trim().ToString();
            adcat = Request.QueryString["adcategory"].Trim().ToString();            
            publ = Request.QueryString["publication"].Trim().ToString();
            pubcen = Request.QueryString["pubcenter"].Trim().ToString();          
            client = Request.QueryString["client"].Trim().ToString();
            edition = Request.QueryString["edition"].Trim().ToString();          
            package = Request.QueryString["package"].Trim().ToString();
            destination = Request.QueryString["destination"].Trim().ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
          
            //drillonscreen(client,adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package);

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
            adtypename = Request.QueryString["adtypename"].ToString();
            editionname = Request.QueryString["editionname"].ToString();            
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
                    datefrom1 =dd + "/" + mm + "/" + yy;

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
       

            if (destination == "1" || destination == "0")
            {
                onscreen(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

            }
            else
                if (destination == "3")
                {
                    pdf(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                }

        }
    }


    private void onscreen(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
       // ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass misrep = new NewAdbooking.classesoracle.reportclass();
            ds = misrep.spclient123(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
      


        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdro~28' class='middle3'   onclick=sorting('SAPID',this.id)> SAPID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdcl~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3' onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'   onclick=sorting('Depth',this.id)> Depth<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'   onclick=sorting('Width',this.id)> Width<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'   onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td>   <td id='tdro~23' class='middle3'   onclick=sorting('Page',this.id)> Page<img id='img23down' src='Images\\down.gif' style='display:block;'><img id='img23up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~22' class='middle3'   onclick=sorting('Ins.No.',this.id)> Ins.No.<img id='img21down' src='Images\\down.gif' style='display:block;'><img id='img21up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~30' class='middle3'   onclick=sorting('RoNo.',this.id)> RoNo.<img id='img30down' src='Images\\down.gif' style='display:block;'><img id='img30up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~31' class='middle3'   onclick=sorting('RoStatus',this.id)> RoStatus<img id='img31down' src='Images\\down.gif' style='display:block;'><img id='img31up' src='Images\\up.gif' style='display:none;'></td><td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~32' class='middle3'   onclick=sorting('RateCode',this.id)> RateCode<img id='img32down' src='Images\\down.gif' style='display:block;'><img id='img32up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~20' class='middle3'   onclick=sorting('AgreedRate',this.id)> AggRate<img id='img20down' src='Images\\down.gif' style='display:block;'><img id='img20up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~19' class='middle3'   onclick=sorting('Amt',this.id) align='right'>Net Amt<img id='img19down' src='Images\\down.gif' style='display:block;'><img id='img19up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~18' class='middle3'   onclick=sorting('Cap',this.id)> Cap<img id='img18down' src='Images\\down.gif' style='display:block;'><img id='img18up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~17' class='middle3'   onclick=sorting('Key',this.id)> Key<img id='img17down' src='Images\\down.gif' style='display:block;'><img id='img17up' src='Images\\up.gif' style='display:none;'></td></tr>");

        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdro~28' class='middle3'   onclick=sorting('SAPID',this.id)> SAPID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.Date</td><td id='tdcl~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3' onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~26' class='middle3'   onclick=sorting('Depth',this.id)> Depth<img id='img26down' src='Images\\down.gif' style='display:block;'><img id='img26up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~29' class='middle3'   onclick=sorting('Width',this.id)> Width<img id='img29down' src='Images\\down.gif' style='display:block;'><img id='img29up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~24' class='middle3'   onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:block;'><img id='img24up' src='Images\\up.gif' style='display:none;'></td>  <td id='tdro~23' class='middle3'   onclick=sorting('Page',this.id)> Page<img id='img23down' src='Images\\down.gif' style='display:block;'><img id='img23up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~22' class='middle3'   onclick=sorting('Ins.No.',this.id)> Ins.No.<img id='img21down' src='Images\\down.gif' style='display:block;'><img id='img21up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~30' class='middle3'   onclick=sorting('RoNo.',this.id)> RoNo.<img id='img30down' src='Images\\down.gif' style='display:block;'><img id='img30up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~31' class='middle3'   onclick=sorting('RoStatus',this.id)> RoStatus<img id='img31down' src='Images\\down.gif' style='display:block;'><img id='img31up' src='Images\\up.gif' style='display:none;'></td><td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~32' class='middle3'   onclick=sorting('RateCode',this.id)> RateCode<img id='img32down' src='Images\\down.gif' style='display:block;'><img id='img32up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~20' class='middle3'   onclick=sorting('AgreedRate',this.id)> AggRate<img id='img20down' src='Images\\down.gif' style='display:block;'><img id='img20up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~19' class='middle3'   onclick=sorting('Amt',this.id) align='right'>Net Amt<img id='img19down' src='Images\\down.gif' style='display:block;'><img id='img19up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~18' class='middle3'   onclick=sorting('Cap',this.id)> Cap<img id='img18down' src='Images\\down.gif' style='display:block;'><img id='img18up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~17' class='middle3'  onclick=sorting('Key',this.id)> Key<img id='img17down' src='Images\\down.gif' style='display:none;'><img id='img17up' src='Images\\up.gif' style='display:block;'></td></tr>");

        }
        else if (hiddenascdesc.Value == "desc")
        {


            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdro~28' class='middle3'  onclick=sorting('SAPID',this.id)> SAPID<img id='img28down' src='Images\\down.gif' style='display:none;'><img id='img28up' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.Date</td><td id='tdcl~3' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3' onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~26' class='middle3'  onclick=sorting('Depth',this.id)> Depth<img id='img26down' src='Images\\down.gif' style='display:none;'><img id='img26up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~29' class='middle3'  onclick=sorting('Width',this.id)> Width<img id='img29down' src='Images\\down.gif' style='display:none;'><img id='img29up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~24' class='middle3'  onclick=sorting('Hue',this.id)> Hue<img id='img24down' src='Images\\down.gif' style='display:none;'><img id='img24up' src='Images\\up.gif' style='display:block;'></td>  <td id='tdro~23' class='middle3'  onclick=sorting('Page',this.id)> Page<img id='img23down' src='Images\\down.gif' style='display:none;'><img id='img23up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~22' class='middle3'   onclick=sorting('Ins.No.',this.id)> Ins.No.<img id='img21down' src='Images\\down.gif' style='display:block;'><img id='img21up' src='Images\\up.gif' style='display:none;'></td><td id='tdro~30' class='middle3'  onclick=sorting('RoNo.',this.id)> RoNo.<img id='img30down' src='Images\\down.gif' style='display:none;'><img id='img30up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~31' class='middle3'  onclick=sorting('RoStatus',this.id)> RoStatus<img id='img31down' src='Images\\down.gif' style='display:none;'><img id='img31up' src='Images\\up.gif' style='display:block;'></td> <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td> <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~32' class='middle3'  onclick=sorting('RateCode',this.id)> RateCode<img id='img32down' src='Images\\down.gif' style='display:none;'><img id='img32up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~20' class='middle3'  onclick=sorting('AgreedRate',this.id)> AggRate<img id='img20down' src='Images\\down.gif' style='display:none;'><img id='img20up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~19' class='middle3'  onclick=sorting('Amt',this.id) align='right'>Net Amt<img id='img19down' src='Images\\down.gif' style='display:none;'><img id='img19up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~18' class='middle3'  onclick=sorting('Cap',this.id)> Cap<img id='img18down' src='Images\\down.gif' style='display:none;'><img id='img18up' src='Images\\up.gif' style='display:block;'></td><td id='tdro~17' class='middle3'   onclick=sorting('Key',this.id)> Key<img id='img17down' src='Images\\down.gif' style='display:block;'><img id='img17up' src='Images\\up.gif' style='display:none;'></td></tr>");

        }



        int i1 = 1;
       
        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");  
               
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");  
               
                
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");  
               
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");  
               
                
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");  
               
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");  
               
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");  
               
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");  
               
                 tbl = tbl + ("<td class='rep_data'>");
                 tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");  
               
               
               


                ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[i]["Ins.No."].ToString());

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


                if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double .Parse (ds.Tables[0].Rows[i]["Amt"].ToString());
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");  
                
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");  
                

                tbl = tbl + "</tr>";

            tbl = tbl + "</tr>";

        }

       // tbl = tbl + ("<tr >");
        //////////////
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";//<td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr width='100%'>");
        tbl = tbl + ("<td class='middle3156'>TotalAds:-</td>");
        tbl = tbl + ("<td class='middle3156'>&nbsp;");

        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle3156'>&nbsp;");


        tbl = tbl + ("<td class='middle3156'>&nbsp;");
        tbl = tbl + ("<td class='middle3156'>&nbsp;<td class='middle3156'>&nbsp;<td class='middle3156'>&nbsp;<td class='middle3156'>&nbsp;</td>");
        tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td>");
        //tbl = tbl + (area.ToString() + "</td>");

        tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>TotalAmt:-</td>");
        tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'align='right'>");
        tbl = tbl + (amt.ToString() + "</td>");
        tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td>");
        tbl = tbl + "</tr>";
        ///////////////
       // tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
       // tbl = tbl + ("<tr >");

       // tbl = tbl + ("<td class='middle3156'>");
       // tbl = tbl + ("<td class='middle3156'>");
       // tbl = tbl + ("<tr><td class='middle3156'>TotalAds:</td>");//<td class='middle13'></td>");
       // tbl = tbl + ("<td class='middle3156'>");
       // tbl = tbl + ((i1-1).ToString() + "</td>");

       // tbl = tbl + ("<td class='middle3156'>&nbsp;</td>");
       //// tbl = tbl + ("<td class='middle13'><td class='middle13'></td><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>Total Amount</td><td class='middle13'></td>");
       // tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle13'>&nbsp;</td><td class='middle3156'>&nbsp;</td><td class='middle3156'width='15%'>Total Amount</td><td class='middle3156'>&nbsp;</td>");

       // tbl = tbl + ("<td class='middle3156'>&nbsp;</td><td class='middle3156'align='right'>");
       // tbl = tbl + (amt.ToString() + "</td>");
       // tbl = tbl + ("<td class='middle3156'>&nbsp;</td>");
       // tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
    }



    private void excel(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";

        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        // ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass misrep = new NewAdbooking.classesoracle.reportclass();
            ds = misrep.spclient123(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "" };
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
        string clint = "";
        if (clientname == "0")
        {
            clint = "ALL";
        }
        else
        {
            clint = clientname1.ToString();
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
        tbl = tbl + "<tr width='100%'><td  align='center'style='font-family:Arial;font-size:12px;' colspan='14'><b>ALL ADS OF CLIENT </b></td></tr>";
        tbl = tbl + "<tr width='100%'><td  align='left'style='font-family:Arial;font-size:12px;' colspan='3'><b>Publication :</b>" + pub + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='3'><b>Pub Center :</b>" + pubcernt + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='4'><b>Edition :</b>" + edit + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='9'><b>Client :</b>" + clint + "</td></tr>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'  colspan='3'><b>Date From :</b>" + fromdate + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'  colspan='3'><b>Date To :</b>" + dateto123 + "</td>";
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' colspan='13'><b>Run Date :</b>" + rundate + "</td></tr></table>";
        tbl = tbl + "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='1'>";
       // tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";



       

            tbl = tbl + ("<tr><td class='middle31'align='right'><b>S.No.</b></td><td id='tdro~28' class='middle3'   ><b> SAPID</b></td><td class='middle31'><b>Ins.Date</b></td><td id='tdcl~3' class='middle3' ><b>Client</b></td><td id='tdcl~4' class='middle3'><b>City</b></td><td id='tdcl~5' class='middle3' ><b>Package</b></td><td id='tdro~26' class='middle3' ><b> Depth</b></td><td id='tdro~29' class='middle3'><b> Width</b></td><td id='tdro~24' class='middle3'> <b>Hue</b></td>   <td id='tdro~23' class='middle3' ><b> Page</b></td><td id='tdro~22' class='middle3' ><b> Ins.No.</b></td><td id='tdro~30' class='middle3' ><b> RoNo.</b></td><td id='tdro~31' class='middle3' ><b> RoStatus</b></td><td id='tdat~13' class='middle3' ><b>AdType</b></td><td id='tdad~14' class='middle3' ><b>AdCat</b></td><td id='tdro~32' class='middle3'  ><b> RateCode</b></td><td id='tdro~20' class='middle3' > <b>AggRate</b></td><td id='tdro~19' class='middle3' ><b>Net Amt</b></td><td id='tdro~18' class='middle3' ><b> Cap</b></td><td id='tdro~17' class='middle3' ><b> Key</b></td></tr>");

        



        int i1 = 1;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");


            //string insdate12 = "";
           string insdate123 = (ds.Tables[0].Rows[i]["Ins.date"].ToString());

           string[] insdate = (insdate123).ToString().Split('/');
           if (insdate[0].Length < 2)
               insdate[0] = "0" + insdate[0];

           if (insdate[1].Length < 2)
               insdate[1] = "0" + insdate[1];
           // if (dt[2]
           if (hiddendateformat.Value == "mm/dd/yyyy")
           {
               hdn_insdate.Value = insdate[1] + "/" + insdate[0] + "/" + insdate[2];

           }
           else if (hiddendateformat.Value == "dd/mm/yyyy")
           {
               hdn_insdate.Value = insdate[0] + "/" + insdate[1] + "/" + insdate[2];
           }
           else
           {
               hdn_insdate.Value = insdate[2] + "/" + insdate[0] + "/" + insdate[1];
           }





           tbl = tbl + (hdn_insdate.Value + "</td>");
            


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");





            ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[i]["Ins.No."].ToString());

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


            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");


            tbl = tbl + "</tr>";

            tbl = tbl + "</tr>";

        }

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds:");
     //   tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'><td class='middle13'></td><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>Total Amount</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "</td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //hw.Write("<p align=center>ALL ADS OF CLIENT");
        hw.WriteBreak();
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());

        Response.Flush();
        Response.End();
    }
    private void pdf(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);


        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC00343 copy.bmp";
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
        //Graphic grx = new Graphic();
        //grx.lineTo(12, 12);
        int NumColumns = 20;
       
        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        //----------------------------------------
        


        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[10].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //grx.lineTo(30, 30);
            //---------------------------------------------
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

            PdfPTable tbl255 = new PdfPTable(4);
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
            string clint = "";
            if (clientname == "0")
            {
                clint = "ALL";
            }
            else
            {
                clint = clientname1.ToString();
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
            //tbl255.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl255.addCell(new Phrase("Pub Center:" + pubcernt, font10));
            tbl255.addCell(new Phrase("Edition:" + edit, font10));
            tbl255.addCell(new Phrase("Client:" + clint, font10));
            //tbl255.addCell(new Phrase(dateto1.ToString(), font11));
            //tbl255.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            //tbl255.addCell(new Phrase(date.ToString(), font11));
            tbl255.WidthPercentage = 100;
            document.Add(tbl255);



            PdfPTable tbl2 = new PdfPTable(4);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase("From Date:" + datefrom1, font10));
           // tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            //tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase("To Date:" + dateto1, font10));
            //tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            // tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            //tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.addCell(new Phrase("" + "", font10));
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
            tb89.addCell(new Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));
            document.Add(tb89);
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

            //-----------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);


            //datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
           // grx.lineTo(200, 800);
            //grx.drawBorder(30, 006);

            float[] headerwidths = { 10, 10, 25, 25, 23, 15, 10, 10, 24, 10, 10, 10, 15, 18, 20, 15, 10, 25, 10, 10 };


            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;


            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            //datatable.HeaderRows = 1;
           // Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            //document.Add(p2);
            datatable.DefaultCell.Colspan = 20;
            datatable.addCell(new Phrase("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));
            // document.Add(tb8944);
            // datatable.HeaderRows = 1;
            datatable.DefaultCell.Colspan = 1;



           // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"", "", "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass misrep = new NewAdbooking.classesoracle.reportclass();
                ds = misrep.spclient123(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }


            //PdfPTable datatable1 = new PdfPTable(NumColumns);
            //float[] headerwidths5 = { 12,14, 15, 26, 22, 19, 13, 19, 14, 24, 24, 21, 21, 20, 20,15, 10, 10 }; // percentage
            //datatable1.setWidths(headerwidths5);
            //datatable1.WidthPercentage = 100; // percentage
            ////datatable1.TotalWidth = 10;
            ////datatable1.TotalHeight = 10;
            //datatable1.DefaultCell.BorderWidth = 0;
            //datatable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable1.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            int i1 = 1;
            int row = 0;
            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            //{
               // for (int a = 0; a <= 10; ++a)
               // {
                    //for (int column = 0; column < ds.Tables[0].Columns.Count; column++)
                    //{
            while (row < ds.Tables[0].Rows.Count)
            {
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString(), font11));
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));

                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));

                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")

                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    //datatable.HeaderRows = 1;

               // }

                //    break;
                    row++;


                //}
            }


            document.Add(datatable);
        

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] abc = { 8, 8, 19, 25, 23, 13, 19, 17, 24, 24, 21, 30, 20, 16, 23, 21, 20, 25, 13, 14 };


            datatable.setWidths(abc);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
           
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
           
            document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName);


            //document.Add(datatable);
            //document.Close();
            //Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        pdf1(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

    }

    private void pdf1(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");


        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC00343 copy.bmp";
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
        //Graphic grx = new Graphic();
        //grx.lineTo(12, 12);
        int NumColumns = 20;

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        //----------------------------------------



        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[10].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //grx.lineTo(30, 30);
            //---------------------------------------------
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

            //-----------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);


            datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            // grx.lineTo(200, 800);
            //grx.drawBorder(30, 006);

            //float[] headerwidths = {13, 18, 19, 25,23, 13, 19, 17, 24, 24, 21, 30, 20,16, 23,21, 15, 16 ,13,14};


            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;


            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);



           // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            
            //ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classnew misrep = new NewAdbooking.classesoracle.classnew();
                ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "reportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), Session["agency_name"].ToString(), "", "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            int i1 = 1;
            int row = 0;
            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            //{
            // for (int a = 0; a <= 10; ++a)
            // {
            //for (int column = 0; column < ds.Tables[0].Columns.Count; column++)
            //{
            while (row < ds.Tables[0].Rows.Count)
            {
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString(), font11));
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
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
                //datatable.HeaderRows = 1;

                // }

                //    break;
                row++;


                //}
            }


            document.Add(datatable);


            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 20, 16, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));

            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

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
    private void drillonscreen(string client,  string adtyp, string adcategory, string fromdate, string dateto, string publication, string pubcenter, string compcode, string edition, string package,string dateformat)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 misrep = new NewAdbooking.classesoracle.Class1();
            ds = misrep.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","","","");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "report_drillout_report_drillout_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>SAPID</td><td class='middle3'>Ins.Date</td><td class='middle3'>Client</td><td class='middle3'>City</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Hue</td><td class='middle3'>page</td><td class='middle3'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle3'>RoStatus</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>RateCode</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");


        //           <td id='tdcl~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td>
        //<td id='tdcl~3' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td>
        //            <td id='tdcl~3' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td>


        //<td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
        //    <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td>
        //        <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td>

        //                <td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td>
        //    <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td>
        //        <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td>



        //           <td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
        //<td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td>
        //            <td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td>


        //           <td id='tdcl~4' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
        //<td id='tdcl~4' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td>
        //            <td id='tdcl~4' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td>




        if (hiddenascdesc.Value == "")
        {

            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>SAPID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdpc~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>Page</td><td class='middle3'>Ins.No</td><td id='tdat~12' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td> <td id='tdad~13' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>SAPID</td><td class='middle31'>Ins.Date</td><td id='tdcl~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>page</td><td class='middle13'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~13' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~14' class='middle3'   onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>AggRate</td><td class='middle31'>Net Amt</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");


        }
        else if (hiddenascdesc.Value == "asc")
        {

            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>SAPID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdpc~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>Page</td><td class='middle3'>Ins.No</td><td id='tdat~12' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~13' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>SAPID</td><td class='middle31'>Ins.Date</td><td id='tdcl~3' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>page</td><td class='middle31'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle31'>RoStatus</td> <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:block;'><img id='imgadup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>AggRate</td><td class='middle31'>Net Amt</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");


        }
        else if (hiddenascdesc.Value == "desc")
        {

            // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>SAPID</td><td class='middle3'>Ins.Date</td><td id='tdag~3' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdpc~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>Hue</td><td class='middle3'>Page</td><td class='middle3'>Ins.No</td><td id='tdat~12' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td><td id='tdad~13' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Amt</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>SAPID</td><td class='middle31'>Ins.Date</td><td id='tdcl~3' class='middle3'  onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:none;'><img id='imgclup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~4' class='middle3'  onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdcl~5' class='middle3'  onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:none;'><img id='imgpaup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>page</td><td class='middle31'>Ins.No</td><td class='middle3'>RoNo.</td><td class='middle31'>RoStatus</td> <td id='tdat~13' class='middle3'  onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:none;'><img id='imgatup' src='Images\\up.gif' style='display:block;'></td> <td id='tdad~14' class='middle3'  onclick=sorting('AdCat',this.id)>AdCat<img id='imgaddown' src='Images\\down.gif' style='display:none;'><img id='imgadup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>RateCode</td><td class='middle31'>AggRate</td><td class='middle31'>Net Amt</td><td class='middle31'>Cap</td><td class='middle31'>Key</td></tr>");


        }



        int i1 = 1;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            //for (int j = 0; j < contc; j++)
            //{
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["SAPID"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["City"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.No."] + "</td>");





            ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[11].ToString());

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


            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");


            tbl = tbl + "</tr>";

            tbl = tbl + "</tr>";

        }

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td></tr>";
        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'><td class='middle13'></td><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'><td class='middle13'></td></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt</td><td class='middle13'></td>");
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
            NewAdbooking.classesoracle.Class1 misrep = new NewAdbooking.classesoracle.Class1();
            ds = misrep.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
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
        hw.Write("<p align=center>All Ads Of The Client");
        // hw.Write("<ul><li>test</li></ul>");
        //hw.Write(comm2);
        hw.WriteBreak();
        //DataGrid1.in
        DataGrid1.RenderControl(hw);
        double arr = comm2 / areanew;
        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"7\">TOTAL</td><td colspan=\"9\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td></table>"));



        //Response.Write(sw.ToString().Replace("</table>", "<tr><td align=\"center\" colspan=\"7\">TOTAL</td><td>50</td><td colspan=\"7\">&nbsp;</td><td>"+comm2+"</td><td></td><td></td></table>"));
        Response.Flush();
        Response.End(); 
        
        
        
        
        
    }
    
    
    
    
    /* string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

        try
        {
            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            
            SqlDataReader myReader1 = null;
            OracleDataReader myReader = null;

            
            //DataSet dst=clsbook.spfun();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                myReader1 = obj.drillout_clientexcel(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString());


                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader1.Read())
                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

                //oSheet.Cells[1, 7] = "All Ads OF A CLIENT";
                for (int j = 0; j < myReader1.FieldCount; j++)
                {

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();

                    oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[26].ToString();
                    oSheet.Cells[3, 20] = pdfxml.Tables[0].Rows[0].ItemArray[27].ToString();




                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();

                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //  string total = "";
                int i1 = 1;
                //int finaltotal = 0;
                while (myReader1.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader1.FieldCount; k++)
                    {





                        oSheet.Cells[iRow, 2] = myReader1["SAPID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader1["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader1["Client"].ToString();
                        oSheet.Cells[iRow, 5] = myReader1["City"].ToString();
                        oSheet.Cells[iRow, 6] = myReader1["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader1["Depth"].ToString();
                        oSheet.Cells[iRow, 8] = myReader1["Width"].ToString();
                        oSheet.Cells[iRow, 9] = myReader1["Hue"].ToString();
                        oSheet.Cells[iRow, 10] = myReader1["Page"].ToString();
                        oSheet.Cells[iRow, 11] = myReader1["Ins.No."].ToString();
                        oSheet.Cells[iRow, 12] = myReader1["RoNo."].ToString();
                        oSheet.Cells[iRow, 13] = myReader1["RoStatus"].ToString();
                        oSheet.Cells[iRow, 14] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 15] = myReader1["AdCat"].ToString();
                        oSheet.Cells[iRow, 16] = myReader1["RateCode"].ToString();
                        oSheet.Cells[iRow, 17] = myReader1["AgreedRate"].ToString();
                        oSheet.Cells[iRow, 18] = myReader1["Amt"].ToString();
                        oSheet.Cells[iRow, 19] = myReader1["Cap"].ToString();
                        oSheet.Cells[iRow, 20] = myReader1["Key"].ToString();


                    }

                    if (myReader1["Amt"].ToString() != "")
                        amt = amt + Convert.ToInt32(myReader1["Amt"].ToString());

                    iRow++;
                }
                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 17] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 18] = amt.ToString();
                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;


                myReader1.Close();
                myReader1 = null;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 misrep = new NewAdbooking.classesoracle.Class1();
                myReader = misrep.drillout_clientexcel(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString());


                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";
                // while(myReader.Read())
                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

                //oSheet.Cells[1, 7] = "All Ads OF A CLIENT";
                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[7].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[8].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[10].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[11].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[12].ToString();

                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[15].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[16].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 15] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 16] = pdfxml.Tables[0].Rows[0].ItemArray[20].ToString();

                    oSheet.Cells[3, 17] = pdfxml.Tables[0].Rows[0].ItemArray[22].ToString();
                    oSheet.Cells[3, 18] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 19] = pdfxml.Tables[0].Rows[0].ItemArray[26].ToString();
                    oSheet.Cells[3, 20] = pdfxml.Tables[0].Rows[0].ItemArray[27].ToString();




                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();

                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //  string total = "";
                int i1 = 1;
                //int finaltotal = 0;
                while (myReader.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader.FieldCount; k++)
                    {





                        oSheet.Cells[iRow, 2] = myReader["SAPID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader["Client"].ToString();
                        oSheet.Cells[iRow, 5] = myReader["City"].ToString();
                        oSheet.Cells[iRow, 6] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["Depth"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["Width"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["Hue"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["Page"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["Ins.No."].ToString();
                        oSheet.Cells[iRow, 12] = myReader["RoNo."].ToString();
                        oSheet.Cells[iRow, 13] = myReader["RoStatus"].ToString();
                        oSheet.Cells[iRow, 14] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 15] = myReader["AdCat"].ToString();
                        oSheet.Cells[iRow, 16] = myReader["RateCode"].ToString();
                        oSheet.Cells[iRow, 17] = myReader["AgreedRate"].ToString();
                        oSheet.Cells[iRow, 18] = myReader["Amt"].ToString();
                        oSheet.Cells[iRow, 19] = myReader["Cap"].ToString();
                        oSheet.Cells[iRow, 20] = myReader["Key"].ToString();


                    }

                    if (myReader["Amt"].ToString() != "")
                        amt = amt + Convert.ToInt32(myReader["Amt"].ToString());

                    iRow++;
                }
                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 17] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 18] = amt.ToString();
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
            oSheet.get_Range("A1", "S1").MergeCells = true;
            oSheet.get_Range("A1", "X1").Font.Bold = true;
            oSheet.get_Range("A1", "X1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;
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
            Response.Redirect("agencyclient.aspx");
        }
           
                 
            


          


    }
     * 
     * 
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
        //    string img = Server.MapPath("") + ("//") + "DSC00343 copy.bmp";
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
        //Graphic grx = new Graphic();
        //grx.lineTo(12, 12);
        int NumColumns = 20;
       
        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        //----------------------------------------
        


        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[10].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //grx.lineTo(30, 30);
            //---------------------------------------------
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

            //-----------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);


            datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
           // grx.lineTo(200, 800);
            //grx.drawBorder(30, 006);

            //float[] headerwidths = {13, 18, 19, 25,23, 13, 19, 17, 24, 24, 21, 30, 20,16, 23,21, 15, 16 ,13,14};


            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;


            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[12].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));       
           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);



            // document.Add(datatable);
            //datatable.DefaultCell.BorderWidth = 0;

            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


            ////float[] head ={ 8 };
            //datatable.setWidths(headerwidths);

           // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            // ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString());
           // ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Class1 misrep = new NewAdbooking.classesoracle.Class1();
                ds = misrep.drilloutclient(client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc,"","","","","");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "report_drillout_report_drillout_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { client, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package, Session["dateformat"].ToString(), descid, ascdesc, "", "", "", "", "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            int i1 = 1;
            int row = 0;
            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            //{
               // for (int a = 0; a <= 10; ++a)
               // {
                    //for (int column = 0; column < ds.Tables[0].Columns.Count; column++)
                    //{
            while (row < ds.Tables[0].Rows.Count)
            {
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][column].ToString(), font11));
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SAPID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
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
                    //datatable.HeaderRows = 1;

               // }

                //    break;
                    row++;


                //}
            }


            document.Add(datatable);
        

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 10, 16, 10, 8, 16, 20, 16, 10, 13, 10, 20 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
          
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            
            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
           
            document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName);


            //document.Add(datatable);
            //document.Close();
            //Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }





     


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


        string check = e.Item.Cells[17].Text;
        string amt = e.Item.Cells[17].Text;









        if (check != "Net Amt")
        {
            if (check != "&nbsp;")
            {


                string grossamt = e.Item.Cells[17].Text;
                comm1 = Convert.ToDouble(grossamt);
                comm2 = comm2 + comm1;

                //string arean = e.Item.Cells[8].Text;
                //areanew=areanew + Convert.ToDouble(arean);


            }
        }


        //area


        


    }
}