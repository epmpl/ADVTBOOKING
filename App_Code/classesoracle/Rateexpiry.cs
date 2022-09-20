using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;
/// <summary>
/// Summary description for Rateexpiry
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class Rateexpiry : orclconnection
    {
        public Rateexpiry()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adtypbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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



        public DataSet ratecode(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("xlsratecode.xlsratecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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


        public DataSet bindcolortyp(string compcode,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcolor.bindcolor_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


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



        public DataSet uombind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("uomadsize.uomadsize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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

        public DataSet bind_category(string compcode, string ad_type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("audit_cate.audit_cate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("v_ad_type", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ad_type;
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
                objOracleConnection.Close();
            }

        }

        public DataSet packagebind_NEW(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bindpackage_NEW.Bindpackage_NEW_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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


        public DataSet datafrgrid(string compcod, string adtyp, string rtcod, string categry, string color, string uom, string frdate, string todate, string packge, string extra1, string extra2, string dateformat, string solo, string edtn_flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_expiry", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcod;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("adtypcod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp=="")
                    prm2.Value = System.DBNull.Value;
                else
                prm2.Value = adtyp;
                objOraclecommand.Parameters.Add(prm2);

  
                OracleParameter prm3 = new OracleParameter("ratecod", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (rtcod == "0" || rtcod == "")
                prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = rtcod;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("categrycod", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (categry == "0" || categry == "")
                prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = categry;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("colorcod", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (color == "0" || color == "")
                prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = color;

                objOraclecommand.Parameters.Add(prm5);

                 OracleParameter prm6 = new OracleParameter("uomcod", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (uom == "0" || uom == "")
                prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = uom;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("frdate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (frdate == "0" || frdate == "")
                prm7.Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frdate = mm + "/" + dd + "/" + yy;
                    }
                prm7.Value = Convert.ToDateTime(frdate).ToString("dd-MMMM-yyyy");

            }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (todate == "0" || todate == "")
                    prm8.Value = todate;
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
                    prm8.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                   
                objOraclecommand.Parameters.Add(prm8);

                 OracleParameter prm9 = new OracleParameter("packgcod", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (packge == "0" || packge == "")
                prm9.Value = System.DBNull.Value;
                else
                    prm9.Value = packge;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("extra1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (extra1 == "0" || extra1 == "")
                    prm10.Value = System.DBNull.Value;
                else
                    prm10.Value = extra1;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("extra2", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (extra2 == "0" || extra2 == "")
                    prm11.Value = System.DBNull.Value;
                else
                    prm11.Value = extra2;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("p_solo", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;


                prm12.Value = solo;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pedtn_flag", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;


                prm13.Value = edtn_flag;
                objOraclecommand.Parameters.Add(prm13);

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


        public DataSet saveexpdate(string compcod, string expdate, string ratecod,string dateformat, string extra1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_expupdat", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcod;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("expdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (expdate == "0" || expdate == "")
                    prm2.Value = System.DBNull.Value;
                else
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = expdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        expdate = mm + "/" + dd + "/" + yy;
                    }
                prm2.Value = Convert.ToDateTime(expdate).ToString("dd-MMMM-yyyy");
                  
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("ratecod", OracleType.VarChar, 500);
                prm3.Direction = ParameterDirection.Input;
                if (ratecod == "0" || ratecod == "")
                    prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = ratecod;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm10 = new OracleParameter("extra1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (extra1 == "0" || extra1 == "")
                    prm10.Value = System.DBNull.Value;
                else
                    prm10.Value = extra1;
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

    }
}