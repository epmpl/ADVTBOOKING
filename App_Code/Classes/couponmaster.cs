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
/// Summary description for Ad_Translation_charge
/// </summary>
namespace NewAdbooking.Classes
{
    public class couponmaster:connection
    {

		 public DataSet getPubCenter()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
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
         public DataSet get_coupon()
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();

             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("ad_gen_coupon", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;  
                 objSqlDataAdapter = new SqlDataAdapter();
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
         public string couponsave(string code, string unitcode, string tblname, string action, string dateformat, string extra1, string extra2)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();

             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("Cir_Dynamic_DML_variable_insert_stmt", ref objSqlConnection);

                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();

                 objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                 objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcolname"].Value = code;

                 objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                 objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                 objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                 objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra1"].Value = extra1;

                 objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra2"].Value = extra2;

                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return "true";


             }
             catch (Exception ex)
             {
                 return ex.Message.ToString();
             }
             finally
             {
                 objSqlConnection.Close();
             }
         }

         public DataSet get_execute(string tblname, string colname, string colvalue, string delimeter, string dateformat, string extra1, string extra2)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();

             //

             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("cir_dynamic_execute_stmt", ref objSqlConnection);

                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();


                 objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                 objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                 objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;

                 objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                 objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                 objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra1"].Value = extra1;

                 objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra2"].Value = extra2;


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

         public DataSet get_unit_name(string comp_code, string unit)
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
                 string query = "select dbo.cir_get_pubcenter('" + comp_code + "','" + unit + "','','','','')";// from dual";
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

         public DataSet Modify_coup(string code, string unitcode, string tblname, string action, string wheresecond, string dateformat, string extra1, string extra2)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("cir_dynamic_update_stmt", ref objSqlConnection);

                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();

                 objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ptable_name"].Value = tblname;


                 objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcolname"].Value = code;

                 objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                 objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcond_colname"].Value = wheresecond;

                 objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                 objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                 objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra1"].Value = extra1;

                 objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra2"].Value = extra2;

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
         public DataSet Delete_coup(string code, string unitcode, string tblname, string action, string wheresecond, string dateformat)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("cir_dynamic_dml_variable_delete_stmt", ref objSqlConnection);

                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();

                 objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ptable_name"].Value = tblname;


                 objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcond_colname"].Value = wheresecond;

                 objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcond_colval"].Value = unitcode;

                 objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                 objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                 objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra1"].Value = "";

                 objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra2"].Value = "";

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

         public DataSet duplicacy_chk(string compcol, string compval, string unitcol, string unitval, string tablename, string desc_col, string desc_val, string alias_col, string alias_val, string date, string extra1, string extra2)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();

             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("cir_check_duplicacy_p", ref objSqlConnection);

                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();


                 objSqlCommand.Parameters.Add("@pcomp_col", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcomp_col"].Value = compcol;

                 objSqlCommand.Parameters.Add("@pcomp_val", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pcomp_val"].Value = compval;

                 objSqlCommand.Parameters.Add("@punit_col", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@punit_col"].Value = unitcol;

                 objSqlCommand.Parameters.Add("@punit_val", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@punit_val"].Value = unitval;

                 objSqlCommand.Parameters.Add("@ptbl_name", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ptbl_name"].Value = tablename;

                 objSqlCommand.Parameters.Add("@pdesc_col", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdesc_col"].Value = desc_col;

                 objSqlCommand.Parameters.Add("@pdesc_val", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdesc_val"].Value = desc_val;

                 objSqlCommand.Parameters.Add("@palias_col", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@palias_col"].Value = alias_col;

                 objSqlCommand.Parameters.Add("@palias_val", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@palias_val"].Value = alias_val;

                 objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pdateformat"].Value = date;

                 objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra1"].Value = extra1;

                 objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pextra2"].Value = extra2;

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
}


}