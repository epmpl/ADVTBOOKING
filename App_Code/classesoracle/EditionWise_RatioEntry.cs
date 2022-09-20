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
/// <summary>
/// Summary description for EditionWise_RatioEntry
/// </summary>


namespace NewAdbooking.classesoracle
{
    public class EditionWise_RatioEntry :orclconnection
    {
        public EditionWise_RatioEntry()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindedition(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BindMainEdition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
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
                objOracleConnection.Close();
            }
        }

        public DataSet GetSubEdition(string compcode,string editionalias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("GetSubEdition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editionname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editionalias;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
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
                objOracleConnection.Close();
            }
        }


        public DataSet saveeditionratio(string compcode, string userid, string maineditioncode, string subeditionname, string pubcode, string subeditioncode, string percentage, string effectivedate, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("saveeditionwise_ratioentry", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("maineditioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = maineditioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("subeditionname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = subeditionname;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("subeditioncode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = subeditioncode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("percentage", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = percentage;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("effectivedate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (effectivedate == "" || effectivedate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = effectivedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        effectivedate = mm + "/" + dd + "/" + yy;   
                    }

                    prm8.Value = Convert.ToDateTime(effectivedate).ToString("dd-MMMM-yyyy"); 
                }
              
                objOraclecommand.Parameters.Add(prm8);

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


        public DataSet exemainditionratio(string editioncode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executemainedition_ratioentry", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
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
                objOracleConnection.Close();
            }
        }


        public DataSet executeeditionwiseratio(string editioncode, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executeeditionwise_ratioentry", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
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
                objOracleConnection.Close();
            }
        }



        public DataSet updateeditionratio(string compcode, string userid, string subeditioncode, string maineditioncode, string percentage, string effectivedate, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifyeditionwise_ratioentry", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("maineditioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = maineditioncode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("subeditioncode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = subeditioncode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("percentage1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = percentage;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("effectivedate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (effectivedate == "" || effectivedate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = effectivedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        effectivedate = mm + "/" + dd + "/" + yy;
                    }

                    prm8.Value = Convert.ToDateTime(effectivedate).ToString("dd-MMMM-yyyy");
                }
              
                objOraclecommand.Parameters.Add(prm8);

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


        public DataSet editiondelete(string editioncode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deleteeditionwise_ratioentry", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("maineditioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

               

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
                objOracleConnection.Close();
            }
        }

        public DataSet chkduplicacy(string editioncode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkduplicayforEWRE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
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
                objOracleConnection.Close();
            }
        }
        
    }
}
