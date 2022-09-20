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

public partial class contractChild : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        txtchannel.Attributes.Add("OnChange", "javascript:return checkValidField('txtchannel','Channel');  ");
        txtpb.Attributes.Add("OnChange", "javascript:return checkValidField('txtpb','Paid/Bonus');  ");
        txtpackage.Attributes.Add("OnChange", "javascript:return checkValidField('txtpackage','Package');  ");
        txtadvtype.Attributes.Add("OnChange", "javascript:return checkValidField('txtadvtype','Adv Type');  ");
        txtbtb.Attributes.Add("OnChange", "javascript:return checkValidField('txtbtb','BTB');  ");
        txtprogramname.Attributes.Add("OnChange", "javascript:return checkValidField('txtprogramname','Program Name');  ");
        txtros.Attributes.Add("OnChange", "javascript:return checkValidField('txtros','Time Band');  ");
        txtday.Attributes.Add("OnChange", "javascript:return checkValidField('txtday','Day');  ");
        txtratetype.Attributes.Add("OnChange", "javascript:return checkValidField('txtratetype','Rate Type');  ");
        txtprem.Attributes.Add("OnChange", "javascript:return checkValidField('txtprem','Premium Type');  ");
        txtcategory.Attributes.Add("OnChange", "javascript:return checkValidField('txtcategory','Category');  ");
        txtsource.Attributes.Add("OnChange", "javascript:return checkValidField('txtsource','Source');  ");
        txtcurrency.Attributes.Add("OnChange", "javascript:return checkValidField('txtcurrency','Currency');  ");
        txtdisctype.Attributes.Add("OnChange", "javascript:return checkValidField('txtdisctype','Disc Type');  ");
        txtdealstart.Attributes.Add("OnChange", "javascript:return checkValidField('txtdealstart','Deal Start');  ");
        txtprogtype.Attributes.Add("OnChange", "javascript:return checkValidField('txtprogtype','Program Type');  ");
        txtratecode.Attributes.Add("OnChange", "javascript:return checkValidField('txtratecode','Rate Code');  ");
        txtdiscon.Attributes.Add("OnChange", "javascript:return checkValidField('txtdiscon','Disc on');  ");
        txtcommallow.Attributes.Add("OnChange", "javascript:return checkValidField('txtcommallow','Comm. Allow');  ");
        txtapproved.Attributes.Add("OnChange", "javascript:return checkValidField('txtapproved','Approved');  ");

        txtsponfrom.Attributes.Add("OnBlur", "javascript:return checkDateValid();  ");
        txtsponto.Attributes.Add("OnBlur", "javascript:return checkDateValid();  ");
        btnOk.Attributes.Add("OnClick", "javascript:return setData(event);");
        txtmaxsize.Attributes.Add("OnBlur", "javascript:return checkMinMax();");
        txtminsize.Attributes.Add("OnBlur", "javascript:return checkMinMax();");
        txtvaluefrom.Attributes.Add("OnBlur", "javascript:return checkFromTo();");
        txtvalueto.Attributes.Add("OnBlur", "javascript:return checkFromTo();");
        hiddencompcode.Value = Session["compcode"].ToString();//"HT001";//
        hiddenuserid.Value = Session["userid"].ToString();//"bh01";//
        hiddendateformat.Value = Session["dateformat"].ToString();//"dd/mm/yyyy";//
        hiddenunit.Value = Session["revenue"].ToString();//"HC";//
        hiddenagcode.Value = Request.QueryString["agcode"].ToString();//"";///
        hiddenagcode.Value = Request.QueryString["agsubcode"].ToString();//"";//
        txtvalidfrom.Value = Request.QueryString["validfrom"].ToString();//"01/01/2011";//
        txtvalidto.Value = Request.QueryString["validto"].ToString();//"01/01/2012";//
        hidcontractdate.Value = Request.QueryString["contdate"].ToString();
        hidreceiptcurr.Value = Request.QueryString["rcptcurr"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(contractChild));
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/contractchild.xml"));
        lblchannel.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        lbllocation.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        lblpackage.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        lbladvtype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        lblprogramname.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        lblbtb.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        lblros.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        lblday.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        lblratetype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        lblfct.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        lbldisctype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        lbldiscper.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        lblcardrate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[12].ToString();
        lblcontrate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[13].ToString();
        lbldev.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[14].ToString();
        lblpb.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[15].ToString();

        lblprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[16].ToString();
        lblcontprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[17].ToString();
        lblcardprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[18].ToString();
        lblsource.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[19].ToString();
        lblcategory.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[20].ToString();
        lblcurrency.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[21].ToString();
        lblsponfrom.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[22].ToString();
        lblsponto.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[23].ToString();

        lblvaluefrom.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[24].ToString();
        lblvalueto.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[25].ToString();
        lblminsize.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[26].ToString();
        lblmaxsize.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[27].ToString();
        lbldealstart.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[28].ToString();
        lblprogtype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[29].ToString();
        lblratecode.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[30].ToString();
        lbldiscon.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[31].ToString();
        lblcommallow.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[32].ToString();
        lbltotvalue.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[33].ToString();
        lblincentive.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[34].ToString();
        lblapproved.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[35].ToString();
        lblremarks.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[36].ToString();
        txtcurrency.Text = Session["currency"].ToString();
        hidcurr.Value = Session["currency"].ToString();
        lblsectioncode.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[37].ToString();
        lblresourceno.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[38].ToString();
        lbllocaltotvalue.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[39].ToString();
        if (Request.QueryString["mode"] != null && (Request.QueryString["mode"].ToString() == "new" || Request.QueryString["mode"].ToString() == "modify"))
        {
            txtchannel.Enabled = true;
            // txtlocation.Enabled = true;
            txtadvtype.Enabled = true;
            txtpb.Enabled = true;
            txtratetype.Enabled = true;
            txtprogramname.Enabled = true;
            txtbtb.Enabled = true;
            txtros.Enabled = true;
            txtday.Enabled = true;
            txtfct.Enabled = true;
            txtpackage.Enabled = true;
            txtvaluefrom.Enabled = true;
            txtvalueto.Enabled = true;
            txtdiscper.Enabled = true;
            txtdisctype.Enabled = true;
            txtprem.Enabled = true;
            txtcontprem.Enabled = true;
            //txtcardprem.Enabled = true;
            txtcontrate.Enabled = true;
            //txtcardrate.Enabled = true;
            txtminsize.Enabled = true;
            txtmaxsize.Enabled = true;
            txtcurrency.Enabled = true;
            txtdealstart.Enabled = true;
            txtprogtype.Enabled = true;
            txtcategory.Enabled = true;
            txtcommallow.Enabled = true;
            txtremarks.Enabled = true;
            txtratecode.Enabled = true;
            txtdiscon.Enabled = true;
            txtsponfrom.Enabled = true;
            txtsponto.Enabled = true;
            txtsource.Enabled = true;
            txtincentive.Enabled = true;
            txtapproved.Enabled = true;
            txtsectioncode.Enabled = true;
            txtresourceno.Enabled = true;
            txtslot.Enabled = true;
            if (Request.QueryString["mode"].ToString() == "modify" && Request.QueryString["dealno"] != null && Request.QueryString["dealno"].ToString() != "")
            {
                bindData(Request.QueryString["dealno"].ToString(), Request.QueryString["seqno"].ToString(), Request.QueryString["consumed"].ToString(), Request.QueryString["balance"].ToString());
            }
        }
        else
        {
            txtchannel.Enabled = false;
            txtlocation.Enabled = false;
            txtadvtype.Enabled = false;
            txtpb.Enabled = false;
            txtratetype.Enabled = false;
            txtprogramname.Enabled = false;
            txtbtb.Enabled = false;
            txtros.Enabled = false;
            txtday.Enabled = false;
            txtfct.Enabled = false;
            txtpackage.Enabled = false;
            txtvaluefrom.Enabled = false;
            txtvalueto.Enabled = false;
            txtdiscper.Enabled = false;
            txtdisctype.Enabled = false;
            txtprem.Enabled = false;
            txtcontprem.Enabled = false;
            //txtcardprem.Enabled = true;
            txtcontrate.Enabled = false;
            //txtcardrate.Enabled = true;
            txtminsize.Enabled = false;
            txtmaxsize.Enabled = false;
            txtcurrency.Enabled = false;
            txtdealstart.Enabled = false;
            txtprogtype.Enabled = false;
            txtcategory.Enabled = false;
            txtcommallow.Enabled = false;
            txtremarks.Enabled = false;
            txtratecode.Enabled = false;
            txtdiscon.Enabled = false;
            txtsponfrom.Enabled = false;
            txtsponto.Enabled = false;
            txtsource.Enabled = false;
            txtincentive.Enabled = false;
            txtapproved.Enabled = false;
            txtsectioncode.Enabled = false;
            txtresourceno.Enabled = false;
            txtresourceno.Enabled = false;
            if (Request.QueryString["mode"].ToString() == "qyery" && Request.QueryString["dealno"] != null && Request.QueryString["dealno"].ToString() != "")
            {
                bindData(Request.QueryString["dealno"].ToString(), Request.QueryString["seqno"].ToString(), Request.QueryString["consumed"].ToString(), Request.QueryString["balance"].ToString());
            }
        }

    }
    private void bindData(string dealno, string seqno, string consumed, string balance)
    {
        DataSet ds = new DataSet();
        ds = bindGridDetails_Contract(Session["compcode"].ToString(), dealno, seqno);
        if (ds.Tables[1].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows[0]["CHANNEL"] != null)
            {
                txtchannel.Text = ds.Tables[1].Rows[0]["CHANNEL"].ToString();
            }
            if (ds.Tables[1].Rows[0]["LOCATION_CODE"] != null)
            {
                txtlocation.Text = ds.Tables[1].Rows[0]["LOCATION_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["AD_TYPE"] != null)
            {
                txtadvtype.Text = ds.Tables[1].Rows[0]["AD_TYPE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["PB_FLG"] != null)
            {
                txtpb.Text = ds.Tables[1].Rows[0]["PB_FLG"].ToString();
            }
            if (ds.Tables[1].Rows[0]["RATE_TYPE"] != null)
            {
                txtratetype.Text = ds.Tables[1].Rows[0]["RATE_TYPE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["PRG_CODE"] != null)
            {
                txtprogramname.Text = ds.Tables[1].Rows[0]["PRG_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["BTB_CODE"] != null)
            {
                txtbtb.Text = ds.Tables[1].Rows[0]["BTB_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["ROS_CODE"] != null)
            {
                txtros.Text = ds.Tables[1].Rows[0]["ROS_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["DAYS"] != null)
            {
                txtday.Text = ds.Tables[1].Rows[0]["DAYS"].ToString();
            }
            if (ds.Tables[1].Rows[0]["NO_OF_INS"] != null)
            {
                txtfct.Text = ds.Tables[1].Rows[0]["NO_OF_INS"].ToString();
            }
            if (ds.Tables[1].Rows[0]["PACKAGE_CODE"] != null)
            {
                txtpackage.Text = ds.Tables[1].Rows[0]["PACKAGE_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["VALUE_FROM"] != null)
            {
                txtvaluefrom.Text = ds.Tables[1].Rows[0]["VALUE_FROM"].ToString();
            }
            if (ds.Tables[1].Rows[0]["VALUE_TO"] != null)
            {
                txtvalueto.Text = ds.Tables[1].Rows[0]["VALUE_TO"].ToString();
            }
            if (ds.Tables[1].Rows[0]["DISC_TYPE"] != null)
            {
                txtdisctype.Text = ds.Tables[1].Rows[0]["DISC_TYPE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["DISC_VAL"] != null)
            {
                txtdiscper.Text = ds.Tables[1].Rows[0]["DISC_VAL"].ToString();
            }
            if (ds.Tables[1].Rows[0]["PREM_CODE"] != null)
            {
                txtprem.Text = ds.Tables[1].Rows[0]["PREM_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["CONTRACT_PREM_VALUE"] != null)
            {
                txtcontprem.Text = ds.Tables[1].Rows[0]["CONTRACT_PREM_VALUE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["CONTRACT_RATE"] != null)
            {
                txtcontrate.Text = ds.Tables[1].Rows[0]["CONTRACT_RATE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["CARD_RATE"] != null)
            {
                txtcardrate.Text = ds.Tables[1].Rows[0]["CARD_RATE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["DEVIATION_RATE"] != null)
            {
                txtdev.Text = ds.Tables[1].Rows[0]["DEVIATION_RATE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["CARD_PREM_VALUE"] != null)
            {
                txtcardprem.Text = ds.Tables[1].Rows[0]["CARD_PREM_VALUE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["MIN_SIZE"] != null)
            {
                txtminsize.Text = ds.Tables[1].Rows[0]["MIN_SIZE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["MAX_SIZE"] != null)
            {
                txtmaxsize.Text = ds.Tables[1].Rows[0]["MAX_SIZE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["CURRENCY"] != null)
            {
                txtcurrency.Text = ds.Tables[1].Rows[0]["CURRENCY"].ToString();
            }
            if (ds.Tables[1].Rows[0]["DEAL_START"] != null)
            {
                txtdealstart.Text = ds.Tables[1].Rows[0]["DEAL_START"].ToString();
            }
            if (ds.Tables[1].Rows[0]["PRG_TYPE"] != null)
            {
                txtprogtype.Text = ds.Tables[1].Rows[0]["PRG_TYPE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["AD_CTG"] != null)
            {
                txtcategory.Text = ds.Tables[1].Rows[0]["AD_CTG"].ToString();
            }
            if (ds.Tables[1].Rows[0]["COMM_ALLOW"] != null)
            {
                txtcommallow.Text = ds.Tables[1].Rows[0]["COMM_ALLOW"].ToString();
            }
            if (ds.Tables[1].Rows[0]["REMARKS"] != null)
            {
                txtremarks.Text = ds.Tables[1].Rows[0]["REMARKS"].ToString();
            }
            if (ds.Tables[1].Rows[0]["RATE_CODE"] != null)
            {
                txtratecode.Text = ds.Tables[1].Rows[0]["RATE_CODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["DISC_ON"] != null)
            {
                txtdiscon.Text = ds.Tables[1].Rows[0]["DISC_ON"].ToString();
            }
            if (ds.Tables[1].Rows[0]["SPN_ST_DT"] != null && ds.Tables[1].Rows[0]["SPN_ST_DT"].ToString() != "1/1/1900 12:00:00 AM")
            {
                txtsponfrom.Text = ds.Tables[1].Rows[0]["SPN_ST_DT"].ToString();
            }
            if (ds.Tables[1].Rows[0]["SPN_END_DT"] != null && ds.Tables[1].Rows[0]["SPN_END_DT"].ToString() != "1/1/1900 12:00:00 AM")
            {
                txtsponto.Text = ds.Tables[1].Rows[0]["SPN_END_DT"].ToString();
            }
            if (ds.Tables[1].Rows[0]["SOURCE"] != null)
            {
                txtsource.Text = ds.Tables[1].Rows[0]["SOURCE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["TOTALVAL"] != null)
            {
                txttotvalue.Text = ds.Tables[1].Rows[0]["TOTALVAL"].ToString();
            }
            if (ds.Tables[1].Rows[0]["INCENTIVE"] != null)
            {
                txttotvalue.Text = ds.Tables[1].Rows[0]["INCENTIVE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["APPROVED"] != null)
            {
                txttotvalue.Text = ds.Tables[1].Rows[0]["APPROVED"].ToString();
            }
            if (ds.Tables[1].Rows[0]["TOTALVAL"] != null)
            {
                txttotvalue.Text = ds.Tables[1].Rows[0]["TOTALVAL"].ToString();
            }
            if (ds.Tables[1].Rows[0]["SECTIONCODE"] != null)
            {
                txtsectioncode.Text = ds.Tables[1].Rows[0]["SECTIONCODE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["RESOURCE_NO"] != null)
            {
                txtresourceno.Text = ds.Tables[1].Rows[0]["RESOURCE_NO"].ToString();
            }
            if (ds.Tables[1].Rows[0]["LOCALTOTALVAL"] != null)
            {
                txtlocaltotvalue.Text = ds.Tables[1].Rows[0]["LOCALTOTALVAL"].ToString();
            }
            if (ds.Tables[1].Rows[0]["CONVRATE"] != null)
            {
                hidcurrency_convrate.Value = ds.Tables[1].Rows[0]["CONVRATE"].ToString();
            }
            if (ds.Tables[1].Rows[0]["SLOT_PER_DAY"] != null)
            {
                txtslot.Text = ds.Tables[1].Rows[0]["SLOT_PER_DAY"].ToString();
            }

            txtconsumed.Text = consumed;
            txtbalance.Text = balance;
        }
    }
    public DataSet bindGridDetails_Contract(string compcode, string dealcode, string seqno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            ds = insert.bindGridDetails_Contract(compcode, dealcode, seqno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract insert = new NewAdbooking.classesoracle.Contract();
            ds = insert.bindGridDetails_Contract(compcode, dealcode, seqno);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getrateforcontract_Elec(string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat, string currency_p, string contractrate_p, string agencycode_p, string subagencycode)
    {
        DataSet dcon = new DataSet();
        if (channel_p.IndexOf("(") >= 0)
            channel_p = channel_p.Substring(channel_p.LastIndexOf("(") + 1, channel_p.Length - channel_p.LastIndexOf("(") - 2);
        if (location_p.IndexOf("(") >= 0)
            location_p = location_p.Substring(location_p.LastIndexOf("(") + 1, location_p.Length - location_p.LastIndexOf("(") - 2);
        if (adtype_p.IndexOf("(") >= 0)
            adtype_p = adtype_p.Substring(adtype_p.LastIndexOf("(") + 1, adtype_p.Length - adtype_p.LastIndexOf("(") - 2);
        if (ratetype.IndexOf("(") >= 0)
            ratetype = ratetype.Substring(ratetype.LastIndexOf("(") + 1, ratetype.Length - ratetype.LastIndexOf("(") - 2);
        if (day_p.IndexOf("(") >= 0)
            day_p = day_p.Substring(day_p.LastIndexOf("(") + 1, day_p.Length - day_p.LastIndexOf("(") - 2);
        if (category_p.IndexOf("(") >= 0)
            category_p = category_p.Substring(category_p.LastIndexOf("(") + 1, category_p.Length - category_p.LastIndexOf("(") - 2);
        if (btb_p.IndexOf("(") >= 0)
            btb_p = btb_p.Substring(btb_p.LastIndexOf("(") + 1, btb_p.Length - btb_p.LastIndexOf("(") - 2);
        if (fct_p.IndexOf("(") >= 0)
            fct_p = fct_p.Substring(fct_p.LastIndexOf("(") + 1, fct_p.Length - fct_p.LastIndexOf("(") - 2);
        if (package_p.IndexOf("(") >= 0)
            package_p = package_p.Substring(package_p.LastIndexOf("(") + 1, package_p.Length - package_p.LastIndexOf("(") - 2);
        if (disctype_p.IndexOf("(") >= 0)
            disctype_p = disctype_p.Substring(disctype_p.LastIndexOf("(") + 1, disctype_p.Length - disctype_p.LastIndexOf("(") - 2);
        if (premium.IndexOf("(") >= 0)
            premium = premium.Substring(premium.LastIndexOf("(") + 1, premium.Length - premium.LastIndexOf("(") - 2);
        if (progtype_p.IndexOf("(") >= 0)
            progtype_p = progtype_p.Substring(progtype_p.LastIndexOf("(") + 1, progtype_p.Length - progtype_p.LastIndexOf("(") - 2);
        if (progname_p.IndexOf("(") >= 0)
            progname_p = progname_p.Substring(progname_p.LastIndexOf("(") + 1, progname_p.Length - progname_p.LastIndexOf("(") - 2);
        if (commallow_p.IndexOf("(") >= 0)
            commallow_p = commallow_p.Substring(commallow_p.LastIndexOf("(") + 1, commallow_p.Length - commallow_p.LastIndexOf("(") - 2);
        if (ratecode_p.IndexOf("(") >= 0)
            ratecode_p = ratecode_p.Substring(ratecode_p.LastIndexOf("(") + 1, ratecode_p.Length - ratecode_p.LastIndexOf("(") - 2);
        if (source_p.IndexOf("(") >= 0)
            source_p = source_p.Substring(source_p.LastIndexOf("(") + 1, source_p.Length - source_p.LastIndexOf("(") - 2);
        if (currency_p.IndexOf("(") >= 0)
            currency_p = currency_p.Substring(currency_p.LastIndexOf("(") + 1, currency_p.Length - currency_p.LastIndexOf("(") - 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract getpkgrate = new NewAdbooking.Classes.Contract();
            dcon = getpkgrate.getrateforcontract_Elec(compcode_p, unit_p, channel_p, location_p, adtype_p, ratetype, day_p, category_p, btb_p, fct_p, validfrom_p, validto_p, package_p, valufrom_p, valueto_p, disctype_p, disper, premium, cardprem_p, contprem_p, minsize_p, maxsize_p, progtype_p, progname_p, commallow_p, ratecode_p, source_p, dateformat, currency_p, contractrate_p, agencycode_p, subagencycode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract getpkgrate = new NewAdbooking.classesoracle.Contract();
                dcon = getpkgrate.getrateforcontract_Elec(compcode_p, unit_p, channel_p, location_p, adtype_p, ratetype, day_p, category_p, btb_p, fct_p, validfrom_p, validto_p, package_p, valufrom_p, valueto_p, disctype_p, disper, premium, cardprem_p, contprem_p, minsize_p, maxsize_p, progtype_p, progname_p, commallow_p, ratecode_p, source_p, dateformat, currency_p, contractrate_p, agencycode_p, subagencycode);
            }
        return dcon;
    }
    [Ajax.AjaxMethod]
    public DataSet getPremPage_detail(string premcode)
    {
        DataSet ds = new DataSet();
        string id = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objUpdatePage_Booking = new NewAdbooking.Classes.BookingMaster();
            ds = objUpdatePage_Booking.getPremPage(premcode, id);
            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objPagePremium = new NewAdbooking.classesoracle.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindProgramType_detail(string compcode, string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindProgramType_TV(compcode, channel);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindProgramType_TV(compcode, channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindProgram_detail(string compcode, string programtype, string btbcode, string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindProgram_TV(compcode, programtype, btbcode, channel);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindProgram_TV(compcode, programtype, btbcode, channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindBTB_detail(string compcode, string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindBTB_TV(compcode, channel);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindBTB_TV(compcode, channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindAdvType_TV_detail(string compcode, string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindAdvType_TV(compcode, channel);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindAdvType_TV(compcode, channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindRos_detail(string compcode, string btbcode, string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindROS_TV(compcode, btbcode, channel);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindROS_TV(compcode, btbcode, channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindpackage_A_detail(string compcode, string adtype, string channel)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.TV_packagebind(compcode, adtype, channel);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                ds = bindopackage.TV_packagebind(compcode, adtype, channel);

            }
            else
            {
                NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();

                ds = bindopackage.packagebind(compcode, adtype);


            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindadvcategory_A_detail(string adtypeval, string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Contract bindadvcate = new NewAdbooking.Classes.Contract();

            ds = bindadvcate.bindadvcategory(compcode, adtypeval);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindadvcate = new NewAdbooking.classesoracle.Contract();

                ds = bindadvcate.bindadvcategory(compcode, adtypeval);

            }
            else
            {
                NewAdbooking.classmysql.Contract bindadvcate = new NewAdbooking.classmysql.Contract();
                ds = bindadvcate.bindadvcategory(compcode, adtypeval);
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindcurrency_detail(string compcode, string userid)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract curr = new NewAdbooking.Classes.Contract();

            ds = curr.currencybind(compcode, userid);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract curr = new NewAdbooking.classesoracle.Contract();

                ds = curr.currencybind(compcode, userid);

            }
            else
            {
                NewAdbooking.classmysql.Contract curr = new NewAdbooking.classmysql.Contract();

                ds = curr.currencybind(compcode, userid);


            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindratecode_detail(string compcode, string adtype)
    {

        DataSet dx = new DataSet();

        string contract = "contract";

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Contract bindrate = new NewAdbooking.Classes.Contract();

            dx = bindrate.ratebind(compcode, adtype);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindrate = new NewAdbooking.classesoracle.Contract();

                dx = bindrate.ratebind(compcode, adtype);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();

                dx = bindrate.ratebind(contract, compcode);


            }
        return dx;
    }
    [Ajax.AjaxMethod]
    public DataSet bindLocation_detail(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindLocation_TV(compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindLocation_TV(compcode);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindChannel_detail(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindChannel_TV(compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindChannel_TV(compcode);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet bindpremium_A_detail(string compcode, string adtype)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bindrate = new NewAdbooking.Classes.RateMaster();
            ds1 = bindrate.premiumbind(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bindrate = new NewAdbooking.classesoracle.RateMaster();
            ds1 = bindrate.premiumbind(compcode, adtype);
        }
        else
        {
            NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            ds1 = bindrate.premiumbind(compcode, adtype);
        }
        return ds1;
    }
    [Ajax.AjaxMethod]
    public DataSet binduom_A_detail(string compcode, string adType, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.uombind(compcode, adType);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.uombind(compcode, userid, adType);
            }
            else
            {
                NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                ds = binduom.uombind(compcode, userid);

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindSource_TV_Contract(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            ds = insert.bindSource_TV(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract insert = new NewAdbooking.classesoracle.Contract();
            ds = insert.bindSource_TV(compcode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getSectionCode(string name_p)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindopackage = new NewAdbooking.Classes.BookingMaster();
            ds = bindopackage.getSectionCode(name_p);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindopackage = new NewAdbooking.classesoracle.BookingMaster();
            ds = bindopackage.getSectionCode(name_p);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getResourceNo(string name_p)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindopackage = new NewAdbooking.Classes.BookingMaster();
            ds = bindopackage.getResourceNo(name_p);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster bindopackage = new NewAdbooking.classesoracle.BookingMaster();
            ds = bindopackage.getResourceNo(name_p);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet CONVERTTOLOCAL_CURRENCY(string p_Comp_code, string p_Curr_Code, string p_gross_amount, string p_bill_amount, string p_date, string dateformat, string covertcurrency)
    {
        DataSet ddl = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster delid = new NewAdbooking.Classes.BookingMaster();

            ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster delid = new NewAdbooking.classesoracle.BookingMaster();

            ddl = delid.CONVERTTOLOCAL_CURRENCY(p_Comp_code, p_Curr_Code, p_gross_amount, p_bill_amount, p_date, dateformat, covertcurrency);
        }
        return ddl;
    }
}
