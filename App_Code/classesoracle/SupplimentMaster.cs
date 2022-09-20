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
    /// Summary description for SupplimentMaster
    /// </summary>
    public class SupplimentMaster:orclconnection
    {
        public SupplimentMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet Pub(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubName.Bind_PubEdName_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
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

        public DataSet supptyp(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_supptyp.Bind_supptyp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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




        public DataSet SubPub()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_SubPubName.Bind_SubPubName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


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

        public DataSet cityName()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_CityEditor.Bind_CityEditor_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet ModifyValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity, string supptyp, string gut, string col, string hr, string min, string pro, string SHORTNAME,string epaper)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_Supplementmodify.websp_Supplementmodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PubName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PubName;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("EditionName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = EditonName;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("SuppName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = SuppName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Alias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("SuppCode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = SuppCode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = uom;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("column1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = column;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("height1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = height;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("width1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = width;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("area1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = area;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("periodicity", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = periodicity;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("supptypcode", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = supptyp;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("gut", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = gut;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("col", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = col;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("hr", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = hr;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("min1", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = min;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pro", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pro;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm21 = new OracleParameter("short_name", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = SHORTNAME;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pepaer", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = epaper;
                objOraclecommand.Parameters.Add(prm22);





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

        public DataSet InsertValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity, string supptyp, string gut, string col, string hr, string min, string pro, string SHORTNAME,string epaper)
         {

             OracleConnection objOracleConnection;
             OracleCommand objOraclecommand;
             DataSet objDataSet = new DataSet();
             objOracleConnection = GetConnection();
             OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
             try
             {
                 objOracleConnection.Open();
                 objOraclecommand = GetCommand("websp_Supplementinsert.websp_Supplementinsert_p", ref objOracleConnection);
                 objOraclecommand.CommandType = CommandType.StoredProcedure;


                 OracleParameter prm3 = new OracleParameter("PubName", OracleType.VarChar, 50);
                 prm3.Direction = ParameterDirection.Input;
                 prm3.Value = PubName;
                 objOraclecommand.Parameters.Add(prm3);

                 OracleParameter prm4 = new OracleParameter("EditionName", OracleType.VarChar, 50);
                 prm4.Direction = ParameterDirection.Input;
                 prm4.Value = EditonName;
                 objOraclecommand.Parameters.Add(prm4);

                 OracleParameter prm5 = new OracleParameter("SuppCode", OracleType.VarChar, 50);
                 prm5.Direction = ParameterDirection.Input;
                 prm5.Value = SuppCode;
                 objOraclecommand.Parameters.Add(prm5);

                 OracleParameter prm7 = new OracleParameter("SuppName", OracleType.VarChar, 50);
                 prm7.Direction = ParameterDirection.Input;
                 prm7.Value = SuppName;
                 objOraclecommand.Parameters.Add(prm7);

                 OracleParameter prm6 = new OracleParameter("Alias", OracleType.VarChar, 50);
                 prm6.Direction = ParameterDirection.Input;
                 prm6.Value = Alias;
                 objOraclecommand.Parameters.Add(prm6);

                 OracleParameter prm20 = new OracleParameter("userid", OracleType.VarChar, 50);
                 prm20.Direction = ParameterDirection.Input;
                 prm20.Value = userid;
                 objOraclecommand.Parameters.Add(prm20);

                 OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                 prm1.Direction = ParameterDirection.Input;
                 prm1.Value = compcode;
                 objOraclecommand.Parameters.Add(prm1);



                 OracleParameter prm8 = new OracleParameter("uom", OracleType.VarChar, 50);
                 prm8.Direction = ParameterDirection.Input;
                 prm8.Value = uom;
                 objOraclecommand.Parameters.Add(prm8);

                 OracleParameter prm9 = new OracleParameter("column1", OracleType.VarChar, 50);
                 prm9.Direction = ParameterDirection.Input;
                 prm9.Value = column;
                 objOraclecommand.Parameters.Add(prm9);

                 OracleParameter prm10 = new OracleParameter("height1", OracleType.VarChar, 50);
                 prm10.Direction = ParameterDirection.Input;
                 prm10.Value = height;
                 objOraclecommand.Parameters.Add(prm10);

                 OracleParameter prm11 = new OracleParameter("width1", OracleType.VarChar, 50);
                 prm11.Direction = ParameterDirection.Input;
                 prm11.Value = width;
                 objOraclecommand.Parameters.Add(prm11);

                 OracleParameter prm12 = new OracleParameter("area1", OracleType.VarChar, 50);
                 prm12.Direction = ParameterDirection.Input;
                 prm12.Value = area;
                 objOraclecommand.Parameters.Add(prm12);

                 OracleParameter prm13 = new OracleParameter("periodicity", OracleType.VarChar, 50);
                 prm13.Direction = ParameterDirection.Input;
                 prm13.Value = periodicity;
                 objOraclecommand.Parameters.Add(prm13);

                 OracleParameter prm14 = new OracleParameter("supptypcode", OracleType.VarChar, 50);
                 prm14.Direction = ParameterDirection.Input;
                 prm14.Value = supptyp;
                 objOraclecommand.Parameters.Add(prm14);

                 OracleParameter prm15 = new OracleParameter("gut", OracleType.VarChar, 50);
                 prm15.Direction = ParameterDirection.Input;
                 prm15.Value = gut;
                 objOraclecommand.Parameters.Add(prm15);

                 OracleParameter prm16 = new OracleParameter("col", OracleType.VarChar, 50);
                 prm16.Direction = ParameterDirection.Input;
                 prm16.Value = col;
                 objOraclecommand.Parameters.Add(prm16);

                 OracleParameter prm17 = new OracleParameter("hr", OracleType.VarChar, 50);
                 prm17.Direction = ParameterDirection.Input;
                 prm17.Value = hr;
                 objOraclecommand.Parameters.Add(prm17);

                 OracleParameter prm18 = new OracleParameter("min1", OracleType.VarChar, 50);
                 prm18.Direction = ParameterDirection.Input;
                 prm18.Value = min;
                 objOraclecommand.Parameters.Add(prm18);

                 OracleParameter prm19 = new OracleParameter("prod", OracleType.VarChar, 50);
                 prm19.Direction = ParameterDirection.Input;
                 prm19.Value = pro;
                 objOraclecommand.Parameters.Add(prm19);

                 OracleParameter prm21 = new OracleParameter("short_name", OracleType.VarChar, 50);
                 prm21.Direction = ParameterDirection.Input;
                 prm21.Value = SHORTNAME;
                 objOraclecommand.Parameters.Add(prm21);

                 OracleParameter prm22 = new OracleParameter("pepaer", OracleType.VarChar, 50);
                 prm22.Direction = ParameterDirection.Input;
                 prm22.Value = epaper;
                 objOraclecommand.Parameters.Add(prm22);



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

       
   



        public DataSet getRO(string PubName, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getRO.getRO_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PubName", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = PubName;
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







        public DataSet SelectValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity, string supptyp, string gut, string col, string hr, string min, string pro, string SHORTNAME)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_SupplementSelect.websp_SupplementSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PubName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (PubName == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = PubName;
                }

                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("EditonName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (EditonName == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = EditonName;
                }

                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("SuppName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = SuppName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Alias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("SuppCode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = SuppCode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (uom == "0")
                {
                    prm8.Value = System.DBNull.Value;

                }
                else
                {
                    prm8.Value = uom;
                }

                objOraclecommand.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("column1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = column;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("height1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = height;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("width1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = width;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("area1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = area;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("periodicity", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (periodicity == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = periodicity;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("supptypcode", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (supptyp == "0")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = supptyp;
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("gut", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = gut;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("col", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = col;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("hr", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = hr;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("min1", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = min;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pro", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pro;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm21 = new OracleParameter("short_name", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = SHORTNAME;
                objOraclecommand.Parameters.Add(prm21);





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

        public DataSet Selectfnpl(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string SHORTNAME)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_supplementfnpl.websp_supplementfnpl_p", ref objOracleConnection);
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

        public DataSet checksupcode(string compcode, string suppcode, string userid, string pubcode, string editioncode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checksupplementcode.checksupplementcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = suppcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

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

        public DataSet selecteditiondaymodify(string compcode, string suppcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("supplementdaymodify.supplementdaymodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = suppcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("mon", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5= new OracleParameter("tue", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6= new OracleParameter("wed", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("allday", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = all;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);
             
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

        public DataSet editiondaysave(string compcode, string suppcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("supplementdaysave.supplementdaysave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = suppcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("allday", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = all;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

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



        public DataSet chksupcode(string SuppName,string SuppCode,string Alias, string compcode, string userid, string pubname, string editionname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chksupcode.chksupcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("SuppCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = SuppCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editionname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editionname;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("suppname", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = SuppName;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("Alias1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Alias;
                objOraclecommand.Parameters.Add(prm7);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;

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

        public DataSet supdel(string SuppCode, string compcode, string userid, string pubcode, string editioncode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("supplimentdel.supplimentdel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("SuppCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = SuppCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
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


        public DataSet chkcsupcode1(string str, string editstr, string pubeditstr)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chksuppcode.chksuppcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0,2);
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }
                OracleParameter prm3 = new OracleParameter("editstr", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editstr;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4= new OracleParameter("pubeditstr", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubeditstr;
                objOraclecommand.Parameters.Add(prm4);


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


        public DataSet countedition(string editioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("filledition1.filledition1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);

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


        public DataSet chkedition(string pubcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpublicationcode.checkpublicationcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm4 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

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


        public DataSet countcity(string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcity1.fillcity1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = edition;
                objOraclecommand.Parameters.Add(prm1);

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


        public DataSet addedition(string pubname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fill_editionalias.fill_editionalias_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubname;
                objOraclecommand.Parameters.Add(prm1);

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


        public DataSet findedition(string editname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fill_supplalias.fill_supplalias_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editname;
                objOraclecommand.Parameters.Add(prm1);

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

        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertsuppdate.insertsuppdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (txtdate == "" || txtdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(txtdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (txtaddate == "" || txtaddate == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtaddate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtaddate = mm + "/" + dd + "/" + yy;
                    }
                    prm5.Value = Convert.ToDateTime(txtaddate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);
           

                OracleParameter prm6= new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
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

        public DataSet selectedfromgrid(string suppcode, string compcode, string userid, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectfromsuppdate.selectfromsuppdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = suppcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
                objOraclecommand.Parameters.Add(prm4);

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

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatesuppdate.updatesuppdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToDateTime(txtdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(txtaddate).ToString("dd-MMMM-yyyy"); 
                objOraclecommand.Parameters.Add(prm5);

                /*
                objOraclecommand.Parameters.Add("txtaddate", SqlDbType.DateTime);


                if (txtaddate == "" || txtaddate == null || txtaddate == "undefined/undefined/")
                {
                    objOraclecommand.Parameters["txtaddate"].Value = System.DBNull.Value;
                }
                else
                {
                    objOraclecommand.Parameters["txtaddate"].Value = Convert.ToDateTime(txtaddate);
                }
                */

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = code10;
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

        public DataSet griddelete(string suppcode, string compcode, string userid, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletegridsuppdate.deletegridsuppdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = suppcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
                objOraclecommand.Parameters.Add(prm4);


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
        public DataSet chkdaetedit(string compcode, string suppcode, string fdate, string sdate)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdatesupp.chkdatesupp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = suppcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("sdate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(sdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);


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

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdatesuppupdate.chkdatesuppupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToDateTime(txtdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(txtaddate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = code10;
                objOraclecommand.Parameters.Add(prm7);


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

        public DataSet ratebind(string code, string compcode, string userid, string date)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindsuppdate.bindsuppdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value =date;
                objOraclecommand.Parameters.Add(prm4);

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


        public DataSet filleditalias(string suppcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillsuppalias.fillsuppalias_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = suppcode;
                objOraclecommand.Parameters.Add(prm3);

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

        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty(string periodicty)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkperiodictyforsupp.chkperiodictyforsupp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("periodicty", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = periodicty;
                objOraclecommand.Parameters.Add(prm1);

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

        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty_edition(string supplement)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkperiodictysupplement.chkperiodictysupplement_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("supplement", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = supplement;
                objOraclecommand.Parameters.Add(prm1);

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

    }
}