using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Web.Mail;

public partial class quotationprint_nam : System.Web.UI.Page
{
    string compcode = ""; string usercode = ""; string quotation = ""; string mainbookingid = "";
    string state1 = ""; string state2 = ""; string state3 = ""; string state4 = ""; string state5 = ""; string state6 = ""; string state7 = ""; string state8 = ""; string state9 = "";
    string state10 = "";
    string state11 = ""; string state12 = ""; string state13 = ""; string state14 = ""; string state15 = ""; string state16 = "";
    double sumtotal = 0;
    double detactiontotal = 0;
    double discounttotal = 0;
    double addagencytotal = 0;
    double agencytotal = 0;
    double vattotal = 0;
    double finaltotal = 0;
    double spechargetotal = 0;
    string dateformate = "";
    int comm_position = 0;
    string account_name_xml = "", bank_xml = "", account_no_xml = "", branch_name_xml = "", branh_code_xml = "", swift_xml = "";
    string account_name_xml_la = "", bank_xml_la = "", account_no_xml_la = "", branch_name_xml_la = "", branh_code_xml_la = "", swift_xml_la = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["compcode"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //    Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
        //    return;
        //}
        //hiddencompcode.Value = Session["compcode"].ToString();
        //hiddenuserid.Value = Session["userid"].ToString();
        //hiddenDateFormat.Value = Session["DateFormat"].ToString();
        //hiddenusername.Value = Session["Username"].ToString();
        //hiddencioidformat.Value = Session["cioid"].ToString();
        //Hiddencentercode.Value = Session["center"].ToString();

        //compcode = hiddencompcode.Value;
        //usercode = hiddenuserid.Value;


        compcode = Request.QueryString["compcode"].ToString();
        usercode = Request.QueryString["usercode"].ToString();
        dateformate = Request.QueryString["dateformate"].ToString();
        mainbookingid = Request.QueryString["mainbookingid"].ToString();
        quotation = Request.QueryString["quotation"].ToString();
        hiddenDateFormat.Value = dateformate;
        hiddencompcode.Value = Request.QueryString["compcode"].ToString();
        hiddenuserid.Value = Request.QueryString["usercode"].ToString();

        if (ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString() == "3")
        {
            comm_position = Convert.ToInt16(ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString());
        }


        Ajax.Utility.RegisterTypeForAjax(typeof(quotationprint_nam));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/quotationprint_nam.xml"));
        state1 =ds.Tables[0].Rows[0].ItemArray[28].ToString();
         state2 =ds.Tables[0].Rows[0].ItemArray[29].ToString();
         state3 =ds.Tables[0].Rows[0].ItemArray[30].ToString();
         state4 =ds.Tables[0].Rows[0].ItemArray[31].ToString();
         state5 =ds.Tables[0].Rows[0].ItemArray[32].ToString();
         state6 =ds.Tables[0].Rows[0].ItemArray[33].ToString();
         state7 =ds.Tables[0].Rows[0].ItemArray[34].ToString();
         state8 = ds.Tables[0].Rows[0].ItemArray[35].ToString();
         state9 = ds.Tables[0].Rows[0].ItemArray[36].ToString();
         state10 = ds.Tables[0].Rows[0].ItemArray[37].ToString();
         state11 = ds.Tables[0].Rows[0].ItemArray[38].ToString();
         state12 = ds.Tables[0].Rows[0].ItemArray[39].ToString();
         state13 = ds.Tables[0].Rows[0].ItemArray[40].ToString();
         state14 = ds.Tables[0].Rows[0].ItemArray[41].ToString();
         state15 = ds.Tables[0].Rows[0].ItemArray[42].ToString();
         state16 = ds.Tables[0].Rows[0].ItemArray[43].ToString();


         account_name_xml_la = ds.Tables[0].Rows[0].ItemArray[44].ToString();
         account_name_xml = ds.Tables[0].Rows[0].ItemArray[45].ToString();
         bank_xml_la = ds.Tables[0].Rows[0].ItemArray[46].ToString();
         bank_xml = ds.Tables[0].Rows[0].ItemArray[47].ToString();
         account_no_xml_la = ds.Tables[0].Rows[0].ItemArray[48].ToString();
         account_no_xml = ds.Tables[0].Rows[0].ItemArray[49].ToString();
         branch_name_xml_la = ds.Tables[0].Rows[0].ItemArray[50].ToString();
         branch_name_xml = ds.Tables[0].Rows[0].ItemArray[51].ToString();
         branh_code_xml_la = ds.Tables[0].Rows[0].ItemArray[52].ToString();
         branh_code_xml = ds.Tables[0].Rows[0].ItemArray[53].ToString();
         swift_xml_la = ds.Tables[0].Rows[0].ItemArray[54].ToString();
         swift_xml = ds.Tables[0].Rows[0].ItemArray[55].ToString();

        quotatinprintreport();
            







    }
    public string chkvalue(string val)
    {
        if (val == null || val == "")
            return "&nbsp;";
        else
            return val;
    }


    public string date_chk(string acc_date)
    {
        if (acc_date != "")
        {
            if (acc_date.IndexOf(" ") > -1)
            {
                string[] chk_str = acc_date.Split(' ');
                acc_date = chk_str[0];
            }

            if (hiddenDateFormat.Value == "dd/mm/yyyy")
            {
                string[] arr = acc_date.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                if (arr[0].Length < 2)
                    dd = "0" + arr[0];
                if (arr[1].Length < 2)
                    mm = "0" + arr[1];
                acc_date = mm + "/" + dd + "/" + yy;

            }
            else
            {
                string[] arr = acc_date.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                if (arr[0].Length < 2)
                    dd = "0" + arr[0];
                if (arr[1].Length < 2)
                    mm = "0" + arr[1];
                acc_date = mm + "/" + dd + "/" + yy;
            }

        }
        return acc_date;
    }


    public void quotatinprintreport()
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
            ds1 = bind.getmailheader(compcode, usercode, mainbookingid);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
            ds1 = bindrate.getmailheader(compcode, usercode, mainbookingid);
        }

        DataSet ds2 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adbooking bind = new NewAdbooking.Classes.adbooking();
            ds2 = bind.getmaildetail(compcode, usercode, mainbookingid);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adbooking bindrate = new NewAdbooking.classesoracle.adbooking();
            ds2 = bindrate.getmaildetail(compcode, usercode, mainbookingid);
        }


        string mailbody = "";

        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='1'>";
        mailbody = mailbody + "<tr>";
        mailbody = mailbody + "<td>";
        //*************************************

      
        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='0'>";
        mailbody = mailbody + "<tr>";
        mailbody = mailbody + "<td width='100%' align='center' class='quotationnam' style='border-bottom:solid 1px black'><img height='150px' src='Images/rikkee.gif'></td>";
        mailbody = mailbody + "</tr>";
        mailbody = mailbody + "</table>";
       
        //*************header  end  order start********
        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='0'>";
        mailbody = mailbody + "<tr height='10px'><td colspan='3' class='quotationnam' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td align='center' colspan='3' class='quotationnam' style='font-size:17px'><b>PROFORMA INVOICE / QUOTATION</b></td></tr>";
        mailbody = mailbody + "<tr height='10px' width='100%'><td colspan='3' class='quotationnam'><b>&nbsp;</b></td></tr>";

        mailbody = mailbody + "<tr height='10px'><td colspan='3' class='quotationnam' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>QUOTATION NR:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["QUOTATION_NO"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr height='10px'><td colspan='3' class='quotationnam' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;TO:</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>VAT Reg No:</b></td><td width='20%' class='quotationnam' align='left' >1912599-01-05</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;" + ds1.Tables[0].Rows[0]["Agency_Name"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Customer No.</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["AGENCY_SUB_CODE"].ToString() + "</td></tr>";


        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;" + ds1.Tables[0].Rows[0]["AG_ADDRESS"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Sales Person:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["EXEC_NAME"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;" + ds1.Tables[0].Rows[0]["CITY_NAME"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Contact Detail:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["PHONE1"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Email Id:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["EXEC_EMAILID"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;" + ds1.Tables[0].Rows[0]["CLIENT_NAME"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>CI / PO Number:</b></td><td width='20%' class='quotationnam' align='left' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp" + ds1.Tables[0].Rows[0]["CUST_ADDRESS"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Date:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["QUOTATION_DATE"].ToString() + "</td></tr>";


        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' >&nbsp;Att:&nbsp;" + ds1.Tables[0].Rows[0]["CONTACT_PERSON"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Valid Until:</b></td><td width='20%' class='quotationnam' align='left' >" + (date_chk(ds1.Tables[0].Rows[0]["QUOTATION_VALID_DATE"].ToString())) + "</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' ><b>&nbsp;Payment Terms:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds1.Tables[0].Rows[0]["PAYMENT_TERMS"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Ad Type:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["AD_TYPE_CODE"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' ><b>&nbsp;Ad Category:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds1.Tables[0].Rows[0]["CATEGORY_NAME"].ToString() + "</td>";
        mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Ad Sub Category:</b></td><td width='20%' class='quotationnam' align='left' >" + ds1.Tables[0].Rows[0]["SUB_CATEGORY_NAME"].ToString() + "</td></tr>";


      if (ds1.Tables[0].Rows[0]["PREMIUM_NAME"].ToString() == "NOTDEFINE" || ds1.Tables[0].Rows[0]["PREMIUM_NAME"].ToString() == null)
        {

            mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' ><b>&nbsp;Caption&nbsp;/&nbsp;Narrative:</b>&nbsp;" + ds1.Tables[0].Rows[0]["CAPTION"].ToString() + "</td>";
            mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>&nbsp;</b></td><td width='20%' class='quotationnam' align='left'>&nbsp;</td></tr>";

         }
       else
         {
             mailbody = mailbody + "<tr width='100%'><td class='quotationnam' width='60%' align='left' ><b>&nbsp;Caption &nbsp;/&nbsp;Narrative:</b>&nbsp;" + ds1.Tables[0].Rows[0]["CAPTION"].ToString() + "</td>";
             mailbody = mailbody + "<td width='20%' class='quotationnam' align='left'><b>Page Premium:</b></td><td width='20%' class='quotationnam' align='left'>" + ds1.Tables[0].Rows[0]["PREMIUM_NAME"].ToString() + "</td></tr>";
          
        }

      mailbody = mailbody + "<tr height='15px'><td colspan='3' class='quotationnam'>&nbsp;</td></tr>";
        mailbody = mailbody + "</table>";
        //**********************************
                    
       
       // mailbody = mailbody + "<tr height='15px'><td class='quotationnam'>&nbsp;</td></tr>";
       // mailbody = mailbody + "</table>";
        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='0'>";

        mailbody = mailbody + "<tr height='20px'><td width='42%' class='quotationnam' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;' align='left'><b>&nbsp;PUBLICATION TYPE</b></td><td width='11%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>ISSUE DATE</b></td>";
        mailbody = mailbody + "<td width='14%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>COLOR</b><td width='11%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>SIZE</b></td></td>";
        mailbody = mailbody + "<td width='11%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>PRICE</b></td><td width='11%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;'><b>AMOUNT<b></td></tr>";

        if (ds2.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                mailbody = mailbody + "<tr><td class='quotationnam' style='border-right:solid 1px black;' align='left'>&nbsp;" + ds2.Tables[0].Rows[i]["package_desc"].ToString() + "</td><td class='quotationnam' align='center' style='border-right:solid 1px black;'>" + ds2.Tables[0].Rows[i]["Insertion_date"].ToString() + "</td>";
                mailbody = mailbody + "<td class='quotationnam' align='center' style='border-right:solid 1px black;'>" + ds2.Tables[0].Rows[i]["Color_Name"].ToString() + "</td><td class='quotationnam' align='center' style='border-right:solid 1px black;'>" + ds2.Tables[0].Rows[i]["SIZE"].ToString() + "</td>";
                if (ds1.Tables[0].Rows[0]["rate_code"].ToString() == "COMBO" || ds2.Tables[0].Rows[0]["PACKAGE_CODE"].ToString() == "WE0")
                {
                    mailbody = mailbody + "<td class='quotationnam' align='right' style='border-right:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds2.Tables[0].Rows[i]["solo_Rate"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td><td class='quotationnam' align='right'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(ds2.Tables[0].Rows[i]["gross_rate"].ToString()), comm_position) + "&nbsp;&nbsp;</td></tr>";
                }
                else
                {
                    mailbody = mailbody + "<td class='quotationnam' align='right' style='border-right:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds2.Tables[0].Rows[i]["Deal_Rate"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td><td class='quotationnam' align='right'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(ds2.Tables[0].Rows[i]["CONTRACT_AMOUNT"].ToString()), comm_position) + "&nbsp;&nbsp;</td></tr>";
                }


            }
        }

        mailbody = mailbody + "<tr height='50px;'><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td>";
        mailbody = mailbody + "<td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;'>&nbsp;</td><tr>";


        if (ds1.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString() == "0" || ds1.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString() == "0.00" || ds1.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>SPECIAL CHARGE </td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
        }

        spechargetotal = Convert.ToDouble(ds1.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString());

        if (ds1.Tables[0].Rows[0]["special_discount_amt"].ToString() == "0" || ds1.Tables[0].Rows[0]["special_discount_amt"].ToString() == "0.00" || ds1.Tables[0].Rows[0]["special_discount_amt"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";   
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>SPECIAL DISCOUNT (" + ds1.Tables[0].Rows[0]["special_discount_per"].ToString() + " %)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["special_discount_amt"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
        }
        discounttotal = Convert.ToDouble(ds1.Tables[0].Rows[0]["special_discount_amt"].ToString());

        if (ds1.Tables[0].Rows[0]["add_agency_comm_amt"].ToString() == "0" || ds1.Tables[0].Rows[0]["add_agency_comm_amt"].ToString() == "0.00" || ds1.Tables[0].Rows[0]["add_agency_comm_amt"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";

        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>ADDITIONAL AGENCY COMMISSION (" + ds1.Tables[0].Rows[0]["add_agency_comm"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["add_agency_comm_amt"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
        }
        addagencytotal = Convert.ToDouble(ds1.Tables[0].Rows[0]["add_agency_comm_amt"].ToString());

        if (ds1.Tables[0].Rows[0]["ag_comm"].ToString() == "0" || ds1.Tables[0].Rows[0]["ag_comm"].ToString() == "0.00" || ds1.Tables[0].Rows[0]["ag_comm"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>AGENCY COMMISSION(" + ds1.Tables[0].Rows[0]["trade_disc"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["ag_comm"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }
        agencytotal = Convert.ToDouble(ds1.Tables[0].Rows[0]["ag_comm"].ToString());

        detactiontotal = addagencytotal + agencytotal;

        sumtotal = Convert.ToDouble(ds1.Tables[0].Rows[0]["GROSS_AMOUNT"].ToString());
        sumtotal = sumtotal - detactiontotal;
        vattotal = Convert.ToDouble(ds1.Tables[0].Rows[0]["VAT_AMOUNT"].ToString());
        finaltotal = sumtotal + vattotal;

        //***************************************other currency condition

        if (ds1.Tables[0].Rows[0]["OTHER_CURR_LOCALGROSS"].ToString() != "0")
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>SUM&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["OTHER_CURR_LOCALGROSS"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>SUM&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(sumtotal).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }


        if (ds1.Tables[0].Rows[0]["OTHER_CURR_VAT_AMT"].ToString() != "0")
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>VAT&nbsp;(" + ds1.Tables[0].Rows[0]["VAT_PER"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["OTHER_CURR_VAT_AMT"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>VAT&nbsp;(" + ds1.Tables[0].Rows[0]["VAT_PER"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["VAT_AMOUNT"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }

        if (ds1.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString() != "0")
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>TO PAY&nbsp;(&nbsp;" + ds1.Tables[0].Rows[0]["CURRENCY_SYMBOL"].ToString() + "&nbsp;)</td><td class='quotationnam' align='right' style='border-left:solid 1px black;border-bottom:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='2'></td><td colspan='3' class='quotationnam' align='right'>TO PAY&nbsp;(&nbsp;" + ds1.Tables[0].Rows[0]["CURRENCY_SYMBOL"].ToString() + "&nbsp;)</td><td class='quotationnam' align='right' style='border-left:solid 1px black;border-bottom:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(finaltotal).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }

        mailbody = mailbody + "<tr height='3px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";

        if (ds1.Tables[0].Rows[0]["MATTER"].ToString() == null || ds1.Tables[0].Rows[0]["MATTER"].ToString() == "" )
        {
            mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;'><b>Material :&nbsp;</b>" + ds1.Tables[0].Rows[0]["MATTER"].ToString() + "</td></tr>";

        }

        mailbody = mailbody + "<tr height='25px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td colspan='2' style='border-bottom:solid 1px black;'></td><td colspan='1'></td><td colspan='2' style='border-bottom:solid 1px black;'></td><td colspan='1'></td></tr>";
        mailbody = mailbody + "<tr><td colspan='2' class='quotationnam' align='center'>SIGNATURE</td><td colspan='1'></td><td colspan='2' class='quotationnam' align='center'>DATE</td><td colspan='1'></td></tr>";

        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + ds1.Tables[0].Rows[0]["PAYMENT_TERMS_DESC"].ToString() + "</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' ><b>&nbsp;" + state2 + "</b></td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state3 + "</td></tr>";
       // mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state4 + "</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' ><b>&nbsp;Cancellation:&nbsp;</b>" + state5 + "</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state6 + "</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state7 + "</td></tr>";

        mailbody = mailbody + "</table>";
        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='0'>";

        mailbody = mailbody + "<tr height='10px'><td colspan='6' class='quotationnam' align='left' style='border-bottom:dotted 1px black' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr height='10px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state10 + "</td></tr>";

        mailbody = mailbody + "<tr height='10px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";



        mailbody = mailbody + "<tr><td width='20%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Account Name</b></td><td width='35%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state11 + "</td>";
        mailbody = mailbody + "<td width='4%' class='quotationnam1' align='left'><b>&nbsp;</b></td><td width='3%' class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td width='18%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Quotation Nr.</b></td><td width='20%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-left:solid 1px black;'>&nbsp;" + ds1.Tables[0].Rows[0]["QUOTATION_NO"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Bank</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;"+ state12 +"</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Quotation Date</b></td><td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + date_chk(ds1.Tables[0].Rows[0]["QUOTATION_DATE"].ToString()) + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Branch</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;"+ state13 +"</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Tel. No.</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + ds1.Tables[0].Rows[0]["PHONE1"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Account Number</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;"+ state14 +"</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        if (ds1.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString() != "0")
        {
            mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Due</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds1.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }
        else
        {
            mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Due</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(finaltotal).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
        }
        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Branch Code</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;"+ state15 +"</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Paid</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Fax</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state16 + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;</td></tr>";


        mailbody = mailbody + "<tr height='5px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;" + account_name_xml_la + "</b></td><td class='quotationnam1'  align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;font-size:11.4px;' colspan='3'>&nbsp;" + account_name_xml + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;" + bank_xml_la + "</b></td><td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + bank_xml + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;" + account_no_xml_la + "</b></td><td class='quotationnam1'  align='left' style='border-bottom:solid 1px black;' colspan='3'>&nbsp;" + account_no_xml + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;" + branch_name_xml_la + "</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + branch_name_xml + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;" + branh_code_xml_la + "</b></td><td class='quotationnam1'  align='left' style='border-bottom:solid 1px black;' colspan='3'>&nbsp;" + branh_code_xml + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;" + swift_xml_la + "</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + swift_xml + "</td></tr>";

        mailbody = mailbody + "<tr height='10px'><td colspan='6'></td></tr>";
        mailbody = mailbody + "</table>";


        //************last table end************


        mailbody = mailbody + "</td>";
        mailbody = mailbody + "</tr>";
        mailbody = mailbody + "</table>";
        div1.Visible = true;
        div1.InnerHtml = mailbody;



    }




}
