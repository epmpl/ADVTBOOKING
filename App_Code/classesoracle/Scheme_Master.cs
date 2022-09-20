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
/// Summary description for Scheme_Master
/// </summary>

namespace NewAdbooking.classesoracle

{
    public class Scheme_Master:orclconnection
    {
        public Scheme_Master()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet schemechk(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string scheme_name, string sc)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schemechk.schemechk_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("scheme_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = scheme_id;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("schemecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = schemecode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("scheme_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = scheme_name;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("sc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sc;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("frominsert", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = frominsert;
                objOraclecommand.Parameters.Add(prm5);




                OracleParameter prm6 = new OracleParameter("toinsert", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = toinsert;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("validfrom", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("validto", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("discount", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = discount;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


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



        public DataSet schemeautocode(string scheme_name)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schemeautocode.schemeautocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("scheme_name", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = scheme_name;
                objOraclecommand.Parameters.Add(prm1);


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




        public DataSet modifyscheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string scheme_name)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifyscheme.modifyscheme_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("scheme_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = scheme_id;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("schemecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = schemecode;
                objOraclecommand.Parameters.Add(prm2);

              
                OracleParameter prm3 = new OracleParameter("scheme_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = scheme_name;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("frominsert", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = frominsert;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("toinsert", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = toinsert;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("validfrom", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = validfrom;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("validto", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = validto;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("discount", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = discount;
                objOraclecommand.Parameters.Add(prm9);




                OracleParameter prm10 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = userid;
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


        public DataSet schememodifychk(string scheme_id, string schemecode, string scheme_name, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schememodifychk.schememodifychk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("scheme_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = scheme_id;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("schemecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = schemecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("scheme_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = scheme_name;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

                //return objDataSet;

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


        //public DataSet updatescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string flagsave)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("schemeupdate", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;


        //        objSqlCommand.Parameters.Add("@scheme_id", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@scheme_id"].Value = scheme_id;

        //        objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@schemecode"].Value = schemecode;


        //        objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Decimal);
        //        if (frominsert == null || frominsert == "")
        //        {
        //            objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@frominsert"].Value = Convert.ToInt32(frominsert);
        //        }

        //        objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Decimal);
        //        if (toinsert == null || toinsert == "")
        //        {
        //            objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@toinsert"].Value = Convert.ToInt32(toinsert);
        //        }

        //        objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
        //        if (discount == null || discount == "")
        //        {
        //            objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
        //        }

        //        objSqlCommand.Parameters.Add("@validfrom", SqlDbType.DateTime);
        //        if (validfrom == "" || validfrom == null || validfrom == "undefined/undefined/")
        //        {
        //            objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@validfrom"].Value = Convert.ToDateTime(validfrom);
        //        }

        //        objSqlCommand.Parameters.Add("@validto", SqlDbType.DateTime);
        //        if (validto == "" || validto == null || validto == "undefined/undefined/")
        //        {
        //            objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@validto"].Value = Convert.ToDateTime(validto);
        //        }


        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@flagsave", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@flagsave"].Value = flagsave;


        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }


        //}

        //public DataSet savescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string userid, string flag, string scheme_name,string adcat)
        public DataSet savescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string userid, string flag, string scheme_name, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string contidate, string consumption, string alternatedate)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schemesave.schemesave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;
                OracleParameter prm1 = new OracleParameter("scheme_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = scheme_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("schemecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = schemecode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("scheme_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = scheme_name;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("frominsert", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToInt32(frominsert);
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("toinsert", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToInt32(toinsert);
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("discount_type", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = discount_type;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("discount", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDecimal(discount);
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("validfrom", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validto", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = compcode;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = flag;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("psun", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = sun;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pmon", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = mon;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("ptue", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = tue;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pwed", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = wed;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pthu", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = thu;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pfri", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = fri;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("psat", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = sat;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pcontidate", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = contidate;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pconsumption", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = consumption;
                objOraclecommand.Parameters.Add(prm21);


                OracleParameter prm21e = new OracleParameter("palternatedate", OracleType.VarChar, 50);
                prm21e.Direction = ParameterDirection.Input;
                prm21e.Value = alternatedate;
                objOraclecommand.Parameters.Add(prm21e);

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
        public DataSet ptdelete(string scheme_id, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schemedelete.schemedelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("scheme_id", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = scheme_id;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
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


        public DataSet ptexecute(string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string scheme_name)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schemeexe.schemeexe_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("scheme_name", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = scheme_name;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("schemecode", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = schemecode;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("frominsert", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = frominsert;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("toinsert", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = toinsert;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = compcode;
                objOraclecommand.Parameters.Add(prm15);



                OracleParameter prm16 = new OracleParameter("validfrom", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = validfrom;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("validto", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = validto;
                objOraclecommand.Parameters.Add(prm17);



                OracleParameter prm18 = new OracleParameter("discount_type", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                if (discount_type=="0")
                {
                    prm18.Value = System .DBNull .Value;
                }
                else
                {
                    prm18.Value = discount_type;
                }
                
                objOraclecommand.Parameters.Add(prm18);



                OracleParameter prm19 = new OracleParameter("discount", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = discount;
                objOraclecommand.Parameters.Add(prm19);

                //OracleParameter prm20 = new OracleParameter("contidate", OracleType.VarChar, 50);
                //prm20.Direction = ParameterDirection.Input;
                //prm20.Value = contidate;
                //objOraclecommand.Parameters.Add(prm20);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
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
