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
    /// Summary description for adsubcat
    /// </summary>
    public class adsubcat : orclconnection
    {
        public adsubcat()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet addcategoryname(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcat.adcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("company_code", OracleType.VarChar, 50);
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


        public DataSet getcode(string catname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcatcode.fillcatcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = catname;
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






        public DataSet savesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string imagename, string txtxml, string pri, string status1, string sapcode, string statecode, string eddiscflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatsave.subcatsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("catcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = catcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("subcatcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("subcatname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subcatname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("subcatalias", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = subcatalias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = userid;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("imagename", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = imagename;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("subcatxml", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtxml;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pri", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pri;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("status1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = status1;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("sapcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = sapcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pstatecode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (statecode == "0")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = statecode;

                }
                //prm12.Value = statecode;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("sun", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("mon", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value =  System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("tue", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("wed", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("thu", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("fri", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("sat", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pubcode", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pedition_discount", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = eddiscflag;
                objOraclecommand.Parameters.Add(prm21);

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







        public DataSet exesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Subcatexe.subcatexe_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (catcode == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = catcode;
                   
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("subcatcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subcatname;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("subcatalias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = subcatalias;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = userid;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (statecode == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = statecode;

                }
                //prm7.Value = statecode;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm20 = new OracleParameter("pubcode", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pexecutive", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm21);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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












        public DataSet updatesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string imagename, string txtxml, string pri, string status1, string sapcode, string statecode, string eddiscflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatupdate.subcatupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = catcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("subcatcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = subcatcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm3 = new OracleParameter("subcatname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subcatname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("subcatalias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subcatalias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm8 = new OracleParameter("imagename", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = imagename;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm7 = new OracleParameter("subcatxml", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txtxml;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("pri", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pri;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("status1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = status1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("psapcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = sapcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pstatecode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = statecode;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("sun", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("mon", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("tue", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("wed", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("thu", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("fri", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("sat", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pubcode", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pexecutive", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pedition_discount", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = eddiscflag;
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




      public DataSet firstsubcat(string compcode, string catcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatfnpl.subcatfnpl_p", ref objOracleConnection);
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


      public DataSet chksubcat(string compcode, string subcatcode, string subcatname, string catcode,string userid,string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatchk.subcatchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("subcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = subcatcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                 OracleParameter prm5= new OracleParameter("psubcatname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = subcatname;
                objOraclecommand.Parameters.Add(prm5);

                 OracleParameter prm6= new OracleParameter("pcatcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = catcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm4 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (statecode == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = statecode;

                }
                //prm4.Value = statecode;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;
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







        public DataSet presubcat(string compcode, string catcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatfnpl.subcatfnpl_p", ref objOracleConnection);
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



        public DataSet nextsubcat(string compcode, string catcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatfnpl.subcatfnpl_p", ref objOracleConnection);
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





        public DataSet lastsubcat(string compcode, string catcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatfnpl.subcatfnpl_p", ref objOracleConnection);
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



        public DataSet delsubcat(string compcode, string catcode, string userid, string subcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("subcatdel.subcatdel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("subcatcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subcatcode;
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



        public DataSet chksubcatcode1(string str, string catcode, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkadsubcatname_new", ref objOracleConnection);
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
                OracleParameter prm3 = new OracleParameter("catcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statecode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS1"].Direction = ParameterDirection.Output;

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