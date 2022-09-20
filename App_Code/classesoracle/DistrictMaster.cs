using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for DistrictMaster
/// </summary>
    public class DistrictMaster : orclconnection 
{
	public DistrictMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 public DataSet bindstate(string code,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("bindstate.bindstate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;			
                OracleParameter prm1 = new OracleParameter("countrycode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


              
 
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objOracleConnection);
			}
		}


		public DataSet statesel(string compcode,string userid,string statcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("statesel.statesel_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

		

                OracleParameter prm1 = new OracleParameter("statcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

 
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objOracleConnection);
			}
		}
		
			
		public DataSet ModifyValue(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMstModify.DistrictMstModify_P", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("DistCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = DistCode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("DistName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = DistName;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = StateName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = CountryName;
                objOraclecommand.Parameters.Add(prm6);
								
			
				objmysqlDataAdapter.SelectCommand =objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}

			catch(OracleException  objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref objOracleConnection);
			}
		}


		public DataSet InsertValue(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMstInsert.DistrictMstInsert_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm1 = new OracleParameter("DistCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = DistCode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("DistName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = DistName;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = StateName;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = CountryName;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);

				
				objmysqlDataAdapter.SelectCommand =objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}

            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref objOracleConnection);
			}
		}

		public DataSet SelectValue(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMstSelect.DistrictMstSelect_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;   
				
                    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);
                    OracleParameter prm2 = new OracleParameter("DistCode", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = DistCode;
                    objOraclecommand.Parameters.Add(prm2);
                    OracleParameter prm3 = new OracleParameter("DistName", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = DistName;
                    objOraclecommand.Parameters.Add(prm3);
                    OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = Alias;
                    objOraclecommand.Parameters.Add(prm4);
                    OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                    prm5.Direction = ParameterDirection.Input;
                    if (StateName=="0")
                {
                    prm5.Value =System .DBNull .Value ;
                }
                else
                {
                    prm5.Value = StateName;
                }
                    objOraclecommand.Parameters.Add(prm5);
                    OracleParameter prm6 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                   
               
                prm6.Direction = ParameterDirection.Input;
                if (CountryName=="0")
                {
                    prm6.Value = System.DBNull.Value;
                 }
                 else
                 {
                    prm6.Value = CountryName;
                 }
                    objOraclecommand.Parameters.Add(prm6);


                    objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                    objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




                    objmysqlDataAdapter.SelectCommand = objOraclecommand;
				
			
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}

            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

		public DataSet Selectfnpl(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMstfnpl.DistrictMstfnpl_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

				
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

              

				
				objmysqlDataAdapter.SelectCommand =objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}
			catch(OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

		public DataSet state(string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMst_State.DistrictMst_State_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
			

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}


		}

		public DataSet DeleteValue(string DistCode,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMstDelete.DistrictMstDelete_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;	
		
				
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("DistCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = DistCode;
                objOraclecommand.Parameters.Add(prm2);
				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

		public DataSet country(string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("DistrictMst_Country.DistrictMst_Country_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

               
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}


		}

		public DataSet checkdistrict(string DistCode,string DistName, string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdiscode.chkdiscode_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("DistCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = DistCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("DistName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = DistName;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

    public DataSet countdistrictcode(string str,string countrycode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkdistrictcodename.chkdistrictcodename_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = str;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (str.Length >2)
            {
                prm2.Value = str.Substring (0,2);
            }
            else
            {
                prm2.Value = str;
            }
            
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
            objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


            objmysqlDataAdapter.SelectCommand = objOraclecommand;
            objmysqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }

    public DataSet countdistrictcodename(string str, string strname, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkdistrictcodenamemodify.chkdistrictcodenamemodify_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


         


            OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = str;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("strname", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = strname;
            objOraclecommand.Parameters.Add(prm2);
            OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);


            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



            objmysqlDataAdapter.SelectCommand = objOraclecommand;
            objmysqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
    

	}
}

