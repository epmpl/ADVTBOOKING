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
public partial class piproduct : System.Web.UI.Page
{
    string uom = "";
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
       // Session["compcode"] = "HT001";
        //Session["dateformat"] = "yyyy/mm/dd";
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
       
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;
       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));
        lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[59].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[68].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[70].ToString();
      
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[73].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
        lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
        lborderby.Text = ds.Tables[0].Rows[0].ItemArray[63].ToString();
      
        ad.Text = ds.Tables[0].Rows[0].ItemArray[65].ToString();
        bill.Text = ds.Tables[0].Rows[0].ItemArray[67].ToString();
        schedule.Text = ds.Tables[0].Rows[0].ItemArray[66].ToString();
        DataSet d2s = new DataSet();
        d2s.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbPublicationCenter.Text = d2s.Tables[0].Rows[0].ItemArray[5].ToString();
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();
            bindpublication();
            bindadtype();
            bindorder();
            bindagencytype();
            publicationbind();

           // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            BtnRun.Attributes.Add("onclick", "javascript:return chkorder_nn();");
           // dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");


            bill.Attributes.Add("OnClick", "javascript:return billclick();");
            schedule.Attributes.Add("OnClick", "javascript:return scheduleclick();");

            dpcategory.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpproduct.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dppublication.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            dpregion.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();"); 



        }

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
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
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

        dppubcent.SelectedValue = Session["center"].ToString();


    }
    public void bindagencytype()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.billregister obj = new NewAdbooking.Report.Classes.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Websp_agent_Websp_agent_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li;
        li = new ListItem();
        dpagtype.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpagtype.Items.Add(li);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagtype.Items.Add(li2);


        }
    }
    public void bindpublication()
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

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppublication.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppublication.Items.Add(li);


        }
    }
    public void bindadtype()
    {

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
        else
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpcategory.Items.Add(li1);


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcategory.Items.Add(li);


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
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        //li1.Selected = true;
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


    public void bindorder()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dporderby.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[27].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        //li1.Selected = true;
        dporderby.Items.Add(li1);

        for (i = 0; i < destination.Tables[14].Columns.Count ; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[14].Rows[0].ItemArray[i].ToString();
           // i = i + 1;
            li.Value = destination.Tables[14].Rows[0].ItemArray[i].ToString();
            dporderby.Items.Add(li);

        }


    }
    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objregion = new NewAdbooking.Report.classesoracle.billregister();
            ds = objregion.bindregionname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "sp_region_sp_region_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        //li1.Text = "--Select Region--";
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

   

    public void bindproductnamne()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.bindProductcategory(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objprod = new NewAdbooking.Report.classesoracle.billregister();
            ds = objprod.bindProductcategory(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "Websp_Product1_Websp_Product1_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
      
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
      
        dpproduct.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpproduct.Items.Add(li);
        }
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string temp1 = "", temp2 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "";
        string str = "";
        string str1 = "";
        string temp11 = dporderby.SelectedValue;
        string temp3 = dpcategory.SelectedValue;
        string adchk = "";
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
        

        if (bill.Checked == true)
            adchk = "1";
        else
            adchk = "2";

        for (int i = 1; i < dpproduct.Items.Count; i++)
        {

            if (dpproduct.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpproduct.Items[i].Value;
                    str1 = dpproduct.Items[i].Text;
                }
                else
                {
                    str = str + "," + dpproduct.Items[i].Value;
                    str1 = str1 + "," + dpproduct.Items[i].Text;
                }
            }
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
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
            if (adchk == "1")
                ds = obj.spproductreport(from_date, to_date, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), str, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, dppubcent.SelectedValue, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
                //ds = obj.spproductreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), dpproduct.SelectedValue, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, temp6, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedItem.Text, Session["userid"].ToString());

            else
                ds = obj.spproductreport(from_date, to_date, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), str, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, dppubcent.SelectedValue, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
              //  ds = obj.spproductreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), dpproduct.SelectedValue, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, temp6, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedValue, Session["userid"].ToString());
            
 

        }
       
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            if(adchk=="1")
                ds = obj.spproductreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), str, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, dppubcent.SelectedValue, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
            else
                ds = obj.spproductreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), str, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, dppubcent.SelectedValue, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedValue, Session["userid"].ToString(), Session["access"].ToString());
        }

        else
        {
            if (adchk == "1")
            {
                string procedureName = "Misreportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), str, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, dppubcent.SelectedValue, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                string procedureName = "Misreportnew";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), str, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, dppublication.SelectedValue, dppubcent.SelectedValue, temp7, temp8, temp9, temp10, temp11, adchk, dpagtype.SelectedValue, Session["userid"].ToString(), Session["access"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }


            
        }


        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(piproduct), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;
            Session["piproduct"] = ds;
            Session["prm_piproduct"] = "regcode~" + dpregion.SelectedValue + "~region~" + dpregion.SelectedItem.Text + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~destination~" + Txtdest.SelectedItem.Value + "~prodcode~" + str + "~product~" + str1 + "~uom~" + hiddendateformat2.Value + "~orderby~" + dporderby.SelectedValue + "~adtype~" + dpcategory.SelectedValue + "~adtypename~" + dpcategory.SelectedItem.Text + "~publication~" + dppublication.SelectedValue + "~publname~" + dppublication.SelectedItem.Text + "~adchk~" + adchk + "~agtype~" + dpagtype.SelectedValue + "~agtypetext~" + dpagtype.SelectedItem.Text + "~chk_excel~" + chk_excel;
            if (Txtdest.SelectedValue == "4")
                 Response.Redirect("piproductviewpage.aspx");   
            else
            ScriptManager.RegisterClientScriptBlock(this, typeof(piproduct), "sa", "window.open('piproductviewpage.aspx','_blank');", true);
         //   Response.Redirect("piproductviewpage.aspx");
            //Response.Redirect("piproductviewpage.aspx?regcode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&prodcode=" + str + "&product=" + str1 + "&uom=" + hiddendateformat2.Value + "&orderby=" + dporderby.SelectedValue + "&adtype=" + dpcategory.SelectedValue + "&adtypename=" + dpcategory.SelectedItem.Text + "&publication=" + dppublication.SelectedValue + "&publname=" + dppublication.SelectedItem.Text + "&adchk=" + adchk + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text);
        }
    }

    //string uom = "";
    //public void binduom()
    //{
       
    //     NewAdbooking.Classes.Class1 objprod = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();

    //    ds = objprod.spbinduom(Session["compcode"].ToString());
       

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
           

    //       hiddendateformat2 .Value  = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //    }


    //}

}
