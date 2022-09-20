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
using System.IO;

public partial class insertMatter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string receipt = "";
        string boxno = "";
        string oldboxno = "";
        string modify = Request.QueryString["modify"].ToString();
        if (Request.QueryString["receipt"] != null)
        {
            receipt = Request.QueryString["receipt"].ToString();
        }
        if (Request.QueryString["boxno"] != null)
        {
            boxno = Request.QueryString["boxno"].ToString();
        }
        if (Request.QueryString["oldboxno"] != null)
        {
            oldboxno = Request.QueryString["oldboxno"].ToString();
        }
        string currCioId1 = "";
        string tempcoiid = "";
        if (Request.QueryString["currcioid"] != null)
            currCioId1 = Request.QueryString["currcioid"].ToString();

        if (Request.QueryString["tempbkid"] != null)
            tempcoiid = Request.QueryString["tempbkid"].ToString();
        if (currCioId1 == "")
            currCioId1 = receipt;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster insertMatter = new NewAdbooking.classesoracle.BookingMaster();
            DataSet chk = new DataSet();
            chk = insertMatter.checkPrevId(currCioId1);
            if (chk.Tables[0].Rows.Count > 0 && chk.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                modify = "1";
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.BookingMaster insertMatter = new NewAdbooking.classmysql.BookingMaster();
            DataSet chk = new DataSet();
            chk = insertMatter.checkPrevId(currCioId1);
            if (chk.Tables.Count > 0 && chk.Tables[0].Rows.Count > 0 && chk.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                modify = "1";
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster insertMatter = new NewAdbooking.Classes.BookingMaster();
            DataSet chk = new DataSet();
            chk = insertMatter.checkPrevId(currCioId1);
            if (chk.Tables.Count > 0 && chk.Tables[0].Rows.Count > 0 && chk.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                modify = "1";
            }
        }
        if (modify == "0")
        {
            string filenames = "";

            if (Session["savedata"] != null)
            {
                DataSet ds_matterFile = new DataSet();
                ds_matterFile = (DataSet)Session["savedata"];
                int matterRowsCnt = ds_matterFile.Tables[0].Rows.Count;
                int matterTablesCnt = ds_matterFile.Tables.Count;

                for (int i = 0; i <= matterTablesCnt - 1; i++)
                {
                    string matter_XTG;
                    string matter_cioid = ds_matterFile.Tables[i].Rows[0].ItemArray[0].ToString();
                    if (tempcoiid == matter_cioid)
                        matter_cioid = currCioId1;
                    string matter_filename = ds_matterFile.Tables[i].Rows[0].ItemArray[1].ToString();
                    // string[] filename = matter_filename.Split('-');
                    if (matter_filename != "")
                    {
                        if ((matter_filename.Contains("_")))
                        {
                            matter_filename = matter_cioid + matter_filename.Substring(matter_filename.IndexOf("_"), (matter_filename.Length - matter_filename.IndexOf("_")));
                        }
                        else
                        {
                            matter_filename = matter_cioid + matter_filename.Substring(matter_filename.IndexOf("-"), (matter_filename.Length - matter_filename.IndexOf("-")));
                        }
                    }
                        //matter_filename = matter_cioid + matter_filename.Substring(matter_filename.IndexOf("-"), (matter_filename.Length - matter_filename.IndexOf("-")));
                    string matter_RTF = ds_matterFile.Tables[i].Rows[0].ItemArray[2].ToString();
                    if (oldboxno == boxno)
                    {
                        matter_XTG = ds_matterFile.Tables[i].Rows[0].ItemArray[3].ToString();
                    }
                    else
                    {
                        matter_XTG = ds_matterFile.Tables[i].Rows[0].ItemArray[3].ToString().Replace(oldboxno, boxno);
                    }
                    string matter = ds_matterFile.Tables[i].Rows[0].ItemArray[4].ToString();
                    string lang = "";
                    if (ds_matterFile.Tables[i].Rows[0].ItemArray.Length > 5)
                        lang = ds_matterFile.Tables[i].Rows[0].ItemArray[5].ToString();
                    filenames = filenames + matter_filename + ",";
                    DataSet db2 = new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {

                        NewAdbooking.Classes.BookingMaster insertMatter = new NewAdbooking.Classes.BookingMaster();

                        db2 = insertMatter.saveMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt, lang, Session["userid"].ToString());
                    }

                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.BookingMaster insertMatter = new NewAdbooking.classesoracle.BookingMaster();
                            if (Request.QueryString["FORMNAME"] != null && Request.QueryString["FORMNAME"].ToString() == "QBC")
                            {
                                //if (matter_filename != "" && receipt !="")
                                //    matter_filename = matter_filename.Replace(matter_cioid, receipt);
                            }
                            db2 = insertMatter.saveMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt, lang, Session["userid"].ToString());


                        }
                        else
                        {
                            /* NewAdbooking.classmysql.BookingMaster insertMatter = new NewAdbooking.classmysql.BookingMaster();

                             db2 = insertMatter.saveMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt,);
                             */

                            string[] parameterValueArray = new string[] { matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt, lang, Session["userid"].ToString() ,"",""};
                            string procedureName = "websp_insertMatter";
                            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                            db2 = sms.DynamicBindProcedure(procedureName, parameterValueArray);

                        }
                }
                Session["fileName"] = null;
                Session["savedata"] = null;
            }
            if (Session["copy_matter"] != null)
            {
                string currCioId = Request.QueryString["currcioid"].ToString();
                DataSet ds_matterFile = new DataSet();
                ds_matterFile = (DataSet)Session["copy_matter"];
                int matterRowsCnt = ds_matterFile.Tables[0].Rows.Count;
                int matterTablesCnt = ds_matterFile.Tables.Count;
                for (int i = 0; i <= matterRowsCnt - 1; i++)
                {
                    string[] arrfilename;
                    string flag = "0";
                    string matter_cioid = currCioId;
                    string matter_filename = ds_matterFile.Tables[0].Rows[i].ItemArray[1].ToString();
                    arrfilename = matter_filename.Split('-');
                    matter_filename = currCioId;
                    for (int j = 1; j < arrfilename.Length; j++)
                    {
                        matter_filename += "-" + arrfilename[j].ToString();
                    }
                    if (filenames != "")
                    {
                        string[] arrnames = filenames.Split(',');
                        for (int j = 0; j < arrnames.Length; j++)
                        {
                            if (matter_filename == arrnames[j])
                            {
                                flag = "1";
                                filenames = filenames.Replace(arrnames[j], "chk");
                            }
                        }
                    }

                    if (flag == "0")
                    {
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/") + matter_cioid);
                        }
                        else
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("/webdir/") + matter_cioid);
                        }
                        FileStream fs = null;
                        //FileStream fs = new FileStream(Server.MapPath("/webdir/") + cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
                        {
                            fs = new FileStream(Server.MapPath("/webdir/") + matter_cioid + "\\" + matter_filename, FileMode.Create, FileAccess.ReadWrite);

                        }
                        else
                        {
                            fs = new FileStream(Server.MapPath("/webdir/") + matter_cioid + "\\" + matter_filename, FileMode.Create, FileAccess.ReadWrite);
                        }
                        StreamWriter sw = new StreamWriter(fs);
                        string fileData = ds_matterFile.Tables[0].Rows[i].ItemArray[3].ToString();
                        sw.WriteLine(fileData);
                        sw.Flush();
                        sw.Dispose();
                        fs.Dispose();

                        string matter_RTF = ds_matterFile.Tables[0].Rows[i].ItemArray[2].ToString();
                        string matter_XTG = ds_matterFile.Tables[0].Rows[i].ItemArray[3].ToString();
                        string matter = ds_matterFile.Tables[0].Rows[i].ItemArray[4].ToString();
                        string lang = "";
                        if (ds_matterFile.Tables[i].Rows[0].ItemArray.Length > 5)
                            lang = ds_matterFile.Tables[i].Rows[0].ItemArray[5].ToString();
                        DataSet db2 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {

                            NewAdbooking.Classes.BookingMaster insertMatter = new NewAdbooking.Classes.BookingMaster();

                            db2 = insertMatter.saveMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt, lang, Session["userid"].ToString());
                        }

                        else
                            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                            {
                                NewAdbooking.classesoracle.BookingMaster insertMatter = new NewAdbooking.classesoracle.BookingMaster();
                                if (Request.QueryString["FORMNAME"] != null && Request.QueryString["FORMNAME"].ToString() == "QBC")
                                {
                                    if (matter_filename != "")
                                        matter_filename = matter_filename.Replace(matter_cioid, receipt);
                                }
                                db2 = insertMatter.saveMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt, lang, Session["userid"].ToString());


                            }
                            else
                            {
                                /*NewAdbooking.classmysql.BookingMaster insertMatter = new NewAdbooking.classmysql.BookingMaster();

                                db2 = insertMatter.saveMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt);
                                */
                                string[] parameterValueArray = new string[] { matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, receipt, lang, Session["userid"].ToString(), "", "" };
                                string procedureName = "websp_insertMatter";
                                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                                db2 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                            }
                    }
                }
                Session["copy_matter"] = null;

            }
        }
        else
        {
            if (Session["savedata"] != null)
            {
                DataSet ds_matterFile = new DataSet();
                ds_matterFile = (DataSet)Session["savedata"];
                int matterRowsCnt = ds_matterFile.Tables[0].Rows.Count;
                int matterTablesCnt = ds_matterFile.Tables.Count;
                for (int i = 0; i <= matterTablesCnt - 1; i++)
                {
                    string matter_cioid = ds_matterFile.Tables[i].Rows[0].ItemArray[0].ToString();
                    string matter_filename = ds_matterFile.Tables[i].Rows[0].ItemArray[1].ToString();
                    string matter_RTF = ds_matterFile.Tables[i].Rows[0].ItemArray[2].ToString();
                    string matter_XTG = ds_matterFile.Tables[i].Rows[0].ItemArray[3].ToString();
                    string matter = ds_matterFile.Tables[i].Rows[0].ItemArray[4].ToString();
                    string lang = "";
                    if (ds_matterFile.Tables[i].Rows[0].ItemArray.Length > 5)
                        lang = ds_matterFile.Tables[i].Rows[0].ItemArray[5].ToString();
                    if (Request.QueryString["FORMNAME"] != null && Request.QueryString["FORMNAME"].ToString() == "QBC")
                        if (receipt != "" && matter_cioid == "")
                            matter_cioid = receipt;

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {

                        NewAdbooking.Classes.BookingMaster chk = new NewAdbooking.Classes.BookingMaster();
                        DataSet dsChk = new DataSet();

                        dsChk = chk.getMatter(matter_cioid, matter_filename);

                        if (dsChk.Tables[0].Rows.Count == 0)
                        {
                            NewAdbooking.Classes.BookingMaster insMatter = new NewAdbooking.Classes.BookingMaster();
                            DataSet db2 = new DataSet();
                            db2 = insMatter.modifyMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, "0", receipt, lang, Session["userid"].ToString());
                        }
                        else
                        {
                            NewAdbooking.Classes.BookingMaster modMatter = new NewAdbooking.Classes.BookingMaster();
                            DataSet db2 = new DataSet();
                            db2 = modMatter.modifyMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, "1", receipt, lang, Session["userid"].ToString());
                        }

                    }
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster chk = new NewAdbooking.classesoracle.BookingMaster();
                        DataSet dsChk = new DataSet();

                        dsChk = chk.getMatter(currCioId1, matter_filename);

                        if (dsChk.Tables[0].Rows.Count == 0)
                        {
                            NewAdbooking.classesoracle.BookingMaster insMatter = new NewAdbooking.classesoracle.BookingMaster();
                            DataSet db2 = new DataSet();
                            //if (matter_filename != "" && receipt != "")
                              //  matter_filename = matter_filename.Replace(matter_cioid, receipt);
                            db2 = insMatter.modifyMatter(currCioId1, matter_filename, matter_RTF, matter_XTG, matter, "0", receipt, lang, Session["userid"].ToString());
                        }
                        else
                        {
                            NewAdbooking.classesoracle.BookingMaster modMatter = new NewAdbooking.classesoracle.BookingMaster();
                            DataSet db2 = new DataSet();
                            //if (matter_filename != "" && receipt != "")
                            //    matter_filename = matter_filename.Replace(matter_cioid, receipt);
                            db2 = modMatter.modifyMatter(currCioId1, matter_filename, matter_RTF, matter_XTG, matter, "1", receipt, lang, Session["userid"].ToString());
                        }
                    }
                    else
                    {
                        NewAdbooking.classmysql.BookingMaster chk = new NewAdbooking.classmysql.BookingMaster();
                        DataSet dsChk = new DataSet();

                        dsChk = chk.getMatter(matter_cioid, matter_filename);

                        if (dsChk.Tables[0].Rows.Count == 0)
                        {
                            NewAdbooking.classmysql.BookingMaster insMatter = new NewAdbooking.classmysql.BookingMaster();
                            DataSet db2 = new DataSet();
                            db2 = insMatter.modifyMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, "0", receipt, lang, Session["userid"].ToString());
                        }
                        else
                        {
                            NewAdbooking.classmysql.BookingMaster modMatter = new NewAdbooking.classmysql.BookingMaster();
                            DataSet db2 = new DataSet();
                            db2 = modMatter.modifyMatter(matter_cioid, matter_filename, matter_RTF, matter_XTG, matter, "1", receipt, lang, Session["userid"].ToString());
                        }
                    }



                }
                Session["fileName"] = null;
                Session["savedata"] = null;
            }


        }

    }
}
