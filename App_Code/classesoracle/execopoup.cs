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
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{


    /// <summary>
    /// Summary description for coupon_booklate
    /// </summary>


    public class execopoup : orclconnection
    {
        public execopoup()
        {
            //
            // TODO: Add constructor logic here
            //
        }




        public DataSet fill_reoprt(string compcode, string pag, string id, string dateformate, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_agent.Websp_agent_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                //OracleParameter prm2 = new OracleParameter("pag_name", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = pag;
                //objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = id;
                objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = dateformate;
                //objOraclecommand.Parameters.Add(prm4);

                //OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                //prm5.Direction = ParameterDirection.Input;
                //prm5.Value = extra1;
                //objOraclecommand.Parameters.Add(prm5);

                //OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                //prm6.Direction = ParameterDirection.Input;
                //prm6.Value = extra2;
                //objOraclecommand.Parameters.Add(prm6);

                //OracleParameter prm7 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = extra3;
                //objOraclecommand.Parameters.Add(prm7);

                //OracleParameter prm8 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                //prm8.Direction = ParameterDirection.Input;
                //prm8.Value = extra4;
                //objOraclecommand.Parameters.Add(prm8);

                //OracleParameter prm9 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                //prm9.Direction = ParameterDirection.Input;
                //prm9.Value = extra5;
                //objOraclecommand.Parameters.Add(prm9);




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



        public DataSet duplicasy_ckeck(string compcode, string execcode, string agencycode, string fromdate, string todate, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_EXEC_DUP", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = execcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pag_type_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;

                if (todate == "" || todate == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);



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






        public DataSet savedata_table(string compcode, string agencycode, string days, string limit, string recovery, string fromdate, string todate, string execcode, string createdby, string createddt, string updatedby, string updateddt, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_EXEC_insert", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pag_type_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencycode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcredit_days", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = days;
                objOraclecommand.Parameters.Add(prm3);





                OracleParameter prm4 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;

                if (todate == "" || todate == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pcredit_limit", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = limit;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("precovery_limit", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = recovery;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = execcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pcreadit_by", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = createdby;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pcreadet_dt", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;

                if (createddt == "" || createddt == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = createddt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        createddt = mm + "/" + dd + "/" + yy;


                    }
                    prm10.Value = Convert.ToDateTime(createddt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pupdated_by", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = updatedby;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pupdated_dt", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;

                if (updateddt == "" || updateddt == null)
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = updateddt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        updateddt = mm + "/" + dd + "/" + yy;


                    }
                    prm12.Value = Convert.ToDateTime(updateddt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);


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
        public DataSet binddata_grid(string compcode, string agencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_EXEC_CREDIT_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencycode;
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


        public DataSet bind_agency(string compcode, string reportto)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                string query = "select ad_agencytype_name('" + compcode + "','" + reportto + "') as Agency_Name from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }





        public DataSet mdy_table(string compcode, string agencycode, string days, string limit, string recovery, string fromdate, string todate, string execcode, string createdby, string createddt, string updatedby, string updateddt, string dateformat, string slab_no)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_EXEC_update", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pag_type_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencycode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcredit_days", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = days;
                objOraclecommand.Parameters.Add(prm3);





                OracleParameter prm4 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;

                if (todate == "" || todate == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pcredit_limit", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = limit;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("precovery_limit", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = recovery;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = execcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pcreadit_by", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = createdby;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pcreadet_dt", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;

                if (createddt == "" || createddt == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = createddt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        createddt = mm + "/" + dd + "/" + yy;


                    }
                    prm10.Value = Convert.ToDateTime(createddt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pupdated_by", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = updatedby;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pupdated_dt", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;

                if (updateddt == "" || updateddt == null)
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = updateddt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        updateddt = mm + "/" + dd + "/" + yy;


                    }
                    prm12.Value = Convert.ToDateTime(updateddt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pexec_slab_sno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = slab_no;
                objOraclecommand.Parameters.Add(prm13);


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


        public DataSet delete_data(string compcode,  string execcode, string slab_no)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_EXEC_del", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                              

                OracleParameter prm8 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = execcode;
                objOraclecommand.Parameters.Add(prm8);

               

                OracleParameter prm13 = new OracleParameter("pexec_slab_sno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = slab_no;
                objOraclecommand.Parameters.Add(prm13);


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