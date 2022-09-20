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

public partial class agency_type_slab : System.Web.UI.Page
{
    static string fDate, tDate;
    int j = 0;
    DataSet dk1 = new DataSet();
    DataSet dk = new DataSet();
    DataRow my_row;
    string agency_type_code = "";
    string comp_code = "";
    string modifyflag = "";
    string execflag = "";
    string message;
    static string gb_commision_typ, gb_commrate, gb_from_day, gb_to_day, gb_valid_from, gb_valid_to,rec_id;



    protected void Page_Load(object sender, EventArgs e)
    {


        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddencomcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

       // Session["agency_type_slab"] = null;

        agency_type_code = Request.QueryString["agency_type_code"].ToString();

        hdnagencytypecode.Value = agency_type_code;
        modifyflag = Request.QueryString["d"].ToString();
        hdnmodifyflag.Value = Request.QueryString["d"].ToString();
     //   execflag = Request.QueryString["k"].ToString();
     //   hdnexecflag.Value = Request.QueryString["k"].ToString();
        hdnsescode.Value = "";
        if (hdnmodifyflag.Value == "0")
        {
            btndelete.Enabled = true;
            Button1.Enabled =  true;

           

        }

        else if (hdnmodifyflag.Value == "1")
        {
            btndelete.Enabled = true;
            Button1.Enabled = true;

        }


        else if (hdnmodifyflag.Value == "5")
        {
            btndelete.Enabled = false;
            Button1.Enabled = false;
            drpcommisiontyp.Enabled = false;
            txtcommision.Enabled = false;
            txtslabfrom.Enabled = false;
            txtslabto.Enabled = false;
            txtfromdt.Enabled = false;
            txttodt.Enabled = false;
            DataGrid1.Enabled = false;

        }


        else
        {
            btndelete.Enabled = false;
            Button1.Enabled = false;


        }








        //			-------------------------------------Code Of XML File--------------
        //		
        Ajax.Utility.RegisterTypeForAjax(typeof(agency_type_slab));
        DataSet objDataSet = new DataSet();
        comp_code = Session["compcode"].ToString();
        objDataSet.ReadXml(Server.MapPath("XML/agency_type_slab.xml"));

        lblcommisiontyp.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcommision.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lblslabfrom.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lblslabto.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lblfromdt.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lbltodt.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        lblextra1.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        lblextra2.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();


        //         --------------------------------End-------------------------------------------------

        if (!Page.IsPostBack)
        {
            bindcommistype();
            btndelete.Attributes.Add("OnClick", "javascript:return deletestatus();");
            Button1.Attributes.Add("OnClick", "javascript:return summition();");


            if (dk1.Tables.Count > 0 && Session["statussave"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();
            }

            if (Session["agency_type_slab"] == null || Session["agency_type_slab"] == "")
            {

                DataGrid2.Visible = false;
                divdatagrid2.Visible = false;

                divdatagrid1.Visible = true;
                DataGrid1.Visible = true;

                hiddenfdate.Value = "";
                hiddentdate.Value = "";
                tDate = "";
                fDate = "";

                databind("COMM_TYPE");

            }
            else
            {

                DataGrid2.Visible = true;
                divdatagrid2.Visible = true;

                divdatagrid1.Visible = false;
                DataGrid1.Visible = false;


                bindgrid1("COMM_TYPE");

                hiddenfdate.Value = fDate;
                hiddentdate.Value = tDate;

            }


        }


    }





    public void bindcommistype()
    {
        DataSet billtyp = new DataSet();
        billtyp.ReadXml(Server.MapPath("XML/agency_type_slab.xml"));
        drpcommisiontyp.Items.Clear();
        int i;
        for (i = 0; i < billtyp.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = billtyp.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = billtyp.Tables[1].Rows[0].ItemArray[i].ToString();

            drpcommisiontyp.Items.Add(li);

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;


        hiddenfdate.Value = hiddenfdate.Value + txtfromdt.Text + ",";
        hiddentdate.Value = hiddentdate.Value + txttodt.Text + ",";
        fDate = hiddenfdate.Value;
        tDate = hiddentdate.Value;


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "COMM_TYPE";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "COMM_RATE";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "FROM_DAYS";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "TILL_DAYS";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "VALID_FROM";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "VALID_TO";
        mydatatable1.Columns.Add(mycolumn1);
        DataSet len = (DataSet)Session["agency_type_slab"];
        int length;
        if (len != null)
        {
            length = len.Tables.Count;
        }
        else
        {
            length = 0;
        }
        int j = 0;
        if (Session["agency_type_slab"] != null && Session["agency_type_slab"] != "")
        {
            while (j < length)
            {
                string sf = len.Tables[j].Rows[0].ItemArray[4].ToString();
                string st = len.Tables[j].Rows[0].ItemArray[5].ToString();
               string adtypecode = len.Tables[j].Rows[0].ItemArray[0].ToString();
               // string uom1 = len.Tables[j].Rows[0].ItemArray[8].ToString();
                string[] ff = sf.Split('/');
                string mm = ff[0];//.ToString();
                string dd = ff[1];
                string yyyy = ff[2];

                string[] tt = st.Split('/');
                string mm1 = tt[0];//.ToString();
                string dd1 = tt[1];
                string yyyy1 = tt[2];

                string txtfrom = txtfromdt.Text;
                string txtto = txttodt.Text;
               // string adtyp = drpadtype.SelectedValue;

                string[] txtff = txtfrom.Split('/');
                string txtmm = txtff[0];//.ToString();
                string txtdd = txtff[1];
                string txtyyyy = txtff[2];

                string[] txttt = txtto.Split('/');
                string txtmm1 = txttt[0];//.ToString();
                string txtdd1 = txttt[1];
                string txtyyyy1 = txttt[2];

               
                    DataSet ds_b = new DataSet();
                    if (len.Tables[j].Rows[0].ItemArray[0].ToString() == drpcommisiontyp.SelectedValue)
                    {
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.pop databindcomm = new NewAdbooking.Classes.pop();


                            ds_b = databindcomm.datechk(sf, st, txtfrom, txtto, Session["dateformat"].ToString());
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.pop databindcomm = new NewAdbooking.classesoracle.pop();
                            ds_b = databindcomm.datechk(sf, st, txtfrom, txtto, Session["dateformat"].ToString());
                        }

                        if (ds_b.Tables[0].Rows[0].ItemArray[0].ToString() == "In Range")
                        {
                            //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                            message = "The Commision Apply  for this duration has already been submitted";
                            AspNetMessageBox(message);
                            return;
                        }

                        DataSet ds_b1 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.agency_type_slab databindcomm = new NewAdbooking.Classes.agency_type_slab();
                            ds_b1 = databindcomm.slabchk(len.Tables[j].Rows[0].ItemArray[2].ToString(), len.Tables[j].Rows[0].ItemArray[3].ToString(), txtslabfrom.Text, txtslabto.Text, Session["dateformat"].ToString());
                        }

                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.agency_type_slab databindcomm = new NewAdbooking.classesoracle.agency_type_slab();
                            ds_b1 = databindcomm.slabchk(len.Tables[j].Rows[0].ItemArray[2].ToString(), len.Tables[j].Rows[0].ItemArray[3].ToString(), txtslabfrom.Text, txtslabto.Text, Session["dateformat"].ToString());
                        }


                        if (ds_b1.Tables[0].Rows[0].ItemArray[0].ToString() == "In Range")
                        {
                            //Response.Write("<script>alert('You have already entered the Commision Apply On for this duration');</script>");
                            message = "The Commision Apply  for this Slab has already been submitted";
                            AspNetMessageBox(message);
                            return;
                        }

                    }

                j++;

            }
        }


        myrow1 = mydatatable1.NewRow();

        myrow1["COMM_TYPE"] = drpcommisiontyp.SelectedItem.Value;
        gb_commision_typ = drpcommisiontyp.SelectedItem.Value;

        myrow1["COMM_RATE"] = txtcommision.Text;
        gb_commrate = txtcommision.Text;

        myrow1["FROM_DAYS"] = txtslabfrom.Text;
        gb_from_day = txtslabfrom.Text;

        myrow1["TILL_DAYS"] = txtslabto.Text;
        gb_to_day = txtslabto.Text;

        myrow1["VALID_FROM"] = txtfromdt.Text;
        gb_valid_from = txtfromdt.Text;


        myrow1["VALID_TO"] = txttodt.Text;
        gb_valid_to = txttodt.Text;


        mydatatable1.Rows.Add(myrow1);


        if (Session["agency_type_slab"] != null)
        {
            DataSet dsNew = new DataSet();
            dsNew = (DataSet)Session["agency_type_slab"];
            dk1 = dsNew;
        }

        dk1.Tables.Add(mydatatable1);

        Session["agency_type_slab"] = dk1;
        bindgrid1("COMM_TYPE");



    }


   protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(agency_type_slab), "ShowAlert", strAlert, true);
    }
    public void bindgrid1(string sortfield)
    {
        DataGrid1.Visible = false;
        DataGrid2.Visible = true;
        divdatagrid2.Visible = true;
        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        //----------------------added by sayrabh Agarwal


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_TYPE";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMM_RATE";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FROM_DAYS";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TILL_DAYS";
        mydatatable.Columns.Add(mycolumn);
       
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "REC_ID";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "VALID_FROM";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "VALID_TO";
        mydatatable.Columns.Add(mycolumn);

        my_row = mydatatable.NewRow();


        my_row["COMM_TYPE"] = gb_commision_typ;
        my_row["COMM_RATE"] = gb_commrate;

        my_row["FROM_DAYS"] = gb_from_day;

        my_row["TILL_DAYS"] = gb_to_day;

        my_row["VALID_FROM"] = gb_valid_from;

        my_row["VALID_TO"] = gb_valid_to;

        my_row["REC_ID"] = "0";
        if (Session["agency_type_slab"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid1.DataSource = ds_tbl.Tables[0];
            //  DataGrid1.DataBind();
        }
        else
        {
            int d;
            int g;
            DataSet dsnew = new DataSet();
            dsnew = (DataSet)Session["agency_type_slab"];
            if (dsnew.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

            for (d = 0; d <= dsnew.Tables.Count - 1; d++)
            {
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                my_row = dsnew.Tables[d].Rows[0];
                //}
                //else
                //{
                //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                //}



                mydatatable.ImportRow(my_row);



            }


            ds_tbl.Tables.Add(mydatatable);
            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            // dv.Sort = sortfield;


            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;

        }

        gb_commision_typ = "";
        gb_commrate = "";
        gb_from_day = "";
        gb_to_day = "";
        gb_valid_from = "";
        gb_valid_to = "";
        rec_id = "";
    }

    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }


    public void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;

            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + "   OnClick=\"javascript:return selectstatus('" + str + "');\" value=" + e.Item.Cells[7].Text + "  />";

            //OnClick=\"javascript:return selectstatus();\"
            j++;
            //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";
        }

        if (e.Item.ItemType == ListItemType.Header)
        {
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {

                    case "COMM_TYPE":
                        str = "Commision Type";
                        break;
                    case "COMM_RATE":
                        str = "Commision Rate";
                        break;

                    case "FROM_DAYS":
                        str = "Slab From";
                        break;

                    case "TILL_DAYS":
                        str = "Slab To";
                        break;

                    case "VALID_FROM":
                        str = "Valid From";
                        break;

                    case "VALID_TO":
                        str = "Valid To";
                        break;

                };
                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //$ctl01$ctl00

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }

            }
        }
    }







    public void databind(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            ds = agentmastersave.agencytypeexecute(comp_code, agency_type_code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab status = new NewAdbooking.classesoracle.agency_type_slab();
            ds = status.agencytypeexecute(comp_code, agency_type_code);
        }
        else
        {
            //NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            //ds = status.statusbind12(agencysubcode, Session["compcode"].ToString(), Session["userid"].ToString(), Session["dateformat"].ToString(), agencode);
        }
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        if (ds.Tables.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;
            dv.Sort = sortfield;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }
    }



    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }




    [Ajax.AjaxMethod]
    public DataSet databind1(string compcode, string agency_type_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            ds = agentmastersave.agencytypeexecute(compcode, agency_type_code);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab status = new NewAdbooking.classesoracle.agency_type_slab();
            ds = status.agencytypeexecute(compcode, agency_type_code);

            return ds;
        }
        else
        {
            //NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            //ds = status.statusbind(agecode, compcode, userid, hiddenccode);

            return ds;
        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }


    [Ajax.AjaxMethod]
    public DataSet UPDATE(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid1, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            ds = agentmastersave.saveagencytype_UPDATE(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab status = new NewAdbooking.classesoracle.agency_type_slab();
            ds = status.saveagencytype_UPDATE(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AgencyTypeMaster status = new NewAdbooking.classmysql.AgencyTypeMaster();
            ds = status.saveagencytype_UPDATE(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);

            return ds;
        }

    }









    [Ajax.AjaxMethod]
    public DataSet Submit(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid1, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            ds = agentmastersave.saveagencytype(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab status = new NewAdbooking.classesoracle.agency_type_slab();
            ds = status.saveagencytype(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);

            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AgencyTypeMaster status = new NewAdbooking.classmysql.AgencyTypeMaster();
            ds = status.saveagencytype(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5,"mm/dd/yyyy");

            return ds;
        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }



    [Ajax.AjaxMethod]
    public DataSet delete1(string compcode, string agencytypecode, string cotype, string corate, string hdnsescode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            da = agentmastersave.agencytypedelete(compcode, agencytypecode, cotype, corate, hdnsescode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab delete = new NewAdbooking.classesoracle.agency_type_slab();
            da = delete.agencytypedelete(compcode, agencytypecode, cotype, corate, hdnsescode);
            return da;
        }
        else
        {
            //NewAdbooking.classmysql.pop delete = new NewAdbooking.classmysql.pop();
            //da = delete.statusdelete(compcode, userid, agencode, agencysubcode, hiddenccode);
            //return da;
        }
        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet duplicay(string compcode, string cotype, string corate, string fromdays, string todays, string validfrom, string validto)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            ds = agentmastersave.cheakduplicacy(compcode, cotype, corate, fromdays, todays, validfrom, validto);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab agentmastersave = new NewAdbooking.classesoracle.agency_type_slab();
            ds = agentmastersave.cheakduplicacy(compcode, cotype, corate, fromdays, todays, validfrom, validto);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AgencyTypeMaster delete = new NewAdbooking.classmysql.AgencyTypeMaster();
            ds = delete.cheakduplicacy(compcode, cotype, corate, fromdays, todays, validfrom, validto);
           // return ds;
        }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet databind11(string agecode,string compcode,string userid,string code10)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
            ds = agentmastersave.agencytypeexecute1123(agecode, compcode, userid, code10);

            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.agency_type_slab status = new NewAdbooking.classesoracle.agency_type_slab();
            ds = status.agencytypeexecute1123(agecode, compcode, userid, code10);

            return ds;
        }
        else
        {
            //NewAdbooking.classmysql.pop status = new NewAdbooking.classmysql.pop();
            //ds = status.statusbind(agecode, compcode, userid, hiddenccode);

            return ds;
        }
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }

}
