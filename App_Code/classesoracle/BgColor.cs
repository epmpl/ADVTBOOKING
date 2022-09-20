using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for BgColor
    /// </summary>
    public class BgColor :orclconnection
    {
        public BgColor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bgSave(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string coltype, string comcode, string bgtype, string bgamt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bg_Save.Bg_Save_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm1 = new OracleParameter("bgid", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgid;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("bgname", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = bgname;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("bgalias", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = bgalias;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm7 = new OracleParameter("pub1", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = pub;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm4 = new OracleParameter("edit", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = edit;
               objOraclecommand.Parameters.Add(prm4);


               OracleParameter prm5 = new OracleParameter("cat1", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = cat;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("coltype", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = coltype;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm11 = new OracleParameter("cat2", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
               prm11.Value = cat2;
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm8 = new OracleParameter("cat3", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = cat3;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("cat4", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = cat4;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm10 = new OracleParameter("cat5", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = cat5;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm12 = new OracleParameter("comcode", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value = comcode;
               objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("bgtype", OracleType.VarChar, 50);
               prm13.Direction = ParameterDirection.Input;
               prm13.Value = bgtype;
               objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("bgamt", OracleType.VarChar, 50);
               prm14.Direction = ParameterDirection.Input;
               prm14.Value = bgamt;
               objOraclecommand.Parameters.Add(prm14);


               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet chkbgid(string bgid, string pub, string edit, string cat, string colortype, string bgname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BGCHK.BGCHK_P", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("bgid", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgid;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("pub1", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = pub;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("edit1", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = edit;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm4 = new OracleParameter("cat1", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = cat;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("coltyp", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = colortype;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("bgname", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = bgname;
               objOraclecommand.Parameters.Add(prm6);


               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

               objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet bgmodify(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string colortype, string compcode,string bgtype,string bgamt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bg_Modify.Bg_Modify_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("bgid", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgid;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("bgname", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = bgname;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("bgalias", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = bgalias;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm4 = new OracleParameter("pub1", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = pub;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("edit1", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = edit;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("cat1", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = cat;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("coltype", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = colortype;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm8 = new OracleParameter("cat2", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = cat2;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("cat3", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = cat3;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm10 = new OracleParameter("cat4", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = cat4;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm11 = new OracleParameter("cat5", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
               prm11.Value = cat5;
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm12 = new OracleParameter("comcode", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value = compcode;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm13 = new OracleParameter("bgamt", OracleType.VarChar, 50);
               prm13.Direction = ParameterDirection.Input;
               prm13.Value = bgamt;
               objOraclecommand.Parameters.Add(prm13);

               OracleParameter prm14 = new OracleParameter("bgtype", OracleType.VarChar, 50);
               prm14.Direction = ParameterDirection.Input;
               prm14.Value = bgtype;
               objOraclecommand.Parameters.Add(prm14);


               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet bgexecute1(string bgid, string bgname, string bgalias, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BG_EXE.BG_EXE_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("vbgid", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgid;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("vbgname", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = bgname;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("vbgalias", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = bgalias;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

              
               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet bgfpnl()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BGFPNL.BGFPNL_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;
               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet bgdelete(string bgid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BG_DELETE.BG_DELETE_P", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("bgid", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgid;
               objOraclecommand.Parameters.Add(prm1);


             

              


               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet bgdauto(string str, string pub, string edit, string cat, string coltype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BG_AUTO.BG_AUTO_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if(str.Length >2)
                {
                prm2.Value = str.Substring (0,2);
                }
                else

                {
                    prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pub1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pub;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("edit", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edit;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("cat1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("coltype", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = coltype;
                objOraclecommand.Parameters.Add(prm6);


               
                


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

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

        public DataSet bgexecute2(string bgid, string bgname, string bgalias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BG_EXE1.BG_EXE1_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm1 = new OracleParameter("vbgid", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgid;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm2 = new OracleParameter("vbgname", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = bgname;
               objOraclecommand.Parameters.Add(prm2);


               OracleParameter prm3 = new OracleParameter("vbgalias", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = bgalias;
               objOraclecommand.Parameters.Add(prm3);




               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

             

               objmysqlDataAdapter.SelectCommand = objOraclecommand;
               objmysqlDataAdapter.Fill(objDataSet);
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



        public DataSet bindcolortyp(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcolortype.bindcolortype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

               

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                da.SelectCommand = objOraclecommand;
                da.Fill(ds);
                return ds;
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

//-------------------for cat2----------------------------------------

        public DataSet addcategoryname2(string adcat, string comp_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advsubcategory.advsubcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adcategory", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adcat;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comp_code;
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

        public DataSet addcategoryname3(string adsubcategory)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advsubsubcategory.advsubsubcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adsubcategory", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adsubcategory;
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
// -----------for adcategory4--------------

        public DataSet bindscategory4(string adscat4, string value, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Rate_bindadcat4.Rate_bindadcat4_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adscat4", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adscat4;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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
        public DataSet bindscategory5(string adscat5, string value, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Rate_bindadcat4.Rate_bindadcat4_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adscat4", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adscat5;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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

    }
}
