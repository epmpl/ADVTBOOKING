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
using System.Web.Mail;
//using System.Net.Mail;
//using System.Net;
public partial class AuthorizationRelease : System.Web.UI.Page
{
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        //DataGrid1.Visible = true;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        //ip1.Value = Request.ServerVariables["REMOTE_ADDR"];
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenDateFormat.Value = Session["DateFormat"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        Hiddencentercode.Value= Session["center"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(AuthorizationRelease));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/AuthorizationRelease.xml"));
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblexec.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[51].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[52].ToString();
        lbltilldate.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();

        lblagency1.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblagreedrate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblclient1.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblagreedamount.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblpaymode.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpublichdate.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();

        lbldiscount.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblrono.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblnoofinsertion.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblpositionpremium.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblrostatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lblpaid.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblspecialdiscount.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lblexecutivename.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lblcontractname.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lblspacediscount.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lbloutstanding.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblheight.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lblspecialcharge.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblretainername.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lbllines.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbladdagecomm.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        lblbookingtype.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lblpageposition.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lblgrossamt.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        lblcolourtype.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lblpositionpre1.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lblretainercommission.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbladcategory.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lblarea.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lblagtradediscount.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbladsubcat1.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lblschemetype.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lblbillamount.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbladsubcat2.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        lblratecode.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
        lbladsubcat3.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lblcardrate.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbladsubcat4.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lblcardamount.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        //Label6.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
        lblbillrecamt.Text = ds.Tables[0].Rows[0].ItemArray[48].ToString();
        lblbillbalamt.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        lblaudit.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();
        lblapr.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        lbrej.Text = ds.Tables[0].Rows[0].ItemArray[55].ToString();
        lblcioid.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
        hdnbranch.Value = ds.Tables[1].Rows[0].ItemArray[0].ToString();
        txtagency1.Focus();

        if (!IsPostBack)
        {
            btnsave1.Attributes.Add("OnClick", "javascript:return savecomment();");
            btnmail.Attributes.Add("OnClick", "javascript:return sendmail();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return mandat();");
            btnExit.Attributes.Add("OnClick", "javascript:return catexitclick1();");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
            lstclient.Attributes.Add("onclick", "javascript:return insertagency();");
            lstexec.Attributes.Add("onclick", "javascript:return insertagency();");
            txtvalidityfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttilldate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            btnautomail.Attributes.Add("OnClick", "javascript:return automail();");
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
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            }
            else
            {
                ds = bindagenname.bindagency(compcode, userid, agency, "0");
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
    public DataSet bindExec(string compcode, string execname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getExec(compcode, execname, "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }
        }
        return ds;



    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (Session["FILTER"].ToString() == "D")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, Session["revenue"].ToString());
            }
            else
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, "0");
            }
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fetchamt(string bookingid, string compcode)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.rofileform executebullet = new NewAdbooking.Classes.rofileform();
            ds = executebullet.fetchamt(bookingid, compcode);
        }
        else
        {
            NewAdbooking.classesoracle.rofileform executebullet = new NewAdbooking.classesoracle.rofileform();
            ds = executebullet.fetchamt(bookingid, compcode);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet execute(string bookingid, string compcode, string adtype, string dateformat)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 executebullet = new NewAdbooking.Classes.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
            return ds;
        }
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 executebullet = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
            return ds;
        }
    }
    //[Ajax.AjaxMethod]
    //public void savecomment(string remarks,string userid,string appstatus,string insertid,string cioid)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.AuthorizationRelease savecomment = new NewAdbooking.Classes.AuthorizationRelease();
    //        ds = savecomment.savedata(remarks, userid, appstatus, insertid, cioid);
    //    }
    //    else
    //    {
    //        NewAdbooking.classesoracle.AuthorizationRelease savecomment = new NewAdbooking.classesoracle.AuthorizationRelease();
    //        ds = savecomment.savedata(remarks, userid, appstatus, insertid, cioid);
    //    }
    //}
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        refreshfeild();
        DataSet ds = new DataSet();
        string agency = "";
        string executive = "";
        string client = "";
        string fdate = txtvalidityfrom.Text;
        string tdate = txttilldate.Text;
        string cioid = txtcioid.Text;
        string flag = drpstatus.SelectedValue;
        string orderby = drpoderby.SelectedValue;
        rbapr.Checked = false;
        rbrej.Checked = false;

        if (txtagency1.Text != "" && txtagency1.Text.LastIndexOf("(")>=0)
        {
            agency = txtagency1.Text.Substring(txtagency1.Text.LastIndexOf("(") + 1, txtagency1.Text.Length - txtagency1.Text.LastIndexOf("(") - 2);
           
        }
        if (txtexecname.Text != "" && txtexecname.Text.LastIndexOf("(") >= 0)
        {
            executive = txtexecname.Text.Substring(txtexecname.Text.LastIndexOf("(") + 1, txtexecname.Text.Length - txtexecname.Text.LastIndexOf("(") - 2);

        }
        if (txtclient1.Text != "" && txtclient1.Text.LastIndexOf("(") >= 0)
        {
            client = txtclient1.Text.Substring(txtclient1.Text.LastIndexOf("(") + 1, txtclient1.Text.Length - txtclient1.Text.LastIndexOf("(") - 2);

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AuthorizationRelease frec = new NewAdbooking.Classes.AuthorizationRelease();
            ds = frec.findrecord(hiddenuserid.Value, hiddencompcode.Value, agency, executive, client, fdate, tdate, hiddenDateFormat.Value, cioid, flag, drpbasedon.SelectedValue, hdnbranch.Value, orderby);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AuthorizationRelease frec = new NewAdbooking.classesoracle.AuthorizationRelease();
            ds = frec.findrecord(hiddenuserid.Value, hiddencompcode.Value, agency, executive, client, fdate, tdate, hiddenDateFormat.Value, cioid, flag, drpbasedon.SelectedValue, hdnbranch.Value, orderby);
           
        }

        else
        {
            //NewAdbooking.classmysql.AuthorizationRelease clsbooking = new NewAdbooking.classmysql.AuthorizationRelease();
            //ds = clsbooking.getClientName(compcode, client);
        }
        //refreshfeild();

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(AuthorizationRelease), "aa", "alert1();", true);


        }

        Session["RowLen"] = ds.Tables[0].Rows.Count;
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }
    protected void refreshfeild()
    {
        txtremarks.Text = "";
        txtagency.Text = "";
        txtuom.Text = "";
        txtwidth.Text = "";
        txtagreedrate.Text = "";
        txtclient.Text = "";
        txtpackage.Text = "";
        txtagreedamount.Text = "";
        txtpaymode.Text = "";
        txtpublishdate.Text = "";
        txtdiscount.Text = "";
        txtrono.Text = "";
        txtnoofinsertion.Text = "";
        txtpositionpremium.Text = "";
        txtrostatus.Text = "";
        txtspecialdiscount.Text = "";
        txtexecutivename.Text = "";
        txtcontractname.Text = "";
        txtspacediscount.Text = "";
        txtoutstanding.Text = "";
        txtheight.Text = "";
        txtspecialcharge.Text = "";
        txtretainername.Text = "";
        txtlines.Text = "";
        txtaddagecomm.Text = "";
        txtbookingtype.Text = "";
        txtpageposition.Text = "";
        txtgrossamt.Text = "";
        txtcolourtype.Text = "";
        TextBox1.Text = "";
        txtretainercommission.Text = "";
        txtadcategory.Text = "";
        txtarea.Text = "";
        txtagtradediscount.Text = "";
        txtadsubcat1.Text = "";
        txtschemetype.Text = "";
        txtbillamount.Text = "";
        txtadsubcat2.Text = "";
        txtratecode.Text = "";
        txtbillrecamt.Text = "";
        txtadsubcat3.Text = "";
        txtcardrate.Text = "";
        txtbillbalamt.Text = "";
        txtadsubcat4.Text = "";
        txtcardamount.Text = "";
        txtremarks.Text ="";
        txtpaid.Text = "";
        rbapr.Checked=true;

    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        hidattach1.Value = "";
        hiddenrowcount.Value = Session["RowLen"].ToString();
        if (e.Item.ItemType != ListItemType.Header)
        {
            //if (e.Item.Cells[14].Text != "Y" && e.Item.Cells[14].Text != "N")
            //{
            string str = "DataGrid1__CheckBox1" + i;
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectrow('" + str + "','" + e.Item.Cells[15].Text + "');\" value=" + e.Item.Cells[1].Text + "  />";
            e.Item.Cells[1].Text = "<a style=\"cursor:hand;color:blue\" id='cio" + i + "' onClick=\"openbooking1('" + e.Item.Cells[1].Text + "','cio" + i + "','" + hiddenrowcount.Value + "','" + e.Item.Cells[3].Text + "','" + e.Item.Cells[15].Text + "'  )\"value=" + e.Item.Cells[1].Text + ">" + e.Item.Cells[1].Text + "</a>";
            //e.Item.Cells[24].Text = "<a id='cio" + i + "' style=\"cursor:hand;color:blue\" onClick=\"openattach1('" + e.Item.Cells[24].Text + "')\">" + e.Item.Cells[24].Text + "</a>";
            //  ==========************ To Showing Attatchment on Name click *********====================//
            string attatch = e.Item.Cells[24].Text;
            if (attatch != "" && attatch != "&nbsp;")
            {
                string[] attatchstr = attatch.Split(',');
                for (int a1 = 0; a1 < attatchstr.Length; a1++)
                {
                    if (hidattach1.Value == "")
                        hidattach1.Value = "<a style=\"cursor:Pointer;color:blue\" onClick=\"openattach1('" + attatchstr[a1].ToString() + "')\">" + attatchstr[a1].ToString() + "</a>";
                    else
                        hidattach1.Value = hidattach1.Value+"," + "<a style=\"cursor:Pointer;color:blue\" onClick=\"openattach1('" + attatchstr[a1].ToString() + "')\">" + attatchstr[a1].ToString() + "</a>";
                }
                e.Item.Cells[24].Text = hidattach1.Value;
            }
            //=======================*************************=========================================//
            //}
            i = i + 1;
        }
        else
        {
            string str = "DataGrid1__CheckBox_Header";
            e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return Selectrow('" + str + "','" + e.Item.Cells[15].Text + "');\" value='DataGrid1__CheckBox_Header'  />";
        }
    }
    protected void btnsave1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string appstatus = "";
        string insertid = "";
        string[] countbookid1 = hiddenbookingid.Value.Split(',');
        int c4 = countbookid1.Length;
        for (int k11 = 0; k11 < c4; k11++)
        {

            if (rbapr.Checked == true)
            {
                appstatus = "Y";
            }
            else
            {
                appstatus = "N";
            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.AuthorizationRelease savecomment = new NewAdbooking.Classes.AuthorizationRelease();
                ds = savecomment.savedata(txtremarks.Text, hiddenuserid.Value, appstatus, insertid, countbookid1[k11]);
            }
            else
            {
                NewAdbooking.classesoracle.AuthorizationRelease savecomment = new NewAdbooking.classesoracle.AuthorizationRelease();
                ds = savecomment.savedata(txtremarks.Text, hiddenuserid.Value, appstatus, insertid, countbookid1[k11]);
            }
            //==========**************Read mail info From Excel****************============================//
            DataSet dsxml = new DataSet();
            dsxml.ReadXml(Server.MapPath("XML/AuthorizationRelease_mail.xml"));

//===========************** Code to send mail for Executive or Retainer *********==============//
            if (dsxml.Tables[0].Rows[0].ItemArray[5].ToString() == "Y" || appstatus == "N")
            {
                DataSet ds1 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.Classes.AuthorizationRelease getid = new NewAdbooking.Classes.AuthorizationRelease();
                    ds1 = getid.fetchMailId(hiddenbookingid.Value);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.AuthorizationRelease getid = new NewAdbooking.classesoracle.AuthorizationRelease();
                    ds1 = getid.fetchMailId(hiddenbookingid.Value);
                }
               string mailid = "";
                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    mailid = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
               }
               

                string tabmail = "";
                tabmail = tabmail + "<table>";
                tabmail = tabmail + "<tr><td align='left' style='font-family:verdana;font-size:12'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
                if(appstatus == "N")
                    tabmail = tabmail + "<tr><td align='left' style='font-family:verdana;font-size:12'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
                else
                    tabmail = tabmail + "<tr><td align='left' style='font-family:verdana;font-size:12'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
                tabmail = tabmail + "<tr><td align='left' style='font-family:verdana;font-size:12'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
                tabmail = tabmail + "<tr><td align='left' style='font-family:verdana;font-size:12'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
                tabmail = tabmail + "</table>";

                //try
                //{

                    MailMessage msgMail = new MailMessage();
                    msgMail.To = mailid;
                    if (dsxml.Tables[0].Rows[0].ItemArray[1].ToString() != "")
                        //msgMail.Cc = dsxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    msgMail.From = dsxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    msgMail.BodyFormat = MailFormat.Html;
                    //	msgMail.Bcc="susmita.d@creativebpo.com";
                    if (appstatus == "N")
                        msgMail.Subject = dsxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    else
                        msgMail.Subject = dsxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    msgMail.Body = tabmail;
                    SmtpMail.SmtpServer = dsxml.Tables[0].Rows[0].ItemArray[4].ToString();
                if(mailid!="")
                    SmtpMail.Send(msgMail);

                //}
                //catch (Exception ex)
                //{
                //    mailmsg = ex.Message;
                //    Response.Write("<script>alert('" + mailmsg + "');</script>");
                //    return;
                //}

               // MailMessage msgMail = new MailMessage();
               // msgMail.To.Add("kuldeepbhati93@gmail.com");//mailid
               //// msgMail.Cc = dsxml.Tables[0].Rows[0].ItemArray[1].ToString();
               // msgMail.From =new MailAddress(dsxml.Tables[0].Rows[0].ItemArray[0].ToString());
               // msgMail.IsBodyHtml = true;//MailFormat.Html;
               //// msgMail.Bcc = "susmita.d@creativebpo.com";
               // msgMail.Subject = dsxml.Tables[0].Rows[0].ItemArray[2].ToString();
               // msgMail.Body = tabmail;
               // SmtpClient objsmtp = new SmtpClient(dsxml.Tables[0].Rows[0].ItemArray[3].ToString());
               // objsmtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
               // objsmtp.Send(msgMail);
               // SmtpMail.SmtpServer = dsxml.Tables[0].Rows[0].ItemArray[3].ToString();
               // SmtpMail.Send(msgMail);
            }
        }
        btnsubmit_Click(sender, e);
    }
}
