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

public partial class chnagesatausholdbooked : System.Web.UI.Page
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





        Ajax.Utility.RegisterTypeForAjax(typeof(chnagesatausholdbooked));

        if (!IsPostBack)
        {
          
            lstagency.Attributes.Add("onclick", "javascript:return insertagency11(event);");


           update.Attributes.Add("onclick", "javascript:return update113(event);");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
             btnsubmit.Attributes.Add("onclick", "javascript:return checkvalidation();");
        }


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/chnagesatausholdbooked.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
       
        lblciod.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();




    }





    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            //ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
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
            NewAdbooking.classesoracle.chnagesatausholdbooked save = new NewAdbooking.classesoracle.chnagesatausholdbooked();

            ds = save.update(insertid);
        }
        else
        {

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
        else
        {
            NewAdbooking.classesoracle.chnagesatausholdbooked save = new NewAdbooking.classesoracle.chnagesatausholdbooked();

            ds = save.bindgridchangestatus(txtfrmdate.Text, txttodate1.Text, hdncodesubcode.Value, txtciod.Text);
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


            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + "    value=" + e.Item.Cells[7].Text+" />";
           
            
            i = i + 1;
            e.Item.Cells[1].Text = i.ToString();
            j++;
        }
    }










}
