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
using System.Web.Mail;

public partial class followup : System.Web.UI.Page
{
    int i = 0;
    string compcode = "";
    string userid = "";
    string dateformat = "";
    string view = "";
    string agency = "";
    string id;
    string client = "";
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
        Ajax.Utility.RegisterTypeForAjax(typeof(followup));
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();

        btnremainder.Enabled = false;

        btnreport.Enabled = false;
        DrpDestinationType.Enabled = false;

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/followup.xml"));
        view = DrpDestinationType.SelectedValue;
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        btnExit.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnremainder.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnreport.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();


        if (!Page.IsPostBack)
        {
           // refreshfeild();
            bindorder();
            btnExit.Attributes.Add("OnClick", "javascript:return formexit();");
            btnreport.Attributes.Add("OnClick", "javascript:return report();");
            btnremainder.Attributes.Add("OnClick", "javascript:return savecomment();");
           
            txtagency.Attributes.Add("onkeydown", "javascript:return fillAgency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
            lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");

            txtclient.Attributes.Add("onkeydown", "javascript:return fillclient(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return onclickclient(event);");
            lstclient.Attributes.Add("onclick", "javascript:return onclickclient(event);");
          
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
        }
      
       
    }
    [Ajax.AjaxMethod]
    public DataSet fill_agency(string compcode, string maingrcode, string dateformat, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.followup admast = new NewAdbooking.Classes.followup();
            ds = admast.execute_maingrp(compcode, maingrcode, dateformat, extra1, extra2);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.followup admast = new NewAdbooking.classesoracle.followup();
                ds = admast.execute_maingrp(compcode, maingrcode, dateformat, extra1, extra2);
            }
        return ds;
    }
   

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        //refreshfeild();
        DataSet ds = new DataSet();
        string agency = "";
        string executive = "";
        string client = "";
        string fdate = txtfrmdate.Text;
        string tdate = txttodate1.Text;
   
        string extra1 = "";
        string extra2 = "";
        string extra3 = "";
        if (txtagency.Text != "" && txtagency.Text.LastIndexOf("(") >= 0)
        {
            agency = txtagency.Text.Substring(txtagency.Text.LastIndexOf("(") + 1, txtagency.Text.Length - txtagency.Text.LastIndexOf("(") - 2);

        }
       
        if (txtclient.Text != "" && txtclient.Text.LastIndexOf("(") >= 0)
        {
            client = txtclient.Text.Substring(txtclient.Text.LastIndexOf("(") + 1, txtclient.Text.Length - txtclient.Text.LastIndexOf("(") - 2);

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.followup frec = new NewAdbooking.Classes.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.followup frec = new NewAdbooking.classesoracle.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);

        }

        else
        {
            //NewAdbooking.classmysql.AuthorizationRelease clsbooking = new NewAdbooking.classmysql.AuthorizationRelease();
            //ds = clsbooking.getClientName(compcode, client);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(followup), "aa", "alert1();", true);
        }


        if (ds.Tables[0].Rows.Count > 0)
        {
        
            Session["RowLen"] = ds.Tables[0].Rows.Count;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, typeof(followup), "aa", "enable();", true);
         
   
        }
        //btnreport.Attributes.Add("onclick", "javascript:window.open('followupreport.aspx?compcode=" + compcode + "&agency=" + agency + "&client=" + client + "&fdate=" + fdate + "&view=" + view + "&tdate=" + tdate + "')");


    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        hiddenrowcount.Value = Session["RowLen"].ToString();
        if (e.Item.ItemType != ListItemType.Header)
        {
            //if (e.Item.Cells[14].Text != "Y" && e.Item.Cells[14].Text != "N")
            //{
            string str = "DataGrid1__CheckBox1" + i;
            e.Item.Cells[0].Text = "<input type='radio' name='a' width='5px' id=" + str + " OnClick=\"javascript:return Selectrow('" + str + "','" + e.Item.Cells[9].Text + "');\" value=" + e.Item.Cells[1].Text + "  />";
            e.Item.Cells[1].Text = "<a style=\"cursor:hand;color:blue\" id='cio" + i + "' onClick=\"openbooking1('" + e.Item.Cells[1].Text + "','cio" + i + "','" + hiddenrowcount.Value + "','" + e.Item.Cells[3].Text + "','" + e.Item.Cells[9].Text + "'  )\"value=" + e.Item.Cells[1].Text + ">" + e.Item.Cells[1].Text + "</a>";
            //}
            i = i + 1;
        }
        else
        {
           // string str = "DataGrid1__CheckBox_Header";
         //   e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectrow('" + str + "','" + e.Item.Cells[9].Text + "');\" value='DataGrid1__CheckBox_Header'  />";
        }
    }
 
    private void bindorder()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/followup.xml"));
        
        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            DrpDestinationType.Items.Add(li1);
        }

    }
    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.followup adagencycli = new NewAdbooking.classesoracle.followup();
            ds = adagencycli.clientxls(compcol, client);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.followup adagencycli = new NewAdbooking.Classes.followup();
            ds = adagencycli.clientxls(compcol, client);
        }

        return ds;
    }
    
    protected void refreshfeild()
    {
        txtfrmdate.Text = "";
        txttodate1.Text = "";
    }
 
      
}
