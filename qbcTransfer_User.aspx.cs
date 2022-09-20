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

public partial class qbcTransfer_User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Ajax.Utility.RegisterTypeForAjax(typeof(qbcTransfer_User));
        hiddendateformat.Value = Session["dateformat"].ToString();


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reportConfirm.xml"));

        heading.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbFromDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbUser.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        if (!IsPostBack)
        {
            fillUserName();//ClientisNumber()
            txtFromDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            txtToDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");

            txtFromDate.Attributes.Add("OnKeypress", "javascript:return ClientisNumber();");
            txtToDate.Attributes.Add("OnKeypress", "javascript:return ClientisNumber();");
        }

    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string dateformat = Session["dateformat"].ToString();
        string fromdatecon = txtFromDate.Text;// getDate(dateformat, txtFromDate.Text);
        string todatecon = txtToDate.Text;// getDate(dateformat, txtToDate.Text);

        Response.Redirect("qbcTransferView_User.aspx?fromdate=" + fromdatecon + "&todate=" + todatecon + "&userid=" + drpUser.SelectedValue + "&username=" + drpUser.SelectedItem + "&order=asc");
    }

    protected void fillUserName()
    {
        int i;
        DataSet dsUserName = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.loginAdmin loginAd = new NewAdbooking.Classes.loginAdmin();

            dsUserName = loginAd.getUserName();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.loginAdmin loginAd = new NewAdbooking.classesoracle.loginAdmin();

            dsUserName = loginAd.getUserName();
        }
        else
        {
            NewAdbooking.classmysql.loginAdmin loginAd = new NewAdbooking.classmysql.loginAdmin();
            dsUserName = loginAd.getUserName();

        }

        drpUser.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select User Name--";
        li1.Value = "0";
        li1.Selected = true;
        drpUser.Items.Add(li1);

        for (i = 0; i < dsUserName.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = dsUserName.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = dsUserName.Tables[0].Rows[i].ItemArray[1].ToString();
            drpUser.Items.Add(li);
        }
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
