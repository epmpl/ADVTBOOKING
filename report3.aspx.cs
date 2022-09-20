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
using System.Data.OracleClient;

public partial class report3 : System.Web.UI.Page
{

   
           

    protected void Page_Load(object sender, EventArgs e)
    {


       // Session["compcode"] = "HT001";
        //Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/report3.xml"));
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        agencyname.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbstatus.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

        
        if (!Page.IsPostBack)
        {
            bindadvtype();
            bindpub();
            publicationbind();
           bindagency();
            binddest();
            bindstatus();
            edition();

        

            BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
           BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");


        }



    }


    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string  hold = "abc";
        string str = "";
        string str1 = "";
        for (int i = 1; i < dpadcatgory.Items.Count; i++)
        {

            if (dpadcatgory.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpadcatgory.Items[i].Value;
                    str1 = dpadcatgory.Items[i].Text;
                }
                else
                {
                    str = str + "," + dpadcatgory.Items[i].Value;
                    str1 = str1 + "," + dpadcatgory.Items[i].Text;
                }
            }
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spStatus(dpagencyna.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpstatus.SelectedItem.Value, dpedition.SelectedValue, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spStatus(dpagencyna.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpstatus.SelectedItem.Value, dpedition.SelectedValue, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Reportnew";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { dpagencyna.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpstatus.SelectedItem.Value, dpedition.SelectedValue, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //ds = obj.spStatus(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(report3), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["frmdt"] = txtfrmdate.Text;
            Session["todt"] = txttodate1.Text;


            Response.Redirect("reportstatus.aspx?agname=" + dpagencyna.SelectedValue + "&adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&destination=" + Txtdest.SelectedItem.Value + "&status1=" + dpstatus.SelectedItem.Text + "&adcatname=" + str1 + "&status=" + dpstatus.SelectedItem.Value + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + dpedition.SelectedItem.Text + "&hold=" + hold);
        }

        //Session["fromdate"] = txtfrmdate.Text;
       // Session["dateto"] = txttodate1.Text;
    }
    protected void dppub1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //int i;
        //ListItem li;
        //li = new ListItem();
        //dpedition.Items.Clear();
        //li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;
        //dpedition.Items.Add(li);


        //if (ds.Tables.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li1;
        //        li1 = new ListItem();
        //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        dpedition.Items.Add(li1);
        //    }
        //}
    }


    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass advpub = new NewAdbooking.classesoracle.reportclass();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
    
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
       // li1.Text = "--Select Publication--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li);


        }
    }
    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass advname = new NewAdbooking.classesoracle.reportclass();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
    
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
       // li1.Text = "--Select Ad Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpdadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


        }
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
       // li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }

    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dpstatus.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
       // li1.Text = "Select Status";
        li1.Value = "0";
        li1.Selected = true;
        dpstatus.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            dpstatus.Items.Add(li);

        }


     

    }
    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass pub_cent1 = new NewAdbooking.classesoracle.reportclass();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "publication_proc_publication_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        //li.Text = "-Select Publication Center-";
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


    }
    public void bindagency()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adagency = new NewAdbooking.Classes.Class1();
            ds = adagency.agency(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adagency = new NewAdbooking.classesoracle.reportclass();
            ds = adagency.agency(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "BINDAGENCYFORCONTRACT_BINDAGENCYFORCONTRACT_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        dpagencyna.Items.Clear();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
       // li1.Text = "--Select Agency Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpagencyna.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagencyna.Items.Add(li);


        }
    }


    
    protected void dpadcatgory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpdadtype.SelectedValue;

        dpadcatgory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adcat = new NewAdbooking.classesoracle.reportclass();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_BINDADCATEGORY_RA_BINDADCATEGORY_P";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        //li1.Text = "--Select Ad Category--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpadcatgory.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadcatgory.Items.Add(li);



        }
    }

    protected void dppubcent_SelectedIndexChanged(object sender, EventArgs e)
    {

        //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //int i;
        //ListItem li;
        //li = new ListItem();
        //dpedition.Items.Clear();
        //li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;
        //dpedition.Items.Add(li);


        //if (ds.Tables.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li1;
        //        li1 = new ListItem();
        //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        dpedition.Items.Add(li1);
        //    }
        //}

    }

    protected void dppubcent_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //int i;
        //ListItem li;
        //li = new ListItem();
        //dpedition.Items.Clear();
        //li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;
        //dpedition.Items.Add(li);


        //if (ds.Tables.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li1;
        //        li1 = new ListItem();
        //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        dpedition.Items.Add(li1);
        //    }
        //}  
    }
    protected void dppubcent_SelectedIndexChanged2(object sender, EventArgs e)
    {
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
                ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass pub_cent2 = new NewAdbooking.classesoracle.reportclass();
                ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "edition_proc_edition_proc_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
     
            int i;
            ListItem li;
            li = new ListItem();
            dpedition.Items.Clear();


            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
            li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            //li.Text = "-Select Edition Name-";
            li.Value = "0";
            li.Selected = true;
            dpedition.Items.Add(li);


            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1;
                    li1 = new ListItem();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    dpedition.Items.Add(li1);
                }
            }

        }
    }
}

