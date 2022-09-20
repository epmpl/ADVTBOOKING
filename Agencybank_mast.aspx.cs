using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Agencybank_mast : System.Web.UI.Page
{
    string agencode, agencysubcode, comp, userid, show;
    int j = 0;
    string sortfield;

    string sortcon;

    public static int numberDiv;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] != null)
        {

            userid = Session["userid"].ToString();
            hiddenuserid.Value = userid;
            comp = Session["compcode"].ToString();
            hiddencomcode.Value = comp;
            hiddendateformat.Value = Session["dateformat"].ToString();
            show = Request.QueryString["show"].ToString();
            //Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Agencybank_mast));
        //			-------------------------------------Code Of XML File--------------
        //		
        DataSet objDataSet = new DataSet();

        objDataSet.ReadXml(Server.MapPath("XML/bank_master.xml"));

        BankName.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        Branch.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        Country.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        BankNo.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        City.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        ACCNO.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        clear.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();

        //         --------------------------------End-------------------------------------------------


        agencode = Request.QueryString["agecode"].ToString();
        hiddenagencycode.Value = agencode;
        agencysubcode = Request.QueryString["agencysubcode"].ToString();
        hiddenagensubcode.Value = agencysubcode;
        //DataSet objDataSet = new DataSet();
        //read XML File
        //work done by shweta

        if (agencode != "" && agencysubcode != "")
        { }
        else
        {
            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }
        //******************************************************


        countryname();
        binddata("bank_name");

        if (!Page.IsPostBack)
        {

            drpcountryname.Attributes.Add("OnChange", "javascript:return fillcity();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitdata();");
            //btnclose.Attributes.Add("OnClick", "javascript:return selected();");
            btndelete.Attributes.Add("OnClick", "javascript:return deleted();");
            clear.Attributes.Add("OnClick", "javascript:return cleardata();");
            //chk for validations shweta
            txtname.Attributes.Add("OnBlur", "javascript:return uppercase('txtname');");
            txtbran.Attributes.Add("OnBlur", "javascript:return uppercase('txtbran');");
            txtbno.Attributes.Add("OnBlur", "javascript:return uppercase('txtbno');");
            txtano.Attributes.Add("OnBlur", "javascript:return uppercase('txtano');");



            //***********************************************************************

        }

    }

    public void countryname()
    {
        NewAdbooking.Classes.bankmaster name = new NewAdbooking.Classes.bankmaster();
        DataSet ds = new DataSet();
        ds = name.adcountryname(Session["compcode"].ToString());
        drpcountryname.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Country-----";
        li1.Value = "0";
        li1.Selected = true;
        drpcountryname.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcountryname.Items.Add(li);
        }
    }



    [Ajax.AjaxMethod]
    public DataSet addcou(string country)
    {
        NewAdbooking.Classes.Master firstAgency = new NewAdbooking.Classes.Master();
        DataSet ds = new DataSet();
        ds = firstAgency.countcity(country);
        return ds;
    }


    public void binddata(string sortfield)
    {
        NewAdbooking.Classes.bankmaster bind = new NewAdbooking.Classes.bankmaster();
        DataSet ds = new DataSet();
        ds = bind.bankbind(agencode, agencysubcode, comp, userid);

        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;
        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();

        
        


    }

   
    [Ajax.AjaxMethod]
    public void insert(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode)
    {
        NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();
        DataSet ds = new DataSet();
        ds = ins.insertdata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode);

    }


    [Ajax.AjaxMethod]
    public DataSet bandcontact(string compcode, string userid, string agencode, string subagncode, string code10)
    {
        NewAdbooking.Classes.bankmaster databind = new NewAdbooking.Classes.bankmaster();
        DataSet da = new DataSet();
        da = databind.bankdata(compcode, userid, agencode, subagncode, code10);
        return da;
    }


    [Ajax.AjaxMethod]
    public void update(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode, string codebk)
    {
        NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();
        DataSet ds = new DataSet();
        ds = ins.updatedata(bankname, branch, country, city, bankno, accountno, compcode, userid, agencode, subagncode, codebk);

    }


    [Ajax.AjaxMethod]
    public void dele(string compcode, string userid, string codebk)
    {
        NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();
        DataSet ds = new DataSet();
        ds = ins.deletedata(compcode, userid, codebk);

    }




    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }

    protected void DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        DataView dv = new DataView();
        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "DataGrid1__ctl_CheckBox1" + j;
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\" value=" + e.Item.Cells[7].Text + "  />";
            j++;
        }

        if (e.Item.ItemType == ListItemType.Header)
        {

            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "bank_name":
                        str = "Bank Name";
                        break;
                    case "branch":
                        str = "Branch";
                        break;

                    case "countryname":
                        str = "Country";
                        break;

                    case "cityname":
                        str = "City";
                        break;

                    case "bank_no":
                        str = "Bank NO.";
                        break;

                    case "Acount_No":
                        str = "Account No.";
                        break;

                    


                };
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')\">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')  \">" + str + "</a>";

                }
                else
                {
                   // e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')\">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl" + dc.IndexOf(dc[ViewState["SortExpression"].ToString()]) + "','')   \">" + str + "</a>";
                }




            }
        }

    }

    private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        NewAdbooking.Classes.bankmaster bind = new NewAdbooking.Classes.bankmaster();
        DataSet ds = new DataSet();
        ds = bind.bankbind(agencode, agencysubcode, comp, userid);
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        if ((numberDiv % 2) == 0)
        {
            dv.Sort = e.SortExpression + " " + "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "ASC";
        }
        else
        {
            dv.Sort = e.SortExpression + " " + "DESC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "DESC";
        }
        numberDiv++;



        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();


    }
}
