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
/// Summary description for agency_type_slab
/// </summary>
/// 

namespace NewAdbooking.Classes
{
    public class agency_type_slab : connection
    {
        public agency_type_slab()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet saveagencytype(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_agency_type_slab", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@agency_type", SqlDbType.VarChar);
                com.Parameters["@agency_type"].Value = agency_type;

                com.Parameters.Add("@comm_type", SqlDbType.VarChar);
                com.Parameters["@comm_type"].Value = comm_type;


                com.Parameters.Add("@comm_rate", SqlDbType.VarChar);

                com.Parameters["@comm_rate"].Value = comm_rate;
                if (comm_rate == "")
                {
                    com.Parameters["@comm_rate"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@from_days", SqlDbType.VarChar);
                com.Parameters["@from_days"].Value = from_days;

                com.Parameters.Add("@till_days", SqlDbType.VarChar);
                com.Parameters["@till_days"].Value = till_days;



                com.Parameters.Add("@valid_from", SqlDbType.VarChar);
                com.Parameters["@valid_from"].Value = valid_from;




                com.Parameters.Add("@valid_to", SqlDbType.VarChar);
                com.Parameters["@valid_to"].Value = valid_to;




                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;



                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                com.Parameters["@extra1"].Value = extra1;




                com.Parameters.Add("@extra2", SqlDbType.VarChar);
                com.Parameters["@extra2"].Value = extra2;





                com.Parameters.Add("@extra3", SqlDbType.VarChar);
                com.Parameters["@extra3"].Value = extra3;



                com.Parameters.Add("@extra4", SqlDbType.VarChar);
                com.Parameters["@extra4"].Value = extra4;



                com.Parameters.Add("@extra5", SqlDbType.VarChar);
                com.Parameters["@extra5"].Value = extra5;

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


        public DataSet saveagencytype_UPDATE(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_agency_type_slab_UPDATE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@agency_type", SqlDbType.VarChar);
                com.Parameters["@agency_type"].Value = agency_type;

                com.Parameters.Add("@comm_type", SqlDbType.VarChar);
                com.Parameters["@comm_type"].Value = comm_type;


                com.Parameters.Add("@comm_rate", SqlDbType.VarChar);

                com.Parameters["@comm_rate"].Value = comm_rate;



                com.Parameters.Add("@from_days", SqlDbType.VarChar);
                com.Parameters["@from_days"].Value = from_days;

                com.Parameters.Add("@till_days", SqlDbType.VarChar);
                com.Parameters["@till_days"].Value = till_days;



                com.Parameters.Add("@valid_from", SqlDbType.VarChar);
                com.Parameters["@valid_from"].Value = valid_from;




                com.Parameters.Add("@valid_to", SqlDbType.VarChar);
                com.Parameters["@valid_to"].Value = valid_to;




                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;



                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                com.Parameters["@extra1"].Value = extra1;




                com.Parameters.Add("@extra2", SqlDbType.VarChar);
                com.Parameters["@extra2"].Value = extra2;





                com.Parameters.Add("@extra3", SqlDbType.VarChar);
                com.Parameters["@extra3"].Value = extra3;



                com.Parameters.Add("@extra4", SqlDbType.VarChar);
                com.Parameters["@extra4"].Value = extra4;



                com.Parameters.Add("@extra5", SqlDbType.VarChar);
                com.Parameters["@extra5"].Value = extra5;

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






        public DataSet agencytypeexecute(string compcode, string agency_type)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_agency_type_slab_exec", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@agency_type", SqlDbType.VarChar);
                com.Parameters["@agency_type"].Value = agency_type;

             

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



        public DataSet agencytypedelete(string compcode, string agency_type, string cotype, string corate, string hdnsescode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_agency_type_slab_delete", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@agency_type", SqlDbType.VarChar);
                com.Parameters["@agency_type"].Value = agency_type;

                com.Parameters.Add("@commtype", SqlDbType.VarChar);
                com.Parameters["@commtype"].Value = cotype;

                com.Parameters.Add("@commrate", SqlDbType.VarChar);
                com.Parameters["@commrate"].Value = corate;

                com.Parameters.Add("@hdnsescode", SqlDbType.VarChar);
                com.Parameters["@hdnsescode"].Value = hdnsescode;


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




        public DataSet cheakduplicacy(string compcode, string cotype, string corate, string fromdays, string todays,string validfrom,string validto)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_agency_type_slab_duplicate", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@commtype", SqlDbType.VarChar);
                com.Parameters["@commtype"].Value = cotype;

                com.Parameters.Add("@commrate", SqlDbType.VarChar);
                com.Parameters["@commrate"].Value = corate;

                com.Parameters.Add("@fromdays", SqlDbType.VarChar);
                com.Parameters["@fromdays"].Value = fromdays;

                com.Parameters.Add("@todays", SqlDbType.VarChar);
                com.Parameters["@todays"].Value = todays;

                com.Parameters.Add("@validfrom", SqlDbType.VarChar);
                com.Parameters["@validfrom"].Value = validfrom;

                com.Parameters.Add("@validto", SqlDbType.VarChar);
                com.Parameters["@validto"].Value = validto;


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


        public DataSet agencytypeexecute1123(string agencode, string compcode, string userid, string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_agency_type_slab_exec12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

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

        public DataSet slabchk(string sf, string st, string txtfrom, string txtto, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("slabchk_b", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@sf", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sf"].Value = sf;

                objSqlCommand.Parameters.Add("@st", SqlDbType.VarChar);
                objSqlCommand.Parameters["@st"].Value = st;

                objSqlCommand.Parameters.Add("@txtfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfrom"].Value = txtfrom;

                objSqlCommand.Parameters.Add("@txtto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtto"].Value = txtto;

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
