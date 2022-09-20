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
/// Summary description for tv_booking_transaction
/// </summary>
namespace NewAdbooking.Classes
{
    public class tv_booking_transaction : connection
    {
        public tv_booking_transaction()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet get10ClientName(string compcode, string client, string center, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_get10clientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getchannelfromdeal(string compcode, string modetype, string deal, string fromdate, string todate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getchannelfromdeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@pmodetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmodetype"].Value = modetype;
                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;
                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@todate"].Value = todate;
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet binddeal(string compcode, string deal, string client, string agency, string adtype, string modetype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@modetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modetype"].Value = modetype;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10deal(string compcode, string deal, string client, string agency, string adtype, string modetype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind10deal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@modetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modetype"].Value = modetype;

                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet getagencyfromdeal(string compcode, string deal)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getagencyfromdeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet getclientfromdeal(string compcode, string deal)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getclientfromdeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindallinfo(string compcode, string deal, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindallinfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindtpid(string compcode, string tpid, string channel, string location, string client, string agency, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_clipbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@tpid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tpid"].Value = tpid;

                objSqlCommand.Parameters.Add("@pUNIT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUNIT"].Value = unit;

                objSqlCommand.Parameters.Add("@pCHANNEL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCHANNEL"].Value = channel;

                objSqlCommand.Parameters.Add("@pLOCATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pLOCATION"].Value = location;

                objSqlCommand.Parameters.Add("@pAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pAGENCY"].Value = agency;

                objSqlCommand.Parameters.Add("@pCLIENTCD", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCLIENTCD"].Value = client;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10tpid(string compcode, string tpid, string channel, string location, string client, string agency, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_clip10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@tpid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tpid"].Value = tpid;

                objSqlCommand.Parameters.Add("@pUNIT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUNIT"].Value = unit;

                objSqlCommand.Parameters.Add("@pCHANNEL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCHANNEL"].Value = channel;

                objSqlCommand.Parameters.Add("@pLOCATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pLOCATION"].Value = location;

                objSqlCommand.Parameters.Add("@pAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pAGENCY"].Value = agency;

                objSqlCommand.Parameters.Add("@pCLIENTCD", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCLIENTCD"].Value = client;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindbtb(string compcode, string deal, string btbval, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_btbbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@btbval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@btbval"].Value = btbval;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10btb(string compcode, string deal, string btbval, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_btb10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@btbval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@btbval"].Value = btbval;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlDataAdapter = new SqlDataAdapter();
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



        public DataSet bindfromto10band(string compcode, string deal, string fromband, string btbcode, string uom, string ros, string channel, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_get_time_band", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_btb", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_btb"].Value = btbcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;


                objSqlCommand.Parameters.Add("@p_btb_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_btb_code"].Value = ros;

                objSqlCommand.Parameters.Add("@p_ros_rod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_ros_rod"].Value = uom;

                objSqlCommand.Parameters.Add("@p_channel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_channel"].Value = channel;

                objSqlCommand.Parameters.Add("@p_deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_deal"].Value = deal;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindfromtoband(string compcode, string deal, string fromband, string btbcode, string uom, string ros, string channel, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_get_time_band", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_btb", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_btb"].Value = btbcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;


                objSqlCommand.Parameters.Add("@p_btb_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_btb_code"].Value = ros;

                objSqlCommand.Parameters.Add("@p_ros_rod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_ros_rod"].Value = uom;

                objSqlCommand.Parameters.Add("@p_channel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_channel"].Value = channel;

                objSqlCommand.Parameters.Add("@p_deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_deal"].Value = deal;

                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet getdatefromdeal(string compcode, string deal)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_BINDDATEFROMDEAL", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                if (deal == "")
                    objSqlCommand.Parameters["@deal"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet binduom(string compcode, string deal, string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_uombind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10uom(string compcode, string deal, string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_uom10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindadtype(string compcode, string deal, string adtype, string channel, string location, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_adtypebind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlCommand.Parameters.Add("@plocation_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plocation_code"].Value = location;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10adtype(string compcode, string deal, string adtype, string channel, string location, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_adtype10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlCommand.Parameters.Add("@plocation_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plocation_code"].Value = location;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindprogram(string compcode, string deal, string program, string channel, string location, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_programbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@program1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@program1"].Value = program;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlCommand.Parameters.Add("@ploc_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ploc_id"].Value = location;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10program(string compcode, string deal, string program, string channel, string location, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_program10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@program1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@program1"].Value = program;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlCommand.Parameters.Add("@ploc_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ploc_id"].Value = location;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlDataAdapter = new SqlDataAdapter();
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



        public DataSet bindbookgrid(string compcode, string unit, string channel, string location, string adtype, string airdate, string deal, string btbcode, string frbtbcode, string tobtbcode, string paidbonus, string dur, string tapid, string prgid, string noofspot, string ratetype, string returndata, string insertid, string status, string fromdate, string todate, string dateformat, string category, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_fetch_booking_data", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit_code"].Value = unit;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlCommand.Parameters.Add("@plocation_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plocation_code"].Value = location;

                objSqlCommand.Parameters.Add("@pad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pad_type"].Value = adtype;

                objSqlCommand.Parameters.Add("@pair_date", SqlDbType.VarChar);
                if (airdate == "")
                    objSqlCommand.Parameters["@pair_date"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pair_date"].Value = airdate;

                objSqlCommand.Parameters.Add("@pdealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdealno"].Value = deal;

                objSqlCommand.Parameters.Add("@pbtb_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbtb_code"].Value = btbcode;

                objSqlCommand.Parameters.Add("@pfr_btb_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfr_btb_code"].Value = frbtbcode;

                objSqlCommand.Parameters.Add("@pto_btb_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pto_btb_code"].Value = tobtbcode;

                objSqlCommand.Parameters.Add("@ppaid_bonus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaid_bonus"].Value = paidbonus;

                objSqlCommand.Parameters.Add("@pdur", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdur"].Value = dur;

                objSqlCommand.Parameters.Add("@ptap_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptap_id"].Value = tapid;

                objSqlCommand.Parameters.Add("@pprg_id", SqlDbType.VarChar);
                if (prgid == "" || prgid == null)
                    objSqlCommand.Parameters["@pprg_id"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pprg_id"].Value = prgid;

                objSqlCommand.Parameters.Add("@pno_of_spot", SqlDbType.VarChar);
                if (noofspot == "" || noofspot == null)
                    objSqlCommand.Parameters["@pno_of_spot"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pno_of_spot"].Value = noofspot;

                objSqlCommand.Parameters.Add("@prate_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prate_type"].Value = ratetype;

                objSqlCommand.Parameters.Add("@p_return_data", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_return_data"].Value = returndata;

                objSqlCommand.Parameters.Add("@p_pref_sec", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_pref_sec"].Value = 10;

                objSqlCommand.Parameters.Add("@pinsert_id", SqlDbType.VarChar);
                if (insertid == "" || insertid == null)
                    objSqlCommand.Parameters["@pinsert_id"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pinsert_id"].Value = insertid;

                objSqlCommand.Parameters.Add("@pbook_status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbook_status"].Value = status;

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@pfrom_date"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@pfrom_date"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@pto_date", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    objSqlCommand.Parameters["@pto_date"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@pto_date"].Value = todate;
                }


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pcatg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcatg"].Value = category;

                objSqlCommand.Parameters.Add("@p_agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_agency"].Value = agency;

                objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra8"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra9"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra10"].Value = System.DBNull.Value;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet get10Exec(string compcode, string execname, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_get10Exec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet get10retainer(string compcode, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GET10RETAINER", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("@PUBCENTER", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUBCENTER"].Value = center;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10Product(string compcode, string product, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_get10Product", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;





                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet insertintoelectronicbooking(string compcode, string adtype1, string bookingdate, string branch, string bookedby, string bookingid, string prebookingid, string client, string agency, string deal, string clientadd, string agencyadd, string subagency, string agencytype, string mobileno, string status1, string agencypaymode, string creditperiod, string rono, string rodate, string rostatus, string dockitno, string keyno, string execode, string execzone, string agencyoutstand, string retainer, string booktype, string color, string adcategory, string appby, string audit, string product, string brand, string varient, string campain, string caption, string materialstatus, string bartertype, string ratecode, string cardrate, string cardamt, string contractrate, string deviation, string discount, string discountpre, string premiumamt, string premiumper, string specialdisc, string specialdiscper, string spacialcharges, string addagencycommrate, string addagencycommrateper, string grossamt, string Retainercomm, string Retainercommper, string billcycle, string revenue, string paymenttype, string billstatus, string cashdiscount, string cashrecieved, string cardname, string cardtype, string expirydate, string drpmonth, string drpyear, string cardno, string chqno, string chqamt, string chqdate, string bankname, string ourbank, string billto, string receipt, string tradedisc, string chktrade, string billamt, string billremark, string userid, string flag, string hidattach1, string hidattach2, string fmg, string fromdealdate, string todaeldate, string modetype, string representative)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertupdateintoelecbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

                objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.DateTime);
                if (bookingdate == "" || bookingdate == null)
                {
                    objSqlCommand.Parameters["@bookingdate"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = bookingdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    bookingdate = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;
                }

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@bookedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookedby"].Value = bookedby;

                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@prebookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prebookingid"].Value = prebookingid;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@clientadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientadd"].Value = clientadd;

                objSqlCommand.Parameters.Add("@agencyadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyadd"].Value = agencyadd;

                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status1;

                objSqlCommand.Parameters.Add("@agencypaymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencypaymode"].Value = agencypaymode;

                objSqlCommand.Parameters.Add("@creditperiod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditperiod"].Value = creditperiod;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr1 = rodate.Split('/');
                    string dd1 = arr1[0];
                    string mm1 = arr1[1];
                    string yy1 = arr1[2];
                    rodate = mm1 + "/" + dd1 + "/" + yy1;
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }


                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = execode;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@agencyoutstand", SqlDbType.Decimal);
                if (agencyoutstand == "" || agencyoutstand == null)
                    objSqlCommand.Parameters["@agencyoutstand"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@agencyoutstand"].Value = agencyoutstand;

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = retainer;

                objSqlCommand.Parameters.Add("@booktype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktype"].Value = booktype;

                objSqlCommand.Parameters.Add("@color1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color1"].Value = color;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@appby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@appby"].Value = appby;

                objSqlCommand.Parameters.Add("@audit1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit1"].Value = audit;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand1"].Value = brand;

                objSqlCommand.Parameters.Add("@varient1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient1"].Value = varient;

                objSqlCommand.Parameters.Add("@campain1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campain1"].Value = campain;

                objSqlCommand.Parameters.Add("@caption1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption1"].Value = caption;

                objSqlCommand.Parameters.Add("@materialstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@materialstatus"].Value = materialstatus;

                objSqlCommand.Parameters.Add("@bartertype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartertype"].Value = bartertype;

                objSqlCommand.Parameters.Add("@ratecode11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode11"].Value = ratecode;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardrate"].Value = cardrate;

                objSqlCommand.Parameters.Add("@cardamt", SqlDbType.Decimal);
                if (cardamt == "" || cardamt == null)
                    objSqlCommand.Parameters["@cardamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardamt"].Value = cardamt;

                objSqlCommand.Parameters.Add("@contractrate", SqlDbType.Decimal);
                if (contractrate == "" || contractrate == null)
                    objSqlCommand.Parameters["@contractrate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contractrate"].Value = contractrate;

                objSqlCommand.Parameters.Add("@deviation1", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                    objSqlCommand.Parameters["@deviation1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@deviation1"].Value = deviation;

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@discount"].Value = discount;

                objSqlCommand.Parameters.Add("@discountpre", SqlDbType.Decimal);
                if (discountpre == "" || discountpre == null)
                    objSqlCommand.Parameters["@discountpre"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@discountpre"].Value = discountpre;

                objSqlCommand.Parameters.Add("@premiumamt", SqlDbType.Decimal);
                if (premiumamt == "" || premiumamt == null)
                    objSqlCommand.Parameters["@premiumamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@premiumamt"].Value = premiumamt;

                objSqlCommand.Parameters.Add("@premiumper", SqlDbType.Decimal);
                if (premiumper == "" || premiumper == null)
                    objSqlCommand.Parameters["@premiumper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@premiumper"].Value = premiumper;

                objSqlCommand.Parameters.Add("@specialdisc", SqlDbType.Decimal);
                if (specialdisc == "" || specialdisc == null)
                    objSqlCommand.Parameters["@specialdisc"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@specialdisc"].Value = specialdisc;

                objSqlCommand.Parameters.Add("@specialdiscper", SqlDbType.Decimal);
                if (specialdiscper == "" || specialdiscper == null)
                    objSqlCommand.Parameters["@specialdiscper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@specialdiscper"].Value = specialdiscper;

                objSqlCommand.Parameters.Add("@spacialcharges", SqlDbType.Decimal);
                if (spacialcharges == "" || spacialcharges == null)
                    objSqlCommand.Parameters["@spacialcharges"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@spacialcharges"].Value = spacialcharges;

                objSqlCommand.Parameters.Add("@addagencycommrate", SqlDbType.Decimal);
                if (addagencycommrate == "" || addagencycommrate == null)
                    objSqlCommand.Parameters["@addagencycommrate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@addagencycommrate"].Value = addagencycommrate;

                objSqlCommand.Parameters.Add("@addagencycommrateper", SqlDbType.Decimal);
                if (addagencycommrateper == "" || addagencycommrateper == null)
                    objSqlCommand.Parameters["@addagencycommrateper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@addagencycommrateper"].Value = addagencycommrateper;

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamt"].Value = grossamt;

                objSqlCommand.Parameters.Add("@Retainercomm", SqlDbType.Decimal);
                if (Retainercomm == "" || Retainercomm == null)
                    objSqlCommand.Parameters["@Retainercomm"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@Retainercomm"].Value = Retainercomm;

                objSqlCommand.Parameters.Add("@Retainercommper", SqlDbType.Decimal);
                if (Retainercommper == "" || Retainercommper == null)
                    objSqlCommand.Parameters["@Retainercommper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@Retainercommper"].Value = Retainercommper;

                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.Decimal);
                if (billcycle == "" || billcycle == null)
                    objSqlCommand.Parameters["@billcycle"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;

                objSqlCommand.Parameters.Add("@paymenttype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymenttype"].Value = paymenttype;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@cashdiscount", SqlDbType.Decimal);
                if (cashdiscount == "" || cashdiscount == null)
                    objSqlCommand.Parameters["@cashdiscount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cashdiscount"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.Decimal);
                if (cashrecieved == "" || cashrecieved == null)
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cashrecieved"].Value = cashrecieved;

                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                if (cardtype == "" || cardtype == null)
                    objSqlCommand.Parameters["@cardtype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@expirydate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@expirydate"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@drpmonth1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpmonth1"].Value = drpmonth;

                objSqlCommand.Parameters.Add("@drpyear1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpyear1"].Value = drpyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@chqno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chqno"].Value = chqno;

                objSqlCommand.Parameters.Add("@chqamt", SqlDbType.Decimal);
                if (chqamt == "" || chqamt == null)
                    objSqlCommand.Parameters["@chqamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@chqamt"].Value = chqamt;

                objSqlCommand.Parameters.Add("@chqdate", SqlDbType.DateTime);
                if (chqdate == "" || chqdate == null)
                {
                    objSqlCommand.Parameters["@chqdate"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr2 = chqdate.Split('/');
                    string dd2 = arr2[0];
                    string mm2 = arr2[1];
                    string yy2 = arr2[2];
                    chqdate = mm2 + "/" + dd2 + "/" + yy2;
                    objSqlCommand.Parameters["@chqdate"].Value = chqdate;
                }

                objSqlCommand.Parameters.Add("@bankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bankname"].Value = bankname;

                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt"].Value = receipt;

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@tradedisc"].Value = tradedisc;

                objSqlCommand.Parameters.Add("@chktrade", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chktrade"].Value = chktrade;

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null)
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamt"].Value = billamt;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@userid1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid1"].Value = userid;

                objSqlCommand.Parameters.Add("@flag1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag1"].Value = flag;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = hidattach1;


                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = hidattach2;

                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmg;

                objSqlCommand.Parameters.Add("@fromdealdate", SqlDbType.VarChar);
                if (fromdealdate == "" || fromdealdate == null)
                {
                    objSqlCommand.Parameters["@fromdealdate"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr2 = fromdealdate.Split('/');
                    string dd2 = arr2[0];
                    string mm2 = arr2[1];
                    string yy2 = arr2[2];
                    fromdealdate = mm2 + "/" + dd2 + "/" + yy2;
                    objSqlCommand.Parameters["@fromdealdate"].Value = fromdealdate;
                }

                objSqlCommand.Parameters.Add("@todaeldate", SqlDbType.VarChar);
                if (todaeldate == "" || todaeldate == null)
                {
                    objSqlCommand.Parameters["@todaeldate"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr2 = todaeldate.Split('/');
                    string dd2 = arr2[0];
                    string mm2 = arr2[1];
                    string yy2 = arr2[2];
                    todaeldate = mm2 + "/" + dd2 + "/" + yy2;
                    objSqlCommand.Parameters["@todaeldate"].Value = todaeldate;
                }

                objSqlCommand.Parameters.Add("@modetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modetype"].Value = modetype;

                objSqlCommand.Parameters.Add("@prepresentative", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prepresentative"].Value = representative;



                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet insertintoelectronicchild(string compcode, string userid, string bookingid, string revenue, string channel, string location, string advtype, string ratetype, string scheduledate, string btbcode, string fromband, string toband, string break1, string position, string progname, string padebonus, string noofspote, string tapeid, string duration, string rate, string gross, string flag, string insertid, string status, string seqno, string category, string clientcode, string productcd, string brandcd)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertupdateintoelechild", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid1"].Value = userid;

                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;

                objSqlCommand.Parameters.Add("@channel1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel1"].Value = channel;

                objSqlCommand.Parameters.Add("@location1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@location1"].Value = location;

                objSqlCommand.Parameters.Add("@advtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advtype1"].Value = advtype;

                objSqlCommand.Parameters.Add("@ratetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratetype"].Value = ratetype;

                objSqlCommand.Parameters.Add("@scheduledate", SqlDbType.DateTime);
                if (scheduledate == "" || scheduledate == null)
                {
                    objSqlCommand.Parameters["@scheduledate"].Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = scheduledate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    scheduledate = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@scheduledate"].Value = scheduledate;
                }

                objSqlCommand.Parameters.Add("@btbcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@btbcode"].Value = btbcode;

                objSqlCommand.Parameters.Add("@fromband", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromband"].Value = fromband;

                objSqlCommand.Parameters.Add("@toband", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toband"].Value = toband;

                objSqlCommand.Parameters.Add("@break1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@break1"].Value = break1;

                objSqlCommand.Parameters.Add("@position1", SqlDbType.Decimal);
                if (position == "" || position == null)
                    objSqlCommand.Parameters["@position1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@position1"].Value = position;

                objSqlCommand.Parameters.Add("@progname1", SqlDbType.VarChar);
                if (progname == "" || progname == null)
                    objSqlCommand.Parameters["@progname1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@progname1"].Value = progname;

                objSqlCommand.Parameters.Add("@padebonus1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padebonus1"].Value = padebonus;

                objSqlCommand.Parameters.Add("@noofspote", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofspote"].Value = noofspote;

                objSqlCommand.Parameters.Add("@tapeid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tapeid"].Value = tapeid;

                objSqlCommand.Parameters.Add("@duration1", SqlDbType.Decimal);
                if (duration == "" || duration == null)
                    objSqlCommand.Parameters["@duration1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@duration1"].Value = duration;

                objSqlCommand.Parameters.Add("@rate11", SqlDbType.Decimal);
                if (rate == "" || rate == null)
                    objSqlCommand.Parameters["@rate11"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate11"].Value = rate;

                objSqlCommand.Parameters.Add("@gross11", SqlDbType.Decimal);
                if (gross == "" || gross == null)
                    objSqlCommand.Parameters["@gross11"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@gross11"].Value = gross;

                objSqlCommand.Parameters.Add("@flag1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag1"].Value = flag;

                objSqlCommand.Parameters.Add("@insertid1", SqlDbType.Decimal);
                if (insertid == "" || insertid == null)
                    objSqlCommand.Parameters["@insertid1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@insertid1"].Value = insertid;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status;

                objSqlCommand.Parameters.Add("@seqno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno"].Value = seqno;

                objSqlCommand.Parameters.Add("@category1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category1"].Value = category;

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("@productcd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productcd"].Value = productcd;

                objSqlCommand.Parameters.Add("@brandcd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brandcd"].Value = brandcd;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet insertupdatehtml(string compcode, string bookingid, string html, string flag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_insertbookhtml", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@html", SqlDbType.Text);
                objSqlCommand.Parameters["@html"].Value = html;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet prevbooking(string compcode, string userid, string formname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("gettheprevbooking1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;



                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet tvbookingexecute(string compcode, string deal, string agencycode, string client, string bookingid, string dockitno, string keyno, string rono, string booking)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_bookingexecute", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                if (deal == "" || deal == null)
                    objSqlCommand.Parameters["@deal"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                if (agencycode == "" || agencycode == null)
                    objSqlCommand.Parameters["@agencycode"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "" || client == null)
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@client"].Value = client;


                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                if (bookingid == "" || bookingid == null)
                    objSqlCommand.Parameters["@bookingid"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                if (dockitno == "" || dockitno == null)
                    objSqlCommand.Parameters["@dockitno"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                if (keyno == "" || keyno == null)
                    objSqlCommand.Parameters["@keyno"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@keyno"].Value = keyno;


                objSqlCommand.Parameters.Add("@rono1", SqlDbType.VarChar);
                if (rono == "" || rono == null)
                    objSqlCommand.Parameters["@rono1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rono1"].Value = rono;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                if (booking == "" || booking == null)
                    objSqlCommand.Parameters["@booking"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@booking"].Value = booking;



                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet tvbookingexecutedet(string compcode, string bookingid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_bookingexecutedet", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                if (compcode == "" || compcode == null)
                    objSqlCommand.Parameters["@compcode"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                if (bookingid == "" || bookingid == null)
                    objSqlCommand.Parameters["@bookingid"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@bookingid"].Value = bookingid;





                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet tvbookinghtml(string compcode, string bookingid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_bookinghtml", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                if (compcode == "" || compcode == null)
                    objSqlCommand.Parameters["@compcode"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                if (bookingid == "" || bookingid == null)
                    objSqlCommand.Parameters["@bookingid"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@bookingid"].Value = bookingid;





                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindbindadcat(string compcode, string deal, string adcat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_adcatbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adcat1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat1"].Value = adcat;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bind10bindadcat(string compcode, string deal, string adcat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_adcat10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;

                objSqlCommand.Parameters.Add("@adcat1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat1"].Value = adcat;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet chkvalidateintable(string tablename, string columnname, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_value_validate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tablename;

                objSqlCommand.Parameters.Add("@pcolumn_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolumn_name"].Value = columnname;

                objSqlCommand.Parameters.Add("@pvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pvalue"].Value = value;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet chkvalidate(string channel, string deal, string btbcode, string padebonus, string tapid, string totalnoofspote)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_check_deal_value", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = channel;

                objSqlCommand.Parameters.Add("@pdealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdealno"].Value = deal;

                objSqlCommand.Parameters.Add("@pbtb_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbtb_code"].Value = btbcode;

                objSqlCommand.Parameters.Add("@ppaid_bonus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaid_bonus"].Value = padebonus;

                objSqlCommand.Parameters.Add("@pclipid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclipid"].Value = tapid;

                objSqlCommand.Parameters.Add("@p_tot_sec", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_tot_sec"].Value = totalnoofspote;

                objSqlCommand.Parameters.Add("@pextra", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bind10representative(string compcode, string resentative)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rep10bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = resentative;


                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindrepresentative(string compcode, string resentative)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("repbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = resentative;


                objSqlDataAdapter = new SqlDataAdapter();
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
        //////new bind bhanu
        public DataSet bind10agency_n(string compcode, string userid, string agency, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind10agencyforbooking_N", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = center;

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
        public DataSet bindagency_n(string compcode, string userid, string agency, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforbooking_N", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = center;

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
        public DataSet get10ClientName_n(string compcode, string client, string center, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_get10clientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getClientName_n(string compcode, string client, string center, string userid)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getExecbooking_n(string compcode, string execname, string value, string adtype,string branch, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getExecbooking_N", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = branch;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getretainer_n(string compcode, string center, string centermain, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETRETAINER", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("@PUBCENTER", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUBCENTER"].Value = center;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = centermain;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getteamname(string compcode, string teamname, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BIND_BOOKING_TEAM", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("@TEAMNAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@TEAMNAME"].Value = teamname;

                objSqlCommand.Parameters.Add("@EXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA1"].Value = extra1;

                objSqlCommand.Parameters.Add("@EXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA2"].Value = extra2;

                objSqlCommand.Parameters.Add("@EXTRA3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA3"].Value = extra3;

                objSqlCommand.Parameters.Add("@EXTRA4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA4"].Value = extra4;

                objSqlCommand.Parameters.Add("@EXTRA5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA5"].Value = extra5;

                objSqlDataAdapter = new SqlDataAdapter();
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
