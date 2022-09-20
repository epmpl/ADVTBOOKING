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
using System.Text.RegularExpressions;

public partial class ctreport_main : System.Web.UI.Page
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
            Session["access"] = "0";
            hiddenuseid.Value = Session["userid"].ToString();
            //hdnunitcode.Value = Session["unitcode"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
        }
           
       //}
       // else
       //{
       // //    Response.Write("<script>alert('Your session has been expired');window.close();</script>");
       // //    return;
       // }
            
        Ajax.Utility.RegisterTypeForAjax(typeof(ctreport_main));

        Session["fromdate"] = txtfromdate.Text;
        Session["todate"] = txttodate.Text;
        DataSet ds1 = new DataSet();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/ctreport.xml"));
        fromdate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        todate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblprtcent.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbldistrict.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbadcat1.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbladcat2.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbladcat3.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        Btnexit.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbteam.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lbexec.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lbreptype.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
           
        if (!Page.IsPostBack)
        {
            bindteam();
           bindbranch();
            bindadtype();
            bindload();
           bindpubcent();
            binddest();
            bindexecutive();
            bindpub();
            edition();
         
           BtnRun.Attributes.Add("OnClick", "javascript:return chkrun();");
           Btnexit.Attributes.Add("OnClick", "javascript:return formexit();");
            dpadtype.Attributes.Add("onchange", "javascript:return bindadcat();");
           dpadcat.Attributes.Add("onchange", "javascript:return bindsubcat();");
           dpadcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");
           dpadsubcat.Attributes.Add("onchange", "javascript:return bindsubcat345();");
          dpadsubcat.Attributes.Add("onkeypress", "javascript:return keySort(this);");
           dpadsubcat3.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpbranch.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpteam.Attributes.Add("onchange", "javascript:return bind_team_exe();");
            dpteam.Attributes.Add("onkeypress", "return keySort1(this);");
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition5();");
            dpteam.Attributes.Add("onkeypress", "javascript:return bind_team_exe();");
           //// txtdist.Attributes.Add("onkeydown", "javascript:return filldist()");

            txtfromdate.Attributes.Add("onchange", "javascript:return checkdate(this);");
            txttodate.Attributes.Add("onchange", "javascript:return checkdate(this);");

            txtdistrict.Attributes.Add("onkeydown", "javascript:return F2filldistrict(event);");
            lstdistrict.Attributes.Add("onclick", "javascript:return Clickdistrict(event);");
            lstdistrict.Attributes.Add("onkeydown", "javascript:return Clickdistrict(event);");

        }
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/ctreport.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }


     //public void binddest()
     //{
     //    DataSet destination = new DataSet();
     //    destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
     //    Txtdest.Items.Clear();
     //    int i;
     //    ListItem li1;
     //    li1 = new ListItem();
     //    DataSet ds1 = new DataSet();
     //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
     //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
     //    //li1.Text = "--Select Destination--";
     //    li1.Value = "";
     //    li1.Selected = true;
     //    Txtdest.Items.Add(li1);

     //    for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
     //    {
     //        ListItem li;
     //        li = new ListItem();
     //        li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
     //        i = i + 1;
     //        li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
     //        Txtdest.Items.Add(li);

     //    }
     //}

     public void bindbranch()
     {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {

             NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
             ds = pub.adbranch(Session["compcode"].ToString());
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
             ds = pub.adbranch(Session["compcode"].ToString());
         }
         else
         {
             string procedureName = "branchbind_adv_branchbind_adv_p";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }


         ListItem li = new ListItem();
         li.Value = "";
         li.Text = "--Select Branch--";
         li.Selected = true;
         dpbranch.Items.Add(li);

         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
         {
             ListItem li1 = new ListItem();
             li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
             li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
             dpbranch.Items.Add(li1);
         }

         dpbranch.SelectedValue = Session["revenue"].ToString();

     }

     public void bindadtype()
     {

         DataSet ds = new DataSet();
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
         else
         {
             string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }


         ListItem li1;
         li1 = new ListItem();
        
         li1.Value = "";
         li1.Text = "Select AdType";
         li1.Selected = true;
         dpadtype.Items.Add(li1);



         int i;
         for (i = 0; i < ds.Tables[0].Rows.Count; i++)
         {
             ListItem li;
             li = new ListItem();
             li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
             li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
             dpadtype.Items.Add(li);


         }
    }
    public void bindpubcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubCentName_r_Bind_PubCentName_r_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "Select Printing Center";
        li.Selected = true;
        dpprintcenter.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpprintcenter.Items.Add(li1);


        }
    }

   
   /// ///////////////////////////////////////////////////
 [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcode, string uid, string extra1)
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.bind_district2(compcode, uid, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.bind_district2(compcode, uid, extra1);
        }
        else
        {
            string procedureName = "getdistrict";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, uid, extra1 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;
    }
  ///////////////////////////////////////////////////////
    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else
        {
            string procedureName = "RA_bindadcategory_RA_bindadcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { adtype, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet subcatbind(string compcode, string cat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.getSubCategory(compcode, cat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.getSubCategory(compcode, cat);
        }
        else
        {
            string procedureName = "advsubcattyp_advsubcattyp_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, cat };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet subcat345(string cat, string compcode, string adcat4, string adcat5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.cat345(cat, compcode, adcat4, adcat5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.cat345(cat, compcode, adcat4, adcat5);
        }
        else
        {
            string procedureName = "bindadcat345_bindadcat345_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { cat, compcode, adcat4, adcat5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet exe_bind(string comp_code, string userid, string team)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
            ds = exec.adexec(comp_code, userid, team);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
            ds = exec.adexec(comp_code, userid, team);
        }
        else
        {
            string procedureName = "xlsBindexec_xlsBindexec_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { comp_code, userid, team };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    public void bindexecutive()
    {
       
        ListItem li1;
        li1 = new ListItem();
        li1.Value = "";
        li1.Text = "--Select Executive Name--";    
        li1.Selected = true;
        dpexec.Items.Add(li1);

        //ListItem li11;
        //li11 = new ListItem();
        //li11.Value = "";
        //li11.Text = "";
        //li11.Selected = true;
        //dpexec.Items.Add(li11);

    }
    public void bindteam()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Categorreport advpub = new NewAdbooking.Report.classesoracle.Categorreport();
            ds = advpub.team(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Bind_team";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        ListItem li1 = new ListItem();
        li1.Value = "";
        li1.Text = "Select Team";
        li1.Selected = true;
        dpteam.Items.Add(li1);
        //DataSet ds1 = new DataSet();
        //ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        //li1.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
        //li.Value = "";
     
      
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li= new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpteam.Items.Add(li);


        }
    }

     public void bindload()
     {
         ListItem li1;
         li1 = new ListItem();
         li1.Text = "Select AdCat";
         li1.Value = "";
         dpadcat.Items.Add(li1);

         ListItem li11;
         li11 = new ListItem();
         li11.Text = "Select AdSubCat1";
         li11.Value = "";
         dpadsubcat.Items.Add(li11);

         ListItem li21;
         li21 = new ListItem();
         li21.Text = "Select AdSubCat2";
         li21.Value = "";
         dpadsubcat3.Items.Add(li21);

         //ListItem li31;
         //li31 = new ListItem();
         //li31.Text = "Select AdSubCat4";
         //li31.Value = "0";
         //dpadsubcat4.Items.Add(li31);

         //ListItem li41;
         //li41 = new ListItem();
         //li41.Text = "Select AdSubCat5";
         //li41.Value = "0";
         //dpadsubcat5.Items.Add(li41);



     }
    /////////////////Pub+ edition////////////////////////

     public void edition()
     {
         ListItem li;
         li = new ListItem();
         dpedition.Items.Clear();
         //DataSet ds1 = new DataSet();
         //ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
         //li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
         //li.Text = "-Select Edition Name-";
         li.Value = "";
         li.Text = "Select Edition";
         li.Selected = true;
         dpedition.Items.Add(li);

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
         else
         {
             string procedureName = "edition_proc_edition_proc_p";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             string[] parameterValueArray = new string[] { pub, pub_cent, compcode };
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }

         return ds;
     }



     public void bindpub()
     {
         //regionhidden=hiddenregion.Value;
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
             ds = advpub.advpub(Session["compcode"].ToString());
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
             ds = advpub.advpub(Session["compcode"].ToString());
         }
         else
         {
             string procedureName = "Bind_PubName_Bind_PubName_p";
             NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
             string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
             ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
         }
         ListItem li1;
         li1 = new ListItem();
         //DataSet ds1 = new DataSet();
         //ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
         //li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Text = "--Select Publication--";
         li1.Value = "";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
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
   //protected void BtnRun_Click(object sender, EventArgs e)
   // {
   //     string chk_excel = "";
   //     string from_date = "";
   //     string to_date = "";
   //     Response.Redirect("");
   //     string hold = "";
   //     string str = "";
   //     string str1 = "";

   //     if (Txtdest.SelectedValue == "4")
   //     {
   //         if (exe.Checked == true)
   //         {
   //             chk_excel = "1";//excel
   //         }
   //         else
   //         {
   //             chk_excel = "2";//csv
   //         }

   //     }
   //     else
   //     {
   //         chk_excel = "0";//other than excel
   //     }


   //     DataSet ds = new DataSet();
   //     if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
   //     {
   //         if (hiddendateformat.Value == "dd/mm/yyyy")
   //         {
   //             from_date = DMYToMDY(txtfromdate.Text);
   //             to_date = DMYToMDY(txttodate.Text);
   //         }


   //         else if (hiddendateformat.Value == "yyyy/mm/dd")
   //         {
   //             from_date = YMDToMDY(txtfromdate.Text);
   //             to_date = YMDToMDY(txttodate.Text);
   //         }
   //         NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.report();
     //         ds = obj.ctreport_main(dpadtype.SelectedValue, str, from_date, to_date, Session["compcode"].ToString(), Session["dateformat"].ToString(), hold, Session["userid"].ToString(), Session["access"].ToString());
   //     }
   //     else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
   //     {
   //         NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
     //         ds = obj.ctreport_main(dpadtype.SelectedValue, str, txtfromdate.Text, txttodate.Text, Session["compcode"].ToString(), Session["dateformat"].ToString(), hold, Session["userid"].ToString(), Session["access"].ToString());
   //     }
   //     int cont = ds.Tables[0].Rows.Count;

   //     if (ds.Tables[0].Rows.Count == 0)
   //     {

   //         ScriptManager.RegisterClientScriptBlock(this, typeof(ctreport_view), "sa", "alert(\"searching criteria is not valid\");", true);
   //         return;
   //     }
   //     else
   //     {
   //         Session["ctreport_main"] = ds;
   //         Session["prm_cwreport"] = "~adtype~" + dpadtype.SelectedValue + "~adcategory~" + str + "~fromdate~" + txtfromdate.Text + "~dateto~" + txttodate.Text + "~pubcenter~" + dppubcent.SelectedValue + "~destination~" + Txtdest.SelectedItem.Value + "~adcatname~" + str1 + "~adtypename~" + dpadtype.SelectedItem.Text + "~chk_excel~" + chk_excel;
   //         Response.Redirect("ctreport_view.aspx");
   //         //Response.Redirect("cwrepoertview.aspx? "&adtype=" + dpadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfromdate.Text + "&dateto=" + txttodate.Text);

   //     }

   // }



    }

