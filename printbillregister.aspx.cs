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

public partial class printbillregister : System.Web.UI.Page
{
    int maxlimit = 19;
    string dateto = "", fromdt = "", destination = "", region = "", regionname = "", edition = "", editionname = "", category = "", categorytext = "";
    string agencycat = "", adtypenew = "", publb = "", adtypename = "", agcattext = "", publicationcd = "";
    double BillAmt = 0;
    double agencomm = 0;
    int count1 = 0;
    int count2 = 0;
    int a = 0;
    string day = "", month = "", year = "", date = "";
   

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();

        hiddendateformat.Value = Session["dateformat"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
        destination = Request.QueryString["destination"].ToString();
        region = Request.QueryString["region"].ToString();
        regionname = Request.QueryString["regionname"].ToString();
        edition = Request.QueryString["edition"].ToString();
        editionname = Request.QueryString["editionname"].ToString();
        category = Request.QueryString["agtype"].ToString();
        categorytext = Request.QueryString["agtypetext"].ToString();
        agencycat = Request.QueryString["agcat"].ToString();
        adtypenew = Request.QueryString["adtype"].ToString();
        publb = Request.QueryString["publication1"].ToString();
        adtypename = Request.QueryString["adtypetext"].ToString();
        agcattext = Request.QueryString["agcattext"].ToString();
        publicationcd = Request.QueryString["publicationcd"].ToString();

        if (edition == "0")
        {
           lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname.ToString();
        }

        if (publicationcd == "0")
        {
            lblpublication.Text= "ALL".ToString();
        }
        else
        {
            lblpublication.Text = publb.ToString();
        }

      
        if (adtypenew == "0")
        {
            lbladtype.Text= "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypename.ToString();
        }


        if (region == "0")
        {
           lblregion.Text = "ALL".ToString();
        }
        else
        {
            lblregion.Text = regionname.ToString();
        }

        if (category == "0")
        {
          lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = categorytext.ToString();
        }

        if (agencycat == "0")
        {
           lblagcat.Text= "ALL".ToString();
        }
        else
        {
            lblagcat.Text = agcattext.ToString();
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
        lblfrom.Text = fromdt;
        lblto.Text = dateto;
        lbldate.Text = date;
 
        screen(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew);
   
    }
    public void screen(string fromdt,string dateto,string region,string edition,string category,string compcode,string dateformat,string agencycat,string adtypenew)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product = "";
       
        DataSet ds = new DataSet();
        NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
        if (category != "0")
            ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat);
        else
            ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);

        string TBL = "";
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
               
                    TBL += "</table>";
                    //TBL += "</br>";
                    TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                //    if (p==0)
                //{
                //     TBL += "<tr><td class='p_head' colspan='15'>Billing Register</td></tr>";
                   
                //}
                    TBL += "<tr valign='top'>";
                    TBL += "<td class='middle111' align='right' colspan='15'>" + "Page  " + s + "  of  " + pagecount;
                    TBL += "</td></tr>";

                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";

                    TBL += "<tr>";
                    TBL += "<td class='middle123' valign='top'>" + "S.No." + "</td>";
                    TBL += "<td class='middle123' align='left' valign='top'>" + "CIOID" + "</td>";
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Agency" + "</td>";
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Client" + "</td>";
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Publication" + "</td>";
                    TBL += "<td class='middle123' align='right' valign='top'>" + "Area" + "</td>";
                    TBL += "<td class='middle123' valign='top'>" + "Revenue" + "</br>" + "Center" + "</td>";
                    TBL += "<td class='middle123' valign='top'>" + "Rate" + "</td>";
                    TBL += "<td class='middle123' align='right' valign='top'>" + "Premium" + "</td>";
                    TBL += "<td class='middle123' valign='top'>" + "Bill" + "</br>" + "Remark" + "</td>";
                    TBL += "<td class='middle123' valign='top'>" + "Clr" + "</td>";
                    TBL += "<td class='middle123' valign='top'>" + "Catg" + "</br>" + "Subcat" + "</td>";
                    TBL += "<td class='middle123' valign='top'>" + "Package" + "</td>";
                    TBL += "<td class='middle123' align='right' valign='top'>" + "Bill" + "</br>" + "Amt" + "</td>";
                    TBL += "<td class='middle123' align='right' valign='top'>" + "Agen" + "</br>" + "Comm" + "</td>";
                    TBL += "</tr>";
                
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {
                    
                         a = d;
                        a = a + 1;

                        TBL += "<tr>";
                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (a.ToString() + "</td>");
                        TBL = TBL + ("<td class='rep_data' align='left'>");

                        string cid = "";
                        string rrr1 = ds.Tables[0].Rows[d]["CIOID"].ToString();
                        char[] cid1 = rrr1.ToCharArray();
                        int len111 = cid1.Length;
                        for (int ch1 = 0; ch1 < len111; ch1++)
                        {

                            if (ch1 == 0)
                            {
                                cid = cid + cid1[ch1];
                            }
                            else if (ch1 % 9 != 0)
                            {
                                cid = cid + cid1[ch1];
                            }
                            else
                            {

                                cid = cid + "</br>" + cid1[ch1];

                            }
                        }
                        TBL = TBL + (cid + "</td>");
                        TBL = TBL + ("<td class='rep_data' align='left'>");
                        //TBL = TBL + (ds.Tables[0].Rows[d]["Agency"] + "</td>");
                        string agency1 = "";
                        string rrr2 = ds.Tables[0].Rows[d]["Agency"].ToString();
                        char[] agency = rrr2.ToCharArray();
                        char[] ag = rrr2.ToCharArray();
                        int len222 = agency.Length;
                        int line22 = 0;
                        for (int ch1 = 0; ((ch1 < len222) && (line22 < 2)); ch1++)
                        {

                            if (ch1 == 0)
                            {
                                agency1 = agency1 + agency[ch1];
                            }
                            else if (ch1 % 15 != 0)
                            {
                                agency1 = agency1 + agency[ch1];
                            }
                            else
                            {
                                line22 = line22 + 1;
                                if (line22 != 2)
                                {
                                    agency1 = agency1 + "</br>" + agency[ch1];
                                }
                            }
                           
                        }

                        //for (int r = rrr2.Length-1 ; r > 1; r--)
                        //{
                        //    if (rrr2.IndexOf("-") >= 0)
                        //    {
                        //        agency1 = agency1 + "</br>" + ag[rrr2.IndexOf("-")];
                        //        break;
                        //    }
                        //}
                        
                        TBL = TBL + (agency1 + "</td>");




                        TBL = TBL + ("<td class='rep_data' align='left'>");
                       //TBL = TBL + (ds.Tables[0].Rows[d]["Client"] + "</td>");
                        string client1 = "";
                        string rrr3 = ds.Tables[0].Rows[d]["Client"].ToString();
                        char[] client = rrr3.ToCharArray();
                        int len333 = client.Length;
                        int line33 = 0;
                        for (int ch1 = 0; ((ch1 < len333) && (line33 < 2)); ch1++)
                        {

                            if (ch1 == 0)
                            {
                                client1 = client1 + client[ch1];
                            }
                            else if (ch1 % 15 != 0)
                            {
                                client1 = client1 + client[ch1];
                            }
                            else
                            {
                                line33 = line33 + 1;
                                if (line33 != 2)
                                {
                                    client1 = client1 + "</br>" + client[ch1];
                                }
                            }
                        }
                        TBL = TBL + (client1 + "</td>");
                        TBL = TBL + ("<td class='rep_data' align='left'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                        TBL = TBL + ("<td class='rep_data' align='right'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Area"] + "</td>");
                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");
                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Rate"] + "</td>");

                        TBL = TBL + ("<td class='rep_data' align='right'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Premium"] + "</td>");



                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["BillRemark"] + "</td>");

                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Color"] + "</td>");

                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Category"]);// + "</td>");
                        TBL = TBL + "</br>";
                        if (ds.Tables[0].Rows[d]["SubCategory"].ToString() == "0")
                            TBL = TBL + ("</td>");
                        else
                            TBL = TBL + (ds.Tables[0].Rows[d]["SubCategory"] + "</td>");

                        TBL = TBL + ("<td class='rep_data'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Package"] + "</td>");
                        TBL = TBL + ("<td class='rep_data' align='right'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["BillAmt"] + "</td>");
                        if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());

                        TBL = TBL + ("<td class='rep_data' align='right'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["AgencyComm"] + "</td>");
                        if (ds.Tables[0].Rows[d]["AgencyComm"].ToString() != "")
                            agencomm = agencomm + double.Parse(ds.Tables[0].Rows[d]["AgencyComm"].ToString());


                        if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["Rate"])
                            count1++;
                        if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Category"].ToString())
                            count2++;

                        TBL += "</tr>";

                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";
                        TBL += "<tr></tr>";

                  
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
               

            }
           
            //TBL += "</table>";
            //TBL += "<table>";

           // TBL = TBL + ("<tr >");

           
           // TBL = TBL + ("<tr >");
          //  TBL = TBL + ("<td class='middle13'>");
            TBL = TBL + ("<tr><td class='middle1212' align='left' ><b>Total Ads.</b></td>");
            TBL = TBL + ("<td class='middle1212'>");
            TBL = TBL + (a.ToString() + "</td>");
            TBL = TBL + ("<td class='middle1212'><b>FMG:</b>");
            TBL = TBL + (count1.ToString() + "</td>");
            TBL = TBL + ("<td class='middle1212' ><b>HouseAd:</b>");
            TBL = TBL + (count2.ToString() + "</td>");

            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");


            TBL = TBL + ("<td class='middle1212'><b>Total:</b></td>");
            TBL = TBL + ("<td class='middle1212' align='right'>");
            double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
            TBL = TBL + (cal.ToString() + "</td>");
            TBL = TBL + ("<td class='middle1212' align='right'  >");
            TBL = TBL + (agencomm.ToString() + "</td>");
            TBL = TBL + "</tr>";
            TBL += "</table>";
          
            div1.Visible = true;
            div1.InnerHtml = TBL;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }


}
