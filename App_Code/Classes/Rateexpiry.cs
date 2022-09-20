using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Rateexpiry
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class Rateexpiry : connection
    {
        public Rateexpiry()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adtypbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advtypbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet bindcolortyp(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bindcolortype", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet ratecode(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("xlsratecode", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet uombind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binduom", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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


        public DataSet bind_category(string compcode, string ad_type)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("audit_cate", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@v_ad_type", SqlDbType.VarChar);
                com.Parameters["@v_ad_type"].Value = ad_type;






                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet packagebind_NEW(string compcode, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("Bindpackage_new", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;



                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet datafrgrid(string compcod, string adtyp, string rtcod, string categry, string color, string uom, string frdate, string todate, string packge, string extra1, string extra2, string dateformat, string solo, string edtn_flag)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("rate_expiry", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                if (compcod == "" || compcod == "0")
                    com.Parameters["@compcode"].Value = System.DBNull.Value;
                else
                com.Parameters["@compcode"].Value = compcod;

                com.Parameters.Add("@adtypcod", SqlDbType.VarChar);
                if (adtyp == "" || adtyp == "0")
                    com.Parameters["@adtypcod"].Value = System.DBNull.Value;
                else
                    com.Parameters["@adtypcod"].Value = adtyp;

                com.Parameters.Add("@ratecod", SqlDbType.VarChar);
                if (rtcod == "" || rtcod == "0")
                com.Parameters["@ratecod"].Value = System.DBNull.Value;
                else
                    com.Parameters["@ratecod"].Value = rtcod;

                com.Parameters.Add("@categrycod", SqlDbType.VarChar);
                if (categry == "" || categry == "0")
                    com.Parameters["@categrycod"].Value = System.DBNull.Value;
                else
                    com.Parameters["@categrycod"].Value = categry;

                com.Parameters.Add("@colorcod", SqlDbType.VarChar);
                if (color == "" || color == "0")
                    com.Parameters["@colorcod"].Value = System.DBNull.Value;
                else
                com.Parameters["@colorcod"].Value = color;

                com.Parameters.Add("@uomcod", SqlDbType.VarChar);
                if (uom == "" || uom == "0")
                    com.Parameters["@uomcod"].Value = System.DBNull.Value;
                else
                com.Parameters["@uomcod"].Value = uom;

                com.Parameters.Add("@frdate", SqlDbType.VarChar);
                if (frdate == "" || frdate == "0")
                {
                    com.Parameters["@uomcod"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = frdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        frdate = mm + "/" + dd + "/" + yy;
                    }
                }


                com.Parameters["@frdate"].Value = frdate;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (frdate == "" || frdate == "0")
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
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
                }
                com.Parameters["@todate"].Value = todate;

                com.Parameters.Add("@packgcod", SqlDbType.VarChar);
                if (packge == "" || packge == "0")
                    com.Parameters["@packgcod"].Value = System.DBNull.Value;
                else
                com.Parameters["@packgcod"].Value = packge;

                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                if (extra1 == "" || extra1 == "0")
                    com.Parameters["@extra1"].Value = System.DBNull.Value;
                else
                com.Parameters["@extra1"].Value = extra1;

                com.Parameters.Add("@extra2", SqlDbType.VarChar);
                if (extra2 == "" || extra2 == "0")
                    com.Parameters["@extra2"].Value = System.DBNull.Value;
                else
                com.Parameters["@extra2"].Value = extra2;



                com.Parameters.Add("@p_solo", SqlDbType.VarChar);
                if (solo == "" || extra2 == "0")
                    com.Parameters["@p_solo"].Value = System.DBNull.Value;
                else
                    com.Parameters["@p_solo"].Value = solo;



                com.Parameters.Add("@pedtn_flag", SqlDbType.VarChar);
                if (edtn_flag == "" || edtn_flag == "0")
                    com.Parameters["@pedtn_flag"].Value = System.DBNull.Value;
                else
                    com.Parameters["@pedtn_flag"].Value = edtn_flag;





                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }



        public DataSet saveexpdate(string compcod, string expdate, string ratecod, string dateformat, string extra1)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("rate_expupdat", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                if (compcod == "" || compcod == null)
                    com.Parameters["@compcode"].Value = System.DBNull.Value;
                else
                    com.Parameters["@compcode"].Value = compcod;

                com.Parameters.Add("@ratecod", SqlDbType.VarChar);
                if (ratecod == "" || ratecod == null)
                    com.Parameters["@ratecod"].Value = System.DBNull.Value;
                else
                    com.Parameters["@ratecod"].Value = ratecod;

                com.Parameters.Add("@expdate", SqlDbType.VarChar);
                if (expdate == "" || expdate == null)
                {
                    com.Parameters["expdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = expdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        expdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = expdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        expdate = mm + "/" + dd + "/" + yy;
                    }
                }


                com.Parameters["@expdate"].Value = expdate;

                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                if (extra1 == "" || extra1 == null)
                    com.Parameters["@extra1"].Value = System.DBNull.Value;
                else
                    com.Parameters["@extra1"].Value = extra1;
              

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


    }
}