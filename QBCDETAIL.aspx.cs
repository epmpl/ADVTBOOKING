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

public partial class QBCDETAIL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(QBCDETAIL));
        if (!Page.IsPostBack)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            lstexec.Attributes.Add("onclick", "javascript:return insertagency();");
            lstproduct.Attributes.Add("onclick", "javascript:return insertagency();");
            drppageprem.Attributes.Add("onchange", "javascript:return getpremper();");
            lstretainer.Attributes.Add("onclick", "javascript:return showretainervalue(this);");
            btnok.Attributes.Add("OnClick", "javascript:return setValue();");
            txtspedisc.Attributes.Add("OnBlur", "javascript:setspediscper();");
            txtspediscper.Attributes.Add("OnBlur", "javascript:setspedisc();");
            drppageposition.Attributes.Add("onChange", "javascript:return getpageamt();"); 
            if (Request.QueryString["agency"] != null)
            {
                bindPaymentMode(Request.QueryString["agency"].ToString(), hiddencompcode.Value);
            }

            DataSet objDataSetlabel = new DataSet();
            objDataSetlabel.ReadXml(Server.MapPath("XML/qbc.xml"));
            if (objDataSetlabel.Tables.Count > 1)
            {
                if (objDataSetlabel.Tables[1].Rows[0].ItemArray[1].ToString() == "hide")
                {

                    Agreedamt.Attributes.Add("style", "display:none");
                }

                //if (objDataSetlabel.Tables[1].Rows[0].ItemArray[2].ToString() == "hide")
                //{

                //    Specialamt.Attributes.Add("style", "display:none");
                //}
            }
            txtspedisc.Enabled = false;
            if (Request.QueryString["status"] != null && (Request.QueryString["status"].ToString() == "new" || Request.QueryString["status"].ToString() == "modify"))
            {
                txtexecname.Enabled = true;
                drpretainer.Enabled = true;
                drppageprem.Enabled = true;
                txtproduct.Enabled = true;
                drppaymenttype.Enabled = true;
                txtagreedamt.Enabled = true;
                txtextracharges.Enabled = true;
                txtspedisc.Enabled = false;
                txtspediscper.Enabled = true;
                btnok.Enabled = true;
                txtexecname.Focus();
            }
            else
            {
                txtexecname.Enabled = false;
                drpretainer.Enabled = false;
                drppageprem.Enabled = false;
                txtproduct.Enabled = false;
                drppaymenttype.Enabled = false;
                txtagreedamt.Enabled = false;
                txtextracharges.Enabled = false;
                txtspedisc.Enabled = false;
                txtspediscper.Enabled = false;
                btnok.Enabled = false;
            }

            bindpageprem();

          //  if (Request.QueryString["status"].ToString() == "EXECUTE" || Request.QueryString["status"].ToString() == "modify")
            //{
                //fetchData(Request.QueryString["cioid"].ToString());
                txtexecname.Text = Request.QueryString["execname"].ToString();
                txtexeczone.Text = Request.QueryString["Executive_zone"].ToString();
                drpretainer.Text = Request.QueryString["RETAINER1"].ToString();
                drppageprem.Text = Request.QueryString["Page_prem"].ToString();
                txtpremper.Text = Request.QueryString["Prem_per"].ToString();
                txtRetainercomm.Text = Request.QueryString["RETAINER_COMM"].ToString();
                txtproduct.Text = Request.QueryString["product"].ToString();
                drppaymenttype.Text = Request.QueryString["Agency_pay"].ToString();
                txtagreedamt.Text = Request.QueryString["Agreed_amount"].ToString();
                txtextracharges.Text = Request.QueryString["Special_charges"].ToString();
                txtspedisc.Text = Request.QueryString["Special_discount"].ToString();
                txtspediscper.Text = Request.QueryString["Special_disc_per"].ToString();
                hiddencardrate.Value = Request.QueryString["cardrate"].ToString();
                txtpageamt.Text = Request.QueryString["pageamt"].ToString();
               
           // }
        }





        DateTime dt = DateTime.Now;

        int year = Convert.ToInt32(dt.Year);
        int month = Convert.ToInt32(dt.Month);
        int day = Convert.ToInt32(dt.Day);
        string serdate = Convert.ToString(month + "/" + day + "/" + year);
        string datetime = "";
        datesave getdatechk = new datesave();
        dateinsert getdateshow = new dateinsert();
        // txtdatetime.Text = getdateshow.getDate(Session["dateformat"].ToString(), serdate);

        //getdatecheck = getdatechk.getDate(Session["dateformat"].ToString(), serdate);

        DataSet dsdate = new DataSet();
        DataSet per = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster cls_book = new NewAdbooking.Classes.BookingMaster();
            dsdate = cls_book.getCurrdate();
        
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
            dsdate = cls_book.getCurrdate();
        }
        else
        {
            NewAdbooking.classesoracle.BookingMaster cls_book = new NewAdbooking.classesoracle.BookingMaster();
            dsdate = cls_book.getCurrdate();
           
        }
       
     
        day = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[0].ToString());
        month = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[1].ToString());
        year = Convert.ToInt32(dsdate.Tables[0].Rows[0].ItemArray[2].ToString());
        string mon1 = Convert.ToString(month);
        if (Convert.ToString(mon1).Length == 1)
        {
            mon1 = "0" + mon1;
        }
        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            datetime = day + "/" + mon1 + "/" + year;

            
        }
        else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
        {
            datetime = year + "/" + mon1 + "/" + day;

           
        }
        else
        {
            datetime = mon1 + "/" + day + "/" + year;//getdateshow.getDate(Session["dateformat"].ToString(), serdate);

            
        }
        txtdatetime.Value = datetime;
        hiddendateformat.Value = Session["dateformat"].ToString();
        bindpagePosition(hiddencompcode.Value, datetime, Session["dateformat"].ToString(),"CL0");
        drppageposition.SelectedValue = Request.QueryString["pageposition"].ToString();
        //txtclientcatdisc.Text = Request.QueryString["txtclientcatdisc"].ToString();
        //txtclientcatam.Text = Request.QueryString["txtclientcatam"].ToString();
        //txtflatfreqdisc.Text = Request.QueryString["txtflatfreqdisc"].ToString();
        //txtflatfreqamt.Text = Request.QueryString["txtflatfreqamt"].ToString();
        //txtcatdisc.Text = Request.QueryString["txtcatdisc"].ToString();
        //txtcatamt.Text = Request.QueryString["txtcatamt"].ToString();
        if (Request.QueryString["txtclientcatdisc"] != null)
        {
            txtclientcatdisc.Text = Request.QueryString["txtclientcatdisc"].ToString();
        }
        else
        {
            txtclientcatdisc.Text = "";
        }
        if (Request.QueryString["txtclientcatam"] != null)
        {
            txtclientcatam.Text = Request.QueryString["txtclientcatam"].ToString();
        }
        else
        {
            txtclientcatam.Text = "";
        }
        if (Request.QueryString["txtflatfreqdisc"] != null)
        {
            txtflatfreqdisc.Text = Request.QueryString["txtflatfreqdisc"].ToString();
        }
        else
        {
            txtflatfreqdisc.Text = "";
        }
        if (Request.QueryString["txtflatfreqamt"] != null)
        {
            txtflatfreqamt.Text = Request.QueryString["txtflatfreqamt"].ToString();
        }
        else
        {
            txtflatfreqamt.Text = "";
        }
        if (Request.QueryString["txtcatdisc"] != null)
        {
            txtcatdisc.Text = Request.QueryString["txtcatdisc"].ToString();
        }
        else
        {
            txtcatdisc.Text = "";
        }
        if (Request.QueryString["txtcatamt"] != null)
        {
            txtcatamt.Text = Request.QueryString["txtcatamt"].ToString();
        }
        else
        {
            txtcatamt.Text = "";
        }
       
     
        DataSet objDatagetlabname = new DataSet();
        objDatagetlabname.ReadXml(Server.MapPath("XML/bookingmaster.xml"));
        lblclientcatdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[140].ToString();
        lblclientcatamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[141].ToString();
        lblflatfreqdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[142].ToString();
        lblflatfreqamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[143].ToString();
        lblcatdisc.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[144].ToString();
        lblcatamt.Text = objDatagetlabname.Tables[0].Rows[0].ItemArray[145].ToString();
    }
    private void fetchData(string cioid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objUpdatePage_Booking = new NewAdbooking.Classes.BookingMaster();
            ds = objUpdatePage_Booking.fetchqbcdetail(hiddencompcode.Value, cioid);
            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objPagePremium = new NewAdbooking.classesoracle.BookingMaster();
            ds = objPagePremium.fetchqbcdetail(hiddencompcode.Value, cioid);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            ds = objPagePremium.fetchqbcdetail(hiddencompcode.Value, cioid);

        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtexecname.Text=ds.Tables[0].Rows[0]["execname"].ToString();
            txtexeczone.Text = ds.Tables[0].Rows[0]["Executive_zone"].ToString();
            drpretainer.Text = ds.Tables[0].Rows[0]["RETAINER1"].ToString();
            drppageprem.Text = ds.Tables[0].Rows[0]["Page_prem"].ToString();
            txtpremper.Text = ds.Tables[0].Rows[0]["Prem_per"].ToString();
            txtRetainercomm.Text = ds.Tables[0].Rows[0]["RETAINER_COMM"].ToString();
            txtproduct.Text = ds.Tables[0].Rows[0]["product"].ToString();
            drppaymenttype.Text = ds.Tables[0].Rows[0]["Agency_pay"].ToString();
            txtagreedamt.Text = ds.Tables[0].Rows[0]["Agreed_amount"].ToString();
            txtextracharges.Text = ds.Tables[0].Rows[0]["Special_charges"].ToString();
            txtspedisc.Text = ds.Tables[0].Rows[0]["Special_discount"].ToString();
            txtspediscper.Text = ds.Tables[0].Rows[0]["Special_disc_per"].ToString();
       
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getPremPage(string premcode, string id)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster objUpdatePage_Booking = new NewAdbooking.Classes.BookingMaster();
            ds = objUpdatePage_Booking.getPremPage(premcode, id);
            // return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster objPagePremium = new NewAdbooking.classesoracle.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster objPagePremium = new NewAdbooking.classmysql.BookingMaster();
            ds = objPagePremium.getPremPage(premcode, id);

        }
        return ds;
    }
    private void bindPaymentMode(string agency,string compcode)
    {
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getstatuspaymodeAgency(agency, compcode);
        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select-";
            li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Selected = true;
            drppaymenttype.Items.Add(li1);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drppaymenttype.Items.Add(li);
            }
        }
    }
    [Ajax.AjaxMethod]
    public DataSet getexeczone(string execcode, string compcode)
    {
        //string execcode = txtexecname.Text;
        DataSet ds = new DataSet();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getExecZoneName(execcode, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.getExecZoneName(execcode, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getExecZoneName(execcode, compcode);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet getRetainerComm(string reatinername, string compcode)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getadcat3 = new NewAdbooking.classesoracle.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getadcat3 = new NewAdbooking.Classes.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

            dacat = getadcat3.getRetainerComm(reatinername, compcode);
        }
        return dacat;
    }
    [Ajax.AjaxMethod]
    public DataSet bindProduct(string compcode, string product)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.bindProduct(compcode, product, "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            ds = clsbooking.bindProduct(compcode, product, "0");
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.bindProduct(compcode, product, "0");
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
    public DataSet bindRetainer(string compcode, string reatinername)
    {
        DataSet dsret = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getRetain = new NewAdbooking.Classes.BookingMaster();

            dsret = getRetain.getretainer(compcode, reatinername);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster getRetain = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                dsret = getRetain.getretainer(compcode, reatinername, Session["revenue"].ToString());
            }
            else
            {
                dsret = getRetain.getretainer(compcode, reatinername, "0");
            }

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster getRetain = new NewAdbooking.classmysql.BookingMaster();
            dsret = getRetain.getretainer(compcode, reatinername, "0");
        }
        return dsret;
    }
    public void bindpageprem()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bindrate = new NewAdbooking.Classes.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(),"CL0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bindrate = new NewAdbooking.classesoracle.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(),"CL0");
        }
        else
        {
            NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            dx = bindrate.premiumbind(Session["compcode"].ToString(),"CL0");
        }

        drppageprem.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Premium-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppageprem.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppageprem.Items.Add(li);
            }

        }


    }





    public void bindpagePosition(string compcode, string bookdate, string dateformat,string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

            ds = clsbooking.bindPagePosition(compcode, bookdate, dateformat,adtype);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

                ds = clsbooking.bindPagePosition(compcode, bookdate, dateformat,adtype);

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

                ds = clsbooking.bindPagePosition(compcode);

            }

         int i;
          ListItem li1;

          li1 = new ListItem();
          drppageposition.Items.Clear();
          li1.Text = "Select Page Position";
          li1.Value = "0";
          li1.Selected = true;
          drppageposition.Items.Add(li1);

          for (i = 0; i < ds.Tables[0].Rows.Count; i++)
          {
              ListItem li;
              li = new ListItem();
              li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
              li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
              drppageposition.Items.Add(li);


          }
    
    }

  

    [Ajax.AjaxMethod]
    public DataSet getpageamount(string pagecode, string compcode)
    {
        DataSet damt = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getamt = new NewAdbooking.Classes.BookingMaster();
            damt = getamt.getpageamt(pagecode, compcode);//, bookdate, dateformat);
            return damt;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getamt = new NewAdbooking.classesoracle.BookingMaster();
                damt = getamt.getpageamt(pagecode, compcode);//, bookdate, dateformat);
                return damt;
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getamt = new NewAdbooking.classmysql.BookingMaster();
                damt = getamt.getpageamt(pagecode, compcode);
                return damt;
            }



    }
}
