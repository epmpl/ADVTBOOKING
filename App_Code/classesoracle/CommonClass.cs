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
using System.Collections;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{
    public class CommonClass : orclconnection
    {
        OracleConnection con = null;
        OracleCommand cmd = null;
        OracleDataAdapter da = new OracleDataAdapter();
        DataSet dsmain = new DataSet();
        ArrayList outputParameter = new ArrayList();
        ArrayList parameterNameArray = new ArrayList();
        ArrayList parameterDataTypeArray = new ArrayList();
        public CommonClass()
        {
            con = null;
            cmd = null;
            dsmain = new DataSet();
            da = new OracleDataAdapter();
            con = GetConnection();   
        }
        public static object GetStringOrDBNull(string value)
        {
            object o;
            if (string.IsNullOrEmpty(value))
            {
                o = DBNull.Value;
            }
            else
            {
                o = value;
            }
            return o;
        }
        public DataSet DynamicBindProcedure(string procedureName, string[] parameterValueArray)
        {
            try
            {
                con.Open();
                GetParameters(procedureName);                
                cmd = GetCommand(procedureName, ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                int x = 0;
                foreach (var paramsValue in parameterValueArray)
                {
                    if (parameterDataTypeArray[x].ToString().ToUpper() == "VARCHAR2")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), OracleType.VarChar).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "DATE")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), OracleType.DateTime).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "NUMBER")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), OracleType.Number).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "INT")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), OracleType.Int16).Value = GetStringOrDBNull(paramsValue);
                    }
                    else
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), OracleType.VarChar).Value = GetStringOrDBNull(paramsValue);
                    }
                    x++;
                }
                foreach (string outputParameternm in outputParameter)
                {
                    cmd.Parameters.Add(outputParameternm, OracleType.Cursor).Direction = ParameterDirection.Output;
                }
                da.SelectCommand = cmd;
                da.Fill(dsmain);                
                return dsmain;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                con.Close();
            }
        }
        void GetParameters(string procedureName)
        {
            if (procedureName.Contains("."))
            {
                procedureName = procedureName.Split('.').Last();
            }
            DataSet ds = new DataSet();
            cmd = GetCommand("inv_get_procedure_params", ref con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("pprocedure_nm", OracleType.VarChar).Value = GetStringOrDBNull(procedureName);
            cmd.Parameters.Add("pextra1", OracleType.VarChar).Value = System.DBNull.Value;
            cmd.Parameters.Add("pextra2", OracleType.VarChar).Value = System.DBNull.Value;
            cmd.Parameters.Add("p_accounts", OracleType.Cursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_accounts1", OracleType.Cursor).Direction = ParameterDirection.Output;
            da.SelectCommand = cmd;
            da.Fill(ds);
            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                parameterNameArray.Insert(z, ds.Tables[0].Rows[z]["PARAMETER_NAME"].ToString());
                parameterDataTypeArray.Insert(z, ds.Tables[0].Rows[z]["DATA_TYPE"].ToString());
            }
            for (int z = 0; z < ds.Tables[1].Rows.Count; z++)
            {
                outputParameter.Insert(z, ds.Tables[1].Rows[z]["PARAMETER_NAME"].ToString());
            }
        }
    }
}