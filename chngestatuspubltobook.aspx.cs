using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class chngestatuspubltobook : System.Web.UI.Page
{
    int i = 0;
    int j = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();





        Ajax.Utility.RegisterTypeForAjax(typeof(chngestatuspubltobook));

        if (!IsPostBack)
        {

            lstagency.Attributes.Add("onclick", "javascript:return insertagency11(event);");


            update.Attributes.Add("onclick", "javascript:return update113(event);");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            btnsubmit.Attributes.Add("onclick", "javascript:return checkvalidation();");
            bindadtype();

        }


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/chnagesatausholdbooked.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();

        lblciod.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();




    }


    public void bindadtype()
    {

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpadtype.Items.Add(li1);


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadtype.Items.Add(li);


        }
    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster bindagenname = new FourCPlus.AdBooking.BookingMaster.Oracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                //  ds = bindagenname.bindagency(compcode, userid, agency, "0");
                ds = bindagenname.bindagency_DB(compcode, agency);
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bindagenname = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                ds = bindagenname.bindagency(compcode, userid, agency, "0");
            }
        }
        return ds;



    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet update11(string insertid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.chnagesatausholdbooked save = new NewAdbooking.Classes.chnagesatausholdbooked();

            ds = save.update(insertid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changedstatuspubtobook save = new NewAdbooking.classesoracle.changedstatuspubtobook();

            ds = save.update(insertid);
        }
        else
        {
            NewAdbooking.classmysql.chngstatuspubtobook save = new NewAdbooking.classmysql.chngstatuspubtobook();
            ds = save.update(insertid);

        }
        return ds;



    }










    protected void btnsubmit_Click(object sender, EventArgs e)
    {


        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.chnagesatausholdbooked save = new NewAdbooking.Classes.chnagesatausholdbooked();

            ds = save.bindgridchangestatus(txtfrmdate.Text, txttodate1.Text, hdncodesubcode.Value, txtciod.Text);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.changedstatuspubtobook save = new NewAdbooking.classesoracle.changedstatuspubtobook();

            ds = save.bindgridchangestatus(txtfrmdate.Text, txttodate1.Text, hdncodesubcode.Value, txtciod.Text, dpadtype.SelectedValue);
        }
        else
        {
            //string procedureName = "BINDGRID_CHANGESTATUSPTOB";
            string[] parameterValueArray = new string[] { txtfrmdate.Text, txttodate1.Text, hdncodesubcode.Value, txtciod.Text, dpadtype.SelectedValue };
            //NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            NewAdbooking.classmysql.chngstatuspubtobook bind = new NewAdbooking.classmysql.chngstatuspubtobook();
            ds = bind.changestatuspublish_to_book(txtfrmdate.Text, txttodate1.Text, hdncodesubcode.Value, txtciod.Text, dpadtype.SelectedValue,"");

        }
        hdnlength.Value = ds.Tables[0].Rows.Count.ToString();
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();


    }



    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            e.Item.Cells[0].Text = "<input type='checkbox' enabled=true id='checkall' onclick=\"javascript:return selectAll();\" />";
        }
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string bookingid = e.Item.Cells[4].Text;
            string str = "chk" + j;


            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "    value=" + e.Item.Cells[7].Text + " />";


            i = i + 1;
            e.Item.Cells[1].Text = i.ToString();
            j++;
        }
    }










}
