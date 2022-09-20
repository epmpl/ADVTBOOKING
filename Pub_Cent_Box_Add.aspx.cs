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

public partial class Pub_Cent_Box_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
        }

        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Pub_Cent_Box_Add));

    //*********************************For Lables***************************
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Pub_Cent_Box_Add.xml"));
        lbpubcent.Text=ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbengboxad.Text=ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbhinboxadd.Text=ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbpunboxadd.Text=ds.Tables[0].Rows[0].ItemArray[3].ToString();

        //***********************************************************************//
        //*****************Code For Read the data from xml File******************//
        //*******************************For The Button**************************//
        //***********************************************************************//
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
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

        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = false;
        btnCancel.Enabled = true;
        btnfirst.Enabled = false;
        btnnext.Enabled = false;
        btnprevious.Enabled = false;
        btnlast.Enabled = false;
        btnExit.Enabled = true;
        drpuncent.Enabled = false;
        txtengboxadd.Enabled = false;
        txthinboxadd.Enabled = false;
        txtpunboxadd.Enabled = false;
        
        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return btnNewClick2();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return btnModifyClick2();");
            btnDelete.Attributes.Add("OnClick", "javascript:return btnDeleteClick2();");
            btnQuery.Attributes.Add("OnClick", "javascript:return btnQueryClick2();");
            btnExecute.Attributes.Add("OnClick", "javascript:return btnExecuteClick2();");
            btnCancel.Attributes.Add("OnClick", "javascript:return btnCancelClick2('Pub_Cent_Box_Add');");
            btnfirst.Attributes.Add("OnClick", "javascript:return pubcentfirstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return pubcentpreviousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return pubcentnextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return pubcatlastclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return pubcatexitclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return pubcatdeleteclick();");
             fillPubCenter();
        }
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
    private void fillPubCenter()
    {
        DataSet ds=new DataSet();
        drpuncent.Items.Clear();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.Pub_Cent_Box_Add bindpublication = new NewAdbooking.Classes.Pub_Cent_Box_Add();
                ds = bindpublication.getPubCenter();
            }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Pub_Cent_Box_Add bindpublication = new NewAdbooking.classesoracle.Pub_Cent_Box_Add();
                ds = bindpublication.getPubCenter();
            }
            //else
            //{
                //NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                //ds = logindetail.getPubCenter();
            //}

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drpuncent.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpuncent.Items.Add(li);
        }

    }
    [Ajax.AjaxMethod]
    public DataSet chkcenter(string compcode, string pubcent)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Pub_Cent_Box_Add chkcenter = new NewAdbooking.Classes.Pub_Cent_Box_Add();

            ds = chkcenter.pubcent(compcode, pubcent);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Pub_Cent_Box_Add chkcenter = new NewAdbooking.classesoracle.Pub_Cent_Box_Add();

                ds = chkcenter.pubcent(compcode, pubcent);

                return ds;

            }
            else
            {
                //NewAdbooking.classmysql.productmaster savecode = new NewAdbooking.classmysql.productmaster();

                //ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;
            }

    }
    [Ajax.AjaxMethod]
    public DataSet pubsave(string pubcent,string compcode,string userid,string engbox,string hinbox,string punbox) 
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Pub_Cent_Box_Add save = new NewAdbooking.Classes.Pub_Cent_Box_Add();

            ds = save.pubsave(pubcent, compcode, userid, engbox, hinbox, punbox);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Pub_Cent_Box_Add save = new NewAdbooking.classesoracle.Pub_Cent_Box_Add();

                ds = save.pubsave(pubcent, compcode, userid, engbox, hinbox, punbox);

                return ds;

            }
            else
            {
                //NewAdbooking.classmysql.productmaster savecode = new NewAdbooking.classmysql.productmaster();

                //ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;
            }

    }
    [Ajax.AjaxMethod]
    public DataSet update(string compcode, string pubcent, string engbox, string hinbox, string punbox)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Pub_Cent_Box_Add modify = new NewAdbooking.Classes.Pub_Cent_Box_Add();

            ds = modify.modifydata(compcode, pubcent, engbox, hinbox, punbox);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Pub_Cent_Box_Add modify = new NewAdbooking.classesoracle.Pub_Cent_Box_Add();

                ds = modify.modifydata(compcode, pubcent, engbox, hinbox, punbox);

                return ds;

            }
            else
            {
                //NewAdbooking.classmysql.productmaster savecode = new NewAdbooking.classmysql.productmaster();

                //ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;
            }

    }
    [Ajax.AjaxMethod]
    public DataSet pubcentexecute(string compcode, string pubcent)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Pub_Cent_Box_Add exec = new NewAdbooking.Classes.Pub_Cent_Box_Add();

            ds = exec.execpubbox(compcode, pubcent);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Pub_Cent_Box_Add exec = new NewAdbooking.classesoracle.Pub_Cent_Box_Add();

                ds = exec.execpubbox(compcode, pubcent);

                return ds;

            }
            else
            {
                //NewAdbooking.classmysql.productmaster savecode = new NewAdbooking.classmysql.productmaster();

                //ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;
            }

    }
    [Ajax.AjaxMethod]
    public DataSet pubcentdelete(string compcode, string pubcent)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Pub_Cent_Box_Add del = new NewAdbooking.Classes.Pub_Cent_Box_Add();

            ds = del.deletedata(compcode, pubcent);

            return ds;

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Pub_Cent_Box_Add del = new NewAdbooking.classesoracle.Pub_Cent_Box_Add();

                ds = del.deletedata(compcode, pubcent);

                return ds;

            }
            else
            {
                //NewAdbooking.classmysql.productmaster savecode = new NewAdbooking.classmysql.productmaster();

                //ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;
            }

    }
}
