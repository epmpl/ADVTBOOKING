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

public partial class Reports_case_register_rep : System.Web.UI.Page
{
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
        
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_case_register_rep));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/case_register.xml"));
        lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbladsubcat.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbl_printcent.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();


        // lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        if (!Page.IsPostBack)
        {
            dpdadtype.Attributes.Add("onchange", "javascript:return adcat_bind();");
            dpadcatgory.Attributes.Add("onchange", "javascript:return adsubcat_bind();");
            dppubcent.Attributes.Add("onchange", "javascript:return bind_edition13();");
            BtnRun.Attributes.Add("OnClick", "javascript:return onclk_run();");
            bindadvtype();
            bindpub();
            bindbranch();
            bindprintcent();
            publicationbind();
            user_bind();
            binddest();
            bindbased();

        }
    }

    [Ajax.AjaxMethod]
    public DataSet bind_adcat(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { adtype, compcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.case_register_rep adcat = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep adcat = new NewAdbooking.Report.Classes.case_register_rep();
            ds = adcat.advtype(adtype, compcode);
        }
        else
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    public void bindadvtype()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.case_register_rep advname = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep advname = new NewAdbooking.Report.Classes.case_register_rep();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
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

    [Ajax.AjaxMethod]
    public DataSet bind_adsubcat(string compcode, string cat)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, cat };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.case_register_rep adcat = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = adcat.get_SubCategory(compcode, cat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep adcat = new NewAdbooking.Report.Classes.case_register_rep();
            ds = adcat.getSubCategory(compcode, cat);
        }
        else
        {
            string procedureName = "adsubcategory_adsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;

    }

    public void bindpub()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.case_register_rep advpub = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep advpub = new NewAdbooking.Report.Classes.case_register_rep();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubName_Bind_PubName_p";
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
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

    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.case_register_rep pub = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep pub = new NewAdbooking.Report.Classes.case_register_rep();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "branchbind_adv_branchbind_adv_p";
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "--Select Branch--";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }
        dpd_branch.SelectedValue = Session["revenue"].ToString();
    }

    public void bindprintcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.case_register_rep pub_cent1 = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep pub_cent1 = new NewAdbooking.Report.Classes.case_register_rep();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubCentName_r_Bind_PubCentName_r_p";
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "--Select Printing Center--";
        li.Selected = true;
        dpd_printcent.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_printcent.Items.Add(li1);


        }
    }

    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.case_register_rep pub_cent2 = new NewAdbooking.Report.classesoracle.case_register_rep();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep pub_cent2 = new NewAdbooking.Report.Classes.case_register_rep();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        else
        {
            string procedureName = "edition_proc_edition_proc_p";
            string[] parameterValueArray = new string[] { pub, pub_cent, compcode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
        else
        {
            string procedureName = "pubcent_proc_pubcent_proc_p";
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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


    }

    public void user_bind()
    {
        DataSet ds = new DataSet();

        if (Session["Admin"].ToString() == "yes")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();

                ds = obj.bind_user(Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();

                ds = obj.bind_user(Session["compcode"].ToString(), Session["ROLEID"].ToString());
            }
            else
            {
                string procedureName = "bind_username_bind_username_p";
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["ROLEID"].ToString() };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            drpuserid.Items.Clear();
            ListItem li11;
            li11 = new ListItem();
            li11.Text = "--Select User--";
            li11.Value = "0";
            li11.Selected = true;
            drpuserid.Items.Add(li11);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpuserid.Items.Add(li1);
            }
        }
        else
        {
            drpuserid.Items.Clear();
            ListItem li11;
            li11 = new ListItem();
            li11.Text = "--Select User--";
            li11.Value = "0";
            li11.Selected = true;
            drpuserid.Items.Add(li11);

            li11 = new ListItem();
            li11.Text = Session["Username"].ToString();
            li11.Value = Session["userid"].ToString();
            drpuserid.Items.Add(li11);


        }

    }

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        drpdest.Items.Clear();
        int i;

        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        drpdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            drpdest.Items.Add(li);
           

        }
    }


    public void bindbased()
    {
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/case_register.xml"));
        drpbased.Items.Clear();
        int i;

        ListItem li1;
        li1 = new ListItem();
       // li1.Text = "---select Based On---";
       // li1.Value = "0";
        li1.Selected = true;
        drpbased.Items.Add(li1);

        for (i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            drpbased.Items.Add(li);



        }
    }
  

}
