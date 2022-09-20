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
    /// Summary description for adons
    /// </summary>
    public class adons : orclconnection
    {
        public adons()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindadon(string compcode, string ratecode, string pkgcode, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindadongrid.bindadongrid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);


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


        public DataSet getpkgname(string compcode, string pkgcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getpkgname.getpkgname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pkgcode;
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



        public DataSet insertadon(string publication, string edition, string supp, string rate, string compcode, string userid, string pkgcode, string pkgdesc, string pkgname, string ratecode, string rateuniqueid, string type,string extrarate,string noofinsert)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adoninsert.adoninsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("publication", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = publication;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("supp", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = supp;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("rate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDecimal(rate);
                objOraclecommand.Parameters.Add(prm5);

                /*objOraclecommand.Parameters.Add("@rate", SqlDbType.Decimal);
                objOraclecommand.Parameters["@rate"].Value = Convert.ToDecimal(rate);*/

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pkgdesc", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pkgdesc;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pkgname", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pkgname;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ratecode11", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ratecode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("extrarate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = extrarate;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (noofinsert == "")
                    noofinsert = "0";
                prm24.Value = noofinsert;
                objOraclecommand.Parameters.Add(prm24);

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


        public DataSet getdataup(string compcode, string ratecode, string code11,string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getadondata.getadondata_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm11 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ratecode;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm10 = new OracleParameter("code11", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = code11;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

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




        public DataSet updateadon(string publication, string edition, string supp, string rate, string compcode, string code, string ratecode, string rateid, string type,string extrarate,string noofinsert)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adonupdate.adonupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("publication", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = publication;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("rateid1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("supp", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = supp;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("rate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = rate;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = code;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm11 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ratecode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("extrarate1", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = extrarate;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = noofinsert;
                objOraclecommand.Parameters.Add(prm24);


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





        public DataSet deladon(string compcode, string code, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adondelete.adondelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = code;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
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


        public DataSet chkdupins(string ratecode, string pub, string edit, string supp, string compcode, string flag,string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdupinaddon.chkdupinaddon_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pub1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pub;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("edit", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm11 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ratecode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm4 = new OracleParameter("supp", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = supp;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm8 = new OracleParameter("flag", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = flag;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

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