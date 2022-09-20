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
/// Summary description for editionmast_circulation
/// </summary>
namespace NewAdbooking.Classes
{
    public class editionmast_circulation:connection 
    {
        public editionmast_circulation()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindCity(string dstcode, string code1, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindcity_edition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@distcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@distcode"].Value = code1;

                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = code1;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@uid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uid"].Value = userid;

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

        public DataSet contactseq()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionpop_info_SEQ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet saveinfo(string seq, string compcode, string crcno, string rdrno, string state, string district, string city,string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("save_cicu_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comcode"].Value = compcode ;

                objSqlCommand.Parameters.Add("@crcno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@crcno"].Value = crcno;

                objSqlCommand.Parameters.Add("@rdrno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rdrno"].Value = rdrno ;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state ;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = district ;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;
                
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
        public DataSet gridbind(string comcode, string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("query_edtiongrid_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

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
        //public DataSet getstatename(string comcode, string gbstate)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("cir_get_state1", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pcomp_code"].Value = comcode;

        //        objSqlCommand.Parameters.Add("@pstate_code", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pstate_code"].Value = gbstate;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}
        public DataSet get_db_accname(string comp_code, string db_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = new SqlCommand();
                string query = "select dbo.fa_get_account_name('" + comp_code + "','" + db_acc + "')";// from dual";
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
         
        public DataSet gridtxt(string comcode, string seq)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fill_grid_txt_edition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

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
        public DataSet saveinfomain(string seq, string compcode, string crcno, string rdrno, string state, string district, string city, string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("save_cicu_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcrcno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcrcno"].Value = crcno;

                objSqlCommand.Parameters.Add("@prdrno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prdrno"].Value = rdrno;

                objSqlCommand.Parameters.Add("@pstate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstate"].Value = state;

                objSqlCommand.Parameters.Add("@pdist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdist"].Value = district;

                objSqlCommand.Parameters.Add("@pcity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcity"].Value = city;

                objSqlCommand.Parameters.Add("@pseq", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pseq"].Value = seq;

                objSqlCommand.Parameters.Add("@peditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@peditioncode"].Value = editioncode;

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

        public DataSet qryinfo(string comcode, string pedcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("query_circ_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pedcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedcode"].Value = pedcode;

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

        public DataSet updateinfo(string seq, string comcode, string crcno, string rdrno, string state, string district, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("update_circu_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pcrcno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcrcno"].Value = crcno;

                objSqlCommand.Parameters.Add("@prdrno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prdrno"].Value = rdrno;

                objSqlCommand.Parameters.Add("@pstate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstate"].Value = state;

                objSqlCommand.Parameters.Add("@pdist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdist"].Value = district;

                objSqlCommand.Parameters.Add("@pcity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcity"].Value = city;

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

        public DataSet deleteinfo(string seq, string comcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("delete_circ_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

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
        
        public DataSet getstatename(string comcode, string gbstate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = new SqlCommand();
                string query = "select [dbo].[cir_get_state1]('" + comcode + "','" + gbstate + "')";//as State_Name from state_mst";
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();

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
        public DataSet getcityname(string comcode, string dbcity)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = new SqlCommand();
                string query = "select [dbo].[cir_get_city_new]('" + comcode + "','" + dbcity + "')";//as State_Name from state_mst";
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();

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

        public DataSet getdisticname(string comcode, string gbstate, string dbdistrict)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = new SqlCommand();
                string query = "select [dbo].[cir_get_distName]('" + comcode + "','" + dbdistrict + "')";//as State_Name from state_mst";
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();

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
        public DataSet deleteinfotemp(string seq, string comcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("delete_circ_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

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
        public DataSet updateinfotemp(string seq, string comcode, string crcno, string rdrno, string state, string district, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("update_circu_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pcrcno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcrcno"].Value = crcno;

                objSqlCommand.Parameters.Add("@prdrno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prdrno"].Value = rdrno;

                objSqlCommand.Parameters.Add("@pstate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstate"].Value = state;

                objSqlCommand.Parameters.Add("@pdist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdist"].Value = district;

                objSqlCommand.Parameters.Add("@pcity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcity"].Value = city;

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

        public DataSet cityname(string comcode,string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Fill_city_dist_state", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pubcentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcentcode"].Value = pubcode;

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
        public DataSet Dist_State(string comcode, string Citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Fill_dist", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = Citycode;

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