using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public partial class Reports_ad_masterreport : System.Web.UI.Page
{
    string extra2 = "", extra3 = "", extra4 = "", extra5 = "", extra6 = "", extra7 = "", extra8 = "", extra9 = "", extra10 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["userid"] == null || Session["userid"] == "" || Session["userid"] == "Nothing")
        {
            Response.Redirect("login.aspx");
        }

        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/ad_masterreport.xml"));
        lblunit.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        Reports.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        type.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenusername.Value = Session["username"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        hiddenunit.Value = Session["center"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_ad_masterreport));
        if (!Page.IsPostBack)
        {
            binddest();
            lstreport.Attributes.Add("onclick", "javascript:return fillSelectedData_fpc();");
            lstreport.Attributes.Add("onkeypress", "javascript:return fillSelectedData_fpc();");
            ListBox4.Attributes.Add("onclick", "javascript:return callfilterfield(this.id);");
            ListBox4.Attributes.Add("onkeypress", "javascript:return callfilterfield(this.id);");
            btnadd.Attributes.Add("onclick", "javascript:return addfilter(this.id);");
            btnadd.Attributes.Add("onkeypress", "javascript:return addfilter(this.id);");
            btnclear.Attributes.Add("onclick", "javascript:return clearfilter(this.id);");
            txtfrom.Attributes.Add("onblur", "javascript:return chkvalidinput(this.id);");
            txtunit.Attributes.Add("onpaste", "return false");
            txtunit.Attributes.Add("ondrag", "return false");
            txtunit.Attributes.Add("ondrop", "return false");
            txtunit.Attributes.Add("oncut", "return false");
            txtunit.Attributes.Add("onkeydown", "javascript:return fillunit()");
            lstunit.Attributes.Add("onkeydown", "javascript:return onclickunit()");
            lstunit.Attributes.Add("onclick", "javascript:return onclickunit()");
            txtto.Attributes.Add("onblur", "javascript:return chkvalidinput(this.id);");
            btnaddsort.Attributes.Add("onclick", "javascript:return addsortval('ListBox5');");
            btnaddsort.Attributes.Add("onkeypress", "javascript:return addsortval('ListBox5');");
            btnclrsort.Attributes.Add("onclick", "javascript:return clearsortval('ListBox5');");
            btnsubmit.Attributes.Add("onclick", "javascript:return submitvalue('ListBox5');");
            btnexit.Attributes.Add("onclick", "javascript:return exit('ListBox5');");

            //DataSet ds1 = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            //   ds1 = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, "ad_masterreport");
            //    if (ds1.Tables[0].Rows.Count > 0)
            //    {
            //        hdn_user_right.Value = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            //    }
            //    else
            //    {
            //        hdn_user_right.Value = "0";
            //    }
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            //ds1 = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, "ad_masterreport");
            //    if (ds1.Tables[0].Rows.Count > 0)
            //    {
            //       // hdn_user_right.Value = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            //        hdn_user_right.Value = "7";
            //    }
            //    else
            //    {
            //        hdn_user_right.Value = "0";
            //    }
            //}
            


        }
    }
      public void binddest()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/ad_masterreport.xml"));
        drtype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();


        for (i = 0; i < ds.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drtype.Items.Add(li);

        }


    }

      [Ajax.AjaxMethod]
      public DataSet bindreport(string compcode, string unit, string cha, string extra1)
      {
          string extra2 = "";
          DataSet ds = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {
             // NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
             // ds = pub.adbranch(Session["compcode"].ToString());
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
              ds = pub11.masrep(compcode, unit, cha, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
          {
              string procedureName = "AD_GET_REPORT_TABLE_BIND";
              NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
              string[] parameterValueArray = { compcode, unit, cha, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
              ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
          }
          return ds;
      }


      [Ajax.AjaxMethod]
      public DataSet fill_unit(string extra1)
      {
          DataSet ds = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {
              // NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
              // ds = pub.adbranch(Session["compcode"].ToString());
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
              ds = pub11.bindunit(extra1);
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
          {
              string procedureName = "websp_pubcenter_websp_pubcenter_p";
              NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
              string[] parameterValueArray = { extra1 };
              ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
          }
          return ds;

      }

      [Ajax.AjaxMethod]
      public DataSet bindlis(string compcode, string unit, string cha, string repo)
      {
          string extra2 = "";
          DataSet ds = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {
              // NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
              // ds = pub.adbranch(Session["compcode"].ToString());
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
              ds = pub11.bindr(compcode, unit, cha, repo, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
          {
              string procedureName = "AD_GET_REPT_TABLE_COL_BINDNEW";
              NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
              string[] parameterValueArray = { compcode, unit, cha, repo, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
              ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
          }
          return ds;
      }
      [Ajax.AjaxMethod]
      public DataSet getdatatype(string compcode, string col, string table)
      {
          string extra2 = "";
          DataSet ds = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {
              // NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
              // ds = pub.adbranch(Session["compcode"].ToString());
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
              ds = pub11.getdatatype1(compcode, col, table, "ERP");
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
          {
              string procedureName = "getdatype";
              NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
              string[] parameterValueArray = { compcode, col, table, "ERP" };
              ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
          }
          return ds;
      }

}