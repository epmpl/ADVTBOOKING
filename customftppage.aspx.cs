using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;
using System.Data.Sql;
//using System.Data.MySqlClient;
using forFtp;
using NewAdbooking.classmysql;

public partial class customftppage : System.Web.UI.Page
{
    #region "Variabili private"
    //  IntPtr hInternet, hFtp;
    //  int nID;
    string stUrl;
    string stUser;
    string stPass;
    int INTERNET_FTP_PORT = 0;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.CacheControl = "no-cache";
        string flag = "";
        string destinationpath ="";
        string[] dest;
        string ref_flag = Request.QueryString["bflag"].ToString();
        string sourcepath = Request.QueryString["xtg_sourcepath"].ToString();
        string pubcode = Request.QueryString["pubcode"].ToString();
        dest = Request.QueryString["xtg_destination"].ToString().Split('\\');         // sourcepath.Split('\\');
        if(ref_flag=="1" || ref_flag=="3")
            destinationpath = "/" + dest[4] + "/" /*+ dest[5] + "/" */ + dest[6] + "/" + dest[7];   //Request.QueryString["xtg_destination"].ToString();        
        else
            destinationpath = "/" + dest[4] + "/" /*+ dest[5] + "/" */ + dest[6];
        
        string filename = Request.QueryString["filename"].ToString();
        
        string center = Request.QueryString["center"].ToString();
        Boolean myPath = false;
        Boolean MyFtpDir = false;

        forFtp.FTP objFtp = new FTP();

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
                     da.SelectCommand = new OracleCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + center + "'", objOracleConnection);
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
                 da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select ftp_ip,ftp_pwd,ftp_uid,ftp_port from ftpcenters where centercode='" + center + "' AND PUBL='" + pubcode + "'", objSqlConnection);
                 da.Fill(ds1);
                 objSqlConnection.Close();
             }

             if (ds1.Tables[0].Rows.Count > 0)
             {
                 stUrl = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                 stUser = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
                 stPass = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
                 INTERNET_FTP_PORT = Convert.ToInt16(ds1.Tables[0].Rows[0].ItemArray[3].ToString());
                 ds1.Clear();
                 ds1.Dispose();
                 bool FTP_Connect = objFtp.Open(stUrl, stUser, stPass);
                 if (FTP_Connect == false)
                 {
                     Response.Write("<script>alert('FTP does not connect. Check your FTP.');</script>");
                     return;
                 }
                 /*  bool bRet = objFtp.PutFile(sourcepath + "\\00002310-All.txt", "/RP/");
                   if (bRet == false)
                   {
                       Response.Write("<script>alert('Failed to upload file. Check your FTP.');</script>");
                       return;
                   }
                   */

                 myPath = objFtp.ftp_SetCurrentDirectory(destinationpath);
                 if (myPath == false)
                 {
                     MyFtpDir = objFtp.ftp_CreateDirectory(destinationpath);
                     myPath = objFtp.ftp_SetCurrentDirectory(destinationpath);
                 }

                 if (ref_flag == "1")
                 {
                     System.IO.DirectoryInfo diinfo1 = new DirectoryInfo(sourcepath);
                     //FileSystemInfo[] fsi1 = diinfo1.GetFiles("*.txt");
                     FileSystemInfo[] fsi1 = diinfo1.GetFiles("*");
                     foreach (FileSystemInfo info1 in fsi1)
                     {
                         // if (System.IO.File.GetAttributes != 0)
                         {
                             bool bRet = objFtp.PutFile(info1.FullName, destinationpath + "/" + info1.Name);
                             if (bRet == false)
                             {
                                 Response.Write("<script>alert('Failed to upload file. Check your FTP.');</script>");
                                 return;
                             }
                             // else
                             //  System.IO.File.SetAttributes(info1, 0);
                             FTP_Connect = objFtp.Open(stUrl, stUser, stPass);
                             if (FTP_Connect == false)
                             {
                                 Response.Write("<script>alert('FTP does not connect. Check your FTP.');</script>");
                                 return;
                             }
                         }
                     }
                 }
                 if (ref_flag == "3")
                 {
                     System.IO.DirectoryInfo diinfo1 = new DirectoryInfo(sourcepath);
                     FileSystemInfo[] fsi1 = diinfo1.GetFiles("*.*");
                     foreach (FileSystemInfo info1 in fsi1)
                     {
                         // if (System.IO.File.GetAttributes != 0)
                         {
                             bool bRet = objFtp.PutFile(info1.FullName, destinationpath + "/" + info1.Name);
                             if (bRet == false)
                             {
                                 Response.Write("<script>alert('Failed to upload file. Check your FTP.');</script>");
                                 return;
                             }
                             // else
                             //  System.IO.File.SetAttributes(info1, 0);
                             FTP_Connect = objFtp.Open(stUrl, stUser, stPass);
                             if (FTP_Connect == false)
                             {
                                 Response.Write("<script>alert('FTP does not connect. Check your FTP.');</script>");
                                 return;
                             }
                         }
                     }
                 }
                 if (ref_flag == "2")
                 {
                     bool bRet = objFtp.PutFile(sourcepath, destinationpath + "/" + System.IO.Path.GetFileName(sourcepath));
                     if (bRet == false)
                     {
                         Response.Write("<script>alert('Failed to upload file. Check your FTP.');</script>");
                         return;
                     }
                     else
                     {
                         flag = "Z";
                     }
                 }
             }
             else
             {
                 flag = "T";
             }

        objFtp.Close();
            

        Response.Write(flag);
        Response.End();
    }
}
