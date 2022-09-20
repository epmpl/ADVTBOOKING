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
    /// Summary description for AdvPositionTypMst
    /// </summary>
    public class AdvPositionTypMst:orclconnection
    {
        public AdvPositionTypMst()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet ModifyValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PositionTypeMstModify.PositionTypeMstModify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("PosType", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PosType;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6= new OracleParameter("premium", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premium;
                objOraclecommand.Parameters.Add(prm6);
              

                OracleParameter prm7 = new OracleParameter("amount1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = amount;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("p_fdate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("p_tdate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm10.Value = System.DBNull.Value;
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
                    prm10.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("p_adtype", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adtype;
                objOraclecommand.Parameters.Add(prm11);
              
                

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


        public DataSet chksave(string PosTypCode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PositionTypechk.PositionTypechk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);


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



        public DataSet delete1(string PosTypCode, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PositionTypedel.PositionTypedel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
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



        public DataSet InsertValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PositionTypeMstInsert.PositionTypeMstInsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PosType", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PosType;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premium;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("Amount", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (amount=="" || amount==null)
                {
                prm7.Value = "0".ToString ();
                }
                else
                {
                    prm7.Value = amount;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("p_fdate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("p_tdate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm10.Value = System.DBNull.Value;
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
                    prm10.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("p_adtype", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adtype;
                objOraclecommand.Parameters.Add(prm11);

                

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

        public DataSet SelectValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid,string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvPosTypeSelect.AdvPosTypeSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("PosType", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PosType;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (premium == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {

                    prm6.Value = premium;
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("Amount", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = amount;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_dateformat", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);

                objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;


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

        public DataSet Selectfnpl(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvPosTypefnpl.AdvPosTypefnpl_p", ref objOracleConnection);
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


        public DataSet pagenobind1(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pagenobind.pagenobind_p", ref objOracleConnection);
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


        public DataSet chkadvposition1(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkadvpostyp.chkadvpostyp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2) ;
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }


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
        //====================***************To check Name In That particular Time period************=================//
        public DataSet chkpastypename1(string PosTypCode, string PosTypName, string compcode, string userid, string fdate, string tdate, string flag, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PositionTypechknameindate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_PosTypCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_PosTypName", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = PosTypName;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("p_compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_flag", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = flag;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm9 = new OracleParameter("p_fdate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("p_tdate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm10.Value = System.DBNull.Value;
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
                    prm10.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);

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