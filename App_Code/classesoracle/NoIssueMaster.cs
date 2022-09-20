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
    /// Summary description for NoIssueMaster
    /// </summary>
    public class NoIssueMaster : orclconnection
    {
        public NoIssueMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet editionname(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionnamebind.editionnamebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


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

        public DataSet editionsuppname(string compcode, string userid, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionnamebind_supp", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pedition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);

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




        public DataSet getbind(string compcode, string userid, string issuecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindissue.bindissue_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
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

        public DataSet chkcode(string issuecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcode.chkcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


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

        public DataSet chkissue3(string issuecode, string noissuecode, string compcode, string date, string dateformat, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkissue3.chkissue3_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("noissuecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = noissuecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("noissuedate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
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


        public DataSet chkissue(string date, string day, string issuecode, string compcode, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkissue.chkissue_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("date1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("day", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = day;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = code;
                objOraclecommand.Parameters.Add(prm5);

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


        public DataSet insertcode(string edition, string issuecode, string compcode, string userid, string alias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("noissinsert.noissinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm5 = new OracleParameter("peditionalias", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
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

        public DataSet modifycode(string edition, string issuecode, string compcode, string userid, string alias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("noissmodify.noissmodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                //OracleParameter prm5 = new OracleParameter("peditionalias", OracleType.VarChar);
                //prm5.Direction = ParameterDirection.Input;
                //prm5.Value = alias;
                //objOraclecommand.Parameters.Add(prm5);

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


        public DataSet deletecode(string edition, string issuecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("noissdelete.noissdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
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

        public DataSet execode(string edition, string editionalias, string issuecode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("noissexe.noissexe_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("editionali", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = editionalias;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
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

        public DataSet fnplcode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("noissfnpl.noissfnpl_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
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

        public DataSet insertdate(string date, string noissueday, string issuecode, string compcode, string userid, string dateformat, string editioncd)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("dateinsert.dateinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("date1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy" && date != "" && date != null)
                {
                    string[] arr = date.Split('/');
                    string mm = arr[1];
                    string dd = arr[0];
                    string yy = arr[2];
                    date = mm + "/" + dd + "/" + yy;
                }

                prm5.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("noissueday", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = noissueday;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm15 = new OracleParameter("pextra1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = editioncd;
                objOraclecommand.Parameters.Add(prm15);

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




        public DataSet chkdate(string date, string noissueday, string issuecode, string edition_alias, string compcode, string userid, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkDateinsert.chkdateinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("date1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy" && date != "" && date != null)
                {
                    string[] arr = date.Split('/');
                    string mm = arr[1];
                    string dd = arr[0];
                    string yy = arr[2];
                    date = mm + "/" + dd + "/" + yy;
                }

                prm5.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("noissueday", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = noissueday;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("edition_ali", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = edition_alias;
                objOraclecommand.Parameters.Add(prm6);

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








        public DataSet chkdate1(string date, string noissueday, string issuecode, string compcode, string userid, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkDateinsert.chkdateinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("date1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy" && date != "" && date != null)
                {
                    //string[] arr = date.Split('/');
                    //string mm = arr[1];
                    //string dd = arr[0];
                    //string yy = arr[2];
                    //date = mm + "/" + dd + "/" + yy;
                }

                prm5.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("noissueday", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = noissueday;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
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






        public DataSet selectdate(string issuecode, string compcode, string userid, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("DATESELECT.DATESELECT_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
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

        public DataSet modifydate(string date, string noissueday, string issuecode, string compcode, string userid, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("datemodify.datemodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("date1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("noissueday", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = noissueday;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm6 = new OracleParameter("code", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = code;
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

        public DataSet deletedate(string issuecode, string compcode, string userid, string datecode)//,string code )
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("datedelete.datedelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("issuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = issuecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = datecode;
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

        public DataSet noissuecode(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("ISSUECODE_AUTO.ISSUECODE_AUTO_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 1)
                {
                    prm2.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;


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






        public DataSet nimbind(string noissuecode, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("no_is_date_bind.no_is_date_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("noissuecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noissuecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
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

        public DataSet pubcodechk(string str, string editioname)//, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("chkNoissuecode", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editioname", OracleType.VarChar, 20);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioname;
                cmd.Parameters.Add(prm2);

                cmd.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT2", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = cmd;
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



        public DataSet gridview(string compcode, string editioncode, string editionalias)//, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("executenoissuedate", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editioncode", OracleType.VarChar, 20);
                prm2.Direction = ParameterDirection.Input;
                if (editioncode == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {

                    prm2.Value = editioncode;
                }
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("no_edition_alias", OracleType.VarChar, 20);
                prm3.Direction = ParameterDirection.Input;
                if (editionalias == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {

                    prm3.Value = editionalias;
                }
                cmd.Parameters.Add(prm3);


                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
                //cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = cmd;
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