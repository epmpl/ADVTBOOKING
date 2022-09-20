using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for agency_type_slab
    /// </summary>
    /// 

    //namespace NewAdbooking.Classes
    //{
        public class agency_type_slab : orclconnection
        {
            public DataSet saveagencytype(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("websp_agency_type_slab", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_agency_type", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = agency_type;
                    objOraclecommand.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("p_comm_type", OracleType.VarChar);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = comm_type;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("p_comm_rate", OracleType.VarChar);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = comm_rate;
                    objOraclecommand.Parameters.Add(prm4);


                    OracleParameter prm5 = new OracleParameter("p_from_days", OracleType.VarChar);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = from_days;
                    objOraclecommand.Parameters.Add(prm5);


                    OracleParameter prm6 = new OracleParameter("p_till_days", OracleType.VarChar);
                    prm6.Direction = ParameterDirection.Input;
                    prm6.Value = till_days;
                    objOraclecommand.Parameters.Add(prm6);


                    OracleParameter prm7 = new OracleParameter("p_valid_from", OracleType.VarChar, 50);
                    prm7.Direction = ParameterDirection.Input;
                    if (valid_from == null || valid_from == "" || valid_from == "undefined/undefined/")
                    {
                        prm7.Value = System.DBNull.Value;
                    }
                    else
                    {

                        prm7.Value = Convert.ToDateTime(valid_from).ToString("dd-MMMM-yyyy");
                    }

                    objOraclecommand.Parameters.Add(prm7);


                    //OracleParameter prm7 = new OracleParameter("p_valid_from", OracleType.VarChar);
                    //prm7.Direction = ParameterDirection.Input;
                    //prm7.Value = valid_from;
                    //objOraclecommand.Parameters.Add(prm7);


                    OracleParameter prm8 = new OracleParameter("p_valid_to", OracleType.VarChar, 50);
                    prm8.Direction = ParameterDirection.Input;
                    if (valid_to == null || valid_to == "" || valid_to == "undefined/undefined/")
                    {
                        prm8.Value = System.DBNull.Value;
                    }
                    else
                    {

                        prm8.Value = Convert.ToDateTime(valid_to).ToString("dd-MMMM-yyyy");
                    }

                    objOraclecommand.Parameters.Add(prm8);


                    //OracleParameter prm8 = new OracleParameter("p_valid_to", OracleType.VarChar);
                    //prm8.Direction = ParameterDirection.Input;
                    //prm8.Value = valid_to;
                    //objOraclecommand.Parameters.Add(prm8);


                    OracleParameter prm9 = new OracleParameter("p_userid", OracleType.VarChar);
                    prm9.Direction = ParameterDirection.Input;
                    prm9.Value = userid;
                    objOraclecommand.Parameters.Add(prm9);


                    OracleParameter prm10 = new OracleParameter("p_extra1", OracleType.VarChar);
                    prm10.Direction = ParameterDirection.Input;
                    prm10.Value = extra1;
                    objOraclecommand.Parameters.Add(prm10);


                    OracleParameter prm11 = new OracleParameter("p_extra2", OracleType.VarChar);
                    prm11.Direction = ParameterDirection.Input;
                    prm11.Value = extra2;
                    objOraclecommand.Parameters.Add(prm11);

                    OracleParameter prm12 = new OracleParameter("p_extra3", OracleType.VarChar);
                    prm12.Direction = ParameterDirection.Input;
                    prm12.Value = extra3;
                    objOraclecommand.Parameters.Add(prm12);


                    OracleParameter prm13 = new OracleParameter("p_extra4", OracleType.VarChar);
                    prm13.Direction = ParameterDirection.Input;
                    prm13.Value = extra4;
                    objOraclecommand.Parameters.Add(prm13);

                    OracleParameter prm14 = new OracleParameter("p_extra5", OracleType.VarChar);
                    prm14.Direction = ParameterDirection.Input;
                    prm14.Value = extra5;
                    objOraclecommand.Parameters.Add(prm14);


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


            public DataSet saveagencytype_UPDATE(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("websp_agency_type_slab_UPDATE", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_agency_type", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = agency_type;
                    objOraclecommand.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("p_comm_type", OracleType.VarChar);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = comm_type;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("p_comm_rate", OracleType.VarChar);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = comm_rate;
                    objOraclecommand.Parameters.Add(prm4);


                    OracleParameter prm5 = new OracleParameter("p_from_days", OracleType.VarChar);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = from_days;
                    objOraclecommand.Parameters.Add(prm5);


                    OracleParameter prm6 = new OracleParameter("p_till_days", OracleType.VarChar);
                    prm6.Direction = ParameterDirection.Input;
                    prm6.Value = till_days;
                    objOraclecommand.Parameters.Add(prm6);


                    OracleParameter prm7 = new OracleParameter("p_valid_from", OracleType.VarChar, 50);
                    prm7.Direction = ParameterDirection.Input;
                    if (valid_from == null || valid_from == "" || valid_from == "undefined/undefined/")
                    {
                        prm7.Value = System.DBNull.Value;
                    }
                    else
                    {

                        prm7.Value = Convert.ToDateTime(valid_from).ToString("dd-MMMM-yyyy");
                    }

                    objOraclecommand.Parameters.Add(prm7);

                    //OracleParameter prm7 = new OracleParameter("p_valid_from", OracleType.VarChar);
                    //prm7.Direction = ParameterDirection.Input;
                    //prm7.Value = valid_from;
                    //objOraclecommand.Parameters.Add(prm7);


                    OracleParameter prm8 = new OracleParameter("p_valid_to", OracleType.VarChar, 50);
                    prm8.Direction = ParameterDirection.Input;
                    if (valid_to == null || valid_to == "" || valid_to == "undefined/undefined/")
                    {
                        prm8.Value = System.DBNull.Value;
                    }
                    else
                    {

                        prm8.Value = Convert.ToDateTime(valid_to).ToString("dd-MMMM-yyyy");
                    }

                    objOraclecommand.Parameters.Add(prm8);

                    //OracleParameter prm8 = new OracleParameter("p_valid_to", OracleType.VarChar);
                    //prm8.Direction = ParameterDirection.Input;
                    //prm8.Value = valid_to;
                    //objOraclecommand.Parameters.Add(prm8);


                    OracleParameter prm9 = new OracleParameter("p_userid", OracleType.VarChar);
                    prm9.Direction = ParameterDirection.Input;
                    prm9.Value = userid;
                    objOraclecommand.Parameters.Add(prm9);


                    OracleParameter prm10 = new OracleParameter("p_extra1", OracleType.VarChar);
                    prm10.Direction = ParameterDirection.Input;
                    prm10.Value = extra1;
                    objOraclecommand.Parameters.Add(prm10);


                    OracleParameter prm11 = new OracleParameter("p_extra2", OracleType.VarChar);
                    prm11.Direction = ParameterDirection.Input;
                    prm11.Value = extra2;
                    objOraclecommand.Parameters.Add(prm11);

                    OracleParameter prm12 = new OracleParameter("p_extra3", OracleType.VarChar);
                    prm12.Direction = ParameterDirection.Input;
                    prm12.Value = extra3;
                    objOraclecommand.Parameters.Add(prm12);


                    OracleParameter prm13 = new OracleParameter("p_extra4", OracleType.VarChar);
                    prm13.Direction = ParameterDirection.Input;
                    prm13.Value = extra4;
                    objOraclecommand.Parameters.Add(prm13);

                    OracleParameter prm14 = new OracleParameter("p_extra5", OracleType.VarChar);
                    prm14.Direction = ParameterDirection.Input;
                    prm14.Value = extra5;
                    objOraclecommand.Parameters.Add(prm14);


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

            public DataSet agencytypeexecute(string comp_code,string agency_type)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("websp_agency_type_slab_exec", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = comp_code;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_agency_type", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = agency_type;
                    objOraclecommand.Parameters.Add(prm2);

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

            public DataSet cheakduplicacy(string compcode, string cotype, string corate, string fromdays, string todays, string validfrom, string validto)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("websp_ag_type_slab_dupli", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_commtype", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = cotype;
                    objOraclecommand.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("p_commrate", OracleType.VarChar);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = corate;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("p_fromdays", OracleType.VarChar);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = fromdays;
                    objOraclecommand.Parameters.Add(prm4);

                    OracleParameter prm5 = new OracleParameter("p_todays", OracleType.VarChar);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = todays;
                    objOraclecommand.Parameters.Add(prm5);

                    OracleParameter prm6 = new OracleParameter("p_validfrom", OracleType.VarChar);
                    prm6.Direction = ParameterDirection.Input;
                    prm6.Value = validfrom;
                    objOraclecommand.Parameters.Add(prm6);

                    OracleParameter prm7 = new OracleParameter("p_validto", OracleType.VarChar);
                    prm7.Direction = ParameterDirection.Input;
                    prm7.Value = validto;
                    objOraclecommand.Parameters.Add(prm7);

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

            public DataSet agencytypeexecute1123(string agecode, string compcode, string userid, string code)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("websp_agency_type_slab_exec12", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_code", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = code;
                    objOraclecommand.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("p_userid", OracleType.VarChar);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = userid;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("p_agencode", OracleType.VarChar);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = agecode;
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

            public DataSet agencytypedelete(string compcode,string agencytypecode,string cotype,string corate,string hdnsescode)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("websp_agency_type_slab_delete", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_agency_type", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = agencytypecode;
                    objOraclecommand.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("p_commtype", OracleType.VarChar);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = cotype;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("p_commrate", OracleType.VarChar);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = corate;
                    objOraclecommand.Parameters.Add(prm4);

                    OracleParameter prm5 = new OracleParameter("p_hdnsescode", OracleType.VarChar);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = hdnsescode;
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

            public DataSet slabchk(string sf, string st, string txtfrom, string txtto, string dateformat)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("slabchk_b", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("p_sf", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = sf;
                    objOraclecommand.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("p_st", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = st;
                    objOraclecommand.Parameters.Add(prm2);


                    OracleParameter prm3 = new OracleParameter("p_txtfrom", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = txtfrom;
                    objOraclecommand.Parameters.Add(prm3);



                    OracleParameter prm4 = new OracleParameter("p_txtto", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = txtto;
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
//}