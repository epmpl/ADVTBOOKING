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
using System.Data.OracleClient;

/// <summary>
/// Summary description for ContractDetails_pop
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class ContractDetails_pop : orclconnection
    {
        public ContractDetails_pop()
        {
		//
		// TODO: Add constructor logic here
		//
        }
        public DataSet saveinfo(string seq, string comcode, string pucode, string cntctname, string cntctno, string desc)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("save_cntct_temp", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pucode", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pucode;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("cntctnm", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = cntctname;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cntctno", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cntctno;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descrptn", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = desc;
                objOrclCommand.Parameters.Add(prm6);

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }

        public DataSet saveinfomain(string seq, string comcode, string pucode, string cntctname, string cntctno, string desc)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("save_cntct_main", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pucode", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pucode;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("cntctnm", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = cntctname;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cntctno", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cntctno;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descrptn", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = desc;
                objOrclCommand.Parameters.Add(prm6);

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }

        public DataSet qryinfo(string comcode, string pucode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("query_cntct_temp", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pucode;
                objOrclCommand.Parameters.Add(prm2);

                objOrclCommand.Parameters.Add("paccounts", OracleType.Cursor);
                objOrclCommand.Parameters["paccounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet; 

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }

        public DataSet updateinfo(string seq, string comcode, string pucode, string cntctname, string cntctno, string desc)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("update_cntct_main", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pucode", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pucode;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("cntctnm", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = cntctname;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cntctno", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cntctno;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descrptn", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = desc;
                objOrclCommand.Parameters.Add(prm6);

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }

        public DataSet deleteinfo(string seq, string comcode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("delete_cntct_main", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = seq;
                objOrclCommand.Parameters.Add(prm2);

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }

        public DataSet gridtxt(string comcode, string seq)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("fill_grid_txt", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcmcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pseq", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = seq;
                objOrclCommand.Parameters.Add(prm2);

                objOrclCommand.Parameters.Add("paccounts", OracleType.Cursor);
                objOrclCommand.Parameters["paccounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }

        public DataSet gridbind(string comcode, string pucode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("query_edtiongrid_temp", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("edition_code", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pucode;
                objOrclCommand.Parameters.Add(prm2);

                objOrclCommand.Parameters.Add("paccounts", OracleType.Cursor);
                objOrclCommand.Parameters["paccounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
    }
}

