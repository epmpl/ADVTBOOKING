using System;
using System.Data;
using System.Data.SqlClient;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for adsubcat.
	/// </summary>
	public class adsubcat:connection
	{
		public adsubcat()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet addcategoryname(string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adcat", ref objSqlConnection);
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				//				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
				//				objSqlCommand.Parameters["@dist"].Value =dist;
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


		public DataSet getcode(string catname)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("fillcatcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@catname"].Value =catname;
				
				
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






        public DataSet savesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string imagename, string txtxml, string pri, string status1, string sapcode, string statecode, string eddiscflag)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatsave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@catcode"].Value =catcode;

				objSqlCommand.Parameters.Add("@subcatcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatcode"].Value =subcatcode;

				objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatname"].Value =subcatname;

				objSqlCommand.Parameters.Add("@subcatalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatalias"].Value =subcatalias;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@imagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagename"].Value = imagename;

                objSqlCommand.Parameters.Add("@subcatxml", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatxml"].Value = txtxml;

                objSqlCommand.Parameters.Add("@pri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pri"].Value = pri;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status1;

                objSqlCommand.Parameters.Add("@sapcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sapcode"].Value = sapcode;


                objSqlCommand.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstatecode"].Value = statecode;

                objSqlCommand.Parameters.Add("@pexecutive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecutive"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sun"].Value = System.DBNull.Value; 

 
                objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mon"].Value = System.DBNull.Value; 

                objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tue"].Value = System.DBNull.Value; 

                objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@wed"].Value = System.DBNull.Value; 

                objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@thu"].Value = System.DBNull.Value;
 
                objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fri"].Value = System.DBNull.Value;
 
                objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sat"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@PEDITION_DISCOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEDITION_DISCOUNT"].Value = eddiscflag; 
               



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







        public DataSet exesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string statecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                //if(@catcode == "0")
                //{
                //    objSqlCommand.Parameters["@catcode"].Value ="%%";
                //}
                //else
                //{
					objSqlCommand.Parameters["@catcode"].Value =catcode;
					
				//}

				objSqlCommand.Parameters.Add("@subcatcode", SqlDbType.VarChar);
                //if(subcatcode!= null && subcatcode!="" && subcatcode!="undefined")
                //{
					objSqlCommand.Parameters["@subcatcode"].Value =subcatcode;
				//}
                //else
                //{
                //    objSqlCommand.Parameters["@subcatcode"].Value ="%%";
                //}




				
				objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                //if(subcatname!= null && subcatname!="" && subcatname!="undefined")
                //{
                    objSqlCommand.Parameters["@subcatname"].Value =subcatname;
				//}
                //else
                //{
                //    objSqlCommand.Parameters["@subcatname"].Value ="%%";
                //}





				objSqlCommand.Parameters.Add("@subcatalias", SqlDbType.VarChar);
                //if(subcatalias!= null && subcatalias!="" && subcatalias!="undefined")
                //{
					objSqlCommand.Parameters["@subcatalias"].Value =subcatalias;
				//}
                //else
                //{
                //    objSqlCommand.Parameters["@subcatalias"].Value ="%%";
                //}

				

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstatecode"].Value = statecode;

                    objSqlCommand.Parameters.Add("@pexecutive", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pexecutive"].Value = System.DBNull.Value;


                    objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pubcode"].Value = System.DBNull.Value;
				
				

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












        public DataSet updatesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string imagename, string txtxml, string pri, string status1, string sapcode, string statecode, string eddiscflag)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@catcode"].Value =catcode;

				objSqlCommand.Parameters.Add("@subcatcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatcode"].Value =subcatcode;

				objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatname"].Value =subcatname;

				objSqlCommand.Parameters.Add("@subcatalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatalias"].Value =subcatalias;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@imagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagename"].Value = imagename;

                objSqlCommand.Parameters.Add("@subcatxml", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatxml"].Value = txtxml;

                objSqlCommand.Parameters.Add("@pri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pri"].Value = pri;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status1;

                objSqlCommand.Parameters.Add("@sapcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sapcode"].Value = sapcode;

                objSqlCommand.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstatecode"].Value = statecode;

                objSqlCommand.Parameters.Add("@pexecutive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecutive"].Value = "";

                objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sun"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mon"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tue"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@wed"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@thu"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fri"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sat"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEDITION_DISCOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEDITION_DISCOUNT"].Value = eddiscflag; 

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




		public DataSet firstsubcat(string compcode,string catcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				

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


        public DataSet chksubcat(string compcode, string subcatcode, string subcatname, string catcode, string userid, string statecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatchk", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@subcatcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatcode"].Value =subcatcode;

				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatname"].Value = subcatname;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;


                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = statecode;

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







		public DataSet presubcat(string compcode,string catcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				

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



		public DataSet nextsubcat(string compcode,string catcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				//objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@catcode"].Value =catcode;

				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				

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





		public DataSet lastsubcat(string compcode,string catcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				

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



		public DataSet delsubcat(string compcode,string catcode,string userid,string subcatcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("subcatdel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				
				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@catcode"].Value =catcode;

				
				
				objSqlCommand.Parameters.Add("@subcatcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subcatcode"].Value =subcatcode;

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



        public DataSet chksubcatcode1(string str, string catcode, string statecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkadsubcatname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;



                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = statecode;

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
