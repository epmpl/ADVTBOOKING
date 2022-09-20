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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
/// <summary>
/// Summary description for CommonClass
/// </summary>
/// 
namespace NewAdbooking.classmysql
{
    public class CommonClass:connection
    {

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataSet dsmain = new DataSet();
        ArrayList outputParameter = new ArrayList();
        ArrayList parameterNameArray = new ArrayList();
        ArrayList parameterDataTypeArray = new ArrayList();
        public CommonClass()
        {
            //
            // TODO: Add constructor logic here
            //
            con = null;
            cmd = null;
            dsmain = new DataSet();
            da = new MySqlDataAdapter();
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
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), MySqlDbType.VarChar).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "DATETIME")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), MySqlDbType.DateTime).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "NUMERIC")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), MySqlDbType.Float).Value = GetStringOrDBNull(paramsValue);
                    }
                    else if (parameterDataTypeArray[x].ToString().ToUpper() == "DECIMAL")
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), MySqlDbType.Decimal).Value = GetStringOrDBNull(paramsValue);
                    }
                    else
                    {
                        cmd.Parameters.Add(parameterNameArray[x].ToString(), MySqlDbType.VarChar).Value = GetStringOrDBNull(paramsValue);
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
        
            cmd.Parameters.Add("p_pprocedure_nm", MySqlDbType.VarChar).Value = procedureName;
            cmd.Parameters.Add("p_pextra1", MySqlDbType.VarChar).Value = System.DBNull.Value;
            cmd.Parameters.Add("p_pextra2", MySqlDbType.VarChar).Value = System.DBNull.Value;
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
