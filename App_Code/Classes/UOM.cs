using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for UOM.
	/// </summary>
	public class UOM:connection
	{
		public UOM()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public DataSet checkuomcode(string code, string txtuomdesc, string compcode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkuom", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlCommand.Parameters.Add("@uomname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomname"].Value = txtuomdesc;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;


			
				
				
				
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

        public DataSet countuomcode(string str,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkuomcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet insertinuom(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet, string uom_desc, string logo, string logouom ,string column,string gutwidth, string colwidth,string acc_cd, string sacc_cd)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertuom", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@txtuomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtuomcode"].Value = txtuomcode;

                objSqlCommand.Parameters.Add("@txtuomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtuomdesc"].Value = txtuomdesc;


                objSqlCommand.Parameters.Add("@txtalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtalias"].Value = txtalias;


                objSqlCommand.Parameters.Add("@txtuomtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtuomtype"].Value = txtuomtype;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@sample_img_hm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sample_img_hm"].Value = sampleimg;

                objSqlCommand.Parameters.Add("@stylesheetname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stylesheetname"].Value = stylesheet;


                objSqlCommand.Parameters.Add("@uom_desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom_desc"].Value = uom_desc;


                objSqlCommand.Parameters.Add("@logo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo"].Value = logo;


                objSqlCommand.Parameters.Add("@logouom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logouom"].Value = logouom;

                objSqlCommand.Parameters.Add("@column", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column"].Value = column;

                objSqlCommand.Parameters.Add("@gutwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gutwidth"].Value = gutwidth;

                objSqlCommand.Parameters.Add("@colwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colwidth"].Value = colwidth;

                objSqlCommand.Parameters.Add("@SAC_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SAC_CODE"].Value = acc_cd;
                objSqlCommand.Parameters.Add("@SUB_SAC_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SUB_SAC_CODE"].Value = sacc_cd;


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

        public DataSet executeuom(string compcode, string userid, string txtuomcode, string txtuomdesc, string txtalias, string adtype, string uomtype)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executeuom", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				objSqlCommand.Parameters.Add("@txtuomcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtuomcode"].Value =txtuomcode;

				objSqlCommand.Parameters.Add("@txtuomdesc", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtuomdesc"].Value =txtuomdesc;


				objSqlCommand.Parameters.Add("@txtalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtalias"].Value =txtalias;

                objSqlCommand.Parameters.Add("@uomtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomtype"].Value = uomtype;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;



				
				
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

		public DataSet firstquery()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstuom", ref objSqlConnection);
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
        public DataSet updaetcode(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet, string uom_desc, string logo, string logouom, string column, string gutwidth, string colwidth, string acc_cd, string sacc_cd)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateuom", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@txtuomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtuomcode"].Value = txtuomcode;

                objSqlCommand.Parameters.Add("@txtuomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtuomdesc"].Value = txtuomdesc;


                objSqlCommand.Parameters.Add("@txtalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtalias"].Value = txtalias;


                objSqlCommand.Parameters.Add("@txtuomtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtuomtype"].Value = txtuomtype;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@sample_img_hm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sample_img_hm"].Value = sampleimg;

                objSqlCommand.Parameters.Add("@stylesheetname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stylesheetname"].Value = stylesheet;

                objSqlCommand.Parameters.Add("@uom_desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom_desc"].Value = uom_desc;

                /*new achange ankur 19 feb*/
                objSqlCommand.Parameters.Add("@logo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo"].Value = logo;

                objSqlCommand.Parameters.Add("@logouom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logouom"].Value = logouom;


                objSqlCommand.Parameters.Add("@column", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column"].Value = column;


                objSqlCommand.Parameters.Add("@gutwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gutwidth"].Value = gutwidth;


                objSqlCommand.Parameters.Add("@colwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colwidth"].Value = colwidth;

                objSqlCommand.Parameters.Add("@SAC_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SAC_CODE"].Value = acc_cd;

                objSqlCommand.Parameters.Add("@SUB_SAC_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SUB_SAC_CODE"].Value = sacc_cd;


                ///////////////////////////////////////

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

		public DataSet deleteuom(string code,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deleteuom", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;


				
				
				
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
		public DataSet bindes()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("fromuom", ref objSqlConnection);
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
	}
}
