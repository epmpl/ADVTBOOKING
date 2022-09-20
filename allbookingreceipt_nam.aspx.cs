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

public partial class allbookingreceipt_nam : System.Web.UI.Page
{
    string cioid = "";
    string mode = "";
    string cls_matter = "";
    string state1 = ""; string state2 = ""; string state3 = ""; string state4 = ""; string state5 = ""; string state6 = ""; string state7 = ""; string state8 = ""; string state9 = "";
    string state10 = "";
    string state11 = ""; string state12 = ""; string state13 = ""; string state14 = ""; string state15 = ""; string state16 = "";
    double detactiontotal = 0;
    double vattotal = 0;
    double sumtotal = 0;
    double finaltotal = 0;
    double discounttotal = 0;
    double addagencytotal = 0;
    double agencytotal = 0;
    string formname = "";
    string dateformate = "";
    double sum_amount_total = 0;
    double allsum_amount_total = 0;
    int comm_position = 0;
    double balance_amt = 0;
    string clntcd = "";
    string account_name_xml = "", bank_xml = "", account_no_xml = "", branch_name_xml = "", branh_code_xml = "", swift_xml = "";
    string account_name_xml_la = "", bank_xml_la = "", account_no_xml_la = "", branch_name_xml_la = "", branh_code_xml_la = "", swift_xml_la = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        formname = Request.QueryString["formname"].ToString();
        cioid = Request.QueryString["cioid"].ToString();
        //hiddenDateFormat.Value = Session["dateformat"].ToString();
        dateformate = Request.QueryString["dateformate"].ToString();
        hiddenDateFormat.Value = dateformate;
        getMatterPreview(cioid);
        if (Request.QueryString["mode"] != null)
        {
            mode = Request.QueryString["mode"].ToString();
        }
        if (Request.QueryString["clientcode"] != null)
        {
            clntcd = Request.QueryString["clientcode"].ToString();
        }
        if (formname == "BOOKING ORDER")
        {
            formname = "BOOKING";
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(allbookingreceipt_nam));
        DataSet ds_xml = new DataSet();
        ds_xml.ReadXml(Server.MapPath("XML/allbookingreceipt_nam.xml"));
        state1 = ds_xml.Tables[0].Rows[0].ItemArray[0].ToString();
        state2 = ds_xml.Tables[0].Rows[0].ItemArray[1].ToString();
        state3 = ds_xml.Tables[0].Rows[0].ItemArray[2].ToString();
        state4 = ds_xml.Tables[0].Rows[0].ItemArray[3].ToString();
        state5 = ds_xml.Tables[0].Rows[0].ItemArray[4].ToString();
        state6 = ds_xml.Tables[0].Rows[0].ItemArray[5].ToString();
        state7 = ds_xml.Tables[0].Rows[0].ItemArray[6].ToString();
        state8 = ds_xml.Tables[0].Rows[0].ItemArray[7].ToString();
        state9 = ds_xml.Tables[0].Rows[0].ItemArray[8].ToString();
        state10 = ds_xml.Tables[0].Rows[0].ItemArray[9].ToString();
        state11 = ds_xml.Tables[0].Rows[0].ItemArray[10].ToString();

        account_name_xml_la = ds_xml.Tables[0].Rows[0].ItemArray[12].ToString();
        account_name_xml = ds_xml.Tables[0].Rows[0].ItemArray[13].ToString();
        bank_xml_la = ds_xml.Tables[0].Rows[0].ItemArray[14].ToString();
        bank_xml = ds_xml.Tables[0].Rows[0].ItemArray[15].ToString();
        account_no_xml_la = ds_xml.Tables[0].Rows[0].ItemArray[16].ToString();
        account_no_xml = ds_xml.Tables[0].Rows[0].ItemArray[17].ToString();
        branch_name_xml_la = ds_xml.Tables[0].Rows[0].ItemArray[18].ToString();
        branch_name_xml = ds_xml.Tables[0].Rows[0].ItemArray[19].ToString();
        branh_code_xml_la = ds_xml.Tables[0].Rows[0].ItemArray[20].ToString();
        branh_code_xml = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
        swift_xml_la = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
        swift_xml = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();

        if (ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString() == "3")
        {
            comm_position = Convert.ToInt16(ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString());
        }

        onscreen(cioid, dateformate, "ORIGINAL");

        
       

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



    private void getMatterPreview(string booking_id)
    {
        DataSet dr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt objmatter = new NewAdbooking.Classes.classifiedreceipt();
            dr = objmatter.clsreceiptmatter(booking_id);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classifiedreceipt objmatter = new NewAdbooking.classesoracle.classifiedreceipt();
                dr = objmatter.clsreceiptmatter(booking_id);

            }
            else
            {
            }
        if (dr.Tables[0].Rows.Count > 0)
        {
            cls_matter = dr.Tables[0].Rows[0]["RTFformat"].ToString();
        }
        else
        {
            cls_matter = "";
        }
        if (dr.Tables[1].Rows.Count > 0)
        {
            cls_matter = dr.Tables[1].Rows[0]["RTFformat"].ToString();
        }
        else
        {
            cls_matter = "";
        }
    }

    public void onscreen(string cioid, string dateformat, string labelval)
    {

        DataSet ds = new DataSet();
        if (clntcd == "SP")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classifiedreceipt obj = new NewAdbooking.classesoracle.classifiedreceipt();
                ds = obj.selectreceipt_nb(cioid, dateformat);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.classifiedreceipt obj = new NewAdbooking.Classes.classifiedreceipt();
                ds = obj.selectreceipt_nb(cioid, dateformat);
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classifiedreceipt obj = new NewAdbooking.classesoracle.classifiedreceipt();
                ds = obj.selectreceipt(cioid, dateformat);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.classifiedreceipt obj = new NewAdbooking.Classes.classifiedreceipt();
                ds = obj.selectreceipt(cioid, dateformat);
            }
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
        mailbody = mailbody + "<tr height='15px'><td class='quotationnam'>&nbsp;</td></tr>";

        

        mailbody = mailbody + "<tr><td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'>&nbsp;</td><td class='quotationnam' align='right' style='font-size:20px'><b>" + formname + "&nbsp;&nbsp;&nbsp;</b></td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td></tr>";

        mailbody = mailbody + "<tr height='15px'><td class='quotationnam'>&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'>&nbsp;</td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>BOOKING ID:</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["CIOID"].ToString() + "</td></tr>";
        mailbody = mailbody + "<tr height='10px'><td class='quotationnam'><b>&nbsp;</b></td></tr>";
       // mailbody = mailbody + "<tr><td class='quotationnam'><b>&nbsp;TO:</b></td></tr>";
        //mailbody = mailbody + "<tr height='10px'><td class='quotationnam'>&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam' colspan='2' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Receipt No.</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["RECEIPT_NO"].ToString() + "</td></tr>";


        mailbody = mailbody + "<tr><td class='quotationnam' colspan='2' align='left'>&nbsp;" + ds.Tables[0].Rows[0]["Agen"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Customer No.</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["AGENCY_SUB_CODE"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam' colspan='2' align='left'>&nbsp;" + ds.Tables[0].Rows[0]["address"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Sales Person:</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["EXEC_NAME"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td colspan='2' class='quotationnam' align='left'>&nbsp;" + ds.Tables[0].Rows[0]["CITY_NAME"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Order No.</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["key_no"].ToString() + "</td></tr>";


        mailbody = mailbody + "<tr><td class='quotationnam' colspan='2' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Key No.:</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["rono"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam' colspan='2' align='left'>&nbsp;" + ds.Tables[0].Rows[0]["client"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Date:</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["BookDate"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td colspan='2' class='quotationnam' align='left'>&nbsp;" + ds.Tables[0].Rows[0]["Client2"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Ad Type :</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["adtype"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td colspan='2' class='quotationnam' align='left'>&nbsp;" + ds.Tables[0].Rows[0]["ph1"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>R.O No./Date :</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["rodate"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr height='10px'><td class='quotationnam'><b>&nbsp;</b></td></tr>";
        if (ds.Tables[0].Rows[0]["CONTACT_PERSON"].ToString() != "")
        {
            mailbody = mailbody + "<tr><td class='quotationnam' align='left'><b> &nbsp;Attn.: </b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["CONTACT_PERSON"].ToString() + "</td></tr>";
        }

        mailbody = mailbody + "<tr><td class='quotationnam' align='left'><b>&nbsp;Category :</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Ad Sub-Category :</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0].ItemArray[16].ToString() + "</td></tr>";

        if (ds.Tables[0].Rows[0]["PREMIUM_NAME"].ToString() == "NOTDEFINE" || ds.Tables[0].Rows[0]["PREMIUM_NAME"].ToString() == null)
        {
        mailbody = mailbody + "<tr><td class='quotationnam' align='left'><b>&nbsp;Caption :</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["caption"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td></tr>";
        }
        else
        {
        mailbody = mailbody + "<tr><td class='quotationnam' align='left'><b>&nbsp;Caption :</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["caption"].ToString() + "</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>&nbsp;</b></td><td class='quotationnam' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam' align='left'><b>Page Premium</b></td><td class='quotationnam' align='left'>" + ds.Tables[0].Rows[0]["PREMIUM_NAME"].ToString() + "</td></tr>";

        }

        
        mailbody = mailbody + "<tr height='10px'><td class='quotationnam'>&nbsp;</td></tr>";

        mailbody = mailbody + "</table>";

        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='0'>";

        mailbody = mailbody + "<tr height='20px'><td width='24%' class='quotationnam' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;' align='left'><b>&nbsp;PUBLICATION TYPE</b></td><td width='21%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>ISSUE DATE</b></td>";
        mailbody = mailbody + "<td width='15%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>COLOR</b><td width='10%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>SIZE</b></td></td>";
        mailbody = mailbody + "<td width='10%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>PAGE NO.</b></td><td width='10%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>PRICE</b></td><td width='10%' class='quotationnam' align='center' style='border-top:solid 1px black;border-bottom:solid 1px black;'><b>AMOUNT<b></td></tr>";

        if (ds.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {

                if (ds.Tables[0].Rows[0]["adtype"].ToString() == "CLASSIFIED")
                {
                    mailbody = mailbody + "<tr><td class='quotationnam' style='border-right:solid 1px black;' align='left'>&nbsp;&nbsp;" + ds.Tables[1].Rows[i]["package_name"].ToString() + "</td><td class='quotationnam' align='left' style='border-right:solid 1px black;'>&nbsp;&nbsp;" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";
                }
                else
                {
                    mailbody = mailbody + "<tr><td class='quotationnam' style='border-right:solid 1px black;' align='left'>&nbsp;&nbsp;" + ds.Tables[0].Rows[0]["adtype"].ToString() + "  :   " + ds.Tables[1].Rows[i]["package_name"].ToString() + "</td><td class='quotationnam' align='left' style='border-right:solid 1px black;'>&nbsp;&nbsp;" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";
                }
                mailbody = mailbody + "<td class='quotationnam' align='left' style='border-right:solid 1px black;'>&nbsp;&nbsp;" + ds.Tables[1].Rows[i]["Col_Alias"].ToString() + "</td><td class='quotationnam' align='left' style='border-right:solid 1px black;'>&nbsp;&nbsp;" + ds.Tables[1].Rows[i]["ad_size"].ToString() + "</td>";
                mailbody = mailbody + "<td class='quotationnam' align='center' style='border-right:solid 1px black;'>" + ds.Tables[1].Rows[i]["Page_No"].ToString() + "</td>";
                if (ds.Tables[1].Rows[i]["package_code"].ToString() == "NA0" || ds.Tables[1].Rows[i]["package_code"].ToString() == "WE0")
                {
                    mailbody = mailbody + "<td class='quotationnam' align='right' style='border-right:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[i]["solo_RATE"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td><td class='quotationnam' align='right'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[i]["gross_rate"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
                }
                else
                {
                    mailbody = mailbody + "<td class='quotationnam' align='right' style='border-right:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[i]["CARD_RATE"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td><td class='quotationnam' align='right'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[i]["card_amount"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
                }

                sum_amount_total = Convert.ToDouble(ds.Tables[1].Rows[i]["CARD_RATE"].ToString());
                allsum_amount_total = allsum_amount_total + sum_amount_total;

            }
        }

        mailbody = mailbody + "<tr height='50px;'><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td>";
        mailbody = mailbody + "<td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;</td><td style='border-bottom:solid 1px black;'>&nbsp;</td><tr>";

        if (ds.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString() == "0" || ds.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString() == "0.00" || ds.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>SPECIAL CHARGE </td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["SPECIAL_CHARGES"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
        }



        if (ds.Tables[0].Rows[0]["special_discount_amt"].ToString() == "0" || ds.Tables[0].Rows[0]["special_discount_amt"].ToString() == "0.00" || ds.Tables[0].Rows[0]["special_discount_amt"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>SPECIAL DISCOUNT ( " + ds.Tables[0].Rows[0]["Special_disc_per"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["special_discount_amt"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }

        discounttotal = Convert.ToDouble(ds.Tables[0].Rows[0]["special_discount_amt"].ToString());

        if (ds.Tables[0].Rows[0]["add_agency_comm_amt"].ToString() == "0" || ds.Tables[0].Rows[0]["add_agency_comm_amt"].ToString() == "0.00" || ds.Tables[0].Rows[0]["add_agency_comm_amt"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>ADDITIONAL AGENCY COMMISSION ( " + ds.Tables[0].Rows[0]["add_agency_comm"].ToString() + "%) &nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["add_agency_comm_amt"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }

        addagencytotal = Convert.ToDouble(ds.Tables[0].Rows[0]["add_agency_comm_amt"].ToString());

        if (ds.Tables[0].Rows[0]["ag_comm"].ToString() == "0" || ds.Tables[0].Rows[0]["ag_comm"].ToString() == "0.00" || ds.Tables[0].Rows[0]["ag_comm"].ToString() == null)
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'></td><td class='quotationnam' align='right' style='border-left:solid 1px black'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>AGENCY COMMISSION ( " + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%) &nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["ag_comm"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
        }

        agencytotal = Convert.ToDouble(ds.Tables[0].Rows[0]["ag_comm"].ToString());

        detactiontotal =  addagencytotal + agencytotal;
        sumtotal = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString());
        sumtotal = sumtotal - detactiontotal;
        vattotal = Convert.ToDouble(ds.Tables[0].Rows[0]["VAT_AMT"].ToString());
        finaltotal = sumtotal + vattotal;
        //***************************************other currency condition
        if (Convert.ToDouble(allsum_amount_total).ToString("F2") == "0.00" || Convert.ToDouble(allsum_amount_total).ToString("F2") == "0")
        {
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>SUM&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>VAT&nbsp;(" + ds.Tables[0].Rows[0]["VAT_PER"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>TO PAY&nbsp;(&nbsp;" + ds.Tables[0].Rows[0]["CURRENCY_SYMBOL"].ToString() + "&nbsp;)</td><td class='quotationnam' align='right' style='border-left:solid 1px black;border-bottom:solid 1px black'>&nbsp;</td></tr>";
        }
        else 
        {

            if (ds.Tables[0].Rows[0]["OTHER_CURR_LOCALGROSS"].ToString() != "0")
            {
                mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>SUM&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["OTHER_CURR_LOCALGROSS"].ToString()).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
            }
            else
            {
                mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>SUM&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(sumtotal).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
            }

            if (ds.Tables[0].Rows[0]["OTHER_CURR_VAT_AMT"].ToString() != "0")
            {
                mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>VAT&nbsp;(" + ds.Tables[0].Rows[0]["VAT_PER"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["OTHER_CURR_VAT_AMT"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
            }
            else
            {
                mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>VAT&nbsp;(" + ds.Tables[0].Rows[0]["VAT_PER"].ToString() + "%)&nbsp;</td><td class='quotationnam' align='right' style='border-left:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["VAT_AMT"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";

            }

            if (ds.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString() != "0")
            {
                mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>TO PAY&nbsp;(&nbsp;" + ds.Tables[0].Rows[0]["CURRENCY_SYMBOL"].ToString() + "&nbsp;)</td><td class='quotationnam' align='right' style='border-left:solid 1px black;border-bottom:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
            }
            else
            {
                mailbody = mailbody + "<tr><td colspan='3'></td><td colspan='3' class='quotationnam' align='right'>TO PAY&nbsp;(&nbsp;" + ds.Tables[0].Rows[0]["CURRENCY_SYMBOL"].ToString() + "&nbsp;)</td><td class='quotationnam' align='right' style='border-left:solid 1px black;border-bottom:solid 1px black'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(finaltotal).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
            }
        }
        mailbody = mailbody + "<tr height='7px'><td colspan='7' class='quotationnam' align='left' >&nbsp;</td></tr>";
        //******CONDITION FOR MATTER IN RECEIPT OR BOOKING ORDER  
        if (ds.Tables[0].Rows[0]["MATTER"].ToString() == null || ds.Tables[0].Rows[0]["MATTER"].ToString() == "" || formname == "RECEIPT")
        {
            mailbody = mailbody + "<tr><td colspan='5' class='quotationnam' align='left'></td></tr>";
        }
        else
        {
            mailbody = mailbody + "<tr><td colspan='7' class='quotationnam' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;'><b>Material :&nbsp;</b>" + ds.Tables[0].Rows[0]["MATTER"].ToString() + "</td></tr>";

        }
        //mailbody = mailbody + "<tr><td colspan='2' style='border-bottom:solid 1px black;'></td><td colspan='1'></td><td colspan='2' style='border-bottom:solid 1px black;'></td><td colspan='2'></td></tr>";
       // mailbody = mailbody + "<tr><td colspan='2' class='quotationnam' align='center'>SIGNATURE</td><td colspan='1'></td><td colspan='2' class='quotationnam' align='center'>DATE</td><td colspan='2'></td></tr>";

        
        mailbody = mailbody + "<tr><td colspan='7' class='quotationnam' align='left' >&nbsp;</td></tr>";
        //mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' ><b>&nbsp;" + state2 + "</b></td></tr>";
        //mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state3 + "</td></tr>";
        //mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;" + state4 + "</td></tr>";
        //mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr><td colspan='7' class='quotationnam' align='left' ><b>&nbsp;Cancellation:</b>"+ state2 +"</td></tr>";
        mailbody = mailbody + "<tr><td colspan='7' class='quotationnam' align='left' >&nbsp;"+ state3 +"</td></tr>";
        mailbody = mailbody + "<tr><td colspan='3' class='quotationnam' align='left' >&nbsp;" + state4 + "</td><td colspan='1'></td><td colspan='3' style='border-bottom:solid 1px black;'>&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td colspan='4' class='quotationnam' align='left' >&nbsp</td><td colspan='2' class='quotationnam' align='center'>SIGNATURE</td><td colspan='1' class='quotationnam' align='center'>DATE</td></tr>";
        mailbody = mailbody + "<tr><td colspan='7' class='quotationnam' align='right' >&nbsp;" + state1 + "&nbsp;</td></tr>";
        mailbody = mailbody + "</table>";
        mailbody = mailbody + "<table width='100%' cellspacing='0' cellpadding='0' border='0'>";

        mailbody = mailbody + "<tr height='10px'><td colspan='6' class='quotationnam' align='left' style='border-bottom:dotted 1px black' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr height='10px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";
        mailbody = mailbody + "<tr><td colspan='6' class='quotationnam' align='left' >&nbsp;"+ state5 +"</td></tr>";

        mailbody = mailbody + "<tr height='20px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";



        mailbody = mailbody + "<tr><td width='20%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Account Name</b></td><td width='35%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state6 + "</td>";
        mailbody = mailbody + "<td width='4%' class='quotationnam1' align='left'><b>&nbsp;</b></td><td width='3%' class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td width='18%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Booking ID</b></td><td width='20%' class='quotationnam1' align='left' style='border-top:solid 1px black;border-left:solid 1px black;'>&nbsp;" + ds.Tables[0].Rows[0]["CIOID"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Bank</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state7 + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Booking Date</b></td><td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + ds.Tables[0].Rows[0]["BookDate"].ToString() + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Branch</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state8 + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Tel. No.</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Account Number</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state9 + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";

        if (Convert.ToDouble(allsum_amount_total).ToString("F2") == "0.00" || Convert.ToDouble(allsum_amount_total).ToString("F2") == "0")
        {
            mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Due</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;</td></tr>";
            mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Branch Code</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state10 + "</td>";
            mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
            mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Paid</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;</td></tr>";
        }
        else
        {

            if (ds.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString() != "0")
            {
                mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Due</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString()).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
                balance_amt = Convert.ToDouble(ds.Tables[0].Rows[0]["OTHER_CURR_GROSS"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["RECEIPT_AMOUNT"].ToString());
            }
            else
            {
                mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Due</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(finaltotal).ToString("F2")), comm_position)  + "&nbsp;&nbsp;</td></tr>";
                balance_amt = Convert.ToDouble(Convert.ToDouble(finaltotal).ToString("F2")) - Convert.ToDouble(ds.Tables[0].Rows[0]["RECEIPT_AMOUNT"].ToString());
            }
            mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Branch Code</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state10 + "</td>";
            mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
            mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Amount Paid</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>" +Convert.ToDouble(ds.Tables[0].Rows[0]["RECEIPT_AMOUNT"].ToString()).ToString("F2") + "&nbsp;&nbsp;</td></tr>";
        }

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;Fax</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'>&nbsp;" + state11 + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left'><b>&nbsp;</b></td><td class='quotationnam1' align='left'>&nbsp;</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;Balance Amt.</b></td><td class='quotationnam1' align='right' style='border-bottom:solid 1px black;border-left:solid 1px black;'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(balance_amt).ToString("F2")), comm_position) + "&nbsp;&nbsp;</td></tr>";
        //****** new banking detail
        mailbody = mailbody + "<tr height='5px'><td colspan='6' class='quotationnam' align='left' >&nbsp;</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;" + account_name_xml_la + "</b></td><td class='quotationnam1'  align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;font-size:11.4px;' colspan='3'>&nbsp;" + account_name_xml + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;" + bank_xml_la + "</b></td><td class='quotationnam1' align='left' style='border-top:solid 1px black;border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + bank_xml + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;" + account_no_xml_la + "</b></td><td class='quotationnam1'  align='left' style='border-bottom:solid 1px black;' colspan='3'>&nbsp;" + account_no_xml + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;" + branch_name_xml_la + "</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + branch_name_xml + "</td></tr>";

        mailbody = mailbody + "<tr><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-right:solid 1px black;'><b>&nbsp;" + branh_code_xml_la + "</b></td><td class='quotationnam1'  align='left' style='border-bottom:solid 1px black;' colspan='3'>&nbsp;" + branh_code_xml + "</td>";
        mailbody = mailbody + "<td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'><b>&nbsp;" + swift_xml_la + "</b></td><td class='quotationnam1' align='left' style='border-bottom:solid 1px black;border-left:solid 1px black;'>&nbsp;" + swift_xml + "</td></tr>";

        //****** new banking detail
        mailbody = mailbody + "<tr height='10px'><td colspan='6'></td></tr>";
        mailbody = mailbody + "</table>";


        //************last table end************


        mailbody = mailbody + "</td>";
        mailbody = mailbody + "</tr>";
        mailbody = mailbody + "</table>";
        div1.Visible = true;
        div1.InnerHtml = mailbody;

//********last 
    }

}
