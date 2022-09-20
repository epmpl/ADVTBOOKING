using System;
using System.Data;
using System.Data.SqlClient;





namespace NewAdbooking.Classes
{
    /// <summary>
/// Summary description for Agency_Role_Master
/// </summary>
public class Agencyrolemaster:connection
{
    public Agencyrolemaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet bindagencycode(string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bindagencycode", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;






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

    public DataSet insertrole(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("insertintorole", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code"].Value = code;

            objSqlCommand.Parameters.Add("@nameofrole", SqlDbType.VarChar);
            objSqlCommand.Parameters["@nameofrole"].Value = nameofrole;

            objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencycode"].Value = agencycode;

            objSqlCommand.Parameters.Add("@subcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@subcode"].Value = subcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;





         


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

    public DataSet modifyrole(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("modifyintorole", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code"].Value = code;

            objSqlCommand.Parameters.Add("@nameofrole", SqlDbType.VarChar);
            objSqlCommand.Parameters["@nameofrole"].Value = nameofrole;

            objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencycode"].Value = agencycode;

            objSqlCommand.Parameters.Add("@subcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@subcode"].Value = subcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@level", SqlDbType.VarChar);
            objSqlCommand.Parameters["@level"].Value = System.DBNull.Value;




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

    public DataSet execute(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("executerole", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code"].Value = code;

            objSqlCommand.Parameters.Add("@nameofrole", SqlDbType.VarChar);
            objSqlCommand.Parameters["@nameofrole"].Value = nameofrole;

            objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencycode"].Value = agencycode;

            objSqlCommand.Parameters.Add("@subcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@subcode"].Value = subcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@level", SqlDbType.VarChar);
            objSqlCommand.Parameters["@level"].Value = System.DBNull.Value;





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

    public DataSet firstdata(string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("firstrole", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;


            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;


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

    public DataSet chkroleage(string code, string compcode, string userid, string nameofrole)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("checkrole", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code"].Value = code;

            objSqlCommand.Parameters.Add("@nameofrole", SqlDbType.VarChar);
            objSqlCommand.Parameters["@nameofrole"].Value = nameofrole;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

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


    public DataSet deldata(string compcode, string userid, string doccode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("agroledel", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;


            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;


            objSqlCommand.Parameters.Add("@doccode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@doccode"].Value = doccode;


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








    public DataSet chksrolecode1(string str)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkrolename", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;


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