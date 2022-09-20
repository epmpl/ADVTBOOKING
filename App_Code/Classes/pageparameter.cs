using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for pageparameter.
	/// </summary>
	public class pageparameter:connection
	{
		public pageparameter()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet uombind(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adduom", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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

		public DataSet checkpage(string pagecode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkpagecode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@pagecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pagecode"].Value =pagecode;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

			
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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

		public DataSet savepageparam(string drpadvtype,string txtpagecode,string drpedition,string drocolor,string txtpageno,string txtadvsize,string txtcolno,string drpuom,string txtremarks,string compcode,string userid,string drpadvcategory,string pub)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertpageparam", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@txtpagecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpagecode"].Value =txtpagecode;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

				objSqlCommand.Parameters.Add("@drpadvtype", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvtype"].Value =drpadvtype;


				objSqlCommand.Parameters.Add("@drpedition", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpedition"].Value =drpedition;


				objSqlCommand.Parameters.Add("@drocolor", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drocolor"].Value =drocolor;


				objSqlCommand.Parameters.Add("@txtpageno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpageno"].Value =txtpageno;


				objSqlCommand.Parameters.Add("@txtadvsize", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtadvsize"].Value =txtadvsize;


				objSqlCommand.Parameters.Add("@txtcolno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcolno"].Value =txtcolno;


				objSqlCommand.Parameters.Add("@drpuom", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpuom"].Value =drpuom;


				objSqlCommand.Parameters.Add("@txtremarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtremarks"].Value =txtremarks;

				objSqlCommand.Parameters.Add("@drpadvcategory", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvcategory"].Value =drpadvcategory;




				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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

		public DataSet executepagepara(string drpadvtype,string txtpagecode,string drpedition,string drpadvcategory,string drocolor,string txtpageno,string txtadvsize,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executepagepara", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@txtpagecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpagecode"].Value =txtpagecode;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@drpadvtype", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvtype"].Value =drpadvtype;


				objSqlCommand.Parameters.Add("@drpedition", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpedition"].Value =drpedition;


				objSqlCommand.Parameters.Add("@drocolor", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drocolor"].Value =drocolor;


				objSqlCommand.Parameters.Add("@txtpageno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpageno"].Value =txtpageno;


				objSqlCommand.Parameters.Add("@txtadvsize", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtadvsize"].Value =txtadvsize;


				


				

			
				objSqlCommand.Parameters.Add("@drpadvcategory", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvcategory"].Value =drpadvcategory;




				
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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
		public DataSet pagefirst()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstpageparam", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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

		public DataSet updatepageparam(string drpadvtype,string txtpagecode,string drpedition,string drocolor,string txtpageno,string txtadvsize,string txtcolno,string drpuom,string txtremarks,string compcode,string userid,string drpadvcategory,string pub)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatepageparam", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@txtpagecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpagecode"].Value =txtpagecode;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@drpadvtype", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvtype"].Value =drpadvtype;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;


				objSqlCommand.Parameters.Add("@drpedition", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpedition"].Value =drpedition;


				objSqlCommand.Parameters.Add("@drocolor", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drocolor"].Value =drocolor;


				objSqlCommand.Parameters.Add("@txtpageno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpageno"].Value =txtpageno;


				objSqlCommand.Parameters.Add("@txtadvsize", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtadvsize"].Value =txtadvsize;


				objSqlCommand.Parameters.Add("@txtcolno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcolno"].Value =txtcolno;


				objSqlCommand.Parameters.Add("@drpuom", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpuom"].Value =drpuom;


				objSqlCommand.Parameters.Add("@txtremarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtremarks"].Value =txtremarks;

				objSqlCommand.Parameters.Add("@drpadvcategory", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvcategory"].Value =drpadvcategory;




				//objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@flag"].Value =z;
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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

		public DataSet deletepageparam(string pagecode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletepageparam", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@pagecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pagecode"].Value =pagecode;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
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

        public DataSet chkpagecode()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpagecodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




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

        public DataSet addedition(string pubname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fill_editionalias", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;

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
