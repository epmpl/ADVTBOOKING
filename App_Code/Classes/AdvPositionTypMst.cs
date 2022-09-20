using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for AdvPositionTypMst.
	/// </summary>
	public class AdvPositionTypMst:connection
	{
		public AdvPositionTypMst()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public DataSet ModifyValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat, string adtype)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("PositionTypeMstModify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PosTypCode"].Value =PosTypCode;
			
				objSqlCommand.Parameters.Add("@PosType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PosType"].Value =PosType;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias ;

              

                objSqlCommand.Parameters.Add("@Amount", SqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objSqlCommand.Parameters["@Amount"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Amount"].Value = Convert.ToDecimal(amount);
                }


                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@p_fdate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@p_fdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_fdate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@p_tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@p_tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_tdate"].Value = tdate;
                }
                objSqlCommand.Parameters.Add("@ad_tpe", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_tpe"].Value = adtype;
                

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


		public DataSet chksave(string PosTypCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("PositionTypechk", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PosTypCode"].Value =PosTypCode;
			
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



		public DataSet delete1(string PosTypCode,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("PositionTypedel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PosTypCode"].Value =PosTypCode;
			
				

						
							
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



        public DataSet InsertValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat, string adtype)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("PositionTypeMstInsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PosTypCode"].Value =PosTypCode;
			
				objSqlCommand.Parameters.Add("@PosType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PosType"].Value =PosType;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias ;


                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                //objSqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
                //objSqlCommand.Parameters["@amount"].Value = amount;

                /*change ankur*/
                objSqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objSqlCommand.Parameters["@amount"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@amount"].Value = Convert.ToDecimal(amount);
                }

                objSqlCommand.Parameters.Add("@p_fdate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@p_fdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_fdate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@p_tdate", SqlDbType.VarChar);
                 if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@p_tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_tdate"].Value = tdate;
                }

                 objSqlCommand.Parameters.Add("@ad_tpe ", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ad_tpe "].Value = adtype;
                 
							
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

		public DataSet SelectValue(string PosTypCode,string PosType,string Alias,string amount, string premium,string compcode,string userid,string dateformat)
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("AdvPosTypeSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
			/*	if(PosTypCode=="" ||PosTypCode==null || PosTypCode=="0")
				{
					objSqlCommand.Parameters["@PosTypCode"].Value ="%%";		
				}
				else*/
			//	{
					objSqlCommand.Parameters["@PosTypCode"].Value =PosTypCode;
			//	}
				
				
				
			
				objSqlCommand.Parameters.Add("@PosType", SqlDbType.VarChar);
			/*	if(PosType=="" ||PosType==null||PosType=="0")
				{
					objSqlCommand.Parameters["@PosType"].Value ="%%";
				}
				else*/
				//{
					objSqlCommand.Parameters["@PosType"].Value =PosType;
				//}

                    objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@premium"].Value = premium;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				/*if(@Alias=="" ||@Alias==null)
				{
					objSqlCommand.Parameters["@Alias "].Value ="%%";
				}
				else*/
				//{
					objSqlCommand.Parameters["@Alias "].Value =Alias;
				//}


        /*        objSqlCommand.Parameters.Add("@pageno",SqlDbType.VarChar);

               
                objSqlCommand.Parameters["@pageno "].Value = pageno;*/

                    objSqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
                    if (amount == "" || amount == null)
                    {
                        objSqlCommand.Parameters["@amount"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        objSqlCommand.Parameters["@amount"].Value = Convert.ToDecimal(amount);
                    }

                objSqlCommand.Parameters.Add("@p_dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_dateformat"].Value = dateformat;

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

		public DataSet Selectfnpl(string PosTypCode,string PosType,string Alias,string amount,string premium,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("AdvPosTypefnpl", ref objSqlConnection);
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


        public DataSet pagenobind1(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pagenobind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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


        public DataSet chkadvposition1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkadvpostyp", ref objSqlConnection);
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

//====================***************To check Name In That particular Time period************=================//
        public DataSet chkpastypename1(string PosTypCode, string PosTypName, string compcode, string userid, string fdate, string tdate, string flag,string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("PositionTypechknameindate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_PosTypCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_PosTypCode"].Value = PosTypCode;

                objSqlCommand.Parameters.Add("@p_PosTypName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_PosTypName"].Value = PosTypName;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = userid;

                objSqlCommand.Parameters.Add("@p_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_flag"].Value = flag;

                objSqlCommand.Parameters.Add("@p_fdate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@p_fdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_fdate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@p_tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@p_tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_tdate"].Value = tdate;
                }

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

	}
}
