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
    /// Summary description for RepMast
    /// </summary>
    public class RepMast : orclconnection
    {
        public RepMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet chkdoc(string compcode, string userid, string repcode, string repname, string dist, string taluka1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("chkrep.chkrep_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compcode;
              objOraclecommand.Parameters.Add(prm1);

              OracleParameter prm2 = new OracleParameter("repcode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = repcode;
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm3 = new OracleParameter("repname", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = repname;
              objOraclecommand.Parameters.Add(prm3);

              OracleParameter prm4 = new OracleParameter("dist", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = dist;
              objOraclecommand.Parameters.Add(prm4);

              OracleParameter prm5 = new OracleParameter("taluka1", OracleType.VarChar, 50);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = taluka1;
              objOraclecommand.Parameters.Add(prm5);

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


        public DataSet docmodify(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("repmodify.repmodify_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;
              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compcode;
              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("repcode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = repcode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("repname", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = repname;
              objOraclecommand.Parameters.Add(prm3);

              OracleParameter prm5 = new OracleParameter("country", OracleType.VarChar, 50);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = country;
              objOraclecommand.Parameters.Add(prm5);

              OracleParameter prm6 = new OracleParameter("city", OracleType.VarChar, 50);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = city;
              objOraclecommand.Parameters.Add(prm6);

              OracleParameter prm7 = new OracleParameter("state", OracleType.VarChar, 50);
              prm7.Direction = ParameterDirection.Input;
              prm7.Value = state;
              objOraclecommand.Parameters.Add(prm7);

              OracleParameter prm8 = new OracleParameter("dist", OracleType.VarChar, 50);
              prm8.Direction = ParameterDirection.Input;
              prm8.Value = dist;
              objOraclecommand.Parameters.Add(prm8);

              OracleParameter prm9 = new OracleParameter("taluka1", OracleType.VarChar, 50);
              prm9.Direction = ParameterDirection.Input;
              prm9.Value = taluka1;
              objOraclecommand.Parameters.Add(prm9);

              OracleParameter prm10 = new OracleParameter("repstatus", OracleType.VarChar, 50);
              prm10.Direction = ParameterDirection.Input;
              prm10.Value = repstatus;
              objOraclecommand.Parameters.Add(prm10);

          
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


        public DataSet docinsert(string compcode, string userid, string repcode, string repname,string country,string city,string state,string dist,string taluka1,string repstatus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("repinsert.repinsert_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;


              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compcode;
              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("repcode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = repcode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("repname", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = repname;
              objOraclecommand.Parameters.Add(prm3);

              OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = userid;
              objOraclecommand.Parameters.Add(prm4);


              OracleParameter prm5 = new OracleParameter("country", OracleType.VarChar, 50);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = country;
              objOraclecommand.Parameters.Add(prm5);

              OracleParameter prm6 = new OracleParameter("city", OracleType.VarChar, 50);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = city;
              objOraclecommand.Parameters.Add(prm6);

              OracleParameter prm7 = new OracleParameter("state", OracleType.VarChar, 50);
              prm7.Direction = ParameterDirection.Input;
              prm7.Value = state;
              objOraclecommand.Parameters.Add(prm7);

              OracleParameter prm8 = new OracleParameter("dist", OracleType.VarChar, 50);
              prm8.Direction = ParameterDirection.Input;
              prm8.Value = dist;
              objOraclecommand.Parameters.Add(prm8);

              OracleParameter prm9 = new OracleParameter("taluka1", OracleType.VarChar, 50);
              prm9.Direction = ParameterDirection.Input;
              prm9.Value = taluka1;
              objOraclecommand.Parameters.Add(prm9);

              OracleParameter prm10 = new OracleParameter("repstatus", OracleType.VarChar, 50);
              prm10.Direction = ParameterDirection.Input;
              prm10.Value = repstatus;
              objOraclecommand.Parameters.Add(prm10);

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



        public DataSet docexe(string compcode, string userid, string repcode, string repname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("repexe.repexe_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compcode;
              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("repcode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = repcode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("repname", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = repname;
              objOraclecommand.Parameters.Add(prm3);
                
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



        public DataSet docfnpl(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("repfnpl.repfnpl_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;
              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compcode;
              objOraclecommand.Parameters.Add(prm1);
              objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
              objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

            
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

        public DataSet docdel(string compcode, string userid, string repcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("repdel.repdel_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compcode;
              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("repcode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = repcode;
              objOraclecommand.Parameters.Add(prm2);
              objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
              objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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


        public DataSet chkrpcode1(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("rpnamechk.rpnamechk_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = str;
              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              if (str.Length > 2)
              {
                  prm2.Value = str.Substring(0, 2);

              }
              else
              {
                  prm2.Value = str;
              }
              objOraclecommand.Parameters.Add(prm2);
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



        //------------------------- ad by rinki ----------------------------------//

        public DataSet adcountryname(string compcode)
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


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

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

        public DataSet countcity(string txtcountry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcity.fillcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("txtcountry", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = txtcountry;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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


        public DataSet addcitydist(string cityname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retaineraddregion.retaineraddregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("regioncode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cityname;
                objOraclecommand.Parameters.Add(prm3);

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

                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts8", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts8"].Direction = ParameterDirection.Output;


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





        public DataSet fill_subcat(string compcode, string ASD)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getrepnamesp", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm4 = new OracleParameter("repname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ASD;
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



    }
}
