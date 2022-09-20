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
public partial class Ageanalysis : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(Ageanalysis));
      
        
           
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

            lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
            lbcity.Text = "City";
           
             lbrev11.Text = "Revenue Center";
            lbPublicationCenter.Text = "Publication Center";
            BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            heading.Text = "Top Agency/Client Analysis Report";
            lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
           if (!IsPostBack)
            {
                publicationbind();
                binddest();
                bindteam();
                bindrev();
                bindstatus();
                bindadvtype();
                bindload();
                bindpub();
                BtnRun.Attributes.Add("OnClick", "javascript:return chkexenew();");
               // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
                //dprev11.Attributes.Add("onfocus", "javascript:return checkrundate1();");

                //txttodate1.Attributes.Add("onkeypress", "javascript:return extodate();");
                //txtfrmdate.Attributes.Add("onkeypress", "javascript:return exfromdate();");
                //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
                //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
                //txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
                //txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

                rdclient.Attributes.Add("onclick", "javascript:return radio('rdclient');");
                rdagency.Attributes.Add("onclick", "javascript:return radio('rdagency');");
                rdbilled.Attributes.Add("onclick", "javascript:return radio1('rdbilled');");
                rdsch.Attributes.Add("onclick", "javascript:return radio1('rdsch');");
                 dpedition.Attributes.Add("onkeypress", "return keySort(this);");
                dpexec11.Attributes.Add("onkeypress", "return keySort(this);");
                   dpcity.Attributes.Add("onkeypress", "return keySort(this);");
                dppubcent.Attributes.Add("onkeypress", "return keySort(this);");

                dppubcent.Attributes.Add("onchange", "javascript:return bind_edition9();");
                dppub1.Attributes.Add("onchange", "javascript:return bind_edition9();");
                dpcity.Attributes.Add("onchange", "javascript:return bind_executive();");
                Txtdest.Attributes.Add("onchange", "javascript:return excel_report();");
                exe.Attributes.Add("onclick", "javascript:return enable_exe();");
                csv.Attributes.Add("onclick", "javascript:return enable_csv();");
            }
        //}
    }

    public void bindload()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Executive Name--";
        li1.Value = "0";
        dpexec11.Items.Add(li1);

        ListItem li11;
        li11 = new ListItem();
        li11.Text = "--Select Edition Name--";
        li11.Value = "0";
        dpedition.Items.Add(li11);


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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "edition_proc_edition_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { pub, pub_cent, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
      [Ajax.AjaxMethod]
    public DataSet executive_bind(string compcode,string city)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Categorreport objregion = new NewAdbooking.Report.classesoracle.Categorreport();
            ds = objregion.bindexecutive(compcode, city);
        
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindexecutive(compcode, city);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Get_Execexec";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, city };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }

    
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string value = "";
        string check11 = "";
        string txtnorows11;
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
           
             if( txtnorows.Text == "")
             {
                 txtnorows11 = "20";
             }
             else
             {
                 txtnorows11 = txtnorows.Text;     
             }

             if (rdclient.Checked == true)
             {
                 check11 = "1";
               
             }

             else
             {
                 check11 = "2";
                
             }

             if (rdbilled.Checked == true)
             {
                 value = "1";
             }

             else
             {
                 value = "2";  
             }

             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {

                 NewAdbooking.Report.classesoracle.acdb obj = new NewAdbooking.Report.classesoracle.acdb();
                 ds = obj.ageana(dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dprev11.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpcity.SelectedValue, txtbill.Text, dppub1.SelectedValue, hiddenedition.Value, txtnorows11, check11, Session["userid"].ToString(), Session["access"].ToString());
             }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
             {
                 string procedureName = "Agencyana_agencyana_p";
                 NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                 string[] parameterValueArray1 = { dppubcent.SelectedValue, dpaddtype.SelectedValue, txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dprev11.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpcity.SelectedValue, txtbill.Text, dppub1.SelectedValue, hiddenedition.Value, txtnorows11, check11, Session["userid"].ToString(), Session["access"].ToString() };
                 string[] parameterValueArray = { txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dprev11.SelectedValue, dppubcent.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dpaddtype.SelectedValue, value, null, null, dpcity.SelectedValue, dppub1.SelectedValue, hiddenedition.Value, check11, txtnorows11, hiddenexecutive.Value, Session["userid"].ToString(), Session["access"].ToString(), null, null };
                 ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
                 ds = obj.ageana(dppubcent.SelectedValue, dpaddtype.SelectedValue, from_date, to_date, Session["compcode"].ToString(), dprev11.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), value, hiddenexecutive.Value, dpcity.SelectedValue, txtbill.Text, dppub1.SelectedValue, hiddenedition.Value, txtnorows11, check11, Session["userid"].ToString(), Session["access"].ToString());
 
                 }              
                      string editionname = "";
                     if(dppub1.SelectedValue != "0" )
                     {
//                         editionname = dpedition.SelectedItem.Text;
                         editionname = hiddeneditionname.Value;
                     }

                     string executivename = "";
                     if (dpcity.SelectedValue != "0")
                     {
                         //executivename = dpexec11.SelectedItem.Text;
                         executivename = hiddenexecutivename.Value;
                     }

                     Session["from"] = txtfrmdate.Text;
                     Session["to"] = txttodate1.Text;

                     
         if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Ageanalysis), "sa", "alert(\"searching criteria is not valid\");", true);
            return ;
         }
         else
         {
             Session["topcliage"] = ds;
             Session["prm_topcliage"] = "destination~" + Txtdest.SelectedValue + "~fromdate~" + txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~pubcent~" + dppubcent.SelectedValue + "~pubcentname~" + dppubcent.SelectedItem.Text + "~revenuecentercode~" + dprev11.SelectedValue + "~revenuecentername~" + dprev11.SelectedItem.Text + "~adtyp~" + dpaddtype.SelectedValue + "~adtypname~" + dpaddtype.SelectedItem.Text + "~value~" + value + "~bill~" + txtbill.Text + "~place~" + dpcity.SelectedValue + "~placename~" + dpcity.SelectedItem.Text + "~editioncode~" + hiddenedition.Value + "~editionname~" + hiddeneditionname.Value + "~check11~" + check11 + "~value1~" + value + "~publicationname~" + dppub1.SelectedItem.Text + "~publicationcode~" + dppub1.SelectedValue + "~executivecode~" + hiddenexecutive.Value + "~executivename~" + hiddenexecutivename.Value + "~noofrows11~" + txtnorows11 + "~chk_excel~" + chk_excel;
             Response.Redirect("ageanaview.aspx");
//             Response.Redirect("ageanaview.aspx?&destination=" + Txtdest.SelectedValue + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&pubcent=" + dppubcent.SelectedValue + "&pubcentname=" + dppubcent.SelectedItem.Text + "&revenuecentercode=" + dprev11.SelectedValue + "&revenuecentername=" + dprev11.SelectedItem.Text + "&adtyp=" + dpaddtype.SelectedValue + "&adtypname=" + dpaddtype.SelectedItem.Text + "&value=" + value + "&bill=" + txtbill.Text + "&place=" + dpcity.SelectedValue + "&placename=" + dpcity.SelectedItem.Text + "&editioncode=" + hiddenedition.Value+ "&editionname=" + hiddeneditionname.Value + "&check11=" + check11 + "&value1=" + value + "&publicationname=" + dppub1.SelectedItem.Text + "&publicationcode=" + dppub1.SelectedValue + "&executivecode=" + hiddenexecutive.Value + "&executivename=" + hiddenexecutivename.Value + "&noofrows11=" + txtnorows11);
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "pubcent_proc_pubcent_proc_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
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

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "RA_adbindcategory_RA_adbindcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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

    public void bindteam()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Categorreport advpub = new NewAdbooking.Report.classesoracle.Categorreport();
            ds = advpub.city(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.city(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_City";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
       // li1.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
        li1.Text = "--Select City--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpcity.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpcity.Items.Add(li);


        }
    }
  


    public void bindrev()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
     
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[31].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dprev11.Items.Add(li1);

        int i;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.bindrevenuecenter(Session["compcode"].ToString());

            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dprev11.Items.Add(li);


            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindrevenuecenter";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dprev11.Items.Add(li);


            }
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindrevenuecenter(Session["compcode"].ToString());

            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dprev11.Items.Add(li);


            }
        }
       
       
    }

    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT advpub = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = advpub.bindpublication(Session["compcode"].ToString());

           
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dppub1.Items.Add(li);


            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindpub11_bindpub11_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dppub1.Items.Add(li);
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppub1.Items.Add(li);


            }
        }    
     
    }
   
}
