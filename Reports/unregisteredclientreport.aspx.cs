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


public partial class unregisteredclientreport : System.Web.UI.Page
{
    string compcode = "";
    string userid = "";
    string dateformat = "";
    int i = 0;
    int k = -1;
    string pper_desc = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {

        
           hiddencomcode.Value = Session["compcode"].ToString();
           compcode = hiddencomcode.Value;
           hiddenuserid.Value = Session["userid"].ToString();
           hiddendateformat.Value = Session["dateformat"].ToString();
          DataSet ds = new DataSet();
          ds.ReadXml(Server.MapPath("XML/unregisteredclientreport.xml"));

          lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
          lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
          lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
          lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
          heading.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
          BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
          btnExit.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
          lbldisplay.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
          lbluom.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
          lbldate.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
          btnreport.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();

          lblregister.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            userid = Session["userid"].ToString();
          pper_desc = "Client Register Required in Transaction";
        Ajax.Utility.RegisterTypeForAjax(typeof(unregisteredclientreport));
        
           if (!Page.IsPostBack)
           {
            bindbranch();
            bindorder();
            bindregister();
            binddate();
            adtypedata(Session["compcode"].ToString());
            binduom();
            btnExit.Attributes.Add("OnClick", "javascript:return formexit();");
            btnreport.Attributes.Add("onclick", "javascript:return openbooking1();");
            DataSet executequery = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
               // NewAdbooking.Report.Classes.unregisteredclient execute = new NewAdbooking.Report.Classes.unregisteredclient();
                //executequery = execute.getciragency(compcode, branch, ciragency, ciragencysubcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient execute = new NewAdbooking.Report.classesoracle.unregisteredclient();
                executequery = execute.getclint(compcode, userid, pper_desc);
                hdnflag.Value = executequery.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {

                string procedureName = "cir_get_userpermission";
                NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
                string[] parameterValueArray = { compcode ,  "","","","", userid , pper_desc , "","","","","","","","","",""};
                ds = obj.BindCommanFunction(procedureName, parameterValueArray);
            }
        }

    }
    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.unregisteredclient pub = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient pub = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }
        dpd_branch.SelectedValue = Session["revenue"].ToString();
    }
    private void bindorder()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/unregisteredclientreport.xml"));

        int i;
        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            dpaddtype.Items.Add(li1);
        }

    }
    private void bindregister()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/unregisteredclientreport.xml"));

        int i;
        for (i = 0; i < ds.Tables[4].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[4].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[4].Rows[0].ItemArray[i].ToString();
            drpregister.Items.Add(li1);
        }

    }




    private void binddate()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/unregisteredclientreport.xml"));

        int i;
        for (i = 0; i < ds.Tables[3].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            drpadate.Items.Add(li1);
        }

    }
    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 bind = new NewAdbooking.Classes.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode };
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
    private void binduom()
    {
        string value = "";
        ///////if in adtype classied is selected than 1 is pass and then the uom drop down is bind from uom_mast where uom type is 3 and if not then not by 3
        if (drpadtype.SelectedItem.Text == "CLASSIFIED")
        {
            value = "1";

        }
        else
        {
            value = "0";
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binduom = new NewAdbooking.Classes.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), value);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster binduom = new NewAdbooking.classesoracle.RateMaster();
                ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), value);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "binduomforrate_binduomforrate_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), value };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

        drpuom.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select UOM-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpuom.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpuom.Items.Add(li);
            }

        }

    }


    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        hiddenrowcount.Value = Session["RowLen"].ToString();
        k = k + 1;
          if (e.Item.ItemType != ListItemType.Header)
        {
            
            e.Item.Cells[3].Text = k.ToString();
    
            string str = "DataGrid1__CheckBox1" + i;
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectrow('" + str + "','" + e.Item.Cells[14].Text + "');\" value=" + e.Item.Cells[3].Text + "  />";
            e.Item.Cells[4].Text = "<a  id='cio" + i + "' onClick=\"openbooking1('" + e.Item.Cells[4].Text + "','cio" + i + "','" + hiddenrowcount.Value + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[12].Text + "'  )\"value=" + e.Item.Cells[3].Text + ">" + e.Item.Cells[4].Text + "</a>";
            e.Item.Cells[4].Enabled = false;
            i = i + 1;
            if (hdnflag.Value == "Y")
            {
                e.Item.Cells[1].Visible = true;
                e.Item.Cells[5].Enabled = true;
            }
            else
            {
                e.Item.Cells[1].Visible = false;
                e.Item.Cells[5].Enabled = false;
            }
        }
        else
        {
            string str = "DataGrid1__CheckBox_Header";
         //  e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectrow('" + str + "','" + e.Item.Cells[12].Text + "');\" value='DataGrid1__CheckBox_Header'  />";
            if (hdnflag.Value == "Y")
            {
                e.Item.Cells[1].Text = "Registered";
                e.Item.Cells[2].Text = "Not To Register";
            }
            else
            {
                e.Item.Cells[1].Visible = false;
                e.Item.Cells[2].Visible = false;
            }
        }
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string fromdate = txtfrmdate.Text;
        string todate = txttodate1.Text;
        string compcode = Session["compcode"].ToString();
        string dateformat = Session["dateformat"].ToString();
        string branch = dpd_branch.Text;
        string padtype = drpadtype.Text;
        string puomcode = drpuom.Text;
        string pdate_flag = drpadate.Text;
        string pextra1 = "";
        string pextra2 = drpregister.Text;
        string pextra3 = "";
        string pextra4 = "";
        string pextra5 = "";

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.clint(compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, pextra2, pextra3, pextra4, pextra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = unregistclient.clint(compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, pextra2, pextra3, pextra4, pextra5);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "rpt_unregistered_client";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, pextra2, pextra3, pextra4, pextra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        Session["RowLen"] = ds.Tables[0].Rows.Count;
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

    }
    protected void DataGrid1_EditCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

          //  string var12= e.CommandName;
           // e.Item.ItemIndex=1;
            //string productID = e.Item.Cells(2).Text;
            TextBox txt1 = (TextBox)e.Item.FindControl("client");
            Label lbl1 = (Label)e.Item.FindControl("bkciod");
            string clientname = txt1.Text;
            string bkd = lbl1.Text;
            string compcode = Session["compcode"].ToString();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
                ds = unregistclient.Updatedata(bkd, clientname, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient clsbooking = new NewAdbooking.Report.classesoracle.unregisteredclient();
                ds = clsbooking.Updatedata(bkd, clientname, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "clientupdttrasac2";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { bkd, clientname, compcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated Successfully');", true);
          
           // return ds;
        }

    }


    protected void DataGrid1_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            TextBox txt1 = (TextBox)e.Item.FindControl("client");
            Label lbl1 = (Label)e.Item.FindControl("bkciod");
            string clientname = txt1.Text;
            string bkd = lbl1.Text;
            string compcode = Session["compcode"].ToString();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
                ds = unregistclient.Updatenotregisterd(bkd, clientname, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient clsbooking = new NewAdbooking.Report.classesoracle.unregisteredclient();
                ds = clsbooking.Updatenotregisterd(bkd, clientname, compcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "ad_client_mark_nonregistered";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { bkd, clientname, compcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated Successfully');", true);

            // return ds;
        }

    }


}
