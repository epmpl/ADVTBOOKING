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
using System.Data.OracleClient;
using System.Data.SqlClient;
public partial class dealaudit : System.Web.UI.Page
{
    int i = 0;
    public string currency;
    string dateformat, formname;
    string branch;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        DataGrid1.Visible = true;

        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        currency = Session["currency"].ToString();
        formname = "dealaudit";
        dateformat = Session["dateformat"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddencenter.Value = Session["revenue"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencurrency.Value = Session["currency"].ToString();
        hiddenconnect.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(dealaudit));







        if (!Page.IsPostBack)
        {

            DataSet objDataSet = new DataSet();

            objDataSet.ReadXml(Server.MapPath("XML/dealaudit.xml"));

            lbad.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
            lbvf.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
            lbvt.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            AgencyCode.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            ClientName.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
            lbat.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
            lbde.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
            lblremark.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
            lblchk.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
            lbllevel.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();

            Ajax.Utility.RegisterTypeForAjax(typeof(dealaudit));


            //drpclientname.Attributes.Add("OnChange", "javascript:return clientChange();");
            btnexit.Attributes.Add("onclick", "javascript:return catexitclick();");
            btnsubmit.Attributes.Add("onclick", "javascript:return submclick();");
            davt.Attributes.Add("OnChange", "javascript:return isDate(dtStr);");
            davf.Attributes.Add("OnChange", "javascript:return isDate(dtStr);");
            btnaudit.Attributes.Add("onclick", "javascript:return auditdeal();");
            approvedby.Attributes.Add("onclick", "javascript:return auditdealunapp();");
            davf.Attributes.Add("OnChange", "javascript:return checkdate(this); ");
            davt.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            btnclear.Attributes.Add("onclick", "javascript:return Cancel();");
            drpat.Attributes.Add("OnChange", "javascript:return diabel();");
            txtde.Attributes.Add("onkeydown", "javascript:return tabvalue1(event);");
            drpagencycode.Attributes.Add("onkeydown", "javascript:return enterf2(event);");
            drpclientname.Attributes.Add("onkeydown", "javascript:return enterf2(event);");
            btnaudit.Enabled = false;
            approvedby.Enabled = false;

        }

    }



    [Ajax.AjaxMethod]
    public DataSet client_Change(string client, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindproduct = new NewAdbooking.Classes.Contract();
            ds = bindproduct.productbind(client, compcode, userid);
        }
        else
        {
            NewAdbooking.classesoracle.Contract bindproduct = new NewAdbooking.classesoracle.Contract();
            ds = bindproduct.productbind(client, compcode, userid);
        }

        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
        }
        else
        {
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            //}
            //else
            //{
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
            //}
        }
        return ds;



    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
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

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string addclientname(string page, string datetime, string value)
    {
        DataSet dag = new DataSet();
        string nameadd = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master getagenameaddress = new NewAdbooking.Classes.Master();

            dag = getagenameaddress.getClientNameadd(page, Session["compcode"].ToString(), value, "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master getagenameaddress = new NewAdbooking.classesoracle.Master();

            dag = getagenameaddress.getClientNameadd(page, Session["compcode"].ToString(), value, "");
        }
        else
        {
            //NewAdbooking.classmysql.BookingMaster getagenameaddress = new NewAdbooking.classmysql.BookingMaster();

            //dag = getagenameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date, Session["dateformat"].ToString());

        }

        if (dag.Tables[0].Rows.Count > 0)
        {
            string clientname = dag.Tables[0].Rows[0].ItemArray[1].ToString();
            string code = dag.Tables[0].Rows[0].ItemArray[0].ToString();
            string address = dag.Tables[0].Rows[0].ItemArray[2].ToString();
            if (address == "null")
                address = "";
            //string agentypename = dag.Tables[1].Rows[0].ItemArray[0].ToString();
            //string agenstatus = dag.Tables[2].Rows[0].ItemArray[0].ToString();
            //string credit = dag.Tables[3].Rows[0].ItemArray[0].ToString();
            //string rategroup = dag.Tables[4].Rows[0].ItemArray[0].ToString();
            //string comm = dag.Tables[5].Rows[0].ItemArray[0].ToString();
            //string pay = dag.Tables[6].Rows[0].ItemArray[0].ToString();

            nameadd = clientname + "(" + code + ")" + "+" + address;
            //Response.Write(nameadd);
            //Response.End();


        }
        return nameadd;



    }


    [Ajax.AjaxMethod]
    public DataSet agencyChange(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Contract bindsub = new NewAdbooking.Classes.Contract();
            ds = bindsub.bindsubagency(agency, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindsub = new NewAdbooking.classesoracle.Contract();
            ds = bindsub.bindsubagency(agency, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.Contract bindsub = new NewAdbooking.classmysql.Contract();
            ds = bindsub.bindsubagency(agency, compcode, userid);
        }
        return ds;
    }
    /*   [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
       public DataSet updatestatus(string dealid, string userid,string remark)
       {
           DataSet ds = new DataSet();
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
           {

               NewAdbooking.Classes.dealaudi bindsub = new NewAdbooking.Classes.dealaudi();
               ds = bindsub.updatedealstatus(Session["compcode"].ToString(),dealid, userid, remark);
           }
           else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
           {
               NewAdbooking.classesoracle.dealaudi bindsub = new NewAdbooking.classesoracle.dealaudi();
               ds = bindsub.updatedealstatus(Session["compcode"].ToString(),dealid, userid, remark);
           }
           else
           {
             
           }
           return ds;
       }
     */
    /* [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
     public DataSet updatestatusunapp(string dealid, string userid, string remark)
     {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {

             NewAdbooking.Classes.dealaudi bindsub = new NewAdbooking.Classes.dealaudi();
             ds = bindsub.updatedealstatusunapp(Session["compcode"].ToString(),dealid, userid, remark);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.dealaudi bindsub = new NewAdbooking.classesoracle.dealaudi();
             ds = bindsub.updatedealstatusunapp(Session["compcode"].ToString(),dealid, userid, remark);
         }
         else
         {

         }
         return ds;
     }
    */

    [Ajax.AjaxMethod]
    public DataSet updatestatus(string compcode, string dealid, string userid, string remark, string unit, string seq, string percentage, string lvl, string dealpass, string disamt)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.dealaudi bindsub = new NewAdbooking.Classes.dealaudi();
            ds = bindsub.updatedealstatus(compcode, dealid, userid, remark, unit, seq, percentage, lvl, dealpass, disamt);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.dealaudi bindsub = new NewAdbooking.classesoracle.dealaudi();
            ds = bindsub.updatedealstatus(compcode, dealid, userid, remark, unit, seq, percentage, lvl, dealpass, disamt);
        }
        else
        {
            NewAdbooking.classmysql.Contract bindsub = new NewAdbooking.classmysql.Contract();
            ds = bindsub.updatedealstatus(compcode, dealid, userid, remark, unit, seq, percentage, lvl, dealpass, disamt);


        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public string getseq()
    {
        try
        {
            string NExt_seq = "";
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = ConfigurationSettings.AppSettings["orclconnectionstring"].ToString();
                con.Open();
                OracleCommand cmd = new OracleCommand();
                string str = "SELECT AD_passlevel_SEQ.NEXTVAL FROM DUAL";
                cmd.CommandText = str;
                cmd.Connection = con;

                OracleDataAdapter da = new OracleDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds);
                NExt_seq = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                con.Close();
                con.Dispose();
            }
            else
            {
                //NewAdbooking.Classes.adbookpackagerate name = new NewAdbooking.Classes.adbookpackagerate();
                //ds = name.sequence34();
                //NExt_seq = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationSettings.AppSettings["sqlConnectionString"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string str = "SELECT NEXT VALUE FOR Test.CountBy1";
                cmd.CommandText = str;
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds);
                NExt_seq = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                con.Close();
                con.Dispose();
            }
            return NExt_seq;
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
    //[Ajax.AjaxMethod]
    //public DataSet submit(string compcode, string adtype, string vf, string vt, string agencycode, string clintname, string de, string at, string dateforma)
    //{
    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {

    //        NewAdbooking.Classes.dealaudi sub = new NewAdbooking.Classes.dealaudi();
    //        ds = bindsub.sub(compcode, adtype, vf, vt, agencycode, clintname, de, at, dateforma);
    //    }
    //    //else
    //    //{
    //    //    NewAdbooking.classesoracle.dealaudit bindsub = new NewAdbooking.classesoracle.dealaudit();
    //    //    ds = bindsub.sub(compcode, adtype, vf, vt, agencycode, clintname, de, at, dateforma);

    //    //}
    //    DataGrid1.DataSource = ds;
    //    DataGrid1.DataBind();


    //}

    //protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    //{



    //}


    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{
    //    if (Session["hdnflag"] == "T")
    //    {

    //        Session["hdnflag"] = null;
    //        DataSet ds = new DataSet();
    //        string agencycodee = "";
    //        string adtype = "";
    //        string clintname = "";


    //        if (drpagencycode.Text != "" && drpagencycode.Text.LastIndexOf("(") >= 0)
    //        {
    //            agencycodee = drpagencycode.Text.Substring(drpagencycode.Text.LastIndexOf("(") + 1, drpagencycode.Text.Length - drpagencycode.Text.LastIndexOf("(") - 2);

    //        }
    //        if (drpclientname.Text != "" && drpclientname.Text.LastIndexOf("(") >= 0)
    //        {
    //            clintname = drpclientname.Text.Substring(drpclientname.Text.LastIndexOf("(") + 1, drpclientname.Text.Length - drpclientname.Text.LastIndexOf("(") - 2);

    //        }



    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //        {

    //            NewAdbooking.Classes.dealaudi bindsub = new NewAdbooking.Classes.dealaudi();
    //            if (drpad.SelectedValue == "0")
    //            {
    //                adtype = "0";
    //            }
    //            else
    //            {
    //                adtype = drpad.SelectedValue;
    //            }



    //            ds = bindsub.sub(Session["compcode"].ToString(), drpad.SelectedValue, davf.Text, davt.Text, agencycodee, clintname, txtde.Text, drpat.SelectedValue, Session["dateformat"].ToString(), drpchk.SelectedValue, Session["userid"].ToString());

    //            //            ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, dpagencyna.SelectedValue, dpagencycli.SelectedValue, branch, dpretainer.SelectedValue, dpexecutive.SelectedValue, hiddensupplement.Value, drpstatus.SelectedValue);
    //        }
    //        else
    //        {
    //            NewAdbooking.classesoracle.dealaudi bindsub = new NewAdbooking.classesoracle.dealaudi();



    //            if (drpad.SelectedValue == "0")
    //            {
    //                adtype = "0";
    //            }
    //            else
    //            {
    //                adtype = drpad.SelectedValue;
    //            }

    //            ds = ds = bindsub.sub(Session["compcode"].ToString(), drpad.SelectedValue, davf.Text, davt.Text, drpagencycode.Text, clintname, txtde.Text, drpat.SelectedValue, Session["dateformat"].ToString());


    //            // ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, dpagencyna.SelectedValue, dpagencycli.SelectedValue, branch, dpretainer.SelectedValue, dpexecutive.SelectedValue, hiddensupplement.Value, drpstatus.SelectedValue);

    //        }
    //        Session["RowLen"] = ds.Tables[0].Rows.Count;
    //        hidden1.Value = Session["RowLen"].ToString();
    //        if (hidden1.Value == "0")
    //        {
    //            DataGrid1.DataSource = ds;
    //            DataGrid1.DataBind();
    //            //ScriptManager.RegisterClientScriptBlock(this, typeof(rate_audit_orderwise), "cc", "checklenthnew()", true);
    //        }
    //        else
    //        {

    //            //DataRow 

    //            ds.Tables[0].AcceptChanges();
    //            DataGrid1.DataSource = ds;
    //            DataGrid1.DataBind();
    //        }
    //    }
    //    else
    //    {
    //        txtde.Text="";
    //    drpad.SelectedValue="print";
    //    davf.Text="";
    //  davt.Text="";
    //  drpagencycode.Text="";
    //  drpclientname.Text="";

    //      txtremark.Text="";
    //      drpat.SelectedValue="0";
    //        DataGrid1.Visible = false;
    //    }
    //}

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Session["hdnflag"] = "T";

        if (Session["hdnflag"] == "T")
        {

            Session["hdnflag"] = null;
            DataSet ds = new DataSet();
            string agencycodee = "";
            string adtype = "";
            string clintname = "";
            if (branch != "" || branch != "null")
            {
                hiddenbranchcode.Value = branch;
            }
            else
            {
                hiddenbranchcode.Value = "";
            }

            if (drpagencycode.Text != "" && drpagencycode.Text.LastIndexOf("(") >= 0)
            {
                agencycodee = drpagencycode.Text.Substring(drpagencycode.Text.LastIndexOf("(") + 1, drpagencycode.Text.Length - drpagencycode.Text.LastIndexOf("(") - 2);

            }
            if (drpclientname.Text != "" && drpclientname.Text.LastIndexOf("(") >= 0)
            {
                clintname = drpclientname.Text.Substring(drpclientname.Text.LastIndexOf("(") + 1, drpclientname.Text.Length - drpclientname.Text.LastIndexOf("(") - 2);

            }

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.dealaudi bindsub = new NewAdbooking.Classes.dealaudi();
                if (drpad.SelectedValue == "0")
                {
                    adtype = "0";
                }
                else
                {
                    adtype = drpad.SelectedValue;
                }
                ds = bindsub.sub(Session["compcode"].ToString(), drpad.SelectedValue, davf.Text, davt.Text, agencycodee, clintname, txtde.Text, drpat.SelectedValue, Session["dateformat"].ToString(), hiddenbranchcode.Value, Session["userid"].ToString());
                //            ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, dpagencyna.SelectedValue, dpagencycli.SelectedValue, branch, dpretainer.SelectedValue, dpexecutive.SelectedValue, hiddensupplement.Value, drpstatus.SelectedValue);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.dealaudi bindsub = new NewAdbooking.classesoracle.dealaudi();
                if (drpad.SelectedValue == "0")
                {
                    adtype = "0";
                }
                else
                {
                    adtype = drpad.SelectedValue;
                }
                ds = ds = bindsub.sub(Session["compcode"].ToString(), drpad.SelectedValue, davf.Text, davt.Text, agencycodee, clintname, txtde.Text, drpat.SelectedValue, Session["dateformat"].ToString(), hiddenbranchcode.Value, Session["userid"].ToString());
                // ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, dpagencyna.SelectedValue, dpagencycli.SelectedValue, branch, dpretainer.SelectedValue, dpexecutive.SelectedValue, hiddensupplement.Value, drpstatus.SelectedValue);
            }
            else
            {
                NewAdbooking.classmysql.Contract bindsub = new NewAdbooking.classmysql.Contract();
                if (drpad.SelectedValue == "0")
                {
                    adtype = "0";
                }
                else
                {
                    adtype = drpad.SelectedValue;
                }
                ds = ds = bindsub.sub(Session["compcode"].ToString(), drpad.SelectedValue, davf.Text, davt.Text, agencycodee, clintname, txtde.Text, drpat.SelectedValue, Session["dateformat"].ToString(), hiddenbranchcode.Value, Session["userid"].ToString());

            }
            Session["RowLen"] = ds.Tables[0].Rows.Count;
            hidden1.Value = Session["RowLen"].ToString();
            if (hidden1.Value == "0")
            {
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                //ScriptManager.RegisterClientScriptBlock(this, typeof(rate_audit_orderwise), "cc", "checklenthnew()", true);
            }
            else
            {

                //DataRow 

                ds.Tables[0].AcceptChanges();
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }
        }
        else
        {
            txtde.Text = "";
            drpad.SelectedValue = "print";
            davf.Text = "";
            davt.Text = "";
            drpagencycode.Text = "";
            drpclientname.Text = "";

            txtremark.Text = "";
            drpat.SelectedValue = "0";
            DataGrid1.Visible = false;
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        hiddenrowcount.Value = Session["RowLen"].ToString();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string bookingid = e.Item.Cells[2].Text;
            e.Item.Cells[2].Text = "<a style=\"cursor:hand;color:blue\" id='cio" + i + "'  onClick=\"bindGridDetails('" + e.Item.Cells[2].Text + "')\">" + e.Item.Cells[2].Text + "</a>";
            i = i + 1;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet tv_paid_balance_cal(string pcomp_code, string punit_code, string pchannel, string plocation_code, string pad_type, string pdealno, string pbtb_code, string ppaid_bonus)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract insert = new NewAdbooking.classesoracle.Contract();
            ds = insert.tv_paid_balance_cal(pcomp_code, punit_code, pchannel, plocation_code, pad_type, pdealno, pbtb_code, ppaid_bonus);

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            ds = insert.tv_paid_balance_cal(pcomp_code, punit_code, pchannel, plocation_code, pad_type, pdealno, pbtb_code, ppaid_bonus);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
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
    public DataSet binddealno(string compcode, string dealno, string mod)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            ds = insert.binddealNo(compcode, dealno, mod);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.dealaudi insert = new NewAdbooking.classesoracle.dealaudi();
            ds = insert.binddealNo(compcode, dealno, mod);
        }
        else
        {
            NewAdbooking.classmysql.Contract insert = new NewAdbooking.classmysql.Contract();
            ds = insert.binddealNo(compcode, dealno, mod);
        }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setviewstatevalue()
    {
        Session["hdnflag"] = "T";
    }

    protected void btnaudit_Click(object sender, EventArgs e)
    {

        btnsubmit_Click(sender, e);
    }
    [Ajax.AjaxMethod]
    public DataSet level(string compcode, string useid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.dealaudi insert = new NewAdbooking.Classes.dealaudi();
            ds = insert.levelper(compcode, useid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.dealaudi insert = new NewAdbooking.classesoracle.dealaudi();
            ds = insert.levelper(compcode, useid);
        }
        return ds;
    }


}


