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
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class executivereportview : System.Web.UI.Page
{

    int sno = 1;
    double amtsum = 0;
    string adtyp = "";
    string destination = "";

    double areasum1 = 0;
    double areasum1new = 0;
   
    string fromdt = "";
    string dateto = "";
  
    string date = "";
  
    string day = "";
    string month = "";
    string year = "";
 
    string pdfName1 = "";
   double amtnew = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string package = "";
    //int area = 0;
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    double ARR = 0;
    int i1 = 1;
    double amt = 0;
    string client = "";
    string agency = "";
    string publicationname = "";
    string publicationcode = "";
    string editionname1 = "";
    string editioncode = "";
    string adcatname1 = "";
    string adcatcode = "";
    string adtypename1 = "";
    string adtypecode = "";
    string teamname = "";
    string teamcode = "";
    string execname = "";
    string execcode = "";

    string adtypename = "";
    string editionname = "";
    string adcat = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string adcatname = "";
    string currency = "";

    string sortorder = "";
    string sortvalue = "";
    string pubcentcode = "", pubcentname = "";
    string page = "", region = "", rep = "", place = "", grp = "";
    string chk_excel = "";
    string name1 = "", name2 = "", name3 = "";
    DataSet ds;
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


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/categoryreport.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();

   
        ds = (DataSet)Session["exereport"];
        string prm = Session["prm_exereport"].ToString();
        string[] prm_Array = new string[35];
        prm_Array = prm.Split('~');

        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        teamcode = prm_Array[5]; //Request.QueryString["teamcode"].ToString();
        teamname = prm_Array[7]; //Request.QueryString["teamname"].ToString();
        execcode = prm_Array[9]; //Request.QueryString["repcode"].ToString();
        execname = prm_Array[11]; //Request.QueryString["repname"].ToString();
        adtypecode = prm_Array[13]; //Request.QueryString["adtypecode"].ToString();
        adtypename1 = prm_Array[15]; //Request.QueryString["adtypename"].ToString();
        destination = prm_Array[17]; //Request.QueryString["destination"].ToString();
        editioncode = prm_Array[19]; //Request.QueryString["editioncode"].ToString();
        adcatcode = prm_Array[21]; //Request.QueryString["adcatcode"].ToString();
        publicationcode = prm_Array[23]; //Request.QueryString["publicationcode"].ToString();
        publicationname = prm_Array[25]; //Request.QueryString["publicationname"].ToString();
        editionname1 = prm_Array[27]; //Request.QueryString["editionname"].ToString();
        adcatname1 = prm_Array[29]; //Request.QueryString["adcatname"].ToString();
        pubcentcode = prm_Array[31]; //Request.QueryString["pubcentcode"].ToString();
        pubcentname = prm_Array[33]; //Request.QueryString["pubcentname"].ToString();
        chk_excel = prm_Array[35];
        currency = prm_Array[36];

        Ajax.Utility.RegisterTypeForAjax(typeof(executivereportview));
        hiddendatefrom.Value = fromdt.ToString();

        if ((publicationcode == "0")||(publicationcode == ""))
        {
            lblpublication.Text = "ALL".ToString();
        }
        else
        {
            lblpublication.Text = publicationname.ToString();
        }

        if ((editioncode == "0")||(editioncode == ""))
        {
            lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname1.ToString();
        }

        if ((adcatcode == "0")||(adcatcode == ""))
        {
            lbladcat.Text = "ALL".ToString();
        }
        else
        {
            lbladcat.Text = adcatname1.ToString();
        }


        if ((adtypecode == "0")||(adtypecode == ""))
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypename1.ToString();
        }

        if ((teamcode == "0")||(teamcode == ""))
        {
            lblteam.Text = "ALL".ToString();
        }
        else
        {
            lblteam.Text = teamname.ToString();
        }

        if ((execcode == "0")||(execcode == ""))
        {
            lblexec.Text = "ALL".ToString();
        }
        else
        {
            lblexec.Text = execname.ToString();
        }
        

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

        lblrundate.Text = date.ToString();


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



        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(adtyp, adcat, fromdt, dateto, publ, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(adtyp, adcat, fromdt, dateto, publ, Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
            else
                if (destination == "3")
                {
                    pdf(adtyp, adcat, fromdt, dateto, publ, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
        }
        else if (hiddenascdesc.Value != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
                ds = obj.executive(fromdt, dateto, adtypecode, teamcode, execcode, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), adcatcode, publicationcode, editioncode, pubcentcode, Session["userid"].ToString(), Session["access"].ToString(),"");

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                string from_date = "";
                string to_date = "";
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    from_date = DMYToMDY(fromdt);
                    to_date = DMYToMDY(dateto);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    from_date = YMDToMDY(fromdt);
                    to_date = YMDToMDY(dateto);
                }
                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                //ds = obj.executive(from_date, to_date, dpdadtype.SelectedValue, dpteam.SelectedValue, hiddenexecutive.Value, Session["compcode"].ToString(), Session["dateformat"].ToString(), "", "", str, dppub1.SelectedValue, hiddenedition.Value, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
                ds = obj.executive(from_date, to_date, adtypecode, teamcode, execcode, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), adcatcode, publicationcode, editioncode, pubcentcode, Session["userid"].ToString(), Session["access"].ToString());
              }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "Executivereport";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { fromdt, dateto, adtypecode, teamcode, execcode, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), adcatcode, publicationcode, editioncode, pubcentcode, Session["userid"].ToString(), Session["access"].ToString(), "" };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            Session["exereport"] = ds;
            onscreen(adtyp, adcat, fromdt, dateto, publ, Session["compcode"].ToString(), Session["dateformat"].ToString());
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
   



    private void onscreen(string adtyp, string adcat, string fromdt, string dateto, string publ,  string compcode,  string dateformat)
    {
       
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    //ds = obj.spfun(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
        //    ds = obj.executive(fromdt, dateto, adtypecode, teamcode, execcode, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), adcatcode, publicationcode, editioncode, pubcentcode);
        //}
        string cu = Session["drpcurrency1234"].ToString();
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0' >";
     //   tbl = tbl + "<tr ><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        
        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td align='left' id='tdag~2' class='middle31new'onclick=sorting('Name',this.id)>Executive<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td align='left' id='tdag~4' class='middle31new'onclick=sorting('Category',this.id)>Ad Category<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td align='right'  class='middle31new'>GrossAmt</td><td align='right'  class='middle31new'>" + "" + "</td><td align='right'  class='middle31new'>Uom</td><td  align='right' class='middle31new'>Edition</td><td align='right'  class='middle31new'>Area</td><td align='right'  class='middle31new'>Yield</td></tr>");

        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td  align='left' id='tdag~2' class='middle31new'onclick=sorting('Name',this.id)>Executive<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td align='left' id='tdag~4' class='middle31new'onclick=sorting('Category',this.id)>Ad Category<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td  align='right' class='middle31new'>GrossAmt</td><td  align='right' class='middle31new'>Edition</td><td  align='right' class='middle31new'>Area</td><td align='right' class='middle31new'>Yield</td></tr>");


        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td align='left' id='tdag~2' class='middle31new'onclick=sorting('Name',this.id)>Executive<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td align='left' id='tdag~4' class='middle31new'onclick=sorting('Category',this.id)>Ad Category<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td  align='right' class='middle31new'>GrossAmt</td><td  align='right' class='middle31new'>Edition</td><td  align='right' class='middle31new'>Area</td><td align='right' class='middle31new'>Yield</td></tr>");

        }
        hiddenascdesc.Value = "";
        int j = 0;

        for (int i = 0; i <= cont - 1; i++)
        {

            /***********************          for subtotal       *********************/
            
            if (hiddencioid.Value == "Name")
            {
                            if (ds.Tables[0].Rows[i]["Name"].ToString() != ds.Tables[1].Rows[j]["Name"].ToString())
                            {
                                            tbl = tbl + ("<tr >");



                                            tbl = tbl + ("<td class='middle31new' colspan='2' valign='top'><b>");
                                            tbl = tbl + "Sub Total:" + "</b></td>";
                                            tbl = tbl + ("<td class='rep_data2' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                            
                                           
                                            
                                            tbl = tbl + ("<td class='middle31new' valign='top' align='right'><b>");
                                            if (cu != "All")
                                            {
                                                tbl = tbl + (Convert.ToDouble(ds.Tables[1].Rows[j]["GrossAmt"]).ToString("F2") + "</b></td>");
                                            }
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                          


                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";

                                            //=======================
                                            tbl = tbl + "</tr>";

                                            j++;
                            }
            }
            else
            {

                            if (ds.Tables[0].Rows[i]["Category"].ToString() != ds.Tables[1].Rows[j]["Category"].ToString())
                            {
                                            tbl = tbl + ("<tr >");



                                            tbl = tbl + ("<td class='middle31new' colspan='2' valign='top'><b>");
                                            tbl = tbl +  "</b></td>";
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                            
                                            tbl = tbl + ("<td class='middle31new' valign='top' align='right'><b>");
                                            
                                            if (cu != "All")
                                            {

                                            tbl = tbl + "Sub Total:" + (Convert.ToDouble(ds.Tables[1].Rows[j]["GrossAmt"]).ToString("F2") + "</b></td>");
                                            }
                                           
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";
                                            tbl = tbl + ("<td class='middle31new' valign='top'>");
                                            tbl = tbl + "" + "</td>";

                                           

                                            //=======================
                                            tbl = tbl + "</tr>";

                                            j++;
                            }
            }

            /***********************************************************************************************/


            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data' valign='top'>");
            tbl = tbl + (i1++.ToString() + "</td>");

            

            //string A_Place1 = "";
            //string rrr111 = ds.Tables[0].Rows[i]["Name"].ToString();
            //char[] A_Place = rrr111.ToCharArray();
            //int len11111 = A_Place.Length;
            //int line1111 = 0;
            //int ch_endp = 0;
            //int ch_strp = 0;
            //for (int ch1 = 0; ((ch1 < len11111) && (line1111 < 2)); ch1++)
            //{
            //    /**/
            //    ch_endp = ch_endp + 25;
            //    ch_strp = ch_endp;
            //    if (ch_endp > len11111)
            //        ch_strp = len11111 - ch1;
            //    else
            //        ch_strp = ch_endp - ch1;

            //    A_Place1 = A_Place1 + rrr111.Substring(ch1, ch_strp).Trim();
            //    A_Place1 = A_Place1 + "</br>";
            //    ch1 = ch1 + 40;
            //    if (ch1 > len11111)
            //        ch1 = len11111;/**/
            //}
            string exe_name = "";
            string rrr = ds.Tables[0].Rows[i]["Name"].ToString();
            if (rrr.Length >= 40)
            {
                exe_name = rrr.Substring(0, 40);
                if (rrr.Length - 40 < 40)
                    exe_name += "</br>" + rrr.Substring(40, rrr.Length - 40);
                else
                    exe_name += "</br>" + rrr.Substring(40, 40);
            }
            else
                exe_name = rrr;
            //----------------------------------------------------------------///


            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (exe_name + "</td>");


            
            string category_name = "";
            string rrr1 = ds.Tables[0].Rows[i]["Category"].ToString();
            if (rrr1.Length >= 30)
            {
                category_name = rrr1.Substring(0, 30);
                if (rrr1.Length - 30 < 30)
                    category_name += "</br>" + rrr1.Substring(30, rrr1.Length - 30);
                else
                    category_name += "</br>" + rrr1.Substring(30, 30);
            }
            else
                category_name = rrr1;
            //----------------------------------------------------------------///
            tbl = tbl + ("<td class='rep_data' align='left'width='80px' >");
            tbl = tbl + (category_name + "</td>");


            tbl = tbl + ("<td class='rep_data' valign='top' align='right' width='120'>");
            tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[i]["GrossAmt"]).ToString("F2") + "</td>");
            if (ds.Tables[0].Rows[i]["GrossAmt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["GrossAmt"].ToString());
            string cur = "";
            if (ds.Tables[0].Rows[i]["Currency"].ToString() == "DO0")
            {
                cur = "USD";
            }
            else
            {
                cur = "KYAT";
            }


            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");



            tbl = tbl + cur;


            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (string.Format("{0:0.00}", ds.Tables[0].Rows[i]["uom"]) + "</td>");
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (string.Format("{0:0.00}", ds.Tables[0].Rows[i]["edition"]) + "</td>");
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (string.Format("{0:0.00}",ds.Tables[0].Rows[i]["Area"]) + "</td>");
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

            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ARR"] + "</td>");
            if (ds.Tables[0].Rows[i]["ARR"].ToString() != "")
                ARR = ARR + double.Parse(ds.Tables[0].Rows[i]["ARR"].ToString());
          
            tbl = tbl + "</tr>";

           
        }


        /***********************          for subtotal       *********************/

      

            tbl = tbl + ("<tr >");

          

            tbl = tbl + ("<td class='rep_data2' colspan='2' valign='top'><b>");
            tbl = tbl +  "</b></td>";
            tbl = tbl + ("<td class='rep_data2' valign='top'>");
            tbl = tbl + "" + "</td>";
           
            tbl = tbl + ("<td class='rep_data2' valign='top' align='right'><b>");
            
            if (cu != "All")
            {
                tbl = tbl + "Sub Total:" + (Convert.ToDouble(ds.Tables[1].Rows[j]["GrossAmt"]).ToString("F2") + "</b></td>");
            }

        
            tbl = tbl + ("<td class='rep_data2' valign='top'>");
            tbl = tbl + "" + "</td>";

        
            tbl = tbl + ("<td class='rep_data2' valign='top'>");
            tbl = tbl + "" + "</td>";

            //=======================
            tbl = tbl + "</tr>";

            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle31new' >Total</td>");
           if (totrol > 0)
                {
                    tbl = tbl + ("<td class='middle31new' align='left' >");
                    tbl = tbl + "Lines:&nbsp&nbsp;" + (calf.ToString()) + "</td>";
                }
                else
                    tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
                if (totcd > 0)
                {
                    tbl = tbl + ("<td class='middle31new' align='left'>");
                    tbl = tbl + "Chars:&nbsp&nbsp;" + (calfd.ToString()) + "</td>";

                }
                else
                    tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");

                if (cu != "All")
                {

                    tbl = tbl + ("<td class='middle31new'  align='right'>" + (amt.ToString("F2")) + "</td>");
                }
            tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
            tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
            tbl = tbl + ("<td class='middle31new'  align='right'>Area:&nbsp;&nbsp;" + (cal.ToString("F2")) + "</td>");
           
                if (totcc > 0)
                {
                    tbl = tbl + ("<td class='middle31new' align='left'>");
                    tbl = tbl + "Words:&nbsp&nbsp;" + (calft.ToString()) + "</td>";

                }
                else
                    tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
                tbl = tbl + ("</tr >");
            
            
       // tbl = tbl + ("<tr >");
       // tbl = tbl + ("<tr >");
       // tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='6'>&nbsp;</b>");
       //// tbl = tbl + ((i1 - 1).ToString() );
       // tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
 
               
       // tbl = tbl + "<b>Total Gross Amount:</b>"+(amt.ToString("F2"));

       // tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
       // double cal = System.Math.Round(Convert.ToDouble(area), 2);
       // tbl = tbl + "<b>Total Area:</b>" + (cal.ToString());

       // if (totrol > 0)
       // {
       //     tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
       //     double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
       //     tbl = tbl + "<b>Total Lines:</b>"+(calf.ToString());
       // }
      
       // if (totcd > 0)
       // {
       //     tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
       //     double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
       //     tbl = tbl + "<b>Total Chars:</b>"+(calfd.ToString());
       // }
       
       // if (totcc > 0)
       // {
       //     tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
       //     double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
       //     tbl = tbl + "<b>Total Words:</b>"+(calft.ToString() + "</td>");
       // }
       


       // tbl = tbl + "</tr>";





  
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
       
        
    }

    private void excel(string adtyp, string adcat, string fromdt, string dateto, string publ, string compcode, string dateformat)
    {
        
        string cu = Session["drpcurrency1234"].ToString();
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        //NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
        //ds = obj.executive(fromdt, dateto, adtypecode, teamcode, execcode, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), adcatcode, publicationcode, editioncode, pubcentcode);
      
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
        nameColumn.HeaderText = "Executive";
        nameColumn.DataField = "Name";

        name1 = name1 + "," + "Executive";
        name2 = name2 + "," + "Name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Ad Category";
        nameColumn1.DataField = "Category";

        name1 = name1 + "," + "Ad Category";
        name2 = name2 + "," + "Category";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "GrossAmt";
        nameColumn2.DataField = "GrossAmt";

        name1 = name1 + "," + "GrossAmt";
        name2 = name2 + "," + "GrossAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn00 = new BoundColumn();
        nameColumn00.HeaderText = "currency";
        nameColumn00.DataField = "currency";

        name1 = name1 + "," + "currency";
        name2 = name2 + "," + "currency";
        name3 = name3 + "," + "";
        DataGrid1.Columns.Add(nameColumn00);

        
        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Area";
        nameColumn4.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);



        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = "Yield";
        nameColumn5.DataField = "ARR";

        name1 = name1 + "," + "Yield";
        name2 = name2 + "," + "ARR";
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
                hw.Write("<p <table border=\"1\"><tr><td colspan=\"8\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"8\"align=\"center\"><b>" + "Executive Wise Report" + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>" + "Pub Center:" + "</b>" + lblpublication.Text + "</td>");
                hw.Write("<p <td colspan=\"2\"align=\"left\"><b>" + "Edition:" + "</b>" + lbledition.Text + "</td>");
                hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Ad Category:" + "</b>" + lbladcat.Text + "</td></tr>");
                hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>" + "Ad Type:" + "</b>" + lbladtype.Text + "</td>");
                hw.Write("<p <td colspan=\"2\"align=\"left\"><b>" + "Team:" + "</b>" + lblteam.Text + "</td>");
                hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Executive:" + "</b>" + lblexec.Text + "</td></tr>");

                hw.Write("<p <tr><td colspan=\"2\"align=\"left\"><b>" + "From Date:" + "</b>" + lblfrom.Text + "</td>");
                hw.Write("<p <td colspan=\"2\"align=\"left\"><b>" + "To Date:" + "</b>" + lblto.Text + "</td>");
                hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Run Date:" + "</b>" + lblrundate.Text + "</td><tr>");

                hw.WriteBreak();

                DataGrid1.RenderControl(hw);


                int sno11 = sno - 1;


             if(cu=="All")
             {
                Response.Write(sw.ToString().Replace("</table>", "<tr><td ></td><td><b>Lines:</b>" + totrol + "</td><td><b>Chars:</b>" + totcd + "</td><td style='display:hidden'><b></b>" + "" +"</td><td><b></b>" + ""+ "</td><td><b>Area:</b>" + area + "</td><td><b>Words:</b>" + totcc + "</td></tr></table>"));
             }
             else{
                 Response.Write(sw.ToString().Replace("</table>", "<tr><td ></td><td><b>Lines:</b>" + totrol + "</td><td><b>Chars:</b>" + totcd + "</td><td style='visibility:hidden'><b>Amount:</b>" + amtnew + "</td><td><b></b>" + "" + "</td><td><b>Area:</b>" + area + "</td><td><b>Words:</b>" + totcc + "</td></tr></table>"));

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
         
        
        

    private void pdf(string adtyp, string adcat, string fromdt, string dateto, string publ, string compcode, string dateformat)
    {
        string cu = Session["drpcurrency1234"].ToString();
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/categoryreport.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        btnprint.Attributes.Add("onclick", "javascript:window.print();");
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        HeaderFooter footer = new HeaderFooter(new Phrase(i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();
        int NumColumns = 4;
        int NumColumns1 = 9;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

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
            //    ds = obj.executive(fromdt, dateto, adtypecode, teamcode, execcode, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), adcatcode, publicationcode, editioncode, pubcentcode);
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
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[17].ToString(), font9));
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
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(8);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            

            tbl2.addCell(new Phrase("Publication", font10));
            tbl2.addCell(new Phrase(lblpublication.Text, font11));
            tbl2.addCell(new Phrase("Edition", font10));
            tbl2.addCell(new Phrase(lbledition.Text, font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("Team", font10));
            tbl2.addCell(new Phrase(lblteam.Text, font11));



            tbl2.addCell(new Phrase("Ad Type", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));
            tbl2.addCell(new Phrase("Ad Category", font10));
            tbl2.addCell(new Phrase(lbladcat.Text, font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("Executive", font10));
            tbl2.addCell(new Phrase(lblexec.Text, font11));

            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns1);
            datatable.DefaultCell.Padding = 3;

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase("Executive", font10));
            datatable.addCell(new Phrase("Ad Category", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[17].ToString(), font10));

            datatable.addCell(new Phrase("currency".ToString(), font10));
            datatable.addCell(new Phrase("Uom".ToString(), font10));
            datatable.addCell(new Phrase("Edition".ToString(), font10));
            datatable.addCell(new Phrase("Area".ToString(), font10));
            datatable.addCell(new Phrase("Yield".ToString(), font10));
            
            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
           
          

            int row = 0;
            //int count = 0;
            int i1 = 1;
           

            /***************************         new          ****************************/
            int j = 0;


            while (row < ds.Tables[0].Rows.Count)
            {

                            if (hiddencioid.Value == "Name")
                            {
                                if (ds.Tables[0].Rows[row]["Name"].ToString() != ds.Tables[1].Rows[j]["Name"].ToString())
                                {
                                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                                      datatable.addCell(new Phrase("Sub Total:", font11));
                                    
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));

                                   
                                        datatable.addCell(new Phrase(chk_null(ds.Tables[1].Rows[j]["GrossAmt"].ToString()), font11));

                                    
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));


                                    j++;
                                
                                }
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[row]["Category"].ToString() != ds.Tables[1].Rows[j]["Category"].ToString())
                                {
                                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    datatable.addCell(new Phrase("", font11));
                                    if (cu != "All")
                                    {


                                        datatable.addCell(new Phrase("Sub Total:" + ds.Tables[1].Rows[j]["GrossAmt"].ToString(), font11));
                                        // datatable.addCell(new Phrase("", font11));
                                        //datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                    }
                                    else
                                    {

                                        // datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                        datatable.addCell(new Phrase("", font11));
                                    }
                                    
                                   




                                    j++;
                                }

                            }






                            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                            datatable.addCell(new Phrase(i1++.ToString(), font11));
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Name"].ToString(), font11));
                                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString(), font11));

                                
                                       datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["GrossAmt"].ToString()), font11));
                                   
                            string cur = "";
                            if (ds.Tables[0].Rows[row]["Currency"].ToString() == "DO0")
                            {
                                cur = "USD";
                            }
                            else
                            {
                                cur = "KYAT";
                            }
                datatable.addCell(new Phrase(cur, font11));
               
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["uom"].ToString(), font11));
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                            datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["Area"].ToString()), font11));
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ARR"].ToString(), font11));
                            if (cu != "All")
                            {
                                if (ds.Tables[0].Rows[row]["GrossAmt"].ToString() != "")

                                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["GrossAmt"].ToString());

                            }


                           
                            //if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                            //    area11 = area11 + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                            if ((ds.Tables[0].Rows[row]["Area"]).ToString() != "")
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
                                else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                                    totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());


                            }
                            row++;

            }



            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase("", font11));
            datatable.addCell(new Phrase("", font11));
            datatable.addCell(new Phrase("", font11));
            datatable.addCell(new Phrase("", font11));

            if (cu != "All")
            {
                datatable.addCell(new Phrase("Sub Total:" + chk_null(ds.Tables[1].Rows[j]["GrossAmt"].ToString()), font11));
               // datatable.addCell(new Phrase("", font11));
                //datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));


            }
            else
            {
                //datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));


            }

            

            /******************************************************************************/






            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);
           // PdfPTable tbltotal = new PdfPTable(18);
           // float[] headerwidths = { 14, 10, 8, 4, 2, 2, 14, 1, 10, 5, 8, 4, 4, 14, 4, 10,  8, 4 }; // percentage
           // tbltotal.setWidths(headerwidths);
           // tbltotal.DefaultCell.BorderWidth = 0;
           // tbltotal.WidthPercentage = 100;
           // tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
           // tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
           // tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
           // tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
           //// tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[66].ToString(), font10));
           //// tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
           // tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase("Amt:", font10));
           // tbltotal.addCell(new Phrase(" ", font11));
           //tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(amt.ToString(), font10));

           // tbltotal.addCell(new Phrase(" ", font11));
           //// tbltotal.addCell(new Phrase(" ", font11));
           
           // tbltotal.addCell(new Phrase("Area:", font10));
           // tbltotal.addCell(new Phrase(" ", font11));

           // tbltotal.addCell(new Phrase(area.ToString(), font11));


           // if (totrol > 0)
           // {
           //     tbltotal.addCell(new Phrase("Lines:", font11));
           //     double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
           //     tbltotal.addCell(new Phrase(calf.ToString(), font11));


           // }
           // else
           // {
           //     tbltotal.addCell(new Phrase(" ", font11));
           //     tbltotal.addCell(new Phrase(" ", font11));
           // }
           // if (totcd > 0)
           // {
           //     tbltotal.addCell(new Phrase("Chars:", font11));
           //     double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
           //     tbltotal.addCell(new Phrase(calfd.ToString(), font11));

           // }
           // else
           // {
           //     tbltotal.addCell(new Phrase(" ", font11));
           //     tbltotal.addCell(new Phrase(" ", font11));
           // }
           // if (totcc > 0)
           // {

           //     double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
           //     tbltotal.addCell(new Phrase("Words:", font11));
           //     tbltotal.addCell(new Phrase(calft.ToString(), font11));

           // }
           // else
           // {
           //     tbltotal.addCell(new Phrase(" ", font11));
           //     tbltotal.addCell(new Phrase(" ", font11));
           // }




           
          
           
           
           // document.Add(tbltotal);

           // document.Close();




            PdfPTable tbltotal = new PdfPTable(6);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
        //    tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase("Total", font11));

            if (totrol > 0)
            {
                //      tbltotal.addCell(new Phrase("Lines:", font11));
                      double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.addCell(new Phrase("Lines:" + calf.ToString(), font11));


            }
            else
            {
                //        tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }

            if (totcd > 0)
            {
        //        tbltotal.addCell(new Phrase("Chars:", font11));
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.addCell(new Phrase("Chars:"+calfd.ToString(), font11));

            }
            else
            {
         //       tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }

            tbltotal.addCell(new Phrase(chk_null(amt.ToString()), font10));
            tbltotal.addCell(new Phrase("Area:"+chk_null(area.ToString()), font11));

            if (totcc > 0)
            {

                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
           //     tbltotal.addCell(new Phrase("Words:", font11));
                tbltotal.addCell(new Phrase("Words:" + calft.ToString(), font11));

            }
            else
            {
         //       tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
          //  tbltotal.addCell(new Phrase("Area", font10));

          //  tbltotal.addCell(new Phrase(area.ToString(), font11));
      //      tbltotal.addCell(new Phrase("BillAmt", font10));


      //      tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));

            document.Add(tbltotal);
            document.Close();

            Session["drpcurrency1234"] = null;

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


        if (e.Item.Cells[4].Text == "DO0")
        {
            e.Item.Cells[4].Text = "USD";
        }
        else if (e.Item.Cells[4].Text == "KY0")
        {
            e.Item.Cells[4].Text = "KYAT";
           
        }
        
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
            
        

        string check11 = e.Item.Cells[5].Text;
        string areanew1 = e.Item.Cells[5].Text;

        if (check11 != "Area")
        {
            if (check11 != "&nbsp;")
            {


                string totalarea11 = e.Item.Cells[6].Text;
                areasum1 = Convert.ToDouble(totalarea11);
                areasum1new = areasum1new + areasum1;


            }
        }




    }
    protected void btnprint_Click(object sender, EventArgs e)
    {


       string ascdesc1 = hiddencioid.Value.Trim() ;
       string descid1 = hiddenascdesc.Value.Trim();
       Session["prm_exereport_print"] = "fromdate~" + fromdt + "~dateto~" + dateto + "~teamcode~" + teamcode + "~teamname~" + teamname + "~repcode~" + execcode + "~repname~" + execname + "~adtypecode~" + adtypecode + "~adtypename~" + adtypename1 + "~editioncode~" + editioncode + "~adcatcode~" + adcatcode + "~publicationcode~" + publicationcode + "~publicationname~" + publicationname + "~editionname~" + editionname1 + "~adcatname~" + adcatname1 + "~ascdesc1~" + ascdesc1 + "~descid1~" + descid1 + "~pubcentcode~" + pubcentcode + "~pubcentname~" + pubcentname;
            Response.Redirect("Executivereportprint.aspx");
//       Response.Redirect("Executivereportprint.aspx?&fromdate=" + fromdt + "&dateto=" + dateto + "&teamcode=" + teamcode + "&teamname=" + teamname + "&repcode=" + execcode + "&repname=" + execname + "&adtypecode=" + adtypecode + "&adtypename=" + adtypename1 + "&editioncode=" + editioncode + "&adcatcode=" + adcatcode + "&publicationcode=" + publicationcode + "&publicationname=" + publicationname + "&editionname=" + editionname1 + "&adcatname=" + adcatname1 + "&ascdesc1=" + ascdesc1 + "&descid1=" + descid1 + "&pubcentcode=" + pubcentcode + "&pubcentname=" + pubcentname);



    }
}
