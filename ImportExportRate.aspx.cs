using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Data.OleDb;
using System.Xml;
using System.Xml.Xsl;
using System.Text.RegularExpressions;
using System.Text;
public partial class ImportExportRate : System.Web.UI.Page
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
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }
        hiddendateformat.Value = Session["dateformat"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(ImportExportRate));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        if (!Page.IsPostBack)
        {
            bindratecode();
            fillPubCenter();
            adtypedata(Session["compcode"].ToString());
            hiddendateformat.Value = Session["dateformat"].ToString();
            //btnimport.Attributes.Add("OnClick", "javascript:return check1();");
            btnexport.Attributes.Add("OnClick", "javascript:return check();");
            rbsolo.Attributes.Add("OnClick", "javascript:return check2();");
            rbpackage.Attributes.Add("OnClick", "javascript:return check3();");
            drpadtype.Attributes.Add("OnChange", "javascript:return packagebind();");
        }
    }
    private void fillPubCenter()
    {
        DataSet ds;
        drppubcenter.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();

            ds = logindetail.getPubCenter();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();

            ds = logindetail.getPubCenter();

        }
        else
             {
                string procedureName = "websp_pubcenter_websp_pubcenter_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] ParmetterValueArray = { null };
                ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drppubcenter.Items.Add(li1);
        string[] drptext;
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().IndexOf("(") > 0)
            {
                drptext = ds.Tables[0].Rows[i].ItemArray[1].ToString().Split('(');
                li.Text = drptext[0];
            }
            else
            {
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            }
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drppubcenter.Items.Add(li);
        }

    }
    public void bindratecode()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.DealReport advname = new NewAdbooking.Report.Classes.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.DealReport advname = new NewAdbooking.Report.classesoracle.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "adb_bindratecode";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { Session["compcode"].ToString(),null,null };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select RateCode--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpratecode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpratecode.Items.Add(li);
        }
    }
   
    public void adtypedata(string compcode)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 bind = new NewAdbooking.Classes.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = bind.adtypbind(compcode);

        }
        else
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }

    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string solo = "S";
        string pakage = "";
        if (rbpackage.Checked == true)
        {
            solo = "P";
        }
        //=====***** For  Rate code ******======//
        string ratecode = "";
        for (int x = 0; x < dpratecode.Items.Count; x++)
        {
            if (dpratecode.Items[x].Selected == true && dpratecode.Items[x].Value != "0")
            {
                if (ratecode == "")
                    ratecode = dpratecode.Items[x].Value;
                else
                    ratecode = ratecode + "," + dpratecode.Items[x].Value;
            }
        }
        //=================for seprate pages==========
        string edition = "";
        if (solo == "S")
        {
            if (rdall.Checked == true)
            {
                edition = "A";
            }
            else if (rdmain.Checked == true)
            {
                edition = "M";
            }
            else if (rdsubedition.Checked == true)
            {
                edition = "E";
            }
            else if (rdsupplement.Checked == true)
            {
                edition = "S";
            }
            else
                edition = "";
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.importexport cls = new NewAdbooking.Classes.importexport();
            ds = cls.getData(drpadtype.SelectedValue, txtvalidityfrom.Text, txttilldate.Text, Session["dateformat"].ToString(), solo, ratecode, drppubcenter.SelectedValue, edition, packagecode1.Value, hiddenadcategary.Value, Hiddenumo.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.importexport cls = new NewAdbooking.classesoracle.importexport();
            ds = cls.getData(drpadtype.SelectedValue, txtvalidityfrom.Text, txttilldate.Text, Session["dateformat"].ToString(), solo, ratecode, drppubcenter.SelectedValue, edition, packagecode1.Value, hiddenadcategary.Value, Hiddenumo.Value);
        }
        else
        {
            string procedureName = "getData_Export";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { drpadtype.SelectedValue, txtvalidityfrom.Text, txttilldate.Text, solo, ratecode, drppubcenter.SelectedValue, edition, packagecode1.Value, hiddenadcategary.Value, Hiddenumo.Value, Session["dateformat"].ToString(), null, null, null, null };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
       // WorkbookEngine.CreateWorkbook(ds, FileUpload1.PostedFile.FileName);
        /*Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        // Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/csv";
        System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
        grid.HeaderStyle.Font.Bold = true;
        grid.DataSource = ds;
        grid.DataMember = ds.Tables[0].TableName;

        grid.DataBind();

        // render the DataGrid control to a file

        using (StreamWriter sw = new StreamWriter(FileUpload1.PostedFile.FileName))
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grid.RenderControl(hw);
            }
        }

*/      Session["RateCard"] = ds;
        string chk_excel="";
        if (RadioButton1.Checked == true)
        {
          chk_excel = "1";
        }
        Response.Redirect("importrateview.aspx?chk_excel=" + chk_excel+ "");       
    }
    public class WorkbookEngine
    {

        public static void CreateWorkbook(DataSet ds, String path)
        {
            
            XmlDataDocument xmlDataDoc = new XmlDataDocument(ds);
            XslTransform xt = new XslTransform();
            StreamReader reader = new StreamReader(typeof(WorkbookEngine).Assembly.GetManifestResourceStream(typeof(WorkbookEngine), "Excel.xsl"));
            //StreamReader reader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WorkbookEngine.Resources.Excel.xsl"));
            XmlTextReader xRdr = new XmlTextReader(reader);
            xt.Load(xRdr, null, null);

            StringWriter sw = new StringWriter();
            xt.Transform(xmlDataDoc, null, sw, null);

            StreamWriter myWriter = new StreamWriter(path);
            myWriter.Write(sw.ToString());
            myWriter.Close();
        }
    }
void Read_Excel()
{
    if (ViewState["Path"] == null)
    {
        lblerror.Text = "Please Upload Excel First";
        return;
    }
    if (RadioButton1.Checked == true)
    {
        string filepath = ViewState["Path"].ToString();//upload_voucher_xml.PostedFile.FileName;
        //string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";
        OleDbConnection oledbConn = new OleDbConnection(connString);
        int kk = 0;
        string alreadyhave = "";
        try
        {
            oledbConn.Open();
            // Create OleDbCommand object and select data from worksheet Sheet1
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [SHEET1$]", oledbConn);


            // Create new OleDbDataAdapter
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            oleda.SelectCommand = cmd;
            // Create a DataSet which will hold the data extracted from the worksheet.
            DataSet ds = new DataSet();
            // Fill the DataSet from the data extracted from the worksheet.
            oleda.Fill(ds);
            /*

                string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + filepath + ";";
                connectionString += "Extended Properties=Excel 8.0;";


            // always read from the sheet1.

                OleDbCommand myCommand = new OleDbCommand("Select * from [Rate Card$];");
                OleDbConnection myConnection = new OleDbConnection(connectionString);

                myConnection.Open();

                myCommand.Connection = myConnection;

                DataTable dt = new DataTable();
                dt = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);



                //String[] excelSheets = new String[dt.Rows.Count];
                //int i = 0;

                // Add the sheet name to the string array.
                //foreach (DataRow row in dt.Rows)
                //{
                //    excelSheets[i] = row["TABLE_NAME"].ToString();
                //    i++;
                //}

                //OleDbDataReader myReader = myCommand.ExecuteReader();*/
            string prevcioid = "";
            string solo = "S";
            if (rbpackage.Checked == true)
            {
                solo = "P";
            }
            //while (myReader.Read())
            //{
            int lenghh = ds.Tables[0].Rows.Count;
            for (; kk < ds.Tables[0].Rows.Count; kk++)
            {
                // it can read upto 5 columns means A to E. In your case if the requirement is different then change the loop limits a/c to it.
                string pubcenter = ds.Tables[0].Rows[kk]["pub_center"].ToString();
                if (pubcenter.IndexOf("'") >= 0)
                    pubcenter = pubcenter.Replace("'", "");
                string ratecode = ds.Tables[0].Rows[kk]["Rate_Mast_Code"].ToString();
                string adtype = ds.Tables[0].Rows[kk]["Adv_Type_Code"].ToString();
                string adcategory = ds.Tables[0].Rows[kk]["Adv_Cat_Code"].ToString();
                if (adcategory.IndexOf("'") >= 0)
                    adcategory = adcategory.Replace("'", "");
                string adsubcategory = ds.Tables[0].Rows[kk]["Adv_subcat_code"].ToString();
                if (adsubcategory.IndexOf("'") >= 0)
                    adsubcategory = adsubcategory.Replace("'", "");
                //if (adsubcategory == "'0")
                //    adsubcategory = "0";
                //if (kk == 355)
                //{
                //    string color1 = ds.Tables[0].Rows[kk]["Color"].ToString();
                //}
                string color = ds.Tables[0].Rows[kk]["Color"].ToString();
                string packagecode = ds.Tables[0].Rows[kk]["Combin_Code"].ToString();
                string currency = ds.Tables[0].Rows[kk]["Currency"].ToString();
                string frdate = ds.Tables[0].Rows[kk]["Valid_From"].ToString();
                DateTime date = DateTime.Parse(frdate);
                String dateInString = date.ToString("dd/MM/yyyy");
                string Valid_From = dateInString;
                //if (fromdate != "")
                //    fromdate = DMYToMDY(fromdate);
                //fromdate = Convert.ToDateTime(fromdate).Date.ToShortDateString();
                string tidate = ds.Tables[0].Rows[kk]["Valid_To"].ToString();
                DateTime date1 = DateTime.Parse(tidate);
                String dateInString1 = date1.ToString("dd/MM/yyyy");
                string Valid_To = dateInString1;
                //if (tilldate != "")
                //    tilldate = Convert.ToDateTime(tilldate).Date.ToShortDateString();
                string uom = ds.Tables[0].Rows[kk]["Uom"].ToString();
                string adscat4 = ds.Tables[0].Rows[kk]["Ad_Subcat4"].ToString();
                if (adscat4.IndexOf("'") >= 0)
                    adscat4 = adscat4.Replace("'", "");
                string adscat5 = ds.Tables[0].Rows[kk]["Ad_Subcat5"].ToString();
                if (adscat5.IndexOf("'") >= 0)
                    adscat5 = adscat5.Replace("'", "");
                string adscat6 = ds.Tables[0].Rows[kk]["Ad_subcat6"].ToString();
                if (adscat6.IndexOf("'") >= 0)
                    adscat6 = adscat6.Replace("'", "");
                string premium = ds.Tables[0].Rows[kk]["Premium"].ToString();
                if (premium.IndexOf("'") >= 0)
                    premium = premium.Replace("'", "");
                //if (premium == "'0")
                //    premium = "0";
                string sizefrom = ds.Tables[0].Rows[kk]["Size_From"].ToString();
                string sizeto = ds.Tables[0].Rows[kk]["Size_To"].ToString();
                string txtfrominsert = ds.Tables[0].Rows[kk]["From_insertion"].ToString();
                string txttoinsert = ds.Tables[0].Rows[kk]["To_insertion"].ToString();
                string clientcat = ds.Tables[0].Rows[kk]["Client_cat"].ToString();

                string comp_code = ds.Tables[0].Rows[kk]["Comp_code"].ToString();
                string userid = "Excelc";// ds.Tables[0].Rows[kk]["userid"].ToString();
                string rategrpcode = ds.Tables[0].Rows[kk]["Rate_Gr_Code"].ToString();
                string combin_Desc = ds.Tables[0].Rows[kk]["combin_desc"].ToString();
                string consumption_Per = ds.Tables[0].Rows[kk]["consumption_Per"].ToString();
                string Col_chr_typ = ds.Tables[0].Rows[kk]["Col_chr_typ"].ToString();
                string Week_Day_Rate = ds.Tables[0].Rows[kk]["Week_Day_Rate"].ToString();
                string Week_min_rate = ds.Tables[0].Rows[kk]["Week_min_rate"].ToString();
                string Week_Extra_Rate = ds.Tables[0].Rows[kk]["Week_Extra_Rate"].ToString();
                string Focus_Day_Rate = ds.Tables[0].Rows[kk]["Focus_Day_Rate"].ToString();
                string Focus_min_rate = ds.Tables[0].Rows[kk]["Focus_min_rate"].ToString();
                string Focus_extra_rate = ds.Tables[0].Rows[kk]["Focus_extra_rate"].ToString();
                // string Valid_From = ds.Tables[0].Rows[kk]["Valid_From"].ToString();
                //string Valid_To = ds.Tables[0].Rows[kk]["Valid_To"].ToString();
                string Remarks = ds.Tables[0].Rows[kk]["Remarks"].ToString();
                string Premium_Charges = ds.Tables[0].Rows[kk]["Premium_Charges"].ToString();
                string weekend_rate = ds.Tables[0].Rows[kk]["weekend_rate"].ToString();
                string weekend_min_rate = ds.Tables[0].Rows[kk]["weekend_min_rate"].ToString();
                string weekend_extra = ds.Tables[0].Rows[kk]["weekend_extra"].ToString();
                string min_ad_area = ds.Tables[0].Rows[kk]["min_ad_area"].ToString();
                string Edition_from = ds.Tables[0].Rows[kk]["Edition_from"].ToString();
                string Edition_to = ds.Tables[0].Rows[kk]["Edition_to"].ToString();
                string floor_amount = ds.Tables[0].Rows[kk]["floor_amount"].ToString();
                string floor_discount = ds.Tables[0].Rows[kk]["floor_discount"].ToString();
                string Scheme_Name = ds.Tables[0].Rows[kk]["Scheme_Name"].ToString();
                if (Scheme_Name.IndexOf("'") >= 0)
                    Scheme_Name = Scheme_Name.Replace("'", "");
                string Agency_type = ds.Tables[0].Rows[kk]["Agency_type"].ToString();
                string Client_cat = ds.Tables[0].Rows[kk]["Client_cat"].ToString();
                string Max_Area = ds.Tables[0].Rows[kk]["Max_Area"].ToString();
                string SUN_RATE = ds.Tables[0].Rows[kk]["SUN_RATE"].ToString();
                string MON_RATE = ds.Tables[0].Rows[kk]["MON_RATE"].ToString();
                string TUE_RATE = ds.Tables[0].Rows[kk]["TUE_RATE"].ToString();
                string WED_RATE = ds.Tables[0].Rows[kk]["WED_RATE"].ToString();
                string THU_RATE = ds.Tables[0].Rows[kk]["THU_RATE"].ToString();
                string FRI_RATE = ds.Tables[0].Rows[kk]["FRI_RATE"].ToString();
                string SAT_RATE = ds.Tables[0].Rows[kk]["SAT_RATE"].ToString();
                string SUN_RATE_EXTRA = ds.Tables[0].Rows[kk]["SUN_RATE_EXTRA"].ToString();
                string MON_RATE_EXTRA = ds.Tables[0].Rows[kk]["MON_RATE_EXTRA"].ToString();
                string TUE_RATE_EXTRA = ds.Tables[0].Rows[kk]["TUE_RATE_EXTRA"].ToString();
                string WED_RATE_EXTRA = ds.Tables[0].Rows[kk]["WED_RATE_EXTRA"].ToString();
                string THU_RATE_EXTRA = ds.Tables[0].Rows[kk]["THU_RATE_EXTRA"].ToString();
                string FRI_RATE_EXTRA = ds.Tables[0].Rows[kk]["FRI_RATE_EXTRA"].ToString();
                string SAT_RATE_EXTRA = ds.Tables[0].Rows[kk]["SAT_RATE_EXTRA"].ToString();
                string MAXWIDTH = ds.Tables[0].Rows[kk]["MAXWIDTH"].ToString();
                string CANCELLATION_CHARGES = "0";// ds.Tables[0].Rows[kk]["CANCELLATION_CHARGES"].ToString();
                string rateuniqueofexcel = ds.Tables[0].Rows[kk]["rateuniqueid"].ToString();

                //string rate_code = myReader["rate_code"].ToString();

                //for detail
                /* string Week_Day_Rate1=myReader["Week_Day_Rate1"].ToString();
                 string Focus_Day_Rate1=myReader["Focus_Day_Rate1"].ToString();
                 string edition_name=myReader["edition_name"].ToString();
                 string Solus_week_rate=myReader["Solus_week_rate"].ToString();
                 string Solus_focus_rate=myReader["Solus_focus_rate"].ToString();
                 string weekend_rate1=myReader["weekend_rate1"].ToString();
                 string Solo_weekendrate=myReader["Solo_weekendrate"].ToString();
                 string Week_Extra_Rate1=myReader["Week_Extra_Rate1"].ToString();
                 string SUN_RATE1=myReader["SUN_RATE1"].ToString();
                 string MON_RATE1=myReader["MON_RATE1"].ToString();
                 string TUE_RATE1=myReader["TUE_RATE1"].ToString();
                 string WED_RATE1=myReader["WED_RATE1"].ToString();
                 string THU_RATE1=myReader["THU_RATE1"].ToString();
                 string FRI_RATE1=myReader["FRI_RATE1"].ToString();
                 string SAT_RATE1=myReader["SAT_RATE1"].ToString();
                 string SUN_RATE_EXTRA1=myReader["SUN_RATE_EXTRA1"].ToString();
                 string MON_RATE_EXTRA1=myReader["MON_RATE_EXTRA1"].ToString();
                 string TUE_RATE_EXTRA1=myReader["TUE_RATE_EXTRA1"].ToString();
                 string WED_RATE_EXTRA1=myReader["WED_RATE_EXTRA1"].ToString();
                 string THU_RATE_EXTRA1=myReader["THU_RATE_EXTRA1"].ToString();
                 string FRI_RATE_EXTRA1=myReader["FRI_RATE_EXTRA1"].ToString();
                 string SAT_RATE_EXTRA1=myReader["SAT_RATE_EXTRA1"].ToString();
             */
                string rateuniqueid = pubcenter + ratecode + adtype + adcategory + adsubcategory + color + packagecode + currency + Valid_From + Valid_To + uom + adscat4 + adscat5 + adscat6 + premium + sizefrom + sizeto + txtfrominsert + txttoinsert + clientcat;
                if (rateuniqueid == "0CORPTDI0EN0BRP122RU120/04/201231/12/2020SQ000000019990")
                {
                    lblerror.Text = "";
                }
                //try
                //{
                // if (prevcioid == "")
                // saverate(comp_code, userid, ratecode, adtype, rategrpcode, adcategory, currency, adsubcategory, packagecode, combin_Desc, uom, sizefrom, sizeto, consumption_Per, color, Col_chr_typ, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, Valid_From, Valid_To, Remarks, premium, Premium_Charges, rateuniqueid, weekend_rate, weekend_min_rate, weekend_extra, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, Agency_type, Client_cat, Max_Area, "company", "", "dd/mm/yyyy", pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, MAXWIDTH, "", CANCELLATION_CHARGES);//myReader["PRIORITY);

                //if (myReader["ratemastid"].ToString() != "")
                if (combin_Desc.IndexOf('+') > 0)
                {
                    //Check for solo Rate of Packages....
                    string res = getsoloname(rateuniqueid, comp_code, packagecode, Week_Day_Rate, Focus_Day_Rate, ratecode, adtype, adcategory, adsubcategory, color, currency, Valid_From, Valid_To, weekend_rate, "decimalvalue", uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, min_ad_area, "company", "agency_code", Session["dateformat"].ToString(), pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, Week_Extra_Rate);
                    if (res != "")
                    {
                        lblerror.Text = res + " Edition Solo Rate Has Not Been Assigned for RateUniqueid :" + rateuniqueid + "in Row :" + (kk + 2);
                        //myConnection.Close();
                        // return;
                        if (alreadyhave == "")
                            alreadyhave = res + ":" + rateuniqueid;
                        else
                            alreadyhave += "," + res + ":" + rateuniqueid;
                    }
                    else
                    {
                        saverate(comp_code, userid, ratecode, adtype, rategrpcode, adcategory, currency, adsubcategory, packagecode, combin_Desc, uom, sizefrom, sizeto, consumption_Per, color, Col_chr_typ, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, Valid_From, Valid_To, Remarks, premium, Premium_Charges, rateuniqueid, weekend_rate, weekend_min_rate, weekend_extra, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, Agency_type, Client_cat, Max_Area, "company", "", "dd/mm/yyyy", pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, MAXWIDTH, "", CANCELLATION_CHARGES);//myReader["PRIORITY);
                        Detailsaverate(rateuniqueid, comp_code, packagecode, Week_Day_Rate, Focus_Day_Rate, ratecode, adtype, adcategory, adsubcategory, color, currency, Valid_From, Valid_To, weekend_rate, "decimalvalue", uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, min_ad_area, "company", "agency_code", Session["dateformat"].ToString(), pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, Week_Extra_Rate, userid);
                    }
                    // (rateuniqueid, compcode, packagecode, weekdrate, focusdarate, ratecode,       adtype, adcategory, adsubcategory, color, currency, fromdate, tilldateweekendrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium,sizefrom,sizeto,txtfrominsert,txttoinsert, clientcat, minadarea, "company", agency_code, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, extweerate, userid);
                    // saverateDetails(Week_Day_Rate1, Focus_Day_Rate1, rate_code, comp_code, userid, edition_name, rateuniqueid, Solus_week_rate, Solus_focus_rate, weekend_rate1, Solo_weekendrate, "company", Week_Extra_Rate1, SUN_RATE1, MON_RATE1, TUE_RATE1, WED_RATE1, THU_RATE1, FRI_RATE1, SAT_RATE1, SUN_RATE_EXTRA1, MON_RATE_EXTRA1, TUE_RATE_EXTRA1, WED_RATE_EXTRA1, THU_RATE_EXTRA1, FRI_RATE_EXTRA1, SAT_RATE_EXTRA1, adtype, pubcenter);
                    // prevcioid = rateuniqueid;
                }
                else
                {
                    saverate(comp_code, userid, ratecode, adtype, rategrpcode, adcategory, currency, adsubcategory, packagecode, combin_Desc, uom, sizefrom, sizeto, consumption_Per, color, Col_chr_typ, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, Valid_From, Valid_To, Remarks, premium, Premium_Charges, rateuniqueid, weekend_rate, weekend_min_rate, weekend_extra, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, Agency_type, Client_cat, Max_Area, "company", "", "dd/mm/yyyy", pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, MAXWIDTH, "", CANCELLATION_CHARGES);//myReader["PRIORITY);
                }
                // else
                //   prevcioid = "";
                //}
                //catch (Exception ex)
                //{
                //    if (alreadyhave == "")
                //        alreadyhave = rateuniqueid;
                //    else
                //        alreadyhave = alreadyhave + "," + rateuniqueid;
                //   //lblerror.Text = ex.Message;
                //   // return;
                //}
                //for (int i1 = 0; i1 < myReader.FieldCount; i1++)

                //{

                //    Response.Write(myReader[i1].ToString() + " ");

                //}

                //Response.Write("<br>");

            }
        }
        catch (Exception e1)
        {
            string errmsg = "Error in Line " + kk + ": " + e1.Message;
            Response.Write("<script>alert('" + errmsg + "');</script>");
            //lblerror.Text = errmsg;
            // return;
        }
        finally
        {
            // Close connection
            lblerror.Text = alreadyhave;
            oledbConn.Close();
        } 
    }
    else
    {
        string filepath = ViewState["Path"].ToString();//upload_voucher_xml.PostedFile.FileName;
        int kk = 0;
        string alreadyhave = "";
        try
        {
            if (RadioButton1.Checked == true)
            {

            }
            else
            {
                DataSet ds = GetData1(filepath);
                string prevcioid = "";
                string solo = "S";
                if (rbpackage.Checked == true)
                {
                    solo = "P";
                }
                int lenghh = ds.Tables[0].Rows.Count;
                for (kk = 0; kk < lenghh; kk++)
                {
                    string pubcenter = ds.Tables[0].Rows[kk]["pub_center"].ToString();
                    if (pubcenter.IndexOf("'") >= 0)
                        pubcenter = pubcenter.Replace("'", "");
                    string ratecode = ds.Tables[0].Rows[kk]["Rate_Mast_Code"].ToString();
                    string adtype = ds.Tables[0].Rows[kk]["Adv_Type_Code"].ToString();
                    string adcategory = ds.Tables[0].Rows[kk]["Adv_Cat_Code"].ToString();
                    if (adcategory.IndexOf("'") >= 0)
                        adcategory = adcategory.Replace("'", "");
                    string adsubcategory = ds.Tables[0].Rows[kk]["Adv_subcat_code"].ToString();
                    if (adsubcategory.IndexOf("'") >= 0)
                        adsubcategory = adsubcategory.Replace("'", "");
                    string color = ds.Tables[0].Rows[kk]["Color"].ToString();
                    string packagecode = ds.Tables[0].Rows[kk]["Combin_Code"].ToString();
                    string currency = ds.Tables[0].Rows[kk]["Currency"].ToString();
                    string frdate = ds.Tables[0].Rows[kk]["Valid_From"].ToString();
                    string Valid_From = ds.Tables[0].Rows[kk]["Valid_From"].ToString();
                    string tidate = ds.Tables[0].Rows[kk]["Valid_To"].ToString();
                    string Valid_To = ds.Tables[0].Rows[kk]["Valid_To"].ToString();
                    string uom = ds.Tables[0].Rows[kk]["Uom"].ToString();
                    string adscat4 = ds.Tables[0].Rows[kk]["Ad_Subcat4"].ToString();
                    if (adscat4.IndexOf("'") >= 0)
                        adscat4 = adscat4.Replace("'", "");
                    string adscat5 = ds.Tables[0].Rows[kk]["Ad_Subcat5"].ToString();
                    if (adscat5.IndexOf("'") >= 0)
                        adscat5 = adscat5.Replace("'", "");
                    string adscat6 = ds.Tables[0].Rows[kk]["Ad_subcat6"].ToString();
                    if (adscat6.IndexOf("'") >= 0)
                        adscat6 = adscat6.Replace("'", "");
                    string premium = ds.Tables[0].Rows[kk]["Premium"].ToString();
                    if (premium.IndexOf("'") >= 0)
                        premium = premium.Replace("'", "");
                    string sizefrom = ds.Tables[0].Rows[kk]["Size_From"].ToString();
                    string sizeto = ds.Tables[0].Rows[kk]["Size_To"].ToString();
                    string txtfrominsert = ds.Tables[0].Rows[kk]["From_insertion"].ToString();
                    string txttoinsert = ds.Tables[0].Rows[kk]["To_insertion"].ToString();
                    string clientcat = ds.Tables[0].Rows[kk]["Client_cat"].ToString();
                    string comp_code = ds.Tables[0].Rows[kk]["Comp_code"].ToString();
                    string userid = "Excelc";// ds.Tables[0].Rows[kk]["userid"].ToString();
                    string rategrpcode = ds.Tables[0].Rows[kk]["Rate_Gr_Code"].ToString();
                    string combin_Desc = ds.Tables[0].Rows[kk]["combin_desc"].ToString();
                    string consumption_Per = ds.Tables[0].Rows[kk]["consumption_Per"].ToString();
                    string Col_chr_typ = ds.Tables[0].Rows[kk]["Col_chr_typ"].ToString();
                    string Week_Day_Rate = ds.Tables[0].Rows[kk]["Week_Day_Rate"].ToString();
                    string Week_min_rate = ds.Tables[0].Rows[kk]["Week_min_rate"].ToString();
                    string Week_Extra_Rate = ds.Tables[0].Rows[kk]["Week_Extra_Rate"].ToString();
                    string Focus_Day_Rate = ds.Tables[0].Rows[kk]["Focus_Day_Rate"].ToString();
                    string Focus_min_rate = ds.Tables[0].Rows[kk]["Focus_min_rate"].ToString();
                    string Focus_extra_rate = ds.Tables[0].Rows[kk]["Focus_extra_rate"].ToString();
                    string Remarks = ds.Tables[0].Rows[kk]["Remarks"].ToString();
                    string Premium_Charges = ds.Tables[0].Rows[kk]["Premium_Charges"].ToString();
                    string weekend_rate = ds.Tables[0].Rows[kk]["weekend_rate"].ToString();
                    string weekend_min_rate = ds.Tables[0].Rows[kk]["weekend_min_rate"].ToString();
                    string weekend_extra = ds.Tables[0].Rows[kk]["weekend_extra"].ToString();
                    string min_ad_area = ds.Tables[0].Rows[kk]["min_ad_area"].ToString();
                    string Edition_from = ds.Tables[0].Rows[kk]["Edition_from"].ToString();
                    string Edition_to = ds.Tables[0].Rows[kk]["Edition_to"].ToString();
                    string floor_amount = ds.Tables[0].Rows[kk]["floor_amount"].ToString();
                    string floor_discount = ds.Tables[0].Rows[kk]["floor_discount"].ToString();
                    string Scheme_Name = ds.Tables[0].Rows[kk]["Scheme_Name"].ToString();
                    if (Scheme_Name.IndexOf("'") >= 0)
                        Scheme_Name = Scheme_Name.Replace("'", "");
                    string Agency_type = ds.Tables[0].Rows[kk]["Agency_type"].ToString();
                    string Client_cat = ds.Tables[0].Rows[kk]["Client_cat"].ToString();
                    string Max_Area = ds.Tables[0].Rows[kk]["Max_Area"].ToString();
                    string SUN_RATE = ds.Tables[0].Rows[kk]["SUN_RATE"].ToString();
                    string MON_RATE = ds.Tables[0].Rows[kk]["MON_RATE"].ToString();
                    string TUE_RATE = ds.Tables[0].Rows[kk]["TUE_RATE"].ToString();
                    string WED_RATE = ds.Tables[0].Rows[kk]["WED_RATE"].ToString();
                    string THU_RATE = ds.Tables[0].Rows[kk]["THU_RATE"].ToString();
                    string FRI_RATE = ds.Tables[0].Rows[kk]["FRI_RATE"].ToString();
                    string SAT_RATE = ds.Tables[0].Rows[kk]["SAT_RATE"].ToString();
                    string SUN_RATE_EXTRA = ds.Tables[0].Rows[kk]["SUN_RATE_EXTRA"].ToString();
                    string MON_RATE_EXTRA = ds.Tables[0].Rows[kk]["MON_RATE_EXTRA"].ToString();
                    string TUE_RATE_EXTRA = ds.Tables[0].Rows[kk]["TUE_RATE_EXTRA"].ToString();
                    string WED_RATE_EXTRA = ds.Tables[0].Rows[kk]["WED_RATE_EXTRA"].ToString();
                    string THU_RATE_EXTRA = ds.Tables[0].Rows[kk]["THU_RATE_EXTRA"].ToString();
                    string FRI_RATE_EXTRA = ds.Tables[0].Rows[kk]["FRI_RATE_EXTRA"].ToString();
                    string SAT_RATE_EXTRA = ds.Tables[0].Rows[kk]["SAT_RATE_EXTRA"].ToString();
                    string MAXWIDTH = ds.Tables[0].Rows[kk]["MAXWIDTH"].ToString();
                    string CANCELLATION_CHARGES = "0";// ds.Tables[0].Rows[kk]["CANCELLATION_CHARGES"].ToString();
                    string rateuniqueofexcel = ds.Tables[0].Rows[kk]["rateuniqueid"].ToString();
                    string rateuniqueid = pubcenter + ratecode + adtype + adcategory + adsubcategory + color + packagecode + currency + Valid_From + Valid_To + uom + adscat4 + adscat5 + adscat6 + premium + sizefrom + sizeto + txtfrominsert + txttoinsert + clientcat;
                    if (rateuniqueid == "0CORPTDI0EN0BRP122RU120/04/201231/12/2020SQ000000019990")
                    {
                        lblerror.Text = "";
                    }
                    if (combin_Desc.IndexOf('+') > 0)
                    {
                        string res = getsoloname(rateuniqueid, comp_code, packagecode, Week_Day_Rate, Focus_Day_Rate, ratecode, adtype, adcategory, adsubcategory, color, currency, Valid_From, Valid_To, weekend_rate, "decimalvalue", uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, min_ad_area, "company", "agency_code", Session["dateformat"].ToString(), pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, Week_Extra_Rate);
                        if (res != "")
                        {
                            lblerror.Text = res + " Edition Solo Rate Has Not Been Assigned for RateUniqueid :" + rateuniqueid + "in Row :" + (kk + 2);
                            if (alreadyhave == "")
                                alreadyhave = res + ":" + rateuniqueid;
                            else
                                alreadyhave += "," + res + ":" + rateuniqueid;
                        }
                        else
                        {
                            saverate(comp_code, userid, ratecode, adtype, rategrpcode, adcategory, currency, adsubcategory, packagecode, combin_Desc, uom, sizefrom, sizeto, consumption_Per, color, Col_chr_typ, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, Valid_From, Valid_To, Remarks, premium, Premium_Charges, rateuniqueid, weekend_rate, weekend_min_rate, weekend_extra, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, Agency_type, Client_cat, Max_Area, "company", "", "dd/mm/yyyy", pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, MAXWIDTH, "", CANCELLATION_CHARGES);//myReader["PRIORITY);
                            Detailsaverate(rateuniqueid, comp_code, packagecode, Week_Day_Rate, Focus_Day_Rate, ratecode, adtype, adcategory, adsubcategory, color, currency, Valid_From, Valid_To, weekend_rate, "decimalvalue", uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, txtfrominsert, txttoinsert, clientcat, min_ad_area, "company", "agency_code", Session["dateformat"].ToString(), pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, Week_Extra_Rate, userid);
                        }
                    }
                    else
                    {
                        saverate(comp_code, userid, ratecode, adtype, rategrpcode, adcategory, currency, adsubcategory, packagecode, combin_Desc, uom, sizefrom, sizeto, consumption_Per, color, Col_chr_typ, Week_Day_Rate, Week_min_rate, Week_Extra_Rate, Focus_Day_Rate, Focus_min_rate, Focus_extra_rate, Valid_From, Valid_To, Remarks, premium, Premium_Charges, rateuniqueid, weekend_rate, weekend_min_rate, weekend_extra, min_ad_area, Edition_from, Edition_to, floor_amount, floor_discount, Scheme_Name, adscat4, adscat5, adscat6, txtfrominsert, txttoinsert, Agency_type, Client_cat, Max_Area, "company", "", "dd/mm/yyyy", pubcenter, SUN_RATE, MON_RATE, TUE_RATE, WED_RATE, THU_RATE, FRI_RATE, SAT_RATE, SUN_RATE_EXTRA, MON_RATE_EXTRA, TUE_RATE_EXTRA, WED_RATE_EXTRA, THU_RATE_EXTRA, FRI_RATE_EXTRA, SAT_RATE_EXTRA, MAXWIDTH, "", CANCELLATION_CHARGES);//myReader["PRIORITY);
                    }
                }
            }
        }
        catch (Exception e1)
        {
            string errmsg = "Error in Line " + kk + ": " + e1.Message;
            Response.Write("<script>alert('" + errmsg + "');</script>");
        }
        finally
        {
            lblerror.Text = alreadyhave;
        }
    }

}
    public string getsoloname(string rateid, string compcode, string pkgcode, string rate, string focusrate, string ratecode, string adtype, string adcategory, string subcategory, string color, string currency, string validfromdate1, string validtill1, string weekrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minarea, string type_, string agencycode, string dateformat, string pubcenter, string ratesun, string ratemon, string ratetue, string ratewed, string ratethu, string ratefri, string ratesat, string ratesunextra, string ratemonextra, string ratetueextra, string ratewedextra, string ratethuextra, string ratefriextra, string ratesatextra, string extrarate)
    {
        DataSet ds = new DataSet();
        string returnvalue = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binddescrip = new NewAdbooking.Classes.RateMaster();
            ds = binddescrip.modifygrid(compcode, pkgcode, rate, focusrate, ratecode, adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, weekrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, extrarate);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster binddescrip = new NewAdbooking.classesoracle.RateMaster();
            ds = binddescrip.modifygrid(compcode, pkgcode, rate, focusrate, ratecode, adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, weekrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, extrarate);

        }
        else
        {
            string procedureName = "ratemodifygrid_ratemodifygrid_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode, pkgcode, rate, focusrate, ratecode, adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, weekrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, extrarate };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
       

        if (ds.Tables[0].Rows.Count > 1)
        {
            //hiddenchkcount.Value = "1";
            for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
            {
                DataSet dpck = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.RateMaster chkpac = new NewAdbooking.Classes.RateMaster();
                    dpck = chkpac.checkpackage(ds.Tables[0].Rows[x].ItemArray[18].ToString(), compcode, "1", ratecode, adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.RateMaster chkpac = new NewAdbooking.classesoracle.RateMaster();
                    dpck = chkpac.checkpackage(ds.Tables[0].Rows[x].ItemArray[18].ToString(), compcode, "1", ratecode, adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter);
                }
                else
                {
                    string procedureName = "chkpackagecode_chkpackagecode_p";
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    string[] ParmetterValueArray = { ds.Tables[0].Rows[x].ItemArray[18].ToString(), compcode, "1", ratecode, adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter };
                    ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
                }
              
                if (dpck.Tables[0].Rows.Count <= 0)
                {
                    returnvalue = ds.Tables[0].Rows[x].ItemArray[27].ToString();
                    return returnvalue;
                }

            }

        }

        return returnvalue;

    }
    public void Detailsaverate(string rateid, string compcode, string pkgcode, string wrate, string o_focusrate, string ratecode, string adtype, string adcategory, string subcategory, string color, string currency, string validfromdate1, string validtill1, string weekrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minarea, string type_, string agencycode, string dateformat, string pubcenter, string ratesun, string ratemon, string ratetue, string ratewed, string ratethu, string ratefri, string ratesat, string ratesunextra, string ratemonextra, string ratetueextra, string ratewedextra, string ratethuextra, string ratefriextra, string ratesatextra, string o_extrarate, string userid)
    {
        DataSet dsrate = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.importexport binddescrip = new NewAdbooking.Classes.importexport();
            dsrate = binddescrip.InsertRatedetailfrExcel(compcode, pkgcode, wrate, o_focusrate, ratecode.ToUpper(), adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, weekrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, o_extrarate, rateid, userid); 
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.importexport binddescrip = new NewAdbooking.classesoracle.importexport();
            dsrate = binddescrip.InsertRatedetailfrExcel(compcode, pkgcode, wrate, o_focusrate, ratecode.ToUpper(), adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, weekrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, o_extrarate, rateid, userid);

        }
        else
        {
            string procedureName = "rate_grid_from_detail";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode, pkgcode, wrate, o_focusrate, ratecode.ToUpper(), adtype, adcategory, subcategory, color, currency, validfromdate1, validtill1, weekrate, decimalvalue, uom, adscat4, adscat5, adscat6, premium, sizefrom, sizeto, frominsert, toinsert, clientcat, minarea, type_, agencycode, dateformat, pubcenter, ratesun, ratemon, ratetue, ratewed, ratethu, ratefri, ratesat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, o_extrarate, rateid, userid };
            dsrate = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
    }
    void saverateDetails(string rate, string focusrate, string ratecodedetail, string compcode, string userid, string edition, string rateid, string solusweekrate, string solusfocusrate, string weekenrate, string soloweekenrate, string type_, string extrarate, string details_rate_sun, string details_rate_mon, string details_rate_tue, string details_rate_wed, string details_rate_thu, string details_rate_fri, string details_rate_sat, string ratesunextra, string ratemonextra, string ratetueextra, string ratewedextra, string ratethuextra, string ratefriextra, string ratesatextra, string adtype, string pubcenter)
    {
        DataSet dinsert = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster insertrate = new NewAdbooking.Classes.RateMaster();
            dinsert = insertrate.ratedetailsinsert(rate, focusrate, ratecodedetail, compcode, userid, edition, rateid, solusweekrate, solusfocusrate, weekenrate, soloweekenrate, type_, extrarate, focusrate, weekenrate, details_rate_sun, details_rate_mon, details_rate_tue, details_rate_wed, details_rate_thu, details_rate_fri, details_rate_sat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, adtype, pubcenter);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster insertrate = new NewAdbooking.classesoracle.RateMaster();
                dinsert = insertrate.ratedetailsinsert(rate, focusrate, ratecodedetail, compcode, userid, edition, rateid, solusweekrate, solusfocusrate, weekenrate, soloweekenrate, type_, extrarate, focusrate, weekenrate, details_rate_sun, details_rate_mon, details_rate_tue, details_rate_wed, details_rate_thu, details_rate_fri, details_rate_sat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, adtype, pubcenter);

            }
            else
            {
                string procedureName = "insertratedetail_insertratedetail_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] ParmetterValueArray = { rate, focusrate, ratecodedetail, compcode, userid, edition, rateid, solusweekrate, solusfocusrate, weekenrate, soloweekenrate, type_, extrarate, focusrate, weekenrate, details_rate_sun, details_rate_mon, details_rate_tue, details_rate_wed, details_rate_thu, details_rate_fri, details_rate_sat, ratesunextra, ratemonextra, ratetueextra, ratewedextra, ratethuextra, ratefriextra, ratesatextra, adtype, pubcenter };
                dinsert = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
            }
    }
    protected void btnimport_Click(object sender, EventArgs e)
    {
        
        Read_Excel();
        
        //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Book1.xls;Extended Properties=Excel 8.0");
        //OleDbDataAdapter da = new OleDbDataAdapter("select * from sheet1", con);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
    }
    void saverate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type_, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max, string priority, string cancellation)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            /*new change ankur 17 feb*/
            NewAdbooking.Classes.RateMaster insert = new NewAdbooking.Classes.RateMaster();
            // dii = insert.insertintorate(Session["compcode"].ToString(), Session["userid"].ToString(), ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area);
            insert.insertintorate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area, type_, agencycode, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max, priority, "", "", "", cancellation,"0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster insert = new NewAdbooking.classesoracle.RateMaster();
            //dii = insert.insertintorate(Session["compcode"].ToString(), Session["userid"].ToString(), ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area);
            insert.insertintorate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area, type_, agencycode, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max, priority, "", "", "", cancellation,"0");

        }
        else
        {
            DataSet insert = new DataSet();
            string procedureName = "insertratemast_insertratemast_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area, type_, agencycode, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max, priority, "", "", "", cancellation, "0" };
            insert = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
    }
    protected void bnnClear_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";
        txtvalidityfrom.Text = "";
        txttilldate.Text = "";
        drpadtype.SelectedValue = "0";
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName == "")
        {
            lblerror.Text = "Please  Select Excel to Upload";
            return;
        }
        //============File upload to server temppdf folder============================//
        try
        {
            if (!System.IO.Directory.Exists(Server.MapPath("temppdf")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("temppdf"));
            }
            string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            string SaveLocation = Server.MapPath("temppdf") + "\\" + fn;
            ViewState.Add("Path", SaveLocation);
            if (System.IO.File.Exists(Server.MapPath("temppdf") + "\\" + fn))
            {
                System.IO.File.Delete(Server.MapPath("temppdf") + "\\" + fn);
            }
            //string filenam = "abp.xls";
            FileUpload1.PostedFile.SaveAs(SaveLocation);
            lblerror.Text = "Excel has been Uploaded.";
            // Response.Write("<script>alert('Excel has been Uploaded.');");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet bindpackage_A_detail(string compcode, string adtype, string channel)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.TV_packagebind(compcode, adtype, channel);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl") 
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                ds = bindopackage.TV_packagebind(compcode, adtype, channel);

            }
            else
            {

                string procedureName = "TV_packagebind";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] ParmetterValueArray = { compcode, adtype, channel };
                ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
            }
        return ds;
    }




    [Ajax.AjaxMethod]
    public DataSet advcat(string compcode, string adtype)
    {
        DataSet dsCat = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.importexport binddescrip = new NewAdbooking.Classes.importexport();
            dsCat = binddescrip.advcategory(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl") 
        {
            NewAdbooking.classesoracle.importexport binddescrip = new NewAdbooking.classesoracle.importexport();
            dsCat = binddescrip.advcategory1(compcode, adtype);
        }
       else
        {
            string procedureName = "adcategory_adcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode, adtype };
            dsCat = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }

        return dsCat;
     

    }


    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtype)
    {
        //NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
        //DataSet ds = new DataSet();
        //ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());
        string value = "";
        if (adtype == "CL0")
        {
            value = "1";

        }
        else
        {
            value = "0";
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binduom = new NewAdbooking.Classes.RateMaster();
            ds = binduom.uombind(compcode, "", value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster binduom = new NewAdbooking.classesoracle.RateMaster();
            ds = binduom.uombind(compcode, "", value);
        }
        else
        {
            string procedureName = "binduomforrate_binduomforrate_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode, "", value };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }

        return ds;

    }

    private static DataSet GetData1(string filepath)
    {
        string strLine;
        string[] strArray;
        char[] charArray = new char[] { ',' };
        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add("TheData");
        FileStream aFile = new FileStream(filepath, FileMode.Open);
        StreamReader sr = new StreamReader(aFile);
        strLine = sr.ReadLine();
        strArray = strLine.Split(charArray);
        for (int x = 0; x <= strArray.GetUpperBound(0); x++)
        {
            dt.Columns.Add(strArray[x].Trim().Replace("\"",""));
        }
        strLine = sr.ReadLine();
        while (strLine != null)
        {
            strArray = strLine.Split(charArray);
            DataRow dr = dt.NewRow();
            for (int i = 0; i <= strArray.GetUpperBound(0); i++)
            {
                dr[i] = strArray[i].Trim().Replace("\"", "");
            }
            dt.Rows.Add(dr);
            strLine = sr.ReadLine();
        }
        sr.Close();
        return ds;
    }
   
    
}
