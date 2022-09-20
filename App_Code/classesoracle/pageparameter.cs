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
    /// Summary description for pageparameter
    /// </summary>
    public class pageparameter:orclconnection
    {
        public pageparameter()
        {
            //
            // TODO: Add constructor logic here
            //
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
                objOraclecommand = GetCommand("adduom.adduom_p", ref objOracleConnection);
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

        public DataSet checkpage(string pagecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpagecode.checkpagecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pagecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pagecode;
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

        public DataSet savepageparam(string drpadvtype, string txtpagecode, string drpedition, string drocolor, string txtpageno, string txtadvsize, string txtcolno, string drpuom, string txtremarks, string compcode, string userid, string drpadvcategory, string pub)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertpageparam.insertpageparam_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("txtpagecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = txtpagecode;
                objOraclecommand.Parameters.Add(prm1);
        

                OracleParameter prm2= new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4= new OracleParameter("pub", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pub;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5= new OracleParameter("drpadvtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadvtype;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("drpedition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpedition;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7= new OracleParameter("drocolor", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drocolor;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("txtpageno", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtpageno;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9= new OracleParameter("txtadvsize", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtadvsize;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("txtcolno", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtcolno;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("drpuom", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = drpuom;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("txtremarks", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = txtremarks;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("drpadvcategory", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = drpadvcategory;
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

        public DataSet executepagepara(string drpadvtype, string txtpagecode, string drpedition, string drpadvcategory, string drocolor, string txtpageno, string txtadvsize, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executepagepara.executepagepara_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("txtpagecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = txtpagecode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm5 = new OracleParameter("drpadvtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (drpadvtype == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = drpadvtype;
                }
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("drpedition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (drpedition == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = drpedition;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drocolor", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (drocolor == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = drocolor;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("txtpageno", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtpageno;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("txtadvsize", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtadvsize;
                objOraclecommand.Parameters.Add(prm9);




                OracleParameter prm13 = new OracleParameter("drpadvcategory", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (drpadvcategory == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = drpadvcategory;
                }
                objOraclecommand.Parameters.Add(prm13);

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
        public DataSet pagefirst()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstpageparam.firstpageparam_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


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

        public DataSet updatepageparam(string drpadvtype, string txtpagecode, string drpedition, string drocolor, string txtpageno, string txtadvsize, string txtcolno, string drpuom, string txtremarks, string compcode, string userid, string drpadvcategory, string pub)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatepageparam.updatepageparam_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("txtpagecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = txtpagecode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm5 = new OracleParameter("drpadvtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadvtype;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm4 = new OracleParameter("pub", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pub;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("drpedition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpedition;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drocolor", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drocolor;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("txtpageno", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtpageno;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("txtadvsize", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtadvsize;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("txtcolno", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtcolno;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("drpuom", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = drpuom;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("txtremarks", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = txtremarks;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("drpadvcategory", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = drpadvcategory;
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

        public DataSet deletepageparam(string pagecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletepageparam.deletepageparam_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pagecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pagecode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
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

        public DataSet chkpagecode()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpagecodename.chkpagecodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


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

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
    }
}