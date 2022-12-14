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

public partial class fmg_transaction : System.Web.UI.Page
{
    string agencycode;
    int j = 0;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
       
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        agencycode = Request.QueryString["agencycode"].ToString();
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddeninsertid.Value = Request.QueryString["fmgInsert"].ToString();
        if (Request.QueryString["adtype"] != null)
        {
            hdnadtype.Value = Request.QueryString["adtype"].ToString();
        }
        if (hiddeninsertid.Value != "")
        {
            arr = hiddeninsertid.Value.Split("~".ToCharArray());
        }
        if (Request.QueryString["fmgreasons"] != null && Request.QueryString["fmgreasons"] != "")
        {
            drpfmgresones.SelectedValue = Request.QueryString["fmgreasons"].ToString();
        }
        else
            drpfmgresones.SelectedValue = "0";
     //   hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["DateFormat"].ToString();
     //   hiddenusername.Value = Session["Username"].ToString();
      //  hiddenauto.Value = Session["autogenerated"].ToString();

      //  hiddenrtaudit_audit.Value = Session["rate_audit"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(fmg_transaction));


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/fmg_transaction.xml"));
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblbookingid.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblvfrm.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblvalidtill.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblfmgresones.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        if (!IsPostBack)
        {
            txtvalidityfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttilldate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");
            Button1.Attributes.Add("onclick", "javascript:return collectdata(this);");
            btnsubmit.Attributes.Add("onclick", "javascript:return checkvalidation();");
            btnExit.Attributes.Add("onclick", "javascript:return exit1();");
            if (hiddeninsertid.Value != "")
            {
               bindGrid();
            }
            binddest();
        }
        if (Request.QueryString["fmgreasons"] != null && Request.QueryString["fmgreasons"] != "")
        {
            drpfmgresones.SelectedValue = Request.QueryString["fmgreasons"].ToString();
        }
        else
            drpfmgresones.SelectedValue = "0";
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (Session["FILTER"].ToString() == "D")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, Session["revenue"].ToString());
            }
            else
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, "0");
            }
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
    }
    private void bindGrid()
    {
        string client = "";
        if (txtclient1.Text != "")
        {
            string[] client1 = txtclient1.Text.Split('(');
            client = client1[1].Replace(")", "");
        }

        string fromdate = "";
        string todate = "";
        string bookingid = "";
        string date = hiddendateformat.Value;
        string comecode1 = hiddencomcode.Value;
        string insertid = hiddeninsertid.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.fmg_transaction fmgbind = new NewAdbooking.classesoracle.fmg_transaction();
            ds = fmgbind.gbind(comecode1, todate, fromdate, bookingid, client, date, agencycode, insertid, hdnadtype.Value);
        }
        else
        {
            NewAdbooking.Classes.fmg_transaction fmgbind = new NewAdbooking.Classes.fmg_transaction();
            ds = fmgbind.gbind(comecode1, todate, fromdate, bookingid, client, date, agencycode, insertid, hdnadtype.Value);
        }
        Session["RowLen"] = ds.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Button1.Visible = true;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string client = "";
        if (txtclient1.Text != "")
        {
            string[] client1 = txtclient1.Text.Split('(');
            if (client1.Length > 1)
                client = client1[1].Replace(")", "");
            else
                client = client1[0].ToString();
        }

        string fromdate = txtvalidityfrom.Text;
        string todate = txttilldate.Text;
        string bookingid = txtbookingid.Text;
        string date = hiddendateformat.Value;
        string comecode1 = hiddencomcode.Value;
        string insertid = "";// hiddeninsertid.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.fmg_transaction fmgbind = new NewAdbooking.classesoracle.fmg_transaction();
            ds = fmgbind.gbind(comecode1, todate, fromdate, bookingid, client, date, agencycode, insertid, hdnadtype.Value);
        }
        else
        {
            NewAdbooking.Classes.fmg_transaction fmgbind = new NewAdbooking.Classes.fmg_transaction();
            ds = fmgbind.gbind(comecode1, todate, fromdate, bookingid, client, date, agencycode, insertid, hdnadtype.Value);
        }
        Session["RowLen"] = ds.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Button1.Visible = true;
           
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
            string str = "chk" + j;
            Boolean flag = false;
            if (arr != null && arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].ToString() == e.Item.Cells[2].Text)
                    {
                        flag = true;
                        i = arr.Length;
                    }
                }
                if (flag == false)
                {
                    e.Item.Cells[0].Text = "<input type='checkbox'  id=" + str + "   value=" + e.Item.Cells[2].Text + " onclick=\"javascript:return enable(); \" />";
                }
                else
                {
                    e.Item.Cells[0].Text = "<input type='checkbox' checked id=" + str + "   value=" + e.Item.Cells[2].Text + " onclick=\"javascript:return enable();\" />";
                }
            }
            else
            {
                e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "   value=" + e.Item.Cells[2].Text + " onclick=\"javascript:return enable();\"  />";
            }
            j++;
        }
    }


    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/fmg_transaction.xml"));
        drpfmgresones.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Fmg Reasons--";
        li1.Value = "0";
        li1.Selected = true;
        drpfmgresones.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            drpfmgresones.Items.Add(li);

        }


    }
}
