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
    /// Summary description for Adsize
    /// </summary>
    public class Adsize : orclconnection
    {
        public Adsize()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet colorbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adsizecolorbind.adsizecolorbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("company_code", OracleType.VarChar, 50);
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

        public DataSet editionbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("adsizeeditionbind.adsizeeditionbind_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpackage.bindpackage_p", ref objOracleConnection);
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


        public DataSet listboxbind(string compcode, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adsizeadvcategory.adsizeadvcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
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

        public DataSet typebind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adtype.adtype_p", ref objOracleConnection);
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


        public DataSet inserttinadsize(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string uom, string remarks, string width1, string width2, string height1, string height2, string compcode, string userid,string column)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintoadsize.insertintoadsize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("badcategory", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = badcategory;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = advsizecode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("description", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = description;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = color;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = uom;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = remarks;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("width1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = width1;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("width2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = width2;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("height1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = height1;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("height2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = height2;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm141 = new OracleParameter("column_p", OracleType.VarChar, 50);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = column;
                objOraclecommand.Parameters.Add(prm141);

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

        public DataSet checkcode(string description,string advsizecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chechcodesize.chechcodesize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advsizecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("description", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = description;
                objOraclecommand.Parameters.Add(prm4);

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

        public DataSet exceutesearch(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("searchexecutesize.searchexecutesize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                //OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = userid;
                //objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advsizecode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (advtype == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = advtype;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("badcategory", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (badcategory == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = badcategory;
                }
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (badcategory == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = badcategory;
                }
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("description", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = description;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (color == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = color;
                }
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

        public DataSet updatesize(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string uom, string remarks, string width1, string width2, string height1, string height2, string compcode, string userid,string column)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateintosize.updateintosize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                //OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = userid;
                //objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advtype;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("badcategory", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = badcategory;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = advsizecode;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("description", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = description;
                objOraclecommand.Parameters.Add(prm7);




                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = color;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = uom;
                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = remarks;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("width1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = width1;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("width2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = width2;
                objOraclecommand.Parameters.Add(prm12);



                OracleParameter prm13 = new OracleParameter("height1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = height1;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("height2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = height2;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm141 = new OracleParameter("column_p", OracleType.VarChar, 50);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = column;
                objOraclecommand.Parameters.Add(prm141);
                 




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

        public DataSet firstnext()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adsizefirstnext.adsizefirstnext_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


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

        public DataSet deletesizead(string advsizecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletesize.deletesize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advsizecode;
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


        public DataSet displaybind(string compcode, string userid, string advsizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("displaysizebind.displaysizebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advsizecode;
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


        public DataSet insertdisplay(string minheight, string maxheight, string minwidth, string maxwidth, string compcode, string userid, string sizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertdisplayin.insertdisplayin_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sizecode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("minheight", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = minheight;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("maxheight", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = maxheight;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("minwidth", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = minwidth;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("maxwidth", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = maxwidth;
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


        public DataSet selecteddisplay(string compcode, string userid, string sizecode, string codesize)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slecteddisplaygrid.slecteddisplaygrid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("codesize", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = codesize;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sizecode;
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

        public DataSet deletedisplay(string compcode, string userid, string sizecode, string codesize)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletedisplaygrid.deletedisplaygrid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("codesize", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = codesize;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sizecode;
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

        public DataSet updatedisplaygrid(string minheight, string maxheight, string minwidth, string maxwidth, string compcode, string userid, string sizecode, string codesize)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatedisplay.updatedisplay_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sizecode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4= new OracleParameter("minheight", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = minheight;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("maxheight", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = maxheight;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("minwidth", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = minwidth;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("maxwidth", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = maxwidth;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("codesize", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = codesize;
                objOraclecommand.Parameters.Add(prm8);




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


        public DataSet classifiedbind(string compcode, string userid, string advsizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("classifiedsizebind.classifiedsizebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("advsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advsizecode;
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

        //		public DataSet insertdisplay(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode)
        //		{
        //			SqlConnection objOracleConnection;
        //			SqlCommand objOracleConnection;
        //			objOracleConnection = GetConnection();
        //			SqlDataAdapter objorclDataAdapter = new SqlDataAdapter();
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objOracleConnection.Open();
        //				objOracleConnection = GetCommand("insertdisplayin", ref objOracleConnection);
        //				objOracleConnection.CommandType = CommandType.StoredProcedure;
        //
        //				objOracleConnection.Parameters.Add("@compcode", SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@compcode"].Value =compcode;
        //
        //				objOracleConnection.Parameters.Add("@userid",SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@userid"].Value=userid;
        // 
        //				objOracleConnection.Parameters.Add("@sizecode",SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@sizecode"].Value=sizecode;
        //
        //				objOracleConnection.Parameters.Add("@minheight",SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@minheight"].Value=minheight;
        //
        //				objOracleConnection.Parameters.Add("@maxheight",SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@maxheight"].Value=maxheight;
        //
        //				objOracleConnection.Parameters.Add("@minwidth",SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@minwidth"].Value=minwidth;
        //
        //				objOracleConnection.Parameters.Add("@maxwidth",SqlDbType.VarChar);
        //				objOracleConnection.Parameters["@maxwidth"].Value=maxwidth;
        // 
        //				
        //				objorclDataAdapter.SelectCommand = objOracleConnection;
        //				objorclDataAdapter.Fill(objDataSet);
        //
        //				return objDataSet;
        //
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objOracleConnection);
        //			}
        //		}


        public DataSet insertclassifiedinto(string fromline, string toline, string maxcharacter, string compcode, string userid, string sizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertclassified.insertclassified_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sizecode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("fromline", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fromline;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("toline", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = toline;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("maxcharacter", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = maxcharacter;
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

        public DataSet selectintoclassifiedinto(string compcode, string userid, string sizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectgridclassified.selectgridclassified_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sizecode;
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

        public DataSet updateclassified(string fromline, string toline, string maxcharacter, string compcode, string userid, string sizecode, string codeclassified)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateclassified.updateclassified_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("sizecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sizecode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("codeclassified", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = codeclassified;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("fromline", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromline;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("toline", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = toline;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("maxcharacter", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = maxcharacter;
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

        public DataSet deleteclassified(string compcode, string userid, string codeclassified)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletesizeclassified.deletesizeclassified_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("codeclassified", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = codeclassified;
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

        public DataSet listboxmultibind(string compcode, string userid, string adsizecode, string abc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertmultiadsize.insertmultiadsize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("abc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = abc;
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

        public DataSet checkmulti(string compcode, string userid, string adsizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkmultiselect.checkmultiselect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm3);
                

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

        public DataSet checkmultibullet(string compcode, string userid, string adsizecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkmultiselect.checkmultiselect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm3);
                 

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
        public DataSet listboxmultiupdate(string compcode, string userid, string adsizecode, string abc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatemultiadsize.updatemultiadsize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("abc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = abc;
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
    }
}
