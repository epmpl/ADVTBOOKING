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

public partial class Agency_EXL_Uploader : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string compcode = "", agency_code = "", extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "",
           cust_acc_id = "", agency_cd = "", old_agenc_cd = "", agency_nm = "";

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
        Ajax.Utility.RegisterTypeForAjax(typeof(Agency_EXL_Uploader));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        if (!Page.IsPostBack)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            //btnimport.Attributes.Add("OnClick", "javascript:return check1();");

        }
    }

    private bool refreshState;
    private bool isRefresh;
    protected override void LoadViewState(object savedState)
    {
        object[] AllStates = (object[])savedState;
        base.LoadViewState(AllStates[0]);
        refreshState = bool.Parse(AllStates[1].ToString());
        if (Session["ISREFRESH"] != null && Session["ISREFRESH"] != "")
            isRefresh = (refreshState == (bool)Session["ISREFRESH"]);
    }
    protected override object SaveViewState()
    {
        Session["ISREFRESH"] = refreshState;
        object[] AllStates = new object[3];
        AllStates[0] = base.SaveViewState();
        AllStates[1] = !(refreshState);
        return AllStates;
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
            lblerror.Text = "Please Upload CSV File First";
            return;
        }


        string filepath = ViewState["Path"].ToString();//upload_voucher_xml.PostedFile.FileName;
        int kk = 0;
        string alreadyhave = "";
        try
        {



            DataSet ds = GetData1(filepath);
            string prevcioid = "";
            string solo = "S";
            DataSet ds_batch = new DataSet();
            int lenghh = ds.Tables[0].Rows.Count;
            clsconnection dconnect1 = new clsconnection();
            string sqldd1 = "";
            string sqldd2 = "";
            sqldd2 = "SELECT nextval('AGENCY_UPLOADER_SEQ') as next_sequence;";
            ds_batch = dconnect1.executequery(sqldd2);
            string batch_no = ds_batch.Tables[0].Rows[0]["next_sequence"].ToString();
            for (kk = 0; kk < lenghh; kk++)
            {
                string PA = batch_no;
                string PB = ds.Tables[0].Rows[kk].ItemArray[3].ToString().Replace("'", "~");
                string PC = ds.Tables[0].Rows[kk].ItemArray[4].ToString().Replace("'", "~");
                if (PC == "")
                {
                    string errmsg = "Error in Line " + kk + ": " + "Name can't be blank.";
                    Response.Write("<script>alert('" + errmsg + "');</script>");
                    return;
                }

                string PD = ds.Tables[0].Rows[kk].ItemArray[5].ToString().Replace("'", "~");
                string PE = ds.Tables[0].Rows[kk].ItemArray[6].ToString().Replace("'", "~");
                string PF = ds.Tables[0].Rows[kk].ItemArray[7].ToString().Replace("'", "~");
                string PG = ds.Tables[0].Rows[kk].ItemArray[8].ToString().Replace("'", "~");
                string PH = ds.Tables[0].Rows[kk].ItemArray[9].ToString().Replace("'", "~");
                string PI = ds.Tables[0].Rows[kk].ItemArray[10].ToString().Replace("'", "~");
                string PJ = ds.Tables[0].Rows[kk].ItemArray[11].ToString().Replace("'", "~");
                string PK = ds.Tables[0].Rows[kk].ItemArray[12].ToString().Replace("'", "~");
                string PL = ds.Tables[0].Rows[kk].ItemArray[13].ToString().Replace("'", "~");
                string PM = ds.Tables[0].Rows[kk].ItemArray[14].ToString().Replace("'", "~");
                string PN = ds.Tables[0].Rows[kk].ItemArray[15].ToString().Replace("'", "~");
                string PO = ds.Tables[0].Rows[kk].ItemArray[16].ToString().Replace("'", "~");
                string PP = ds.Tables[0].Rows[kk].ItemArray[17].ToString().Replace("'", "~");
                string PQ = ds.Tables[0].Rows[kk].ItemArray[18].ToString().Replace("'", "~");
                string PR = ds.Tables[0].Rows[kk].ItemArray[19].ToString().Replace("'", "~");
                string PS = ds.Tables[0].Rows[kk].ItemArray[20].ToString().Replace("'", "~");
                string PT = ds.Tables[0].Rows[kk].ItemArray[21].ToString().Replace("'", "~");
                string PU = ds.Tables[0].Rows[kk].ItemArray[22].ToString().Replace("'", "~");
                string PV = ds.Tables[0].Rows[kk].ItemArray[23].ToString().Replace("'", "~");
                string PW = ds.Tables[0].Rows[kk].ItemArray[24].ToString().Replace("'", "~");
                string PX = ds.Tables[0].Rows[kk].ItemArray[25].ToString().Replace("'", "~");
                string PY = ds.Tables[0].Rows[kk].ItemArray[26].ToString().Replace("'", "~");
                string PZ = ds.Tables[0].Rows[kk].ItemArray[27].ToString().Replace("'", "~");
                if (RadioButton1.Checked == true)
                {
                    sqldd2 = "delete from agency_mast_data_upload  where  a !=  ";
                    sqldd2 = sqldd2 + "'" + PA + "'" + ";";
                    ds_batch = dconnect1.executequery(sqldd2);
                    sqldd1 = "insert into agency_mast_data_upload (A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z) values ";
                    sqldd1 = sqldd1 + "('" + PA + "','" + PB + "','" + PC + "','" + PD + "','" + PE + "','" + PF + "','" + PG + "','" + PH + "','" + PI + "','" + PJ + "','" + PK + "','"
                                      + PL + "','" + PM + "','" + PN + "','" + PO + "','" + PP + "','" + PQ + "','" + PR + "','" + PS + "','" + PT + "','" + PU + "','" + PV + "','" + PW + "','" + PZ + "','" + PZ + "','" + PZ + "');";
                }
                else
                {
                    sqldd2 = "delete from client_mast_data_upload where  A !=  ";
                    sqldd2 = sqldd2 + "'" + PA + "'" + ";";
                    ds_batch = dconnect1.executequery(sqldd2);
                    sqldd1 = "insert into client_mast_data_upload (A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z) values ";
                    sqldd1 = sqldd1 + "('" + PA + "','" + PB + "','" + PC + "','" + PD + "','" + PE + "','" + PF + "','" + PG + "','" + PH + "','" + PI + "','" + PJ + "','" + PK + "','"
                                      + PL + "','" + PM + "','" + PN + "','" + PO + "','" + PP + "','" + PQ + "','" + PR + "','" + PS + "','" + PT + "','" + PU + "','" + PV + "','" + PW + "','" + PZ + "','" + PZ + "','" + PZ + "');";
                }
                dconnect1.executequery(sqldd1);

            }
            if (RadioButton1.Checked == true)
            {
                processagency("TNIE");
            }
            else
            {
                processclient("TNIE");
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
    [Ajax.AjaxMethod]
    public DataSet processagency(string compcode)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "AGENCY_DATA_UPLOAD";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            string[] ParmetterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "AGENCY_DATA_UPLOAD";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            string[] ParmetterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
        else
        {
            string procedureName = "AGENCY_DATA_UPLOAD";
            string[] ParmetterValueArray = { compcode };
            NewAdbooking.classmysql.Agency_EXL_Uploader bind = new NewAdbooking.classmysql.Agency_EXL_Uploader();
            ds = bind.Agency_EXL_Upload(compcode);

            //NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }

        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet processclient(string compcode)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "CLIENT_DATA_UPLOAD";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            string[] ParmetterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "CLIENT_DATA_UPLOAD";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            string[] ParmetterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }
        else
        {
            string procedureName = "CLIENT_DATA_UPLOAD";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] ParmetterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, ParmetterValueArray);
        }

        return ds;

    }
    protected void btnimport_Click(object sender, EventArgs e)
    {

        Read_Excel();

        //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Book1.xls;Extended Properties=Excel 8.0");
        //OleDbDataAdapter da = new OleDbDataAdapter("select * from sheet1", con);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
    }
    protected void bnnClear_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";

    }
    //protected void btnupload_Click(object sender, EventArgs e)
    //{
    //    if (FileUpload1.PostedFile.FileName == "")
    //    {
    //        lblerror.Text = "Please  Select Excel to Upload";
    //        return;
    //    }
    //    //============File upload to server temppdf folder============================//
    //    try
    //    {
    //        string[] validFileTypes = { "csv" };
    //        string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
    //        bool isValidFile = false;
    //        for (int i = 0; i < validFileTypes.Length; i++)
    //        {
    //            if (ext == "." + validFileTypes[i])
    //            {
    //                isValidFile = true;
    //                break;
    //            }
    //        }
    //        if (!isValidFile)
    //        {
    //            lblerror.ForeColor = System.Drawing.Color.Red;
    //            lblerror.Text = "Invalid File. Please upload a File with extension " +
    //                           string.Join(",", validFileTypes);
    //        }
    //        else
    //        {


    //            if (!System.IO.Directory.Exists(Server.MapPath("temppdf")))
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("temppdf"));
    //            }
    //            string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //            string SaveLocation = Server.MapPath("temppdf") + "\\" + fn;
    //            ViewState.Add("Path", SaveLocation);
    //            if (System.IO.File.Exists(Server.MapPath("temppdf") + "\\" + fn))
    //            {
    //                System.IO.File.Delete(Server.MapPath("temppdf") + "\\" + fn);
    //            }
    //            //string filenam = "abp.xls";
    //            FileUpload1.PostedFile.SaveAs(SaveLocation);

    //            lblerror.ForeColor = System.Drawing.Color.Green;
    //            lblerror.Text = "File uploaded successfully.";
    //            // Response.Write("<script>alert('Excel has been Uploaded.');");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblerror.Text = ex.Message;
    //    }
    //}

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
        for (int x = 0; x < strArray.GetUpperBound(0); x++)
        {
            dt.Columns.Add(strArray[x].Trim().Replace("\"", ""));
        }
        strLine = sr.ReadLine();
        while (strLine != null)
        {
            strArray = strLine.Split(charArray);
            DataRow dr = dt.NewRow();
            if (strArray.GetUpperBound(0) > 29)
            {
                for (int i = 0; i < 30; i++)
                {
                    dr[i] = strArray[i].Trim().Replace("\"", "");
                }
                dt.Rows.Add(dr);
                strLine = sr.ReadLine();
            }
        }
        sr.Close();
        return ds;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (isRefresh == false)
        {
            if (FileUpload1.PostedFile.FileName == "")
            {
                lblerror.Text = "Please Select Excel to Upload";
                return;
            }
            //============File upload to server TempExcel folder============================//
            try
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SEC = "0";
                SEC = DateTime.Now.Second.ToString();
                string SaveLocation = "";
                //SaveLocation = Server.MapPath("temppdf") + "\\" + SEC + fn;
                SaveLocation = Server.MapPath("temppdf") + "\\" + fn;
                ViewState.Add("Path", SaveLocation);
                Array.ForEach(Directory.GetFiles(Server.MapPath("temppdf")), File.Delete);
                FileUpload1.PostedFile.SaveAs(SaveLocation);
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }
            string filepath = ViewState["Path"].ToString();
            DataSet dsxml = new DataSet();
            string fn1 = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            string SaveLocation1 = Server.MapPath("temppdf") + "\\" + fn1;
            DataSet ds_read_xml = new DataSet();
            string connString = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();


            string SaveExcelPath = ViewState["Path"].ToString();
            /*if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xlsx" || Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xls")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + SaveExcelPath + ";Extended Properties=Excel 12.0";
            }
            else
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SaveExcelPath + ";Extended Properties=Excel 8.0";
            }*/

            if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xls")
            {
                //connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SaveExcelPath + ";Extended Properties=Excel 8.0";
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + SaveExcelPath + ";Extended Properties=Excel 12.0";
            }
            else if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xlsx")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SaveExcelPath + ";Extended Properties=Excel 8.0";
            }
            //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0";
            OleDbConnection oledbConn = new OleDbConnection(connString);

            if (oledbConn.State == ConnectionState.Closed)
            {
                oledbConn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);
                OleDbCommand cmd1 = new OleDbCommand("SELECT * FROM [Sheet2$]", oledbConn);
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                OleDbDataAdapter oleda1 = new OleDbDataAdapter();
                oleda.SelectCommand = cmd;
                oleda1.SelectCommand = cmd1;
                oleda.Fill(ds);
                //--------------------------------------------read excel file and insert----------------------------------------------------------------//
                int kk = 0;
                string alreadyhave = "";
                try
                {
                    string prevcioid = "";
                    string solo = "S";
                    DataSet ds_batch = new DataSet();
                    int lenghh = ds.Tables[0].Rows.Count;
                    clsconnection dconnect1 = new clsconnection();
                    string sqldd1 = "";
                    string sqldd2 = "";
                    sqldd2 = "SELECT nextval('AGENCY_UPLOADER_SEQ') as next_sequence;";
                    ds_batch = dconnect1.executequery(sqldd2);
                    string batch_no = ds_batch.Tables[0].Rows[0]["next_sequence"].ToString();
                    for (kk = 0; kk < lenghh; kk++)
                    {
                        //string PA = batch_no;
                        string PA = ds.Tables[0].Rows[kk].ItemArray[0].ToString().Replace("'", "~");
                        string PB = ds.Tables[0].Rows[kk].ItemArray[1].ToString().Replace("'", "~");
                        string PC = ds.Tables[0].Rows[kk].ItemArray[2].ToString().Replace("'", "~");
                        //if (PC == "")
                        //{
                        //    string errmsg = "Error in Line " + kk + ": " + "Name cant be blank.";
                        //    Response.Write("<script>alert('" + errmsg + "');</script>");
                        //    return;
                        //}

                        string PD = ds.Tables[0].Rows[kk].ItemArray[3].ToString().Replace("'", "~");
                        string PE = ds.Tables[0].Rows[kk].ItemArray[4].ToString().Replace("'", "~");
                        string PF = ds.Tables[0].Rows[kk].ItemArray[5].ToString().Replace("'", "~");
                        string PG = ds.Tables[0].Rows[kk].ItemArray[6].ToString().Replace("'", "~");
                        string PH = ds.Tables[0].Rows[kk].ItemArray[7].ToString().Replace("'", "~");
                        string PI = ds.Tables[0].Rows[kk].ItemArray[8].ToString().Replace("'", "~");
                        string PJ = ds.Tables[0].Rows[kk].ItemArray[9].ToString().Replace("'", "~");
                        string PK = ds.Tables[0].Rows[kk].ItemArray[10].ToString().Replace("'", "~");
                        string PL = ds.Tables[0].Rows[kk].ItemArray[11].ToString().Replace("'", "~");
                        string PM = ds.Tables[0].Rows[kk].ItemArray[12].ToString().Replace("'", "~");
                        string PN = ds.Tables[0].Rows[kk].ItemArray[13].ToString().Replace("'", "~");
                        string PO = ds.Tables[0].Rows[kk].ItemArray[14].ToString().Replace("'", "~");
                        string PP = ds.Tables[0].Rows[kk].ItemArray[15].ToString().Replace("'", "~");
                        string PQ = ds.Tables[0].Rows[kk].ItemArray[16].ToString().Replace("'", "~");
                        string PR = ds.Tables[0].Rows[kk].ItemArray[17].ToString().Replace("'", "~");
                        string PS = ds.Tables[0].Rows[kk].ItemArray[18].ToString().Replace("'", "~");
                        string PT = ds.Tables[0].Rows[kk].ItemArray[19].ToString().Replace("'", "~");
                        string PU = ds.Tables[0].Rows[kk].ItemArray[20].ToString().Replace("'", "~");
                        string PV = ds.Tables[0].Rows[kk].ItemArray[21].ToString().Replace("'", "~");
                        string PW = ds.Tables[0].Rows[kk].ItemArray[22].ToString().Replace("'", "~");
                        string PX = ds.Tables[0].Rows[kk].ItemArray[23].ToString().Replace("'", "~");
                        string PY = ds.Tables[0].Rows[kk].ItemArray[24].ToString().Replace("'", "~");
                        string PZ = ds.Tables[0].Rows[kk].ItemArray[25].ToString().Replace("'", "~");
                        if (RadioButton1.Checked == true)
                        {
                            //sqldd2 = "delete from agency_mast_data_upload  where  a !=  ";
                            //sqldd2 = sqldd2 + "'" + PA + "'" + ";";
                            //ds_batch = dconnect1.executequery(sqldd2);
                            sqldd1 = "insert into agency_mast_data_upload (A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z) values ";
                            sqldd1 = sqldd1 + "('" + PA + "','" + PB + "','" + PC + "','" + PD + "','" + PE + "','" + PF + "','" + PG + "','" + PH + "','" + PI + "','" + PJ + "','" + PK + "','"
                                              + PL + "','" + PM + "','" + PN + "','" + PO + "','" + PP + "','" + PQ + "','" + PR + "','" + PS + "','" + PT + "','" + PU + "','" + PV + "','" + PW + "','" + PZ + "','" + PZ + "','" + PZ + "');";
                        }
                        else
                        {
                            //sqldd2 = "delete from client_mast_data_upload where  A !=  ";
                            //sqldd2 = sqldd2 + "'" + PA + "'" + ";";
                            //ds_batch = dconnect1.executequery(sqldd2);
                            sqldd1 = "insert into client_mast_data_upload (A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z) values ";
                            sqldd1 = sqldd1 + "('" + PA + "','" + PB + "','" + PC + "','" + PD + "','" + PE + "','" + PF + "','" + PG + "','" + PH + "','" + PI + "','" + PJ + "','" + PK + "','"
                                              + PL + "','" + PM + "','" + PN + "','" + PO + "','" + PP + "','" + PQ + "','" + PR + "','" + PS + "','" + PT + "','" + PU + "','" + PV + "','" + PW + "','" + PZ + "','" + PZ + "','" + PZ + "');";
                        }
                        dconnect1.executequery(sqldd1);

                    }
                    if (RadioButton1.Checked == true)
                    {
                        processagency(Session["compcode"].ToString());
                    }
                    else
                    {
                        processclient(Session["compcode"].ToString());
                    }
                }

                catch (Exception e1)
                {
                    string errmsg = "Error in Line " + kk + ": " + e1.Message;
                    Response.Write("<script>alert('" + errmsg + "');</script>");
                }
                finally
                {
                    lblerror.Text = "Uploded SuccessFully" ;
                }


                //----------------------------------------------------------------------------------------//
                oledbConn.Close();
            }
        }
    }


}
