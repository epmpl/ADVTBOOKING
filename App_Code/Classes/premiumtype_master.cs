using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for premiumtype_master.
	/// </summary>
	public class premiumtype_master:connection
	{
		public premiumtype_master()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public DataSet checkpremcode(string premcode, string compcode, string userid, string premname, string advtype)
		{
			SqlCommand objsqlcommand;
			SqlConnection objsqlconnection;
			objsqlconnection=GetConnection();
			SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("checkprem",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@comcode",SqlDbType.VarChar);
                objsqlcommand.Parameters["@comcode"].Value = premcode;

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

                objsqlcommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                objsqlcommand.Parameters["@advtype"].Value = advtype;

                objsqlcommand.Parameters.Add("@premname", SqlDbType.VarChar);
                objsqlcommand.Parameters["@premname"].Value = premname;
				objSqlDataAdapter.SelectCommand=objsqlcommand;


				objSqlDataAdapter.Fill(ds);
				return ds;


			}
			catch(Exception ex)
			{
				throw(ex);
			}

			finally
			{
				CloseConnection(ref objsqlconnection);
			}



		}

		public DataSet insertintoprem(string advtype,string premcode,string alias,string premdesc,string compcode,string userid)
		{
			SqlCommand objsqlcommand;
			SqlConnection objsqlconnection;
			objsqlconnection=GetConnection();
			SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("insertpremtype",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@premcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premcode"].Value=premcode;

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@advtype",SqlDbType.VarChar);
				objsqlcommand.Parameters["@advtype"].Value=advtype;

				objsqlcommand.Parameters.Add("@alias",SqlDbType.VarChar);
				objsqlcommand.Parameters["@alias"].Value=alias;

				objsqlcommand.Parameters.Add("@premdesc",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premdesc"].Value=premdesc;

				objSqlDataAdapter.SelectCommand=objsqlcommand;


				objSqlDataAdapter.Fill(ds);
				return ds;


			}
			catch(Exception ex)
			{
				throw(ex);
			}

			finally
			{
				CloseConnection(ref objsqlconnection);
			}



		}

		public DataSet executeintoprem(string advtype,string premcode,string alias,string premdesc,string compcode,string userid)
		{
			SqlCommand objsqlcommand;
			SqlConnection objsqlconnection;
			objsqlconnection=GetConnection();
			SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("executepremtype",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@premcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premcode"].Value=premcode;

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

                //objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@advtype",SqlDbType.VarChar);
				objsqlcommand.Parameters["@advtype"].Value=advtype;

				objsqlcommand.Parameters.Add("@alias",SqlDbType.VarChar);
				objsqlcommand.Parameters["@alias"].Value=alias;

				objsqlcommand.Parameters.Add("@premdesc",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premdesc"].Value=premdesc;

				objSqlDataAdapter.SelectCommand=objsqlcommand;


				objSqlDataAdapter.Fill(ds);
				return ds;


			}
			catch(Exception ex)
			{
				throw(ex);
			}

			finally
			{
				CloseConnection(ref objsqlconnection);
			}



		}
		public DataSet firstfromprem()
		{
			SqlCommand objsqlcommand;
			SqlConnection objsqlconnection;
			objsqlconnection=GetConnection();
			SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("firstpremtype",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				

				objSqlDataAdapter.SelectCommand=objsqlcommand;


				objSqlDataAdapter.Fill(ds);
				return ds;


			}
			catch(Exception ex)
			{
				throw(ex);
			}

			finally
			{
				CloseConnection(ref objsqlconnection);
			}



		}

		public DataSet updateintoprem(string advtype,string premcode,string alias,string premdesc,string compcode,string userid)
		{
			SqlCommand objsqlcommand;
			SqlConnection objsqlconnection;
			objsqlconnection=GetConnection();
			SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("updatepremtype",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@premcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premcode"].Value=premcode;

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

                //objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@advtype",SqlDbType.VarChar);
				objsqlcommand.Parameters["@advtype"].Value=advtype;

				objsqlcommand.Parameters.Add("@alias",SqlDbType.VarChar);
				objsqlcommand.Parameters["@alias"].Value=alias;

				objsqlcommand.Parameters.Add("@premdesc",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premdesc"].Value=premdesc;

				objSqlDataAdapter.SelectCommand=objsqlcommand;


				objSqlDataAdapter.Fill(ds);
				return ds;


			}
			catch(Exception ex)
			{
				throw(ex);
			}

			finally
			{
				CloseConnection(ref objsqlconnection);
			}



		}

		public DataSet deleteintoprem(string premcode,string compcode,string userid)
		{
			SqlCommand objsqlcommand;
			SqlConnection objsqlconnection;
			objsqlconnection=GetConnection();
			SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("deletepremtype",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@premcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@premcode"].Value=premcode;

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

                //objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objsqlcommand.Parameters["@userid"].Value=userid;

				objSqlDataAdapter.SelectCommand=objsqlcommand;


				objSqlDataAdapter.Fill(ds);
				return ds;


			}
			catch(Exception ex)
			{
				throw(ex);
			}

			finally
			{
				CloseConnection(ref objsqlconnection);
			}



		}








        public DataSet chkptcode1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkptname", ref objSqlConnection);
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
