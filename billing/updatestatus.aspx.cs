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

public partial class updatestatus : System.Web.UI.Page
{
    int sno = 1;
    string booking_audit = "";
    string formname = "";
    protected void Page_Load(object sender, EventArgs e)
    {



        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            //Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }




       // Session["compcode"] = Session["Compcode"].ToString();
        //Session["dateformat"] = "mm/dd/yyyy";
        hiddencompcode.Value = Session["Compcode"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(updatestatus));
        hiddendateformat.Value = Session["dateformat"].ToString();
       hiddenserverip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();
       hiddenuser_id.Value = Session["userid"].ToString();

           booking_audit=Session["audit"].ToString();


           formname = "Publish_Audit";
           DataSet dz = new DataSet();
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
           {

               NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
               dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);

           }
           else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
           {
               string procedureName = "websp_showpermission_websp_showpermission_p";
               string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), formname };
               NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
               dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);
           }
           else
           {
               NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
               dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);


           }
           string id = "";
           if (dz.Tables[0].Rows.Count > 0)
           {
               id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
           }

            // id = "15";

           //  chk_idstatus.Value = id;

           if ((id != "15"))
           {

               Response.Write("<script>alert('you are not authorised for publish Audit');</script>");
               // ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last), "sa", "alert(\"you are not authorised for publish Audit\");", true);
               Response.Write("<script>window.close();</script>");
               BtnRun.Enabled = false;
           }
           else
           {
               BtnRun.Enabled = true;
           }
        if (!Page.IsPostBack)
        {
            bindadvtype();
            bindbranch();
            bindpub();
            publicationbind();
           // district_bind();
        }
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();

        btnsubmit.Attributes.Add("onclick", "javascript:return checkboxid()");
        BtnRun.Attributes.Add("onclick", "javascript:return chekvalidaton()");
        txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
        txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
        dppubcent.Attributes.Add("OnChange", "javascript:return filledition();");
        dppub1.Attributes.Add("OnChange", "javascript:return filledition();");
        dpedition.Attributes.Add("onchange", "javascript:return suppbind();");
        txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
        txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

        dpdadtype.Attributes.Add("OnChange", "javascript:return bindcategory();");
        drprate.Attributes.Add("onclick", "javascript:return fetch_categary(this.value);");

           
       // heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();

    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string branchnew = "";

        if (drpbranch.SelectedValue != "0")
        {
            branchnew = drpbranch.SelectedValue;
        }
        else
        {
            branchnew = "0";
        }
        

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit abc = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = abc.websp_updatestatus(Session["dateformat"].ToString(), txttodate1.Text, txtfrmdate.Text, dpdadtype.SelectedValue, branchnew, dppub1.SelectedValue, hiddenedition.Value, hiddensupplement.Value, booking_audit, drpstatus.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            if (hiddensupplement.Value == "--Select Supplement--")
            {
                hiddensupplement.Value = "";
            }
            // string editioncodem = hiddenedition.Value;


            string procedureName = "Websp_updatestatus";
            string[] parameterValueArray = { txtfrmdate.Text, txttodate1.Text, dpdadtype.SelectedValue, branchnew, dppub1.SelectedValue, Session["dateformat"].ToString(), hiddenedition.Value, hiddensupplement.Value, booking_audit, drpstatus.SelectedValue, dppubcent.SelectedValue, hdnexecutivetxt.Value, Session["userid"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {

            NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = abc.websp_updatestatus(Session["dateformat"].ToString(), txttodate1.Text, txtfrmdate.Text, dpdadtype.SelectedValue, branchnew, dppub1.SelectedValue, hiddenedition.Value, hiddensupplement.Value, booking_audit, drpstatus.SelectedValue, dppubcent.SelectedValue, hdnexecutivetxt.Value, Session["userid"].ToString());


        }



        Session["RowLen"] = ds.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();
        if (hidden1.Value == "0")
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            //div1.Disabled = true;
            ScriptManager.RegisterClientScriptBlock(this, typeof(updatestatus), "cc", "checklenthbill()", true);
            return;



        }


        else
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
           ScriptManager.RegisterClientScriptBlock(this, typeof(updatestatus), "cc", "checkvisible()", true);
           return;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet updatestatusnew(string bookingid, string insertion, string edition, string serverip, string userid)
    {
        DataSet ds = new DataSet();

        string err = "";
        try
        {
           
            if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.publish_audit executebullet = new NewAdbooking.BillingClass.Classes.publish_audit();
                ds = executebullet.updatestatusnew(bookingid, insertion, edition);
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "updatestausnew_updatestausnew_p";
                string[] parameterValueArray = { bookingid, edition, insertion, userid };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save executebullet = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds = executebullet.updatestatusnew(bookingid, insertion, edition);
            }

            
        }
        catch (Exception e)
        {
            err = e.Message;

        }

        string adcatcode2 = "publish Audit " + bookingid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1 ,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + userid + "','publish Audit','" + err.Replace("'", "''") + "','publish audit','" + adcatcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + serverip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;
     
    }








    [Ajax.AjaxMethod]
    public DataSet fillEdition2(string publication, string pub_cent, string comp_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(publication, pub_cent, comp_code);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 pub_cent2 = new NewAdbooking.classesoracle.Class1();
            ds = pub_cent2.edition(publication, pub_cent, comp_code);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "edition_proc_edition_proc_p";
            string[] parameterValueArray = { publication, pub_cent, comp_code };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;



    }


    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit pub_cent2 = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = pub_cent2.pubsupply(compcode, edition);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindsuppliment_bindsuppliment_p";
            string[] parameterValueArray = { compcode, edition };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 pub_cent2 = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = pub_cent2.pubsupply(compcode, edition);
        }
        return ds;

    }

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {

           // NewAdbooking.BillingClass.Classes.session_billing logindetail = new NewAdbooking.BillingClass.Classes.session_billing();
           // ds = logindetail.getPubCenter();
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.updatestaus pub_cent1 = new NewAdbooking.BillingClass.classesoracle.updatestaus();
            ds = pub_cent1.publication_center(Session["compcode"].ToString());
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "PubCentName1_PubCentName1_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
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


    }


    public void bindbranch()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit bind = new NewAdbooking.BillingClass.Classes.publish_audit(); 
            ds = bind.bindbranch();
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bind_branch_bind_branch_p";
            string[] parameterValueArray = {  };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {

            NewAdbooking.BillingClass.classesoracle.billing_save bind = new NewAdbooking.BillingClass.classesoracle.billing_save(); 
            ds = bind.bindbranch();

        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        drpbranch.Items.Clear();
        li1.Text = "-Select Branch-";
        li1.Value = "0";
        li1.Selected = true;
        drpbranch.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbranch.Items.Add(li);


        }

    }
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classesoracle.Class1  advname = new NewAdbooking.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        dpdadtype.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpdadtype.Items.Add(li1);
        
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


        }
    }
















    //public void district_bind()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
    //    {
    //        //NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
    //        //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.Class1 pub_cent1 = new NewAdbooking.classesoracle.Class1();
    //        ds = pub_cent1.bind_district(Session["compcode"].ToString());
    //    }
    //    else
    //    {
    //    }
    //    int i;
    //    ListItem li;
    //    li = new ListItem();
    //    dpdisrtict.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
    //    // li.Text = "-Select Publication Center-";
    //    li.Value = "0";
    //    li.Selected = true;
    //    dpdisrtict.Items.Add(li);


    //    if (ds.Tables.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li1;
    //            li1 = new ListItem();
    //            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            dpdisrtict.Items.Add(li1);
    //        }
    //    }


    //}











    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 advpub = new NewAdbooking.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            string[] parameterValueArray = { Session["compcode"].ToString() };
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


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        

    }
    protected void DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }
    }
    protected void DataGrid1_ItemDataBound2(object sender, DataGridItemEventArgs e)
    {

        string sno1 = e.Item.Cells[1].Text;
        string cioidchk = e.Item.Cells[3].Text;
        string insert_status = e.Item.Cells[21].Text;

       if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[1].Text = Convert.ToString(sno++);
       }



       if (insert_status == "publish")
       {
           e.Item.Cells[2].Text = "<img src=\"images/flag.gif\" ></img>";
       }

       if ((insert_status == "publish") && (insert_status != "") && (insert_status != "&nbsp;"))
       {
           e.Item.Cells[0].Enabled = false;
       }



    }

    [Ajax.AjaxMethod]
    public DataSet getcategory(string compcode, string pkg_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.publish_audit objpkg = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = objpkg.bind_category(compcode, pkg_code);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = objpkg.bind_category(compcode, pkg_code);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "audit_cate_audit_cate_p";
            string[] parameterValueArray = { compcode, pkg_code };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet fetch_date_data(string pcomp_code, string pformname, string puserid, string pentry_date, string pdateformat, string pextra1, string pextra2)
    {
        DataSet ds = new DataSet();


        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ad_get_backdays_validate";
            string[] parameterValueArray = { pcomp_code , pformname , puserid , pentry_date , pdateformat , pextra1 , pextra2 };
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")

        {

            NewAdbooking.BillingClass.classesoracle.session_billing abcd = new NewAdbooking.BillingClass.classesoracle.session_billing();
            ds = abcd.ad_get_backdays_validate(pcomp_code, pformname, puserid, pentry_date, pdateformat, pextra1, pextra2);

        }

        return ds;
    }
    
    protected void btnsubmit_Click2(object sender, EventArgs e)
    {
        BtnRun_Click(sender, e);

    }
}
