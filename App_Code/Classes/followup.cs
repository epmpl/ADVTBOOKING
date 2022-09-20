using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for followup
    /// </summary>
    public class followup : connection
    {
        public followup()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet execute_maingrp(string compcode, string maingrcode, string dateformat, string extra1, string extra2)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("bindagencyforxls", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                sqlcom.Parameters["@agency"].Value = extra1;


                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
        public DataSet findrecord(string compcode, string agency, string client, string fdate, string tdate, string dateformat, string extra1, string extra2, string extra3)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("followup", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                sqlcom.Parameters["@pcompcode"].Value = compcode;

                sqlcom.Parameters.Add("@pagency", SqlDbType.VarChar);
                sqlcom.Parameters["@pagency"].Value = agency;

                sqlcom.Parameters.Add("@pclient", SqlDbType.VarChar);
                sqlcom.Parameters["@pclient"].Value = client;

               // sqlcom.Parameters.Add("@pdatefrom", SqlDbType.Date);


                sqlcom.Parameters.Add("@pdatefrom", SqlDbType.VarChar);


                if (fdate == "" || fdate == null)
                {
                    sqlcom.Parameters["@pdatefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }

                    sqlcom.Parameters["@pdatefrom"].Value = fdate;
                }
              //  sqlcom.Parameters["@pdatefrom"].Value = fdate;

              //  sqlcom.Parameters.Add("@pdateto", SqlDbType.Date);





                sqlcom.Parameters.Add("@pdateto", SqlDbType.VarChar);


                if (tdate == "" || tdate == null)
                {
                    sqlcom.Parameters["@pdateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }

                    sqlcom.Parameters["@pdateto"].Value = tdate;
                }



               // sqlcom.Parameters["@pdateto"].Value = tdate;

                sqlcom.Parameters.Add("@pdateformate", SqlDbType.VarChar);
                sqlcom.Parameters["@pdateformate"].Value = dateformat;

                sqlcom.Parameters.Add("@pextra1", SqlDbType.VarChar);
                sqlcom.Parameters["@pextra1"].Value = extra1;

                sqlcom.Parameters.Add("@pextra2", SqlDbType.VarChar);
                sqlcom.Parameters["@pextra2"].Value = extra2;

                sqlcom.Parameters.Add("@pextra3", SqlDbType.VarChar);
                sqlcom.Parameters["@pextra3"].Value = extra3;

               
                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
        public DataSet clientxls(string compcode, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindclientforxls", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet fetchMailId(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchMailId_ro", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bkid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bkid"].Value = cioid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
    }
}
