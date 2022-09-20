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

public partial class ScheduleRegister : System.Web.UI.Page
{
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
                Session["access"] = "0";
                hiddendateformat.Value = Session["dateformat"].ToString();
                hdncompcode.Value = Session["compcode"].ToString();
                hiddencompcode.Value = Session["compcode"].ToString();
            }

            Ajax.Utility.RegisterTypeForAjax(typeof(ScheduleRegister));
            DataSet dsG = new DataSet();
            dsG.ReadXml(Server.MapPath("XML/report1.xml"));
            heading.Text = dsG.Tables[0].Rows[0].ItemArray[5].ToString();



            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

            lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

            lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();

            BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();

            lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            editiondetail.Text = ds.Tables[0].Rows[0].ItemArray[64].ToString();
            status.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[93].ToString();
            lblrostatus.Text = ds.Tables[0].Rows[0].ItemArray[97].ToString();
            lbldesigner.Text = ds.Tables[0].Rows[0].ItemArray[98].ToString();





            DataSet dsr = new DataSet();
            dsr.ReadXml(Server.MapPath("XML/billbook.xml"));
            suppliment.Text = dsr.Tables[0].Rows[0].ItemArray[3].ToString();
            if (!IsPostBack)
            {
                edition();
                bindadvtype();
                binddest();
                bindpub();
                bindstatus();
                publicationbind();
                bindedidetail();
                bindbranch();

                BtnRun.Attributes.Add("OnClick", "javascript:return chknessschedule_nn();");
                dpedition.Attributes.Add("onchange", "javascript:return suppforschedule();");

                dpaddtype.Attributes.Add("onchange", "javascript:return bindadcat_schedule();");
                dppubcent.Attributes.Add("onchange", "javascript:return bind_edition_sch();");
                dppub1.Attributes.Add("onchange", "javascript:return bind_edition_sch();");

                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                dpsuppliment.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpedition.Attributes.Add("onkeypress", "return keySort(this);");
                Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
                exe.Attributes.Add("onclick", "javascript:return enable_exe();");
                csv.Attributes.Add("onclick", "javascript:return enable_csv();");
                drppackagedetail.Attributes.Add("onchange", "javascript:return enable_pkg();");

                lstsectioncode.Attributes.Add("onclick", "javascript:return fillondesign(event);");
                lstsectioncode.Attributes.Add("onclick", "javascript:return fillondesign(event);");
                txt_designer.Attributes.Add("onkeydown", "javascript:return F2fillsectioncode(event);");
                txt_designer.Attributes.Add("onkeypress", "javascript:return F2fillsectioncode(event);");
                btnRunedtn.Attributes.Add("onclick", "javascript:return run();");




                ListItem li81;
                li81 = new ListItem();
                li81.Text = "Select supplement";
                li81.Value = "0";
                dpsuppliment.Items.Add(li81);



                ListItem li85;
                li85 = new ListItem();
                li85.Text = "--Select Package--";
                li85.Value = "0";
                drppackage.Items.Add(li85);

                drppackage.Enabled = false;
                bindpackagedetailreq();

            }
        }
    }


    //protected void dpaddtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string adtype = dpaddtype.SelectedValue;

    //    drppackage.Items.Clear();
    //    DataSet ds4 = new DataSet();
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
    //        ds4 = adcat.package_report(Session["compcode"].ToString(), adtype);
    //    }
    //    else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 adcat1 = new NewAdbooking.Report.classesoracle.Class1();
    //        ds4 = adcat1.package_report(Session["compcode"].ToString(), adtype);
    //    }

    //    ListItem li4;
    //    li4 = new ListItem();

    //    li4.Text = "--Select Package--";
    //    li4.Value = "0";
    //    li4.Selected = true;
    //    drppackage.Items.Add(li4);


    //    int i4;
    //    for (i4 = 0; i4 < ds4.Tables[0].Rows.Count; i4++)
    //    {
    //        ListItem li5;
    //        li5 = new ListItem();
    //        li5.Value = ds4.Tables[0].Rows[i4].ItemArray[0].ToString();
    //        li5.Text = ds4.Tables[0].Rows[i4].ItemArray[1].ToString();
    //        drppackage.Items.Add(li5);



    //    }






    //    dpadcatgory.Items.Clear();
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
    //        ds = adcat.advtype(adtype, Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = adcat.advtype(adtype, Session["compcode"].ToString());
    //    }
    //    else
    //    {
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    // li1.Selected = true;
    //    dpadcatgory.Items.Add(li1);

    //    //dpadcatgory.Items.Clear();
    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpadcatgory.Items.Add(li);



    //    }
    //    //ScriptManager.RegisterClientScriptBlock(this,"typeof(re)")
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(ScheduleRegister), "sa", "document.getElementById('dpaddtype').focus();", true);
    //}
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { pub, pub_cent, compcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        else
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet adpkg_bind(string adtype, string compcode)
    {

        DataSet ds4 = new DataSet();
        string[] parameterValueArray = new string[] { compcode, adtype };
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds4 = adcat.package_report(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat1 = new NewAdbooking.Report.classesoracle.Class1();
            ds4 = adcat1.package_report(compcode, adtype);
        }

        else
        {
            string procedureName = "BINDPACKAGEREPORT_BINDPACKAGEREPORT_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds4 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds4;

    }
    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { adtype, compcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }

        else
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, edition };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.pubsupply(compcode, edition);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.pubsupply(compcode, edition);
        }

        else
        {
            string procedureName = "bindsuppliment_bindsuppliment_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";

        string str = "";
        string str1 = "";
        string reptype = drpreptype.SelectedValue;
        str = hiddenadcat.Value;
        str1 = hiddenadcatname.Value;

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

        string hsuppliment = hdnsuppliment.Value;

        DataSet ds = new DataSet();
         string[] parameterValueArray = new string[] { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, hiddenedition.Value, dppubcent.SelectedValue, dpaddtype.SelectedValue, str, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), hsuppliment, hiddenpackage.Value, dpedidetail.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, ddlrostatus.SelectedValue};
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
            ds = obj.displayonscreenreport(from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, hiddenedition.Value, dppubcent.SelectedValue, dpaddtype.SelectedValue, str, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), hsuppliment, hiddenpackage.Value, dpedidetail.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, ddlrostatus.SelectedValue, txt_designer.Text);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, hiddenedition.Value, dppubcent.SelectedValue, dpaddtype.SelectedValue, str, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), hsuppliment, hiddenpackage.Value, dpedidetail.SelectedValue, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, ddlrostatus.SelectedValue);
            // ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, dpedition.SelectedValue, dppubcent.SelectedValue, dpaddtype.SelectedValue, dpadcatgory.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }

        else
        {
            string procedureName = "Schedulereport1";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(ScheduleRegister), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            // Response.Redirect("disschregview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&agencyname=" + txtagency.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&Product=" + txtproduct.Text + "&client=" + txtclient.Text + "&region=" + dpregion.SelectedValue + "&publication="+dppub1.SelectedValue);
            if (reptype == "O")
            {
                Session["from"] = txtfrmdate.Text;
                Session["to"] = txttodate1.Text;
                Session["schedulerep"] = ds;
                Session["rep_schedulerep"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~publicationname~" + dppub1.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~editionname~" + hiddeneditionname.Value + "~publicationcenter~" + dppubcent.SelectedItem.Text + "~pubcentcode~" + dppubcent.SelectedValue + "~adtype~" + dpaddtype.SelectedItem.Text + "~adtypecode~" + dpaddtype.SelectedValue + "~adcategory~" + str + "~editiondetail~" + dpedidetail.SelectedValue + "~status~" + drpstatus.SelectedValue + "~adcatname~" + str1 + "~supplementcode~" + hsuppliment + "~package11~" + hiddenpackage.Value + "~pkgdetail~" + drppackagedetail.SelectedValue + "~package11name~" + hiddenpackagename.Value + "~chk_excel~" + chk_excel + "~branch_code~" + dpd_branch.SelectedValue + "~branch_name~" + dpd_branch.SelectedItem.Text + "~designer~" + txt_designer.Text;
                Response.Redirect("ScheduleRegisterView.aspx");
                //Response.Redirect("ScheduleRegisterView.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&editionname=" + dpedition.SelectedItem.Text + "&publicationcenter=" + dppubcent.SelectedItem.Text + "&pubcentcode=" + dppubcent.SelectedValue + "&adtype=" + dpaddtype.SelectedItem.Text + "&adtypecode=" + dpaddtype.SelectedValue + "&adcategory=" + str + "&editiondetail=" + dpedidetail.SelectedValue + "&status=" + drpstatus.SelectedValue + "&adcatname=" + str1 + "&supplementcode=" + hsuppliment + "&package11=" + drppackage.SelectedValue + "&pkgdetail=" + drppackagedetail.SelectedValue + "&package11name=" + drppackage.SelectedItem.Text);
            }
            //else if (reptype == "E")
            //{
            //    Session["from"] = txtfrmdate.Text;
            //    Session["to"] = txttodate1.Text;
            //    Session["schedulerep"] = ds;
            //    Session["rep_schedulerep"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~publicationname~" + dppub1.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~editionname~" + hiddeneditionname.Value + "~publicationcenter~" + dppubcent.SelectedItem.Text + "~pubcentcode~" + dppubcent.SelectedValue + "~adtype~" + dpaddtype.SelectedItem.Text + "~adtypecode~" + dpaddtype.SelectedValue + "~adcategory~" + str + "~editiondetail~" + dpedidetail.SelectedValue + "~status~" + drpstatus.SelectedValue + "~adcatname~" + str1 + "~supplementcode~" + hsuppliment + "~package11~" + hiddenpackage.Value + "~pkgdetail~" + drppackagedetail.SelectedValue + "~package11name~" + hiddenpackagename.Value + "~chk_excel~" + chk_excel + "~branch_code~" + dpd_branch.SelectedValue + "~branch_name~" + dpd_branch.SelectedItem.Text + "~designer~" + txt_designer.Text;
            //    Response.Redirect("scheduleregister_new_edition.aspx");
            //}
            else
            {
                Session["from"] = txtfrmdate.Text;
                Session["to"] = txttodate1.Text;
                Session["schedulerep"] = ds;
                Session["rep_schedulerep"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~publication~" + dppub1.SelectedValue + "~publicationname~" + dppub1.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~editionname~" + hiddeneditionname.Value + "~publicationcenter~" + dppubcent.SelectedItem.Text + "~pubcentcode~" + dppubcent.SelectedValue + "~adtype~" + dpaddtype.SelectedItem.Text + "~adtypecode~" + dpaddtype.SelectedValue + "~adcategory~" + str + "~editiondetail~" + dpedidetail.SelectedValue + "~status~" + drpstatus.SelectedValue + "~adcatname~" + str1 + "~supplementcode~" + hsuppliment + "~package11~" + hiddenpackage.Value + "~pkgdetail~" + drppackagedetail.SelectedValue + "~package11name~" + hiddenpackagename.Value + "~chk_excel~" + chk_excel + "~branch_code~" + dpd_branch.SelectedValue + "~branch_name~" + dpd_branch.SelectedItem.Text + "~designer~" + txt_designer.Text;
                Response.Redirect("scheduleregister_new.aspx");
            }

        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmis_run(string fromdate, string todate, string pub, string edtn, string dest, string branch, string codesubcode, string adtype, string extra2, string extra3, string extra4, string extra5, string edtnnm)
    {


        Session["fromdate"] = fromdate;
        Session["todate"] = todate;
        Session["pub"] = pub;
        Session["edtn"] = edtn;
        Session["dest"] = dest;
        Session["adtype"] = adtype;
        Session["branch"] = branch;
        Session["codesubcode"] = codesubcode;
        Session["extra2"] = extra2;
        Session["extra3"] = extra3;
        Session["extra4"] = extra4;
        Session["extra5"] = extra5;
        Session["edtnnm"] = edtnnm;

    }


    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
            string procedureName = "bind_pubname_bind_pubname_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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
    public void bindbranch()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
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
            string procedureName = "BRANCHBIND_ADV_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        ListItem li = new ListItem();
        li.Value = "0";
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

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

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
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
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


    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }

    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };

        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else  if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }

         else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
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



    [Ajax.AjaxMethod]
    public DataSet getSectionCode(string name_p)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { name_p };
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
        else
        {
            string procedureName = "getSectionCode";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
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








    public void bindedidetail()
    {
        DataSet edidetail = new DataSet();
        edidetail.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        dpedidetail.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        li1.Value = "0";
        li1.Selected = true;
        dpedidetail.Items.Add(li1);

        for (i = 0; i < edidetail.Tables[13].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = edidetail.Tables[13].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = edidetail.Tables[13].Rows[0].ItemArray[i].ToString();
            dpedidetail.Items.Add(li);

        }
    }


    //protected void dppubcent_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
    //        ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());

    //    }
    //    else
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub_cent2.edition1(dppub1.SelectedValue, dppubcent.SelectedValue,Session["compcode"].ToString());

    //    }
    //    int i;
    //    ListItem li;
    //    li = new ListItem();
    //    dpedition.Items.Clear();
    //    li.Text = "-Select Edition Name-";
    //    li.Value = "0";
    //    li.Selected = true;
    //    dpedition.Items.Add(li);


    //    if (ds.Tables.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li1;
    //            li1 = new ListItem();
    //            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            dpedition.Items.Add(li1);
    //        }
    //    }
    //}

    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));

    }


    public void bindpackagedetailreq()
    {


        //   int i;
        drppackagedetail.Items.Clear();

        ListItem li;
        li = new ListItem();
        li.Text = "No";
        li.Value = "0";
        drppackagedetail.Items.Add(li);

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Yes";
        li1.Value = "1";
        drppackagedetail.Items.Add(li1);




    }

    protected void drppackagedetail_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (drppackagedetail.SelectedValue == "1")
        {
            drppackage.Enabled = true;
            dppub1.Enabled = false;
            dppubcent.Enabled = false;
            dpsuppliment.Enabled = false;
            dpedition.Enabled = false;

            dppub1.SelectedValue = "0";
            dppubcent.SelectedValue = "0";
            dpsuppliment.SelectedValue = "0";
            dpedition.SelectedValue = "0";
        }
        else
        {
            dppub1.Enabled = true;
            dppubcent.Enabled = true;
            dpsuppliment.Enabled = true;
            dpedition.Enabled = true;
            drppackage.Enabled = false;

            drppackage.SelectedValue = "0";
        }

    }
}
