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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class representative_ledger : System.Web.UI.Page
{
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "ShowAlert", strAlert, true);
    }
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            if (Session["dateformat"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                hiddendateformat.Value = Session["dateformat"].ToString();
                hiddencompcode.Value = Session["compcode"].ToString();
                hiddenuserid.Value = Session["userid"].ToString();
                hdncompcode.Value = Session["compcode"].ToString();
            }
            Ajax.Utility.RegisterTypeForAjax(typeof(representative_ledger));
            txt_retainer.Enabled = false;
          
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

            lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
            lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[84].ToString();
            lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            lbrevenue.Text = ds.Tables[0].Rows[0].ItemArray[72].ToString();
            lbteam.Text = ds.Tables[0].Rows[0].ItemArray[85].ToString();
            
            BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
           
            lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();

            lbag.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            lbcl.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
           
            executivewise.Text = ds.Tables[0].Rows[0].ItemArray[88].ToString();
            retainerwise.Text = ds.Tables[0].Rows[0].ItemArray[89].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[93].ToString();
            lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[94].ToString();
            btnsummary.Text = ds.Tables[0].Rows[0].ItemArray[95].ToString();

            DataSet dsj = new DataSet();
            dsj.ReadXml(Server.MapPath("XML/billbook.xml"));
            retainer.Text = dsj.Tables[0].Rows[0].ItemArray[25].ToString();
           

            DataSet df = new DataSet();
            df.ReadXml(Server.MapPath("XML/report1.xml"));
            heading.Text = df.Tables[0].Rows[0].ItemArray[8].ToString();

            if (!IsPostBack)
            {
                publicationbind();
                binddest();
                bindteam();
                bindrev();
                bindstatus();
                bindadvtype();
               // bindagecli();
              //  bindagency();
             
              //  bindretainer();
                bindload();
                bindbranch();

                BtnRun.Attributes.Add("OnClick", "javascript:return runclickbarter_exe();");
                btnsummary.Attributes.Add("OnClick", "javascript:return runclickbarter_exe();");
               // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
               
                //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
                //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
                //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
                //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
                //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
                //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
               
                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

                dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
                executivewise.Attributes.Add("onclick", "javascript:return executewise();");
                retainerwise.Attributes.Add("onclick", "javascript:return retainwise();");
               
                rbclient.Attributes.Add("onclick", "javascript:return radio('rbclient');");
                rbagency.Attributes.Add("onclick", "javascript:return radio('rbagency');");
                dpteam.Attributes.Add("onchange", "javascript:return bind_exe_represen();");
                Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
                exe.Attributes.Add("onclick", "javascript:return enable_exe();");
                csv.Attributes.Add("onclick", "javascript:return enable_csv();");

                txt_agency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_exe(event);");
                txt_agency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_exe(event);");

                lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency_exe(event);");
                lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency_exe(event);");

                txt_client.Attributes.Add("onkeydown", "javascript:return F2fillclientcr_exe(event);");
                txt_client.Attributes.Add("onkeypress", "javascript:return F2fillclientcr_exe(event);");

                lstclient.Attributes.Add("onclick", "javascript:return Clickclient_exe(event);");
                lstclient.Attributes.Add("onkeydown", "javascript:return Clickclient_exe(event);");

                txt_retainer.Attributes.Add("onkeydown", "javascript:return F2fillretainercr_exe(event);");
                txt_retainer.Attributes.Add("onkeypress", "javascript:return F2fillretainercr_exe(event);");

                lstretainer.Attributes.Add("onclick", "javascript:return Clickretainer_exe(event);");
                lstretainer.Attributes.Add("onkeydown", "javascript:return Clickretainer_exe(event);");



                txtdistrict.Attributes.Add("onkeydown", "javascript:return F2filldistrict(event);");
                lstdistrict.Attributes.Add("onclick", "javascript:return Clickdistrict(event);");
                lstdistrict.Attributes.Add("onkeydown", "javascript:return Clickdistrict(event);");



            }

        }
    }




    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }

        dpd_branch.SelectedValue = Session["revenue"].ToString();

    }



    [Ajax.AjaxMethod]
    public DataSet fillF2_CreditAgency(string compcol, string agen)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else
        {
            string procedureName = "bindagencyforxls_bindagencyforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcol, agen };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string cli)
    {
        DataSet ds = new DataSet();
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
            string[] parameterValueArray = new string[] { compcol, cli };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditretainer(string compcol, string ret)
    {
        DataSet ds = new DataSet();
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
            string[] parameterValueArray = new string[] { compcol, ret };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
  
    public void bindload()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Executive Name--";
        li1.Value = "0";
        dpexec.Items.Add(li1);
        
    }
    //public void bindretainer()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //    NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
    //    ds = objregion.bindretainer(Session["compcode"].ToString());
    //    }
    //     else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
    //        ds = objregion.bindretainer(Session["compcode"].ToString());
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = ("Select Retainer");
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    txt_retainer.Items.Add(li1);



    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        txt_retainer.Items.Add(li);


    //    }
    //}
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string value = "";
        string rep = "";
        string chk_excel = "";
        if (Txtdest.SelectedValue == "4")
        {
            if (exe.Checked == true)
            {
                chk_excel = "1";//excel
            }
            else
            {
                chk_excel = "2";//csv
            }

        }
        else
        {
            chk_excel = "0";//other than excel
        }

        if (executivewise.Checked == true)
            rep = "1";
        else
            rep = "2";
        if (rbagency.Checked == true)
        {
            value = "1";


            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    from_date = DMYToMDY(txtfrmdate.Text);
                    to_date = DMYToMDY(txttodate1.Text);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    from_date = YMDToMDY(txtfrmdate.Text);
                    to_date = YMDToMDY(txttodate1.Text);
                }
                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                ds = obj.representative(dppubcent.SelectedValue, dpaddtype.SelectedValue, from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
                ds = obj.representative(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
            }
            else
            {
                string procedureName = "Representative_Representative_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            
            if (ds.Tables[0].Rows.Count == 0)
            {
               
                ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "alert(\"searching criteria is not valid\");", true);
                return;
            }
            else
            {
              
                Session["from"] = txtfrmdate.Text;
                Session["to"] = txttodate1.Text;
                Session["repledger"] = ds;
                Session["prm_repledger"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~pubcent~" + dppubcent.SelectedValue + "~publication~" + dppub1.SelectedValue + "~publicationname~" + dppub1.SelectedItem.Text + "~adtyp~" + dpaddtype.SelectedValue + "~value~" + value + "~execut~" + hiddenexecutive.Value + "~team~" + dpteam.SelectedValue + "~bill~" + txtbill.Text + "~cl~" + hdnclient.Value + "~ag~" + hdnagency.Value + "~retainercode~" + hdnretainer.Value + "~retainername~" + txt_retainer.Text + "~rep~" + rep + "~pubcentname~" + dppubcent.SelectedItem.Text + "~adtypename~" + dpaddtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~districtname~" + txtdistrict.Text + "~branchname~" + dpd_branch.SelectedItem.Text + "~branch~" + dpd_branch.SelectedValue + "~branchname~" + dpd_branch.SelectedItem.Text + "~districtcode~" + hidden_dist.Value;
                    Response.Redirect("representative_view.aspx");
//                Response.Redirect("representative_view.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&value=" + value + "&execut=" +hiddenexecutive.Value + "&team=" + dpteam.SelectedValue + "&bill=" + txtbill.Text + "&cl=" + hdnclient.Value + "&ag=" + hdnagency.Value + "&retainercode=" + hdnretainer.Value + "&retainername=" + txt_retainer.Text + "&rep=" + rep + "&pubcentname=" + dppubcent.SelectedItem.Text + "&adtypename=" + dpaddtype.SelectedItem.Text);
            }


        }
        else
        {
            if (hdnagency.Value != "0")
            {


                value = "2";
                string excel = "4";
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                    ds = obj.representative(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString() ,dpd_branch.SelectedValue, hidden_dist_text.Value);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
                    ds = obj.representative(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
                }
                else
                {
                    string procedureName = "Representative_Representative_p";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = new string[] { dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }

              
                if (ds.Tables[0].Rows.Count == 0)
                {
                   
                    ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "alert(\"searching criteria is not valid\");", true);
                    return;
                }
                else
                {
                   
                    Session["from"] = txtfrmdate.Text;
                    Session["to"] = txttodate1.Text;

                    Response.Redirect("representative_view.aspx?&destination=" + excel + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&value=" + value + "&execut=" + dpexec.SelectedValue + "&team=" + dpteam.SelectedValue + "&bill=" + txtbill.Text + "&cl=" + hdnclient.Value + "&ag=" + hdnagency.Value + "&retainercode=" + hdnretainer.Value + "&retainername=" + txt_retainer.Text + "&rep=" + rep);
                }

            }
            else
            {
                AspNetMessageBox("Please Select Agency");
            }

        }




    }

    //protected void btnxl_Click(object sender, EventArgs e)
    //{
    //    string excel = "4";
    //    string value = "";
    //    string rep = "";
    //    if (executivewise.Checked == true)
    //        rep = "1";
    //    else
    //        rep = "2";
    //    if (rbagency.Checked == true)
    //    {
    //        value = "1";


    //        SqlDataAdapter da = new SqlDataAdapter();
    //        DataSet ds = new DataSet();
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //        {
    //            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    //            //ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
    //        }
    //        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
    //            ds = obj.representative(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value,hdnretainer.Value,rep);
    //        }
    //        else
    //        {
    //        }
    //        //int cont = ds.Tables[0].Rows.Count;

    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
    //            //return;
    //            ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "alert(\"searching criteria is not valid\");", true);
    //            return;
    //        }
    //        else
    //        {
    //            // Response.Redirect("disschregview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&agencyname=" + txtagency.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&Product=" + txtproduct.Text + "&client=" + txtclient.Text + "&region=" + dpregion.SelectedValue + "&publication="+dppub1.SelectedValue);

    //            Session["from"] = txtfrmdate.Text;
    //            Session["to"] = txttodate1.Text;

    //            Response.Redirect("representative_view.aspx?&destination=" + excel + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&value=" + value + "&execut=" + dpexec.SelectedValue + "&team=" + dpteam.SelectedValue + "&bill=" + txtbill.Text + "&cl=" + hdnclient.Value + "&ag=" + hdnagency.Value + "&retainercode=" + hdnretainer.Value + "&retainername" + txt_retainer.Text);
    //        }


    //    }
    //    else
    //    {
    //        value = "2";

    //        SqlDataAdapter da = new SqlDataAdapter();
    //        DataSet ds = new DataSet();
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //        {
    //            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    //            //ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
    //        }
    //        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
    //            ds = obj.representative(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value,hdnretainer.Value,rep);
    //        }
    //        else
    //        {
    //        }
    //        //int cont = ds.Tables[0].Rows.Count;

    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
    //            //return;
    //            ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "alert(\"searching criteria is not valid\");", true);
    //            return;
    //        }
    //        else
    //        {
    //            // Response.Redirect("disschregview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&agencyname=" + txtagency.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&Product=" + txtproduct.Text + "&client=" + txtclient.Text + "&region=" + dpregion.SelectedValue + "&publication="+dppub1.SelectedValue);

    //            Session["from"] = txtfrmdate.Text;
    //            Session["to"] = txttodate1.Text;

    //            Response.Redirect("representative_view.aspx?&destination=" + excel + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&value=" + value + "&execut=" + dpexec.SelectedValue + "&team=" + dpteam.SelectedValue + "&bill=" + txtbill.Text + "&cl=" + hdnclient.Value + "&ag=" + hdnagency.Value + "&retainercode=" + hdnretainer.Value + "&retainername" + txt_retainer.Text);
    //        }



    //    }




    //}

    //public void bindagecli()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());

    //    }
        

    //    ListItem li1;
    //    li1 = new ListItem();
    //    txt_client.Items.Clear();


    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_client.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        txt_client.Items.Add(li);
    //    }
    //}

    //public void bindagency()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
    //        ds = adagencycli.agency(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = adagencycli.agency(Session["compcode"].ToString());

    //    }
    //    ListItem li1;
    //    li1 = new ListItem();
    //    txt_agency.Items.Clear();


    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    txt_agency.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        txt_agency.Items.Add(li);


    //    }

    //}

    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li);


        }
    }


    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else
        {
            string procedureName = "pubcent_proc_pubcent_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }
        dppubcent.SelectedValue = Session["center"].ToString();

    }

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }


   
    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
       
    }

    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

     
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString()};
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       

        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpaddtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpaddtype.Items.Add(li);


        }
    }

    public void bindteam()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SummaryReport advpub = new NewAdbooking.Report.classesoracle.SummaryReport();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Bind_team";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
     
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpteam.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpteam.Items.Add(li);


        }
    }
    public void bindrevcentre()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindexecutive(Session["compcode"].ToString(), dpteam.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SummaryReport objregion = new NewAdbooking.Report.classesoracle.SummaryReport();
            ds = objregion.bindexecutive(Session["compcode"].ToString(), dpteam.SelectedValue);
        }
        else
        {
            string procedureName = "Get_Execexec";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), dpteam.SelectedValue };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/executivemaster.xml"));

        dpexec.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();

        li1.Value = "0";
        li1.Selected = true;
        dpexec.Items.Add(li1);



        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpexec.Items.Add(li);

        }


    }

    public void bindrev()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
      
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());

        }
        else
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString()};
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[31].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dppub1.Items.Add(li);


        }
    }

    [Ajax.AjaxMethod]
    public DataSet exe_bind(string comp_code, string userid, string team)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
            ds = exec.adexec(comp_code, userid, team);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
            ds = exec.adexec(comp_code, userid, team);

        }
        else
        {
            string procedureName = "xlsBindexec_xlsBindexec_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { comp_code, userid, team };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }






    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcode, string uid)
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.district(compcode, uid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.district(compcode, uid);
        }
        else
        {
            string procedureName = "CityMst_District";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, uid };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    protected void Btnsummaryclick(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string value = "";
        string rep = "";
        string chk_excel = "";
        if (Txtdest.SelectedValue == "4")
        {
            if (exe.Checked == true)
            {
                chk_excel = "1";//excel
            }
            else
            {
                chk_excel = "2";//csv
            }

        }
        else
        {
            chk_excel = "0";//other than excel
        }

        if (executivewise.Checked == true)
            rep = "1";
        else
            rep = "2";
        if (rbagency.Checked == true)
        {
            value = "1";


            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    from_date = DMYToMDY(txtfrmdate.Text);
                    to_date = DMYToMDY(txttodate1.Text);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    from_date = YMDToMDY(txtfrmdate.Text);
                    to_date = YMDToMDY(txttodate1.Text);
                }
                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                ds = obj.representativesummary(dppubcent.SelectedValue, dpaddtype.SelectedValue, from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
                ds = obj.representativesummary(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
            }
            else
            {
                string procedureName = "Representative_summmery";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "alert(\"searching criteria is not valid\");", true);
                return;
            }
            else
            {

                Session["from"] = txtfrmdate.Text;
                Session["to"] = txttodate1.Text;
                Session["repledger"] = ds;
                Session["prm_repledger"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~pubcent~" + dppubcent.SelectedValue + "~publication~" + dppub1.SelectedValue + "~publicationname~" + dppub1.SelectedItem.Text + "~adtyp~" + dpaddtype.SelectedValue + "~value~" + value + "~execut~" + hiddenexecutive.Value + "~team~" + dpteam.SelectedValue + "~bill~" + txtbill.Text + "~cl~" + hdnclient.Value + "~ag~" + hdnagency.Value + "~retainercode~" + hdnretainer.Value + "~retainername~" + txt_retainer.Text + "~rep~" + rep + "~pubcentname~" + dppubcent.SelectedItem.Text + "~adtypename~" + dpaddtype.SelectedItem.Text + "~chk_excel~" + chk_excel + "~districtname~" + txtdistrict.Text + "~branchname~" + dpd_branch.SelectedItem.Text + "~branch~" + dpd_branch.SelectedValue + "~branchname~" + dpd_branch.SelectedItem.Text + "~districtcode~" + hidden_dist.Value;
                Response.Redirect("representative_ledgersummary.aspx");
                //                Response.Redirect("representative_view.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&value=" + value + "&execut=" +hiddenexecutive.Value + "&team=" + dpteam.SelectedValue + "&bill=" + txtbill.Text + "&cl=" + hdnclient.Value + "&ag=" + hdnagency.Value + "&retainercode=" + hdnretainer.Value + "&retainername=" + txt_retainer.Text + "&rep=" + rep + "&pubcentname=" + dppubcent.SelectedItem.Text + "&adtypename=" + dpaddtype.SelectedItem.Text);
            }


        }
        else
        {
            if (hdnagency.Value != "0")
            {


                value = "2";
                string excel = "4";
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                    ds = obj.representativesummary(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
                    ds = obj.representativesummary(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value);
                }
                else
                {
                    string procedureName = "Representative_summmery";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] parameterValueArray = new string[] { dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, dpexec.SelectedValue, dpteam.SelectedValue, txtbill.Text, hdnclient.Value, hdnagency.Value, hdnretainer.Value, rep, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, hidden_dist_text.Value };
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }


                if (ds.Tables[0].Rows.Count == 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "alert(\"searching criteria is not valid\");", true);
                    return;
                }
                else
                {

                    Session["from"] = txtfrmdate.Text;
                    Session["to"] = txttodate1.Text;

                    Response.Redirect("representative_ledgersummary.aspx?&destination=" + excel + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&value=" + value + "&execut=" + dpexec.SelectedValue + "&team=" + dpteam.SelectedValue + "&bill=" + txtbill.Text + "&cl=" + hdnclient.Value + "&ag=" + hdnagency.Value + "&retainercode=" + hdnretainer.Value + "&retainername=" + txt_retainer.Text + "&rep=" + rep);
                }

            }
            else
            {
                AspNetMessageBox("Please Select Agency");
            }

        }




    }


}
