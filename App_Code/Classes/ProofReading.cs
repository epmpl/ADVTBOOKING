using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProofReading
/// </summary>
namespace NewAdbooking.Classes
{
    public class ProofReading : connection
    {
        public ProofReading()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet findrec(string frmdate, string todate, string cat, string filter, string compcode, string dateformat, string cat2, string InsertionType, string bookingtype, string p_bkid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindproofreading", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@filter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filter"].Value = filter;

                objSqlCommand.Parameters.Add("@cate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cate"].Value = cat;

                objSqlCommand.Parameters.Add("@frdate", SqlDbType.VarChar);
                if (frmdate == "" || frmdate == null)
                {
                    objSqlCommand.Parameters["@frdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@frdate"].Value = frmdate;
                }

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@todate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@cat2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat2"].Value = cat2;



                objSqlCommand.Parameters.Add("@p_repeat", SqlDbType.VarChar);
                if (InsertionType == "" || InsertionType == null)
                {
                    objSqlCommand.Parameters["@p_repeat"].Value=System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@p_repeat"].Value = InsertionType;
                }
             


                objSqlCommand.Parameters.Add("@p_booktype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_booktype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@p_bkid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_bkid"].Value = p_bkid;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = pextra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = pextra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = pextra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = pextra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = pextra5;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

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
        public DataSet prevdata(string bookid,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindprev", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookid"].Value = bookid;

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
        public DataSet selecproof(string bookid, string filename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_proofad", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                if (filename == "" || filename.Length==1)
                {
                    objSqlCommand.Parameters["@filename"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@filename"].Value = filename;
                }
                objSqlCommand.Parameters.Add("@bookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookid"].Value = bookid;

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
        public DataSet findprec(string bookid, string filename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_proorec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;

                objSqlCommand.Parameters.Add("@bookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookid"].Value = bookid;

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
