using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for currencymaster.
	/// </summary>
	public class currencymaster:connection
	{
        static string prev = "";
		public currencymaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public DataSet bindcount(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bindcountry", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet chkcurrcode(string code,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkcurrcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;


				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet currsave(string txtcurrcode, string txtcurrname, string txtalias, string drpcountryname, string compcode, string userid, string SYMBOL_P, string cursymbol)
		{
            DataSet objDataSet = new DataSet();	
            SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertcurrencymst", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtcurrcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcurrcode"].Value =txtcurrcode;


				objSqlCommand.Parameters.Add("@txtcurrname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcurrname"].Value =txtcurrname;

				objSqlCommand.Parameters.Add("@txtalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtalias"].Value =txtalias;

				objSqlCommand.Parameters.Add("@drpcountryname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcountryname"].Value =drpcountryname;

                objSqlCommand.Parameters.Add("@SYMBOL_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SYMBOL_P"].Value = SYMBOL_P;

                objSqlCommand.Parameters.Add("@CURR_SYMBOL_NAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CURR_SYMBOL_NAME"].Value = cursymbol;

                

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet executecurrmst(string txtcurrcode, string txtcurrname, string txtalias, string drpcountryname, string compcode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("exeecutecurrencymast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtcurrcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcurrcode"].Value =txtcurrcode;


				objSqlCommand.Parameters.Add("@txtcurrname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcurrname"].Value =txtcurrname;

				objSqlCommand.Parameters.Add("@txtalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtalias"].Value =txtalias;

				objSqlCommand.Parameters.Add("@drpcountryname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcountryname"].Value =drpcountryname;

                

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet firstcurrmst()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstcurrenmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet currmodify(string txtcurrcode, string txtcurrname, string txtalias, string drpcountryname, string compcode, string userid, string SYMBOL_P, string cursymbol)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("modifycurrmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtcurrcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcurrcode"].Value =txtcurrcode;


				objSqlCommand.Parameters.Add("@txtcurrname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcurrname"].Value =txtcurrname;

				objSqlCommand.Parameters.Add("@txtalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtalias"].Value =txtalias;

				objSqlCommand.Parameters.Add("@drpcountryname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcountryname"].Value =drpcountryname;


                objSqlCommand.Parameters.Add("@SYMBOL_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SYMBOL_P"].Value = SYMBOL_P;


                objSqlCommand.Parameters.Add("@CURR_SYMBOL_NAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CURR_SYMBOL_NAME"].Value = cursymbol;
                

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet currdelete(string code,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletecurrmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;
				
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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet checkratecode(string code,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("converartechk", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;


				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}
		public DataSet ratebind(string code,string compcode,string userid,string date)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bindcurrmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;

				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =date;



				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet insertconverrate(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string currency, string txtunit)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertconvertrate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtconrate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtconrate"].Value =txtconrate;

				objSqlCommand.Parameters.Add("@txtfromdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtfromdate"].Value =Convert.ToDateTime(txtfromdate);

				objSqlCommand.Parameters.Add("@txtefftill", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtefftill"].Value =Convert.ToDateTime(txtefftill);

				objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currcode"].Value = currcode; 

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@txtunit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtunit"].Value = txtunit; 
				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet selectedfromgrid(string currcode,string compcode,string userid,string code10)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("selectfromcurrmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@currcode"].Value =currcode;

				

				objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code10"].Value =code10;


				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet gridupdate(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string code10, string currency, string unit)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updateconvertrate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtconrate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtconrate"].Value =txtconrate;

				objSqlCommand.Parameters.Add("@txtfromdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtfromdate"].Value =Convert.ToDateTime(txtfromdate);

				objSqlCommand.Parameters.Add("@txtefftill", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtefftill"].Value =Convert.ToDateTime(txtefftill);

				objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@currcode"].Value =currcode;

				objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code10"].Value =code10;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@txtunit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtunit"].Value = unit; 
				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet griddelete(string currcode,string compcode,string userid,string code10)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletegridconrate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				

				

				objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@currcode"].Value =currcode;

				objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code10"].Value =code10;


				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}
		public DataSet chkdaetconv(string txtconrate,string txtfromdate,string txtefftill,string compcode,string userid,string currcode,string currency)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkdateconrate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtconrate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtconrate"].Value =txtconrate;

				objSqlCommand.Parameters.Add("@txtfromdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtfromdate"].Value =Convert.ToDateTime(txtfromdate);

				objSqlCommand.Parameters.Add("@txtefftill", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtefftill"].Value =Convert.ToDateTime(txtefftill);

				objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@currcode"].Value =currcode;

                objSqlCommand.Parameters.Add("@pcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcurrency"].Value = currency; 


				

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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet chkdateupdate(string txtconrate,string txtfromdate,string txtefftill,string compcode,string userid,string currcode,string code10,string currency)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkdateupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@txtconrate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtconrate"].Value =txtconrate;

				objSqlCommand.Parameters.Add("@txtfromdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtfromdate"].Value =Convert.ToDateTime(txtfromdate);

				objSqlCommand.Parameters.Add("@txtefftill", SqlDbType.DateTime);
				objSqlCommand.Parameters["@txtefftill"].Value =Convert.ToDateTime(txtefftill);

				objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@currcode"].Value =currcode;

				objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code10"].Value =code10;

                objSqlCommand.Parameters.Add("@pcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcurrency"].Value = currency;
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
			
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet countcurrencycode(string str,string country)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcurrencycodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;


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


        public DataSet countcurrencycodectry(string country)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcurrencycodenamectry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;


            

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
