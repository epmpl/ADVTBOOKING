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
using System.Collections;
/// <summary>
/// Summary description for CommonClass
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class CommonClass : connection
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet dsmain = new DataSet();
        ArrayList outputParameter = new ArrayList();
        ArrayList parameterNameArray = new ArrayList();
        ArrayList parameterDataTypeArray = new ArrayList();
        public CommonClass()
        {
            con = null;
            cmd = null;
            dsmain = new DataSet();
            da = new SqlDataAdapter();
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
                    if (parameterDataTypeArray[x].ToString().ToUpper() == "VARCHAR")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), SqlDbType.VarChar).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "DATETIME")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), SqlDbType.DateTime).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "NUMERIC")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), SqlDbType.Float).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "DECIMAL")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), SqlDbType.Decimal).Value = GetStringOrDBNull(paramsValue);
                    }
                    else
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), SqlDbType.VarChar).Value = GetStringOrDBNull(paramsValue);
                    }
                    x++;
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
            DataSet ds = new DataSet();
            cmd = GetCommand("inv_get_procedure_params", ref con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pprocedure_nm", SqlDbType.VarChar).Value = GetStringOrDBNull(procedureName);
            cmd.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = System.DBNull.Value;
            cmd.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = System.DBNull.Value;
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