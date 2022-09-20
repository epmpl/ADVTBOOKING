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


public partial class rpt_auditor_comment : System.Web.UI.Page
{
    int i = 0;
    string compcode = "";
    string userid = "";
    string dateformat = "";
    string view = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(rpt_auditor_comment));
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/auditor_comment.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        btnExit.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcenter.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblbranch.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        dateflag.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();


        if (!Page.IsPostBack)
        {
            bindorder();
            fillPubCenter(Session["compcode"].ToString());
            bookingtype();
            adtypedata(Session["compcode"].ToString());
            btnExit.Attributes.Add("OnClick", "javascript:return formexit();");
            BtnRun.Attributes.Add("OnClick", "javascript:return forreport();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            drpcenter.Attributes.Add("OnChange", "javascript:return bindQBC();");
           
        }


    }
    private void bindorder()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/auditor_comment.xml"));

        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            dpaddtype.Items.Add(li1);
        }

    }
    private void fillPubCenter(string compcode)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.misupdation logindetail = new NewAdbooking.Classes.misupdation();
            ds = logindetail.getPubCenter();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.misupdation logindetail = new NewAdbooking.classesoracle.misupdation();

            ds = logindetail.getPubCenter_company(compcode);

        }
        else
        {
            string procedureName = "Bind_PubCentName_Bind_PubCentName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }



        drpcenter.Items.Clear();
        ListItem li1;



        li1 = new ListItem();
        li1.Text = "-Select Center-";
        li1.Value = "";
        li1.Selected = true;
        drpcenter.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcenter.Items.Add(li);
        }


    }
    private void bookingtype()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/auditor_comment.xml"));

        for (i = 0; i < ds.Tables[2].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            drpdateflag.Items.Add(li1);
        }

    }
    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.misupdation bind = new NewAdbooking.Classes.misupdation();
            ds = bind.adtypbind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.misupdation bind = new NewAdbooking.classesoracle.misupdation();
            ds = bind.adtypbind(compcode);
        }
         else
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }



        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }

    }

    [Ajax.AjaxMethod]
    public DataSet fillQBC(string userid)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.misupdation logindetail = new NewAdbooking.Classes.misupdation();

            ds = logindetail.bindbranch_userwise(userid);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.misupdation bind = new NewAdbooking.classesoracle.misupdation();
                ds = bind.bindbranch_userwise(userid);

            }
            else
            {
                string procedureName = "bind_branch_branchwise_bind_branch_branchwise_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { userid };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }

}
