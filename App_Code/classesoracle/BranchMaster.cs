using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for BranchMaster
/// </summary>
    public class BranchMaster : orclconnection
{
	public BranchMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
           public DataSet addcity()
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("clientfillcity.clientfillcity_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
				 
				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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



    public DataSet addregion(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("regionbind.regionbind_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

                 OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }


        public DataSet addzone(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("zonebind.zonebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
  

 

        public DataSet addcountry(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
              try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcountryname.adcountryname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }







		public DataSet addpickdistname(string citycode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("fillstaedistcountry.fillstaedistcountry_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                  OracleParameter prm1 = new OracleParameter("citycode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = citycode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;

				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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


		public DataSet branchchk(string compcode,string userid,string branchcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchchk.branchchk_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                
                  OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                
                  OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                
                  OracleParameter prm3 = new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

 
				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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


        public DataSet branchchkcode(string str, string pubcent,string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("branchchkcodename.branchchkcodename_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            
                
                  OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("pubcent", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcent;
                objOraclecommand.Parameters.Add(prm3);

                  OracleParameter prm2= new OracleParameter("cod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0,2);
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }

                OracleParameter prm4 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;
          
            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }


        //public DataSet branchinsert(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string branchaccont, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
        public DataSet branchinsert(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchinsert.branchinsert_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                         OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                         OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                         OracleParameter prm4 = new OracleParameter("branchname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchname;
                objOraclecommand.Parameters.Add(prm4);
		
                         OracleParameter prm5 = new OracleParameter("alias", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
		
                 OracleParameter prm6= new OracleParameter("address", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = address;
                objOraclecommand.Parameters.Add(prm6);
		
                         OracleParameter prm7 = new OracleParameter("street", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = street;
                objOraclecommand.Parameters.Add(prm7);
			
                         OracleParameter prm8 = new OracleParameter("city", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = city;
                objOraclecommand.Parameters.Add(prm8);
	
                         OracleParameter prm9= new OracleParameter("dist", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dist;
                objOraclecommand.Parameters.Add(prm9);
	
                         OracleParameter prm10 = new OracleParameter("state", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = state;
                objOraclecommand.Parameters.Add(prm10);

         OracleParameter prm11 = new OracleParameter("country", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = country;
                objOraclecommand.Parameters.Add(prm11);

                         OracleParameter prm12 = new OracleParameter("fax", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = fax;
                objOraclecommand.Parameters.Add(prm12);

                         OracleParameter prm13 = new OracleParameter("pin", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pin;
                objOraclecommand.Parameters.Add(prm13);

                         OracleParameter prm14 = new OracleParameter("phone1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = phone1;
                objOraclecommand.Parameters.Add(prm14);
			
                         OracleParameter prm15 = new OracleParameter("phone2", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = phone2;
                objOraclecommand.Parameters.Add(prm15);

                         OracleParameter prm16 = new OracleParameter("email", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = email;
                objOraclecommand.Parameters.Add(prm16);

                         OracleParameter prm17 = new OracleParameter("zone", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = zone;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("region", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = region;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("boxadd", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = boxadd;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter rm21 = new OracleParameter("pbranchnick", OracleType.VarChar);
                rm21.Direction = ParameterDirection.Input;
                rm21.Value = Branchnick;
                objOraclecommand.Parameters.Add(rm21);

                OracleParameter rm22 = new OracleParameter("pbranchaccont", OracleType.VarChar);
                rm22.Direction = ParameterDirection.Input;
                rm22.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(rm22);


                OracleParameter rm23 = new OracleParameter("finphone1", OracleType.VarChar);
                rm23.Direction = ParameterDirection.Input;
                rm23.Value = finphone1;
                objOraclecommand.Parameters.Add(rm23);


                OracleParameter rm24 = new OracleParameter("finphone2", OracleType.VarChar);
                rm24.Direction = ParameterDirection.Input;
                rm24.Value = finphone2;
                objOraclecommand.Parameters.Add(rm24);


                OracleParameter rm25 = new OracleParameter("collphone1", OracleType.VarChar);
                rm25.Direction = ParameterDirection.Input;
                rm25.Value = collph1;
                objOraclecommand.Parameters.Add(rm25);

                OracleParameter rm26 = new OracleParameter("collphone2", OracleType.VarChar);
                rm26.Direction = ParameterDirection.Input;
                rm26.Value = collph2;
                objOraclecommand.Parameters.Add(rm26);


                OracleParameter rm27 = new OracleParameter("cirphone1", OracleType.VarChar);
                rm27.Direction = ParameterDirection.Input;
                rm27.Value = cirph1;
                objOraclecommand.Parameters.Add(rm27);


                OracleParameter rm28= new OracleParameter("cirphone2", OracleType.VarChar);
                rm28.Direction = ParameterDirection.Input;
                rm28.Value = cirph2;
                objOraclecommand.Parameters.Add(rm28);


                OracleParameter rm29 = new OracleParameter("npphone1", OracleType.VarChar);
                rm29.Direction = ParameterDirection.Input;
                rm29.Value = npph1;
                objOraclecommand.Parameters.Add(rm29);


                OracleParameter rm30 = new OracleParameter("npphone2", OracleType.VarChar);
                rm30.Direction = ParameterDirection.Input;
                rm30.Value = npph2;
                objOraclecommand.Parameters.Add(rm30);


                OracleParameter rm31 = new OracleParameter("stphone1", OracleType.VarChar);
                rm31.Direction = ParameterDirection.Input;
                rm31.Value = stph1;
                objOraclecommand.Parameters.Add(rm31);


                OracleParameter rm32 = new OracleParameter("stphone2", OracleType.VarChar);
                rm32.Direction = ParameterDirection.Input;
                rm32.Value = stph2;
                objOraclecommand.Parameters.Add(rm32);


				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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

        //public DataSet branchupdate(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string branchaccount, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
        public DataSet branchupdate(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchupdate.branchupdate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

			           OracleParameter prm4 = new OracleParameter("branchname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchname;
                objOraclecommand.Parameters.Add(prm4);
		
                         OracleParameter prm5 = new OracleParameter("alias", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
		
                 OracleParameter prm6= new OracleParameter("address", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = address;
                objOraclecommand.Parameters.Add(prm6);
		
            OracleParameter prm7 = new OracleParameter("street", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = street;
                objOraclecommand.Parameters.Add(prm7);
			
                         OracleParameter prm8 = new OracleParameter("city", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = city;
                objOraclecommand.Parameters.Add(prm8);
	
                         OracleParameter prm9= new OracleParameter("dist", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dist;
                objOraclecommand.Parameters.Add(prm9);
	
                         OracleParameter prm10 = new OracleParameter("state", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = state;
                objOraclecommand.Parameters.Add(prm10);

			  OracleParameter prm11 = new OracleParameter("country", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = country;
                objOraclecommand.Parameters.Add(prm11);

                         OracleParameter prm12 = new OracleParameter("fax", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = fax;
                objOraclecommand.Parameters.Add(prm12);

                         OracleParameter prm13 = new OracleParameter("pin", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pin;
                objOraclecommand.Parameters.Add(prm13);

           OracleParameter prm14 = new OracleParameter("phone1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = phone1;
                objOraclecommand.Parameters.Add(prm14);
			
                         OracleParameter prm15 = new OracleParameter("phone2", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = phone2;
                objOraclecommand.Parameters.Add(prm15);

                         OracleParameter prm16 = new OracleParameter("email", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = email;
                objOraclecommand.Parameters.Add(prm16);

                         OracleParameter prm17 = new OracleParameter("zone", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = zone;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("region", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = region;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("boxadd", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = boxadd;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter rm21 = new OracleParameter("pbranchnick", OracleType.VarChar);
                rm21.Direction = ParameterDirection.Input;
                rm21.Value = Branchnick;
                objOraclecommand.Parameters.Add(rm21);

                OracleParameter rm22 = new OracleParameter("pbranchaccount", OracleType.VarChar);
                rm22.Direction = ParameterDirection.Input;
                rm22.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(rm22);

                OracleParameter rm23 = new OracleParameter("finphone1", OracleType.VarChar);
                rm23.Direction = ParameterDirection.Input;
                rm23.Value = finphone1;
                objOraclecommand.Parameters.Add(rm23);


                OracleParameter rm24 = new OracleParameter("finphone2", OracleType.VarChar);
                rm24.Direction = ParameterDirection.Input;
                rm24.Value = finphone2;
                objOraclecommand.Parameters.Add(rm24);


                OracleParameter rm25 = new OracleParameter("collphone1", OracleType.VarChar);
                rm25.Direction = ParameterDirection.Input;
                rm25.Value = collph1;
                objOraclecommand.Parameters.Add(rm25);

                OracleParameter rm26 = new OracleParameter("collphone2", OracleType.VarChar);
                rm26.Direction = ParameterDirection.Input;
                rm26.Value = collph2;
                objOraclecommand.Parameters.Add(rm26);


                OracleParameter rm27 = new OracleParameter("cirphone1", OracleType.VarChar);
                rm27.Direction = ParameterDirection.Input;
                rm27.Value = cirph1;
                objOraclecommand.Parameters.Add(rm27);


                OracleParameter rm28 = new OracleParameter("cirphone2", OracleType.VarChar);
                rm28.Direction = ParameterDirection.Input;
                rm28.Value = cirph2;
                objOraclecommand.Parameters.Add(rm28);


                OracleParameter rm29 = new OracleParameter("npphone1", OracleType.VarChar);
                rm29.Direction = ParameterDirection.Input;
                rm29.Value = npph1;
                objOraclecommand.Parameters.Add(rm29);


                OracleParameter rm30 = new OracleParameter("npphone2", OracleType.VarChar);
                rm30.Direction = ParameterDirection.Input;
                rm30.Value = npph2;
                objOraclecommand.Parameters.Add(rm30);


                OracleParameter rm31 = new OracleParameter("stphone1", OracleType.VarChar);
                rm31.Direction = ParameterDirection.Input;
                rm31.Value = stph1;
                objOraclecommand.Parameters.Add(rm31);


                OracleParameter rm32 = new OracleParameter("stphone2", OracleType.VarChar);
                rm32.Direction = ParameterDirection.Input;
                rm32.Value = stph2;
                objOraclecommand.Parameters.Add(rm32);
 
				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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

		public DataSet branchexe(string compcode,string userid,string branchcode,string branchname,string alias,string country,string city, string pubcenter)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchexe.branchexe_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

			
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

			           OracleParameter prm4 = new OracleParameter("branchname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchname;
                objOraclecommand.Parameters.Add(prm4);

		                  OracleParameter prm5 = new OracleParameter("alias", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);

            	  OracleParameter prm11 = new OracleParameter("country", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (country=="0")
                {
                    prm11.Value =System .DBNull .Value ;
                }
                else
                {
                prm11.Value = country;
                }

                objOraclecommand.Parameters.Add(prm11);

			    OracleParameter prm8 = new OracleParameter("city", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if(city=="0")
                {
                    prm8.Value =System .DBNull .Value ;
                }
                else
                {
                prm8.Value = city;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm12 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm12);


             


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
 
 
				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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

		public DataSet branchfnpl(string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchfnpl.branchfnpl_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

		        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
 

				 
				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);

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



		public DataSet branchdel(string compcode,string userid,string branchcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchdel.branchdel_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

			     OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
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

	
		public DataSet contactbind(string branchcode,string userid,string compcode,string dateformat)
		{

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchbind.branchbind_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                           OracleParameter prm4= new OracleParameter("date1", OracleType.VarChar);
                           prm4.Direction = ParameterDirection.Input;
                           prm4.Value = dateformat;
                           objOraclecommand.Parameters.Add(prm4);

                           objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                           objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

				
				objorclDataAdapter.SelectCommand =objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
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
  

    //**************************To check Contact Person***************************

    public DataSet chksubmitcontact1(string contactperson,string branchcode)
    {
        //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("branchhckcontper.branchhckcontper_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

                 OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                     OracleParameter prm4= new OracleParameter("contactperson", OracleType.VarChar);
                     prm4.Direction = ParameterDirection.Input;
                     prm4.Value = contactperson;
                     objOraclecommand.Parameters.Add(prm4);

                     objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                     objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


           
        
            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }
//*******************************************************************************************

    //**************************To check Contact Person at time of update***************************

    public DataSet chksubmitcontactupdate(string contactperson, string branchcode)
    {
        //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("branchhckcontperupdate.branchhckcontperupdate_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                     OracleParameter prm4= new OracleParameter("contactperson", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = contactperson;
                objOraclecommand.Parameters.Add(prm4);



                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



         
            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
   
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }
	
		public DataSet contactupdate (string contactperson,string dob,string designation,string phone,string ext,string fax,string mail,string compcode,string userid,string branchcode,string update)
		{
			//contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchcontup.branchcontup_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
			      OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                     OracleParameter prm4= new OracleParameter("contactperson", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = contactperson;
                objOraclecommand.Parameters.Add(prm4);

                                     OracleParameter prm5= new OracleParameter("designation", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = designation;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6= new OracleParameter("dob1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (dob == "")
                    prm6.Value = dob;
                else
                    prm6.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

				/*objOraclecommand.Parameters.Add("dob", SqlDbType.DateTime);
				if(dob!="" && dob!=null)
				{
					objOraclecommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
				}
				else
				{
					objOraclecommand.Parameters["dob"].Value = System.DBNull.Value;
				}*/

                OracleParameter prm7= new OracleParameter("phone", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = phone;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8= new OracleParameter("ext", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ext;
                objOraclecommand.Parameters.Add(prm8);

                 OracleParameter prm9= new OracleParameter("fax", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = fax;
                objOraclecommand.Parameters.Add(prm9);

                 OracleParameter prm10= new OracleParameter("mail", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = mail;
                objOraclecommand.Parameters.Add(prm10);

                 OracleParameter prm11= new OracleParameter("compcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                                     OracleParameter prm12= new OracleParameter("update1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = update;
                objOraclecommand.Parameters.Add(prm12);

				
				objorclDataAdapter.SelectCommand =objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
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

		public DataSet insertcontact(string contact,string designation,string dob,string phone,string ext, string fax,string mail,string userid,string branchcode,string compcode)
		{

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchcontin.branchcontin_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
	      OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("contact", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = contact;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5= new OracleParameter("designation", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = designation;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6= new OracleParameter("dob", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (dob == "")
                    prm6.Value = dob;
                else
                    prm6.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);
                /*
				objOraclecommand.Parameters.Add("dob", SqlDbType.DateTime);

				if(dob != null && dob != "")
				{
					objOraclecommand.Parameters["dob"].Value =Convert.ToDateTime(dob);
				}
				else
				{
					objOraclecommand.Parameters["dob"].Value =System.DBNull.Value;
				}*/

				 OracleParameter prm7= new OracleParameter("phone", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = phone;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8= new OracleParameter("ext", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ext;
                objOraclecommand.Parameters.Add(prm8);

                 OracleParameter prm9= new OracleParameter("fax", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = fax;
                objOraclecommand.Parameters.Add(prm9);

                 OracleParameter prm10= new OracleParameter("mail", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = mail;
                objOraclecommand.Parameters.Add(prm10);

                           OracleParameter prm12= new OracleParameter("userid", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);


	           OracleParameter prm11= new OracleParameter("compcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

				objorclDataAdapter.SelectCommand =objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
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


		public DataSet contactbind12(string branchcode,string compcode,string userid,string hiddencccode)
		{

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchselect.branchselect_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
			 
	      OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

			    OracleParameter prm11= new OracleParameter("compcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                                 OracleParameter prm12= new OracleParameter("hiddencccode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = hiddencccode;
                objOraclecommand.Parameters.Add(prm12);


			                 OracleParameter prm13= new OracleParameter("userid", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = userid;
                objOraclecommand.Parameters.Add(prm13);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


				
				objorclDataAdapter.SelectCommand =objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
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


		public DataSet contactdelete(string branchcode,string compcode,string userid,string update)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("branchcontdel.branchcontdel_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
		
				 
	                OracleParameter prm3= new OracleParameter("branchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

			    OracleParameter prm11= new OracleParameter("compcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);


				OracleParameter prm13= new OracleParameter("userid", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = userid;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("update1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = update;
                objOraclecommand.Parameters.Add(prm14);

				
				objorclDataAdapter.SelectCommand =objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
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

        public DataSet branchnamechk(string str)//, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("chkbranchname", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT2", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = cmd;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet pubcodechk(string str, string company_code)//, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("chkpubcatcode", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar, 20);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                cmd.Parameters.Add(prm2);

                cmd.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = cmd;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet chkdel(string compcode, string branchcode, string branchname, string alias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CHECKBRANCHEXIST", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm11 = new OracleParameter("branchcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = branchcode;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm13 = new OracleParameter("branchname", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = branchname;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("branchalias", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = alias;
                objOraclecommand.Parameters.Add(prm14);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet bindbranchNo(string compcode, string branchaccount, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fa_account_type_bind.fa_account_mast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pacc_ty", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchaccount;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;








                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet bindempcode(string compcode, string empname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("emp_code_bindall", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pname", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = empname;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


}
}

