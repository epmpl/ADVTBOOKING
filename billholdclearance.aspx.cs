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

public partial class billholdclearance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(billholdclearance));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencenter.Value = Session["revenue"].ToString();
        hiddencentername.Value = Session["centername"].ToString();
        hiddencentercode.Value = Session["center"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet objDataSet = new DataSet();
  

        objDataSet.ReadXml(Server.MapPath("XML/billholdclearance.xml"));
        lbfromdate.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbtodate.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        bntsub.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        btnCancel.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExit.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublicationCenter.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        lbbookingid.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btnsave.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lbbillholdtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        btnreport.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        btnmodify.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
      
        if (!Page.IsPostBack)
        {
            publicationbind();

            bntsub.Attributes.Add("onclick", "javascript:return submi();");
            btnCancel.Attributes.Add("onclick", "javascript:return clear1();");
            btnExit.Attributes.Add("onclick", "javascript:return exit();");
            btnsave.Attributes.Add("onclick", "javascript:return saveclick();");
            txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            btnreport.Attributes.Add("onclick", "javascript:return report1();");
            btnmodify.Attributes.Add("onclick", "javascript:return openpage();");
          
                  }
    }
    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {

        
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.updatestaus pub_cent1 = new NewAdbooking.BillingClass.classesoracle.updatestaus();
            ds = pub_cent1.publication_center(Session["compcode"].ToString());
        }
        else
        {
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        //li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
         li.Text = "-Select Booking Center-";
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }


    }




    [Ajax.AjaxMethod]
    public DataSet Fetch(string fdate, string todate, string bookingcenter, string holdtype, string bookini, string compcode, string dateformat, string logincenter,string userid,string extra1,string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.billholdcrearence insert = new NewAdbooking.Classes.billholdcrearence();
            ds = insert.Fetchdata(fdate, todate, bookingcenter, holdtype, bookini, compcode, dateformat, logincenter, userid, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billholdclearence insert = new NewAdbooking.classesoracle.billholdclearence();
            ds = insert.Fetchdata(fdate, todate, bookingcenter, holdtype, bookini, compcode, dateformat, logincenter, userid, extra1, extra2);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet savebillhold(string compcode, string bookingcenter, string bookingid, string billcycle, string usid, string billdate, string billno, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.billholdcrearence insert = new NewAdbooking.Classes.billholdcrearence();
            ds = insert.savedata(compcode, bookingcenter, bookingid, billcycle, usid, billdate, billno, dateformat, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billholdclearence insert = new NewAdbooking.classesoracle.billholdclearence();
            ds = insert.savedata(compcode, bookingcenter, bookingid, billcycle, usid, billdate, billno, dateformat, extra1, extra2, extra3, extra4, extra5);
        }
        return ds;
    }
}
