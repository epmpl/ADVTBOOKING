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
    /// Summary description for region
    /// </summary>
    public class region : orclconnection 
    {
        public region()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet regionmaster_save(string Comp_Code, string Region_Code, string Region_Name, string Region_alias, string UserId, string zone)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("region_save.region_save_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

         



                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Region_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Region_Code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Region_Name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Region_Name;
                objOraclecommand.Parameters.Add(prm3);

              

                OracleParameter prm5 = new OracleParameter("Region_alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Region_alias;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("UserId", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("zone1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = zone;
                objOraclecommand.Parameters.Add(prm7);

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





        public DataSet regionmaster_modify(string Comp_Code, string Region_Code, string Region_Name, string Region_alias, string UserId, string zone)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_modifyregion.sp_modifyregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;          

              

                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Region_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Region_Code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Region_Name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Region_Name;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm5 = new OracleParameter("Region_alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Region_alias;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("zone1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = zone;
                objOraclecommand.Parameters.Add(prm6);


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



        public DataSet chkregion(string compcode, string regioncode, string regionname, string alias, string username, string zone)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_chkregion.sp_chkregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = regioncode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("regionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = regionname;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm5 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("zone1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = zone;
                objOraclecommand.Parameters.Add(prm6);

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


        //********************************************************************************************************	

        //*******************************************************************************************************


        public DataSet btndelete(string compcode, string regioncode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("regiondel.regiondel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;              

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = regioncode;
                objOraclecommand.Parameters.Add(prm2);


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


        public DataSet chkregion123(string compcode, string regionname, string regioncode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkregion.chkregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = regioncode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("regionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = regionname;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

             


           

               


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
        public DataSet countregioncode(string str,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkregioncodename.chkregioncodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;            

              

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length  >2)
                {
                prm2.Value = str.Substring (0,2);
                }
                else
                {
                     prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;



                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;




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
        //******************************************************************************************************
        public DataSet chknameforduplicate(string regioncode, string regionname, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkduplicateregion.chkduplicateregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = regioncode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("regionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = regionname;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;




              



               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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

        //******************************************************************************************************
        public DataSet getzone(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindzone.bindzone_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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
    }
}
