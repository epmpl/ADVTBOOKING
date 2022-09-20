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
using System.Text;
using System.Collections.Generic;
//using System.Linq;


public partial class reportlognew : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Session Expired Please Login Again');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(reportlognew));
        hiddendateformat.Value = Session["dateformat"].ToString();

        
        ds.ReadXml(Server.MapPath("XML/reportlognew.xml"));
        heading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbFromDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbForm.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();

        lbluser.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //drpForm.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        txtbookid.Enabled = true;

        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnDelete.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnExit.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        Label1.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        BtnRun.Attributes.Add("onclick", "javascript:return validate()");
        btnDelete.Attributes.Add("onclick", "javascript:return validate_d()");
        btnExit.Attributes.Add("onclick", "javascript:return exitform()");
        txtFromDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
        txtToDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
        drpForm.Attributes.Add("OnChange", "javascript:return checkprocess();");
        txtFromDate.Attributes.Add("OnKeydown", "javascript:return ClientisNumber(event);");
        txtToDate.Attributes.Add("OnKeydown", "javascript:return ClientisNumber(event);");
        txtFromDate.Focus();
        if (!Page.IsPostBack)
        {
            DataSet dsxml = new DataSet();
            dsxml.ReadXml(Server.MapPath("XML/log.xml"));
            DataView dv = dsxml.Tables["Proces"].DefaultView;
            drpForm.DataTextField = "Name";
            drpForm.DataValueField = "ID";
            drpForm.DataSource = dv;
            drpForm.DataBind(); 
            //drpForm.Items.Add("ALL");
            //drpForm.Items.Add("Agency");
            //drpForm.Items.Add("Agency Discount");
            //drpForm.Items.Add("Client Master");
            ////drpForm.Items.Add("Housekeeping");
            //drpForm.Items.Add("Order");
            //drpForm.Items.Add("Order Print Receipt");
            //drpForm.Items.Add("Priveledge Master");
            ////drpForm.Items.Add("Seq. Number");
            //drpForm.Items.Add("Rate");
            ////drpForm.Items.Add("Receipt Format");
            ////drpForm.Items.Add("Receipt Seq.");
            ////drpForm.Items.Add("Sync-Up");
            //drpForm.Items.Add("User");
            //drpForm.Items.Add("UOM");
            //drpForm.Items.Add("Login");

            
            
            clsconnection dconnect = new clsconnection();
            string sqldd = "";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                sqldd = "select \"userid\",\"username\" from login ";
                if (Session[0].ToString() != "0")
                    sqldd = sqldd + " where \"Agency_code\"='" + Session[0].ToString() + "'";
            }
            else
            {
                sqldd = "select userid,username from login";
                if (Session[0].ToString() != "0")
                    sqldd = sqldd + " where Agency_code='" + Session[0].ToString() + "'" + " order by username";
                else
                    sqldd = sqldd + " order by username";

            }
            
            ds=dconnect.executequery(sqldd);
            ListItem b = new ListItem();
            b.Text = "ALL";
            b.Value = "ALL";
            ue.Items.Add(b);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem a = new ListItem();
                a.Text=ds.Tables[0].Rows[i].ItemArray[1].ToString();
                a.Value=ds.Tables[0].Rows[i].ItemArray[0].ToString();
                ue.Items.Add(a);
            }

        }

    }
    protected void GridView1_Init(object sender, EventArgs e)
        {
       
            

        }

        
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        clsconnection dconnect = new clsconnection();
        string sqldd = "select ";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            sqldd = sqldd + " to_char(DATE1,'dd/mm/yyyy hh24:mi:ss') as DATE1,";
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            sqldd = sqldd + "convert(varchar,DATE1,101)as DATE1,";
        else
            sqldd = sqldd + "DATE_FORMAT(DATE1,'%d/%m/%Y %H:%i:%S')  as DATE1,";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            sqldd = sqldd + "(select \"username\" from login where login.\"userid\"=log_new.USERID and rownum=1) as username,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP from log_new";
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            sqldd = sqldd + "(select top 1 username from login where login.userid=log_new.USERID) as username,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP from log_new";
        else
            sqldd = sqldd + "(select username from login where login.userid=log_new.USERID and rownum=1) as username,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP from log_new";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            sqldd = sqldd + " where date1 between to_date('" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("MM/dd/yyyy") + " 00:00:00','mm/dd/yyyy hh24:Mi:ss') and to_date('" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("MM/dd/yyyy") + " 00:00:00','mm/dd/yyyy hh24:Mi:ss') ";
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            sqldd = sqldd + " where date1 between '" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("MM-dd-yyyy") + "' ";
        }
        else
        {
            sqldd = sqldd + " where date1 between '" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("yyyy/MM/dd") + "' and '" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("yyyy/MM/dd") + "' ";
        }
        if (drpForm.SelectedValue != "ALL")
            sqldd = sqldd + " and PROCESSNAME='" + drpForm.SelectedValue + "'";
        if (ue.SelectedValue == "ALL")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && Session[0].ToString() != "0")
                sqldd = sqldd + " and USERID in (select login.\"userid\" from login where \"Agency_code\"='" + Session[0].ToString() + "')";
        }
        else
            sqldd = sqldd + " and USERID='" + ue.SelectedValue + "'";
        if (txtbookid.Text != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                sqldd = sqldd + " and \"DESCRIPTION\" like '%" + txtbookid.Text + "%'"; ;
        }
        sqldd = sqldd + " order by date1 desc";
        DataSet ds = new DataSet();
        ds = dconnect.executequery(sqldd);
        GridView1.DataSource = ds;
        for (int i = (GridView1.PageIndex*10); i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem a = new ListItem();
            a.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            a.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            ue.Items.Add(a);
        }

        GridView1.DataBind();
    }


        



        protected void BtnRun_Click(object sender, EventArgs e)
        {

        }
        protected void BtnRun_Click1(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            if (Session["compcode"] == null)
            {
                return;
            }
            clsconnection dconnect = new clsconnection();
            string sqldd = "select ";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                sqldd = sqldd + " to_char(DATE1,'dd/mm/yyyy hh24:mi:ss') as DATE1,";
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                sqldd = sqldd + "convert(varchar,DATE1,101)as DATE1,";
            else
                sqldd = sqldd + "DATE_FORMAT(DATE1,'%d/%m/%Y %H:%i:%S')  as DATE1,";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                sqldd = sqldd + "(select \"username\" from login where login.\"userid\"=log_new.USERID and rownum=1) as username,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP from log_new";
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                sqldd = sqldd + "(select top 1 username from login where login.userid=log_new.USERID) as username,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP from log_new";
            else
                sqldd = sqldd + "(select username from login where login.userid=log_new.USERID and rownum=1) as username,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP from log_new";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                sqldd = sqldd + " where date1 between to_date('" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("MM/dd/yyyy") + " 00:00:00','mm/dd/yyyy hh24:Mi:ss') and to_date('" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("MM/dd/yyyy") + " 00:00:00','mm/dd/yyyy hh24:Mi:ss') ";
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                sqldd = sqldd + " where date1 between '" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("MM-dd-yyyy") + "' ";
            }
            else
            {
                sqldd = sqldd + " where date1 between '" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("yyyy/MM/dd") + "' and '" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("yyyy/MM/dd") + "' ";
            }
            if (drpForm.SelectedValue != "ALL")
                sqldd = sqldd + " and PROCESSNAME='" + drpForm.SelectedValue + "'";
            if (ue.SelectedValue == "ALL")
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && Session[0].ToString() != "0")
                    sqldd = sqldd + " and USERID in (select login.\"userid\" from login where \"Agency_code\"='" + Session[0].ToString() + "')";
            }
            else
                sqldd = sqldd + " and USERID='" + ue.SelectedValue + "'";
            if (txtbookid.Text != "")
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    sqldd = sqldd + " and \"DESCRIPTION\" like '%"+ txtbookid.Text +"%'"; ;
            }
            sqldd = sqldd + " order by date1 desc";
            DataSet ds = new DataSet();
            ds = dconnect.executequery(sqldd);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected string convertdate(string d1)
        {
            string receiptdate = "";
            if (Session["dateformat"].ToString() == "mm/dd/yyyy")
            {
                string[] arr = null;

                receiptdate = d1;

            }
            if (Session["dateformat"].ToString() == "dd/mm/yyyy")
            {
                string[] arr = null;
                arr = d1.Split("/".ToCharArray());
                receiptdate = arr[1] + "/" + arr[0] + "/" + arr[2];

            }
            if (Session["dateformat"].ToString() == "yyyy/mm/dd")
            {
                string[] arr = null;
                arr = d1.Split("/".ToCharArray());
                receiptdate = arr[1] + "/" + arr[2] + "/" + arr[0];

            }
            return receiptdate;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["compcode"] == null)
            {
                return;
            }
            clsconnection dconnect = new clsconnection();
            string sqldd = "select count(*) from log_new";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                sqldd = sqldd + " where date1 between to_date('" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("MM/dd/yyyy hh:mm:ss") + "','mm/dd/yyyy hh24:Mi:ss') and to_date('" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("MM/dd/yyyy hh:mm:ss") + "','mm/dd/yyyy hh24:Mi:ss')  ";
            }
            else
            {
                sqldd = sqldd + " where date1 between '" + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("yyyy/MM/dd hh:mm:ss") + "' and '" + Convert.ToDateTime(convertdate(txtToDate.Text)).AddDays(1).ToString("yyyy/MM/dd hh:mm:ss") + "' ";
            }
            if (drpForm.SelectedValue != "ALL")
                sqldd = sqldd + " and PROCESSNAME='" + drpForm.SelectedValue + "'";
            if (ue.SelectedValue == "ALL")
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl" && Session[0].ToString() != "0")
                    sqldd = sqldd + " and USERID in (select login.\"userid\" from login where \"Agency_code\"='" + Session[0].ToString() + "')";
            }
            else
                sqldd = sqldd + " and USERID='" + ue.SelectedValue + "'";
            DataSet ds = new DataSet();
            ds = dconnect.executequery(sqldd);

            double count = 0;
            count = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0]);
            sqldd = sqldd.Replace("select count(*) ", "delete ");
            dconnect.executenonqueryd(sqldd);
            sqldd = "insert into log_new values($date,'" + Session["userid"].ToString() + "','Log Truncation','','Log Truncation','";
            sqldd = sqldd + Convert.ToString(count) + " records from " + Convert.ToDateTime(convertdate(txtFromDate.Text)).ToString("dd-MMM-yyyy") + " to " + Convert.ToDateTime(convertdate(txtToDate.Text)).ToString("dd-MMM-yyyy");
            sqldd = sqldd + "','" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "')";
            dconnect.executenonqueryd(sqldd);
            
            BtnRun_Click1(sender , e);
        }
    
}
