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
/// <summary>
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class Agenmerging : orclconnection
    {
        public Agenmerging()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindagency(string compcode, string userid, string agency,string agtype,string ag_main_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adb_bindagencyformerge", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ag_main_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ag_main_code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("agtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("extra1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("extra2", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);

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


        public string process_call(string compcode, string Agency_main_code, string Agency_sub_code, string from_agency_code, string to_agency_main_code, string to_agency_sub_code, string to_agency_code, string on_date, string dateformat, string remarks, string user, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_merge_agency_proc", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pfrom_agency_main_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Agency_main_code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pfrom_agency_sub_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Agency_sub_code;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pfrom_agency_code", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = from_agency_code;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pto_agency_main_code", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = to_agency_main_code;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pto_agency_sub_code", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = to_agency_sub_code;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pto_agency_code", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = to_agency_code;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("pon_date", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (on_date == "" || on_date == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = on_date.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         on_date = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(on_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm8 = new OracleParameter("premarks", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = remarks;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm10 = new OracleParameter("puser", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = user;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = dateformat;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pextra1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra2", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pextra5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm17);

                objOraclecommand.Parameters.Add("p_error", OracleType.VarChar,2000);
                objOraclecommand.Parameters["p_error"].Direction = ParameterDirection.Output;
                
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return (objOraclecommand.Parameters["p_error"].Value).ToString();

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