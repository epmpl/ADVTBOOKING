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

public partial class bullet_premium : System.Web.UI.Page
{

    int j = 0;
    DataRow my_row;
    static DataSet dk1 = new DataSet();
    static string gbedition, gbpremium, gbamount, gbcircular, gbstatusname, gbvaliffrom, gbvalifto, gbpublication;


    string logocode = "";
    string temp = "";

    string ankit = "";

    string dateformat = "";

    //static string fDate, tDate;
    protected void Page_Load(object sender, EventArgs e)
    {


        hiddendateformat.Value = Session["dateformat"].ToString();

        dateformat = Session["dateformat"].ToString();
        Response.Expires = -1;

        Response.Buffer = true;
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        temp = Request.QueryString["temp"].ToString();
        ankit = Request.QueryString["ankit"].ToString();
        hdnmodify.Value = Request.QueryString["flag2"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(bullet_premium));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/logopremmast.xml"));
        premium.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        edition.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnSubmit.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        Label1.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();


        logocode = Request.QueryString["logocode"].ToString();

        hdnlogo.Value = Request.QueryString["logocode"].ToString();

        if (ankit == "1")
        {
            btnSubmit.Enabled = false;

        }

        else if (ankit == "0")
        {
            btnSubmit.Enabled = true;
        }
        else
        {
            btnSubmit.Enabled = false;

        }




        if (hdnmodify.Value == "0")
        {
            btndelete.Enabled = false;

        }

        else if (hdnmodify.Value == "1")
        {
            btndelete.Enabled = true;
        }
        else
        {
            btndelete.Enabled = false;

        }












        if (!Page.IsPostBack)
        {

            drppubl.Attributes.Add("onchange", "javascript:return bind_edition();");
            btnSubmit.Attributes.Add("Onclick", "javascript:return savelogo();");
            btnclose.Attributes.Add("OnClick", "javascript:return Exit();");
            btndelete.Attributes.Add("OnClick", "javascript:return Delete();");

            txtfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtto.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            DropDownList1.Attributes.Add("OnChange", "javascript:return geteditionval();");


            // bindpub();

            publicationbind();


            if (dk1.Tables.Count > 0 && Session["BULLET"] == null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
            }

            if (Session["BULLET"] == null)
            {
                DataGrid2.Visible = false;
                Divgrid2.Visible = false;
                Divgrid1.Visible = true;
                DataGrid1.Visible = true;

                binddata();
            }
            else
            {
                DataGrid2.Visible = true;
                Divgrid2.Visible = true;
                Divgrid1.Visible = false;
                DataGrid1.Visible = false;
                binddata1("cust_status");

            }

        }
    }



    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "");
        }

        int i;
        ListItem li;
        li = new ListItem();
        drppubl.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        li.Value = "0";
        li.Selected = true;
        drppubl.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drppubl.Items.Add(li1);
            }
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

    public void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //string str = "DataGrid1__ctl_CheckBox1" + j;

            ////e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "  value=" + e.Item.Cells[4].Text + "  />";
            //e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return ClientSelected('" + str + "');\" value=" + e.Item.Cells[4].Text + "  />";
            //j++;

            //saurabh

            DataView dv = new DataView();


            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;




            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;

                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return StatusSelect('" + str + "');\" value=" + e.Item.Cells[3].Text + "-" + e.Item.Cells[6].Text + "  />";
                j++;

            }

            if (e.Item.ItemType == ListItemType.Header)
            {
                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {


                        // case "STATUS_NAME":
                        case "cust_status":
                            str = "Status";
                            break;

                        case "FROM_DATE":
                            str = "From Date";
                            break;

                        case "TO_DATE":
                            str = "To Date";
                            break;


                        case "circular_no":
                            str = "Circular No.";
                            break;

                    };
                    string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                    strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                    if (strd.Length < 2)
                        strd = "0" + strd;
                    if (ViewState["order"].ToString() == "DESC")
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "</a>";

                    }
                    else
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')   \">" + str + "</a>";
                    }




                }
            }


        }

    }



    [Ajax.AjaxMethod]
    public DataSet bindlogo1(string compcode, string logocode, string seqno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bulletmaster databind = new NewAdbooking.classesoracle.bulletmaster();
            ds = databind.logobind1(compcode, logocode, seqno);

        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.bulletmaster modify = new NewAdbooking.Classes.bulletmaster();

                ds = modify.bindlogo1(compcode, logocode, seqno);


            }




        return ds;
    }







    public void bindpub()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.logopremmast advpub = new NewAdbooking.classesoracle.logopremmast();
            ds = advpub.bindedition11(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.logopremium modify = new NewAdbooking.Classes.logopremium();
            ds = modify.bindedition11(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        DropDownList1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            DropDownList1.Items.Add(li);


        }

    }

    [Ajax.AjaxMethod]

    public DataSet save(string compcode, string userid, string logoprem, string edition, string premimum, string amount, string validfrom, string validto, string publication)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bulletmaster cate = new NewAdbooking.classesoracle.bulletmaster();

            ds = cate.save1(compcode, userid, logoprem, edition, premimum, amount, validfrom, validto, publication);


        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.bulletmaster modify = new NewAdbooking.Classes.bulletmaster();

                ds = modify.save(compcode, userid, logoprem, edition, premimum, amount, validfrom, validto, publication);


            }



        return ds;
    }




    [Ajax.AjaxMethod]

    public DataSet update1(string COMP_CODE, string USERID, string LOGOPREMIUM_CODE, string EDITION, string AMOUNT, string premimum, string hdnsequenceno, string validfrom, string validto, string publication)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bulletmaster cate = new NewAdbooking.classesoracle.bulletmaster();

            ds = cate.update1(COMP_CODE, USERID, LOGOPREMIUM_CODE, EDITION, AMOUNT, premimum, hdnsequenceno, validfrom, validto, publication);


        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.bulletmaster modify = new NewAdbooking.Classes.bulletmaster();

                ds = modify.update1(COMP_CODE, USERID, LOGOPREMIUM_CODE, EDITION, AMOUNT, premimum, hdnsequenceno, validfrom, validto, publication);



            }





        return ds;
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {



        hiddenfdate.Value = hiddenfdate.Value + txtfrom.Text + ",";
        hiddentdate.Value = hiddentdate.Value + txtto.Text + ",";
        // fDate = hiddenfdate.Value;
        //tDate = hiddentdate.Value;




        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "EDITION";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "PREMIUM";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "VALIDFROM";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "VALIDTO";
        mydatatable1.Columns.Add(mycolumn1);




        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "AMOUNT";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "BULLETPREMIUMDETCODE";
        mydatatable1.Columns.Add(mycolumn1);



        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "PUBLICATION";
        mydatatable1.Columns.Add(mycolumn1);


        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "EDITIONCODE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "PUBLICATIONCODE";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;


        myrow1 = mydatatable1.NewRow();


        gbedition = hdnedition.Value;
        gbpremium = drpremium.SelectedItem.Text;
        gbamount = txtamount.Text;
        gbvaliffrom = txtfrom.Text;
        gbvalifto = txtto.Text;
        gbpublication = drppubl.SelectedItem.Value;

        myrow1["EDITIONCODE"] = hdnedition.Value;
        myrow1["PREMIUM"] = gbpremium;
        myrow1["AMOUNT"] = gbamount;

        myrow1["EDITION"] = hdneditiontext.Value;

        myrow1["VALIDFROM"] = gbvaliffrom;

        myrow1["VALIDTO"] = gbvalifto;
        if (drppubl.SelectedItem.Text == "--Select Publication Center--")
        {
            myrow1["PUBLICATION"] = "";
        }
        else
        {

            myrow1["PUBLICATION"] = drppubl.SelectedItem.Text;
            myrow1["PUBLICATIONCODE"] = drppubl.SelectedItem.Value;
        }



        int j = 0;
        if (DataGrid2.Items.Count > 0)
        {

            while (j < DataGrid2.Items.Count)
            {



                string fromdate = DataGrid2.Items[j].Cells[3].Text;
                string todate = DataGrid2.Items[j].Cells[4].Text;
                string publication = DataGrid2.Items[j].Cells[6].Text;
                if (drppubl.SelectedItem.Value == "0")
                {
                    if (DataGrid2.Items[j].Cells[6].Text == "&nbsp;")
                    {
                        if (fromdate == txtfrom.Text && todate == txtto.Text)
                        {
                            string message = "Bullet Premium already exist with this Date Range";
                            AspNetMessageBox(message);
                            txtfrom.Text = "";
                            txtto.Text = "";
                            return;
                        }
                    }


                }
                else if (DataGrid2.Items[j].Cells[6].Text == drppubl.SelectedItem.Text)
                {
                    if (fromdate == txtfrom.Text && todate == txtto.Text)
                    {
                        string message = "Bullet Premium already exist with this Date Range";
                        AspNetMessageBox(message);
                        txtfrom.Text = "";
                        txtto.Text = "";
                        return;
                    }
                }


                j++;
            }

        }




        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);

        Session["BULLET"] = dk1;

        binddata1("status_name");
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(bullet_premium), "ShowAlert", strAlert, true);
    }



    public void binddata1(string sortfield)
    {
        DataGrid2.Visible = true;
        Divgrid2.Visible = true;
        DataGrid1.Visible = false;
        Divgrid1.Visible = false;

        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();



        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "EDITION";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PREMIUM";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "AMOUNT";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "VALIDFROM";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "VALIDTO";
        mydatatable.Columns.Add(mycolumn);



        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "BULLETPREMIUMDETCODE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "PUBLICATION";
        mydatatable.Columns.Add(mycolumn);





        my_row = mydatatable.NewRow();


        my_row["EDITION"] = gbedition;
        my_row["PREMIUM"] = gbpremium;
        my_row["AMOUNT"] = gbamount;


        my_row["VALIDFROM"] = gbvaliffrom;

        my_row["VALIDTO"] = gbvalifto;
        my_row["PUBLICATION"] = gbpublication;





        ds_tbl.Tables.Add(mydatatable);



        if (Session["BULLET"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
            int d;
            int g;
            if (dk1.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

            for (d = 0; d <= dk1.Tables.Count - 1; d++)
            {

                my_row = dk1.Tables[d].Rows[0];






                mydatatable.ImportRow(my_row);



            }



            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;



            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;

        }





        drppubl.SelectedValue = "0";
        hdnedition.Value = "0";
        drpremium.SelectedValue = "0";
        txtamount.Text = "";
        txtfrom.Text = "";
        txtto.Text = "";
        hdneditiontext.Value = "";


    }





    public void binddata()
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bulletmaster modify = new NewAdbooking.Classes.bulletmaster();

            da = modify.logobind(Session["compcode"].ToString(), logocode);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.bulletmaster databind = new NewAdbooking.classesoracle.bulletmaster();
                da = databind.logobind(Session["compcode"].ToString(), logocode);

            }
            else
            {
                //NewAdbooking.classmysql.RetainerMaster databind = new NewAdbooking.classmysql.RetainerMaster();
                //da = databind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }


        DataView dv = new DataView();
        if (da.Tables.Count > 0)
        {
            dv = da.Tables[0].DefaultView;

            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

    }


    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        return ds;
    }




    [Ajax.AjaxMethod]
    public void binddata123(string compcode, string logocode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bulletmaster databind = new NewAdbooking.Classes.bulletmaster();

            da = databind.logobind(compcode, logocode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.bulletmaster databind = new NewAdbooking.classesoracle.bulletmaster();
                da = databind.logobind(compcode, logocode);

            }
            else
            {
                //NewAdbooking.classmysql.RetainerMaster databind = new NewAdbooking.classmysql.RetainerMaster();
                //da = databind.retainerstatusbind(retcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

            }


        DataView dv = new DataView();
        if (da.Tables.Count > 0)
        {
            dv = da.Tables[0].DefaultView;

            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

    }







    [Ajax.AjaxMethod]
    public DataSet Delete(string compcode, string amount)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bulletmaster rtmst = new NewAdbooking.Classes.bulletmaster();

            ds = rtmst.Delete(compcode, amount);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.bulletmaster rtmst = new NewAdbooking.classesoracle.bulletmaster();

                ds = rtmst.Delete(compcode, amount);
                string aa = "";
                binddata1(aa);

            }




        return ds;
    }






    [Ajax.AjaxMethod]

    public DataSet duplicay(string compcode, string logoprem, string edition, string validfrom, string validto,string publication)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bulletmaster cate = new NewAdbooking.classesoracle.bulletmaster();

            ds = cate.duplicay1(compcode, logoprem, validfrom, validto,publication);


        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bulletmaster rtmst = new NewAdbooking.Classes.bulletmaster();

            ds = rtmst.duplicay1(compcode, logoprem, edition, validfrom, validto,publication);

        }



        return ds;
    }






}
