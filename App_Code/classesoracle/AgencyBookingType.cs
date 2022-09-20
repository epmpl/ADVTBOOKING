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
/// <summary>
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.classesoracle
{

    public class AgencyBookingType : orclconnection
    {
        public AgencyBookingType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 //==============================================================//
        public DataSet savebkdata(string booktyp, string agency, string frmdate, string tdate, string dateformat, string usrid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("savebktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("booktyp", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booktyp;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("frmdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (frmdate == "" || frmdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("tdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("usrid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = usrid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet delbkdata(string compcode, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("delbktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("code11", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code11;
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
        public DataSet updbkdata(string booktyp, string agency, string frmdate, string tdate, string dateformat, string usrid, string compcode,string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updbktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("booktyp", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booktyp;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("frmdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (frmdate == "" || frmdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("tdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("usrid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = usrid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("code11", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = code11;
                objOraclecommand.Parameters.Add(prm7);

                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet chkdup(string booktyp, string agency, string frmdate, string tdate, string dateformat, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdupbktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("booktyp", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booktyp;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("frmdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (frmdate == "" || frmdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("tdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
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
        public DataSet chkdupdate(string booktyp, string agency, string frmdate, string tdate, string dateformat, string compcode,string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdupdatebktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("booktyp", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booktyp;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("frmdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (frmdate == "" || frmdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("tdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("code11", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = code11;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet findrec(string booktyp, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("findrecbktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("booktyp", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booktyp;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
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
        public DataSet bindcktyp(string compcode, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindbktype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("code11", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code11;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
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
    }
}
