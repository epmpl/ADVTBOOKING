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
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;
using System.IO;
using CuteWebUI;
using System.Net;

public partial class classified_fields : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    NewAdbooking.classified.classified_sql objsql = new NewAdbooking.classified.classified_sql();
    NewAdbooking.classified.classified_mysql objmysql = new NewAdbooking.classified.classified_mysql();
    NewAdbooking.classified.classified_oracle objoracle = new NewAdbooking.classified.classified_oracle();
    string Getid = "";
    string Getddlval = "";
    string cntryCode = "IN0";//ConfigurationSettings.AppSettings["cntryCode"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnsubmit.Enabled = false; 
        if (Request.QueryString["compCode"] != null && Request.QueryString["catid"] != null && Request.QueryString["scatid"] != null && Request.QueryString["adid"] != null && Request.QueryString["adPremium"] != null)
        {
            btnsubmit.Enabled = true;
            string cCode = Request.QueryString["compCode"];
            if (!IsPostBack)
            {
                string mainCat = Request.QueryString["catid"], sCat = Request.QueryString["scatid"];
                string adExid = Request.QueryString["adid"];
                DataSet ds1 = new DataSet();
                if (sCat == "" || sCat == "0")
                {
                    sCat = "";
                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    ds = objsql.getMappingCatCode(mainCat, sCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mainCat = ds.Tables[0].Rows[0][0].ToString();
                    }
                    ds = objsql.getMappingCatCode(Request.QueryString["catid"], "");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hidcat.Value = ds.Tables[0].Rows[0][0].ToString();
                    }
                    ds = objsql.getMappingCatCode(Request.QueryString["catid"], sCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hidscat.Value = ds.Tables[0].Rows[0][0].ToString();
                    }
                    ds = objsql.getLocation(cCode, "st", cntryCode);
                    ds1 = objsql.getAdbasicDetail(adExid);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    ds = objoracle.getMappingCatCode(mainCat, sCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mainCat = ds.Tables[0].Rows[0][0].ToString();
                    }
                    ds = objoracle.getLocation(cCode, "st", cntryCode);
                    ds1 = objoracle.getAdbasicDetail(adExid);
                }
                else
                {
                    ds = objmysql.getMappingCatCode(mainCat, sCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mainCat = ds.Tables[0].Rows[0][0].ToString();
                    }
                    ds = objmysql.getLocation(cCode, "st", cntryCode);
                    ds1 = objmysql.getAdbasicDetail(adExid);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    common.FillDropDown(ref ddlloc, ds, ds.Tables[0].Columns[1].ColumnName, ds.Tables[0].Columns[0].ColumnName, "---Select State---", true);
                }
                ds.Dispose();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    tblimg.Style.Add("display", "none");
                    btnsubmit.Text = "Modify Ad Record";
                    txttitle.Text = ds1.Tables[0].Rows[0]["ad_title"].ToString();
                    string lcid = ds1.Tables[0].Rows[0]["loc_id"].ToString();
                    string adid = ds1.Tables[0].Rows[0]["ad_id"].ToString();
                    hidid.Value = adid;
                    string pid = "";
                    try
                    {
                        ddlloc.ClearSelection();
                        ddlloc.Items.FindByValue(lcid).Selected = true;
                    }
                    catch (Exception ex)
                    {
                        ddlcity.ClearSelection();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            pid = objsql.getParentLoc(lcid);
                            ds = objsql.getLocation(cCode, "ct", pid);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            pid = objoracle.getParentLoc(lcid);
                            ds = objoracle.getLocation(cCode, "ct", pid);
                        }
                        else
                        {
                            pid = objmysql.getParentLoc(lcid);
                            ds = objmysql.getLocation(cCode, "ct", pid);
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            common.FillDropDown(ref ddlcity, ds, ds.Tables[0].Columns[1].ColumnName, ds.Tables[0].Columns[0].ColumnName, "---Select State---", true);
                        }
                        ds.Dispose();
                        ddlloc.ClearSelection();
                        ddlloc.Items.FindByValue(pid).Selected = true;
                        ddlcity.Items.FindByValue(lcid).Selected = true;
                    }
                }
                ds1.Dispose();
                bindForm(mainCat);
            }
        }
        else
        {
            bindForm("CL0");
        }

    }
    void bindForm(string ctCd)
    {
        DataSet ds = new DataSet();
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = objsql.getFields(ctCd);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ds = objoracle.getFields(ctCd);
        }
        else
        {
            ds = objmysql.getFields(ctCd);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            frmvw.DataSource = ds;
            frmvw.DataBind();
        }
        else
        {
            frmvw.DataSource = null;
            frmvw.DataBind();
        }
        ds.Dispose();
    }

    protected void frmvw_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataSet ds = (DataSet)frmvw.DataSource;
            if (ds != null)
            {
                string fType = ds.Tables[0].Rows[e.Item.ItemIndex]["fld_type"].ToString();
                string fLen = ds.Tables[0].Rows[e.Item.ItemIndex]["fld_len"].ToString();
                TextBox txtCntrl = (TextBox)e.Item.FindControl("txtfld");
                txtCntrl.MaxLength = int.Parse(fLen);
                Label lblidd = (Label)e.Item.FindControl("lblid");
                if (fType == "N")
                {
                    txtCntrl.Attributes.Add("onkeypress", "javascript:return ClientisNumber(event);");
                }
                else if (fType == "L")
                {
                    txtCntrl.Attributes.Add("onkeypress", "javascript:return charValidate();");
                }
                DataSet dsfld = new DataSet();
                string fldval = "";
                if (hidid.Value != "")
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        dsfld = objsql.getFieldDetail(hidid.Value, lblidd.Text);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        dsfld = objoracle.getFieldDetail(hidid.Value, lblidd.Text);
                    }
                    else
                    {
                        dsfld = objmysql.getFieldDetail(hidid.Value, lblidd.Text);
                    }
                    if (dsfld.Tables[0].Rows.Count > 0)
                    {
                        fldval = dsfld.Tables[0].Rows[0]["fld_value"].ToString();
                    }
                }               
                
                if (fType == "N" || fType == "L" || fType == "T" || fType == "D")
                {
                    if (dsfld.Tables.Count >0 && dsfld.Tables[0].Rows.Count > 0)
                    {
                        txtCntrl.Text = fldval;
                    }
                }
                else if (fType == "C" || fType == "R" || fType == "S")
                {
                    DataSet dsopt = null;
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        dsopt = objsql.getFieldOption(lblidd.Text);
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        dsopt = objoracle.getFieldOption(lblidd.Text);
                    }
                    else
                    {
                        dsopt = objmysql.getFieldOption(lblidd.Text);
                    }
                    if (fType == "R")
                    {
                        RadioButtonList rdoOpt = (RadioButtonList)e.Item.FindControl("rdoList");
                        if (dsopt.Tables[0].Rows.Count > 0)
                        {
                            common.FillRadioList(ref rdoOpt, dsopt, "opt_name", "auto_id");
                            rdoOpt.Visible = true;
                            if (dsfld.Tables.Count > 0 && dsfld.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsfld.Tables[0].Rows.Count; i++)
                                {
                                    fldval = dsfld.Tables[0].Rows[i]["fld_value"].ToString();
                                    rdoOpt.Items.FindByValue(fldval).Selected = true;
                                }
                            }
                        }
                        else
                        {
                            rdoOpt.Visible = false;
                        }
                    }
                    else if (fType == "S")
                    {
                        DropDownList drpOpt = (DropDownList)e.Item.FindControl("drpList");
                        if (dsopt.Tables[0].Rows.Count > 0)
                        {
                            common.FillDropDown(ref drpOpt, dsopt, "opt_name", "auto_id", "---Select---", true);
                            drpOpt.Visible = true;
                            if (dsfld.Tables.Count > 0 && dsfld.Tables[0].Rows.Count > 0)
                            {
                                drpOpt.Items.FindByValue(fldval).Selected = true;
                            }
                        }
                        else
                        {
                            drpOpt.Visible = false;
                        }
                    }
                    else
                    {
                        CheckBoxList chkopt = (CheckBoxList)e.Item.FindControl("chkList");
                        if (dsopt.Tables[0].Rows.Count > 0)
                        {
                            common.FillCheckBoxList(ref chkopt, dsopt, "opt_name", "auto_id");
                            chkopt.Visible = true;
                            if (dsfld.Tables.Count > 0 && dsfld.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsfld.Tables[0].Rows.Count; i++)
                                {
                                    fldval = dsfld.Tables[0].Rows[i]["fld_value"].ToString();
                                    chkopt.Items.FindByValue(fldval).Selected = true;
                                }
                            }
                        }
                        else
                        {
                            chkopt.Visible = false;
                        }
                    }
                    dsopt.Dispose();
                    txtCntrl.Visible = false;
                }
                else if (fType == "D")
                {
                    HtmlImage imgcal = new HtmlImage();
                    imgcal.Src = "images/cal.jpg";
                    imgcal.Attributes.Add("onclick", "popUpCalendar(this,form1." + txtCntrl.ClientID + ", \"mm/dd/yyyy\");");
                    e.Item.Controls.AddAt(e.Item.Controls.IndexOf(txtCntrl) + 1, imgcal);
                }
            }
            ds.Dispose();
        }
    }
    protected void ddlloc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlloc.SelectedValue != "0")
        {
            string cCode = Request.QueryString["compCode"];
            DataSet ds = null;
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                ds = objsql.getLocation(cCode, "ct", ddlloc.SelectedValue);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                ds = objoracle.getLocation(cCode, "ct", ddlloc.SelectedValue);
            }
            else
            {
                ds = objmysql.getLocation(cCode, "ct", ddlloc.SelectedValue);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                common.FillDropDown(ref ddlcity, ds, ds.Tables[0].Columns[1].ColumnName, ds.Tables[0].Columns[0].ColumnName, "---Select City---", true);
            }
            ds.Dispose();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (ddlloc.SelectedValue == "0" || ddlloc.SelectedValue == ""|| txttitle.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(classified_fields), "aas", "alert('Please Fill Ad Location/Title!');", true);
        }
        else
        {
            try
            {
                string strLoc = ddlloc.SelectedValue;
                if (ddlcity.SelectedValue != "" && ddlcity.SelectedValue != "0")
                {
                    strLoc = ddlcity.SelectedValue;
                }
                string strCat = hidcat.Value;
                string strScat = hidscat.Value;
                string strSscat = "0";
                string strTitle = txttitle.Text.Trim();
                string strDesc = "";
                string strEmail = "";
                string strPhn = "0";
                string strFeature = "F";
                int ad_uid = 1; //Fix for online
                int strprc = 0;
                string strHot = "F";
                string strHome = "F";
                string strUrg = "F";
                string mapURl = "";
                string adtype = Request.QueryString["adPremium"];
                
                int maxAdid = 0; String virtualFileName = "", extendId= Request.QueryString["adid"];
                //--- Upload Image
                if (Attachments1.Items.Count != 0)
                {
                    string fileName = "";
                    foreach (AttachmentItem item in Attachments1.Items)
                    {
                        //Upload file to a FTP location.
                        fileName = "WEB-" + Path.GetRandomFileName() + "." + Path.GetExtension(item.FileName);
                        virtualFileName += "|" + fileName;
                        fileName = Server.MapPath(Attachments1.TempDirectory + "/" + fileName);
                        item.CopyTo(fileName);
                        uploadImageFiles(fileName);
                        File.Delete(fileName);
                    }
                    virtualFileName = virtualFileName.Substring(1);
                    Attachments1.DeleteAllAttachments();
                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    maxAdid = objsql.update_extended(extendId, strLoc, strCat, strScat, adtype, strTitle, hidid.Value);
                    if (maxAdid == 0)
                    {
                        maxAdid = objsql.maxid_online();
                        objsql.insertOnlineAdv(maxAdid, strLoc, strCat, strScat, strSscat, strTitle, strDesc, virtualFileName, strEmail, strPhn,
                            strFeature, ad_uid, strUrg, strHot, strHome, adtype, strprc.ToString(), mapURl, "0", "", IpAddress(),DateTime.Now.AddMonths(1).ToShortDateString());
                        objsql.extend_online(maxAdid.ToString(), extendId);
                    }
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    maxAdid = objoracle.update_extended(extendId, strLoc, strCat, strScat, adtype, strTitle, hidid.Value);
                    if (maxAdid == 0)
                    {
                        maxAdid = objoracle.maxid_online();
                        objoracle.insertOnlineAdv(maxAdid, strLoc, strCat, strScat, strSscat, strTitle, strDesc, virtualFileName, strEmail, strPhn,
                            strFeature, ad_uid, strUrg, strHot, strHome, adtype, strprc.ToString(), mapURl, "0", "", IpAddress(), DateTime.Now.AddMonths(1).ToShortDateString());
                        objoracle.extend_online(maxAdid.ToString(), extendId);
                    }
                }
                else
                {
                    maxAdid = objmysql.update_extended(extendId, strLoc, strCat, strScat, adtype, strTitle, hidid.Value);
                    if (maxAdid == 0)
                    {
                        maxAdid = objmysql.maxid_online();
                        objmysql.insertOnlineAdv(maxAdid, strLoc, strCat, strScat, strSscat, strTitle, strDesc, virtualFileName, strEmail, strPhn,
                            strFeature, ad_uid, strUrg, strHot, strHome, adtype, strprc.ToString(), mapURl, "0", "", IpAddress(), DateTime.Now.AddMonths(1).ToShortDateString());
                        objmysql.extend_online(maxAdid.ToString(), extendId);
                    }
                }                
                if (frmvw.Items.Count > 0)
                {
                    if (hidid.Value != "")
                    {
                        maxAdid = int.Parse(hidid.Value);
                    }
                    for (int j = 0; j < frmvw.Items.Count; j++)
                    {
                        Label lblidd = (Label)frmvw.Items[j].FindControl("lblid");
                        string fldid = lblidd.Text;
                        TextBox txtCntrl = (TextBox)frmvw.Items[j].FindControl("txtfld");
                        DropDownList drpopt = (DropDownList)frmvw.Items[j].FindControl("drpList");
                        RadioButtonList rdoopt = (RadioButtonList)frmvw.Items[j].FindControl("rdoList");
                        CheckBoxList chkopt = (CheckBoxList)frmvw.Items[j].FindControl("chkList");
                        string fldval = "";
                        if (txtCntrl.Visible == true)
                        {
                            fldval = txtCntrl.Text.Trim();
                            if (fldval.Trim() != "" && fldval.Trim() != "0")
                            {
                                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                {
                                    objsql.insertChildField(maxAdid, fldval, fldid);
                                }
                                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                                {
                                    objoracle.insertChildField(maxAdid, fldval, fldid);
                                }
                                else
                                {
                                    objmysql.insertChildField(maxAdid, fldval, fldid);
                                }
                            }
                        }
                        else if (drpopt.Visible == true)
                        {
                            fldval = drpopt.SelectedValue;
                            if (fldval.Trim() != "" && fldval.Trim() != "0")
                            {
                                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                {
                                    objsql.insertChildField(maxAdid, fldval, fldid);
                                }
                                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                                {
                                    objoracle.insertChildField(maxAdid, fldval, fldid);
                                }
                                else
                                {
                                    objmysql.insertChildField(maxAdid, fldval, fldid);
                                }
                            }
                        }
                        else if (rdoopt.Visible == true)
                        {
                            foreach (ListItem item in rdoopt.Items)
                            {
                                if (item.Selected)
                                {
                                    fldval = item.Value;
                                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                    {
                                        objsql.insertChildField(maxAdid, fldval, fldid);
                                    }
                                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                                    {
                                        objoracle.insertChildField(maxAdid, fldval, fldid);
                                    }
                                    else
                                    {
                                        objmysql.insertChildField(maxAdid, fldval, fldid);
                                    }
                                }
                            }
                        }
                        else if (chkopt.Visible == true)
                        {
                            foreach (ListItem item in chkopt.Items)
                            {
                                if (item.Selected)
                                {
                                    fldval = item.Value;
                                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                    {
                                        objsql.insertChildField(maxAdid, fldval, fldid);
                                    }
                                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                                    {
                                        objoracle.insertChildField(maxAdid, fldval, fldid);
                                    }
                                    else
                                    {
                                        objmysql.insertChildField(maxAdid, fldval, fldid);
                                    }
                                }
                            }
                        }

                    }
                }
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_fields), "ps", "alert('Ad Submitted Successfully!');window.close();", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(classified_fields), "er", "alert(\"" + ex.Message.ToString() + "\");", true);
            }
        }
    }
    void uploadImageFiles(string filePath)
    {
        string ftpAddr = ConfigurationManager.AppSettings["ftpPath"].ToString();
        string ftpUname = ConfigurationManager.AppSettings["ftpUser"].ToString();
        string ftpPwd = ConfigurationManager.AppSettings["ftpPwd"].ToString();

        //Load the file
        FileStream stream = File.OpenRead(filePath);
        byte[] buffer = new byte[stream.Length];

        stream.Read(buffer, 0, buffer.Length);
        stream.Close();

        ServiceUpload.Service oo = new ServiceUpload.Service();
        string ttt = oo.uploadFile(ftpAddr, filePath, ftpUname, ftpPwd, buffer);
    }
    public string IpAddress()
    {
        string strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
        {
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        //Response.Write("<script>alert('" + strIpAddress + "')</script>");
        return strIpAddress;
    }
}
