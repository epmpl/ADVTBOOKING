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

public partial class reportConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      

        Ajax.Utility.RegisterTypeForAjax(typeof(reportConfirm));
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            //Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
            string sessionout = "Your Session Has Been Expired";
            AspNetMessageBox_close(sessionout);
            ScriptManager.RegisterClientScriptBlock(this, typeof(reportConfirm), "enable", "window.close();", true);

            return;

        }
       hiddendateformat.Value = Session["dateformat"].ToString();
        
       
        
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reportConfirm.xml"));
        heading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        heading.Text += "/" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + " Ads";
        lbFromDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbStatus.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblfilter.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

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
        //string fromDate = "", toDate = "", status = "";
        //fromDate = txtFromDate.Text;
        //toDate = txtToDate.Text;
        //status = drpStatus.SelectedValue;
        string dateformat = Session["dateformat"].ToString();
        string fromdatecon = txtFromDate.Text;// getDate(dateformat, txtFromDate.Text);
        string todatecon = txtToDate.Text;// getDate(dateformat, txtToDate.Text);


        Response.Redirect("qbcConfirmView.aspx?fromdate=" + fromdatecon + "&todate=" + todatecon + "&status=" + drpStatus.SelectedValue + "&order=asc" + "&filter=" + drpfilter.SelectedValue);
        //DataSet ds = new DataSet();
        //NewAdbooking.classmysql.reportConfirm rc = new NewAdbooking.classmysql.reportConfirm();
        //ds=rc.bindGrid(fromDate, toDate, status);
        //DataGrid1.DataSource = ds;
        //DataGrid1.DataBind();
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
    protected void AspNetMessageBox_close(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage); 
        string strAlert = "";
        strAlert = "alert('" + strMessage + "');window.close();";
        ScriptManager.RegisterClientScriptBlock(this, typeof(reportConfirm), "ShowAlert", strAlert, true);
    }
}
