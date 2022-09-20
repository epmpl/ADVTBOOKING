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
using System.Configuration;


public partial class cash_recon_form : System.Web.UI.Page
{
     string userid, comp,  branchcode,show,optn;
     string compcode, branch_code, frmdt, todt, extra1, extra2, extra3, extra4, extra5, extra6;
     DataSet dk1 = new DataSet();
     DataSet dk = new DataSet();
     DataRow my_row;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] != null)
        {

            userid = Session["userid"].ToString();
            hiddenuserid.Value = userid;
            comp = Session["compcode"].ToString();
            hiddencomcode.Value = comp;
            hiddenbranchcode.Value = Session["revenue"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
           // show = Request.QueryString["show"].ToString();
           // hiddenshow.Value = Request.QueryString["show"].ToString();
            optn = Session["optn"].ToString();
            hiddenoptn.Value = Session["optn"].ToString();
            hiddencentername.Value = Session["centername"].ToString();
            txtcenter.Text = Session["centername"].ToString();
            txtcenter.Enabled = false;
            txtamt.Enabled = false;
            //Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(cash_recon_form));
          DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/cash_recon_form.xml"));
            lblcenter.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            lblfromdt.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            lbltodt.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        if(optn == "B")
        {
            lblbnkslipdt.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        }
        else{
            lblbnkslipdt.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        }

            lblvchno.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            lblamt.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();



        if(optn=="B")
        {
             lblvchno.Style.Add("display", "none");
            txtvchno.Style.Add("display", "none");
        }
        if(!Page.IsPostBack)
			{                
            btnsubmit.Attributes.Add("OnClick", "javascript:return submitdata();");
            btnsave.Attributes.Add("OnClick","javascript:return savedata();");          
            }            
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    [Ajax.AjaxMethod]
    public DataSet submit(string compcode, string branch_code, string frmdt, string todt, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Cash_Recancilation submitt = new NewAdbooking.Classes.Cash_Recancilation();
            ds = submitt.submitdata(compcode, branch_code, frmdt, todt, extra1, extra2, extra3, extra4, extra5, extra6);
        }
        else
        {
            NewAdbooking.classesoracle.Cash_Recancilation submitt = new NewAdbooking.classesoracle.Cash_Recancilation();
            ds = submitt.submitdata(compcode, branch_code, frmdt, todt, extra1, extra2, extra3, extra4, extra5, extra6);

        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet savedata(string compcode, string branch_code, string doctype, string bkidnum, string recptno, string recptdt, string amount, string agmaincode, string agsubcode, string deposittype, string depositnum, string depositdate, string userid, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Cash_Recancilation save = new NewAdbooking.Classes.Cash_Recancilation();
            ds = save.savedata(compcode, branch_code, doctype, bkidnum, recptno,recptdt, amount, agmaincode, agsubcode, deposittype, depositnum, depositdate, userid, extra1, extra2, extra3, extra4, extra5, extra6, extra7);
        }
        else
        {
            NewAdbooking.classesoracle.Cash_Recancilation save = new NewAdbooking.classesoracle.Cash_Recancilation();
            ds = save.savedata(compcode, branch_code, doctype, bkidnum, recptno, recptdt, amount, agmaincode, agsubcode, deposittype, depositnum, depositdate, userid, extra1, extra2, extra3, extra4, extra5, extra6, extra7);

        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet count(string compcode, string deposite_type)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.Cash_Recancilation obj = new NewAdbooking.Classes.Cash_Recancilation();
            //ds = obj.count(compcode, deposite_type);
        }
        else
        {
            NewAdbooking.classesoracle.Cash_Recancilation obj = new NewAdbooking.classesoracle.Cash_Recancilation();
            ds = obj.count(compcode, deposite_type);

        }
        return ds;
    }
  
   
}