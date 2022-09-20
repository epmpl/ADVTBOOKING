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
    public class CD_Upload : orclconnection
    {
        public CD_Upload()
        {
            
        }
        public DataSet upload_for_all(string bookingid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("add_cd_upload_for_all", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("bookind_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bookingid;
                objOracleCommand.Parameters.Add(prm1);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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
 
        public DataSet formpermission(string compcode, string userid, string formname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            //OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_show_permission", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("formname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.InputOutput;
                prm1.Value = formname;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOracleCommand.ExecuteNonQuery();

                DataTable dt1 = new DataTable();
                DataRow dr = dt1.NewRow();
                DataColumn d1 = new DataColumn("a1", System.Type.GetType("System.String"));

                dt1.Columns.Add(d1);
                dr[0] = prm1.Value;
                dt1.Rows.Add(dr);
                objDataSet.Tables.Add(dt1);
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
        } //end of formpermission

        public DataSet clsViewBooking_CD(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string pageno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_GetAdMaterial_CD", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (pageno == "")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = pageno;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_GetAgency", OracleType.Cursor);
                objOraclecommand.Parameters["p_GetAgency"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }
       
         public void clsInsertInfo(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string iidnum, string fname, string orig_filename, string dateformat, string username, string pad_type)
         {
             OracleConnection objOracleConnection;
             OracleCommand objOraclecommand;
             objOracleConnection = GetConnection();
             try
             {
                 objOracleConnection.Open();
                 objOraclecommand = GetCommand("websp_InsertAdInfo", ref objOracleConnection);
                 objOraclecommand.CommandType = CommandType.StoredProcedure;

                 OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                 prm1.Direction = ParameterDirection.Input;
                 if (pubdate == "" || pubdate == null)
                 {
                     prm1.Value = System.DBNull.Value;
                 }
                 else
                 {
                     if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = pubdate.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         pubdate = mm + "/" + dd + "/" + yy;
                     }
                     prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                 }
                 objOraclecommand.Parameters.Add(prm1);

                 OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                 prm2.Direction = ParameterDirection.Input;
                 prm2.Value = pubcode;
                 objOraclecommand.Parameters.Add(prm2);

                 OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                 prm3.Direction = ParameterDirection.Input;
                 prm3.Value = centercode;
                 objOraclecommand.Parameters.Add(prm3);

                 OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                 prm4.Direction = ParameterDirection.Input;
                 prm4.Value = editioncode;
                 objOraclecommand.Parameters.Add(prm4);

                 OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                 prm5.Direction = ParameterDirection.Input;
                 prm5.Value = suppcode;
                 objOraclecommand.Parameters.Add(prm5);

                 OracleParameter prm7 = new OracleParameter("iidnum", OracleType.VarChar, 50);
                 prm7.Direction = ParameterDirection.Input;
                 prm7.Value = iidnum;
                 objOraclecommand.Parameters.Add(prm7);

                 OracleParameter prm8 = new OracleParameter("fname", OracleType.VarChar, 50);
                 prm8.Direction = ParameterDirection.Input;
                 prm8.Value = fname;
                 objOraclecommand.Parameters.Add(prm8);

                 OracleParameter prm11 = new OracleParameter("pusername", OracleType.VarChar, 50);
                 prm11.Direction = ParameterDirection.Input;
                 prm11.Value = username;
                 objOraclecommand.Parameters.Add(prm11);

                 OracleParameter prm12 = new OracleParameter("porig_filename", OracleType.VarChar, 50);
                 prm12.Direction = ParameterDirection.Input;
                 prm12.Value = orig_filename;
                 objOraclecommand.Parameters.Add(prm12);

                 OracleParameter prm13 = new OracleParameter("p_adtype", OracleType.VarChar, 50);
                 prm13.Direction = ParameterDirection.Input;
                 prm13.Value = pad_type;
                 objOraclecommand.Parameters.Add(prm13);

                 objOraclecommand.ExecuteNonQuery();
             }
             catch (Exception objException)
             {
                 throw (objException);
             }
             finally
             {
                 objOracleConnection.Close();
             }
         }
//**********************************************************************************************************

        public DataSet clsBindCenters()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_bindftpcenters", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet clsgetClientname(string compcode, string pubdate, string iidnum, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_GetClient.websp_GetClient_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;

                    }
                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("iidnum", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = iidnum;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet editioncodes(string centercode, string userid, string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_addeditions", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = centercode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        public DataSet secpubcodes(string compcode, string userid, string editioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_Addsecpubs", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editioncode;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_secpub", OracleType.Cursor);
                objOracleCommand.Parameters["p_secpub"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        //Get Publication Code from preference
        public DataSet Pripubcode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();

            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addpubcode1.Websp_addpubcode1_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        //Get center Code from preference
        public DataSet centercode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addcenter_p.Websp_addcenter", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("p_center", OracleType.Cursor);
                objOracleCommand.Parameters["p_center"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        //Get edition Code from preference
        public DataSet editioncode(string compcode, string userid)/*, string pubcode)*/
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_addedition.websp_addedition_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                //OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = pubcode;
                //objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        //Get supp Code from preference
        public DataSet secpubcode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addsecpub_p.Websp_addsecpub", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);


                //OracleParameter prm3 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = editioncode;
                //objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_secpub", OracleType.Cursor);
                objOracleCommand.Parameters["p_secpub"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        //**************************
        //UpdateFilename in tbl_booking insert
        public DataSet UpdateFilename_CD(string compcode, string fname, string idnum, string insnum, string insertid, string editioncode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_updatefilename_CD", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("fname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = fname;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("idnum", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = idnum;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("insnum", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = insnum;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("insertid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = insertid;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("peditioncode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editioncode;
                objOracleCommand.Parameters.Add(prm6);

                // objOracleCommand.ExecuteNonQuery();
                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);
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
        //*******************************************

        public void clsInsertInfo(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string iidnum, string fname, string orig_filename, string dateformat, string username, string pad_type, string optionalstr)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_InsertAdInfo", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("iidnum", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = iidnum;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fname", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fname;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm11 = new OracleParameter("pusername", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = username;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("porig_filename", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = orig_filename;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("p_adtype", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pad_type;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("usercentercode", OracleType.VarChar, 100);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = optionalstr;
                objOraclecommand.Parameters.Add(prm14);
                objOraclecommand.ExecuteNonQuery();
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }
    }
}
