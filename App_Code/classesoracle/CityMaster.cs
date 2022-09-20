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
    /// Summary description for CityMaster
    /// </summary>
    public class CityMaster : orclconnection 
    {
        public CityMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet distselect(string compcode, string userid, string statcode, string distcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("distsel.distsel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

              


                OracleParameter prm3 = new OracleParameter("statcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = statcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("distcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = distcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

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
                CloseConnection(ref objOracleConnection);
            }
        }




        public DataSet bindstate(string code, string compcode, string userid)
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


                OracleParameter prm3 = new OracleParameter("countrycode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOraclecommand.Parameters.Add(prm3);
               

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet binddistrict(string code1, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("binddistrict.binddistrict_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm3 = new OracleParameter("statecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code1;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
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
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet ModifyValue(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMstModify.CityMstModify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("CityCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CityCode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm2 = new OracleParameter("CityName", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CityName;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("DistrictName", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = DistrictName;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = StateName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("ZoneName", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ZoneName;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = CountryName;
                objOraclecommand.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("CitySTD", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = CitySTD;
                objOraclecommand.Parameters.Add(prm9);
                OracleParameter prm10= new OracleParameter("Region", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = Region;
                objOraclecommand.Parameters.Add(prm10);   

             


               

                

              
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (OracleException  objException)
            {
                throw (objException);
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


        public DataSet InsertValue(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMstInsert.CityMstInsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;        


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm3 = new OracleParameter("CityCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CityCode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm2 = new OracleParameter("CityName", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CityName;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("DistrictName", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = DistrictName;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = StateName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("ZoneName", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ZoneName;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = CountryName;
                objOraclecommand.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("CitySTD", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = CitySTD;
                objOraclecommand.Parameters.Add(prm9);
                OracleParameter prm10 = new OracleParameter("Region", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = Region;
                objOraclecommand.Parameters.Add(prm10);   


               
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (OracleException objException)
            {
                throw (objException);
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

        public DataSet SelectValue(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMstSelect.CityMstSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure; 


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("CityCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CityCode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm2 = new OracleParameter("CityName", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CityName;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("DistrictName", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (DistrictName=="0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                prm6.Value = DistrictName;
                }
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (StateName == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = StateName;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("ZoneName", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (ZoneName == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = ZoneName;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (CountryName == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = CountryName;
                }
                objOraclecommand.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("CitySTD", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = CitySTD;
                objOraclecommand.Parameters.Add(prm9);
                OracleParameter prm10 = new OracleParameter("Region", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (Region == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Region;
                }
                objOraclecommand.Parameters.Add(prm10);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
               
               
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (OracleException objException)
            {
                throw (objException);
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

        public DataSet Selectfnpl(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMstfnpl.CityMstfnpl_p", ref objOracleConnection);
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

            catch (OracleException objException)
            {
                throw (objException);
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

        public DataSet district(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMst_District.CityMst_District_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet state(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMst_State.CityMst_State_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet zone(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMst_Zone.CityMst_Zone_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet country(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMst_Country.CityMst_Country_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet region(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMst_Region.CityMst_Region_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet DeleteValue(string CityCode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CityMastDelete.CityMastDelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

             



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("CityCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CityCode;
                objOraclecommand.Parameters.Add(prm3);

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
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet citycheck(string CityCode, string compcode, string name, string CountryName, string StateName, string DistrictName, string mode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("citychkcode.citychkcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;






         

                OracleParameter prm3 = new OracleParameter("CityCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CityCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("name", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = name;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("CountryName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = CountryName;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("StateName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = StateName;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("DistrictName", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = DistrictName;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("mode1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = mode;
                objOraclecommand.Parameters.Add(prm7);

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
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet countcode(string str, string countrycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("chkcitycodename.chkcitycodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if(str.Length >2)
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
                CloseConnection(ref objOracleConnection);
            }
        }
//------------------ for branch save ----------------------------
        public DataSet getbranch()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_getbranchname.login_getbranchname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet usersavebranch(string username, string branchcode, string compcode, string CityCode,string userflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CitySaveBranch", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branchcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("CityCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CityCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userflag1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userflag;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

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

        public DataSet executebranch(string compcode, string citycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("citybranchexe", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = citycode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

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

        public DataSet userupdatebranch(string username, string branchcode, string compcode, string citycode, string userflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CityUpdateBranch", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("branchcode1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branchcode;
                objOraclecommand.Parameters.Add(prm2);

              

              
                OracleParameter prm3 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = citycode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("userflag1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userflag;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

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

//==========Bind Region=============
        public DataSet bindregion(string code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindregion", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("zonecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindCity(string dstcode, string code1, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BINDCITY_EDITION", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm1 = new OracleParameter("statecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code1;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("distcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dstcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("uid", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = userid;
                objOraclecommand.Parameters.Add(prm21);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




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
                CloseConnection(ref objOracleConnection);
            }
        }
    }
}
