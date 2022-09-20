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

public partial class changeexecutive : System.Web.UI.Page
{
    int i = 0;
    int j = 0;


    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();


        Ajax.Utility.RegisterTypeForAjax(typeof(changeexecutive));

        if (!IsPostBack)
        {
            btnsubmit.Attributes.Add("onclick", "javascript:return rrr();");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency11(event);");

            lstexecutive.Attributes.Add("onclick", "javascript:return clickexecutive(event);");
            lstexecutive.Attributes.Add("onkeydown", "javascript:return clickexecutive(event);");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");

            lstclientname.Attributes.Add("onclick", "javascript:return clickclient_name(event);");
            lstclientname.Attributes.Add("onkeydown", "javascript:return clickclient_name(event);");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");

            lstagen.Attributes.Add("onclick", "javascript:return clickagen_name(event);");
            lstagen.Attributes.Add("onkeydown", "javascript:return clickagen_name(event);");
            
            lstretainer.Attributes.Add("onclick", "javascript:return Clickretainer_exe(event);");          
            lstretainer.Attributes.Add("onkeydown", "javascript:return Clickretainer_exe(event);");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
           // btnsubmit.Attributes.Add("onclick", "javascript:return bindgrid();");
            btnexit.Attributes.Add("OnClick", "javascript:return exit();");

            listadd.Attributes.Add("onclick", "javascript:return F2fillcliadd(event);");
            listadd.Attributes.Add("onkeydown", "javascript:return F2fillcliadd(event);");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");

            //Update.Attributes.Add("OnClick", "javascript:return adbillsmodificationvalidate();");
        }
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/changeexecutive.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblciod.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
    }
         
  
    [Ajax.AjaxMethod]
    public DataSet bindexecutive(string compcol, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive chk = new NewAdbooking.Classes.changeexecutive();
            ds = chk.bindexecutive(compcol, userid, "", "");
            //   ds = chk.insertpayment(paycode, payname, compcode, userid, alias, cash);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();
                ds = save.bindexecutive(compcol, userid, "", "");
            }
            else
            {
                NewAdbooking.classmysql.PaymentMode chk = new NewAdbooking.classmysql.PaymentMode();
                ds = chk.insertpayment(compcol, userid, "", "");
            }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet updateexe(string compcol, string cioid, string executive, string clientname, string clientadd, string retainername,string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.changeexecutive chk = new NewAdbooking.Classes.changeexecutive();
            //ds = chk.updateexe(compcol, cioid, executive, clientname, clientadd, retainername,agency);
            // ds = chk.insertpayment(paycode, payname, compcode, userid, alias, cash);
            string[] parameterValueArray = { compcol, cioid, executive, clientname, clientadd, retainername, agency };
            string procedureName = "updateexecutive ";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();
                //// ds = save.updateexe(compcol, cioid, executivecode, clientname, clientadd, retainername);
                string[] parameterValueArray = { compcol, cioid, executive, clientname, clientadd, retainername, agency };
                string procedureName = "updateexecutive ";
                NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                NewAdbooking.classmysql.PaymentMode chk = new NewAdbooking.classmysql.PaymentMode();
                ds = chk.insertpayment(compcol, cioid, executive, clientname);
            }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive bindagenname = new NewAdbooking.Classes.changeexecutive();
            ds = bindagenname.bindagencys(compcode, userid, agency, Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ////FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    //ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            //}
            //else
            //{
            //    //ds = bindagenname.bindagency(compcode, userid, agency, "0");
            //    //ds = bindagenname.bindagency_DB(compcode, agency);
            //}
            string[] parameterValueArray = { compcode, userid, agency, Session["revenue"].ToString() };
            string procedureName = "bindagencyforbooking_p ";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive clsbooking = new NewAdbooking.Classes.changeexecutive();
            ds = clsbooking.getClientName(compcode, client);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (Session["FILTER"].ToString() == "D")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, Session["revenue"].ToString());
            }
            else
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, "0");
            }
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public void submit(string compcode,string fromdate,string todate,string agency,string client,string cioid)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, fromdate, todate, agency, client, cioid };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.PaymentMode chk = new NewAdbooking.Classes.PaymentMode();

            //   ds = chk.insertpayment(paycode, payname, compcode, userid, alias, cash);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();

                ds = save.submit(compcode,fromdate, todate, agency, client, cioid);
            }
            else
            {
                string procedureName = "executivefind";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

                //NewAdbooking.classmysql.PaymentMode chk = new NewAdbooking.classmysql.PaymentMode();
                //ds = chk.insertpayment(paycode, payname, compcode, userid);
            }

    }

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "chk" + j;
            string str1 = "exe" + j;
            string str2 = "cle" + j;
            string str3 = "ret" + j;
            string str4 = "add" + j;
            string str5 = "agen" + j;
            e.Item.Cells[9].Text = "<input type=button id= '" + str + "' value=Update Exec  style='height:24px;width:65px;font-family: Arial;font-size:xx-small;' onclick=\"updateexecutive112('" + e.Item.Cells[8].Text + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + e.Item.Cells[0].Text + "')\" >";
            e.Item.Cells[8].Text = "<input type=text id= '" + str1 + "' style='height:13px;width:100px;border: 1px solid #929292;' value='" + e.Item.Cells[8].Text + "' onkeyup=\"filllist(event,'" + str1 + "')\" >";           
            e.Item.Cells[5].Text = "<input type=text id= '" + str2 + "' style='height:13px;width:100px;border: 1px solid #929292;' value='" + e.Item.Cells[5].Text + "' onkeyup=\"fillCLIENT(event,'" + str2 + "')\" >";
            e.Item.Cells[7].Text = "<input type=text id= '" + str3 + "' style='height:13px;width:100px;border: 1px solid #929292;' value='" + e.Item.Cells[7].Text + "' onkeyup=\"fillretainer(event,'" + str3 + "')\" >";
            e.Item.Cells[6].Text = "<input type=text id= '" + str4 + "' style='height:13px;width:100px;border: 1px solid #929292;' value='" + e.Item.Cells[6].Text + "' onkeyup=\"fillAdd(event,'" + str4 + "')\" >";
            e.Item.Cells[1].Text = "<input type=text id= '" + str5 + "' style='height:13px;width:100px;border: 1px solid #929292;' value='" + e.Item.Cells[1].Text + "' onkeyup=\"fillagen(event,'" + str5 + "')\" >";

            //  e.Item.Cells[6].Text = "<input    type=button value=Update  id=" + str + "    value=" + e.Item.Cells[6].Text + " onclick=\"updateexecutive112('" + e.Item.Cells[6].Text + "','this.id')\" />";

            j++;
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {       
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { hdnclientcode.Value, hdncode.Value, hdncodesubcode.Value, txtciod.Text, txtfrmdate.Text, txttodate1.Text, hiddendateformat.Value };
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();
            ds = save.bindgridexecutive(hdnclientcode.Value, hdncode.Value, hdncodesubcode.Value, txtciod.Text, txtfrmdate.Text, txttodate1.Text);
        }
        else if  (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive save = new NewAdbooking.Classes.changeexecutive();
            ds = save.bindgridexecutive(hdnclientcode.Value, hdncode.Value, hdncodesubcode.Value, txtciod.Text, txtfrmdate.Text, txttodate1.Text, hiddendateformat.Value);
        }

         else
         {
             string procedureName = "bindexecutivegrid";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string cli)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, cli };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagencycli.clientxls(compcol, cli);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
            ds = adagencycli.clientxls(compcol, cli);
        }

        else
        {
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet F2fillretainercr_exe(string compcol, string ret)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcol, ret };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = objregion.retainerxls(compcol, ret);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.retainerxls(compcol, ret);
        }
        else
        {
            string procedureName = "xlsRetainerbind_xlsRetainerbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }


    [Ajax.AjaxMethod]

    public DataSet billupdatedata(string compcode, string ciobookid, string userid, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5, string flag)
    {
        DataSet dsch = new DataSet();
        string[] parameterValueArray = new string[] { compcode, ciobookid, userid, dateformat, extra1, extra2, extra3, extra4, extra5, flag };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive bindbgcolor = new NewAdbooking.Classes.changeexecutive();
            dsch = bindbgcolor.billupdatedata(compcode, ciobookid, userid, dateformat, extra1, extra2, extra3, extra4, extra5, flag);
           // dsch = bindbgcolor.billupdatedata(compcode, ciobookid, suppl_date, suppl_billno, userid, dateformat, flag);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                //dsch = bindbgcolor.billupdatedata(compcode, ciobookid, userid, dateformat, extra1, extra2, extra3, extra4, extra5, flag);
                string procedureName = "billdet_for_bill_update_data_N";
                NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
                dsch = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                string procedureName = "billdet_for_bill_update_data_N";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                dsch = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return dsch;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet adbillsmodificationvalidate(string compcode, string centcode, string branch, string supplementbillno, string supplementbilldate, string dateformat, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet dsch = new DataSet();
        string[] parameterValueArray = new string[] { compcode, centcode, branch, supplementbillno, supplementbilldate, dateformat, userid, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive bindbgcolor = new NewAdbooking.Classes.changeexecutive();
            dsch = bindbgcolor.adbillsmodificationvalidate(compcode, centcode, branch, supplementbillno, supplementbilldate, dateformat, userid, extra1, extra2, extra3, extra4, extra5);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.adbooking bindbgcolor = new NewAdbooking.classesoracle.adbooking();
                ////dsch = bindbgcolor.adbillsmodificationvalidate(compcode, centcode, branch, supplementbillno, supplementbilldate, dateformat, userid, extra1, extra2, extra3, extra4, extra5);
                
                string procedureName = "ad_bills_modification_validate";
                NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
                dsch = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            
            }

            else
            {
                string procedureName = "ad_bills_modification_validate";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                dsch = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return dsch;
    }

}
