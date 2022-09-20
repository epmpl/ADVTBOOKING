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

public partial class qbctransfer_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Ajax.Utility.RegisterTypeForAjax(typeof(qbctransfer_report));
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("xml/Transferbookingreport.xml"));

        lblmsg.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbFromDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        BtnSubmit.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();

        string dateformat = Session["dateformat"].ToString();


        if (!IsPostBack)
        {
            txtFromDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            txtToDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            BtnSubmit.Attributes.Add("onclick", "javascript:return submitreport();");

            txtFromDate.Attributes.Add("OnKeypress", "javascript:return ClientisNumber();");
            txtToDate.Attributes.Add("OnKeypress", "javascript:return ClientisNumber();");
        }


    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string dateformat=Session["dateformat"].ToString();
        string formdatecon = txtFromDate.Text;// getDate(dateformat, txtFromDate.Text);
        string todatecon = txtToDate.Text;//getDate(dateformat, txtToDate.Text);
        Response.Redirect("qbcdisplaytransfer.aspx?fromdate=" + formdatecon + "&todate=" + todatecon + "&order=asc");

        //Response.Redirect("displaygridview.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtToDate.Text);
  
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

}
