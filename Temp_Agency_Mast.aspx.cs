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
using System.Net;
using System.Net.Mail;

public partial class Temp_Agency_Mast : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] != null)
        {
            hdncompcode.Value = Session["compcode"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
             hdnbrancd.Value = Session["revenue"].ToString();
            //hdnbrannm.Value = Session["revenuename"].ToString();
            hdnusernm.Value = Session["Username"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Temp_Agency_Mast));

        DataSet objDataSetbu = new DataSet();
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl     = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl    = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl  = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl   = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl  = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl   = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl    = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl    = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl  = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl    = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Temp_Agency_Mast.xml"));
        lblunitname.Text    = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbagcategory.Text   = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblagency.Text      = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblmail.Text        = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbladd.Text         = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblplace.Text       = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblgst.Text         = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblmob.Text         = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpincode.Text     = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblphone.Text       = ds.Tables[0].Rows[0].ItemArray[10].ToString();

        hdnunitcd.Value         = Request.QueryString["PrintRevCentCd"].ToString();
        hdnunitnm.Value         = Request.QueryString["PrintRevCentName"].ToString();
        hdnrefbookingid.Value   = Request.QueryString["refbookingid"].ToString();
        hdnrefflag.Value        = Request.QueryString["refflag"].ToString();
        if (!Page.IsPostBack)
        {
            addagent();
            addcit();
            btnNew.Attributes.Add("onclick", "javascript:return OnClickNew();");
            btnSave.Attributes.Add("onclick", "javascript:return OnClickSave();");
            btnModify.Attributes.Add("onclick", "javascript:return OnClickModify();");
            btnQuery.Attributes.Add("onclick", "javascript:return OnClickQuery();");
            btnExecute.Attributes.Add("onclick", "javascript:return OnClickExecute();");
            btnCancel.Attributes.Add("onclick", "javascript:return OnClickClear();");
            btnfirst.Attributes.Add("onclick", "javascript:return OnClickFirst();");
            btnprevious.Attributes.Add("onclick", "javascript:return OnClickPrevious();");
            btnnext.Attributes.Add("onclick", "javascript:return OnClickNext();");
            btnlast.Attributes.Add("onclick", "javascript:return OnClickLast();");
            btnDelete.Attributes.Add("onclick", "javascript:return OnClickDelete();");
            btnExit.Attributes.Add("onclick", "javascript:return OnClickExit();");
            
            txtmail.Attributes.Add("OnBlur", "javascript:return checkEmail();");
            
            /*drpagcategory.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtagency.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtmail.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtadd.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtplace.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtgst.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtmob.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");
            txtpincode.Attributes.Add("onfocus", "javascript:return changebackcolor(this);");*/
        }
    }
    public void addagent()
    {
        drpagcategory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master agent = new NewAdbooking.Classes.Master();


            ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master agent = new NewAdbooking.classesoracle.Master();


                ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());

            }
            else
            {
                //NewAdbooking.classmysql.Master agent = new NewAdbooking.classmysql.Master();
                //ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());
                
                string procedureName = "bindagencytype_bindagencytype_p";
                string[] parameterValueArray = { "" };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Agency Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpagcategory.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpagcategory.Items.Add(li);
            }

        }



    }

    public DataSet addcit()
    {
        txtplace.Items.Clear();

        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "clientfillcity";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "clientfillcity.clientfillcity_p";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "clientfillcity_clientfillcity_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select City-----";
        li1.Value = "0";
        li1.Selected = true;
        txtplace.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                txtplace.Items.Add(li);
            }
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet ad_temp_agency_save(string[] parameterValueArray)
    {
        DataSet ds = new DataSet();
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "ad_temp_agency_save";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "ad_temp_agency_save";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ad_temp_agency_save";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmis_run(string agencycode)
    {
        Session["TEMP_AGENCYRATECODE"] = agencycode;
    }




    [Ajax.AjaxMethod]
    public string mailfinalsaveagency(string compcode, string agcategoryname, string agency, string mail, string add,string place, string placename, string gst, string mob, string pincode, string PHONE, string userid, string tempagencycode, string unitname, string extra11, string extra12)
    {
        DataSet ds = new DataSet();
        string err = "";
        //string mat_spl_nm = "";
        string mailid = "sourabh.sharma@4cplus.com";
        string USEREMAIL = "";//"adsonline@newindianexpress.com";
        //string AGENCYEMAILID = "gm_fernandez@newindianexpress.com,kothandaraman@newindianexpress.com,b_manivannan@newindianexpress.com,vijayakumar.m@newindianexpress.com,mallik@newindianexpress.com,sourabh.sharma@4cplus.com";
        DataSet ds12 = new DataSet();
        try
        {

            string[] parameterValueArray = new string[] { compcode, userid, unitname, place, "", "", "" };
            string procedureName = "bind_tempnew_agency_data";
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CommonClass sms = new NewAdbooking.classesoracle.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.CommonClass sms = new NewAdbooking.Classes.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds12 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            //bind_tempnew_agency_data
            USEREMAIL =  ds12.Tables[0].Rows[0]["user_email_id"].ToString();
            string AGENCYEMAILID =  ds12.Tables[1].Rows[0]["sender_mail"].ToString();
            string centername = ds12.Tables[2].Rows[0]["pub_cent_name"].ToString();

            // string centername = ds12.Tables[2].Rows[0]["pub_cent_name"].ToString();
            string dist_name = ds12.Tables[3].Rows[0]["dist_name"].ToString();
            string state_name = ds12.Tables[3].Rows[0]["state_name"].ToString();

            {
                DataSet objdat1 = new DataSet();
                // Read in the XML file
                string datapath = (Server.MapPath("XML/dealmailbody.xml")).Replace("ajax\\", "");
                //  datapath.Replace("ajax\\","");
                objdat1.ReadXml(datapath);
                //string mailtoval = mailid + "," + USEREMAIL;
                string mailtoval = USEREMAIL;
                if (mailtoval == "")
                {
                    mailtoval = "4cplusadbooking@newindianexpress.com";
                }
                string mailbody = "Please arrange to allot new agency code with the following details:- " + "\n\n" + "Name of the Revenue Centre/Region:- " + centername + "\n" + "Agency Category:- " + agcategoryname + "\n" + "Agency Name:- " + agency + "\n" + "Agency Address:- " + add + "\n" + "City:-" + placename + "\n" + "Dist:-" + dist_name + "\n" + "State:-" + state_name + "\n" + "Pincode:-" + pincode + "\n" + "E-mail Address:-" + mail + "\n" + "Mobile Number:-" + mob + "\n" + "Phone Number:-" + PHONE + "\n" + "GST Number:-" + gst + "\n" + "Temporary code Number:-" + tempagencycode + "\n";
                string t_mailbody = "";

                string smtpadd = objdat1.Tables[0].Rows[0].ItemArray[32].ToString();
                string mailfromval = objdat1.Tables[0].Rows[0].ItemArray[31].ToString();
                string mailstr = objdat1.Tables[0].Rows[0].ItemArray[33].ToString();
                string attachurl = objdat1.Tables[0].Rows[0].ItemArray[34].ToString();
                string insert_mat_attachurl = objdat1.Tables[0].Rows[0].ItemArray[35].ToString();

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 25;
                smtp.Host = "203.197.142.35";
                smtp.Credentials = new NetworkCredential("adsonline", "advtupload");
                MailMessage email_msg = new MailMessage();

                MailMessage t_email_msg = new MailMessage();
                if (AGENCYEMAILID != "")
                {
                    email_msg.To.Add(mailtoval + "," + AGENCYEMAILID + "," + "sourabh.sharma@4cplus.com");//("karthick@newindianexpress.com,swamy@newindianexpress.com");
                }
                else
                {
                    email_msg.To.Add(mailtoval + "," + "sourabh.sharma@4cplus.com");
                }
                //string t_fmailid = "bhattijs18@gmail.com" + "," + "sourabhsharma0701@gmail.com" + "," + USEREMAIL;
                string t_fmailid = USEREMAIL;
                string t_agency = "t";
                if (t_agency != "")
                {
                    t_email_msg.To.Add(t_fmailid);
                    t_email_msg.From = new MailAddress(USEREMAIL);
                    t_email_msg.Subject = "Request to allot a new agency";
                    t_email_msg.Body = t_mailbody;
                    t_email_msg.IsBodyHtml = false;

                }
                email_msg.From = new MailAddress(USEREMAIL);
                email_msg.Subject = "Request to allot a new agency";
                
                email_msg.Body = mailbody;

                email_msg.IsBodyHtml = false;
                smtp.Send(email_msg);
                /*if (t_agency != "")
                {
                    smtp.Send(t_email_msg);
                }*/
                //}
            }
        }
        catch (Exception e)
        {
            err = e.Message;

        }

        return err;
    }






}