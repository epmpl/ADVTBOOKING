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

public partial class Retaincom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();

        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        //lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //agencyname.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbaaddress.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();

        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();

            bindadvtype();
            bindretainer1();
            bindbranch1();
            //bindagency();
           // bindcategory();
            txtfrmdate.Focus();

            BtnRun.Attributes.Add("OnClick", "javascript:return datenullcheck();");
            //BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            ////dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            BtnRun.Attributes.Add("onclick", "javascript:return runclickbillregister();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            txtfrmdate.Attributes.Add("onblur", "javascript:return check_dat();");
            txttodate1.Attributes.Add("onblur", "javascript:return check_dat();");

            

        }
    }

    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();
        //    ds = advname.adname(Session["compcode"].ToString());
        //}
        //else
        //{
            NewAdbooking.classesoracle.Class1 advname = new NewAdbooking.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        //}
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
            NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 objregion = new NewAdbooking.classesoracle.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
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

    public void bindretainer1()
    {
        //regionhidden=hiddenregion.Value;
        //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        //ds = objregion.bindregion(Session["compcode"].ToString());

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        //    ds = objregion.bindregion(Session["compcode"].ToString());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        NewAdbooking.classesoracle.SHACHIREPORT objregion = new NewAdbooking.classesoracle.SHACHIREPORT();
            ds = objregion.bindretainer(Session["compcode"].ToString());
        //}
        //else
        //{
        //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
        //    //ds = pub.product(region, Session["compcode"].ToString());
        //}

        ListItem li1;
        li1 = new ListItem();
       // DataSet ds1 = new DataSet();
       // ds1.ReadXml(Server"--Select Retainer--");
        li1.Text = ("--Select Retainer--");
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpretainer.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpretainer.Items.Add(li);


        }
    }


    public void bindbranch1()
    {
        //regionhidden=hiddenregion.Value;
        //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        //ds = objregion.bindregion(Session["compcode"].ToString());

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        //    ds = objregion.bindregion(Session["compcode"].ToString());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        NewAdbooking.classesoracle.SHACHIREPORT objregion = new NewAdbooking.classesoracle.SHACHIREPORT();
        ds = objregion.bindbranch(Session["compcode"].ToString());
        //}
        //else
        //{
        //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
        //    //ds = pub.product(region, Session["compcode"].ToString());
        //}

        ListItem li1;
        li1 = new ListItem();
        // DataSet ds1 = new DataSet();
        // ds1.ReadXml(Server"--Select Retainer--");
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
    }

    public void bindproductnamne()
    {
        ListItem li;
        li = new ListItem();
        dpprodcat.Items.Clear();
        DataSet ds1 = new DataSet();
       // ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
       // li.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

        li.Text = "--Select Publication--";
        li.Value = "0";
        li.Selected = true;
        dpprodcat.Items.Add(li);


        /**************************         new            **************************************/

        DataSet ds = new DataSet();

        NewAdbooking.classesoracle.SHACHIREPORT objregion = new NewAdbooking.classesoracle.SHACHIREPORT();
        ds = objregion.bindpublication(Session["compcode"].ToString());

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1;
            li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpprodcat.Items.Add(li1);


        }

        /****************************************************************************************/

       
    }


    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "";
         //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
       
        
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.retainonscreen(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dpprodcat.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());


        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        //    ds = obj.retainonscreen(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dpprodcat.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
            NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
            ds = obj.retainonscreen(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedItem.Text, dpprodcat.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, drpbranch.SelectedItem.Text, drpedition.SelectedValue, drpretainer.SelectedValue, dpaddtype.SelectedValue);
        //}
        //else
        //{
        //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
        //    //ds = pub.product(region, Session["compcode"].ToString());
        //}

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Retaincom), "sa", "alert(\"searching criteria is not valid\");", true);

            return;
        }
        else
        {
            Response.Redirect("Retaincomview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&regioncode=" + dpregion.SelectedValue + "&regionname=" + dpregion.SelectedItem + "&productcode=" + dpprodcat.SelectedValue + "&productname=" + dpprodcat.SelectedItem + "&editioncode=" + drpedition.SelectedValue + "&editionname=" + drpedition.SelectedItem + "&branchcode=" + drpbranch.SelectedValue + "&branchname=" + drpbranch.SelectedItem + "&Adtypecode=" + dpaddtype.SelectedValue + "&Adtypename=" + dpaddtype.SelectedItem + "&Retainercode=" + drpretainer.SelectedValue + "&Retainername=" + drpretainer.SelectedItem);
        }
    }


  
    //protected void dpregion_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    string region = dpregion.SelectedValue;
    //    dpprodcat.Items.Clear();
    //    //NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();
    //    DataSet ds = new DataSet();
    //   // ds = pub.product(region, Session["compcode"].ToString());

    //    //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    //{
    //    //    NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();
    //    //    ds = pub.product(region, Session["compcode"].ToString());
    //    //}
    //    //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    //{
    //        NewAdbooking.classesoracle.bill pub = new NewAdbooking.classesoracle.bill();
    //        ds = pub.product(region, Session["compcode"].ToString());
    //    //}
    //    //else
    //    //{
    //    //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
    //    //    //ds = pub.product(region, Session["compcode"].ToString());
    //    //}

    //    ListItem li1;
    //    li1 = new ListItem();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpprodcat.Items.Add(li1);

    //    //dpadcatgory.Items.Clear();
    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpprodcat.Items.Add(li);



    //    }

    //}
    protected void dpprodcat_SelectedIndexChanged(object sender, EventArgs e)
    {
                string pub_code;
                pub_code = dpprodcat.SelectedValue;
                ListItem li;
                li = new ListItem();
                drpedition.Items.Clear();
                DataSet ds1 = new DataSet();
                // ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
                // li.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

                li.Text = "--Select Edition--";
                li.Value = "0";
                li.Selected = true;
                drpedition.Items.Add(li);


                /**************************         new            **************************************/

                DataSet ds = new DataSet();

                NewAdbooking.classesoracle.SHACHIREPORT objregion = new NewAdbooking.classesoracle.SHACHIREPORT();
                ds = objregion.bindedition(Session["compcode"].ToString(), pub_code);

                int i;
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                            ListItem li1;
                            li1 = new ListItem();
                            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                            drpedition.Items.Add(li1);


                }
          
    }
}

