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
using System.Text.RegularExpressions;
public partial class Invoice_cancellation : System.Web.UI.Page
{
    static string YMDToMDY(string input)
    {

        if (input != "")
            return Regex.Replace(input,
                "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
                "${month}/${day}/${year}");
        else
            return input;
    }
    static string DMYToMDY(string input)
    {

        if (input != "")
            return Regex.Replace(input,
                "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
                "${month}/${day}/${year}");
        else
            return input;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] != null)
        {
            hdncompcode.Value = Session["compcode"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdnuserid.Value = Session["userid"].ToString();


            hiddendateformat.Value = Session["dateformat"].ToString();
         //   hiddencomcode.Value = Session["compcode"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Invoice_cancellation));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Invoice_cancellation.xml"));
        lblcompcode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcompname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblunitcode.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblunitname.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblvouchertyp.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblvoucherdt.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblvoucherno.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblrcptno.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblremark.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //lbl_rcptno.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbl_rcptdt.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        //lbl_voucherno.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        //lbl_voucherdt.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbl_rono.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        //lbl_vouchertyp.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //lbl_rcptto.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lbl_agcl.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        //lbl_glcode.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        //lbl_creditday.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        //lbl_oppositeac.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        //lbl_netamt.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        //lbl_actype.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        btn_query.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        btn_delete.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        btn_clear.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        btn_exit.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lbl_billno.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lbl_billdt.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lblunit.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        lbl_recno.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbl_recdt.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lblrodate.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        if (!IsPostBack)
        {
            bindvouchertype();
            txtunitcode.Attributes.Add("onkeydown", "javascript:return fillunit(event);");
            lstunit.Attributes.Add("onkeydown", "javascript:return onclickunit(event);");
            lstunit.Attributes.Add("onclick", "javascript:return onclickunit(event);");

            txtvoucherno.Attributes.Add("onkeydown", "javascript:return fillvoucher(event);");
            lstvoucherno.Attributes.Add("onkeydown", "javascript:return onclickvoucher(event);");
            lstvoucherno.Attributes.Add("onclick", "javascript:return onclickvoucher(event);");

            txtrcptno.Attributes.Add("onkeydown", "javascript:return fillrcptno(event);");
            lstrcptno.Attributes.Add("onkeydown", "javascript:return onclickrcptno(event);");
            lstrcptno.Attributes.Add("onclick", "javascript:return onclickrcptno(event);");

            btn_query.Attributes.Add("onclick", "javascript:return click_query();");
            btn_delete.Attributes.Add("onclick", "javascript:return click_voucherdelete();");
            btn_clear.Attributes.Add("onclick", "javascript:return click_clear();");
            btn_exit.Attributes.Add("onclick", "javascript:return click_exit();");

            txtvoucherdt.Attributes.Add("onblur", "javascript:return isDate(this.value,this.id,document.getElementById('hiddendateformat'),document.getElementById('hiddendateformat').value)");
        }
    }
    [Ajax.AjaxMethod]
    public DataSet bindunit(string compcode ,string citycode,string dateformat,string extra1,string extra2 )
    {

       
		  
		  //  var citycode = "";

           

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.voucher_deletion logindetail = new NewAdbooking.Classes.voucher_deletion();

            ds = logindetail.getbranch(compcode, citycode, dateformat, "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.voucher_deletion logindetail = new NewAdbooking.classesoracle.voucher_deletion();
            ds = logindetail.getbranch();
        }


        return ds;
    }
    public void bindvouchertype()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.voucher_deletion bind = new NewAdbooking.Classes.voucher_deletion();
            ds = bind.check_drcr(hdncompcode.Value, "", "", "", "");
        }
        else
        {

            NewAdbooking.classesoracle.voucher_deletion bind = new NewAdbooking.classesoracle.voucher_deletion();
            ds = bind.check_drcr(hdncompcode.Value, "", "", "", "");

        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        dpdvouchertyp.Items.Clear();
        li1.Text = "-Select Voucher Type-";
        li1.Value = "";
        li1.Selected = true;
        dpdvouchertyp.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["doc_Name"].ToString().ToUpper().IndexOf("BIL") > -1)
            { }
            else
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i]["doc_type"].ToString();
                li.Text = ds.Tables[0].Rows[i]["doc_Name"].ToString();
                dpdvouchertyp.Items.Add(li);
            }

        }

    }

    [Ajax.AjaxMethod]
    public DataSet bindbillno(string compcode, string doctype, string unit, string rcptdt, string dateformat)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (dateformat == "dd/mm/yyyy")
            {
                rcptdt = DMYToMDY(rcptdt);
            }
            else if (dateformat == "yyyy/mm/dd")
            {
                rcptdt = YMDToMDY(rcptdt);
            }
            NewAdbooking.Classes.voucher_deletion logindetail = new NewAdbooking.Classes.voucher_deletion();

            ds = logindetail.bind_billno(compcode, doctype, unit, rcptdt, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.voucher_deletion logindetail = new NewAdbooking.classesoracle.voucher_deletion();
            ds = logindetail.bind_billno(compcode, doctype, unit, rcptdt, dateformat);
        }


        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindbilldetail(string compcode, string doctype, string unit, string rcptdt, string dateformat, string voucherno)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (dateformat == "dd/mm/yyyy")
            {
                rcptdt = DMYToMDY(rcptdt);
            }
            else if (dateformat == "yyyy/mm/dd")
            {
                rcptdt = YMDToMDY(rcptdt);
            }
            NewAdbooking.Classes.voucher_deletion logindetail = new NewAdbooking.Classes.voucher_deletion();

            ds = logindetail.bind_billdetail(compcode, doctype, unit, rcptdt, dateformat, voucherno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.voucher_deletion logindetail = new NewAdbooking.classesoracle.voucher_deletion();
            ds = logindetail.bind_billdetail(compcode, doctype, unit, rcptdt, dateformat, voucherno);
        }


        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet bindbilldelete(string compcode, string doctype, string unit, string rcptdt, string dateformat, string voucherno, string userid)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (dateformat == "dd/mm/yyyy")
            {
                rcptdt = DMYToMDY(rcptdt);
            }
            else if (dateformat == "yyyy/mm/dd")
            {
                rcptdt = YMDToMDY(rcptdt);
            }
            NewAdbooking.Classes.voucher_deletion logindetail = new NewAdbooking.Classes.voucher_deletion();

            ds = logindetail.bind_billdelete(compcode, doctype, unit, rcptdt, dateformat, voucherno,userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.voucher_deletion logindetail = new NewAdbooking.classesoracle.voucher_deletion();
            ds = logindetail.bind_billdelete(compcode, doctype, unit, rcptdt, dateformat, voucherno);
        }


        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindbilladjust(string compcode, string rcptdt, string billno, string userid, string dateformat, string extra1, string extra2)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (dateformat == "dd/mm/yyyy")
            {
                rcptdt = DMYToMDY(rcptdt);
            }
            else if (dateformat == "yyyy/mm/dd")
            {
                rcptdt = YMDToMDY(rcptdt);
            }
            NewAdbooking.Classes.voucher_deletion logindetail = new NewAdbooking.Classes.voucher_deletion();

            ds = logindetail.bill_adjust(compcode,rcptdt, billno, userid,dateformat, extra1,extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.voucher_deletion logindetail = new NewAdbooking.classesoracle.voucher_deletion();
            ds = logindetail.bill_adjust(compcode, rcptdt,billno, userid, dateformat, extra1,extra2);
        }


        return ds;
    }
}
