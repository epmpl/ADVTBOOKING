using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
/// <summary>
/// Summary description for PublishAudit
/// </summary>
    public class PublishAudit : connection
    {
        public PublishAudit()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adtypbind(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advtypbind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);

            }
        }

        public DataSet bindgrid(string comcode, string dateformat, string tilldate, string fromdate, string publication, string adtype, string branch)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpublishert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = comcode;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                if (dateformat == "")
                {
                    objmysqlcommand.Parameters["date1"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["date1"].Value = dateformat;
                }

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                if (tilldate == "")
                {
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = yy + "/" + mm + "/" + dd;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = tilldate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            tilldate = yy + "/" + mm + "/" + dd;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = tilldate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                tilldate = yy + "/" + mm + "/" + dd;
                            }
                    objmysqlcommand.Parameters["todate"].Value = tilldate;
                }
               

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                if (fromdate == "")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat  == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = yy + "/" + mm + "/" + dd;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = fromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            fromdate = yy + "/" + mm + "/" + dd;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = fromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                fromdate = yy + "/" + mm + "/" + dd;
                            }
                    objmysqlcommand.Parameters["fromdate"].Value = fromdate;
                }
               

                objmysqlcommand.Parameters.Add("branch1", MySqlDbType.VarChar);
                String BRANCHNAME = branch;
                if (branch == "Select Branch" || branch == "" || branch == "0")
                {
                    objmysqlcommand.Parameters["branch1"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["branch1"].Value = branch;
                }


                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                if (publication == "Select Center" || publication == "" || publication == "0")
                {
                    objmysqlcommand.Parameters["publication"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["publication"].Value = publication;
                }
                //objmysqlcommand.Parameters["publication"].Value = publication;

                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);

            }
        }

        public DataSet update(string insert_id)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateStatus2", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("insert_id1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insert_id1"].Value = insert_id;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }



    }
}
