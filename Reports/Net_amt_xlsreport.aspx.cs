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
public partial class Reports_Net_amt_xlsreport : System.Web.UI.Page
{
    double[] value;
    double gau1 = 0;
    string from_date = "", to_date = "";
    string dateto1 = "";
    string datefrom1 = "";
    string ad_tbl = "";
    string date = "";
    string fromdt = "";
    string dateto = "";  
    string rundate = "", Run_Date = "",day = "", month = "", year = "";
    string dateformat = "";
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
            HDN_dateformat.Value = Session["dateformat"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
        }
       

        if (HDN_dateformat.Value == "mm/dd/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;

        }
        else if (HDN_dateformat.Value == "dd/mm/yyyy")
        {
            HDN_server_date.Value = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
        }
        else
        {
            HDN_server_date.Value = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_Net_amt_xlsreport));

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/billbook.xml"));
        //string prm = Session["prm_piproduct"].ToString();
        //string[] prm_Array = new string[33];
       // prm_Array = prm.Split('~');

        //fromdt = prm_Array[5];//Request.QueryString["fromdate"].ToString();
      // dateto = prm_Array[7]; //Request.QueryString["dateto"].ToString();

        fromdate.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        todate.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
       // lblRunningDate.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        book.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        bill.Text = ds.Tables[0].Rows[0].ItemArray[49].ToString();
        insert.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
        //lbl_run = lblRunningDate.Text;




        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                }

        Run_Date = date.ToString();

        


        //hiddendatefrom.Value = fromdt.ToString();
           
        
        
        
        
       /* if (fromdt != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                datefrom1 = dd + "/" + mm + "/" + yy;

            }
            else
            {
                 DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = year + "/" + month + "/" + day;
                }
            }
        }
        from_date = datefrom1;
        //dateto1 = "";
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto1 = dd + "/" + mm + "/" + yy;

            }


            else
            {

               

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = day + "/" + month + "/" + year;

                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = year + "/" + month + "/" + day;
                }
            }
        }
        to_date = dateto1;

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                }



        //lblRdate.Text = Run_Date;
        from_date = fromdt;
        to_date = dateto;
        Run_Date = date.ToString();*/
 
        
        
       

        BtnRun.Attributes.Add("OnClick", "javascript:return checkrundatenetamt();");
       // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();");
       // txttodate.Attributes.Add("onkeypress", "javascript:return validdate1();");
       // txtfromdate.Attributes.Add("onkeypress", "javascript:return validdate();");

      //  txttodate.Attributes.Add("onfocus", "javascript:return checkrundate();");
      //  dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
      //  txttodate.Attributes.Add("onchange", "javascript:return dateformate();");
      //  txtfromdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfromdate);");
       // txttodate.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate);");

        //txttodate.Attributes.Add("onblur", "javascript:return isDate(this.value,this.id,document.getElementById('HDN_dateformat'),document.getElementById('HDN_server_date').value)");
        //txtfromdate.Attributes.Add("onblur", "javascript:return isDate(this.value,this.id,document.getElementById('HDN_dateformat'),document.getElementById('HDN_server_date').value)");
        txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
        txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);");


        //bill.Attributes.Add("onclick", "javascript:return billbill();");
        //book.Attributes.Add("onclick", "javascript:return billbook();");
       
        //insert.Attributes.Add("onclick", "javascript:return billinsert();");

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));

        heading.Text = ds1.Tables[3].Rows[0].ItemArray[0].ToString();
        lbldrp1.Text = ds1.Tables[3].Rows[0].ItemArray[1].ToString();
        lbldrp2.Text = ds1.Tables[3].Rows[0].ItemArray[2].ToString();

        if (IsPostBack != true)
        {
            binddrp1();
            binddrp2();
            exe.Attributes.Add("onclick", "javascript:return enable_exe();");
            csv.Attributes.Add("onclick", "javascript:return enable_csv();"); 
        }


    }

    public void binddrp1()
    {


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i;

        for (i = 0; i < ds.Tables[0].Columns.Count ; i++)
        {
            ListItem li;
            li = new ListItem();
          //  i = i + 1;
            li.Text = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            li.Value = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            drpdrp1.Items.Add(li);

        }

    }

    public void binddrp2()
    {


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i1;

        for (i1 = 0; i1 < ds.Tables[1].Columns.Count ; i1++)
        {
            ListItem li;
            li = new ListItem();
         //   i1 = i1 + 1;
            li.Text = ds.Tables[1].Rows[0].ItemArray[i1].ToString();
            li.Value = ds.Tables[1].Rows[0].ItemArray[i1].ToString();
            drpdrp2.Items.Add(li);
            

        }

    }
    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }



    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string from_date = "";
        string to_date = "";
        string chk_excel = "";
        string adchk = "";
        string filter = "";
        if (book.Checked == true)
            adchk = "1";
        else if (bill.Checked == true)
            adchk = "2";
        else
            adchk = "3";

        string col = "";
        string row = "";
        col = drpdrp1.SelectedValue;
        row = drpdrp2.SelectedValue;

        string name1 = "", name2 = "", name3 = "";

        //if (Txtdest.SelectedValue == "4")
        //{
        if (exe.Checked == true)
        {
            chk_excel = "1";//excel
        }
        else
        {
            chk_excel = "3";//csv
        }


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 ncls = new NewAdbooking.Report.classesoracle.Class1();
            if (adchk == "1")
                ds = ncls.netamtreport(txtfromdate.Text, txttodate.Text, hdncompcode.Value, hiddendateformat.Value, drpdrp1.SelectedValue, drpdrp2.SelectedValue, adchk, Session["userid"].ToString(), Session["access"].ToString());
            else if (adchk == "3")
                ds = ncls.netamtreportinsert(txtfromdate.Text, txttodate.Text, hdncompcode.Value, hiddendateformat.Value, drpdrp1.SelectedValue, drpdrp2.SelectedValue, adchk, Session["userid"].ToString(), Session["access"].ToString());
            else if (adchk == "2")
                ds = ncls.netamtreportdatewise(txtfromdate.Text, txttodate.Text, hdncompcode.Value, hiddendateformat.Value, drpdrp1.SelectedValue, drpdrp2.SelectedValue, adchk, Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                from_date = DMYToMDY(txtfromdate.Text);
                to_date = DMYToMDY(txttodate.Text);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                from_date = YMDToMDY(txtfromdate.Text);
                to_date = YMDToMDY(txttodate.Text);
            }
            NewAdbooking.Report.Classes.report ncls = new NewAdbooking.Report.Classes.report();
            if (adchk == "1")
                ds = ncls.netamtreport(from_date,to_date, hdncompcode.Value, hiddendateformat.Value, drpdrp1.SelectedValue, drpdrp2.SelectedValue, adchk, Session["userid"].ToString(), Session["access"].ToString());
            else if (adchk == "3")
                ds = ncls.netamtreportinsert(from_date,to_date, hdncompcode.Value, hiddendateformat.Value, drpdrp1.SelectedValue, drpdrp2.SelectedValue, adchk, Session["userid"].ToString(), Session["access"].ToString());
            else if (adchk == "2")
                ds = ncls.netamtreportdatewise(from_date, to_date, hdncompcode.Value, hiddendateformat.Value, drpdrp1.SelectedValue, drpdrp2.SelectedValue, adchk, Session["userid"].ToString(), Session["access"].ToString());
        }

    if (ds.Tables[0].Columns.Count == 0 || ds.Tables[0].Rows[0].ItemArray[0].ToString() == "abc_pk")
    {
        ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_Net_amt_xlsreport), "sa", "alert(\"There Is No Data To Display\");", true);
        return;
    }
    else
    {
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        if (chk_excel == "1")
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        }
        else
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        }
        value = new double[ds.Tables[0].Columns.Count];
        
        for (int r = 1; r < ds.Tables[0].Columns.Count; r++)
        {
            gau1 = 0;
            string ffdd = ds.Tables[0].Columns[r].ToString();
            BoundColumn nameColumn = new BoundColumn();
            nameColumn.HeaderText = ffdd;
            nameColumn.DataField = ffdd;

            name1 = name1 + "," + ffdd;
            name2 = name2 + "," + ffdd;
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                double  gau = 0;
                if (r >= 2 && ds.Tables[0].Rows[i][ffdd].ToString()!="")
                {
                    gau = Convert.ToDouble(ds.Tables[0].Rows[i][ffdd].ToString());
                    gau1 = gau1 + gau;
                }
                
            }
            value[r] = gau1;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }


       /* for (int r = 1; r < ds.Tables[0].Columns.Count; r++)
        {
            string ffdd = ds.Tables[0].Columns[r].ToString();
            BoundColumn nameColumn = new BoundColumn();
            nameColumn.HeaderText = ffdd;
            nameColumn.DataField = ffdd;
            DataGrid1.Columns.Add(nameColumn);
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }*/
        ad_tbl="<tr><td><b>Total</b></td>";
        for (int x = 2; x < value.Length; x++)
        {
            ad_tbl = ad_tbl + "<td>" + value[x] +"</td>";
        }
        ad_tbl = ad_tbl+"</tr>";

        if (chk_excel == "1")
        {




            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            string headexcel = "";

            if (txtfromdate.Text != "")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    string[] arr = txtfromdate.Text.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datefrom1 = dd + "/" + mm + "/" + yy;

                }
                else
                {
                    DateTime dt = Convert.ToDateTime(txtfromdate.Text.ToString());
                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = day + "/" + month + "/" + year;


                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = year + "/" + month + "/" + day;
                    }
                }



            }
            from_date = datefrom1.ToString();
            if (txttodate.Text != "")
            {
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    string[] arr = txttodate.Text.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = dd + "/" + mm + "/" + yy;

                }
                else
                {
                    DateTime dt = Convert.ToDateTime(txttodate.Text.ToString());
                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = day + "/" + month + "/" + year;


                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = year + "/" + month + "/" + day;
                    }
                }
            }

            to_date = dateto1.ToString();

            hw.Write("<p <table border=\"1\"><tr><td colspan=\"15\"align=\"center\"><b>Net Amount Report</b></td></tr>");


            //hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "From Date:" + from_date + "</b></td><td colspan=\"7\"align=\"center\"><b>" + "To Date:" + lblto.Text + "</b></td><td colspan=\"6\"align=\"right\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
                
           // headexcel = "Net Amount Report " + chkorder + " Wise";
            //hw.Write("<p align=\"center\"><b>Net Amount Report<b>");
            //hw.Write("<p align=\"left\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            // hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>" + headexcel + "<b>");
            //  hw.Write("<p <tr><td colspan=\"20\"align=\"center\"><b>" + "Pi Report" + "</b></td></tr>");
            //hw.Write("<p <td align=\"left\"><b>" + "From Date:" + txtfromdate.Text + "</b></td>");
            //hw.Write(" <td align=\"right\"><b>" + "To Date:" + txttodate.Text + "</b></td>");
            //hw.Write("<td align=\"left\"><b>Data in Row:" + drpdrp1.SelectedItem.Text + "</b></td>");
            //hw.Write("<td align=\"right\"><b>Data in Column:" + drpdrp2.SelectedItem.Text + "</b></td>");

            hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "From Date:" + from_date + "</b></td><td colspan=\"3\"align=\"left\"><b>" + "To Date:" + to_date + "</b></td><td colspan=\"5\"align=\"right\"><b>" + "Run Date:" + Run_Date + "</b></td></tr>");

            hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "Data in Row:" + drpdrp1.SelectedItem.Text + "</b></td><td colspan=\"3\"align=\"left\"><b>" + "Data in Column:" + drpdrp2.SelectedItem.Text  + "</b></td></tr>");
            
            
            
           // hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "Run Date:" + Run_Date + "</b></td></tr>"); 
           // hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "From Date:" + from_date + "</b></td><td colspan=\"8\"align=\"right\"><b>" + "To Date:" + to_date + "</b></td></tr>");
           // hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "Data in Row:" + drpdrp1.SelectedItem.Text + "</b></td><td colspan=\"8\"align=\"right\"><b>" + "Data in Column:" + drpdrp2.SelectedItem.Text + "</b></td></tr>");
            
            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //DataGrid1.ShowHeader = true;
            //DataGrid1.ShowFooter = true;
           // hw.Write("<p align=center><b>Net Amount Report</b>");
            //hw.Write("<p align=\"left\"><b>From Date:</b>" + txtfromdate.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>To Date:</b>" + txttodate.Text);
           // hw.Write("<p align=\"left\"><b>Data in Row:</b>" + drpdrp1.SelectedItem.Text + " Wise" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Data in Column:</b>" + drpdrp2.SelectedItem.Text + " Wise");
            //hw.Write("<p align=\"left\"><b>Net Amount Report<b>");
              
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            Response.Write(sw.ToString().Replace("</table>", ad_tbl + "</table>"));

            //Response.Write(sw.ToString());
        }
        else
        {
            DataGrid1.DataSource = ds;

            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties ={ names, captions, formats };

            QueryToCSV(ds, colProperties);
        }
        Response.Flush();
        Response.End();
    } 
    }

    private void QueryToCSV(DataSet dr, string[][] colProperties)
    {
        if (colProperties.Length > 0)
        {
            int counter;
            Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
            for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
            {
                counter = 0;
                Response.Write("\"");
                foreach (String column in colProperties[0])
                {
                    //dr.Tables[0].Rows[i].
                    Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                    if (counter < colProperties[0].Length - 1)
                    {
                        Response.Write("\",\"");
                    }
                    counter += 1;
                }
                Response.Write("\"\n");
            }
            //dr.Close();
            //tw.Close();
        }
    }
    private int getcolindex(DataSet ds, string col)
    {
        int i;
        for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
        {
            if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
            {
                goto td5;

            }
        }
    td5:
        return i;
    }



    protected void book_CheckedChanged(object sender, EventArgs e)
    {
        drpdrp1.Items.Clear();
        drpdrp2.Items.Clear();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i;

        for (i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            //  i = i + 1;
            li.Text = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            li.Value = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            drpdrp1.Items.Add(li);

        }

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i1;

        for (i1 = 0; i1 < ds.Tables[1].Columns.Count; i1++)
        {
            ListItem li1;
            li1 = new ListItem();
            //   i1 = i1 + 1;
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i1].ToString();
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i1].ToString();
            drpdrp2.Items.Add(li1);


        }
        bill.Checked = false;
        insert.Checked = false;
        book.Checked = true;

    }
    protected void bill_CheckedChanged(object sender, EventArgs e)
    {
        drpdrp1.Items.Clear();
        drpdrp2.Items.Clear();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i;

        for (i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            //  i = i + 1;
            li.Text = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            li.Value = ds.Tables[2].Rows[0].ItemArray[i].ToString();
            drpdrp1.Items.Add(li);

        }

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i1;

        for (i1 = 0; i1 < ds.Tables[1].Columns.Count; i1++)
        {
            ListItem li1;
            li1 = new ListItem();
            //   i1 = i1 + 1;
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i1].ToString();
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i1].ToString();
            drpdrp2.Items.Add(li1);


        }

        bill.Checked = true;
       insert.Checked = false;
       book.Checked = false;



    }
    protected void insert_CheckedChanged(object sender, EventArgs e)
    {
        drpdrp1.Items.Clear();
        drpdrp2.Items.Clear();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i;

        for (i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            //  i = i + 1;
            li.Text = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            li.Value = ds.Tables[0].Rows[0].ItemArray[i].ToString();
            drpdrp1.Items.Add(li);

        }

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/Net_amtxls.xml"));


        int i1;

        for (i1 = 0; i1 < ds.Tables[1].Columns.Count; i1++)
        {
            ListItem li1;
            li1 = new ListItem();
            //   i1 = i1 + 1;
            li1.Text = ds1.Tables[1].Rows[0].ItemArray[i1].ToString();
            li1.Value = ds1.Tables[1].Rows[0].ItemArray[i1].ToString();
            drpdrp2.Items.Add(li1);


        }

        bill.Checked = false;
        insert.Checked = true;
        book.Checked = false;

    }
}
