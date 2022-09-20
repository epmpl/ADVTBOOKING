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
    /// Summary description for premiummaster
    /// </summary>
    public class premiummaster : orclconnection
    {
        public premiummaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet rategrpbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand= GetCommand("rategroupbind.rategroupbind_p", ref objOracleConnection);
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

        public DataSet pactypbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("packagetypebind.packagetypebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                

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
        public DataSet combinbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("packagetypebind.packagetypebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2= new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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

        public DataSet packagebind(string comb, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpkgname.bindpkgname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comb", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comb;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet checkprem(string txtpremiumcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpremmast.checkpremmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtpremiumcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtpremiumcode;
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet insertpremmast(string drpcombin, string drpadvtype, string drpcategory, string txtpremiumcode, string drpprerate, string txtrate, string drppremiumtype, string txtremarks, string validatedate, string validatetill, string compcode, string userid, string drppackagename, string drprategroup)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertpremmast.insertpremmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("drprategroup", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = drprategroup;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpcombin", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpcombin;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadvtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadvtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpcategory", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("txtpremiumcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txtpremiumcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpprerate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpprerate;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("txtrate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtrate;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("drppremiumtype", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = drppremiumtype;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("txtremarks", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txtremarks;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("validatedate", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = Convert.ToDateTime(validatedate);
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("validatetill", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = validatetill;
                objOraclecommand.Parameters.Add(prm13);

                /*

                objOraclecommand.Parameters.Add("@validatetill", SqlDbType.DateTime);

                if (validatetill != null && validatetill != "")
                {
                    objOraclecommand.Parameters["@validatetill"].Value = Convert.ToDateTime(validatetill);
                }
                else
                {
                    objOraclecommand.Parameters["@validatetill"].Value = System.DBNull.Value;
                }*/


                OracleParameter prm14 = new OracleParameter("drppackagename", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = drppackagename;
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
        public DataSet bindpretyp(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("premiumtypbind.premiumtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
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



        public DataSet executeprmma(string drpadvtype, string drpcategory, string txtpremiumcode, string drpprerate, string validatedate, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executepremmast.executepremmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);







                OracleParameter prm3 = new OracleParameter("drpadvtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (drpadvtype=="0")
                {
                    prm3.Value =System .DBNull .Value;
                }
                else
                {
                prm3.Value = drpadvtype;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("drpcategory", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (drpcategory == "0")
                {
                    prm4.Value = System.DBNull.Value;


                }
                else
                {
                    prm4.Value = drpcategory;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("txtpremiumcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtpremiumcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("drpprerate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (drpprerate=="0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                prm6.Value = drpprerate;
                }
                objOraclecommand.Parameters.Add(prm6);



                
                










                //				objOraclecommand.Parameters.Add("@validatedate",SqlDbType.DateTime);
                //				objOraclecommand.Parameters["@validatedate"].Value=Convert.ToDateTime(validatedate);
                // 
                
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

        public DataSet premfirst()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstpremmast.firstpremmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                // 
                
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

        public DataSet updatepremmast(string drpcombin, string drpadvtype, string drpcategory, string txtpremiumcode, string drpprerate, string txtrate, string drppremiumtype, string txtremarks, string validatedate, string validatetill, string compcode, string userid, string drppackagename, string drprategroup)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatepremmast.updatepremmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("drprategroup", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = drprategroup;
                objOraclecommand.Parameters.Add(prm1);
                

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);
                

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);
                

                OracleParameter prm4 = new OracleParameter("drpcombin", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpcombin;
                objOraclecommand.Parameters.Add(prm4);
                
                OracleParameter prm5 = new OracleParameter("drpadvtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadvtype;
                objOraclecommand.Parameters.Add(prm5);
                
                OracleParameter prm6 = new OracleParameter("drpcategory", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpcategory;
                objOraclecommand.Parameters.Add(prm6);
                
                OracleParameter prm7 = new OracleParameter("txtpremiumcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txtpremiumcode;
                objOraclecommand.Parameters.Add(prm7);
                
                OracleParameter prm8 = new OracleParameter("drpprerate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpprerate;
                objOraclecommand.Parameters.Add(prm8);
                
                OracleParameter prm9 = new OracleParameter("txtrate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtrate;
                objOraclecommand.Parameters.Add(prm9);
                
                OracleParameter prm10 = new OracleParameter("drppremiumtype", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = drppremiumtype;
                objOraclecommand.Parameters.Add(prm10);
                
                OracleParameter prm11 = new OracleParameter("txtremarks", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txtremarks;
                objOraclecommand.Parameters.Add(prm11);
                
                OracleParameter prm12 = new OracleParameter("validatedate", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = Convert.ToDateTime(validatedate);
                objOraclecommand.Parameters.Add(prm12);
                
                OracleParameter prm13 = new OracleParameter("validatetill", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = compcode;
                objOraclecommand.Parameters.Add(prm13);

                /*
                objOraclecommand.Parameters.Add("@validatetill", SqlDbType.DateTime);

                if (validatetill != null && validatetill != "")
                {
                    objOraclecommand.Parameters["@validatetill"].Value = Convert.ToDateTime(validatetill);
                }
                else
                {
                    objOraclecommand.Parameters["@validatetill"].Value = System.DBNull.Value;
                }
                */
                OracleParameter prm14 = new OracleParameter("drppackagename", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = drppackagename;
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

        public DataSet deletepremmast(string txtpremiumcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletepremmast.deletepremmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("txtpremiumcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtpremiumcode;
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
                CloseConnection(ref objOracleConnection);
            }
        }



    }
}
