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

public partial class Reports_reotype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenuserhome.Value = Session["userhome"].ToString();
            hiddenrevenue.Value = Session["Revenue"].ToString();
            hiddenadmin.Value = Session["Admin"].ToString();
            Session["access"] = "0";
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_reotype));



       // Session["fromdate"] = txtfrmdate.Text;
      //  Session["todate"] = txttodate1.Text;
        DataSet ds1 = new DataSet();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reotype.xml"));

        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblusername.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblfirstnm.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbllastnm.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblbranch.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblempcode.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblcomnm.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
       
        lblemailid.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbldis.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
       
        lblbranchper.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblrolenm.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbledit.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
          lblstatus.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
          BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
          lbldestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
       

        if (!Page.IsPostBack)
        {
            bindstatus();
            binddat();
           // BindRolename();
            bindbranch();



            dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr_dev(event);");
            dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr_dev(event);");

            lstagency.Attributes.Add("onclick", "javascript:return ClickAgaencybb(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaencybb(event);");

           // lstbranch.Attributes.Add("onclick", "javascript:return ClickAgaencybb(event);");
           // lstbranch.Attributes.Add("onkeydown", "javascript:return ClickAgaencybb(event);");

            //lstusernm.Attributes.Add("onclick", "javascript:return ClickAgaencybb(event);");
           // lstusernm.Attributes.Add("onkeydown", "javascript:return ClickAgaencybb(event);");
            BtnRun.Attributes.Add("OnClick", "javascript:return checkrundatenetamt();");
            drpuserid.Attributes.Add("onkeydown", "javascript:return binduser(event);");
            drpuserid.Attributes.Add("onkeypress", "javascript:return binduser(event);");
            lst_user.Attributes.Add("onclick", "javascript:return filluser(event);");
            lst_user.Attributes.Add("onkeydown", "javascript:return filluser(event);");
            txtemailid.Attributes.Add("onblur", "javascript:return email(this);");

           // txtdis.Attributes.Add("onkeydown", "javascript:return isInteger(this);");
            txtdis.Attributes.Add("onkeypress", "javascript:return checknos(event);");


          
        }
    }
    public void bindstatus()
    {
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/reotype.xml"));
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "-Select Status-";
        li.Selected = true;
        drpstatus.Items.Add(li);
        for (int i = 1; i < ds1.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i + 1].ToString();
            drpstatus.Items.Add(li1);
            i++;

        }


    }



    public void binddat()
    {
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/reotype.xml"));
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "-Select-";
        li.Selected = true;
        drpdes.Items.Add(li);
        for (int i = 1; i < ds1.Tables[2].Columns.Count - 1; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            li1.Value = ds1.Tables[2].Rows[0].ItemArray[i + 1].ToString();
            drpdes.Items.Add(li1);
            i++;

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

    }



   
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency, string pubcenter)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
        }
        else
        {
            NewAdbooking.Report.classesoracle.reotype age = new NewAdbooking.Report.classesoracle.reotype();
            ds = age.bindagencyname(compcode, userid, agency, "0");
        }
        return ds;



    }
    [Ajax.AjaxMethod]
    public DataSet UserBind(string compcode, string userid, string userhome, string revenue, string admin)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp(compcode, userid, userhome, admin, revenue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp(compcode, userid, userhome, admin, revenue);
        }
        else
        {
            //  NewAdbooking.classmysql.pop MastPrev = new NewAdbooking.classmysql.pop();
            //  ds1 = MastPrev.MastPrevDisp(compcode,userid,userhome,revenue,admin);
        }
        return ds1;
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

        return ds;
    }





    [Ajax.AjaxMethod]
    public DataSet call_email(string email, string at)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.reotype email1 = new NewAdbooking.Report.classesoracle.reotype();

         
            ds = email1.checkemail(email, at);
        }
        else
        {


            NewAdbooking.Report.Classes.reporttype email1 = new NewAdbooking.Report.Classes.reporttype();


            ds = email1.checkemail(email, at);
        }
        return ds;
    }

}
