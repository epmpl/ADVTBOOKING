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
/// Summary description for ColorRateGroupMast
/// </summary>
///
namespace NewAdbooking.classesoracle
{
    public class ColorRateGroupMast:orclconnection
    {
        public ColorRateGroupMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //Bind publication
        public DataSet pubmast(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_BindPublication.CR_BindPublication_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


                
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
        //Bind Edition
        public DataSet seledition(string compcode, string pub)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_BindEdition.CR_BindEdition_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pub;
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

        //Bind Supplement
        public DataSet suppliment(string compcode, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_BindSupplement.CR_BindSupplement_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);
                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


                

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
        //Bind Color
        public DataSet fillcolor(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_BindColor.CR_BindColor_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
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
        //AutoGenerated Code
        public DataSet autocode()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_autocode.CR_autocode_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@str", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@str"].Value = str;

                //objOraclecommand.Parameters.Add("@code", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@code"].Value = str;
                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;

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

        //Select Package
        public DataSet selpackage(string compcode, string pack_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_BindPackage.CR_BindPackage_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Packcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pack_code;
                objOraclecommand.Parameters.Add(prm2);



                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;



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

        //Display On Selected
        public DataSet packdes(string compcode, string pack_des)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_BindPackdescr.CR_BindPackdescr_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packdes", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pack_des;
                objOraclecommand.Parameters.Add(prm2);
                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


                

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
        //Insert
        public DataSet insertedvalue(string crgcode, string crgname, string drppub, string drpedi, string drpsupp, string drpcolrate, string drpcolname, string crgover, string compcode, string userid, string fromdate, string tilldate, string colorcode, string adtype, string rategpcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cr_insert.cr_insert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("crgcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = crgcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("crgname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = crgname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drppub;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpedi;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("suppliment", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpsupp;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("colorrate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcolrate;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("colname", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = drpcolname;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pecent", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = crgover;
                objOraclecommand.Parameters.Add(prm10);

              
               


                OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("tilldate", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("colorcode", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = colorcode;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("ad_type", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adtype;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("rategpcode", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = rategpcode;
                objOraclecommand.Parameters.Add(prm16);
              

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

        //Chechk Code Before Insert
        public DataSet chkcode(string colorcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_checkcode.CR_checkcode_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@code", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@code"].Value = crgcode;


                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("colorcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colorcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


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

        //Check Color Before Insert
        public DataSet chkcolor(string drpcolname, string compcode, string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_checkcolor.CR_checkcolor_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@code", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@code"].Value = crgcode;
                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("colorname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = drpcolname;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;



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

        //Check Color Before Modify
        public DataSet checkcolor(string drpcolname, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_checkcolormodify.CR_checkcolormodify_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@code", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@code"].Value = crgcode;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("colorname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = drpcolname;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;

             
                

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


        //Modify The Value
        public DataSet updatecrg(string crgcode, string crgname, string drppub, string drpedi, string drpsupp, string drpcolrate, string drpcolname, string crgover, string compcode, string fromdate, string tilldate, string colorcode, string adtype, string rategpcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_Modify.CR_Modify_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                //objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value = userid;
                OracleParameter prm2 = new OracleParameter("crgcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = crgcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("crgname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = crgname;
                objOraclecommand.Parameters.Add(prm3);
             
                               

                //objOraclecommand.Parameters.Add("@publication", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@publication"].Value = drppub;

                //objOraclecommand.Parameters.Add("@edition", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@edition"].Value = drpedi;

                //objOraclecommand.Parameters.Add("@suppliment", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@suppliment"].Value = drpsupp;
                OracleParameter prm4 = new OracleParameter("colorrate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpcolrate;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("colname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpcolname;
                objOraclecommand.Parameters.Add(prm5);


             

                OracleParameter prm7 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = Convert.ToDateTime(fromdate).ToString("dd/MMMM/yyyy");
                }

                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("tilldate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (tilldate == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = Convert.ToDateTime(tilldate).ToString("dd/MMMM/yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("colorcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = colorcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pecent", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = crgover;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ad_type", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adtype;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("rategpcode", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = rategpcode;
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

        //Execute Value  string drpedi, string drpsupp,
        public DataSet CR_Execute(string crgcode, string crgname, string drppub,string drpedi, string drpsupp, string drpcolrate, string drpcolname, string crgover, string compcode, string fromdate, string tilldate, string colorcode,string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_Execute.CR_Execute_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                //objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value = userid;
                OracleParameter prm1 = new OracleParameter("crgcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
               if (crgcode=="0")
              {
                  prm1.Value = System.DBNull.Value;
               }
                else
              {
                prm1.Value = crgcode;
              }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("crgname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = crgname;
                objOraclecommand.Parameters.Add(prm2);



                //objOraclecommand.Parameters.Add("@publication", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@publication"].Value = drppub;

                //objOraclecommand.Parameters.Add("@edition", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@edition"].Value = drpedi;

                //objOraclecommand.Parameters.Add("@suppliment", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@suppliment"].Value = drpsupp;

                OracleParameter prm3 = new OracleParameter("colorrate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (drpcolrate=="0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                prm3.Value = drpcolrate;
                }
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("colname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (drpcolname=="0")
                {
                prm4.Value = System .DBNull .Value ;
                }
                else
                {

                    prm4.Value = drpcolname;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pecent", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = crgover;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = Convert.ToDateTime(fromdate).ToString("dd/MMMM/yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("tilldate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (tilldate == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = Convert.ToDateTime(tilldate).ToString("dd/MMMM/yyyy");
                }
               
                objOraclecommand.Parameters.Add(prm7);




                OracleParameter prm8 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = compcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("colorcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = colorcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (drppub=="0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = drppub;
                }
              
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm12 = new OracleParameter("ad_type", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = adtype;
                }

                objOraclecommand.Parameters.Add(prm12);




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
        //Delete The Value
        public DataSet CRDelete(string colorcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("CR_Delete.CR_Delete_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("colorcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = colorcode;
                objOraclecommand.Parameters.Add(prm1);

               
                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
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


        //public DataSet packdes(string compcode, string pack_des)
        //{

        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("CR_BindPackdescr", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);


        //        OracleParameter prm2 = new OracleParameter("packdes", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = pack_des;
        //        objOraclecommand.Parameters.Add(prm2);



        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }

        //}




    }
}
