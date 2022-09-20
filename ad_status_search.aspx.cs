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

public partial class ad_status_search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnRun.Attributes.Add("OnClick", "javascript:return runReport();");
        hiddendateformat.Value = Session["dateformat"].ToString();
        if (!Page.IsPostBack)
        {
            bindEdition();
        }
    }
    private void bindEdition()
    {
        DataSet ds = new DataSet();
        string agency_name = Session["agency_name"].ToString();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportconfirm clsconfirm = new NewAdbooking.classesoracle.reportconfirm();
            ds = clsconfirm.bindSapEdition(agency_name);
            drpedition.Items.Clear();
            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Client-";
            li1.Value = "0";
            li1.Selected = true;
            drpedition.Items.Add(li1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    drpedition.Items.Add(li);
                }
            }

        }
        else
        {
            NewAdbooking.Classes.Class1 clsconfirm = new NewAdbooking.Classes.Class1();
            ds = clsconfirm.bindSapEdition(agency_name);
            drpedition.Items.Clear();
            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Client-";
            li1.Value = "0";
            li1.Selected = true;
            drpedition.Items.Add(li1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    drpedition.Items.Add(li);
                }
            }

        }
    }
}
