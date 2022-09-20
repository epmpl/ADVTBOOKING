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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class Retaincom : System.Web.UI.Page
{
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Retaincom));
      
      
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();

        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;

        DataSet d1s = new DataSet();
        d1s.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = d1s.Tables[0].Rows[0].ItemArray[5].ToString();
        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();

            bindadvtype();
           // bindretainer1();
            bindbranch1();
            publicationbind();
            txtfrmdate.Focus();

           // BtnRun.Attributes.Add("OnClick", "javascript:return datenullcheck();");
        
           // BtnRun.Attributes.Add("onclick", "javascript:return runclickbillregister();");
            BtnRun.Attributes.Add("onclick", "javascript:return daily_summarized_ret();");
            
            //BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            //txtfrmdate.Attributes.Add("onblur", "javascript:return check_dat();");
            //txttodate1.Attributes.Add("onblur", "javascript:return check_dat();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            txt_retainer.Attributes.Add("onkeypress", "return keySort(this);");
            dpregion.Attributes.Add("onkeypress", "return keySort(this);");
            drpbranch.Attributes.Add("onkeypress", "return keySort(this);");
            dpedition.Attributes.Add("onkeypress", "return keySort(this);");

            dppub1.Attributes.Add("onchange", "javascript:return bind_edition14();");
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition14();");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");

            txt_retainer.Attributes.Add("onkeydown", "javascript:return F2fillretainercr_ret(event);");
            txt_retainer.Attributes.Add("onkeypress", "javascript:return F2fillretainercr_ret(event);");

            lstretainer.Attributes.Add("onclick", "javascript:return Clickretainer_ret(event);");
            lstretainer.Attributes.Add("onkeydown", "javascript:return Clickretainer_ret(event);");

            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();");
            ListItem li1;
            li1 = new ListItem();

            li1.Text = ("--Select Edition Name--");
            li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Selected = true;
            dpedition.Items.Add(li1);

            

        }
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditretainer(string compcol, string ret)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = objregion.retainerxls(compcol, ret);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.retainerxls(compcol, ret);
        }


        return ds;
    }
  

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }

        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
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

        dppubcent.SelectedValue = Session["center"].ToString();


    }

    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        return ds;
    }
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
    }
     else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpaddtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpaddtype.Items.Add(li);


        }
    }


    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        //for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        for (i = 0; i < destination.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }

    
    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        //ds = objregion.bindregion(Session["compcode"].ToString());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objregion = new NewAdbooking.Report.classesoracle.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
       

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpregion.Items.Add(li);


        }
    }


   // BIND_RETAINERNAME

    //public void bindretainer1()
    //{
    //    //regionhidden=hiddenregion.Value;
    //    //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //    NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
    //        ds = objregion.bindretainer(Session["compcode"].ToString());
    //}
    // else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
    //        ds = objregion.bindretainer(Session["compcode"].ToString());
    //    }

    //    ListItem li1;
    //    li1 = new ListItem();
    //   // DataSet ds1 = new DataSet();
    //   // ds1.ReadXml(Server"--Select Retainer--");
    //    li1.Text = ("--Select Retainer--");
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    txt_retainer.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        txt_retainer.Items.Add(li);


    //    }
    //}


    public void bindbranch1()
    {
        //regionhidden=hiddenregion.Value;
        //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {  
        NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
        ds = objregion.bindbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindbranch(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
      
        li1.Text = ("--Select Branch--");
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbranch.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbranch.Items.Add(li);


        }

        drpbranch.SelectedValue = Session["revenue"].ToString();
    }

    public void bindproductnamne()
    {
        ListItem li;
        li = new ListItem();
        dppub1.Items.Clear();
        DataSet ds1 = new DataSet();
      
        li.Text = "--Select Publication--";
        li.Value = "0";
        li.Selected = true;
        dppub1.Items.Add(li);
        int i;

        /**************************         new            **************************************/

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
        NewAdbooking.Report.classesoracle.SHACHIREPORT objregion = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
        ds = objregion.bindpublication(Session["compcode"].ToString());

        
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1;
            li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li1);


        }
    }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());


            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dppub1.Items.Add(li1);


            }
        }
        /****************************************************************************************/

       
    }


    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string from_date = "";
        string to_date = "";
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "";
         //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        string chk_excel = "";
        if (Txtdest.SelectedValue == "4")
        {
            if (exe.Checked == true)
            {
                chk_excel = "1";//excel
            }
            else
            {
                chk_excel = "2";//csv
            }

        }
        else
        {
            chk_excel = "0";//other than excel
        }
        
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        { 
            NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();
            
            ds = obj.retainonscreen(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dppub1.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, drpbranch.SelectedValue, hiddeneditionname.Value, hdnretainer.Value, dpaddtype.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
    }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfrmdate.Text);
                to_date = DMYToMDY(txttodate1.Text);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                from_date = YMDToMDY(txtfrmdate.Text);
                to_date = YMDToMDY(txttodate1.Text);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            ds = obj.retainonscreen(from_date, to_date, dpregion.SelectedValue, dppub1.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, drpbranch.SelectedValue, hiddeneditionname.Value, hdnretainer.Value, dpaddtype.SelectedValue, dppubcent.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        }
          
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Retaincom), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["retaincom"] = ds;
            Session["prm_retaincom"] = "destination~" + Txtdest.SelectedItem.Value + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~regioncode~" + dpregion.SelectedValue + "~regionname~" + dpregion.SelectedItem + "~productcode~" + dppub1.SelectedValue + "~productname~" + dppub1.SelectedItem + "~editioncode~" + dpedition.SelectedValue + "~editionname~" + dpedition.SelectedItem + "~branchcode~" + drpbranch.SelectedValue + "~branchname~" + drpbranch.SelectedItem + "~Adtypecode~" + dpaddtype.SelectedValue + "~Adtypename~" + dpaddtype.SelectedItem + "~Retainercode~" + hdnretainer.Value + "~Retainername~" + txt_retainer.Text + "~chk_excel~" + chk_excel;
            
            Response.Write("<Script>window.open('Retaincomview.aspx',target='_blank')</Script>");
//            Response.Redirect("Retaincomview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&regioncode=" + dpregion.SelectedValue + "&regionname=" + dpregion.SelectedItem + "&productcode=" + dppub1.SelectedValue + "&productname=" + dppub1.SelectedItem + "&editioncode=" + dpedition.SelectedValue + "&editionname=" + dpedition.SelectedItem + "&branchcode=" + drpbranch.SelectedValue + "&branchname=" + drpbranch.SelectedItem + "&Adtypecode=" + dpaddtype.SelectedValue + "&Adtypename=" + dpaddtype.SelectedItem + "&Retainercode=" + txt_retainer.SelectedValue + "&Retainername=" + txt_retainer.SelectedItem);
        }
    }


}

