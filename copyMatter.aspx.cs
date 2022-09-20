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

public partial class copyMatter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
       // string foldername = Request.QueryString["folder"].ToString();
        string foldername = "xtg";
        if (Session["savedata"] != null)
        {
            DataSet ds_data = new DataSet();
            ds_data = (DataSet)Session["savedata"];
            int matterRowsCnt = ds_data.Tables[0].Rows.Count;
            int matterTablesCnt = ds_data.Tables.Count;

            for (int i = 0; i <= matterTablesCnt - 1; i++)
            {
                string matter_cioid = ds_data.Tables[i].Rows[0].ItemArray[0].ToString();
                string matter_filename = ds_data.Tables[i].Rows[0].ItemArray[1].ToString();
                string matter_RTF = ds_data.Tables[i].Rows[0].ItemArray[2].ToString();
                string matter_XTG = ds_data.Tables[i].Rows[0].ItemArray[3].ToString();
                string matter = ds_data.Tables[i].Rows[0].ItemArray[4].ToString();
                if (matter_filename == Request.QueryString["filename"].ToString())
                {
                    DataTable dt_data = new DataTable();
                    DataRow dr_data = dt_data.NewRow();
                    DataColumn dc_data;

                    dc_data = new DataColumn();
                    dc_data.DataType = System.Type.GetType("System.String");
                    dc_data.ColumnName = "cioid";
                    dt_data.Columns.Add(dc_data);//matter

                    dc_data = new DataColumn();
                    dc_data.DataType = System.Type.GetType("System.String");
                    dc_data.ColumnName = "filename";
                    dt_data.Columns.Add(dc_data);

                    dc_data = new DataColumn();
                    dc_data.DataType = System.Type.GetType("System.String");
                    dc_data.ColumnName = "rtfformat";
                    dt_data.Columns.Add(dc_data);

                    dc_data = new DataColumn();
                    dc_data.DataType = System.Type.GetType("System.String");
                    dc_data.ColumnName = "xtgformat";
                    dt_data.Columns.Add(dc_data);

                    dc_data = new DataColumn();
                    dc_data.DataType = System.Type.GetType("System.String");
                    dc_data.ColumnName = "matter";
                    dt_data.Columns.Add(dc_data);

                    dr_data["cioid"] = matter_cioid;
                    dr_data["filename"] = Request.QueryString["copyfilename"].ToString();
                    dr_data["rtfformat"] = matter_RTF;
                    dr_data["xtgformat"] = matter_XTG;
                    dr_data["matter"] = matter;

                    dt_data.Rows.Add(dr_data);
                    ds_data.Tables.Add(dt_data);

                    Session["savedata"] = ds_data;

                    FileStream fs = null;
                    //FileStream fs = new FileStream(Server.MapPath("/ADBooking/") + cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
                    {
                        //fs = new FileStream(Server.MapPath("/ADBooking/") + matter_cioid + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                        //fs = new FileStream(Server.MapPath("/ADBooking/") + foldername + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                        fs = new FileStream(Server.MapPath("/ADBooking/xtg/")  + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);

                    }
                    else
                    {
                        //fs = new FileStream(Server.MapPath("/ADBooking/") + matter_cioid + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                        //fs = new FileStream(Server.MapPath("/ADBooking/") + foldername + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                        fs = new FileStream(Server.MapPath("/ADBooking/xtg/")  + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                    }
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine(matter_XTG);
                    //sw.WriteLine(mFinal);

                    sw.Flush();
                    sw.Dispose();
                    fs.Dispose();



                }
            }
        }
        else
        {
            DataSet dsmatter = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getData = new NewAdbooking.Classes.BookingMaster();

                dsmatter = getData.getMatter(Request.QueryString["cioid"].ToString(), "copy");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getData = new NewAdbooking.classesoracle.BookingMaster();

                dsmatter = getData.getMatter(Request.QueryString["cioid"].ToString(), "copy");
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster getData = new NewAdbooking.classmysql.BookingMaster();

                dsmatter = getData.getMatter(Request.QueryString["cioid"].ToString(), "copy"); ;
            }
            if (dsmatter.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsmatter.Tables[0].Rows.Count; i++)
                {
                    string matter_cioid = dsmatter.Tables[0].Rows[i].ItemArray[0].ToString();
                    string matter_filename = dsmatter.Tables[0].Rows[i].ItemArray[1].ToString();
                    string matter_RTF = dsmatter.Tables[0].Rows[i].ItemArray[2].ToString();
                    string matter_XTG = dsmatter.Tables[0].Rows[i].ItemArray[3].ToString();
                    string matter = dsmatter.Tables[0].Rows[i].ItemArray[4].ToString();

                    if (matter_filename == Request.QueryString["filename"].ToString())
                    {
                        DataSet ds_data = new DataSet();
                        DataTable dt_data = new DataTable();
                        DataRow dr_data = dt_data.NewRow();
                        DataColumn dc_data;

                        dc_data = new DataColumn();
                        dc_data.DataType = System.Type.GetType("System.String");
                        dc_data.ColumnName = "cioid";
                        dt_data.Columns.Add(dc_data);//matter

                        dc_data = new DataColumn();
                        dc_data.DataType = System.Type.GetType("System.String");
                        dc_data.ColumnName = "filename";
                        dt_data.Columns.Add(dc_data);

                        dc_data = new DataColumn();
                        dc_data.DataType = System.Type.GetType("System.String");
                        dc_data.ColumnName = "rtfformat";
                        dt_data.Columns.Add(dc_data);

                        dc_data = new DataColumn();
                        dc_data.DataType = System.Type.GetType("System.String");
                        dc_data.ColumnName = "xtgformat";
                        dt_data.Columns.Add(dc_data);

                        dc_data = new DataColumn();
                        dc_data.DataType = System.Type.GetType("System.String");
                        dc_data.ColumnName = "matter";
                        dt_data.Columns.Add(dc_data);

                        dr_data["cioid"] = matter_cioid;
                        dr_data["filename"] = Request.QueryString["copyfilename"].ToString();
                        dr_data["rtfformat"] = matter_RTF;
                        dr_data["xtgformat"] = matter_XTG;
                        dr_data["matter"] = matter;

                        dt_data.Rows.Add(dr_data);
                        ds_data.Tables.Add(dt_data);

                        Session["savedata"] = ds_data;

                        FileStream fs = null;
                        //FileStream fs = new FileStream(Server.MapPath("/ADBooking/") + cioid + "\\" + fileName, FileMode.Create, FileAccess.ReadWrite);
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
                        {
                            //fs = new FileStream(Server.MapPath("/ADBooking/") + matter_cioid + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                            fs = new FileStream(Server.MapPath("/ADBooking/") + foldername + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);

                        }
                        else
                        {
                            //fs = new FileStream(Server.MapPath("/ADBooking/") + matter_cioid + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                            fs = new FileStream(Server.MapPath("/ADBooking/") + foldername + "\\" + Request.QueryString["copyfilename"].ToString(), FileMode.Create, FileAccess.ReadWrite);
                        }
                        StreamWriter sw = new StreamWriter(fs);

                        sw.WriteLine(matter_XTG);
                        //sw.WriteLine(mFinal);

                        sw.Flush();
                        sw.Dispose();
                        fs.Dispose();



                    }
                }
            }
        }
    }
}
