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
/// Summary description for PaymentMode
/// </summary>
namespace NewAdbooking.Classes
{
public class PaymentMode:connection
{
	public PaymentMode()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public DataSet checkpayment(string paycode,string payname, string compcode, string userid )
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkpayment", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@paycode"].Value =paycode;

				objSqlCommand.Parameters.Add("@payname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@payname"].Value =payname;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		
		}


        public DataSet insertpayment(string paycode, string payname, string compcode, string userid, string alias,string cash)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("paymantinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@paycode"].Value =paycode;

				objSqlCommand.Parameters.Add("@payname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@payname"].Value =payname;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@cash", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash"].Value = cash;
				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		
		}


        public DataSet updatepayment(string paycode, string payname, string compcode, string userid, string alias,string cash)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("paymantmodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@paycode"].Value =paycode;

				objSqlCommand.Parameters.Add("@payname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@payname"].Value =payname;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@cash", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash"].Value = cash;
				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		
		}


		public DataSet exepayment(string paycode,string payname, string compcode, string userid )
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("paymentexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@paycode"].Value =paycode;

				objSqlCommand.Parameters.Add("@payname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@payname"].Value =payname;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		
		}



		public DataSet fnplpayment( string compcode, string userid)//, string paycode )
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("paymentfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@paycode"].Value = paycode;

				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		
		}



		public DataSet delpayment( string compcode, string userid ,string paycode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("paymentdel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@paycode"].Value =paycode;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		
		}

    public DataSet paymentauto(string str,string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();

            objSqlCommand = GetCommand("PAYMENTCODE_AUTO", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            //objSqlCommand.Parameters.Add("@paycode", SqlDbType.VarChar);
            //objSqlCommand.Parameters["@paycode"].Value = paycode;

            //objSqlCommand.Parameters.Add("@payname", SqlDbType.VarChar);
            //objSqlCommand.Parameters["@payname"].Value = payname;

            //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            //objSqlCommand.Parameters["@userid"].Value = userid;

            //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            //objSqlCommand.Parameters["@compcode"].Value = compcode;


            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

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
