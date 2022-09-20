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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

public partial class payment_gatewayprev : System.Web.UI.Page
{
    public string mob1 = "";
    public string rono1 = "";
    public string amt1 = "";
    public string clientname = "";
    public string country = "";
    public string bok = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string rono = "";
        string amt = "";
        string add = "";
        string mob = "";
        Ajax.Utility.RegisterTypeForAjax(typeof(payment_gatewayprev));
        DataSet ds1 = new DataSet();
        DataSet ds12 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master name = new NewAdbooking.Classes.Master();

            ds1 = name.fetchdata(Session["compcode"].ToString(), Session["sesbooking"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master name = new NewAdbooking.classesoracle.Master();

            ds1 = name.fetchdata(Session["compcode"].ToString(), Session["sesbooking"].ToString());
        }

        if (ds1.Tables[0].Rows[0]["BOOKING"] != null)
        {
            rono1 = ds1.Tables[0].Rows[0]["BOOKING"].ToString();//Session["Ro_no"].ToString();
        }
        if (ds1.Tables[0].Rows[0]["BAP"] != null)
        {
            amt1 = ds1.Tables[0].Rows[0]["BAP"].ToString();
        }
        if (ds1.Tables[0].Rows[0]["Client"] != null)
        {
            clientname = ds1.Tables[0].Rows[0]["Client"].ToString();
        }
        if (ds1.Tables[0].Rows[0]["Client_address"] != null)
        {
            add = ds1.Tables[0].Rows[0]["Client_address"].ToString();
        }
        if (ds1.Tables[0].Rows[0]["MOBILENO"] != null)
        {
            mob = ds1.Tables[0].Rows[0]["MOBILENO"].ToString();
            mob1 = ds1.Tables[0].Rows[0]["MOBILENO"].ToString();
        }

        divmarue.InnerHtml = "Booking No :-" + " " + rono1 + " " + "," + "Amount :-" + " " + amt1 + " " + "," + "Name :-" + " " + clientname + " " + "," + "Mobile :-" + " " + mob;

        countryname();
        if (!Page.IsPostBack)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                // ds1 = clsbooking.saveonlinepaymentdetail(Session["compcode"].ToString(), code, msg, date, payid, rono, amt, mode, billname, billadd, billcity, billstate, billpin, billcountry, billphone, billemail, deliverybame, deladd, delcity, delstate, delpincode, delcountry, delphone, desc, flag, transacid, paymethod, reqid, securehash, rono);
                ds12 = clsbooking.saveonlinepaymenttem(Session["compcode"].ToString(), "", "", "", "", rono1, amt1, "", clientname, add, drpcity.SelectedValue, "", txtpincode.Text, txtcountry.SelectedValue, mob1, txtemail.Text, "", "", "", "", "", "", "", "", "Yes", "", "", "", "");
            }

            txtcountry.Attributes.Add("OnChange", "javascript:return addcount(this);");
            txtemail.Attributes.Add("onblur", "javascript:ClientEmailCheck(this);");
            //Button1.Attributes.Add("onclick", "javascript:submitdata();");
        }
        string hashmethod = Request.Form["hashmethod"];
        Response.Write(hashmethod);
        if (Request.HttpMethod == "POST")
        {
            string FormName = "form1";
            string Method = "post";


            string hashValue = "10431977e684095912d29ac87448e31a"; //secret key
            string V3URL = "https://secure.ebs.in/pg/ma/payment/request";


            string md5HashData = hashValue;
            List<KeyValuePair<string, string>> postparamslist = new List<KeyValuePair<string, string>>();

            for (int i = 0; i <= Request.Form.Keys.Count - 1; i++)
            {
                KeyValuePair<string, string> postparam = new KeyValuePair<string, string>(Request.Form.Keys[i], Request.Form[Request.Form.Keys[i]]);
                if (i >= 6 && Request.Form.Keys[i] != "submitted")
                {
                    postparamslist.Add(postparam);
                }
            }
            postparamslist.Sort((kv1, kv2) => kv1.Key.CompareTo(kv2.Key));

            foreach (KeyValuePair<string, string> param in postparamslist)
            {
                if (param.Key == "reference_no")
                {
                    md5HashData += "|" + ds1.Tables[0].Rows[0]["BOOKING"].ToString();
                }
                else if (param.Key == "amount")
                {
                    md5HashData += "|" + ds1.Tables[0].Rows[0]["BAP"].ToString();
                }
                else if (param.Key == "name")
                {
                    md5HashData += "|" + ds1.Tables[0].Rows[0]["Client"].ToString();
                }
                else if (param.Key == "phone")
                {
                    md5HashData += "|" + ds1.Tables[0].Rows[0]["MOBILENO"].ToString();
                }
                else if (param.Key == "channel")
                {
                    md5HashData += "|10";
                }
                else if (param.Key == "account_id")
                {
                    md5HashData += "|19828";
                }
                else if (param.Key == "mode")
                {
                    md5HashData += "|LIVE";
                }
                else if (param.Key == "currency")
                {
                    md5HashData += "|INR";
                }
                else if (param.Key == "description")
                {
                    md5HashData += "|Payment Done";
                }
                else if (param.Key == "hashmethod")
                {
                    md5HashData += "|MD5";
                }
                else
                {
                    md5HashData += "|" + param.Value;
                }
            }

            string hashedvalue = "";
            if (hashmethod == "MD5")
            {
                if (hashValue.Length > 0)
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        hashedvalue += GetMd5Hash(md5Hash, md5HashData);
                    }
                }
            }

            Response.Clear();
            Response.Write("<html><head>");
            Response.Write("<META HTTP-EQUIV=\\'CACHE-CONTROL\\' CONTENT=\\'no-store, no-cache, must-revalidate\\' />");
            Response.Write("<META HTTP-EQUIV=\\'PRAGMA\\' CONTENT=\\'no-store, no-cache, must-revalidate\\' />");
            Response.Write(string.Format("</head><body onload='document." + FormName + ".submit()'>"));
            Response.Write(string.Format("<form name='" + FormName + "' method='" + Method + "' action='" + V3URL + "' >"));
            foreach (KeyValuePair<string, string> param in postparamslist)
            {
                Response.Write("<input name='" + param.Key + "' type='hidden' value='" + param.Value + "' />");
            }
            // Response.Write("<input type=hidden' name='response' value='" & md5HashData & "'")
            Response.Write("<input type='hidden' name='secure_hash' value='" + hashedvalue + "' />");
            Response.Write("</form>");
            Response.Write("</body></html>");
            Response.End();
        }
    }
    public string GetMd5Hash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i <= data.Length - 1; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString().ToUpper();
    }
    public void countryname()
    {
        txtcountry.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master name = new NewAdbooking.Classes.Master();

            ds = name.adcountryname(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master name = new NewAdbooking.classesoracle.Master();

                ds = name.adcountryname(Session["compcode"].ToString());
            }
            else
            {
                NewAdbooking.classmysql.Master name = new NewAdbooking.classmysql.Master();
                ds = name.adcountryname(Session["compcode"].ToString());
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Country-----";
        li1.Value = "0";
        li1.Selected = true;
        txtcountry.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            txtcountry.Items.Add(li);
        }


    }
    [Ajax.AjaxMethod]
    public DataSet addcou(string txtcountry)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master firstAgency = new NewAdbooking.Classes.Master();

            ds = firstAgency.countcity(txtcountry);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master firstAgency = new NewAdbooking.classesoracle.Master();

                ds = firstAgency.countcity(txtcountry);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.Master firstAgency = new NewAdbooking.classmysql.Master();
                ds = firstAgency.countcity(txtcountry);
                return ds;
            }
    }

    protected void txtcountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}