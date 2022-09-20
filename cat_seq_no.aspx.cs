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


public partial class cat_seq_no : System.Web.UI.Page
{
    string compcode = "";
    string pkg_code="";
    int j = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //btnNew.Focus();
        
       // compcode = Session["compcode"].ToString();
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenauto.Value = Session["DateFormat"].ToString();
        }

        else
        {
            //Response.Redirect("login.aspx");
           // Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
           // return;

        }
        ip1.Value = Request.ServerVariables["REMOTE_ADDR"];
        Ajax.Utility.RegisterTypeForAjax(typeof(cat_seq_no));
        hiddenusername.Value = Session["Username"].ToString();

          DataSet objds = new DataSet();
        objds.ReadXml(Server.MapPath("XML/cat_seq_no.xml"));

        lblday.Text = objds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcenter.Text = objds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladtype.Text = objds.Tables[0].Rows[0].ItemArray[2].ToString();
        btnview.Text = objds.Tables[0].Rows[0].ItemArray[3].ToString();
        btnsave.Text = objds.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.Text = objds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnexit.Text = objds.Tables[0].Rows[0].ItemArray[6].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(cat_seq_no));
         if (!Page.IsPostBack)
         {
             //btnNew.Attributes.Add("OnClick", "javascript:return NewClick2();");
             btnexit.Attributes.Add("OnClick", "javascript:return ExitClick2();");


             btnCancel.Attributes.Add("OnClick", "javascript:return cancelClick();");
             btnsave.Attributes.Add("OnClick", "javascript:return save();");
      
             fillPubCenter(Session["compcode"].ToString());
             adtypedata(Session["compcode"].ToString());
             addPageDays();
            
         }
          if (Session["Username"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        else
        {
        }
       


    }
    private void fillPubCenter(string compcode)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.cat_seq_no logindetail = new NewAdbooking.Classes.cat_seq_no();
            ds = logindetail.getPubCenter();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cat_seq_no logindetail = new NewAdbooking.classesoracle.cat_seq_no();

            ds = logindetail.getPubCenter_company(compcode);

        }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.getPubCenter();
        }



     


        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Center-";
        li1.Value = "0";
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
   
    public void addPageDays()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/cat_seq_no.xml"));
        int i;
        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            ddlDays.Items.Add(li1);
        }
      
       
    }
    public void adtypedata(string compcode)
    {
        

        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "advtypbind";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "advtypbind.advtypbind_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //return ds;



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
    protected void GridView1_databound(object sender, GridViewRowEventArgs e)
    { 
        if (e.Row.RowIndex != -1)
        {
            string strinc = "txtindco_" + j;

            e.Row.Cells[2].Text = "<input type='text' size='15' maxlength=3  id=" + strinc + " onkeydown=\"javascript:return chk_downkey(event);\"  value='" + e.Row.Cells[2].Text + "'  />";
         
              j++;
        }


    }
    protected void GridView1_PageIndexChange(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        btnview_Click(sender, e);


    }




    protected void btnview_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string compcode = Session["compcode"].ToString();
        string pcenter = drpcenter.Text;
        string pdays = ddlDays.Text;
        string padtype = drpadtype.Text;
        string puserid = Session["userid"].ToString();
        string dateformate = Session["DateFormat"].ToString();
        string extra1 = "";
        string extra2 = "";
        string extra3 = "";
        string extra4 = "";
        string extra5 = "";

        if (ddlDays.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Days');", true);
            ddlDays.Focus();
            return;
        }
        if (drpcenter.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Center');", true);
            drpcenter.Focus();
            return;
        }
        if (drpadtype.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Adtype');", true);
            drpadtype.Focus();
            return;
        }

        string[] parameterValueArray = new string[] { compcode, pcenter, pdays, padtype, puserid, dateformate, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.classesoracle.cat_seq_no category = new NewAdbooking.classesoracle.cat_seq_no();
            ds = category.cat_seq(compcode, pcenter, pdays, padtype, puserid, dateformate, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cat_seq_no category = new NewAdbooking.classesoracle.cat_seq_no();
            ds = category.cat_seq(compcode, pcenter, pdays, padtype, puserid,dateformate, extra1, extra2, extra3, extra4,extra5);
        }
        else
        {
            string procedureName = "FETCH_AD_CAT_FLOW_SEQUENCE";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('There is no data according to your selection ');", true);
            btnview.Focus();
            return;
        }
        Session["RowLen"] = ds.Tables[0].Rows.Count;
         GridView1.DataSource = ds;
        GridView1.DataBind();
    

    }
    [Ajax.AjaxMethod]
    public DataSet save(string compcode, string center, string days, string adtype, string catcode, int cat_seqno, string userid, string flag, string ins_upd, string datformate, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray =  { compcode, center, days, adtype, catcode, cat_seqno.ToString(), userid, flag, ins_upd, datformate, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.classesoracle.cat_seq_no category = new NewAdbooking.classesoracle.cat_seq_no();
            ds = category.save(compcode, center, days, adtype, catcode, cat_seqno, userid, flag, ins_upd, datformate, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.cat_seq_no category = new NewAdbooking.classesoracle.cat_seq_no();
            ds = category.save(compcode, center, days, adtype, catcode, cat_seqno, userid, flag, ins_upd, datformate, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            string procedureName = "FETCH_AD_CAT_FLOW_SEQUENCE";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;

    }
}
