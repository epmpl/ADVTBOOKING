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

public partial class stoptime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }


        hiddencompcode.Value = Session["compcode"].ToString();      
        hiddenuserid.Value = Session["userid"].ToString();       
        hiddendateformat.Value = Session["dateformat"].ToString();
        hdnunit.Value = Session["center"].ToString();
        if (hiddendateformat.Value == "mm/dd/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;

        }
        else if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
        }
        else
        {
            HDN_server_date.Value = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
        }
       
        DataSet dk = new DataSet();
        dk.ReadXml(Server.MapPath("XML/stoptime.xml"));
        Ajax.Utility.RegisterTypeForAjax(typeof(stoptime));
        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();  ");
            btnCancel.Attributes.Add("OnClick", "javascript:return onload_clear();");
            btnSave.Attributes.Add("OnClick", "javascript:return itemsave();");
            btnModify.Attributes.Add("OnClick", "javascript:return modfiyclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executelick();");
            //btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            //btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            //btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            //btnprevious.Attributes.Add("OnClick", "javascript:return Previousclick();");
            //btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
        }
        DataSet objDataSetbu =new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        if (btnNew.Enabled == false)
            btnNew.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[11].ToString();
        btnNew.Focus();
    }

    [Ajax.AjaxMethod]
    public DataSet save_data(string compcode,string unitcode,string days,string hour,string createdby,string seq,string extra1,string extra2,string extra3,string extra4)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.stoptime checkform = new NewAdbooking.classesoracle.stoptime();
            ds = checkform.saveaddeduct(compcode, unitcode, days, hour, createdby, seq, extra1, extra2, extra3, extra4);
        }
        else
        {
            NewAdbooking.Classes.stoptime1 checkform = new NewAdbooking.Classes.stoptime1();
            ds = checkform.saveaddeduct(compcode, unitcode, days, hour, createdby,seq, extra1, extra2, extra3, extra4);

        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet autogen()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //    finance.classesoracle.fix_assest_sale taluka = new finance.classesoracle.fix_assest_sale();
            //    ds = taluka.saveaddeduct(compcode, unitcode, branchcode, locationcode, assetcode, captisalied, datecapti, quainity, assetvalue, assdate, type, uid, dateformat, createddate, FA_CAT_CD, FA_SUB_CD, FA_THIRD_CD, RATE_OF_DEP_CO, extra1, extra2, extra3, extra4, trans_no);
        }
        else
        {
            NewAdbooking.Classes.stoptime1 checkform = new NewAdbooking.Classes.stoptime1();
            ds = checkform.autoseq();

        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet save_exec(string compcode, string unitcode, string days, string hour, string createdby, string seq, string extra1, string extra2, string extra3, string extra4)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.stoptime checkform = new NewAdbooking.classesoracle.stoptime();
            ds = checkform.execdata(compcode, unitcode, days, hour, createdby, seq, extra1, extra2, extra3, extra4);
        }
        else
        {
            NewAdbooking.Classes.stoptime1 checkform = new NewAdbooking.Classes.stoptime1();
            ds = checkform.execdata(compcode, unitcode, days, hour, createdby, seq, extra1, extra2, extra3, extra4);

        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet data_modify(string compcode, string unitcode, string days, string hour, string createdby, string seq, string extra1, string extra2, string extra3, string extra4)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //    finance.classesoracle.fix_assest_sale taluka = new finance.classesoracle.fix_assest_sale();
            //    ds = taluka.saveaddeduct(compcode, unitcode, branchcode, locationcode, assetcode, captisalied, datecapti, quainity, assetvalue, assdate, type, uid, dateformat, createddate, FA_CAT_CD, FA_SUB_CD, FA_THIRD_CD, RATE_OF_DEP_CO, extra1, extra2, extra3, extra4, trans_no);
        }
        else
        {
            NewAdbooking.Classes.stoptime1 checkform = new NewAdbooking.Classes.stoptime1();
            ds = checkform.exec_modify(compcode, unitcode, days, hour, createdby, seq, extra1, extra2, extra3, extra4);

        }
        return ds;
    }

}
