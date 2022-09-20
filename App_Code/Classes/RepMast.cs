using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for RepMast.
	/// </summary>
	public class RepMast:connection
	{
		public RepMast()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public DataSet chkdoc(string compcode,string userid,string repcode, string repname,string dist,string taluka1)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkrep", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@repcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repcode"].Value =repcode;

                objSqlCommand.Parameters.Add("@repname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repname"].Value = repname;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@taluka1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@taluka1"].Value = taluka1;


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


        public DataSet docmodify(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("repmodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@repcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repcode"].Value =repcode;

				objSqlCommand.Parameters.Add("@repname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repname"].Value =repname;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@taluka1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@taluka1"].Value = taluka1;

                objSqlCommand.Parameters.Add("@repstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repstatus"].Value = repstatus;

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

        //Change
        public DataSet adcountryname(string compcode)
        {
            SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adcountryname", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

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

        public DataSet docinsert(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("repinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@repcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repcode"].Value =repcode;

				objSqlCommand.Parameters.Add("@repname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repname"].Value =repname;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@taluka1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@taluka1"].Value = taluka1;

                objSqlCommand.Parameters.Add("@repstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repstatus"].Value = repstatus;
				
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



		public DataSet docexe(string compcode,string userid,string repcode,string repname)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("repexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@repcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repcode"].Value =repcode;

				objSqlCommand.Parameters.Add("@repname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repname"].Value =repname;

				

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



		public DataSet docfnpl(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("repfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

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

		public DataSet docdel(string compcode,string userid,string repcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("repdel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@repcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@repcode"].Value =repcode;

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


        public DataSet chkrpcode1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpnamechk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objSqlCommand.Parameters["@cod"].Value = str.Substring(0, 2);

                }
                else
                {
                    objSqlCommand.Parameters["@cod"].Value = str;
                }
                //objSqlCommand.Parameters["@cod"].Value = str;


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




        public DataSet fill_subcat(string compcode, string ASD)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getrepnamesp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@repname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repname"].Value = ASD;

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
