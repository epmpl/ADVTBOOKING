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

public partial class reportmisbookid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(reportmisbookid));
        hiddendateformat.Value = Session["dateformat"].ToString();



        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reportmisbookid.xml"));
        heading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //heading.Text += "/" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + " Ads";
        lbFromDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbStatus.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();

        if (!IsPostBack)
        {
            txtFromDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            txtToDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");

            txtFromDate.Attributes.Add("OnKeydown", "javascript:return ClientisNumber(event);");
            txtToDate.Attributes.Add("OnKeydown", "javascript:return ClientisNumber(event);");
        }
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {

        bindGrid();
        //Response.Redirect("qbcConfirmView.aspx?fromdate=" + fromdatecon + "&todate=" + todatecon + "&status=" + drpStatus.SelectedValue + "&order=asc");
        
    }

    private void bindGrid()
    {
        string dateformat = Session["dateformat"].ToString();
        string fromdatecon = getDate(dateformat, txtFromDate.Text);
        string todatecon = getDate(dateformat, txtToDate.Text);

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.reportmisbookingid getid = new NewAdbooking.Classes.reportmisbookingid();

            ds = getid.bindbookingid(fromdatecon, todatecon);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportmisbookingid getid = new NewAdbooking.classesoracle.reportmisbookingid();

            ds = getid.bindbookingid(fromdatecon, todatecon);
        }
        else
        {
            NewAdbooking.classmysql.reportmisbookingid getid = new NewAdbooking.classmysql.reportmisbookingid();

            ds = getid.bindbookingid(fromdatecon, todatecon);

        }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }
    public string getDate(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        if (dateValue != "")
        {
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];

                dateReturn = mm + "/" + dd + "/" + yyyy;


            }
            //else if (dateformat == "yyyy/mm/dd")
            //{
            //    yyyy = myarrayfrom[0];
            //    mm = myarrayfrom[1];
            //    dd = myarrayfrom[2];

            //    dateReturn = mm + "/" + dd + "/" + yyyy;
            //}
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        bindGrid();
    }
}
