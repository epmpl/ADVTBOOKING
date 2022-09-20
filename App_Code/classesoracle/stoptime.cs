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
/// Summary description for stoptime
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class stoptime : orclconnection
    {
        public stoptime()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet saveaddeduct(string compcode, string unitcode, string days, string hour, string createdby, string seq, string extra1, string extra2, string extra3, string extra4)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_STOPTIME_INSERT", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
              
                objOraclecommand.Parameters.Add("pcompcode", OracleType.VarChar).Value = compcode;
                objOraclecommand.Parameters.Add("punitcode", OracleType.VarChar).Value = unitcode;
                objOraclecommand.Parameters.Add("pdays", OracleType.VarChar).Value = days;
                objOraclecommand.Parameters.Add("ptime", OracleType.VarChar).Value = hour;
                objOraclecommand.Parameters.Add("pcreatedby", OracleType.VarChar).Value = createdby;
                objOraclecommand.Parameters.Add("pseqno", OracleType.VarChar).Value = seq;
                objOraclecommand.Parameters.Add("pextra1", OracleType.VarChar).Value = extra1;
                objOraclecommand.Parameters.Add("pextra2", OracleType.VarChar).Value = extra2;
                objOraclecommand.Parameters.Add("pextra3", OracleType.VarChar).Value = extra3;
                objOraclecommand.Parameters.Add("pextra4", OracleType.VarChar).Value = extra3;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }




        public DataSet execdata(string compcode, string unitcode, string days, string hour, string createdby, string seq, string extra1, string extra2, string extra3, string extra4)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_STOPTIME_EXEC", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("punitcode", OracleType.VarChar);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = unitcode;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1b = new OracleParameter("pdays", OracleType.VarChar);
                prm1b.Direction = ParameterDirection.Input;
                prm1b.Value = days;
                objOraclecommand.Parameters.Add(prm1b);


                OracleParameter prm1d = new OracleParameter("ptime", OracleType.VarChar);
                prm1d.Direction = ParameterDirection.Input;
                prm1d.Value = hour;
                objOraclecommand.Parameters.Add(prm1d);

                OracleParameter prm1e = new OracleParameter("pcreatedby", OracleType.VarChar);
                prm1e.Direction = ParameterDirection.Input;
                prm1e.Value = createdby;
                objOraclecommand.Parameters.Add(prm1e);

                OracleParameter prm1f = new OracleParameter("pseq", OracleType.VarChar);
                prm1f.Direction = ParameterDirection.Input;
                prm1f.Value = seq;
                objOraclecommand.Parameters.Add(prm1f);

                OracleParameter prm1g = new OracleParameter("pextra1", OracleType.VarChar);
                prm1g.Direction = ParameterDirection.Input;
                prm1g.Value = extra1;
                objOraclecommand.Parameters.Add(prm1g);

                OracleParameter prm1h = new OracleParameter("pextra2", OracleType.VarChar);
                prm1h.Direction = ParameterDirection.Input;
                prm1h.Value = extra2;
                objOraclecommand.Parameters.Add(prm1h);

                OracleParameter prm1i = new OracleParameter("pextra3", OracleType.VarChar);
                prm1i.Direction = ParameterDirection.Input;
                prm1i.Value = extra3;
                objOraclecommand.Parameters.Add(prm1i);

                OracleParameter prm1l = new OracleParameter("pextra4", OracleType.VarChar);
                prm1l.Direction = ParameterDirection.Input;
                prm1l.Value = extra4;
                objOraclecommand.Parameters.Add(prm1l);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
    }
}
