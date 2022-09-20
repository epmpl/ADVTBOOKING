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

public partial class CaptionMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
           
        }

        else
        {

            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;

        }

        Ajax.Utility.RegisterTypeForAjax(typeof(CaptionMaster));
        //***********************************************************************//
        //*****************Code For Read the data from xml File******************//
        //*******************************For The Button**************************//
        //***********************************************************************/
        DataSet objDataSetbu = new DataSet();
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

        //********************************For Label****************************************/
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/CaptionMaster.xml"));

        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblcaption.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = false;
        btnCancel.Enabled = true;
        btnfirst.Enabled = false;
        btnprevious.Enabled = false;
        btnnext.Enabled = false;
        btnlast.Enabled = false;
        btnExit.Enabled = true;

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
        if (!Page.IsPostBack)
        {
            bindadvtype();
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('CaptionMaster');");
        }
    }

   
    //**********This is used to bind Ad Type name***************//
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster advname = new NewAdbooking.Classes.AdCategoryMaster();

            ds = advname.adname(hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster advname = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = advname.adname(hiddencompcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster advname = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = advname.adname(hiddencompcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Ad Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }
    }

    //[Ajax.AjaxMethod]
    //public DataSet chkname(string compcode, string pubname, string catname, string subcatname, string refname)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        //NewAdbooking.Classes.pubcatref chk = new NewAdbooking.Classes.pubcatref();
    //        //ds = chk.chkpubcatname(compcode, pubname, catname, subcatname, refname);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.pubcatref chk = new NewAdbooking.classesoracle.pubcatref();
    //        ds = chk.chkpubcatname(compcode, pubname, catname, subcatname, refname);

    //    }
    //    else
    //    {
    //        //NewAdbooking.classmysql.pubcatref chk = new NewAdbooking.classmysql.pubcatref();
    //        //ds = chk.chkpubcatname(compcode, pubname, catname, subcatname, refname);
    //    }
    //    return ds;
    //}
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void CAPTION_INS_UPD_DEL(string compcode, string padtype, string caption, string trxtype, string pcaptioncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pubcatref insert = new NewAdbooking.Classes.pubcatref();
            ds = insert.CAPTION_INS_UPD_DELF(compcode, padtype, caption, trxtype, Session["userid"].ToString(), pcaptioncode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pubcatref insert = new NewAdbooking.classesoracle.pubcatref();
            ds = insert.CAPTION_INS_UPD_DELF(compcode,padtype, caption, trxtype, Session["userid"].ToString(),pcaptioncode);

        }
    }
    
    [Ajax.AjaxMethod]
    public DataSet execute(string compcode, string adtype, string capcode, string capname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pubcatref exe = new NewAdbooking.Classes.pubcatref();
            ds = exe.capexecute(compcode, adtype, capcode, capname, "");

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pubcatref exe = new NewAdbooking.classesoracle.pubcatref();
            ds = exe.capexecute(compcode, adtype, capcode, capname, "");

        }
        return ds;
    }
   
}