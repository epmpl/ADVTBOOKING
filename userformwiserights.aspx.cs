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
using System.Data.OracleClient;

public partial class userformwiserights : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null || Session["userid"] == "" || Session["userid"] == "Nothing") 
        {
            Response.Redirect("login.aspx");
        }

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/userformwiserights.xml"));
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcompanyname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblunit.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblformat.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbllanguage.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblmodulename.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //lblheading.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblusername.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(userformwiserights));

        dateformat.Value = Session["dateformat"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hdnunitcode.Value = Session["center"].ToString();
        hdnunit.Value = Session["center"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        
        if (!Page.IsPostBack)
        {
            binduserid();
            bindunit();
            bindmodule();
            bindorder();
            bindlang();
            //drpuserid.Attributes.Add("onchange", "javascript:return foruserid();");
            lstuser.Attributes.Add("onclick", "javascript:return insertuser();");
            //lstuser.Attributes.Add("onkeydown", "javascript:return insertuserbyenter(event);");
            btnsubmit.Attributes.Add("onclick", "javascript:return foruserformwiserights();");
            btncancel.Attributes.Add("onclick", "javascript:return forcancel();");
            btnexit.Attributes.Add("onclick", "javascript:window.close('userformwiserights.aspx')");



            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    DataSet ds_per = new DataSet();
            //    NewAdbooking.Classes.cir_permission ls = new NewAdbooking.Classes.cir_permission();
            //    ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunit.Value, hdnuserid.Value, "1", "USERFORMWISERIGHTS", dateformat.Value, "", "");
            //    if (ds_per.Tables[0].Rows.Count > 0)
            //    {
            //        hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
            //    }
            //    else
            //    {
            //        hdn_user_right.Value = "0";
            //    }
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    DataSet ds_per = new DataSet();
            //    NewAdbooking.classesoracle.cir_permission ls = new NewAdbooking.classesoracle.cir_permission();
            //    ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunit.Value, hdnuserid.Value, "1", "USERFORMWISERIGHTS", dateformat.Value, "", "");
            //    if (ds_per.Tables[0].Rows.Count > 0)
            //    {
            //        hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
            //    }
            //    else
            {
                hdn_user_right.Value = "7";
            }
            //}
        
        }
    }
    private void bindorder()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/subroutemastreport.xml"));
        ListItem li = new ListItem();
        int i;
        li.Text = "On Screen";
        li.Value = "ons";
        drpformat.Items.Add(li);

        for (i = 0; i < ds.Tables[2].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            drpformat.Items.Add(li1);
        }
    }
    private void bindlang()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/subroutemastreport.xml"));
        ListItem li = new ListItem();
        int i;
        li.Text = "English";
        li.Value = "eng";
        drplanguage.Items.Add(li);

        for (i = 0; i < ds.Tables[3].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            drplanguage.Items.Add(li1);
        }
    }

    public void binduserid()
    {
        //drpuserid.Items.Clear();
        DataSet ds = new DataSet();
        string extra1 = "";
        string extra2 = "";
        string logincode = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.userformwiserights rpt = new NewAdbooking.classesoracle.userformwiserights();

            ds = rpt.binduserid(logincode, dateformat.Value, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_login_bind_cir_login_bind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { logincode, dateformat.Value, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.userformwiserights rpt = new NewAdbooking.Classes.userformwiserights();

            ds = rpt.binduserid(logincode, dateformat.Value, extra1, extra2);
        }
        //ListItem li = new ListItem();
        //li.Text = "---Select Userid---";
        //li.Value = "";
        //drpuserid.Items.Add(li);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li1 = new ListItem();
        //    li1.Text = ds.Tables[0].Rows[i]["username"].ToString();
        //    li1.Value = ds.Tables[0].Rows[i]["userid"].ToString();
        //    drpuserid.Items.Add(li1);
        //}
    }
    [Ajax.AjaxMethod]
    public DataSet bindcompname(string usercode, string dateformat, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.userformwiserights rpt = new NewAdbooking.classesoracle.userformwiserights();


            ds = rpt.bindcompname(usercode, dateformat, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_change_company_cir_change_company_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { usercode, dateformat, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.userformwiserights rpt = new NewAdbooking.Classes.userformwiserights();


            ds = rpt.bindcompname(usercode, dateformat, extra1, extra2);
        }
        return ds;
    }
    public void bindunit()
    {
        drpunit.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.userformwiserights rpt = new NewAdbooking.classesoracle.userformwiserights();

            ds = rpt.bindunit();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_change_company_cir_change_company_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = {  };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.Classes.userformwiserights rpt = new NewAdbooking.Classes.userformwiserights();

            ds = rpt.bindunit();
        }
        ListItem li = new ListItem();
        li.Text = "---Select Unit---";
        li.Value = "";
        drpunit.Items.Add(li);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[0].Rows[i]["center"].ToString();
            li1.Value = ds.Tables[0].Rows[i]["Pub_cent_Code"].ToString();
            drpunit.Items.Add(li1);
        }
    }
    public void bindmodule()
    {
        drpmodulename.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/FormSubbmition.xml"));
        //string extra1 = "";
        //string extra2 = "";
        //string modulecode = "";
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.classesoracle.userformwiserights rpt = new NewAdbooking.classesoracle.userformwiserights();

        //    ds = rpt.bindmodule(modulecode, dateformat.Value, extra1, extra2);
        //}
        //else
        //{
        //    NewAdbooking.Classes.userformwiserights rpt = new NewAdbooking.Classes.userformwiserights();

        //    ds = rpt.bindmodule(modulecode, dateformat.Value, extra1, extra2);
        //}
        //ListItem li = new ListItem();
        //li.Text = "---Select Module---";
        //li.Value = "";
        //drpmodulename.Items.Add(li);
        for (int i = 2; i < ds.Tables[1].Rows[0].ItemArray.Length; i++)
        {
            ListItem li1= new ListItem();
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i + 1].ToString();
            drpmodulename.Items.Add(li1);
            i = i + 1;
        }
    }
  [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet Binduser(string username)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp_user(Session["compcode"].ToString(), Session["userid"].ToString(),"","", "", username);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp_user(Session["compcode"].ToString(), Session["userid"].ToString(), "", "", "", username);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "wesp_Modultuser_wesp_wesp_Modultuser_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), "", "", "", username };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds1;
    }

}

