using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

public partial class contractchildprint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        hiddendateformat.Value = Session["dateformat"].ToString();

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencenter.Value = Session["center"].ToString();
        hiddenvalidfrom.Value = Request.QueryString["validfrom"].ToString();
        hiddenvalidto.Value = Request.QueryString["validto"].ToString();
        hdncltcod.Value = Request.QueryString["clientcod"].ToString();
        hidagency.Value = Request.QueryString["agencycod"].ToString();
        hdnagency.Value = Session["revenue"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(contractchildprint));
        DataSet objDataSetbu = new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/contractchieldprint.xml"));
        lbadtype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        lbhue.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        lbumo.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        lbpackage.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        lbctegory.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        lbcurrency.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[29].ToString();
        lbstatus.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[30].ToString();
        lbpremium.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        lbcardprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        lbcontractprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        lbpositionpremium.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        lbcardposprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        lbcontposprem.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        lbcontractrate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[31].ToString();
        lbcardrate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();
        lbdeviation.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[12].ToString();

        lbcontarctamount.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[13].ToString();

        lbdisctype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[14].ToString();
        lbdiscper.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[15].ToString();
        lbdiscon.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[16].ToString();
        lbminsize.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[17].ToString();

        lbmaxsize.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[18].ToString();
        lbvaluefrom.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[19].ToString();
        lbvalueto.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[20].ToString();
        lbday.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[21].ToString();
        lbinsertion.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[22].ToString();
        lbcomallow.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[23].ToString();
        lbdealstart.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[24].ToString();
        lbratecode.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[25].ToString();

        lbtotalrate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[26].ToString();
        lbincentive.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[27].ToString();
        lbremarks.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[28].ToString();
        lbltoinsert.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[32].ToString();
        lblbarter.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[33].ToString();
         
              lstcommon.Attributes.Add("onkeydown", "javascript:return onclicklist(event);");
              lstcommon.Attributes.Add("onclick", "javascript:return onclicklist(event);");
              btnOk.Attributes.Add("onclick", "javascript:return setData(event);");
           //   txtadtype.Attributes.Add("OnBlur", "javascript:return packagebind();");
              txtcontractrate.Attributes.Add("OnBlur", "javascript:return deviation();");
              txtcardrate.Attributes.Add("OnBlur", "javascript:return deviation();");
              txtmaxsize.Attributes.Add("OnBlur", "javascript:return greater();");
              txtvalueto.Attributes.Add("OnBlur", "javascript:return checkFromTo();");
              //txtadtype.Attributes.Add("OnChange", "javascript:return get_rate();");
              //txthue.Attributes.Add("OnBlur", "javascript:return get_rate();");
              //txtumo.Attributes.Add("OnBlur", "javascript:return get_rate();");
              //txtcategory.Attributes.Add("OnBlur", "javascript:return get_rate();");
              //txtcurrency.Attributes.Add("OnBlur", "javascript:return get_rate();");
              //listpackage.Attributes.Add("OnChange", "javascript:return get_rate();");
              txtadsubcat.Attributes.Add("onkeydown", "javascript:return onclicksubcat(event);");
              lstsubcat.Attributes.Add("onkeydown", "javascript:return onclicksubcat1(event);");
              lstsubcat.Attributes.Add("onclick", "javascript:return onclicksubcat1(event);");
              txtcurrency.Text = Session["currency"].ToString();
              hiddencurrency.Value = Session["currency"].ToString();
              if (Request.QueryString["mode"] != null && (Request.QueryString["mode"].ToString() == "new" || Request.QueryString["mode"].ToString() == "modify"))
              {
                  txtadtype.Enabled = true;
                  // txtlocation.Enabled = true;
                  txthue.Enabled = true;
                  txtumo.Enabled = true;
                  txtcategory.Enabled = true;
                  listpackage.Enabled = true;
                  txtcurrency.Enabled = true;
                  txtstatus.Enabled = true;
                  txtday.Enabled = true;
                  txtpremium.Enabled = true;
              //    txtcardprem.Enabled = true;
                  txtcontractperm.Enabled = true;
              //    txtpositiomprem.Enabled = true;
                  txtcardpositionprem.Enabled = true;
                  txtcontarctpositionprem.Enabled = true;
                  txtcontractrate.Enabled = true;
              //    txtcardrate.Enabled = true;
                  //txtcardprem.Enabled = true;
              //    txtdeviation.Enabled = true;
                  //txtcardrate.Enabled = true;
                  txtcontractamount.Enabled = true;
                  txtdisctype.Enabled = true;
                  txtdiscper.Enabled = true;
                  txtdiscon.Enabled = true;
                  txtminsize.Enabled = true;
                  txtmaxsize.Enabled = true;
                  txtvaluefrom.Enabled = true;
                  txtvalueto.Enabled = true;
                  txtday.Enabled = true;
                  txtinsertion.Enabled = true;
                  txtcomallow.Enabled = true;
                  txtdealstart.Enabled = true;
                  txtratecode.Enabled = true;
             //     txttotalrate.Enabled = true;
            //      txtincentive.Enabled = true;
                  txtremarks.Enabled = true;

                  if (Session["tempdata"] != null)
                  {
                      bindDataFromSession();
                  }
                  else if (Request.QueryString["mode"].ToString() == "modify" && Request.QueryString["dealno"] != null && Request.QueryString["dealno"].ToString() != "")
                  {
                      bindData(Request.QueryString["dealno"].ToString());
                  }
                 
              }
              else
              {
                  txtadtype.Enabled = false;
                  // txtlocation.Enabled = true;
                  txthue.Enabled = false;
                  txtumo.Enabled = false;
                  txtcategory.Enabled = false;
                  listpackage.Enabled = false;
                  txtcurrency.Enabled = false;
                  txtstatus.Enabled = false;
                  txtday.Enabled = false;
                  txtpremium.Enabled = false;
                  txtcardprem.Enabled = false;
                  txtcontractperm.Enabled = false;
                  txtpositiomprem.Enabled = false;
                  txtcardpositionprem.Enabled = false;
                  txtcontarctpositionprem.Enabled = false;
                  txtcontractrate.Enabled = false;
                  txtcardrate.Enabled = false;
                  //txtcardprem.Enabled = false;
                  txtdeviation.Enabled = false;
                  //txtcardrate.Enabled = false;
                  txtcontractamount.Enabled = false;
                  txtdisctype.Enabled = false;
                  txtdiscper.Enabled = false;
                  txtdiscon.Enabled = false;
                  txtminsize.Enabled = false;
                  txtmaxsize.Enabled = false;
                  txtvaluefrom.Enabled = false;
                  txtvalueto.Enabled = false;
                  txtday.Enabled = false;
                  txtinsertion.Enabled = false;
                  txtcomallow.Enabled = false;
                  txtdealstart.Enabled = false;
                  txtratecode.Enabled = false;
               //   txttotalrate.Enabled = false;
              //    txtincentive.Enabled = false;
                  txtremarks.Enabled = false;
                  if (Session["tempdata"] != null)
                  {
                      bindDataFromSession();
                  }
                  else if (Request.QueryString["mode"].ToString() == "qyery" && Request.QueryString["dealno"] != null && Request.QueryString["dealno"].ToString() != "")
                  {
                      bindData(Request.QueryString["dealno"].ToString());
                  }
              }
    }

    private void bindDataFromSession()
    {
        string str = Session["tempdata"].ToString();
        string[] arr;
        string[] arr1;
        arr = str.Split("~".ToCharArray());
        txtadtype.Text = arr[0].ToString();
        string adtye = txtadtype.Text;
        if (adtye == "<INPUT style=\"WIDTH: 100%\">")
            adtye = "";
        if (adtye == "'<INPUT style=\"WIDTH: 100%\"")
            adtye = "";
        if (adtye != "")
        {
            arr1 = adtye.Split("(".ToCharArray());
            if (arr1.Length > 1)
                adtye = arr1[1].Replace(")", "");
            adtye = adtye.Replace(">", "");
        }
        //       txtadtype.Text = adtye;
        if (txtadtype.Text == "<INPUT style=\"WIDTH: 100%\">")
            txtadtype.Text = "";
        if (txtadtype.Text == "'<INPUT style=\"WIDTH: 100%\"")
            txtadtype.Text = "";
        bindpackage_A_detail_M(hiddencompcode.Value, adtye);
        txthue.Text = arr[1].ToString();
        if (txthue.Text == "<INPUT style=\"WIDTH: 100%\">")
            txthue.Text = "";
        txtumo.Text = arr[2].ToString();
        for (int i = 0; i < listpackage.Items.Count; i++)
        {
            if (arr[3].ToString().IndexOf("(" + listpackage.Items[i].Value + ")") >= 0)
            {
                listpackage.Items[i].Selected = true;
            }
        }
        //listpackage.Text = arr[3].ToString();
        txtcategory.Text = arr[4].ToString();
        txtcardprem.Text = arr[5].ToString();
        txtpremium.Text = arr[6].ToString();
        txtcontractperm.Text = arr[7].ToString();
        txtcontractrate.Text = arr[8].ToString();
        txtcardrate.Text = arr[9].ToString();
        txtdeviation.Text = arr[10].ToString();
        txtdisctype.Text = arr[11].ToString();
        txtdiscper.Text = arr[12].ToString();
        txtdiscon.Text = arr[13].ToString();
        txtminsize.Text = arr[14].ToString();
        txtmaxsize.Text = arr[15].ToString();
        txtvaluefrom.Text = arr[16].ToString();
        txtvalueto.Text = arr[17].ToString();
        txtday.Text = arr[18].ToString();
        txtinsertion.Text = arr[19].ToString();
        txtcomallow.Text = arr[20].ToString();
        txtdealstart.Text = arr[21].ToString();
        txtcurrency.Text = arr[22].ToString();
        txtratecode.Text = arr[23].ToString();
        txttotalrate.Text = arr[24].ToString();
        txtincentive.Text = arr[25].ToString();
        txtremarks.Text = arr[26].ToString();
        txtstatus.Text = arr[27].ToString();
        txtpositiomprem.Text = arr[28].ToString();
        txtcontractamount.Text = arr[29].ToString();
        txtcardpositionprem.Text = arr[30].ToString();
        txtcontarctpositionprem.Text = arr[31].ToString();
        txtinsert.Text = arr[32].ToString();
        txtbarter.Text= arr[33].ToString();
    }

    [Ajax.AjaxMethod]
    public DataSet bindadtype_detail(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            ds = bind.adtypbind(compcode);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
            ds = bind.adtypbind(compcode);
        }
        else
        {
            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
            ds = bind.adtypbind(compcode);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindcolor_detail(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();

            ds = bindcolor.colorbind(compcode, userid);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();

                ds = bindcolor.colorbind(compcode, userid);
            }
            else
            {
                NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();

                ds = bindcolor.colorbind(compcode, userid);

            }
        return ds;
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
    public DataSet pagebindpremium_A_detail(string compcode, string prem)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindrate = new NewAdbooking.Classes.Contract();
            ds1 = bindrate.pagepremiumbind(compcode, prem);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindrate = new NewAdbooking.classesoracle.Contract();
            ds1 = bindrate.pagepremiumbind(compcode, prem);
        }

        return ds1;
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
    public DataSet pagebindpremium(string compcode, string Premcode)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindrate = new NewAdbooking.Classes.Contract();
            ds1 = bindrate.getposprem(compcode, Premcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindrate = new NewAdbooking.classesoracle.Contract();
            ds1 = bindrate.getposprem(compcode, Premcode);
        }

        return ds1;
    }

    private void bindData(string dealno)
    {
        DataSet ds = new DataSet();
        ds = bindGridDetails_Contract(Session["compcode"].ToString(), dealno);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ADTYPE"] != null)
            {
                txtadtype.Text = ds.Tables[0].Rows[0]["ADTYPE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["COLOR"] != null)
            {
                txthue.Text = ds.Tables[0].Rows[0]["COLOR"].ToString();
            }
            if (ds.Tables[0].Rows[0]["UOM"] != null)
            {
                txtumo.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["ADVCATEGORY"] != null)
            {
                txtcategory.Text = ds.Tables[0].Rows[0]["ADVCATEGORY"].ToString();
            }
            if (ds.Tables[0].Rows[0]["PACKAGECODE"] != null)
            {
                hiddenpackagecode.Value = ds.Tables[0].Rows[0]["PACKAGECODE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CURRENCY"] != null)
            {
                txtcurrency.Text = ds.Tables[0].Rows[0]["CURRENCY"].ToString();
            }
            if (ds.Tables[0].Rows[0]["APPROVED"] != null)
            {
                txtstatus.Text = ds.Tables[0].Rows[0]["APPROVED"].ToString();
            }
            if (ds.Tables[0].Rows[0]["PREMIUMCODE"] != null)
            {
                txtpremium.Text = ds.Tables[0].Rows[0]["PREMIUMCODE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CARDPREMIUM"] != null)
            {
                txtcardprem.Text = ds.Tables[0].Rows[0]["CARDPREMIUM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DEALPREMIUM"] != null)
            {
                txtcontractperm.Text = ds.Tables[0].Rows[0]["DEALPREMIUM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["POSITION_PREM"] != null)
            {
                txtpositiomprem.Text = ds.Tables[0].Rows[0]["POSITION_PREM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CONTRACTCODE"] != null)
            {
                txtcardpositionprem.Text = ds.Tables[0].Rows[0]["CONTRACTCODE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CONTRACT_POSITION_PREM"] != null)
            {
                txtcontarctpositionprem.Text = ds.Tables[0].Rows[0]["CONTRACT_POSITION_PREM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DEALARTE"] != null)
            {
                txtcontractrate.Text = ds.Tables[0].Rows[0]["DEALARTE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CARDRATE"] != null)
            {
                txtcardrate.Text = ds.Tables[0].Rows[0]["CARDRATE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DEVIATION"] != null)
            {
                txtdeviation.Text = ds.Tables[0].Rows[0]["DEVIATION"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CONTRACT_AMOUNT"] != null)
            {
                txtcontractamount.Text = ds.Tables[0].Rows[0]["CONTRACT_AMOUNT"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DISCTYPE"] != null)
            {
                txtdisctype.Text = ds.Tables[0].Rows[0]["DISCTYPE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DISCPER"] != null)
            {
                txtdiscper.Text = ds.Tables[0].Rows[0]["DISCPER"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DISCOUNTED"] != null)
            {
                txtdiscon.Text = ds.Tables[0].Rows[0]["DISCOUNTED"].ToString();
            }
            if (ds.Tables[0].Rows[0]["SIZEFROM"] != null)
            {
                txtminsize.Text = ds.Tables[0].Rows[0]["SIZEFROM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["SIZETO"] != null)
            {
                txtmaxsize.Text = ds.Tables[0].Rows[0]["SIZETO"].ToString();
            }
            if (ds.Tables[0].Rows[0]["VALUEFROM"] != null)
            {
                txtvaluefrom.Text = ds.Tables[0].Rows[0]["VALUEFROM"].ToString();
            }
            if (ds.Tables[0].Rows[0]["VALUETO"] != null)
            {
                txtvalueto.Text = ds.Tables[0].Rows[0]["VALUETO"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DAYNAME"] != null)
            {
                txtday.Text = ds.Tables[0].Rows[0]["DAYNAME"].ToString();
            }
            if (ds.Tables[0].Rows[0]["INSERTION"] != null)
            {
                txtinsertion.Text = ds.Tables[0].Rows[0]["INSERTION"].ToString();
            }
            if (ds.Tables[0].Rows[0]["COMMITION_ALLOW"] != null)
            {
                txtcomallow.Text = ds.Tables[0].Rows[0]["COMMITION_ALLOW"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DEAL_START"] != null)
            {
                txtdealstart.Text = ds.Tables[0].Rows[0]["DEAL_START"].ToString();
            }
            if (ds.Tables[0].Rows[0]["RATE_CODE"] != null)
            {
                txtratecode.Text = ds.Tables[0].Rows[0]["RATE_CODE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["CONVERTRATE"] != null)
            {
                txttotalrate.Text = ds.Tables[0].Rows[0]["CONVERTRATE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["INCENTIVE"] != null)
            {
                txtincentive.Text = ds.Tables[0].Rows[0]["INCENTIVE"].ToString();
            }
            if (ds.Tables[0].Rows[0]["REMARKS"] != null )
            {
                txtremarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
            }
          
         
        }
    }
    public DataSet bindGridDetails_Contract(string compcode, string dealcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            ds = insert.bindGridDetails_Contract(compcode, dealcode, "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract insert = new NewAdbooking.classesoracle.Contract();
            ds = insert.bindGridDetails_Contract(compcode, dealcode, "");
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getrateforcontract_detail(string adcat, string pkgcode, string color, string currency, string uom, string advtype, string validfrom, string validto, string compcode, string dateformat, string premium, string subcat)
    {
        DataSet dcon = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract getpkgrate = new NewAdbooking.Classes.Contract();
            dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode, dateformat, premium, subcat);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract getpkgrate = new NewAdbooking.classesoracle.Contract();
                dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode, dateformat, premium);
            }
            else
            {
                NewAdbooking.classmysql.Contract getpkgrate = new NewAdbooking.classmysql.Contract();
                dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode);
            }
        return dcon;
    }
    [Ajax.AjaxMethod]
    public DataSet getBarter(string compcode, string center, string branch, string agency, string client)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster execute = new NewAdbooking.Classes.BookingMaster();
            executequery = execute.getBarter(compcode, center, branch, agency, client);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster execute = new NewAdbooking.classesoracle.BookingMaster();
            executequery = execute.getBarter(compcode, center, branch, agency, client);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster execute = new NewAdbooking.classmysql.BookingMaster();
            executequery = execute.getBarter(compcode, center, branch, agency, client);

        }
        return executequery;
    }

    [Ajax.AjaxMethod]
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

    private void bindpackage_A_detail_M(string compcode, string adtype)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {




            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.TV_packagebind(compcode, adtype, "");
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                ds = bindopackage.TV_packagebind(compcode, adtype, "");

            }
            else
            {
                NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();

                ds = bindopackage.packagebind(compcode, adtype);


            }

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i]["Package_Name"].ToString();
                li.Value = ds.Tables[0].Rows[i]["Combin_Code"].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                listpackage.Items.Add(li);

            }

        }

    }

    [Ajax.AjaxMethod]
    public DataSet fill_subcat(string compcode, string adcat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindadsubcat = new NewAdbooking.Classes.Contract();

            ds = bindadsubcat.advsubcat(compcode, adcat);
        }
        return ds;
    }
}
