using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

public partial class response : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.HttpMethod == "POST")
        {
            List<KeyValuePair<string, string>> postlist = new List<KeyValuePair<string, string>>();

            for (int i = 0; i <= Request.Form.Keys.Count - 1; i++)
            {
                KeyValuePair<string, string> postparam = new KeyValuePair<string, string>(Request.Form.Keys[i], Request.Form[Request.Form.Keys[i]]);
                postlist.Add(postparam);

            }

            string imag = "Images/Untitled1.jpg";
            string imag1 = "Images/Untitled.jpg";
            string imag2 = "Images/Untitled2.jpg";
            //lblimg1.Text = "<img src='" + imag+"' alt=''/>";
            Response.Write("<div style='background-color:white;'>");
            Response.Write("<center><div><img src='" + imag1 + "' alt=''/><img src='" + imag2 + "' alt=''/><img src='" + imag + "' alt=''/></div>");
            Response.Write("<div style='background-color:white;'>");
            Response.Write("<center><div>LOKMAT MEDIA PVT. LTD</div>");
            Response.Write("<center><div style='font-size:11px;'>REGD. OFFICE 126,MITTAL TOWER, B WING, 12TH FLOOR,NARIMAN POINT, MUMBAI 400021</div>");
            Response.Write("<center><div><table style='width:100%;'><tr><td>CIN No.U99999MH1973PTC016613</td><td>INCOME TAX PAN No.AAACL1888J</td><td>Fax No.-07122545555</td></tr></table></div>");
            Response.Write("<center><div><table style='width:80%;'><tr><td>Email ID-classifieds@lokmat.com</td><td>Phone No. 07122423527(10 Lines)</td></tr></table></div>");
            Response.Write("<center><div style='background-color:white; box-shadow:5px 5px 5px 5px'>");
            Response.Write("<center><div style='background-color:lightblue'><h1> Response Details</h1><br></div><center><div><table>");

            foreach (KeyValuePair<string, string> param in postlist)
            {

                Response.Write("<tr>");
                Response.Write("<td>" + param.Key + "</td>");
                Response.Write("<td>" + param.Value + "</td>");
                Response.Write("</tr>");

                //Response.Write("<input name='" & param.Key & "' type='text' value='" & param.Value & "' />")
            }
            Response.Write("</table></<center><br><hr><hr><br></div>");
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            if (Request.Form["ResponseCode"] == "0") // update details in DB
            {
                //Response.Write(Request.Form["Amount"]);
                //Response.Write(Request.Form["MerchantRefNo"]);
                string rono = Request.Form["MerchantRefNo"]; string code = Request.Form["ResponseCode"]; string msg = Request.Form["ResponseMessage"];
                string date = Request.Form["DateCreated"]; string payid = Request.Form["PaymentId"]; string amt = Request.Form["Amount"];
                string mode = Request.Form["Mode"]; string billname = Request.Form["BillingName"]; string billadd = Request.Form["BillingAddress"];
                string billcity = Request.Form["BillingCity"]; string billstate = Request.Form["BillingState"]; string billpin = Request.Form["BillingPostalCode"];
                string billcountry = Request.Form["BillingCountry"]; string billphone = Request.Form["BillingPhone"]; string billemail = Request.Form["BillingEmail"];
                string deliverybame = Request.Form["DeliveryName"]; string deladd = Request.Form["DeliveryAddress"]; string delcity = Request.Form["DeliveryCity"];
                string delstate = Request.Form["DeliveryState"]; string delpincode = Request.Form["DeliveryPostalCode"]; string delcountry = Request.Form["DeliveryCountry"];
                string delphone = Request.Form["DeliveryPhone"]; string desc = Request.Form["Description"]; string flag = Request.Form["IsFlagged"];
                string transacid = Request.Form["TransactionID"]; string paymethod = Request.Form["PaymentMethod"]; string reqid = Request.Form["RequestID"];
                string securehash = Request.Form["SecureHash"];

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                    ds = clsbooking.updategetway("LOK01", rono);
                    ds1 = clsbooking.saveonlinepaymentdetail("LOK01", code, msg, "", payid, rono, amt, mode, billname, billadd, billcity, billstate, billpin, billcountry, billphone, billemail, deliverybame, deladd, delcity, delstate, delpincode, delcountry, delphone, desc, flag, transacid, paymethod, reqid, securehash);
                }
            }
            else
            {
                string rono = Request.Form["MerchantRefNo"]; string code = Request.Form["ResponseCode"]; string msg = Request.Form["ResponseMessage"];
                string date = Request.Form["DateCreated"]; string payid = Request.Form["PaymentId"]; string amt = Request.Form["Amount"];
                string mode = Request.Form["Mode"]; string billname = Request.Form["BillingName"]; string billadd = Request.Form["BillingAddress"];
                string billcity = Request.Form["BillingCity"]; string billstate = Request.Form["BillingState"]; string billpin = Request.Form["BillingPostalCode"];
                string billcountry = Request.Form["BillingCountry"]; string billphone = Request.Form["BillingPhone"]; string billemail = Request.Form["BillingEmail"];
                string deliverybame = Request.Form["DeliveryName"]; string deladd = Request.Form["DeliveryAddress"]; string delcity = Request.Form["DeliveryCity"];
                string delstate = Request.Form["DeliveryState"]; string delpincode = Request.Form["DeliveryPostalCode"]; string delcountry = Request.Form["DeliveryCountry"];
                string delphone = Request.Form["DeliveryPhone"]; string desc = Request.Form["Description"]; string flag = Request.Form["IsFlagged"];
                string transacid = Request.Form["TransactionID"]; string paymethod = Request.Form["PaymentMethod"]; string reqid = Request.Form["RequestID"];
                string securehash = Request.Form["SecureHash"];

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                    ds1 = clsbooking.saveonlinepaymentdetail("LOK01", code, msg, "", payid, rono, amt, mode, billname, billadd, billcity, billstate, billpin, billcountry, billphone, billemail, deliverybame, deladd, delcity, delstate, delpincode, delcountry, delphone, desc, flag, transacid, paymethod, reqid, securehash);
                }
                Response.Write("<h3>" + Request.Form["ResponseMessage"] + "</h3>");
            }

        }
        else
        {
            List<KeyValuePair<string, string>> postlist = new List<KeyValuePair<string, string>>();

            for (int i = 0; i <= Request.QueryString.Keys.Count - 1; i++)
            {
                KeyValuePair<string, string> postparam = new KeyValuePair<string, string>(Request.QueryString.Keys[i], Request.QueryString[Request.QueryString.Keys[i]]);
                postlist.Add(postparam);

            }
            Response.Write("<div style='background-color:white; box-shadow:5px 5px 5px 5px'>");
            Response.Write("<center><div style='background-color:lightblue'><h1> Response Details</h1><br></div><table width=600px>");

            foreach (KeyValuePair<string, string> param in postlist)
            {

                Response.Write("<tr>");
                Response.Write("<td>" + param.Key + "</td>");
                Response.Write("<td>" + param.Value + "</td>");
                Response.Write("</tr>");

                //Response.Write("<input name='" & param.Key & "' type='text' value='" & param.Value & "' />")
            }
            Response.Write("</table></<center><br><hr><hr><br></div>");
        }
    }
}