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
    /// Summary description for adsubcat3
    /// </summary>
    public class adsubcat3 : orclconnection
    {
        public adsubcat3()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getCat1(string cat1, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getCat1.getCat1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cat2", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cat1;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar, 50);
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
        public DataSet addcategory3name(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adsubcat.adsubcat_p", ref objOracleConnection);
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
        public DataSet savecat3(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string xml, string priority, string statusai, string ppubcenter, string sapcode, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cat3save.cat3save_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = catname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = catcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("catalias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = catalias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("xml", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = xml;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("prior1", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = priority;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter rm10 = new OracleParameter("status1", OracleType.VarChar, 50);
                rm10.Direction = ParameterDirection.Input;
                rm10.Value = statusai;
                objOraclecommand.Parameters.Add(rm10);

                OracleParameter rm11 = new OracleParameter("ppubcenter", OracleType.VarChar, 50);
                rm11.Direction = ParameterDirection.Input;
                rm11.Value = ppubcenter;
                objOraclecommand.Parameters.Add(rm11);

                OracleParameter rm12 = new OracleParameter("sapcode", OracleType.VarChar, 50);
                rm12.Direction = ParameterDirection.Input;
                rm12.Value = sapcode;
                objOraclecommand.Parameters.Add(rm12);

                OracleParameter rm13 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                rm13.Direction = ParameterDirection.Input;
                rm13.Value = statecode;
                objOraclecommand.Parameters.Add(rm13);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet catmodify(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string xml, string ppubcenter, string priority, string statusai, string sapcode, string st)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cat3_modify.cat3_modify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = catname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = catcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("catalias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = catalias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("xml", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = xml;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("prior1", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = priority;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter m7 = new OracleParameter("status1", OracleType.VarChar, 50);
                m7.Direction = ParameterDirection.Input;
                m7.Value = statusai;
                objOraclecommand.Parameters.Add(m7);


                OracleParameter m8 = new OracleParameter("ppubcenter", OracleType.VarChar, 50);
                m8.Direction = ParameterDirection.Input;
                m8.Value = ppubcenter;
                objOraclecommand.Parameters.Add(m8);

                OracleParameter m9 = new OracleParameter("psapcode", OracleType.VarChar, 50);
                m9.Direction = ParameterDirection.Input;
                m9.Value = sapcode;
                objOraclecommand.Parameters.Add(m9);
                OracleParameter m10 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                m10.Direction = ParameterDirection.Input;
                m10.Value = st;
                objOraclecommand.Parameters.Add(m10);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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
        //public DataSet catfpnl()
        //{
        //    MySqlConnection objOracleConnection;
        //    MySqlCommand objOraclecommand;
        //    objOracleConnection = GetConnection();
        //    MySqlDataAdapter objorclDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objOracleConnection.Open();
        //       objOraclecommand = GetCommand("CATFPNL", ref objOracleConnection);
        //       objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        objorclDataAdapter.SelectCommand =objOraclecommand;
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
        public DataSet catdelete(string compcode, string catcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CAT_DELETE.CAT_DELETE_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = catcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
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
        public DataSet catdauto(string str, string subcatname, string compcode, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Cat_Auto_new", ref objOracleConnection);
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
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }

                OracleParameter prm3 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = statecode;
                objOraclecommand.Parameters.Add(prm5);

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


        public DataSet chkcatcod(string catcode, string subcatname, string compcode, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CATCHK.CATCHK_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = catcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = catcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statecode;
                objOraclecommand.Parameters.Add(prm4);



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


        public DataSet catexecute1(string compcode, string subcatname, string catname, string catcode, string catalias, string xml, string ppubcenter, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CAT_EXE1.CAT_EXE1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (subcatname == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = subcatname;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = catcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("catalias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = catalias;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("xml", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = xml;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ppubcenter", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ppubcenter;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = statecode;
                objOraclecommand.Parameters.Add(prm8);


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
        public DataSet catnamechk(string str, string subcatname, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cat_namechk.cat_namechk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


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
        public DataSet pub_centbind(string compcode, string useid, string chk_acc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("pubcent_proc.pubcent_proc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = useid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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