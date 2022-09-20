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
using System.Text;
using NewAdbooking.classmysql;
using System.Data.OracleClient;
using System.Data.Sql;

public partial class CreateReferenceFile : System.Web.UI.Page
{
    string classified_reference = ConfigurationSettings.AppSettings["Classified_Reference_Path"].ToString();
    string xtg_path = "";
    string cat_path = "";
    string CD_Ad_path = "";
    string eps_path = "";
    string org_CD_path = "";
    string obt_xtg_path = "";
    //for sms ****************
    string sms_path = "";
    string sms_str = "";
    string sms_file_name = "";
    string puname = "";
    string edtnname = "";
    string chkcenters = "";
    string stUrl;
    //*****************************
    protected void Page_Load(object sender, EventArgs e)
    {
        string pubcode = "";
        string compcode = Request.QueryString["compcode"].ToString();
        string pubdate = Request.QueryString["pubdate"].ToString();
        if (Request.QueryString["pubname"] != null)
        {
            puname = Request.QueryString["pubname"].ToString();
        }
        string centercode = "";
        string editioncode = "";
        string suppcode = "";
        string packagecode = "";
        string flag = "";
        string centername = "";
        if (Request.QueryString["pubcode"] != null)
        {
            pubcode = Request.QueryString["pubcode"].ToString();
        }

        if (Request.QueryString["centercode"] != null)
        {
            centercode = Request.QueryString["centercode"].ToString();
        }

        if (Request.QueryString["editioncode"] != null)
        {
            editioncode = Request.QueryString["editioncode"].ToString();
        }
        else
        {
            editioncode = Request.QueryString["packagecode"].ToString();
        }

        if (Request.QueryString["suppcode"] != null)
        {
            suppcode = Request.QueryString["suppcode"].ToString();
        }
        if (Request.QueryString["packagecode"] != null)
        {
            packagecode = Request.QueryString["packagecode"].ToString();
        }
        if (Request.QueryString["flag"] != null)
        {
            flag = Request.QueryString["flag"].ToString();
        }
        if (Request.QueryString["chkcenters"] != null)
        {
            chkcenters = Request.QueryString["chkcenters"].ToString();
        }
        

        string logincenter = Request.QueryString["logincenter"].ToString();
        string dateformat = Request.QueryString["dateformat"].ToString();
        string chk = Request.QueryString["chk"].ToString();
        string includeuom = Request.QueryString["includeuom"].ToString();
        string excludeuom = Request.QueryString["excludeuom"].ToString();
        string includecat = Request.QueryString["includecat"].ToString();
        string excludecat = Request.QueryString["excludecat"].ToString();
        if (flag == "1")
        {
            centername = Session["centername"].ToString().Substring(0, 5);
        }
        else
        {
            centername = Request.QueryString["centername"].ToString().Substring(0, 2);
        }
        string physicalpath = Request.QueryString["physicalpath"].ToString();// +"\\" + centername;
        // classified_reference = classified_reference + centername + "\\";
        if (System.IO.Directory.Exists(classified_reference) == false)
            System.IO.Directory.CreateDirectory(classified_reference);

        string xtg_filename = "";
        string catname = "";
        string subcatname = "";
        string subsubcatname = "";

        xtg_path = classified_reference + "xtg\\";    //Server.MapPath("xtg\\");
        cat_path = ConfigurationSettings.AppSettings["Category"].ToString();
        CD_Ad_path = classified_reference + "pdf\\";    //Server.MapPath("orignal\\");
        eps_path = classified_reference + "eps\\";
        org_CD_path = Server.MapPath("Orignal/");
        obt_xtg_path = classified_reference + "xtg_obt\\";
        sms_path = classified_reference + "SMS\\"; ///**************************
        DataSet ds = new DataSet();
        if (flag == "1")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.getReferenceFile objbindFile = new NewAdbooking.Classes.getReferenceFile();
                ds = objbindFile.clsReferenceFilepackage(compcode, pubdate, dateformat, logincenter, chk, includeuom, excludeuom, includecat, excludecat, packagecode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
                ds = objbindFile.clsReferenceFilepackage(compcode, pubdate, dateformat, logincenter, chk, includeuom, excludeuom, includecat, excludecat, packagecode, pubcode, editioncode);
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.getReferenceFile objbindFile = new NewAdbooking.Classes.getReferenceFile();
                ds = objbindFile.clsReferenceFile(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, logincenter, chk, includeuom, excludeuom, includecat, excludecat);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
                ds = objbindFile.clsReferenceFile(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, logincenter, chk, includeuom, excludeuom, includecat, excludecat);
            }
            else
            {
                string procedureName = "WEBSP_GETREFERENCEFILEDICT";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, pubdate, pubcode, centercode, editioncode, suppcode, logincenter/*, chk, includeuom, excludeuom, includecat, excludecat */};
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        }
        string month;
        string day;
        string ref_date = "0";
        string ref_date1 = "0";
        if (dateformat == "dd/mm/yyyy")
        {
            day = pubdate.Split('/')[0];
            if (day.Length == 1)
                day = "0" + day;
            month = pubdate.Split('/')[1];
            if (month.Length == 1)
                month = "0" + month;
            ref_date = day + "-" + month + "-" + pubdate.Split('/')[2];
            ref_date1 = day + month + pubdate.Split('/')[2];
        }
        if (dateformat == "mm/dd/yyyy")
        {
            day = pubdate.Split('/')[1];
            if (day.Length == 1)
                day = "0" + day;
            month = pubdate.Split('/')[0];
            if (month.Length == 1)
                month = "0" + month;
            ref_date = day + "-" + month + "-" + pubdate.Split('/')[2];
            ref_date1 = day + month + pubdate.Split('/')[2];
        }
        if (Directory.Exists(xtg_path + ref_date1) == false)
            Directory.CreateDirectory(xtg_path + ref_date1);
        if (Directory.Exists(CD_Ad_path + ref_date1) == false)
            Directory.Exists(CD_Ad_path + ref_date1);
        if (Directory.Exists(CD_Ad_path + ref_date1) == false)
            Directory.CreateDirectory(CD_Ad_path + ref_date1);
        if (Directory.Exists(obt_xtg_path) == false)
            Directory.CreateDirectory(obt_xtg_path);
        if (Directory.Exists(sms_path + ref_date1) == false)
            Directory.CreateDirectory(sms_path + ref_date1);

        if (ds.Tables[0].Rows.Count != 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                if (ds.Tables[0].Rows[j].ItemArray[1].ToString() != "")
                {
                    if (ds.Tables[0].Rows[j].ItemArray[14].ToString() == "ROWyes")
                    {
                        xtg_filename = obt_xtg_path + "\\" + ds.Tables[0].Rows[j].ItemArray[1].ToString().Replace(" ", "");
                        if (File.Exists(xtg_filename) == true)
                            File.Delete(xtg_filename);
                        StreamWriter myStreamWriter1 = new StreamWriter(xtg_filename, true, System.Text.Encoding.Default);
                        string xtgdate = ds.Tables[0].Rows[j].ItemArray[2].ToString();
                        xtgdate = xtgdate.Replace("Gandhi", "4C AbhishekHed");
                        xtgdate = xtgdate.Replace("\r\n", "");
                        myStreamWriter1.Write(xtgdate);
                        myStreamWriter1.Flush();
                        myStreamWriter1.Close();
                    }
                    else if (ds.Tables[0].Rows[j].ItemArray[14].ToString() == "ROW0")
                    {
                        xtg_filename = xtg_path + ref_date1 + "\\" + ds.Tables[0].Rows[j].ItemArray[1].ToString().Replace(" ", "");
                        if (File.Exists(xtg_filename) == true)
                            File.Delete(xtg_filename);
                        StreamWriter myStreamWriter1 = new StreamWriter(xtg_filename, true, System.Text.Encoding.Default);
                        string xtgdate = ds.Tables[0].Rows[j].ItemArray[2].ToString();
                        xtgdate = xtgdate.Replace("Gandhi", "4C AbhishekHed");
                        xtgdate = xtgdate.Replace("\r\n", "");
                        myStreamWriter1.Write(xtgdate);
                        myStreamWriter1.Flush();
                        myStreamWriter1.Close();
                    }
                    //else if (ds.Tables[0].Rows[j].ItemArray[14].ToString() == "ROWno")
                    else if (ds.Tables[0].Rows[j].ItemArray[14].ToString() == "ROW")
                    {
                        xtg_filename = xtg_path + ref_date1 + "\\" + ds.Tables[0].Rows[j].ItemArray[1].ToString().Replace(" ", "");
                        if (File.Exists(xtg_filename) == true)
                            File.Delete(xtg_filename);
                        StreamWriter myStreamWriter1 = new StreamWriter(xtg_filename, true, System.Text.Encoding.Default);
                        string xtgdate = ds.Tables[0].Rows[j].ItemArray[2].ToString();
                        if (xtgdate.ToString().IndexOf("Helvetica") > 0 || xtgdate.ToString().IndexOf("Bhaskar") > 0)
                        {
                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                            {
                                DataSet dsfont = new DataSet();
                                NewAdbooking.classesoracle.getReferenceFile objbindFile = new NewAdbooking.classesoracle.getReferenceFile();
                                if (xtgdate.ToString().IndexOf("Helvetica") > 0)
                                {


                                    dsfont = objbindFile.getfontsizeleading("Helvetica");
                                    if (dsfont.Tables.Count > 0 && dsfont.Tables[0].Rows.Count > 0)
                                    {
                                        string fontleading = dsfont.Tables[0].Rows[0]["FONTLEADING"].ToString();
                                        string fontsize = dsfont.Tables[0].Rows[0]["FONTSIZE"].ToString();
                                        xtgdate = xtgdate.Replace("<cSize:6.5><cLeading:6.5><cFont:Helvetica>", "<cSize:" + fontsize + "><cLeading:" + fontleading + "><cFont:Helvetica>");
                                    }
                                }
                                if (xtgdate.ToString().IndexOf("Bhaskar") > 0)
                                {
                                    dsfont.Clear();
                                    dsfont = objbindFile.getfontsizeleading("Bhaskar");
                                    if (dsfont.Tables.Count > 0 && dsfont.Tables[0].Rows.Count > 0)
                                    {
                                        string fontleading = dsfont.Tables[0].Rows[0]["FONTLEADING"].ToString();
                                        string fontsize = dsfont.Tables[0].Rows[0]["FONTSIZE"].ToString();
                                        xtgdate = xtgdate.Replace("<cSize:6.5><cLeading:6.5><cFont:Bhaskar>", "<cSize:" + fontsize + "><cLeading:" + fontleading + "><cFont:Bhaskar>");
                                    }
                                }
                            }
                        }
                        else if (xtgdate.ToString().IndexOf("GothamCondensed") > 0 || xtgdate.ToString().IndexOf("eDn_Body") > 0 || xtgdate.ToString().IndexOf("KANNAN") > 0 || xtgdate.ToString().IndexOf("Gautami") > 0)
                        {
                            string fontsize = "8";
                            string fontleading = "9";
                            if (xtgdate.ToString().IndexOf("GothamCondensed") > 0)
                            {
                                xtgdate = xtgdate.Replace("<cSize:5.75><cLeading:6.5><cFont:GothamCondensed>", "<cSize:" + fontsize + "><cLeading:" + fontleading + "><cFont:GothamCondensed>");
                            }
                            if (xtgdate.ToString().IndexOf("eDn_Body") > 0)
                            {
                                xtgdate = xtgdate.Replace("<cSize:6.2><cLeading:6.5><cFont:eDn_Body>", "<cSize:" + fontsize + "><cLeading:" + fontleading + "><cFont:Dn011>");
                            }
                            if (xtgdate.ToString().IndexOf("KANNAN") > 0)
                            {
                                xtgdate = xtgdate.Replace("<cSize:6.5><cLeading:6.5><cFont:KANNAN>", "<cSize:" + fontsize + "><cLeading:" + fontleading + "><cFont:KANNAN>");
                            }
                            //else
                            //{
                            //    xtgdate = xtgdate.Replace("<cSize:5.75><cLeading:6.5><cFont:Gautami>", "<cSize:" + fontsize + "><cLeading:" + fontleading + "><cFont:GothamCondensed>");
                            //}
                        }
                        xtgdate = xtgdate.Replace("Gautami", "GothamCondensed");
                        xtgdate = xtgdate.Replace("\r\n", "");
                        xtgdate = xtgdate.Replace("<cSize:>", "\r\n<cSize:>");
                        //xtgdate = xtgdate + " " + "\r\n" + ds.Tables[0].Rows[j]["cio_booking_id"].ToString();
                        xtgdate = xtgdate + ds.Tables[0].Rows[j]["cio_booking_id"].ToString();
                        xtgdate = xtgdate.Replace("\\", "\\\\");
                        xtgdate = xtgdate.Replace("<ASCII-WIN>", "<ASCII-WIN>\r\n");
                        myStreamWriter1.Write(xtgdate);
                        myStreamWriter1.Flush();
                        myStreamWriter1.Close();
                    }
                    else
                    {
                        xtg_filename = xtg_path + ref_date1 + "\\" + ds.Tables[0].Rows[j].ItemArray[1].ToString().Replace(" ", "");
                        if (File.Exists(xtg_filename) == true)
                            File.Delete(xtg_filename);
                        StreamWriter myStreamWriter1 = new StreamWriter(xtg_filename, true, System.Text.Encoding.Default);
                        string xtgdate = ds.Tables[0].Rows[j].ItemArray[2].ToString();
                        //xtgdate = xtgdate.Replace("p(0,0,0,9,0,0,g,U.S. English)z5.75fGautami","p(0,0,0,6.5,0,0,g,U.S. English)z7.3fGautami").Replace("<*p(0,0,0,8.5,0,0,g,"U.S. English")><*F*p(0,0,0,8.5,0,0,g,"U.S. English")z8.5f"Gandhi">","<*p(0,0,0,9,0,0,g,"U.S. English")><*F*p(0,0,0,9,0,0,g,"U.S. English")z8.5f"Gandhi">");
                        xtgdate = xtgdate.Replace("(0,0,0,6.5,0,0,g,\"U.S. English\")z5.75", "(0,0,0,6.5,0,0,g,\"U.S. English\")z7").Replace("F(0,0,0,8.5,0,0,g,\"U.S. English\")z8.5f\"Gandhi\"", "F(0,0,0,9,0,0,g,\"U.S. English\")z8.5f\"Gandhi\"").Replace("F(0,0,0,8,0,0,g,\"U.S. English\")z7f\"Gautami\"", "F(0,0,0,8,0,0,g,\"U.S. English\")z7f\"Gautami\"").Replace("F*p(0,0,0,6.5,0,0,g,\"U.S. English\")z5.75f\"Gautami\"", "F*p(0,0,0,8,0,0,g,\"U.S. English\")z7f\"Gautami\"");

                        xtgdate = xtgdate.Replace("\"Gautami\"", "\"Candara\"");
                        xtgdate = xtgdate.Replace("\"Gandhi\"", "\"4C AbhishekHed\"");
                        xtgdate = xtgdate.Replace("\r\n", "");
                        if (xtgdate.IndexOf("\"Gautami\"") > 1)
                        {
                            xtgdate = xtgdate + " " + "<*F*p(0,0,0,8,0,0,g,\"U.S. English\")z5f\"Gautami\">" + "(" + ds.Tables[0].Rows[j]["RO_No"].ToString() + ")";
                        }
                        else
                        {
                            //xtgdate = xtgdate + " " + "\r\n" +/*"<*F*p(0,0,0,9,0,0,g,\"U.S. English\")z5f\"Gautami\">" +*/ ds.Tables[0].Rows[j]["cio_booking_id"].ToString();
                        }
                       
                        xtgdate = xtgdate.Replace("<ASCII-WIN>", "<ASCII-WIN>\r\n");
                        myStreamWriter1.Write(xtgdate);
                        myStreamWriter1.Flush();
                        myStreamWriter1.Close();
                    }
                }
            }
            edtnname = ds.Tables[0].Rows[0]["EDTNNAME"].ToString();
        }
        //************************
        string ref_path = classified_reference + "ReferenceFile\\";  //Server.MapPath("Reffile\\");

        if (System.IO.Directory.Exists(ref_path) == false)
            System.IO.Directory.CreateDirectory(ref_path);
        string ref_file = puname + "-" + edtnname.Replace(",", "-") + "-" + ref_date + ".txt";

        //******************************************************
        if (System.IO.Directory.Exists(sms_path) == false)
            System.IO.Directory.CreateDirectory(sms_path);
        string sms_file = "SMS-" + editioncode.Replace(",", "-") + "-" + ref_date + ".txt";
        sms_file_name = sms_path + ref_date1 + "\\" + sms_file;

        if (File.Exists(sms_file_name) == true)
            File.Delete(sms_file_name);
        //StreamWriter myStreamWriter33 = new StreamWriter(sms_file_name, true, System.Text.Encoding.Default);
        //myStreamWriter33.Write(ref_file);
        //myStreamWriter33.Flush();
        //myStreamWriter33.Close();
        //*********************************************************
        string centerip = ""; // "172.22.0.54";
        string newcat_path = "";
        string newphysicalpath = "";

        if (chkcenters == "F")
        {

              DataSet ds1 = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                
                }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                     OracleConnection objOracleConnection;
                     NewAdbooking.classesoracle.orclconnection objConnection = new NewAdbooking.classesoracle.orclconnection();
                     objOracleConnection = objConnection.GetConnection();
                     objOracleConnection.Open();
                     OracleDataAdapter da = new OracleDataAdapter();
                     da.SelectCommand = new OracleCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + centercode + "'", objOracleConnection);
                     da.Fill(ds1);
                     objOracleConnection.Close();   
                }
                 else
                 {
                     MySql.Data.MySqlClient.MySqlConnection objSqlConnection;
                     NewAdbooking.classmysql.connection objConnection = new NewAdbooking.classmysql.connection();
                     objSqlConnection = objConnection.GetConnection();
                     objSqlConnection.Open();
                     MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                     //da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + center + "'", objSqlConnection);
                     da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + centercode + "' AND PUBL='" + pubcode + "'", objSqlConnection);
                     da.Fill(ds1);
                     objSqlConnection.Close();
                 }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    stUrl = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                    newcat_path = cat_path.Replace(cat_path.Split('\\')[2], stUrl);
                    newphysicalpath = physicalpath.Replace(physicalpath.Split('\\')[2], stUrl);
                }
                else
                {
                    newcat_path = cat_path;
                    newphysicalpath = physicalpath;
                }
        }
        else
        {
            newcat_path = cat_path;
            newphysicalpath = physicalpath;
        }

        if (ds.Tables[0].Rows.Count != 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[14].ToString() == "ROWyes")
                ref_file = "OB0" + "-" + ref_date + ".txt";
            string v_fname = ref_path + ref_file;
            if (File.Exists(v_fname) == true)
                File.Delete(v_fname);

            string sms_fname = sms_path + sms_file;
            if (File.Exists(sms_fname) == true)
                File.Delete(sms_fname);

            Encoding ascii = Encoding.ASCII;
            StreamWriter myStreamWriter = new StreamWriter(v_fname, true, System.Text.Encoding.Default);
            StreamWriter smsStreamWriter = new StreamWriter(sms_file_name, true, System.Text.Encoding.Default);
            myStreamWriter.WriteLine("Ü" + ref_date + "Ü");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //if (ds.Tables[0].Rows[i].ItemArray[3].ToString() != null)
                //{
                //    if (catname != ds.Tables[0].Rows[i].ItemArray[3].ToString() && ds.Tables[0].Rows[i].ItemArray[3].ToString() != "")
                //    {
                //        if (ds.Tables[0].Rows[i].ItemArray[4].ToString() == "" || ds.Tables[0].Rows[i].ItemArray[4].ToString() == null)
                //            myStreamWriter.WriteLine("¶" + cat_path + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "_" + pubcode + ".pdf,1*1¶");
                //        else
                //            myStreamWriter.WriteLine("¶" + cat_path + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "_" + pubcode + ",1*1¶");
                //        subcatname = "";
                //        subsubcatname = "";
                //    }
                //    catname = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                //}
                
                
                if (ds.Tables[0].Rows[i].ItemArray[5].ToString() != null)
                {
                    if (subcatname != ds.Tables[0].Rows[i].ItemArray[5].ToString() && ds.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[i].ItemArray[6].ToString() == "" || ds.Tables[0].Rows[i].ItemArray[6].ToString() == null)
                            myStreamWriter.WriteLine("¶" + newcat_path + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "_" + pubcode + ".pdf,1*1¶");
                            //myStreamWriter.WriteLine("¶" + cat_path + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "_" + pubcode + ".pdf" + ",.71*1¶");
                        else
                            myStreamWriter.WriteLine("¶" + newcat_path + ds.Tables[0].Rows[i].ItemArray[6].ToString() + "_" + pubcode + ",.71*1¶");
                        subsubcatname = "";
                    }
                    subcatname = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                    /*if (subcatname != ds.Tables[0].Rows[i].ItemArray[5].ToString() && ds.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[i].ItemArray[6].ToString() == "" || ds.Tables[0].Rows[i].ItemArray[6].ToString() == null)
                            myStreamWriter.WriteLine("¶" + cat_path + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "_" + pubcode + ".pdf" + ",.71*1¶");
                        else
                            myStreamWriter.WriteLine("¶" + cat_path + ds.Tables[0].Rows[i].ItemArray[6].ToString() + "_" + pubcode + ",.71*1¶");
                        subsubcatname = "";
                    }
                    subcatname = ds.Tables[0].Rows[i].ItemArray[5].ToString();*/
                }

                if (ds.Tables[0].Rows[i].ItemArray[20].ToString() != null)
                {
                    if (subsubcatname != ds.Tables[0].Rows[i].ItemArray[20].ToString() && ds.Tables[0].Rows[i].ItemArray[20].ToString() != "")
                    {
                        myStreamWriter.WriteLine("¶" + newcat_path + ds.Tables[0].Rows[i].ItemArray[20].ToString() + "_" + pubcode + ".pdf,1*1¶");
                        //myStreamWriter.WriteLine("ù" + cat_path + ds.Tables[0].Rows[i].ItemArray[16].ToString() + "ù");
                    }
                    subsubcatname = ds.Tables[0].Rows[i].ItemArray[20].ToString();
                }

                if (ds.Tables[0].Rows[i].ItemArray[14].ToString() == "CD")
                {
                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                    {
                        //check filename for edition 
                        string edi_filename = ds.Tables[0].Rows[i].ItemArray[1].ToString();  // ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "");
                        DataSet ds_filename = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            // NewAdbooking.classesoracle.getReferenceFile objpublish = new NewAdbooking.classesoracle.getReferenceFile();
                            // objpublish.clsPublishClassifiedAd(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[13].ToString());
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.getReferenceFile objfile = new NewAdbooking.classesoracle.getReferenceFile();
                            ds_filename = objfile.clsEditionFileName(compcode, pubdate, pubcode, centercode, editioncode, suppcode, ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[13].ToString(), dateformat);
                        }
                        else
                        {
                            NewAdbooking.classmysql.getReferenceFile objfile = new NewAdbooking.classmysql.getReferenceFile();
                            ds_filename = objfile.clsEditionFileName(compcode, pubdate, pubcode, centercode, editioncode, suppcode, ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[13].ToString(), dateformat);
                        }
                        if (ds_filename.Tables.Count > 0)
                            if (ds_filename.Tables[0].Rows.Count > 0)
                                edi_filename = ds_filename.Tables[0].Rows[0].ItemArray[0].ToString();
                        ds_filename.Clear();
                        ds_filename.Dispose();
                        if (edi_filename == "")
                        {
                            edi_filename = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                        }
                        //*************************************************
                        if (System.IO.File.Exists(org_CD_path + edi_filename + ".pdf") == true)
                        {
                            System.IO.File.Copy(org_CD_path + edi_filename + ".pdf", CD_Ad_path + ref_date1 + "\\" + edi_filename + ".pdf", true);
                            //myStreamWriter.WriteLine("æD," + physicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename +/* ".pdf" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 3.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 4)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "1" + "," + "æ");
                            }
                            else if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 6.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 8)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "2" + "," + "æ");
                            }
                            else
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            }
                            if (flag == "1")
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".pdf" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".pdf" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else if (System.IO.File.Exists(org_CD_path + edi_filename + ".eps") == true)
                        {
                            System.IO.File.Copy(org_CD_path + edi_filename + ".eps", CD_Ad_path + ref_date1 + "\\" + edi_filename + ".eps", true);
                            //myStreamWriter.WriteLine("æD," + physicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename +/* ".eps" + */"," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 3.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 4)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "1" + "," + "æ");
                            }
                            else if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 6.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 8)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "2" + "," + "æ");
                            }
                            else
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            }
                            if (flag == "1")
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".eps" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".eps" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else if (System.IO.File.Exists(org_CD_path + edi_filename + ".tif") == true)
                        {
                            System.IO.File.Copy(org_CD_path + edi_filename + ".tif", CD_Ad_path + ref_date1 + "\\" + edi_filename + ".tif", true);
                            if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 3.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 4)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "1" + "," + "æ");
                            }
                            else if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 6.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 8)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "2" + "," + "æ");
                            }
                            else
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            }
                            // myStreamWriter.WriteLine("æD," + physicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + ".tif" + "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            if (flag == "1")
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".tif" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".tif" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else if (System.IO.File.Exists(org_CD_path + edi_filename + ".tiff") == true)
                        {
                            System.IO.File.Copy(org_CD_path + edi_filename + ".tiff", CD_Ad_path + ref_date1 + "\\" + edi_filename + ".tiff", true);
                            //myStreamWriter.WriteLine("æD," + physicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tiff" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 3.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 4)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "1" + "," + "æ");
                            }
                            else if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) > 6.00 && Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[12].ToString()) <= 8)
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "2" + "," + "æ");
                            }
                            else
                            {
                                myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            }
                            if (flag == "1")
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".tiff" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".tiff" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else if (System.IO.File.Exists(org_CD_path + edi_filename + ".jpg") == true)
                        {
                            System.IO.File.Copy(org_CD_path + edi_filename + ".jpg", CD_Ad_path + ref_date1 + "\\" + edi_filename + ".jpg", true);
                            myStreamWriter.WriteLine("æD," + physicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".jpg" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            if (flag == "1")
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".jpg" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".jpg" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else if (System.IO.File.Exists(org_CD_path + edi_filename + ".jpeg") == true)
                        {
                            System.IO.File.Copy(org_CD_path + edi_filename + ".jpeg", CD_Ad_path + ref_date1 + "\\" + edi_filename + ".jpeg", true);
                            myStreamWriter.WriteLine("æD," + physicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".jpeg" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                            if (flag == "1")
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".jpeg" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".jpeg" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else
                        {
                            myStreamWriter.WriteLine("æD," + newphysicalpath + "pdf\\" + ref_date1 + "\\" + edi_filename + /*".tif" +*/ "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "1" + "," + "æ");
                        }
                        //myStreamWriter.WriteLine("æD," + physicalpath + "\\pdf\\" + ref_date1 + "\\" + edi_filename + ".tif" + "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");

                        //sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ","") + ".tif" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                        smsStreamWriter.WriteLine(sms_str);
                    }
                    else
                    {

                        if (ds.Tables[0].Rows[i].ItemArray[12].ToString() == "3")
                        {
                            myStreamWriter.WriteLine("æD," + newphysicalpath + "\\pdf\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ".tif" + "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + "1" + "," + "æ");
                        }
                        else
                        {
                            myStreamWriter.WriteLine("æD," + newphysicalpath + "\\pdf\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[0].ToString() /*+ ".tif"*/ + "," + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "*" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "," + "æ");
                        }
                        if (flag == "1")
                        {
                            sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + ".tif" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                        }
                        else
                        {
                            sms_str = ds.Tables[0].Rows[i].ItemArray[0].ToString() + ".tif" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                        }
                        smsStreamWriter.WriteLine(sms_str);
                    }
                }
                else if (ds.Tables[0].Rows[i].ItemArray[14].ToString() == "ROWyes")
                {
                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                        myStreamWriter.WriteLine("æD," + physicalpath + "\\eps\\" + System.IO.Path.GetFileNameWithoutExtension(ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "")) + ",2*1,æ");
                    else
                        myStreamWriter.WriteLine("æD," + physicalpath + "\\eps\\" + System.IO.Path.GetFileNameWithoutExtension(ds.Tables[0].Rows[i].ItemArray[0].ToString()) + ",2*1,æ");
                }
                else     // if (ds.Tables[0].Rows[i].ItemArray[14].ToString() == "ROW")
                {
                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                    {

                        if (ds.Tables[0].Rows[i].ItemArray[10].ToString() == "SB0")
                        {
                            if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BU0")
                                myStreamWriter.WriteLine("æB," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR0")
                                myStreamWriter.WriteLine("æG," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "YE0")
                                myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "PI0")
                                myStreamWriter.WriteLine("æP," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "PU0")
                                myStreamWriter.WriteLine("æV," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "OR0")
                                myStreamWriter.WriteLine("æO," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "SK0")
                                myStreamWriter.WriteLine("æS," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR1")
                                myStreamWriter.WriteLine("æW," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR2")
                                myStreamWriter.WriteLine("æT," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BL0")
                                myStreamWriter.WriteLine("æU," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR3")  //yellow and outline
                                myStreamWriter.WriteLine("æE," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO0")
                            //    myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "G,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO1")
                            //    myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "E,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO2")
                            //    myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "G,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO3")
                            //    myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "E,æ");
                            else
                                myStreamWriter.WriteLine("æL," + newphysicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                        }
                        else if (ds.Tables[0].Rows[i].ItemArray[10].ToString() == "SP0")
                        {
                            myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "D,æ");
                        }
                        else if (ds.Tables[0].Rows[i].ItemArray[10].ToString() == "BO1")
                        {
                            if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BU0")
                                myStreamWriter.WriteLine("æB," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR0")
                                myStreamWriter.WriteLine("æG," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "YE0")
                                myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "PI0")
                                myStreamWriter.WriteLine("æP," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "PU0")
                                myStreamWriter.WriteLine("æV," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "OR0")
                                myStreamWriter.WriteLine("æO," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "SK0")
                                myStreamWriter.WriteLine("æS," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR1")
                                myStreamWriter.WriteLine("æW," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR2")
                                myStreamWriter.WriteLine("æT," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BL0")
                                myStreamWriter.WriteLine("æU," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR3")  //yellow and outline
                                myStreamWriter.WriteLine("æE," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO0")
                            //    myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "G,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO1")
                            //    myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "E,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO2")
                            //    myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "G,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO3")
                            //    myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "E,æ");
                            else
                                myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                        }
                        else if (ds.Tables[0].Rows[i].ItemArray[10].ToString() == "BO0")
                        {
                            myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "E,æ");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BU0")
                                myStreamWriter.WriteLine("æB," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR0")
                                myStreamWriter.WriteLine("æG," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "YE0")
                                myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "PI0")
                                myStreamWriter.WriteLine("æP," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "PU0")
                                myStreamWriter.WriteLine("æV," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "OR0")
                                myStreamWriter.WriteLine("æO," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "SK0")
                                myStreamWriter.WriteLine("æS," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR1")
                                myStreamWriter.WriteLine("æW," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR2")
                                myStreamWriter.WriteLine("æT," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BL0")
                                myStreamWriter.WriteLine("æU," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "GR3")  //yellow and outline
                                myStreamWriter.WriteLine("æE," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO0")
                            //    myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "G,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO1")
                            //    myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "E,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO2")
                            //    myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "G,æ");
                            //else if (ds.Tables[0].Rows[i].ItemArray[9].ToString() == "BO3")
                            //    myStreamWriter.WriteLine("æY," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + "E,æ");
                            else
                                myStreamWriter.WriteLine("æL," + newphysicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");

                        }



                        if (flag == "1")
                        {
                            sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                        }
                        else
                        {
                            sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                        }
                        smsStreamWriter.WriteLine(sms_str);
                    }
                    else
                    {
                        if (flag == "1")
                        {
                            if (ds.Tables[0].Rows[i].ItemArray[1].ToString() == "")
                            {

                                myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ".xtg" + "," + "P,æ");
                                sms_str = ds.Tables[0].Rows[i].ItemArray[0].ToString() + ".xtg" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                myStreamWriter.WriteLine("æL," + physicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString() + ".xtg" + "|" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[25].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[24].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[i].ItemArray[1].ToString() == "")
                            {
                                if (ds.Tables[0].Rows[i].ItemArray[11].ToString() == "0")
                                    myStreamWriter.WriteLine("æL," + newphysicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ".txt" + "," + "P,æ");
                                else
                                    myStreamWriter.WriteLine("æL," + newphysicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[0].ToString().Replace(" ", "") + "," + "P,æ");
                                sms_str = ds.Tables[0].Rows[i].ItemArray[0].ToString() + ".xtg" + "|" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                            else
                            {
                                myStreamWriter.WriteLine("æL," + newphysicalpath + "\\xtg\\" + ref_date1 + "\\" + ds.Tables[0].Rows[i].ItemArray[1].ToString().Replace(" ", "") + "," + "P,æ");
                                sms_str = ds.Tables[0].Rows[i].ItemArray[1].ToString() + ".xtg" + "|" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[12].ToString() + "|" + "0" + "|" + ds.Tables[0].Rows[i].ItemArray[19].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[28].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[27].ToString() + "|" + ds.Tables[0].Rows[i].ItemArray[21].ToString();
                            }
                        }
                        smsStreamWriter.WriteLine(sms_str);
                    }
                }
                //***************************************
                if (flag != "1")
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        // NewAdbooking.classesoracle.getReferenceFile objpublish = new NewAdbooking.classesoracle.getReferenceFile();
                        // objpublish.clsPublishClassifiedAd(compcode, pubdate, pubcode, centercode, editioncode, suppcode, dateformat, ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[13].ToString());
                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.getReferenceFile objpublish = new NewAdbooking.classesoracle.getReferenceFile();
                        //objpublish.clsPublishClassifiedAd(compcode, pubdate, pubcode, centercode, editioncode, suppcode, ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[13].ToString(), dateformat);
                    }
                    else
                    {
                        NewAdbooking.classmysql.getReferenceFile objpublish = new NewAdbooking.classmysql.getReferenceFile();
                        objpublish.clsPublishClassifiedAd(compcode, pubdate, pubcode, centercode, editioncode, suppcode, ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[13].ToString(), dateformat);
                    }
                }
            }
            myStreamWriter.Flush();
            myStreamWriter.Close();
            smsStreamWriter.Flush();
            smsStreamWriter.Close();
            Response.Write("<script language=javascript>alert(\"Reference File generated successfully.\");window.close()</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert(\"No Booking available.\");window.close()</script>");
        }

    }
}
